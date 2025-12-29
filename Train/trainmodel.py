import numpy as np
import requests
import torch
import torch.nn as nn
from torch.utils.data import DataLoader, TensorDataset
import onnx
import onnxruntime as ort

SYMBOL = "BTCUSDT"
INTERVAL = "1d"
LIMIT = 1000
SEQUENCE_LENGTH = 50
EPOCHS = 30
BATCH_SIZE = 32
LEARNING_RATE = 0.001
HIDDEN_SIZE = 64
NUM_LAYERS = 2


class CryptoLSTM(nn.Module):
    def __init__(self, input_size=5, hidden_size=64, num_layers=2, output_size=1):
        super(CryptoLSTM, self).__init__()
        self.hidden_size = hidden_size
        self.num_layers = num_layers
        
        self.lstm = nn.LSTM(
            input_size=input_size,
            hidden_size=hidden_size,
            num_layers=num_layers,
            batch_first=True,
            dropout=0.2 if num_layers > 1 else 0
        )
        
        self.fc = nn.Sequential(
            nn.Linear(hidden_size, 32),
            nn.ReLU(),
            nn.Dropout(0.2),
            nn.Linear(32, output_size)
        )
    
    def forward(self, x):
        lstm_out, _ = self.lstm(x)
        last_output = lstm_out[:, -1, :]  # Son çıktıyı al
        prediction = self.fc(last_output)
        return prediction


def fetch_klines(symbol: str, interval: str, limit: int) -> np.ndarray:
    """Binance API'den mum verisi çek."""
    url = "https://api.binance.com/api/v3/klines"
    params = {
        "symbol": symbol,
        "interval": interval,
        "limit": limit
    }
    
    response = requests.get(url, params=params)
    response.raise_for_status()
    data = response.json()
    
    # OHLCV verisini çıkar
    klines = np.array([
        [
            float(candle[1]),  # Açılış
            float(candle[2]),  # Yüksek
            float(candle[3]),  # Düşük
            float(candle[4]),  # Kapanış
            float(candle[5])   # Hacim
        ]
        for candle in data
    ])
    
    return klines


def normalize_window(window: np.ndarray) -> tuple:
    """Pencereyi normalize et. İlk mumun kapanış fiyatını referans al."""
    price_ref = window[0, 3]
    
    # Fiyatları referansa göre normalize et
    normalized = window.copy()
    normalized[:, :4] = window[:, :4] / price_ref
    
    # Hacmi log ölçeğinde normalize et
    volume = window[:, 4]
    volume_log = np.log1p(volume)
    volume_min = volume_log.min()
    volume_max = volume_log.max()
    if volume_max > volume_min:
        normalized[:, 4] = (volume_log - volume_min) / (volume_max - volume_min)
    else:
        normalized[:, 4] = 0.5
    
    return normalized, price_ref


def prepare_data(klines: np.ndarray, sequence_length: int) -> tuple:
    """Eğitim verisini hazırla."""
    X = []
    y = []
    refs = []
    
    for i in range(len(klines) - sequence_length - 1):
        window = klines[i:i + sequence_length]
        normalized_window, price_ref = normalize_window(window)
        
        # Hedef: sonraki mumun normalize kapanış fiyatı
        next_close = klines[i + sequence_length, 3]
        normalized_target = next_close / price_ref
        
        X.append(normalized_window)
        y.append(normalized_target)
        refs.append(price_ref)
    
    return np.array(X), np.array(y), np.array(refs)


def train_model(X_train: np.ndarray, y_train: np.ndarray) -> CryptoLSTM:
    """LSTM modelini eğit."""
    device = torch.device("cuda" if torch.cuda.is_available() else "cpu")
    
    X_tensor = torch.FloatTensor(X_train).to(device)
    y_tensor = torch.FloatTensor(y_train).unsqueeze(1).to(device)
    
    dataset = TensorDataset(X_tensor, y_tensor)
    train_size = int(0.8 * len(dataset))
    val_size = len(dataset) - train_size
    train_dataset, val_dataset = torch.utils.data.random_split(dataset, [train_size, val_size])
    
    train_loader = DataLoader(train_dataset, batch_size=BATCH_SIZE, shuffle=True)
    val_loader = DataLoader(val_dataset, batch_size=BATCH_SIZE, shuffle=False)
    
    model = CryptoLSTM(
        input_size=5,
        hidden_size=HIDDEN_SIZE,
        num_layers=NUM_LAYERS,
        output_size=1
    ).to(device)
    
    criterion = nn.MSELoss()
    optimizer = torch.optim.Adam(model.parameters(), lr=LEARNING_RATE)
    scheduler = torch.optim.lr_scheduler.ReduceLROnPlateau(optimizer, patience=10, factor=0.5)
    
    best_val_loss = float('inf')
    best_model_state = None
    
    for epoch in range(EPOCHS):
        model.train()
        train_loss = 0.0
        for batch_X, batch_y in train_loader:
            optimizer.zero_grad()
            outputs = model(batch_X)
            loss = criterion(outputs, batch_y)
            loss.backward()
            torch.nn.utils.clip_grad_norm_(model.parameters(), max_norm=1.0)
            optimizer.step()
            train_loss += loss.item()
        
        train_loss /= len(train_loader)
        
        model.eval()
        val_loss = 0.0
        with torch.no_grad():
            for batch_X, batch_y in val_loader:
                outputs = model(batch_X)
                loss = criterion(outputs, batch_y)
                val_loss += loss.item()
        
        val_loss /= len(val_loader)
        scheduler.step(val_loss)
        
        if val_loss < best_val_loss:
            best_val_loss = val_loss
            best_model_state = model.state_dict().copy()
        
        if (epoch + 1) % 20 == 0:
            print(f"Epoch {epoch+1}/{EPOCHS} - Kayıp: {val_loss:.6f}")
    
    model.load_state_dict(best_model_state)
    print(f"En iyi kayıp: {best_val_loss:.6f}")
    
    return model


def export_to_onnx(model: CryptoLSTM, filepath: str):
    """Modeli ONNX formatına aktar."""
    model.eval()
    model.cpu()
    
    dummy_input = torch.randn(1, SEQUENCE_LENGTH, 5)
    
    torch.onnx.export(
        model,
        dummy_input,
        filepath,
        export_params=True,
        opset_version=14,
        do_constant_folding=True,
        input_names=['input'],
        output_names=['output'],
        dynamic_axes={
            'input': {0: 'batch_size'},
            'output': {0: 'batch_size'}
        }
    )
    
    onnx_model = onnx.load(filepath)
    onnx.checker.check_model(onnx_model)
    print(f"Model kaydedildi: {filepath}")


def test_onnx_model(filepath: str, X_test: np.ndarray, y_test: np.ndarray, refs: np.ndarray):
    """ONNX modelini test et."""
    session = ort.InferenceSession(filepath)
    indices = np.random.choice(len(X_test), min(3, len(X_test)), replace=False)
    
    print("\nTest Sonuçları:")
    for idx in indices:
        input_data = X_test[idx:idx+1].astype(np.float32)
        outputs = session.run(None, {'input': input_data})
        
        ref_price = refs[idx]
        predicted = outputs[0][0][0] * ref_price
        actual = y_test[idx] * ref_price
        error = abs(predicted - actual) / actual * 100
        
        print(f"  Tahmin: ${predicted:.2f} | Gerçek: ${actual:.2f} | Hata: %{error:.2f}")


def main():
    print(f"\n{SYMBOL} için veri çekiliyor...")
    klines = fetch_klines(SYMBOL, INTERVAL, LIMIT)
    print(f"{len(klines)} mum alındı")
    
    X, y, refs = prepare_data(klines, SEQUENCE_LENGTH)
    print(f"{len(X)} eğitim örneği hazırlandı")
    
    model = train_model(X, y)
    
    onnx_path = "crypto_lstm_model.onnx"
    export_to_onnx(model, onnx_path)
    test_onnx_model(onnx_path, X, y, refs)
    
    print("\nEğitim tamamlandı!")


if __name__ == "__main__":
    main()

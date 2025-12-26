using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace InvestAI.PredictAI
{
    public static class Predictor
    {
        private static readonly HttpClient _httpClient = new();
        private static InferenceSession? _session;
        private static readonly object _lock = new();
        private const int SequenceLength = 50;

        /// <summary>
        /// Predicts the next day's close price for the given cryptocurrency symbol.
        /// </summary>
        /// <param name="symbol">The trading pair symbol (e.g., "BTCUSDT", "ETHUSDT")</param>
        /// <returns>The predicted close price for the next day</returns>
        public static async Task<double> PredictAsync(string symbol)
        {
            EnsureSessionInitialized();

            // Fetch 50 daily candles from Binance API
            var url = $"https://api.binance.com/api/v3/klines?symbol={symbol}&interval=1d&limit={SequenceLength}";
            var response = await _httpClient.GetStringAsync(url);
            var jsonArray = JsonSerializer.Deserialize<JsonElement[]>(response)!;

            // Parse OHLCV data - use InvariantCulture to handle decimal points correctly
            var ohlcv = jsonArray.Select(c => new double[] {
                double.Parse(c[1].GetString()!, CultureInfo.InvariantCulture), // Open
                double.Parse(c[2].GetString()!, CultureInfo.InvariantCulture), // High
                double.Parse(c[3].GetString()!, CultureInfo.InvariantCulture), // Low
                double.Parse(c[4].GetString()!, CultureInfo.InvariantCulture), // Close
                double.Parse(c[5].GetString()!, CultureInfo.InvariantCulture)  // Volume
            }).ToArray();

            // Normalize using first candle's close as reference
            double refPrice = ohlcv[0][3];
            var volumeLog = ohlcv.Select(k => Math.Log(1 + k[4])).ToArray();
            double volMin = volumeLog.Min(), volMax = volumeLog.Max(), volRange = volMax - volMin;

            var input = new float[1, SequenceLength, 5];
            for (int i = 0; i < SequenceLength; i++)
            {
                input[0, i, 0] = (float)(ohlcv[i][0] / refPrice);
                input[0, i, 1] = (float)(ohlcv[i][1] / refPrice);
                input[0, i, 2] = (float)(ohlcv[i][2] / refPrice);
                input[0, i, 3] = (float)(ohlcv[i][3] / refPrice);
                input[0, i, 4] = volRange > 0 ? (float)((volumeLog[i] - volMin) / volRange) : 0.5f;
            }

            // Run inference
            var tensor = new DenseTensor<float>(input.Cast<float>().ToArray(), new[] { 1, SequenceLength, 5 });
            var inputs = new List<NamedOnnxValue> { NamedOnnxValue.CreateFromTensor("input", tensor) };
            
            using var results = _session!.Run(inputs);
            
            // Return denormalized prediction
            return results.First().AsTensor<float>()[0] * refPrice;
        }

        /// <summary>
        /// Gets the current price of a symbol.
        /// </summary>
        public static async Task<double> GetCurrentPriceAsync(string symbol)
        {
            var url = $"https://api.binance.com/api/v3/ticker/price?symbol={symbol}";
            var response = await _httpClient.GetStringAsync(url);
            var json = JsonSerializer.Deserialize<JsonElement>(response);
            return double.Parse(json.GetProperty("price").GetString()!, CultureInfo.InvariantCulture);
        }

        private static void EnsureSessionInitialized()
        {
            if (_session == null)
            {
                lock (_lock)
                {
                    if (_session == null)
                    {
                        string modelPath = GetModelPath();
                        _session = new InferenceSession(modelPath);
                    }
                }
            }
        }

        private static string GetModelPath()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            
            // Try multiple locations
            string[] possiblePaths = new[]
            {
                Path.Combine(baseDir, "PredictAI", "crypto_lstm_model.onnx"),
                Path.Combine(baseDir, "crypto_lstm_model.onnx"),
                Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..", "PredictAI", "crypto_lstm_model.onnx"))
            };

            foreach (var path in possiblePaths)
            {
                if (File.Exists(path))
                    return path;
            }

            throw new FileNotFoundException(
                $"ONNX model file not found. Searched paths:\n" +
                string.Join("\n", possiblePaths.Select((p, i) => $"{i + 1}. {p}")));
        }

        /// <summary>
        /// Disposes the ONNX session. Call this when the application is closing.
        /// </summary>
        public static void Dispose()
        {
            _session?.Dispose();
            _session = null;
        }
    }
}

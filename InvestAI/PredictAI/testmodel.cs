/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace CryptoLSTMTest
{
    class Program
    {
        private static readonly HttpClient _httpClient = new();
        private static InferenceSession? _session;
        private const int SequenceLength = 50;

        static async Task Main(string[] args)
        {
            _session = new InferenceSession("crypto_lstm_model.onnx");

            var symbols = new[] { "BTCUSDT", "ETHUSDT", "BNBUSDT", "SOLUSDT", "XRPUSDT" };

            foreach (var symbol in symbols)
            {
                var predictedPrice = await PredictNextClose(symbol);
                Console.WriteLine($"{symbol}: ${predictedPrice:N2}");
            }

            _session.Dispose();
        }

        static async Task<double> PredictNextClose(string symbol)
        {
            // Fetch 50 candles
            var url = $"https://api.binance.com/api/v3/klines?symbol={symbol}&interval=1d&limit={SequenceLength}";
            var response = await _httpClient.GetStringAsync(url);
            var jsonArray = JsonSerializer.Deserialize<JsonElement[]>(response)!;

            // Parse OHLCV data
            var ohlcv = jsonArray.Select(c => new double[] {
                double.Parse(c[1].GetString()!), // Open
                double.Parse(c[2].GetString()!), // High
                double.Parse(c[3].GetString()!), // Low
                double.Parse(c[4].GetString()!), // Close
                double.Parse(c[5].GetString()!)  // Volume
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
    }
}
*/
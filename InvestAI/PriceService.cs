using Binance.Net;
using Binance.Net.Clients;
using Binance.Net.Enums;
using CryptoExchange.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestAI
{
    // Fiyat çekme işlemleri
    internal class PriceService
    {
        private readonly BinanceRestClient _client;

        // create client
        public PriceService()
        {
            _client = new BinanceRestClient();
        }

        // get current price for a symbol
        public async Task<decimal?> GetCurrentPriceAsync(string symbol)
        {
            var result = await _client.SpotApi.ExchangeData.GetTickerAsync(symbol);
            if (!result.Success)
            {
                Console.WriteLine($"Error fetching price: {result.Error}");
                return null;
            }

            return result.Data.LastPrice;
        }

        //get top 50 most popular coins in the last 24h
        public async Task<List<(string Symbol, decimal Price, decimal Volume)>> GetTop50CoinsAsync()
        {
            var result = await _client.SpotApi.ExchangeData.GetTickersAsync();

            if (!result.Success)
            {
                return new List<(string, decimal, decimal)>();
            }

            return result.Data
                .Where(t => t.Symbol.EndsWith("USDT"))
                .OrderByDescending(t => t.QuoteVolume)  //sort by trade volume
                .Take(50)
                .Select(t => (t.Symbol, t.LastPrice, t.QuoteVolume))
                .ToList();
        }
        public async Task<List<ScottPlot.OHLC>> GetKlinesAsync(string symbol,KlineInterval interval,int limit)
        {
            var result=await _client.SpotApi.ExchangeData.GetKlinesAsync(symbol,interval,limit:limit);
            if (!result.Success) { return new List<ScottPlot.OHLC>(); }
            TimeSpan period = interval switch
            {
                KlineInterval.OneMinute => TimeSpan.FromMinutes(1),
                KlineInterval.FiveMinutes => TimeSpan.FromMinutes(5),
                KlineInterval.FifteenMinutes => TimeSpan.FromMinutes(15),
                KlineInterval.OneHour => TimeSpan.FromHours(1),
                KlineInterval.OneDay => TimeSpan.FromDays(1),
                _ => TimeSpan.FromMinutes(15)
            };

            return result.Data.Select(k => new ScottPlot.OHLC(
                (double)k.OpenPrice,
                (double)k.HighPrice,
                (double)k.LowPrice,
                (double)k.ClosePrice,
                k.OpenTime,
                period
            )).ToList();

        }
        
    }

}

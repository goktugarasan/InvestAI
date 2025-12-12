using Binance.Net;
using Binance.Net.Clients;
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
    }

}

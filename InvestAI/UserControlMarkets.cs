using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvestAI
{
    public partial class UserControlMarkets : UserControl
    {
        public event EventHandler<string> CoinSelected;

        public UserControlMarkets()
        {
            InitializeComponent();

            // Wire up the CellClick event in addition to CellContentClick
            cryptoGridView.CellClick += cryptoGridView_CellClick;
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                if (c is Button btn)
                {
                    btn.Click += async (s, e) => await HandleCoinSelection(btn.Text);
                }
            }
        }
        public async void LoadAllCoins()
        {
            cryptoGridView.Rows.Clear();

            var priceService = new PriceService();
            var topCoins = await priceService.GetTop50CoinsAsync();
            int rank = 1;
            foreach (var coin in topCoins)
            {
                var csymbol = coin.Symbol.Remove(coin.Symbol.LastIndexOf("USDT"));
                
                // Add() returns the row index - use it!
                int rowIndex = cryptoGridView.Rows.Add(rank, $"{csymbol}", $"${coin.Price}", "{change}", $"{coin.Volume}");
                
                // Store the full symbol (including USDT) in the Tag property
                cryptoGridView.Rows[rowIndex].Tag = coin.Symbol;
                
                rank++;
            }
        }

        public async void LoadFavoriteCoins(List<string> favoriteSymbols)
        {
            cryptoGridView.Rows.Clear();

            if (favoriteSymbols == null || favoriteSymbols.Count == 0)
            {
                return;
            }

            var priceService = new PriceService();
            int rank = 1;
            foreach (var symbol in favoriteSymbols)
            {
                var price = await priceService.GetCurrentPriceAsync(symbol);
                if (price.HasValue)
                {
                    var csymbol = symbol.Remove(symbol.LastIndexOf("USDT"));
                    int rowIndex = cryptoGridView.Rows.Add(rank, $"{csymbol}", $"${price.Value}", "{change}", "-");
                    cryptoGridView.Rows[rowIndex].Tag = symbol;
                    rank++;
                }
            }
        }

        public void RemoveCoinFromGrid(string symbol)
        {
            for (int i = cryptoGridView.Rows.Count - 1; i >= 0; i--)
            {
                var row = cryptoGridView.Rows[i];
                if (row.Tag as string == symbol)
                {
                    cryptoGridView.Rows.RemoveAt(i);
                    
                    for (int j = i; j < cryptoGridView.Rows.Count; j++)
                    {
                        cryptoGridView.Rows[j].Cells[0].Value = j + 1;
                    }
                    break;
                }
            }
        }

        private void stockGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void cryptoGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            await HandleCoinSelection("1 Day");
        }

        private async void cryptoGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            await HandleCoinSelection("1 Day");
        }

        private async Task HandleCoinSelection(string duration = "1 Day")
        {
            var currentRow = cryptoGridView.CurrentRow;

            if (currentRow == null || currentRow.Tag == null) return;

            string symbol = currentRow.Tag.ToString();

            (Binance.Net.Enums.KlineInterval interval, int limit) = duration switch
            {
                "1 Day" => (Binance.Net.Enums.KlineInterval.FifteenMinutes, 96),
                "5 Days" => (Binance.Net.Enums.KlineInterval.OneHour, 120),
                "1 Month" => (Binance.Net.Enums.KlineInterval.FourHour, 180),
                "6 Month" => (Binance.Net.Enums.KlineInterval.OneDay, 180),
                "1 Year" => (Binance.Net.Enums.KlineInterval.OneDay, 365),
                _ => (Binance.Net.Enums.KlineInterval.FifteenMinutes, 96)
            };

            var priceService = new PriceService();
            var ohlcs = await priceService.GetKlinesAsync(symbol, interval, limit);

            if (ohlcs != null && ohlcs.Any())
            {
                cryptoChart.Plot.Clear();
                var candles = cryptoChart.Plot.Add.Candlestick(ohlcs);
                cryptoChart.Plot.Axes.DateTimeTicksBottom();
                cryptoChart.Plot.Axes.AutoScale();
                cryptoChart.Plot.Title($"{symbol.Remove(symbol.LastIndexOf("USDT"))} ({duration})");
                cryptoChart.Refresh();
            }

            CoinSelected?.Invoke(this, symbol);
        }
    }
}

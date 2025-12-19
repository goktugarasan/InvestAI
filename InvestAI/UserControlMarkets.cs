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

        private void stockGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cryptoGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < cryptoGridView.Rows.Count)
            {
                var row = cryptoGridView.Rows[e.RowIndex];
                var symbol = row.Tag as string;

                if (!string.IsNullOrEmpty(symbol))
                {
                    CoinSelected?.Invoke(this, symbol);
                }
            }
        }

        private void cryptoGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < cryptoGridView.Rows.Count)
            {
                var row = cryptoGridView.Rows[e.RowIndex];
                var symbol = row.Tag as string;

                if (!string.IsNullOrEmpty(symbol))
                {
                    CoinSelected?.Invoke(this, symbol);
                }
            }
        }
    }
}

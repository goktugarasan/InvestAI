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
        public UserControlMarkets()
        {
            InitializeComponent();
            fillCoinGrid();
        }

        private async void fillCoinGrid()
        {
            cryptoGridView.Rows.Clear();

            var priceService = new PriceService();
            var topCoins = await priceService.GetTop50CoinsAsync();
            int rank = 1;
            foreach (var coin in topCoins)
            {
                var csymbol = coin.Symbol.Remove(coin.Symbol.LastIndexOf("USDT")); // coin symbol sonundan USDT'yi çıkarır
                //change % eklenmedi
                cryptoGridView.Rows.Add(rank, $"{csymbol}", $"${coin.Price}", "{change}", $"{coin.Volume}");
                rank++;
            }
        }

        private void stockGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cryptoGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

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
    public partial class Dashboard : Form
    {
        UserControlMarkets userControlMarkets = new UserControlMarkets();
        private JsonFavoritesService favoritesService = new JsonFavoritesService();
        private string selectedCoinSymbol;
        private bool isShowingFavorites = false;

        public Dashboard()
        {
            InitializeComponent();
            Username.Visible = false;

            // Subscribe to CoinSelected event
            userControlMarkets.CoinSelected += OnCoinSelected;
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
            signInButton.Visible = false;
            Username.Visible = true;
        }

        private void marketsButton_Click(object sender, EventArgs e)
        {
            isShowingFavorites = false;
            mainPanel.Controls.Clear();
            userControlMarkets = new UserControlMarkets();
            userControlMarkets.CoinSelected += OnCoinSelected;
            userControlMarkets.Dock = DockStyle.Fill;
            userControlMarkets.LoadAllCoins();
            mainPanel.Controls.Add(userControlMarkets);
            favoriteButton.Visible = false;
            selectedCoinSymbol = null;
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            isShowingFavorites = true;
            mainPanel.Controls.Clear();
            userControlMarkets = new UserControlMarkets();
            userControlMarkets.CoinSelected += OnCoinSelected;
            userControlMarkets.Dock = DockStyle.Fill;

            // Load only favorite coins
            var favorites = favoritesService.GetFavorites();
            userControlMarkets.LoadFavoriteCoins(favorites);

            mainPanel.Controls.Add(userControlMarkets);

            // Hide favorite button initially
            favoriteButton.Visible = false;
            selectedCoinSymbol = null;
        }

        private void OnCoinSelected(object sender, string symbol)
        {
            selectedCoinSymbol = symbol;

            // Show the favorite button
            favoriteButton.Visible = true;

            // Update button text based on whether coin is already favorited
            if (favoritesService.IsFavorite(symbol))
            {
                favoriteButton.Text = "Remove from Favorites";
            }
            else
            {
                favoriteButton.Text = "Add to Favorites";
            }
        }

        private void favoriteButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedCoinSymbol))
                return;

            if (favoritesService.IsFavorite(selectedCoinSymbol))
            {
                favoritesService.RemoveFavorite(selectedCoinSymbol);
                favoriteButton.Text = "Add to Favorites";

                if (isShowingFavorites)
                {
                    userControlMarkets.RemoveCoinFromGrid(selectedCoinSymbol);
                    favoriteButton.Visible = false;
                    selectedCoinSymbol = null;
                }
            }
            else
            {
                favoritesService.AddFavorite(selectedCoinSymbol);
                favoriteButton.Text = "Remove from Favorites";
            }
        }
    }
}


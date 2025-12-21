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

        // Premium Dark Theme Colors
        private readonly Color darkBackground = Color.FromArgb(12, 14, 18);
        private readonly Color cardBackground = Color.FromArgb(24, 27, 32);
        private readonly Color sidebarBackground = Color.FromArgb(20, 23, 28);
        private readonly Color accentBlue = Color.FromArgb(64, 150, 255);
        private readonly Color accentGreen = Color.FromArgb(52, 211, 153);
        private readonly Color accentRed = Color.FromArgb(239, 68, 68);
        private readonly Color buttonDefault = Color.FromArgb(48, 54, 64);
        private readonly Color buttonHover = Color.FromArgb(58, 65, 77);
        private readonly Color buttonActive = Color.FromArgb(64, 150, 255);
        private readonly Color textPrimary = Color.FromArgb(240, 244, 248);
        private readonly Color textSecondary = Color.FromArgb(156, 163, 175);

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19;
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

        [System.Runtime.InteropServices.DllImport("Gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        public Dashboard()
        {
            InitializeComponent();

            // Dark title bar (Windows 10/11)
            ApplyDarkTitleBar();

            ApplyModernTheme();
            userControlMarkets.CoinSelected += OnCoinSelected;
        }

        private void ApplyDarkTitleBar()
        {
            if (System.Environment.OSVersion.Version.Build >= 17763)
            {
                var attribute = DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1;
                if (System.Environment.OSVersion.Version.Build >= 18985)
                {
                    attribute = DWMWA_USE_IMMERSIVE_DARK_MODE;
                }

                int useImmersiveDarkMode = 1;
                DwmSetWindowAttribute(this.Handle, attribute, ref useImmersiveDarkMode, sizeof(int));
            }
        }

        private void ApplyModernTheme()
        {
            // Form - Deep dark background
            this.BackColor = Color.FromArgb(12, 14, 18);
            this.ForeColor = textPrimary;

            // Top Panel - Elevated glass card effect
            panel1.Height = 90;
            panel1.BackColor = Color.FromArgb(24, 27, 32);
            panel1.Padding = new Padding(25, 15, 25, 15);

            // Subtle gradient-like border at bottom
            panel1.Paint += (s, e) =>
            {
                using (Pen borderPen = new Pen(Color.FromArgb(40, 64, 150, 255), 1))
                {
                    e.Graphics.DrawLine(borderPen, 0, panel1.Height - 1, panel1.Width, panel1.Height - 1);
                }
            };

            // App Name - Premium gradient-like glow
            appName.ForeColor = Color.FromArgb(90, 170, 255);
            appName.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            appName.Location = new Point(25, 22);
            appName.AutoSize = true;

            // Favorite Button - Glassmorphism style
            favoriteButton.Size = new Size(200, 44);
            favoriteButton.Location = new Point(this.ClientSize.Width - 220, 23);
            favoriteButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            favoriteButton.FlatStyle = FlatStyle.Flat;
            favoriteButton.BackColor = accentGreen;
            favoriteButton.ForeColor = Color.White;
            favoriteButton.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            favoriteButton.FlatAppearance.BorderSize = 0;
            favoriteButton.Cursor = Cursors.Hand;
            MakeRounded(favoriteButton, 10);

            // Main Panel - Deep background
            mainPanel.BackColor = Color.FromArgb(12, 14, 18);
            mainPanel.Location = new Point(250, panel1.Height);
            mainPanel.Size = new Size(this.ClientSize.Width - 250, this.ClientSize.Height - panel1.Height);
            mainPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainPanel.Padding = new Padding(15);

            // Sidebar - Elevated card
            flowLayoutPanel1.BackColor = Color.FromArgb(20, 23, 28);
            flowLayoutPanel1.Location = new Point(0, panel1.Height);
            flowLayoutPanel1.Size = new Size(250, this.ClientSize.Height - panel1.Height);
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            flowLayoutPanel1.Padding = new Padding(15, 25, 15, 15);

            // Subtle border on right
            flowLayoutPanel1.Paint += (s, e) =>
            {
                using (Pen borderPen = new Pen(Color.FromArgb(30, 64, 150, 255), 1))
                {
                    e.Graphics.DrawLine(borderPen, flowLayoutPanel1.Width - 1, 0, flowLayoutPanel1.Width - 1, flowLayoutPanel1.Height);
                }
            };

            // Navigation Buttons - Premium cards
            StyleNavButton(homeButton, "🏠 ");
            StyleNavButton(marketsButton, "📊 ");

            // Resize handler
            this.Resize += (s, e) =>
            {
                if (favoriteButton != null)
                    favoriteButton.Location = new Point(this.ClientSize.Width - 220, 23);
                mainPanel.Size = new Size(this.ClientSize.Width - 250, this.ClientSize.Height - panel1.Height);
                flowLayoutPanel1.Size = new Size(250, this.ClientSize.Height - panel1.Height);
            };
        }

        private void StyleNavButton(Button btn, string icon)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.Transparent;
            btn.ForeColor = Color.FromArgb(140, 150, 165);
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(15, 10, 15, 10);

            string originalText = btn.Text.Replace("🏠", "").Replace("📊", "").Trim();
            btn.Text = $"{icon}{originalText}";

            MakeRounded(btn, 10);

            // Premium hover with smooth transition
            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = Color.FromArgb(35, 40, 48);
                btn.ForeColor = Color.FromArgb(255, 255, 255);
            };

            btn.MouseLeave += (s, e) =>
            {
                if (btn.BackColor != buttonActive)
                {
                    btn.BackColor = Color.Transparent;
                    btn.ForeColor = Color.FromArgb(140, 150, 165);
                }
            };

            // Active state with glow
            btn.Click += (s, e) =>
            {
                foreach (Control c in flowLayoutPanel1.Controls)
                {
                    if (c is Button navBtn && navBtn != btn)
                    {
                        navBtn.BackColor = Color.Transparent;
                        navBtn.ForeColor = Color.FromArgb(140, 150, 165);
                    }
                }
                btn.BackColor = Color.FromArgb(64, 150, 255);
                btn.ForeColor = Color.White;
            };
        }

        private void MakeRounded(Button btn, int radius)
        {
            btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn.Width, btn.Height, radius, radius));
            btn.Resize += (s, e) =>
            {
                btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn.Width, btn.Height, radius, radius));
            };
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
            var favorites = favoritesService.GetFavorites();
            userControlMarkets.LoadFavoriteCoins(favorites);
            mainPanel.Controls.Add(userControlMarkets);
            favoriteButton.Visible = false;
            selectedCoinSymbol = null;
        }

        private void OnCoinSelected(object sender, string symbol)
        {
            selectedCoinSymbol = symbol;
            favoriteButton.Visible = true;

            if (favoritesService.IsFavorite(symbol))
            {
                favoriteButton.Text = "★ Remove Favorite";
                favoriteButton.BackColor = accentRed;
            }
            else
            {
                favoriteButton.Text = "☆ Add Favorite";
                favoriteButton.BackColor = accentGreen;
            }
        }

        private void favoriteButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedCoinSymbol)) return;

            if (favoritesService.IsFavorite(selectedCoinSymbol))
            {
                favoritesService.RemoveFavorite(selectedCoinSymbol);
                favoriteButton.Text = "☆ Add Favorite";
                favoriteButton.BackColor = accentGreen;

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
                favoriteButton.Text = "★ Remove Favorite";
                favoriteButton.BackColor = accentRed;
            }
        }
        
    }
}


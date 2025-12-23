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
    public partial class Notifications : UserControl
    {
        private JsonNotifsService _notifsService;
        private JsonFavoritesService _favoritesService;
        private PriceService _priceService;
        private DataGridView _notificationsGrid;
        private DataGridView _favoritesGrid;
        private string _selectedSymbol;

        // Theme colors
        private readonly Color darkBg = Color.FromArgb(18, 20, 24);
        private readonly Color cardBg = Color.FromArgb(28, 32, 38);
        private readonly Color accentBlue = Color.FromArgb(64, 150, 255);
        private readonly Color textPrimary = Color.FromArgb(240, 244, 248);
        private readonly Color textSecondary = Color.FromArgb(156, 163, 175);
        private readonly Color profitGreen = Color.FromArgb(52, 211, 153);
        private readonly Color lossRed = Color.FromArgb(239, 68, 68);

        public Notifications()
        {
            InitializeComponent();
            _notifsService = new JsonNotifsService();
            _favoritesService = new JsonFavoritesService();
            _priceService = new PriceService();

            InitializeFavoritesGrid();
            InitializeNotificationsGrid();
            ApplyModernTheme();
            LoadFavorites();
            LoadNotifications();

            aboveRadio.Checked = true;
            symbolTextbox.Text = "Select a coin ?";
            symbolTextbox.ForeColor = textSecondary;
            symbolTextbox.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
            symbolTextbox.TextAlign = HorizontalAlignment.Center;
        }

        private void ApplyModernTheme()
        {
            this.BackColor = darkBg;
            splitContainer1.Panel1.BackColor = darkBg;
            splitContainer1.Panel2.BackColor = darkBg;
            splitContainer2.Panel1.BackColor = darkBg;
            splitContainer2.Panel2.BackColor = darkBg;
            splitContainer3.Panel1.BackColor = darkBg;
            splitContainer3.Panel2.BackColor = cardBg;

            label1.ForeColor = textPrimary;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Bold);

            label2.ForeColor = textPrimary;
            label2.Font = new Font("Segoe UI", 10.5F);

            label3.ForeColor = textSecondary;
            label3.Font = new Font("Segoe UI", 10.5F);

            label4.ForeColor = accentBlue;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            label5.ForeColor = textPrimary;
            label5.Font = new Font("Segoe UI", 14F, FontStyle.Bold);

            instructionLabel.BackColor = cardBg;
            instructionLabel.ForeColor = textSecondary;
            instructionLabel.Font = new Font("Segoe UI", 10F);

            StyleTextBox(symbolTextbox);
            StyleTextBox(priceTextbox);

            aboveRadio.ForeColor = textPrimary;
            aboveRadio.Font = new Font("Segoe UI", 10.5F);
            belowRadio.ForeColor = textPrimary;
            belowRadio.Font = new Font("Segoe UI", 10.5F);

            button1.FlatStyle = FlatStyle.Flat;
            button1.BackColor = accentBlue;
            button1.ForeColor = Color.White;
            button1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button1.FlatAppearance.BorderSize = 0;
            button1.Cursor = Cursors.Hand;

            button1.MouseEnter += (s, e) => button1.BackColor = Color.FromArgb(74, 160, 255);
            button1.MouseLeave += (s, e) => button1.BackColor = accentBlue;
        }

        private void StyleTextBox(TextBox textBox)
        {
            textBox.BackColor = Color.FromArgb(35, 40, 48);
            textBox.ForeColor = textPrimary;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Font = new Font("Segoe UI", 11F);
        }

        private void InitializeFavoritesGrid()
        {
            _favoritesGrid = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.FromArgb(18, 21, 26),
                ForeColor = textPrimary,
                Font = new Font("Segoe UI", 10F),
                GridColor = Color.FromArgb(35, 40, 48),
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                RowTemplate = { Height = 52 },
                ColumnHeadersHeight = 55,
                EnableHeadersVisualStyles = false,
                RowHeadersVisible = false,
                CellBorderStyle = DataGridViewCellBorderStyle.None
            };

            _favoritesGrid.Columns.Add("Symbol", "Coin");
            _favoritesGrid.Columns.Add("Price", "Price");
            _favoritesGrid.Columns.Add("Change", "Change %");
            _favoritesGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _favoritesGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _favoritesGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            _favoritesGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(28, 32, 38);
            _favoritesGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(220, 225, 235);
            _favoritesGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            _favoritesGrid.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 12, 12, 12);
            _favoritesGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            _favoritesGrid.DefaultCellStyle.SelectionBackColor = accentBlue;
            _favoritesGrid.DefaultCellStyle.SelectionForeColor = Color.White;
            _favoritesGrid.DefaultCellStyle.BackColor = Color.FromArgb(20, 23, 28);
            _favoritesGrid.DefaultCellStyle.ForeColor = textPrimary;
            _favoritesGrid.DefaultCellStyle.Padding = new Padding(12, 10, 12, 10);
            _favoritesGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(24, 27, 32);

            _favoritesGrid.CellClick += FavoritesGrid_CellClick;

            label5.Location = new Point(15, 15);
            label5.Size = new Size(label5.PreferredWidth, label5.PreferredHeight);
            label5.BringToFront();

            _favoritesGrid.Location = new Point(0, 75);
            _favoritesGrid.Size = new Size(splitContainer3.Panel1.Width, splitContainer3.Panel1.Height - 75);
            _favoritesGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            splitContainer3.Panel1.Controls.Add(_favoritesGrid);
            _favoritesGrid.SendToBack();
        }

        private void InitializeNotificationsGrid()
        {
            _notificationsGrid = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.FromArgb(18, 21, 26),
                ForeColor = textPrimary,
                Font = new Font("Segoe UI", 10F),
                GridColor = Color.FromArgb(35, 40, 48),
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                ReadOnly = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                RowTemplate = { Height = 52 },
                ColumnHeadersHeight = 55,
                EnableHeadersVisualStyles = false,
                RowHeadersVisible = false,
                CellBorderStyle = DataGridViewCellBorderStyle.None
            };

            _notificationsGrid.Columns.Add("Symbol", "Symbol");
            _notificationsGrid.Columns.Add("Condition", "Condition");
            _notificationsGrid.Columns.Add("TargetPrice", "Target Price");

            var deleteButtonColumn = new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "Action",
                Text = "Remove",
                UseColumnTextForButtonValue = true
            };
            _notificationsGrid.Columns.Add(deleteButtonColumn);

            _notificationsGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _notificationsGrid.Columns[0].FillWeight = 25;
            _notificationsGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _notificationsGrid.Columns[1].FillWeight = 30;
            _notificationsGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _notificationsGrid.Columns[2].FillWeight = 25;
            _notificationsGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _notificationsGrid.Columns[3].FillWeight = 20;

            _notificationsGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(28, 32, 38);
            _notificationsGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(220, 225, 235);
            _notificationsGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            _notificationsGrid.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 12, 12, 12);
            _notificationsGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            _notificationsGrid.DefaultCellStyle.SelectionBackColor = accentBlue;
            _notificationsGrid.DefaultCellStyle.SelectionForeColor = Color.White;
            _notificationsGrid.DefaultCellStyle.BackColor = Color.FromArgb(20, 23, 28);
            _notificationsGrid.DefaultCellStyle.ForeColor = textPrimary;
            _notificationsGrid.DefaultCellStyle.Padding = new Padding(12, 10, 12, 10);
            _notificationsGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(24, 27, 32);

            _notificationsGrid.CellClick += NotificationsGrid_CellClick;
            splitContainer1.Panel1.Controls.Add(_notificationsGrid);
        }

        private async void LoadFavorites()
        {
            _favoritesGrid.Rows.Clear();
            var favorites = _favoritesService.GetFavorites();

            if (favorites == null || favorites.Count == 0)
            {
                return;
            }

            foreach (var symbol in favorites)
            {
                try
                {
                    var priceData = await _priceService.GetCurrentPriceAsync(symbol);
                    if (priceData != null && priceData.Count > 0)
                    {
                        string displaySymbol = symbol.Replace("USDT", "");
                        decimal price = priceData[0];
                        decimal change = priceData[1];
                        string changeText = $"{change:F2}%";

                        int rowIndex = _favoritesGrid.Rows.Add(displaySymbol, $"${price:F2}", changeText);
                        _favoritesGrid.Rows[rowIndex].Tag = symbol;

                        if (change > 0)
                        {
                            _favoritesGrid.Rows[rowIndex].Cells[2].Value = $"+{changeText}";
                            _favoritesGrid.Rows[rowIndex].Cells[2].Style.ForeColor = profitGreen;
                            _favoritesGrid.Rows[rowIndex].Cells[2].Style.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                        }
                        else if (change < 0)
                        {
                            _favoritesGrid.Rows[rowIndex].Cells[2].Style.ForeColor = lossRed;
                            _favoritesGrid.Rows[rowIndex].Cells[2].Style.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading price for {symbol}: {ex.Message}");
                }
            }
        }

        private void FavoritesGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = _favoritesGrid.Rows[e.RowIndex];
            string symbol = row.Tag?.ToString();

            if (!string.IsNullOrEmpty(symbol))
            {
                _selectedSymbol = symbol;
                symbolTextbox.Text = symbol.Replace("USDT", "");
                symbolTextbox.ForeColor = accentBlue;
                symbolTextbox.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
                symbolTextbox.TextAlign = HorizontalAlignment.Center;
            }
        }

        private void LoadNotifications()
        {
            _notificationsGrid.Rows.Clear();
            var notifications = _notifsService.GetNotifications();

            foreach (var notif in notifications)
            {
                string condition = notif.isAbove ? "Goes Above" : "Goes Below";
                string symbol = notif.symbol.Replace("USDT", "");
                _notificationsGrid.Rows.Add(symbol, condition, $"${notif.targetPrice:F2}");
            }
        }

        private void NotificationsGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (_notificationsGrid.Columns[e.ColumnIndex].Name == "Delete")
            {
                var row = _notificationsGrid.Rows[e.RowIndex];
                string symbol = row.Cells[0].Value.ToString() + "USDT";
                string condition = row.Cells[1].Value.ToString();
                decimal targetPrice = decimal.Parse(row.Cells[2].Value.ToString().Replace("$", ""));

                var notif = new Notification
                {
                    symbol = symbol,
                    targetPrice = targetPrice,
                    isAbove = condition == "Goes Above"
                };

                _notifsService.RemoveNotif(notif);
                LoadNotifications();
                MessageBox.Show($"Notification removed for {symbol}", "Notification Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedSymbol))
            {
                MessageBox.Show("Please select a coin from your favorites first", "No Coin Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(priceTextbox.Text.Trim(), out decimal targetPrice) || targetPrice <= 0)
            {
                MessageBox.Show("Please enter a valid target price", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!aboveRadio.Checked && !belowRadio.Checked)
            {
                MessageBox.Show("Please select a condition (Above or Below)", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var notification = new Notification
            {
                symbol = _selectedSymbol,
                targetPrice = targetPrice,
                isAbove = aboveRadio.Checked
            };

            _notifsService.AddNotif(notification);
            LoadNotifications();

            priceTextbox.Clear();
            aboveRadio.Checked = true;
            symbolTextbox.Text = "Select a coin ?";
            symbolTextbox.ForeColor = textSecondary;
            symbolTextbox.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
            _selectedSymbol = null;

            string conditionText = notification.isAbove ? "above" : "below";
            MessageBox.Show($"Alert created!\n\nYou'll be notified when {notification.symbol.Replace("USDT", "")} goes {conditionText} ${targetPrice:F2}",
                "Notification Set", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                LoadFavorites();
                LoadNotifications();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void splitContainer3_Panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}

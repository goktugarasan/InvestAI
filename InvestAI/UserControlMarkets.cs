using CryptoExchange.Net;
using ScottPlot;
using ScottPlot.Plottables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvestAI
{
    public partial class UserControlMarkets : UserControl
    {
        public event EventHandler<string> CoinSelected;
        private List<ScottPlot.OHLC> _currentohlcs;
        private ScottPlot.Plottables.Text _chartdata;
        private ScottPlot.Plottables.Crosshair _crosshair;
        private ScottPlot.Plottables.Marker _marker;

        // Theme colors
        private readonly System.Drawing.Color darkBg = System.Drawing.Color.FromArgb(18, 20, 24);
        private readonly System.Drawing.Color cardBg = System.Drawing.Color.FromArgb(28, 32, 38);
        private readonly System.Drawing.Color gridBg = System.Drawing.Color.FromArgb(24, 27, 32);
        private readonly System.Drawing.Color gridAlt = System.Drawing.Color.FromArgb(32, 36, 42);
        private readonly System.Drawing.Color accentBlue = System.Drawing.Color.FromArgb(64, 150, 255);
        private readonly System.Drawing.Color btnDefault = System.Drawing.Color.FromArgb(48, 54, 64);
        private readonly System.Drawing.Color btnHover = System.Drawing.Color.FromArgb(58, 65, 77);
        private readonly System.Drawing.Color textPrimary = System.Drawing.Color.FromArgb(240, 244, 248);
        private readonly System.Drawing.Color textSecondary = System.Drawing.Color.FromArgb(156, 163, 175);
        private readonly System.Drawing.Color profitGreen = System.Drawing.Color.FromArgb(52, 211, 153);
        private readonly System.Drawing.Color lossRed = System.Drawing.Color.FromArgb(239, 68, 68);

        [System.Runtime.InteropServices.DllImport("Gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(int l, int t, int r, int b, int w, int h);

        public UserControlMarkets()
        {
            InitializeComponent();

            // Apply modern theme
            ApplyModernTheme();

            cryptoGridView.CellClick += cryptoGridView_CellClick;
            cryptoChart.MouseMove += cryptoChart_MouseMove;
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                if (c is Button btn)
                {
                    btn.Click += async (s, e) => await HandleCoinSelection(btn.Text);
                }
            }
        }

        private void ApplyModernTheme()
        {
            this.BackColor = darkBg;
            panel1.BackColor = darkBg;
            panel2.BackColor = darkBg;

            // Duration buttons panel - DÜZELTİLDİ
            flowLayoutPanel1.BackColor = cardBg;
            flowLayoutPanel1.Padding = new Padding(8, 6, 8, 6);
            flowLayoutPanel1.AutoSize = true; // AutoSize true yapıldı
            flowLayoutPanel1.WrapContents = true;
            flowLayoutPanel1.MinimumSize = new System.Drawing.Size(0, 40); // Minimum yükseklik

            foreach (Control c in flowLayoutPanel1.Controls)
            {
                if (c is Button btn) StyleDurationButton(btn);
            }

            // DataGridView
            StyleGrid();

            // Chart
            StyleChart();
        }

        private void StyleDurationButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = System.Drawing.Color.FromArgb(35, 40, 48);
            btn.ForeColor = System.Drawing.Color.FromArgb(140, 150, 165);
            btn.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.Padding = new Padding(10, 5, 10, 5);
            btn.AutoSize = true; // AutoSize true
            btn.MinimumSize = new System.Drawing.Size(70, 28); // Minimum boyut
            btn.Margin = new Padding(3, 2, 3, 2); // Margin eklendi

            btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn.Width, btn.Height, 8, 8));
            btn.Resize += (s, e) => btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn.Width, btn.Height, 8, 8));

            // Smooth premium hover
            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = System.Drawing.Color.FromArgb(48, 55, 65);
                btn.ForeColor = System.Drawing.Color.FromArgb(240, 245, 255);
            };

            btn.MouseLeave += (s, e) =>
            {
                if (btn.BackColor != accentBlue)
                {
                    btn.BackColor = System.Drawing.Color.FromArgb(35, 40, 48);
                    btn.ForeColor = System.Drawing.Color.FromArgb(140, 150, 165);
                }
            };

            // Premium active state
            btn.Click += (s, e) =>
            {
                foreach (Control c in flowLayoutPanel1.Controls)
                {
                    if (c is Button durationBtn && durationBtn != btn)
                    {
                        durationBtn.BackColor = System.Drawing.Color.FromArgb(35, 40, 48);
                        durationBtn.ForeColor = System.Drawing.Color.FromArgb(140, 150, 165);
                    }
                }
                btn.BackColor = accentBlue;
                btn.ForeColor = System.Drawing.Color.White;
            };
        }

        private void StyleGrid()
        {
            cryptoGridView.BackgroundColor = System.Drawing.Color.FromArgb(18, 21, 26);
            cryptoGridView.ForeColor = textPrimary;
            cryptoGridView.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            cryptoGridView.GridColor = System.Drawing.Color.FromArgb(35, 40, 48);
            cryptoGridView.BorderStyle = BorderStyle.None;
            cryptoGridView.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(64, 150, 255);
            cryptoGridView.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            cryptoGridView.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(20, 23, 28);
            cryptoGridView.DefaultCellStyle.ForeColor = textPrimary;
            cryptoGridView.DefaultCellStyle.Padding = new Padding(12, 8, 12, 8);
            cryptoGridView.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(24, 27, 32);
            cryptoGridView.RowTemplate.Height = 48;

            // Premium header with subtle gradient
            cryptoGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(28, 32, 38);
            cryptoGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(220, 225, 235);
            cryptoGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            cryptoGridView.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 10, 12, 10);
            cryptoGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            cryptoGridView.ColumnHeadersHeight = 50;
            cryptoGridView.EnableHeadersVisualStyles = false;
            cryptoGridView.RowHeadersVisible = false;
            cryptoGridView.CellBorderStyle = DataGridViewCellBorderStyle.None;

            // Subtle shadow line between rows
            cryptoGridView.RowPostPaint += (s, e) =>
            {
                using (Pen shadowPen = new Pen(System.Drawing.Color.FromArgb(15, 0, 0, 0), 1))
                {
                    e.Graphics.DrawLine(shadowPen,
                        e.RowBounds.Left,
                        e.RowBounds.Bottom - 1,
                        e.RowBounds.Right,
                        e.RowBounds.Bottom - 1);
                }
            };

            // Column widths
            if (cryptoGridView.Columns.Count >= 5)
            {
                cryptoGridView.Columns[0].Width = 90;
                cryptoGridView.Columns[0].MinimumWidth = 90;
                cryptoGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                cryptoGridView.Columns[1].Width = 110;
                cryptoGridView.Columns[1].MinimumWidth = 100;
                cryptoGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                cryptoGridView.Columns[2].Width = 160;
                cryptoGridView.Columns[2].MinimumWidth = 140;
                cryptoGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                cryptoGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                cryptoGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // User restrictions
            cryptoGridView.AllowUserToAddRows = false;
            cryptoGridView.AllowUserToDeleteRows = false;
            cryptoGridView.AllowUserToResizeRows = false;
            cryptoGridView.ReadOnly = true;
            cryptoGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            cryptoGridView.MultiSelect = false;
            cryptoGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            cryptoGridView.ScrollBars = ScrollBars.Vertical;
        }

        private void StyleChart()
        {
            cryptoChart.BackColor = System.Drawing.Color.FromArgb(20, 23, 28);
            var plot = cryptoChart.Plot;

            // Premium dark backgrounds
            plot.FigureBackground.Color = ScottPlot.Color.FromHex("#14171C");
            plot.DataBackground.Color = ScottPlot.Color.FromHex("#14171C");

            // Subtle glowing grid
            plot.Grid.MajorLineColor = ScottPlot.Color.FromHex("#252A32");
            plot.Grid.MinorLineColor = ScottPlot.Color.FromHex("#1A1D22");
            plot.Grid.MajorLineWidth = 1;

            // Ultra-readable text
            plot.Axes.Bottom.Label.ForeColor = ScottPlot.Color.FromHex("#E8EBF0");
            plot.Axes.Bottom.TickLabelStyle.ForeColor = ScottPlot.Color.FromHex("#B0B8C8");
            plot.Axes.Bottom.TickLabelStyle.FontSize = 11;

            // Right axis - prominent and bold
            plot.Axes.Right.Label.ForeColor = ScottPlot.Color.FromHex("#E8EBF0");
            plot.Axes.Right.TickLabelStyle.ForeColor = ScottPlot.Color.FromHex("#E8EBF0");
            plot.Axes.Right.TickLabelStyle.IsVisible = true;
            plot.Axes.Right.TickLabelStyle.FontSize = 13;
            plot.Axes.Right.TickLabelStyle.Bold = true;

            plot.Axes.Left.TickLabelStyle.IsVisible = false;
            plot.Axes.Left.FrameLineStyle.IsVisible = false;
            plot.Axes.Top.FrameLineStyle.IsVisible = false;

            // Premium title
            plot.Title("📊 Select a coin to view chart");

            // Glass-like legend
            plot.Legend.IsVisible = true;
            plot.Legend.BackgroundColor = ScottPlot.Color.FromHex("#1C2028");
            plot.Legend.OutlineColor = ScottPlot.Color.FromHex("#3A4250");
            plot.Legend.FontColor = ScottPlot.Color.FromHex("#E8EBF0");
            plot.Legend.FontSize = 12;
            plot.Legend.Alignment = Alignment.LowerRight;

            // Premium spacing
            plot.Layout.Fixed(new ScottPlot.PixelPadding(
                left: 75,
                right: 90,
                bottom: 130,
                top: 65
            ));
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

                string change = $"{coin.Change:F2}%";
                int rowIndex = cryptoGridView.Rows.Add(rank, $"{csymbol}", $"${coin.Price:N2}", change, $"{coin.Volume:N0}");

                cryptoGridView.Rows[rowIndex].Tag = coin.Symbol;

                if (coin.Change < 0)
                {
                    cryptoGridView.Rows[rowIndex].Cells[3].Style.ForeColor = lossRed;
                    cryptoGridView.Rows[rowIndex].Cells[3].Style.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
                }
                else if (coin.Change > 0)
                {
                    cryptoGridView.Rows[rowIndex].Cells[3].Value = $"+{change}";
                    cryptoGridView.Rows[rowIndex].Cells[3].Style.ForeColor = profitGreen;
                    cryptoGridView.Rows[rowIndex].Cells[3].Style.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
                }

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
                if (price.Count>0)
                {
                    var csymbol = symbol.Remove(symbol.LastIndexOf("USDT"));
                    int rowIndex = cryptoGridView.Rows.Add(rank, $"{csymbol}", $"${price[0]:F2}", $"{price[1]:F2}", $"{price[2]}");
                    cryptoGridView.Rows[rowIndex].Tag = symbol;
                    if (price[1] < 0)
                    {
                        cryptoGridView.Rows[rowIndex].Cells[3].Style.ForeColor = System.Drawing.Color.Red;
                    }
                    else if (price[1] > 0)
                    {
                        cryptoGridView.Rows[rowIndex].Cells[3].Value = $"+{price[1]}";
                        cryptoGridView.Rows[rowIndex].Cells[3].Style.ForeColor = System.Drawing.Color.Green;
                    }
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

        private void cryptoChart_MouseMove(object sender, MouseEventArgs e)
        {
            if (_currentohlcs == null || _currentohlcs.Count == 0 || _chartdata == null || _crosshair == null || _marker == null) return;

            Pixel pixel = new(e.X, e.Y);
            Coordinates coordinates = cryptoChart.Plot.GetCoordinates(pixel);
            OHLC closest = _currentohlcs.OrderBy(ohlc => Math.Abs(ScottPlot.NumericConversion.ToNumber(ohlc.DateTime) - coordinates.X)).FirstOrDefault();

            _chartdata.LabelText = $"DATE:{closest.DateTime:dd-MM-yyyy HH:mm} OPEN:{closest.Open:F2} HIGH:{closest.High:F2} LOW:{closest.Low:F2} CLOSE:{closest.Close:F2}";
            var limits = cryptoChart.Plot.Axes.GetLimits(cryptoChart.Plot.Axes.Bottom, cryptoChart.Plot.Axes.Right);
            _chartdata.Location = new Coordinates(limits.Left, limits.Top);

            if (closest.Close > closest.Open)
            {
                _chartdata.LabelFontColor = ScottPlot.Color.FromHex("#34D399");
            }
            else if (closest.Close < closest.Open)
            {
                _chartdata.LabelFontColor = ScottPlot.Color.FromHex("#EF4444");
            }
            else
            {
                _chartdata.LabelFontColor = ScottPlot.Color.FromHex("#F0F4F8");
            }

            Coordinates candlecoords = new Coordinates(closest.DateTime.ToOADate(), closest.Close);
            _crosshair.Position = candlecoords;
            _marker.Position = candlecoords;

            cryptoChart.Refresh();
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
                _currentohlcs = ohlcs;
                cryptoChart.Plot.Clear();
                double firstDate = ohlcs[0].DateTime.ToOADate();
                double firstPrice = (double)ohlcs[0].Close;

                _chartdata = cryptoChart.Plot.Add.Text("", firstDate, firstPrice);
                _chartdata.Axes.YAxis = cryptoChart.Plot.Axes.Right;
                _chartdata.LabelFontColor = ScottPlot.Color.FromHex("#F0F4F8");
                _chartdata.LabelFontSize = 18;
                _chartdata.LabelBold = true;
                _chartdata.Alignment = Alignment.UpperLeft;
                _chartdata.LabelBackgroundColor = ScottPlot.Color.FromHex("#1E2228");
                _chartdata.LabelBorderColor = ScottPlot.Color.FromHex("#2D323A");
                _chartdata.LabelBorderWidth = 1;

                var candles = cryptoChart.Plot.Add.Candlestick(ohlcs);
                candles.Axes.YAxis = cryptoChart.Plot.Axes.Right;

                double[] closePrices = ohlcs.Select(x => (double)x.Close).ToArray();
                double[] allDates = ohlcs.Select(x => x.DateTime.ToOADate()).ToArray();
                AddMovingAverage(closePrices, allDates, 20, ScottPlot.Colors.Yellow);
                AddMovingAverage(closePrices, allDates, 50, ScottPlot.Colors.Blue);

                cryptoChart.Plot.Axes.DateTimeTicksBottom();
                cryptoChart.Plot.Axes.AutoScale();

                // Sağdaki Y eksenini görünür ve BÜYÜK yap
                cryptoChart.Plot.Axes.Right.TickGenerator = new ScottPlot.TickGenerators.NumericAutomatic();
                cryptoChart.Plot.Axes.Right.TickLabelStyle.FontSize = 12;
                cryptoChart.Plot.Axes.Right.TickLabelStyle.Bold = true;
                cryptoChart.Plot.Axes.Right.TickLabelStyle.ForeColor = ScottPlot.Color.FromHex("#F0F4F8");

                // Alt taraftaki tarih fontlarını da büyüt
                cryptoChart.Plot.Axes.Bottom.TickLabelStyle.FontSize = 11;
                cryptoChart.Plot.Axes.Bottom.TickLabelStyle.ForeColor = ScottPlot.Color.FromHex("#F0F4F8");

                cryptoChart.Plot.Title($"{symbol.Remove(symbol.LastIndexOf("USDT"))} ({duration})");
                cryptoChart.Plot.Axes.Left.TickLabelStyle.IsVisible = false;
                cryptoChart.Plot.Axes.Left.FrameLineStyle.IsVisible = false;

                _crosshair = cryptoChart.Plot.Add.Crosshair(0, 0);
                _crosshair.Axes.YAxis = cryptoChart.Plot.Axes.Right;
                _crosshair.LineColor = ScottPlot.Colors.Gray;
                _crosshair.LineWidth = 1;
                _crosshair.LinePattern = LinePattern.Dashed;

                _marker = cryptoChart.Plot.Add.Marker(firstDate, firstPrice);
                _marker.Axes.YAxis = cryptoChart.Plot.Axes.Right;
                _marker.MarkerShape = MarkerShape.FilledCircle;
                _marker.Color = ScottPlot.Colors.Gray;
                _marker.LineWidth = 1;
                _marker.MarkerLineColor = ScottPlot.Colors.Gray;
                _marker.MarkerLineWidth = 8;

                cryptoChart.Refresh();
            }

            CoinSelected?.Invoke(this, symbol);
        }

        private void AddMovingAverage(double[] closePrices, double[] allDates, int windowSize, ScottPlot.Color color)
        {
            double[] maValues = ScottPlot.Statistics.Series.MovingAverage(closePrices, windowSize);
            double[] maDates = allDates.Skip(windowSize - 1).ToArray();
            var sp = cryptoChart.Plot.Add.Scatter(maDates, maValues);
            sp.Color = color;
            sp.LineWidth = 2;
            sp.MarkerSize = 0;
            sp.LegendText = $"MA{windowSize}";
            sp.Axes.YAxis = cryptoChart.Plot.Axes.Right;
        }
    }
}

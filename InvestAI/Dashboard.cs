using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InvestAI
{
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private async void Dashboard_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            var priceService = new PriceService();
            var price = await priceService.GetCurrentPriceAsync("BTCUSDT");
            button1.Enabled = true;

            dgv.Rows.Add("BTC", "$" + price.Value.ToString("F"), "TUT");
            dgv.Rows.Add("burger king", "3332", "AL");
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            
            dgv.Rows.Clear();
            // Ornek veri ekleme
            Dashboard_Load(sender, e);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

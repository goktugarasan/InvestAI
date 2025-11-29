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
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgv.Rows.Clear();
            // Ornek veri ekleme
            dgv.Rows.Add("BTC", "4398092", "AL");
            dgv.Rows.Add("burger king", "3332", "SAT");

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            dgv.Rows.Add("BTC", "1221", "TUT");
            dgv.Rows.Add("burger king", "3332", "AL");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

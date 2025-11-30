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
            cryptoGridView.Rows.Add("BTC", "91,365", "0.88", "37.47B");
            stockGridView.Rows.Add("NVDA", "177.00", "- 3.26", "121M");
        }

        private void stockGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

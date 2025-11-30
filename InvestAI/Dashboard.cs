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
        public Dashboard()
        {
            InitializeComponent();
            Username.Visible = false;
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
            mainPanel.Controls.Clear();
            userControlMarkets.Dock= DockStyle.Fill;
            mainPanel.Controls.Add(userControlMarkets);
        }
    }
}

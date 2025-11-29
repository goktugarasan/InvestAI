namespace InvestAI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void loadControl(UserControl uc)
        {
            mainPanel.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(uc);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadControl(new Dashboard());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            loadControl(new Dashboard());
        }

        private void notifsButton_Click(object sender, EventArgs e)
        {
            loadControl(new Notifications());
        }
    }
}

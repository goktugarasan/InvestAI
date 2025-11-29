namespace InvestAI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            RegisterScreen registerScreen = new RegisterScreen();
            registerScreen.ShowDialog();
            this.Close();

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

namespace InvestAI
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            Username = new Label();
            signInButton = new Button();
            appName = new Label();
            searchBar = new TextBox();
            panel2 = new Panel();
            walletButton = new Button();
            portfolioButton = new Button();
            marketsButton = new Button();
            homeButton = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(Username);
            panel1.Controls.Add(signInButton);
            panel1.Controls.Add(appName);
            panel1.Controls.Add(searchBar);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1271, 123);
            panel1.TabIndex = 0;
            // 
            // Username
            // 
            Username.AutoSize = true;
            Username.Location = new Point(1106, 88);
            Username.Name = "Username";
            Username.Size = new Size(121, 32);
            Username.TabIndex = 4;
            Username.Text = "Username";
            // 
            // signInButton
            // 
            signInButton.Location = new Point(1069, 40);
            signInButton.Name = "signInButton";
            signInButton.Size = new Size(135, 45);
            signInButton.TabIndex = 3;
            signInButton.Text = "Sign In";
            signInButton.UseVisualStyleBackColor = true;
            signInButton.Click += signInButton_Click;
            // 
            // appName
            // 
            appName.AutoSize = true;
            appName.Font = new Font("Segoe UI", 16F);
            appName.Location = new Point(91, 46);
            appName.Name = "appName";
            appName.Size = new Size(134, 45);
            appName.TabIndex = 2;
            appName.Text = "InvestAI";
            // 
            // searchBar
            // 
            searchBar.Location = new Point(307, 46);
            searchBar.Name = "searchBar";
            searchBar.Size = new Size(696, 39);
            searchBar.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(walletButton);
            panel2.Controls.Add(portfolioButton);
            panel2.Controls.Add(marketsButton);
            panel2.Controls.Add(homeButton);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 123);
            panel2.Name = "panel2";
            panel2.Size = new Size(225, 643);
            panel2.TabIndex = 1;
            // 
            // walletButton
            // 
            walletButton.Location = new Point(0, 388);
            walletButton.Name = "walletButton";
            walletButton.Size = new Size(228, 77);
            walletButton.TabIndex = 7;
            walletButton.Text = "Wallet";
            walletButton.UseVisualStyleBackColor = true;
            // 
            // portfolioButton
            // 
            portfolioButton.Location = new Point(0, 271);
            portfolioButton.Name = "portfolioButton";
            portfolioButton.Size = new Size(228, 77);
            portfolioButton.TabIndex = 6;
            portfolioButton.Text = "Portfolio";
            portfolioButton.UseVisualStyleBackColor = true;
            // 
            // marketsButton
            // 
            marketsButton.Location = new Point(-3, 153);
            marketsButton.Name = "marketsButton";
            marketsButton.Size = new Size(228, 77);
            marketsButton.TabIndex = 3;
            marketsButton.Text = "Markets";
            marketsButton.UseVisualStyleBackColor = true;
            // 
            // homeButton
            // 
            homeButton.Location = new Point(0, 40);
            homeButton.Name = "homeButton";
            homeButton.Size = new Size(225, 77);
            homeButton.TabIndex = 2;
            homeButton.Text = "Home";
            homeButton.UseVisualStyleBackColor = true;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1271, 766);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "Dashboard";
            Text = "InvestAI";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label appName;
        private Button signInButton;
        private TextBox searchBar;
        private Button marketsButton;
        private Button homeButton;
        private Button portfolioButton;
        private Label Username;
        private Button walletButton;
    }
}
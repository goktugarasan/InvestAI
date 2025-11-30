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
            mainPanel = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            homeButton = new Button();
            marketsButton = new Button();
            portfolioButton = new Button();
            walletButton = new Button();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
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
            Username.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Username.AutoSize = true;
            Username.Location = new Point(1150, 91);
            Username.Name = "Username";
            Username.Size = new Size(121, 32);
            Username.TabIndex = 4;
            Username.Text = "Username";
            // 
            // signInButton
            // 
            signInButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            signInButton.Location = new Point(1070, 40);
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
            // mainPanel
            // 
            mainPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainPanel.Location = new Point(225, 123);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1046, 643);
            mainPanel.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(homeButton);
            flowLayoutPanel1.Controls.Add(marketsButton);
            flowLayoutPanel1.Controls.Add(portfolioButton);
            flowLayoutPanel1.Controls.Add(walletButton);
            flowLayoutPanel1.Dock = DockStyle.Left;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 123);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(225, 643);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // homeButton
            // 
            homeButton.Location = new Point(3, 3);
            homeButton.Name = "homeButton";
            homeButton.Size = new Size(225, 77);
            homeButton.TabIndex = 2;
            homeButton.Text = "Home";
            homeButton.UseVisualStyleBackColor = true;
            // 
            // marketsButton
            // 
            marketsButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            marketsButton.Location = new Point(3, 86);
            marketsButton.Name = "marketsButton";
            marketsButton.Size = new Size(228, 77);
            marketsButton.TabIndex = 3;
            marketsButton.Text = "Markets";
            marketsButton.UseVisualStyleBackColor = true;
            marketsButton.Click += marketsButton_Click;
            // 
            // portfolioButton
            // 
            portfolioButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            portfolioButton.Location = new Point(3, 169);
            portfolioButton.Name = "portfolioButton";
            portfolioButton.Size = new Size(228, 77);
            portfolioButton.TabIndex = 6;
            portfolioButton.Text = "Portfolio";
            portfolioButton.UseVisualStyleBackColor = true;
            // 
            // walletButton
            // 
            walletButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            walletButton.Location = new Point(3, 252);
            walletButton.Name = "walletButton";
            walletButton.Size = new Size(228, 77);
            walletButton.TabIndex = 7;
            walletButton.Text = "Wallet";
            walletButton.UseVisualStyleBackColor = true;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1271, 766);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(mainPanel);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "Dashboard";
            Text = "InvestAI";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label appName;
        private Button signInButton;
        private TextBox searchBar;
        private Label Username;
        private Panel mainPanel;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button homeButton;
        private Button marketsButton;
        private Button portfolioButton;
        private Button walletButton;
    }
}
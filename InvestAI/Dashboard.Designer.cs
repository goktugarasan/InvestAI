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
            favoriteButton = new Button();
            appName = new Label();
            mainPanel = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            homeButton = new Button();
            marketsButton = new Button();
            notificationsButton = new Button();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(favoriteButton);
            panel1.Controls.Add(appName);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1271, 123);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // favoriteButton
            // 
            favoriteButton.BackColor = Color.LightSkyBlue;
            favoriteButton.Location = new Point(1020, 46);
            favoriteButton.Name = "favoriteButton";
            favoriteButton.Size = new Size(200, 45);
            favoriteButton.TabIndex = 5;
            favoriteButton.Text = "Add to Favorites";
            favoriteButton.UseVisualStyleBackColor = false;
            favoriteButton.Visible = false;
            favoriteButton.Click += favoriteButton_Click;
            // 
            // appName
            // 
            appName.AutoSize = true;
            appName.Font = new Font("Segoe UI", 16F);
            appName.Location = new Point(91, 46);
            appName.Name = "appName";
            appName.Size = new Size(175, 59);
            appName.TabIndex = 2;
            appName.Text = "InvestAI";
            // 
            // mainPanel
            // 
            mainPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainPanel.Location = new Point(237, 123);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1034, 643);
            mainPanel.TabIndex = 2;
            mainPanel.Paint += mainPanel_Paint;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(homeButton);
            flowLayoutPanel1.Controls.Add(marketsButton);
            flowLayoutPanel1.Controls.Add(notificationsButton);
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
            homeButton.Size = new Size(234, 160);
            homeButton.TabIndex = 2;
            homeButton.Text = "Home";
            homeButton.UseVisualStyleBackColor = true;
            homeButton.Click += homeButton_Click;
            // 
            // marketsButton
            // 
            marketsButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            marketsButton.Location = new Point(3, 169);
            marketsButton.Name = "marketsButton";
            marketsButton.Size = new Size(234, 167);
            marketsButton.TabIndex = 3;
            marketsButton.Text = "Markets";
            marketsButton.UseVisualStyleBackColor = true;
            marketsButton.Click += marketsButton_Click;
            // 
            // notificationsButton
            // 
            notificationsButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            notificationsButton.Location = new Point(3, 342);
            notificationsButton.Name = "notificationsButton";
            notificationsButton.Size = new Size(234, 167);
            notificationsButton.TabIndex = 4;
            notificationsButton.Text = "Notifications";
            notificationsButton.UseVisualStyleBackColor = true;
            notificationsButton.Click += notificationsButton_Click;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(18F, 45F);
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
        private Panel mainPanel;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button homeButton;
        private Button marketsButton;
        private Button favoriteButton;
        private Button notificationsButton;
    }
}

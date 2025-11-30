namespace InvestAI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainPanel = new Panel();
            bottomPanel = new Panel();
            notifsButton = new Button();
            dashboardButton = new Button();
            bottomPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(843, 429);
            mainPanel.TabIndex = 0;
            // 
            // bottomPanel
            // 
            bottomPanel.Controls.Add(notifsButton);
            bottomPanel.Controls.Add(dashboardButton);
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.Location = new Point(0, 429);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Size = new Size(843, 30);
            bottomPanel.TabIndex = 2;
            // 
            // notifsButton
            // 
            notifsButton.Location = new Point(509, 7);
            notifsButton.Name = "notifsButton";
            notifsButton.Size = new Size(171, 23);
            notifsButton.TabIndex = 1;
            notifsButton.Text = "Bildirimler";
            notifsButton.UseVisualStyleBackColor = true;
            notifsButton.Click += notifsButton_Click;
            // 
            // dashboardButton
            // 
            dashboardButton.Location = new Point(185, 7);
            dashboardButton.Name = "dashboardButton";
            dashboardButton.Size = new Size(159, 23);
            dashboardButton.TabIndex = 0;
            dashboardButton.Text = "Özetiniz";
            dashboardButton.UseVisualStyleBackColor = true;
            dashboardButton.Click += button1_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(843, 459);
            Controls.Add(mainPanel);
            Controls.Add(bottomPanel);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "InvestAI";
            Load += Form1_Load;
            bottomPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel mainPanel;
        private Panel bottomPanel;
        private Button notifsButton;
        private Button dashboardButton;

        #endregion

    }
}

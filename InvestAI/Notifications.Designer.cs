namespace InvestAI
{
    partial class Notifications
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notifications));
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            splitContainer3 = new SplitContainer();
            label5 = new Label();
            label4 = new Label();
            priceTextbox = new TextBox();
            label3 = new Label();
            symbolTextbox = new TextBox();
            label2 = new Label();
            aboveRadio = new RadioButton();
            belowRadio = new RadioButton();
            label1 = new Label();
            button1 = new Button();
            instructionLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(1761, 1050);
            splitContainer1.SplitterDistance = 587;
            splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(instructionLabel);
            splitContainer2.Size = new Size(1170, 1050);
            splitContainer2.SplitterDistance = 800;
            splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(0, 0);
            splitContainer3.Name = "splitContainer3";
            splitContainer3.Orientation = Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(label5);
            splitContainer3.Panel1.Padding = new Padding(0, 0, 0, 10);
            splitContainer3.Panel1.Paint += splitContainer3_Panel1_Paint;
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(label4);
            splitContainer3.Panel2.Controls.Add(priceTextbox);
            splitContainer3.Panel2.Controls.Add(label3);
            splitContainer3.Panel2.Controls.Add(symbolTextbox);
            splitContainer3.Panel2.Controls.Add(label2);
            splitContainer3.Panel2.Controls.Add(aboveRadio);
            splitContainer3.Panel2.Controls.Add(belowRadio);
            splitContainer3.Panel2.Controls.Add(label1);
            splitContainer3.Panel2.Controls.Add(button1);
            splitContainer3.Panel2.Padding = new Padding(15, 20, 15, 20);
            splitContainer3.Size = new Size(800, 1050);
            splitContainer3.SplitterDistance = 350;
            splitContainer3.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(15, 15);
            label5.Name = "label5";
            label5.Size = new Size(232, 45);
            label5.TabIndex = 0;
            label5.Text = "Your Favorites";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label4.Location = new Point(20, 400);
            label4.Name = "label4";
            label4.Size = new Size(35, 41);
            label4.TabIndex = 7;
            label4.Text = "$";
            label4.Click += label4_Click;
            // 
            // priceTextbox
            // 
            priceTextbox.Font = new Font("Segoe UI", 11F);
            priceTextbox.Location = new Point(58, 395);
            priceTextbox.Name = "priceTextbox";
            priceTextbox.Size = new Size(340, 47);
            priceTextbox.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.5F);
            label3.Location = new Point(20, 235);
            label3.Name = "label3";
            label3.Size = new Size(76, 38);
            label3.TabIndex = 5;
            label3.Text = "goes";
            // 
            // symbolTextbox
            // 
            symbolTextbox.Font = new Font("Segoe UI", 11F);
            symbolTextbox.Location = new Point(20, 150);
            symbolTextbox.Name = "symbolTextbox";
            symbolTextbox.ReadOnly = true;
            symbolTextbox.Size = new Size(380, 47);
            symbolTextbox.TabIndex = 4;
            symbolTextbox.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.5F);
            label2.Location = new Point(20, 110);
            label2.Name = "label2";
            label2.Size = new Size(165, 38);
            label2.TabIndex = 3;
            label2.Text = "The price of";
            // 
            // aboveRadio
            // 
            aboveRadio.AutoSize = true;
            aboveRadio.Font = new Font("Segoe UI", 10.5F);
            aboveRadio.Location = new Point(20, 285);
            aboveRadio.Name = "aboveRadio";
            aboveRadio.Size = new Size(126, 42);
            aboveRadio.TabIndex = 2;
            aboveRadio.TabStop = true;
            aboveRadio.Text = "Above";
            aboveRadio.UseVisualStyleBackColor = true;
            // 
            // belowRadio
            // 
            belowRadio.AutoSize = true;
            belowRadio.Font = new Font("Segoe UI", 10.5F);
            belowRadio.Location = new Point(170, 285);
            belowRadio.Name = "belowRadio";
            belowRadio.Size = new Size(122, 42);
            belowRadio.TabIndex = 2;
            belowRadio.TabStop = true;
            belowRadio.Text = "Below";
            belowRadio.UseVisualStyleBackColor = true;
            belowRadio.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(283, 45);
            label1.TabIndex = 1;
            label1.Text = "Create Price Alert";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button1.Location = new Point(20, 480);
            button1.Name = "button1";
            button1.Size = new Size(380, 55);
            button1.TabIndex = 0;
            button1.Text = "Set Notification";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // instructionLabel
            // 
            instructionLabel.Dock = DockStyle.Fill;
            instructionLabel.Font = new Font("Segoe UI", 11F);
            instructionLabel.Location = new Point(0, 0);
            instructionLabel.Name = "instructionLabel";
            instructionLabel.Padding = new Padding(20);
            instructionLabel.Size = new Size(366, 1050);
            instructionLabel.TabIndex = 0;
            instructionLabel.Text = resources.GetString("instructionLabel.Text");
            // 
            // Notifications
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "Notifications";
            Size = new Size(1761, 1050);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel1.PerformLayout();
            splitContainer3.Panel2.ResumeLayout(false);
            splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer3;
        private Button button1;
        private Label label2;
        private RadioButton aboveRadio;
        private RadioButton belowRadio;
        private Label label1;
        private Label label3;
        private TextBox symbolTextbox;
        private Label label4;
        private TextBox priceTextbox;
        private Label label5;
        private Label instructionLabel;
    }
}

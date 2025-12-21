namespace InvestAI
{
    partial class UserControlMarkets
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
            cryptoGridView = new DataGridView();
            CryptoColumn0 = new DataGridViewTextBoxColumn();
            CryptoColumn1 = new DataGridViewTextBoxColumn();
            CryptoColumn2 = new DataGridViewTextBoxColumn();
            CryptoColumn3 = new DataGridViewTextBoxColumn();
            CryptoColumn4 = new DataGridViewTextBoxColumn();
            cryptoChart = new ScottPlot.WinForms.FormsPlot();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            splitContainer1 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)cryptoGridView).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // cryptoGridView
            // 
            cryptoGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            cryptoGridView.Columns.AddRange(new DataGridViewColumn[] { CryptoColumn0, CryptoColumn1, CryptoColumn2, CryptoColumn3, CryptoColumn4 });
            cryptoGridView.Dock = DockStyle.Fill;
            cryptoGridView.Location = new Point(0, 0);
            cryptoGridView.Margin = new Padding(2);
            cryptoGridView.Name = "cryptoGridView";
            cryptoGridView.RowHeadersWidth = 62;
            cryptoGridView.Size = new Size(522, 878);
            cryptoGridView.TabIndex = 0;
            cryptoGridView.CellContentClick += cryptoGridView_CellContentClick;
            // 
            // CryptoColumn0
            // 
            CryptoColumn0.HeaderText = "Rank";
            CryptoColumn0.MinimumWidth = 6;
            CryptoColumn0.Name = "CryptoColumn0";
            CryptoColumn0.Width = 60;
            // 
            // CryptoColumn1
            // 
            CryptoColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            CryptoColumn1.HeaderText = "Coin";
            CryptoColumn1.MinimumWidth = 8;
            CryptoColumn1.Name = "CryptoColumn1";
            // 
            // CryptoColumn2
            // 
            CryptoColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            CryptoColumn2.HeaderText = "Price";
            CryptoColumn2.MinimumWidth = 8;
            CryptoColumn2.Name = "CryptoColumn2";
            // 
            // CryptoColumn3
            // 
            CryptoColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            CryptoColumn3.HeaderText = "Change";
            CryptoColumn3.MinimumWidth = 8;
            CryptoColumn3.Name = "CryptoColumn3";
            // 
            // CryptoColumn4
            // 
            CryptoColumn4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            CryptoColumn4.HeaderText = "Volume";
            CryptoColumn4.MinimumWidth = 8;
            CryptoColumn4.Name = "CryptoColumn4";
            // 
            // cryptoChart
            // 
            cryptoChart.DisplayScale = 1.5F;
            cryptoChart.Dock = DockStyle.Fill;
            cryptoChart.Location = new Point(0, 0);
            cryptoChart.Name = "cryptoChart";
            cryptoChart.Size = new Size(1042, 878);
            cryptoChart.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(button1);
            flowLayoutPanel1.Controls.Add(button2);
            flowLayoutPanel1.Controls.Add(button3);
            flowLayoutPanel1.Controls.Add(button4);
            flowLayoutPanel1.Controls.Add(button5);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1042, 63);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(131, 42);
            button1.TabIndex = 0;
            button1.Text = "1 Day";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(140, 3);
            button2.Name = "button2";
            button2.Size = new Size(131, 42);
            button2.TabIndex = 1;
            button2.Text = "5 Days";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(277, 3);
            button3.Name = "button3";
            button3.Size = new Size(131, 42);
            button3.TabIndex = 2;
            button3.Text = "1 Month";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(414, 3);
            button4.Name = "button4";
            button4.Size = new Size(131, 42);
            button4.TabIndex = 3;
            button4.Text = "6 Months";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(551, 3);
            button5.Name = "button5";
            button5.Size = new Size(131, 42);
            button5.TabIndex = 4;
            button5.Text = "1 Year";
            button5.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(cryptoGridView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(flowLayoutPanel1);
            splitContainer1.Panel2.Controls.Add(cryptoChart);
            splitContainer1.Size = new Size(1568, 878);
            splitContainer1.SplitterDistance = 522;
            splitContainer1.TabIndex = 7;
            // 
            // UserControlMarkets
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Margin = new Padding(2);
            Name = "UserControlMarkets";
            Size = new Size(1568, 878);
            ((System.ComponentModel.ISupportInitialize)cryptoGridView).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView cryptoGridView;
        private Label cryptoLabel;
        private Label stockLabel;
        private DataGridViewTextBoxColumn CryptoColumn0;
        private DataGridViewTextBoxColumn CryptoColumn1;
        private DataGridViewTextBoxColumn CryptoColumn2;
        private DataGridViewTextBoxColumn CryptoColumn3;
        private DataGridViewTextBoxColumn CryptoColumn4;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button1;
        private ScottPlot.WinForms.FormsPlot cryptoChart;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private SplitContainer splitContainer1;
    }
}

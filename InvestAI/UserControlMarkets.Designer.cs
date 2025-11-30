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
            CryptoColumn1 = new DataGridViewTextBoxColumn();
            CryptoColumn2 = new DataGridViewTextBoxColumn();
            CryptoColumn3 = new DataGridViewTextBoxColumn();
            CryptoColumn4 = new DataGridViewTextBoxColumn();
            stockGridView = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)cryptoGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)stockGridView).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // cryptoGridView
            // 
            cryptoGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            cryptoGridView.Columns.AddRange(new DataGridViewColumn[] { CryptoColumn1, CryptoColumn2, CryptoColumn3, CryptoColumn4 });
            cryptoGridView.Dock = DockStyle.Fill;
            cryptoGridView.Location = new Point(0, 0);
            cryptoGridView.Name = "cryptoGridView";
            cryptoGridView.RowHeadersWidth = 62;
            cryptoGridView.Size = new Size(788, 877);
            cryptoGridView.TabIndex = 0;
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
            // stockGridView
            // 
            stockGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            stockGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            stockGridView.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            stockGridView.Dock = DockStyle.Fill;
            stockGridView.Location = new Point(0, 0);
            stockGridView.Name = "stockGridView";
            stockGridView.RowHeadersWidth = 62;
            stockGridView.Size = new Size(780, 877);
            stockGridView.TabIndex = 4;
            stockGridView.CellContentClick += stockGridView_CellContentClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn1.HeaderText = "Stock";
            dataGridViewTextBoxColumn1.MinimumWidth = 8;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn2.HeaderText = "Price";
            dataGridViewTextBoxColumn2.MinimumWidth = 8;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn3.HeaderText = "Change";
            dataGridViewTextBoxColumn3.MinimumWidth = 8;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn4.HeaderText = "Volume";
            dataGridViewTextBoxColumn4.MinimumWidth = 8;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // panel1
            // 
            panel1.Controls.Add(cryptoGridView);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(788, 877);
            panel1.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.Controls.Add(stockGridView);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(788, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(780, 877);
            panel2.TabIndex = 6;
            // 
            // UserControlMarkets
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "UserControlMarkets";
            Size = new Size(1568, 877);
            ((System.ComponentModel.ISupportInitialize)cryptoGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)stockGridView).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView cryptoGridView;
        private Label cryptoLabel;
        private Label stockLabel;
        private DataGridViewTextBoxColumn CryptoColumn1;
        private DataGridViewTextBoxColumn CryptoColumn2;
        private DataGridViewTextBoxColumn CryptoColumn3;
        private DataGridViewTextBoxColumn CryptoColumn4;
        private DataGridView stockGridView;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private Panel panel1;
        private Panel panel2;
    }
}

namespace UiStoreWatchdog
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.rbOnline = new System.Windows.Forms.RadioButton();
            this.rbOffline = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Ubiquiti Store Watchdog";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // rbOnline
            // 
            this.rbOnline.AutoSize = true;
            this.rbOnline.Location = new System.Drawing.Point(21, 12);
            this.rbOnline.Name = "rbOnline";
            this.rbOnline.Size = new System.Drawing.Size(52, 19);
            this.rbOnline.TabIndex = 1;
            this.rbOnline.Text = "Aktiv";
            this.rbOnline.UseVisualStyleBackColor = true;
            this.rbOnline.CheckedChanged += new System.EventHandler(this.rbOnline_CheckedChanged);
            // 
            // rbOffline
            // 
            this.rbOffline.AutoSize = true;
            this.rbOffline.Checked = true;
            this.rbOffline.Location = new System.Drawing.Point(79, 12);
            this.rbOffline.Name = "rbOffline";
            this.rbOffline.Size = new System.Drawing.Size(62, 19);
            this.rbOffline.TabIndex = 2;
            this.rbOffline.TabStop = true;
            this.rbOffline.Text = "Ej aktiv";
            this.rbOffline.UseVisualStyleBackColor = true;
            this.rbOffline.CheckedChanged += new System.EventHandler(this.rbOffline_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colUrl,
            this.colActive});
            this.dataGridView1.Location = new System.Drawing.Point(12, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(776, 179);
            this.dataGridView1.TabIndex = 3;
            // 
            // colName
            // 
            this.colName.HeaderText = "Namn";
            this.colName.Name = "colName";
            // 
            // colUrl
            // 
            this.colUrl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colUrl.HeaderText = "Url";
            this.colUrl.Name = "colUrl";
            // 
            // colActive
            // 
            this.colActive.HeaderText = "Aktiv";
            this.colActive.Name = "colActive";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Timer intervall (s)";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(268, 12);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 228);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.rbOffline);
            this.Controls.Add(this.rbOnline);
            this.Name = "frmMain";
            this.Text = "Ubiquity Shop Watchdog";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer timer1;
        private RadioButton rbOnline;
        private RadioButton rbOffline;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colUrl;
        private DataGridViewCheckBoxColumn colActive;
        private Label label1;
        private NumericUpDown numericUpDown1;
    }
}
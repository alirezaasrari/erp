namespace ET
{
    partial class Frm_Senni_Ras_Check
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CTafsili = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NTafsili = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ras_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mablagh_kol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCalc = new System.Windows.Forms.Button();
            this.btnExcell = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.rdbtnMoshtarekin = new System.Windows.Forms.RadioButton();
            this.rdbtnKhareji = new System.Windows.Forms.RadioButton();
            this.rdbtnKhososi = new System.Windows.Forms.RadioButton();
            this.rdbtnDolati = new System.Windows.Forms.RadioButton();
            this.txtTafsili = new System.Windows.Forms.TextBox();
            this.chkTafsili = new System.Windows.Forms.CheckBox();
            this.btnReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CTafsili,
            this.NTafsili,
            this.Ras_date,
            this.Mablagh_kol});
            this.dataGridView1.Location = new System.Drawing.Point(22, 135);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(641, 353);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.TabStop = false;
            // 
            // CTafsili
            // 
            this.CTafsili.DataPropertyName = "CTafsili";
            this.CTafsili.HeaderText = "کد تفصیلی";
            this.CTafsili.Name = "CTafsili";
            this.CTafsili.Width = 80;
            // 
            // NTafsili
            // 
            this.NTafsili.DataPropertyName = "NTafsili";
            this.NTafsili.HeaderText = "نام تفصیلی";
            this.NTafsili.Name = "NTafsili";
            this.NTafsili.Width = 300;
            // 
            // Ras_date
            // 
            this.Ras_date.DataPropertyName = "Ras_date";
            this.Ras_date.HeaderText = "تاریخ راس";
            this.Ras_date.Name = "Ras_date";
            // 
            // Mablagh_kol
            // 
            this.Mablagh_kol.DataPropertyName = "Mablagh_kol";
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = "0";
            this.Mablagh_kol.DefaultCellStyle = dataGridViewCellStyle1;
            this.Mablagh_kol.HeaderText = "مبلغ کل";
            this.Mablagh_kol.Name = "Mablagh_kol";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnCalc);
            this.groupBox1.Controls.Add(this.btnExcell);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.rdbtnMoshtarekin);
            this.groupBox1.Controls.Add(this.rdbtnKhareji);
            this.groupBox1.Controls.Add(this.rdbtnKhososi);
            this.groupBox1.Controls.Add(this.rdbtnDolati);
            this.groupBox1.Controls.Add(this.txtTafsili);
            this.groupBox1.Controls.Add(this.chkTafsili);
            this.groupBox1.Controls.Add(this.btnReport);
            this.groupBox1.Location = new System.Drawing.Point(24, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(641, 115);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // btnCalc
            // 
            this.btnCalc.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnCalc.Location = new System.Drawing.Point(112, 27);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(81, 32);
            this.btnCalc.TabIndex = 6;
            this.btnCalc.Text = "محاسبه";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // btnExcell
            // 
            this.btnExcell.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnExcell.Location = new System.Drawing.Point(25, 27);
            this.btnExcell.Name = "btnExcell";
            this.btnExcell.Size = new System.Drawing.Size(81, 32);
            this.btnExcell.TabIndex = 8;
            this.btnExcell.Text = "Excell";
            this.btnExcell.UseVisualStyleBackColor = true;
            this.btnExcell.Click += new System.EventHandler(this.btnExcell_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnExit.Location = new System.Drawing.Point(25, 65);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(81, 32);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // rdbtnMoshtarekin
            // 
            this.rdbtnMoshtarekin.AutoSize = true;
            this.rdbtnMoshtarekin.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rdbtnMoshtarekin.Location = new System.Drawing.Point(356, 51);
            this.rdbtnMoshtarekin.Name = "rdbtnMoshtarekin";
            this.rdbtnMoshtarekin.Size = new System.Drawing.Size(65, 17);
            this.rdbtnMoshtarekin.TabIndex = 3;
            this.rdbtnMoshtarekin.Text = "مشترکین";
            this.rdbtnMoshtarekin.UseVisualStyleBackColor = true;
            // 
            // rdbtnKhareji
            // 
            this.rdbtnKhareji.AutoSize = true;
            this.rdbtnKhareji.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rdbtnKhareji.Location = new System.Drawing.Point(323, 19);
            this.rdbtnKhareji.Name = "rdbtnKhareji";
            this.rdbtnKhareji.Size = new System.Drawing.Size(96, 17);
            this.rdbtnKhareji.TabIndex = 2;
            this.rdbtnKhareji.Text = "مشتریان خارجی";
            this.rdbtnKhareji.UseVisualStyleBackColor = true;
            // 
            // rdbtnKhososi
            // 
            this.rdbtnKhososi.AutoSize = true;
            this.rdbtnKhososi.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rdbtnKhososi.Location = new System.Drawing.Point(519, 51);
            this.rdbtnKhososi.Name = "rdbtnKhososi";
            this.rdbtnKhososi.Size = new System.Drawing.Size(107, 17);
            this.rdbtnKhososi.TabIndex = 1;
            this.rdbtnKhososi.Text = "مشتریان خصوصی";
            this.rdbtnKhososi.UseVisualStyleBackColor = true;
            // 
            // rdbtnDolati
            // 
            this.rdbtnDolati.AutoSize = true;
            this.rdbtnDolati.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rdbtnDolati.Location = new System.Drawing.Point(532, 19);
            this.rdbtnDolati.Name = "rdbtnDolati";
            this.rdbtnDolati.Size = new System.Drawing.Size(96, 17);
            this.rdbtnDolati.TabIndex = 0;
            this.rdbtnDolati.Text = "مشتریان دولتی";
            this.rdbtnDolati.UseVisualStyleBackColor = true;
            // 
            // txtTafsili
            // 
            this.txtTafsili.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtTafsili.Location = new System.Drawing.Point(444, 86);
            this.txtTafsili.Name = "txtTafsili";
            this.txtTafsili.Size = new System.Drawing.Size(100, 22);
            this.txtTafsili.TabIndex = 5;
            this.txtTafsili.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTafsili_KeyDown);
            // 
            // chkTafsili
            // 
            this.chkTafsili.AutoSize = true;
            this.chkTafsili.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.chkTafsili.Location = new System.Drawing.Point(550, 87);
            this.chkTafsili.Name = "chkTafsili";
            this.chkTafsili.Size = new System.Drawing.Size(79, 17);
            this.chkTafsili.TabIndex = 4;
            this.chkTafsili.Text = "کد تفصیلی";
            this.chkTafsili.UseVisualStyleBackColor = true;
            this.chkTafsili.CheckedChanged += new System.EventHandler(this.chkTafsili_CheckedChanged);
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnReport.Location = new System.Drawing.Point(112, 65);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(81, 32);
            this.btnReport.TabIndex = 7;
            this.btnReport.Text = "نمایش";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // Frm_Senni_Ras_Check
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(684, 502);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Frm_Senni_Ras_Check";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "راس چک";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_Senni_Ras_Check_FormClosed);
            this.Load += new System.EventHandler(this.Frm_Ras_Check_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTafsili;
        private System.Windows.Forms.CheckBox chkTafsili;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.RadioButton rdbtnMoshtarekin;
        private System.Windows.Forms.RadioButton rdbtnKhareji;
        private System.Windows.Forms.RadioButton rdbtnKhososi;
        private System.Windows.Forms.RadioButton rdbtnDolati;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnExcell;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTafsili;
        private System.Windows.Forms.DataGridViewTextBoxColumn NTafsili;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ras_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mablagh_kol;
        private System.Windows.Forms.Button btnCalc;
    }
}
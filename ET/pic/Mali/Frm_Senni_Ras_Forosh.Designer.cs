namespace ET
{
    partial class Frm_Senni_Ras_Forosh
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.radif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTafsili = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NTafsili = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ras_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mablagh_kol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExcell = new System.Windows.Forms.Button();
            this.rdbtnMoshtarekin = new System.Windows.Forms.RadioButton();
            this.rdbtnKhareji = new System.Windows.Forms.RadioButton();
            this.rdbtnKhososi = new System.Windows.Forms.RadioButton();
            this.rdbtnDolati = new System.Windows.Forms.RadioButton();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtTafsili = new System.Windows.Forms.TextBox();
            this.chkTafsili = new System.Windows.Forms.CheckBox();
            this.btnReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.radif,
            this.CTafsili,
            this.NTafsili,
            this.Ras_Date,
            this.mablagh_kol});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Location = new System.Drawing.Point(22, 135);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(641, 353);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.TabStop = false;
            // 
            // radif
            // 
            this.radif.DataPropertyName = "radif";
            this.radif.HeaderText = "ردیف";
            this.radif.Name = "radif";
            this.radif.Width = 40;
            // 
            // CTafsili
            // 
            this.CTafsili.DataPropertyName = "CTafsili";
            this.CTafsili.HeaderText = "کد مشتری";
            this.CTafsili.Name = "CTafsili";
            this.CTafsili.Width = 50;
            // 
            // NTafsili
            // 
            this.NTafsili.DataPropertyName = "NTafsili";
            this.NTafsili.HeaderText = "نام مشتری";
            this.NTafsili.Name = "NTafsili";
            this.NTafsili.Width = 300;
            // 
            // Ras_Date
            // 
            this.Ras_Date.DataPropertyName = "Ras_Date";
            this.Ras_Date.HeaderText = "تاریخ راس";
            this.Ras_Date.Name = "Ras_Date";
            this.Ras_Date.Width = 110;
            // 
            // mablagh_kol
            // 
            this.mablagh_kol.DataPropertyName = "mablagh_kol";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = "0";
            this.mablagh_kol.DefaultCellStyle = dataGridViewCellStyle2;
            this.mablagh_kol.HeaderText = "مبلغ کل";
            this.mablagh_kol.Name = "mablagh_kol";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnExcell);
            this.groupBox1.Controls.Add(this.rdbtnMoshtarekin);
            this.groupBox1.Controls.Add(this.rdbtnKhareji);
            this.groupBox1.Controls.Add(this.rdbtnKhososi);
            this.groupBox1.Controls.Add(this.rdbtnDolati);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.txtTafsili);
            this.groupBox1.Controls.Add(this.chkTafsili);
            this.groupBox1.Controls.Add(this.btnReport);
            this.groupBox1.Location = new System.Drawing.Point(24, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(641, 115);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnExcell
            // 
            this.btnExcell.Location = new System.Drawing.Point(25, 19);
            this.btnExcell.Name = "btnExcell";
            this.btnExcell.Size = new System.Drawing.Size(82, 33);
            this.btnExcell.TabIndex = 7;
            this.btnExcell.Text = "Excell";
            this.btnExcell.UseVisualStyleBackColor = true;
            this.btnExcell.Click += new System.EventHandler(this.btnExcell_Click);
            // 
            // rdbtnMoshtarekin
            // 
            this.rdbtnMoshtarekin.AutoSize = true;
            this.rdbtnMoshtarekin.Location = new System.Drawing.Point(346, 50);
            this.rdbtnMoshtarekin.Name = "rdbtnMoshtarekin";
            this.rdbtnMoshtarekin.Size = new System.Drawing.Size(65, 17);
            this.rdbtnMoshtarekin.TabIndex = 3;
            this.rdbtnMoshtarekin.TabStop = true;
            this.rdbtnMoshtarekin.Text = "مشترکین";
            this.rdbtnMoshtarekin.UseVisualStyleBackColor = true;
            // 
            // rdbtnKhareji
            // 
            this.rdbtnKhareji.AutoSize = true;
            this.rdbtnKhareji.Location = new System.Drawing.Point(313, 21);
            this.rdbtnKhareji.Name = "rdbtnKhareji";
            this.rdbtnKhareji.Size = new System.Drawing.Size(96, 17);
            this.rdbtnKhareji.TabIndex = 2;
            this.rdbtnKhareji.TabStop = true;
            this.rdbtnKhareji.Text = "مشتریان خارجی";
            this.rdbtnKhareji.UseVisualStyleBackColor = true;
            // 
            // rdbtnKhososi
            // 
            this.rdbtnKhososi.AutoSize = true;
            this.rdbtnKhososi.Location = new System.Drawing.Point(508, 50);
            this.rdbtnKhososi.Name = "rdbtnKhososi";
            this.rdbtnKhososi.Size = new System.Drawing.Size(107, 17);
            this.rdbtnKhososi.TabIndex = 1;
            this.rdbtnKhososi.TabStop = true;
            this.rdbtnKhososi.Text = "مشتریان خصوصی";
            this.rdbtnKhososi.UseVisualStyleBackColor = true;
            // 
            // rdbtnDolati
            // 
            this.rdbtnDolati.AutoSize = true;
            this.rdbtnDolati.Location = new System.Drawing.Point(521, 21);
            this.rdbtnDolati.Name = "rdbtnDolati";
            this.rdbtnDolati.Size = new System.Drawing.Size(96, 17);
            this.rdbtnDolati.TabIndex = 0;
            this.rdbtnDolati.TabStop = true;
            this.rdbtnDolati.Text = "مشتریان دولتی";
            this.rdbtnDolati.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(112, 58);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(82, 33);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtTafsili
            // 
            this.txtTafsili.Location = new System.Drawing.Point(433, 82);
            this.txtTafsili.Name = "txtTafsili";
            this.txtTafsili.Size = new System.Drawing.Size(100, 20);
            this.txtTafsili.TabIndex = 5;
            this.txtTafsili.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTafsili_KeyDown);
            // 
            // chkTafsili
            // 
            this.chkTafsili.AutoSize = true;
            this.chkTafsili.Location = new System.Drawing.Point(539, 82);
            this.chkTafsili.Name = "chkTafsili";
            this.chkTafsili.Size = new System.Drawing.Size(79, 17);
            this.chkTafsili.TabIndex = 4;
            this.chkTafsili.Text = "کد تفصیلی";
            this.chkTafsili.UseVisualStyleBackColor = true;
            this.chkTafsili.CheckedChanged += new System.EventHandler(this.chkTafsili_CheckedChanged);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(112, 19);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(82, 33);
            this.btnReport.TabIndex = 6;
            this.btnReport.Text = "نمایش گزارش";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // Frm_Senni_Ras_Forosh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(684, 502);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Name = "Frm_Senni_Ras_Forosh";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "راس فروش";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_Ras_Forosh_FormClosed);
            this.Load += new System.EventHandler(this.Frm_Ras_Forosh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTafsili;
        private System.Windows.Forms.CheckBox chkTafsili;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.RadioButton rdbtnMoshtarekin;
        private System.Windows.Forms.RadioButton rdbtnKhareji;
        private System.Windows.Forms.RadioButton rdbtnKhososi;
        private System.Windows.Forms.RadioButton rdbtnDolati;
        private System.Windows.Forms.Button btnExcell;
        private System.Windows.Forms.DataGridViewTextBoxColumn radif;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTafsili;
        private System.Windows.Forms.DataGridViewTextBoxColumn NTafsili;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ras_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn mablagh_kol;


    }
}
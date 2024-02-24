namespace ET
{
    partial class Frm_Ras
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
            this.btnCalc = new System.Windows.Forms.Button();
            this.btnExcell = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.rdbtnMoshtarekin = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnkhadamat = new System.Windows.Forms.RadioButton();
            this.rdbtnTafsili = new System.Windows.Forms.RadioButton();
            this.rdbtnKhareji = new System.Windows.Forms.RadioButton();
            this.rdbtnKhososi = new System.Windows.Forms.RadioButton();
            this.rdbtnDolati = new System.Windows.Forms.RadioButton();
            this.txtTafsili = new System.Windows.Forms.TextBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.dgw = new System.Windows.Forms.DataGridView();
            this.radif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTafsili = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NTafsili = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mablagh_Factor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ras_Factor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mablagh_Check = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ras_Check = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
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
            this.rdbtnMoshtarekin.Location = new System.Drawing.Point(343, 51);
            this.rdbtnMoshtarekin.Name = "rdbtnMoshtarekin";
            this.rdbtnMoshtarekin.Size = new System.Drawing.Size(65, 17);
            this.rdbtnMoshtarekin.TabIndex = 3;
            this.rdbtnMoshtarekin.Text = "مشترکین";
            this.rdbtnMoshtarekin.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rbtnkhadamat);
            this.groupBox1.Controls.Add(this.rdbtnTafsili);
            this.groupBox1.Controls.Add(this.btnCalc);
            this.groupBox1.Controls.Add(this.btnExcell);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.rdbtnMoshtarekin);
            this.groupBox1.Controls.Add(this.rdbtnKhareji);
            this.groupBox1.Controls.Add(this.rdbtnKhososi);
            this.groupBox1.Controls.Add(this.rdbtnDolati);
            this.groupBox1.Controls.Add(this.txtTafsili);
            this.groupBox1.Controls.Add(this.btnReport);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox1.Location = new System.Drawing.Point(24, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(639, 115);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // rbtnkhadamat
            // 
            this.rbtnkhadamat.AutoSize = true;
            this.rbtnkhadamat.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rbtnkhadamat.Location = new System.Drawing.Point(352, 85);
            this.rbtnkhadamat.Name = "rbtnkhadamat";
            this.rbtnkhadamat.Size = new System.Drawing.Size(56, 17);
            this.rbtnkhadamat.TabIndex = 11;
            this.rbtnkhadamat.Text = "خدمات";
            this.rbtnkhadamat.UseVisualStyleBackColor = true;
            // 
            // rdbtnTafsili
            // 
            this.rdbtnTafsili.AutoSize = true;
            this.rdbtnTafsili.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rdbtnTafsili.Location = new System.Drawing.Point(544, 80);
            this.rdbtnTafsili.Name = "rdbtnTafsili";
            this.rdbtnTafsili.Size = new System.Drawing.Size(78, 17);
            this.rdbtnTafsili.TabIndex = 10;
            this.rdbtnTafsili.TabStop = true;
            this.rdbtnTafsili.Text = "کد تفصیلی";
            this.rdbtnTafsili.UseVisualStyleBackColor = true;
            this.rdbtnTafsili.CheckedChanged += new System.EventHandler(this.rdbtnTafsili_CheckedChanged);
            // 
            // rdbtnKhareji
            // 
            this.rdbtnKhareji.AutoSize = true;
            this.rdbtnKhareji.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rdbtnKhareji.Location = new System.Drawing.Point(312, 22);
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
            this.rdbtnKhososi.Location = new System.Drawing.Point(517, 51);
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
            this.rdbtnDolati.Location = new System.Drawing.Point(528, 22);
            this.rdbtnDolati.Name = "rdbtnDolati";
            this.rdbtnDolati.Size = new System.Drawing.Size(96, 17);
            this.rdbtnDolati.TabIndex = 0;
            this.rdbtnDolati.Text = "مشتریان دولتی";
            this.rdbtnDolati.UseVisualStyleBackColor = true;
            // 
            // txtTafsili
            // 
            this.txtTafsili.Location = new System.Drawing.Point(440, 82);
            this.txtTafsili.Name = "txtTafsili";
            this.txtTafsili.Size = new System.Drawing.Size(100, 20);
            this.txtTafsili.TabIndex = 5;
            this.txtTafsili.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTafsili_KeyDown);
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
            // dgw
            // 
            this.dgw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgw.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.radif,
            this.CTafsili,
            this.NTafsili,
            this.mablagh_Factor,
            this.Ras_Factor,
            this.Mablagh_Check,
            this.Ras_Check,
            this.Dif});
            this.dgw.Location = new System.Drawing.Point(22, 135);
            this.dgw.Name = "dgw";
            this.dgw.Size = new System.Drawing.Size(641, 349);
            this.dgw.TabIndex = 3;
            this.dgw.TabStop = false;
            this.dgw.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgw_CellContentClick);
            // 
            // radif
            // 
            this.radif.DataPropertyName = "radif";
            this.radif.HeaderText = "ردیف";
            this.radif.Name = "radif";
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
            // mablagh_Factor
            // 
            this.mablagh_Factor.DataPropertyName = "mablagh_Factor";
            this.mablagh_Factor.HeaderText = "مبلغ فاکتور";
            this.mablagh_Factor.Name = "mablagh_Factor";
            // 
            // Ras_Factor
            // 
            this.Ras_Factor.DataPropertyName = "Ras_Factor";
            this.Ras_Factor.HeaderText = "راس فاکتور";
            this.Ras_Factor.Name = "Ras_Factor";
            // 
            // Mablagh_Check
            // 
            this.Mablagh_Check.DataPropertyName = "Mablagh_Check";
            this.Mablagh_Check.HeaderText = "مبلغ چک";
            this.Mablagh_Check.Name = "Mablagh_Check";
            // 
            // Ras_Check
            // 
            this.Ras_Check.DataPropertyName = "Ras_Check";
            this.Ras_Check.HeaderText = "راس چک";
            this.Ras_Check.Name = "Ras_Check";
            // 
            // Dif
            // 
            this.Dif.DataPropertyName = "Dif";
            this.Dif.HeaderText = "اختلاف راسها";
            this.Dif.Name = "Dif";
            // 
            // Frm_Ras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(684, 502);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgw);
            this.Name = "Frm_Ras";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "را س گیری";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_Ras_FormClosed);
            this.Load += new System.EventHandler(this.Frm_Ras_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Button btnExcell;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.RadioButton rdbtnMoshtarekin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbtnKhareji;
        private System.Windows.Forms.RadioButton rdbtnKhososi;
        private System.Windows.Forms.RadioButton rdbtnDolati;
        private System.Windows.Forms.TextBox txtTafsili;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.DataGridView dgw;
        private System.Windows.Forms.DataGridViewTextBoxColumn radif;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTafsili;
        private System.Windows.Forms.DataGridViewTextBoxColumn NTafsili;
        private System.Windows.Forms.DataGridViewTextBoxColumn mablagh_Factor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ras_Factor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mablagh_Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ras_Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dif;
        private System.Windows.Forms.RadioButton rdbtnTafsili;
        private System.Windows.Forms.RadioButton rbtnkhadamat;

    }
}
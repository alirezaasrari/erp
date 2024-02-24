namespace ET
{
    partial class FrmHavaleAnbar
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn17 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn18 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn19 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn20 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn21 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.grd_havale = new Telerik.WinControls.UI.RadGridView();
            this.rpt_havale = new Microsoft.Reporting.WinForms.ReportViewer();
            this.txtHavale_no = new System.Windows.Forms.TextBox();
            this.txtc_kala = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pdatestart = new Telerik.WinControls.UI.RadDateTimePicker();
            this.pdateend = new Telerik.WinControls.UI.RadDateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.chkHovale_no = new System.Windows.Forms.CheckBox();
            this.chkDateHavale = new System.Windows.Forms.CheckBox();
            this.chkC_kala = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.grd_havale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_havale.MasterTemplate)).BeginInit();
            this.grd_havale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pdatestart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdateend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grd_havale
            // 
            this.grd_havale.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd_havale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grd_havale.Controls.Add(this.rpt_havale);
            this.grd_havale.Cursor = System.Windows.Forms.Cursors.Default;
            this.grd_havale.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.grd_havale.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grd_havale.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grd_havale.Location = new System.Drawing.Point(2, 143);
            // 
            // grd_havale
            // 
            this.grd_havale.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn15.EnableExpressionEditor = false;
            gridViewTextBoxColumn15.FieldName = "HavaleNO";
            gridViewTextBoxColumn15.HeaderText = "شماره حواله";
            gridViewTextBoxColumn15.MaxWidth = 100;
            gridViewTextBoxColumn15.MinWidth = 50;
            gridViewTextBoxColumn15.Name = "HavaleNO";
            gridViewTextBoxColumn15.Width = 62;
            gridViewTextBoxColumn16.EnableExpressionEditor = false;
            gridViewTextBoxColumn16.FieldName = "HavaleDate";
            gridViewTextBoxColumn16.HeaderText = "تاریخ حواله";
            gridViewTextBoxColumn16.Name = "HavaleDate";
            gridViewTextBoxColumn16.Width = 69;
            gridViewTextBoxColumn17.EnableExpressionEditor = false;
            gridViewTextBoxColumn17.FieldName = "Product_code";
            gridViewTextBoxColumn17.HeaderText = "کد محصول";
            gridViewTextBoxColumn17.Name = "Product_code";
            gridViewTextBoxColumn17.Width = 80;
            gridViewTextBoxColumn18.EnableExpressionEditor = false;
            gridViewTextBoxColumn18.FieldName = "Product_name";
            gridViewTextBoxColumn18.HeaderText = "نام محصول";
            gridViewTextBoxColumn18.Name = "Product_name";
            gridViewTextBoxColumn18.Width = 250;
            gridViewTextBoxColumn19.EnableExpressionEditor = false;
            gridViewTextBoxColumn19.FieldName = "node";
            gridViewTextBoxColumn19.HeaderText = "کد قطعه";
            gridViewTextBoxColumn19.Name = "node";
            gridViewTextBoxColumn19.Width = 69;
            gridViewTextBoxColumn20.EnableExpressionEditor = false;
            gridViewTextBoxColumn20.FieldName = "n_kala";
            gridViewTextBoxColumn20.HeaderText = "نام قطعه";
            gridViewTextBoxColumn20.Name = "n_kala";
            gridViewTextBoxColumn20.Width = 200;
            gridViewTextBoxColumn21.EnableExpressionEditor = false;
            gridViewTextBoxColumn21.FieldName = "Tedad";
            gridViewTextBoxColumn21.HeaderText = "تعداد";
            gridViewTextBoxColumn21.Name = "Tedad";
            gridViewTextBoxColumn21.Width = 45;
            this.grd_havale.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn15,
            gridViewTextBoxColumn16,
            gridViewTextBoxColumn17,
            gridViewTextBoxColumn18,
            gridViewTextBoxColumn19,
            gridViewTextBoxColumn20,
            gridViewTextBoxColumn21});
            this.grd_havale.Name = "grd_havale";
            this.grd_havale.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grd_havale.Size = new System.Drawing.Size(838, 301);
            this.grd_havale.TabIndex = 0;
            this.grd_havale.Text = "radGridView1";
            this.grd_havale.Click += new System.EventHandler(this.radGridView1_Click);
            // 
            // rpt_havale
            // 
            this.rpt_havale.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rpt_havale.Location = new System.Drawing.Point(3, 3);
            this.rpt_havale.Name = "rpt_havale";
            this.rpt_havale.PromptAreaCollapsed = true;
            this.rpt_havale.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rpt_havale.ShowBackButton = false;
            this.rpt_havale.ShowContextMenu = false;
            this.rpt_havale.ShowCredentialPrompts = false;
            this.rpt_havale.ShowFindControls = false;
            this.rpt_havale.ShowParameterPrompts = false;
            this.rpt_havale.ShowRefreshButton = false;
            this.rpt_havale.ShowStopButton = false;
            this.rpt_havale.Size = new System.Drawing.Size(835, 298);
            this.rpt_havale.TabIndex = 137;
            this.rpt_havale.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // txtHavale_no
            // 
            this.txtHavale_no.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHavale_no.Enabled = false;
            this.txtHavale_no.Location = new System.Drawing.Point(601, 19);
            this.txtHavale_no.Name = "txtHavale_no";
            this.txtHavale_no.Size = new System.Drawing.Size(126, 20);
            this.txtHavale_no.TabIndex = 1;
            // 
            // txtc_kala
            // 
            this.txtc_kala.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtc_kala.Enabled = false;
            this.txtc_kala.Location = new System.Drawing.Point(601, 60);
            this.txtc_kala.Name = "txtc_kala";
            this.txtc_kala.Size = new System.Drawing.Size(126, 20);
            this.txtc_kala.TabIndex = 3;
            this.txtc_kala.TextChanged += new System.EventHandler(this.txtc_kala_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(744, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 4;
            // 
            // pdatestart
            // 
            this.pdatestart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pdatestart.Enabled = false;
            this.pdatestart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.pdatestart.Location = new System.Drawing.Point(601, 99);
            this.pdatestart.Name = "pdatestart";
            this.pdatestart.Size = new System.Drawing.Size(126, 20);
            this.pdatestart.TabIndex = 128;
            this.pdatestart.TabStop = false;
            this.pdatestart.Text = "01/01/2015";
            this.pdatestart.Value = new System.DateTime(2015, 1, 1, 8, 5, 46, 101);
            // 
            // pdateend
            // 
            this.pdateend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pdateend.Enabled = false;
            this.pdateend.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.pdateend.Location = new System.Drawing.Point(430, 99);
            this.pdateend.Name = "pdateend";
            this.pdateend.Size = new System.Drawing.Size(126, 20);
            this.pdateend.TabIndex = 127;
            this.pdateend.TabStop = false;
            this.pdateend.Text = "01/01/2015";
            this.pdateend.Value = new System.DateTime(2015, 1, 1, 8, 5, 46, 101);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(727, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 129;
            this.label4.Text = "از";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(562, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 130;
            this.label5.Text = "تا";
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.Location = new System.Drawing.Point(289, 51);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(85, 27);
            this.btnReport.TabIndex = 131;
            this.btnReport.Text = "گزارش";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(289, 90);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(84, 27);
            this.btnPrint.TabIndex = 132;
            this.btnPrint.Text = "چاپ";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // chkHovale_no
            // 
            this.chkHovale_no.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkHovale_no.AutoSize = true;
            this.chkHovale_no.Location = new System.Drawing.Point(750, 22);
            this.chkHovale_no.Name = "chkHovale_no";
            this.chkHovale_no.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkHovale_no.Size = new System.Drawing.Size(82, 17);
            this.chkHovale_no.TabIndex = 134;
            this.chkHovale_no.Text = "شماره حواله";
            this.chkHovale_no.UseVisualStyleBackColor = true;
            this.chkHovale_no.CheckedChanged += new System.EventHandler(this.chkHovale_no_CheckedChanged);
            // 
            // chkDateHavale
            // 
            this.chkDateHavale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDateHavale.AutoSize = true;
            this.chkDateHavale.Location = new System.Drawing.Point(755, 100);
            this.chkDateHavale.Name = "chkDateHavale";
            this.chkDateHavale.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkDateHavale.Size = new System.Drawing.Size(77, 17);
            this.chkDateHavale.TabIndex = 135;
            this.chkDateHavale.Text = "تاریخ حواله";
            this.chkDateHavale.UseVisualStyleBackColor = true;
            this.chkDateHavale.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // chkC_kala
            // 
            this.chkC_kala.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkC_kala.AutoSize = true;
            this.chkC_kala.Location = new System.Drawing.Point(755, 61);
            this.chkC_kala.Name = "chkC_kala";
            this.chkC_kala.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkC_kala.Size = new System.Drawing.Size(77, 17);
            this.chkC_kala.TabIndex = 136;
            this.chkC_kala.Text = "کد محصول";
            this.chkC_kala.UseVisualStyleBackColor = true;
            this.chkC_kala.CheckedChanged += new System.EventHandler(this.chkC_kala_CheckedChanged);
            // 
            // FrmHavaleAnbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(844, 445);
            this.Controls.Add(this.chkC_kala);
            this.Controls.Add(this.chkDateHavale);
            this.Controls.Add(this.chkHovale_no);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pdatestart);
            this.Controls.Add(this.pdateend);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtc_kala);
            this.Controls.Add(this.txtHavale_no);
            this.Controls.Add(this.grd_havale);
            this.Name = "FrmHavaleAnbar";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "حواله انبار";
            this.Load += new System.EventHandler(this.FrmHavaleAnbar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grd_havale.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_havale)).EndInit();
            this.grd_havale.ResumeLayout(false);
            this.grd_havale.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pdatestart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdateend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grd_havale;
        private System.Windows.Forms.TextBox txtHavale_no;
        private System.Windows.Forms.TextBox txtc_kala;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadDateTimePicker pdatestart;
        private Telerik.WinControls.UI.RadDateTimePicker pdateend;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.CheckBox chkHovale_no;
        private System.Windows.Forms.CheckBox chkDateHavale;
        private System.Windows.Forms.CheckBox chkC_kala;
        private Microsoft.Reporting.WinForms.ReportViewer rpt_havale;
    }
}
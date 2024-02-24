namespace ET
{
    partial class FrmBudjeInsYear
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
            this.label23 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.btnYearAdd = new Telerik.WinControls.UI.RadButton();
            this.btnAmalkard = new Telerik.WinControls.UI.RadButton();
            this.sEdtMonth = new Telerik.WinControls.UI.RadSpinEditor();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnYearAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAmalkard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sEdtMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(936, 27);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(29, 13);
            this.label23.TabIndex = 383;
            this.label23.Text = "سال:";
            // 
            // txtYear
            // 
            this.txtYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtYear.Location = new System.Drawing.Point(877, 24);
            this.txtYear.Name = "txtYear";
            this.txtYear.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtYear.Size = new System.Drawing.Size(53, 20);
            this.txtYear.TabIndex = 382;
            // 
            // btnYearAdd
            // 
            this.btnYearAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYearAdd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnYearAdd.Location = new System.Drawing.Point(704, 24);
            this.btnYearAdd.Name = "btnYearAdd";
            this.btnYearAdd.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnYearAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnYearAdd.Size = new System.Drawing.Size(132, 25);
            this.btnYearAdd.TabIndex = 408;
            this.btnYearAdd.Text = "ایجاد سال بودجه";
            this.btnYearAdd.Click += new System.EventHandler(this.btnYearAdd_Click);
            // 
            // btnAmalkard
            // 
            this.btnAmalkard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAmalkard.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAmalkard.Location = new System.Drawing.Point(704, 88);
            this.btnAmalkard.Name = "btnAmalkard";
            this.btnAmalkard.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnAmalkard.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAmalkard.Size = new System.Drawing.Size(132, 25);
            this.btnAmalkard.TabIndex = 409;
            this.btnAmalkard.Text = "محاسبه عملکرد ماهانه";
            this.btnAmalkard.Click += new System.EventHandler(this.btnAmalkard_Click);
            // 
            // sEdtMonth
            // 
            this.sEdtMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sEdtMonth.Location = new System.Drawing.Point(879, 91);
            this.sEdtMonth.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.sEdtMonth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sEdtMonth.Name = "sEdtMonth";
            this.sEdtMonth.Size = new System.Drawing.Size(51, 20);
            this.sEdtMonth.TabIndex = 411;
            this.sEdtMonth.TabStop = false;
            this.sEdtMonth.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.sEdtMonth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(943, 92);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 13);
            this.label16.TabIndex = 410;
            this.label16.Text = "ماه";
            // 
            // FrmBudjeInsYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 325);
            this.Controls.Add(this.sEdtMonth);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btnAmalkard);
            this.Controls.Add(this.btnYearAdd);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtYear);
            this.Name = "FrmBudjeInsYear";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "ایجاد سال بودجه";
            ((System.ComponentModel.ISupportInitialize)(this.btnYearAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAmalkard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sEdtMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtYear;
        private Telerik.WinControls.UI.RadButton btnYearAdd;
        private Telerik.WinControls.UI.RadButton btnAmalkard;
        private Telerik.WinControls.UI.RadSpinEditor sEdtMonth;
        private System.Windows.Forms.Label label16;
    }
}

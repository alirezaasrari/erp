namespace ET
{
    partial class Frm_Senni_Operate
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
            this.btnOperate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labeltimeinf = new System.Windows.Forms.Label();
            this.labeldateinf = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labeltimeopr = new System.Windows.Forms.Label();
            this.labeldateopr = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUpdInf = new System.Windows.Forms.Button();
            this.dtpStart = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dtpEnd = new Telerik.WinControls.UI.RadDateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOperate
            // 
            this.btnOperate.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnOperate.Location = new System.Drawing.Point(31, 157);
            this.btnOperate.Name = "btnOperate";
            this.btnOperate.Size = new System.Drawing.Size(238, 40);
            this.btnOperate.TabIndex = 1;
            this.btnOperate.Text = "انجام عملیات گزارش سنی بدهکاران";
            this.btnOperate.UseVisualStyleBackColor = true;
            this.btnOperate.Click += new System.EventHandler(this.btnOperate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labeltimeinf);
            this.groupBox1.Controls.Add(this.labeldateinf);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(31, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 84);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // labeltimeinf
            // 
            this.labeltimeinf.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labeltimeinf.Location = new System.Drawing.Point(13, 49);
            this.labeltimeinf.Name = "labeltimeinf";
            this.labeltimeinf.Size = new System.Drawing.Size(77, 23);
            this.labeltimeinf.TabIndex = 6;
            this.labeltimeinf.Text = "-";
            this.labeltimeinf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labeldateinf
            // 
            this.labeldateinf.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labeldateinf.Location = new System.Drawing.Point(13, 21);
            this.labeldateinf.Name = "labeldateinf";
            this.labeldateinf.Size = new System.Drawing.Size(80, 23);
            this.labeldateinf.TabIndex = 5;
            this.labeldateinf.Text = "-";
            this.labeldateinf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label10.Location = new System.Drawing.Point(103, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 20);
            this.label10.TabIndex = 4;
            this.label10.Text = "زمان آخرین بروزرسانی";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(99, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "تاریخ آخرین بروزرسانی";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labeltimeopr);
            this.groupBox2.Controls.Add(this.labeldateopr);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(31, 203);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(238, 89);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // labeltimeopr
            // 
            this.labeltimeopr.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labeltimeopr.Location = new System.Drawing.Point(13, 56);
            this.labeltimeopr.Name = "labeltimeopr";
            this.labeltimeopr.Size = new System.Drawing.Size(77, 23);
            this.labeltimeopr.TabIndex = 8;
            this.labeltimeopr.Text = "-";
            this.labeltimeopr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labeldateopr
            // 
            this.labeldateopr.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labeldateopr.Location = new System.Drawing.Point(13, 24);
            this.labeldateopr.Name = "labeldateopr";
            this.labeldateopr.Size = new System.Drawing.Size(77, 23);
            this.labeldateopr.TabIndex = 7;
            this.labeldateopr.Text = "-";
            this.labeldateopr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(131, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "زمان آخرین عملیات";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(127, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "تاریخ آخرین عملیات";
            // 
            // btnUpdInf
            // 
            this.btnUpdInf.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnUpdInf.Location = new System.Drawing.Point(31, 27);
            this.btnUpdInf.Name = "btnUpdInf";
            this.btnUpdInf.Size = new System.Drawing.Size(238, 40);
            this.btnUpdInf.TabIndex = 0;
            this.btnUpdInf.Text = "بروز رسانی اطلاعات سنی بدهکاران";
            this.btnUpdInf.UseVisualStyleBackColor = true;
            this.btnUpdInf.Click += new System.EventHandler(this.btnUpdInf_Click);
            // 
            // dtpStart
            // 
            this.dtpStart.AllowDrop = true;
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(282, 32);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(122, 20);
            this.dtpStart.TabIndex = 134;
            this.dtpStart.TabStop = false;
            this.dtpStart.Text = "2015/01/01";
            this.dtpStart.Value = new System.DateTime(2015, 1, 1, 8, 5, 46, 101);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(282, 67);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(122, 20);
            this.dtpEnd.TabIndex = 133;
            this.dtpEnd.TabStop = false;
            this.dtpEnd.Text = "2015/01/01";
            this.dtpEnd.Value = new System.DateTime(2015, 1, 1, 8, 5, 37, 521);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(410, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 24);
            this.label5.TabIndex = 135;
            this.label5.Text = "تاریخ پایان";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(410, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 24);
            this.label3.TabIndex = 136;
            this.label3.Text = "تاریخ شروع";
            // 
            // Frm_Senni_Operate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(483, 310);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.btnUpdInf);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOperate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_Senni_Operate";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "انجام عملیات";
            this.Load += new System.EventHandler(this.FrmOperate_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOperate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labeltimeinf;
        private System.Windows.Forms.Label labeldateinf;
        private System.Windows.Forms.Label labeltimeopr;
        private System.Windows.Forms.Label labeldateopr;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnUpdInf;
        private Telerik.WinControls.UI.RadDateTimePicker dtpStart;
        private Telerik.WinControls.UI.RadDateTimePicker dtpEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
    }
}
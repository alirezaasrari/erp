namespace ET
{
    partial class FrmPM_AddTask
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
            this.drpPersonel = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.dt1 = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtTimeStart = new Telerik.WinControls.UI.RadDateTimePicker();
            this.lblMoreViewsIns = new Telerik.WinControls.UI.RadLabel();
            this.lblIdCalendar = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.txtTimeEnd = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.drpPersonel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMoreViewsIns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIdCalendar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // drpPersonel
            // 
            this.drpPersonel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.drpPersonel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.drpPersonel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.drpPersonel.Location = new System.Drawing.Point(1, 12);
            this.drpPersonel.Name = "drpPersonel";
            this.drpPersonel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.drpPersonel.Size = new System.Drawing.Size(125, 21);
            this.drpPersonel.TabIndex = 147;
            // 
            // radLabel3
            // 
            this.radLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(132, 12);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(115, 19);
            this.radLabel3.TabIndex = 148;
            this.radLabel3.Text = "شخص انجام دهنده";
            // 
            // dt1
            // 
            this.dt1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dt1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt1.Location = new System.Drawing.Point(75, 39);
            this.dt1.Name = "dt1";
            this.dt1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dt1.Size = new System.Drawing.Size(97, 21);
            this.dt1.TabIndex = 150;
            this.dt1.TabStop = false;
            this.dt1.Text = "01/01/2015";
            this.dt1.Value = new System.DateTime(2015, 1, 1, 8, 5, 46, 101);
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(178, 41);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(69, 19);
            this.radLabel1.TabIndex = 149;
            this.radLabel1.Text = "تاریخ شروع";
            // 
            // txtTimeStart
            // 
            this.txtTimeStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimeStart.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTimeStart.Location = new System.Drawing.Point(140, 66);
            this.txtTimeStart.Name = "txtTimeStart";
            this.txtTimeStart.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTimeStart.ShowUpDown = true;
            this.txtTimeStart.Size = new System.Drawing.Size(60, 20);
            this.txtTimeStart.TabIndex = 220;
            this.txtTimeStart.TabStop = false;
            this.txtTimeStart.Text = "10/02/2016 12:57 ب.ظ";
            this.txtTimeStart.Value = new System.DateTime(2016, 2, 10, 12, 57, 55, 799);
            // 
            // lblMoreViewsIns
            // 
            this.lblMoreViewsIns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMoreViewsIns.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoreViewsIns.Location = new System.Drawing.Point(12, 94);
            this.lblMoreViewsIns.Name = "lblMoreViewsIns";
            this.lblMoreViewsIns.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMoreViewsIns.Size = new System.Drawing.Size(12, 19);
            this.lblMoreViewsIns.TabIndex = 149;
            this.lblMoreViewsIns.Text = "-";
            this.lblMoreViewsIns.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIdCalendar
            // 
            this.lblIdCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIdCalendar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdCalendar.Location = new System.Drawing.Point(40, 124);
            this.lblIdCalendar.Name = "lblIdCalendar";
            this.lblIdCalendar.Size = new System.Drawing.Size(12, 19);
            this.lblIdCalendar.TabIndex = 149;
            this.lblIdCalendar.Text = "-";
            this.lblIdCalendar.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radLabel2
            // 
            this.radLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(171, 124);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(79, 19);
            this.radLabel2.TabIndex = 149;
            this.radLabel2.Text = "کد دستور کار";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAdd.Image = global::ET.Properties.Resources.ADD;
            this.btnAdd.Location = new System.Drawing.Point(4, 119);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAdd.Size = new System.Drawing.Size(30, 24);
            this.btnAdd.TabIndex = 146;
            this.btnAdd.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtTimeEnd
            // 
            this.txtTimeEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimeEnd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTimeEnd.Location = new System.Drawing.Point(42, 66);
            this.txtTimeEnd.Name = "txtTimeEnd";
            this.txtTimeEnd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTimeEnd.ShowUpDown = true;
            this.txtTimeEnd.Size = new System.Drawing.Size(60, 20);
            this.txtTimeEnd.TabIndex = 220;
            this.txtTimeEnd.TabStop = false;
            this.txtTimeEnd.Text = "10/02/2016 12:57 ب.ظ";
            this.txtTimeEnd.Value = new System.DateTime(2016, 2, 10, 12, 57, 55, 799);
            // 
            // radLabel4
            // 
            this.radLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(203, 66);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(44, 19);
            this.radLabel4.TabIndex = 149;
            this.radLabel4.Text = "زمان از";
            // 
            // radLabel5
            // 
            this.radLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel5.Location = new System.Drawing.Point(119, 67);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(15, 19);
            this.radLabel5.TabIndex = 149;
            this.radLabel5.Text = "تا";
            // 
            // FrmPM_AddTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 148);
            this.Controls.Add(this.txtTimeEnd);
            this.Controls.Add(this.txtTimeStart);
            this.Controls.Add(this.dt1);
            this.Controls.Add(this.lblIdCalendar);
            this.Controls.Add(this.lblMoreViewsIns);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.drpPersonel);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmPM_AddTask";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ثبت انجام سرویس پیشگیرانه";
            this.Load += new System.EventHandler(this.FrmPM_AddTask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.drpPersonel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMoreViewsIns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIdCalendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnAdd;
        private Telerik.WinControls.UI.RadDropDownList drpPersonel;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadDateTimePicker dt1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        public Telerik.WinControls.UI.RadDateTimePicker txtTimeStart;
        private Telerik.WinControls.UI.RadLabel lblMoreViewsIns;
        private Telerik.WinControls.UI.RadLabel lblIdCalendar;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        public Telerik.WinControls.UI.RadDateTimePicker txtTimeEnd;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel5;
    }
}

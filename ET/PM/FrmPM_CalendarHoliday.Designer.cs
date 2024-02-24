namespace ET
{
    partial class FrmPM_CalendarHoliday
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.ConditionalFormattingObject conditionalFormattingObject1 = new Telerik.WinControls.UI.ConditionalFormattingObject();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.btnYears = new Telerik.WinControls.UI.RadButton();
            this.dt2 = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dt1 = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.grdDayHoliday = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.btnYears)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDayHoliday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDayHoliday.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnYears
            // 
            this.btnYears.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYears.Location = new System.Drawing.Point(423, 12);
            this.btnYears.Name = "btnYears";
            this.btnYears.Size = new System.Drawing.Size(110, 24);
            this.btnYears.TabIndex = 0;
            this.btnYears.Text = "ایجاد تقویم سال";
            this.btnYears.Click += new System.EventHandler(this.btnYears_Click);
            // 
            // dt2
            // 
            this.dt2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dt2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt2.Location = new System.Drawing.Point(15, 12);
            this.dt2.Name = "dt2";
            this.dt2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dt2.Size = new System.Drawing.Size(97, 21);
            this.dt2.TabIndex = 128;
            this.dt2.TabStop = false;
            this.dt2.Text = "1/1/2015";
            this.dt2.Value = new System.DateTime(2015, 1, 1, 8, 5, 46, 101);
            // 
            // dt1
            // 
            this.dt1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dt1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt1.Location = new System.Drawing.Point(215, 12);
            this.dt1.Name = "dt1";
            this.dt1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dt1.Size = new System.Drawing.Size(97, 21);
            this.dt1.TabIndex = 129;
            this.dt1.TabStop = false;
            this.dt1.Text = "1/1/2015";
            this.dt1.Value = new System.DateTime(2015, 1, 1, 8, 5, 46, 101);
            // 
            // radLabel2
            // 
            this.radLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(118, 14);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(91, 19);
            this.radLabel2.TabIndex = 126;
            this.radLabel2.Text = "تاریخ پایان سال";
            // 
            // radLabel3
            // 
            this.radLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(318, 14);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(99, 19);
            this.radLabel3.TabIndex = 127;
            this.radLabel3.Text = "تاریخ شروع سال";
            // 
            // grdDayHoliday
            // 
            this.grdDayHoliday.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDayHoliday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grdDayHoliday.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdDayHoliday.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grdDayHoliday.ForeColor = System.Drawing.Color.Black;
            this.grdDayHoliday.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdDayHoliday.Location = new System.Drawing.Point(215, 42);
            // 
            // 
            // 
            this.grdDayHoliday.MasterTemplate.AllowAddNewRow = false;
            this.grdDayHoliday.MasterTemplate.AllowColumnReorder = false;
            this.grdDayHoliday.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "DateHoliday";
            gridViewTextBoxColumn1.HeaderText = "تاریخ";
            gridViewTextBoxColumn1.MaxLength = 12;
            gridViewTextBoxColumn1.Name = "DateHoliday";
            gridViewTextBoxColumn1.Width = 141;
            conditionalFormattingObject1.ApplyToRow = true;
            conditionalFormattingObject1.CellBackColor = System.Drawing.Color.Red;
            conditionalFormattingObject1.CellFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            conditionalFormattingObject1.CellForeColor = System.Drawing.Color.Black;
            conditionalFormattingObject1.Name = "NewCondition";
            conditionalFormattingObject1.RowBackColor = System.Drawing.Color.Red;
            conditionalFormattingObject1.RowFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            conditionalFormattingObject1.RowForeColor = System.Drawing.Color.Black;
            conditionalFormattingObject1.TValue1 = "True";
            gridViewCheckBoxColumn1.ConditionalFormattingObjectList.Add(conditionalFormattingObject1);
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.FieldName = "IsHoliday";
            gridViewCheckBoxColumn1.HeaderText = "تعطیلی";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "IsHoliday";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "IdHoliday";
            gridViewTextBoxColumn2.HeaderText = "IdHoliday";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "IdHoliday";
            gridViewTextBoxColumn2.Width = 206;
            this.grdDayHoliday.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn2});
            this.grdDayHoliday.MasterTemplate.EnableAlternatingRowColor = true;
            this.grdDayHoliday.MasterTemplate.EnableFiltering = true;
            this.grdDayHoliday.MasterTemplate.EnableGrouping = false;
            this.grdDayHoliday.MasterTemplate.ShowGroupedColumns = true;
            this.grdDayHoliday.MasterTemplate.ShowRowHeaderColumn = false;
            this.grdDayHoliday.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdDayHoliday.Name = "grdDayHoliday";
            this.grdDayHoliday.ReadOnly = true;
            this.grdDayHoliday.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdDayHoliday.ShowGroupPanel = false;
            this.grdDayHoliday.Size = new System.Drawing.Size(318, 527);
            this.grdDayHoliday.TabIndex = 130;
            this.grdDayHoliday.Text = "radGridView1";
            this.grdDayHoliday.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.MasterTemplate_CellDoubleClick);
            // 
            // FrmPM_CalendarHoliday
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 570);
            this.Controls.Add(this.grdDayHoliday);
            this.Controls.Add(this.dt2);
            this.Controls.Add(this.dt1);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.btnYears);
            this.Name = "FrmPM_CalendarHoliday";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "تقویم تعطیلات نت";
            this.Load += new System.EventHandler(this.FrmPM_CalendarHoliday_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnYears)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDayHoliday.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDayHoliday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnYears;
        private Telerik.WinControls.UI.RadDateTimePicker dt2;
        private Telerik.WinControls.UI.RadDateTimePicker dt1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadGridView grdDayHoliday;
    }
}

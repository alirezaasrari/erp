namespace ET
{
    partial class FrmTolidShowDailyReport
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.grdDailyReport = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdDailyReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDailyReport.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDailyReport
            // 
            this.grdDailyReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grdDailyReport.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdDailyReport.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.grdDailyReport.ForeColor = System.Drawing.Color.Black;
            this.grdDailyReport.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdDailyReport.Location = new System.Drawing.Point(12, 12);
            // 
            // 
            // 
            this.grdDailyReport.MasterTemplate.AllowAddNewRow = false;
            this.grdDailyReport.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "ID";
            gridViewTextBoxColumn1.HeaderText = "کد گزارش روزانه";
            gridViewTextBoxColumn1.Name = "ID";
            gridViewTextBoxColumn1.Width = 85;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "tarikh";
            gridViewTextBoxColumn2.HeaderText = "تاریخ";
            gridViewTextBoxColumn2.Name = "tarikh";
            gridViewTextBoxColumn2.Width = 100;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "shift";
            gridViewTextBoxColumn3.HeaderText = "شیفت";
            gridViewTextBoxColumn3.Name = "shift";
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "dastgah";
            gridViewTextBoxColumn4.HeaderText = "دستگاه";
            gridViewTextBoxColumn4.Name = "dastgah";
            gridViewTextBoxColumn4.Width = 116;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "FK_ID_part_process";
            gridViewTextBoxColumn5.HeaderText = "کد قطعه";
            gridViewTextBoxColumn5.Name = "FK_ID_part_process";
            gridViewTextBoxColumn5.Width = 147;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "N_Kala";
            gridViewTextBoxColumn6.HeaderText = "نام کالا";
            gridViewTextBoxColumn6.Name = "N_Kala";
            gridViewTextBoxColumn6.Width = 230;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "tedad";
            gridViewTextBoxColumn7.HeaderText = "تعداد تولید";
            gridViewTextBoxColumn7.Name = "tedad";
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "N_process";
            gridViewTextBoxColumn8.HeaderText = "فرایند";
            gridViewTextBoxColumn8.Name = "N_process";
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "FK_ID_unit";
            gridViewTextBoxColumn9.HeaderText = "واحد";
            gridViewTextBoxColumn9.Name = "FK_ID_unit";
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "zaman_kari";
            gridViewTextBoxColumn10.HeaderText = "زمان کاری";
            gridViewTextBoxColumn10.Name = "zaman_kari";
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.FieldName = "FK_ID_barname";
            gridViewTextBoxColumn11.HeaderText = "کد برنامه";
            gridViewTextBoxColumn11.Name = "FK_ID_barname";
            this.grdDailyReport.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11});
            this.grdDailyReport.MasterTemplate.EnableFiltering = true;
            this.grdDailyReport.MasterTemplate.ShowRowHeaderColumn = false;
            this.grdDailyReport.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdDailyReport.Name = "grdDailyReport";
            this.grdDailyReport.ReadOnly = true;
            this.grdDailyReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdDailyReport.ShowGroupPanel = false;
            this.grdDailyReport.Size = new System.Drawing.Size(1080, 442);
            this.grdDailyReport.TabIndex = 0;
            this.grdDailyReport.Text = "radGridView1";
            this.grdDailyReport.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdDailyReport_CellDoubleClick);
            // 
            // FrmTolidShowDailyReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 466);
            this.Controls.Add(this.grdDailyReport);
            this.Name = "FrmTolidShowDailyReport";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "گزارش روزانه";
            this.Load += new System.EventHandler(this.FrmTolidShowDailyReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDailyReport.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDailyReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grdDailyReport;
    }
}

namespace ET
{
    partial class FrmSofrehDateReport
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewRelation gridViewRelation1 = new Telerik.WinControls.UI.GridViewRelation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSofrehDateReport));
            this.grd = new Telerik.WinControls.UI.RadGridView();
            this.btnExcel = new Telerik.WinControls.UI.RadButton();
            this.dtpSofrehFirst = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dtpSofrehLast = new Telerik.WinControls.UI.RadDateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearch = new Telerik.WinControls.UI.RadButton();
            this.chkSofrehDate = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpSofrehFirst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpSofrehLast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grd
            // 
            this.grd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grd.Cursor = System.Windows.Forms.Cursors.Default;
            this.grd.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grd.ForeColor = System.Drawing.Color.Black;
            this.grd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grd.Location = new System.Drawing.Point(12, 73);
            // 
            // 
            // 
            this.grd.MasterTemplate.AllowAddNewRow = false;
            this.grd.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "Id_AsliVahed";
            gridViewTextBoxColumn1.HeaderText = "شناسه واحد اصلی";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "Id_AsliVahed";
            gridViewTextBoxColumn1.Width = 98;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "NameAsliVahed";
            gridViewTextBoxColumn2.HeaderText = "نام واحد اصلی";
            gridViewTextBoxColumn2.Name = "NameAsliVahed";
            gridViewTextBoxColumn2.Width = 161;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "ID_FareeVahed";
            gridViewTextBoxColumn3.HeaderText = "شناسه واحد فرعی";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "ID_FareeVahed";
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "NameFareeVahed";
            gridViewTextBoxColumn4.HeaderText = "نام واحد فرعی";
            gridViewTextBoxColumn4.Name = "NameFareeVahed";
            gridViewTextBoxColumn4.Width = 133;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "IDHHazineh";
            gridViewTextBoxColumn5.HeaderText = "شناسه هزینه";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "IDHHazineh";
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "NameHHazineh";
            gridViewTextBoxColumn6.HeaderText = "نام هزینه";
            gridViewTextBoxColumn6.Name = "NameHHazineh";
            gridViewTextBoxColumn6.Width = 155;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "C_Kol";
            gridViewTextBoxColumn7.HeaderText = "کد کل";
            gridViewTextBoxColumn7.Name = "C_Kol";
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "N_kol";
            gridViewTextBoxColumn8.HeaderText = "نام کل";
            gridViewTextBoxColumn8.Name = "N_kol";
            gridViewTextBoxColumn8.Width = 129;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "C_Moeen";
            gridViewTextBoxColumn9.HeaderText = "کد معین";
            gridViewTextBoxColumn9.Name = "C_Moeen";
            gridViewTextBoxColumn9.Width = 59;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "N_moeen";
            gridViewTextBoxColumn10.HeaderText = "نام معین";
            gridViewTextBoxColumn10.Name = "N_moeen";
            gridViewTextBoxColumn10.Width = 145;
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.FieldName = "datesanad";
            gridViewTextBoxColumn11.HeaderText = "تاریخ";
            gridViewTextBoxColumn11.Name = "datesanad";
            gridViewTextBoxColumn11.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending;
            gridViewTextBoxColumn11.Width = 89;
            gridViewTextBoxColumn12.EnableExpressionEditor = false;
            gridViewTextBoxColumn12.FieldName = "Mandeh";
            gridViewTextBoxColumn12.HeaderText = "مانده";
            gridViewTextBoxColumn12.Name = "Mandeh";
            gridViewTextBoxColumn12.Width = 105;
            this.grd.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
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
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12});
            this.grd.MasterTemplate.EnableFiltering = true;
            sortDescriptor1.PropertyName = "datesanad";
            this.grd.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.grd.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grd.Name = "grd";
            this.grd.ReadOnly = true;
            gridViewRelation1.ChildColumnNames = ((System.Collections.Specialized.StringCollection)(resources.GetObject("gridViewRelation1.ChildColumnNames")));
            gridViewRelation1.ParentColumnNames = ((System.Collections.Specialized.StringCollection)(resources.GetObject("gridViewRelation1.ParentColumnNames")));
            gridViewRelation1.ParentTemplate = this.grd.MasterTemplate;
            this.grd.Relations.AddRange(new Telerik.WinControls.UI.GridViewRelation[] {
            gridViewRelation1});
            this.grd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grd.Size = new System.Drawing.Size(970, 465);
            this.grd.TabIndex = 196;
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Location = new System.Drawing.Point(148, 28);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(92, 24);
            this.btnExcel.TabIndex = 195;
            this.btnExcel.Text = "خروجی اکسل";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // dtpSofrehFirst
            // 
            this.dtpSofrehFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpSofrehFirst.Enabled = false;
            this.dtpSofrehFirst.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSofrehFirst.Location = new System.Drawing.Point(784, 31);
            this.dtpSofrehFirst.Name = "dtpSofrehFirst";
            this.dtpSofrehFirst.Size = new System.Drawing.Size(98, 20);
            this.dtpSofrehFirst.TabIndex = 194;
            this.dtpSofrehFirst.TabStop = false;
            this.dtpSofrehFirst.Text = "01/01/2015";
            this.dtpSofrehFirst.Value = new System.DateTime(2015, 1, 1, 8, 5, 46, 101);
            // 
            // dtpSofrehLast
            // 
            this.dtpSofrehLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpSofrehLast.Enabled = false;
            this.dtpSofrehLast.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSofrehLast.Location = new System.Drawing.Point(652, 31);
            this.dtpSofrehLast.Name = "dtpSofrehLast";
            this.dtpSofrehLast.Size = new System.Drawing.Size(100, 20);
            this.dtpSofrehLast.TabIndex = 193;
            this.dtpSofrehLast.TabStop = false;
            this.dtpSofrehLast.Text = "01/01/2015";
            this.dtpSofrehLast.Value = new System.DateTime(2015, 1, 1, 8, 5, 37, 521);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(888, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 24);
            this.label4.TabIndex = 191;
            this.label4.Text = "از";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(758, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 24);
            this.label5.TabIndex = 192;
            this.label5.Text = "تا";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ImageIndex = 15;
            this.btnSearch.Location = new System.Drawing.Point(481, 27);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(71, 24);
            this.btnSearch.TabIndex = 190;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chkSofrehDate
            // 
            this.chkSofrehDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSofrehDate.AutoSize = true;
            this.chkSofrehDate.Location = new System.Drawing.Point(919, 35);
            this.chkSofrehDate.Name = "chkSofrehDate";
            this.chkSofrehDate.Size = new System.Drawing.Size(63, 17);
            this.chkSofrehDate.TabIndex = 197;
            this.chkSofrehDate.Text = "تاریخ سند";
            this.chkSofrehDate.UseVisualStyleBackColor = true;
            this.chkSofrehDate.CheckedChanged += new System.EventHandler(this.chkSofrehDate_CheckedChanged);
            // 
            // FrmSofrehDateReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 570);
            this.Controls.Add(this.chkSofrehDate);
            this.Controls.Add(this.grd);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.dtpSofrehFirst);
            this.Controls.Add(this.dtpSofrehLast);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSearch);
            this.Name = "FrmSofrehDateReport";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "گزارش تاریخ سفره";
            this.Load += new System.EventHandler(this.FrmSofrehDateReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grd.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpSofrehFirst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpSofrehLast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnExcel;
        private Telerik.WinControls.UI.RadDateTimePicker dtpSofrehFirst;
        private Telerik.WinControls.UI.RadDateTimePicker dtpSofrehLast;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Telerik.WinControls.UI.RadButton btnSearch;
        private Telerik.WinControls.UI.RadGridView grd;
        private System.Windows.Forms.CheckBox chkSofrehDate;
    }
}

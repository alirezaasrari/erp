namespace ET
{
    partial class FrmSarbarLastDateReport
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewSummaryItem gridViewSummaryItem2 = new Telerik.WinControls.UI.GridViewSummaryItem();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewRelation gridViewRelation2 = new Telerik.WinControls.UI.GridViewRelation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSarbarLastDateReport));
            this.grd = new Telerik.WinControls.UI.RadGridView();
            this.chkSarbarDate = new System.Windows.Forms.CheckBox();
            this.btnExcel = new Telerik.WinControls.UI.RadButton();
            this.dtpSarbarFirst = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dtpSarbarLast = new Telerik.WinControls.UI.RadDateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearch = new Telerik.WinControls.UI.RadButton();
            this.btnShowQV = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpSarbarFirst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpSarbarLast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowQV)).BeginInit();
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
            this.grd.Location = new System.Drawing.Point(8, 76);
            // 
            // 
            // 
            this.grd.MasterTemplate.AllowAddNewRow = false;
            this.grd.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "FK_Id_AsliVahedFirst";
            gridViewTextBoxColumn7.HeaderText = "شناسه واحد اصلی خدمت دهنده";
            gridViewTextBoxColumn7.IsVisible = false;
            gridViewTextBoxColumn7.Name = "FK_Id_AsliVahedFirst";
            gridViewTextBoxColumn7.Width = 98;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "NameVahedFirst";
            gridViewTextBoxColumn8.HeaderText = "نام واحد اصلی خدمت دهنده";
            gridViewTextBoxColumn8.Name = "NameVahedFirst";
            gridViewTextBoxColumn8.Width = 227;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "FK_Id_AsliVahedLast";
            gridViewTextBoxColumn9.HeaderText = "شناسه واحد اصلی گیرنده";
            gridViewTextBoxColumn9.IsVisible = false;
            gridViewTextBoxColumn9.Name = "FK_Id_AsliVahedLast";
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "NameVahedLast";
            gridViewTextBoxColumn10.HeaderText = "نام واحد اصلی گیرنده";
            gridViewTextBoxColumn10.Name = "NameVahedLast";
            gridViewTextBoxColumn10.Width = 209;
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.FieldName = "HazinehLast";
            gridViewTextBoxColumn11.FormatString = "{0:###,##0}";
            gridViewTextBoxColumn11.HeaderText = "هزینه";
            gridViewTextBoxColumn11.Name = "HazinehLast";
            gridViewTextBoxColumn11.Width = 151;
            gridViewTextBoxColumn12.EnableExpressionEditor = false;
            gridViewTextBoxColumn12.FieldName = "DateTashim";
            gridViewTextBoxColumn12.HeaderText = "تاریخ تسهیم";
            gridViewTextBoxColumn12.Name = "DateTashim";
            gridViewTextBoxColumn12.Width = 163;
            this.grd.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12});
            this.grd.MasterTemplate.EnableFiltering = true;
            gridViewSummaryItem2.Aggregate = Telerik.WinControls.UI.GridAggregateFunction.Sum;
            gridViewSummaryItem2.AggregateExpression = null;
            gridViewSummaryItem2.FormatString = "{0:###,##0.00}";
            gridViewSummaryItem2.Name = "HazinehLast";
            this.grd.MasterTemplate.SummaryRowsBottom.Add(new Telerik.WinControls.UI.GridViewSummaryRowItem(new Telerik.WinControls.UI.GridViewSummaryItem[] {
                gridViewSummaryItem2}));
            this.grd.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grd.Name = "grd";
            this.grd.ReadOnly = true;
            gridViewRelation2.ChildColumnNames = ((System.Collections.Specialized.StringCollection)(resources.GetObject("gridViewRelation2.ChildColumnNames")));
            gridViewRelation2.ParentColumnNames = ((System.Collections.Specialized.StringCollection)(resources.GetObject("gridViewRelation2.ParentColumnNames")));
            gridViewRelation2.ParentTemplate = this.grd.MasterTemplate;
            this.grd.Relations.AddRange(new Telerik.WinControls.UI.GridViewRelation[] {
            gridViewRelation2});
            this.grd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grd.Size = new System.Drawing.Size(970, 465);
            this.grd.TabIndex = 204;
            // 
            // chkSarbarDate
            // 
            this.chkSarbarDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSarbarDate.AutoSize = true;
            this.chkSarbarDate.Location = new System.Drawing.Point(915, 38);
            this.chkSarbarDate.Name = "chkSarbarDate";
            this.chkSarbarDate.Size = new System.Drawing.Size(63, 17);
            this.chkSarbarDate.TabIndex = 205;
            this.chkSarbarDate.Text = "تاریخ سند";
            this.chkSarbarDate.UseVisualStyleBackColor = true;
            this.chkSarbarDate.CheckedChanged += new System.EventHandler(this.chkSarbarDate_CheckedChanged);
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Location = new System.Drawing.Point(144, 31);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(92, 24);
            this.btnExcel.TabIndex = 203;
            this.btnExcel.Text = "خروجی اکسل";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // dtpSarbarFirst
            // 
            this.dtpSarbarFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpSarbarFirst.Enabled = false;
            this.dtpSarbarFirst.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSarbarFirst.Location = new System.Drawing.Point(780, 34);
            this.dtpSarbarFirst.Name = "dtpSarbarFirst";
            this.dtpSarbarFirst.Size = new System.Drawing.Size(98, 20);
            this.dtpSarbarFirst.TabIndex = 202;
            this.dtpSarbarFirst.TabStop = false;
            this.dtpSarbarFirst.Text = "2015/01/01";
            this.dtpSarbarFirst.Value = new System.DateTime(2015, 1, 1, 8, 5, 46, 101);
            // 
            // dtpSarbarLast
            // 
            this.dtpSarbarLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpSarbarLast.Enabled = false;
            this.dtpSarbarLast.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSarbarLast.Location = new System.Drawing.Point(648, 34);
            this.dtpSarbarLast.Name = "dtpSarbarLast";
            this.dtpSarbarLast.Size = new System.Drawing.Size(100, 20);
            this.dtpSarbarLast.TabIndex = 201;
            this.dtpSarbarLast.TabStop = false;
            this.dtpSarbarLast.Text = "2015/01/01";
            this.dtpSarbarLast.Value = new System.DateTime(2015, 1, 1, 8, 5, 37, 521);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(884, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 24);
            this.label4.TabIndex = 199;
            this.label4.Text = "از";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(754, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 24);
            this.label5.TabIndex = 200;
            this.label5.Text = "تا";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ImageIndex = 15;
            this.btnSearch.Location = new System.Drawing.Point(477, 30);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(71, 24);
            this.btnSearch.TabIndex = 198;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnShowQV
            // 
            this.btnShowQV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowQV.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowQV.ImageIndex = 15;
            this.btnShowQV.Location = new System.Drawing.Point(336, 32);
            this.btnShowQV.Name = "btnShowQV";
            this.btnShowQV.Size = new System.Drawing.Size(112, 24);
            this.btnShowQV.TabIndex = 206;
            this.btnShowQV.Text = "نمایش گزارش";
            this.btnShowQV.Click += new System.EventHandler(this.btnShowQV_Click);
            // 
            // FrmSarbarLastDateReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 570);
            this.Controls.Add(this.btnShowQV);
            this.Controls.Add(this.chkSarbarDate);
            this.Controls.Add(this.grd);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.dtpSarbarFirst);
            this.Controls.Add(this.dtpSarbarLast);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSearch);
            this.Name = "FrmSarbarLastDateReport";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "گزارش تارخ سربار نهایی";
            this.Load += new System.EventHandler(this.FrmSarbarLastDateReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grd.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpSarbarFirst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpSarbarLast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowQV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSarbarDate;
        private Telerik.WinControls.UI.RadGridView grd;
        private Telerik.WinControls.UI.RadButton btnExcel;
        private Telerik.WinControls.UI.RadDateTimePicker dtpSarbarFirst;
        private Telerik.WinControls.UI.RadDateTimePicker dtpSarbarLast;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Telerik.WinControls.UI.RadButton btnSearch;
        private Telerik.WinControls.UI.RadButton btnShowQV;
    }
}

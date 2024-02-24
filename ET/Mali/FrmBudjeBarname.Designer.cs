namespace ET
{
    partial class FrmBudjeBarname
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
            Telerik.WinControls.UI.GridViewMaskBoxColumn gridViewMaskBoxColumn1 = new Telerik.WinControls.UI.GridViewMaskBoxColumn();
            Telerik.WinControls.UI.GridViewMaskBoxColumn gridViewMaskBoxColumn2 = new Telerik.WinControls.UI.GridViewMaskBoxColumn();
            Telerik.WinControls.UI.GridViewMaskBoxColumn gridViewMaskBoxColumn3 = new Telerik.WinControls.UI.GridViewMaskBoxColumn();
            Telerik.WinControls.UI.GridViewMaskBoxColumn gridViewMaskBoxColumn4 = new Telerik.WinControls.UI.GridViewMaskBoxColumn();
            Telerik.WinControls.UI.GridViewMaskBoxColumn gridViewMaskBoxColumn5 = new Telerik.WinControls.UI.GridViewMaskBoxColumn();
            Telerik.WinControls.UI.GridViewMaskBoxColumn gridViewMaskBoxColumn6 = new Telerik.WinControls.UI.GridViewMaskBoxColumn();
            Telerik.WinControls.UI.GridViewMaskBoxColumn gridViewMaskBoxColumn7 = new Telerik.WinControls.UI.GridViewMaskBoxColumn();
            Telerik.WinControls.UI.GridViewMaskBoxColumn gridViewMaskBoxColumn8 = new Telerik.WinControls.UI.GridViewMaskBoxColumn();
            Telerik.WinControls.UI.GridViewMaskBoxColumn gridViewMaskBoxColumn9 = new Telerik.WinControls.UI.GridViewMaskBoxColumn();
            Telerik.WinControls.UI.GridViewMaskBoxColumn gridViewMaskBoxColumn10 = new Telerik.WinControls.UI.GridViewMaskBoxColumn();
            Telerik.WinControls.UI.GridViewMaskBoxColumn gridViewMaskBoxColumn11 = new Telerik.WinControls.UI.GridViewMaskBoxColumn();
            Telerik.WinControls.UI.GridViewMaskBoxColumn gridViewMaskBoxColumn12 = new Telerik.WinControls.UI.GridViewMaskBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.label23 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.GrdBudje = new Telerik.WinControls.UI.RadGridView();
            this.btnAddBudje = new Telerik.WinControls.UI.RadButton();
            this.btnSearch = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.GrdBudje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdBudje.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddBudje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(1044, 9);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(29, 13);
            this.label23.TabIndex = 188;
            this.label23.Text = "سال:";
            // 
            // txtYear
            // 
            this.txtYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtYear.Location = new System.Drawing.Point(985, 7);
            this.txtYear.MaxLength = 4;
            this.txtYear.Name = "txtYear";
            this.txtYear.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtYear.Size = new System.Drawing.Size(53, 20);
            this.txtYear.TabIndex = 187;
            // 
            // GrdBudje
            // 
            this.GrdBudje.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrdBudje.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.GrdBudje.Cursor = System.Windows.Forms.Cursors.Default;
            this.GrdBudje.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.GrdBudje.ForeColor = System.Drawing.Color.Black;
            this.GrdBudje.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GrdBudje.Location = new System.Drawing.Point(12, 43);
            // 
            // 
            // 
            this.GrdBudje.MasterTemplate.AllowAddNewRow = false;
            this.GrdBudje.MasterTemplate.AllowColumnReorder = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "BudjeYear";
            gridViewTextBoxColumn1.HeaderText = "سال";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "BudjeYear";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 46;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "typeHdName";
            gridViewTextBoxColumn2.HeaderText = "عنوان حساب";
            gridViewTextBoxColumn2.Name = "typeHdName";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 123;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "FK_ID_DType";
            gridViewTextBoxColumn3.HeaderText = "شناسه حساب";
            gridViewTextBoxColumn3.Name = "FK_ID_DType";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 45;
            gridViewMaskBoxColumn1.DataType = typeof(double);
            gridViewMaskBoxColumn1.EnableExpressionEditor = false;
            gridViewMaskBoxColumn1.FieldName = "M_B1";
            gridViewMaskBoxColumn1.HeaderText = "فروردین";
            gridViewMaskBoxColumn1.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            gridViewMaskBoxColumn1.Name = "M_B1";
            gridViewMaskBoxColumn1.Width = 82;
            gridViewMaskBoxColumn2.DataType = typeof(double);
            gridViewMaskBoxColumn2.EnableExpressionEditor = false;
            gridViewMaskBoxColumn2.FieldName = "M_B2";
            gridViewMaskBoxColumn2.HeaderText = "اردیبهشت";
            gridViewMaskBoxColumn2.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            gridViewMaskBoxColumn2.Name = "M_B2";
            gridViewMaskBoxColumn2.Width = 68;
            gridViewMaskBoxColumn3.DataType = typeof(double);
            gridViewMaskBoxColumn3.EnableExpressionEditor = false;
            gridViewMaskBoxColumn3.FieldName = "M_B3";
            gridViewMaskBoxColumn3.HeaderText = "خرداد";
            gridViewMaskBoxColumn3.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            gridViewMaskBoxColumn3.Name = "M_B3";
            gridViewMaskBoxColumn3.Width = 69;
            gridViewMaskBoxColumn4.DataType = typeof(double);
            gridViewMaskBoxColumn4.EnableExpressionEditor = false;
            gridViewMaskBoxColumn4.FieldName = "M_B4";
            gridViewMaskBoxColumn4.HeaderText = "تیر";
            gridViewMaskBoxColumn4.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            gridViewMaskBoxColumn4.Name = "M_B4";
            gridViewMaskBoxColumn4.Width = 80;
            gridViewMaskBoxColumn5.DataType = typeof(double);
            gridViewMaskBoxColumn5.EnableExpressionEditor = false;
            gridViewMaskBoxColumn5.FieldName = "M_B5";
            gridViewMaskBoxColumn5.HeaderText = "مرداد";
            gridViewMaskBoxColumn5.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            gridViewMaskBoxColumn5.Name = "M_B5";
            gridViewMaskBoxColumn5.Width = 69;
            gridViewMaskBoxColumn6.DataType = typeof(double);
            gridViewMaskBoxColumn6.EnableExpressionEditor = false;
            gridViewMaskBoxColumn6.FieldName = "M_B6";
            gridViewMaskBoxColumn6.HeaderText = "شهریور";
            gridViewMaskBoxColumn6.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            gridViewMaskBoxColumn6.Name = "M_B6";
            gridViewMaskBoxColumn6.Width = 78;
            gridViewMaskBoxColumn7.DataType = typeof(double);
            gridViewMaskBoxColumn7.EnableExpressionEditor = false;
            gridViewMaskBoxColumn7.FieldName = "M_B7";
            gridViewMaskBoxColumn7.HeaderText = "مهر";
            gridViewMaskBoxColumn7.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            gridViewMaskBoxColumn7.Name = "M_B7";
            gridViewMaskBoxColumn7.Width = 77;
            gridViewMaskBoxColumn8.DataType = typeof(double);
            gridViewMaskBoxColumn8.EnableExpressionEditor = false;
            gridViewMaskBoxColumn8.FieldName = "M_B8";
            gridViewMaskBoxColumn8.HeaderText = "آبان";
            gridViewMaskBoxColumn8.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            gridViewMaskBoxColumn8.Name = "M_B8";
            gridViewMaskBoxColumn8.Width = 75;
            gridViewMaskBoxColumn9.DataType = typeof(double);
            gridViewMaskBoxColumn9.EnableExpressionEditor = false;
            gridViewMaskBoxColumn9.FieldName = "M_B9";
            gridViewMaskBoxColumn9.HeaderText = "آذر";
            gridViewMaskBoxColumn9.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            gridViewMaskBoxColumn9.Name = "M_B9";
            gridViewMaskBoxColumn9.Width = 79;
            gridViewMaskBoxColumn10.DataType = typeof(double);
            gridViewMaskBoxColumn10.EnableExpressionEditor = false;
            gridViewMaskBoxColumn10.FieldName = "M_B10";
            gridViewMaskBoxColumn10.HeaderText = "دی";
            gridViewMaskBoxColumn10.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            gridViewMaskBoxColumn10.Name = "M_B10";
            gridViewMaskBoxColumn10.Width = 62;
            gridViewMaskBoxColumn11.DataType = typeof(double);
            gridViewMaskBoxColumn11.EnableExpressionEditor = false;
            gridViewMaskBoxColumn11.FieldName = "M_B11";
            gridViewMaskBoxColumn11.HeaderText = "بهمن";
            gridViewMaskBoxColumn11.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            gridViewMaskBoxColumn11.Name = "M_B11";
            gridViewMaskBoxColumn12.DataType = typeof(double);
            gridViewMaskBoxColumn12.EnableExpressionEditor = false;
            gridViewMaskBoxColumn12.FieldName = "M_B12";
            gridViewMaskBoxColumn12.HeaderText = "اسفند";
            gridViewMaskBoxColumn12.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            gridViewMaskBoxColumn12.Name = "M_B12";
            this.GrdBudje.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewMaskBoxColumn1,
            gridViewMaskBoxColumn2,
            gridViewMaskBoxColumn3,
            gridViewMaskBoxColumn4,
            gridViewMaskBoxColumn5,
            gridViewMaskBoxColumn6,
            gridViewMaskBoxColumn7,
            gridViewMaskBoxColumn8,
            gridViewMaskBoxColumn9,
            gridViewMaskBoxColumn10,
            gridViewMaskBoxColumn11,
            gridViewMaskBoxColumn12});
            this.GrdBudje.MasterTemplate.EnableAlternatingRowColor = true;
            this.GrdBudje.MasterTemplate.EnableFiltering = true;
            this.GrdBudje.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GrdBudje.Name = "GrdBudje";
            this.GrdBudje.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GrdBudje.Size = new System.Drawing.Size(1061, 538);
            this.GrdBudje.TabIndex = 189;
            this.GrdBudje.Text = "radGridView1";
            this.GrdBudje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GrdBudje_KeyPress);
            // 
            // btnAddBudje
            // 
            this.btnAddBudje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddBudje.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAddBudje.Image = global::ET.Properties.Resources.ok;
            this.btnAddBudje.Location = new System.Drawing.Point(898, 3);
            this.btnAddBudje.Name = "btnAddBudje";
            this.btnAddBudje.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnAddBudje.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAddBudje.Size = new System.Drawing.Size(31, 25);
            this.btnAddBudje.TabIndex = 355;
            this.btnAddBudje.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddBudje.Click += new System.EventHandler(this.btnAddBudje_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSearch.Image = global::ET.Properties.Resources.Search;
            this.btnSearch.Location = new System.Drawing.Point(948, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSearch.Size = new System.Drawing.Size(31, 25);
            this.btnSearch.TabIndex = 356;
            this.btnSearch.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // FrmBudjeBarname
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 593);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnAddBudje);
            this.Controls.Add(this.GrdBudje);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtYear);
            this.Name = "FrmBudjeBarname";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "ثبت بودجه";
            this.Load += new System.EventHandler(this.FrmBudjeBarname_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrdBudje.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdBudje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddBudje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtYear;
        private Telerik.WinControls.UI.RadGridView GrdBudje;
        private Telerik.WinControls.UI.RadButton btnAddBudje;
        private Telerik.WinControls.UI.RadButton btnSearch;
    }
}

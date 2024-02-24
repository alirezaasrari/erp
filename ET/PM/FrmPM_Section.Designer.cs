namespace ET
{
    partial class FrmPM_Section
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
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewRelation gridViewRelation1 = new Telerik.WinControls.UI.GridViewRelation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPM_Section));
            this.gridViewTemplate1 = new Telerik.WinControls.UI.GridViewTemplate();
            this.grd_section = new Telerik.WinControls.UI.RadGridView();
            this.btn_newSection = new Telerik.WinControls.UI.RadButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_deleteSection = new Telerik.WinControls.UI.RadButton();
            this.gb_R_Section_SparePart = new Telerik.WinControls.UI.RadGroupBox();
            this.lbl_vahed = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.btn_section = new Telerik.WinControls.UI.RadButton();
            this.atxb_ID_Spart = new Telerik.WinControls.UI.RadAutoCompleteBox();
            this.txb_some_much = new Telerik.WinControls.UI.RadTextBox();
            this.btn_New_SS = new Telerik.WinControls.UI.RadButton();
            this.btn_Del_SS = new Telerik.WinControls.UI.RadButton();
            this.btn_Add_SS = new Telerik.WinControls.UI.RadButton();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.btn_editSection = new Telerik.WinControls.UI.RadButton();
            this.btn_addSection = new Telerik.WinControls.UI.RadButton();
            this.txb_namesection = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTemplate1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_section)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_section.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_newSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_deleteSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gb_R_Section_SparePart)).BeginInit();
            this.gb_R_Section_SparePart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_vahed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_section)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.atxb_ID_Spart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txb_some_much)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_New_SS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Del_SS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Add_SS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_editSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_addSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txb_namesection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridViewTemplate1
            // 
            this.gridViewTemplate1.AutoGenerateColumns = false;
            this.gridViewTemplate1.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "ID_spare_part";
            gridViewTextBoxColumn1.HeaderText = "ID_spare_part";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "ID_spare_part";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "FK_ID_section";
            gridViewTextBoxColumn2.HeaderText = "FK_ID_section";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "FK_ID_section";
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "NKala";
            gridViewTextBoxColumn3.HeaderText = "نام قطعات";
            gridViewTextBoxColumn3.Name = "NKala";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "ID_sectionANDsparepart";
            gridViewTextBoxColumn4.HeaderText = "ID_sectionANDsparepart";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "ID_sectionANDsparepart";
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "some_much";
            gridViewTextBoxColumn5.HeaderText = "مقدار/تعداد";
            gridViewTextBoxColumn5.Name = "some_much";
            gridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "NameVahed";
            gridViewTextBoxColumn6.HeaderText = "واحد";
            gridViewTextBoxColumn6.Name = "NameVahed";
            gridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.gridViewTemplate1.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.gridViewTemplate1.ShowRowHeaderColumn = false;
            this.gridViewTemplate1.ViewDefinition = tableViewDefinition1;
            // 
            // grd_section
            // 
            this.grd_section.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd_section.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grd_section.Cursor = System.Windows.Forms.Cursors.Default;
            this.grd_section.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.grd_section.ForeColor = System.Drawing.Color.Black;
            this.grd_section.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grd_section.Location = new System.Drawing.Point(12, 131);
            // 
            // 
            // 
            this.grd_section.MasterTemplate.AllowAddNewRow = false;
            this.grd_section.MasterTemplate.AllowColumnReorder = false;
            this.grd_section.MasterTemplate.AutoGenerateColumns = false;
            this.grd_section.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "ID_Section";
            gridViewTextBoxColumn7.HeaderText = "کد قسمت";
            gridViewTextBoxColumn7.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn7.IsVisible = false;
            gridViewTextBoxColumn7.Name = "ID_Section";
            gridViewTextBoxColumn7.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending;
            gridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn7.Width = 90;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "N_section";
            gridViewTextBoxColumn8.HeaderText = "نام قسمت";
            gridViewTextBoxColumn8.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn8.Name = "N_section";
            gridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn8.Width = 536;
            this.grd_section.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.grd_section.MasterTemplate.EnableFiltering = true;
            this.grd_section.MasterTemplate.ShowGroupedColumns = true;
            this.grd_section.MasterTemplate.ShowRowHeaderColumn = false;
            sortDescriptor1.PropertyName = "ID_Section";
            this.grd_section.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.grd_section.MasterTemplate.Templates.AddRange(new Telerik.WinControls.UI.GridViewTemplate[] {
            this.gridViewTemplate1});
            this.grd_section.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grd_section.Name = "grd_section";
            this.grd_section.ReadOnly = true;
            gridViewRelation1.ChildColumnNames = ((System.Collections.Specialized.StringCollection)(resources.GetObject("gridViewRelation1.ChildColumnNames")));
            gridViewRelation1.ChildTemplate = this.gridViewTemplate1;
            gridViewRelation1.ParentColumnNames = ((System.Collections.Specialized.StringCollection)(resources.GetObject("gridViewRelation1.ParentColumnNames")));
            gridViewRelation1.ParentTemplate = this.grd_section.MasterTemplate;
            gridViewRelation1.RelationName = "قسمت قطعه";
            this.grd_section.Relations.AddRange(new Telerik.WinControls.UI.GridViewRelation[] {
            gridViewRelation1});
            this.grd_section.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grd_section.Size = new System.Drawing.Size(558, 347);
            this.grd_section.TabIndex = 17;
            this.grd_section.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grd_section_CellDoubleClick);
            // 
            // btn_newSection
            // 
            this.btn_newSection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_newSection.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_newSection.ImageIndex = 0;
            this.btn_newSection.ImageList = this.imageList1;
            this.btn_newSection.Location = new System.Drawing.Point(12, 12);
            this.btn_newSection.Name = "btn_newSection";
            this.btn_newSection.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btn_newSection.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_newSection.Size = new System.Drawing.Size(60, 25);
            this.btn_newSection.TabIndex = 15;
            this.btn_newSection.Text = "جدید";
            this.btn_newSection.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_newSection.Click += new System.EventHandler(this.btn_newSection_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ADD.gif");
            this.imageList1.Images.SetKeyName(1, "Attach.gif");
            this.imageList1.Images.SetKeyName(2, "Buy.gif");
            this.imageList1.Images.SetKeyName(3, "Cancel.gif");
            this.imageList1.Images.SetKeyName(4, "Download.gif");
            this.imageList1.Images.SetKeyName(5, "Edit.gif");
            this.imageList1.Images.SetKeyName(6, "Help.gif");
            this.imageList1.Images.SetKeyName(7, "Next.gif");
            this.imageList1.Images.SetKeyName(8, "ok.gif");
            this.imageList1.Images.SetKeyName(9, "Open.gif");
            this.imageList1.Images.SetKeyName(10, "Previous.gif");
            this.imageList1.Images.SetKeyName(11, "print.gif");
            this.imageList1.Images.SetKeyName(12, "Refresh.gif");
            this.imageList1.Images.SetKeyName(13, "Remove.gif");
            this.imageList1.Images.SetKeyName(14, "Save.gif");
            this.imageList1.Images.SetKeyName(15, "Search.gif");
            this.imageList1.Images.SetKeyName(16, "UpLoad.gif");
            // 
            // btn_deleteSection
            // 
            this.btn_deleteSection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_deleteSection.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_deleteSection.ImageIndex = 13;
            this.btn_deleteSection.ImageList = this.imageList1;
            this.btn_deleteSection.Location = new System.Drawing.Point(78, 12);
            this.btn_deleteSection.Name = "btn_deleteSection";
            this.btn_deleteSection.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btn_deleteSection.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_deleteSection.Size = new System.Drawing.Size(60, 25);
            this.btn_deleteSection.TabIndex = 14;
            this.btn_deleteSection.Text = "حذف";
            this.btn_deleteSection.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_deleteSection.Click += new System.EventHandler(this.btn_deleteSection_Click);
            // 
            // gb_R_Section_SparePart
            // 
            this.gb_R_Section_SparePart.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gb_R_Section_SparePart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_R_Section_SparePart.Controls.Add(this.lbl_vahed);
            this.gb_R_Section_SparePart.Controls.Add(this.radLabel6);
            this.gb_R_Section_SparePart.Controls.Add(this.btn_section);
            this.gb_R_Section_SparePart.Controls.Add(this.atxb_ID_Spart);
            this.gb_R_Section_SparePart.Controls.Add(this.txb_some_much);
            this.gb_R_Section_SparePart.Controls.Add(this.btn_New_SS);
            this.gb_R_Section_SparePart.Controls.Add(this.btn_Del_SS);
            this.gb_R_Section_SparePart.Controls.Add(this.btn_Add_SS);
            this.gb_R_Section_SparePart.Controls.Add(this.radLabel7);
            this.gb_R_Section_SparePart.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_R_Section_SparePart.HeaderText = "ارتباط قطعه و قسمت";
            this.gb_R_Section_SparePart.Location = new System.Drawing.Point(12, 43);
            this.gb_R_Section_SparePart.Name = "gb_R_Section_SparePart";
            this.gb_R_Section_SparePart.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gb_R_Section_SparePart.Size = new System.Drawing.Size(558, 82);
            this.gb_R_Section_SparePart.TabIndex = 16;
            this.gb_R_Section_SparePart.Text = "ارتباط قطعه و قسمت";
            // 
            // lbl_vahed
            // 
            this.lbl_vahed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_vahed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbl_vahed.Location = new System.Drawing.Point(369, 56);
            this.lbl_vahed.Name = "lbl_vahed";
            this.lbl_vahed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_vahed.Size = new System.Drawing.Size(12, 17);
            this.lbl_vahed.TabIndex = 41;
            this.lbl_vahed.Text = "_";
            this.lbl_vahed.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // radLabel6
            // 
            this.radLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radLabel6.Location = new System.Drawing.Point(495, 56);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radLabel6.Size = new System.Drawing.Size(58, 17);
            this.radLabel6.TabIndex = 40;
            this.radLabel6.Text = "مقدار/تعداد";
            this.radLabel6.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // btn_section
            // 
            this.btn_section.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_section.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_section.Location = new System.Drawing.Point(5, 22);
            this.btn_section.Name = "btn_section";
            this.btn_section.Size = new System.Drawing.Size(71, 24);
            this.btn_section.TabIndex = 8;
            this.btn_section.Text = "ایجاد قطعه";
            this.btn_section.Click += new System.EventHandler(this.btn_section_Click);
            // 
            // atxb_ID_Spart
            // 
            this.atxb_ID_Spart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.atxb_ID_Spart.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.atxb_ID_Spart.Location = new System.Drawing.Point(82, 21);
            this.atxb_ID_Spart.Name = "atxb_ID_Spart";
            this.atxb_ID_Spart.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.atxb_ID_Spart.Size = new System.Drawing.Size(397, 26);
            this.atxb_ID_Spart.TabIndex = 1;
            this.atxb_ID_Spart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.atxb_ID_Spart.WordWrap = false;
            this.atxb_ID_Spart.TextChanged += new System.EventHandler(this.atxb_ID_Spart_TextChanged);
            // 
            // txb_some_much
            // 
            this.txb_some_much.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_some_much.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txb_some_much.Location = new System.Drawing.Point(421, 54);
            this.txb_some_much.Name = "txb_some_much";
            this.txb_some_much.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txb_some_much.Size = new System.Drawing.Size(58, 19);
            this.txb_some_much.TabIndex = 11;
            this.txb_some_much.Text = "1";
            this.txb_some_much.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_New_SS
            // 
            this.btn_New_SS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_New_SS.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_New_SS.ImageIndex = 0;
            this.btn_New_SS.ImageList = this.imageList1;
            this.btn_New_SS.Location = new System.Drawing.Point(5, 52);
            this.btn_New_SS.Name = "btn_New_SS";
            this.btn_New_SS.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btn_New_SS.Size = new System.Drawing.Size(60, 25);
            this.btn_New_SS.TabIndex = 5;
            this.btn_New_SS.Text = "جدید";
            this.btn_New_SS.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_New_SS.Click += new System.EventHandler(this.btn_New_SS_Click);
            // 
            // btn_Del_SS
            // 
            this.btn_Del_SS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Del_SS.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Del_SS.ImageIndex = 13;
            this.btn_Del_SS.ImageList = this.imageList1;
            this.btn_Del_SS.Location = new System.Drawing.Point(71, 52);
            this.btn_Del_SS.Name = "btn_Del_SS";
            this.btn_Del_SS.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btn_Del_SS.Size = new System.Drawing.Size(60, 25);
            this.btn_Del_SS.TabIndex = 4;
            this.btn_Del_SS.Text = "حذف";
            this.btn_Del_SS.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Del_SS.Click += new System.EventHandler(this.btn_Del_SS_Click);
            // 
            // btn_Add_SS
            // 
            this.btn_Add_SS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Add_SS.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add_SS.ImageIndex = 14;
            this.btn_Add_SS.ImageList = this.imageList1;
            this.btn_Add_SS.Location = new System.Drawing.Point(137, 52);
            this.btn_Add_SS.Name = "btn_Add_SS";
            this.btn_Add_SS.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btn_Add_SS.Size = new System.Drawing.Size(60, 25);
            this.btn_Add_SS.TabIndex = 2;
            this.btn_Add_SS.Text = "ثبت";
            this.btn_Add_SS.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Add_SS.Click += new System.EventHandler(this.btn_Add_SS_Click);
            // 
            // radLabel7
            // 
            this.radLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radLabel7.Location = new System.Drawing.Point(485, 26);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(68, 17);
            this.radLabel7.TabIndex = 7;
            this.radLabel7.Text = " انتخاب قطعه";
            this.radLabel7.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // btn_editSection
            // 
            this.btn_editSection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_editSection.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editSection.ImageIndex = 5;
            this.btn_editSection.ImageList = this.imageList1;
            this.btn_editSection.Location = new System.Drawing.Point(144, 12);
            this.btn_editSection.Name = "btn_editSection";
            this.btn_editSection.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btn_editSection.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_editSection.Size = new System.Drawing.Size(60, 25);
            this.btn_editSection.TabIndex = 13;
            this.btn_editSection.Text = "ویرایش";
            this.btn_editSection.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_editSection.Click += new System.EventHandler(this.btn_editSection_Click);
            // 
            // btn_addSection
            // 
            this.btn_addSection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_addSection.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addSection.ImageIndex = 14;
            this.btn_addSection.ImageList = this.imageList1;
            this.btn_addSection.Location = new System.Drawing.Point(210, 12);
            this.btn_addSection.Name = "btn_addSection";
            this.btn_addSection.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btn_addSection.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_addSection.Size = new System.Drawing.Size(60, 25);
            this.btn_addSection.TabIndex = 12;
            this.btn_addSection.Text = "ثبت";
            this.btn_addSection.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_addSection.Click += new System.EventHandler(this.btn_addSection_Click);
            // 
            // txb_namesection
            // 
            this.txb_namesection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_namesection.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txb_namesection.Location = new System.Drawing.Point(286, 14);
            this.txb_namesection.Name = "txb_namesection";
            this.txb_namesection.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txb_namesection.Size = new System.Drawing.Size(221, 19);
            this.txb_namesection.TabIndex = 11;
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radLabel1.Location = new System.Drawing.Point(513, 16);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radLabel1.Size = new System.Drawing.Size(57, 17);
            this.radLabel1.TabIndex = 19;
            this.radLabel1.Text = "نام قسمت";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // FrmPM_Section
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 490);
            this.Controls.Add(this.btn_newSection);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.btn_deleteSection);
            this.Controls.Add(this.gb_R_Section_SparePart);
            this.Controls.Add(this.txb_namesection);
            this.Controls.Add(this.grd_section);
            this.Controls.Add(this.btn_editSection);
            this.Controls.Add(this.btn_addSection);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPM_Section";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = true;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ورود اطلاعات قسمت دستگاه";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.FrmPM_Section_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTemplate1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_section.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_section)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_newSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_deleteSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gb_R_Section_SparePart)).EndInit();
            this.gb_R_Section_SparePart.ResumeLayout(false);
            this.gb_R_Section_SparePart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_vahed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_section)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.atxb_ID_Spart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txb_some_much)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_New_SS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Del_SS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Add_SS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_editSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_addSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txb_namesection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btn_newSection;
        private Telerik.WinControls.UI.RadButton btn_deleteSection;
        private Telerik.WinControls.UI.RadGroupBox gb_R_Section_SparePart;
        private Telerik.WinControls.UI.RadAutoCompleteBox atxb_ID_Spart;
        private Telerik.WinControls.UI.RadButton btn_New_SS;
        private Telerik.WinControls.UI.RadButton btn_Del_SS;
        private Telerik.WinControls.UI.RadButton btn_Add_SS;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadButton btn_editSection;
        private Telerik.WinControls.UI.RadButton btn_addSection;
        private Telerik.WinControls.UI.RadGridView grd_section;
        private Telerik.WinControls.UI.GridViewTemplate gridViewTemplate1;
        private Telerik.WinControls.UI.RadTextBox txb_namesection;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.ImageList imageList1;
        private Telerik.WinControls.UI.RadButton btn_section;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadTextBox txb_some_much;
        private Telerik.WinControls.UI.RadLabel lbl_vahed;
    }
}

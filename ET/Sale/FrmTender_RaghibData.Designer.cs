namespace ET
{
    partial class FrmTender_RaghibData
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.grdRaghib = new Telerik.WinControls.UI.RadGridView();
            this.txtRaghibName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTafsili = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new Telerik.WinControls.UI.RadButton();
            this.btnEdit = new Telerik.WinControls.UI.RadButton();
            this.btnDel = new Telerik.WinControls.UI.RadButton();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdRaghib)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRaghib.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grdRaghib
            // 
            this.grdRaghib.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdRaghib.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grdRaghib.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdRaghib.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.grdRaghib.ForeColor = System.Drawing.Color.Black;
            this.grdRaghib.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdRaghib.Location = new System.Drawing.Point(12, 78);
            // 
            // 
            // 
            this.grdRaghib.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "IdRaghib";
            gridViewTextBoxColumn4.HeaderText = "IdRaghib";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "IdRaghib";
            gridViewTextBoxColumn4.Width = 42;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "NameRaghib";
            gridViewTextBoxColumn5.HeaderText = "نام رقیب";
            gridViewTextBoxColumn5.Name = "NameRaghib";
            gridViewTextBoxColumn5.Width = 282;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "Tafsili";
            gridViewTextBoxColumn6.HeaderText = "تفصیلی";
            gridViewTextBoxColumn6.Name = "Tafsili";
            gridViewTextBoxColumn6.Width = 107;
            this.grdRaghib.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.grdRaghib.MasterTemplate.EnableFiltering = true;
            this.grdRaghib.MasterTemplate.EnableGrouping = false;
            this.grdRaghib.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grdRaghib.Name = "grdRaghib";
            this.grdRaghib.ReadOnly = true;
            this.grdRaghib.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdRaghib.Size = new System.Drawing.Size(511, 312);
            this.grdRaghib.TabIndex = 269;
            this.grdRaghib.TabStop = false;
            this.grdRaghib.Text = "radGridView1";
            this.grdRaghib.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdRaghib_CellClick);
            this.grdRaghib.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdRaghib_CellDoubleClick);
            // 
            // txtRaghibName
            // 
            this.txtRaghibName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRaghibName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRaghibName.Location = new System.Drawing.Point(274, 39);
            this.txtRaghibName.Name = "txtRaghibName";
            this.txtRaghibName.Size = new System.Drawing.Size(149, 21);
            this.txtRaghibName.TabIndex = 271;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(429, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 13);
            this.label9.TabIndex = 270;
            this.label9.Text = "کد تفصیلی رقیب:";
            // 
            // txtTafsili
            // 
            this.txtTafsili.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTafsili.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTafsili.Location = new System.Drawing.Point(274, 12);
            this.txtTafsili.Name = "txtTafsili";
            this.txtTafsili.Size = new System.Drawing.Size(149, 21);
            this.txtTafsili.TabIndex = 273;
            this.txtTafsili.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTafsili_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(467, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 272;
            this.label1.Text = "نام رقیب:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnRefresh.Image = global::ET.Properties.Resources.Refresh;
            this.btnRefresh.Location = new System.Drawing.Point(12, 47);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnRefresh.Size = new System.Drawing.Size(37, 25);
            this.btnRefresh.TabIndex = 302;
            this.btnRefresh.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Enabled = false;
            this.btnEdit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnEdit.Image = global::ET.Properties.Resources.Edit;
            this.btnEdit.Location = new System.Drawing.Point(96, 47);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnEdit.Size = new System.Drawing.Size(37, 25);
            this.btnEdit.TabIndex = 301;
            this.btnEdit.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.Enabled = false;
            this.btnDel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDel.Image = global::ET.Properties.Resources.Cancel;
            this.btnDel.Location = new System.Drawing.Point(55, 47);
            this.btnDel.Name = "btnDel";
            this.btnDel.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnDel.Size = new System.Drawing.Size(35, 25);
            this.btnDel.TabIndex = 300;
            this.btnDel.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAdd.Image = global::ET.Properties.Resources.ADD;
            this.btnAdd.Location = new System.Drawing.Point(139, 47);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnAdd.Size = new System.Drawing.Size(37, 25);
            this.btnAdd.TabIndex = 299;
            this.btnAdd.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // FrmTender_RaghibData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 402);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtTafsili);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRaghibName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.grdRaghib);
            this.Name = "FrmTender_RaghibData";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "اطلاعات رقیب ها";
            this.Load += new System.EventHandler(this.FrmTender_RaghibData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdRaghib.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRaghib)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grdRaghib;
        private System.Windows.Forms.TextBox txtRaghibName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTafsili;
        private System.Windows.Forms.Label label1;
        public Telerik.WinControls.UI.RadButton btnRefresh;
        public Telerik.WinControls.UI.RadButton btnEdit;
        public Telerik.WinControls.UI.RadButton btnDel;
        public Telerik.WinControls.UI.RadButton btnAdd;
    }
}

namespace ET
{
    partial class Frm_Customer_title
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Customer_title));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.btn_ADD = new Telerik.WinControls.UI.RadButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_Delete = new Telerik.WinControls.UI.RadButton();
            this.btn_Edit = new Telerik.WinControls.UI.RadButton();
            this.btn_Save = new Telerik.WinControls.UI.RadButton();
            this.txb_N = new Telerik.WinControls.UI.RadTextBox();
            this.grd = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.btn_ADD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Save)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txb_N)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_ADD
            // 
            this.btn_ADD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ADD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ADD.ImageIndex = 0;
            this.btn_ADD.ImageList = this.imageList1;
            this.btn_ADD.Location = new System.Drawing.Point(12, 12);
            this.btn_ADD.Name = "btn_ADD";
            this.btn_ADD.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btn_ADD.Size = new System.Drawing.Size(60, 25);
            this.btn_ADD.TabIndex = 4;
            this.btn_ADD.Text = "جدید";
            this.btn_ADD.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ADD.Click += new System.EventHandler(this.btn_ADD_Click);
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
            // btn_Delete
            // 
            this.btn_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Delete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.ImageIndex = 13;
            this.btn_Delete.ImageList = this.imageList1;
            this.btn_Delete.Location = new System.Drawing.Point(78, 12);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btn_Delete.Size = new System.Drawing.Size(60, 25);
            this.btn_Delete.TabIndex = 3;
            this.btn_Delete.Text = "حذف";
            this.btn_Delete.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Edit
            // 
            this.btn_Edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Edit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Edit.ImageIndex = 5;
            this.btn_Edit.ImageList = this.imageList1;
            this.btn_Edit.Location = new System.Drawing.Point(144, 12);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btn_Edit.Size = new System.Drawing.Size(60, 25);
            this.btn_Edit.TabIndex = 2;
            this.btn_Edit.Text = "ویرایش";
            this.btn_Edit.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Save.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.ImageIndex = 14;
            this.btn_Save.ImageList = this.imageList1;
            this.btn_Save.Location = new System.Drawing.Point(210, 12);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btn_Save.Size = new System.Drawing.Size(60, 25);
            this.btn_Save.TabIndex = 1;
            this.btn_Save.Text = "ثبت";
            this.btn_Save.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txb_N
            // 
            this.txb_N.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_N.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_N.Location = new System.Drawing.Point(351, 14);
            this.txb_N.Name = "txb_N";
            this.txb_N.NullText = "سمت";
            this.txb_N.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txb_N.Size = new System.Drawing.Size(219, 19);
            this.txb_N.TabIndex = 0;
            // 
            // grd
            // 
            this.grd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grd.Cursor = System.Windows.Forms.Cursors.Default;
            this.grd.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.grd.ForeColor = System.Drawing.Color.Black;
            this.grd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grd.Location = new System.Drawing.Point(12, 43);
            // 
            // grd
            // 
            this.grd.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "ID_Title";
            gridViewTextBoxColumn1.HeaderText = "کد سمت";
            gridViewTextBoxColumn1.Name = "ID_Title";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn1.Width = 86;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "N_Title";
            gridViewTextBoxColumn2.HeaderText = "شرح سمت";
            gridViewTextBoxColumn2.Name = "N_Title";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn2.Width = 171;
            this.grd.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2});
            this.grd.MasterTemplate.EnableFiltering = true;
            this.grd.Name = "grd";
            this.grd.ReadOnly = true;
            this.grd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grd.Size = new System.Drawing.Size(558, 395);
            this.grd.TabIndex = 3;
            this.grd.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grd_CellDoubleClick);
            // 
            // Frm_Customer_title
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 450);
            this.Controls.Add(this.btn_ADD);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Edit);
            this.Controls.Add(this.grd);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.txb_N);
            this.Name = "Frm_Customer_title";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "ثبت سمت";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.Frm_Supplier_semat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btn_ADD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Save)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txb_N)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btn_ADD;
        private System.Windows.Forms.ImageList imageList1;
        private Telerik.WinControls.UI.RadButton btn_Delete;
        private Telerik.WinControls.UI.RadButton btn_Edit;
        private Telerik.WinControls.UI.RadButton btn_Save;
        private Telerik.WinControls.UI.RadTextBox txb_N;
        private Telerik.WinControls.UI.RadGridView grd;

    }
}

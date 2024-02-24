namespace ET
{
    partial class FrmAnbar_GroupKala
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnbar_GroupKala));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.FilterDescriptor filterDescriptor3 = new Telerik.WinControls.Data.FilterDescriptor();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_edit_sparepart = new Telerik.WinControls.UI.RadButton();
            this.btn_del_sparepart = new Telerik.WinControls.UI.RadButton();
            this.btn_add_sparepart = new Telerik.WinControls.UI.RadButton();
            this.txtGroup = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.grdGroupKala = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.btn_edit_sparepart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_del_sparepart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_add_sparepart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupKala)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupKala.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
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
            // btn_edit_sparepart
            // 
            this.btn_edit_sparepart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_edit_sparepart.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_edit_sparepart.ImageIndex = 5;
            this.btn_edit_sparepart.ImageList = this.imageList1;
            this.btn_edit_sparepart.Location = new System.Drawing.Point(107, 217);
            this.btn_edit_sparepart.Name = "btn_edit_sparepart";
            this.btn_edit_sparepart.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btn_edit_sparepart.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_edit_sparepart.Size = new System.Drawing.Size(60, 25);
            this.btn_edit_sparepart.TabIndex = 7;
            this.btn_edit_sparepart.Text = "ویرایش";
            this.btn_edit_sparepart.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_edit_sparepart.Click += new System.EventHandler(this.btn_edit_sparepart_Click);
            // 
            // btn_del_sparepart
            // 
            this.btn_del_sparepart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_del_sparepart.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_del_sparepart.ImageIndex = 13;
            this.btn_del_sparepart.ImageList = this.imageList1;
            this.btn_del_sparepart.Location = new System.Drawing.Point(41, 217);
            this.btn_del_sparepart.Name = "btn_del_sparepart";
            this.btn_del_sparepart.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btn_del_sparepart.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_del_sparepart.Size = new System.Drawing.Size(60, 25);
            this.btn_del_sparepart.TabIndex = 8;
            this.btn_del_sparepart.Text = "حذف";
            this.btn_del_sparepart.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_del_sparepart.Click += new System.EventHandler(this.btn_del_sparepart_Click);
            // 
            // btn_add_sparepart
            // 
            this.btn_add_sparepart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_add_sparepart.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_add_sparepart.ImageIndex = 14;
            this.btn_add_sparepart.ImageList = this.imageList1;
            this.btn_add_sparepart.Location = new System.Drawing.Point(173, 217);
            this.btn_add_sparepart.Name = "btn_add_sparepart";
            this.btn_add_sparepart.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btn_add_sparepart.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_add_sparepart.Size = new System.Drawing.Size(60, 25);
            this.btn_add_sparepart.TabIndex = 6;
            this.btn_add_sparepart.Text = "ثبت";
            this.btn_add_sparepart.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_add_sparepart.Click += new System.EventHandler(this.btn_add_sparepart_Click);
            // 
            // txtGroup
            // 
            this.txtGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGroup.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGroup.Location = new System.Drawing.Point(41, 172);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(153, 21);
            this.txtGroup.TabIndex = 15;
            this.txtGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radLabel3
            // 
            this.radLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radLabel3.Location = new System.Drawing.Point(207, 174);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(43, 17);
            this.radLabel3.TabIndex = 14;
            this.radLabel3.Text = "نام گروه";
            this.radLabel3.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // grdGroupKala
            // 
            this.grdGroupKala.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdGroupKala.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(222)))), ((int)(((byte)(254)))));
            this.grdGroupKala.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdGroupKala.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Bold);
            this.grdGroupKala.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdGroupKala.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdGroupKala.Location = new System.Drawing.Point(12, 10);
            // 
            // grdGroupKala
            // 
            this.grdGroupKala.MasterTemplate.AllowAddNewRow = false;
            this.grdGroupKala.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "IdGroupKala";
            gridViewTextBoxColumn5.HeaderText = "کد گروه";
            gridViewTextBoxColumn5.Name = "IdGroupKala";
            gridViewTextBoxColumn5.Width = 46;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "NameGroupKala";
            gridViewTextBoxColumn6.HeaderText = "نام گروه";
            gridViewTextBoxColumn6.Name = "NameGroupKala";
            gridViewTextBoxColumn6.Width = 153;
            this.grdGroupKala.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.grdGroupKala.MasterTemplate.EnableFiltering = true;
            filterDescriptor3.Operator = Telerik.WinControls.Data.FilterOperator.IsGreaterThanOrEqualTo;
            this.grdGroupKala.MasterTemplate.FilterDescriptors.AddRange(new Telerik.WinControls.Data.FilterDescriptor[] {
            filterDescriptor3});
            this.grdGroupKala.Name = "grdGroupKala";
            this.grdGroupKala.ReadOnly = true;
            this.grdGroupKala.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdGroupKala.Size = new System.Drawing.Size(250, 144);
            this.grdGroupKala.TabIndex = 121;
            this.grdGroupKala.Text = "radGridView1";
            this.grdGroupKala.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdGroupKala_CellDoubleClick);
            // 
            // FrmPub_GroupKala
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 254);
            this.Controls.Add(this.grdGroupKala);
            this.Controls.Add(this.txtGroup);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.btn_edit_sparepart);
            this.Controls.Add(this.btn_del_sparepart);
            this.Controls.Add(this.btn_add_sparepart);
            this.Name = "FrmPub_GroupKala";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "گروه کالا";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.FrmPub_GroupKala_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btn_edit_sparepart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_del_sparepart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_add_sparepart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupKala.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupKala)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private Telerik.WinControls.UI.RadButton btn_edit_sparepart;
        private Telerik.WinControls.UI.RadButton btn_del_sparepart;
        private Telerik.WinControls.UI.RadButton btn_add_sparepart;
        private Telerik.WinControls.UI.RadTextBox txtGroup;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadGridView grdGroupKala;
    }
}

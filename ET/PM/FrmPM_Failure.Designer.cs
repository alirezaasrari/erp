namespace ET
{
    partial class FrmPM_Failure
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPM_Failure));
            this.grdFailure = new Telerik.WinControls.UI.RadGridView();
            this.btnDelete = new Telerik.WinControls.UI.RadButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnUpdate = new Telerik.WinControls.UI.RadButton();
            this.btn_save = new Telerik.WinControls.UI.RadButton();
            this.txb_reason_delay = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grdFailure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFailure.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_save)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txb_reason_delay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grdFailure
            // 
            this.grdFailure.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFailure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grdFailure.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdFailure.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.grdFailure.ForeColor = System.Drawing.Color.Black;
            this.grdFailure.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdFailure.Location = new System.Drawing.Point(12, 61);
            // 
            // 
            // 
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "ID_Failure";
            gridViewTextBoxColumn1.HeaderText = "کد خرابی";
            gridViewTextBoxColumn1.Name = "ID_Failure";
            gridViewTextBoxColumn1.Width = 66;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "NFailure";
            gridViewTextBoxColumn2.HeaderText = "شرح خرابی";
            gridViewTextBoxColumn2.Name = "NFailure";
            gridViewTextBoxColumn2.Width = 366;
            this.grdFailure.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2});
            this.grdFailure.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdFailure.Name = "grdFailure";
            this.grdFailure.ReadOnly = true;
            this.grdFailure.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdFailure.Size = new System.Drawing.Size(499, 208);
            this.grdFailure.TabIndex = 0;
            this.grdFailure.Text = "radGridView1";
            this.grdFailure.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdFailure_CellDoubleClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDelete.ImageIndex = 3;
            this.btnDelete.ImageList = this.imageList1;
            this.btnDelete.Location = new System.Drawing.Point(12, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnDelete.Size = new System.Drawing.Size(62, 25);
            this.btnDelete.TabIndex = 149;
            this.btnDelete.Text = "حذف";
            this.btnDelete.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnUpdate.ImageIndex = 5;
            this.btnUpdate.ImageList = this.imageList1;
            this.btnUpdate.Location = new System.Drawing.Point(78, 12);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnUpdate.Size = new System.Drawing.Size(62, 25);
            this.btnUpdate.TabIndex = 148;
            this.btnUpdate.Text = "ویرایش";
            this.btnUpdate.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_save.ImageIndex = 14;
            this.btn_save.ImageList = this.imageList1;
            this.btn_save.Location = new System.Drawing.Point(144, 12);
            this.btn_save.Name = "btn_save";
            this.btn_save.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btn_save.Size = new System.Drawing.Size(62, 25);
            this.btn_save.TabIndex = 147;
            this.btn_save.Text = "ذخیره";
            this.btn_save.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txb_reason_delay
            // 
            this.txb_reason_delay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_reason_delay.AutoSize = false;
            this.txb_reason_delay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_reason_delay.Location = new System.Drawing.Point(212, 12);
            this.txb_reason_delay.Multiline = true;
            this.txb_reason_delay.Name = "txb_reason_delay";
            this.txb_reason_delay.Size = new System.Drawing.Size(233, 43);
            this.txb_reason_delay.TabIndex = 152;
            this.txb_reason_delay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radLabel3
            // 
            this.radLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radLabel3.Location = new System.Drawing.Point(451, 16);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(60, 17);
            this.radLabel3.TabIndex = 151;
            this.radLabel3.Text = "علت خرابی";
            this.radLabel3.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // FrmPM_Failure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 279);
            this.Controls.Add(this.txb_reason_delay);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.grdFailure);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.Name = "FrmPM_Failure";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "فرم شرح خرابی";
            this.Load += new System.EventHandler(this.FrmPM_Failure_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdFailure.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFailure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_save)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txb_reason_delay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grdFailure;
        private Telerik.WinControls.UI.RadButton btnDelete;
        private Telerik.WinControls.UI.RadButton btnUpdate;
        public Telerik.WinControls.UI.RadButton btn_save;
        private System.Windows.Forms.ImageList imageList1;
        public Telerik.WinControls.UI.RadTextBox txb_reason_delay;
        private Telerik.WinControls.UI.RadLabel radLabel3;
    }
}

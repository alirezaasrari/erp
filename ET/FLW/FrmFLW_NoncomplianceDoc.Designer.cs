namespace ET
{
    partial class FrmFLW_NoncomplianceDoc
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
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFLW_NoncomplianceDoc));
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radLabel15 = new Telerik.WinControls.UI.RadLabel();
            this.txtDesc = new Telerik.WinControls.UI.RadTextBox();
            this.btnSabtDoc = new Telerik.WinControls.UI.RadButton();
            this.grdDoc = new Telerik.WinControls.UI.RadGridView();
            this.LoadPic = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSabtDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDoc.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel15
            // 
            this.radLabel15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel15.Location = new System.Drawing.Point(441, 15);
            this.radLabel15.Name = "radLabel15";
            this.radLabel15.Size = new System.Drawing.Size(27, 18);
            this.radLabel15.TabIndex = 362;
            this.radLabel15.Text = "شرح";
            this.radLabel15.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(12, 13);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(423, 20);
            this.txtDesc.TabIndex = 361;
            // 
            // btnSabtDoc
            // 
            this.btnSabtDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSabtDoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSabtDoc.Image = global::ET.Properties.Resources.ADD;
            this.btnSabtDoc.Location = new System.Drawing.Point(545, 12);
            this.btnSabtDoc.Name = "btnSabtDoc";
            this.btnSabtDoc.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnSabtDoc.Size = new System.Drawing.Size(76, 25);
            this.btnSabtDoc.TabIndex = 360;
            this.btnSabtDoc.Text = "افزودن";
            this.btnSabtDoc.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSabtDoc.Click += new System.EventHandler(this.btnSabtDoc_Click);
            // 
            // grdDoc
            // 
            this.grdDoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grdDoc.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdDoc.EnableHotTracking = false;
            this.grdDoc.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.grdDoc.ForeColor = System.Drawing.Color.Black;
            this.grdDoc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdDoc.Location = new System.Drawing.Point(12, 43);
            // 
            // 
            // 
            this.grdDoc.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "IdNoneComolainceDoc";
            gridViewTextBoxColumn1.HeaderText = "IdNoneComolainceDoc";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "IdNoneComolainceDoc";
            gridViewTextBoxColumn1.Width = 122;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "TitleDoc";
            gridViewTextBoxColumn2.HeaderText = "عنوان";
            gridViewTextBoxColumn2.Name = "TitleDoc";
            gridViewTextBoxColumn2.Width = 291;
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.FieldName = "btnEdit";
            gridViewCommandColumn1.HeaderText = "مشاهده";
            gridViewCommandColumn1.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn1.Image")));
            gridViewCommandColumn1.Name = "btnEdit";
            gridViewCommandColumn1.Width = 63;
            gridViewCommandColumn2.EnableExpressionEditor = false;
            gridViewCommandColumn2.FieldName = "btnDelete";
            gridViewCommandColumn2.HeaderText = "حذف";
            gridViewCommandColumn2.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn2.Image")));
            gridViewCommandColumn2.Name = "btnDelete";
            gridViewCommandColumn2.Width = 63;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "DocNoneComolaince";
            gridViewTextBoxColumn3.HeaderText = "DocNoneComolaince";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "DocNoneComolaince";
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "contentType";
            gridViewTextBoxColumn4.HeaderText = "contentType";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "contentType";
            this.grdDoc.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewCommandColumn1,
            gridViewCommandColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.grdDoc.MasterTemplate.EnableGrouping = false;
            this.grdDoc.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdDoc.Name = "grdDoc";
            this.grdDoc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdDoc.ShowGroupPanel = false;
            this.grdDoc.Size = new System.Drawing.Size(609, 262);
            this.grdDoc.TabIndex = 359;
            this.grdDoc.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdDoc_CellClick);
            // 
            // LoadPic
            // 
            this.LoadPic.FileName = "openFileDialog1";
            // 
            // FrmFLW_NoncomplianceDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 317);
            this.Controls.Add(this.radLabel15);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.btnSabtDoc);
            this.Controls.Add(this.grdDoc);
            this.Name = "FrmFLW_NoncomplianceDoc";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مستندات عدم انطباق";
            this.Load += new System.EventHandler(this.FrmFLW_NoncomplianceDoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSabtDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDoc.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel15;
        private Telerik.WinControls.UI.RadTextBox txtDesc;
        public Telerik.WinControls.UI.RadButton btnSabtDoc;
        private Telerik.WinControls.UI.RadGridView grdDoc;
        private System.Windows.Forms.OpenFileDialog LoadPic;
    }
}

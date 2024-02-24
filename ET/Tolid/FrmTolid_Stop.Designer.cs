namespace ET
{
    partial class FrmTolid_Stop
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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.Data.FilterDescriptor filterDescriptor1 = new Telerik.WinControls.Data.FilterDescriptor();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn2 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.label34 = new System.Windows.Forms.Label();
            this.txtDescStop = new System.Windows.Forms.TextBox();
            this.grdStop = new Telerik.WinControls.UI.RadGridView();
            this.btnDelete = new Telerik.WinControls.UI.RadButton();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.btnUpdate = new Telerik.WinControls.UI.RadButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdStop = new System.Windows.Forms.TextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.chkIsOk = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStop.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label34
            // 
            this.label34.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(508, 20);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(60, 13);
            this.label34.TabIndex = 289;
            this.label34.Text = "شرح توقف:";
            // 
            // txtDescStop
            // 
            this.txtDescStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescStop.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescStop.Location = new System.Drawing.Point(311, 17);
            this.txtDescStop.Name = "txtDescStop";
            this.txtDescStop.Size = new System.Drawing.Size(182, 21);
            this.txtDescStop.TabIndex = 287;
            // 
            // grdStop
            // 
            this.grdStop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grdStop.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdStop.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.grdStop.ForeColor = System.Drawing.Color.Black;
            this.grdStop.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdStop.Location = new System.Drawing.Point(12, 106);
            // 
            // 
            // 
            this.grdStop.MasterTemplate.AllowAddNewRow = false;
            this.grdStop.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "ID_stop";
            gridViewTextBoxColumn1.HeaderText = "کد";
            gridViewTextBoxColumn1.Name = "ID_stop";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "Desc_stop";
            gridViewTextBoxColumn2.HeaderText = "شرح توقف";
            gridViewTextBoxColumn2.Name = "Desc_stop";
            gridViewTextBoxColumn2.Width = 258;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.FieldName = "Active";
            filterDescriptor1.IsFilterEditor = true;
            filterDescriptor1.Operator = Telerik.WinControls.Data.FilterOperator.IsEqualTo;
            filterDescriptor1.PropertyName = "Active";
            filterDescriptor1.Value = "True";
            gridViewCheckBoxColumn1.FilterDescriptor = filterDescriptor1;
            gridViewCheckBoxColumn1.HeaderText = "فعال";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "Active";
            gridViewCheckBoxColumn1.Width = 68;
            gridViewCheckBoxColumn2.EnableExpressionEditor = false;
            gridViewCheckBoxColumn2.FieldName = "IsOk";
            gridViewCheckBoxColumn2.HeaderText = "مجاز";
            gridViewCheckBoxColumn2.MinWidth = 20;
            gridViewCheckBoxColumn2.Name = "IsOk";
            gridViewCheckBoxColumn2.Width = 68;
            this.grdStop.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewCheckBoxColumn1,
            gridViewCheckBoxColumn2});
            this.grdStop.MasterTemplate.EnableFiltering = true;
            this.grdStop.MasterTemplate.FilterDescriptors.AddRange(new Telerik.WinControls.Data.FilterDescriptor[] {
            filterDescriptor1});
            this.grdStop.MasterTemplate.ShowRowHeaderColumn = false;
            sortDescriptor1.PropertyName = "ID_shenase";
            this.grdStop.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.grdStop.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdStop.Name = "grdStop";
            this.grdStop.ReadOnly = true;
            this.grdStop.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdStop.ShowGroupPanel = false;
            this.grdStop.Size = new System.Drawing.Size(556, 389);
            this.grdStop.TabIndex = 288;
            this.grdStop.TabStop = false;
            this.grdStop.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdStop_CellDoubleClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDelete.Image = global::ET.Properties.Resources.Remove;
            this.btnDelete.Location = new System.Drawing.Point(12, 75);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnDelete.Size = new System.Drawing.Size(35, 25);
            this.btnDelete.TabIndex = 285;
            this.btnDelete.TabStop = false;
            this.btnDelete.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAdd.Image = global::ET.Properties.Resources.ADD;
            this.btnAdd.Location = new System.Drawing.Point(92, 75);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnAdd.Size = new System.Drawing.Size(37, 25);
            this.btnAdd.TabIndex = 284;
            this.btnAdd.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnUpdate.Image = global::ET.Properties.Resources.Edit;
            this.btnUpdate.Location = new System.Drawing.Point(51, 75);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnUpdate.Size = new System.Drawing.Size(37, 25);
            this.btnUpdate.TabIndex = 286;
            this.btnUpdate.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(508, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 291;
            this.label1.Text = "کد توقف:";
            // 
            // txtIdStop
            // 
            this.txtIdStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdStop.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdStop.Location = new System.Drawing.Point(311, 44);
            this.txtIdStop.Name = "txtIdStop";
            this.txtIdStop.Size = new System.Drawing.Size(182, 21);
            this.txtIdStop.TabIndex = 290;
            // 
            // chkActive
            // 
            this.chkActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(444, 75);
            this.chkActive.Name = "chkActive";
            this.chkActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkActive.Size = new System.Drawing.Size(49, 18);
            this.chkActive.TabIndex = 292;
            this.chkActive.Text = "فعال";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // chkIsOk
            // 
            this.chkIsOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIsOk.AutoSize = true;
            this.chkIsOk.Location = new System.Drawing.Point(312, 75);
            this.chkIsOk.Name = "chkIsOk";
            this.chkIsOk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIsOk.Size = new System.Drawing.Size(48, 18);
            this.chkIsOk.TabIndex = 293;
            this.chkIsOk.Text = "مجاز";
            this.chkIsOk.UseVisualStyleBackColor = true;
            // 
            // FrmTolid_Stop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 507);
            this.Controls.Add(this.chkIsOk);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIdStop);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.txtDescStop);
            this.Controls.Add(this.grdStop);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmTolid_Stop";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "توقف";
            this.Load += new System.EventHandler(this.FrmTolid_Stop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdStop.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox txtDescStop;
        private Telerik.WinControls.UI.RadGridView grdStop;
        public Telerik.WinControls.UI.RadButton btnDelete;
        public Telerik.WinControls.UI.RadButton btnAdd;
        public Telerik.WinControls.UI.RadButton btnUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdStop;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.CheckBox chkIsOk;
    }
}

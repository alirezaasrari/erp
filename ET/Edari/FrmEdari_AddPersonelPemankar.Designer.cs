namespace ET
{
    partial class FrmEdari_AddPersonelPemankar
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
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEdari_AddPersonelPemankar));
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.grdPersonel = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonel.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grdPersonel
            // 
            this.grdPersonel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grdPersonel.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdPersonel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPersonel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.grdPersonel.ForeColor = System.Drawing.Color.Black;
            this.grdPersonel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdPersonel.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.grdPersonel.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "IdPersonel";
            gridViewTextBoxColumn1.HeaderText = "کد پرسنل";
            gridViewTextBoxColumn1.Name = "IdPersonel";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 115;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "N_oper";
            gridViewTextBoxColumn2.HeaderText = "نام پرسنل";
            gridViewTextBoxColumn2.Name = "N_oper";
            gridViewTextBoxColumn2.Width = 215;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.FieldName = "typeP";
            gridViewCheckBoxColumn1.HeaderText = "مرد";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "typeP";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.FieldName = "btnDelete";
            gridViewCommandColumn1.HeaderText = "حذف";
            gridViewCommandColumn1.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn1.Image")));
            gridViewCommandColumn1.Name = "btnDelete";
            this.grdPersonel.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewCheckBoxColumn1,
            gridViewCommandColumn1});
            this.grdPersonel.MasterTemplate.EnableFiltering = true;
            this.grdPersonel.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdPersonel.Name = "grdPersonel";
            this.grdPersonel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdPersonel.ShowGroupPanel = false;
            this.grdPersonel.Size = new System.Drawing.Size(476, 370);
            this.grdPersonel.TabIndex = 161;
            this.grdPersonel.UserAddingRow += new Telerik.WinControls.UI.GridViewRowCancelEventHandler(this.grdPersonel_UserAddingRow);
            this.grdPersonel.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdPersonel_CellClick);
            // 
            // FrmEdari_AddPersonelPemankar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 370);
            this.Controls.Add(this.grdPersonel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmEdari_AddPersonelPemankar";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "پرسنل پیمانکار";
            this.Load += new System.EventHandler(this.FrmEdari_AddPersonelPemankar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonel.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grdPersonel;
    }
}

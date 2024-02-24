namespace ET
{
    partial class FrmEdari_ListPersonel
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
            this.grdPersonel.MasterTemplate.AllowAddNewRow = false;
            this.grdPersonel.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "IdPersonel";
            gridViewTextBoxColumn4.HeaderText = "کد پرسنل";
            gridViewTextBoxColumn4.Name = "IdPersonel";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 115;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "NamePersonel";
            gridViewTextBoxColumn5.HeaderText = "نام پرسنل";
            gridViewTextBoxColumn5.Name = "NamePersonel";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 215;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "taf";
            gridViewTextBoxColumn6.HeaderText = "تفصیلی";
            gridViewTextBoxColumn6.Name = "taf";
            gridViewTextBoxColumn6.Width = 105;
            this.grdPersonel.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.grdPersonel.MasterTemplate.EnableFiltering = true;
            this.grdPersonel.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grdPersonel.Name = "grdPersonel";
            this.grdPersonel.ReadOnly = true;
            this.grdPersonel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdPersonel.ShowGroupPanel = false;
            this.grdPersonel.Size = new System.Drawing.Size(490, 271);
            this.grdPersonel.TabIndex = 160;
            this.grdPersonel.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdPersonel_CellDoubleClick);
            this.grdPersonel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdPersonel_KeyDown);
            // 
            // FrmEdari_ListPersonel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 271);
            this.Controls.Add(this.grdPersonel);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Name = "FrmEdari_ListPersonel";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جستجوی پرسنل";
            this.Load += new System.EventHandler(this.FrmEdari_ListPersonel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonel.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grdPersonel;

    }
}

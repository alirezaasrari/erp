namespace ET
{
    partial class FrmPLN_RadyabiGhete
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.grdRadyabi = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdRadyabi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRadyabi.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grdRadyabi
            // 
            this.grdRadyabi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdRadyabi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grdRadyabi.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdRadyabi.Font = new System.Drawing.Font("Tahoma", 9F);
            this.grdRadyabi.ForeColor = System.Drawing.Color.Black;
            this.grdRadyabi.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdRadyabi.Location = new System.Drawing.Point(12, 12);
            // 
            // 
            // 
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "NameHeed";
            gridViewTextBoxColumn1.HeaderText = "نام قطعه";
            gridViewTextBoxColumn1.Name = "NameHeed";
            gridViewTextBoxColumn1.Width = 235;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "CodeHeed";
            gridViewTextBoxColumn2.HeaderText = "کد قطعه";
            gridViewTextBoxColumn2.Name = "CodeHeed";
            gridViewTextBoxColumn2.Width = 98;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "NameDetail";
            gridViewTextBoxColumn3.HeaderText = "نام فرایند ساخت";
            gridViewTextBoxColumn3.Name = "NameDetail";
            gridViewTextBoxColumn3.Width = 343;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "CodeDetail";
            gridViewTextBoxColumn4.HeaderText = "کد فرایند ساخت";
            gridViewTextBoxColumn4.Name = "CodeDetail";
            gridViewTextBoxColumn4.Width = 106;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "Tartib";
            gridViewTextBoxColumn5.HeaderText = "ترتیب";
            gridViewTextBoxColumn5.Name = "Tartib";
            gridViewTextBoxColumn5.Width = 36;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "IdRadyabi";
            gridViewTextBoxColumn6.HeaderText = "کد ردیابی";
            gridViewTextBoxColumn6.Name = "IdRadyabi";
            gridViewTextBoxColumn6.Width = 105;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "TedadTolid";
            gridViewTextBoxColumn7.HeaderText = "تعداد برنامه";
            gridViewTextBoxColumn7.Name = "TedadTolid";
            gridViewTextBoxColumn7.Width = 66;
            this.grdRadyabi.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7});
            this.grdRadyabi.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdRadyabi.Name = "grdRadyabi";
            this.grdRadyabi.ReadOnly = true;
            this.grdRadyabi.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdRadyabi.Size = new System.Drawing.Size(1035, 436);
            this.grdRadyabi.TabIndex = 0;
            this.grdRadyabi.Text = "radGridView1";
            this.grdRadyabi.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdRadyabi_CellDoubleClick);
            // 
            // FrmPLN_RadyabiGhete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 460);
            this.Controls.Add(this.grdRadyabi);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmPLN_RadyabiGhete";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "ردیابی قطعه";
            this.Load += new System.EventHandler(this.FrmPLN_RadyabiGhete_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdRadyabi.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRadyabi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grdRadyabi;
    }
}

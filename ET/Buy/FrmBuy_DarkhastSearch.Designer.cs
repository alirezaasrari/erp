namespace ET
{
    partial class FrmBuy_DarkhastSearch
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
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBuy_DarkhastSearch));
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.Grd = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grd.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // Grd
            // 
            this.Grd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.Grd.Cursor = System.Windows.Forms.Cursors.Default;
            this.Grd.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Grd.ForeColor = System.Drawing.Color.Black;
            this.Grd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Grd.Location = new System.Drawing.Point(12, 12);
            // 
            // 
            // 
            this.Grd.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "Sho_Darkhast";
            gridViewTextBoxColumn1.HeaderText = "شماره درخواست";
            gridViewTextBoxColumn1.Name = "Sho_Darkhast";
            gridViewTextBoxColumn1.Width = 114;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "Radif_Darkhast";
            gridViewTextBoxColumn2.HeaderText = "ردیف درخواست";
            gridViewTextBoxColumn2.Name = "Radif_Darkhast";
            gridViewTextBoxColumn2.Width = 116;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "C_Kala";
            gridViewTextBoxColumn3.HeaderText = "کد کالا";
            gridViewTextBoxColumn3.Name = "C_Kala";
            gridViewTextBoxColumn3.Width = 160;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "Nkala";
            gridViewTextBoxColumn4.HeaderText = "نام کالا";
            gridViewTextBoxColumn4.Name = "Nkala";
            gridViewTextBoxColumn4.Width = 241;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "Mored_masraf";
            gridViewTextBoxColumn5.HeaderText = "مورد مصرف";
            gridViewTextBoxColumn5.Name = "Mored_masraf";
            gridViewTextBoxColumn5.Width = 138;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "Date_Niaz";
            gridViewTextBoxColumn6.HeaderText = "تاریخ نیاز";
            gridViewTextBoxColumn6.Name = "Date_Niaz";
            gridViewTextBoxColumn6.Width = 99;
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.FieldName = "btnSelect";
            gridViewCommandColumn1.HeaderText = "انتخاب";
            gridViewCommandColumn1.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn1.Image")));
            gridViewCommandColumn1.Name = "btnSelect";
            this.Grd.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewCommandColumn1});
            this.Grd.MasterTemplate.EnableFiltering = true;
            this.Grd.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.Grd.Name = "Grd";
            this.Grd.ReadOnly = true;
            this.Grd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Grd.Size = new System.Drawing.Size(1002, 366);
            this.Grd.TabIndex = 9;
            this.Grd.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.Grd_CellClick);
            // 
            // FrmBuy_DarkhastSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 390);
            this.Controls.Add(this.Grd);
            this.Name = "FrmBuy_DarkhastSearch";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جستجوی درخواست خرید";
            this.Load += new System.EventHandler(this.FrmBuy_DarkhastSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grd.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView Grd;
    }
}

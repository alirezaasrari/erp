namespace ET
{
    partial class FrmBuy_TaeedReturn
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn17 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn18 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn19 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn20 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn21 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn22 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn2 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.Data.FilterDescriptor filterDescriptor2 = new Telerik.WinControls.Data.FilterDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.grdDarkhast = new Telerik.WinControls.UI.RadGridView();
            this.btnSearch = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdDarkhast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDarkhast.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDarkhast
            // 
            this.grdDarkhast.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDarkhast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(222)))), ((int)(((byte)(254)))));
            this.grdDarkhast.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdDarkhast.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Bold);
            this.grdDarkhast.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdDarkhast.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdDarkhast.Location = new System.Drawing.Point(12, 43);
            // 
            // 
            // 
            this.grdDarkhast.MasterTemplate.AllowAddNewRow = false;
            this.grdDarkhast.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn12.EnableExpressionEditor = false;
            gridViewTextBoxColumn12.FieldName = "Sho_Darkhast";
            gridViewTextBoxColumn12.HeaderText = "شماره درخواست";
            gridViewTextBoxColumn12.Name = "Sho_Darkhast";
            gridViewTextBoxColumn12.Width = 98;
            gridViewTextBoxColumn13.EnableExpressionEditor = false;
            gridViewTextBoxColumn13.FieldName = "Radif_Darkhast";
            gridViewTextBoxColumn13.HeaderText = "ردیف درخواست";
            gridViewTextBoxColumn13.Name = "Radif_Darkhast";
            gridViewTextBoxColumn13.Width = 86;
            gridViewTextBoxColumn14.EnableExpressionEditor = false;
            gridViewTextBoxColumn14.FieldName = "C_kala";
            gridViewTextBoxColumn14.HeaderText = "کد کالا";
            gridViewTextBoxColumn14.Name = "C_kala";
            gridViewTextBoxColumn14.Width = 111;
            gridViewTextBoxColumn15.EnableExpressionEditor = false;
            gridViewTextBoxColumn15.FieldName = "Nkala";
            gridViewTextBoxColumn15.HeaderText = "نام کالا";
            gridViewTextBoxColumn15.Name = "Nkala";
            gridViewTextBoxColumn15.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn15.Width = 231;
            gridViewTextBoxColumn16.EnableExpressionEditor = false;
            gridViewTextBoxColumn16.FieldName = "anbar_out";
            gridViewTextBoxColumn16.HeaderText = "انبار";
            gridViewTextBoxColumn16.Name = "anbar_out";
            gridViewTextBoxColumn16.Width = 43;
            gridViewTextBoxColumn17.EnableExpressionEditor = false;
            gridViewTextBoxColumn17.FieldName = "n_zanbar";
            gridViewTextBoxColumn17.HeaderText = "زیر انبار";
            gridViewTextBoxColumn17.IsVisible = false;
            gridViewTextBoxColumn17.Name = "n_zanbar";
            gridViewTextBoxColumn17.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn17.Width = 94;
            gridViewTextBoxColumn18.EnableExpressionEditor = false;
            gridViewTextBoxColumn18.FieldName = "meghdar_taeed";
            gridViewTextBoxColumn18.HeaderText = "مقدار درخواست";
            gridViewTextBoxColumn18.Name = "meghdar_taeed";
            gridViewTextBoxColumn18.Width = 84;
            gridViewTextBoxColumn19.EnableExpressionEditor = false;
            gridViewTextBoxColumn19.FieldName = "N_UnitKala";
            gridViewTextBoxColumn19.HeaderText = "واحد کالا";
            gridViewTextBoxColumn19.Name = "N_UnitKala";
            gridViewTextBoxColumn20.EnableExpressionEditor = false;
            gridViewTextBoxColumn20.FieldName = "Date_Niaz";
            gridViewTextBoxColumn20.HeaderText = "تاریخ نیاز";
            gridViewTextBoxColumn20.Name = "Date_Niaz";
            gridViewTextBoxColumn20.Width = 73;
            gridViewTextBoxColumn21.EnableExpressionEditor = false;
            gridViewTextBoxColumn21.FieldName = "Date_darkhast";
            gridViewTextBoxColumn21.HeaderText = "تاریخ درخواست";
            gridViewTextBoxColumn21.Name = "Date_darkhast";
            gridViewTextBoxColumn21.Width = 84;
            gridViewTextBoxColumn22.EnableExpressionEditor = false;
            gridViewTextBoxColumn22.FieldName = "Mored_masraf";
            gridViewTextBoxColumn22.HeaderText = "مورد مصرف";
            gridViewTextBoxColumn22.Name = "Mored_masraf";
            gridViewTextBoxColumn22.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn22.Width = 118;
            gridViewCheckBoxColumn2.EnableExpressionEditor = false;
            gridViewCheckBoxColumn2.FieldName = "TaeedDarkhast";
            gridViewCheckBoxColumn2.HeaderText = "تایید";
            gridViewCheckBoxColumn2.MinWidth = 20;
            gridViewCheckBoxColumn2.Name = "TaeedDarkhast";
            this.grdDarkhast.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewTextBoxColumn15,
            gridViewTextBoxColumn16,
            gridViewTextBoxColumn17,
            gridViewTextBoxColumn18,
            gridViewTextBoxColumn19,
            gridViewTextBoxColumn20,
            gridViewTextBoxColumn21,
            gridViewTextBoxColumn22,
            gridViewCheckBoxColumn2});
            this.grdDarkhast.MasterTemplate.EnableFiltering = true;
            filterDescriptor2.Operator = Telerik.WinControls.Data.FilterOperator.IsGreaterThanOrEqualTo;
            this.grdDarkhast.MasterTemplate.FilterDescriptors.AddRange(new Telerik.WinControls.Data.FilterDescriptor[] {
            filterDescriptor2});
            this.grdDarkhast.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grdDarkhast.Name = "grdDarkhast";
            this.grdDarkhast.ReadOnly = true;
            this.grdDarkhast.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdDarkhast.Size = new System.Drawing.Size(1053, 415);
            this.grdDarkhast.TabIndex = 122;
            this.grdDarkhast.Text = "radGridView1";
            this.grdDarkhast.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdDarkhast_CellClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSearch.Image = global::ET.Properties.Resources.Refresh;
            this.btnSearch.Location = new System.Drawing.Point(12, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSearch.Size = new System.Drawing.Size(31, 25);
            this.btnSearch.TabIndex = 123;
            this.btnSearch.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // FrmBuy_TaeedReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 470);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.grdDarkhast);
            this.Name = "FrmBuy_TaeedReturn";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "بازگشت از تایید";
            this.Load += new System.EventHandler(this.FrmBuy_TaeedReturn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDarkhast.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDarkhast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grdDarkhast;
        private Telerik.WinControls.UI.RadButton btnSearch;

    }
}

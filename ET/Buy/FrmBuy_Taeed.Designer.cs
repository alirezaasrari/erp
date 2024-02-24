namespace ET
{
    partial class FrmBuy_Taeed
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn34 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn35 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn36 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn37 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn38 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn39 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn40 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn41 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn42 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn43 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn44 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn4 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.Data.FilterDescriptor filterDescriptor4 = new Telerik.WinControls.Data.FilterDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition4 = new Telerik.WinControls.UI.TableViewDefinition();
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
            gridViewTextBoxColumn34.EnableExpressionEditor = false;
            gridViewTextBoxColumn34.FieldName = "Sho_Darkhast";
            gridViewTextBoxColumn34.HeaderText = "شماره درخواست";
            gridViewTextBoxColumn34.Name = "Sho_Darkhast";
            gridViewTextBoxColumn34.Width = 98;
            gridViewTextBoxColumn35.EnableExpressionEditor = false;
            gridViewTextBoxColumn35.FieldName = "Radif_Darkhast";
            gridViewTextBoxColumn35.HeaderText = "ردیف درخواست";
            gridViewTextBoxColumn35.Name = "Radif_Darkhast";
            gridViewTextBoxColumn35.Width = 86;
            gridViewTextBoxColumn36.EnableExpressionEditor = false;
            gridViewTextBoxColumn36.FieldName = "C_kala";
            gridViewTextBoxColumn36.HeaderText = "کد کالا";
            gridViewTextBoxColumn36.Name = "C_kala";
            gridViewTextBoxColumn36.Width = 111;
            gridViewTextBoxColumn37.EnableExpressionEditor = false;
            gridViewTextBoxColumn37.FieldName = "Nkala";
            gridViewTextBoxColumn37.HeaderText = "نام کالا";
            gridViewTextBoxColumn37.Name = "Nkala";
            gridViewTextBoxColumn37.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn37.Width = 231;
            gridViewTextBoxColumn38.EnableExpressionEditor = false;
            gridViewTextBoxColumn38.FieldName = "anbar_out";
            gridViewTextBoxColumn38.HeaderText = "انبار";
            gridViewTextBoxColumn38.Name = "anbar_out";
            gridViewTextBoxColumn38.Width = 43;
            gridViewTextBoxColumn39.EnableExpressionEditor = false;
            gridViewTextBoxColumn39.FieldName = "n_zanbar";
            gridViewTextBoxColumn39.HeaderText = "زیر انبار";
            gridViewTextBoxColumn39.IsVisible = false;
            gridViewTextBoxColumn39.Name = "n_zanbar";
            gridViewTextBoxColumn39.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn39.Width = 94;
            gridViewTextBoxColumn40.EnableExpressionEditor = false;
            gridViewTextBoxColumn40.FieldName = "meghdar_taeed";
            gridViewTextBoxColumn40.HeaderText = "مقدار درخواست";
            gridViewTextBoxColumn40.Name = "meghdar_taeed";
            gridViewTextBoxColumn40.Width = 84;
            gridViewTextBoxColumn41.EnableExpressionEditor = false;
            gridViewTextBoxColumn41.FieldName = "N_UnitKala";
            gridViewTextBoxColumn41.HeaderText = "واحد کالا";
            gridViewTextBoxColumn41.Name = "N_UnitKala";
            gridViewTextBoxColumn42.EnableExpressionEditor = false;
            gridViewTextBoxColumn42.FieldName = "Date_Niaz";
            gridViewTextBoxColumn42.HeaderText = "تاریخ نیاز";
            gridViewTextBoxColumn42.Name = "Date_Niaz";
            gridViewTextBoxColumn42.Width = 73;
            gridViewTextBoxColumn43.EnableExpressionEditor = false;
            gridViewTextBoxColumn43.FieldName = "Date_darkhast";
            gridViewTextBoxColumn43.HeaderText = "تاریخ درخواست";
            gridViewTextBoxColumn43.Name = "Date_darkhast";
            gridViewTextBoxColumn43.Width = 84;
            gridViewTextBoxColumn44.EnableExpressionEditor = false;
            gridViewTextBoxColumn44.FieldName = "Mored_masraf";
            gridViewTextBoxColumn44.HeaderText = "مورد مصرف";
            gridViewTextBoxColumn44.Name = "Mored_masraf";
            gridViewTextBoxColumn44.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn44.Width = 118;
            gridViewCheckBoxColumn4.EnableExpressionEditor = false;
            gridViewCheckBoxColumn4.FieldName = "TaeedDarkhast";
            gridViewCheckBoxColumn4.HeaderText = "تایید";
            gridViewCheckBoxColumn4.MinWidth = 20;
            gridViewCheckBoxColumn4.Name = "TaeedDarkhast";
            this.grdDarkhast.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn34,
            gridViewTextBoxColumn35,
            gridViewTextBoxColumn36,
            gridViewTextBoxColumn37,
            gridViewTextBoxColumn38,
            gridViewTextBoxColumn39,
            gridViewTextBoxColumn40,
            gridViewTextBoxColumn41,
            gridViewTextBoxColumn42,
            gridViewTextBoxColumn43,
            gridViewTextBoxColumn44,
            gridViewCheckBoxColumn4});
            this.grdDarkhast.MasterTemplate.EnableFiltering = true;
            filterDescriptor4.Operator = Telerik.WinControls.Data.FilterOperator.IsGreaterThanOrEqualTo;
            this.grdDarkhast.MasterTemplate.FilterDescriptors.AddRange(new Telerik.WinControls.Data.FilterDescriptor[] {
            filterDescriptor4});
            this.grdDarkhast.MasterTemplate.ViewDefinition = tableViewDefinition4;
            this.grdDarkhast.Name = "grdDarkhast";
            this.grdDarkhast.ReadOnly = true;
            this.grdDarkhast.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdDarkhast.Size = new System.Drawing.Size(1064, 425);
            this.grdDarkhast.TabIndex = 121;
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
            this.btnSearch.Size = new System.Drawing.Size(32, 25);
            this.btnSearch.TabIndex = 123;
            this.btnSearch.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // FrmBuy_Taeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 480);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.grdDarkhast);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmBuy_Taeed";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "تایید درخواست خرید";
            this.Load += new System.EventHandler(this.FrmBuy_Taeed_Load);
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

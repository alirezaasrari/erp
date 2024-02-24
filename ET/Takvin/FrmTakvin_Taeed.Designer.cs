namespace ET
{
    partial class FrmTakvin_Taeed
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
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn3 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.grdTreeTaeed = new Telerik.WinControls.UI.RadGridView();
            this.btnRefresh = new Telerik.WinControls.UI.RadButton();
            this.btnExcel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdTreeTaeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTreeTaeed.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grdTreeTaeed
            // 
            this.grdTreeTaeed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTreeTaeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grdTreeTaeed.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdTreeTaeed.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.grdTreeTaeed.ForeColor = System.Drawing.Color.Black;
            this.grdTreeTaeed.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdTreeTaeed.Location = new System.Drawing.Point(12, 33);
            // 
            // 
            // 
            this.grdTreeTaeed.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "idRootTree";
            gridViewTextBoxColumn1.HeaderText = "idRootTree";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "idRootTree";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "id_Gheteh";
            gridViewTextBoxColumn2.HeaderText = "id_Gheteh";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "id_Gheteh";
            gridViewTextBoxColumn2.Width = 82;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "FaniNo";
            gridViewTextBoxColumn3.HeaderText = "شماره فنی";
            gridViewTextBoxColumn3.Name = "FaniNo";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 74;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "GhetehCode";
            gridViewTextBoxColumn4.HeaderText = "کد ریشه درخت";
            gridViewTextBoxColumn4.Name = "GhetehCode";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 107;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "GheteName";
            gridViewTextBoxColumn5.HeaderText = "نام ریشه درخت";
            gridViewTextBoxColumn5.Name = "GheteName";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 254;
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.FieldName = "TaeedOpr";
            gridViewCommandColumn1.HeaderText = "تایید اپراتور";
            gridViewCommandColumn1.IsVisible = false;
            gridViewCommandColumn1.Name = "TaeedOpr";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.Width = 89;
            gridViewCommandColumn2.AllowResize = false;
            gridViewCommandColumn2.EnableExpressionEditor = false;
            gridViewCommandColumn2.FieldName = "TaeedDesign";
            gridViewCommandColumn2.HeaderText = "تایید مهندسی";
            gridViewCommandColumn2.IsVisible = false;
            gridViewCommandColumn2.Name = "TaeedDesign";
            gridViewCommandColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.Width = 86;
            gridViewCommandColumn3.AllowResize = false;
            gridViewCommandColumn3.EnableExpressionEditor = false;
            gridViewCommandColumn3.FieldName = "TaeedPlan";
            gridViewCommandColumn3.HeaderText = "تایید برنامه ریزی";
            gridViewCommandColumn3.IsVisible = false;
            gridViewCommandColumn3.Name = "TaeedPlan";
            gridViewCommandColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn3.Width = 85;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "Opr";
            gridViewTextBoxColumn6.HeaderText = "Opr";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "Opr";
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "desi";
            gridViewTextBoxColumn7.HeaderText = "desi";
            gridViewTextBoxColumn7.IsVisible = false;
            gridViewTextBoxColumn7.Name = "desi";
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "plani";
            gridViewTextBoxColumn8.HeaderText = "plani";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.Name = "plani";
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "TaeedOpr";
            gridViewTextBoxColumn9.HeaderText = "تایید اپراتور";
            gridViewTextBoxColumn9.Name = "TaeedOpr2";
            gridViewTextBoxColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn9.Width = 83;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "DateOpr";
            gridViewTextBoxColumn10.HeaderText = "تایید اپراتور";
            gridViewTextBoxColumn10.Name = "DateOpr";
            gridViewTextBoxColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn10.Width = 82;
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.FieldName = "TaeedDesign";
            gridViewTextBoxColumn11.HeaderText = "تایید مهندسی";
            gridViewTextBoxColumn11.Name = "TaeedDesign2";
            gridViewTextBoxColumn11.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn11.Width = 85;
            gridViewTextBoxColumn12.EnableExpressionEditor = false;
            gridViewTextBoxColumn12.FieldName = "DateDesign";
            gridViewTextBoxColumn12.HeaderText = "تایید مهندسی";
            gridViewTextBoxColumn12.Name = "DateDesign";
            gridViewTextBoxColumn12.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn12.Width = 86;
            gridViewTextBoxColumn13.EnableExpressionEditor = false;
            gridViewTextBoxColumn13.FieldName = "TaeedPlan";
            gridViewTextBoxColumn13.HeaderText = "تایید برنامه ریزی";
            gridViewTextBoxColumn13.Name = "TaeedPlan2";
            gridViewTextBoxColumn13.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn13.Width = 89;
            gridViewTextBoxColumn14.EnableExpressionEditor = false;
            gridViewTextBoxColumn14.FieldName = "DatePlan";
            gridViewTextBoxColumn14.HeaderText = "برنامه ریزی";
            gridViewTextBoxColumn14.Name = "DatePlan";
            gridViewTextBoxColumn14.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn14.Width = 79;
            this.grdTreeTaeed.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewCommandColumn1,
            gridViewCommandColumn2,
            gridViewCommandColumn3,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14});
            this.grdTreeTaeed.MasterTemplate.EnableFiltering = true;
            this.grdTreeTaeed.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdTreeTaeed.Name = "grdTreeTaeed";
            this.grdTreeTaeed.ReadOnly = true;
            this.grdTreeTaeed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdTreeTaeed.Size = new System.Drawing.Size(899, 426);
            this.grdTreeTaeed.TabIndex = 0;
            this.grdTreeTaeed.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdTreeTaeed_CellClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnRefresh.Image = global::ET.Properties.Resources.Refresh;
            this.btnRefresh.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRefresh.Location = new System.Drawing.Point(12, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnRefresh.Size = new System.Drawing.Size(28, 25);
            this.btnRefresh.TabIndex = 264;
            this.btnRefresh.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Image = global::ET.Properties.Resources.Excel1;
            this.btnExcel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExcel.Location = new System.Drawing.Point(46, 2);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnExcel.Size = new System.Drawing.Size(27, 25);
            this.btnExcel.TabIndex = 265;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // FrmTakvin_Taeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 471);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.grdTreeTaeed);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmTakvin_Taeed";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "تایید درخت محصول";
            this.Load += new System.EventHandler(this.FrmTakvin_Taeed_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdTreeTaeed.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTreeTaeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grdTreeTaeed;
        public Telerik.WinControls.UI.RadButton btnRefresh;
        private Telerik.WinControls.UI.RadButton btnExcel;
    }
}

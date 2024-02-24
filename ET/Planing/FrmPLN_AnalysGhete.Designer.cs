namespace ET
{
    partial class FrmPLN_AnalysGhete
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.btnAnalyse = new Telerik.WinControls.UI.RadButton();
            this.grdAnalyseGhete = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.btnAnalyse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAnalyseGhete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAnalyseGhete.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAnalyse
            // 
            this.btnAnalyse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnalyse.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAnalyse.Image = global::ET.Properties.Resources.UpLoad;
            this.btnAnalyse.Location = new System.Drawing.Point(886, 12);
            this.btnAnalyse.Name = "btnAnalyse";
            this.btnAnalyse.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnAnalyse.Size = new System.Drawing.Size(92, 25);
            this.btnAnalyse.TabIndex = 254;
            this.btnAnalyse.Text = "انجام آنالیز";
            this.btnAnalyse.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAnalyse.Click += new System.EventHandler(this.btnAnalyse_Click);
            // 
            // grdAnalyseGhete
            // 
            this.grdAnalyseGhete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAnalyseGhete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grdAnalyseGhete.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdAnalyseGhete.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.grdAnalyseGhete.ForeColor = System.Drawing.Color.Black;
            this.grdAnalyseGhete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdAnalyseGhete.Location = new System.Drawing.Point(12, 60);
            // 
            // 
            // 
            this.grdAnalyseGhete.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "IdGhete";
            gridViewTextBoxColumn1.HeaderText = "شناسه قطعه";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "IdGhete";
            gridViewTextBoxColumn1.Width = 83;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "GhetehCode";
            gridViewTextBoxColumn2.HeaderText = "کد قطعه";
            gridViewTextBoxColumn2.Name = "GhetehCode";
            gridViewTextBoxColumn2.Width = 125;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "GheteName";
            gridViewTextBoxColumn3.HeaderText = "نام قطعه";
            gridViewTextBoxColumn3.Name = "GheteName";
            gridViewTextBoxColumn3.Width = 250;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "GhetehAnbar";
            gridViewTextBoxColumn4.HeaderText = "انبار";
            gridViewTextBoxColumn4.Name = "GhetehAnbar";
            gridViewTextBoxColumn4.Width = 39;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "MeghdarNiaz";
            gridViewTextBoxColumn5.HeaderText = "مقدار نیاز";
            gridViewTextBoxColumn5.Name = "MeghdarNiaz";
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "sefaresh";
            gridViewTextBoxColumn6.HeaderText = "تعداد سفارش";
            gridViewTextBoxColumn6.Name = "sefaresh";
            gridViewTextBoxColumn6.Width = 71;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "zakhire";
            gridViewTextBoxColumn7.HeaderText = "ذخیره احتیاطی";
            gridViewTextBoxColumn7.Name = "zakhire";
            gridViewTextBoxColumn7.Width = 79;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "TypeGhete";
            gridViewTextBoxColumn8.HeaderText = "نوع قطعه";
            gridViewTextBoxColumn8.Name = "TypeGhete";
            gridViewTextBoxColumn8.Width = 69;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "MojoodiKhat";
            gridViewTextBoxColumn9.HeaderText = "موجودی پای خط";
            gridViewTextBoxColumn9.Name = "MojoodiKhat";
            gridViewTextBoxColumn9.Width = 86;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "TedadBarname";
            gridViewTextBoxColumn10.HeaderText = "برنامه درراه";
            gridViewTextBoxColumn10.Name = "TedadBarname";
            gridViewTextBoxColumn10.Width = 60;
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.FieldName = "MandeKharid";
            gridViewTextBoxColumn11.HeaderText = "مانده خرید";
            gridViewTextBoxColumn11.Name = "MandeKharid";
            gridViewTextBoxColumn11.Width = 57;
            gridViewTextBoxColumn12.EnableExpressionEditor = false;
            gridViewTextBoxColumn12.FieldName = "MojoodiAnbar";
            gridViewTextBoxColumn12.HeaderText = "موجودی انبار";
            gridViewTextBoxColumn12.Name = "MojoodiAnbar";
            gridViewTextBoxColumn12.Width = 68;
            this.grdAnalyseGhete.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12});
            this.grdAnalyseGhete.MasterTemplate.EnableFiltering = true;
            this.grdAnalyseGhete.MasterTemplate.ShowRowHeaderColumn = false;
            this.grdAnalyseGhete.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdAnalyseGhete.Name = "grdAnalyseGhete";
            this.grdAnalyseGhete.ReadOnly = true;
            this.grdAnalyseGhete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdAnalyseGhete.Size = new System.Drawing.Size(993, 292);
            this.grdAnalyseGhete.TabIndex = 266;
            this.grdAnalyseGhete.TabStop = false;
            this.grdAnalyseGhete.Text = "radGridView2";
            // 
            // FrmPLN_AnalysGhete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 364);
            this.Controls.Add(this.grdAnalyseGhete);
            this.Controls.Add(this.btnAnalyse);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmPLN_AnalysGhete";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "آنالیز مقدار نیاز قطعه";
            this.Load += new System.EventHandler(this.FrmPLN_AnalysGhete_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnAnalyse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAnalyseGhete.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAnalyseGhete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadButton btnAnalyse;
        private Telerik.WinControls.UI.RadGridView grdAnalyseGhete;
    }
}

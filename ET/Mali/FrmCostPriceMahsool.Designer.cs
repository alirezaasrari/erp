namespace ET
{
    partial class FrmCostPriceMahsool
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtGhetehCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGheteName = new System.Windows.Forms.TextBox();
            this.btnExcel = new Telerik.WinControls.UI.RadButton();
            this.btnRefresh = new Telerik.WinControls.UI.RadButton();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.grdCostPrice = new Telerik.WinControls.UI.RadGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGhetehAnbar = new System.Windows.Forms.TextBox();
            this.btnF2KalaAnbar = new Telerik.WinControls.UI.RadButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.btnExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCostPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCostPrice.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnF2KalaAnbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(796, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "کد قطعه";
            // 
            // txtGhetehCode
            // 
            this.txtGhetehCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGhetehCode.Location = new System.Drawing.Point(614, 6);
            this.txtGhetehCode.Name = "txtGhetehCode";
            this.txtGhetehCode.ReadOnly = true;
            this.txtGhetehCode.Size = new System.Drawing.Size(145, 20);
            this.txtGhetehCode.TabIndex = 43;
            this.txtGhetehCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGhetehCode_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(790, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "نام قطعه:";
            // 
            // txtGheteName
            // 
            this.txtGheteName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGheteName.Location = new System.Drawing.Point(308, 33);
            this.txtGheteName.Name = "txtGheteName";
            this.txtGheteName.ReadOnly = true;
            this.txtGheteName.Size = new System.Drawing.Size(451, 20);
            this.txtGheteName.TabIndex = 46;
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnExcel.Image = global::ET.Properties.Resources.Excel1;
            this.btnExcel.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcel.Location = new System.Drawing.Point(12, 62);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnExcel.Size = new System.Drawing.Size(35, 25);
            this.btnExcel.TabIndex = 279;
            this.btnExcel.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnRefresh.Image = global::ET.Properties.Resources.Refresh;
            this.btnRefresh.Location = new System.Drawing.Point(135, 62);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnRefresh.Size = new System.Drawing.Size(35, 25);
            this.btnRefresh.TabIndex = 278;
            this.btnRefresh.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAdd.Image = global::ET.Properties.Resources.ADD;
            this.btnAdd.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.Location = new System.Drawing.Point(176, 62);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnAdd.Size = new System.Drawing.Size(35, 25);
            this.btnAdd.TabIndex = 275;
            this.btnAdd.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grdCostPrice
            // 
            this.grdCostPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdCostPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grdCostPrice.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdCostPrice.Font = new System.Drawing.Font("Tahoma", 9F);
            this.grdCostPrice.ForeColor = System.Drawing.Color.Black;
            this.grdCostPrice.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdCostPrice.Location = new System.Drawing.Point(12, 93);
            // 
            // 
            // 
            this.grdCostPrice.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "id_Price";
            gridViewTextBoxColumn1.HeaderText = "شناسه قیمت";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "id_Price";
            gridViewTextBoxColumn1.Width = 100;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "GhetehCode";
            gridViewTextBoxColumn2.HeaderText = "کد کالا";
            gridViewTextBoxColumn2.Name = "GhetehCode";
            gridViewTextBoxColumn2.Width = 116;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "GheteName";
            gridViewTextBoxColumn3.HeaderText = "نام کالا";
            gridViewTextBoxColumn3.Name = "GheteName";
            gridViewTextBoxColumn3.Width = 265;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "GhetehAnbar";
            gridViewTextBoxColumn4.HeaderText = "انبار";
            gridViewTextBoxColumn4.Name = "GhetehAnbar";
            gridViewTextBoxColumn4.Width = 41;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "Price";
            gridViewTextBoxColumn5.HeaderText = "قیمت تعیین شده";
            gridViewTextBoxColumn5.Name = "Price";
            gridViewTextBoxColumn5.Width = 115;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "date_insert";
            gridViewTextBoxColumn6.HeaderText = "تاریخ";
            gridViewTextBoxColumn6.Name = "date_insert";
            gridViewTextBoxColumn6.Width = 100;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "user_insert";
            gridViewTextBoxColumn7.HeaderText = "شناسه کاربر";
            gridViewTextBoxColumn7.Name = "user_insert";
            gridViewTextBoxColumn7.Width = 76;
            this.grdCostPrice.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7});
            this.grdCostPrice.MasterTemplate.EnableFiltering = true;
            this.grdCostPrice.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdCostPrice.Name = "grdCostPrice";
            this.grdCostPrice.ReadOnly = true;
            this.grdCostPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdCostPrice.Size = new System.Drawing.Size(830, 375);
            this.grdCostPrice.TabIndex = 280;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(584, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 283;
            this.label6.Text = "ریال";
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.Location = new System.Drawing.Point(614, 59);
            this.txtPrice.MaxLength = 15;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(145, 20);
            this.txtPrice.TabIndex = 281;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(765, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 282;
            this.label5.Text = "قیمت محصول :";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(428, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 285;
            this.label1.Text = "انبار";
            // 
            // txtGhetehAnbar
            // 
            this.txtGhetehAnbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGhetehAnbar.Location = new System.Drawing.Point(391, 6);
            this.txtGhetehAnbar.Name = "txtGhetehAnbar";
            this.txtGhetehAnbar.ReadOnly = true;
            this.txtGhetehAnbar.Size = new System.Drawing.Size(31, 20);
            this.txtGhetehAnbar.TabIndex = 284;
            // 
            // btnF2KalaAnbar
            // 
            this.btnF2KalaAnbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnF2KalaAnbar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnF2KalaAnbar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnF2KalaAnbar.Location = new System.Drawing.Point(584, 6);
            this.btnF2KalaAnbar.Name = "btnF2KalaAnbar";
            this.btnF2KalaAnbar.Size = new System.Drawing.Size(24, 20);
            this.btnF2KalaAnbar.TabIndex = 286;
            this.btnF2KalaAnbar.Text = "...";
            this.btnF2KalaAnbar.Click += new System.EventHandler(this.btnF2KalaAnbar_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmCostPriceMahsool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 480);
            this.Controls.Add(this.btnF2KalaAnbar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGhetehAnbar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.grdCostPrice);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGhetehCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtGheteName);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmCostPriceMahsool";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "ثبت قیمت محصولات";
            this.Load += new System.EventHandler(this.FrmCostPriceMahsool_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCostPrice.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCostPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnF2KalaAnbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGhetehCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGheteName;
        public Telerik.WinControls.UI.RadButton btnExcel;
        public Telerik.WinControls.UI.RadButton btnRefresh;
        public Telerik.WinControls.UI.RadButton btnAdd;
        private Telerik.WinControls.UI.RadGridView grdCostPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGhetehAnbar;
        public Telerik.WinControls.UI.RadButton btnF2KalaAnbar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

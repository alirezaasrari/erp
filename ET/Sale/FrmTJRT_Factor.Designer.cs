namespace ET
{
    partial class FrmTJRT_Factor
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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTJRT_Factor));
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.txtFactor = new Telerik.WinControls.UI.RadTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddFactor = new Telerik.WinControls.UI.RadButton();
            this.btnAddBarge = new Telerik.WinControls.UI.RadButton();
            this.txtIdBarge = new Telerik.WinControls.UI.RadTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grd = new Telerik.WinControls.UI.RadGridView();
            this.btnCalc = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddBarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdBarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCalc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFactor
            // 
            this.txtFactor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFactor.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFactor.Location = new System.Drawing.Point(779, 50);
            this.txtFactor.MaxLength = 12;
            this.txtFactor.Name = "txtFactor";
            this.txtFactor.Size = new System.Drawing.Size(183, 21);
            this.txtFactor.TabIndex = 323;
            this.txtFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(968, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 322;
            this.label3.Text = "شماره فاکتور";
            // 
            // btnAddFactor
            // 
            this.btnAddFactor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFactor.Enabled = false;
            this.btnAddFactor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAddFactor.Image = global::ET.Properties.Resources.ADD;
            this.btnAddFactor.Location = new System.Drawing.Point(742, 50);
            this.btnAddFactor.Name = "btnAddFactor";
            this.btnAddFactor.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnAddFactor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAddFactor.Size = new System.Drawing.Size(31, 25);
            this.btnAddFactor.TabIndex = 324;
            this.btnAddFactor.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddFactor.Click += new System.EventHandler(this.btnAddFactor_Click);
            // 
            // btnAddBarge
            // 
            this.btnAddBarge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddBarge.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAddBarge.Image = global::ET.Properties.Resources.ADD;
            this.btnAddBarge.Location = new System.Drawing.Point(742, 12);
            this.btnAddBarge.Name = "btnAddBarge";
            this.btnAddBarge.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnAddBarge.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAddBarge.Size = new System.Drawing.Size(31, 25);
            this.btnAddBarge.TabIndex = 327;
            this.btnAddBarge.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddBarge.Click += new System.EventHandler(this.btnAddBarge_Click);
            // 
            // txtIdBarge
            // 
            this.txtIdBarge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdBarge.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdBarge.Location = new System.Drawing.Point(779, 12);
            this.txtIdBarge.MaxLength = 12;
            this.txtIdBarge.Name = "txtIdBarge";
            this.txtIdBarge.ReadOnly = true;
            this.txtIdBarge.Size = new System.Drawing.Size(183, 21);
            this.txtIdBarge.TabIndex = 326;
            this.txtIdBarge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(968, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 325;
            this.label1.Text = "شماره برگه";
            // 
            // grd
            // 
            this.grd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grd.Cursor = System.Windows.Forms.Cursors.Default;
            this.grd.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grd.ForeColor = System.Drawing.Color.Black;
            this.grd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grd.Location = new System.Drawing.Point(12, 89);
            // 
            // 
            // 
            this.grd.MasterTemplate.AllowAddNewRow = false;
            this.grd.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "CkalaH";
            gridViewTextBoxColumn1.HeaderText = "کد کالا";
            gridViewTextBoxColumn1.Name = "CkalaH";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn1.Width = 141;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "NkalaH";
            gridViewTextBoxColumn2.HeaderText = "نام کالا";
            gridViewTextBoxColumn2.Name = "NkalaH";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.Width = 320;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "IdFactorD";
            gridViewTextBoxColumn3.HeaderText = "IdFactorD";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "IdFactorD";
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "IdFactorH";
            gridViewTextBoxColumn4.HeaderText = "شماره فاکتور";
            gridViewTextBoxColumn4.Name = "IdFactorH";
            gridViewTextBoxColumn4.Width = 115;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "Meghdar";
            gridViewTextBoxColumn5.HeaderText = "مقدار";
            gridViewTextBoxColumn5.Name = "Meghdar";
            gridViewTextBoxColumn5.Width = 101;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "Nerkh";
            gridViewTextBoxColumn6.HeaderText = "نرخ";
            gridViewTextBoxColumn6.Name = "Nerkh";
            gridViewTextBoxColumn6.Width = 93;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "Mablagh";
            gridViewTextBoxColumn7.HeaderText = "مبلغ";
            gridViewTextBoxColumn7.Name = "Mablagh";
            gridViewTextBoxColumn7.Width = 154;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.FieldName = "IsKit";
            gridViewCheckBoxColumn1.HeaderText = "کیت";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "IsKit";
            gridViewCheckBoxColumn1.Width = 74;
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.FieldName = "btnDelete";
            gridViewCommandColumn1.HeaderText = "حذف";
            gridViewCommandColumn1.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn1.Image")));
            gridViewCommandColumn1.Name = "btnDelete";
            this.grd.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewCheckBoxColumn1,
            gridViewCommandColumn1});
            this.grd.MasterTemplate.EnableFiltering = true;
            this.grd.MasterTemplate.ShowGroupedColumns = true;
            this.grd.MasterTemplate.ShowRowHeaderColumn = false;
            this.grd.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grd.Name = "grd";
            this.grd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grd.ShowGroupPanel = false;
            this.grd.Size = new System.Drawing.Size(1035, 467);
            this.grd.TabIndex = 328;
            this.grd.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grd_CellClick);
            // 
            // btnCalc
            // 
            this.btnCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnCalc.Image = global::ET.Properties.Resources.UpLoad;
            this.btnCalc.Location = new System.Drawing.Point(465, 50);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnCalc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCalc.Size = new System.Drawing.Size(160, 25);
            this.btnCalc.TabIndex = 325;
            this.btnCalc.Text = "محاسبه سامانه تجارت";
            this.btnCalc.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // FrmTJRT_Factor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 568);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.grd);
            this.Controls.Add(this.btnAddBarge);
            this.Controls.Add(this.txtIdBarge);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddFactor);
            this.Controls.Add(this.txtFactor);
            this.Controls.Add(this.label3);
            this.Name = "FrmTJRT_Factor";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فاکتورهای سامانه تجارت";
            this.Load += new System.EventHandler(this.FrmTJRT_Factor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddBarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdBarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCalc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox txtFactor;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadButton btnAddFactor;
        private Telerik.WinControls.UI.RadButton btnAddBarge;
        private Telerik.WinControls.UI.RadTextBox txtIdBarge;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadGridView grd;
        private Telerik.WinControls.UI.RadButton btnCalc;
    }
}

namespace ET
{
    partial class FrmTJRT_BargeList
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
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTJRT_BargeList));
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn3 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.grd = new Telerik.WinControls.UI.RadGridView();
            this.btnAddBarge = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddBarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
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
            this.grd.Location = new System.Drawing.Point(12, 40);
            // 
            // 
            // 
            this.grd.MasterTemplate.AllowAddNewRow = false;
            this.grd.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "IdBarge";
            gridViewTextBoxColumn1.HeaderText = "شماره برگه";
            gridViewTextBoxColumn1.Name = "IdBarge";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn1.Width = 123;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "DateBarge";
            gridViewTextBoxColumn2.HeaderText = "تاریخ";
            gridViewTextBoxColumn2.Name = "DateBarge";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.Width = 185;
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.FieldName = "btnFactor";
            gridViewCommandColumn1.HeaderText = "ثبت فاکتور";
            gridViewCommandColumn1.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn1.Image")));
            gridViewCommandColumn1.Name = "btnFactor";
            gridViewCommandColumn1.Width = 113;
            gridViewCommandColumn2.EnableExpressionEditor = false;
            gridViewCommandColumn2.FieldName = "btnSamane";
            gridViewCommandColumn2.HeaderText = "سامانه تجارت";
            gridViewCommandColumn2.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn2.Image")));
            gridViewCommandColumn2.Name = "btnSamane";
            gridViewCommandColumn2.Width = 106;
            gridViewCommandColumn3.EnableExpressionEditor = false;
            gridViewCommandColumn3.FieldName = "btnDelete";
            gridViewCommandColumn3.HeaderText = "حذف";
            gridViewCommandColumn3.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn3.Image")));
            gridViewCommandColumn3.Name = "btnDelete";
            this.grd.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewCommandColumn1,
            gridViewCommandColumn2,
            gridViewCommandColumn3});
            this.grd.MasterTemplate.EnableFiltering = true;
            this.grd.MasterTemplate.ShowGroupedColumns = true;
            this.grd.MasterTemplate.ShowRowHeaderColumn = false;
            this.grd.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grd.Name = "grd";
            this.grd.ReadOnly = true;
            this.grd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grd.ShowGroupPanel = false;
            this.grd.Size = new System.Drawing.Size(843, 661);
            this.grd.TabIndex = 329;
            this.grd.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grd_CellClick);
            // 
            // btnAddBarge
            // 
            this.btnAddBarge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddBarge.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAddBarge.Image = global::ET.Properties.Resources.ADD;
            this.btnAddBarge.Location = new System.Drawing.Point(747, 9);
            this.btnAddBarge.Name = "btnAddBarge";
            this.btnAddBarge.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnAddBarge.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAddBarge.Size = new System.Drawing.Size(108, 25);
            this.btnAddBarge.TabIndex = 330;
            this.btnAddBarge.Tag = "";
            this.btnAddBarge.Text = "افزودن برگه";
            this.btnAddBarge.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddBarge.Click += new System.EventHandler(this.btnAddBarge_Click);
            // 
            // FrmTJRT_BargeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 713);
            this.Controls.Add(this.btnAddBarge);
            this.Controls.Add(this.grd);
            this.Name = "FrmTJRT_BargeList";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "لیست برگه ها";
            this.Load += new System.EventHandler(this.FrmTJRT_BargeList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grd.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddBarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grd;
        private Telerik.WinControls.UI.RadButton btnAddBarge;
    }
}

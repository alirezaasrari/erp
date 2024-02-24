namespace ET
{
    partial class FrmTakvinShowMostanadAll
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn23 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn24 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.GrdMostanadAll = new Telerik.WinControls.UI.RadGridView();
            this.btnExcel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.GrdMostanadAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdMostanadAll.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // GrdMostanadAll
            // 
            this.GrdMostanadAll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrdMostanadAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.GrdMostanadAll.Cursor = System.Windows.Forms.Cursors.Default;
            this.GrdMostanadAll.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.GrdMostanadAll.ForeColor = System.Drawing.Color.Black;
            this.GrdMostanadAll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GrdMostanadAll.Location = new System.Drawing.Point(0, 31);
            // 
            // 
            // 
            this.GrdMostanadAll.MasterTemplate.AllowAddNewRow = false;
            this.GrdMostanadAll.MasterTemplate.AllowColumnReorder = false;
            this.GrdMostanadAll.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn13.EnableExpressionEditor = false;
            gridViewTextBoxColumn13.FieldName = "IDMostanad";
            gridViewTextBoxColumn13.HeaderText = "شماره مستند";
            gridViewTextBoxColumn13.Name = "IDMostanad";
            gridViewTextBoxColumn13.Width = 85;
            gridViewTextBoxColumn14.EnableExpressionEditor = false;
            gridViewTextBoxColumn14.FieldName = "FaniNo";
            gridViewTextBoxColumn14.HeaderText = "شماره فنی";
            gridViewTextBoxColumn14.Name = "FaniNo";
            gridViewTextBoxColumn14.Width = 116;
            gridViewTextBoxColumn15.EnableExpressionEditor = false;
            gridViewTextBoxColumn15.FieldName = "GhetehCode";
            gridViewTextBoxColumn15.HeaderText = "کد قطعه";
            gridViewTextBoxColumn15.Name = "GhetehCode";
            gridViewTextBoxColumn15.Width = 104;
            gridViewTextBoxColumn16.EnableExpressionEditor = false;
            gridViewTextBoxColumn16.FieldName = "GheteName";
            gridViewTextBoxColumn16.HeaderText = "نام قطعه";
            gridViewTextBoxColumn16.Name = "GheteName";
            gridViewTextBoxColumn16.Width = 247;
            gridViewTextBoxColumn17.EnableExpressionEditor = false;
            gridViewTextBoxColumn17.FieldName = "GhetehAnbar";
            gridViewTextBoxColumn17.HeaderText = "کد انبار";
            gridViewTextBoxColumn17.Name = "GhetehAnbar";
            gridViewTextBoxColumn17.Width = 45;
            gridViewTextBoxColumn18.EnableExpressionEditor = false;
            gridViewTextBoxColumn18.FieldName = "MostanadTypeName";
            gridViewTextBoxColumn18.HeaderText = "نوع مستند";
            gridViewTextBoxColumn18.Name = "MostanadTypeName";
            gridViewTextBoxColumn18.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn18.Width = 86;
            gridViewTextBoxColumn19.EnableExpressionEditor = false;
            gridViewTextBoxColumn19.FieldName = "MosVersion";
            gridViewTextBoxColumn19.HeaderText = "ویرایش مستند";
            gridViewTextBoxColumn19.Name = "MosVersion";
            gridViewTextBoxColumn19.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn19.Width = 57;
            gridViewTextBoxColumn20.EnableExpressionEditor = false;
            gridViewTextBoxColumn20.FieldName = "DateSanad";
            gridViewTextBoxColumn20.HeaderText = "تاریخ سند";
            gridViewTextBoxColumn20.Name = "DateSanad";
            gridViewTextBoxColumn20.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn20.Width = 81;
            gridViewTextBoxColumn21.EnableExpressionEditor = false;
            gridViewTextBoxColumn21.FieldName = "DateCreate";
            gridViewTextBoxColumn21.HeaderText = "تاریخ به روز رسانی";
            gridViewTextBoxColumn21.Name = "DateCreate";
            gridViewTextBoxColumn21.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn21.Width = 84;
            gridViewTextBoxColumn22.EnableExpressionEditor = false;
            gridViewTextBoxColumn22.FieldName = "MosTime";
            gridViewTextBoxColumn22.HeaderText = "ساعت";
            gridViewTextBoxColumn22.Name = "MosTime";
            gridViewTextBoxColumn22.Width = 68;
            gridViewTextBoxColumn23.EnableExpressionEditor = false;
            gridViewTextBoxColumn23.FieldName = "DescMostanadVaziat";
            gridViewTextBoxColumn23.HeaderText = "وضعیت مستند";
            gridViewTextBoxColumn23.Name = "DescMostanadVaziat";
            gridViewTextBoxColumn23.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn23.Width = 57;
            gridViewTextBoxColumn24.EnableExpressionEditor = false;
            gridViewTextBoxColumn24.FieldName = "username";
            gridViewTextBoxColumn24.HeaderText = "کاربر";
            gridViewTextBoxColumn24.Name = "username";
            gridViewCommandColumn2.DefaultText = "پیوست";
            gridViewCommandColumn2.EnableExpressionEditor = false;
            gridViewCommandColumn2.FieldName = "MostanadPic";
            gridViewCommandColumn2.HeaderText = "نمایش";
            gridViewCommandColumn2.Name = "MostanadPic";
            gridViewCommandColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.UseDefaultText = true;
            gridViewCommandColumn2.Width = 59;
            this.GrdMostanadAll.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
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
            gridViewTextBoxColumn23,
            gridViewTextBoxColumn24,
            gridViewCommandColumn2});
            this.GrdMostanadAll.MasterTemplate.EnableAlternatingRowColor = true;
            this.GrdMostanadAll.MasterTemplate.EnableFiltering = true;
            this.GrdMostanadAll.MasterTemplate.ShowGroupedColumns = true;
            this.GrdMostanadAll.MasterTemplate.ShowRowHeaderColumn = false;
            this.GrdMostanadAll.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.GrdMostanadAll.Name = "GrdMostanadAll";
            this.GrdMostanadAll.ReadOnly = true;
            this.GrdMostanadAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GrdMostanadAll.Size = new System.Drawing.Size(976, 497);
            this.GrdMostanadAll.TabIndex = 6;
            this.GrdMostanadAll.Text = "radGridView1";
            this.GrdMostanadAll.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.GrdMostanadAll_CellClick);
            // 
            // btnExcel
            // 
            this.btnExcel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Image = global::ET.Properties.Resources.Excel1;
            this.btnExcel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExcel.Location = new System.Drawing.Point(2, 3);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnExcel.Size = new System.Drawing.Size(27, 25);
            this.btnExcel.TabIndex = 266;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // FrmTakvinShowMostanadAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 531);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.GrdMostanadAll);
            this.Name = "FrmTakvinShowMostanadAll";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "مشاهده مستندات";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTakvinShowMostanadAll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrdMostanadAll.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdMostanadAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView GrdMostanadAll;
        private Telerik.WinControls.UI.RadButton btnExcel;
    }
}

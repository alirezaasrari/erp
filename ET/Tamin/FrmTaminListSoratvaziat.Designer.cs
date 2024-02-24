namespace ET
{
    partial class FrmTaminListSoratvaziat
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTaminListSoratvaziat));
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.grd = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd.MasterTemplate)).BeginInit();
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
            this.grd.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.grd.ForeColor = System.Drawing.Color.Black;
            this.grd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grd.Location = new System.Drawing.Point(12, 12);
            // 
            // 
            // 
            this.grd.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "IdSoratVaziatH";
            gridViewTextBoxColumn5.HeaderText = "شماره صورت وضعیت";
            gridViewTextBoxColumn5.Name = "IdSoratVaziatH";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 140;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "DateSorat";
            gridViewTextBoxColumn6.HeaderText = "تاریخ ایجاد";
            gridViewTextBoxColumn6.Name = "DateSorat";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn6.Width = 99;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "DateTasvib";
            gridViewTextBoxColumn7.HeaderText = "تاریخ تصویب";
            gridViewTextBoxColumn7.Name = "DateTasvib";
            gridViewTextBoxColumn7.ReadOnly = true;
            gridViewTextBoxColumn7.Width = 105;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "Tozihat";
            gridViewTextBoxColumn8.HeaderText = "توضیحات";
            gridViewTextBoxColumn8.Name = "Tozihat";
            gridViewTextBoxColumn8.Width = 150;
            gridViewCommandColumn2.EnableExpressionEditor = false;
            gridViewCommandColumn2.FieldName = "btnPrint";
            gridViewCommandColumn2.HeaderText = "چاپ";
            gridViewCommandColumn2.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn2.Image")));
            gridViewCommandColumn2.Name = "btnPrint";
            gridViewCommandColumn2.Width = 60;
            this.grd.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewCommandColumn2});
            this.grd.MasterTemplate.EnableFiltering = true;
            this.grd.MasterTemplate.EnableGrouping = false;
            this.grd.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grd.Name = "grd";
            this.grd.ReadOnly = true;
            this.grd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grd.Size = new System.Drawing.Size(904, 459);
            this.grd.TabIndex = 3;
            this.grd.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grd_CellClick);
            // 
            // FrmTaminListSoratvaziat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 518);
            this.Controls.Add(this.grd);
            this.Name = "FrmTaminListSoratvaziat";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "لیست صورت وضعیت";
            this.Load += new System.EventHandler(this.FrmTaminListSoratvaziat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grd.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grd;
    }
}

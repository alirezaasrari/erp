namespace ET
{
    partial class FrmTakvinBomSearch
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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.GrdBOM = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.GrdBOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdBOM.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // GrdBOM
            // 
            this.GrdBOM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrdBOM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.GrdBOM.Cursor = System.Windows.Forms.Cursors.Default;
            this.GrdBOM.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.GrdBOM.ForeColor = System.Drawing.Color.Black;
            this.GrdBOM.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GrdBOM.Location = new System.Drawing.Point(12, 12);
            // 
            // 
            // 
            this.GrdBOM.MasterTemplate.AllowAddNewRow = false;
            this.GrdBOM.MasterTemplate.AllowColumnReorder = false;
            this.GrdBOM.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "ID_Bom";
            gridViewTextBoxColumn1.HeaderText = "کد  BOM";
            gridViewTextBoxColumn1.Name = "ID_Bom";
            gridViewTextBoxColumn1.Width = 97;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "NameBom";
            gridViewTextBoxColumn2.HeaderText = "نام  BOM";
            gridViewTextBoxColumn2.Name = "NameBom";
            gridViewTextBoxColumn2.Width = 275;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "FK_Vahedsanjesh";
            gridViewTextBoxColumn3.HeaderText = "کد نوع سنجش واحد";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "FK_Vahedsanjesh";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn3.Width = 111;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "FK_VahedsanjeshName";
            gridViewTextBoxColumn4.HeaderText = "نوع سنجش واحد";
            gridViewTextBoxColumn4.Name = "FK_VahedsanjeshName";
            gridViewTextBoxColumn4.Width = 106;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "MavadCode";
            gridViewTextBoxColumn5.HeaderText = "کد مواد";
            gridViewTextBoxColumn5.Name = "MavadCode";
            gridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn5.Width = 116;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "N_Kala";
            gridViewTextBoxColumn6.HeaderText = "نام مواد";
            gridViewTextBoxColumn6.Name = "N_Kala";
            gridViewTextBoxColumn6.Width = 166;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "MavadAnabr";
            gridViewTextBoxColumn7.HeaderText = "انبار مواد";
            gridViewTextBoxColumn7.Name = "MavadAnabr";
            gridViewTextBoxColumn7.Width = 56;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "MavadDarsad";
            gridViewTextBoxColumn8.HeaderText = "درصد مواد";
            gridViewTextBoxColumn8.Name = "MavadDarsad";
            gridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn8.Width = 71;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.FieldName = "VaziatEjraee";
            gridViewCheckBoxColumn1.HeaderText = "وضعیت اجرا";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "VaziatEjraee";
            gridViewCheckBoxColumn1.Width = 71;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "date_insert";
            gridViewTextBoxColumn9.HeaderText = "تاریخ ویرایش";
            gridViewTextBoxColumn9.Name = "date_insert";
            gridViewTextBoxColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn9.Width = 101;
            this.GrdBOM.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn9});
            this.GrdBOM.MasterTemplate.EnableAlternatingRowColor = true;
            this.GrdBOM.MasterTemplate.EnableFiltering = true;
            this.GrdBOM.MasterTemplate.ShowGroupedColumns = true;
            this.GrdBOM.MasterTemplate.ShowRowHeaderColumn = false;
            this.GrdBOM.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GrdBOM.Name = "GrdBOM";
            this.GrdBOM.ReadOnly = true;
            this.GrdBOM.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GrdBOM.Size = new System.Drawing.Size(978, 518);
            this.GrdBOM.TabIndex = 186;
            this.GrdBOM.Text = "radGridView1";
            this.GrdBOM.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.GrdBOM_CellDoubleClick);
            // 
            // FrmTakvinBomSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 542);
            this.Controls.Add(this.GrdBOM);
            this.KeyPreview = true;
            this.Name = "FrmTakvinBomSearch";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "BOM";
            this.Load += new System.EventHandler(this.FrmTakvinBomSearch_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmTakvinBomSearch_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.GrdBOM.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdBOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView GrdBOM;
    }
}

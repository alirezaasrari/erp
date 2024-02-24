namespace ET
{
    partial class FrmPM_ElatTakhir
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
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rgrdElat = new Telerik.WinControls.UI.RadGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_delete = new Telerik.WinControls.UI.RadButton();
            this.btn_save = new Telerik.WinControls.UI.RadButton();
            this.txt_Nelat = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.rgrdElat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgrdElat.MasterTemplate)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_save)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rgrdElat
            // 
            this.rgrdElat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.rgrdElat.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgrdElat.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgrdElat.ForeColor = System.Drawing.Color.Black;
            this.rgrdElat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgrdElat.Location = new System.Drawing.Point(5, 129);
            // 
            // 
            // 
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "ID_Halt";
            gridViewTextBoxColumn1.HeaderText = "کد علت توقف";
            gridViewTextBoxColumn1.Name = "ID_Halt";
            gridViewTextBoxColumn1.Width = 98;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "ReasonHalt";
            gridViewTextBoxColumn2.HeaderText = "نام علت توقف";
            gridViewTextBoxColumn2.Name = "ReasonHalt";
            gridViewTextBoxColumn2.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending;
            gridViewTextBoxColumn2.Width = 210;
            this.rgrdElat.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2});
            sortDescriptor1.PropertyName = "ReasonHalt";
            this.rgrdElat.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.rgrdElat.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rgrdElat.Name = "rgrdElat";
            this.rgrdElat.ReadOnly = true;
            this.rgrdElat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rgrdElat.Size = new System.Drawing.Size(357, 277);
            this.rgrdElat.TabIndex = 0;
            this.rgrdElat.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgrdElat_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_delete);
            this.groupBox1.Controls.Add(this.btn_save);
            this.groupBox1.Controls.Add(this.txt_Nelat);
            this.groupBox1.Location = new System.Drawing.Point(7, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 125);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "نام علت توقف";
            // 
            // btn_delete
            // 
            this.btn_delete.Image = global::ET.Properties.Resources.Remove;
            this.btn_delete.Location = new System.Drawing.Point(50, 83);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(72, 24);
            this.btn_delete.TabIndex = 3;
            this.btn_delete.Text = "حذف";
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_save
            // 
            this.btn_save.Image = global::ET.Properties.Resources.Save;
            this.btn_save.Location = new System.Drawing.Point(142, 83);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(72, 24);
            this.btn_save.TabIndex = 2;
            this.btn_save.Text = "ذخیره";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txt_Nelat
            // 
            this.txt_Nelat.Location = new System.Drawing.Point(50, 49);
            this.txt_Nelat.Name = "txt_Nelat";
            this.txt_Nelat.Size = new System.Drawing.Size(200, 20);
            this.txt_Nelat.TabIndex = 1;
            // 
            // FrmPM_ElatTakhir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 418);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rgrdElat);
            this.Name = "FrmPM_ElatTakhir";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "علت تاخیر";
            this.Load += new System.EventHandler(this.FrmElat_takhir_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgrdElat.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgrdElat)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_save)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView rgrdElat;
        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadButton btn_delete;
        private Telerik.WinControls.UI.RadButton btn_save;
        private System.Windows.Forms.TextBox txt_Nelat;
        private System.Windows.Forms.Label label2;
    }
}
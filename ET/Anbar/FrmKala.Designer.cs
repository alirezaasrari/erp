namespace ET
{
    partial class FrmKala
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNkala = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCkala = new System.Windows.Forms.TextBox();
            this.Grd = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grd.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(437, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "نام کالا";
            // 
            // txtNkala
            // 
            this.txtNkala.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNkala.Location = new System.Drawing.Point(266, 18);
            this.txtNkala.Name = "txtNkala";
            this.txtNkala.Size = new System.Drawing.Size(165, 20);
            this.txtNkala.TabIndex = 1;
            this.txtNkala.TextChanged += new System.EventHandler(this.txtNkala_TextChanged);
            this.txtNkala.Enter += new System.EventHandler(this.txtNkala_Enter);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(437, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "کد کالا";
            // 
            // txtCkala
            // 
            this.txtCkala.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCkala.Location = new System.Drawing.Point(266, 44);
            this.txtCkala.Name = "txtCkala";
            this.txtCkala.Size = new System.Drawing.Size(165, 20);
            this.txtCkala.TabIndex = 2;
            this.txtCkala.TextChanged += new System.EventHandler(this.txtCkala_TextChanged);
            // 
            // Grd
            // 
            this.Grd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.Grd.Cursor = System.Windows.Forms.Cursors.Default;
            this.Grd.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Grd.ForeColor = System.Drawing.Color.Black;
            this.Grd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Grd.Location = new System.Drawing.Point(12, 91);
            // 
            // 
            // 
            this.Grd.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "C_Kala";
            gridViewTextBoxColumn1.HeaderText = "کد کالا";
            gridViewTextBoxColumn1.Name = "C_Kala";
            gridViewTextBoxColumn1.Width = 160;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "N_Kala";
            gridViewTextBoxColumn2.HeaderText = "نام کالا";
            gridViewTextBoxColumn2.Name = "N_Kala";
            gridViewTextBoxColumn2.Width = 241;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "N_Vahed";
            gridViewTextBoxColumn3.HeaderText = "واحد کالا";
            gridViewTextBoxColumn3.Name = "N_Vahed";
            gridViewTextBoxColumn3.Width = 114;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "C_Anbar";
            gridViewTextBoxColumn4.HeaderText = "کد انبار";
            gridViewTextBoxColumn4.Name = "C_Anbar";
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "N_anbar";
            gridViewTextBoxColumn5.HeaderText = "نام انبار";
            gridViewTextBoxColumn5.Name = "N_anbar";
            gridViewTextBoxColumn5.Width = 112;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "id_Gheteh";
            gridViewTextBoxColumn6.HeaderText = "column1";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "id_Gheteh";
            this.Grd.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.Grd.MasterTemplate.EnableFiltering = true;
            this.Grd.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.Grd.Name = "Grd";
            this.Grd.ReadOnly = true;
            this.Grd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Grd.Size = new System.Drawing.Size(484, 239);
            this.Grd.TabIndex = 8;
            this.Grd.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdKala_CellDoubleClick);
            this.Grd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdKala_KeyDown);
            // 
            // FrmKala
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 342);
            this.Controls.Add(this.Grd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCkala);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNkala);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmKala";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جستجوی کالا";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.RadForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grd.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNkala;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCkala;
        private Telerik.WinControls.UI.RadGridView Grd;
    }
}

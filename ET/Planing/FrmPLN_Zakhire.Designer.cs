namespace ET
{
    partial class FrmPLN_Zakhire
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.grdZakhire = new Telerik.WinControls.UI.RadGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtZakhire = new System.Windows.Forms.TextBox();
            this.btnF2Kala = new Telerik.WinControls.UI.RadButton();
            this.lblCKala = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNKala = new System.Windows.Forms.TextBox();
            this.btnAddZakhire = new Telerik.WinControls.UI.RadButton();
            this.lblCAnbar = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdZakhire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZakhire.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnF2Kala)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddZakhire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grdZakhire
            // 
            this.grdZakhire.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdZakhire.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grdZakhire.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdZakhire.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.grdZakhire.ForeColor = System.Drawing.Color.Black;
            this.grdZakhire.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdZakhire.Location = new System.Drawing.Point(12, 84);
            // 
            // 
            // 
            this.grdZakhire.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "C_Kala";
            gridViewTextBoxColumn6.HeaderText = "کد کالا";
            gridViewTextBoxColumn6.Name = "C_Kala";
            gridViewTextBoxColumn6.Width = 125;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "N_Kala";
            gridViewTextBoxColumn7.HeaderText = "نام کالا";
            gridViewTextBoxColumn7.Name = "N_Kala";
            gridViewTextBoxColumn7.Width = 250;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "C_anbar";
            gridViewTextBoxColumn8.HeaderText = "کد انبار";
            gridViewTextBoxColumn8.Name = "C_anbar";
            gridViewTextBoxColumn8.Width = 45;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "N_anbar";
            gridViewTextBoxColumn9.HeaderText = "نام انبار";
            gridViewTextBoxColumn9.Name = "N_anbar";
            gridViewTextBoxColumn9.Width = 122;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "ZakhireAnbar";
            gridViewTextBoxColumn10.HeaderText = "مقدار ذخیره احتیاطی";
            gridViewTextBoxColumn10.Name = "ZakhireAnbar";
            gridViewTextBoxColumn10.Width = 107;
            this.grdZakhire.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10});
            this.grdZakhire.MasterTemplate.EnableFiltering = true;
            this.grdZakhire.MasterTemplate.EnableGrouping = false;
            this.grdZakhire.MasterTemplate.ShowRowHeaderColumn = false;
            this.grdZakhire.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grdZakhire.Name = "grdZakhire";
            this.grdZakhire.ReadOnly = true;
            this.grdZakhire.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdZakhire.Size = new System.Drawing.Size(907, 401);
            this.grdZakhire.TabIndex = 267;
            this.grdZakhire.TabStop = false;
            this.grdZakhire.Text = "radGridView2";
            this.grdZakhire.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.MasterTemplate_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(840, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 290;
            this.label1.Text = "ذخیره احتیاطی:";
            // 
            // txtZakhire
            // 
            this.txtZakhire.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtZakhire.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtZakhire.Location = new System.Drawing.Point(718, 42);
            this.txtZakhire.Name = "txtZakhire";
            this.txtZakhire.Size = new System.Drawing.Size(109, 21);
            this.txtZakhire.TabIndex = 291;
            // 
            // btnF2Kala
            // 
            this.btnF2Kala.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnF2Kala.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnF2Kala.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnF2Kala.Location = new System.Drawing.Point(374, 7);
            this.btnF2Kala.Name = "btnF2Kala";
            this.btnF2Kala.Size = new System.Drawing.Size(23, 20);
            this.btnF2Kala.TabIndex = 289;
            this.btnF2Kala.Text = "...";
            this.btnF2Kala.Click += new System.EventHandler(this.btnF2Kala_Click);
            // 
            // lblCKala
            // 
            this.lblCKala.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCKala.AutoSize = true;
            this.lblCKala.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCKala.Location = new System.Drawing.Point(228, 9);
            this.lblCKala.Name = "lblCKala";
            this.lblCKala.Size = new System.Drawing.Size(13, 13);
            this.lblCKala.TabIndex = 288;
            this.lblCKala.Text = "_";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(893, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 286;
            this.label7.Text = "کالا:";
            // 
            // txtNKala
            // 
            this.txtNKala.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNKala.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtNKala.Location = new System.Drawing.Point(403, 6);
            this.txtNKala.Name = "txtNKala";
            this.txtNKala.Size = new System.Drawing.Size(484, 21);
            this.txtNKala.TabIndex = 287;
            // 
            // btnAddZakhire
            // 
            this.btnAddZakhire.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAddZakhire.Image = global::ET.Properties.Resources.Edit;
            this.btnAddZakhire.Location = new System.Drawing.Point(12, 7);
            this.btnAddZakhire.Name = "btnAddZakhire";
            this.btnAddZakhire.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnAddZakhire.Size = new System.Drawing.Size(37, 25);
            this.btnAddZakhire.TabIndex = 285;
            this.btnAddZakhire.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddZakhire.Click += new System.EventHandler(this.btnAddZakhire_Click);
            // 
            // lblCAnbar
            // 
            this.lblCAnbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCAnbar.AutoSize = true;
            this.lblCAnbar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCAnbar.Location = new System.Drawing.Point(517, 50);
            this.lblCAnbar.Name = "lblCAnbar";
            this.lblCAnbar.Size = new System.Drawing.Size(13, 13);
            this.lblCAnbar.TabIndex = 292;
            this.lblCAnbar.Text = "_";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(558, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 293;
            this.label3.Text = "کد انبار:";
            // 
            // FrmPLN_Zakhire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 497);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCAnbar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtZakhire);
            this.Controls.Add(this.btnF2Kala);
            this.Controls.Add(this.lblCKala);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNKala);
            this.Controls.Add(this.btnAddZakhire);
            this.Controls.Add(this.grdZakhire);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmPLN_Zakhire";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "ذخیره احتیاطی";
            this.Load += new System.EventHandler(this.FrmPLN_Zakhire_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdZakhire.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZakhire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnF2Kala)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddZakhire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grdZakhire;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtZakhire;
        public Telerik.WinControls.UI.RadButton btnF2Kala;
        private System.Windows.Forms.Label lblCKala;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNKala;
        public Telerik.WinControls.UI.RadButton btnAddZakhire;
        private System.Windows.Forms.Label lblCAnbar;
        private System.Windows.Forms.Label label3;
    }
}

namespace ET
{
    partial class FrmTolid_MojudiKhat
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.grdMojudiKhat = new Telerik.WinControls.UI.RadGridView();
            this.btnAddMojoodiKhat = new Telerik.WinControls.UI.RadButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNKala = new System.Windows.Forms.TextBox();
            this.btnF2Kala = new Telerik.WinControls.UI.RadButton();
            this.lblCKala = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMojudiKhat = new System.Windows.Forms.TextBox();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnShow = new Telerik.WinControls.UI.RadButton();
            this.dtpDateMojoodi = new Telerik.WinControls.UI.RadDateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdMojudiKhat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMojudiKhat.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddMojoodiKhat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnF2Kala)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateMojoodi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grdMojudiKhat
            // 
            this.grdMojudiKhat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdMojudiKhat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grdMojudiKhat.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdMojudiKhat.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.grdMojudiKhat.ForeColor = System.Drawing.Color.Black;
            this.grdMojudiKhat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdMojudiKhat.Location = new System.Drawing.Point(12, 143);
            // 
            // 
            // 
            this.grdMojudiKhat.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "idMojudiKhat";
            gridViewTextBoxColumn1.HeaderText = "idMojudiKhat";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "idMojudiKhat";
            gridViewTextBoxColumn1.Width = 71;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "GhetehCode";
            gridViewTextBoxColumn2.HeaderText = "کد قطعه";
            gridViewTextBoxColumn2.Name = "GhetehCode";
            gridViewTextBoxColumn2.Width = 143;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "GheteName";
            gridViewTextBoxColumn3.HeaderText = "نام قطعه";
            gridViewTextBoxColumn3.Name = "GheteName";
            gridViewTextBoxColumn3.Width = 356;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "tedadKhat";
            gridViewTextBoxColumn4.HeaderText = "موجودی";
            gridViewTextBoxColumn4.Name = "tedadKhat";
            gridViewTextBoxColumn4.Width = 84;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "DateMojoodi";
            gridViewTextBoxColumn5.HeaderText = "تاریخ ثبت";
            gridViewTextBoxColumn5.Name = "DateMojoodi";
            gridViewTextBoxColumn5.Width = 95;
            this.grdMojudiKhat.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.grdMojudiKhat.MasterTemplate.EnableFiltering = true;
            this.grdMojudiKhat.MasterTemplate.EnableGrouping = false;
            this.grdMojudiKhat.MasterTemplate.ShowRowHeaderColumn = false;
            this.grdMojudiKhat.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdMojudiKhat.Name = "grdMojudiKhat";
            this.grdMojudiKhat.ReadOnly = true;
            this.grdMojudiKhat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdMojudiKhat.Size = new System.Drawing.Size(817, 349);
            this.grdMojudiKhat.TabIndex = 265;
            this.grdMojudiKhat.TabStop = false;
            this.grdMojudiKhat.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdMojudiKhat_CellDoubleClick);
            // 
            // btnAddMojoodiKhat
            // 
            this.btnAddMojoodiKhat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddMojoodiKhat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAddMojoodiKhat.Image = global::ET.Properties.Resources.Edit;
            this.btnAddMojoodiKhat.Location = new System.Drawing.Point(279, 87);
            this.btnAddMojoodiKhat.Name = "btnAddMojoodiKhat";
            this.btnAddMojoodiKhat.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnAddMojoodiKhat.Size = new System.Drawing.Size(37, 25);
            this.btnAddMojoodiKhat.TabIndex = 278;
            this.btnAddMojoodiKhat.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddMojoodiKhat.Click += new System.EventHandler(this.btnAddMojoodiKhat_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(798, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 279;
            this.label7.Text = "کالا:";
            // 
            // txtNKala
            // 
            this.txtNKala.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNKala.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtNKala.Location = new System.Drawing.Point(284, 48);
            this.txtNKala.Name = "txtNKala";
            this.txtNKala.Size = new System.Drawing.Size(508, 21);
            this.txtNKala.TabIndex = 280;
            // 
            // btnF2Kala
            // 
            this.btnF2Kala.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnF2Kala.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnF2Kala.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnF2Kala.Location = new System.Drawing.Point(255, 49);
            this.btnF2Kala.Name = "btnF2Kala";
            this.btnF2Kala.Size = new System.Drawing.Size(23, 20);
            this.btnF2Kala.TabIndex = 282;
            this.btnF2Kala.Text = "...";
            this.btnF2Kala.Click += new System.EventHandler(this.btnF2Kala_Click);
            // 
            // lblCKala
            // 
            this.lblCKala.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCKala.AutoSize = true;
            this.lblCKala.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCKala.Location = new System.Drawing.Point(133, 51);
            this.lblCKala.Name = "lblCKala";
            this.lblCKala.Size = new System.Drawing.Size(13, 13);
            this.lblCKala.TabIndex = 281;
            this.lblCKala.Text = "_";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(738, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 283;
            this.label1.Text = "موجودی پای خط:";
            // 
            // txtMojudiKhat
            // 
            this.txtMojudiKhat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMojudiKhat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtMojudiKhat.Location = new System.Drawing.Point(623, 84);
            this.txtMojudiKhat.Name = "txtMojudiKhat";
            this.txtMojudiKhat.Size = new System.Drawing.Size(109, 21);
            this.txtMojudiKhat.TabIndex = 284;
            // 
            // cmbUnit
            // 
            this.cmbUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbUnit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(507, 9);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(225, 22);
            this.cmbUnit.TabIndex = 285;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(779, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 286;
            this.label2.Text = "خط تولید:";
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnShow.Image = global::ET.Properties.Resources.ok;
            this.btnShow.Location = new System.Drawing.Point(464, 9);
            this.btnShow.Name = "btnShow";
            this.btnShow.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnShow.Size = new System.Drawing.Size(37, 25);
            this.btnShow.TabIndex = 287;
            this.btnShow.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // dtpDateMojoodi
            // 
            this.dtpDateMojoodi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDateMojoodi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateMojoodi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateMojoodi.Location = new System.Drawing.Point(255, 11);
            this.dtpDateMojoodi.MinDate = new System.DateTime(622, 3, 22, 0, 0, 0, 0);
            this.dtpDateMojoodi.Name = "dtpDateMojoodi";
            this.dtpDateMojoodi.Size = new System.Drawing.Size(104, 19);
            this.dtpDateMojoodi.TabIndex = 288;
            this.dtpDateMojoodi.TabStop = false;
            this.dtpDateMojoodi.Text = "11/10/1393";
            this.dtpDateMojoodi.Value = new System.DateTime(2015, 1, 1, 8, 5, 37, 521);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(365, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 289;
            this.label3.Text = "تاریخ موجودی:";
            // 
            // FrmTolid_MojudiKhat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 504);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpDateMojoodi);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbUnit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMojudiKhat);
            this.Controls.Add(this.btnF2Kala);
            this.Controls.Add(this.lblCKala);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNKala);
            this.Controls.Add(this.btnAddMojoodiKhat);
            this.Controls.Add(this.grdMojudiKhat);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmTolid_MojudiKhat";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "موجودی پای خط";
            this.Load += new System.EventHandler(this.FrmTolid_MojudiKhat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdMojudiKhat.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMojudiKhat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddMojoodiKhat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnF2Kala)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateMojoodi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grdMojudiKhat;
        public Telerik.WinControls.UI.RadButton btnAddMojoodiKhat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNKala;
        public Telerik.WinControls.UI.RadButton btnF2Kala;
        private System.Windows.Forms.Label lblCKala;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMojudiKhat;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Label label2;
        public Telerik.WinControls.UI.RadButton btnShow;
        public Telerik.WinControls.UI.RadDateTimePicker dtpDateMojoodi;
        private System.Windows.Forms.Label label3;
    }
}

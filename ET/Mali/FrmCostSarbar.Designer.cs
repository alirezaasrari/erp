namespace ET
{
    partial class FrmCostSarbar
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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.cmbProcNameKargah = new Telerik.WinControls.UI.RadDropDownList();
            this.txtCodeKargah = new System.Windows.Forms.TextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSarbar = new System.Windows.Forms.TextBox();
            this.btnClearSarbar = new Telerik.WinControls.UI.RadButton();
            this.btnAddSarbar = new Telerik.WinControls.UI.RadButton();
            this.grdSarbar = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProcNameKargah)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClearSarbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddSarbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSarbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSarbar.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbProcNameKargah
            // 
            this.cmbProcNameKargah.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProcNameKargah.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbProcNameKargah.AutoSizeItems = true;
            this.cmbProcNameKargah.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbProcNameKargah.Location = new System.Drawing.Point(713, 38);
            this.cmbProcNameKargah.Name = "cmbProcNameKargah";
            this.cmbProcNameKargah.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbProcNameKargah.Size = new System.Drawing.Size(137, 19);
            this.cmbProcNameKargah.TabIndex = 351;
            this.cmbProcNameKargah.SelectedValueChanged += new System.EventHandler(this.cmbProcNameKargah_SelectedValueChanged);
            this.cmbProcNameKargah.TextChanged += new System.EventHandler(this.cmbProcNameKargah_TextChanged);
            // 
            // txtCodeKargah
            // 
            this.txtCodeKargah.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodeKargah.Location = new System.Drawing.Point(500, 38);
            this.txtCodeKargah.Name = "txtCodeKargah";
            this.txtCodeKargah.ReadOnly = true;
            this.txtCodeKargah.Size = new System.Drawing.Size(127, 20);
            this.txtCodeKargah.TabIndex = 350;
            // 
            // label56
            // 
            this.label56.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(632, 42);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(53, 13);
            this.label56.TabIndex = 349;
            this.label56.Text = "کد کارگاه:";
            // 
            // label55
            // 
            this.label55.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(901, 41);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(54, 13);
            this.label55.TabIndex = 348;
            this.label55.Text = "نام کارگاه:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(901, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 352;
            this.label1.Text = "نرخ سربار:";
            // 
            // txtSarbar
            // 
            this.txtSarbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSarbar.Location = new System.Drawing.Point(713, 86);
            this.txtSarbar.MaxLength = 15;
            this.txtSarbar.Name = "txtSarbar";
            this.txtSarbar.Size = new System.Drawing.Size(137, 20);
            this.txtSarbar.TabIndex = 353;
            // 
            // btnClearSarbar
            // 
            this.btnClearSarbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearSarbar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnClearSarbar.Image = global::ET.Properties.Resources.Refresh;
            this.btnClearSarbar.Location = new System.Drawing.Point(404, 81);
            this.btnClearSarbar.Name = "btnClearSarbar";
            this.btnClearSarbar.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnClearSarbar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClearSarbar.Size = new System.Drawing.Size(31, 25);
            this.btnClearSarbar.TabIndex = 355;
            this.btnClearSarbar.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClearSarbar.Click += new System.EventHandler(this.btnClearSarbar_Click);
            // 
            // btnAddSarbar
            // 
            this.btnAddSarbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSarbar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAddSarbar.Image = global::ET.Properties.Resources.ADD;
            this.btnAddSarbar.Location = new System.Drawing.Point(455, 81);
            this.btnAddSarbar.Name = "btnAddSarbar";
            this.btnAddSarbar.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnAddSarbar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAddSarbar.Size = new System.Drawing.Size(31, 25);
            this.btnAddSarbar.TabIndex = 354;
            this.btnAddSarbar.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddSarbar.Click += new System.EventHandler(this.btnAddSarbar_Click);
            // 
            // grdSarbar
            // 
            this.grdSarbar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSarbar.AutoScroll = true;
            this.grdSarbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grdSarbar.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdSarbar.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grdSarbar.ForeColor = System.Drawing.Color.Black;
            this.grdSarbar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdSarbar.Location = new System.Drawing.Point(12, 112);
            // 
            // 
            // 
            this.grdSarbar.MasterTemplate.AllowAddNewRow = false;
            this.grdSarbar.MasterTemplate.AllowColumnReorder = false;
            this.grdSarbar.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "FK_ID_unit";
            gridViewTextBoxColumn1.HeaderText = "کد واحد";
            gridViewTextBoxColumn1.Name = "FK_ID_unit";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn1.Width = 89;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "onvan";
            gridViewTextBoxColumn2.HeaderText = "نام واحد";
            gridViewTextBoxColumn2.Name = "onvan";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.Width = 145;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "Sarbar";
            gridViewTextBoxColumn3.HeaderText = "سربار برحسب ریال و ثانیه";
            gridViewTextBoxColumn3.Name = "Sarbar";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn3.Width = 237;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.FieldName = "VaziatEjraee";
            gridViewCheckBoxColumn1.HeaderText = "وضعیت اجرا";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "VaziatEjraee";
            gridViewCheckBoxColumn1.Width = 84;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "date_insert";
            gridViewTextBoxColumn4.HeaderText = "تاریخ";
            gridViewTextBoxColumn4.Name = "date_insert";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn4.Width = 108;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "username";
            gridViewTextBoxColumn5.HeaderText = "کاربر";
            gridViewTextBoxColumn5.Name = "username";
            gridViewTextBoxColumn5.Width = 128;
            this.grdSarbar.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.grdSarbar.MasterTemplate.EnableAlternatingRowColor = true;
            this.grdSarbar.MasterTemplate.EnableFiltering = true;
            this.grdSarbar.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.grdSarbar.MasterTemplate.ShowGroupedColumns = true;
            this.grdSarbar.MasterTemplate.ShowRowHeaderColumn = false;
            this.grdSarbar.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdSarbar.Name = "grdSarbar";
            this.grdSarbar.ReadOnly = true;
            this.grdSarbar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdSarbar.Size = new System.Drawing.Size(988, 408);
            this.grdSarbar.TabIndex = 356;
            this.grdSarbar.Text = "radGridView1";
            // 
            // FrmCostSarbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 532);
            this.Controls.Add(this.grdSarbar);
            this.Controls.Add(this.btnClearSarbar);
            this.Controls.Add(this.btnAddSarbar);
            this.Controls.Add(this.txtSarbar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbProcNameKargah);
            this.Controls.Add(this.txtCodeKargah);
            this.Controls.Add(this.label56);
            this.Controls.Add(this.label55);
            this.Name = "FrmCostSarbar";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "ثبت سربار";
            this.Load += new System.EventHandler(this.FrmCostSarbar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbProcNameKargah)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClearSarbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddSarbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSarbar.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSarbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList cmbProcNameKargah;
        private System.Windows.Forms.TextBox txtCodeKargah;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSarbar;
        private Telerik.WinControls.UI.RadButton btnClearSarbar;
        private Telerik.WinControls.UI.RadButton btnAddSarbar;
        private Telerik.WinControls.UI.RadGridView grdSarbar;
    }
}

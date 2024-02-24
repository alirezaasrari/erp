namespace ET
{
    partial class FrmCostDastmozd
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
            this.txtDastmozd = new System.Windows.Forms.TextBox();
            this.btnClearDastmozd = new Telerik.WinControls.UI.RadButton();
            this.btnAddDastmozd = new Telerik.WinControls.UI.RadButton();
            this.grdDastmozd = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProcNameKargah)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClearDastmozd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddDastmozd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDastmozd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDastmozd.MasterTemplate)).BeginInit();
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
            this.label1.Location = new System.Drawing.Point(901, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 352;
            this.label1.Text = "نرخ دستمزد:";
            // 
            // txtDastmozd
            // 
            this.txtDastmozd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDastmozd.Location = new System.Drawing.Point(713, 86);
            this.txtDastmozd.MaxLength = 15;
            this.txtDastmozd.Name = "txtDastmozd";
            this.txtDastmozd.Size = new System.Drawing.Size(137, 20);
            this.txtDastmozd.TabIndex = 353;
            // 
            // btnClearDastmozd
            // 
            this.btnClearDastmozd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearDastmozd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnClearDastmozd.Image = global::ET.Properties.Resources.Refresh;
            this.btnClearDastmozd.Location = new System.Drawing.Point(404, 81);
            this.btnClearDastmozd.Name = "btnClearDastmozd";
            this.btnClearDastmozd.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnClearDastmozd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClearDastmozd.Size = new System.Drawing.Size(31, 25);
            this.btnClearDastmozd.TabIndex = 355;
            this.btnClearDastmozd.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClearDastmozd.Click += new System.EventHandler(this.btnClearDastmozd_Click);
            // 
            // btnAddDastmozd
            // 
            this.btnAddDastmozd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddDastmozd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAddDastmozd.Image = global::ET.Properties.Resources.ADD;
            this.btnAddDastmozd.Location = new System.Drawing.Point(455, 81);
            this.btnAddDastmozd.Name = "btnAddDastmozd";
            this.btnAddDastmozd.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnAddDastmozd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAddDastmozd.Size = new System.Drawing.Size(31, 25);
            this.btnAddDastmozd.TabIndex = 354;
            this.btnAddDastmozd.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddDastmozd.Click += new System.EventHandler(this.btnAddDastmozd_Click);
            // 
            // grdDastmozd
            // 
            this.grdDastmozd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDastmozd.AutoScroll = true;
            this.grdDastmozd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grdDastmozd.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdDastmozd.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grdDastmozd.ForeColor = System.Drawing.Color.Black;
            this.grdDastmozd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdDastmozd.Location = new System.Drawing.Point(12, 112);
            // 
            // 
            // 
            this.grdDastmozd.MasterTemplate.AllowAddNewRow = false;
            this.grdDastmozd.MasterTemplate.AllowColumnReorder = false;
            this.grdDastmozd.MasterTemplate.AutoGenerateColumns = false;
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
            gridViewTextBoxColumn3.FieldName = "Dastmozd";
            gridViewTextBoxColumn3.HeaderText = "دستمزد برحسب ریال و ثانیه";
            gridViewTextBoxColumn3.Name = "Dastmozd";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn3.Width = 170;
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
            this.grdDastmozd.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.grdDastmozd.MasterTemplate.EnableAlternatingRowColor = true;
            this.grdDastmozd.MasterTemplate.EnableFiltering = true;
            this.grdDastmozd.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.grdDastmozd.MasterTemplate.ShowGroupedColumns = true;
            this.grdDastmozd.MasterTemplate.ShowRowHeaderColumn = false;
            this.grdDastmozd.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdDastmozd.Name = "grdDastmozd";
            this.grdDastmozd.ReadOnly = true;
            this.grdDastmozd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdDastmozd.Size = new System.Drawing.Size(988, 408);
            this.grdDastmozd.TabIndex = 356;
            this.grdDastmozd.Text = "radGridView1";
            // 
            // FrmCostDastmozd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 532);
            this.Controls.Add(this.grdDastmozd);
            this.Controls.Add(this.btnClearDastmozd);
            this.Controls.Add(this.btnAddDastmozd);
            this.Controls.Add(this.txtDastmozd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbProcNameKargah);
            this.Controls.Add(this.txtCodeKargah);
            this.Controls.Add(this.label56);
            this.Controls.Add(this.label55);
            this.Name = "FrmCostDastmozd";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "ثبت دستمزد";
            this.Load += new System.EventHandler(this.FrmCostDastmozd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbProcNameKargah)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClearDastmozd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddDastmozd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDastmozd.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDastmozd)).EndInit();
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
        private System.Windows.Forms.TextBox txtDastmozd;
        private Telerik.WinControls.UI.RadButton btnClearDastmozd;
        private Telerik.WinControls.UI.RadButton btnAddDastmozd;
        private Telerik.WinControls.UI.RadGridView grdDastmozd;
    }
}

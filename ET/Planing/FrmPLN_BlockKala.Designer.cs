namespace ET
{
    partial class FrmPLN_BlockKala
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
            this.label1 = new System.Windows.Forms.Label();
            this.grdKala = new Telerik.WinControls.UI.RadGridView();
            this.txtC_Kala = new System.Windows.Forms.TextBox();
            this.lblN_Kala = new System.Windows.Forms.Label();
            this.lblN_Anbar = new System.Windows.Forms.Label();
            this.lblC_Anbar = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBlock = new Telerik.WinControls.UI.RadButton();
            this.txtBlock = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdKala)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKala.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(820, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "کد کالا";
            // 
            // grdKala
            // 
            this.grdKala.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdKala.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grdKala.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdKala.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.grdKala.ForeColor = System.Drawing.Color.Black;
            this.grdKala.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdKala.Location = new System.Drawing.Point(12, 138);
            // 
            // grdKala
            // 
            this.grdKala.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "C_Kala";
            gridViewTextBoxColumn1.HeaderText = "کد کالا";
            gridViewTextBoxColumn1.Name = "C_Kala";
            gridViewTextBoxColumn1.Width = 159;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "N_Kala";
            gridViewTextBoxColumn2.HeaderText = "نام کالا";
            gridViewTextBoxColumn2.Name = "N_Kala";
            gridViewTextBoxColumn2.Width = 251;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "C_Anbar";
            gridViewTextBoxColumn3.HeaderText = "کد انبار";
            gridViewTextBoxColumn3.Name = "C_Anbar";
            gridViewTextBoxColumn3.Width = 46;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "TimeBlock";
            gridViewTextBoxColumn4.HeaderText = "تاریخ تعلیق";
            gridViewTextBoxColumn4.Name = "TimeBlock";
            gridViewTextBoxColumn4.Width = 84;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "UserBlock";
            gridViewTextBoxColumn5.HeaderText = "کاربر";
            gridViewTextBoxColumn5.Name = "UserBlock";
            gridViewTextBoxColumn5.Width = 74;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "CommentBlock";
            gridViewTextBoxColumn6.HeaderText = "توضیحات تعلیق";
            gridViewTextBoxColumn6.Name = "CommentBlock";
            gridViewTextBoxColumn6.Width = 201;
            this.grdKala.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.grdKala.MasterTemplate.EnableFiltering = true;
            this.grdKala.Name = "grdKala";
            this.grdKala.ReadOnly = true;
            this.grdKala.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdKala.Size = new System.Drawing.Size(850, 301);
            this.grdKala.TabIndex = 1;
            this.grdKala.Text = "radGridView1";
            this.grdKala.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdKala_CellDoubleClick);
            // 
            // txtC_Kala
            // 
            this.txtC_Kala.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtC_Kala.Location = new System.Drawing.Point(622, 16);
            this.txtC_Kala.Name = "txtC_Kala";
            this.txtC_Kala.Size = new System.Drawing.Size(192, 20);
            this.txtC_Kala.TabIndex = 2;
            this.txtC_Kala.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtC_Kala_KeyDown);
            // 
            // lblN_Kala
            // 
            this.lblN_Kala.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblN_Kala.AutoSize = true;
            this.lblN_Kala.Location = new System.Drawing.Point(583, 51);
            this.lblN_Kala.Name = "lblN_Kala";
            this.lblN_Kala.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblN_Kala.Size = new System.Drawing.Size(15, 16);
            this.lblN_Kala.TabIndex = 3;
            this.lblN_Kala.Text = "_";
            // 
            // lblN_Anbar
            // 
            this.lblN_Anbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblN_Anbar.AutoSize = true;
            this.lblN_Anbar.Location = new System.Drawing.Point(448, 51);
            this.lblN_Anbar.Name = "lblN_Anbar";
            this.lblN_Anbar.Size = new System.Drawing.Size(15, 16);
            this.lblN_Anbar.TabIndex = 4;
            this.lblN_Anbar.Text = "_";
            // 
            // lblC_Anbar
            // 
            this.lblC_Anbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblC_Anbar.AutoSize = true;
            this.lblC_Anbar.Location = new System.Drawing.Point(448, 20);
            this.lblC_Anbar.Name = "lblC_Anbar";
            this.lblC_Anbar.Size = new System.Drawing.Size(15, 16);
            this.lblC_Anbar.TabIndex = 5;
            this.lblC_Anbar.Text = "_";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(487, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "انبار : ";
            // 
            // btnBlock
            // 
            this.btnBlock.Location = new System.Drawing.Point(48, 29);
            this.btnBlock.Name = "btnBlock";
            this.btnBlock.Size = new System.Drawing.Size(79, 24);
            this.btnBlock.TabIndex = 7;
            this.btnBlock.Text = "تعلیق کالا";
            this.btnBlock.Click += new System.EventHandler(this.btnBlock_Click);
            // 
            // txtBlock
            // 
            this.txtBlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBlock.Location = new System.Drawing.Point(262, 92);
            this.txtBlock.Name = "txtBlock";
            this.txtBlock.Size = new System.Drawing.Size(528, 20);
            this.txtBlock.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(796, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "علت تعلیق";
            // 
            // FrmPLN_BlockKala
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 451);
            this.Controls.Add(this.txtBlock);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBlock);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblC_Anbar);
            this.Controls.Add(this.lblN_Anbar);
            this.Controls.Add(this.lblN_Kala);
            this.Controls.Add(this.txtC_Kala);
            this.Controls.Add(this.grdKala);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmPLN_BlockKala";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "تعلیق کالاها";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.FrmPLN_BlockKala_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdKala.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKala)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBlock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadGridView grdKala;
        private System.Windows.Forms.TextBox txtC_Kala;
        private System.Windows.Forms.Label lblN_Kala;
        private System.Windows.Forms.Label lblN_Anbar;
        private System.Windows.Forms.Label lblC_Anbar;
        private System.Windows.Forms.Label label4;
        private Telerik.WinControls.UI.RadButton btnBlock;
        private System.Windows.Forms.TextBox txtBlock;
        private System.Windows.Forms.Label label2;
    }
}

namespace ET
{
    partial class Frm_Tafsili
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
            this.txtCTafsili = new System.Windows.Forms.TextBox();
            this.txtNTafsili = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgw = new System.Windows.Forms.DataGridView();
            this.Ctafsili = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ntafsili = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCTafsili
            // 
            this.txtCTafsili.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtCTafsili.Location = new System.Drawing.Point(197, 26);
            this.txtCTafsili.Name = "txtCTafsili";
            this.txtCTafsili.Size = new System.Drawing.Size(100, 21);
            this.txtCTafsili.TabIndex = 0;
            this.txtCTafsili.TextChanged += new System.EventHandler(this.txtCTafsili_TextChanged);
            // 
            // txtNTafsili
            // 
            this.txtNTafsili.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtNTafsili.Location = new System.Drawing.Point(51, 57);
            this.txtNTafsili.Name = "txtNTafsili";
            this.txtNTafsili.Size = new System.Drawing.Size(246, 21);
            this.txtNTafsili.TabIndex = 1;
            this.txtNTafsili.TextChanged += new System.EventHandler(this.txtNTafsili_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(308, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "کد تفصیلی";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(308, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "نام تفصیلی";
            // 
            // dgw
            // 
            this.dgw.AllowUserToAddRows = false;
            this.dgw.AllowUserToDeleteRows = false;
            this.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ctafsili,
            this.Ntafsili});
            this.dgw.Location = new System.Drawing.Point(12, 100);
            this.dgw.Name = "dgw";
            this.dgw.ReadOnly = true;
            this.dgw.Size = new System.Drawing.Size(374, 255);
            this.dgw.TabIndex = 4;
            this.dgw.TabStop = false;
            this.dgw.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgw_CellDoubleClick);
            // 
            // Ctafsili
            // 
            this.Ctafsili.DataPropertyName = "Ctafsili";
            this.Ctafsili.HeaderText = "کد تفصیلی";
            this.Ctafsili.Name = "Ctafsili";
            this.Ctafsili.ReadOnly = true;
            this.Ctafsili.Width = 60;
            // 
            // Ntafsili
            // 
            this.Ntafsili.DataPropertyName = "Ntafsili";
            this.Ntafsili.HeaderText = "نام تفصیلی";
            this.Ntafsili.Name = "Ntafsili";
            this.Ntafsili.ReadOnly = true;
            this.Ntafsili.Width = 260;
            // 
            // Frm_Tafsili
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(398, 367);
            this.Controls.Add(this.dgw);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNTafsili);
            this.Controls.Add(this.txtCTafsili);
            this.Name = "Frm_Tafsili";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جستجوی تفصیلی";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_Tafsili_FormClosed);
            this.Load += new System.EventHandler(this.Frm_Tafsili_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCTafsili;
        private System.Windows.Forms.TextBox txtNTafsili;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgw;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ctafsili;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ntafsili;
    }
}
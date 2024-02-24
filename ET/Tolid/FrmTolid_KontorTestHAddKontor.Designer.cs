namespace ET
{
    partial class FrmTolid_KontorTestHAddKontor
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
            this.components = new System.ComponentModel.Container();
            this.label19 = new System.Windows.Forms.Label();
            this.txtKontor = new System.Windows.Forms.TextBox();
            this.lst = new System.Windows.Forms.ListBox();
            this.txtRadif = new System.Windows.Forms.TextBox();
            this.chkRadif = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(244, 9);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 13);
            this.label19.TabIndex = 384;
            this.label19.Text = "شماره کنتور:";
            // 
            // txtKontor
            // 
            this.txtKontor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKontor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKontor.Location = new System.Drawing.Point(125, 6);
            this.txtKontor.Name = "txtKontor";
            this.txtKontor.Size = new System.Drawing.Size(113, 21);
            this.txtKontor.TabIndex = 385;
            this.txtKontor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKontor_KeyDown);
            // 
            // lst
            // 
            this.lst.FormattingEnabled = true;
            this.lst.Location = new System.Drawing.Point(125, 33);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(113, 147);
            this.lst.TabIndex = 386;
            // 
            // txtRadif
            // 
            this.txtRadif.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRadif.Enabled = false;
            this.txtRadif.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRadif.Location = new System.Drawing.Point(12, 31);
            this.txtRadif.Name = "txtRadif";
            this.txtRadif.Size = new System.Drawing.Size(51, 21);
            this.txtRadif.TabIndex = 388;
            // 
            // chkRadif
            // 
            this.chkRadif.AutoSize = true;
            this.chkRadif.Location = new System.Drawing.Point(7, 8);
            this.chkRadif.Name = "chkRadif";
            this.chkRadif.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkRadif.Size = new System.Drawing.Size(107, 17);
            this.chkRadif.TabIndex = 389;
            this.chkRadif.Text = "شماره ردیف جدید";
            this.toolTip1.SetToolTip(this.chkRadif, "در صورت درج در وسط لیست از این بخش استفاده شود");
            this.chkRadif.UseVisualStyleBackColor = true;
            this.chkRadif.CheckedChanged += new System.EventHandler(this.chkRadif_CheckedChanged);
            // 
            // FrmTolid_KontorTestHAddKontor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 193);
            this.Controls.Add(this.chkRadif);
            this.Controls.Add(this.txtRadif);
            this.Controls.Add(this.lst);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtKontor);
            this.Name = "FrmTolid_KontorTestHAddKontor";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label19;
        public System.Windows.Forms.TextBox txtKontor;
        private System.Windows.Forms.ListBox lst;
        public System.Windows.Forms.TextBox txtRadif;
        private System.Windows.Forms.CheckBox chkRadif;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

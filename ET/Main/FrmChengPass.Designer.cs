namespace ET
{
    partial class FrmChengPass
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassOld = new Telerik.WinControls.UI.RadTextBox();
            this.txtPassNew = new Telerik.WinControls.UI.RadTextBox();
            this.txtPassNewS = new Telerik.WinControls.UI.RadTextBox();
            this.btnEditPass = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassOld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassNewS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "رمز عبور فعلی";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "رمز عبور جدید";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(122, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "تکرار رمز عبور";
            // 
            // txtPassOld
            // 
            this.txtPassOld.Location = new System.Drawing.Point(12, 12);
            this.txtPassOld.MaxLength = 12;
            this.txtPassOld.Name = "txtPassOld";
            this.txtPassOld.PasswordChar = '●';
            this.txtPassOld.Size = new System.Drawing.Size(100, 20);
            this.txtPassOld.TabIndex = 0;
            this.txtPassOld.UseSystemPasswordChar = true;
            this.txtPassOld.Enter += new System.EventHandler(this.txtPassOld_Enter);
            this.txtPassOld.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassOld_KeyDown);
            this.txtPassOld.Leave += new System.EventHandler(this.txtPassOld_Leave);
            // 
            // txtPassNew
            // 
            this.txtPassNew.Location = new System.Drawing.Point(12, 38);
            this.txtPassNew.MaxLength = 12;
            this.txtPassNew.Name = "txtPassNew";
            this.txtPassNew.PasswordChar = '●';
            this.txtPassNew.Size = new System.Drawing.Size(100, 20);
            this.txtPassNew.TabIndex = 1;
            this.txtPassNew.UseSystemPasswordChar = true;
            this.txtPassNew.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassNew_KeyDown);
            this.txtPassNew.Leave += new System.EventHandler(this.txtPassNew_Leave);
            // 
            // txtPassNewS
            // 
            this.txtPassNewS.Location = new System.Drawing.Point(12, 64);
            this.txtPassNewS.MaxLength = 12;
            this.txtPassNewS.Name = "txtPassNewS";
            this.txtPassNewS.PasswordChar = '●';
            this.txtPassNewS.Size = new System.Drawing.Size(100, 20);
            this.txtPassNewS.TabIndex = 2;
            this.txtPassNewS.UseSystemPasswordChar = true;
            this.txtPassNewS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassNewS_KeyDown);
            this.txtPassNewS.Leave += new System.EventHandler(this.txtPassNewS_Leave);
            // 
            // btnEditPass
            // 
            this.btnEditPass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnEditPass.Image = global::ET.Properties.Resources.Edit;
            this.btnEditPass.Location = new System.Drawing.Point(12, 90);
            this.btnEditPass.Name = "btnEditPass";
            this.btnEditPass.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnEditPass.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnEditPass.Size = new System.Drawing.Size(70, 25);
            this.btnEditPass.TabIndex = 3;
            this.btnEditPass.Text = "ویرایش";
            this.btnEditPass.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditPass.Click += new System.EventHandler(this.btnEditPass_Click);
            // 
            // FrmChengPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 118);
            this.Controls.Add(this.btnEditPass);
            this.Controls.Add(this.txtPassNewS);
            this.Controls.Add(this.txtPassNew);
            this.Controls.Add(this.txtPassOld);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChengPass";
            this.RightToLeftLayout = true;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تغییر رمز عبور";
            ((System.ComponentModel.ISupportInitialize)(this.txtPassOld)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassNewS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadTextBox txtPassOld;
        private Telerik.WinControls.UI.RadTextBox txtPassNew;
        private Telerik.WinControls.UI.RadTextBox txtPassNewS;
        private Telerik.WinControls.UI.RadButton btnEditPass;
    }
}

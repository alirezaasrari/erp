namespace ET
{
    partial class Frm_Menu
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btn_Ras = new System.Windows.Forms.Button();
            this.BtnTotal = new System.Windows.Forms.Button();
            this.btn_Reportforosh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(72, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "بروز رسانی اطلاعات";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(72, 60);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(188, 31);
            this.button2.TabIndex = 1;
            this.button2.Text = "سنی کلی";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(72, 96);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(188, 31);
            this.button3.TabIndex = 2;
            this.button3.Text = "سنی ماهانه";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(184, 180);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(188, 31);
            this.button4.TabIndex = 3;
            this.button4.Text = "راس فاکتور";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(156, 206);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(188, 31);
            this.button5.TabIndex = 4;
            this.button5.Text = "راس چک";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btn_Ras
            // 
            this.btn_Ras.Location = new System.Drawing.Point(72, 169);
            this.btn_Ras.Name = "btn_Ras";
            this.btn_Ras.Size = new System.Drawing.Size(188, 31);
            this.btn_Ras.TabIndex = 5;
            this.btn_Ras.Text = "گزارش راس گیری";
            this.btn_Ras.UseVisualStyleBackColor = true;
            this.btn_Ras.Click += new System.EventHandler(this.btn_Ras_Click);
            // 
            // BtnTotal
            // 
            this.BtnTotal.Location = new System.Drawing.Point(72, 205);
            this.BtnTotal.Name = "BtnTotal";
            this.BtnTotal.Size = new System.Drawing.Size(188, 30);
            this.BtnTotal.TabIndex = 6;
            this.BtnTotal.Text = "گزارش سنی جامع";
            this.BtnTotal.UseVisualStyleBackColor = true;
            this.BtnTotal.Click += new System.EventHandler(this.BtnTotal_Click);
            // 
            // btn_Reportforosh
            // 
            this.btn_Reportforosh.Location = new System.Drawing.Point(72, 133);
            this.btn_Reportforosh.Name = "btn_Reportforosh";
            this.btn_Reportforosh.Size = new System.Drawing.Size(188, 31);
            this.btn_Reportforosh.TabIndex = 7;
            this.btn_Reportforosh.Text = "گزارش سنی فروش";
            this.btn_Reportforosh.UseVisualStyleBackColor = true;
            this.btn_Reportforosh.Click += new System.EventHandler(this.btn_Reportforosh_Click);
            // 
            // Frm_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(336, 263);
            this.Controls.Add(this.btn_Reportforosh);
            this.Controls.Add(this.BtnTotal);
            this.Controls.Add(this.btn_Ras);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_Menu_FormClosed);
            this.Load += new System.EventHandler(this.Frm_Menu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btn_Ras;
        private System.Windows.Forms.Button BtnTotal;
        private System.Windows.Forms.Button btn_Reportforosh;
    }
}
namespace ET
{
    partial class FrmDore
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
            this.dgw = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.N_DB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DB_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DB_Paya = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DbYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            this.SuspendLayout();
            // 
            // dgw
            // 
            this.dgw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgw.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.N_DB,
            this.DB_Description,
            this.DB_Paya,
            this.DbYear});
            this.dgw.Location = new System.Drawing.Point(12, 12);
            this.dgw.Name = "dgw";
            this.dgw.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgw.Size = new System.Drawing.Size(657, 404);
            this.dgw.TabIndex = 0;
            this.dgw.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgw_CellContentDoubleClick);
            this.dgw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgw_KeyDown);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "کد دوره";
            this.ID.Name = "ID";
            // 
            // N_DB
            // 
            this.N_DB.DataPropertyName = "N_DB";
            this.N_DB.HeaderText = "نام دوره";
            this.N_DB.Name = "N_DB";
            // 
            // DB_Description
            // 
            this.DB_Description.DataPropertyName = "DB_Description";
            this.DB_Description.HeaderText = "شرح دوره";
            this.DB_Description.Name = "DB_Description";
            // 
            // DB_Paya
            // 
            this.DB_Paya.DataPropertyName = "DB_Paya";
            this.DB_Paya.HeaderText = "دوره پایا";
            this.DB_Paya.Name = "DB_Paya";
            // 
            // DbYear
            // 
            this.DbYear.DataPropertyName = "DbYear";
            this.DbYear.HeaderText = "سال";
            this.DbYear.Name = "DbYear";
            // 
            // FrmDore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(222)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(681, 428);
            this.Controls.Add(this.dgw);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmDore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "انتخاب دوره";
            this.Load += new System.EventHandler(this.FrmDore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgw;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn N_DB;
        private System.Windows.Forms.DataGridViewTextBoxColumn DB_Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn DB_Paya;
        private System.Windows.Forms.DataGridViewTextBoxColumn DbYear;
    }
}
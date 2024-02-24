namespace ET
{
    partial class FrnUM_Report
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.grdControl = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grdControl
            // 
            this.grdControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grdControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdControl.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grdControl.ForeColor = System.Drawing.Color.Black;
            this.grdControl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdControl.Location = new System.Drawing.Point(15, 12);
            // 
            // 
            // 
            this.grdControl.MasterTemplate.AllowAddNewRow = false;
            this.grdControl.MasterTemplate.AllowColumnReorder = false;
            this.grdControl.MasterTemplate.EnableAlternatingRowColor = true;
            this.grdControl.MasterTemplate.EnableFiltering = true;
            this.grdControl.MasterTemplate.ShowGroupedColumns = true;
            this.grdControl.MasterTemplate.ShowRowHeaderColumn = false;
            this.grdControl.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grdControl.Name = "grdControl";
            this.grdControl.ReadOnly = true;
            this.grdControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdControl.Size = new System.Drawing.Size(201, 235);
            this.grdControl.TabIndex = 5;
            this.grdControl.Text = "radGridView1";
            // 
            // FrnUM_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 270);
            this.Controls.Add(this.grdControl);
            this.Name = "FrnUM_Report";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "گزارش مدیریت کاربران";
            this.Load += new System.EventHandler(this.FrnUM_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grdControl;
    }
}

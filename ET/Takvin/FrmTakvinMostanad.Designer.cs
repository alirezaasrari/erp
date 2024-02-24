namespace ET
{
    partial class FrmTakvinMostanad
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
            Telerik.WinControls.UI.RadPrintWatermark radPrintWatermark2 = new Telerik.WinControls.UI.RadPrintWatermark();
            this.radPdfViewerNavigatorMos = new Telerik.WinControls.UI.RadPdfViewerNavigator();
            this.radPdfVMostanad = new Telerik.WinControls.UI.RadPdfViewer();
            this.picMostanad = new System.Windows.Forms.PictureBox();
            this.contextMenuStripMos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemCloseForm = new System.Windows.Forms.ToolStripMenuItem();
            this.AllowPrintMostanadat = new System.Windows.Forms.Label();
            this.PrintDocMostanad = new Telerik.WinControls.UI.RadPrintDocument();
            this.printDlgMostanad = new System.Windows.Forms.PrintDialog();
            this.btnPrintMostanad = new Telerik.WinControls.UI.RadButton();
            this.radThemeManager1 = new Telerik.WinControls.RadThemeManager();
            ((System.ComponentModel.ISupportInitialize)(this.radPdfViewerNavigatorMos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPdfVMostanad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMostanad)).BeginInit();
            this.contextMenuStripMos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintMostanad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPdfViewerNavigatorMos
            // 
            this.radPdfViewerNavigatorMos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.radPdfViewerNavigatorMos.AssociatedViewer = this.radPdfVMostanad;
            this.radPdfViewerNavigatorMos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radPdfViewerNavigatorMos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radPdfViewerNavigatorMos.Location = new System.Drawing.Point(12, 5);
            this.radPdfViewerNavigatorMos.Name = "radPdfViewerNavigatorMos";
            this.radPdfViewerNavigatorMos.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radPdfViewerNavigatorMos.Size = new System.Drawing.Size(721, 38);
            this.radPdfViewerNavigatorMos.TabIndex = 0;
            this.radPdfViewerNavigatorMos.Text = "radPdfViewerNavigator1";
            // 
            // radPdfVMostanad
            // 
            this.radPdfVMostanad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radPdfVMostanad.Location = new System.Drawing.Point(12, 43);
            this.radPdfVMostanad.Name = "radPdfVMostanad";
            this.radPdfVMostanad.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radPdfVMostanad.Size = new System.Drawing.Size(768, 509);
            this.radPdfVMostanad.TabIndex = 1;
            this.radPdfVMostanad.Text = "radPdfViewer1";
            this.radPdfVMostanad.ThumbnailsScaleFactor = 0.15F;
            this.radPdfVMostanad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.radPdfVMostanad_KeyDown);
            this.radPdfVMostanad.Leave += new System.EventHandler(this.radPdfVMostanad_Leave);
            this.radPdfVMostanad.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radPdfVMostanad_MouseDown);
            this.radPdfVMostanad.MouseLeave += new System.EventHandler(this.radPdfVMostanad_MouseLeave);
            // 
            // picMostanad
            // 
            this.picMostanad.Location = new System.Drawing.Point(10, 5);
            this.picMostanad.Name = "picMostanad";
            this.picMostanad.Size = new System.Drawing.Size(27, 25);
            this.picMostanad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMostanad.TabIndex = 0;
            this.picMostanad.TabStop = false;
            // 
            // contextMenuStripMos
            // 
            this.contextMenuStripMos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemCloseForm});
            this.contextMenuStripMos.Name = "contextMenuStripMos";
            this.contextMenuStripMos.Size = new System.Drawing.Size(121, 26);
            // 
            // ToolStripMenuItemCloseForm
            // 
            this.ToolStripMenuItemCloseForm.Name = "ToolStripMenuItemCloseForm";
            this.ToolStripMenuItemCloseForm.Size = new System.Drawing.Size(120, 22);
            this.ToolStripMenuItemCloseForm.Text = "بستن فرم";
            this.ToolStripMenuItemCloseForm.Click += new System.EventHandler(this.ToolStripMenuItemCloseForm_Click);
            // 
            // AllowPrintMostanadat
            // 
            this.AllowPrintMostanadat.AutoSize = true;
            this.AllowPrintMostanadat.Location = new System.Drawing.Point(0, 0);
            this.AllowPrintMostanadat.Name = "AllowPrintMostanadat";
            this.AllowPrintMostanadat.Size = new System.Drawing.Size(13, 13);
            this.AllowPrintMostanadat.TabIndex = 2;
            this.AllowPrintMostanadat.Text = "..";
            // 
            // PrintDocMostanad
            // 
            this.PrintDocMostanad.AutoPortraitLandscape = true;
            this.PrintDocMostanad.FooterFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PrintDocMostanad.FooterHeight = 0;
            this.PrintDocMostanad.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PrintDocMostanad.HeaderHeight = 0;
            this.PrintDocMostanad.LeftFooter = "0";
            this.PrintDocMostanad.LeftHeader = "0";
            this.PrintDocMostanad.OriginAtMargins = true;
            this.PrintDocMostanad.RightFooter = "0";
            this.PrintDocMostanad.RightHeader = "0";
            this.PrintDocMostanad.Watermark = radPrintWatermark2;
            // 
            // printDlgMostanad
            // 
            this.printDlgMostanad.AllowCurrentPage = true;
            this.printDlgMostanad.AllowSelection = true;
            this.printDlgMostanad.AllowSomePages = true;
            this.printDlgMostanad.Document = this.PrintDocMostanad;
            this.printDlgMostanad.PrintToFile = true;
            this.printDlgMostanad.UseEXDialog = true;
            // 
            // btnPrintMostanad
            // 
            this.btnPrintMostanad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintMostanad.Enabled = false;
            this.btnPrintMostanad.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnPrintMostanad.Image = global::ET.Properties.Resources.print;
            this.btnPrintMostanad.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPrintMostanad.Location = new System.Drawing.Point(652, 5);
            this.btnPrintMostanad.Name = "btnPrintMostanad";
            this.btnPrintMostanad.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnPrintMostanad.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPrintMostanad.Size = new System.Drawing.Size(128, 38);
            this.btnPrintMostanad.TabIndex = 158;
            this.btnPrintMostanad.Text = "چاپ";
            this.btnPrintMostanad.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintMostanad.Click += new System.EventHandler(this.btnPrintMostanad_Click);
            // 
            // FrmTakvinMostanad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 570);
            this.Controls.Add(this.btnPrintMostanad);
            this.Controls.Add(this.AllowPrintMostanadat);
            this.Controls.Add(this.radPdfViewerNavigatorMos);
            this.Controls.Add(this.radPdfVMostanad);
            this.Controls.Add(this.picMostanad);
            this.MaximizeBox = false;
            this.Name = "FrmTakvinMostanad";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ShowItemToolTips = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مشاهده مستند";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTakvinMostanad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmTakvinMostanad_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmTakvinMostanad_KeyPress);
            this.Leave += new System.EventHandler(this.FrmTakvinMostanad_Leave);
            this.MouseLeave += new System.EventHandler(this.FrmTakvinMostanad_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.radPdfViewerNavigatorMos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPdfVMostanad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMostanad)).EndInit();
            this.contextMenuStripMos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintMostanad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picMostanad;
        private Telerik.WinControls.UI.RadPdfViewer radPdfVMostanad;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMos;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCloseForm;
        private System.Windows.Forms.Label AllowPrintMostanadat;
        //private Microsoft.VisualBasic.PowerPacks.Printing.PrintForm PrintFormMostanad;
        public System.Windows.Forms.PrintDialog printDlgMostanad;
        //public Microsoft.VisualBasic.PowerPacks.Printing.PrintForm PrintFormMostanad;
        public Telerik.WinControls.UI.RadPrintDocument PrintDocMostanad;
        private Telerik.WinControls.UI.RadButton btnPrintMostanad;
        private Telerik.WinControls.RadThemeManager radThemeManager1;
        private Telerik.WinControls.UI.RadPdfViewerNavigator radPdfViewerNavigatorMos;
    }
}

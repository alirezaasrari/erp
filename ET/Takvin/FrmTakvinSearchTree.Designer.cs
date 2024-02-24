namespace ET
{
    partial class FrmTakvinSearchTree
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.grdSearchTree = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchTree.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.grdSearchTree);
            this.radGroupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox1.HeaderText = "مشخصات قطعه";
            this.radGroupBox1.Location = new System.Drawing.Point(2, 17);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1007, 476);
            this.radGroupBox1.TabIndex = 149;
            this.radGroupBox1.Text = "مشخصات قطعه";
            // 
            // grdSearchTree
            // 
            this.grdSearchTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSearchTree.AutoScroll = true;
            this.grdSearchTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grdSearchTree.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdSearchTree.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grdSearchTree.ForeColor = System.Drawing.Color.Black;
            this.grdSearchTree.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdSearchTree.Location = new System.Drawing.Point(14, 21);
            // 
            // 
            // 
            this.grdSearchTree.MasterTemplate.AllowAddNewRow = false;
            this.grdSearchTree.MasterTemplate.AllowColumnReorder = false;
            this.grdSearchTree.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "RootFaniNo";
            gridViewTextBoxColumn1.HeaderText = "شماره فنی درخت";
            gridViewTextBoxColumn1.Name = "RootFaniNo";
            gridViewTextBoxColumn1.Width = 115;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "RootGhetehCode";
            gridViewTextBoxColumn2.HeaderText = "کد درخت";
            gridViewTextBoxColumn2.Name = "RootGhetehCode";
            gridViewTextBoxColumn2.Width = 86;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "RootGheteName";
            gridViewTextBoxColumn3.HeaderText = "نام درخت";
            gridViewTextBoxColumn3.Name = "RootGheteName";
            gridViewTextBoxColumn3.Width = 138;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "RootGhetehAnbar";
            gridViewTextBoxColumn4.HeaderText = "انبار درخت";
            gridViewTextBoxColumn4.Name = "RootGhetehAnbar";
            gridViewTextBoxColumn4.Width = 65;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "ParentFaniNo";
            gridViewTextBoxColumn5.HeaderText = "شماره فنی پدر";
            gridViewTextBoxColumn5.Name = "ParentFaniNo";
            gridViewTextBoxColumn5.Width = 93;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "ParentGhetehCode";
            gridViewTextBoxColumn6.HeaderText = "کد پدر";
            gridViewTextBoxColumn6.Name = "ParentGhetehCode";
            gridViewTextBoxColumn6.Width = 104;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "ParentGheteName";
            gridViewTextBoxColumn7.HeaderText = "نام پدر";
            gridViewTextBoxColumn7.Name = "ParentGheteName";
            gridViewTextBoxColumn7.Width = 139;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "ParentGhetehAnbar";
            gridViewTextBoxColumn8.HeaderText = "انبار پدر";
            gridViewTextBoxColumn8.Name = "ParentGhetehAnbar";
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "FaniNo";
            gridViewTextBoxColumn9.HeaderText = "شماره فنی قطعه";
            gridViewTextBoxColumn9.Name = "FaniNo";
            gridViewTextBoxColumn9.Width = 112;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "GhetehCode";
            gridViewTextBoxColumn10.HeaderText = "کد قطعه";
            gridViewTextBoxColumn10.Name = "GhetehCode";
            gridViewTextBoxColumn10.Width = 115;
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.FieldName = "GheteName";
            gridViewTextBoxColumn11.HeaderText = "نام قطعه";
            gridViewTextBoxColumn11.Name = "GheteName";
            gridViewTextBoxColumn11.Width = 304;
            gridViewTextBoxColumn12.EnableExpressionEditor = false;
            gridViewTextBoxColumn12.FieldName = "GhetehAnbar";
            gridViewTextBoxColumn12.HeaderText = "کد انبار";
            gridViewTextBoxColumn12.Name = "GhetehAnbar";
            gridViewTextBoxColumn12.Width = 51;
            gridViewTextBoxColumn13.EnableExpressionEditor = false;
            gridViewTextBoxColumn13.FieldName = "Nodelevel";
            gridViewTextBoxColumn13.HeaderText = "سطح";
            gridViewTextBoxColumn13.Name = "Nodelevel";
            gridViewTextBoxColumn14.EnableExpressionEditor = false;
            gridViewTextBoxColumn14.FieldName = "idRootTree";
            gridViewTextBoxColumn14.HeaderText = "شناسه ریشه";
            gridViewTextBoxColumn14.IsVisible = false;
            gridViewTextBoxColumn14.Name = "idRootTree";
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.FieldName = "TaeedDesign";
            gridViewCheckBoxColumn1.HeaderText = "تایید مهندسی";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "TaeedDesign";
            gridViewCheckBoxColumn1.Width = 110;
            this.grdSearchTree.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewCheckBoxColumn1});
            this.grdSearchTree.MasterTemplate.EnableAlternatingRowColor = true;
            this.grdSearchTree.MasterTemplate.EnableFiltering = true;
            this.grdSearchTree.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.grdSearchTree.MasterTemplate.ShowGroupedColumns = true;
            this.grdSearchTree.MasterTemplate.ShowRowHeaderColumn = false;
            this.grdSearchTree.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdSearchTree.Name = "grdSearchTree";
            this.grdSearchTree.ReadOnly = true;
            this.grdSearchTree.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdSearchTree.Size = new System.Drawing.Size(988, 450);
            this.grdSearchTree.TabIndex = 3;
            this.grdSearchTree.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdSearchTree_CellDoubleClick);
            // 
            // FrmTakvinSearchTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 496);
            this.Controls.Add(this.radGroupBox1);
            this.KeyPreview = true;
            this.Name = "FrmTakvinSearchTree";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "جستجوی درخت";
            this.Load += new System.EventHandler(this.FrmTakvinSearchTree_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmTakvinSearchTree_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchTree.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView grdSearchTree;
    }
}

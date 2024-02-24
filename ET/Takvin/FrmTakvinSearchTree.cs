using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace ET
{
    public partial class FrmTakvinSearchTree : Telerik.WinControls.UI.RadForm
    {
        public FrmTakvinSearchTree()
        {
            InitializeComponent();
        }
        ClsTakvin objTakvin = new ClsTakvin();

        private void FrmTakvinSearchTree_Load(object sender, EventArgs e)
        {
            grdSearchTree.DataSource = objTakvin.searchTree().Tables[0]; 
            ClsTakvin.GetRootCode ="";
            ClsTakvin.GetRootName = "";
            ClsTakvin.GetRootAnbar = "";
            ClsTakvin.GetRootFaniNo = "";
            ClsTakvin.GetidRootTree = "";

            ClsTakvin.GetParentCode = "";
            ClsTakvin.GetParentName = "";
            ClsTakvin.GetParentAnbar = "";
            ClsTakvin.GetParentFaniNo = "";

            ClsTakvin.GetGhetehCode = "";
            ClsTakvin.GetGheteName = "";
            ClsTakvin.GetGhetehAnbar = "";
            ClsTakvin.GetGhetehFaniNo = "";              

        }

        private void grdSearchTree_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {

                ClsTakvin.GetRootCode = grdSearchTree.Rows[e.RowIndex].Cells["RootGhetehCode"].Value.ToString();
                ClsTakvin.GetRootName = grdSearchTree.Rows[e.RowIndex].Cells["RootGheteName"].Value.ToString();
                ClsTakvin.GetRootAnbar = grdSearchTree.Rows[e.RowIndex].Cells["RootGhetehAnbar"].Value.ToString();
                ClsTakvin.GetRootFaniNo = grdSearchTree.Rows[e.RowIndex].Cells["RootFaniNo"].Value.ToString();
                ClsTakvin.GetidRootTree = grdSearchTree.Rows[e.RowIndex].Cells["idRootTree"].Value.ToString();

                //ClsTakvin.GetParentCode = grdSearchTree.Rows[e.RowIndex].Cells["ParentGhetehCode"].Value.ToString();
                //ClsTakvin.GetParentName = grdSearchTree.Rows[e.RowIndex].Cells["ParentGheteName"].Value.ToString();
                //ClsTakvin.GetParentAnbar = grdSearchTree.Rows[e.RowIndex].Cells["ParentGhetehAnbar"].Value.ToString();
                //ClsTakvin.GetParentFaniNo = grdSearchTree.Rows[e.RowIndex].Cells["ParentFaniNo"].Value.ToString();

                ClsTakvin.GetGhetehCode = grdSearchTree.Rows[e.RowIndex].Cells["GhetehCode"].Value.ToString();
                ClsTakvin.GetGheteName = grdSearchTree.Rows[e.RowIndex].Cells["GheteName"].Value.ToString();
                ClsTakvin.GetGhetehAnbar = grdSearchTree.Rows[e.RowIndex].Cells["GhetehAnbar"].Value.ToString();
                ClsTakvin.GetGhetehFaniNo = grdSearchTree.Rows[e.RowIndex].Cells["FaniNo"].Value.ToString();
                //ClsTakvin.GetNodelevel = grdSearchTree.Rows[e.RowIndex].Cells["Nodelevel"].Value.ToString();
                this.Close();
            }
            catch 
            {
                return;
            }
        }

        private void FrmTakvinSearchTree_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close(); 
        }

    }
}

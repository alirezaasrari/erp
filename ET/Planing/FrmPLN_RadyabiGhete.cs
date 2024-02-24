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
    public partial class FrmPLN_RadyabiGhete : Telerik.WinControls.UI.RadForm
    {
        public FrmPLN_RadyabiGhete()
        {
            InitializeComponent();
        }
        public string strIdGhete, strIdRadyabi;
        private void FrmPLN_RadyabiGhete_Load(object sender, EventArgs e)
        {
            ClsPlanning objPlanning = new ClsPlanning();
            objPlanning.strIdGhete = strIdGhete;
            grdRadyabi.DataSource = objPlanning.Select_RadyabiGhete().Tables[0];
        }

        private void grdRadyabi_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            strIdRadyabi = grdRadyabi.Rows[e.RowIndex].Cells["IdRadyabi"].Value.ToString();
            Close();
        }
    }
}

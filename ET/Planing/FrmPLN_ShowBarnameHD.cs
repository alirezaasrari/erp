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
    public partial class FrmPLN_ShowBarnameHD : Telerik.WinControls.UI.RadForm
    {
        public FrmPLN_ShowBarnameHD()
        {
            InitializeComponent();
        }
        public string strIdBarnameH;
        private void FrmPLN_ShowBarnameHD_Load(object sender, EventArgs e)
        {
            ClsPlanning objPlanning = new ClsPlanning();
            grdBarnameHD.DataSource = objPlanning.Select_BarnameHD().Tables[0];
        }

        private void grdBarnameHD_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            strIdBarnameH = grdBarnameHD.Rows[e.RowIndex].Cells["IdBarname"].Value.ToString();
            this.Close();
        }
    }
}

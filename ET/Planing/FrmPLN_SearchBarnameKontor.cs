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
    public partial class FrmPLN_SearchBarnameKontor : Telerik.WinControls.UI.RadForm
    {
        public FrmPLN_SearchBarnameKontor()
        {
            InitializeComponent();
        }
        public string strIdBarnameH;
        private void FrmPLN_SearchBarnameKontor_Load(object sender, EventArgs e)
        {
            ClsPlanning obj = new ClsPlanning();
            grd.DataSource = obj.Select_BarnameKontorH("0").Tables[0];
        }

        private void grd_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if(e.Column.Name=="btnSelect")
            {
                strIdBarnameH = grd.CurrentRow.Cells["IdBarnameH"].Value.ToString();
                Close();
            }
        }
    }
}

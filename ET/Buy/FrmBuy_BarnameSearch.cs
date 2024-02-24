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
    public partial class FrmBuy_BarnameSearch : Telerik.WinControls.UI.RadForm
    {
        public FrmBuy_BarnameSearch()
        {
            InitializeComponent();
        }

        private void FrmBuy_BarnameSearch_Load(object sender, EventArgs e)
        {
            ClsBuy objBuy=new ClsBuy();
            //objBuy.strC_anbar = "15";
            objBuy.intMande_d = 1;
            grd.DataSource = objBuy.SelectDarkhastKharid().Tables[0];
        }

        private void grd_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            ClsBuy.Sho_Darkhast = grd.Rows[e.RowIndex].Cells["Sho_Darkhast"].Value.ToString();
            ClsBuy.DarkhastRadif = grd.Rows[e.RowIndex].Cells["Radif_Darkhast"].Value.ToString();
            ClsBuy.C_kala = grd.Rows[e.RowIndex].Cells["C_kala"].Value.ToString();
            ClsBuy.N_kala = grd.Rows[e.RowIndex].Cells["Nkala"].Value.ToString();
            ClsBuy.Baghimande = grd.Rows[e.RowIndex].Cells["baghimande"].Value.ToString();
            Close();
        }
    }
}

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
    public partial class FrmBuy_Taeed : Telerik.WinControls.UI.RadForm
    {
        public FrmBuy_Taeed()
        {
            InitializeComponent();
        }
        ClsBuy objBuy = new ClsBuy();
        private void FrmBuy_Taeed_Load(object sender, EventArgs e)
        {
            //objBuy.insBarnameAnbar14();
            grdDarkhast.DataSource = objBuy.SelectDarkhastTaeed().Tables[0]; 
        }

        private void grdDarkhast_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "TaeedDarkhast")
            {
                objBuy.strSho_Darkhast = e.Row.Cells["Sho_Darkhast"].Value.ToString();
                objBuy.strDarkhastRadif = e.Row.Cells["Radif_Darkhast"].Value.ToString();
                objBuy.strC_Personel = "0";

                objBuy.insBarname();
                grdDarkhast.DataSource = objBuy.SelectDarkhastTaeed().Tables[0];
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            grdDarkhast.DataSource = objBuy.SelectDarkhastTaeed().Tables[0];
        }
    }
}

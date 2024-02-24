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
    public partial class FrmBuy_TaeedReturn : Telerik.WinControls.UI.RadForm
    {
        public FrmBuy_TaeedReturn()
        {
            InitializeComponent();
        }
        ClsBuy objBuy = new ClsBuy();
        private void FrmBuy_TaeedReturn_Load(object sender, EventArgs e)
        {
            grdDarkhast.DataSource = objBuy.SelectDarkhast().Tables[0];
        }

        private void grdDarkhast_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "TaeedDarkhast")
            {
                if (MessageBox.Show("آیا از اعمال تغییرات اطمینان دارید؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    objBuy.strSho_Darkhast = e.Row.Cells["Sho_Darkhast"].Value.ToString();
                    objBuy.strDarkhastRadif = e.Row.Cells["Radif_Darkhast"].Value.ToString();

                    MessageBox.Show(objBuy.DelBarname());
                    grdDarkhast.DataSource = objBuy.SelectDarkhast().Tables[0];
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            grdDarkhast.DataSource = objBuy.SelectDarkhast().Tables[0];
        }
    }
}

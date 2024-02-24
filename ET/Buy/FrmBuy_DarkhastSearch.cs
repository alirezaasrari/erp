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
    public partial class FrmBuy_DarkhastSearch : Telerik.WinControls.UI.RadForm
    {
        public FrmBuy_DarkhastSearch()
        {
            InitializeComponent();
        }
        public string strIdDarkhastKharid, strCkala, strNkala, str, strMored_masraf, strDateNiaz;
        private void FrmBuy_DarkhastSearch_Load(object sender, EventArgs e)
        {
            ClsBuy obj = new ClsBuy();
            Grd.DataSource = obj.Select_DarkhastKharidSearch().Tables[0];
        }

        private void Grd_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if(e.Column.Name=="btnSelect")
            {
                strIdDarkhastKharid= Grd.Rows[e.RowIndex].Cells["Sho_Darkhast"].Value.ToString();
                strCkala = Grd.Rows[e.RowIndex].Cells["C_kala"].Value.ToString();
                strNkala = Grd.Rows[e.RowIndex].Cells["Nkala"].Value.ToString();
                strMored_masraf = Grd.Rows[e.RowIndex].Cells["Mored_masraf"].Value.ToString();
                strDateNiaz = Grd.Rows[e.RowIndex].Cells["Date_Niaz"].Value.ToString();
                Close();
            }
        }
    }
}

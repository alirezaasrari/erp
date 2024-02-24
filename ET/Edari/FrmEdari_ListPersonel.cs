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
    public partial class FrmEdari_ListPersonel : Telerik.WinControls.UI.RadForm
    {
        public String strC_personel, strN_personel, strTFather, strTypeOpen = "", strTaf;
        public FrmEdari_ListPersonel()
        {
            InitializeComponent();
        }

        private void grdPersonel_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            strC_personel = grdPersonel.Rows[e.RowIndex].Cells["IdPersonel"].Value.ToString();
            strN_personel = grdPersonel.Rows[e.RowIndex].Cells["NamePersonel"].Value.ToString();
            ClsPublic.strN_personel =strN_personel ;
            ClsPublic.strC_personel = strC_personel;
            strTaf= grdPersonel.Rows[e.RowIndex].Cells["taf"].Value.ToString();
            Close();
        }

        private void FrmEdari_ListPersonel_Load(object sender, EventArgs e)
        {
            ClsEdari objEdari = new ClsEdari();
            objEdari.strTFather = strTFather;
            if (strTypeOpen == "PeintEdari")
                grdPersonel.DataSource = objEdari.Select_PersonelDataPaya().Tables[0];
            else
                grdPersonel.DataSource = objEdari.Select_Personel().Tables[0];
            ClsPublic.strN_personel = "";
            ClsPublic.strC_personel = "";
        }

        private void grdPersonel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                strC_personel = grdPersonel.CurrentRow.Cells["IdPersonel"].Value.ToString();
                strN_personel = grdPersonel.CurrentRow.Cells["NamePersonel"].Value.ToString();
                ClsPublic.strN_personel = strN_personel;
                ClsPublic.strC_personel = strC_personel;
                strTaf = grdPersonel.CurrentRow.Cells["taf"].Value.ToString();
                Close();
            }
        }
    }
}

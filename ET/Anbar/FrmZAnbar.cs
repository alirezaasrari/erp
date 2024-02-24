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
    public partial class FrmZAnbar : Telerik.WinControls.UI.RadForm
    {
        public FrmZAnbar()
        {
            InitializeComponent();
        }
        ClsAnbar clsAnbarObj = new ClsAnbar();
        public string strC_Anbar, strC_Anbar2;
        private void FrmZAnbar_Load(object sender, EventArgs e)
        {
            clsAnbarObj.strC_ZAnbar = "";
            clsAnbarObj.strC_Anbar = strC_Anbar;
            clsAnbarObj.strC_Anbar2 = strC_Anbar2;
            grd.DataSource = clsAnbarObj.SelectZAnbar().Tables[0];
        }
        private void grd_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                ClsAnbar.N_ZAnbar = grd.Rows[e.RowIndex].Cells["n_zanbar"].Value.ToString();
                ClsAnbar.C_ZAnbar = grd.Rows[e.RowIndex].Cells["cd_zanbar"].Value.ToString();
                this.Close();
            }
            catch { }
        }

        private void txtNZanbar_TextChanged(object sender, EventArgs e)
        {
            clsAnbarObj.strN_ZAnbar = txtNZanbar.Text;
            clsAnbarObj.strC_Anbar = strC_Anbar;
            grd.DataSource = clsAnbarObj.SelectZAnbar().Tables[0];
        }

        private void grd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Return)
                {
                    ClsAnbar.N_ZAnbar = grd.CurrentRow.Cells["n_zanbar"].Value.ToString();
                    ClsAnbar.C_ZAnbar = grd.CurrentRow.Cells["cd_zanbar"].Value.ToString();
                    this.Close();
                }
            }
            catch { }
        }

        private void txtCZanbar_TextChanged(object sender, EventArgs e)
        {
            clsAnbarObj.strC_ZAnbar = txtCZanbar.Text;
            clsAnbarObj.strN_ZAnbar = "";
            clsAnbarObj.strC_Anbar = strC_Anbar;
            grd.DataSource = clsAnbarObj.SelectZAnbar().Tables[0];
        }
    }
}

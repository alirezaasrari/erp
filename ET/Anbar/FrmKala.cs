using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Globalization;

namespace ET
{
    public partial class FrmKala : Telerik.WinControls.UI.RadForm
    {
        public FrmKala()
        {
            InitializeComponent();
        }
        ClsBuy clsBuyObj = new ClsBuy();
        ClsAnbar clsAnbarObj = new ClsAnbar();
        public string strKalaBarname = "",strC_Anbar ,strC_zAnbar;
        private void txtNkala_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("fa-IR"));
        }

        private void txtNkala_TextChanged(object sender, EventArgs e)
        {
            if (strKalaBarname == "")
            {
                clsAnbarObj.strNkala = txtNkala.Text;
                clsAnbarObj.strC_ZAnbar = strC_zAnbar;
                clsAnbarObj.strC_Kala = "";
                Grd.DataSource = clsAnbarObj.SelectKala().Tables[0];
                clsBuyObj.strN_kala = "";
            }
            else
            {
                clsBuyObj.strN_kala = txtNkala.Text;
                clsBuyObj.strC_kala = "";
                Grd.DataSource = clsBuyObj.KalaBarname().Tables[0];
                clsBuyObj.strN_kala = "";
            }
        }

        private void RadForm1_Load(object sender, EventArgs e)
        {
            ClsPublic.C_kala = "";
            ClsPublic.N_kala = "";
            ClsPublic.C_Anbar = "";
            ClsPublic.N_Anbar = "";
            
            clsBuyObj.strN_kala = "";
            clsBuyObj.strC_kala = "";
            if (strKalaBarname != "")
                Grd.DataSource = clsBuyObj.KalaBarname().Tables[0];
            else
            {
                clsAnbarObj.strC_Anbar = strC_Anbar;
                clsAnbarObj.strC_ZAnbar = strC_zAnbar;
                Grd.DataSource = clsAnbarObj.SelectKala().Tables[0];
            }
        }

        private void txtCkala_TextChanged(object sender, EventArgs e)
        {
            try
            {
                clsAnbarObj.strC_Kala = txtCkala.Text;
                clsAnbarObj.strC_ZAnbar = strC_zAnbar;
                clsAnbarObj.strNkala = "";
                Grd.DataSource = clsAnbarObj.SelectKala().Tables[0];
                clsBuyObj.strN_kala = "";
                clsBuyObj.strC_kala = "";
            }
            catch
            {}
        }

        private void grdKala_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                ClsBuy.N_kala = Grd.Rows[e.RowIndex].Cells["N_Kala"].Value.ToString();
                ClsBuy.C_kala = Grd.Rows[e.RowIndex].Cells["C_Kala"].Value.ToString();
                ClsBuy.N_Anbar = Grd.Rows[e.RowIndex].Cells["N_anbar"].Value.ToString();
                ClsBuy.C_Anbar = Grd.Rows[e.RowIndex].Cells["C_anbar"].Value.ToString();
                ClsBuy.strN_Vahed = Grd.Rows[e.RowIndex].Cells["N_Vahed"].Value.ToString();

                ClsPublic.N_kala = Grd.Rows[e.RowIndex].Cells["N_Kala"].Value.ToString();
                ClsPublic.C_kala = Grd.Rows[e.RowIndex].Cells["C_Kala"].Value.ToString();
                ClsPublic.N_Anbar = Grd.Rows[e.RowIndex].Cells["N_anbar"].Value.ToString();
                ClsPublic.C_Anbar = Grd.Rows[e.RowIndex].Cells["C_anbar"].Value.ToString();
                ClsPublic.id_Gheteh = Grd.Rows[e.RowIndex].Cells["id_Gheteh"].Value.ToString();
                this.Close();
            }
            catch { }
        }

        private void grdKala_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Return)
                {
                    ClsBuy.N_kala = Grd.CurrentRow.Cells["N_Kala"].Value.ToString();
                    ClsBuy.C_kala = Grd.CurrentRow.Cells["C_Kala"].Value.ToString();
                    ClsBuy.N_Anbar = Grd.CurrentRow.Cells["N_anbar"].Value.ToString();
                    ClsBuy.C_Anbar = Grd.CurrentRow.Cells["C_anbar"].Value.ToString();

                    ClsPublic.N_kala = Grd.CurrentRow.Cells["N_Kala"].Value.ToString();
                    ClsPublic.C_kala = Grd.CurrentRow.Cells["C_Kala"].Value.ToString();
                    ClsPublic.N_Anbar = Grd.CurrentRow.Cells["N_anbar"].Value.ToString();
                    ClsPublic.C_Anbar = Grd.CurrentRow.Cells["C_anbar"].Value.ToString();
                    this.Close();
                }
            }
            catch { }
        }
    }
}

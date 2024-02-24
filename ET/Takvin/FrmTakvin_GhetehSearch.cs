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
    public partial class FrmTakvin_GhetehSearch : Telerik.WinControls.UI.RadForm
    {
        public FrmTakvin_GhetehSearch()
        {
            InitializeComponent();
        }
        public string strPlanning, strIdUnit;
        private void FrmTakvin_GhetehSearch_Load(object sender, EventArgs e)
        {
            ClsAnbar objAnbar = new ClsAnbar();
            if (strPlanning == "1")
            {
                //objAnbar.strC_Anbar = "13";
                objAnbar.strPlanning = strPlanning;
            } 
            objAnbar.strIdUnit = strIdUnit;
            Grd.DataSource = objAnbar.SelectGheteh().Tables[0];
            if (strPlanning == "2")
                Grd.Columns["MeghdarNiaz"].IsVisible = false;
        }

        private void Grd_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            ClsPublic.N_kala = Grd.Rows[e.RowIndex].Cells["GheteName"].Value.ToString();
            ClsPublic.C_kala = Grd.Rows[e.RowIndex].Cells["GhetehCode"].Value.ToString();
            ClsPublic.C_Anbar = Grd.Rows[e.RowIndex].Cells["GhetehAnbar"].Value.ToString();
            ClsPublic.FaniNo = Grd.Rows[e.RowIndex].Cells["FaniNo"].Value.ToString();
            ClsPublic.id_Gheteh = Grd.Rows[e.RowIndex].Cells["id_Gheteh"].Value.ToString();
            ClsPublic.strMeghdarNiaz = Grd.Rows[e.RowIndex].Cells["MeghdarNiaz"].Value.ToString();
            ClsPublic.strzakhire = Grd.Rows[e.RowIndex].Cells["zakhire"].Value.ToString();
            ClsPublic.strMojoodiKhat = Grd.Rows[e.RowIndex].Cells["MojoodiKhat"].Value.ToString();
            ClsPublic.strTeloranceTolid = Grd.Rows[e.RowIndex].Cells["TeloranceTolid"].Value.ToString();
            if (Grd.Rows[e.RowIndex].Cells["VaznMavad"] != null)
                ClsPublic.VaznMavad = Grd.Rows[e.RowIndex].Cells["VaznMavad"].Value.ToString();
            if (Grd.Rows[e.RowIndex].Cells["FK_ID_unit"] != null)
                ClsPublic.strID_unit = Grd.Rows[e.RowIndex].Cells["FK_ID_unit"].Value.ToString();
            if (Grd.Rows[e.RowIndex].Cells["onvan"] != null)
                ClsPublic.strNameUnit = Grd.Rows[e.RowIndex].Cells["onvan"].Value.ToString();
            if (Grd.Rows[e.RowIndex].Cells["FK_ID_machine"] != null)
                ClsPublic.strIdMachine = Grd.Rows[e.RowIndex].Cells["FK_ID_machine"].Value.ToString();
            if (Grd.Rows[e.RowIndex].Cells["N_machine"] != null)
                ClsPublic.strNameMachine = Grd.Rows[e.RowIndex].Cells["N_machine"].Value.ToString();
            if (Grd.Rows[e.RowIndex].Cells["Zaman_standard"] != null)
                ClsPublic.strZaman_standard = Grd.Rows[e.RowIndex].Cells["Zaman_standard"].Value.ToString();
            if (Grd.Rows[e.RowIndex].Cells["nafar_tedad"] != null)
                ClsPublic.strnafar_tedad = Grd.Rows[e.RowIndex].Cells["nafar_tedad"].Value.ToString();
            if (Grd.Rows[e.RowIndex].Cells["hofre_tedad"] != null)
                ClsPublic.strhofre_tedad = Grd.Rows[e.RowIndex].Cells["hofre_tedad"].Value.ToString();
            this.Close();
        }
    }
}

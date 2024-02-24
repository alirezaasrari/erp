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
    public partial class FrmFLW_Ronevesht : Telerik.WinControls.UI.RadForm
    {
        public FrmFLW_Ronevesht()
        {
            InitializeComponent();
        }

        private void FrmFLW_Ronevesht_Load(object sender, EventArgs e)
        {
            ClsFlw obj = new ClsFlw();
            obj.strKartabl = "3";
            obj.strRonevesht = "0";
            grd.DataSource = obj.Select_FormFlowTaeedH().Tables[0];
            gridViewTemplate1.DataSource = obj.Select_FormFlowTaeed().Tables[0];
        }

        private void grd_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "btnDetail")
            {
                int Ispaya = 0;
                FrmFLW_Khorooj frm = new FrmFLW_Khorooj();
                frm.IntLevelTaeed = "1";
                frm.strIdKhoroojH = grd.Rows[e.RowIndex].Cells["CodeFormX"].Value.ToString();
                //frm.IntIdFormChart = grd.Rows[e.RowIndex].Cells["IdFormChart"].Value.ToString();
                frm.IntIdFormChart = grd.Rows[e.RowIndex].Cells["IdFormChart"].Value.ToString();
                frm.strID_FormUnit = grd.Rows[e.RowIndex].Cells["ID_FormUnit"].Value.ToString();
                frm.strSend = "0";

                if (frm.strID_FormUnit == "1")
                {
                    if (Convert.ToInt32(frm.IntIdFormChart) < 3)
                        frm.ShowDialog();
                    else
                        Ispaya = 1;

                }
                if (frm.strID_FormUnit == "2")
                {
                    if (Convert.ToInt32(frm.IntIdFormChart) < 9)
                        frm.ShowDialog();
                    else
                        Ispaya = 1;
                }
                if (frm.strID_FormUnit == "3")
                {
                    FrmFLW_Tahvil_tatbigh frmt = new FrmFLW_Tahvil_tatbigh();
                    frmt.IntLevelTaeed = grd.Rows[e.RowIndex].Cells["LevelTaeed"].Value.ToString();
                    frmt.IntIdFormChart = grd.Rows[e.RowIndex].Cells["IdFormChart"].Value.ToString();
                    frmt.IntIdMarhale = grd.Rows[e.RowIndex].Cells["IdMarhale"].Value.ToString();
                    frmt.strIdTahvil_Tatbigh_H = grd.Rows[e.RowIndex].Cells["CodeFormX"].Value.ToString();
                    frmt.strID_FormUnit = grd.Rows[e.RowIndex].Cells["ID_FormUnit"].Value.ToString();
                    frmt.strIdTaeed = grd.Rows[e.RowIndex].Cells["IdTaeed"].Value.ToString();
                    frmt.strSend = "0";
                    if (Convert.ToInt32(frmt.IntIdMarhale) < 7)
                        frmt.ShowDialog();
                    else
                    {
                        FrmFLW_Noncompliance frmn = new FrmFLW_Noncompliance();

                        frmn.ShowDialog();
                    }
                }
                if (frm.strID_FormUnit == "4")
                {
                    if (Convert.ToInt32(frm.IntIdFormChart) < 87)
                        frm.ShowDialog();
                    else
                        Ispaya = 1;
                }
                if (frm.strID_FormUnit == "5")
                {
                    if (Convert.ToInt32(frm.IntIdFormChart) < 93)
                        frm.ShowDialog();
                    else
                        Ispaya = 1;
                }
                if (frm.strID_FormUnit == "6")
                {
                    if (Convert.ToInt32(frm.IntIdFormChart) < 99)
                        frm.ShowDialog();
                    else
                        Ispaya = 1;
                }
                if (frm.strID_FormUnit == "7")
                {
                    if (Convert.ToInt32(frm.IntIdFormChart) < 105)
                        frm.ShowDialog();
                    else
                        Ispaya = 1;
                }
                if (frm.strID_FormUnit == "8")
                {
                    if (Convert.ToInt32(frm.IntIdFormChart) < 112)
                        frm.ShowDialog();
                    else
                        Ispaya = 1;
                }
                if (frm.strID_FormUnit == "9")
                {
                    if (Convert.ToInt32(frm.IntIdFormChart) < 119)
                        frm.ShowDialog();
                    else
                        Ispaya = 1;
                }
                if (frm.strID_FormUnit == "10")
                {
                    DataTable dt = new DataTable();
                    ClsFlw objn = new ClsFlw();
                    dt = objn.Select_NamoHeader2(grd.Rows[e.RowIndex].Cells["IdCodeFormX"].Value.ToString()).Tables[0];
                    FrmFLW_Noncompliance frmn = new FrmFLW_Noncompliance();
                    frmn.strIdTahvil_Tatbigh_D = dt.Rows[0]["IdTahvil_Tatbigh_D"].ToString();
                    frmn.txtNKala.Text = dt.Rows[0]["N_Kala"].ToString();
                    frmn.lblCkala.Text = dt.Rows[0]["CKala"].ToString();
                    frmn.txtTracker.Text = dt.Rows[0]["Tracker"].ToString();
                    frmn.txtMeghdar.Text = dt.Rows[0]["Meghdar"].ToString();
                    frmn.txtWorkShop.Text = dt.Rows[0]["WorkShop"].ToString();
                    frmn.txtDevice.Text = dt.Rows[0]["Device"].ToString();
                    frmn.IntIdFormChart = grd.Rows[e.RowIndex].Cells["IdFormChart"].Value.ToString();
                    frmn.IntIdMarhale = grd.Rows[e.RowIndex].Cells["IdMarhale"].Value.ToString();
                    frmn.strID_FormUnit = grd.Rows[e.RowIndex].Cells["ID_FormUnit"].Value.ToString();
                    frmn.strIdTaeed = grd.Rows[e.RowIndex].Cells["IdTaeed"].Value.ToString();
                    frmn.strInbox = "1";
                    frmn.ShowDialog();
                }
                if (frm.strID_FormUnit == "11")
                {
                    if (Convert.ToInt32(frm.IntIdFormChart) < 155)
                        frm.ShowDialog();
                    else
                        Ispaya = 1;
                }
                if (frm.strID_FormUnit == "12")
                {
                    if (Convert.ToInt32(frm.IntIdFormChart) < 164)
                        frm.ShowDialog();
                    else
                        Ispaya = 1;
                }
                if (frm.strID_FormUnit == "13")
                {
                    FrmFLW_KasrHazine frmKasr = new FrmFLW_KasrHazine();
                    frmKasr.txtIdKasr.Text = grd.Rows[e.RowIndex].Cells["CodeFormX"].Value.ToString();
                    frmKasr.IntIdFormChart = grd.Rows[e.RowIndex].Cells["IdFormChart"].Value.ToString();
                    frmKasr.strSend = "0";
                    frmKasr.ShowDialog();
                }
                if (frm.strID_FormUnit == "14")
                {
                    FrmFLW_KhoroojMahsool frmAghlam = new FrmFLW_KhoroojMahsool();
                    frmAghlam.strSend = "0";
                    frmAghlam.IdKhoroojAghlam = grd.Rows[e.RowIndex].Cells["CodeFormX"].Value.ToString();
                    frmAghlam.IntIdFormChart = grd.Rows[e.RowIndex].Cells["IdFormChart"].Value.ToString();
                    frmAghlam.strIdTaeed = grd.Rows[e.RowIndex].Cells["IdTaeed"].Value.ToString();
                    frmAghlam.IntIdMarhale = grd.Rows[e.RowIndex].Cells["IdMarhale"].Value.ToString();
                    frmAghlam.ShowDialog();
                }

                if (Ispaya == 1)
                {
                    FrmFLW_KhoroojPaya frmP = new FrmFLW_KhoroojPaya();
                    //frmP.IntIdMarhale = grd.Rows[e.RowIndex].Cells["IdMarhale"].Value.ToString();
                    frmP.strIdKhoroojH = frm.strIdKhoroojH;
                    frmP.strIdTaeed = frm.strIdTaeed;
                    frmP.strID_FormUnit = frm.strID_FormUnit;
                    frmP.strSend = "1";
                    frmP.ShowDialog();
                }
            }
        }
    }
}

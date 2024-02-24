using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Diagnostics;
using FastReport;

namespace ET
{
    public partial class FrmEdari_Gharardad : Telerik.WinControls.UI.RadForm
    {
        public FrmEdari_Gharardad()
        {
            InitializeComponent();
        }
        public string strTaf;
        private void FrmEdari_Rep_Load(object sender, EventArgs e)
        {

        }

        private void btnSearchPersonel_Click(object sender, EventArgs e)
        {
            FrmEdari_ListPersonel frm = new FrmEdari_ListPersonel();
            frm.strTypeOpen = "PeintEdari";
            frm.ShowDialog();
            txtNamePersonel.Text = frm.strN_personel;
            lblCodePersonel.Text = frm.strC_personel;
            strTaf = frm.strTaf;

            ClsEdari obj = new ClsEdari();
            obj.strC_personel = lblCodePersonel.Text;
            obj.strTafsili = strTaf;
            grdPersonelData.DataSource = obj.Select_PersonelDataReport().Tables[0];
            grdHokm.DataSource = obj.Select_PersonelHokmReport().Tables[0];
            grdGharardad.DataSource = obj.Select_PersonelGharardadReport().Tables[0];
            grdWife.DataSource = obj.Select_PersonelTakafol().Tables[0];
        }

        private void btnGharardad_Click(object sender, EventArgs e)
        {
            try
            {
                Report objReport = new Report();

                objReport.Load(ClsPublic.strRepPath + "Gharadad.frx");
                objReport.SetParameterValue("@CodePersonel", lblCodePersonel.Text);
                objReport.SetParameterValue("@Tafsili", strTaf);
                objReport.Show();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnGharardadSefid_Click(object sender, EventArgs e)
        {
            Report objReport = new Report();

            objReport.Load(ClsPublic.strRepPath + "Gharadad.frx");
            objReport.SetParameterValue("@CodePersonel", "0");
            objReport.Show();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            try
            {
                Report objReport = new Report();

                objReport.Load(ClsPublic.strRepPath + "GharadadKholase.frx");
                objReport.SetParameterValue("@CodePersonel", lblCodePersonel.Text);
                objReport.Show();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnEvalModir_Click(object sender, EventArgs e)
        {
            try
            {
                Report objReport = new Report();

                objReport.Load(ClsPublic.strRepPath + "arzeshyabi.frx");
                objReport.SetParameterValue("@CodePersonel", lblCodePersonel.Text);
                objReport.Show();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnEvalKarshenas_Click(object sender, EventArgs e)
        {
            try
            {
                Report objReport = new Report();

                objReport.Load(ClsPublic.strRepPath + "arzeshyabimasul.frx");
                objReport.SetParameterValue("@CodePersonel", lblCodePersonel.Text);
                objReport.Show();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnEvalKargar_Click(object sender, EventArgs e)
        {
            try
            {
                Report objReport = new Report();

                objReport.Load(ClsPublic.strRepPath + "arzeshyabikargar.frx");
                objReport.SetParameterValue("@CodePersonel", lblCodePersonel.Text);
                objReport.Show();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnHokmJari_Click(object sender, EventArgs e)
        {
            try
            {
                Report objReport = new Report();

                objReport.Load(ClsPublic.strRepPath + "HOKMjari.frx");
                objReport.SetParameterValue("@CodePersonel", lblCodePersonel.Text);
                objReport.SetParameterValue("@Tafsili", strTaf);
                objReport.Show();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnHokmBime_Click(object sender, EventArgs e)
        {
            try
            {
                Report objReport = new Report();

                objReport.Load(ClsPublic.strRepPath + "HOKMbime.frx");
                objReport.SetParameterValue("@CodePersonel", lblCodePersonel.Text);
                objReport.SetParameterValue("@Tafsili", strTaf);
                objReport.Show();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnTasvie_Click(object sender, EventArgs e)
        {
            try
            {
                Report objReport = new Report();

                objReport.Load(ClsPublic.strRepPath + "tasvieh.frx");
                objReport.SetParameterValue("@CodePersonel", lblCodePersonel.Text);
                objReport.Show();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            try
            {
                Report objReport = new Report();

                objReport.Load(ClsPublic.strRepPath + "taahod.frx");
                objReport.SetParameterValue("@CodePersonel", lblCodePersonel.Text);
                objReport.Show();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        //private void grdWife_UserAddingRow(object sender, Telerik.WinControls.UI.GridViewRowCancelEventArgs e)
        //{
        //    //try
        //    //{
        //    //    ClsEdari obj = new ClsEdari();
        //    //    obj.strNameWife = grdWife.CurrentRow.Cells["NameWife"].Value.ToString();
        //    //    obj.strFamilWife = grdWife.CurrentRow.Cells["FamilWife"].Value.ToString();
        //    //    obj.strNameFather = grdWife.CurrentRow.Cells["NameFather"].Value.ToString();
        //    //    obj.strShoMeli = grdWife.CurrentRow.Cells["ShoMeli"].Value.ToString();
        //    //    obj.strShoShenasname = grdWife.CurrentRow.Cells["ShoShenasname"].Value.ToString();
        //    //    obj.strDateBirth = grdWife.CurrentRow.Cells["DateBirth"].Value.ToString().Substring(0,9);
        //    //    obj.strDateMaried = grdWife.CurrentRow.Cells["DateMaried"].Value.ToString().Substring(0,9);
        //    //    obj.strC_personel = lblCodePersonel.Text;

        //    //    MessageBox.Show(obj.Insert_PersonelWife());
        //    //    grdWife.Rows.AddNew();
        //    //    grdWife.DataSource = obj.Select_PersonelWife().Tables[0];
        //    //}
        //    //catch(Exception ee)
        //    //{
        //    //    MessageBox.Show(ee.Message);
        //    //}
        //}

        //private void grdWife_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        //{
        //    //try
        //    //{
        //    //    if (e.Column.Name == "btnDelete")
        //    //    {
        //    //        ClsEdari obj = new ClsEdari();
        //    //        obj.strIdEmpWife = grdWife.CurrentRow.Cells["IdEmpWife"].Value.ToString();

        //    //        MessageBox.Show(obj.Delete_PersonelWife());
        //    //        grdWife.DataSource = obj.Select_PersonelWife().Tables[0];
        //    //    }
        //    //    if (e.Column.Name == "btnEdit")
        //    //    {
        //    //        ClsEdari obj = new ClsEdari();
        //    //        obj.strNameWife = grdWife.CurrentRow.Cells["NameWife"].Value.ToString();
        //    //        obj.strFamilWife = grdWife.CurrentRow.Cells["FamilWife"].Value.ToString();
        //    //        obj.strNameFather = grdWife.CurrentRow.Cells["NameFather"].Value.ToString();
        //    //        obj.strShoMeli = grdWife.CurrentRow.Cells["ShoMeli"].Value.ToString();
        //    //        obj.strShoShenasname = grdWife.CurrentRow.Cells["ShoShenasname"].Value.ToString();
        //    //        obj.strDateBirth = grdWife.CurrentRow.Cells["DateBirth"].Value.ToString().Substring(0, 9);
        //    //        obj.strDateMaried = grdWife.CurrentRow.Cells["DateMaried"].Value.ToString().Substring(0, 9);
        //    //        obj.strIdEmpWife = grdWife.CurrentRow.Cells["IdEmpWife"].Value.ToString();
        //    //        obj.strC_personel = lblCodePersonel.Text;

        //    //        MessageBox.Show(obj.Update_PersonelWife());
        //    //        grdWife.DataSource = obj.Select_PersonelWife().Tables[0];
        //    //    }
        //    //}
        //    //catch (Exception ee)
        //    //{
        //    //    MessageBox.Show(ee.Message);
        //    //}
        //}

        //private void grdChild_UserAddingRow(object sender, Telerik.WinControls.UI.GridViewRowCancelEventArgs e)
        //{
        //    //try
        //    //{
        //    //    ClsEdari obj = new ClsEdari();
        //    //    obj.strNameChild = grdChild.CurrentRow.Cells["NameChild"].Value.ToString();
        //    //    obj.strShoMeli = grdChild.CurrentRow.Cells["ShoMeli"].Value.ToString();
        //    //    obj.strShoShenasname = grdChild.CurrentRow.Cells["ShoShenasname"].Value.ToString();
        //    //    obj.strDateBirth = grdChild.CurrentRow.Cells["DateBirth"].Value.ToString().Substring(0, 9);
        //    //    obj.strCityBirth = grdChild.CurrentRow.Cells["CityBirth"].Value.ToString();
        //    //    obj.strC_personel = lblCodePersonel.Text;

        //    //    MessageBox.Show(obj.Insert_PersonelChild());
        //    //    grdChild.Rows.AddNew();
        //    //    grdChild.DataSource = obj.Select_PersonelChild().Tables[0];
        //    //}
        //    //catch (Exception ee)
        //    //{
        //    //    MessageBox.Show(ee.Message);
        //    //}
        //}

        //private void grdChild_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        //{
        //    //try
        //    //{
        //    //    if (e.Column.Name == "btnDelete")
        //    //    {
        //    //        ClsEdari obj = new ClsEdari();
        //    //        obj.strIdEmpChild = grdChild.CurrentRow.Cells["IdEmpChild"].Value.ToString();

        //    //        MessageBox.Show(obj.Delete_PersonelChild());
        //    //        grdChild.DataSource = obj.Select_PersonelChild().Tables[0];
        //    //    }
        //    //    if (e.Column.Name == "btnEdit")
        //    //    {
        //    //        ClsEdari obj = new ClsEdari();
        //    //        obj.strNameChild = grdChild.CurrentRow.Cells["NameChild"].Value.ToString();
        //    //        obj.strShoMeli = grdChild.CurrentRow.Cells["ShoMeli"].Value.ToString();
        //    //        obj.strShoShenasname = grdChild.CurrentRow.Cells["ShoShenasname"].Value.ToString();
        //    //        obj.strDateBirth = grdChild.CurrentRow.Cells["DateBirth"].Value.ToString().Substring(0, 9);
        //    //        obj.strCityBirth = grdChild.CurrentRow.Cells["CityBirth"].Value.ToString();
        //    //        obj.strIdEmpChild = grdChild.CurrentRow.Cells["IdEmpChild"].Value.ToString();
        //    //        obj.strC_personel = lblCodePersonel.Text;

        //    //        MessageBox.Show(obj.Update_PersonelChild());
        //    //        grdChild.DataSource = obj.Select_PersonelChild().Tables[0];
        //    //    }
        //    //}
        //    //catch (Exception ee)
        //    //{
        //    //    MessageBox.Show(ee.Message);
        //    //}
        //}

        private void btnRefah_Click(object sender, EventArgs e)
        {
            try
            {
                Report objReport = new Report();

                objReport.Load(ClsPublic.strRepPath + "SangooghRefah.frx");
                objReport.SetParameterValue("@CodePersonel", lblCodePersonel.Text);
                objReport.Show();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}

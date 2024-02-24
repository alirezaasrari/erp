using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using FastReport;

namespace ET
{
    public partial class FrmPLN_SabtBarname : Telerik.WinControls.UI.RadForm
    {
        public FrmPLN_SabtBarname()
        {
            InitializeComponent();
        }
        public string strIdGhete, strIdUnit, strFaniNo, strIdMachine, strMeghdarNiaz, strTeloranceTolid
            , strMojoodiKhat, strzakhire, strIdBarnameSefaresh, strIsView;
        private void btnAddH_Click(object sender, EventArgs e)
        {
            btnAddSefaresh.Enabled = true;
            btnPrintH.Enabled = true;
            //double mojaz = Convert.ToInt32(strMeghdarNiaz) + (Convert.ToDouble(strMeghdarNiaz) * Convert.ToDouble(strTeloranceTolid) / 100);
            //if (Convert.ToInt32(txtTedadTolid.Text) > mojaz)
            //{
            //    MessageBox.Show("حداکثر میزان مجاز تولید " + Convert.ToInt32(mojaz) + " عدد است");
            //    return;
            //}

            ClsPlanning objPlanning = new ClsPlanning();
            objPlanning.strIdGhete = strIdGhete;
            objPlanning.strDescription = txtTozihat.Text;
            objPlanning.strUserInsert = ClsMain.StrUsername;
            objPlanning.strDateStart = txtAzDate.Value.ToString().Substring(0, 10);
            objPlanning.strShiftStart = cmbAzShift.Text;
            objPlanning.strDateEnd = txtTaDate.Value.ToString().Substring(0, 10);
            objPlanning.strShiftEnd = cmbTaShift.Text;
            objPlanning.strTedadShift = cmbTedadShift.Text;
            objPlanning.strshiftHour = txtZamanKari.Text;
            if (cmbDastgah.SelectedValue != null)
                objPlanning.strIdMachine = cmbDastgah.SelectedValue.ToString();
            else
                objPlanning.strIdMachine = "";

            if (cmbUnit.SelectedValue != null)
                objPlanning.strIdUnit = cmbUnit.SelectedValue.ToString();
            else
                objPlanning.strIdUnit = "";

            if (cmbBOM.SelectedValue != null)
                objPlanning.strIdBOM = cmbBOM.SelectedValue.ToString();
            else
                objPlanning.strIdBOM = "0";

            if (cmbProccess.SelectedValue != null)
                objPlanning.strIdproccess = cmbProccess.SelectedValue.ToString();
            else
                objPlanning.strIdproccess = "";

            objPlanning.strTedadTolid = txtTedadTolid.Text;
            objPlanning.strzakhire = strzakhire;
            objPlanning.strTeloranceTolid = strTeloranceTolid;
            objPlanning.strMojoodiKhat = strMojoodiKhat;
            objPlanning.strTedadPersonel = txtNafar.Text;
            objPlanning.strTedadHofre = txtTedadHofre.Text;

            MessageBox.Show(objPlanning.Insert_BarnameHD());

            objPlanning.strIdBarnameH = txtIdBarnameH.Text = objPlanning.Select_BarnameMaxIdH().Tables[0].Rows[0][0].ToString();
        }

        private void btnF2Kala_Click(object sender, EventArgs e)
        {
            ClearControl();
            FrmTakvin_GhetehSearch frm = new FrmTakvin_GhetehSearch();
            frm.strPlanning = "1";
            frm.ShowDialog();
            if (ClsPublic.id_Gheteh == null)
                return;
            txtGheteName.Text = ClsPublic.N_kala;
            lblGhetehCode.Text = ClsPublic.C_kala;
            txtMavadVazn.Text = ClsPublic.VaznMavad;
            strIdUnit = ClsPublic.strID_unit;
            cmbUnit.Text = ClsPublic.strNameUnit;

            txtZamanKari.Text = "8";
            ClsTolid ObjTolid = new ClsTolid();
            ObjTolid.strDastgah = strIdMachine = ClsPublic.strIdMachine;
            cmbDastgah.DataSource = ObjTolid.Select_Dastgah().Tables[0];
            cmbDastgah.ValueMember = "ID_machine";
            cmbDastgah.DisplayMember = "N_machine";
            cmbDastgah.SelectedValue = ObjTolid.strDastgah;
            if (ClsPublic.strZaman_standard != "0" & ClsPublic.strZaman_standard != null & ClsPublic.strZaman_standard != "")
                txtZarfiatTolid.Text = Convert.ToInt32((Convert.ToDouble(txtZamanKari.Text) * 3600) / Convert.ToDouble(ClsPublic.strZaman_standard)).ToString();
            else
                txtZarfiatTolid.Text = "0";

            txtTedadTolid.Text = ClsPublic.strMeghdarNiaz;

            ClsPlanning objPlanning = new ClsPlanning();
            objPlanning.strIdGhete = strIdGhete = ClsPublic.id_Gheteh;
            cmbBOM.DataSource = objPlanning.Select_GhetehBom().Tables[0];
            cmbBOM.ValueMember = "FK_ID_Bom";
            cmbBOM.DisplayMember = "NameBom";
            if (cmbBOM.Items.Count > 0)
            {
                objPlanning.strIdBOM = cmbBOM.Items[0].Value.ToString();
                objPlanning.strMavadVazn = txtMavadVazn.Text;
                objPlanning.strTedadTolid = txtTedadTolid.Text;
                if (txtMavadVazn.Text != "")
                    grdBOM.DataSource = objPlanning.Select_BOM().Tables[0];
            }

            txtZamanStandard.Text = ClsPublic.strZaman_standard;
            txtNafar.Text = ClsPublic.strnafar_tedad;
            txtTedadHofre.Text = ClsPublic.strhofre_tedad;
            strMeghdarNiaz = ClsPublic.strMeghdarNiaz;
            strzakhire = ClsPublic.strzakhire;
            strMojoodiKhat = ClsPublic.strMojoodiKhat;
            strTeloranceTolid = ClsPublic.strTeloranceTolid;

            if (txtMavadVazn.Text != "0" & txtMavadVazn.Text != "" & txtTedadTolid.Text != "")
                txtMavadVaznKol.Text = (Convert.ToDouble(txtTedadTolid.Text) * Convert.ToDouble(txtMavadVazn.Text) / 1000).ToString();
            if (txtTedadHofre.Text != "0" & txtTedadHofre.Text != "" & txtMavadVazn.Text != "")
                txtVaznZob.Text = (Convert.ToDouble(txtTedadHofre.Text) * Convert.ToDouble(txtMavadVazn.Text)).ToString();
        }

        private void FrmPLN_SabtBarname_Load(object sender, EventArgs e)
        {
            txtAzDate.Value = DateTime.Now;
            txtTaDate.Value = DateTime.Now;

            ClsTolid ObjTolid = new ClsTolid();
            cmbProccess.DataSource = ObjTolid.Select_Proccess().Tables[0];
            cmbProccess.ValueMember = "ID_process";
            cmbProccess.DisplayMember = "N_process";

            cmbDastgah.DataSource = ObjTolid.Select_Dastgah().Tables[0];
            cmbDastgah.ValueMember = "ID_machine";
            cmbDastgah.DisplayMember = "N_machine";

            cmbUnit.DataSource = ObjTolid.Select_Unit().Tables[0];
            cmbUnit.ValueMember = "C_unit";
            cmbUnit.DisplayMember = "N_unit";

            if (strIsView=="1")
            {
                btnAddH.Enabled = false;
                btnEditH.Enabled = false;
                btnDeleteH.Enabled = false;

                ClsPlanning objPlanning = new ClsPlanning();
                objPlanning.strIdBarnameH = txtIdBarnameH.Text;
                grdSefaresh.DataSource = objPlanning.Select_SefareshBarname().Tables[0];

                ShowData();
            }
        }

        private void cmbDastgah_Enter(object sender, EventArgs e)
        {
            //ClsTolid ObjTolid = new ClsTolid();
            //cmbDastgah.Text = "";
            //ObjTolid.strDastgah = "";
            //ObjTolid.strUnit = strIdUnit;
            //cmbDastgah.DataSource = ObjTolid.Select_Dastgah().Tables[0];
            //cmbDastgah.ValueMember = "ID_machine";
            //cmbDastgah.DisplayMember = "N_machine";
        }

        private void cmbBOM_Enter(object sender, EventArgs e)
        {
            //try
            //{
            //    ClsPlanning objPlanning = new ClsPlanning();
            //    objPlanning.strIdGhete = strIdGhete;
            //    cmbBOM.DataSource = objPlanning.Select_GhetehBom().Tables[0];
            //    cmbBOM.ValueMember = "FK_ID_Bom";
            //    cmbBOM.DisplayMember = "NameBom";
            //}
            //catch { }
        }

        private void cmbBOM_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                ClsPlanning ObjPlanning = new ClsPlanning();
                ObjPlanning.strMavadVazn = txtMavadVazn.Text;
                ObjPlanning.strTedadTolid = txtTedadTolid.Text;
                ObjPlanning.strIdBOM = cmbBOM.SelectedValue.ToString();
                grdBOM.DataSource = ObjPlanning.Select_BOM().Tables[0];
            }
            catch { }
        }

        private void btnSearchBarnameH_Click(object sender, EventArgs e)
        {
            btnAddSefaresh.Enabled = true;
            ClsPlanning objPlanning = new ClsPlanning();
            objPlanning.strIdBarnameH = txtIdBarnameH.Text;
            grdSefaresh.DataSource = objPlanning.Select_SefareshBarname().Tables[0];
            btnEditH.Enabled = true;
            btnDeleteH.Enabled = true;
            btnPrintH.Enabled = true;
            ShowData();
        }

        private void btnEditH_Click(object sender, EventArgs e)
        {
            txtAzDate.Enabled = true;
            txtTaDate.Enabled = true;
            cmbAzShift.Enabled = true;
            cmbTaShift.Enabled = true;
            cmbTedadShift.Enabled = true;
            btnAddH.Enabled = true;
            btnEditH.Enabled = false;
            btnDeleteH.Enabled = false;
            btnPrintH.Enabled = false;

            ClsPlanning objPlanning = new ClsPlanning();
            objPlanning.strIdBarnameH = txtIdBarnameH.Text;
            objPlanning.strIdGhete = strIdGhete;
            objPlanning.strDescription = txtTozihat.Text;
            objPlanning.strUserInsert = ClsMain.StrUsername;
            objPlanning.strDateStart = txtAzDate.Value.ToString().Substring(0, 10);
            objPlanning.strShiftStart = cmbAzShift.Text;
            objPlanning.strDateEnd = txtTaDate.Value.ToString().Substring(0, 10);
            objPlanning.strShiftEnd = cmbTaShift.Text;
            objPlanning.strTedadShift = cmbTedadShift.Text;
            objPlanning.strshiftHour = txtZamanKari.Text;
            if (cmbDastgah.SelectedValue != null)
                objPlanning.strIdMachine = cmbDastgah.SelectedValue.ToString();
            else
                objPlanning.strIdMachine = "";

            if (cmbUnit.SelectedValue != null)
                objPlanning.strIdUnit = cmbUnit.SelectedValue.ToString();
            else
                objPlanning.strIdUnit = "";

            if (cmbBOM.SelectedValue != null)
                objPlanning.strIdBOM = cmbBOM.SelectedValue.ToString();
            else
                objPlanning.strIdBOM = "0";

            if (cmbProccess.SelectedValue != null)
                objPlanning.strIdproccess = cmbProccess.SelectedValue.ToString();
            else
                objPlanning.strIdproccess = "";

            objPlanning.strTedadTolid = txtTedadTolid.Text;
            objPlanning.strzakhire = strzakhire;
            objPlanning.strTeloranceTolid = strTeloranceTolid;
            objPlanning.strMojoodiKhat = strMojoodiKhat;
            objPlanning.strTedadPersonel = txtNafar.Text;
            objPlanning.strTedadHofre = txtTedadHofre.Text;

            MessageBox.Show(objPlanning.Update_BarnameH());
        }

        private void btnDeleteH_Click(object sender, EventArgs e)
        {
            txtAzDate.Enabled = true;
            txtTaDate.Enabled = true;
            cmbAzShift.Enabled = true;
            cmbTaShift.Enabled = true;
            cmbTedadShift.Enabled = true;
            btnAddH.Enabled = true;
            btnEditH.Enabled = false;
            btnDeleteH.Enabled = false;
            btnPrintH.Enabled = false;

            ClsPlanning objPlanning = new ClsPlanning();
            objPlanning.strIdBarnameH = txtIdBarnameH.Text;
            MessageBox.Show(objPlanning.Delete_BarnameH());

            ClearControl();
        }

        private void btnF2Barname_Click(object sender, EventArgs e)
        {
            FrmPLN_ShowBarnameHD frm = new FrmPLN_ShowBarnameHD();
            frm.ShowDialog();
            txtIdBarnameH.Text = frm.strIdBarnameH;
        }

        public void ClearControl()
        {
            txtAzDate.Enabled = true;
            txtTaDate.Enabled = true;
            cmbAzShift.Enabled = true;
            cmbTaShift.Enabled = true;
            cmbTedadShift.Enabled = true;
            //btnAddH.Enabled = true;
            //btnEditH.Enabled = false;
            //btnDeleteH.Enabled = false;
            //btnEditD.Enabled = false;
            //btnDeleteD.Enabled = false;
            txtAzDate.Value = DateTime.Now;
            txtTaDate.Value = DateTime.Now;
            cmbAzShift.SelectedIndex = 0;
            cmbTaShift.SelectedIndex = 0;
            cmbTedadShift.SelectedIndex = 0;

            txtGheteName.Text = "";
            //strIdGhete = "";
            cmbUnit.Text = "";
            //strIdUnit = "";
            txtTozihat.Text = "";
            txtZamanStandard.Text = "";
            //txtZamanKari.Text = "";
            txtTedadHofre.Text = "";
            cmbDastgah.Text = "";
            txtTedadTolid.Text = "";
            txtNafar.Text = "";
            txtTedadHofre.Text = "";
            txtMavadVazn.Text = "";
            txtMavadVaznKol.Text = "";
            txtVaznZob.Text = "";
            txtVaznZob.Text = "";
            txtVaznZob.Text = "";
            txtVaznZob.Text = "";
            txtVaznZob.Text = "";
            txtVaznZob.Text = "";
            txtVaznZob.Text = "";
            txtVaznZob.Text = "";
            txtVaznZob.Text = "";
            txtVaznZob.Text = "";
            //grdBarnameHD.DataSource = null;
            grdBOM.DataSource = null;
            //grdSefaresh.DataSource = null;
            cmbBOM.Text = "";
            cmbSefaresh.Text = "";
            btnAddSefaresh.Enabled = false;
            btnDelSefaresh.Enabled = false;
        }

        private void btnPrintH_Click(object sender, EventArgs e)
        {
            //txtAzDate.Enabled = true;
            //txtTaDate.Enabled = true;
            //cmbAzShift.Enabled = true;
            //cmbTaShift.Enabled = true;
            //cmbTedadShift.Enabled = true;
            //btnAddH.Enabled = true;
            //btnEditH.Enabled = false;
            //btnDeleteH.Enabled = false;
            //btnPrintH.Enabled = false;

            //if (strIdUnit == "120")
            //{
            Report objReport = new Report();

            objReport.Load(ClsPublic.strRepPath + "BarnameTolid.frx");
            objReport.SetParameterValue("IdBarname", txtIdBarnameH.Text);
            objReport.Show();
            //}
        }

        private void cmbSefaresh_Enter(object sender, EventArgs e)
        {
            try
            {
                ClsPlanning objPlanning = new ClsPlanning();
                objPlanning.strIdGhete = strIdGhete;
                cmbSefaresh.DataSource = objPlanning.Select_SefareshGhete().Tables[0];
                cmbSefaresh.ValueMember = "m_name";
                cmbSefaresh.DisplayMember = "order_code";
            }
            catch { }
        }

        private void btnAddSefaresh_Click(object sender, EventArgs e)
        {
            ClsPlanning objPlanning = new ClsPlanning();
            objPlanning.strIdBarnameH = txtIdBarnameH.Text;
            objPlanning.strIdSefaresh = cmbSefaresh.Text;
            MessageBox.Show(objPlanning.Insert_BarnameSefaresh());

            grdSefaresh.DataSource = objPlanning.Select_SefareshBarname().Tables[0];
        }

        private void btnDelSefaresh_Click(object sender, EventArgs e)
        {
            ClsPlanning objPlanning = new ClsPlanning();
            objPlanning.strIdBarnameSefaresh = strIdBarnameSefaresh;
            MessageBox.Show(objPlanning.Delete_BarnameSefaresh());

            objPlanning.strIdBarnameH = txtIdBarnameH.Text;
            grdSefaresh.DataSource = objPlanning.Select_SefareshBarname().Tables[0];
            btnDelSefaresh.Enabled = false;
        }

        private void grdSefaresh_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            strIdBarnameSefaresh = grdSefaresh.Rows[e.RowIndex].Cells["idBarnameSefaresh"].Value.ToString();
            cmbSefaresh.Text = grdSefaresh.Rows[e.RowIndex].Cells["IdSefaresh"].Value.ToString();
            btnDelSefaresh.Enabled = true;
        }

        private void cmbSefaresh_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                lblMoshtari.Text = cmbSefaresh.SelectedValue.ToString();
            }
            catch { }
        }

        private void txtTedadTolid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtMavadVaznKol.Text = (Convert.ToInt32(txtTedadTolid.Text) * Convert.ToInt32(txtMavadVazn.Text)/1000).ToString();
            }
            catch { }
        }

        private void txtZamanKari_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (ClsPublic.strZaman_standard != "0" & ClsPublic.strZaman_standard != null & ClsPublic.strZaman_standard != "")
                    txtZarfiatTolid.Text = Convert.ToInt32((Convert.ToDouble(txtZamanKari.Text) * 3600) / Convert.ToDouble(ClsPublic.strZaman_standard)).ToString();
                else
                    txtZarfiatTolid.Text = "0";
            }
            catch { }
        }

        private void txtTedadHofre_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtVaznZob.Text = (Convert.ToInt32(txtTedadHofre.Text) * Convert.ToInt32(txtMavadVazn.Text)).ToString();
            }
            catch { }           
        }
        public void ShowData()
        {
            ClsPlanning obj = new ClsPlanning();
            DataTable dt = new DataTable();
            obj.strIdBarnameH = txtIdBarnameH.Text;
            dt = obj.Select_BarnameHD().Tables[0];
            txtGheteName.Text = dt.Rows[0]["GheteName"].ToString();
            strIdGhete = dt.Rows[0]["id_Gheteh"].ToString();
            cmbUnit.Text = dt.Rows[0]["NameUnit"].ToString();
            txtAzDate.Text = dt.Rows[0]["DateStart"].ToString();
            txtTaDate.Text = dt.Rows[0]["DateEnd"].ToString();
            cmbAzShift.Text = dt.Rows[0]["ShiftStart"].ToString();
            cmbTaShift.Text = dt.Rows[0]["ShiftEnd"].ToString();
            cmbTedadShift.Text = dt.Rows[0]["TedadShift"].ToString();
            txtZamanKari.Text = dt.Rows[0]["shiftHour"].ToString();
            if (dt.Rows[0]["N_machine"].ToString() != "")
                cmbDastgah.Text = dt.Rows[0]["N_machine"].ToString();
            else
                cmbDastgah.Text = "";
            cmbProccess.Text = dt.Rows[0]["NameProccess"].ToString();
            txtTedadTolid.Text = dt.Rows[0]["TedadTolid"].ToString();
            txtTedadHofre.Text = dt.Rows[0]["TedadHofre"].ToString();
            txtTozihat.Text = dt.Rows[0]["Description"].ToString();

            txtZamanStandard.Text = dt.Rows[0]["Zaman_standard"].ToString();
            txtNafar.Text = dt.Rows[0]["TedadPersonel"].ToString();
            strzakhire = dt.Rows[0]["zakhire"].ToString(); 
            strMojoodiKhat = dt.Rows[0]["MojoodiKhat"].ToString(); 
            strTeloranceTolid = dt.Rows[0]["TeloranceTolid"].ToString();
            txtZarfiatTolid.Text = dt.Rows[0]["ZarfiatTolid"].ToString();
            txtMavadVazn.Text = dt.Rows[0]["MavadVazn"].ToString();

            if (txtMavadVazn.Text != "0" & txtMavadVazn.Text != "" & txtTedadTolid.Text != "")
                txtMavadVaznKol.Text = (Convert.ToDouble(txtTedadTolid.Text) * Convert.ToDouble(txtMavadVazn.Text) / 1000).ToString();
            if (txtTedadHofre.Text != "0" & txtTedadHofre.Text != "" & txtMavadVazn.Text != "")
                txtVaznZob.Text = (Convert.ToDouble(txtTedadHofre.Text) * Convert.ToDouble(txtMavadVazn.Text)).ToString();

            obj.strIdGhete = strIdGhete;
            cmbBOM.DataSource = obj.Select_GhetehBom().Tables[0];
            cmbBOM.ValueMember = "FK_ID_Bom";
            cmbBOM.DisplayMember = "NameBom";
            if (cmbBOM.Items.Count > 0)
            {
                obj.strIdBOM = cmbBOM.Items[0].Value.ToString();
                if (txtMavadVazn.Text != "")
                    obj.strMavadVazn = txtMavadVazn.Text;
                else
                    obj.strMavadVazn = "0";
                if (txtTedadTolid.Text != "")
                    obj.strTedadTolid = txtTedadTolid.Text;
                else
                    obj.strTedadTolid = "0";
                grdBOM.DataSource = obj.Select_BOM().Tables[0];
            }
        }
    }
}

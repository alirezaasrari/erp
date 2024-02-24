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
    public partial class FrmPLN_SabtBarnameKontor : Telerik.WinControls.UI.RadForm
    {
        public FrmPLN_SabtBarnameKontor()
        {
            InitializeComponent();
        }
        public string strIdBarnameH;
        private void btnAddH_Click(object sender, EventArgs e)
        {
            try
            {
                ClsPlanning obj = new ClsPlanning();
                obj.strDateBarname = txtDateBarname.Text;
                obj.strStartTime = txtStartTime.Text;
                obj.strEndTime = txtEndTime.Text;
                obj.strShift = txtShift.Text;
                obj.strZamanEsterahat = txtZamanEsterahat.Text;
                strIdBarnameH = obj.Insert_BarnameKontorH().Tables[0].Rows[0][0].ToString();
                txtIdBarnameH.Text = strIdBarnameH;
                MessageBox.Show("ثبت برنامه انجام شد");
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            try
            {
                ClsPlanning obj = new ClsPlanning();
                obj.strIdBarnameH = txtIdBarnameH.Text;
                obj.strTypePart = (cmbTypePart.SelectedIndex+1).ToString();
                obj.strVaziatKar = cmbVaziatKar.Text;
                obj.strCkalaKontor = lblGhetehCode.Text;
                obj.strIdEmpOperator = txtOperator.Text;
                obj.strZaman = txtZaman.Text;
                obj.strZamanKari = txtZamanKari.Text;
                obj.strZamanPolomp = txtZamanPolomp.Text;
                obj.strTedadTolid = txtTedadTolid.Text;
                obj.strTedadKhat = txtTedadKhat.Text;
                obj.strTedadTest = txtTedadTest.Text;
                obj.strTedadOperator = txtTedadOperator.Text;
                MessageBox.Show(obj.Insert_BarnameKontorD());
                grd.DataSource = obj.Select_BarnameKontorD(txtIdBarnameH.Text).Tables[0];
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnF2Barname_Click(object sender, EventArgs e)
        {
            FrmPLN_SearchBarnameKontor frm = new FrmPLN_SearchBarnameKontor();
            frm.ShowDialog();
            txtIdBarnameH.Text = frm.strIdBarnameH;
            ClsPlanning obj = new ClsPlanning();
            DataTable dt = new DataTable();
            dt = obj.Select_BarnameKontorH(txtIdBarnameH.Text).Tables[0];
            txtDateBarname.Text = dt.Rows[0]["DateBarname"].ToString();
            txtStartTime.Text = dt.Rows[0]["StartTime"].ToString();
            txtEndTime.Text = dt.Rows[0]["EndTime"].ToString();
            txtZamanEsterahat.Text = dt.Rows[0]["ZamanEsterahat"].ToString();
            txtShift.Text = dt.Rows[0]["Shift"].ToString();
            grd.DataSource = obj.Select_BarnameKontorD(txtIdBarnameH.Text).Tables[0];
        }

        private void btnF2Operator_Click(object sender, EventArgs e)
        {
            FrmEdari_ListPersonel frm = new FrmEdari_ListPersonel();
            frm.strTFather = "7";
            frm.ShowDialog();
            txtOperator.Text = frm.strC_personel;
            lblOperatorName.Text = frm.strN_personel;
        }

        private void btnF2Kala_Click(object sender, EventArgs e)
        {
            FrmKala frm = new FrmKala();
            frm.strC_Anbar = "14";
            frm.strC_zAnbar = "35";
            frm.ShowDialog();
            txtGheteName.Text = ClsBuy.N_kala;
            lblGhetehCode.Text = ClsBuy.C_kala;
        }

        private void grd_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "btnEdit")
            {
                ClsPlanning obj = new ClsPlanning();
                obj.strIdBarnameD = grd.CurrentRow.Cells["IdBarnameD"].Value.ToString();
                obj.strZaman = grd.CurrentRow.Cells["Zaman"].Value.ToString();
                obj.strZamanKari = grd.CurrentRow.Cells["ZamanKari"].Value.ToString();
                obj.strZamanPolomp = grd.CurrentRow.Cells["ZamanPolomp"].Value.ToString();
                obj.strTedadTolid = grd.CurrentRow.Cells["TedadTolid"].Value.ToString();
                obj.strTedadKhat = grd.CurrentRow.Cells["TedadKhat"].Value.ToString();
                obj.strTedadTest = grd.CurrentRow.Cells["TedadTest"].Value.ToString();
                obj.strTedadOperator = grd.CurrentRow.Cells["TedadOperator"].Value.ToString();

                MessageBox.Show(obj.Update_BarnameKontorD());
                grd.DataSource = obj.Select_BarnameKontorD(txtIdBarnameH.Text).Tables[0];
            }
            if (e.Column.Name == "btnDelete")
            {
                ClsPlanning obj = new ClsPlanning();

                MessageBox.Show(obj.Delete_BarnameKontorD(grd.CurrentRow.Cells["IdBarnameD"].Value.ToString()));
                grd.DataSource = obj.Select_BarnameKontorD(txtIdBarnameH.Text).Tables[0];
            }
        }

        private void btnEditH_Click(object sender, EventArgs e)
        {
            try
            {
                ClsPlanning obj = new ClsPlanning();
                obj.strIdBarnameH = txtIdBarnameH.Text;
                obj.strDateBarname = txtDateBarname.Text;
                obj.strStartTime = txtStartTime.Text;
                obj.strEndTime = txtEndTime.Text;
                obj.strShift = txtShift.Text;
                obj.strZamanEsterahat = txtZamanEsterahat.Text;
                MessageBox.Show(obj.Update_BarnameKontorH());                
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnDeleteH_Click(object sender, EventArgs e)
        {
            ClsPlanning obj = new ClsPlanning();
            if (MessageBox.Show("آیا از حذف برنامه اطمینان دارید؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show(obj.Delete_BarnameKontorH(txtIdBarnameH.Text));
                ClearData();
            }
        }
        public void ClearData()
        {
            grd.DataSource = null;
            txtStartTime.Text = "";
            txtEndTime.Text = "";
            txtZamanEsterahat.Text = "";
            txtShift.Text = "";
            txtIdBarnameH.Text = "";
            cmbTypePart.Text = "";
            cmbVaziatKar.Text = "";
            txtOperator.Text = "";
            txtOperator.Text = "";
            txtGheteName.Text = "";
            lblGhetehCode.Text = "_";
            txtZaman.Text = "";
            txtZamanKari.Text = "";
            txtZamanPolomp.Text = "";
            txtTedadTolid.Text = "";
            txtTedadKhat.Text = "";
            txtTedadOperator.Text = "";
            txtTedadTest.Text = "";
        }

        private void FrmPLN_SabtBarnameKontor_Load(object sender, EventArgs e)
        {
            txtDateBarname.Value= DateTime.Now;
        }
    }
}

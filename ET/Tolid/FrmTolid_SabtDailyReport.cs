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
    public partial class FrmTolid_SabtDailyReport : Telerik.WinControls.UI.RadForm
    {
        public FrmTolid_SabtDailyReport()
        {
            InitializeComponent();
        }
        
        ClsAnbar ObjAnbar = new ClsAnbar();
        public DataSet ds = new DataSet();
        public DataSet dsTemp = new DataSet();
        public string strOpr, strIdPersonel, strStop, strIdStop, strIdZayeatNamontabegh;
        private void FrmTolid_SabtDailyReport_Load(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            cmbKargah.DataSource = ObjTolid.Select_Unit().Tables[0];
            cmbKargah.ValueMember = "C_unit";
            cmbKargah.DisplayMember = "N_unit";

            dtpDateDailyReport.Value = DateTime.Now;
            grpRadyabi.Enabled = false;
            grpOprTav.Enabled = false;
            grpMontabegh.Enabled = false;
            grpZayeat.Enabled = false;
        }
        private void chkBarnameId_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBarnameId.Checked == true)
            {
                cmbBarname.Enabled = true;
                //dtpDateDailyReport.Enabled = false;
                //cmbShift.Enabled = false;
            }
            else
            {
                cmbBarname.Text = "";
                cmbBarname.Enabled = false;
                dtpDateDailyReport.Enabled = true;
                cmbShift.Enabled = true;
            }
        }
        private void cmbBarname_Enter(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            cmbBarname.Text = "";
            ObjTolid.strBarname = "";
            ObjTolid.strDateBarname = dtpDateDailyReport.Value.ToString().Substring(0, 10);
            ObjTolid.strUnit = cmbKargah.SelectedValue.ToString();
            ObjTolid.strShift = cmbShift.Text;

            cmbBarname.DataSource = ObjTolid.Select_Barname().Tables[0];
            cmbBarname.ValueMember = "IdBarnameD";
            cmbBarname.DisplayMember = "IdBarnameD";
        }
        private void txtNKala_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmKala frm = new FrmKala();
                frm.strC_Anbar = "13,14,19,16";
                frm.ShowDialog();
                txtNKala.Text = ClsBuy.N_kala;
                lblCKala.Text = ClsBuy.C_kala;
            }
        }
        private void cmbProccess_Enter(object sender, EventArgs e)
        {
            try
            {
                ClsTolid ObjTolid = new ClsTolid();
                cmbProccess.Text = "";
                ObjTolid.strUnit = cmbKargah.SelectedValue.ToString();
                cmbProccess.DataSource = ObjTolid.Select_Proccess().Tables[0];
                cmbProccess.ValueMember = "ID_process";
                cmbProccess.DisplayMember = "N_process";
            }
            catch { }
        }
        private void cmbKargah_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnablaControl();
        }
        private void cmbArm_Enter(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            cmbArm.Text = "";
            cmbArm.DataSource = ObjTolid.Select_Arm().Tables[0];
            cmbArm.ValueMember = "ID_arm";
            cmbArm.DisplayMember = "N_arm";
        }
        private void btnAddRadyabi_Click(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            //if (cmbKargah.SelectedValue.ToString() == "200")
            //{
            //    if (txtIdRadyabi.TextLength != 11)
            //    {
            //        MessageBox.Show("طول کد ردیابی باید 11 عدد باشد");
            //        return;
            //    }
            //}
            //else
            //{
            //    if (txtIdRadyabi.TextLength != 10)
            //    {
            //        MessageBox.Show("طول کد ردیابی باید 10 عدد باشد");
            //        return;
            //    }
            //}
            ObjTolid.strIdRadyabi=txtIdRadyabi.Text;
            ObjTolid.strIdDailyReport = txtIdDailyReport.Text;
            MessageBox.Show(ObjTolid.INS_Radyabi_DailyReport());
            ObjTolid.strIdRadyabi = "";
            grdRadyabi.DataSource = ObjTolid.Select_Radyabi_DailyReport().Tables[0];
            txtIdRadyabi.Text = "";
        }
        private void btnAddDailyReport_Click(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            try
            {
                if (cmbBarname.SelectedValue != null)
                    ObjTolid.strBarname = cmbBarname.SelectedValue.ToString();
                else
                    ObjTolid.strBarname = "";
                ObjTolid.strtarikh = dtpDateDailyReport.Value.ToString().Substring(0, 10);
                ObjTolid.strShift = cmbShift.Text;
                if (cmbDastgah.SelectedValue != null)
                    ObjTolid.strDastgah = cmbDastgah.SelectedValue.ToString();
                else
                    ObjTolid.strDastgah = "";

                ClsTakvin objtkv = new ClsTakvin();
                objtkv.strSearchGhetehCode = lblCKala.Text.Substring(0, 9) + cmbProccess.SelectedValue.ToString();
                if (objtkv.searchGheteh().Tables[0].Rows.Count > 0)
                {
                    ObjTolid.strPart_process = objtkv.strSearchGhetehCode;
                }
                else
                {
                    if (MessageBox.Show("این قطعه با این فرایند وجود ندارد ثبت انجام شود؟", "هشدار", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        ObjTolid.strPart_process = lblCKala.Text;
                    else
                        return;
                }

                ObjTolid.strtedad = txtTedadSalem.Text;
                
                if (cmbProccess.SelectedValue != null)
                    ObjTolid.strProc = cmbProccess.SelectedValue.ToString();
                else
                    ObjTolid.strProc = "";
                ObjTolid.strUnit = cmbKargah.SelectedValue.ToString();
                if (cmbArm.SelectedValue != null)
                    ObjTolid.strArm = cmbArm.SelectedValue.ToString();
                else
                    ObjTolid.strArm = "";
                ObjTolid.strzaman_kari = txtZamanKariOpr.Text = txtZamanKari.Text;
                ObjTolid.strv_zayeat = txtVaznZayeat.Text;
                ObjTolid.strv_rahgah = txtRahgah.Text;
                ObjTolid.strv_gheteh = txtVaznGhete.Text;
                ObjTolid.strTedad_hofre = txtHofre.Text;
                ObjTolid.strt_nafar = txtNafar.Text;
                ObjTolid.strTozihat = txtTozihat.Text;
                ObjTolid.ShenaseKitInt = txtIdShenase.Text;

                ObjTolid.strTekrarKontor = txtTekrarKontor.Text;
                ObjTolid.strTedadKontor = txtTedadKontor.Text;
                ObjTolid.strtedadAbi = txtTedadAbi.Text;
                ObjTolid.strtedadMeshki = txtTedadMeshki.Text;
                ObjTolid.strTedadTestKontor = txtTedadTestKontor.Text;
                ObjTolid.strTedadTestKhat = txtTedadTestKhat.Text;
                ObjTolid.strTedadTolidEsmi = txtTedadTolidEsmi.Text;
                ObjTolid.strTedadMotefareghe = txtTedadMotefareghe.Text;
                ObjTolid.strZamanTest = txtZamanTest.Text;
                ObjTolid.strTypeKontor = cmbTypeKontor.Text;
                ObjTolid.strZamanKol = txtZamanKol.Text;

                ObjTolid.strIdDailyReport = txtIdDailyReport.Text = ObjTolid.Select_IdDailyReport().Tables[0].Rows[0][0].ToString();

                MessageBox.Show(ObjTolid.INS_DailyReport());
                grpHeader1.Enabled = false;
                grpHeader2.Enabled = false;
                btnRefresh.Enabled = true;

                grpRadyabi.Enabled = true;
                grpOprTav.Enabled = true;
                grpMontabegh.Enabled = true;
                grpZayeat.Enabled = true;
                ActiveControl = txtIdRadyabi;
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }
        private void btnDelRadyabi_Click(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            ObjTolid.strIdDailyReport=txtIdDailyReport.Text;
            ObjTolid.strIdRadyabi=txtIdRadyabi.Text;
            MessageBox.Show(ObjTolid.DEL_RadyabiDailyReport());
            ObjTolid.strIdRadyabi = "";
            grdRadyabi.DataSource = ObjTolid.Select_Radyabi_DailyReport().Tables[0];
            txtIdRadyabi.Text = "";
        }
        private void grdRadyabi_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            txtIdRadyabi.Text = grdRadyabi.Rows[e.RowIndex].Cells["IdRadyabi"].Value.ToString();          
        }
        private void btnAddDarkhast_Click(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            ObjTolid.strIdDailyReport=txtIdDailyReport.Text;
            ObjTolid.strIdDarkhast = txtIdDarkhast.Text;
            MessageBox.Show(ObjTolid.INS_Radyabi_Anbar());
            ObjTolid.strIdDarkhast = "";
            grdDarkhast.DataSource = ObjTolid.Select_Radyabi_Anbar().Tables[0];
            txtIdDarkhast.Text = "";
        }
        private void btnDelDarkhast_Click(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            ObjTolid.strIdDailyReport=txtIdDailyReport.Text;
            ObjTolid.strIdDarkhast=txtIdDarkhast.Text;
            MessageBox.Show(ObjTolid.DEL_Radyabi_Anbar());
            ObjTolid.strIdDarkhast = "";
            grdDarkhast.DataSource = ObjTolid.Select_Radyabi_Anbar().Tables[0];
            txtIdDarkhast.Text = "";
        }
        private void grdDarkhast_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            txtIdDarkhast.Text = grdDarkhast.Rows[e.RowIndex].Cells["IdDarkhast"].Value.ToString();
        }
        private void btnSearchBarname_Click(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            try
            {
                if (loadDataDailyReport("b") == 0)
                {
                    //ObjTolid.strBarname = cmbBarname.SelectedValue.ToString();
                    ObjTolid.strBarname = cmbBarname.Text;
                    ds.Clear();
                    ds = ObjTolid.Select_Barname();

                    lblCKala.Text = ObjAnbar.strC_Kala = ds.Tables[0].Rows[0]["GhetehCode"].ToString();
                    ObjTolid.strProc = ds.Tables[0].Rows[0]["FK_ID_process"].ToString();
                    ObjTolid.strDastgah = ds.Tables[0].Rows[0]["ID_machine"].ToString();

                    txtTedadSalem.Text = ds.Tables[0].Rows[0]["TedadTolid"].ToString();
                    txtZamanKari.Text = ds.Tables[0].Rows[0]["ShiftHour"].ToString();
                    txtNafar.Text = ds.Tables[0].Rows[0]["TedadPersonel"].ToString();

                    ObjAnbar.strC_Anbar = "13,14,19,16";
                    dsTemp = ObjAnbar.SelectKala();
                    txtNKala.Text = dsTemp.Tables[0].Rows[0]["N_Kala"].ToString();

                    cmbProccess.Text = "";
                    cmbProccess.DataSource = ObjTolid.Select_Proccess().Tables[0];
                    cmbProccess.ValueMember = "ID_process";
                    cmbProccess.DisplayMember = "N_process";

                    cmbDastgah.Text = "";
                    cmbDastgah.DataSource = ObjTolid.Select_Dastgah().Tables[0];
                    cmbDastgah.ValueMember = "ID_machine";
                    cmbDastgah.DisplayMember = "N_machine";

                    cmbDastgah.Enabled = false;
                    txtNKala.Enabled = false;
                    cmbProccess.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("خطا در نمایش برنامه");
            }
        }
        private void btnEditDailyReport_Click(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            try
            {
                ObjTolid.strIdDailyReport = txtIdDailyReport.Text;
                ObjTolid.strtarikh = dtpDateDailyReport.Value.ToString().Substring(0, 10);
                ObjTolid.strShift = cmbShift.Text;
                if (cmbDastgah.SelectedValue != null)
                    ObjTolid.strDastgah = cmbDastgah.SelectedValue.ToString();
                else
                    ObjTolid.strDastgah = "";
                ObjTolid.strPart_process = lblCKala.Text;
                ObjTolid.strtedad = txtTedadSalem.Text;
                ObjTolid.strProc = cmbProccess.SelectedValue.ToString();
                if (cmbArm.SelectedValue != null)
                    ObjTolid.strArm = cmbArm.SelectedValue.ToString();
                else
                    ObjTolid.strArm = "";
                ObjTolid.strzaman_kari = txtZamanKari.Text;
                ObjTolid.strv_zayeat = txtVaznZayeat.Text;
                ObjTolid.strv_rahgah = txtRahgah.Text;
                ObjTolid.strv_gheteh = txtVaznGhete.Text;
                ObjTolid.strTedad_hofre = txtHofre.Text;
                ObjTolid.strt_nafar = txtNafar.Text;
                ObjTolid.strTozihat = txtTozihat.Text;
                ObjTolid.ShenaseKitInt = txtIdShenase.Text;

                ObjTolid.strTekrarKontor = txtTekrarKontor.Text;
                ObjTolid.strTedadKontor = txtTedadKontor.Text;
                ObjTolid.strtedadAbi = txtTedadAbi.Text;
                ObjTolid.strtedadMeshki = txtTedadMeshki.Text;
                ObjTolid.strTedadTestKontor = txtTedadTestKontor.Text;
                ObjTolid.strTedadTestKhat = txtTedadTestKhat.Text;
                ObjTolid.strTedadTolidEsmi = txtTedadTolidEsmi.Text;
                ObjTolid.strTedadMotefareghe = txtTedadMotefareghe.Text;
                ObjTolid.strZamanTest = txtZamanTest.Text;
                ObjTolid.strTypeKontor = cmbTypeKontor.Text;
                ObjTolid.strZamanKol = txtZamanKol.Text;

                if (MessageBox.Show("آیا از ویرایش گزارش کار اطمینان دارید؟", "اخطار", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    MessageBox.Show(ObjTolid.Upd_DailyReport());
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }
        private void btnDelDailyReport_Click(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            ObjTolid.strIdDailyReport = txtIdDailyReport.Text;
            if (MessageBox.Show("آیا از حذف گزارش کار اطمینان دارید؟", "اخطار", MessageBoxButtons.YesNo) == DialogResult.Yes)
                MessageBox.Show(ObjTolid.DelDailyReport());
            btnRefresh_Click(sender, e);
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            grpHeader1.Enabled = true;
            grpHeader2.Enabled = true;
            grpRadyabi.Enabled = false;
            grpOprTav.Enabled = false;
            grpZayeat.Enabled = false;
            grpMontabegh.Enabled = false;

            cmbDastgah.Enabled = true;
            txtNKala.Enabled = true;
            cmbProccess.Enabled = true;
            EnablaControl();

            cmbDastgah.Text = "";
            txtNKala.Text = "";
            lblCKala.Text = "_";
            cmbProccess.Text = "";
            txtZamanKari.Text = "";
            txtVaznGhete.Text = "";
            txtNafar.Text = "";
            txtRahgah.Text = "";
            txtHofre.Text = "";
            txtTedadSalem.Text = "";
            txtTedadAbi.Text = "";
            txtTedadMeshki.Text = "";
            cmbArm.Text = "";
            txtVaznZayeat.Text = "";
            txtTozihat.Text = "";
            txtIdShenase.Text = "";
            txtIdDailyReport.Text = "";
            grdRadyabi.DataSource = null;
            grdDarkhast.DataSource = null;
            grdOpr.DataSource = null;
            grdTavaghof.DataSource = null;
            grdZayeat.DataSource = null;
            grdMontabegh.DataSource = null;
            txtIdRadyabi.Text = "";
            txtIdDarkhast.Text = "";
            txtOperator.Text = "";
            txtZamanKariOpr.Text = "";
            cmbTavaghof.Text = "";
            txtZamanTavaghof.Text = "";
            cmbShZayeat.Text = "";
            cmbEltZayeat.Text = "";
            cmbAmelZ.Text = "";
            txtTedadZ.Text = "";
            cmbShMontabegh.Text = "";
            cmbEltMontabegh.Text = "";
            cmbAmelN.Text = "";
            txtTedadN.Text = "";
            txtTekrarKontor.Text = "";
            txtTedadKontor.Text = "";
            txtTedadTestKontor.Text = "";
            txtTedadTestKhat.Text = "";
            txtTedadTolidEsmi.Text = "";
            txtTedadMotefareghe.Text = "";
            txtZamanTest.Text = "";
            cmbTypeKontor.Text = "";
            //ObjTolid.strProc = "";
            //ObjTolid.strDastgah = "";
        }
        private void cmbDastgah_Enter(object sender, EventArgs e)
        {
            try
            {
                ClsTolid ObjTolid = new ClsTolid();
                cmbDastgah.Text = "";
                ObjTolid.strDastgah = "";
                ObjTolid.strUnit = cmbKargah.SelectedValue.ToString();
                cmbDastgah.DataSource = ObjTolid.Select_Dastgah().Tables[0];
                cmbDastgah.ValueMember = "ID_machine";
                cmbDastgah.DisplayMember = "N_machine";
            }
            catch { }
        }
        private void cmbTavaghof_Enter(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            cmbTavaghof.DataSource = ObjTolid.Select_Stop().Tables[0];
            cmbTavaghof.ValueMember = "ID_stop";
            cmbTavaghof.DisplayMember = "Desc_stop";
        }
        private void btnAddOpr_Click(object sender, EventArgs e)
        {
            try
            {
                ClsTolid ObjTolid = new ClsTolid();
                ObjTolid.strIdDailyReport = txtIdDailyReport.Text;
                if (ObjTolid.Select_CountOprDailyReport().Tables[0].Rows.Count>0)
                    if (Convert.ToInt16(ObjTolid.Select_CountOprDailyReport().Tables[0].Rows[0][0].ToString()) == 0)
                    {
                        MessageBox.Show("تعداد اپراتور بیشتر از تعداد مجاز است");
                        return;
                    }
                ObjTolid.strIdPersonel = strIdPersonel;
                ObjTolid.strzaman_kari = txtZamanKariOpr.Text;
                ObjTolid.strtedad = txtTedadOpr.Text;
                //if (txtTedadSalem.Text.Length == 0)
                //{
                //    txtTedadSalem.Text = txtTedadOpr.Text;
                //}
                //else
                //{
                //    txtTedadSalem.Text = (Convert.ToInt16(txtTedadSalem.Text) + Convert.ToInt16(txtTedadOpr.Text)).ToString();
                //}
                txtTedadSalem.Text = ObjTolid.Select_TedadeTolideOperator().Tables[0].Rows[0][0].ToString();
               // txtTedadSalem.Text = txtTedadSalem.Text + txtTedadOpr.Text;
                if (lblOperatorName.Text=="-")
                {
                    MessageBox.Show("اپراتور نامعتبر");
                    return;
                }
                MessageBox.Show(ObjTolid.INS_OprDailyReport());

                grdOpr.DataSource = ObjTolid.Select_Opr().Tables[0];
            }
            catch { }
        }
        private void btnAddTavaghof_Click(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            ObjTolid.strIdDailyReport = txtIdDailyReport.Text;
            ObjTolid.strStop = txtTavaghofCode.Text.Trim();
            if(ObjTolid.Select_Stop().Tables[0].Rows.Count==0)
            {
                MessageBox.Show("کد توقف نامعتبر");
                return;
            }
            ObjTolid.strZamanStop = txtZamanTavaghof.Text;
            MessageBox.Show(ObjTolid.INS_StopDailyReport());
            grdTavaghof.DataSource = ObjTolid.Select_StopDailyReport().Tables[0];
        }
        private void btnDelOpr_Click(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            ObjTolid.strIdDailyReport = txtIdDailyReport.Text;
            ObjTolid.strOpr = strOpr;
            MessageBox.Show(ObjTolid.DEL_OprDailyReport());
            grdOpr.DataSource = ObjTolid.Select_Opr().Tables[0];
            txtOperator.Text = " ";
            txtZamanKariOpr.Text = "";
            txtTedadSalem.Text = ObjTolid.Select_TedadeTolideOperator().Tables[0].Rows[0][0].ToString();
        }
        private void grdTavaghof_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            strIdStop = grdTavaghof.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            cmbTavaghof.SelectedValue = grdTavaghof.Rows[e.RowIndex].Cells["FK_ID_stop"].Value;
            txtTavaghofCode.Text = grdTavaghof.Rows[e.RowIndex].Cells["FK_ID_stop"].Value.ToString();
            txtZamanTavaghof.Text = grdTavaghof.Rows[e.RowIndex].Cells["zaman_stop"].Value.ToString();
        }
        private void grdOpr_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            strOpr = grdOpr.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            txtOperator.Text = grdOpr.Rows[e.RowIndex].Cells["FK_ID_oper"].Value.ToString();
            if (grdOpr.Rows[e.RowIndex].Cells["Tedad"].Value == null)
            {
                txtTedadOpr.Text = "0";
            }
            else
            {
                txtTedadOpr.Text = grdOpr.Rows[e.RowIndex].Cells["Tedad"].Value.ToString();
            }
            
            //strIdPersonel = grdOpr.Rows[e.RowIndex].Cells["FK_ID_oper"].Value.ToString();
            txtZamanKariOpr.Text = grdOpr.Rows[e.RowIndex].Cells["zaman_kari"].Value.ToString();
        }
        private void btnDelTavaghof_Click(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            ObjTolid.strIdStop = strIdStop;
            ObjTolid.strIdDailyReport = txtIdDailyReport.Text;
            MessageBox.Show(ObjTolid.DEL_StopDailyReport());
            grdTavaghof.DataSource = ObjTolid.Select_StopDailyReport().Tables[0];
            cmbTavaghof.Text = "";
            txtZamanTavaghof.Text = "";
            txtTavaghofCode.Text = " ";
        }
        private void cmbShZayeat_Enter(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            ObjTolid.strUnit = cmbKargah.SelectedValue.ToString();
            cmbShZayeat.DataSource = ObjTolid.Select_shenase().Tables[0];
            cmbShZayeat.ValueMember = "ID_shenase";
            cmbShZayeat.DisplayMember = "N_shenase";
        }
        private void cmbEltZayeat_Enter(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            ObjTolid.strUnit = cmbKargah.SelectedValue.ToString();
            cmbEltZayeat.DataSource = ObjTolid.Select_Elat().Tables[0];
            cmbEltZayeat.ValueMember = "ID_ellat";
            cmbEltZayeat.DisplayMember = "desc_ellat";
        }
        private void cmbShMontabegh_Enter(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            ObjTolid.strUnit = cmbKargah.SelectedValue.ToString();
            cmbShMontabegh.DataSource = ObjTolid.Select_shenase().Tables[0];
            cmbShMontabegh.ValueMember = "ID_shenase";
            cmbShMontabegh.DisplayMember = "N_shenase";
        }
        private void cmbEltMontabegh_Enter(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            ObjTolid.strUnit = cmbKargah.SelectedValue.ToString();
            cmbEltMontabegh.DataSource = ObjTolid.Select_Elat().Tables[0];
            cmbEltMontabegh.ValueMember = "ID_ellat";
            cmbEltMontabegh.DisplayMember = "desc_ellat";
        }
        private void btnAddZayeat_Click(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            try
            {
                if (lblShZayeat.Text=="-")
                {
                    MessageBox.Show("شناسه ضایعات را تعیین کنید");
                    return;
                }
                ObjTolid.strIdDailyReport = txtIdDailyReport.Text;
                ObjTolid.strShenase = lblShZayeat.Text;
                ObjTolid.strElat = lblEltZayeat.Text;
                ObjTolid.strAmel = cmbAmelZ.Text;
                ObjTolid.strtedad = txtTedadZ.Text;
                ObjTolid.strIsZayeat = "1";
                ObjTolid.strIsNamontabegh = "0";
                MessageBox.Show(ObjTolid.INS_ZayeatNamontabegh_DailyReport());
                grdZayeat.DataSource = ObjTolid.Select_ZayeatNamontabegh_DailyReport().Tables[0];
            }
            catch
            {
                MessageBox.Show("خطا در ثبت اطلاعات");
            }
        }
        private void btnSearchDailyReport_Click(object sender, EventArgs e)
        {
            //ClsTolid ObjTolid = new ClsTolid();
            try
            {
                if (txtIdDailyReport.Text =="")
                {
                    MessageBox.Show("گزارش روزانه مورد نظر را انتخاب کنید");
                    return;
                }
                loadDataDailyReport("d");                
            }
            catch { }
        }
        private void txtIdDailyReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                ClsTolid.strShiftST = cmbShift.Text;
                ClsTolid.strUnitST = cmbKargah.SelectedValue.ToString();
                FrmTolidShowDailyReport frm = new FrmTolidShowDailyReport(this);
                frm.ShowDialog();
            }
        }
        private void cmbAmelZ_Enter(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            cmbAmelZ.DataSource = ObjTolid.Select_Amel().Tables[0];
            cmbAmelZ.ValueMember = "ID_amel";
            cmbAmelZ.DisplayMember = "ID_amel";
        }
        private void btnDelZayeat_Click(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            ObjTolid.strIdDailyReport = txtIdDailyReport.Text;
            ObjTolid.strIsZayeat = "1";
            ObjTolid.strIdZayeatNamontabegh = strIdZayeatNamontabegh;
            MessageBox.Show(ObjTolid.Del_ZayeatNamontabegh_DailyReport());
            grdZayeat.DataSource = ObjTolid.Select_ZayeatNamontabegh_DailyReport().Tables[0];
            cmbShZayeat.Text = "";
            lblShZayeat.Text = "-";
            cmbEltZayeat.Text = "";
            lblEltZayeat.Text = "-";
            cmbAmelZ.Text = "";
            txtTedadZ.Text = "";
        }
        private void grdZayeat_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                strIdZayeatNamontabegh = grdZayeat.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                lblShZayeat.Text = grdZayeat.Rows[e.RowIndex].Cells["FK_ID_shenase"].Value.ToString();
                cmbShZayeat.Text = grdZayeat.Rows[e.RowIndex].Cells["N_shenase"].Value.ToString();
                lblEltZayeat.Text = grdZayeat.Rows[e.RowIndex].Cells["FK_ID_ellat"].Value.ToString();
                cmbEltZayeat.Text = grdZayeat.Rows[e.RowIndex].Cells["desc_ellat"].Value.ToString();
                cmbAmelZ.Text = grdZayeat.Rows[e.RowIndex].Cells["FK_ID_amel"].Value.ToString();
                txtTedadZ.Text = grdZayeat.Rows[e.RowIndex].Cells["tedad"].Value.ToString();
            }
            catch { }
        }
        private void grdMontabegh_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                strIdZayeatNamontabegh = grdMontabegh.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                lblShMontabegh.Text = grdMontabegh.Rows[e.RowIndex].Cells["FK_ID_shenase"].Value.ToString();
                cmbShMontabegh.Text = grdMontabegh.Rows[e.RowIndex].Cells["N_shenase"].Value.ToString();
                lblEltMontabegh.Text = grdMontabegh.Rows[e.RowIndex].Cells["FK_ID_ellat"].Value.ToString();
                cmbEltMontabegh.Text = grdMontabegh.Rows[e.RowIndex].Cells["desc_ellat"].Value.ToString();
                cmbAmelN.Text = grdMontabegh.Rows[e.RowIndex].Cells["FK_ID_amel"].Value.ToString();
                txtTedadN.Text = grdMontabegh.Rows[e.RowIndex].Cells["tedad"].Value.ToString();
            }
            catch { }
        }
        private void btnAddMontabegh_Click(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            try
            {
                if (lblShMontabegh.Text == "-")
                {
                    MessageBox.Show("شناسه نامنطبق را تعیین کنید");
                    return;
                }
                ObjTolid.strIdDailyReport = txtIdDailyReport.Text;
                ObjTolid.strIdZayeatNamontabegh = strIdZayeatNamontabegh;
                ObjTolid.strShenase = lblShMontabegh.Text;
                ObjTolid.strElat = lblEltMontabegh.Text;
                ObjTolid.strAmel = cmbAmelN.Text;
                ObjTolid.strtedad = txtTedadN.Text;
                ObjTolid.strIsZayeat = "0";
                ObjTolid.strIsNamontabegh = "1";
                MessageBox.Show(ObjTolid.INS_ZayeatNamontabegh_DailyReport());
                grdMontabegh.DataSource = ObjTolid.Select_ZayeatNamontabegh_DailyReport().Tables[0];
            }
            catch
            {
                MessageBox.Show("خطا در ثبت اطلاعات");
            }
        }
        private void btnDelMontabegh_Click(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            ObjTolid.strIdDailyReport = txtIdDailyReport.Text;
            ObjTolid.strIsNamontabegh = "1";
            ObjTolid.strIdZayeatNamontabegh = strIdZayeatNamontabegh;
            MessageBox.Show(ObjTolid.Del_ZayeatNamontabegh_DailyReport());
            grdMontabegh.DataSource = ObjTolid.Select_ZayeatNamontabegh_DailyReport().Tables[0];
            cmbShMontabegh.Text = "";
            lblShMontabegh.Text = "-";
            cmbEltMontabegh.Text = "";
            lblEltMontabegh.Text = "-";
            cmbAmelN.Text = "";
            txtTedadN.Text = "";
        }
        private void cmbAmelN_Enter(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            cmbAmelN.DataSource = ObjTolid.Select_Amel().Tables[0];
            cmbAmelN.ValueMember = "ID_amel";
            cmbAmelN.DisplayMember = "ID_amel";
        }
        public void EnablaControl()
        {
            cmbAmelN.Text = "";
            cmbAmelZ.Text = "";
            cmbEltMontabegh.Text = "";
            cmbEltZayeat.Text = "";
            cmbShZayeat.Text = "";
            cmbShMontabegh.Text = "";
            cmbTavaghof.Text = "";
            lblShZayeat.Text = "-";
            lblShMontabegh.Text = "-";
            lblEltZayeat.Text = "-";
            lblEltMontabegh.Text = "-";
            ClsTolid ObjTolid = new ClsTolid();
            try
            {
                ObjTolid.strUnit = cmbKargah.SelectedValue.ToString();
                chkBarnameId.Checked = false;
                cmbProccess.Enabled = true;
                txtNKala.Enabled = true;
                //if (cmbKargah.SelectedValue.ToString() == "155")
                //    grpKontor.Enabled = true;
                //else
                //    grpKontor.Enabled = false;
                if (cmbKargah.SelectedValue.ToString() == "150")
                {
                    txtIdShenase.Enabled = true;
                }
                else
                {
                    txtIdShenase.Enabled = false;
                }

                if (cmbKargah.SelectedValue.ToString() == "120" || cmbKargah.SelectedValue.ToString() == "160"
                || cmbKargah.SelectedValue.ToString() == "150" || cmbKargah.SelectedValue.ToString() == "145")
                    cmbArm.Enabled = false;
                else
                    cmbArm.Enabled = true;

                if (cmbKargah.SelectedValue.ToString() == "120" || cmbKargah.SelectedValue.ToString() == "150"
                 || cmbKargah.SelectedValue.ToString() == "145" || cmbKargah.SelectedValue.ToString() == "140"
                 || cmbKargah.SelectedValue.ToString() == "200" || cmbKargah.SelectedValue.ToString() == "130"
                 || cmbKargah.SelectedValue.ToString() == "110" || cmbKargah.SelectedValue.ToString() == "999")
                    txtVaznZayeat.Enabled = false;
                else
                    txtVaznZayeat.Enabled = true;

                if (cmbKargah.SelectedValue.ToString() == "160" || cmbKargah.SelectedValue.ToString() == "150"
                 || cmbKargah.SelectedValue.ToString() == "145" || cmbKargah.SelectedValue.ToString() == "140"
                 || cmbKargah.SelectedValue.ToString() == "200" || cmbKargah.SelectedValue.ToString() == "130"
                 || cmbKargah.SelectedValue.ToString() == "110" || cmbKargah.SelectedValue.ToString() == "999")
                {
                    txtRahgah.Enabled = false;
                    txtVaznGhete.Enabled = false;
                    txtHofre.Enabled = false;
                }
                else
                {
                    txtRahgah.Enabled = true;
                    txtVaznGhete.Enabled = true;
                    txtHofre.Enabled = true;
                }

                if (cmbKargah.SelectedValue.ToString() == "130" || cmbKargah.SelectedValue.ToString() == "110"
                 || cmbKargah.SelectedValue.ToString() == "999")
                    cmbDastgah.Enabled = false;
                else
                    cmbDastgah.Enabled = true;
                ////////////////////////////////////////////////               
            }
            catch { }
        }
        private void btnF2DailyReport_Click(object sender, EventArgs e)
        {
            ClsTolid.strShiftST = cmbShift.Text;
            ClsTolid.strUnitST = cmbKargah.SelectedValue.ToString();
            FrmTolidShowDailyReport frm = new FrmTolidShowDailyReport(this);
            frm.ShowDialog();
        }
        private void btnF2Kala_Click(object sender, EventArgs e)
        {
            FrmKala frm = new FrmKala();
            frm.strC_Anbar = "13,14,19,16";
            frm.ShowDialog();
            txtNKala.Text = ClsBuy.N_kala;
            lblCKala.Text = ClsBuy.C_kala;
        }
        private void btnF2Operator_Click(object sender, EventArgs e)
        {
            FrmEdari_ListPersonel frm = new FrmEdari_ListPersonel();
            frm.strTFather = "7";
            frm.ShowDialog();
            txtOperator.Text = frm.strC_personel;
            //strIdPersonel = frm.strC_personel;
        }
        private void txtOperator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmEdari_ListPersonel frm = new FrmEdari_ListPersonel();
                frm.strTFather = "7";
                frm.ShowDialog();
                txtOperator.Text = frm.strN_personel;
                strIdPersonel = frm.strC_personel;
            }
        }
        private void txtOperator_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ClsEdari objEdari = new ClsEdari();
                objEdari.strC_personel = strIdPersonel = txtOperator.Text;
                lblOperatorName.Text = objEdari.Select_Personel().Tables[0].Rows[0]["NamePersonel"].ToString();
            }
            catch 
            {
                lblOperatorName.Text = "-";
            }
        }
        private void cmbTavaghof_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtTavaghofCode.Text = cmbTavaghof.SelectedValue.ToString();
                lblTavaghofName.Text = cmbTavaghof.Text;
            }
            catch { }
        }
        private void txtTavaghofCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ClsTolid ObjTolid = new ClsTolid();
                ObjTolid.strStop = txtTavaghofCode.Text.Trim();
                lblTavaghofName.Text = ObjTolid.Select_Stop().Tables[0].Rows[0]["Desc_stop"].ToString();
            }
            catch { }
        }
        private void cmbShZayeat_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                lblShZayeat.Text = cmbShZayeat.SelectedValue.ToString();
            }
            catch { }
        }
        private void cmbEltZayeat_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                lblEltZayeat.Text = cmbEltZayeat.SelectedValue.ToString();
            }
            catch { }
        }
        private void cmbShMontabegh_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                lblShMontabegh.Text = cmbShMontabegh.SelectedValue.ToString();
            }
            catch { }
        }
        private void cmbEltMontabegh_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                lblEltMontabegh.Text = cmbEltMontabegh.SelectedValue.ToString();
            }
            catch { }
        }
        private void btnUpdateOpr_Click(object sender, EventArgs e)
        {
            try
            {
                ClsTolid ObjTolid = new ClsTolid();
                ObjTolid.strIdDailyReport = txtIdDailyReport.Text;
                ObjTolid.strOpr = strOpr;
                ObjTolid.strIdPersonel = strIdPersonel;
                ObjTolid.strzaman_kari = txtZamanKariOpr.Text;
                ObjTolid.strtedad = txtTedadOpr.Text;
                txtTedadSalem.Text = ObjTolid.Select_TedadeTolideOperator().Tables[0].Rows[0][0].ToString();
                if (lblOperatorName.Text == "-")
                {
                    MessageBox.Show("اپراتور نامعتبر");
                    return;
                }
                MessageBox.Show(ObjTolid.Update_DailyOpr());

                grdOpr.DataSource = ObjTolid.Select_Opr().Tables[0];
            }
            catch { }
        }
        private void btnUpdateTavaghof_Click(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            ObjTolid.strIdDailyReport = txtIdDailyReport.Text;
            ObjTolid.strIdStop = strIdStop;
            ObjTolid.strStop = txtTavaghofCode.Text.Trim();
            ObjTolid.strZamanStop = txtZamanTavaghof.Text;
            MessageBox.Show(ObjTolid.Update_DailyStop());
            grdTavaghof.DataSource = ObjTolid.Select_StopDailyReport().Tables[0];
        }

        private void grdOpr_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateZayeat_Click(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            try
            {
                ObjTolid.strIdZayeatNamontabegh = strIdZayeatNamontabegh;
                ObjTolid.strIdDailyReport = txtIdDailyReport.Text;
                ObjTolid.strShenase = lblShZayeat.Text;
                ObjTolid.strElat = lblEltZayeat.Text;
                ObjTolid.strAmel = cmbAmelZ.Text;
                ObjTolid.strtedad = txtTedadZ.Text;
                ObjTolid.strIsZayeat = "1";
                ObjTolid.strIsNamontabegh = "0";
                MessageBox.Show(ObjTolid.Update_ZayeatNamontabegh_DailyReport());
                grdZayeat.DataSource = ObjTolid.Select_ZayeatNamontabegh_DailyReport().Tables[0];
            }
            catch
            {
                MessageBox.Show("خطا در ثبت اطلاعات");
            }
        }
        private void btnUpdateMontabegh_Click(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            try
            {
                ObjTolid.strIdZayeatNamontabegh = strIdZayeatNamontabegh;
                ObjTolid.strIdDailyReport = txtIdDailyReport.Text;
                ObjTolid.strShenase = lblShMontabegh.Text;
                ObjTolid.strElat = lblEltMontabegh.Text;
                ObjTolid.strAmel = cmbAmelN.Text;
                ObjTolid.strtedad = txtTedadN.Text;
                ObjTolid.strIsZayeat = "0";
                ObjTolid.strIsNamontabegh = "1";
                MessageBox.Show(ObjTolid.Update_ZayeatNamontabegh_DailyReport());
                grdMontabegh.DataSource = ObjTolid.Select_ZayeatNamontabegh_DailyReport().Tables[0];
            }
            catch
            {
                MessageBox.Show("خطا در ثبت اطلاعات");
            }
        }
        public int loadDataDailyReport(string t)
        {
            ClsTolid ObjTolid = new ClsTolid();
            if (t == "d")
                ObjTolid.strIdDailyReport = txtIdDailyReport.Text;
            else
                ObjTolid.strIdBarname = cmbBarname.Text;
            ds = ObjTolid.Select_DailyReport();
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("گزارشی برای این برنامه یافت نشد");
                return 0;
            }
            ObjTolid.strIdDailyReport = txtIdDailyReport.Text = ds.Tables[0].Rows[0]["ID"].ToString();
            txtTedadOpr.Text = ObjTolid.Select_TedadeTolideOperator().Tables[0].Rows[0][0].ToString();
            txtZamanKariOpr.Text = ObjTolid.Select_TedadeTolideOperator().Tables[0].Rows[0][0].ToString(); 
            dtpDateDailyReport.Text = ds.Tables[0].Rows[0]["tarikh"].ToString();
            cmbKargah.SelectedValue = ds.Tables[0].Rows[0]["FK_ID_unit"].ToString();
            cmbBarname.Text = ds.Tables[0].Rows[0]["FK_ID_barname"].ToString();
            if (ds.Tables[0].Rows[0]["FK_ID_barname"] != null && ds.Tables[0].Rows[0]["FK_ID_barname"].ToString() != "")
            {
                cmbDastgah.Enabled = false;
                txtNKala.Enabled = false;
                cmbProccess.Enabled = false;
                chkBarnameId.Checked = true;
            }
            else
                EnablaControl();
            cmbDastgah.DataSource = ds.Tables[0];
            cmbDastgah.ValueMember = "ID_machine";
            cmbDastgah.DisplayMember = "dastgah";
            txtNKala.Text = ds.Tables[0].Rows[0]["N_Kala"].ToString();
            lblCKala.Text = ds.Tables[0].Rows[0]["FK_ID_part_process"].ToString();
            cmbProccess.Text = "";
            cmbProccess.DataSource = ds.Tables[0];
            cmbProccess.ValueMember = "FK_ID_proc";
            cmbProccess.DisplayMember = "N_process";
            txtTedadSalem.Text = ds.Tables[0].Rows[0]["tedad"].ToString();
            txtTedadAbi.Text = ds.Tables[0].Rows[0]["tedadPaletAbi"].ToString();
            txtTedadMeshki.Text = ds.Tables[0].Rows[0]["tedadPaletMeshki"].ToString();
            txtZamanKari.Text = ds.Tables[0].Rows[0]["zaman_kari"].ToString();
            txtRahgah.Text = ds.Tables[0].Rows[0]["v_rahgah"].ToString();
            txtHofre.Text = ds.Tables[0].Rows[0]["tedad_hofre"].ToString();
            txtVaznGhete.Text = ds.Tables[0].Rows[0]["v_gheteh"].ToString();
            txtVaznZayeat.Text = ds.Tables[0].Rows[0]["v_zayeat"].ToString();
            txtNafar.Text = ds.Tables[0].Rows[0]["t_nafar"].ToString();
            txtTozihat.Text = ds.Tables[0].Rows[0]["tozihat"].ToString();
            txtIdShenase.Text = ds.Tables[0].Rows[0]["IdShenaseStart"].ToString();
            txtTekrarKontor.Text = ds.Tables[0].Rows[0]["TekrarKontor"].ToString();
            //txtOperator.Text = ds.Tables[0].Rows[0]["N"].ToString();
            txtTedadTestKontor.Text = ds.Tables[0].Rows[0]["TedadTestKontor"].ToString();
            txtTedadKontor.Text = ds.Tables[0].Rows[0]["TedadKontor"].ToString();
            txtTedadTestKhat.Text = ds.Tables[0].Rows[0]["TedadTestKhat"].ToString();
            txtTedadTolidEsmi.Text = ds.Tables[0].Rows[0]["TedadTolidEsmi"].ToString();
            txtTedadMotefareghe.Text = ds.Tables[0].Rows[0]["TedadMotefareghe"].ToString();
            txtZamanTest.Text = ds.Tables[0].Rows[0]["ZamanTest"].ToString();
            cmbTypeKontor.Text = ds.Tables[0].Rows[0]["TypeKontor"].ToString();
            txtZamanKol.Text = ds.Tables[0].Rows[0]["ZamanKol"].ToString();
            ////////////////////////////////////////////////////////////
            grpRadyabi.Enabled = true;
            grpOprTav.Enabled = true;
            grpMontabegh.Enabled = true;
            grpZayeat.Enabled = true;

            grdRadyabi.DataSource = ObjTolid.Select_Radyabi_DailyReport().Tables[0];
            grdDarkhast.DataSource = ObjTolid.Select_Radyabi_Anbar().Tables[0];
            grdOpr.DataSource = ObjTolid.Select_Opr().Tables[0];
            grdTavaghof.DataSource = ObjTolid.Select_StopDailyReport().Tables[0];

            ObjTolid.strIsNamontabegh = "0";
            ObjTolid.strIsZayeat = "1";
            grdZayeat.DataSource = ObjTolid.Select_ZayeatNamontabegh_DailyReport().Tables[0];
            ObjTolid.strIsNamontabegh = "1";
            ObjTolid.strIsZayeat = "0";
            grdMontabegh.DataSource = ObjTolid.Select_ZayeatNamontabegh_DailyReport().Tables[0];
            return 1;
        }
        private void btnF2Ghete_Click(object sender, EventArgs e)
        {
            FrmTakvin_GhetehSearch frm = new FrmTakvin_GhetehSearch();
            frm.strPlanning = "1";
            frm.strIdUnit = cmbKargah.SelectedValue.ToString();
            frm.ShowDialog();
            if (ClsPublic.id_Gheteh == null)
                return;
            txtNKala.Text = ClsPublic.N_kala;
            lblCKala.Text = ClsPublic.C_kala;
            cmbProccess.Enabled = false;
        }
    }
}

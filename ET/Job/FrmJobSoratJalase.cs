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
    public partial class FrmJobSoratJalase : Telerik.WinControls.UI.RadForm
    {
        public FrmJobSoratJalase()
        {
            InitializeComponent();
        }
        ClsJob ObjJob = new ClsJob();
        public string ID_HSoratJ;
        private void txtHSJRaees_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmEdari_ListPersonel frmEL = new FrmEdari_ListPersonel();
                frmEL.ShowDialog();
                lblHSJC_Raees.Text = (!string.IsNullOrEmpty(ClsPublic.strC_personel) ? ClsPublic.strC_personel : lblHSJC_Raees.Text.Trim());
                txtHSJRaees.Text = (!string.IsNullOrEmpty(ClsPublic.strN_personel) ? ClsPublic.strN_personel : txtHSJRaees.Text.Trim());
                

            }
        }

        private void txtHSJDabir_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmEdari_ListPersonel frmEL = new FrmEdari_ListPersonel();
                frmEL.ShowDialog();
                lblHSJC_Dabir.Text = (!string.IsNullOrEmpty(ClsPublic.strC_personel) ? ClsPublic.strC_personel : lblHSJC_Dabir.Text.Trim());
                txtHSJDabir.Text = (!string.IsNullOrEmpty(ClsPublic.strN_personel) ? ClsPublic.strN_personel : txtHSJDabir.Text.Trim());


            }
        }

        private void FrmJobSoratJalase_Load(object sender, EventArgs e)
        {
            dtpReqSJAnjam.Value = DateTime.Now;
            dtpHSJDate.Value = DateTime.Now;
            //---------------------------------------------------------------------vahed masool
            cmbReqSJVahed.DataSource = ObjJob.SelectUniteSorat().Tables[0];
            cmbReqSJVahed.ValueMember = "IdUnit";
            cmbReqSJVahed.DisplayMember = "onvan";
           // cmbMosType.SelectedValue = 1;
        }

        private void btnAddHSJ_Click(object sender, EventArgs e)
        {
            if (txtHSJOnvan.Text.Trim() == "")
            {
                RadMessageBox.Show("عنوان صورت جلسه را تعیین نمایید");
                return;
            }
            ObjJob.OnvanHSoratJ  =   txtHSJOnvan.Text.Trim()  ;
            ObjJob.RaeesHSoratJ = lblHSJC_Raees.Text.Trim();
            ObjJob.DabirHSoratJ = lblHSJC_Dabir.Text.Trim();
            ObjJob.DateHSoratJ   =   dtpHSJDate.Value.ToString().Substring(0, 10);
            try
            {

                ID_HSoratJ = ObjJob.InsertHSorat().Tables[0].Rows[0]["ID_HSoratJ"].ToString();
                if (!string.IsNullOrEmpty(ID_HSoratJ))
                {
                    txtHSJID.Text = ObjJob.ID_HSoratJ = ID_HSoratJ;
                    GrdReqSJ.DataSource = ObjJob.SelectReqSorat().Tables[0];
                    RadMessageBox.Show("صورت جلسه با موفقیت ثبت شد");
                    btnAddReqSJ.Enabled = true;
                    btnDelHSJ.Enabled = true;
                    btnUpdHSJ.Enabled = true;
                }
            }

            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }
           
           
            
        }

        private void btnUpdHSJ_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ID_HSoratJ))
            {
                RadMessageBox.Show("صورت جلسه را تعیین نمایید");
                return;
            }
            if (txtHSJOnvan.Text.Trim() == "")
            {
                RadMessageBox.Show("عنوان صورت جلسه را تعیین نمایید");
                return;
            }
            ObjJob.OnvanHSoratJ = txtHSJOnvan.Text.Trim();
            ObjJob.RaeesHSoratJ = lblHSJC_Raees.Text.Trim();
            ObjJob.DabirHSoratJ = lblHSJC_Dabir.Text.Trim();
            ObjJob.DateHSoratJ = dtpHSJDate.Value.ToString().Substring(0, 10);
            try
            {
                RadMessageBox.Show(ObjJob.UpdateHSorat());
                GrdReqSJ.DataSource = ObjJob.SelectReqSorat().Tables[0];
            }

            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }
           
        }

        private void btnDelHSJ_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ID_HSoratJ))
            {
                RadMessageBox.Show("صورت جلسه را تعیین نمایید");
                return;
            }
            // check for not detail
            if (ObjJob.SelectReqSorat().Tables[0].Rows.Count > 0)
            {
                RadMessageBox.Show("صورت جلسه دارای درخواست است");
                return;
            }
            try
            {

                RadMessageBox.Show(ObjJob.deleteHSorat());
                ObjJob.ID_HSoratJ= ID_HSoratJ = "";
                GrdReqSJ.DataSource = null;
            }

            catch (Exception ex)
            {
                RadMessageBox.Show("خطا در حذف صورت جلسه"+ex.Message);
            }
            
        }

        private void btnAddReqSJ_Click(object sender, EventArgs e)
        {
            if ( string.IsNullOrEmpty(ID_HSoratJ))
            {
                RadMessageBox.Show(" صورت جلسه را تعیین نمایید");
                return;
            }
            ObjJob.Priority = (rbtnReqSJPrifori.Checked == true ? "1" : "0");
            ObjJob.Status_Case = (rbtnReqSJNotActive.Checked == true ? "1" : "0");
            ObjJob.ID_HSoratJ = ID_HSoratJ;
            ObjJob.ReqSJDesc = rtxtReqSJDesc.Text;
            ObjJob.DateNiaz = dtpReqSJAnjam.Value.ToString().Substring(0, 10);
            RadMessageBox.Show(ObjJob.InsertTaskREQSorat());
            GrdReqSJ.DataSource= ObjJob.SelectReqSorat().Tables[0];
        }

        private void cmbReqSJVahed_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbReqSJVahed.SelectedValue == null || cmbReqSJVahed.SelectedValue.ToString() == "System.Data.DataRowView" || cmbReqSJVahed.SelectedText.ToString() == "System.Data.DataRowView")
                {
                    cmbReqSJVahed.Text = "";
                    return;
                }
                ObjJob.ID_UnitSJ = "";
                ObjJob.ID_UnitSJ = cmbReqSJVahed.SelectedValue.ToString();
                cmbReqSJActing.DataSource = null;
                cmbReqSJCases.DataSource = null;

                cmbReqSJActing.DataSource = ObjJob.SelectActingSorat().Tables[0];
                cmbReqSJActing.ValueMember = "ID_Acting";
                cmbReqSJActing.DisplayMember = "NActing";

            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }
            
                
            
        }

        private void cmbReqSJActing_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbReqSJActing.SelectedValue == null || cmbReqSJActing.SelectedValue.ToString() == "System.Data.DataRowView" || cmbReqSJActing.SelectedText.ToString() == "System.Data.DataRowView")
            {
                cmbReqSJActing.Text = "";
                return;
            }

            ObjJob.ReqSJActing = "";
            ObjJob.NIDCase =  "";
            ObjJob.NNCase =  "";
            ObjJob.NtblCase = "";
            ObjJob.ReqSJActing = cmbReqSJActing.SelectedValue.ToString();
            DataSet dsNametblCase = ObjJob.SelectNametblCase();
            if (dsNametblCase.Tables[0].Rows.Count==0)
            {
                return;
            }
            ObjJob.NIDCase = dsNametblCase.Tables[0].Rows[0]["NIDCase"].ToString();
            ObjJob.NNCase = dsNametblCase.Tables[0].Rows[0]["NNCase"].ToString();
            ObjJob.NtblCase = dsNametblCase.Tables[0].Rows[0]["NtblCase"].ToString();
            if (string.IsNullOrEmpty(ObjJob.NIDCase) || string.IsNullOrEmpty(ObjJob.NNCase) || string.IsNullOrEmpty(ObjJob.NtblCase))
            {
                return;
            }
            cmbReqSJCases.DataSource = ObjJob.SelectDRPCase().Tables[0];
            cmbReqSJCases.ValueMember = "" + ObjJob.NIDCase + "";
            cmbReqSJCases.DisplayMember = "" + ObjJob.NNCase + "";
        }

        private void cmbReqSJCases_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbReqSJCases.SelectedValue == null || cmbReqSJCases.SelectedValue.ToString() == "System.Data.DataRowView" || cmbReqSJCases.SelectedText.ToString() == "System.Data.DataRowView")
            {
                cmbReqSJCases.Text = "";
                return;
            }
            ObjJob.ReqSJCases = cmbReqSJCases.SelectedValue.ToString();
        }

        private void txtHSJOnvan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmJobSoratSearch frmJss = new FrmJobSoratSearch();
                frmJss.ShowDialog();
                txtHSJID.Text = ID_HSoratJ = ClsJob.GetID_HSoratJ;
                ObjJob.ID_HSoratJ = ID_HSoratJ;
                txtHSJOnvan.Text = ClsJob.GetOnvanHSoratJ;
                lblHSJC_Raees.Text = ClsJob.GetRaeesHSoratJ;
                txtHSJRaees.Text = ClsJob.GetNRaees;
                txtHSJDabir.Text = ClsJob.GetNDabir;
                lblHSJC_Dabir.Text = ClsJob.GetDabirHSoratJ;
                dtpHSJDate.Text = ClsJob.GetDateHSoratJ;
                GrdReqSJ.DataSource = null;
                if (!string.IsNullOrEmpty(ID_HSoratJ))
                {
                    GrdReqSJ.DataSource = ObjJob.SelectReqSorat().Tables[0];
                    btnDelHSJ.Enabled = true;
                    btnUpdHSJ.Enabled = true;
                }
                

            }
        }

        private void btnUpdReqSJ_Click(object sender, EventArgs e)
        {
           // GrdReqSJ.DataSource = null;
           // if (!string.IsNullOrEmpty(ID_HSoratJ))
           // {
           //     GrdReqSJ.DataSource = ObjJob.SelectReqSorat().Tables[0];
           // }
        }

        private void btnDelReqSJ_Click(object sender, EventArgs e)
        {
            GrdReqSJ.DataSource = null;
            if (!string.IsNullOrEmpty(ID_HSoratJ))
            {
                GrdReqSJ.DataSource = ObjJob.SelectReqSorat().Tables[0];
            }
        }

        private void GrdReqSJ_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {

                ID_HSoratJ = GrdReqSJ.Rows[e.RowIndex].Cells["ID_HSoratJ"].Value.ToString();
                txtHSJID.Text = ID_HSoratJ;
                cmbReqSJVahed.Text = GrdReqSJ.Rows[e.RowIndex].Cells["onvan"].Value.ToString();
                cmbReqSJVahed.SelectedValue = GrdReqSJ.Rows[e.RowIndex].Cells["FK_ID_Unit"].Value;
                cmbReqSJActing.Text = GrdReqSJ.Rows[e.RowIndex].Cells["NActing"].Value.ToString();
                cmbReqSJActing.SelectedValue = GrdReqSJ.Rows[e.RowIndex].Cells["FK_ID_Acting"].Value;
                cmbReqSJActing_SelectedValueChanged(sender, e);
                //RadMessageBox.Show(GrdReqSJ.Rows[e.RowIndex].Cells["FK_ID_Cases"].Value.ToString());
                cmbReqSJCases.SelectedValue = GrdReqSJ.Rows[e.RowIndex].Cells["FK_ID_Cases"].Value;
                //cmbReqSJCases.SelectedValue = GrdReqSJ.Rows[e.RowIndex].Cells["FK_ID_Cases"].Value.ToString();
                //cmbReqSJCases.Text = GrdReqSJ.Rows[e.RowIndex].Cells["DateHSoratJ"].Value.ToString();
                rtxtReqSJDesc.Text = GrdReqSJ.Rows[e.RowIndex].Cells["description_Task"].Value.ToString();
                rbtnReqSJPrifori.Checked = Convert.ToBoolean(GrdReqSJ.Rows[e.RowIndex].Cells["Status_Case"].Value);
                rbtnReqSJPriAdi.Checked = !Convert.ToBoolean(GrdReqSJ.Rows[e.RowIndex].Cells["Status_Case"].Value);
                rbtnReqSJNotActive.Checked = Convert.ToBoolean(GrdReqSJ.Rows[e.RowIndex].Cells["Priority"].Value);
                rbtnReqSJActive.Checked = !Convert.ToBoolean(GrdReqSJ.Rows[e.RowIndex].Cells["Priority"].Value);
                txtReqSJ_ID.Text = GrdReqSJ.Rows[e.RowIndex].Cells["IDRequest"].Value.ToString();
                dtpReqSJAnjam.Text = GrdReqSJ.Rows[e.RowIndex].Cells["DateNiaz"].Value.ToString();//.Value.ToString().Substring(0, 10);
                if (GrdReqSJ.Rows[e.RowIndex].Cells["EndTask_Vaziat"].Value.ToString() == "اتمام")
                {
                    btnRejectedDalil.Enabled = true;
                }
                else
                    btnRejectedDalil.Enabled = false;
            }
            catch(Exception ex)
            {}
        }

        private void btnClearHSJ_Click(object sender, EventArgs e)
        {
            ID_HSoratJ = "";
            txtHSJID.Clear();
            btnAddReqSJ.Enabled = false;
            txtHSJOnvan.Clear();
            lblHSJC_Raees.Text="";
            txtHSJRaees.Clear();
            txtHSJDabir.Clear();
            lblHSJC_Dabir.Text = "";
            dtpHSJDate.Value = DateTime.Now;
            
            btnClearReqSJ_Click(sender,e);
            btnDelHSJ.Enabled = false;
            btnUpdHSJ.Enabled = false;
            btnRejectedDalil.Enabled = false;
            GrdReqSJ.DataSource = null;
        }

        private void btnClearReqSJ_Click(object sender, EventArgs e)
        {
            cmbReqSJVahed.SelectedValue = null;
            txtReqSJ_ID.Clear();
            rtxtReqSJDesc.Clear();
            cmbReqSJActing.DataSource = null;
            dtpReqSJAnjam.Value= DateTime.Now;
            cmbReqSJCases.DataSource = null;
            rbtnReqSJPriAdi.Checked = true;
            rbtnReqSJActive.Checked = true;
            ObjJob.IDRequest = "";
            txtReqSJ_ID.Clear();
            ObjJob.RejectedRequest = "";
            rtxtRejectedDalil.Clear();
            btnRejectedDalil.Enabled = false;
            //GrdReqSJ.DataSource = ObjJob.SelectReqSorat().Tables[0];
        }

        private void btnRejectedDalil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ID_HSoratJ))
            {
                RadMessageBox.Show(" صورت جلسه را تعیین نمایید");
                return;
            }
            if (string.IsNullOrEmpty(txtReqSJ_ID.Text.Trim()))
            {
                RadMessageBox.Show(" درخواست را تعیین نمایید");
                return;
            }
            ObjJob.IDRequest = txtReqSJ_ID.Text.Trim();
            ObjJob.RejectedRequest= rtxtRejectedDalil.Text.Trim();
            try
            {
                RadMessageBox.Show(ObjJob.UpdateReject());
                GrdReqSJ.DataSource = ObjJob.SelectReqSorat().Tables[0];
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }         
        }

        private void btnHSJRaees_Click(object sender, EventArgs e)
        {
            FrmEdari_ListPersonel frmEL = new FrmEdari_ListPersonel();
            frmEL.ShowDialog();
            lblHSJC_Raees.Text = (!string.IsNullOrEmpty(ClsPublic.strC_personel) ? ClsPublic.strC_personel : lblHSJC_Raees.Text.Trim());
            txtHSJRaees.Text = (!string.IsNullOrEmpty(ClsPublic.strN_personel) ? ClsPublic.strN_personel : txtHSJRaees.Text.Trim());
                
        }

        private void btnHSJDabir_Click(object sender, EventArgs e)
        {
            FrmEdari_ListPersonel frmEL = new FrmEdari_ListPersonel();
            frmEL.ShowDialog();
            lblHSJC_Dabir.Text = (!string.IsNullOrEmpty(ClsPublic.strC_personel) ? ClsPublic.strC_personel : lblHSJC_Dabir.Text.Trim());
            txtHSJDabir.Text = (!string.IsNullOrEmpty(ClsPublic.strN_personel) ? ClsPublic.strN_personel : txtHSJDabir.Text.Trim());

        }

        private void btnHSJOnvan_Click(object sender, EventArgs e)
        {
            FrmJobSoratSearch frmJss = new FrmJobSoratSearch();
            frmJss.ShowDialog();
            txtHSJID.Text= ID_HSoratJ = ClsJob.GetID_HSoratJ;
            ObjJob.ID_HSoratJ = ID_HSoratJ;
            txtHSJOnvan.Text = ClsJob.GetOnvanHSoratJ;
            lblHSJC_Raees.Text = ClsJob.GetRaeesHSoratJ;
            txtHSJRaees.Text = ClsJob.GetNRaees;
            txtHSJDabir.Text = ClsJob.GetNDabir;
            lblHSJC_Dabir.Text = ClsJob.GetDabirHSoratJ;
            dtpHSJDate.Text = ClsJob.GetDateHSoratJ;
            GrdReqSJ.DataSource = null;
            if (!string.IsNullOrEmpty(ID_HSoratJ))
            {
                GrdReqSJ.DataSource = ObjJob.SelectReqSorat().Tables[0];
                btnDelHSJ.Enabled = true;
                btnUpdHSJ.Enabled = true;
            }
        }
    }
}

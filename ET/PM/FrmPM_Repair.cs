using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
//using System.Globalization;

namespace ET
{
    public partial class FrmPM_Repair : Telerik.WinControls.UI.RadForm
    {
        public FrmPM_Repair()
        {
            InitializeComponent();
        }

        ClsPM cp = new ClsPM();
        ClsPublic cpu = new ClsPublic();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        public string ID_Task, ID_HRepair;
        private void FrmPM_Repair_Load(object sender, EventArgs e)
        {
            try
            {
                cmbStatus_Machine.SelectedIndex = 0;
                cmbDegree_Importance.SelectedIndex = 0;
                txtDate_do.Value = DateTime.Now;
                dtDate_Time_Failure.Value = DateTime.Now;
                dtDateEnd.Value = DateTime.Now;
                dtDateStartR.Value = DateTime.Now;
                txtTimeFailure.Text = DateTime.Now.TimeOfDay.ToString().Substring(0,5);          
                cmbFailure.DataSource = cp.select_Failure().Tables[0];
                cmbFailure.ValueMember = "ID_Failure";
                cmbFailure.DisplayMember = "NFailure";
                if (ClsPM.IDFailure != null)
                    cmbFailure.SelectedValue = ClsPM.IDFailure;

                cmbHalt.DataSource = cp.Select_Halt().Tables[0];
                cmbHalt.ValueMember = "ID_Halt";
                cmbHalt.DisplayMember = "ReasonHalt";

                cmbSparePart.DataSource = cp.selectSparPart().Tables[0];
                cmbSparePart.ValueMember = "ID_spare_part";
                cmbSparePart.DisplayMember = "NKala";
                cmbSparePart.SelectedIndex = -1;

                 cmbPersonel.DataSource = cp.SelectPersonel().Tables[0];
                cmbPersonel.ValueMember = "IdEmp";
                cmbPersonel.DisplayMember = "NAME";
                cmbPersonel.SelectedIndex = -1;

                cmbN_machine.DataSource = cp.selectMachine().Tables[0];
                cmbN_machine.ValueMember = "ID_machine";
                cmbN_machine.DisplayMember = "N_machine";
                cmbN_machine.SelectedIndex = -1;

                cmbTypeRepair.DataSource = cp.select_TypeRepair().Tables[0];
                cmbTypeRepair.ValueMember = "IdTypeRepair";
                cmbTypeRepair.DisplayMember = "NameTypeRepair";
                cmbTypeRepair.SelectedIndex = 1;

                //grb3.Enabled = false;
                //txb_preamble.Enabled = false;
                //btn_add_sparepart.Enabled = false;
                //btn_del_sparepart.Enabled = false;
                //btn_edit_sparepart.Enabled = false;
                //btn_new_sparepart.Enabled = false;
                if (ID_HRepair != null)
                {
                    cp.ID_HRepair = ID_HRepair;
                    dt = cp.Select_HRepair().Tables[0];
                    lbl_ID_HRepair.Text = ID_HRepair;
                    cmbN_machine.Text = dt.Rows[0]["N_machine"].ToString();
                    txtDescription_Req.Text = dt.Rows[0]["Description_Request"].ToString();
                    txtDescription_Task.Text = dt.Rows[0]["Description_Task"].ToString();
                    dtDate_Time_Failure.Text = dt.Rows[0]["Date_Time_Failure"].ToString();
                    txtTimeFailure.Text = dt.Rows[0]["TimeFailure"].ToString();
                    txb_reason_delay.Text = dt.Rows[0]["Reason_delay"].ToString();
                    cmbFailure.Text = dt.Rows[0]["NFailure"].ToString();
                    cmbTypeRepair.Text = dt.Rows[0]["NameTypeRepair"].ToString();
                    cmbDegree_Importance.SelectedIndex = Convert.ToInt32(dt.Rows[0]["Degree_Importance"].ToString());
                    cmbStatus_Machine.SelectedIndex = Convert.ToInt32(dt.Rows[0]["Status_Machine"].ToString());
                    txtSuggest_Repairman.Text = dt.Rows[0]["Suggest_Repairman"].ToString();
                    txb_time_delay.Text = dt.Rows[0]["Time_delay"].ToString();

                    if (dt.Rows[0]["TPM"].ToString() == "True")
                        chk_TPM.Checked = true;
                    else
                        chk_TPM.Checked = false;
                    if (dt.Rows[0]["Correction_Need"].ToString() == "True")
                        chkCorrection_Need.Checked = true;
                    else
                        chkCorrection_Need.Checked = false;
                    txb_preamble.Text = dt.Rows[0]["Preamble"].ToString();
                    dtDateStartR.Text = dt.Rows[0]["Date_Time_Start"].ToString();
                    txtTimeStartR.Text = dt.Rows[0]["TimeStart"].ToString();
                    dtDateEnd.Text = dt.Rows[0]["Date_Time_END"].ToString();
                    txtTimeEndR.Text = dt.Rows[0]["TimeEnd"].ToString();
                    if (dt.Rows[0]["Bargh"].ToString() == "1")
                        rbtnBargh.IsChecked = true;
                    else
                        rbtnMechanic.IsChecked = true;
                    if (dt.Rows[0]["IsDone"].ToString() == "True")
                        chkEndTask.Checked = true;
                    else
                        chkEndTask.Checked = false;
                    txtEndTaskDescript.Text = dt.Rows[0]["Description_End"].ToString();
                    grdHalt.DataSource = cp.select_DRepair_Halt().Tables[0];
                    grdSparePart.DataSource = cp.select_DRepair_SparePart().Tables[0];
                    //grdTaskPersonel.DataSource = cp.Select_TaskPersonel().Tables[0];
                    lblSumHalt.Text = cp.select_sum_halt().Tables[0].Rows[0][0].ToString();
                    //if (grdActionReport.Enabled == true)
                    //{
                    grdActionReport.DataSource = cp.Select_ActionReport().Tables[0];
                    //}
                }
                //drp_status.SelectedIndex = 0;
                //sumt();
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void Up_HRepair()
        {
            cp.Time_delay = txb_time_delay.Text;
            cp.Reason_delay = txb_reason_delay.Text;

            if (rbtn_Service0.IsChecked == true)
            {
                cp.Service = 0;
            }
            if (rbtn_Service1.IsChecked == true)
            {
                cp.Service = 1;
            }
            if (chk_TPM.Checked == true)
            {
                cp.TPM = 1;
            }
            else
            {
                cp.TPM = 0;
            }
            cp.Preamble = txb_preamble.Text;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                //cp.status_Machine = Convert.ToInt32(chkTavaghof.Checked);
                if (cmbN_machine.SelectedValue == null)
                    cp.FK_ID_machine = "";
                else
                    cp.FK_ID_machine = cmbN_machine.SelectedValue.ToString();
                cp.descriptionTask = txtDescription_Task.Text;
                cp.DescriptioEnd = txtEndTaskDescript.Text;
                cp.descriptionReq = txtDescription_Req.Text;
                if (cmbFailure.SelectedValue == null)
                    cp.FK_ID_Failure = "";
                else
                    cp.FK_ID_Failure = cmbFailure.SelectedValue.ToString();
                cp.IdTypeRepair = cmbTypeRepair.SelectedValue.ToString();
                cp.Date_Time_Failure = dtDate_Time_Failure.Text;
                cp.TimeFailure = txtTimeFailure.Text;
                cp.Date_Time_Start = dtDateStartR.Text;
                cp.strTimeStart = txtTimeStartR.Text;
                cp.Date_Time_END = dtDateEnd.Text;
                cp.strTimeEnd = txtTimeEndR.Text;
                cp.Time_delay = txb_time_delay.Value.ToString();
                cp.Reason_delay = txb_reason_delay.Text;

                if (rbtn_Service0.IsChecked)
                    cp.Service = 0;
                if (rbtn_Service1.IsChecked)
                    cp.Service = 1;               
                if (chkEndTask.IsChecked)
                    cp.strIsDone = "1";
                else
                    cp.strIsDone = "0";
               
                if (rbtnBargh.IsChecked)
                    cp.flagBargh = 1;
                if (rbtnMechanic.IsChecked)
                    cp.flagBargh = 2;
                if (rbtnTasisat.IsChecked)
                    cp.flagBargh = 3;
                if (rbtnElectronic.IsChecked)
                    cp.flagBargh = 4;

                cp.TPM = Convert.ToInt32(chk_TPM.Checked);
                cp.Preamble = txb_preamble.Text;
                cp.EndTaskDescript = txtEndTaskDescript.Text;
                cp.Degree_Importance = cmbDegree_Importance.SelectedIndex.ToString();
                cp.Correction_Need = chkCorrection_Need.Checked;
                cp.Status_Machine = cmbStatus_Machine.SelectedIndex.ToString();
                cp.Suggest_Repairman = txtSuggest_Repairman.Text;
                RadMessageBox.Show(cp.Ins_HRepair());
                cp.ID_HRepair = cp.Select_MaxTamir().Tables[0].Rows[0][0].ToString();
                lbl_ID_HRepair.Text = cp.ID_HRepair;
                ///////////////////////////
                grdHalt.DataSource = cp.select_DRepair_Halt().Tables[0];
                grdSparePart.DataSource = cp.select_DRepair_SparePart().Tables[0];
                lblSumHalt.Text = cp.select_sum_halt().Tables[0].Rows[0][0].ToString();
                //Up_HRepair();
                grpRepair1.Enabled = true;
                grpRepair2.Enabled = true;
                grpRepair3.Enabled = true;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                chkEndTask.Enabled = true;
                btn_save.Enabled = false;
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        //private string shamsiTOmiladi(String inputdata)
        //{
        //    GregorianCalendar juli = new GregorianCalendar();
        //    DateTime dt = Convert.ToDateTime(inputdata);
        //    string s = string.Format("{0}-{1}-{2} {3}:{4}:{5}", juli.GetYear(dt), juli.GetMonth(dt),
        //        juli.GetDayOfMonth(dt), juli.GetHour(dt), juli.GetMinute(dt), juli.GetSecond(dt));
        //    return s;
        //}
        private void chk_TPM_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_TPM.Checked == true)
            {
                txb_preamble.Enabled = true;
            }
            if (chk_TPM.Checked == false)
            {
                txb_preamble.Enabled = false;
            }
        }
        private void btn_del_sparepart_Click(object sender, EventArgs e)
        {
            RadMessageBox.Show(cp.Del_DRepair_SparePart());
            grdSparePart.DataSource = cp.select_DRepair_SparePart().Tables[0];
        }
        private void btn_new_sparepart_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbl_ID_HRepair.Text == "" | lbl_ID_HRepair.Text == "_")
                {
                    MessageBox.Show("ابتدا تعمیر را ثبت کنید");
                    return;
                }
                cp.ID_HRepair = lbl_ID_HRepair.Text;
                cp.FK_ID_spare_part = cmbSparePart.SelectedValue.ToString();
                if (drp_status.SelectedIndex == 0) { cp.Status = "0"; }
                if (drp_status.SelectedIndex == 1) { cp.Status = "1"; }
                cp.Some_ = txb_sparepart_Some.Value.ToString();
                RadMessageBox.Show(cp.Ins_DRepair_SparePart());
                grdSparePart.DataSource = cp.select_DRepair_SparePart().Tables[0];
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbN_machine.SelectedValue == null)
                    cp.FK_ID_machine = "";
                else
                    cp.FK_ID_machine = cmbN_machine.SelectedValue.ToString();
                cp.description = txtDescription_Task.Text;
                if (cmbFailure.SelectedValue == null)
                    cp.FK_ID_Failure = "";
                else
                    cp.FK_ID_Failure = cmbFailure.SelectedValue.ToString();
                cp.IdTypeRepair = cmbTypeRepair.SelectedValue.ToString();
                cp.Date_Time_Failure = dtDate_Time_Failure.Text;
                cp.TimeFailure = txtTimeFailure.Text;
                cp.Date_Time_Start = dtDateStartR.Text;
                cp.Date_Time_END = dtDateEnd.Text;
                cp.strTimeStart = txtTimeStartR.Text;
                cp.strTimeEnd = txtTimeEndR.Text;              
                cp.Time_delay = txb_time_delay.Value.ToString();
                cp.Reason_delay = txb_reason_delay.Text;
                cp.DescriptioEnd = txtEndTaskDescript.Text;
                cp.descriptionReq = txtDescription_Req.Text;
                cp.Degree_Importance = cmbDegree_Importance.SelectedIndex.ToString();
                cp.Correction_Need = chkCorrection_Need.Checked;
                cp.Status_Machine = cmbStatus_Machine.SelectedIndex.ToString();
                cp.Suggest_Repairman = txtSuggest_Repairman.Text;

                if (rbtn_Service0.IsChecked)
                    cp.Service = 0;
                if (rbtn_Service1.IsChecked)
                    cp.Service = 1;
                if (rbtnMechanic.IsChecked)
                    cp.flagBargh = 2;
                if (rbtnBargh.IsChecked)
                    cp.flagBargh = 1;
                if (chkEndTask.IsChecked)
                    cp.strIsDone = "1";
                else
                    cp.strIsDone = "0";
                cp.TPM = Convert.ToInt32(chk_TPM.Checked);
                cp.Preamble = txb_preamble.Text;
                RadMessageBox.Show(cp.UpdateRepair());
                this.Close();
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            RadMessageBox.Show(cp.Del_HRepair());
            this.Close();
        }

        private void btnAddHalt_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbl_ID_HRepair.Text == "" | lbl_ID_HRepair.Text == "_")
                {
                    MessageBox.Show("ابتدا تعمیر را ثبت کنید");
                    return;
                }
                cp.ID_HRepair = lbl_ID_HRepair.Text;
                cp.Reason_Halt = cmbHalt.SelectedValue.ToString();
                cp.Time_Halt = txtTimeHalt.Text;
                RadMessageBox.Show(cp.Ins_DRepair_Halt());

                grdHalt.DataSource = cp.select_DRepair_Halt().Tables[0];
                lblSumHalt.Text = cp.select_sum_halt().Tables[0].Rows[0][0].ToString();
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbl_ID_HRepair.Text == "" | lbl_ID_HRepair.Text == "_")
                {
                    MessageBox.Show("ابتدا تعمیر را ثبت کنید");
                    return;
                }
                cp.ID_HRepair = lbl_ID_HRepair.Text;
                cp.IdEmp = cmbPersonel.SelectedValue.ToString();
                cp.strDo_time_start = txtDo_time_start.Text;
                cp.strDo_time_start = txtDo_time_start.Text;
                cp.strDo_time_end = txtDo_time_end.Text;
                cp.strDate_do = txtDate_do.Text;
                cp.strDescription = txtDescriptionAction.Text;
                cp.strOpinion = "";
                if (cp.SelectValidateTime().Tables[0].Rows.Count == 0)
                {
                    RadMessageBox.Show(cp.Ins_ActionReport());
                    grdActionReport.DataSource = cp.Select_ActionReport().Tables[0];
                }
                else
                {
                    RadMessageBox.Show("مجری در این تاریخ و زمان کاری را انجام داده است");
                }
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        private void grdActionReport_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            cp.strID_Action_Report = grdActionReport.Rows[e.RowIndex].Cells["ID_Action_Report"].Value.ToString();
            txtDate_do.Text = grdActionReport.Rows[e.RowIndex].Cells["Date_do"].Value.ToString();
            txtDescriptionAction.Text = grdActionReport.Rows[e.RowIndex].Cells["Description"].Value.ToString();
            txtDo_time_start.Text = grdActionReport.Rows[e.RowIndex].Cells["Do_time_start"].Value.ToString();
            txtDo_time_end.Text = grdActionReport.Rows[e.RowIndex].Cells["Do_time_end"].Value.ToString();
            lblIdPersonel.Text = grdActionReport.Rows[e.RowIndex].Cells["NAME"].Value.ToString();
            btnDelActionReport.Enabled = true;
            //btnAction.Enabled = false;
        }

        private void btnDelHalt_Click(object sender, EventArgs e)
        {
            try
            {
                cp.strID_RepairHalt = grdHalt.CurrentRow.Cells["ID_RepairHalt"].Value.ToString();
                MessageBox.Show(cp.Del_DRepair_Halt());
                grdHalt.DataSource = cp.select_DRepair_Halt().Tables[0];
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }       

        private void grdSparePart_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            cp.FK_ID_spare_part = grdSparePart.Rows[e.RowIndex].Cells["ID_D_Repair_SparePart"].Value.ToString();
        }
        private void btnDelActionReport_Click(object sender, EventArgs e)
        {
            try
            {
                RadMessageBox.Show(cp.Del_Action_Report());
                grdActionReport.DataSource = cp.Select_ActionReport().Tables[0];
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        private void chkEndTask_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            //if (chkEndTask.Checked == true)
            //{
            //    if (RadMessageBox.Show("آیا مطمئن هستید اتمام شود؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    {
            //        cp.ID_HRepair = ID_HRepair;
            //        cp.EndTaskDescript = txtEndTaskDescript.Text;
            //        cp.updateEndTakTrue();
            //    }
            //    else
            //    {
            //        chkEndTask.Checked = false;
            //    }
            //}
            //if (chkEndTask.Checked == false)
            //{
            //    cp.updateEndTakFalse();
            //}
        }

        private void txtDo_time_end_TextChanged(object sender, EventArgs e)
        {
            try 
            {

                TimeSpan duration = DateTime.Parse(txtDo_time_end.Text).Subtract(DateTime.Parse(txtDo_time_start.Text));
                lblTimeSpan.Text = duration.ToString();
            }
            catch { }
        }

        private void btnPart_Click(object sender, EventArgs e)
        {
            cmbSparePart.DataSource = null;
            cmbSparePart.Items.Clear();
                //cmbSparePart.AutoCompleteDataSource = null;
            FrmPM_SparePart frmsp = new FrmPM_SparePart();
            frmsp.ShowDialog();
            cmbSparePart.DataSource = cp.selectSparPart().Tables[0];
            cmbSparePart.ValueMember = "ID_spare_part";
            cmbSparePart.DisplayMember = "NKala";
            cmbSparePart.SelectedIndex = -1;
        }

        private void txtDo_time_end_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                TimeSpan duration = DateTime.Parse(txtDo_time_end.Text).Subtract(DateTime.Parse(txtDo_time_start.Text));
                lblTimeSpan.Text = duration.ToString();
            }
            catch { }
        }

        private void cmbTypeRepair_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTypeRepair.SelectedValue.ToString() == "1")
            {
                dtDate_Time_Failure.Enabled = false;
                txtTimeFailure.Enabled = false;
            }
            else
            {
                dtDate_Time_Failure.Enabled = true;
                txtTimeFailure.Enabled = true;
            }
        }

        private void cmbFailure_SelectedIndexChanged(object sender, EventArgs e)
        {
            


        }
    }
}
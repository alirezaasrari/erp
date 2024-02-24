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
    public partial class FrmJobTaskModir : Telerik.WinControls.UI.RadForm
    {
        public FrmJobTaskModir()
        {
            InitializeComponent();
        }
        ClsJob ObjJob = new ClsJob();
        public string UnitMasool = "", TaskSJID = "", strID_Task_Per="";

       

        private void btnUpdTaskSJ_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TaskSJID))
            {
                RadMessageBox.Show("وظیفه ای تعیین نشده است");
                return;
            }
            ObjJob.TaskSJID = TaskSJID;
            ObjJob.Date_End = dtpTaskSJGhabelanjam.Value.ToString().Substring(0, 10);
            ObjJob.ID_Acting = cmbReqSJActing.SelectedValue.ToString();
            ObjJob.ID_Cases = cmbReqSJCases.SelectedValue.ToString();
            ObjJob.Time_do_Task = txtTaskSJTime.Text.Trim();
            ObjJob.description_Task = rtxtdescription_Task.Text.Trim();
            try
            {
                RadMessageBox.Show(ObjJob.UpdateTask());
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }
            MasterTemplate.DataSource = ObjJob.SelectTask(UnitMasool).Tables[0];
            gridViewTemplate1.DataSource = ObjJob.SelectTaskPers().Tables[0];
            gridViewTemplate2.DataSource = ObjJob.SelectTaskActionRep().Tables[0];
            ////ObjJob.TaskSJEnd_Task = (chkTaskSJEnd_Task.Checked == true ? "1" : "0");

        }

        private void btnClearTaskSJ_Click(object sender, EventArgs e)
        {
            TaskSJID = "";
            btnDelTaskSJ.Enabled = false;
            btnUpdTaskSJ.Enabled = false;
            grbVaziat.Enabled = false;
            txtTaskSJTime.Clear();
            rtxtdescription_Task.Clear();
            txtTaskSJID_Task.Clear();
            rtxtTaskSJDescEnd.Clear();
            
            btnErjaTaskSJ.Enabled = false;
            btnVaziatTaskSJ.Enabled = false;
            
            dtpTaskSJGhabelanjam.Value = DateTime.Now;
            cmbReqSJCases.DataSource = null;
            ObjJob.IDTaskPersonel = strID_Task_Per=txtID_Task_Per.Text="";
            btnRegTaskPer.Enabled = false;
            ////MasterTemplate.DataSource = ObjJob.SelectTask(UnitMasool).Tables[0];
            ////gridViewTemplate1.DataSource = ObjJob.SelectTaskPers().Tables[0];
            ////gridViewTemplate2.DataSource = ObjJob.SelectTaskActionRep().Tables[0];
            
        }

        private void cmbReqSJActing_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbReqSJActing.SelectedValue == null || cmbReqSJActing.SelectedValue.ToString() == "System.Data.DataRowView" || cmbReqSJActing.SelectedText.ToString() == "System.Data.DataRowView")
            {
                cmbReqSJActing.Text = "";
                return;
            }

            ObjJob.ReqSJActing = "";
            ObjJob.NIDCase = "";
            ObjJob.NNCase = "";
            ObjJob.NtblCase = "";
            ObjJob.ReqSJActing = cmbReqSJActing.SelectedValue.ToString();
            DataSet dsNametblCase = ObjJob.SelectNametblCase();
            if (dsNametblCase.Tables[0].Rows.Count == 0)
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

        private void btnAddTaskSJ_Click(object sender, EventArgs e)
        {
            ObjJob.Date_End = dtpTaskSJGhabelanjam.Value.ToString().Substring(0, 10);
            ObjJob.ID_Acting = cmbReqSJActing.SelectedValue.ToString();
            ObjJob.ID_Cases = cmbReqSJCases.SelectedValue.ToString();
            ObjJob.Time_do_Task = txtTaskSJTime.Text.Trim();
            ObjJob.description_Task = rtxtdescription_Task.Text.Trim();
            try
            {

                txtTaskSJID_Task.Text = ObjJob.Insert_TaskSorat().Tables[0].Rows[0]["IDTask"].ToString();
                MasterTemplate.DataSource = ObjJob.SelectTask(UnitMasool).Tables[0];
                gridViewTemplate1.DataSource = ObjJob.SelectTaskPers().Tables[0];
                gridViewTemplate2.DataSource = ObjJob.SelectTaskActionRep().Tables[0];
            }

            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }
            TaskSJID = txtTaskSJID_Task.Text.Trim();
            if (!string.IsNullOrEmpty(TaskSJID))
            {
                RadMessageBox.Show("وظیفه ثبت شد");
            }
            


            btnDelTaskSJ.Enabled = true;
            btnUpdTaskSJ.Enabled = true;
            grbVaziat.Enabled = true;
            btnVaziatTaskSJ.Enabled = true;
            btnErjaTaskSJ.Enabled = true;
        }

        private void chkaskSJPersonel_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkaskSJPersonel.Checked == true && !string.IsNullOrEmpty(TaskSJID) )
            {
                cmbTaskSJPersonel.DataSource = ObjJob.SelectPersonelUnit().Tables[0];
                cmbTaskSJPersonel.ValueMember = "code_personeli";
                cmbTaskSJPersonel.DisplayMember = "name";
            }
            else if (chkaskSJPersonel.Checked == true && string.IsNullOrEmpty(TaskSJID))
            { 
                RadMessageBox.Show("وظیفه را تعیین کنید");
                chkaskSJPersonel.Checked = false;
                return;
            }
            else
                if (chkaskSJPersonel.Checked == false)
                {
                    cmbTaskSJPersonel.DataSource = null;
                    
                }
        }

        private void btnDelTaskSJ_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TaskSJID))
            {
                RadMessageBox.Show("وظیفه ای تعیین نشده است");
                return;
            }
            try
            {
                RadMessageBox.Show(ObjJob.DeleteTask());
                MasterTemplate.DataSource = ObjJob.SelectTask(UnitMasool).Tables[0];
                gridViewTemplate1.DataSource = ObjJob.SelectTaskPers().Tables[0];
                gridViewTemplate2.DataSource = ObjJob.SelectTaskActionRep().Tables[0];
            }
           catch(Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }
           
        }

        private void btnVaziatTaskSJ_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TaskSJID))
            {
                RadMessageBox.Show("وظیفه ای تعیین نشده است");
                return;
            }
            ObjJob.TaskSJID = TaskSJID;

            ObjJob.EndTaskDescript = rtxtTaskSJDescEnd.Text.Trim();

            if (rbtnTaskSJEghdam_Task.Checked == true)
            {
                ObjJob.EndTask = "null";
            }
            else
                if (rbtnTaskSJCancel_Task.Checked == true)
                    ObjJob.EndTask = "0";
              else
            
                if ( rbtnTaskSJEnd_Task.Checked ==true)
                    ObjJob.EndTask = "1";

            try
            {
                if (ObjJob.EndTask == "1" || ObjJob.EndTask == "0")
                {
                    RadMessageBox.Show(ObjJob.UpdateTaskVaziat());
                    btnClearTaskSJ_Click(sender, e);
                    MasterTemplate.DataSource = ObjJob.SelectTask(UnitMasool).Tables[0];
                    gridViewTemplate1.DataSource = ObjJob.SelectTaskPers().Tables[0];
                    gridViewTemplate2.DataSource = ObjJob.SelectTaskActionRep().Tables[0];
                }
                
            }

            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }
            
        }

        private void btnErjaTaskSJ_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TaskSJID))
            {
                RadMessageBox.Show("وظیفه ای تعیین نشده است");
                return;
            }
            ObjJob.TaskSJID = TaskSJID;
            ObjJob.FK_ID_Personel = cmbTaskSJPersonel.SelectedValue.ToString();
            ObjJob.Order_desc = rtxtTaskSJDescErja.Text.Trim();
            try
            {
                RadMessageBox.Show(ObjJob.InsertTaskPersonelsj());
                MasterTemplate.DataSource = ObjJob.SelectTask(UnitMasool).Tables[0];
                gridViewTemplate1.DataSource = ObjJob.SelectTaskPers().Tables[0];
                gridViewTemplate2.DataSource = ObjJob.SelectTaskActionRep().Tables[0];
            }

            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }
        }

        private void FrmJobTaskModir_Load(object sender, EventArgs e)
        {
            try
            {
                UnitMasool = ObjJob.SelectUnitPersonel().Tables[0].Rows[0]["ID_Unit"].ToString();
                MasterTemplate.DataSource = ObjJob.SelectTask(UnitMasool).Tables[0];
                gridViewTemplate1.DataSource = ObjJob.SelectTaskPers().Tables[0];
                gridViewTemplate2.DataSource = ObjJob.SelectTaskActionRep().Tables[0];


                dtpTaskSJGhabelanjam.Value = DateTime.Now;
                //---------------------------------------------------------------------acting
                ObjJob.ID_UnitSJ = UnitMasool;

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

        private void btnErjaTaskPer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ObjJob.IDTaskPersonel))
            {
                RadMessageBox.Show("شناسه وظیفه کاربر را مشخص کنید");
            }
            try
            {
                RadMessageBox.Show(ObjJob.UpdateTP_Rej());
                MasterTemplate.DataSource = ObjJob.SelectTask(UnitMasool).Tables[0];
                gridViewTemplate1.DataSource = ObjJob.SelectTaskPers().Tables[0];
                gridViewTemplate2.DataSource = ObjJob.SelectTaskActionRep().Tables[0];
            }
           catch(Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }
        }

        private void GrdJobTask_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (MasterTemplate.CurrentRow.HierarchyLevel == 1)//click on template
            {
                btnClearTaskSJ_Click(sender, e);
                strID_Task_Per = MasterTemplate.Templates[0].Rows[e.RowIndex].Cells["ID_Task_Personel"].Value.ToString();
                ObjJob.IDTaskPersonel = strID_Task_Per;
                txtID_Task_Per.Text = strID_Task_Per;
                txtTaskSJID_Task.Text = MasterTemplate.Templates[0].Rows[e.RowIndex].Cells["FK_ID_Task"].Value.ToString();
                btnRegTaskPer.Enabled = true;
            }
            else
                if (MasterTemplate.CurrentRow.HierarchyLevel == 0)
                {
                    btnClearTaskSJ_Click(sender, e);
                    string strFK_ID_HSoratJ = "", strerjae_modir = "";
                    txtTaskSJID_Task.Text = MasterTemplate.Rows[e.RowIndex].Cells["ID_Task"].Value.ToString();
                    TaskSJID = txtTaskSJID_Task.Text;

                    txtTaskSJTime.Text = MasterTemplate.Rows[e.RowIndex].Cells["Time_do_Task"].Value.ToString();
                    rtxtdescription_Task.Text = MasterTemplate.Rows[e.RowIndex].Cells["description_Task"].Value.ToString();
                    dtpTaskSJGhabelanjam.Text = MasterTemplate.Rows[e.RowIndex].Cells["Date_End"].Value.ToString();//.Value.ToString().Substring(0, 10);
                    cmbReqSJActing.Text = MasterTemplate.Rows[e.RowIndex].Cells["NActing"].Value.ToString();
                    cmbReqSJActing.SelectedValue = MasterTemplate.Rows[e.RowIndex].Cells["FK_ID_Acting"].Value;
                    cmbReqSJActing_SelectedValueChanged(sender, e);
                    cmbReqSJCases.SelectedValue = MasterTemplate.Rows[e.RowIndex].Cells["FK_ID_Cases"].Value;

                    strerjae_modir = Convert.ToBoolean(MasterTemplate.Rows[e.RowIndex].Cells["erjae_modir"].Value).ToString();
                    strFK_ID_HSoratJ = MasterTemplate.Rows[e.RowIndex].Cells["ID_HSoratJ"].Value.ToString();
                    if (string.IsNullOrEmpty(MasterTemplate.Rows[e.RowIndex].Cells["EndTask"].Value.ToString()) == true)
                    {
                        rbtnTaskSJEghdam_Task.Checked = true;
                    }
                    if (!string.IsNullOrEmpty(TaskSJID))
                    {

                        grbVaziat.Enabled = true;
                        btnVaziatTaskSJ.Enabled = true;
                        btnErjaTaskSJ.Enabled = true;

                    }
                    if (string.IsNullOrEmpty(strFK_ID_HSoratJ) == false || strerjae_modir == "false")//sorat jalase va biron vahed nabayad delete or update shavad
                    {
                        btnDelTaskSJ.Enabled = false;
                        btnUpdTaskSJ.Enabled = false;
                    }
                    else
                    {
                        btnDelTaskSJ.Enabled = true;
                        btnUpdTaskSJ.Enabled = true;
                    }


                    //else
                    //{
                    //    rbtnTaskSJCancel_Task.Checked = !Convert.ToBoolean(GrdTaskSJ.Rows[e.RowIndex].Cells["EndTask"].Value);
                    //    rbtnTaskSJEnd_Task.Checked = Convert.ToBoolean(GrdTaskSJ.Rows[e.RowIndex].Cells["EndTask"].Value);
                    //}
                    rtxtTaskSJDescEnd.Text = MasterTemplate.Rows[e.RowIndex].Cells["EndTaskDescript"].Value.ToString();
                    //chkTaskSJEnd_Task.Checked = Convert.ToBoolean(GrdTaskSJ.Rows[e.RowIndex].Cells["EndTask"].Value);
                }
        }
    }
}

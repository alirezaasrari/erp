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
    public partial class FrmJobAction : Telerik.WinControls.UI.RadForm
    {
        public FrmJobAction()
        {
            InitializeComponent();
        }
        ClsJob ObjJob = new ClsJob();
        public string ID_Task_Personel, ID_Action_Report;
        private void FrmJobAction_Load(object sender, EventArgs e)
        {
            dtpobActionDate_do.Value = DateTime.Now;
            GrdJobAction.DataSource = ObjJob.SelectTaskPrsonelsj().Tables[0];
            gridViewTemplate1.DataSource = ObjJob.SelectActionReportsj().Tables[0];
        }

        private void btnAddJobAction_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ID_Task_Personel))
            {
                RadMessageBox.Show("وظیفه ای برای پرسنل تعیین نشده است");
                return;
            }
            ObjJob.IDTaskPersonel=ID_Task_Personel;
            ObjJob.Do_time_start=mebJobActionTimeF.Text;
            ObjJob.Do_time_end=mebJobActionTimeE.Text;
            ObjJob.Description=rtxtJobActionDesc.Text;
            ObjJob.Date_do = dtpobActionDate_do.Value.ToString().Substring(0, 10);
            try
            {
                txtJobActionIDActionRep.Text = ObjJob.ID_Action_Report = ID_Action_Report = ObjJob.Insert_ActionReportSJ().Tables[0].Rows[0]["ID_Action_Report"].ToString();
                RadMessageBox.Show("عملکرد ثبت شد");
                GrdJobAction.DataSource = ObjJob.SelectTaskPrsonelsj().Tables[0];
                gridViewTemplate1.DataSource = ObjJob.SelectActionReportsj().Tables[0];
            }
           catch(Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }
            
        }

        private void btnEndJobAction_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ID_Task_Personel))
            {
                RadMessageBox.Show("وظیفه ای برای پرسنل تعیین نشده است");
                return;
            }
            ObjJob.IDTaskPersonel = ID_Task_Personel;
            try
            {
                RadMessageBox.Show(ObjJob.UpdateTP_ENDSJ());
                //GrdJobAction.DataSource = ObjJob.SelectTaskPrsonelsj().Tables[0];
                btnClearJobAction_Click(sender, e);
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
                
            }
        }

        private void btnUpdJobAction_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ID_Task_Personel))
            {
                RadMessageBox.Show("وظیفه ای برای پرسنل تعیین نشده است");
                return;
            }
            if (string.IsNullOrEmpty(ID_Action_Report))
            {
                RadMessageBox.Show("گزارش عملکردی برای پرسنل تعیین نشده است");
                return;
            }

            ObjJob.ID_Action_Report = ID_Action_Report;
            ObjJob.Do_time_start = mebJobActionTimeF.Text;
            ObjJob.Do_time_end = mebJobActionTimeE.Text;
            ObjJob.Description = rtxtJobActionDesc.Text;
            ObjJob.Date_do = dtpobActionDate_do.Value.ToString().Substring(0, 10);
            try
            { 
                RadMessageBox.Show(ObjJob.UpdateActionReport());
                GrdJobAction.DataSource = ObjJob.SelectTaskPrsonelsj().Tables[0];
                gridViewTemplate1.DataSource = ObjJob.SelectActionReportsj().Tables[0];
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }
            
        }

        private void btnDelJobAction_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ID_Task_Personel))
            {
                RadMessageBox.Show("وظیفه ای برای پرسنل تعیین نشده است");
                return;
            }
            if (string.IsNullOrEmpty(ID_Action_Report))
            {
                RadMessageBox.Show("گزارش عملکردی برای پرسنل تعیین نشده است");
                return;
            }

            ObjJob.ID_Action_Report = ID_Action_Report;
            try 
            { 
                RadMessageBox.Show(ObjJob.del_Action_TP());
                GrdJobAction.DataSource = ObjJob.SelectTaskPrsonelsj().Tables[0];
                gridViewTemplate1.DataSource = ObjJob.SelectActionReportsj().Tables[0];
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }
            
        }

        private void btnClearJobAction_Click(object sender, EventArgs e)
        {
            ObjJob.ID_Action_Report = ID_Action_Report = "";
            ObjJob.IDTaskPersonel=ID_Task_Personel = "";
            rtxtJobActionDesc.Clear();
            rtxtJobActionDescEnd.Clear();
            
            mebJobActionTimeF.Clear();
            mebJobActionTimeE.Clear();
            
            GrdJobAction.DataSource = null;
            gridViewTemplate1.DataSource = null;
            dtpobActionDate_do.Value = DateTime.Now;
            GrdJobAction.DataSource = ObjJob.SelectTaskPrsonelsj().Tables[0];
            gridViewTemplate1.DataSource = ObjJob.SelectActionReportsj().Tables[0];
            txtJobActionIDTaskPer.Clear();
            txtJobActionIDActionRep.Clear();
            btnAddJobAction.Enabled = false;
            btnDelJobAction.Enabled = false;
            btnUpdJobAction.Enabled = false;
            btnEndJobAction.Enabled = false;

        }

        

        private void GrdJobAction_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (GrdJobAction.CurrentRow.HierarchyLevel == 1)//click on template
            {
                txtJobActionIDTaskPer.Text = ObjJob.IDTaskPersonel = ID_Task_Personel = GrdJobAction.Templates[0].Rows[e.RowIndex].Cells["FK_ID_Task_Personel"].Value.ToString();
                txtJobActionIDActionRep.Text = ObjJob.ID_Action_Report =ID_Action_Report= GrdJobAction.Templates[0].Rows[e.RowIndex].Cells["ID_Action_Report"].Value.ToString();
                rtxtJobActionDesc.Text = GrdJobAction.Templates[0].Rows[e.RowIndex].Cells["Description"].Value.ToString();

                dtpobActionDate_do.Text = GrdJobAction.Templates[0].Rows[e.RowIndex].Cells["Date_do"].Value.ToString();
                mebJobActionTimeF.Text = GrdJobAction.Templates[0].Rows[e.RowIndex].Cells["Do_time_start"].Value.ToString();
                mebJobActionTimeE.Text = GrdJobAction.Templates[0].Rows[e.RowIndex].Cells["Do_time_end"].Value.ToString();
                btnAddJobAction.Enabled = true;
                btnDelJobAction.Enabled = true;
                btnUpdJobAction.Enabled = true;
                btnEndJobAction.Enabled = true;
                return;
            }
            else
            {
                txtJobActionIDTaskPer.Text = ObjJob.IDTaskPersonel = ID_Task_Personel = GrdJobAction.Rows[e.RowIndex].Cells["ID_Task_Personel"].Value.ToString();
                txtJobActionIDActionRep.Text = ObjJob.ID_Action_Report = ID_Action_Report = "";
                btnAddJobAction.Enabled = true;
                btnEndJobAction.Enabled = true;
                btnAddJobAction.Enabled = true;
            }
            
        }
        
             
         
    }
}

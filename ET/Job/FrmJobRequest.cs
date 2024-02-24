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
    public partial class FrmJobRequest : Telerik.WinControls.UI.RadForm
    {
        public FrmJobRequest()
        {
            InitializeComponent();
        }
        ClsJob ObjJob = new ClsJob();
        public string Unite_Inserted = "", TaskSJID = "", strEndTask ="";
        private void FrmJobRequest_Load(object sender, EventArgs e)
        {
            Unite_Inserted = ObjJob.SelectUnitPersonel().Tables[0].Rows[0]["ID_Unit"].ToString();
            GrdReqSJ.DataSource = ObjJob.SelectReq(Unite_Inserted).Tables[0];
            dtpReqSJAnjam.Value = DateTime.Now;
            
            
            //---------------------------------------------------------------------vahed masool
            cmbReqSJVahed.DataSource = ObjJob.SelectUniteSorat().Tables[0];
            cmbReqSJVahed.ValueMember = "IdUnit";
            cmbReqSJVahed.DisplayMember = "onvan";
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
                RadMessageBox.Show(" صورت جلسه را تعیین نمایید");
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

        private void cmbReqSJCases_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbReqSJCases.SelectedValue == null || cmbReqSJCases.SelectedValue.ToString() == "System.Data.DataRowView" || cmbReqSJCases.SelectedText.ToString() == "System.Data.DataRowView")
            {
                cmbReqSJCases.Text = "";
                return;
            }
            ObjJob.ReqSJCases = cmbReqSJCases.SelectedValue.ToString();
        }

        private void btnClearReqSJ_Click(object sender, EventArgs e)
        {
            cmbReqSJVahed.SelectedValue = null;
            txtReqSJ_ID.Clear();
            rtxtReqSJDesc.Clear();
            cmbReqSJActing.DataSource = null;
            dtpReqSJAnjam.Value = DateTime.Now;
            cmbReqSJCases.DataSource = null;
            rbtnReqSJPriAdi.Checked = true;
            rbtnReqSJActive.Checked = true;
            ObjJob.IDRequest = "";
            txtReqSJ_ID.Clear();
            ObjJob.RejectedRequest = "";
            rtxtRejectedDalil.Clear();
            btnRejectedDalil.Enabled = false;
        }

        private void btnAddReqSJ_Click(object sender, EventArgs e)
        {
            
            ObjJob.Priority = (rbtnReqSJPrifori.Checked == true ? "1" : "0");
            ObjJob.Status_Case = (rbtnReqSJNotActive.Checked == true ? "1" : "0");
            
            ObjJob.ReqSJDesc = rtxtReqSJDesc.Text;
            ObjJob.DateNiaz = dtpReqSJAnjam.Value.ToString().Substring(0, 10);
            RadMessageBox.Show(ObjJob.InsertTaskREQSorat());
            GrdReqSJ.DataSource = ObjJob.SelectReq(Unite_Inserted).Tables[0];
        }

        private void btnRejectedDalil_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtReqSJ_ID.Text.Trim()))
            {
                RadMessageBox.Show(" درخواست را تعیین نمایید");
                return;
            }
            ObjJob.IDRequest = txtReqSJ_ID.Text.Trim();
            ObjJob.RejectedRequest = rtxtRejectedDalil.Text.Trim();
            try
            {
                RadMessageBox.Show(ObjJob.UpdateReject());
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }
            GrdReqSJ.DataSource = ObjJob.SelectReq(Unite_Inserted).Tables[0];
        }

        private void GrdReqSJ_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
           
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
    }
}

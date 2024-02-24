using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;

namespace ET
{
    public partial class FrmPM_RepairShow : Telerik.WinControls.UI.RadForm
    {
        public FrmPM_RepairShow()
        {
            InitializeComponent();
        
        }
        ClsPM cp = new ClsPM();
      
      
        private void FrmPM_RepairShow_Load(object sender, EventArgs e)
        {

            if (chkShowForm.Checked == true) { cp.FlagShowRepair = true; }
            if (chkShowForm.Checked == false) { cp.FlagShowRepair = false; }
            //grd_HRepair.DataSource = cp.select_JobRepair().Tables[0];
            grd_HRepair.DataSource = cp.Select_HRepair().Tables[0];

            this.grd_HRepair.MasterTemplate.ShowHeaderCellButtons = true; 
            this.grd_HRepair.MasterTemplate.ShowFilteringRow = false;
            this.grd_HRepair.FilterPopupRequired += new FilterPopupRequiredEventHandler(radGridView1_FilterPopupRequired);
           
        }
        void radGridView1_FilterPopupRequired(object sender, FilterPopupRequiredEventArgs e)
        { return; }

        private void grd_HRepair_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {

            //if (grd_HRepair.Rows[e.RowIndex].Cells["EndTask"].Value.ToString() == "True" ) 
            //{
            //    MessageBox.Show("فرم غیر قابل ویرایش است بدلیل تحویل شدن");
            //}
            //else
            //  {
            FrmPM_Repair frm = new FrmPM_Repair();
            try
            {
                //frm.txtDescription_Task.Text = grd_HRepair.Rows[e.RowIndex].Cells["description_Task"].Value.ToString();
                frm.cmbN_machine.Text = grd_HRepair.Rows[e.RowIndex].Cells["N_machine"].Value.ToString();

                if (grd_HRepair.Rows[e.RowIndex].Cells["Time_delay"].Value.ToString() == "")
                    frm.txb_time_delay.Value = 0;
                else
                    frm.txb_time_delay.Value = Convert.ToInt32(grd_HRepair.Rows[e.RowIndex].Cells["Time_delay"].Value.ToString());
                frm.txb_reason_delay.Text = grd_HRepair.Rows[e.RowIndex].Cells["Reason_delay"].Value.ToString();
                //frm.ID_Task = grd_HRepair.Rows[e.RowIndex].Cells["ID_Task"].Value.ToString();
                if (grd_HRepair.Rows[e.RowIndex].Cells["ID_HRepair"].Value.ToString() == "")
                {
                    frm.ID_HRepair = "0";
                    frm.btn_save.Enabled = true;
                    frm.btnUpdate.Enabled = false;
                    frm.btnDelete.Enabled = false;
                    frm.grpRepair1.Enabled = false;
                    frm.grpRepair2.Enabled = false;
                    frm.grpRepair3.Enabled = false;
                    frm.chkEndTask.Enabled = false;
                }
                else
                {
                    frm.ID_HRepair = grd_HRepair.Rows[e.RowIndex].Cells["ID_HRepair"].Value.ToString();
                    frm.btn_save.Enabled = false;
                    frm.grpRepair1.Enabled = true;
                    frm.grpRepair2.Enabled = true;
                    frm.grpRepair3.Enabled = true;
                }
                //frm.txtDateFailure.Text = grd_HRepair.Rows[e.RowIndex].Cells["DateInsert"].Value.ToString();
                //frm.txtTimeFailure.Text = grd_HRepair.Rows[e.RowIndex].Cells["timerequest"].Value.ToString();
                //if (grd_HRepair.Rows[e.RowIndex].Cells["FK_IDRequest"].Value.ToString() != null &&
                //    grd_HRepair.Rows[e.RowIndex].Cells["FK_IDRequest"].Value.ToString() != "")
                //{
                //    frm.txtDateStartR.Text = grd_HRepair.Rows[e.RowIndex].Cells["DateRequest"].Value.ToString().Substring(0, 10);
                //    frm.txtTimeStartR.Text = grd_HRepair.Rows[e.RowIndex].Cells["TimeStart"].Value.ToString();
                //    frm.txtEndStartR.Text = grd_HRepair.Rows[e.RowIndex].Cells["Date_Time_END"].Value.ToString();
                //    frm.txtTimeEndR.Text = grd_HRepair.Rows[e.RowIndex].Cells["TimeEnd"].Value.ToString();
                //    if (grd_HRepair.Rows[e.RowIndex].Cells["TPM"].Value.ToString() == "")
                //        frm.chk_TPM.Checked = false;
                //    else
                //        frm.chk_TPM.Checked = Convert.ToBoolean(grd_HRepair.Rows[e.RowIndex].Cells["TPM"].Value.ToString());
                //    frm.txb_preamble.Text = grd_HRepair.Rows[e.RowIndex].Cells["Preamble"].Value.ToString();
                //    frm.lbl_ID_HRepair.Text = grd_HRepair.Rows[e.RowIndex].Cells["FK_IDRequest"].Value.ToString();
                //}
                //if(grd_HRepair.Rows[e.RowIndex].Cells["EndTask"].Value.ToString()=="True") frm.chkEndTask.Checked = true ;
                //if (grd_HRepair.Rows[e.RowIndex].Cells["EndTask"].Value.ToString() == "False") frm.chkEndTask.Checked = false;
                if (grd_HRepair.Rows[e.RowIndex].Cells["Bargh"].Value.ToString() == "1") frm.rbtnBargh.IsChecked = true;
                else
                    if (grd_HRepair.Rows[e.RowIndex].Cells["Bargh"].Value.ToString() == "2") frm.rbtnMechanic.IsChecked = true;
                //frm.txtEndTaskDescript.Text = grd_HRepair.Rows[e.RowIndex].Cells["EndTaskDescript"].Value.ToString();

                ClsPM.IDFailure = grd_HRepair.Rows[e.RowIndex].Cells["ID_Failure"].Value.ToString();
                //if (grd_HRepair.Rows[e.RowIndex].Cells["Status_Machine"].Value.ToString() == "")
                //    chkTavaghof.Checked = false;
                //else
                //    chkTavaghof.Checked = Convert.ToBoolean(grd_HRepair.Rows[e.RowIndex].Cells["Status_Machine"].Value.ToString());
                //frm.btnDelActionReport.Enabled = false;
                //frm.btnAction.Enabled = false;
                frm.ShowDialog();
                grd_HRepair.DataSource = cp.Select_HRepair().Tables[0];
            }
            catch
            {
            }
            //}
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (chkShowForm.Checked == true) { cp.FlagShowRepair = true; }
            if (chkShowForm.Checked == false) { cp.FlagShowRepair = false; }
            grd_HRepair.DataSource = cp.Select_HRepair().Tables[0];
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string fileName = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = string.Format("{0} (*{1})|*{1}", "Excel Files", ".xls")
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
            }
                (new ExportToExcelML(this.grd_HRepair)).RunExport(fileName);
            if (RadMessageBox.Show("فایل اکسل ایجاد شد.آیا می خواهید فایل باز شود؟", "Export to Excel", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Process.Start(fileName);
                }
                catch
                {
                }
            }
        }
    }
}

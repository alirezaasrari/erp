using System;
using Telerik.WinControls.UI;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI.Export;
using System.Diagnostics;




namespace ET
{
    public partial class FrmPM_Calendar : Telerik.WinControls.UI.RadForm
    {
        public FrmPM_Calendar()
        {
            InitializeComponent();
        }
        DataTable DtCalender = new DataTable();
        ClsPM objpm = new ClsPM();
        DataTable DtSerchIns = new DataTable();
        class ViewDefinitionInfo
        {
            public List<string> Columns; 
            public IGridViewDefinition ViewDefinition;
            public int RowHeight = 30;
            public int HeaderHeight = 30;     
        } 
        private void FrmPM_Calendar_Load(object sender, EventArgs e)
        {
            //DtCalender = objpm.Select_InstructionCalendar().Tables[0];
            //grdCalendar.DataSource = DtCalender;
            dt1.Value = DateTime.Now;
            dt2.Value = DateTime.Now;

            drp_Machine.DataSource = objpm.selectNameMachine().Tables[0];
            drp_Machine.DisplayMember = "N_machine";
            drp_Machine.ValueMember = "ID_machine";
            drp_Machine.SelectedIndex = 1;

            chkMachin.Checked = true;

            ////***************************************************************************************************
            //try
            //{
            //    this.grdCalendar.LoadLayout(@"C:\Users\" + Environment.UserName + @"\AppData\Local\grdCalendar.xml");
            //}
            //catch { }          
        }
        private void btnShowIns_Click(object sender, EventArgs e)
        {
            objpm.IDInstruction = "";
            objpm.DateStart = dt1.Value.ToString().Substring(0, 10);
            objpm.DateEnd = dt2.Value.ToString().Substring(0, 10);
            objpm.ID_Machine = "";
            if (chkMachin.IsChecked)
            {
                objpm.ID_Machine = drp_Machine.SelectedValue.ToString();
            }
            if (chkInstruction.IsChecked)
            {
                objpm.IDInstruction = txtIDInstruction.Text;
            }
            if (rdbNoDo.IsChecked == true)
                objpm.DoTask = false;
            else
                objpm.DoTask = true;
            grdCalendar.DataSource = objpm.Select_InstructionCalendar().Tables[0];

            //DataTable dti = new DataTable();
            //if (chkMachin.IsChecked)
            //{
            //    objpm.ID_Machine = drp_Machine.SelectedValue.ToString();
            //    dti = objpm.Select_Instruction().Tables[0];
            //}
            //if (chkInstruction.IsChecked)
            //{

            //    DataRow[] dr = DtSerchIns.Select("ID_Instruction=" + txtIDInstruction.Text + "");
            //    dti = dr.CopyToDataTable();
            //}

            //DataTable Dt_tblCalender = objpm.select_tblCalender().Tables[0];
            //DateTime dateS = new DateTime();
            //DateTime dateE = new DateTime();
            //dateE = dt2.Value;

            //for (int i = 0; i <= dti.Rows.Count - 1; i++)
            //{                
            //    int x = (int)dti.Rows[i]["PeriodicityDay"];
            //    TimeSpan span = new TimeSpan(x, 0, 0, 0);
            //    DataRow[] dr = Dt_tblCalender.Select("FKID_Instruction ="+dti.Rows[i]["ID_Instruction"].ToString() +" ");
            //    if (dr.Length > 0)
            //    {
            //        Dt_tblCalender = dr.CopyToDataTable();
            //        dateS = (DateTime)Dt_tblCalender.Compute("Max(DateIns)", "")+span;
            //    }
            //    else dateS = dt1.Value;
            //    while (dateS < dateE)
            //    {
            //        DtCalender.Rows.Add(dti.Rows[i]["ID_Instruction"].ToString()
            //            ,null

            //            ,dti.Rows[i]["MoreViewsIns"].ToString()
            //            ,dti.Rows[i]["StatusM"].ToString()
            //            ,dti.Rows[i]["TimeDoService"].ToString()
            //            ,dti.Rows[i]["PeriodicityDay"].ToString()
            //            , null
            //            , null
            //            , null
            //            ,dti.Rows[i]["DescriptionIns"].ToString()
            //            , null
            //            , null
            //            , null
            //            ,dti.Rows[i]["Description"].ToString()
            //            ,dti.Rows[i]["N_machine"].ToString()
            //            ,dti.Rows[i]["codmachine"].ToString()
            //            ,dti.Rows[i]["Unit_Placed"].ToString()
            //            , null
            //            ,dateS.ToString().Substring(0, 10));
            //             dateS = dateS + span;
            //    }
            //}
            //grdCalendar.DataSource = DtCalender;
        }
        private void drp_Machine_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                objpm.ID_Machine = drp_Machine.SelectedValue.ToString();
                lblCodMachine.Text = objpm.selectNameMachine().Tables[0].Rows[0]["codmachine"].ToString();
                objpm.ID_Machine = null;
            }
            catch
            {
            }
        }
        private void btnRefreshgrd_Click(object sender, EventArgs e)
        {
            DtCalender = objpm.Select_InstructionCalendar().Tables[0];
            grdCalendar.DataSource = DtCalender;
        }
        private void txtIDInstruction_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
           
        }
        private void chkMachin_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chkMachin.IsChecked)
            {
                txtIDInstruction.Enabled = false;
                lblInstruction.Text = "-";
                drp_Machine.Enabled = true;
                chkMachin.Checked = true;
                chkInstruction.Checked = false;
                txtIDInstruction.Text = null;
                btnAdd.Enabled = true;
            }
            else
                btnAdd.Enabled = false;
        }
        private void chkInstruction_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chkInstruction.IsChecked)
            {
                drp_Machine.Enabled = false;
                drp_Machine.SelectedIndex = -1;
                lblCodMachine.Text = "-";
                txtIDInstruction.Enabled = true;
                chkMachin.Checked = false;
                chkInstruction.Checked = true;
                objpm.ID_Machine = null;
                DtSerchIns = objpm.Select_Instruction().Tables[0];
            }
        }
        private void txtIDInstruction_TextChanged(object sender, EventArgs e)
        {
            if (txtIDInstruction.Text.Length > 0)
            {
                DataRow[] dr = DtSerchIns.Select("ID_Instruction=" + txtIDInstruction.Text + "");
                if (dr.Length > 0) lblInstruction.Text = dr[0]["MoreViewsIns"].ToString(); 
                else lblInstruction.Text = "-";
            }
            else 
            {
                 lblInstruction.Text = "-";
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            //if (chkInstruction.IsChecked) 
            //{
            //    objpm.IDInstruction = txtIDInstruction.Text;
            //    objpm.ID_Machine = "0";
            //}
            //if (chkMachin.IsChecked)
            //{
            //    objpm.IDInstruction = "0";
            //    objpm.ID_Machine = drp_Machine.SelectedValue.ToString();
            //}
            //objpm.DateStart = dt1.Value.ToString().Substring(0, 10);
            //objpm.DateEnd = dt2.Value.ToString().Substring(0, 10);
            objpm.IDInstruction = "0";
            objpm.ID_Machine = drp_Machine.SelectedValue.ToString();
            objpm.DateStart = "CONVERT(NCHAR(10),GETDATE(),102)";
            objpm.DateEnd = "1395/12/30";
            RadMessageBox.Show(objpm.InsCalendar());
            //***********
            DtCalender = objpm.Select_InstructionCalendar().Tables[0];
            grdCalendar.DataSource = DtCalender;
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            RadPrintPreviewDialog dialog = new RadPrintPreviewDialog();
            dialog.ThemeName = this.grdCalendar.ThemeName;
            dialog.Document = this.radPrintDocument1;
            dialog.StartPosition = FormStartPosition.CenterScreen;
            dialog.ShowDialog(); 
        }
        private void btnDelForm_Click(object sender, EventArgs e)
        {
            if (RadMessageBox.Show("آیا از حذف تقویم دستگاه اطمینان دارید؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //objpm.DateStart = dt1.Value.ToString().Substring(0, 10);
                //objpm.DateEnd = dt2.Value.ToString().Substring(0, 10);
                objpm.DateStart = "1395/01/01";
                objpm.DateEnd = "1395/12/30";
                //if (chkInstruction.IsChecked)
                //{
                //    objpm.IDInstruction = txtIDInstruction.Text;
                //    RadMessageBox.Show(objpm.DelCalendarInstruction());
                //}
                if (chkMachin.IsChecked)
                {
                    objpm.ID_Machine = drp_Machine.SelectedValue.ToString();
                    RadMessageBox.Show(objpm.DelCalendarMachin());
                }
                //***********************************************************************************
                DtCalender = objpm.Select_InstructionCalendar().Tables[0];
                grdCalendar.DataSource = DtCalender;
            }
        }
        private void grdCalendar_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (grdCalendar.CurrentColumn.Index >0 & grdCalendar.CurrentRow.Index > -1 )
            {
                objpm.IdCalendar =  grdCalendar.CurrentRow.Cells["IdCalendar"].Value.ToString();                
                FrmPM_AddTask frm = new FrmPM_AddTask();
                frm.StrMachinCod = grdCalendar.CurrentRow.Cells["FKIdMachine"].Value.ToString();
                frm.TimeDoService = grdCalendar.CurrentRow.Cells["TimeDoService"].Value.ToString();
                frm.MoreViewsIns = grdCalendar.CurrentRow.Cells["MoreViewsIns"].Value.ToString();
                frm.IdCalendar = grdCalendar.CurrentRow.Cells["IdCalendar"].Value.ToString();
                frm.ShowDialog();
                //***********************************************************************************
                DtCalender = objpm.Select_InstructionCalendar().Tables[0];
                grdCalendar.DataSource = DtCalender;
            }
        }       
        private void FrmPM_Calendar_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.grdCalendar.SaveLayout(@"C:\Users\" + Environment.UserName + @"\AppData\Local\grdCalendar.xml");            
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            string fileName = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = string.Format("{0} (*{1})|*{1}", "Excel Files", ".xlsx")
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
            }
           
            (new ExportToExcelML(this.grdCalendar)).RunExport(fileName);
           
            if (RadMessageBox.Show("اطلاعات به درستی خارج شد.آیا می خواهید فایل باز شود؟", "Export to Excel", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
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
        private void chkMashinNoCal_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chkMashinNoCal.Checked == false)
            {
                objpm.ID_Machine = "";
                drp_Machine.DataSource = objpm.selectNameMachine().Tables[0];
                drp_Machine.DisplayMember = "N_machine";
                drp_Machine.ValueMember = "ID_machine";
                //drp_Machine.SelectedIndex = -1;
            }
            else
            {
                drp_Machine.DataSource = objpm.selectNameMachineNoCalc().Tables[0];
                drp_Machine.DisplayMember = "N_machine";
                drp_Machine.ValueMember = "ID_machine";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;

namespace ET
{
    public partial class FrmPM_Instruction : Telerik.WinControls.UI.RadForm
    {
        public FrmPM_Instruction()
        {
            InitializeComponent();           
        }

        ClsPM objpm = new ClsPM();
      
        string IDInstruction;
        bool IsCalender;

        private void FrmPM_Instruction_Load(object sender, EventArgs e)
        {
            NewInstruction();
        }
       
        private void drp_Machine_SelectedValueChanged(object sender, EventArgs e)
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

        private void txtDosageSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && (txtDosageSP.Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btn_ADD_Section_Click(object sender, EventArgs e)
        {
            objpm.ID_Machine = drp_Machine.SelectedValue.ToString();
            objpm.MoreViewsIns = txtMoreViews.Text;
            if (rbtnStatusM0.IsChecked == true)
                objpm.StatusM = "0";
            if (rbtnStatusM1.IsChecked == true)
                objpm.StatusM = "1";
            objpm.TimeDoService = txtTimeDoService.Value.ToString();
            objpm.PeriodicityDay = txtPeriodicityDay.Value.ToString();
            if (!String.IsNullOrEmpty(drpSparePart.Text))
                objpm.ID_SparePart = drpSparePart.SelectedValue.ToString();
            objpm.DosageSP = txtDosageSP.Text;
            objpm.IDMasolejra = drpMasolejra.SelectedValue.ToString();
            objpm.DescriptionIns = txtDescriptionIns.Text;
            MessageBox.Show(objpm.InsInstruction());
            NewInstruction();
        }

        private void NewInstruction()
        {
            grd_Instruction.Enabled = true;
            objpm.ID_Machine = null;
            //drp_Machine.DataSource = objpm.selectMachinedrp().Tables[0];
            drp_Machine.DataSource = objpm.selectNameMachine().Tables[0];
            drp_Machine.DisplayMember = "N_machine";
            drp_Machine.ValueMember = "ID_machine";
            drp_Machine.SelectedIndex = -1;

            drpMasolejra.DataSource = objpm.selectMasolejra().Tables[0];
            drpMasolejra.DisplayMember = "Description";
            drpMasolejra.ValueMember = "IDMasolejra";
            drpMasolejra.SelectedIndex = -1;

            objpm.FlagIsInstruction = true;
            drpSparePart.DataSource = objpm.selectSparPart().Tables[0];
            drpSparePart.ValueMember = "ID_spare_part";
            drpSparePart.DisplayMember = "NKala";
            drpSparePart.SelectedIndex = -1;

            //txtMoreViews.Text = null;
            //txtTimeDoService.Value = 0;
            //txtPeriodicityDay.Value = 0;
            //txtDosageSP.Text = "0";
            //txtDescriptionIns.Text = null;
            //lblCodMachine.Text = "-";
            objpm.IDInstruction = null;
            IDInstruction = null;
            grd_Instruction.DataSource = objpm.Select_Instruction().Tables[0];

            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }

        private void btn_Delete_Section_Click(object sender, EventArgs e)
        {
            objpm.IDInstruction = IDInstruction;     
            if (IsCalender)
            {
                if (!String.IsNullOrEmpty(IDInstruction))
                {
                                   
                    RadMessageBox.Show(objpm.DelCalendarAuto());
                    NewInstruction();
                }
            }
            if (!IsCalender)
            {
                RadMessageBox.Show(objpm.DelInsTable());
                NewInstruction();
            }
        }

        private void btn_New_Section_Click(object sender, EventArgs e)
        {
            NewInstruction();
        }

        private void grd_Instruction_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (grd_Instruction.CurrentRow.Index > -1)
            { 
                btnDelete.Enabled = true ;
                btnEdit.Enabled = true ;
                
                IDInstruction = grd_Instruction.CurrentRow.Cells["ID_Instruction"].Value.ToString();
                objpm.IDInstruction = IDInstruction;
                //***********************************************
                if (objpm.SelectIsCalendar().Tables[0].Rows.Count > 0)
                    IsCalender = true;
                else
                    IsCalender = false;
                //***********************************************
                drp_Machine.SelectedValue = grd_Instruction.CurrentRow.Cells["FKIdMachine"].Value;
                txtMoreViews.Text = grd_Instruction.CurrentRow.Cells["MoreViewsIns"].Value.ToString();
                if(Convert.ToBoolean(grd_Instruction.CurrentRow.Cells["s"].Value))
                    rbtnStatusM1.IsChecked = true;
                else  rbtnStatusM0.IsChecked = true;
                txtTimeDoService.Value = Convert.ToInt16(grd_Instruction.CurrentRow.Cells["TimeDoService"].Value);
                txtPeriodicityDay.Value = Convert.ToInt16(grd_Instruction.CurrentRow.Cells["PeriodicityDay"].Value);
                drpSparePart.SelectedValue = grd_Instruction.CurrentRow.Cells["FKIDSparePart"].Value;
                txtDosageSP.Text = grd_Instruction.CurrentRow.Cells["DosageSP"].Value.ToString();
                drpMasolejra.SelectedValue = grd_Instruction.CurrentRow.Cells["FKIDMasolejra"].Value;
                txtDescriptionIns.Text = grd_Instruction.CurrentRow.Cells["DescriptionIns"].Value.ToString();
                grd_Instruction.Enabled = false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            objpm.IDInstruction = IDInstruction;
            if (IsCalender)
            {
                if (!String.IsNullOrEmpty(IDInstruction))
                {
                    
                    objpm.ID_Machine = "0";                                      
                    //******************
                    objpm.ID_Machine = drp_Machine.SelectedValue.ToString();
                    objpm.MoreViewsIns = txtMoreViews.Text;
                    if (rbtnStatusM0.IsChecked == true)
                        objpm.StatusM = "0";
                    if (rbtnStatusM1.IsChecked == true)
                        objpm.StatusM = "1";
                    objpm.TimeDoService = txtTimeDoService.Value.ToString();
                    objpm.PeriodicityDay = txtPeriodicityDay.Value.ToString();
                    if (!String.IsNullOrEmpty(drpSparePart.Text))
                        objpm.ID_SparePart = drpSparePart.SelectedValue.ToString();
                    else objpm.ID_SparePart = null;
                    objpm.DosageSP = txtDosageSP.Text;
                    objpm.IDMasolejra = drpMasolejra.SelectedValue.ToString();
                    objpm.DescriptionIns = txtDescriptionIns.Text;
                    
                    //******************************
                    RadMessageBox.Show(objpm.InsCalendarEdite());
                    NewInstruction();
                }
            }
            if (!IsCalender)
            {
                objpm.ID_Machine = drp_Machine.SelectedValue.ToString();
                objpm.MoreViewsIns = txtMoreViews.Text;
                if (rbtnStatusM0.IsChecked == true)
                    objpm.StatusM = "0";
                if (rbtnStatusM1.IsChecked == true)
                    objpm.StatusM = "1";
                objpm.TimeDoService = txtTimeDoService.Value.ToString();
                objpm.PeriodicityDay = txtPeriodicityDay.Value.ToString();
                if (!String.IsNullOrEmpty(drpSparePart.Text))
                    objpm.ID_SparePart = drpSparePart.SelectedValue.ToString();
                else objpm.ID_SparePart = null;
                objpm.DosageSP = txtDosageSP.Text;
                objpm.IDMasolejra = drpMasolejra.SelectedValue.ToString();
                objpm.DescriptionIns = txtDescriptionIns.Text;
                MessageBox.Show(objpm.updateInstructionTable());
                NewInstruction();
            }
        }

        private void btnRefreshSparepart_Click(object sender, EventArgs e)
        {
            objpm.FlagIsInstruction = true;
            drpSparePart.DataSource = objpm.selectSparPart().Tables[0];
            drpSparePart.ValueMember = "ID_spare_part";
            drpSparePart.DisplayMember = "NKala";
            drpSparePart.SelectedIndex = -1;
        }

    }
}
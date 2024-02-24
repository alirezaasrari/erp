using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace ET
{
    public partial class FrmPln_GantDastgah : Telerik.WinControls.UI.RadForm
    {
        public FrmPln_GantDastgah()
        {
            InitializeComponent();
        }

        private void FrmPln_GantDastgah_Load(object sender, EventArgs e)
        {
            ClsPlanning objPlanning = new ClsPlanning();
            grd.DataSource = objPlanning.Select_GantDastgah().Tables[0];
        }

        private void grd_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "btnSabt")
            {
                ClsPlanning objPlanning = new ClsPlanning();
                objPlanning.strIdGantProj = grd.CurrentRow.Cells["id"].Value.ToString();
                objPlanning.strOlaviat = grd.CurrentRow.Cells["mOlaviat"].Value.ToString();
                objPlanning.strIdMachine = grd.CurrentRow.Cells["ID_machine"].Value.ToString();
                objPlanning.strNameGhete = grd.CurrentRow.Cells["NameGhete"].Value.ToString();
                objPlanning.strZaman = grd.CurrentRow.Cells["Zaman"].Value.ToString();
                objPlanning.strTedadMahsool = grd.CurrentRow.Cells["TedadMahsool"].Value.ToString();
                MessageBox.Show(objPlanning.Update_GantDastgah());
                if(grd.CurrentRow.Cells["TedadMahsool"].Value.ToString()!=grd.CurrentRow.Cells["TedadGhabli"].Value.ToString())
                {
                    objPlanning.strTedadMahsool = (Convert.ToInt32(grd.CurrentRow.Cells["TedadGhabli"].Value)
                                                - Convert.ToInt32(grd.CurrentRow.Cells["TedadMahsool"].Value)).ToString();
                    MessageBox.Show(objPlanning.Insert_GantProj());
                }
                //grd.DataSource = objPlanning.Select_GantDastgah().Tables[0]; 
            }
            //if (grd.CurrentCell.ColumnIndex == 0)
            //{
            //    FrmPLN_GantMachine frm = new FrmPLN_GantMachine();
            //    frm.ShowDialog();
            //    if (ClsTolid.strIdMachine != "" & ClsTolid.strIdMachine != null)
            //    {
            //        grd.CurrentRow.Cells["ID_machine"].Value = ClsTolid.strIdMachine;
            //        grd.CurrentRow.Cells["N_machine"].Value = ClsTolid.strNameMachine;
            //    }
            //}
        }

        private void btnSabt_Click(object sender, EventArgs e)
        {
            ClsPlanning objPlanning = new ClsPlanning();
            objPlanning.Insert_GantProjFromView();
            grd.DataSource = objPlanning.Select_GantDastgah().Tables[0];

            //ClsTolid objTolid = new ClsTolid();
            //objTolid.strUnit = "120";
            //GridViewComboBoxColumn comboCol = this.grd.Columns["ID_machine"] as GridViewComboBoxColumn;
            //comboCol.DataSource = objTolid.Select_Dastgah().Tables[0];
            //comboCol.DisplayMember = "N_machine";
            //comboCol.ValueMember = "ID_machine";
            //comboCol.FieldName = "ID_machine";
            //comboCol.Name = "ID_machine";
            //comboCol.HeaderText = "نام دستگاه";
            //comboCol.FilteringMode = GridViewFilteringMode.ValueMember;
            //comboCol.Width = 200;
            //grd.Columns.Add(comboCol);  
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClsPlanning objPlanning = new ClsPlanning();  
            grd.DataSource = objPlanning.Select_GantDastgah().Tables[0]; 
        }

        private void grd_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (grd.CurrentCell.ColumnIndex == 0)
            {
                FrmPLN_GantMachine frm = new FrmPLN_GantMachine();
                frm.ShowDialog();
                if (ClsTolid.strIdMachine != "" & ClsTolid.strIdMachine != null)
                {
                    grd.CurrentRow.Cells["ID_machine"].Value = ClsTolid.strIdMachine;
                    grd.CurrentRow.Cells["N_machine"].Value = ClsTolid.strNameMachine;
                }
            }
        }
    }
}

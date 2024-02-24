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
    public partial class FrmPLNGhetehProcessOther : Telerik.WinControls.UI.RadForm
    {
        public FrmPLNGhetehProcessOther()
        {
            InitializeComponent();
        }
        public string strid_Gheteh;
        private void btnCkala_Click(object sender, EventArgs e)
        {
            FrmKala frm = new FrmKala();
            frm.ShowDialog();
            txtCkala.Text = ClsPublic.C_kala;
            txtNKala.Text = ClsPublic.N_kala;
        }

        private void FrmPLNGhetehProcessOther_Load(object sender, EventArgs e)
        {
            ClsPlanning objpln = new ClsPlanning();
            ClsTakvin obj = new ClsTakvin();
            cmbProcN_Process.DataSource = null;
            cmbProcN_Process.DataSource = obj.SelectProccessList().Tables[0];
            cmbProcN_Process.ValueMember = "ID_process";
            cmbProcN_Process.DisplayMember = "N_process";

            grd.DataSource = objpln.SelectProcessGhetehOther().Tables[0];
        }

        private void btnClearProc_Click(object sender, EventArgs e)
        {
            ClsTakvin obj = new ClsTakvin();
            MessageBox.Show(obj.InsGheteFromPaya());
        }

        private void grd_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                strid_Gheteh = grd.Rows[e.RowIndex].Cells["id_Gheteh"].Value.ToString();
                txtCkala.Text = grd.Rows[e.RowIndex].Cells["GhetehCode"].Value.ToString();
                txtNKala.Text = grd.Rows[e.RowIndex].Cells["GheteName"].Value.ToString();
                cmbProcN_Process.SelectedValue = grd.Rows[e.RowIndex].Cells["FK_ID_process"].Value.ToString();
                txtProcTime_standard.Text = grd.Rows[e.RowIndex].Cells["Zaman_standard"].Value.ToString();
                txtProcNafar.Text = grd.Rows[e.RowIndex].Cells["nafar_tedad"].Value.ToString();
                btnUpdProc.Enabled = true;
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        private void btnUpdProc_Click(object sender, EventArgs e)
        {
            try
            {
                ClsPlanning obj = new ClsPlanning();
                obj.strProcNafar = txtProcNafar.Text;
                obj.strZaman = txtProcTime_standard.Text;
                obj.strIdGhete = strid_Gheteh;
                MessageBox.Show(obj.Update_GhetehOther());
                btnUpdProc.Enabled = false;
                grd.DataSource = obj.SelectProcessGhetehOther().Tables[0];
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }
    }
}

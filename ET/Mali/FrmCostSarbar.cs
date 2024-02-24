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
    public partial class FrmCostSarbar : Telerik.WinControls.UI.RadForm
    {
        public FrmCostSarbar()
        {
            InitializeComponent();
        }
        ClsMali objMali = new ClsMali();
        private void cmbProcNameKargah_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbProcNameKargah.SelectedValue == null || cmbProcNameKargah.Text.ToString().Trim() == "System.Data.DataRowView")
                return;
            try
            {
                objMali.strIdUnit = cmbProcNameKargah.SelectedValue.ToString();
                txtCodeKargah.Text = objMali.strIdUnit;
            }
            catch (System.NullReferenceException exp)
            {
                RadMessageBox.Show("کارگاه را انتخاب نمایید \n " + exp.Message);
            }
        }

        private void cmbProcNameKargah_TextChanged(object sender, EventArgs e)
        {
            txtCodeKargah.Clear();
            objMali.strIdUnit = "";
        }

        private void FrmCostSarbar_Load(object sender, EventArgs e)
        {
            //----------------------------------------------------------------------kargah ( unit )
            cmbProcNameKargah.DataSource = objMali.SelectUnit().Tables[0];
            cmbProcNameKargah.ValueMember = "IdUnit";
            cmbProcNameKargah.DisplayMember = "onvan";
            cmbProcNameKargah.SelectedValue = null;
            cmbProcNameKargah.Text = "";
            txtCodeKargah.Clear();
            //--------------------------------------------------------------------
            grdSarbar.DataSource = objMali.SelectSarbar("1").Tables[0];
        }

        private void btnAddSarbar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodeKargah.Text.Trim()) || string.IsNullOrEmpty(txtSarbar.Text.Trim()))
            {
                RadMessageBox.Show(" اطلاعات را وارد نمایید");
                return;
            }
            try
            {
                objMali.strIdUnit = txtCodeKargah.Text.Trim();
                objMali.strSarbar = txtSarbar.Text.Trim();
                RadMessageBox.Show(objMali.InsSarbar());
                grdSarbar.DataSource = null;
                grdSarbar.DataSource = objMali.SelectSarbar("1").Tables[0];
            }
            catch (Exception exp)
            {
                RadMessageBox.Show("خطا در اجرای عملیات \n" + exp.Message);
            }
        }

        private void btnClearSarbar_Click(object sender, EventArgs e)
        {
            cmbProcNameKargah.SelectedValue = null;
            cmbProcNameKargah.Text = "";
            txtCodeKargah.Clear();
            objMali.strIdUnit = "";
            objMali.strSarbar = "";
            txtSarbar.Clear();
            grdSarbar.DataSource = null;
            grdSarbar.DataSource = objMali.SelectSarbar("0").Tables[0];
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI.Export;
using System.Diagnostics;

namespace ET
{
    public partial class FrmSale_RepControlHavale : Telerik.WinControls.UI.RadForm
    {
        public FrmSale_RepControlHavale()
        {
            InitializeComponent();
        }
        ClsSale objSale = new ClsSale();
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ClsSale objSale = new ClsSale();
            if (chkDateHavale.Checked == true)
            {
                objSale.strAzDateHavale = dtpAzHvl.Value.ToString().Substring(0, 10);
                objSale.strTaDateHavale = dtpTaHvl.Value.ToString().Substring(0, 10);
            }
            if (chkDateKhorooj.Checked == true)
            {
                objSale.strAzDateKh = dtpAzKh.Value.ToString().Substring(0, 10);
                objSale.strTaDateKh = dtpTaKh.Value.ToString().Substring(0, 10);
            }
            if (chkDateF.Checked == true)
            {
                objSale.strAzDateF = dtpAzF.Value.ToString().Substring(0, 10);
                objSale.strTaDateF = dtpTaF.Value.ToString().Substring(0, 10);
            }
            if (chkHavale.Checked == true)
                objSale.strHvlNo = txtHvl.Text;
            if (chkPf.Checked == true)
                objSale.strPf = txtPf.Text;

            if (chkSf.Checked == true)
                objSale.strSfNO = txtSf.Text;

            if (chkMoshtari.Checked == true)
                objSale.strMoshtariNO = txtMoshtari.Text;

            if (chkCAnbar.Checked == true)
            {
                objSale.strAzCAnbar = txtAzCAnbar.Text;
                objSale.strTaCAnbar = txtTaCAnbar.Text;
            }
            if (chkCKala.Checked == true)
                objSale.strCKala = txtCKala.Text;

            if (chkUserSabtBarge.Checked == true)
                objSale.strUserSabtBarge = txtUserBarge.Text;

            if (ChkUserSabtRadif.Checked == true)
                objSale.strUserSabtRadif = txtUserRadif.Text;

            if (chkHvlNoFish.Checked == true)
                objSale.strHvlNoFish = "1";
            else
                objSale.strHvlNoFish = "0";

            if (chkTafDiferent.Checked == true)
                objSale.strTafDiferent = "1";
            else
                objSale.strTafDiferent = "0";
      //-------------------------------------------------------------------
            if (rdbBothPFactor.Checked == true)
                objSale.strPfValid = "2";
            else
                if (rdbYesPFactor.Checked == true)
                    objSale.strPfValid = "1";
                else
                    if (rdbNoPFactor.Checked == true)
                        objSale.strPfValid = "0";

            if (rdbBothSefsresh.Checked == true)
                objSale.strSfNOValid = "2";
            else
                if (rdbYesSefaresh.Checked == true)
                    objSale.strSfNOValid = "1";
                else
                    if (rdbNoSefaresh.Checked == true)
                        objSale.strSfNOValid = "0";

            if (rdbBothFactor.Checked == true)
                objSale.strFactorValid = "2";
            else
                if (rdbYesFactor.Checked == true)
                    objSale.strFactorValid = "1";
                else
                    if (rdbNoFactor.Checked == true)
                        objSale.strFactorValid = "0";

            if (rdbHvlAll.Checked == true)
                objSale.strHavaleSabt = "2";
            else
                if (rdbHvlYesSabt.Checked == true)
                    objSale.strHavaleSabt = "1";
                else
                    if (rdbHvlNoSabt.Checked == true)
                        objSale.strHavaleSabt = "0";

            grd.DataSource = objSale.Select_ControlHavale().Tables[0];
            gridViewTemplate1.DataSource = objSale.Select_ControlHavale().Tables[1];
        }

        private void FrmSale_RepControlHavale_Load(object sender, EventArgs e)
        {
            dtpAzHvl.Value = DateTime.Now;
            dtpTaHvl.Value = DateTime.Now;
            dtpAzKh.Value = DateTime.Now;
            dtpTaKh.Value = DateTime.Now;
            dtpAzF.Value = DateTime.Now;
            dtpTaF.Value = DateTime.Now;
        }

        private void chkDateHavale_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDateHavale.Checked == true)
            {
                dtpAzHvl.Enabled = true;
                dtpTaHvl.Enabled = true;
            }
            else
            {
                dtpAzHvl.Enabled = false;
                dtpTaHvl.Enabled = false;
            }
        }

        private void chkDateKhorooj_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDateKhorooj.Checked == true)
            {
                dtpAzKh.Enabled = true;
                dtpTaKh.Enabled = true;
            }
            else
            {
                dtpAzKh.Enabled = false;
                dtpTaKh.Enabled = false;
            }
        }

        private void chkDateF_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDateF.Checked == true)
            {
                dtpAzF.Enabled = true;
                dtpTaF.Enabled = true;
            }
            else
            {
                dtpAzF.Enabled = false;
                dtpTaF.Enabled = false;
            }
        }

        private void chkHavale_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHavale.Checked == true)
                txtHvl.Enabled = true;
            else
                txtHvl.Enabled = false;
        }

        private void chkPf_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPf.Checked == true)
                txtPf.Enabled = true;
            else
                txtPf.Enabled = false;
        }

        private void chkSf_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSf.Checked == true)
                txtSf.Enabled = true;
            else
                txtSf.Enabled = false;
        }

        private void chkMoshtari_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMoshtari.Checked == true)
                txtMoshtari.Enabled = true;
            else
                txtMoshtari.Enabled = false;
        }

        private void chkCAnbar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCAnbar.Checked == true)
            {
                txtAzCAnbar.Enabled = true;
                txtTaCAnbar.Enabled = true;
            }
            else
            {
                txtAzCAnbar.Enabled = false;
                txtTaCAnbar.Enabled = false;
            }
        }

        private void chkCKala_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCKala.Checked == true)
                txtCKala.Enabled = true;
            else
                txtCKala.Enabled = false;
        }

        private void chkUserSabtBarge_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUserSabtBarge.Checked == true)
                txtUserBarge.Enabled = true;
            else
                txtUserBarge.Enabled = false;
        }

        private void ChkUserSabtRadif_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkUserSabtRadif.Checked == true)
                txtUserRadif.Enabled = true;
            else
                txtUserRadif.Enabled = false;
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
                (new ExportToExcelML(this.grd)).RunExport(fileName);
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
    }
}

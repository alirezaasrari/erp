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
    public partial class FrmSale_RepControlSefaresh : Telerik.WinControls.UI.RadForm
    {
        public FrmSale_RepControlSefaresh()
        {
            InitializeComponent();
        }
        ClsSale objSale = new ClsSale();
        private void FrmSale_RepControlSefaresh_Load(object sender, EventArgs e)
        {
            dtpAzPf.Value = DateTime.Now;
            dtpTaPf.Value = DateTime.Now;
            dtpAzSf.Value = DateTime.Now;
            dtpTaSf.Value = DateTime.Now;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (chkPf.Checked == true)
                objSale.strPfNO = txtPf.Text;
            if (chkSf.Checked == true)
                objSale.strSfNO = txtSf.Text;
            if (chkMoshtari.Checked == true)
                objSale.strMoshtariNO = txtMoshtari.Text;
            if (chkTafsili.Checked == true)
                objSale.strTafsiliNO = txtTafsili.Text;
            if (chkDatePf.Checked == true)
            {
                objSale.strAzDatePf = dtpAzPf.Value.ToString().Substring(0, 10);
                objSale.strTaDatePf = dtpTaPf.Value.ToString().Substring(0, 10);
            }
            if (chkDateSf.Checked == true)
            {
                objSale.strAzDateSf = dtpAzSf.Value.ToString().Substring(0, 10);
                objSale.strTaDateSf = dtpTaSf.Value.ToString().Substring(0, 10);
            }
            if (chkCAnbar.Checked == true)
            {
                objSale.strAzDateSf = dtpAzSf.Value.ToString().Substring(0, 10);
                objSale.strTaDateSf = dtpTaSf.Value.ToString().Substring(0, 10);
            }
            if (chkCKala.Checked == true)
                objSale.strCKala = txtCKala.Text;
            if (chkUserSabtBarge.Checked == true)
                objSale.strUserSabtBarge = txtUserBarge.Text;
            if (ChkUserSabtRadif.Checked == true)
                objSale.strUserSabtRadif = txtUserRadif.Text;


            if (rdbRadif.Checked == true)
            {
                grdT.Visible = false;
                grd.Visible = true;
                grd.DataSource = objSale.Select_ControlSefaresh_radif().Tables[0];
            }
            else
            {
                grd.Visible = false;
                grdT.Visible = true;
                grdT.DataSource = objSale.Select_ControlSefaresh_barge().Tables[0];
            }               
        }

        private void btnAghlam_Click(object sender, EventArgs e)
        {
            FrmPLN_cntF2.strTypeReport = "aghlam";
            FrmPLN_cntF2 frm = new FrmPLN_cntF2();

            frm.ShowDialog();
        }

        private void chkPf_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPf.Checked == true)
                txtPf.Enabled=true;
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

        private void chkTafsili_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTafsili.Checked == true)
                txtTafsili.Enabled = true;
            else
                txtTafsili.Enabled = false;
        }

        private void chkDatePf_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDatePf.Checked == true)
            {
                dtpAzPf.Enabled = true;
                dtpTaPf.Enabled = true;
            }
            else
            {
                dtpAzPf.Enabled = false;
                dtpTaPf.Enabled = false;
            }
        }

        private void chkDateSf_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDateSf.Checked == true)
            {
                dtpAzSf.Enabled = true;
                dtpTaSf.Enabled = true;
            }
            else
            {
                dtpAzSf.Enabled = false;
                dtpTaSf.Enabled = false;
            }
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
            if (rdbRadif.Checked == true)
                (new ExportToExcelML(this.grd)).RunExport(fileName);
            else
                (new ExportToExcelML(this.grdT)).RunExport(fileName);
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

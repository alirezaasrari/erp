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
    public partial class FrmSofrehDateReport : Telerik.WinControls.UI.RadForm
    {
        public FrmSofrehDateReport()
        {
            InitializeComponent();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ClsMali objMali = new ClsMali();
            if (chkSofrehDate.Checked == true)
            {
                objMali.strSofrehFirst = dtpSofrehFirst.Value.ToString().Substring(0, 10);
                objMali.strSofrehLast = dtpSofrehLast.Value.ToString().Substring(0, 10);
            }
            grd.DataSource = objMali.SelectSorehDate().Tables[0];
        }

        private void FrmSofrehDateReport_Load(object sender, EventArgs e)
        {
            dtpSofrehFirst.Value = DateTime.Now;
            dtpSofrehLast.Value = DateTime.Now;

        }

        private void chkSofrehDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSofrehDate.Checked == true)
            {
                dtpSofrehFirst.Enabled = true;
                dtpSofrehLast.Enabled = true;
            }
            else
            {
                dtpSofrehFirst.Enabled = false;
                dtpSofrehLast.Enabled = false;
            }
        }
    }
}

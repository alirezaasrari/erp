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
    public partial class FrmSarbarLastDateReport : Telerik.WinControls.UI.RadForm
    {
        public FrmSarbarLastDateReport()
        {
            InitializeComponent();
        }

        private void FrmSarbarLastDateReport_Load(object sender, EventArgs e)
        {
            dtpSarbarFirst.Value = DateTime.Now;
            dtpSarbarLast.Value = DateTime.Now;

            ClsMali objMali = new ClsMali();
            grd.DataSource = objMali.SelectSarbarLastShow().Tables[0];
        }

        private void chkSarbarDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSarbarDate.Checked == true)
            {
                dtpSarbarFirst.Enabled = true;
                dtpSarbarLast.Enabled = true;
            }
            else
            {
                dtpSarbarFirst.Enabled = false;
                dtpSarbarLast.Enabled = false;
            }
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
            if (chkSarbarDate.Checked == true)
            {
                objMali.strSarbarFirst = dtpSarbarFirst.Value.ToString().Substring(0, 10);
                objMali.strSarbarLast = dtpSarbarLast.Value.ToString().Substring(0, 10);
            }
            grd.DataSource = objMali.SelectSarbarDate().Tables[0];
        }

        private void btnShowQV_Click(object sender, EventArgs e)
        {
            ClsMali objMali = new ClsMali();
            if (chkSarbarDate.Checked == true)
            {
                objMali.strSarbarFirst = dtpSarbarFirst.Value.ToString().Substring(0, 10);
                objMali.strSarbarLast = dtpSarbarLast.Value.ToString().Substring(0, 10);
            }
            using (new PleaseWait(this.Location))
            {
                objMali.SelectSarbarDate();
                objMali.SelectSarbarFinal();
            }

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = ClsPublic.strQlikPath + "SARBARLAST" + (ClsConnect.DbYear).Substring(2, 2).ToString() + ".exe ";
            startInfo.WindowStyle = ProcessWindowStyle.Maximized;
            Process.Start(startInfo);
            //Frm_Main.dr = Frm_Main.dt.Select("name_form = 'FrmSarbarLastDateReport1' ");
            //Frm_Main.dt.Rows.Remove(Frm_Main.dr[0]);
            //this.Close();
        }
    }
}

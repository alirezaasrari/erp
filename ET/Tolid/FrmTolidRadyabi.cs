using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Diagnostics;
using Telerik.WinControls.UI.Export;

namespace ET
{
    public partial class FrmTolidRadyabi : Telerik.WinControls.UI.RadForm
    {
        public FrmTolidRadyabi()
        {
            InitializeComponent();
        }
        ClsTolid objTolid = new ClsTolid();
        public Boolean intNoMontaj;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string StrIdDailyReports = "";
                int RowCount;
                DataSet ds = new DataSet(); 

                objTolid.strIdRadyabi = txtIdRadyabi.Text;

                if (chkNoMontaj.Checked == true)
                {
                    ds = objTolid.Select_DailyReportTemp2();
                    intNoMontaj = true;
                }
                else
                {
                    ds = objTolid.Select_DailyReportTemp();
                    intNoMontaj = false;
                }
                objTolid.intNoMontaj = intNoMontaj;
    
                RowCount = 0;
                StrIdDailyReports = ds.Tables[0].Rows[RowCount++][0].ToString();
                while (RowCount < ds.Tables[0].Rows.Count)
                {
                    StrIdDailyReports += "," + ds.Tables[0].Rows[RowCount][0].ToString();
                    RowCount++;
                }
                objTolid.strDailyReportsTemp = StrIdDailyReports;
                GrdDailyReport.DataSource = objTolid.Select_DailyReportRadyabi().Tables[0];
                
                grdResid.DataSource = objTolid.Select_ResidRadyabi().Tables[0];

                grdHvl.DataSource = objTolid.SelectHvl_Radyabi().Tables[0];
                gridViewTemplate1.DataSource = objTolid.SelectHvlResidMovaghat_Radyabi().Tables[0];

                //objTolid.strIdDailyReport = StrIdDailyReports;
                gridViewTemplate2.DataSource = objTolid.Select_Radyabi_DailyReport().Tables[0];
            }
            catch { }
        }

        private void FrmTolidRadyabi_Load(object sender, EventArgs e)
        {
           if( 1 == 1);
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
            (new ExportToExcelML(this.GrdDailyReport)).RunExport(fileName);
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

        private void btnExcelResid_Click(object sender, EventArgs e)
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
            (new ExportToExcelML(this.grdResid)).RunExport(fileName);
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

        private void BtnExcelHvl_Click(object sender, EventArgs e)
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
            (new ExportToExcelML(this.grdHvl)).RunExport(fileName);
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

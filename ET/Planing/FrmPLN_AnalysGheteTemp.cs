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
    public partial class FrmPLN_AnalysGheteTemp : Telerik.WinControls.UI.RadForm
    {
        public FrmPLN_AnalysGheteTemp()
        {
            InitializeComponent();
        }

        private void FrmPLN_AnalysGheteTemp_Load(object sender, EventArgs e)
        {
            ClsPlanning objPlanning = new ClsPlanning();
            //grdAnalyseGhete.DataSource = objPlanning.Select_AnalysGheteTree().Tables[0];
            grdAnalyseGhete.DataSource = objPlanning.Select_AnalysGheteSefaresh().Tables[0];
            grdMavad.DataSource = objPlanning.Select_AnalysGheteSefareshMavadSum().Tables[0];
            grdMavadSefaresh.DataSource = objPlanning.Select_AnalysGheteSefareshMavad().Tables[0];
            grdSum.DataSource = objPlanning.Select_AnalysGheteSefareshSum().Tables[0];
            grdMojudi.DataSource = objPlanning.Select_AnalysGheteSefareshMojudi().Tables[0];
        }

        private void btnAnalyse_Click(object sender, EventArgs e)
        {
            try
            {
                ClsPlanning objPlanning = new ClsPlanning();
                using (new PleaseWait(this.Location))
                {
                    objPlanning.AnalyzeSefaresh();
                }
                grdAnalyseGhete.DataSource = objPlanning.Select_AnalysGheteSefaresh().Tables[0];
                grdMavad.DataSource = objPlanning.Select_AnalysGheteSefareshMavadSum().Tables[0];
                grdMavadSefaresh.DataSource = objPlanning.Select_AnalysGheteSefareshMavad().Tables[0];
                grdSum.DataSource = objPlanning.Select_AnalysGheteSefareshSum().Tables[0];
                grdMojudi.DataSource = objPlanning.Select_AnalysGheteSefareshMojudi().Tables[0];
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
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
            (new ExportToExcelML(this.grdSum)).RunExport(fileName);
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

        private void btnExcelMavadSefaresh_Click(object sender, EventArgs e)
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
            (new ExportToExcelML(this.grdMavadSefaresh)).RunExport(fileName);
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

        private void btnExcelMavad_Click(object sender, EventArgs e)
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
            (new ExportToExcelML(this.grdMavad)).RunExport(fileName);
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

        private void btnExcelAnalyseGhete_Click(object sender, EventArgs e)
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
            (new ExportToExcelML(this.grdAnalyseGhete)).RunExport(fileName);
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

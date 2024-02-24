using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI.Export;

namespace ET
{
    public partial class FrmTJRT_Samane : Telerik.WinControls.UI.RadForm
    {
        public FrmTJRT_Samane()
        {
            InitializeComponent();
        }
        public string strIdBarge;
        private void FrmTJRT_Samane_Load(object sender, EventArgs e)
        {
            ClsSale obj = new ClsSale();
            obj.strIdBarge = strIdBarge;
            grd.DataSource = obj.Select_TJRTFactorDD().Tables[0];
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
                (new ExportToExcelML(this.grd)).RunExport(fileName);
            if (RadMessageBox.Show("فایل به درستی ایجاد شد.آیا می خواهید فایل باز شود؟", "Export to Excel", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
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

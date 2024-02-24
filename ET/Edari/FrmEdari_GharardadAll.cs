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
    public partial class FrmEdari_GharardadAll : Telerik.WinControls.UI.RadForm
    {
        public FrmEdari_GharardadAll()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.grd.TableElement.BeginUpdate();
            this.grd.EnableFiltering = true;
            this.grd.AllowAddNewRow = false;
            this.grd.ReadOnly = true;
            this.grd.MasterTemplate.ShowHeaderCellButtons = true;
            this.grd.MasterTemplate.ShowFilteringRow = false;
            this.grd.TableElement.EndUpdate();

        }
        private void FrmEdari_GharardadAll_Load(object sender, EventArgs e)
        {
            ClsEdari obj = new ClsEdari();
            grd.DataSource = obj.Select_PersonelGharardadReportAll().Tables[0];
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
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
            catch { }
        }
    }
}

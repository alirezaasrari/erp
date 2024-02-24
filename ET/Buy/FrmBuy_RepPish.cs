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
    public partial class FrmBuy_RepPish : Telerik.WinControls.UI.RadForm
    {
        public FrmBuy_RepPish()
        {
            InitializeComponent();
        }
        public DataSet ds = new DataSet();
        ClsBuy clsBuyObj = new ClsBuy();
        private void FrmBuy_RepPish_Load(object sender, EventArgs e)
        {  
            clsBuyObj.intTaeed = 1;
            clsBuyObj.intPish = 1;
            AgrdPishSum.DataSource = clsBuyObj.Select_PishKala().Tables[0];
            gridViewTemplate1.DataSource = clsBuyObj.Select_PishKalaDetail().Tables[0];
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
                (new ExportToExcelML(this.AgrdPishSum)).RunExport(fileName);
            if (RadMessageBox.Show("فایل اکسل ایجاد شد.آیا می خواهید فایل باز شود؟", "Export to Excel", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
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

        private void AgrdPishSum_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            try
            {
                if (e.RowElement.RowInfo.Cells["MeghdarPart1"].Value.ToString() == "0")
                {
                    e.RowElement.DrawFill = true;
                    //e.RowElement.GradientStyle = GradientStyles.Solid;
                    e.RowElement.BackColor = Color.Aqua;
                }
                else
                {
                    if (Convert.ToInt32(e.RowElement.RowInfo.Cells["Takhir"].Value.ToString()) > 0)
                    {
                        e.RowElement.DrawFill = true;
                        e.RowElement.BackColor = Color.Orange;
                    }
                    else
                    {
                        e.RowElement.DrawFill = true;
                        e.RowElement.BackColor = Color.White;
                    }
                }               
            }
            catch { }
        }
    }
}

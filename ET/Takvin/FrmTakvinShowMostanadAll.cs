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
using System.IO;
namespace ET
{
    public partial class FrmTakvinShowMostanadAll : Telerik.WinControls.UI.RadForm
    {
        public FrmTakvinShowMostanadAll()
        {
            InitializeComponent();
        }

        ClsTakvin objTakvin = new ClsTakvin();
        private void FrmTakvinShowMostanadAll_Load(object sender, EventArgs e)
        {
            
            objTakvin.ShowAllMostanadat = "0";
            GrdMostanadAll.DataSource = objTakvin.selectMostanadAll().Tables[0];
        }

        private void GrdMostanadAll_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 12)
                {
                    FrmTakvinMostanad frmMos = new FrmTakvinMostanad();

                    // if (GrdMostanad.Rows[e.RowIndex].Cells["IsPeyvast"].Value.ToString() == "True")
                    // {
                    string strfilenameMos = GrdMostanadAll.Rows[e.RowIndex].Cells["IDMostanad"].Value.ToString();   //+ ".pdf";
                    string strDesPathKol = objTakvin.strDesPath + strfilenameMos  +".pdf";
                    try
                    {
                        frmMos.strMostanadName = strfilenameMos;
                        frmMos.MostanadLocation = strDesPathKol;
                        frmMos.ShowDialog();
                    }
                    catch (Exception exp)
                    {
                        RadMessageBox.Show("خطا در باز کردن فایل");
                    }

                    //}
                }
            }
            catch (Exception exp)
            {
                return;
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
            (new ExportToExcelML(this.GrdMostanadAll)).RunExport(fileName);
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

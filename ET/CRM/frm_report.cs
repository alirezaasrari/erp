using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Text;
//using System.Windows.Forms;
//using Telerik.WinControls;

//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Text;
//using System.Windows.Forms;
//using Microsoft.Reporting.WinForms;
//using System.Windows.Forms;
//using Telerik.Data;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.Windows.Forms;
//using System.IO;

namespace ET
{
    public partial class frm_report : Telerik.WinControls.UI.RadForm
    {
        public frm_report()
        {
            InitializeComponent();
        }
        Cls_Customer ccr =new Cls_Customer();
        private void frm_report_Load(object sender, EventArgs e)
        {
            grdR.DataSource = ccr.selectriport().Tables[0];
            //grd_E.DataSource = ccr.select_H_Exbi().Tables[0];
            //gridViewTemplate1.DataSource = ccr.selectdsuggest().Tables[0];
            //gridViewTemplate1.Caption = "درخواست";
            //gridViewTemplate3.DataSource = ccr.selectdkala().Tables[0];
            //gridViewTemplate3.Caption = "کالا";
            ////gridViewTemplate2.DataSource = ccr.selectfollow().Tables[0];
            ////gridViewTemplate2.Caption = "پیگیری";
            ////gridViewTemplate4.DataSource = ccr.Select_suplier_tel().Tables[0];
            ////gridViewTemplate4.Caption = "تلفن";
        }
        SaveFileDialog sfd = new SaveFileDialog();

         private void btnExcelML_Click(object sender, EventArgs e)
         {
             radProgressBar1.Visible = true;
             sfd.Filter = String.Format("{0} (*{1})|*{1}", "Excel Files", ".xls");
             if (sfd.ShowDialog() == DialogResult.OK)
             {
                     ExportToExcelML exporter = new ExportToExcelML(this.grdR);
                     exporter.ExportHierarchy = true;
                     int rowNumber = grdR.RowCount;
                     for (int i = 1; i <= rowNumber; i++)
                     {
                         int position = (int)(100 * ((double)i / rowNumber));
                         this.UpdateProgressBar(position);
                     }

                     exporter.ExportVisualSettings = true;
                     exporter.RunExport(sfd.FileName);
                     RadMessageBox.SetThemeName(this.grdR.ThemeName);
                     
                     DialogResult dr = RadMessageBox.Show("فایل ایجاد آیا تمایل دارید باز شود؟", "Export to CSV", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                     if (dr == DialogResult.Yes)
                     {
                         System.Diagnostics.Process.Start(sfd.FileName);                        
                     }
                     else { RadMessageBox.Show("فایل \n" + sfd.FileName + "\nایجاد شد"); }
             }
             radProgressBar1.Visible = false;
         }   
        private void UpdateProgressBar(int value)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(delegate
                {
                    if (value < 100)
                    {
                        this.radProgressBar1.Value1 = value;
                    }
                    else
                    {
                        this.radProgressBar1.Value1 = 100;
                    }
                }));
            }
            else
            {
                if (value < 100)
                {
                    this.radProgressBar1.Value1 = value;
                }
                else
                {
                    this.radProgressBar1.Value1 = 100;
                }
            }
        }
    }
}

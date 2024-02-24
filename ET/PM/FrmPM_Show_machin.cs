using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Telerik.Data;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.IO;
//using Telerik.QuickStart.WinControls;


namespace ET
{
    public partial class FrmPM_Show_machin : Telerik.WinControls.UI.RadForm
    {
        public FrmPM_Show_machin()
        {
            InitializeComponent();
        }

        ClsPM cp = new ClsPM();
        DataTable dt = new DataTable(); 
        private void FrmPM_Show_machin_Load(object sender, EventArgs e)
        {
            grd_machine.DataSource = cp.selectMachine().Tables[0];
            gridViewTemplate1.DataSource = cp.select_SCSectin().Tables[0];
            gridViewTemplate1.Caption = "قسمت";
            gridViewTemplate4.DataSource = cp.selectSectionANDsparePart().Tables[0];
           // gridViewTemplate2.DataSource = cp.select_SCSupplier().Tables[0];
            gridViewTemplate2.Caption = "تامین کننده";
            gridViewTemplate3.DataSource = cp.select_Unit_place_machine().Tables[0];
            gridViewTemplate3.Caption = "تاریخچه مکان";
            //grd_machine.DataSource = cp.selectMachine().Tables[0];
            //gridViewTemplate1.DataSource = cp.select_SCSectin().Tables[0];
            //gridViewTemplate1.Caption = "قسمت";
            //gridViewTemplate2.DataSource = cp.select_SCSupplier().Tables[0];
            //gridViewTemplate2.Caption = "تامین کننده";
            //gridViewTemplate3.DataSource = cp.selectSectionANDsparePart().Tables[0];
            //gridViewTemplate3.DataSource = cp.select_Unit_place_machine().Tables[0];
            //gridViewTemplate3.Caption = "تاریخچه مکان";
            reportViewer1.Visible = false;

            grd_machine.Visible = true;
            int k = 0;
            while (k < grd_machine.Columns.Count)
            {
                dt.Columns.Add(grd_machine.Columns[k].Name);
                k++;
            }
            
        }

        private void grd_Machine_Section_Supplier_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                cp.Print_ID_Machine = grd_machine.CurrentRow.Cells["ID_machine"].Value.ToString();
                btn_print_shenasnameh.Enabled = true;
            }
            catch
            {
                MessageBox.Show("روی خطوط گرید کلید نمایید");
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            grd_machine.Visible = false;
            reportViewer1.Visible = true;
            reportViewer1.LocalReport.DataSources.Clear();
            //reportViewer1.LocalReport.ReportEmbeddedResource = @"ET.PM.PM_Print_shenasname_machine.rdlc";
            reportViewer1.LocalReport.ReportPath = @"RDLC\PM_Print_shenasname_machine.rdlc";
            ReportDataSource dataset = new ReportDataSource("table");
            reportViewer1.LocalReport.DataSources.Add(dataset);
            dataset.Value = cp.selectMachine().Tables[0];
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
        }

        private void btn_print_List_Click(object sender, EventArgs e)
        {
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);            
            dt.Clear();
            for (int j = 0; j < grd_machine.MasterView.Rows.Count; j++)
            {
                DataRow dr = dt.NewRow();
                for (int i = 0; i < grd_machine.ColumnCount; i++)
                {
                    dr[grd_machine.Columns[i].Name] = grd_machine.MasterView.Rows[j].Cells[i].Value;
                }
                dt.Rows.Add(dr);
            }
            grd_machine.Visible = false;
            reportViewer1.Visible = true;        
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportPath = @"RDLC\PM_Print_list_machine.rdlc";
            ReportDataSource dataset = new ReportDataSource("table");
            reportViewer1.LocalReport.DataSources.Add(dataset);
            dataset.Value = dt;
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport(); 
        }
        private void btn_print_Show_Click(object sender, EventArgs e)
        {
            grd_machine.Visible = true;
            reportViewer1.Visible = false;
            //radGridView1.Visible = false;
        }
        private void btn_column_Click(object sender, EventArgs e)
        {
            grd_machine.ShowColumnChooser(); 
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            grd_machine.PrintPreview();
            //SaveFileDialog sh = new System.Windows.Forms.SaveFileDialog();
            //sh.ShowDialog();
            //excelExporter.ExportVisualSettings = this.exportVisualSettings; 
        }
        SaveFileDialog sfd = new SaveFileDialog();
        private void btnExportFile_Click(object sender, EventArgs e)
        {
            //SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = String.Format("{0} (*{1})|*{1}", "Excel Files", ".xls");
            if (sfd.ShowDialog() == DialogResult.OK)
                tbFileName.Text = sfd.FileName; 
        }

        private void btnExcelML_Click(object sender, EventArgs e)
        {
            if (!tbFileName.Text.Equals(string.Empty))
            {
                ExportToExcelML exporter = new ExportToExcelML(grd_machine);
                exporter.RunExport(tbFileName.Text);
                MessageBox.Show("فایل \n"+sfd.FileName+"\nایجاد شد");
            }
        }          
    }
    
       
    
}
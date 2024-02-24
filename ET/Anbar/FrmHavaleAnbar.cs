using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace ET
{
    public partial class FrmHavaleAnbar : Telerik.WinControls.UI.RadForm
    {
        public FrmHavaleAnbar()
        {
            InitializeComponent();
        }

        private void radGridView1_Click(object sender, EventArgs e)
        {

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ClsAnbar clsAnbar = new ClsAnbar();
            if ((txtHavale_no.Text != "") & (chkHovale_no.Checked == true))
            {
                clsAnbar.strHavaleNO = txtHavale_no.Text;
            }
            else
            {
                clsAnbar.strHavaleNO = "";
            }
            if ((pdatestart.Text != "") & (pdateend.Text != "") & (chkDateHavale.Checked == true))
            {
                clsAnbar.strDate1 = pdatestart.Text;
                clsAnbar.strDate2 = pdateend.Text;
            }
            else
            {
                clsAnbar.strDate1 = "";
                clsAnbar.strDate2 = "";
            }

            if ((txtc_kala.Text != "") & (chkC_kala.Checked == true))
            {
                clsAnbar.strkalaCode = txtc_kala.Text;
            }
            else
            {
                clsAnbar.strkalaCode = "";
            }

            
            grd_havale.DataSource = clsAnbar.HavaleAnbar().Tables[0];
            grd_havale.Visible = true;
            rpt_havale.Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {
        
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ClsAnbar clsAnbar = new ClsAnbar();

            if ((txtHavale_no.Text != "") & (chkHovale_no.Checked == true))
            {
                clsAnbar.strHavaleNO = txtHavale_no.Text;
            }
            else
            {
                clsAnbar.strHavaleNO = "";
            }
            if ((pdatestart.Text != "") & (pdateend.Text != "") & (chkDateHavale.Checked == true))
            {
                clsAnbar.strDate1 = pdatestart.Text;
                clsAnbar.strDate2 = pdateend.Text;
            }
            else
            {
                clsAnbar.strDate1 = "";
                clsAnbar.strDate2 = "";
            }

            if ((txtc_kala.Text != "") & (chkC_kala.Checked == true))
            {
                clsAnbar.strkalaCode = txtc_kala.Text;
            }
            else
            {
                clsAnbar.strkalaCode = "";
            }  
          
           // rpt_havale.
            rpt_havale.LocalReport.DataSources.Clear();
            //reportViewer1.LocalReport.ReportEmbeddedResource = @"ET.PM.PM_Print_shenasname_machine.rdlc";
            rpt_havale.LocalReport.ReportPath = @"RDLC\Anbar_Print_Havale.rdlc";
            ReportDataSource dataset = new ReportDataSource("table");
            rpt_havale.LocalReport.DataSources.Add(dataset);
            dataset.Value = clsAnbar.PrintHavale().Tables[0];
            rpt_havale.LocalReport.Refresh();
            rpt_havale.RefreshReport();
            //grd_havale.Visible = false;
            rpt_havale.Visible = true;

        }

        private void FrmHavaleAnbar_Load(object sender, EventArgs e)
        {

          //  this.rpt_havale.RefreshReport();
            //this.rpt_havale.RefreshReport();
           // this.reportViewer1.RefreshReport();
           // this.reportViewer1.RefreshReport();
        }

        private void chkHovale_no_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHovale_no.Checked==true)
            {
                txtHavale_no.Enabled = true;
            }
            else
            {
                txtHavale_no.Enabled = false;
            }
        }

        private void txtc_kala_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkC_kala_CheckedChanged(object sender, EventArgs e)
        {
            if (chkC_kala.Checked==true)
            {
                txtc_kala.Enabled = true;
            }
            else
            {
                txtc_kala.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDateHavale.Checked == true)
            {
                pdatestart.Enabled = true;
                pdateend.Enabled = true;
            }
            else
            {
                pdatestart.Enabled = false;
                pdateend.Enabled = false;
            }
        }
    }
}

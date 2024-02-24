using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace ET
{
    public partial class FrmTolidShowDailyReport : Telerik.WinControls.UI.RadForm
    {
        FrmTolid_SabtDailyReport frm;
        public FrmTolidShowDailyReport(FrmTolid_SabtDailyReport frm1)
        {
            InitializeComponent();
            frm = frm1;
        }
        ClsTolid ObjTolid = new ClsTolid();
        private void FrmTolidShowDailyReport_Load(object sender, EventArgs e)
        {
            ObjTolid.strUnit = frm.cmbKargah.SelectedValue.ToString();
            ObjTolid.strShift = frm.cmbShift.Text;
            ObjTolid.strtarikh = frm.dtpDateDailyReport.Value.ToString().Substring(0, 10);
            grdDailyReport.DataSource = ObjTolid.Select_DailyReport().Tables[0];
        }

        private void grdDailyReport_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            frm.txtIdDailyReport.Text = grdDailyReport.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            this.Close();
        }
    }
}

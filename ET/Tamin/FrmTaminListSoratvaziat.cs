using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using FastReport;

namespace ET
{
    public partial class FrmTaminListSoratvaziat : Telerik.WinControls.UI.RadForm
    {
        public FrmTaminListSoratvaziat()
        {
            InitializeComponent();
        }

        private void grd_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "btnPrint")
                {
                    Report objReport = new Report();

                    objReport.Load(ClsPublic.strRepPath + "SoratVaziat.frx");
                    objReport.SetParameterValue("IdSoratVaziatH", grd.CurrentRow.Cells["IdSoratVaziatH"].Value.ToString());
                    objReport.Show();
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void FrmTaminListSoratvaziat_Load(object sender, EventArgs e)
        {
            ClsTamin obj = new ClsTamin();
            grd.DataSource = obj.Select_SoratVaziatH().Tables[0];
        }
    }
}

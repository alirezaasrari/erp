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
    public partial class FrmTaminNasbRepAll : Telerik.WinControls.UI.RadForm
    {
        public FrmTaminNasbRepAll()
        {
            InitializeComponent();
        }

        private void btnShahrakha_Click(object sender, EventArgs e)
        {
            Report objReport = new Report();
            //objReport.Load(ClsPublic.strRepPath + "BarnamePrintBerenj.frx");
            objReport.Load("TaminShahrakha.frx");
            objReport.SetParameterValue("@idMantaghe", '6');
            objReport.Show();
        }

        private void FrmTaminNasbRepAll_Load(object sender, EventArgs e)
        {
            ClsTamin obj = new ClsTamin();
            grd.DataSource = obj.Select_TaminNasbRepAll().Tables[0];
        }
    }
}

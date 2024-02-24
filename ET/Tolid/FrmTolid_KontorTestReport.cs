using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace ET
{
    public partial class FrmTolid_KontorTestReport : Telerik.WinControls.UI.RadForm
    {
        public FrmTolid_KontorTestReport()
        {
            InitializeComponent();
        }

        private void FrmTolid_KontorTestReport_Load(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                //if (ClsConnect.Dore == "misdb94")
                //    startInfo.FileName = @"\\Mps\mis\QlikViewFile\DailyReport94.exe";
                //if (ClsConnect.Dore == "misdb95")
                //    startInfo.FileName = @"\\Mps\mis\QlikViewFile\DailyReport95.exe";
                //if (ClsConnect.Dore == "misdb96")
                //    startInfo.FileName = @"\\Mps\mis\QlikViewFile\DailyReport96.exe";
                startInfo.FileName = ClsPublic.strQlikPath + "Kontor.exe ";
                startInfo.WindowStyle = ProcessWindowStyle.Maximized;
                Process.Start(startInfo);
                Frm_Main.dr = Frm_Main.dt.Select("name_form = 'FrmTolid_KontorTestReport1' ");
                Frm_Main.dt.Rows.Remove(Frm_Main.dr[0]);
                this.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace ET
{
    public partial class FrmTolidDailyReport : Telerik.WinControls.UI.RadForm
    {
        public FrmTolidDailyReport()
        {
            InitializeComponent();
        }

        private void Frm_TolidDailyReport_Load(object sender, EventArgs e)
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
                startInfo.FileName = ClsPublic.strQlikPath + "DailyReport" + (ClsConnect.DbYear).Substring(2, 2).ToString() + ".exe ";
                startInfo.WindowStyle = ProcessWindowStyle.Maximized;
                Process.Start(startInfo);
                Frm_Main.dr = Frm_Main.dt.Select("name_form = 'FrmTolidDailyReport1' ");
                Frm_Main.dt.Rows.Remove(Frm_Main.dr[0]);
                this.Close();
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}

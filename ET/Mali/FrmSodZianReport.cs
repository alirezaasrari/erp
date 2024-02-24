using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Diagnostics;


namespace ET
{
    public partial class FrmSodZianReport : Telerik.WinControls.UI.RadForm
    {
        public FrmSodZianReport()
        {
            InitializeComponent();
        }

        private void FrmSodZianReport_Load(object sender, EventArgs e)
        {
            //------------excec proc soodzian


            ClsMali objMali = new ClsMali();
            objMali.SelectSodZian();


            //if (ClsConnect.Dore == "misdb94")
            //    startInfo.FileName = @"\\Mps\mis\QlikViewFile\DailyReport94.exe";
            //if (ClsConnect.Dore == "misdb95")
            //    startInfo.FileName = @"\\Mps\mis\QlikViewFile\DailyReport95.exe";
            //if (ClsConnect.Dore == "misdb96")
            //    startInfo.FileName = @"\\Mps\mis\QlikViewFile\DailyReport96.exe";
            //startInfo.FileName = @"\\Mps\mis\QlikViewFile\SARBAR" + (ClsConnect.DbYear).Substring(2, 2).ToString() + ".exe ";


            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = ClsPublic.strQlikPath + "SoodZian" + (ClsConnect.DbYear).Substring(2, 2).ToString() + ".exe ";
            startInfo.WindowStyle = ProcessWindowStyle.Maximized;
            Process.Start(startInfo);
            Frm_Main.dr = Frm_Main.dt.Select("name_form = 'FrmSodZianReport1' ");
            Frm_Main.dt.Rows.Remove(Frm_Main.dr[0]);
            this.Close();
        }
    }
}

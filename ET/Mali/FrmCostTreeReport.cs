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
    public partial class FrmCostTreeReport : Telerik.WinControls.UI.RadForm
    {
        public FrmCostTreeReport()
        {
            InitializeComponent();
        }

        private void FrmCostTreeReport_Load(object sender, EventArgs e)
        {
            //------------excec proc sarbar last


            ////ClsMali objMali = new ClsMali();
            ////objMali.SelectCostTreeMahsul();


            //if (ClsConnect.Dore == "misdb94")
            //    startInfo.FileName = @"\\Mps\mis\QlikViewFile\DailyReport94.exe";
            //if (ClsConnect.Dore == "misdb95")
            //    startInfo.FileName = @"\\Mps\mis\QlikViewFile\DailyReport95.exe";
            //if (ClsConnect.Dore == "misdb96")
            //    startInfo.FileName = @"\\Mps\mis\QlikViewFile\DailyReport96.exe";
            //startInfo.FileName = @"\\Mps\mis\QlikViewFile\SARBAR" + (ClsConnect.DbYear).Substring(2, 2).ToString() + ".exe ";

            ClsMali objMali = new ClsMali();
            objMali.SelectSarbarLast();
            objMali.SelectSarbarFinal();          

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = ClsPublic.strQlikPath + "CostTreeMahsul" + (ClsConnect.DbYear).Substring(2, 2).ToString() + ".exe ";
            startInfo.WindowStyle = ProcessWindowStyle.Maximized;
            Process.Start(startInfo);
            Frm_Main.dr = Frm_Main.dt.Select("name_form = 'FrmCostTreeReport1' ");
            Frm_Main.dt.Rows.Remove(Frm_Main.dr[0]);
            this.Close();
        }
    }
}

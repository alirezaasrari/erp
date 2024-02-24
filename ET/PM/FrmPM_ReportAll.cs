using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;
using Telerik.WinControls;

namespace ET
{
    public partial class FrmPM_ReportAll : Telerik.WinControls.UI.RadForm
    {
        public FrmPM_ReportAll()
        {
            InitializeComponent();
        }

        private void FrmPM_ReportAll_Load(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            //if (ClsConnect.Dore == "misdb97")
            //    startInfo.FileName = ClsPublic.strQlikPath + "PM97.exe";
            //if (ClsConnect.Dore == "misdb98")
            //    startInfo.FileName = ClsPublic.strQlikPath + "PM98.exe";
            //if (ClsConnect.Dore == "misdb99")
            //    startInfo.FileName = ClsPublic.strQlikPath + "PM99.exe";

            startInfo.FileName = ClsPublic.strQlikPath + "PM" + (ClsConnect.DbYear).Substring(2, 2).ToString() + ".exe ";
            startInfo.WindowStyle = ProcessWindowStyle.Maximized;

            startInfo.WindowStyle = ProcessWindowStyle.Maximized;
            Process.Start(startInfo);
            Frm_Main.dr = Frm_Main.dt.Select("name_form = 'FrmPM_ReportAll1' ");
            Frm_Main.dt.Rows.Remove(Frm_Main.dr[0]);
            this.Close();
        }
    }
}

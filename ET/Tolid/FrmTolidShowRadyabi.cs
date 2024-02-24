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
    public partial class FrmTolidShowRadyabi : Telerik.WinControls.UI.RadForm
    {
        public FrmTolidShowRadyabi()
        {
            InitializeComponent();
        }

        private void FrmTolidShowRadyabi_Load(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            if (ClsConnect.Dore == "misdb95")
                startInfo.FileName = ClsPublic.strQlikPath + "Tracking95.exe";
            if (ClsConnect.Dore == "misdb96")
                startInfo.FileName = ClsPublic.strQlikPath + "Tracking96.exe";
            if (ClsConnect.Dore == "misdb97")
                startInfo.FileName = ClsPublic.strQlikPath + "Tracking96.exe";

            startInfo.WindowStyle = ProcessWindowStyle.Maximized;
            Process.Start(startInfo);
            Frm_Main.dr = Frm_Main.dt.Select("name_form = 'FrmTolidShowRadyabi1' ");
            Frm_Main.dt.Rows.Remove(Frm_Main.dr[0]);
            this.Close();
        }
    }
}

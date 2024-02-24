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
    public partial class FrmPLN_ReportSefaresh : Telerik.WinControls.UI.RadForm
    {
        public FrmPLN_ReportSefaresh()
        {
            InitializeComponent();
        }

        private void FrmPLN_ReportSefaresh_Load(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            if (ClsConnect.Dore == "misdb99")
                startInfo.FileName = ClsPublic.strQlikPath + "Sefaresh.exe";

            startInfo.WindowStyle = ProcessWindowStyle.Maximized;
            Process.Start(startInfo);
            Frm_Main.dr = Frm_Main.dt.Select("name_form = 'FrmPLN_ReportSefaresh1' ");
            Frm_Main.dt.Rows.Remove(Frm_Main.dr[0]);
            this.Close();
        }
    }
}

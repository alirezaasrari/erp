﻿using System;
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
    public partial class FrmSofrehReport : Telerik.WinControls.UI.RadForm
    {
        public FrmSofrehReport()
        {
            InitializeComponent();
        }

        private void FrmSofrehReport_Load(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = ClsPublic.strQlikPath + "SOFREH" + (ClsConnect.DbYear).Substring(2, 2).ToString() + ".exe ";
            startInfo.WindowStyle = ProcessWindowStyle.Maximized;
            Process.Start(startInfo);
            Frm_Main.dr = Frm_Main.dt.Select("name_form = 'FrmSofrehReport1' ");
            Frm_Main.dt.Rows.Remove(Frm_Main.dr[0]);
            this.Close();
        }
    }
}

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
    public partial class FrmMali_SanadTafsili : Telerik.WinControls.UI.RadForm
    {
        public FrmMali_SanadTafsili()
        {
            InitializeComponent();
        }

        private void FrmMali_SanadTafsili_Load(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = ClsPublic.strQlikPath + "SanadTafsili.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Maximized;
            Process.Start(startInfo);
            Frm_Main.dr = Frm_Main.dt.Select("name_form = 'FrmMali_SanadTafsili1' ");
            Frm_Main.dt.Rows.Remove(Frm_Main.dr[0]);
            this.Close();
        }
    }
}

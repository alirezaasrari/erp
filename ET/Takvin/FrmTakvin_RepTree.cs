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
    public partial class FrmTakvin_RepTree : Telerik.WinControls.UI.RadForm
    {
        public FrmTakvin_RepTree()
        {
            InitializeComponent();
        }

        private void FrmTakvin_RepTree_Load(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = startInfo.FileName = ClsPublic.strQlikPath + "TreeMahsul" + (ClsConnect.DbYear).Substring(2, 2).ToString() + ".exe";
            startInfo.WindowStyle = ProcessWindowStyle.Maximized;
            Process.Start(startInfo);
            Frm_Main.dr = Frm_Main.dt.Select("name_form = 'FrmTakvin_RepTree1' ");
            Frm_Main.dt.Rows.Remove(Frm_Main.dr[0]);
            this.Close();
        }
    }
}

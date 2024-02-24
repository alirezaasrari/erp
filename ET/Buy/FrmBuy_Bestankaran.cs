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
    public partial class FrmBuy_Bestankaran : Telerik.WinControls.UI.RadForm
    {
        public FrmBuy_Bestankaran()
        {
            InitializeComponent();
        }

        private void FrmCostTreeReport_Load(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = ClsPublic.strQlikPath + "bestankaranTadarokat.exe ";
            startInfo.WindowStyle = ProcessWindowStyle.Maximized;
            Process.Start(startInfo);
            Frm_Main.dr = Frm_Main.dt.Select("name_form = 'FrmBuy_Bestankaran1' ");
            Frm_Main.dt.Rows.Remove(Frm_Main.dr[0]);
            this.Close();
        }
    }
}

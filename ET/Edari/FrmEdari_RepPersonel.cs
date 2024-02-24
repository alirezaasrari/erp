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
    public partial class FrmEdari_RepPersonel : Telerik.WinControls.UI.RadForm
    {
        public FrmEdari_RepPersonel()
        {
            InitializeComponent();
        }

        private void FrmEdari_Rep_Load(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            //System.Security.SecureString strpass = new System.Security.SecureString()
            //startInfo.FileName = ClsPublic.strQlikPath2 + "personelData.exe";
            startInfo.FileName = ClsPublic.strQlikPath + "personelData.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Maximized;
            Process.Start(startInfo);
            Frm_Main.dr = Frm_Main.dt.Select("name_form = 'FrmEdari_RepPersonel1' ");
            Frm_Main.dt.Rows.Remove(Frm_Main.dr[0]);
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace ET
{
    public partial class FrmTakvin_RepMahsoolAll : Telerik.WinControls.UI.RadForm
    {
        public FrmTakvin_RepMahsoolAll()
        {
            InitializeComponent();
        }

        private void FrmTakvin_RepMahsoolAll_Load(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();

                startInfo.FileName = ClsPublic.strQlikPath + "takvin.exe";
                startInfo.WindowStyle = ProcessWindowStyle.Maximized;
                Process.Start(startInfo);
                Frm_Main.dr = Frm_Main.dt.Select("name_form = 'FrmTakvin_RepMahsoolAll' ");
                Frm_Main.dt.Rows.Remove(Frm_Main.dr[0]);
                this.Close();
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}

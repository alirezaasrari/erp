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
    public partial class Frm_ManabeDashboard : Telerik.WinControls.UI.RadForm
    {
        public Frm_ManabeDashboard()
        {
            InitializeComponent();
        }

        private void Frm_ManabeDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = ClsPublic.strQlikPath + "Manabe.exe ";
                startInfo.WindowStyle = ProcessWindowStyle.Maximized;
                Process.Start(startInfo);
                Frm_Main.dr = Frm_Main.dt.Select("name_form = 'Frm_ManabeDashboard1' ");
                Frm_Main.dt.Rows.Remove(Frm_Main.dr[0]);
                this.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}

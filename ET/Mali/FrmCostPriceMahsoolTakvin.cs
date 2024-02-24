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
    public partial class FrmCostPriceMahsoolTakvin : Telerik.WinControls.UI.RadForm
    {
        public FrmCostPriceMahsoolTakvin()
        {
            InitializeComponent();
        }

        private void FrmCostPriceMahsoolTakvin_Load(object sender, EventArgs e)
        {
            ClsTakvin obj = new ClsTakvin();
            obj.UpdCost_tblMahsoolPrice();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = ClsPublic.strQlikPath + "CostPriceMahsoolTakvin.exe";

            startInfo.WindowStyle = ProcessWindowStyle.Maximized;
            Process.Start(startInfo);
            Frm_Main.dr = Frm_Main.dt.Select("name_form = 'FrmCostPriceMahsoolTakvin1' ");
            Frm_Main.dt.Rows.Remove(Frm_Main.dr[0]);
            this.Close();
        }
    }
}

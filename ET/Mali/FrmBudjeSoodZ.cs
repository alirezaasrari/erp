using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace ET
{
    public partial class FrmBudjeSoodZ : Telerik.WinControls.UI.RadForm
    {
        public FrmBudjeSoodZ()
        {
            InitializeComponent();
        }
        ClsMali objMali = new ClsMali();
        private void btnSearch_Click(object sender, EventArgs e)
        {
            GrdSoodZ.DataSource = null;
            GrdSoodZ.DataSource = objMali.SelectSoodZ(txtYear.Text.Trim()).Tables[0];
        }
    }
}

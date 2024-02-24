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
    public partial class Frm_ManabeReport : Telerik.WinControls.UI.RadForm
    {
        public Frm_ManabeReport()
        {
            InitializeComponent();
        }

        private void Frm_ManabeReport_Load(object sender, EventArgs e)
        {
            ClsMali obj=new ClsMali();
            grd.DataSource = obj.SelectMali_ManabeReport().Tables[0];
        }
    }
}

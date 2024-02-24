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
    public partial class FrmTolid_KontorTestDList : Telerik.WinControls.UI.RadForm
    {
        public FrmTolid_KontorTestDList()
        {
            InitializeComponent();
        }

        private void FrmTolid_KontorTestDList_Load(object sender, EventArgs e)
        {
            ClsTolid obj = new ClsTolid();
            grd.DataSource = obj.Select_KontorTestD().Tables[0];
        }
    }
}

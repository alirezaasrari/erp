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
    public partial class FrnUM_Report : Telerik.WinControls.UI.RadForm
    {
        public FrnUM_Report()
        {
            InitializeComponent();
        }
        ClsUM objum = new ClsUM();
        private void FrnUM_Report_Load(object sender, EventArgs e)
        {
            grdControl.DataSource = objum.SelectControlFormProgramRole().Tables[0];
        }
    }
}

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
    public partial class FrmPLN_AnalysGhete : Telerik.WinControls.UI.RadForm
    {
        public FrmPLN_AnalysGhete()
        {
            InitializeComponent();
        }

        private void btnAnalyse_Click(object sender, EventArgs e)
        {
            ClsPlanning objPlanning = new ClsPlanning();
            using (new PleaseWait(this.Location))
            {
                objPlanning.AnalysGhete();
            }
            grdAnalyseGhete.DataSource = objPlanning.Select_AnalysGheteSefaresh().Tables[0];
        }

        private void FrmPLN_AnalysGhete_Load(object sender, EventArgs e)
        {
            ClsPlanning objPlanning = new ClsPlanning();
            grdAnalyseGhete.DataSource = objPlanning.Select_AnalysGheteSefaresh().Tables[0];
        }
    }
}

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
    public partial class FrmPLN_AnalyzeSefareshat : Telerik.WinControls.UI.RadForm
    {
        public FrmPLN_AnalyzeSefareshat()
        {
            InitializeComponent();
        }
        public static string strTypeReport;
        ClsSale objSale = new ClsSale();
        private void FrmPLN_aghlamF2_Load(object sender, EventArgs e)
        {

        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            ClsPlanning obj = new ClsPlanning();
            using (new PleaseWait(this.Location))
            {              
                //MessageBox.Show(obj.AnalyzeSefareshat());
                obj.AnalyzeSefareshat1();
                obj.AnalyzeSefareshat2();                
            }
            MessageBox.Show(obj.AnalyzeSefareshat3());
        }
    }
}

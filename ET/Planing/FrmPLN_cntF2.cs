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
    public partial class FrmPLN_cntF2 : Telerik.WinControls.UI.RadForm
    {
        public FrmPLN_cntF2()
        {
            InitializeComponent();
        }
        public static string strTypeReport;
        ClsSale objSale = new ClsSale();
        private void FrmPLN_aghlamF2_Load(object sender, EventArgs e)
        {
            if (strTypeReport == "aghlam")
            {
                grd.MasterTemplate.Columns.Add("aghlam_code");
                grd.MasterTemplate.Columns["aghlam_code"].HeaderText = "کد اقلام";
                grd.MasterTemplate.Columns.Add("year");
                grd.DataSource = objSale.Select_AghlamF2().Tables[0];
            } 
        }
    }
}

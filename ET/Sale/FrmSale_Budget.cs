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
    public partial class FrmSale_Budget : Telerik.WinControls.UI.RadForm
    {
        public FrmSale_Budget()
        {
            InitializeComponent();
        }
        ClsSale objSale = new ClsSale();
        public int intIdMonth;
        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            intIdMonth = (cmbMonth.SelectedIndex + 1);
        }

        private void FrmSale_Budget_Load(object sender, EventArgs e)
        {
            grdBudget.DataSource = objSale.Select_Budget().Tables[0];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            objSale.IntIdMonth = intIdMonth;
            objSale.strBudget = txtBudget.Text;
            MessageBox.Show(objSale.Update_Budget());
            grdBudget.DataSource = objSale.Select_Budget().Tables[0];

        }
    }
}

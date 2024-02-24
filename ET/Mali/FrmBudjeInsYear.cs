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
    public partial class FrmBudjeInsYear : Telerik.WinControls.UI.RadForm
    {
        public FrmBudjeInsYear()
        {
            InitializeComponent();
        }
        ClsMali objMali = new ClsMali();
        private void btnYearAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtYear.Text.Trim()) || txtYear.Text.Trim().Length!=4)
            {
                RadMessageBox.Show(" سال را وارد نمایید");
                return;
            }
            try
            {

                RadMessageBox.Show(objMali.InsYear(txtYear.Text.Trim()));
                
            }
            catch (Exception exp)
            {
                RadMessageBox.Show("خطا در اجرای عملیات \n" + exp.Message);
            }
        }

        private void btnAmalkard_Click(object sender, EventArgs e)
        {
            DataRow drSelectAmalkard = objMali.SelectAmalkard(txtYear.Text.Trim(), sEdtMonth.Value.ToString()).Tables[0].Rows[0];

                   
        }
    }
}

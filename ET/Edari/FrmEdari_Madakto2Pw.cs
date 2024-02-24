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
    public partial class FrmEdari_Madakto2Pw : Telerik.WinControls.UI.RadForm
    {
        public FrmEdari_Madakto2Pw()
        {
            InitializeComponent();
        }
        public ClsEdari ClsEdariObj = new ClsEdari();
        private void btnReadData_Click(object sender, EventArgs e)
        {
            if(cmbType.SelectedIndex==-1)
            {
                MessageBox.Show("نوع تردد را مشخص کنید");
                return;
            }
            MessageBox.Show(ClsEdariObj.Madakto2Pw(cmbType.SelectedIndex));
            lblCount.Text = ClsEdariObj.CountMadakto2Pw(cmbType.SelectedIndex).Tables[0].Rows[0][0].ToString();
        }

        private void FrmEdari_Madakto2Pw_Load(object sender, EventArgs e)
        {
            ClsEdariObj.Madakto2PwUpdateTable();
        }

        private void cmbType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            using (new PleaseWait(this.Location))
            {
                lblCount.Text = ClsEdariObj.CountMadakto2Pw(cmbType.SelectedIndex).Tables[0].Rows[0][0].ToString();
            }
        }
    }
}

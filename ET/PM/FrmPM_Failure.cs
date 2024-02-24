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
    public partial class FrmPM_Failure : Telerik.WinControls.UI.RadForm
    {
        public FrmPM_Failure()
        {
            InitializeComponent();
        }
        ClsPM objPM = new ClsPM();
        private void FrmPM_Failure_Load(object sender, EventArgs e)
        {
            grdFailure.DataSource = objPM.select_Failure().Tables[0];
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            objPM.Nfailure = txb_reason_delay.Text;
            MessageBox.Show(objPM.Ins_Failure());
            grdFailure.DataSource = objPM.select_Failure().Tables[0];
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            objPM.Nfailure = txb_reason_delay.Text;
            MessageBox.Show(objPM.update_Failure());
            grdFailure.DataSource = objPM.select_Failure().Tables[0];
        }

        private void grdFailure_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            objPM.FK_ID_Failure = grdFailure.Rows[e.RowIndex].Cells["ID_Failure"].Value.ToString();
            txb_reason_delay.Text = grdFailure.Rows[e.RowIndex].Cells["NFailure"].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show(objPM.Del_Failure());

            grdFailure.DataSource = objPM.select_Failure().Tables[0];
            txb_reason_delay.Text = "";
        }
    }
}

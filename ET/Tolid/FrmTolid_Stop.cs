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
    public partial class FrmTolid_Stop : Telerik.WinControls.UI.RadForm
    {
        public FrmTolid_Stop()
        {
            InitializeComponent();
        }
        string strIdTolidStop;
        private void FrmTolid_Stop_Load(object sender, EventArgs e)
        {
            ClsTolid objTolid = new ClsTolid();
            grdStop.DataSource = objTolid.Select_TolidStop().Tables[0];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClsTolid objTolid = new ClsTolid();
            objTolid.strIdTolidStop = txtIdStop.Text;
            objTolid.strDescStop = txtDescStop.Text;
            objTolid.boolActive = chkActive.Checked;
            objTolid.boolIsOk = chkIsOk.Checked;
            MessageBox.Show(objTolid.INS_TolidStop());

            objTolid.strIdTolidStop = "";
            grdStop.DataSource = objTolid.Select_TolidStop().Tables[0];
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ClsTolid objTolid = new ClsTolid();
            objTolid.strIdTolidStop = txtIdStop.Text;
            objTolid.strIdTolidStopW = strIdTolidStop;
            objTolid.strDescStop = txtDescStop.Text;
            objTolid.boolActive = chkActive.Checked;
            objTolid.boolIsOk = chkIsOk.Checked;
            MessageBox.Show(objTolid.Update_TolidStop());

            objTolid.strIdTolidStop = "";
            grdStop.DataSource = objTolid.Select_TolidStop().Tables[0];
        }

        private void grdStop_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            strIdTolidStop = grdStop.Rows[e.RowIndex].Cells["ID_stop"].Value.ToString();
            txtIdStop.Text = grdStop.Rows[e.RowIndex].Cells["ID_stop"].Value.ToString();
            txtDescStop.Text = grdStop.Rows[e.RowIndex].Cells["Desc_stop"].Value.ToString();
            chkActive.Checked = Convert.ToBoolean(grdStop.Rows[e.RowIndex].Cells["Active"].Value.ToString());
            chkIsOk.Checked = Convert.ToBoolean(grdStop.Rows[e.RowIndex].Cells["IsOk"].Value.ToString());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ClsTolid objTolid = new ClsTolid();
            objTolid.strIdTolidStopW = strIdTolidStop;
            MessageBox.Show(objTolid.DelTolidStop());

            objTolid.strIdTolidStop = "";
            grdStop.DataSource = objTolid.Select_TolidStop().Tables[0];
        }
    }
}

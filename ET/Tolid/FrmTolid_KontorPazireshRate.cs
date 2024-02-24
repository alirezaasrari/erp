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
    public partial class FrmTolid_KontorPazireshRate : Telerik.WinControls.UI.RadForm
    {
        public FrmTolid_KontorPazireshRate()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ClsTolid obj = new ClsTolid();
                obj.strError1 = txtError1.Text;
                obj.strError2 = txtError2.Text;
                obj.ResultTest = cmbResult.Text;
                RadMessageBox.Show(obj.INS_KontorPazireshRate());
                grd.DataSource = obj.Select_KontorPazireshRate().Tables[0];
            }
            catch(Exception ee)
            {
                RadMessageBox.Show(ee.Message);
            }
        }

        private void FrmTolid_KontorPazireshRate_Load(object sender, EventArgs e)
        {
            ClsTolid obj = new ClsTolid();
            cmbResult.DataSource= obj.Select_KontorResult().Tables[0];
            cmbResult.ValueMember = "IdPazireshRate";
            cmbResult.DisplayMember = "ResultTest";

            grd.DataSource = obj.Select_KontorPazireshRate().Tables[0];
        }

        private void grd_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "btnEdit")
                {
                    ClsTolid obj = new ClsTolid();
                    if (MessageBox.Show("آیا از تغییر اطمینان دارید؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        obj.strIdPazireshRate = grd.CurrentRow.Cells["IdPazireshRate"].Value.ToString();
                        obj.strError1 = grd.CurrentRow.Cells["Error1"].Value.ToString();
                        obj.strError2 = grd.CurrentRow.Cells["Error2"].Value.ToString();
                        obj.Update_KontorPazireshRateBase();
                    }
                    grd.DataSource = obj.Select_KontorPazireshRate().Tables[0];
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}

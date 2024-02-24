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
    public partial class FrmTJRT_Factor : Telerik.WinControls.UI.RadForm
    {
        public FrmTJRT_Factor()
        {
            InitializeComponent();
        }
        public string strIdBarge;
        private void btnAddBarge_Click(object sender, EventArgs e)
        {
            ClsSale obj = new ClsSale();
            txtIdBarge.Text = obj.Insert_TJRTBarge().Tables[0].Rows[0][0].ToString();
            btnAddBarge.Enabled = false;
            btnAddFactor.Enabled = true;
        }

        private void btnAddFactor_Click(object sender, EventArgs e)
        {
            ClsSale obj = new ClsSale();
            obj.strIdBarge = txtIdBarge.Text;
            obj.strIdFactorH = txtFactor.Text;
            MessageBox.Show(obj.Insert_TJRTFactorH());
            txtFactor.Text = "";
            grd.DataSource = obj.Select_TJRTFactor().Tables[0];
        }

        private void FrmTJRT_Factor_Load(object sender, EventArgs e)
        {
            if(strIdBarge != null)
            {
                txtIdBarge.Text = strIdBarge;
                btnAddBarge.Enabled = false;
                btnAddFactor.Enabled = true;
                ClsSale obj = new ClsSale();
                obj.strIdBarge = txtIdBarge.Text;
                grd.DataSource = obj.Select_TJRTFactor().Tables[0];
            }
            else
            {

            }
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            ClsSale obj = new ClsSale();
            obj.strIdBarge = txtIdBarge.Text;
            MessageBox.Show(obj.Insert_TJRTFactorCalc());
        }

        private void grd_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "IsKit")
            {
                ClsSale obj = new ClsSale();
                //obj.strIsKit = Convert.ToInt32(grd.CurrentRow.Cells["IsKit"].Value).ToString();
                obj.strCKala = grd.CurrentRow.Cells["CkalaH"].Value.ToString();
                obj.Update_TJRTFactorKit();
            }
            if (e.Column.Name == "btnDelete")
            {
                if (RadMessageBox.Show("آیا از حذف اطلاعات اطمینان دارید؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ClsSale obj = new ClsSale();
                    obj.strIdFactorD = grd.CurrentRow.Cells["IdFactorD"].Value.ToString();
                    obj.Delete_TJRTFactorD();

                    obj.strIdBarge = txtIdBarge.Text;
                    grd.DataSource = obj.Select_TJRTFactor().Tables[0];
                }
            }
        }
    }
}

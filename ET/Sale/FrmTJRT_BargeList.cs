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
    public partial class FrmTJRT_BargeList : Telerik.WinControls.UI.RadForm
    {
        public FrmTJRT_BargeList()
        {
            InitializeComponent();
        }

        private void grd_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "btnFactor")
            {
                FrmTJRT_Factor frm = new FrmTJRT_Factor();
                frm.strIdBarge = grd.CurrentRow.Cells["IdBarge"].Value.ToString();
                frm.ShowDialog();
            }
            if (e.Column.Name == "btnSamane")
            {
                FrmTJRT_Samane frm = new FrmTJRT_Samane();
                frm.strIdBarge = grd.CurrentRow.Cells["IdBarge"].Value.ToString();
                frm.ShowDialog();
            }
            if (e.Column.Name == "btnDelete")
            {
                if (RadMessageBox.Show("آیا از حذف برگه اطمینان دارید؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ClsSale obj = new ClsSale();
                    obj.strIdBarge = grd.CurrentRow.Cells["IdBarge"].Value.ToString();
                    obj.Delete_TJRTBarge();
                    grd.DataSource = obj.Select_TJRTBarge().Tables[0];
                }
            }
        }

        private void FrmTJRT_BargeList_Load(object sender, EventArgs e)
        {
            ClsSale obj = new ClsSale();
            grd.DataSource = obj.Select_TJRTBarge().Tables[0];
        }

        private void btnAddBarge_Click(object sender, EventArgs e)
        {
            FrmTJRT_Factor frm = new FrmTJRT_Factor();
            frm.ShowDialog();
        }
    }
}

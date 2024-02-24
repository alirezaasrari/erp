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
    public partial class Frm_Customer_adjoint_work : Telerik.WinControls.UI.RadForm
    {
        public Frm_Customer_adjoint_work()
        {
            InitializeComponent();
        }
        Cls_Customer cc = new Cls_Customer();
        private void Frm_Customer_adjoint_work_Load(object sender, EventArgs e)
        {
            New_CAW();
        }
        private void New_CAW()
        {
            grd.DataSource = cc.select_adjoint_work().Tables[0];
            btn_ADD.Enabled = false;
            btn_Delete.Enabled = false;
            btn_Edit.Enabled = false;
            btn_Save.Enabled = true;            
            cc.ID_adjoint_work = null;
            txb_N.Text = null;
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            cc.N_adjoint_work = txb_N.Text;
            RadMessageBox.Show(cc.Ins_adjoint_work());
            New_CAW();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            RadMessageBox.Show(cc.Delete_adjoint_work());
            New_CAW();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            cc.N_adjoint_work = txb_N.Text;
            RadMessageBox.Show(cc.Update_adjoint_work());
            New_CAW();
        }

        private void btn_ADD_Click(object sender, EventArgs e)
        {
            New_CAW();
        }

        private void grd_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            btn_ADD.Enabled = true;
            btn_Delete.Enabled = true;
            btn_Edit.Enabled = true;
            btn_Save.Enabled = false;
            txb_N.Text = grd.CurrentRow.Cells["N_adjoint_work"].Value.ToString();
            cc.ID_adjoint_work = grd.CurrentRow.Cells["ID_adjoint_work"].Value.ToString();
        }
    }
}

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
    public partial class Frm_Customer_title : Telerik.WinControls.UI.RadForm
    {
        //ClsSupplier cs = new ClsSupplier();
        Cls_Customer cc = new Cls_Customer();
        public Frm_Customer_title()
        {
            InitializeComponent();
        }
        private void NewSH()
        {
            grd.DataSource = cc.select_customer_title().Tables[0];
            btn_ADD.Enabled = false;
            btn_Delete.Enabled = false;
            btn_Edit.Enabled = false;
            btn_Save.Enabled = true;
            //cs.Name = null;
            cc.ID_Title = null;
            txb_N.Text = null;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            cc.N_Title = txb_N.Text;
            RadMessageBox.Show(cc.Ins_Customer_title());
            NewSH();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            cc.N_Title = txb_N.Text;
            RadMessageBox.Show(cc.Update_Customer_title());
            NewSH();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            RadMessageBox.Show(cc.Delete_Customer_title());
            NewSH();
        }

        private void btn_ADD_Click(object sender, EventArgs e)
        {
            NewSH();
        }

        private void Frm_Supplier_semat_Load(object sender, EventArgs e)
        {
            NewSH();
        }

        private void grd_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            btn_ADD.Enabled = true;
            btn_Delete.Enabled = true;
            btn_Edit.Enabled = true;
            btn_Save.Enabled = false;
            try
            {
                txb_N.Text = grd.CurrentRow.Cells["N_Title"].Value.ToString();
                cc.ID_Title = grd.CurrentRow.Cells["ID_Title"].Value.ToString();
            }
            catch
            {
                RadMessageBox.Show("روی خطوط گرید کلید نمایید");
            }
        }
    }
}

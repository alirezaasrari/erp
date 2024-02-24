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
    public partial class FrmAnbar_GroupKala : Telerik.WinControls.UI.RadForm
    {
        public FrmAnbar_GroupKala()
        {
            InitializeComponent();
        }
        ClsAnbar ObjAnbar = new ClsAnbar();
        public string strIdGroupKala, strNameGroupKala;
        private void FrmPub_GroupKala_Load(object sender, EventArgs e)
        {
            grdGroupKala.DataSource = ObjAnbar.SelectGroupKala().Tables[0];
        }

        private void btn_edit_sparepart_Click(object sender, EventArgs e)
        {
            ObjAnbar.strIdGroupKala = strIdGroupKala;
            ObjAnbar.strNameGroupKala = txtGroup.Text;
            if (MessageBox.Show("آیا از تغییر اطلاعات اطمینان دارید؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                MessageBox.Show(ObjAnbar.UpdateGroupKala());

            ObjAnbar.strNameGroupKala = "";
            grdGroupKala.DataSource = ObjAnbar.SelectGroupKala().Tables[0];
        }

        private void grdGroupKala_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            strIdGroupKala = grdGroupKala.Rows[e.RowIndex].Cells["IdGroupKala"].Value.ToString();
            txtGroup.Text = grdGroupKala.Rows[e.RowIndex].Cells["NameGroupKala"].Value.ToString();
        }

        private void btn_add_sparepart_Click(object sender, EventArgs e)
        {
            ObjAnbar.strNameGroupKala = txtGroup.Text;
            MessageBox.Show(ObjAnbar.InsertGroupKala());

            ObjAnbar.strNameGroupKala = "";
            grdGroupKala.DataSource = ObjAnbar.SelectGroupKala().Tables[0];
        }

        private void btn_del_sparepart_Click(object sender, EventArgs e)
        {
            ObjAnbar.strIdGroupKala = strIdGroupKala;
            if (MessageBox.Show("آیا از تغییر اطلاعات اطمینان دارید؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                MessageBox.Show(ObjAnbar.DeleteGroupKala());

            ObjAnbar.strNameGroupKala = "";
            grdGroupKala.DataSource = ObjAnbar.SelectGroupKala().Tables[0];
        }
    }
}

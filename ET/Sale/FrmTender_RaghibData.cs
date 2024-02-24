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
    public partial class FrmTender_RaghibData : Telerik.WinControls.UI.RadForm
    {
        public FrmTender_RaghibData()
        {
            InitializeComponent();
        }
        public string strNameRaghib, strIdRaghib;
        private void FrmTender_RaghibData_Load(object sender, EventArgs e)
        {
            ClsSale objSale = new ClsSale();
            grdRaghib.DataSource = objSale.Select_TenderRaghib().Tables[0];
        }

        private void grdRaghib_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            strIdRaghib = grdRaghib.Rows[e.RowIndex].Cells["IdRaghib"].Value.ToString();
            strNameRaghib = grdRaghib.Rows[e.RowIndex].Cells["NameRaghib"].Value.ToString();
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClsSale objSale = new ClsSale();
            objSale.strNameRaghib = txtRaghibName.Text;
            objSale.strTafsiliNO = txtTafsili.Text;
            MessageBox.Show(objSale.Insert_TenderRaghib());

            grdRaghib.DataSource = objSale.Select_TenderRaghib().Tables[0];
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ClsSale objSale = new ClsSale();
            objSale.strNameRaghib = txtRaghibName.Text;
            objSale.strTafsiliNO = txtTafsili.Text;
            objSale.strIdRaghib = strIdRaghib;
            MessageBox.Show(objSale.Update_TenderRaghib());

            grdRaghib.DataSource = objSale.Select_TenderRaghib().Tables[0];

            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            ClsSale objSale = new ClsSale();
            objSale.strIdRaghib = strIdRaghib;
            MessageBox.Show(objSale.Delete_TenderRaghib());

            grdRaghib.DataSource = objSale.Select_TenderRaghib().Tables[0];

            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
        }

        private void grdRaghib_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            strIdRaghib = grdRaghib.Rows[e.RowIndex].Cells["IdRaghib"].Value.ToString();
            txtRaghibName.Text = strNameRaghib = grdRaghib.Rows[e.RowIndex].Cells["NameRaghib"].Value.ToString();
            txtTafsili.Text = strNameRaghib = grdRaghib.Rows[e.RowIndex].Cells["Tafsili"].Value.ToString();

            btnAdd.Enabled = false;
            btnEdit.Enabled = true;
            btnDel.Enabled = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
        }

        private void txtTafsili_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmTafsili frm = new FrmTafsili();
                frm.ShowDialog();
                txtTafsili.Text = frm.Ctifsili;
                txtRaghibName.Text = frm.Ntafsili;
            }
        }
    }
}

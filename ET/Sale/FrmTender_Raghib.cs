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
    public partial class FrmTender_Raghib : Telerik.WinControls.UI.RadForm
    {
        public FrmTender_Raghib()
        {
            InitializeComponent();
        }
        public string strIdTender, strIdRaghib, strIdRaghibTender, strIdTenderRaghibDetail; 
        private void btnAddRaghibTender_Click(object sender, EventArgs e)
        {
            ClsSale ObjSale = new ClsSale();
            ObjSale.strIdTender = strIdTender;
            ObjSale.strIdRaghib = strIdRaghib;
            ObjSale.strRank = txtRank.Text;
            ObjSale.strPrice = txtPriceAll.Text;
            MessageBox.Show(ObjSale.Insert_TenderRaghibList());

            grdRaghib.DataSource = ObjSale.Select_TenderRaghibList().Tables[0];
        }

        private void btnF2Tender_Click(object sender, EventArgs e)
        {
            FrmTender_Show frm = new FrmTender_Show();
            frm.ShowDialog();
            if (frm.strIdTender == null)
                strIdTender = "0";
            else
                strIdTender = frm.strIdTender;
            txtTenderName.Text = frm.strTenderName;

            DataSet ds = new DataSet();
            ClsSale objSale = new ClsSale();
            objSale.strIdTender = strIdTender;
            ds = objSale.Select_TenderRaghibList();

            grdRaghib.DataSource = objSale.Select_TenderRaghibList().Tables[0];
        }

        private void btnF2Raghib_Click(object sender, EventArgs e)
        {
            FrmTender_RaghibData frm = new FrmTender_RaghibData();
            frm.ShowDialog();
            txtRaghibName.Text = frm.strNameRaghib;
            strIdRaghib = frm.strIdRaghib;
        }

        private void btnF2kala_Click(object sender, EventArgs e)
        {
            FrmKala frm = new FrmKala();
            frm.strC_Anbar = "14,15";
            frm.ShowDialog();
            txtNkala.Text = ClsPublic.N_kala;
            lblCkala.Text = ClsPublic.C_kala;
            txtCAnbar.Text = ClsPublic.C_Anbar;
            lblNAnbar.Text = ClsPublic.N_Anbar;
        }

        private void btnEditRaghibTender_Click(object sender, EventArgs e)
        {
            ClsSale ObjSale = new ClsSale();
            ObjSale.strIdRaghibTender = strIdRaghibTender;
            ObjSale.strIdRaghib = strIdRaghib;
            ObjSale.strRank = txtRank.Text;
            ObjSale.strPrice = txtPriceAll.Text;
            MessageBox.Show(ObjSale.Update_TenderRaghib());

            ObjSale.strIdTender = strIdTender;
            grdRaghib.DataSource = ObjSale.Select_TenderRaghibList().Tables[0];
        }

        private void btnDelRaghibTender_Click(object sender, EventArgs e)
        {
            ClsSale ObjSale = new ClsSale();
            ObjSale.strIdRaghibTender = strIdRaghibTender;
            MessageBox.Show(ObjSale.Delete_TenderRaghib());

            ObjSale.strIdTender = strIdTender;
            grdRaghib.DataSource = ObjSale.Select_TenderRaghibList().Tables[0];

            strIdRaghibTender = "0";
        }

        private void btnAddRaghibDetail_Click(object sender, EventArgs e)
        {
            ClsSale ObjSale = new ClsSale();
            ObjSale.strIdRaghibTender = strIdRaghibTender;
            ObjSale.strCKala = lblCkala.Text;
            ObjSale.strCAnbar = txtCAnbar.Text;
            ObjSale.strTedad = txtTedad.Text;
            ObjSale.strPrice = txtPrice.Text;

            MessageBox.Show(ObjSale.Insert_TenderRaghibDetail());

            grdDetail.DataSource = ObjSale.Select_TenderRaghibDetail().Tables[0];
        }

        private void grdRaghib_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            ClsSale ObjSale = new ClsSale();
            txtRaghibName.Text = grdRaghib.Rows[e.RowIndex].Cells["NameRaghib"].Value.ToString();
            strIdRaghib = grdRaghib.Rows[e.RowIndex].Cells["IdRaghib"].Value.ToString();
            txtRank.Text = grdRaghib.Rows[e.RowIndex].Cells["Rank"].Value.ToString();
            ObjSale.strIdRaghibTender = strIdRaghibTender = grdRaghib.Rows[e.RowIndex].Cells["IdRaghibTender"].Value.ToString();
            grdDetail.DataSource = ObjSale.Select_TenderRaghibDetail().Tables[0];

            btnAddRaghibDetail.Enabled = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtTenderName.Text = "";
            txtRaghibName.Text = "";
            txtRank.Text = "0";
            grdRaghib.DataSource = null;
        }

        private void grdDetail_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            strIdTenderRaghibDetail = grdDetail.Rows[e.RowIndex].Cells["id"].Value.ToString();
            txtNkala.Text = grdDetail.Rows[e.RowIndex].Cells["N_Kala"].Value.ToString();
            lblCkala.Text = grdDetail.Rows[e.RowIndex].Cells["Ckala"].Value.ToString();
            txtCAnbar.Text = grdDetail.Rows[e.RowIndex].Cells["CAnbar"].Value.ToString();
            lblNAnbar.Text = grdDetail.Rows[e.RowIndex].Cells["N_anbar"].Value.ToString();
            txtPrice.Text = grdDetail.Rows[e.RowIndex].Cells["Price"].Value.ToString();
            txtTedad.Text = grdDetail.Rows[e.RowIndex].Cells["Tedad"].Value.ToString();

            btnAddRaghibDetail.Enabled = false;
            btnEditRaghibDetail.Enabled = true;
            btnDeleteRaghibDetail.Enabled = true;
        }

        private void btnEditRaghibDetail_Click(object sender, EventArgs e)
        {
            ClsSale objSale = new ClsSale();
            objSale.strIdTenderRaghibDetail = strIdTenderRaghibDetail;
            objSale.strCKala = lblCkala.Text;
            objSale.strCAnbar = txtCAnbar.Text;
            objSale.strTedad = txtTedad.Text;
            objSale.strPrice = txtPrice.Text;
            MessageBox.Show(objSale.Update_TenderRaghibDetail());

            objSale.strIdRaghibTender = strIdRaghibTender;
            grdDetail.DataSource = objSale.Select_TenderRaghibDetail().Tables[0];

            btnAddRaghibDetail.Enabled = true;
            btnEditRaghibDetail.Enabled = false;
            btnDeleteRaghibDetail.Enabled = false;
        }

        private void btnDeleteRaghibDetail_Click(object sender, EventArgs e)
        {
            ClsSale ObjSale = new ClsSale();
            ObjSale.strIdTenderRaghibDetail = strIdTenderRaghibDetail;
            MessageBox.Show(ObjSale.Delete_TenderRaghibDetail());

            ObjSale.strIdRaghibTender = strIdRaghibTender;
            grdDetail.DataSource = ObjSale.Select_TenderRaghibDetail().Tables[0];

            strIdTenderRaghibDetail = "0";
            txtNkala.Text = "";
            lblCkala.Text = "";
            txtCAnbar.Text = "";
            lblNAnbar.Text = "";
            txtPrice.Text = "";
            txtTedad.Text = "";

            btnAddRaghibDetail.Enabled = true;
            btnEditRaghibDetail.Enabled = false;
            btnDeleteRaghibDetail.Enabled = false;
        }

        private void btnRefreshDetail_Click(object sender, EventArgs e)
        {
            btnAddRaghibDetail.Enabled = true;
            btnEditRaghibDetail.Enabled = false;
            btnDeleteRaghibDetail.Enabled = false;
        }
    }
}

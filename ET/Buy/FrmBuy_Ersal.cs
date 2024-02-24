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
    public partial class FrmBuy_Ersal : Telerik.WinControls.UI.RadForm
    {
        public FrmBuy_Ersal()
        {
            InitializeComponent();
        }
        public string strIdErsalH, strIdErsalD, strBaghimande;
        private void FrmBuy_Ersal_Load(object sender, EventArgs e)
        {
            dtpErsal.Value = DateTime.Now;
            dtpTahvil.Value = DateTime.Now;

            ClsBuy objBuy = new ClsBuy();
            GrdH.DataSource = objBuy.Select_BuyErsalH().Tables[0];
        }

        private void txtTamin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmTafsili frm = new FrmTafsili();
                frm.ShowDialog();
                lblTamin.Text = ClsBuy.tafsili_Name;
                txtTamin.Text = ClsBuy.tafsili_Id;
            }
        }

        private void txtMoshtari_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmTafsili frm = new FrmTafsili();
                frm.ShowDialog();
                lblMoshtari.Text = ClsBuy.tafsili_Name;
                txtMoshtari.Text = ClsBuy.tafsili_Id;
            }
        }

        private void txtDarkhast_No_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmBuy_BarnameSearch frm = new FrmBuy_BarnameSearch();
                frm.ShowDialog();
                txtDarkhast_No.Text = ClsBuy.Sho_Darkhast;
                txtDarkhast_Radif.Text = ClsBuy.DarkhastRadif;
                txtCkala.Text = ClsBuy.C_kala;
                txtNkala.Text = ClsBuy.N_kala;
                txtMeghdar.Text = strBaghimande = ClsBuy.Baghimande;
            }
        }

        private void btnAddH_Click(object sender, EventArgs e)
        {
            ClsBuy objBuy = new ClsBuy();
            objBuy.Tafsili = txtTamin.Text;
            objBuy.str_cMoshtari = txtMoshtari.Text;
            objBuy.strDate1 = dtpErsal.Value.ToString().Substring(0, 10);
            objBuy.strDate2 = dtpTahvil.Value.ToString().Substring(0, 10);
            objBuy.strBazresi = rdbBazresiYes.Checked.ToString();
            objBuy.strTypeSefaresh = (cmbTypeSefaresh.SelectedIndex + 1).ToString();
            MessageBox.Show(objBuy.InsErsalH());
            GrdH.DataSource = objBuy.Select_BuyErsalH().Tables[0];
            txtIdErsarH.Text = strIdErsalH = objBuy.Select_BuyErsalHMaxID().Tables[0].Rows[0][0].ToString();            

            grpH.Enabled = false;;
            grpD.Enabled = true;
        }

        private void btnAddD_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(strBaghimande) < Convert.ToInt32(txtMeghdar.Text))
            {
                MessageBox.Show("مقدار ارسال بیشتر از مانده درخواست است");
                return;
            }
            ClsBuy objBuy = new ClsBuy();
            objBuy.strIdErsalH = txtIdErsarH.Text;
            objBuy.strSho_Darkhast = txtDarkhast_No.Text;
            objBuy.strDarkhastRadif = txtDarkhast_Radif.Text;
            objBuy.Meghdar = txtMeghdar.Text;
            objBuy.strComment = txtTozihat.Text;
            MessageBox.Show(objBuy.InsErsalD());
            SearchErsalH();
        }

        public void SearchErsalH()
        {
            try
            {
                ClsBuy objBuy = new ClsBuy();
                GrdH.DataSource = objBuy.Select_BuyErsalH().Tables[0];
                objBuy.strIdErsalH = txtIdErsarH.Text;
                DataSet ds = new DataSet();
                ds = objBuy.Select_BuyErsalH();
                txtTamin.Text = ds.Tables[0].Rows[0]["IdTaminKonande"].ToString();
                lblTamin.Text = ds.Tables[0].Rows[0]["NameTamin"].ToString();
                txtMoshtari.Text = ds.Tables[0].Rows[0]["IdMoshtari"].ToString();
                lblMoshtari.Text = ds.Tables[0].Rows[0]["nMoshtari"].ToString();
                if (ds.Tables[0].Rows[0]["Bazresi"].ToString() == "True")
                    rdbBazresiYes.Checked = true;
                else
                    rdbBazresiNo.Checked = true;
                dtpErsal.Text = ds.Tables[0].Rows[0]["DateErsal"].ToString();
                dtpTahvil.Text = ds.Tables[0].Rows[0]["DateTahvil"].ToString();

                grd.DataSource = objBuy.Select_BuyErsalD().Tables[0];
            }
            catch { }
        }

        private void grd_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                btnAddD.Enabled = false;
                btnEditD.Enabled = true;
                btnDeleteD.Enabled = true;
                strIdErsalD = grd.Rows[e.RowIndex].Cells["IdErsalD"].Value.ToString();
                txtDarkhast_No.Text = grd.Rows[e.RowIndex].Cells["Sho_Darkhast"].Value.ToString();
                txtDarkhast_Radif.Text = grd.Rows[e.RowIndex].Cells["Radif_Darkhast"].Value.ToString();
                txtCkala.Text = grd.Rows[e.RowIndex].Cells["C_kala"].Value.ToString();
                txtNkala.Text = grd.Rows[e.RowIndex].Cells["Nkala"].Value.ToString();
                txtMeghdar.Text = grd.Rows[e.RowIndex].Cells["Tedad"].Value.ToString();
                txtTozihat.Text = grd.Rows[e.RowIndex].Cells["Tozihat"].Value.ToString();
            }
            catch { }
        }

        private void btnEditD_Click(object sender, EventArgs e)
        {
            ClsBuy objBuy = new ClsBuy();
            objBuy.strSho_Darkhast = txtDarkhast_No.Text;
            objBuy.strDarkhastRadif = txtDarkhast_Radif.Text;
            objBuy.Meghdar = txtMeghdar.Text;
            objBuy.strComment = txtTozihat.Text;
            objBuy.strIdErsalD = strIdErsalD;
            MessageBox.Show(objBuy.UpdateErsalD());
            SearchErsalH();
        }

        private void btnDeleteD_Click(object sender, EventArgs e)
        {
            ClsBuy objBuy = new ClsBuy();
            objBuy.strIdErsalD = strIdErsalD;
            MessageBox.Show(objBuy.DelErsalD());
            SearchErsalH();
        }

        private void btnRefreshH_Click(object sender, EventArgs e)
        {
            txtTamin.Text = "";
            lblTamin.Text = "_";
            txtMoshtari.Text = "";
            lblMoshtari.Text = "_";
            grd.DataSource = null;
            btnEditH.Enabled = false;
            btnDeleteH.Enabled = false;
            btnAddH.Enabled = true;
            grpD.Enabled = false;
            grd.Enabled = true;
            ClsBuy objBuy = new ClsBuy();
            GrdH.DataSource = objBuy.Select_BuyErsalH().Tables[0];

        }

        private void btnEditH_Click(object sender, EventArgs e)
        {
            ClsBuy objBuy = new ClsBuy();
            objBuy.strIdErsalH=txtIdErsarH.Text;
            if (objBuy.Select_BuyErsalH().Tables[0].Rows[0]["IsSend"].ToString() == "True")
            {
                MessageBox.Show("این فرم امضا شده است");
                return;
            }
            objBuy.Tafsili = txtTamin.Text;
            objBuy.str_cMoshtari = txtMoshtari.Text;
            objBuy.strDate1 = dtpErsal.Value.ToString().Substring(0, 10);
            objBuy.strDate2 = dtpTahvil.Value.ToString().Substring(0, 10);
            objBuy.strBazresi = rdbBazresiYes.Checked.ToString();
            MessageBox.Show(objBuy.UpdateErsalH());

            SearchErsalH();

            btnRefreshH_Click(sender, e);
        }

        private void btnDeleteH_Click(object sender, EventArgs e)
        {
            ClsBuy objBuy = new ClsBuy();
            objBuy.strIdErsalH = txtIdErsarH.Text;
            if (objBuy.Select_BuyErsalH().Tables[0].Rows[0]["IsSend"].ToString() == "True")
            {
                MessageBox.Show("این فرم امضا شده است");
                return;
            }
            MessageBox.Show(objBuy.DelErsalH());
            SearchErsalH();

            btnRefreshH_Click(sender, e);
        }

        private void GrdH_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            ClsBuy objBuy = new ClsBuy();
            objBuy.strIdErsalH = txtIdErsarH.Text = GrdH.Rows[e.RowIndex].Cells["IdErsalH"].Value.ToString();
            txtTamin.Text = GrdH.Rows[e.RowIndex].Cells["IdTaminKonande"].Value.ToString();
            lblTamin.Text = GrdH.Rows[e.RowIndex].Cells["NameTamin"].Value.ToString();
            txtMoshtari.Text = GrdH.Rows[e.RowIndex].Cells["IdMoshtari"].Value.ToString();
            lblMoshtari.Text = GrdH.Rows[e.RowIndex].Cells["nMoshtari"].Value.ToString();
            if (GrdH.Rows[e.RowIndex].Cells["Bazresi"].Value.ToString() == "True")
                rdbBazresiYes.Checked = true;
            else
                rdbBazresiNo.Checked = true;
            dtpErsal.Text = GrdH.Rows[e.RowIndex].Cells["DateErsal"].Value.ToString();
            dtpTahvil.Text = GrdH.Rows[e.RowIndex].Cells["DateTahvil"].Value.ToString();
            cmbTypeSefaresh.SelectedIndex = Convert.ToInt16(GrdH.Rows[e.RowIndex].Cells["FK_SefareshTypeID"].Value)-1;

            grd.DataSource = objBuy.Select_BuyErsalD().Tables[0];

            btnEditH.Enabled = true;
            btnDeleteH.Enabled = true;
            btnAddH.Enabled = false;
            grpD.Enabled = true;
        }

        private void btnRefreshD_Click(object sender, EventArgs e)
        {
            btnEditD.Enabled = false;
            btnDeleteD.Enabled = false;
            btnAddD.Enabled = true;
            grpH.Enabled = true;
            btnRefreshH_Click(sender, e);
            strIdErsalD = "";
            txtDarkhast_No.Text = "";
            txtDarkhast_Radif.Text = "";
            txtCkala.Text = "";
            txtNkala.Text = "";
            txtMeghdar.Text = "";
            txtTozihat.Text = "";
        }
    }
}

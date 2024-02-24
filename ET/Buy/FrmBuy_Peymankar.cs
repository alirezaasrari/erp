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
    public partial class FrmBuy_Peymankar : Telerik.WinControls.UI.RadForm
    {
        public FrmBuy_Peymankar()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        public string strid_Gheteh, strIdPeymankardata;

        private void txtC_Tafsili_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtC_Tafsili.Text != "")
                {
                    ClsBuy objBuy = new ClsBuy();
                    objBuy.str_cMoshtari = txtC_Tafsili.Text;
                    objBuy.strC_Tafsili = txtC_Tafsili.Text;
                    ds = objBuy.Select_TafsiliData();
                    grd.DataSource = ds.Tables[0];
                    txtN_Tafsili.Text = objBuy.SelectTafsili().Tables[0].Rows[0]["nMoshtari"].ToString();
                }
                else
                {
                    grd.DataSource = null;
                }
            }
            catch { }
        }

        private void btnF2Tafsili_Click(object sender, EventArgs e)
        {
            FrmTafsili frm = new FrmTafsili();

            frm.ShowDialog();
            txtC_Tafsili.Text = ClsBuy.tafsili_Id;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClsBuy objBuy = new ClsBuy();
            objBuy.strC_Tafsili = txtC_Tafsili.Text;
            objBuy.strId_Gheteh = strid_Gheteh;
            objBuy.strCountInDay = txtCountInDay.Text;
            objBuy.InsPeymankarData();

            objBuy.strIdPeymankardata = objBuy.Select_MaxTafsiliID().Tables[0].Rows[0][0].ToString();
            objBuy.strPriceKala = txtPriceSabt.Text;
            MessageBox.Show(objBuy.InsPeymankarPrice());

            txtC_Tafsili_TextChanged(sender, e);
        }
        
        public void ClearControl()
        {
            //txtN_Tafsili.Text = "";
            txtGhetehCode.Text = "";
            txtGheteName.Text = "";
            txtCountInDay.Text = "";
            txtPriceResid.Text = "";
            txtPriceSabt.Text = "";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtC_Tafsili.Text = "";
            txtN_Tafsili.Text = "";
            ClearControl();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ClsBuy objBuy = new ClsBuy();
                objBuy.strC_Tafsili = txtC_Tafsili.Text;
                ds = objBuy.Select_TafsiliData();
                grd.DataSource = ds.Tables[0];
            }
            catch { }
        }

        private void btnF2Kala_Click(object sender, EventArgs e)
        {
            ClearControl();
            FrmTakvinKala frm = new FrmTakvinKala();
            frm.strIsOutSource = "1";
            frm.ShowDialog();
            txtGheteName.Text = FrmTakvinKala.strNkala;
            txtGhetehCode.Text = FrmTakvinKala.strCkala;
            strid_Gheteh = FrmTakvinKala.strIdGhete;
        }

        private void txtGhetehCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ClsTakvin objTakvin = new ClsTakvin();
                objTakvin.strCKala = txtGhetehCode.Text;
                ds = objTakvin.SelectTakvinKala();
                txtGheteName.Text = ds.Tables[0].Rows[0]["GheteName"].ToString();
                strid_Gheteh = ds.Tables[0].Rows[0]["id_Gheteh"].ToString();

                ClsBuy objBuy = new ClsBuy();
                objBuy.strGhetehCode = txtGhetehCode.Text;
                objBuy.strC_Tafsili = txtC_Tafsili.Text;
                objBuy.strPriceKala = "1";
                txtPriceResid.Text = objBuy.Select_ResidGhati().Tables[0].Rows[0]["mablagh"].ToString();
            }
            catch { }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtC_Tafsili.Enabled = true;
            btnF2Tafsili.Enabled = true;
            btnF2Kala.Enabled = true;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;

            ClsBuy objBuy = new ClsBuy();
            objBuy.strCountInDay = txtCountInDay.Text;
            objBuy.strIdPeymankardata = strIdPeymankardata;
            objBuy.UpdatePeymankarData();

            objBuy.strIdPeymankardata = strIdPeymankardata;
            objBuy.strPriceKala = txtPriceSabt.Text;
            MessageBox.Show(objBuy.InsPeymankarPrice());

            txtC_Tafsili_TextChanged(sender, e);
        }

        private void grd_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            txtC_Tafsili.Enabled = false;
            btnF2Tafsili.Enabled = false;
            btnF2Kala.Enabled = false;
            btnEdit.Enabled = true;
            btnDel.Enabled = true;

            txtGhetehCode.Text = grd.Rows[e.RowIndex].Cells["GhetehCode"].Value.ToString();//ds.Tables[0].Rows[0]["GhetehCode"].ToString();
            strid_Gheteh = grd.Rows[e.RowIndex].Cells["id_Gheteh"].Value.ToString();//ds.Tables[0].Rows[0]["id_Gheteh"].ToString();
            txtGheteName.Text = grd.Rows[e.RowIndex].Cells["GheteName"].Value.ToString();//ds.Tables[0].Rows[0]["GheteName"].ToString();
            txtCountInDay.Text = grd.Rows[e.RowIndex].Cells["CountInDay"].Value.ToString();//ds.Tables[0].Rows[0]["CountInDay"].ToString();
            txtPriceResid.Text = grd.Rows[e.RowIndex].Cells["mablaghResid"].Value.ToString();//ds.Tables[0].Rows[0]["mablaghResid"].ToString();
            txtPriceSabt.Text = grd.Rows[e.RowIndex].Cells["PriceKala"].Value.ToString();//ds.Tables[0].Rows[0]["PriceKala"].ToString();
            strIdPeymankardata = grd.Rows[e.RowIndex].Cells["IdPeymankarData"].Value.ToString();//ds.Tables[0].Rows[0]["PriceKala"].ToString();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            txtC_Tafsili.Enabled = true;
            btnF2Tafsili.Enabled = true;
            btnF2Kala.Enabled = true;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;

            if(MessageBox.Show("آیا از حذف اطلاعات این کالا اطمینان دارید؟","",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                ClsBuy objBuy = new ClsBuy();
                objBuy.strIdPeymankardata = strIdPeymankardata;
                MessageBox.Show(objBuy.DelPeymankarData());

                txtC_Tafsili_TextChanged(sender, e);
            }
        }
    }
}

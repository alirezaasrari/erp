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
    public partial class FrmZamanDarRah : Telerik.WinControls.UI.RadForm
    {
        public FrmZamanDarRah()
        {
            InitializeComponent();
        }
        ClsBuy clsBuyObj = new ClsBuy();
        ClsAnbar clsAnbar = new ClsAnbar();
        private void FrmZamanDarRah_Load(object sender, EventArgs e)
        {
            grd.DataSource = clsBuyObj.KalaBuy().Tables[0];
        }

        private void txtCkala_TextChanged(object sender, EventArgs e)
        {
            try
            {
                clsAnbar.strC_Kala = txtCkala.Text;
                lblNkala.Text = clsAnbar.SelectKala().Tables[0].Rows[0]["N_Kala"].ToString();
                lblUnit1.Text = clsAnbar.SelectKala().Tables[0].Rows[0]["N_Vahed"].ToString();
            }
            catch
            {
                lblNkala.Text = "نام کالا";
                lblUnit1.Text = "واحد کالا";
            }
        }

        private void txtCkala_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNumber = 0;
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);
        }

        private void txtCkala_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmKala frm = new FrmKala();
                frm.ShowDialog();
                txtCkala.Text = ClsBuy.C_kala;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            clsBuyObj.strC_kala = txtCkala.Text;
            clsBuyObj.Meghdar = txtMeghdarPart.Text;
            clsBuyObj.Part = txtTimePart.Text;
            if (chkIsTadarokat.Checked == true)
                clsBuyObj.int_IS_tadarokat = "1";
            else
                clsBuyObj.int_IS_tadarokat = "0";
            MessageBox.Show(clsBuyObj.insBuyKala());

            clsBuyObj.strC_kala = "";
            grd.DataSource = clsBuyObj.KalaBuy().Tables[0];
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            clsBuyObj.strC_kala = txtCkala.Text;
            clsBuyObj.Meghdar = txtMeghdarPart.Text;
            clsBuyObj.Part = txtTimePart.Text;
            if (chkIsTadarokat.Checked == true)
                clsBuyObj.int_IS_tadarokat = "1";
            else
                clsBuyObj.int_IS_tadarokat = "0";
            MessageBox.Show(clsBuyObj.UpdateBuyKala());

            clsBuyObj.strC_kala = "";
            grd.DataSource = clsBuyObj.KalaBuy().Tables[0];

            btn_Save.Enabled = true;
            btn_Edit.Enabled = false;
            btn_Delete.Enabled = false;
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            clsBuyObj.strC_kala = txtCkala.Text;
            MessageBox.Show(clsBuyObj.DelBuyKala());

            clsBuyObj.strC_kala = "";
            grd.DataSource = clsBuyObj.KalaBuy().Tables[0];

            btn_Save.Enabled = true;
            btn_Edit.Enabled = false;
            btn_Delete.Enabled = false;
        }

        private void grd_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            txtCkala.Text = grd.Rows[e.RowIndex].Cells["C_kala"].Value.ToString();
            chkIsTadarokat.Checked = Convert.ToBoolean(grd.Rows[e.RowIndex].Cells["IS_Tadarokat"].Value);
            txtMeghdarPart.Text = grd.Rows[e.RowIndex].Cells["Meghdar_Part"].Value.ToString();
            txtTimePart.Text = grd.Rows[e.RowIndex].Cells["Time_Part"].Value.ToString();

            btn_Save.Enabled = false;
            btn_Edit.Enabled = true;
            btn_Delete.Enabled = true;
        }
    }
}

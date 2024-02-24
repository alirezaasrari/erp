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
    public partial class FrmAnbar_GroupKalaKala : Telerik.WinControls.UI.RadForm
    {
        public FrmAnbar_GroupKalaKala()
        {
            InitializeComponent();
        }
        ClsAnbar ObjAnbar = new ClsAnbar();
        private void FrmAnbar_GroupKalaKala_Load(object sender, EventArgs e)
        {
            ObjAnbar.strNkala = "";
            ObjAnbar.strC_Anbar = "";
            grdKala.DataSource = ObjAnbar.SelectKalaGroupKala().Tables[0];

            ObjAnbar.strC_Anbar = "";
            txtA_Zanbar.AutoCompleteDataSource = ObjAnbar.SelectZAnbar().Tables[0];
            //txtA_Zanbar.AutoCompleteValueMember = "cd_zanbar";
            //txtA_Zanbar.AutoCompleteDisplayMember = "n_zanbar";
            txtA_Zanbar.AutoCompleteValueMember = "n_zanbar";
            txtA_Zanbar.AutoCompleteDisplayMember = "cd_zanbar";

            ObjAnbar.strNkala = "";
            ObjAnbar.strC_Anbar = "";
            ObjAnbar.strC_ZAnbar = "";
            ObjAnbar.strC_Kala = "";
            txtA_Kala.AutoCompleteDataSource = ObjAnbar.SelectKala().Tables[0];
            //txtA_Kala.AutoCompleteValueMember = "C_Kala";
            //txtA_Kala.AutoCompleteDisplayMember = "N_Kala";
            txtA_Kala.AutoCompleteValueMember = "N_Kala";
            txtA_Kala.AutoCompleteDisplayMember = "C_Kala";

            ObjAnbar.strNameGroupKala = "";
            txtA_nGroup.AutoCompleteDataSource = ObjAnbar.SelectGroupKala().Tables[0];
            txtA_nGroup.AutoCompleteValueMember = "IdGroupKala";
            txtA_nGroup.AutoCompleteDisplayMember = "NameGroupKala";
        }

        private void txtA_Kala_Enter(object sender, EventArgs e)
        {
            //if (txtA_Zanbar.Items.Count > 0)
            //{
            //    ObjAnbar.strNkala = "";
            //    ObjAnbar.strC_Anbar = txt_anbar.Text;
            //    //ObjAnbar.strC_ZAnbar = txtA_Zanbar.Items[0].Value.ToString();
            //    ObjAnbar.strC_ZAnbar = txtA_Zanbar.Items[0].Text;
            //    txtA_Kala.AutoCompleteDataSource = ObjAnbar.SelectKala().Tables[0];
            //    txtA_Kala.AutoCompleteValueMember = "N_Kala";
            //    txtA_Kala.AutoCompleteDisplayMember = "C_Kala";
            //}
            //else
            //    MessageBox.Show("انبار و زیر انبار را انتخاب کنید");
        }

        private void btn_add_sparepart_Click(object sender, EventArgs e)
        {
            ObjAnbar.strC_Anbar = txt_anbar.Text;
            //ObjAnbar.strC_Kala = txtA_Kala.Items[0].Value.ToString();
            ObjAnbar.strC_Kala = txtA_Kala.Items[0].Text;
            ObjAnbar.strIdGroupKala = txtA_nGroup.Items[0].Value.ToString();
            //ObjAnbar.strIdGroupKala = txtA_nGroup.Items[0].Text;
            MessageBox.Show(ObjAnbar.InsertKalaGroupKala());

            ObjAnbar.strNkala = "";
            ObjAnbar.strC_Anbar = "";
            grdKala.DataSource = ObjAnbar.SelectKalaGroupKala().Tables[0];
        }

        private void btn_edit_sparepart_Click(object sender, EventArgs e)
        {
            ObjAnbar.strC_Anbar = txt_anbar.Text;
            //ObjAnbar.strC_Kala = txtA_Kala.Items[0].Value.ToString();
            ObjAnbar.strC_Kala = txtA_Kala.Items[0].Text;
            ObjAnbar.strIdGroupKala = txtA_nGroup.Items[0].Value.ToString();
            //ObjAnbar.strIdGroupKala = txtA_nGroup.Items[0].Text;
            MessageBox.Show(ObjAnbar.UpdateKalaGroupKala());

            ObjAnbar.strNkala = "";
            ObjAnbar.strC_Anbar = "";
            grdKala.DataSource = ObjAnbar.SelectKalaGroupKala().Tables[0];

            txt_anbar.Enabled = true;
            txtA_Kala.Enabled = true;
            txtA_Zanbar.Enabled = true;
        }

        private void MasterTemplate_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                txtA_Zanbar.Text = grdKala.Rows[e.RowIndex].Cells["cd_zanbar"].Value.ToString() + ";";
                //lblN_Zanbar = grdKala.Rows[e.RowIndex].Cells["N_anbar"].Value.ToString() + ";";
                txtA_Kala.Text = grdKala.Rows[e.RowIndex].Cells["cKala"].Value.ToString() + ";";
                txt_anbar.Text = grdKala.Rows[e.RowIndex].Cells["cAnbar"].Value.ToString();
                txtA_nGroup.Text = grdKala.Rows[e.RowIndex].Cells["NameGroupKala"].Value.ToString() + ";";

                txt_anbar.Enabled = false;
                txtA_Kala.Enabled = false;
                txtA_Zanbar.Enabled = false;
            }
            catch
            {}
        }

        private void btn_del_sparepart_Click(object sender, EventArgs e)
        {
            ObjAnbar.strC_Anbar = txt_anbar.Text;
            //ObjAnbar.strC_Kala = txtA_Kala.Items[0].Value.ToString();
            ObjAnbar.strC_Kala = txtA_Kala.Items[0].Text;
            MessageBox.Show(ObjAnbar.DeleteKalaGroupKala());

            ObjAnbar.strNkala = "";
            ObjAnbar.strC_Anbar = "";
            grdKala.DataSource = ObjAnbar.SelectKalaGroupKala().Tables[0];

            txt_anbar.Enabled = true;
            txtA_Kala.Enabled = true;
            txtA_Zanbar.Enabled = true;
        }

        private void txtA_Zanbar_Enter(object sender, EventArgs e)
        {
            if (txt_anbar.Text != "")
            {
                ObjAnbar.strNkala = "";
                ObjAnbar.strC_ZAnbar = "";
                ObjAnbar.strN_ZAnbar = "";
                ObjAnbar.strC_Anbar = txt_anbar.Text;
                txtA_Zanbar.AutoCompleteDataSource = ObjAnbar.SelectZAnbar().Tables[0];
                txtA_Zanbar.AutoCompleteValueMember = "n_zanbar";
                txtA_Zanbar.AutoCompleteDisplayMember = "cd_zanbar";
            }
            else
                MessageBox.Show("زیر انبار را انتخاب کنید");
        }

        private void txtA_Kala_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2)
                {
                    FrmKala frm = new FrmKala();
                    frm.strC_Anbar = txt_anbar.Text;
                    frm.strC_zAnbar = txtA_Zanbar.Items[0].Text;
                    frm.ShowDialog();
                    txtA_Kala.Text = ClsBuy.C_kala + ";";
                }
            }
            catch { }
        }

        private void txtA_Zanbar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2)
                {
                    FrmZAnbar frm = new FrmZAnbar();
                    frm.strC_Anbar = txt_anbar.Text;
                    frm.ShowDialog();
                    txtA_Zanbar.Text = ClsAnbar.C_ZAnbar + ";";
                }
            }
            catch { }
        }

        private void txt_anbar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtA_Zanbar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblN_Zanbar.Text = txtA_Zanbar.Items[0].Value.ToString();
            }
            catch
            { }
        }

        private void txtA_Kala_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblN_Kala.Text = txtA_Kala.Items[0].Value.ToString();
            }
            catch
            { }
        }
    }
}

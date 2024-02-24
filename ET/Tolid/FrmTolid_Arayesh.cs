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
    public partial class FrmTolid_Arayesh : Telerik.WinControls.UI.RadForm
    {
        public FrmTolid_Arayesh()
        {
            InitializeComponent();
        }
        ClsTolid objtolid = new ClsTolid();
        public string IdTafsili, IdTafsili2, IdBazras;
        private void FrmTolid_Arayesh_Load(object sender, EventArgs e)
        {
            NewKala();
            NewA();          
        }    
        DataTable dtKala = new DataTable();
        private void txtCkala_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmKala frm = new FrmKala();
                frm.ShowDialog();
                txtCkala.Text = ClsBuy.C_kala;
                lblNkala.Text = ClsBuy.N_kala;
                txtShenase.Text = ClsBuy.N_kala;
            }
        }

        private void txtA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmKala frm = new FrmKala();
                frm.strC_Anbar = "16";
                frm.ShowDialog();
                txtA.Text = ClsBuy.C_kala;
                lblNameKit.Text = ClsBuy.N_kala;
            }

        }

        private void txtA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9' ? e.KeyChar != '\b' : false))
            {
                e.Handled = true;
               // e.KeyChar = '\0';
            }
        }

        private void btnAddA_Click(object sender, EventArgs e)
        {
            if(txtTafsili.Text=="" | txtBazras.Text=="")
            {
                MessageBox.Show("نام منطقه و نام بازرس را وارد کنید");
                return;
            }
            objtolid.StrCodeKala = txtA.Text;
            objtolid.strIdMantaghe = IdTafsili;
            objtolid.strIdBazras = IdBazras;
            objtolid.boolEarth = chkEarth.Checked;
            RadMessageBox.Show(objtolid.INSArayesh());
            NewA();
        }
        public string IdArayesh;
        private void btnEditA_Click(object sender, EventArgs e)
        {
            objtolid.StrCodeKala = txtA.Text;
            objtolid.StrIdArayesh = IdArayesh;
            objtolid.strIdMantaghe = IdTafsili;
            objtolid.strIdBazras = IdBazras;
            objtolid.strIdTafsili2 = IdTafsili2;
            objtolid.boolEarth = chkEarth.Checked;
            RadMessageBox.Show(objtolid.UpdateArayesh());
            objtolid.StrIdArayesh = "";
            NewA();
        }

        private void btnDelA_Click(object sender, EventArgs e)
        {
            if (grdKala.RowCount == 0)
            {
                objtolid.StrIdArayesh = IdArayesh;
                RadMessageBox.Show(objtolid.DelArayesh());
                NewA();
            }
            else RadMessageBox.Show("لطفا ابتدا کالا ها را حذف کنید");
        }

        private void btnNewA_Click(object sender, EventArgs e)
        {
            objtolid.StrIdArayesh = "";
            NewA();
        }
 
        private void NewA()
        {
            ClsTolid objtolid = new ClsTolid();
            btnAddA.Enabled = true;
            btnEditA.Enabled = false;
            btnDelA.Enabled = false;  
            IdArayesh = null;
            txtA.Text = null;
            lblNameKit.Text = "_";
            grdA.DataSource = objtolid.Select_ArayeshKit().Tables[0];
        }
        private void NewKala()
        {
            txtCkala.Text = "";
            txtShenase.Text = "";
            txtCountInKit.Text = "";
            chkHack.Checked = false;
    
            objtolid.StrIdArayesh = IdArayesh;
            grdKala.DataSource = objtolid.SelectKalaArayeshKit().Tables[0];
        }

        private void grdA_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            IdArayesh = grdA.CurrentRow.Cells["IdArayesh"].Value.ToString();
            txtA.Text = grdA.CurrentRow.Cells["CodeKit"].Value.ToString();
            lblNameKit.Text = grdA.CurrentRow.Cells["N_Kala"].Value.ToString();
            IdTafsili = grdA.CurrentRow.Cells["TafsiliAnbar"].Value.ToString();
            txtTafsili.Text = grdA.CurrentRow.Cells["Mantaghe"].Value.ToString();
            IdBazras = grdA.CurrentRow.Cells["TafsiliBazras"].Value.ToString();
            txtBazras.Text = grdA.CurrentRow.Cells["bazras"].Value.ToString();
            txtTafsili2.Text = grdA.CurrentRow.Cells["Ntafsili2"].Value.ToString();
            IdTafsili2 = grdA.CurrentRow.Cells["Tafsili2"].Value.ToString();
            //txtTafsili.Text = "";
            //IdTafsili = "";
            //txtBazras.Text = "";
            //IdBazras = "";
            btnAddA.Enabled = false;
            btnEditA.Enabled = true;
            btnDelA.Enabled = true;
            NewKala();
        }

        private void btnAddKala_Click(object sender, EventArgs e)
        {
            if (txtShenase.Text == "")
            {
                MessageBox.Show("نام تجاری را وارد کنید");
                return;
            }
            objtolid.StrCodeKala = txtCkala.Text;
            objtolid.strCountInKit = txtCountInKit.Text;
            objtolid.strHack = chkHack.Checked;
            objtolid.boolOutKit = chkOut.Checked;
            objtolid.strShenaseMoshtari = txtShenase.Text;
            objtolid.StrIdArayesh = grdA.CurrentRow.Cells["IdArayesh"].Value.ToString();
            RadMessageBox.Show(objtolid.INSKalaArayesh());
            NewKala();

        }

        private void btnDelKala_Click(object sender, EventArgs e)
        {
            objtolid.StrCodeKala = grdKala.CurrentRow.Cells["cKala"].Value.ToString();
            objtolid.StrIdArayesh = grdKala.CurrentRow.Cells["IdArayesh"].Value.ToString();
            RadMessageBox.Show(objtolid.DelKalaArayesh());
            NewKala();
        }

        private void grdA_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                grdKala.DataSource = null;
                grdKala.Rows.Clear();
                DataRow[] dr = dtKala.Select("IdArayesh="+grdA.CurrentRow.Cells["IdArayesh"].Value+" ");               
                grdKala.DataSource = dr.CopyToDataTable(); }
            catch { }          
        }

        private void MasterTemplate_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            txtCkala.Text = grdKala.CurrentRow.Cells["cKala"].Value.ToString();
            lblNkala.Text = grdKala.CurrentRow.Cells["N_Kala"].Value.ToString();
            txtCountInKit.Text = grdKala.CurrentRow.Cells["Tedad"].Value.ToString();
            txtShenase.Text = grdKala.CurrentRow.Cells["ShenaseMoshtari"].Value.ToString();
            chkHack.Checked = Convert.ToBoolean(grdKala.CurrentRow.Cells["hack"].Value);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            objtolid.StrCodeKala = txtCkala.Text;
            objtolid.strCountInKit = txtCountInKit.Text;
            objtolid.strHack = chkHack.Checked;
            objtolid.boolOutKit = chkOut.Checked;
            objtolid.strShenaseMoshtari = txtShenase.Text;
            objtolid.StrIdArayesh = grdA.CurrentRow.Cells["IdArayesh"].Value.ToString();
            RadMessageBox.Show(objtolid.UpdateKalaArayesh());
            NewKala();
        }

        private void txtTafsili_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmTafsili frm = new FrmTafsili();
                frm.ShowDialog();
                txtTafsili.Text = ClsBuy.tafsili_Name;
                IdTafsili = ClsBuy.tafsili_Id;
            }
        }

        private void txtBazras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmTafsili frm = new FrmTafsili();
                frm.ShowDialog();
                txtBazras.Text = ClsBuy.tafsili_Name;
                IdBazras = ClsBuy.tafsili_Id;
            }
        }

        private void txtTafsili2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmTafsili2 frm = new FrmTafsili2();
                frm.ShowDialog();
                txtTafsili2.Text = frm.strNtafsili2;
                IdTafsili2 = frm.strCtafsili2;
            }
        }
       

    }
}
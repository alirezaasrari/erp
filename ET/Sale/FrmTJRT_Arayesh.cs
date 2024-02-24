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
    public partial class FrmTJRT_Arayesh : Telerik.WinControls.UI.RadForm
    {
        public FrmTJRT_Arayesh()
        {
            InitializeComponent();
        }
        ClsTolid objtolid = new ClsTolid();
        public string IdTafsili, IdTafsili2, IdBazras, strRow;
        private void FrmTolid_Arayesh_Load(object sender, EventArgs e)
        {
            NewKala();
            NewA();          
        }    
        DataTable dtKala = new DataTable();

        private void txtA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmKala frm = new FrmKala();
                //frm.strC_Anbar = "16";
                frm.ShowDialog();
                txtCkalaH.Text = ClsBuy.C_kala;
                lblNameKala.Text = ClsBuy.N_kala;
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
            objtolid.StrCodeKala = txtCkalaH.Text;
            objtolid.StrNameKala = lblNameKala.Text;
            RadMessageBox.Show(objtolid.INSArayeshTJRT());
            NewA();
        }

        private void btnDelA_Click(object sender, EventArgs e)
        {
            if (grdKala.RowCount == 0)
            {
                objtolid.StrCodeKala = txtCkalaH.Text;
                RadMessageBox.Show(objtolid.DelTJRTkala());
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
            btnDelA.Enabled = false;  
            txtCkalaH.Text = null;
            lblNameKala.Text = "_";
            grdA.DataSource = objtolid.Select_TJRTKalaH().Tables[0];
        }
        private void NewKala()
        {
            txtCkalaD.Text = "";
            txtNKalaD.Text = "";
            txtMeghdar.Text = "";
            objtolid.StrCodeKala = txtCkalaH.Text;
            grdKala.DataSource = objtolid.Select_TJRTKalaD().Tables[0];
        }

        private void grdA_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            txtCkalaH.Text = grdA.CurrentRow.Cells["CkalaH"].Value.ToString();
            lblNameKala.Text = grdA.CurrentRow.Cells["NameKala"].Value.ToString();
            btnAddA.Enabled = false;
            btnDelA.Enabled = true;
            NewKala();
        }

        private void btnAddKala_Click(object sender, EventArgs e)
        {
            objtolid.StrCodeKala = txtCkalaH.Text;
            objtolid.StrCodeKalaD = txtCkalaD.Text;
            objtolid.StrNameKalaD = txtNKalaD.Text;
            objtolid.StrMeghdar = txtMeghdar.Text;
            objtolid.StrVahed = txtVahed.Text;
            RadMessageBox.Show(objtolid.INSArayeshDTJRT());
            NewKala();

        }

        private void btnDelKala_Click(object sender, EventArgs e)
        {
            objtolid.strRow = grdKala.CurrentRow.Cells["IdRow"].Value.ToString();
            RadMessageBox.Show(objtolid.DelTJRTkalaD());
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            objtolid.StrCodeKala = txtCkalaH.Text;
            objtolid.StrCodeKalaD = txtCkalaD.Text;
            objtolid.StrNameKalaD = txtNKalaD.Text;
            objtolid.StrMeghdar = txtMeghdar.Text;
            objtolid.StrVahed = txtVahed.Text;
            objtolid.strRow = strRow;
            RadMessageBox.Show(objtolid.UpdateKalaArayeshTJRT());
            NewKala();
        }

        private void grdKala_CellDoubleClick_1(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            txtCkalaD.Text = grdKala.CurrentRow.Cells["CkalaD"].Value.ToString();
            txtNKalaD.Text = grdKala.CurrentRow.Cells["NameKalaD"].Value.ToString();
            txtMeghdar.Text = grdKala.CurrentRow.Cells["Meghdar"].Value.ToString();
            txtVahed.Text = grdKala.CurrentRow.Cells["Vahed"].Value.ToString();
            strRow = grdKala.CurrentRow.Cells["IdRow"].Value.ToString();
        }
    }
}
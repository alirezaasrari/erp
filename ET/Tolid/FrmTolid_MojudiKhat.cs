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
    public partial class FrmTolid_MojudiKhat : Telerik.WinControls.UI.RadForm
    {
        public FrmTolid_MojudiKhat()
        {
            InitializeComponent();
        }
        //public string strIdGhete;
        private void FrmTolid_MojudiKhat_Load(object sender, EventArgs e)
        {
            dtpDateMojoodi.Value = DateTime.Now;
            ClsMali obj = new ClsMali();
            cmbUnit.DataSource = obj.SelectUnit().Tables[0];
            cmbUnit.ValueMember = "IdUnit";
            cmbUnit.DisplayMember = "onvan";
        }

        private void btnF2Kala_Click(object sender, EventArgs e)
        {
            FrmTakvin_GhetehSearch frm = new FrmTakvin_GhetehSearch();
            frm.strPlanning = "2";
            frm.strIdUnit = cmbUnit.SelectedValue.ToString();
            frm.ShowDialog();
            if (ClsPublic.C_kala == null)
                return;
            txtNKala.Text = ClsPublic.N_kala;
            lblCKala.Text = ClsPublic.C_kala;
            //strIdGhete = ClsPublic.id_Gheteh;
        }

        private void btnAddMojoodiKhat_Click(object sender, EventArgs e)
        {
            ClsTolid objTolid = new ClsTolid();
            //objTolid.strIdGheteh = strIdGhete;
            objTolid.StrCodeKala = lblCKala.Text;
            objTolid.strTedadKhat = txtMojudiKhat.Text;
            objTolid.strDateMojoodi = dtpDateMojoodi.Text;
            objTolid.strIdUnit = cmbUnit.SelectedValue.ToString();
            MessageBox.Show(objTolid.INS_MojudiKhat());

            grdMojudiKhat.DataSource = objTolid.Select_MojudiKhat().Tables[0];
        }

        private void grdMojudiKhat_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            txtNKala.Text = grdMojudiKhat.Rows[e.RowIndex].Cells["GheteName"].Value.ToString();
            lblCKala.Text = grdMojudiKhat.Rows[e.RowIndex].Cells["GhetehCode"].Value.ToString();
            txtMojudiKhat.Text = grdMojudiKhat.Rows[e.RowIndex].Cells["tedadKhat"].Value.ToString();
            //strIdGhete = grdMojudiKhat.Rows[e.RowIndex].Cells["FK_id_Gheteh"].Value.ToString();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ClsTolid objTolid = new ClsTolid();
            objTolid.strIdUnit = cmbUnit.SelectedValue.ToString();
            grdMojudiKhat.DataSource = objTolid.Select_MojudiKhat().Tables[0];
        }
    }
}

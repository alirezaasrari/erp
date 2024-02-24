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
    public partial class FrmPLN_Zakhire : Telerik.WinControls.UI.RadForm
    {
        public FrmPLN_Zakhire()
        {
            InitializeComponent();
        }
        //public string strCkala, strCabnar, strzakhire;
        private void FrmPLN_Zakhire_Load(object sender, EventArgs e)
        {
            ClsPlanning objPlanning = new ClsPlanning();
            grdZakhire.DataSource = objPlanning.Select_ZakhireGhete().Tables[0];
        }

        private void MasterTemplate_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            txtNKala.Text = grdZakhire.Rows[e.RowIndex].Cells["N_Kala"].Value.ToString();
            lblCKala.Text = grdZakhire.Rows[e.RowIndex].Cells["C_Kala"].Value.ToString();
            lblCAnbar.Text = grdZakhire.Rows[e.RowIndex].Cells["C_anbar"].Value.ToString();
            txtZakhire.Text = grdZakhire.Rows[e.RowIndex].Cells["ZakhireAnbar"].Value.ToString();
        }

        private void btnAddZakhire_Click(object sender, EventArgs e)
        {
            ClsPlanning objPlanning = new ClsPlanning();
            objPlanning.strCkala = lblCKala.Text;
            objPlanning.strCabnar = lblCAnbar.Text;
            objPlanning.strzakhire = txtZakhire.Text;
            MessageBox.Show(objPlanning.Insert_ZakhireGhete());

            grdZakhire.DataSource = objPlanning.Select_ZakhireGhete().Tables[0];
        }

        private void btnF2Kala_Click(object sender, EventArgs e)
        {
            FrmKala frm = new FrmKala();
            //frm.strC_Anbar = "13,14,19,16";
            frm.ShowDialog();
            txtNKala.Text = ClsBuy.N_kala;
            lblCKala.Text = ClsBuy.C_kala;
            lblCAnbar.Text = ClsPublic.C_Anbar;
        }
    }
}

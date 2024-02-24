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
    public partial class FrmPM_Personel : Telerik.WinControls.UI.RadForm
    {
        public FrmPM_Personel()
        {
            InitializeComponent();
        }
        string strIdPersonel, strIdEmpRow;
        private void FrmPM_Personel_Load(object sender, EventArgs e)
        {
            ClsPM obj = new ClsPM();
            cmbMasolejra.DataSource = obj.selectMasolejra().Tables[0];
            cmbMasolejra.ValueMember = "IDMasolejra";
            cmbMasolejra.DisplayMember = "Description";

            cmbSemat.DataSource = obj.selectSemat().Tables[0];
            cmbSemat.ValueMember = "IdSemat";
            cmbSemat.DisplayMember = "NameSemat";

            grd.DataSource = obj.SelectPersonel().Tables[0];
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            ClsPM obj = new ClsPM();
            obj.IdEmp = strIdPersonel;
            obj.IDMasolejra = cmbMasolejra.SelectedValue.ToString();
            obj.IdSemat = cmbSemat.SelectedValue.ToString();
            MessageBox.Show(obj.InsPersonel());
            grd.DataSource = obj.SelectPersonel().Tables[0];
        }

        private void grd_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "btnSelect")
            {
                ClsPM obj = new ClsPM();
                strIdEmpRow = grd.CurrentRow.Cells["IdEmpRow"].Value.ToString();
                strIdPersonel = grd.CurrentRow.Cells["IdEmp"].Value.ToString();
                txtIdEmp.Text = grd.CurrentRow.Cells["NAME"].Value.ToString();
                cmbMasolejra.Text = grd.CurrentRow.Cells["Description"].Value.ToString();
                cmbSemat.Text = grd.CurrentRow.Cells["NameSemat"].Value.ToString();
            }
            if (e.Column.Name == "btnDelete")
            {
                ClsPM obj = new ClsPM();
                obj.IdEmpRow = grd.CurrentRow.Cells["IdEmpRow"].Value.ToString();
                MessageBox.Show(obj.DelEmpPersonel());
                grd.DataSource = obj.SelectPersonel().Tables[0];
            }
        }

        private void btnSerachBarge_Click(object sender, EventArgs e)
        {
            FrmEdari_ListPersonel frm = new FrmEdari_ListPersonel();
            frm.ShowDialog();
            strIdPersonel = frm.strC_personel;
            txtIdEmp.Text = frm.strN_personel;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ClsPM obj = new ClsPM();
            obj.IdEmp = strIdPersonel;
            obj.IDMasolejra = cmbMasolejra.SelectedValue.ToString();
            obj.IdSemat = cmbSemat.SelectedValue.ToString();
            obj.IdEmpRow = strIdEmpRow;
            MessageBox.Show(obj.updatePersonelPM());
            grd.DataSource = obj.SelectPersonel().Tables[0];
        }
    }
}

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
    public partial class FrmPM_Peymankar : Telerik.WinControls.UI.RadForm
    {
        public FrmPM_Peymankar()
        {
            InitializeComponent();
        }
        public string strIdPeymankar;
        private void FrmPM_Peymankar_Load(object sender, EventArgs e)
        {
            ClsPM obj = new ClsPM();
            cmbclass1.DataSource = obj.Selectclassmachin().Tables[0];
            cmbclass1.ValueMember = "ID_class";
            cmbclass1.DisplayMember = "N_class";

            cmbHoze.DataSource = obj.SelectHoze().Tables[0];
            cmbHoze.ValueMember = "IdHoze";
            cmbHoze.DisplayMember = "NameHoze";

            grd.DataSource = obj.SelectPeymankar().Tables[0];
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            ClsPM obj = new ClsPM();
            obj.NamePeymankar = txtNamePeymankar.Text;
            obj.Namayande = txtNamayande.Text;
            obj.CityName = txtCityName.Text;
            obj.Tell = txtTell.Text;
            obj.Mobile = txtMobile.Text;
            obj.AddressPeymankar = txtAddressPeymankar.Text;
            obj.Id_class1 = cmbclass1.SelectedValue.ToString();
            obj.Tozihat = txtTozihat.Text;
            obj.IdHoze = cmbHoze.SelectedValue.ToString();

            MessageBox.Show(obj.InsPeymankar());
            grd.DataSource = obj.SelectPeymankar().Tables[0];
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ClsPM obj = new ClsPM();
            obj.IdPeymankar = strIdPeymankar;
            obj.NamePeymankar = txtNamePeymankar.Text;
            obj.Namayande = txtNamayande.Text;
            obj.CityName = txtCityName.Text;
            obj.Tell = txtTell.Text;
            obj.Mobile = txtMobile.Text;
            obj.AddressPeymankar = txtAddressPeymankar.Text;
            obj.Id_class1 = cmbclass1.SelectedValue.ToString();
            obj.Tozihat = txtTozihat.Text;
            obj.IdHoze = cmbHoze.SelectedValue.ToString();

            MessageBox.Show(obj.updatePeymankar());
            grd.DataSource = obj.SelectPeymankar().Tables[0];
        }

        private void grd_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "btnSelect")
            {
                ClsPM obj = new ClsPM();
                strIdPeymankar = grd.CurrentRow.Cells["IdPeymankar"].Value.ToString();
                txtNamePeymankar.Text = grd.CurrentRow.Cells["NamePeymankar"].Value.ToString();
                txtNamayande.Text = grd.CurrentRow.Cells["Namayande"].Value.ToString();
                txtCityName.Text = grd.CurrentRow.Cells["CityName"].Value.ToString();
                txtTell.Text = grd.CurrentRow.Cells["Tell"].Value.ToString();
                txtMobile.Text = grd.CurrentRow.Cells["Mobile"].Value.ToString();
                txtAddressPeymankar.Text = grd.CurrentRow.Cells["AddressPeymankar"].Value.ToString();
                cmbclass1.Text = grd.CurrentRow.Cells["N_class"].Value.ToString();
                txtTozihat.Text = grd.CurrentRow.Cells["Tozihat"].Value.ToString();
                cmbHoze.Text = grd.CurrentRow.Cells["NameHoze"].Value.ToString();
            }
            if (e.Column.Name == "btnDelete")
            {
                ClsPM obj = new ClsPM();
                obj.IdPeymankar = grd.CurrentRow.Cells["IdPeymankar"].Value.ToString();
                MessageBox.Show(obj.DelEmpPeymankar());
                grd.DataSource = obj.SelectPeymankar().Tables[0];
            }
        }
    }
}

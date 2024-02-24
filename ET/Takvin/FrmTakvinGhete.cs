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
    public partial class FrmTakvinGhete : Telerik.WinControls.UI.RadForm
    {
        public FrmTakvinGhete()
        {
            InitializeComponent();
        }

        private void FrmTakvinGhete_Load(object sender, EventArgs e)
        {
            ClsTakvin obj = new ClsTakvin();
            Grd.DataSource = obj.searchGhetehAll().Tables[0];
        }

        private void Grd_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "btnEdit")
                {
                    ClsTakvin obj = new ClsTakvin();
                    obj.strZaman_standard = Grd.CurrentRow.Cells["Zaman_standard"].Value.ToString();
                    obj.strNafar_tedad = Grd.CurrentRow.Cells["nafar_tedad"].Value.ToString();
                    obj.strHofre_tedad = Grd.CurrentRow.Cells["hofre_tedad"].Value.ToString();

                    MessageBox.Show(obj.UpdGhetehAll(Grd.CurrentRow.Cells["id_Gheteh"].Value.ToString()));
                }
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }
    }
}

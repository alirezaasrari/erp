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
    public partial class FrmEdari_AddPersonelPemankar : Telerik.WinControls.UI.RadForm
    {
        public FrmEdari_AddPersonelPemankar()
        {
            InitializeComponent();
        }

        private void grdPersonel_UserAddingRow(object sender, Telerik.WinControls.UI.GridViewRowCancelEventArgs e)
        {
            try
            {
                ClsEdari objEdari = new ClsEdari();
                if (grdPersonel.CurrentRow.Cells["typeP"].Value != null)
                    if (grdPersonel.CurrentRow.Cells["typeP"].Value.ToString() == "True")
                        objEdari.strTypeP = "1";
                    else
                        objEdari.strTypeP = "0";
                else
                    objEdari.strTypeP = "0";
                objEdari.strN_personel = grdPersonel.CurrentRow.Cells["N_oper"].Value.ToString();

                MessageBox.Show(objEdari.Insert_PersonelPeymankar());

                grdPersonel.Rows.AddNew();
                ClsEdari objEdariShow = new ClsEdari();
                grdPersonel.DataSource = objEdariShow.Select_PersonelPeymankar().Tables[0];
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        private void FrmEdari_AddPersonelPemankar_Load(object sender, EventArgs e)
        {
            ClsEdari objEdariShow = new ClsEdari();
            grdPersonel.DataSource = objEdariShow.Select_PersonelPeymankar().Tables[0];
        }

        private void grdPersonel_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "btnDelete")
                {
                    if (MessageBox.Show("آیا از حذف سطر اطمینان دارید؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ClsEdari objEdari = new ClsEdari();
                        objEdari.strC_personel = grdPersonel.CurrentRow.Cells["IdPersonel"].Value.ToString();
                        MessageBox.Show(objEdari.Delete_PersonelPeymankar());
                        //grdPersonel.DataSource = objEdari.Select_PersonelPeymankar().Tables[0];

                        ClsEdari objEdariShow = new ClsEdari();
                        grdPersonel.DataSource = objEdariShow.Select_PersonelPeymankar().Tables[0];
                    }
                }
            }
            catch
            {

            }
        }
    }
}

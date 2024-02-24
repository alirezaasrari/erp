using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ET
{
    public partial class Frm_Tafsili_Etebar : Telerik.WinControls.UI.RadForm
    {
        public static string CTafsili,NTafsili;
        public string fm;
        ClsBI BI = new ClsBI();
        DataSet ds = new DataSet();

        public Frm_Tafsili_Etebar()
        {
            InitializeComponent();
        }

        private void Frm_Tafsili_Load(object sender, EventArgs e)
        {
            ClsMali obj = new ClsMali();
            cmbTafsili.DataSource = obj.SelectTafsili().Tables[0];
            cmbTafsili.ValueMember = "Ctafsili";
            cmbTafsili.DisplayMember = "Ntafsili";
            
            grd.DataSource = obj.SelectTafsiliEtebar().Tables[0];
        }

        private void grd_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {

                ClsMali obj = new ClsMali();
                obj.strIdTafsili = grd.CurrentRow.Cells["IdTafsili"].Value.ToString();

                if (e.Column.Name == "btnEdit")
                {
                    if (MessageBox.Show("آیا از ویرایش اطلاعات اطمینان دارید؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        obj.strEtebar = grd.CurrentRow.Cells["Etebar"].Value.ToString();
                        MessageBox.Show(obj.Update_TafsiliEtebar());
                        grd.DataSource = obj.SelectTafsiliEtebar().Tables[0];
                    }
                }
                if (e.Column.Name == "btnDelete")
                {
                    if (MessageBox.Show("آیا از حذف اطلاعات اطمینان دارید؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        MessageBox.Show(obj.Delete_TafsiliEtebar());
                        grd.DataSource = obj.SelectTafsiliEtebar().Tables[0];
                    }
                }              
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ClsMali obj = new ClsMali();
                obj.strIdTafsili = cmbTafsili.SelectedValue.ToString();
                obj.strEtebar = txtEtebar.Text;
                MessageBox.Show(obj.InsTafsiliEtebar());
                grd.DataSource = obj.SelectTafsiliEtebar().Tables[0];
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }
    }
}

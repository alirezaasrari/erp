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
    public partial class FrmTaminSanadList : Telerik.WinControls.UI.RadForm
    {
        public FrmTaminSanadList()
        {
            InitializeComponent();
        }

        private void grd_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if(e.Column.Name=="btnEdit")
                {
                    ClsTamin objTamin = new ClsTamin();
                    objTamin.strIdSanad = grd.CurrentRow.Cells["num_sanad"].Value.ToString();
                    objTamin.strTafsiliAnbar = grd.CurrentRow.Cells["tafsili"].Value.ToString();
                    objTamin.strTafsiliBank = grd.CurrentRow.Cells["h_tafsili"].Value.ToString();
                    objTamin.strTozihat = grd.CurrentRow.Cells["Tozihat"].Value.ToString();
                    if (grd.CurrentRow.Cells["ReturnVariz"].Value.ToString() != "")
                        objTamin.strReturnVariz = Convert.ToInt16(grd.CurrentRow.Cells["ReturnVariz"].Value).ToString();
                    else
                        objTamin.strReturnVariz = "0";
                    MessageBox.Show(objTamin.Update_SanadList());
                }
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        private void FrmTaminSanadList_Load(object sender, EventArgs e)
        {
            ClsTamin objTamin = new ClsTamin();

            using (new PleaseWait(this.Location))
            {
                cmbMantaghe.DataSource = objTamin.Select_Mantaghe().Tables[0];
                cmbMantaghe.DisplayMember = "NameMantaghe";
                cmbMantaghe.ValueMember = "tafsili";

                objTamin.Insert_TaminBank2SanadList();

                objTamin.strSanaNo = "1";
                grd.DataSource = objTamin.Select_SanadListShow().Tables[0];
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            using (new PleaseWait(this.Location))
            {
                ClsTamin objTamin = new ClsTamin();
                objTamin.strTafsiliAnbar = cmbMantaghe.SelectedValue.ToString();
                objTamin.Update_SanadListSend();

                objTamin.strSanaNo = "1";
                grd.DataSource = objTamin.Select_SanadListShow().Tables[0];
            }
            MessageBox.Show("انتقال اطلاعات با موفقیت ثبت شد");
        }

        private void chkShowAll_CheckStateChanged(object sender, EventArgs e)
        {
            ClsTamin objTamin = new ClsTamin();
            if (chkShowAll.Checked == false)
                objTamin.strSanaNo = "1";

            grd.DataSource = objTamin.Select_SanadListShow().Tables[0];
        }
    }
}

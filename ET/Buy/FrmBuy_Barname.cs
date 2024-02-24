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
    public partial class FrmBuy_Barname : Telerik.WinControls.UI.RadForm
    {
        public ClsBuy clsBuyObj = new ClsBuy();
        public DataSet ds = new DataSet();
        public DataSet ds2 = new DataSet();
        public string strBarnameId;
        public FrmBuy_Barname()
        {
            InitializeComponent();
        }        

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkDelete.Checked == true)
                {
                    if (MessageBox.Show("آیا از حذف این ردیف درخواست از لیست کار اطمینان دارید؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        clsBuyObj.Barname_ID = strBarnameId;
                        clsBuyObj.Tahvil_No = "";
                        if (clsBuyObj.selectPart().Tables[0].Rows.Count > 0)
                        {
                            //if (MessageBox.Show("آیا این درخواست به مسئول دیگری انتقال یابد؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            //{
                            //    clsBuyObj.strC_Personel = txtMasool2.Items[0].Value.ToString();
                            //    clsBuyObj.strActive = "";
                            //    clsBuyObj.strDone = "";
                            //    MessageBox.Show(clsBuyObj.UpdateBarname());
                            //}
                            MessageBox.Show("برای این درخواست پارت خرید ثبت شده است");
                            return;
                        }

                        clsBuyObj.strSho_Darkhast = txtIdDarkhast2.Text;
                        clsBuyObj.strDarkhastRadif = txtRadifDarkhast2.Text;

                        //MessageBox.Show(clsBuyObj.DelBarname());
                        clsBuyObj.strC_Personel = "0";
                        clsBuyObj.intSabtD = 0;
                        clsBuyObj.strDateSabt = "";
                        MessageBox.Show(clsBuyObj.UpdateBarname());
                    }
                }
                else
                {
                    if (MessageBox.Show("آیا از اعمال تغییرات اطمینان دارید؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        clsBuyObj.strC_Personel = txtMasool2.Items[0].Value.ToString();
                        clsBuyObj.strActive = "";
                        clsBuyObj.strDone = "";

                        clsBuyObj.Barname_ID = strBarnameId;
                        if (chkTaligh.Checked == true)
                            clsBuyObj.strActive = "1";
                        else
                            clsBuyObj.strActive = "0";
                        clsBuyObj.intSabtD = 1;
                        MessageBox.Show(clsBuyObj.UpdateBarname());
                    }
                }
                clsBuyObj.strC_Personel = "";
                clsBuyObj.strC_kala = "";
                clsBuyObj.strSho_Darkhast = "";
                if (chkActivity.Checked == true)
                    clsBuyObj.strActive = "0";
                else
                    clsBuyObj.strActive = "1";
                clsBuyObj.intSabt = 1;
                clsBuyObj.intDone = 0;
                grdBarname.DataSource = clsBuyObj.Barname().Tables[0];

                txtIdDarkhast2.Text = "";
                txtRadifDarkhast2.Text = "";
                chkDelete.Checked = false;
                chkTaligh.Checked = false;
            }
            catch
            {
                MessageBox.Show("خطا در اجرا");
            }
        }

        private void chkActivity_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActivity.Checked == true)
                clsBuyObj.strActive = "0";
            else
                clsBuyObj.strActive = "1";

            clsBuyObj.strC_Personel = "";
            clsBuyObj.strSho_Darkhast = "";
            clsBuyObj.strC_kala = "";
            clsBuyObj.intSabt = 1;
            clsBuyObj.intDone = 0;
            grdBarname.DataSource = clsBuyObj.Barname().Tables[0];
        }

        private void grdBarname_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                txtIdDarkhast2.Text = grdBarname.Rows[e.RowIndex].Cells["Sho_Darkhast"].Value.ToString();
                txtRadifDarkhast2.Text = grdBarname.Rows[e.RowIndex].Cells["Radif_Darkhast"].Value.ToString();
                txtMasool2.Text = grdBarname.Rows[e.RowIndex].Cells["Personel_Name"].Value.ToString() + ";";
                strBarnameId = grdBarname.Rows[e.RowIndex].Cells["Barname_ID"].Value.ToString();
                //MessageBox.Show(grdBarname.Rows[e.RowIndex].Cells[15].Value.ToString());
                chkTaligh.Checked = Convert.ToBoolean(grdBarname.Rows[e.RowIndex].Cells["active"].Value.ToString());
            }
            catch { }
        }

        private void FrmBuy_Barname_Load(object sender, EventArgs e)
        {
            //clsBuyObj.insBarnameAnbar14();
            clsBuyObj.DelDeleted();

            if (chkActivity.Checked == true)
                clsBuyObj.strActive = "0";
            else
                clsBuyObj.strActive = "1";

            clsBuyObj.strC_Personel = "";
            clsBuyObj.strSho_Darkhast = "";
            clsBuyObj.intSabt = 1;
            clsBuyObj.intDone = 0;
            grdBarname.DataSource = clsBuyObj.Barname().Tables[0];

            ds = clsBuyObj.SelectPersonelBuy();
            ///////////////////////////////////////////////
            txtMasool2.AutoCompleteDataSource = ds.Tables[0];
            txtMasool2.AutoCompleteValueMember = "Personel_ID";
            txtMasool2.AutoCompleteDisplayMember = "name";

        }
    }
}

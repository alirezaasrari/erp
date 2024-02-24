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
    public partial class FrmBuy_Eslah : Telerik.WinControls.UI.RadForm
    {
        public FrmBuy_Eslah()
        {
            InitializeComponent();
        }
        public ClsBuy clsBuyObj = new ClsBuy();
        public string barnameID, Meghdar_Darkhast, tasir;
        public DataSet ds = new DataSet();
        ClsMain objMain = new ClsMain();
        private void FrmBuy_Eslah_Load(object sender, EventArgs e)
        {
            //سطح دسترسی کنترلها       

            DataTable DtControlAccess = new DataTable();
            DataRow[] dr = ClsMain.DtAccessUser.Select("n_form='" + this.Name + "'");
            if (dr.Length > 0) DtControlAccess = dr.CopyToDataTable();
            if (DtControlAccess.Rows.Count > 0)
            {
                Control ctn;
                for (int i = 0; i < DtControlAccess.Rows.Count; i++)
                {
                    string strControl = DtControlAccess.Rows[i]["n_control"].ToString();
                    ctn = radGroupBox1.Controls[strControl];
                    if (ctn != null)
                    {
                        bool rv, re;
                        if (DtControlAccess.Rows[i]["id_user"].ToString() == ClsMain.IDUser)
                        {
                            rv = Convert.ToBoolean(DtControlAccess.Rows[i]["isActive"].ToString());
                            re = Convert.ToBoolean(DtControlAccess.Rows[i]["isshow"].ToString());
                        }
                        else
                        {
                            rv = false;
                            re = false;
                        }
                        ctn.Enabled = re;
                        ctn.Visible = rv;
                    }
                }
            }
            ////--------------------------

            clsBuyObj.strC_kala = "";
            clsBuyObj.strC_Personel = "";
            clsBuyObj.strSho_Darkhast = "";
            clsBuyObj.strActive = "1";
            clsBuyObj.intSabt = 1;
            clsBuyObj.intDone = 0;
            //grdBarname.DataSource = clsBuyObj.Barname().Tables[0];
            grdBarname.DataSource = clsBuyObj.SelectEslahSum().Tables[0];
            clsBuyObj.strActive = "";
        }

        private void grdBarname_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                barnameID = grdBarname.Rows[e.RowIndex].Cells["Barname_ID"].Value.ToString();
                txtCkalaEslah.Text = grdBarname.Rows[e.RowIndex].Cells["C_kala"].Value.ToString();
                lblNkalaEaslah.Text = grdBarname.Rows[e.RowIndex].Cells["Nkala"].Value.ToString();
                txtDarkhast_No.Text = grdBarname.Rows[e.RowIndex].Cells["Sho_Darkhast"].Value.ToString();
                txtDarkhast_Radif.Text = grdBarname.Rows[e.RowIndex].Cells["Radif_Darkhast"].Value.ToString();
                //clsBuyObj.Barname_ID = grdBarname.Rows[e.RowIndex].Cells["Barname_ID"].Value.ToString();

                clsBuyObj.Barname_ID = barnameID;
                clsBuyObj.Eslah_No = "";
                grdEslah.DataSource = clsBuyObj.SelectEslah().Tables[0];
                txtMeghdar.Enabled = true;
                cmbTasir.Enabled = true;
                btn_edit.Enabled = false;
                btn_del.Enabled = false;
                btn_add.Enabled = true;
            }
            catch { }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (cmbTasir.Text == "")
            {
                MessageBox.Show("نوع تاثیر را انتخاب کنید");
                return;
            }

            clsBuyObj.Barname_ID = barnameID;
            clsBuyObj.Meghdar = txtMeghdar.Text;
            clsBuyObj.strTasir = "False";
            if (chkTaeed.Checked == true)
                clsBuyObj.intTaeed = 1;
            else
                clsBuyObj.intTaeed = 0;

            if (Convert.ToDouble(clsBuyObj.BaghimandeAnbar().Tables[0].Rows[0][0].ToString()) < 0)
            {
                MessageBox.Show("تعداد نا معتبر است");
                return;
            }

            MessageBox.Show(clsBuyObj.insEslah());

            clsBuyObj.Barname_ID = barnameID;
            clsBuyObj.Eslah_No = "";
            grdEslah.DataSource = clsBuyObj.SelectEslah().Tables[0];

            clsBuyObj.Barname_ID = "";
            clsBuyObj.strC_kala = "";
            clsBuyObj.strC_Personel = "";
            clsBuyObj.strSho_Darkhast = "";
            clsBuyObj.strActive = "1";
            clsBuyObj.intSabt = 1;
            clsBuyObj.intDone = 0;
            grdBarname.DataSource = clsBuyObj.SelectEslahSum().Tables[0];
            clsBuyObj.strActive = "";
        }

        private void cmbTasir_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbTasir.SelectedIndex == 0)
            //    tasir = "True";
            //else
            //    tasir = "False";
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            clsBuyObj.Barname_ID = barnameID;
            if (clsBuyObj.SelectEslah().Tables[0].Rows[0]["Taeed"].ToString() == "True")
            {
                MessageBox.Show("این اصلاح تایید شده است");
                return;
            }
            clsBuyObj.Barname_ID = "";
            if (MessageBox.Show("آیا از حذف  این اصلاحیه اطمینان دارید؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show(clsBuyObj.DelEslah());

                clsBuyObj.strC_kala = "";
                clsBuyObj.strC_Personel = "";
                clsBuyObj.strSho_Darkhast = "";
                clsBuyObj.strActive = "1";
                clsBuyObj.intSabt = 1;
                grdBarname.DataSource = clsBuyObj.Barname().Tables[0];
                clsBuyObj.strActive = "";

                clsBuyObj.Barname_ID = barnameID;
                clsBuyObj.Eslah_No = "";
                grdEslah.DataSource = clsBuyObj.SelectEslah().Tables[0];
                txtMeghdar.Enabled = true;
                cmbTasir.Enabled = true;
                btn_edit.Enabled = false;
                btn_del.Enabled = false;
                btn_add.Enabled = true;

                clsBuyObj.Barname_ID = "";
                clsBuyObj.strC_kala = "";
                clsBuyObj.strC_Personel = "";
                clsBuyObj.strSho_Darkhast = "";
                clsBuyObj.strActive = "1";
                clsBuyObj.intSabt = 1;
                clsBuyObj.intDone = 0;
                grdBarname.DataSource = clsBuyObj.SelectEslahSum().Tables[0];
                clsBuyObj.strActive = "";
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            clsBuyObj.Barname_ID = barnameID;
            if (MessageBox.Show("آیا از ویرایش  این اصلاحیه اطمینان دارید؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                clsBuyObj.intTaeed = Convert.ToInt32(chkTaeed.Checked);
                MessageBox.Show(clsBuyObj.UpdateEslah());
                clsBuyObj.Eslah_No = "";
                grdEslah.DataSource = clsBuyObj.SelectEslah().Tables[0];
                txtMeghdar.Enabled = true;
                cmbTasir.Enabled = true;
                btn_edit.Enabled = false;
                btn_del.Enabled = false;
                btn_add.Enabled = true;

                clsBuyObj.Barname_ID = "";
                clsBuyObj.strC_kala = "";
                clsBuyObj.strC_Personel = "";
                clsBuyObj.strSho_Darkhast = "";
                clsBuyObj.strActive = "1";
                clsBuyObj.intSabt = 1;
                clsBuyObj.intDone = 0;
                grdBarname.DataSource = clsBuyObj.SelectEslahSum().Tables[0];
                clsBuyObj.strActive = "";
            }
        }

        private void grdEslah_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            clsBuyObj.Eslah_No = grdEslah.Rows[e.RowIndex].Cells["Eslah_No"].Value.ToString();
            lblNoEslah.Text = clsBuyObj.Eslah_No;
            txtMeghdar.Text = grdEslah.Rows[e.RowIndex].Cells["meghdar"].Value.ToString();
            chkTaeed.Checked = Convert.ToBoolean(grdEslah.Rows[e.RowIndex].Cells["Taeed"].Value.ToString());
            txtMeghdar.Enabled = false;
            cmbTasir.Enabled = false;
            btn_edit.Enabled = true;
            btn_del.Enabled = true;
            btn_add.Enabled = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btn_edit.Enabled = true;
            btn_del.Enabled = true;
            btn_add.Enabled = false;
        }
    }
}

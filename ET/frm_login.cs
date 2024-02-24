using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Globalization;

namespace ET
{
    public partial class login : Telerik.WinControls.UI.RadForm
    {
        public login()
        {
            InitializeComponent();            
        }

        //دیتا ست سطح دسترسی
        public DataSet Ds = new System.Data.DataSet();
        ClsMain cm = new ClsMain(); 

        private void login_Load(object sender, EventArgs e)
        {
            //txtUser.Text = Environment.UserName;
            ThemeResolutionService.ApplicationThemeName = "Office2010Blue";
            //انتخاب دوره
            cm.DbCurent = "1";
            Ds = cm.SelectDB_Curent();
            ClsConnect.Dore = Ds.Tables[0].Rows[0][0].ToString();
            ClsConnect.Namedore = Ds.Tables[0].Rows[0][1].ToString();
            ClsConnect.DbPaya = Ds.Tables[0].Rows[0][2].ToString();
            ClsConnect.DbYear = Ds.Tables[0].Rows[0][4].ToString();
        }
        
        private void login_f()
        {
            if (txtUser.Text == "" || txtPass.Text == "")
            {
                RadMessageBox.Show("اطلاعات را درست وارد کنید");
                this.ActiveControl = txtUser;
                return;
            }
            cm.StrUser = txtUser.Text;
            cm.StrPass = txtPass.Text;
            Ds.Tables.Clear();
            Ds = cm.SelectLoginUser();
            if (Ds.Tables[0].Rows.Count == 0)
            {
                RadMessageBox.Show("کلمه کاربری یا رمز ورود اشتباه است");
                //this.ActiveControl = txtPass;
                return;
            }
            if (Ds.Tables[0].Rows[0]["flag_active"].ToString() == "False")
            {
                RadMessageBox.Show("نام کاربری غیر فعال می باشد");
           
                return;
            }
            //if (Ds.Tables[0].Rows[0][""].ToString() == "False")
            //{
            //    MessageBox.Show("نام کاربری غیر فعال می باشد");

            //    return;
            //}
            if (Ds.Tables[0].Rows.Count == 1)
            {
                ClsMain.StrNameUser = Ds.Tables[0].Rows[0]["NAME"].ToString();
                ClsMain.StrPersonerId = Ds.Tables[0].Rows[0]["code_personeli"].ToString();
                ClsMain.StrUsername = Ds.Tables[0].Rows[0]["username"].ToString();
                ClsMain.IDUser = Ds.Tables[0].Rows[0]["id"].ToString();
                DataTable dt = new DataTable();
                dt = cm.SelectSematUser().Tables[0];
                if (dt.Rows.Count > 0)
                {
                    ClsMain.StrSemat = dt.Rows[0]["semat"].ToString();
                    ClsMain.strID_unit = dt.Rows[0]["IdUnit"].ToString();
                    ClsMain.strNameUnit = dt.Rows[0]["NameUnit"].ToString();
                    ClsMain.strIdPersonelChart = dt.Rows[0]["ID_PersonelChart"].ToString();
                }

                txtPass.Text = "";
                this.Hide();
                Frm_Main sa = new Frm_Main();
                sa.ShowDialog();
                this.Close();
            }
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.ActiveControl = txtPass;
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                //this.ActiveControl = icnLogin;
                login_f();
            }
        }

        private void pb_login_Click(object sender, EventArgs e)
        {
            login_f();
        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pb_login_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            login_f();
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-us"));
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            //login_f();
        }

        private void icnLogin_Click(object sender, EventArgs e)
        {
            login_f();
        }

        private void shutdown_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
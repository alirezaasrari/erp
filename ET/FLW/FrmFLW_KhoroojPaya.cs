using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using FastReport;

namespace ET
{
    public partial class FrmFLW_KhoroojPaya : Telerik.WinControls.UI.RadForm
    {
        public FrmFLW_KhoroojPaya()
        {
            InitializeComponent();
        }
        public string strIdUnit, strCkala, strIdKhoroojH, strGrdEnable, strSend, IntLevelTaeed, strIdTaeed;

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                ClsFlw obj = new ClsFlw();
                if (strSend == "0")
                {
                    MessageBox.Show("امکان تایید وجود ندارد");
                    return;
                }
                if (string.IsNullOrEmpty(IntIdMarhale))
                {
                    MessageBox.Show("امکان برگشت وجود ندارد");
                    return;
                }
                if (strID_FormUnit == "2")//تدارکات
                {
                    if (IntIdMarhale == "6")
                    {
                        obj.strValueVariable = "0";
                        obj.strIdVariable = "2";
                        obj.Update_Variable();
                    }
                    if (IntIdMarhale == "5")
                    {
                        obj.strValueVariable = "0";
                        obj.strIdVariable = "7";
                        obj.Update_Variable();
                    }
                    if (IntIdMarhale == "4")
                    {
                        obj.strValueVariable = "0";
                        obj.strIdVariable = "8";
                        obj.Update_Variable();
                    }
                    if (IntIdMarhale == "9")
                    {
                        obj.strValueVariable = "0";
                        obj.strIdVariable = "26";
                        obj.Update_Variable();

                        obj.strCodeKhoroojPaya = txtCodeKhoroojPaya.Text;
                        obj.strValueVariable = obj.Select_KhoroojHPaya().Tables[0].Rows[0]["IndexAnbardar"].ToString();
                        obj.strIdVariable = "4";
                        obj.Update_Variable();
                    }
                }
                if (strID_FormUnit == "4")
                {
                    if (IntIdMarhale == "5")
                    {
                        obj.strValueVariable = "0";
                        obj.strIdVariable = "27";
                        obj.Update_Variable();
                    }
                }
                if (strID_FormUnit == "5")
                {
                    if (IntIdMarhale == "5")
                    {
                        obj.strValueVariable = "0";
                        obj.strIdVariable = "28";
                        obj.Update_Variable();
                    }
                }
                if (strID_FormUnit == "8")
                {
                    if (IntIdMarhale == "6")
                    {
                        obj.strValueVariable = "0";
                        obj.strIdVariable = "29";
                        obj.Update_Variable();
                    }
                }
                if (strID_FormUnit == "9")
                {
                    if (IntIdMarhale == "6")
                    {
                        obj.strValueVariable = "0";
                        obj.strIdVariable = "30";
                        obj.Update_Variable();
                    }
                }

                obj.strCheckTaeed = "2";
                obj.strDescTaeed = txtErja.Text;
                obj.strIdTaeed = strIdTaeed;

                MessageBox.Show(obj.Update_FormFlowTaeed());
                obj.Update_FormFlowTaeedActive();
                this.Close();
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
                return;
            }
        }

        public string IntIdMarhale, strID_FormUnit;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            Report objReport = new Report();

            objReport.Load(ClsPublic.strRepPath + "KhoroojPaya.frx");
            objReport.SetParameterValue("KhNO", txtCodeKhoroojPaya.Text);
            objReport.Print();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            try
            {
                if (strSend == "0")
                {
                    MessageBox.Show("امکان تایید وجود ندارد");
                    return;
                }
                ClsFlw obj = new ClsFlw();
                obj.strCheckTaeed = "3";
                obj.strDescTaeed = txtErja.Text;
                obj.strIdTaeed = strIdTaeed;

                MessageBox.Show(obj.Update_FormFlowTaeed());
                this.Close();
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        public DataTable dt = new DataTable();
        private void FrmFLW_KhoroojPaya_Load(object sender, EventArgs e)
        {
            try
            {
                btnEnd.Visible = false;
                //btnBack.Visible = false;
                if (strID_FormUnit == "2")
                {
                    if (IntIdMarhale == "4" | IntIdMarhale == "5" | IntIdMarhale == "6" | IntIdMarhale == "7" | IntIdMarhale == "9")//دسترسی برگشت
                    {
                        btnBack.Visible = true;
                    }
                    if (IntIdMarhale == "1" | IntIdMarhale == "4" | IntIdMarhale == "6" | IntIdMarhale == "7")//اتمام
                    {
                        btnEnd.Visible = true;
                    }
                }
                if (Convert.ToInt32(strID_FormUnit) == 4)
                {
                    grdKhorooj.Visible = false;
                    lblKhorooj.Visible = false;
                    if (IntIdMarhale == "2" | IntIdMarhale == "4")//دسترسی اتمام
                    {
                        btnEnd.Visible = true;
                    }
                }
                if (Convert.ToInt32(strID_FormUnit) == 5)
                {
                    grdKhorooj.Visible = false;
                    lblKhorooj.Visible = false;
                    if (IntIdMarhale == "2" | IntIdMarhale == "3" | IntIdMarhale == "4" | IntIdMarhale == "6")//دسترسی اتمام
                    {
                        btnEnd.Visible = true;                        
                    }
                }
                if (Convert.ToInt32(strID_FormUnit) == 6 | Convert.ToInt32(strID_FormUnit) == 7)
                {
                    grdKhorooj.Visible = false;
                    lblKhorooj.Visible = false;
                    if (IntIdMarhale == "3" | IntIdMarhale == "4")//دسترسی اتمام
                    {
                        btnEnd.Visible = true;
                    }
                }
                if (Convert.ToInt32(strID_FormUnit) == 8 | Convert.ToInt32(strID_FormUnit) == 9)
                {
                    grdKhorooj.Visible = false;
                    lblKhorooj.Visible = false;
                    if (IntIdMarhale == "3" | IntIdMarhale == "4" | IntIdMarhale == "5")//دسترسی اتمام
                    {
                        btnEnd.Visible = true;
                    }
                    if (IntIdMarhale == "6")//دسترسی برگشت
                    {
                        btnBack.Visible = true;
                    }
                }

                ClsFlw obj = new ClsFlw();
                obj.strCodeFormX = strIdKhoroojH;
                dt = obj.Select_KhoroojPaya().Tables[0];
                if (dt.Rows.Count > 0)
                {
                    txtCodeKhoroojPaya.Text = dt.Rows[0]["KhNO"].ToString();
                    txtDate.Text = dt.Rows[0]["KhDt"].ToString();
                    txtTypeKhorooj.Text = dt.Rows[0]["TypeKhorooj"].ToString();
                    txtTozihat.Text = dt.Rows[0]["Tozihat"].ToString();
                    txtHavale.Text = dt.Rows[0]["IdHavale"].ToString();
                    grd.DataSource = dt;
                }
               
                grdKhorooj.DataSource = obj.Select_KhoroojD().Tables[0];
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (strSend == "0")
                {
                    MessageBox.Show("امکان تایید وجود ندارد");
                    return;
                }
                ClsFlw obj = new ClsFlw();
                if (strID_FormUnit == "2")
                {
                    if (IntIdMarhale == "9")
                    {
                        obj.strValueVariable = "1";
                        obj.strIdVariable = "26";
                        obj.Update_Variable();
                    }
                }
                if (strID_FormUnit == "4")
                {
                    if (IntIdMarhale == "5")
                    {
                        obj.strValueVariable = "1";
                        obj.strIdVariable = "27";
                        obj.Update_Variable();
                    }
                }
                if (strID_FormUnit == "8")
                {
                    if (IntIdMarhale == "6")
                    {
                        obj.strValueVariable = "1";
                        obj.strIdVariable = "29";
                        obj.Update_Variable();
                    }
                }
                if (strID_FormUnit == "9")
                {
                    if (IntIdMarhale == "6")
                    {
                        obj.strValueVariable = "1";
                        obj.strIdVariable = "30";
                        obj.Update_Variable();
                    }
                }
                if (strID_FormUnit == "5")
                {
                    if (IntIdMarhale == "5")
                    {
                        obj.strValueVariable = "1";
                        obj.strIdVariable = "28";
                        obj.Update_Variable();
                    }
                }

                
                obj.strCheckTaeed = "1";
                obj.strDescTaeed = txtErja.Text;
                obj.strIdTaeed = strIdTaeed;

                MessageBox.Show(obj.Update_FormFlowTaeed());
                this.Close();
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }
    }
}

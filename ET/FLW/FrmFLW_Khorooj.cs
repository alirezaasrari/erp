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
    public partial class FrmFLW_Khorooj : Telerik.WinControls.UI.RadForm
    {
        public string strIdUnit, strCkala, strIdKhoroojH, strGrdEnable, strSend, strID_FormUnit;
        public FrmFLW_Khorooj()
        {
            InitializeComponent();
        }

        public string IntLevelTaeed, strIdTaeed, IntIdFormChart, IntIdMarhale, strCKalaH;
        public int ITAccess, MavadAccess, DeviceTamir, DevicePeymankar, DeviceSale, Imeni, GhalebPeymankar
            , GhalebTamir, ZayeatSite, ZayeatTolid, IsBuy;

        private void btnSearchDarkhast_Click(object sender, EventArgs e)
        {
            try
            {
                FrmBuy_DarkhastSearch frm = new FrmBuy_DarkhastSearch();
                frm.ShowDialog();
                txtIdDarkhastKharid.Text = frm.strIdDarkhastKharid;
                strCKalaH = frm.strCkala;
            }
            catch { }
        }

        DataTable dt = new DataTable();
        private void FrmFLW_Khorooj_Load(object sender, EventArgs e)
        {
            try
            {
                AccessData();
                if (strID_FormUnit == null)
                    strID_FormUnit = ClsFlw.ID_FormUnit;

                if (strID_FormUnit == "1" & ITAccess == 0 & ClsFlw.Isnew == "1")
                {
                    RadMessageBox.Show("دسترسی وجود ندارد");
                    btnSend.Visible = false;
                    return;
                }
                if (strID_FormUnit == "2")
                {
                    if(Convert.ToInt16(IntIdMarhale)<5)
                    {
                        btnBack.Enabled = false;
                        btnEnd.Enabled = false;
                    }
                    if (MavadAccess == 0 & ClsFlw.Isnew == "1")
                    {
                        RadMessageBox.Show("دسترسی وجود ندارد");
                        btnSend.Visible = false;
                        return;
                    }
                }
                if (strID_FormUnit == "4")
                {
                    if (DeviceTamir == 0 & ClsFlw.Isnew == "1")
                    {
                        RadMessageBox.Show("دسترسی وجود ندارد");
                        btnSend.Visible = false;
                        return;
                    }
                    cmbAnbardar.Visible = false;
                    grpNext.Visible = false;
                    //grpDetail.Visible = false;
                    //grd.Visible = false;
                    chkModirAmel.Visible = false;
                    if (IntIdFormChart == "86")
                        grpKhorooj.Enabled = true;
                }
                if (strID_FormUnit == "5" )
                {
                    if (DevicePeymankar == 0 & ClsFlw.Isnew == "1")
                    {
                        RadMessageBox.Show("دسترسی وجود ندارد");
                        btnSend.Visible = false;
                        return;
                    }
                    cmbAnbardar.Visible = false;
                    grpNext.Visible = false;
                    //grpDetail.Visible = false;
                    //grd.Visible = false;
                    chkModirAmel.Visible = false;
                    if (IntIdFormChart == "92")
                        grpKhorooj.Enabled = true;
                }
                if (strID_FormUnit == "6")
                {
                    if (DeviceSale == 0 & ClsFlw.Isnew == "1")
                    {
                        RadMessageBox.Show("دسترسی وجود ندارد");
                        btnSend.Visible = false;
                        return;
                    }
                    cmbAnbardar.Visible = false;
                    grpNext.Visible = false;
                    //grpDetail.Visible = false;
                    //grd.Visible = false;
                    chkModirAmel.Visible = false;
                    if (IntIdFormChart == "98")
                        grpKhorooj.Enabled = true;
                }
                if (strID_FormUnit == "7")
                {
                    if (Imeni == 0 & ClsFlw.Isnew == "1")
                    {
                        RadMessageBox.Show("دسترسی وجود ندارد");
                        btnSend.Visible = false;
                        return;
                    }
                    cmbAnbardar.Visible = false;
                    grpNext.Visible = false;
                    //grpDetail.Visible = false;
                    //grd.Visible = false;
                    chkModirAmel.Visible = false;
                    if (IntIdFormChart == "104")
                        grpKhorooj.Enabled = true;
                }
                if (strID_FormUnit == "8")
                {
                    if (GhalebPeymankar == 0 & ClsFlw.Isnew == "1")
                    {
                        RadMessageBox.Show("دسترسی وجود ندارد");
                        btnSend.Visible = false;
                        return;
                    }
                    cmbAnbardar.Visible = false;
                    grpNext.Visible = false;
                    //grpDetail.Visible = false;
                    //grd.Visible = false;
                    chkModirAmel.Visible = false;
                    if (IntIdFormChart == "111")
                        grpKhorooj.Enabled = true;
                }
                if (strID_FormUnit == "9")
                {
                    if (GhalebTamir == 0 & ClsFlw.Isnew == "1")
                    {
                        RadMessageBox.Show("دسترسی وجود ندارد");
                        btnSend.Visible = false;
                        return;
                    }
                    cmbAnbardar.Visible = false;
                    grpNext.Visible = false;
                    //grpDetail.Visible = false;
                    //grd.Visible = false;
                    chkModirAmel.Visible = false;
                    if (IntIdFormChart == "118")
                        grpKhorooj.Enabled = true;
                }
                if (strID_FormUnit == "11")
                {
                    if (ZayeatSite == 0 & ClsFlw.Isnew == "1")
                    {
                        RadMessageBox.Show("دسترسی وجود ندارد");
                        btnSend.Visible = false;
                        return;
                    }
                    cmbAnbardar.Visible = false;
                    grpNext.Visible = false;
                    //grpDetail.Visible = false;
                    //grd.Visible = false;
                    chkModirAmel.Visible = false;
                    if (IntIdFormChart == "154")
                        grpKhorooj.Enabled = true;
                }
                if (strID_FormUnit == "12")
                {
                    if (ZayeatTolid == 0 & ClsFlw.Isnew == "1")
                    {
                        RadMessageBox.Show("دسترسی وجود ندارد");
                        btnSend.Visible = false;
                        return;
                    }
                    cmbAnbardar.Visible = false;
                    grpNext.Visible = false;
                    //grpDetail.Visible = false;
                    //grd.Visible = false;
                    chkModirAmel.Visible = false;
                    if (IntIdFormChart == "163")
                        grpKhorooj.Enabled = true;
                }
                ClsFlw.Isnew = "0";
                if (string.IsNullOrEmpty(IntLevelTaeed))
                {
                    grpCreate.Enabled = true;
                    //grpDetail.Enabled = true;
                    strGrdEnable = "1"; //اجازه تغییر اطلاعات گرید
                    btnSend.Enabled = false;
                    btnBack.Enabled = false;
                    btnEnd.Enabled = false;
                    btnSabtHeader.Enabled = true;
                    btnBack.Visible = false;

                    strIdUnit = ClsMain.strID_unit;
                    txtUnitRequest.Text = ClsMain.strNameUnit;
                }
                else
                {
                    btnSabtHeader.Enabled = false;
                    if (Convert.ToInt32(IntLevelTaeed) > 1)
                    {
                        strGrdEnable = "0";                       
                        grpCreate.Enabled = false;
                    }
                    else
                        strGrdEnable = "1";

                    if (strID_FormUnit == "1")
                    {
                        if (IntLevelTaeed == "2")
                        {
                            grpKhorooj.Enabled = true;
                        }
                    }
                    if (strID_FormUnit == "2")
                    {
                        if (Convert.ToInt16(IntIdMarhale) == 8 )//انباردار
                        {
                            grpKhorooj.Enabled = true;
                        }
                        if (IntIdMarhale == "4" | IntIdMarhale == "5" | IntIdMarhale == "6" | IntIdMarhale == "7" | IntIdMarhale == "9")//دسترسی برگشت
                        {
                            btnBack.Visible = true;
                            btnBack.Enabled = true;
                        }
                        if (IntIdMarhale == "1" | IntIdMarhale == "4"  | IntIdMarhale == "6" | IntIdMarhale == "7" | IntIdMarhale == "8")//اتمام
                        {
                            btnEnd.Visible = true;
                            btnEnd.Enabled = true;
                        }
                        if (IntIdMarhale == "1" | IntIdMarhale == "3" | IntIdMarhale == "4")//تغییر هدر
                        {
                            grpCreate.Enabled = true;
                            btnUpdateHeader.Enabled = true;
                        }
                        if (IntIdMarhale == "1" | IntIdMarhale == "6" )//تغییر گرید
                        {
                            strGrdEnable = "1";
                            grpCreate.Enabled = true;
                            btnUpdateHeader.Enabled = true;
                        }
                    }
                                       
                    if (IntLevelTaeed == "1")
                    {
                        grpDetail.Enabled = true;
                    }
                }
                
                SetCmb();
                ShowData();
                
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
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
                if (string.IsNullOrEmpty(IntIdFormChart))
                {
                    ClsFlw obj = new ClsFlw();
                    obj.strID_Form = "1";
                    obj.strID_Unit = strIdUnit;
                    obj.strID_FormUnit = ClsFlw.ID_FormUnit;
                    obj.strCodeFormX = strIdKhoroojH;
                    obj.Insert_CodeFormX();
                    obj.strIdCodeFormX = obj.Select_CodeFormXMax().Tables[0].Rows[0]["IdCodeFormX"].ToString();
                    obj.strTozihat = txtErja.Text;
                    MessageBox.Show(obj.Insert_FormFlowTaeed());
                    if (strID_FormUnit == "4" | strID_FormUnit == "5" | strID_FormUnit == "6" | strID_FormUnit == "7" | strID_FormUnit == "8" | strID_FormUnit == "9")
                    {
                        obj.strCheckTaeed = "1";
                        obj.strDescTaeed = txtErja.Text;
                        obj.strIdTaeed = obj.Select_TaeedMax().Tables[0].Rows[0][0].ToString();

                        obj.Update_FormFlowTaeed();
                        obj.Update_FormFlowTaeedActive();
                    }
                    this.Close();
                }
                else
                {
                    ClsFlw obj = new ClsFlw();
                    if (strID_FormUnit == "2")//تدارکات
                    {
                        if (IntIdMarhale == "1")
                        {
                            obj.strValueVariable = cmbBuy.SelectedValue.ToString();
                            obj.strIdVariable = "6";
                            obj.Update_Variable();
                        }
                        if (IntIdMarhale == "3")
                        {
                            obj.strValueVariable = Convert.ToInt16(chkIsBuy.Checked).ToString();
                            obj.strIdVariable = "51";
                            obj.Update_Variable();

                            obj.strValueVariable = cmbQC.SelectedValue.ToString();
                            obj.strIdVariable = "5";
                            obj.Update_Variable();
                        }
                        if (IntIdMarhale == "4")
                        {                           
                            obj.strValueVariable = "1";
                            obj.strIdVariable = "8";
                            obj.Update_Variable();
                        }
                        if (IntIdMarhale == "5")
                        {
                            obj.strValueVariable = "1";
                            obj.strIdVariable = "7";
                            obj.Update_Variable();
                        }                        
                        if (IntIdMarhale == "6")
                        {
                            obj.strValueVariable = Convert.ToInt16(chkModirAmel.Checked).ToString();
                            obj.strIdVariable = "1";
                            obj.Update_Variable();

                            obj.strValueVariable = "1";
                            obj.strIdVariable = "2";
                            obj.Update_Variable();
                        }
                        if (IntIdMarhale == "7" | IntIdMarhale == "6")
                        {
                            obj.strValueVariable = cmbAnbardar.SelectedValue.ToString();
                            obj.strIdVariable = "4";
                            obj.Update_Variable();
                        }

                        if (Convert.ToInt16(IntIdMarhale) == 8)
                        {
                            if (txtCodeKhoroojPaya.Text == "" | grpKhorooj.Enabled == true)
                            {
                                MessageBox.Show("شماره برگه خروج پایا را ثبت نمایید");
                                return;
                            }
                        }

                        if (IntIdMarhale == "9")
                        {
                            obj.strValueVariable = "1";
                            obj.strIdVariable = "26";
                            obj.Update_Variable();
                        }
                    }

                    if (strID_FormUnit == "4")
                    {
                        if (txtCodeKhoroojPaya.Text == "" & IntIdMarhale == "8")
                        {
                            MessageBox.Show("برگه خروج را وارد کنید");
                            return;
                        }
                        if (IntIdMarhale == "5")
                        {
                            obj.strValueVariable = "1";
                            obj.strIdVariable = "27";
                            obj.Update_Variable();
                        }
                    }
                    if (strID_FormUnit == "4" | strID_FormUnit == "6" | strID_FormUnit == "7")
                    {
                        if (txtCodeKhoroojPaya.Text == "" & IntIdMarhale == "4")
                        {
                            MessageBox.Show("برگه خروج پایا را وارد کنید");
                            return;
                        }
                    }
                    if (strID_FormUnit == "8" )
                    {
                        if (txtCodeKhoroojPaya.Text == "" & IntIdMarhale == "5")
                        {
                            MessageBox.Show("برگه خروج پایا را وارد کنید");
                            return;
                        }
                        if (IntIdMarhale == "6")
                        {
                            obj.strValueVariable = "1";
                            obj.strIdVariable = "29";
                            obj.Update_Variable();
                        }
                    }
                    if (strID_FormUnit == "9")
                    {
                        if (txtCodeKhoroojPaya.Text == "" & IntIdMarhale == "5")
                        {
                            MessageBox.Show("برگه خروج پایا را وارد کنید");
                            return;
                        }
                        if (IntIdMarhale == "6")
                        {
                            obj.strValueVariable = "1";
                            obj.strIdVariable = "30";
                            obj.Update_Variable();
                        }
                    }
                    if (strID_FormUnit == "5")
                    {
                        if (txtCodeKhoroojPaya.Text == "" & IntIdMarhale == "4")
                        {
                            MessageBox.Show("برگه خروج پایا را وارد کنید");
                            return;
                        }
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
                    obj.Update_FormFlowTaeedActive();
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
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
                if (string.IsNullOrEmpty(IntLevelTaeed))
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

                        obj.strValueVariable = cmbAnbardar.SelectedValue.ToString();
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

        private void btnF2Moshtari_Click(object sender, EventArgs e)
        {
            FrmTafsili frm = new FrmTafsili();
            frm.ShowDialog();
            txtDestination.Text = frm.Ntafsili;
        }

        private void btnUpdateHeader_Click(object sender, EventArgs e)
        {
            try
            {
                ClsFlw obj = new ClsFlw();
                obj.strAlways = cmbAlways.SelectedValue.ToString();
                obj.strReason = cmbReason.SelectedValue.ToString();
                obj.strDestination = txtDestination.Text;
                obj.strTozihat = txtTozihat.Text;
                obj.strIndexAnbardar = cmbAnbardar.SelectedValue.ToString();
                obj.strIndexQC = cmbQC.SelectedValue.ToString();
                obj.strTaeedModirAmel = Convert.ToInt16(chkModirAmel.Checked).ToString();
                obj.strIsBuy = Convert.ToInt16(chkIsBuy.Checked).ToString();
                obj.strIdKhoroojH = strIdKhoroojH;
                MessageBox.Show(obj.Update_KhoroojH());
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        private void grd_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "btnDelete")
                {
                    if (strSend == "0")
                    {
                        MessageBox.Show("امکان تغییر وجود ندارد");
                        return;
                    }
                    if (strGrdEnable == "0")
                    {
                        MessageBox.Show("امکان تغییر اطلاعات وجود ندارد");
                        return;
                    }
                    ClsFlw obj = new ClsFlw();
                    obj.strIdKhoroojD= grd.Rows[e.RowIndex].Cells["IdKhoroojD"].Value.ToString();
                    if (MessageBox.Show("آیا از حذف ردیف اطمینان دارید؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        MessageBox.Show(obj.Delete_KhoroojD());
                    obj.strCodeFormX = strIdKhoroojH;
                    grd.DataSource = obj.Select_KhoroojD().Tables[0];
                }
            }
            catch 
            {
                
            }
        }

        private void btnSabtHeader_Click(object sender, EventArgs e)
        {
            try
            {               
                ClsFlw obj = new ClsFlw();
                obj.strAlways = cmbAlways.SelectedValue.ToString();
                obj.strReason = cmbReason.SelectedValue.ToString();
                obj.strDestination = txtDestination.Text;
                obj.strIdUnit = strIdUnit;
                obj.strTozihat = txtTozihat.Text;
                obj.strIndexAnbardar = cmbAnbardar.SelectedValue.ToString();
                obj.strIndexQC = cmbQC.SelectedValue.ToString();
                obj.strIndexBuy = cmbBuy.SelectedValue.ToString();
                obj.strTaeedModirAmel = Convert.ToInt16(chkModirAmel.Checked).ToString();
                obj.strIsBuy = Convert.ToInt16(chkIsBuy.Checked).ToString();
                MessageBox.Show(obj.Ins_KhoroojH());
                grpDetail.Enabled = true;
                strIdKhoroojH = obj.Select_KhoroojHMax().Tables[0].Rows[0][0].ToString();

                btnSend.Enabled = true;
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
                if (strSend == "0")
                {
                    MessageBox.Show("امکان تغییر وجود ندارد");
                    return;
                }
                ClsBuy objBuy = new ClsBuy();
                objBuy.strSho_Darkhast = txtIdDarkhastKharid.Text;
                if (objBuy.SelectDarkhastKharid().Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("شماره درخواست خرید در پایا پیدا نشد");
                    return;
                }
                ClsFlw obj = new ClsFlw();
                obj.strCodeFormX = strIdKhoroojH;
                obj.strCKala = strCkala;
                obj.strMeghdar = txtMeghdar.Text;
                obj.strMeghdarFarie = txtMeghdarFarie.Text;
                obj.strVahedFarie = txtVahedFarie.Text;
                obj.strTozihat = txtTozihatD.Text;
                obj.strIdDarkhastKharid = txtIdDarkhastKharid.Text;
                obj.strCKalaH = strCKalaH;
                MessageBox.Show(obj.Ins_KhoroojD());

                grd.DataSource = obj.Select_KhoroojD().Tables[0];
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        private void btnKhoroojPaya_Click(object sender, EventArgs e)
        {
            try
            {
                ClsFlw obj = new ClsFlw();
                obj.strCodeKhoroojPaya = txtCodeKhoroojPaya.Text;
                obj.strIdKhoroojH = strIdKhoroojH;
                if(obj.Select_KhoroojPayaValid().Tables[0].Rows.Count>0)
                {
                    MessageBox.Show("خروج پایا با کالاهای مجوز خروج متفاوت است");
                    //return;
                }
                MessageBox.Show(obj.Update_KhoroojHPaya());
                grpKhorooj.Enabled = false;
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        private void btnF2Kala_Click(object sender, EventArgs e)
        {
            FrmKala frm = new FrmKala();
            //frm.strC_Anbar = "13,14,19,16";
            frm.ShowDialog();
            txtNKala.Text = ClsBuy.N_kala;
            strCkala = ClsBuy.C_kala;
            lblUnitKala.Text = ClsBuy.strN_Vahed;
        }
        public void ShowData()
        {
            try
            {
                ClsFlw obj = new ClsFlw();
                obj.strCodeFormX = strIdKhoroojH;
                dt = obj.Select_KhoroojH().Tables[0];
                if (dt.Rows.Count > 0)
                {
                    cmbReason.SelectedValue = Convert.ToInt32(dt.Rows[0]["Reason"].ToString());
                    cmbAlways.SelectedValue = Convert.ToInt32(dt.Rows[0]["always"].ToString());
                    cmbAnbardar.SelectedValue = Convert.ToInt32(dt.Rows[0]["IndexAnbardar"].ToString());
                    cmbQC.SelectedValue = Convert.ToInt32(dt.Rows[0]["IndexQC"].ToString());
                    cmbBuy.SelectedValue = Convert.ToInt32(dt.Rows[0]["IndexBuy"].ToString());
                    chkModirAmel.Checked = Convert.ToBoolean(dt.Rows[0]["TaeedModirAmel"]);
                    chkIsBuy.Checked = Convert.ToBoolean(dt.Rows[0]["IsBuy"]);
                    txtDestination.Text = dt.Rows[0]["Destination"].ToString();
                    txtUnitRequest.Text = dt.Rows[0]["NameUnit"].ToString();
                    txtTozihat.Text = dt.Rows[0]["Tozihat"].ToString();
                    txtCodeKhoroojPaya.Text= dt.Rows[0]["CodeKhoroojPaya"].ToString();

                    grd.DataSource = obj.Select_KhoroojD().Tables[0];
                }
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }
        public void SetCmb()
        {
            DataColumn dc;
            DataRow dr;
            DataTable dt = new DataTable();

            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.Int32");
            dc.ColumnName = "id";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.String");
            dc.ColumnName = "item";
            dt.Columns.Add(dc);

            dr = dt.NewRow();
            dr["item"] = "برگشت";
            dr["id"] = "1";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["item"] = "امانی";
            dr["id"] = "2";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["item"] = "تعمیری";
            dr["id"] = "3";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["item"] = "اجرتی";
            dr["id"] = "4";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["item"] = "مصرفی";
            dr["id"] = "5";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["item"] = "فروش ضایعات تولید";
            dr["id"] = "6";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["item"] = "فروش ضایعات سایت";
            dr["id"] = "7";
            dt.Rows.Add(dr);

            cmbReason.DataSource = dt;
            cmbReason.ValueMember = "id";
            cmbReason.DisplayMember = "item";
            ////////////////////////////////////////////////
            DataColumn dc1;
            DataRow dr1;
            DataTable dt1 = new DataTable();

            dc1 = new DataColumn();
            dc1.DataType = System.Type.GetType("System.Int32");
            dc1.ColumnName = "id";
            dt1.Columns.Add(dc1);

            dc1 = new DataColumn();
            dc1.DataType = System.Type.GetType("System.String");
            dc1.ColumnName = "item";
            dt1.Columns.Add(dc1);

            dr1 = dt1.NewRow();
            dr1["item"] = "دائم";
            dr1["id"] = "1";
            dt1.Rows.Add(dr1);

            dr1 = dt1.NewRow();
            dr1["item"] = "موقت";
            dr1["id"] = "2";
            dt1.Rows.Add(dr1);

            cmbAlways.DataSource = dt1;
            cmbAlways.ValueMember = "id";
            cmbAlways.DisplayMember = "item";
            /////////////////////////////////////////////////////
            DataColumn dc2;
            DataRow dr2;
            DataTable dt2 = new DataTable();

            dc2 = new DataColumn();
            dc2.DataType = System.Type.GetType("System.Int32");
            dc2.ColumnName = "id";
            dt2.Columns.Add(dc2);

            dc2 = new DataColumn();
            dc2.DataType = System.Type.GetType("System.String");
            dc2.ColumnName = "item";
            dt2.Columns.Add(dc2);

            dr2 = dt2.NewRow();
            dr2["item"] = "آقای رحمانی";
            dr2["id"] = "0";
            dt2.Rows.Add(dr2);

            dr2 = dt2.NewRow();
            dr2["item"] = "آقای سجادی";
            dr2["id"] = "1";
            dt2.Rows.Add(dr2);

            dr2 = dt2.NewRow();
            dr2["item"] = "آقای طاهری";
            dr2["id"] = "2";
            dt2.Rows.Add(dr2);

            dr2 = dt2.NewRow();
            dr2["item"] = "آقای رومی";
            dr2["id"] = "3";
            dt2.Rows.Add(dr2);

            dr2 = dt2.NewRow();
            dr2["item"] = "آقای محمد علی حیدری";
            dr2["id"] = "4";
            dt2.Rows.Add(dr2);

            dr2 = dt2.NewRow();
            dr2["item"] = "آقای قوش قلعه";
            dr2["id"] = "5";
            dt2.Rows.Add(dr2);

            cmbAnbardar.DataSource = dt2;
            cmbAnbardar.ValueMember = "id";
            cmbAnbardar.DisplayMember = "item";
            //////////////////////////////////////////////////
            DataColumn dc3;
            DataRow dr3;
            DataTable dt3 = new DataTable();

            dc3 = new DataColumn();
            dc3.DataType = System.Type.GetType("System.Int32");
            dc3.ColumnName = "id";
            dt3.Columns.Add(dc3);

            dc3 = new DataColumn();
            dc3.DataType = System.Type.GetType("System.String");
            dc3.ColumnName = "item";
            dt3.Columns.Add(dc3);

            dr3 = dt3.NewRow();
            dr3["item"] = "آقای پارسا";
            dr3["id"] = "1";
            dt3.Rows.Add(dr3);

            dr3 = dt3.NewRow();
            dr3["item"] = "آقای مفردیان";
            dr3["id"] = "2";
            dt3.Rows.Add(dr3);

            dr3 = dt3.NewRow();
            dr3["item"] = "آقای شریف";
            dr3["id"] = "3";
            dt3.Rows.Add(dr3);

            dr3 = dt3.NewRow();
            dr3["item"] = "خانم خزائی";
            dr3["id"] = "4";
            dt3.Rows.Add(dr3);

            //dr3 = dt3.NewRow();
            //dr3["item"] = "آقای رحمانی";
            //dr3["id"] = "5";
            //dt3.Rows.Add(dr3);

            //dr3 = dt3.NewRow();
            //dr3["item"] = "آقای سجادی";
            //dr3["id"] = "6";
            //dt3.Rows.Add(dr3);

            //dr3 = dt3.NewRow();
            //dr3["item"] = "آقای طاهری";
            //dr3["id"] = "7";
            //dt3.Rows.Add(dr3);

            //dr3 = dt3.NewRow();
            //dr3["item"] = "آقای رومی";
            //dr3["id"] = "8";
            //dt3.Rows.Add(dr3);

            //dr3 = dt3.NewRow();
            //dr3["item"] = "آقای اصغری";
            //dr3["id"] = "9";
            //dt3.Rows.Add(dr3);

            cmbQC.DataSource = dt3;
            cmbQC.ValueMember = "id";
            cmbQC.DisplayMember = "item";
            //////////////////////////////////////////////////
            DataColumn dc4;
            DataRow dr4;
            DataTable dt4 = new DataTable();

            dc4 = new DataColumn();
            dc4.DataType = System.Type.GetType("System.Int32");
            dc4.ColumnName = "id";
            dt4.Columns.Add(dc4);

            dc4 = new DataColumn();
            dc4.DataType = System.Type.GetType("System.String");
            dc4.ColumnName = "item";
            dt4.Columns.Add(dc4);

            dr4 = dt4.NewRow();
            dr4["item"] = "آقای رسانی";
            dr4["id"] = "1";
            dt4.Rows.Add(dr4);

            dr4 = dt4.NewRow();
            dr4["item"] = "آقای هاشمی";
            dr4["id"] = "2";
            dt4.Rows.Add(dr4);

            dr4 = dt4.NewRow();
            dr4["item"] = "آقای الهی";
            dr4["id"] = "3";
            dt4.Rows.Add(dr4);

            dr4 = dt4.NewRow();
            dr4["item"] = "آقای بذرگری";
            dr4["id"] = "4";
            dt4.Rows.Add(dr4);

            dr4 = dt4.NewRow();
            dr4["item"] = "آقای قانعی";
            dr4["id"] = "5";
            dt4.Rows.Add(dr4);

            cmbBuy.DataSource = dt4;
            cmbBuy.ValueMember = "id";
            cmbBuy.DisplayMember = "item";
        }
        public void AccessData()
        {
            //سطح دسترسی کنترلها       
            DataTable DtControlAccess = new DataTable();
            DataRow[] dr = ClsMain.DtAccessUser.Select("n_form='" + this.Name + "'");
            if (dr.Length > 0) DtControlAccess = dr.CopyToDataTable();
            if (DtControlAccess.Rows.Count > 0)
            {
                //Control ctn;
                for (int i = 0; i < DtControlAccess.Rows.Count; i++)
                {
                    string strControl = DtControlAccess.Rows[i]["n_control"].ToString();
                    if (strControl == "FrmFLW_KhoroojMavadAccess")
                    {
                        if (DtControlAccess.Rows[i]["id_user"].ToString() == ClsMain.IDUser & DtControlAccess.Rows[i]["isActive"] != null)
                            MavadAccess = 1;
                        else
                            MavadAccess = 0;
                    }
                    if (strControl == "FrmFLW_KhoroojITAccess")
                    {
                        if (DtControlAccess.Rows[i]["id_user"].ToString() == ClsMain.IDUser & DtControlAccess.Rows[i]["isActive"] != null)
                            ITAccess = 1;
                        else
                            ITAccess = 0;
                    }
                    if (strControl == "FrmFLW_KhoroojDeviceTamir")
                    {
                        if (DtControlAccess.Rows[i]["id_user"].ToString() == ClsMain.IDUser & DtControlAccess.Rows[i]["isActive"] != null)
                            DeviceTamir = 1;
                        else
                            DeviceTamir = 0;
                    }
                    if (strControl == "FrmFLW_KhoroojDevicePeymankar")
                    {
                        if (DtControlAccess.Rows[i]["id_user"].ToString() == ClsMain.IDUser & DtControlAccess.Rows[i]["isActive"] != null)
                            DevicePeymankar = 1;
                        else
                            DevicePeymankar = 0;
                    }
                    if (strControl == "FrmFLW_KhoroojDeviceSale")
                    {
                        if (DtControlAccess.Rows[i]["id_user"].ToString() == ClsMain.IDUser & DtControlAccess.Rows[i]["isActive"] != null)
                            DeviceSale = 1;
                        else
                            DeviceSale = 0;
                    }
                    if (strControl == "FrmFLW_KhoroojImeni")
                    {
                        if (DtControlAccess.Rows[i]["id_user"].ToString() == ClsMain.IDUser & DtControlAccess.Rows[i]["isActive"] != null)
                            Imeni = 1;
                        else
                            Imeni = 0;
                    }
                    if (strControl == "FrmFLW_KhoroojGhalebPeymankar")
                    {
                        if (DtControlAccess.Rows[i]["id_user"].ToString() == ClsMain.IDUser & DtControlAccess.Rows[i]["isActive"] != null)
                            GhalebPeymankar = 1;
                        else
                            GhalebPeymankar = 0;
                    }
                    if (strControl == "FrmFLW_KhoroojGhalebTamir")
                    {
                        if (DtControlAccess.Rows[i]["id_user"].ToString() == ClsMain.IDUser & DtControlAccess.Rows[i]["isActive"] != null)
                            GhalebTamir = 1;
                        else
                            GhalebTamir = 0;
                    }
                    if (strControl == "FrmFLW_ZayeatSite")
                    {
                        if (DtControlAccess.Rows[i]["id_user"].ToString() == ClsMain.IDUser & DtControlAccess.Rows[i]["isActive"] != null)
                            ZayeatSite = 1;
                        else
                            ZayeatSite = 0;
                    }
                    if (strControl == "FrmFLW_ZayeatTolid")
                    {
                        if (DtControlAccess.Rows[i]["id_user"].ToString() == ClsMain.IDUser & DtControlAccess.Rows[i]["isActive"] != null)
                            ZayeatTolid = 1;
                        else
                            ZayeatTolid = 0;
                    }
                }
            }
            ////--------------------------
        }
    }
}

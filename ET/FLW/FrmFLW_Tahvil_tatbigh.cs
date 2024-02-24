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
    public partial class FrmFLW_Tahvil_tatbigh : Telerik.WinControls.UI.RadForm
    {
        public string strIdTahvil_Tatbigh_H, strCkala, strSend, IntIdFormChart, IntIdMarhale, IntLevelTaeed, strGrdEnable
            , strID_FormUnit, strIdTaeed, strIdTahvil_Tatbigh_D;
        public int TahvilAccess;
        DataTable dt = new DataTable();
        private void btnUpdateHeader_Click(object sender, EventArgs e)
        {
            try
            {
                ClsFlw obj = new ClsFlw();
                obj.strDateEnter = txtDateEnter.Text;
                obj.strDriver = txtDriver.Text;
                obj.StrNumberCar = txtNumberCar.Text;
                obj.StrIdKhorooji = txtIdKhorooji.Text;
                obj.strNameTamin = txtTamin.Text;
                obj.strIndexAnbardar = cmbAnbardar.SelectedValue.ToString();
                obj.strIndexQC = cmbQC.SelectedValue.ToString();
                obj.strIndexBuy = cmbBuy.SelectedValue.ToString();
                obj.strIdResidMovaghat = txtResidMovaghat.Text;
                obj.StrIdHavale = txtHavale.Text;
                MessageBox.Show(obj.Update_Tahvil_Tatbigh_H(strIdTahvil_Tatbigh_H));
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        private void btnSabtHeader_Click(object sender, EventArgs e)
        {
            try
            {
                ClsFlw obj = new ClsFlw();
                obj.strDateEnter = txtDateEnter.Text;
                obj.strDriver = txtDriver.Text;
                obj.StrNumberCar = txtNumberCar.Text;
                obj.StrIdKhorooji = txtIdKhorooji.Text;
                obj.strNameTamin = txtTamin.Text;
                obj.strIndexAnbardar = cmbAnbardar.SelectedValue.ToString();
                obj.strIndexQC = cmbQC.SelectedValue.ToString();
                obj.strIndexBuy = cmbBuy.SelectedValue.ToString();
                MessageBox.Show(obj.Ins_Tahvil_Tatbigh_H());
                grpDetail.Enabled = true;
                strIdTahvil_Tatbigh_H = obj.Select_Tahvil_Tatbigh_HMax().Tables[0].Rows[0][0].ToString();
                lbl_IDRequest.Text = strIdTahvil_Tatbigh_H;
                btnUpdateHeader.Enabled = true;

                btnSend.Enabled = true;
                grpDetail.Enabled = true;
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        private void FrmFLW_Tahvil_tatbigh_Load(object sender, EventArgs e)
        {
            try
            {
                strGrdEnable = "1";
                txtDateEnter.Value = DateTime.Now;
                AccessData();

                if (TahvilAccess == 0 & ClsFlw.Isnew == "1")
                {
                    RadMessageBox.Show("دسترسی وجود ندارد");
                    btnSend.Visible = false;
                    Close();
                }
                
                SetCmb();                
                if (string.IsNullOrEmpty(IntLevelTaeed))
                {
                    grpCreate.Enabled = true;
                    txtMeghdarVoroodi.Enabled = true;
                    //grpDetail.Enabled = true;
                    strGrdEnable = "1"; //اجازه تغییر اطلاعات گرید
                    btnSend.Enabled = false;
                    btnBack.Enabled = false;
                    btnEnd.Enabled = false;
                    btnSabtHeader.Enabled = true;
                    grpDetail.Enabled = false;
                }
                else
                {
                    ShowData();
                    btnSabtHeader.Enabled = false;
                    //if (Convert.ToInt32(IntLevelTaeed) > 1)
                    //{
                    //    grpCreate.Enabled = false;
                    //}
                    //else
                    //    strGrdEnable = "1";

                    if (IntIdMarhale == "2")//تدارکات
                    {
                        //btnF2Kala.Enabled = false;
                        //txtMeghdar.Enabled = false;
                        //grd.Enabled = false;
                        //btnAdd.Enabled = false;
                        btnResidMovaghat.Enabled = false;
                        btnUpdateHeader.Enabled = true;
                        txtMeghdarVoroodi.Enabled = true;
                    }
                    if (IntIdMarhale == "3")//نگهبانی
                    {
                        btnF2Kala.Enabled = false;
                        txtMeghdarTaeed.Enabled = false;
                        //txtMeghdarCounted.Enabled = false;
                        //grd.Enabled = false;
                        strGrdEnable = "0";
                        btnAdd.Enabled = false;
                        btnUpdateHeader.Enabled = true;
                        btnEnd.Visible = true;
                    }
                    if (IntIdMarhale == "4")//انباردار
                    {
                        btnF2Kala.Enabled = false;
                        //txtMeghdarCounted.Enabled = false;
                        //grd.Enabled = false;
                        txtMeghdarVoroodi.Enabled = false;
                        txtMeghdarTaeed.Enabled = false;
                        txtMeghdarMardood.Enabled = false;
                        txtMeghdarErfagh.Enabled = false;
                        cmbKharid.Enabled = false;
                        cmbJari.Enabled = false;
                        btnAdd.Enabled = false;
                        btnUpdateHeader.Enabled = true;
                        btnBack.Visible = true;
                        btnEnd.Visible = true;
                    }
                    if (IntIdMarhale == "5")//QC
                    {
                        btnF2Kala.Enabled = false;
                        btnResidMovaghat.Enabled = false;
                        btnAdd.Enabled = false;
                        //btnEditDetail.Enabled = true;
                        txtNumberBuy.Enabled = false;
                        //txtMeghdarTaeed.Enabled = false;
                        btnUpdateHeader.Enabled = true;
                        //txtFrmDisagreement.Enabled = false;
                        //cmbVazieatKifi.Enabled = false;
                        //grd.Enabled = false;
                    }
                    if (IntIdMarhale == "6")//anbar
                    {
                        btnF2Kala.Enabled = false;
                        btnAdd.Enabled = false;
                        btnEditDetail.Enabled = true;
                        txtNumberBuy.Enabled = true;
                        txtMeghdarAnbar.Enabled = true;
                        //txtMeghdarTaeed.Enabled = false;
                        grpCreate.Enabled = false;
                        //grd.Enabled = false;
                        strGrdEnable = "0";
                        grpDetail.Enabled = false;
                        //txtFrmDisagreement.Enabled = false;
                        //cmbVazieatKifi.Enabled = false;
                        //grd.Enabled = false;
                    }
                }
                if (strSend == "0")
                {
                    btnAdd.Enabled = false;
                    btnResidMovaghat.Enabled = false;
                    btnSabtHeader.Enabled = false;
                    btnUpdateHeader.Enabled = false;
                    grpDetail.Enabled = false;
                    //grd.Enabled = false;
                    strGrdEnable = "0";
                    btnSend.Enabled = false;
                    btnEnd.Enabled = false;
                    btnBack.Enabled = false;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        public FrmFLW_Tahvil_tatbigh()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ClsFlw obj = new ClsFlw();
                obj.IdTahvil_Tatbigh_H = strIdTahvil_Tatbigh_H;
                obj.CKala = strCkala;
                obj.ProcessGoods = txtProcessGoods.Text;
                obj.NumberBuy = txtNumberBuy.Text;
                obj.MeghdarTaeed = txtMeghdarTaeed.Text;
                obj.MeghdarMardood = txtMeghdarMardood.Text;
                obj.MeghdarErfagh = txtMeghdarErfagh.Text;
                obj.MeghdarVoroodi = txtMeghdarVoroodi.Text;
                obj.Kharid = cmbKharid.Text;
                obj.Jari = cmbJari.Text;
                MessageBox.Show(obj.Ins_Tahvil_Tatbigh_D());
                grd.DataSource = obj.Select_Tahvil_Tatbigh_D(strIdTahvil_Tatbigh_H).Tables[0];
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
                if (strGrdEnable == "0")
                {
                    MessageBox.Show("امکان تغییر وجود ندارد");
                    return;
                }
                if (strSend == "0")
                {
                    MessageBox.Show("امکان تایید وجود ندارد");
                    return;
                }
                if (e.Column.Name == "btnDelete")
                {
                    if (IntIdMarhale == "4")//QC
                    {
                        MessageBox.Show("امکان تغییر وجود ندارد");
                        return;
                    }
                    //if (strGrdEnable == "0")
                    //{
                    //    MessageBox.Show("امکان تغییر اطلاعات وجود ندارد");
                    //    return;
                    //}
                    ClsFlw obj = new ClsFlw();
                    if (MessageBox.Show("آیا از حذف ردیف اطمینان دارید؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        MessageBox.Show(obj.Delete_Tahvil_Tatbigh_D(grd.Rows[e.RowIndex].Cells["IdTahvil_Tatbigh_D"].Value.ToString()));

                    grd.DataSource = obj.Select_Tahvil_Tatbigh_D(strIdTahvil_Tatbigh_H).Tables[0];
                }
                if (e.Column.Name == "btnSelect")
                {
                    btnEditDetail.Enabled = true;
                    strIdTahvil_Tatbigh_D = grd.Rows[e.RowIndex].Cells["IdTahvil_Tatbigh_D"].Value.ToString();
                    txtNKala.Text = grd.Rows[e.RowIndex].Cells["N_Kala"].Value.ToString();
                    strCkala = grd.Rows[e.RowIndex].Cells["CKala"].Value.ToString();
                    txtMeghdarVoroodi.Text = grd.Rows[e.RowIndex].Cells["MeghdarVoroodi"].Value.ToString();
                    txtMeghdarAnbar.Text = grd.Rows[e.RowIndex].Cells["MeghdarAnbar"].Value.ToString();
                    txtMeghdarTaeed.Text = grd.Rows[e.RowIndex].Cells["MeghdarTaeed"].Value.ToString();
                    txtMeghdarMardood.Text = grd.Rows[e.RowIndex].Cells["MeghdarMardood"].Value.ToString();
                    txtMeghdarErfagh.Text = grd.Rows[e.RowIndex].Cells["MeghdarErfagh"].Value.ToString();
                    txtNumberBuy.Text = grd.Rows[e.RowIndex].Cells["NumberBuy"].Value.ToString();
                    txtProcessGoods.Text = grd.Rows[e.RowIndex].Cells["ProcessGoods"].Value.ToString();
                    cmbKharid.Text = grd.Rows[e.RowIndex].Cells["Kharid"].Value.ToString();
                    cmbJari.Text = grd.Rows[e.RowIndex].Cells["Jari"].Value.ToString();
                }
                if (e.Column.Name == "btnNamo")
                {
                    //strIdTahvil_Tatbigh_D = grd.Rows[e.RowIndex].Cells["IdTahvil_Tatbigh_D"].Value.ToString();
                    //txtNKala.Text = grd.Rows[e.RowIndex].Cells["N_Kala"].Value.ToString();
                    //strCkala = grd.Rows[e.RowIndex].Cells["CKala"].Value.ToString();
                    //txtMeghdar.Text = grd.Rows[e.RowIndex].Cells["Meghdar"].Value.ToString();
                    //txtNumberBuy.Text = grd.Rows[e.RowIndex].Cells["NumberBuy"].Value.ToString();
                    //txtProcessGoods.Text = grd.Rows[e.RowIndex].Cells["ProcessGoods"].Value.ToString();
                    //cmbVazieatKifi.SelectedIndex = Convert.ToInt32(grd.Rows[e.RowIndex].Cells["VazieatKifi"].Value);

                    FrmFLW_Noncompliance frm = new FrmFLW_Noncompliance();
                    frm.strIdTahvil_Tatbigh_D = grd.Rows[e.RowIndex].Cells["IdTahvil_Tatbigh_D"].Value.ToString();
                    frm.txtNKala.Text = grd.Rows[e.RowIndex].Cells["N_Kala"].Value.ToString();
                    frm.lblCkala.Text = grd.Rows[e.RowIndex].Cells["CKala"].Value.ToString();
                    frm.txtTracker.Text = txtResidMovaghat.Text;
                    frm.txtMeghdar.Text = grd.Rows[e.RowIndex].Cells["MeghdarMardood"].Value.ToString();
                    frm.txtWorkShop.Text = txtTamin.Text;
                    frm.txtDevice.Text = grd.Rows[e.RowIndex].Cells["ProcessGoods"].Value.ToString();
                    frm.ShowDialog();
                }
            }
            catch
            {

            }
        }

        private void grd_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            //try
            //{
            //    e.CellElement.DrawFill = true;
            //    e.CellElement.ForeColor = Color.Black;
            //    e.CellElement.NumberOfColors = 1;
            //    e.CellElement.BackColor = Color.White;

            //    if (grd.Rows[e.RowIndex].Cells["VazieatKifi"].Value.ToString() == "1")
            //    {
            //        e.CellElement.NumberOfColors = 1;
            //        e.CellElement.BackColor = Color.LightGreen;
            //    }
            //}
            //catch (Exception e1)
            //{
            //    MessageBox.Show(e1.ToString());
            //}
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
                obj.strID_Form = "3";
                obj.strCheckTaeed = "3";
                obj.strDescTaeed = txtErja.Text;
                obj.strIdTaeed = strIdTaeed;

                MessageBox.Show(obj.Update_FormFlowTaeed());
                obj.Update_FormFlowTaeedActive();
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
                if (IntIdMarhale == "4")
                {
                    ClsFlw obj = new ClsFlw();
                    obj.strValueVariable = cmbBuy.SelectedValue.ToString();
                    obj.strIdVariable = "9";
                    obj.Update_Variable();

                    obj.strValueVariable = "0";
                    obj.strIdVariable = "49";
                    obj.Update_Variable();

                    obj.strCheckTaeed = "2";
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Report objReport = new Report();

            objReport.Load(ClsPublic.strRepPath + "TahvilKala.frx");
            objReport.SetParameterValue("IdTahvil_Tatbigh_H", lbl_IDRequest.Text);
            objReport.Print();
        }

        private void btnResidMovaghat_Click(object sender, EventArgs e)
        {
            try
            {
                ClsFlw obj = new ClsFlw();
                obj.strDateEnter = txtDateEnter.Text;
                obj.strDriver = txtDriver.Text;
                obj.StrNumberCar = txtNumberCar.Text;
                obj.strNameTamin = txtTamin.Text;
                obj.strIndexAnbardar = cmbAnbardar.SelectedValue.ToString();
                obj.strIndexQC = cmbQC.SelectedValue.ToString();
                obj.strIndexBuy = cmbBuy.SelectedValue.ToString();
                obj.strIdResidMovaghat = txtResidMovaghat.Text;
                MessageBox.Show(obj.Update_Tahvil_Tatbigh_H(strIdTahvil_Tatbigh_H));
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        private void btnEditDetail_Click(object sender, EventArgs e)
        {
            ClsFlw obj = new ClsFlw();
            obj.ProcessGoods = txtProcessGoods.Text;
            obj.NumberBuy = txtNumberBuy.Text;
            obj.MeghdarTaeed = txtMeghdarTaeed.Text;
            obj.MeghdarMardood = txtMeghdarMardood.Text;
            obj.MeghdarErfagh = txtMeghdarErfagh.Text;
            obj.MeghdarVoroodi = txtMeghdarVoroodi.Text;
            obj.MeghdarAnbar = txtMeghdarAnbar.Text;
            obj.Kharid = cmbKharid.Text;
            obj.Jari = cmbJari.Text;

            obj.Update_Tahvil_Tatbigh_D(strIdTahvil_Tatbigh_D);
            grd.DataSource = obj.Select_Tahvil_Tatbigh_D(strIdTahvil_Tatbigh_H).Tables[0];
        }

        private void grd_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {

        }

        private void btnF2Moshtari_Click(object sender, EventArgs e)
        {
            FrmTafsili frm = new FrmTafsili();
            frm.ShowDialog();
            txtTamin.Text = frm.Ntafsili + '_' + frm.Ctifsili;
            //lblCtafsili.Text = frm.Ctifsili;
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
                    obj.strID_Form = "3";

                    obj.strValueVariable = cmbBuy.SelectedValue.ToString();
                    obj.strIdVariable = "9";
                    obj.Update_Variable();
                    //obj.strID_Unit = strIdUnit;
                    obj.strID_FormUnit = ClsFlw.ID_FormUnit;
                    obj.strCodeFormX = strIdTahvil_Tatbigh_H;
                    obj.Insert_CodeFormX();
                    obj.strIdCodeFormX = obj.Select_CodeFormXMax().Tables[0].Rows[0]["IdCodeFormX"].ToString();
                    obj.strTozihat = txtErja.Text;                   
                    MessageBox.Show(obj.Insert_FormFlowTaeed());

                    obj.strCheckTaeed = "1";
                    obj.strDescTaeed = txtErja.Text;
                    obj.strIdTaeed = obj.Select_TaeedMax().Tables[0].Rows[0][0].ToString();

                    obj.Update_FormFlowTaeed();
                    obj.Update_FormFlowTaeedActive();
                    this.Close();
                }
                else
                {
                    ClsFlw obj = new ClsFlw();
                    if (IntIdMarhale == "1")
                    {
                        obj.strValueVariable = cmbBuy.SelectedValue.ToString();
                        obj.strIdVariable = "9";
                        obj.Update_Variable();
                    }
                    if (IntIdMarhale == "3" | IntIdMarhale == "5")
                    {
                        obj.strValueVariable = cmbAnbardar.SelectedValue.ToString();
                        obj.strIdVariable = "10";
                        obj.Update_Variable();

                        obj.strValueVariable = cmbAnbardar.SelectedValue.ToString();
                        obj.strIdVariable = "23";
                        obj.Update_Variable();
                    }
                    if (IntIdMarhale == "4")
                    {
                        obj.strValueVariable = cmbQC.SelectedValue.ToString();
                        obj.strIdVariable = "11";
                        obj.Update_Variable();

                        obj.strValueVariable = "1";
                        obj.strIdVariable = "49";
                        obj.Update_Variable();
                    }
                    if (IntIdMarhale == "5")
                    {
                        obj.strIdTahvil_Tatbigh_H = lbl_IDRequest.Text;
                        //if (obj.Select_TaeedKala().Tables[0].Rows[0][0].ToString() == "0")
                        //    obj.strValueVariable = "0";
                        //else
                        //    obj.strValueVariable = "1";
                        //obj.strIdVariable = "12";
                        //obj.Update_Variable();                       
                    }
                    //if (IntIdMarhale == "6")
                    //{
                        
                    //}

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

        private void btnF2Kala_Click(object sender, EventArgs e)
        {
            FrmKala frm = new FrmKala();
            //frm.strC_Anbar = "13,14,19,16";
            frm.ShowDialog();
            txtNKala.Text = ClsBuy.N_kala;
            strCkala = ClsBuy.C_kala;
            lblUnitKala.Text = ClsBuy.strN_Vahed;
        }
        public void SetCmb()
        {
            DataColumn dc;
            DataRow dr;
            DataTable dt = new DataTable();

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
            dr3["item"] = "آقای پازیان";
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

            dr3 = dt3.NewRow();
            dr3["item"] = "آقای رحمانی";
            dr3["id"] = "5";
            dt3.Rows.Add(dr3);

            dr3 = dt3.NewRow();
            dr3["item"] = "آقای سجادی";
            dr3["id"] = "6";
            dt3.Rows.Add(dr3);

            dr3 = dt3.NewRow();
            dr3["item"] = "آقای طاهری";
            dr3["id"] = "7";
            dt3.Rows.Add(dr3);

            dr3 = dt3.NewRow();
            dr3["item"] = "آقای رومی";
            dr3["id"] = "8";
            dt3.Rows.Add(dr3);

            dr3 = dt3.NewRow();
            dr3["item"] = "آقای حیدری";
            dr3["id"] = "9";
            dt3.Rows.Add(dr3);

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
            dr4["item"] = "آقای پارسا";
            dr4["id"] = "2";
            dt4.Rows.Add(dr4);

            dr4 = dt4.NewRow();
            dr4["item"] = "آقای حیدری";
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
        public void ShowData()
        {
            try
            {
                ClsFlw obj = new ClsFlw();
                obj.strCodeFormX = strIdTahvil_Tatbigh_H;
                lbl_IDRequest.Text = obj.strCodeFormX;
                dt = obj.Select_Tahvil_Tatbigh_H(strIdTahvil_Tatbigh_H).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    cmbAnbardar.SelectedValue = Convert.ToInt32(dt.Rows[0]["IndexAnbardar"].ToString());
                    cmbQC.SelectedValue = Convert.ToInt32(dt.Rows[0]["IndexQC"].ToString());
                    cmbBuy.SelectedValue = Convert.ToInt32(dt.Rows[0]["IndexBuy"].ToString());
                    txtDateEnter.Text = dt.Rows[0]["DateEnter"].ToString();
                    txtTamin.Text = dt.Rows[0]["NameTamin"].ToString();
                    txtDriver.Text = dt.Rows[0]["Driver"].ToString();
                    txtNumberCar.Text = dt.Rows[0]["NumberCar"].ToString();
                    txtResidMovaghat.Text = dt.Rows[0]["IdResidMovaghat"].ToString();
                    txtIdKhorooji.Text = dt.Rows[0]["IdKhorooj"].ToString();
                    txtHavale.Text = dt.Rows[0]["IdHavale"].ToString();

                    grd.DataSource = obj.Select_Tahvil_Tatbigh_D(strIdTahvil_Tatbigh_H).Tables[0];
                }
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
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
                    if (strControl == "FrmFLW_Tahvil_tatbigh")
                    {
                        if (DtControlAccess.Rows[i]["id_user"].ToString() == ClsMain.IDUser & DtControlAccess.Rows[i]["isActive"] != null)
                            TahvilAccess = 1;
                        else
                            TahvilAccess = 0;
                    }                   
                }
            }
            ////--------------------------
        }
    }
}

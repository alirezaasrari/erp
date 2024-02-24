using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace ET
{
    public partial class FrmFLW_Noncompliance : Telerik.WinControls.UI.RadForm
    {
        public string strIdNoncomplianceH, strCkala, strIdTahvil_Tatbigh_D;
        public string strIdTahvil_Tatbigh_H, strSend, IntIdFormChart, IntIdMarhale, IntLevelTaeed, strGrdEnable, strID_FormUnit, strIdTaeed, strInbox, strID_PersonelChart;
        public int AccessGrdH = 0, AccessGrdUnit = 0;
        
        private void btnUpdateHeader2_Click(object sender, EventArgs e)
        {
            try
            {            
                ClsFlw obj = new ClsFlw();
                obj.ShoNoneComolaince = txtShoNoneComolaince.Text; 
                obj.Type_ = cmbType.Text;
                obj.DateH = txtDate.Text;
                obj.Stage = cmbLevel.Text;
                obj.TimeH = txtTime.Text;
                obj.Inspector = txtInspector.Text;
                obj.Tracker = txtTracker.Text;
                obj.CKala = lblCkala.Text;
                obj.Meghdar = txtMeghdar.Text;
                obj.WorkShop = txtWorkShop.Text;
                obj.Device = txtDevice.Text;
                obj.CommandQualityExp = txtCommandQualityExp.Text;
                obj.CommentQualityMng = cmbCommentQualityMng.Text;
                obj.CommentAny = txtCommentAny.Text;
                obj.Confirmn = (chkConfirm.Checked) ? "1" : "0";
                obj.DesMng = txtDesMng.Text;
                obj.Reason = cmbReason.Text;
                obj.Constrast = cmbConstrast.Text;
                obj.DesTerms = txtDesTerms.Text;
                obj.Action_ = cmbAction.Text;
                obj.DesTermsDo = txtDesTermsDo.Text;
                obj.Renewal = (chkRenewal.Checked) ? "1" : "0";
                obj.ResultToQC = (chkResultToQC.Checked) ? "1" : "0";
                obj.StrIdUnitTaeed = "0";
                MessageBox.Show(obj.Update_NoneComolaince_H(strIdNoncomplianceH));
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        private void cmbUnit_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void txtShoNoneComolaince_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void btnF2Kala_Click(object sender, EventArgs e)
        {
            FrmKala frm = new FrmKala();
            //frm.strC_Anbar = "13,14,19,16";
            frm.ShowDialog();
            txtNKala.Text = ClsBuy.N_kala;
            strCkala = ClsBuy.C_kala;
            lblCkala.Text = ClsBuy.C_kala;
        }

        private void btnUpdateHeader_Click(object sender, EventArgs e)
        {
            try
            {
                ClsFlw obj = new ClsFlw();
                
                obj.ShoNoneComolaince = txtShoNoneComolaince.Text;
                obj.Type_ = cmbType.Text;
                obj.DateH = txtDate.Text;
                obj.Stage = cmbLevel.Text;
                obj.TimeH = txtTime.Text;
                obj.Inspector = txtInspector.Text;
                obj.Tracker = txtTracker.Text;
                obj.CKala = lblCkala.Text;
                obj.Meghdar = txtMeghdar.Text;
                obj.WorkShop = txtWorkShop.Text;
                obj.Device = txtDevice.Text;
                obj.CommandQualityExp = txtCommandQualityExp.Text;
                obj.CommentQualityMng = cmbCommentQualityMng.Text;
                obj.CommentAny = txtCommentAny.Text;
                obj.Confirmn = (chkConfirm.Checked) ? "1" : "0";
                obj.DesMng = txtDesMng.Text;
                obj.Reason = cmbReason.Text;
                obj.Constrast = cmbConstrast.Text;
                obj.DesTerms = txtDesTerms.Text;
                obj.Action_ = cmbAction.Text;
                obj.DesTermsDo = txtDesTermsDo.Text;
                obj.Renewal = (chkRenewal.Checked) ? "1" : "0";
                obj.ResultToQC = (chkResultToQC.Checked) ? "1" : "0";
                obj.StrIdUnitTaeed = CmbUnitTaeed.SelectedValue.ToString();
                MessageBox.Show(obj.Update_NoneComolaince_H(strIdNoncomplianceH));
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
                obj.ShoNoneComolaince = txtShoNoneComolaince.Text;
                obj.Type_ = cmbType.Text;
                obj.DateH = txtDate.Text;
                obj.Stage = cmbLevel.Text;
                obj.TimeH = txtTime.Text;
                obj.Inspector = txtInspector.Text;
                obj.Tracker = txtTracker.Text;
                obj.CKala = lblCkala.Text;
                obj.Meghdar = txtMeghdar.Text;
                obj.WorkShop = txtWorkShop.Text;
                obj.Device = txtDevice.Text;
                obj.CommandQualityExp = txtCommandQualityExp.Text;
                obj.CommentQualityMng = cmbCommentQualityMng.Text;
                obj.CommentAny = txtCommentAny.Text;
                obj.Confirmn = (chkConfirm.Checked) ? "1" : "0";
                obj.Reason = cmbReason.Text;
                obj.Constrast = cmbConstrast.Text;
                obj.DesTerms = txtDesTerms.Text;
                obj.Action_ = cmbAction.Text;
                obj.DesTermsDo = txtDesTermsDo.Text;
                obj.Renewal = (chkRenewal.Checked) ? "1" : "0";
                
                if(lblCkala.Text== "_")
                {
                    RadMessageBox.Show("یک کالا انتخاب کنید");
                    return;
                }
                //obj.strIdTahvil_Tatbigh_D = strIdTahvil_Tatbigh_D;
                obj.strIdTahvil_Tatbigh_D = "0";
                MessageBox.Show(obj.Ins_NoneComolaince_H());
                //grpDetail.Enabled = true;
                strIdNoncomplianceH = obj.Select_NoneComolaince_HMax().Tables[0].Rows[0][0].ToString();
                lblIdNoncompliance.Text = strIdNoncomplianceH;
                btnUpdateHeader.Enabled = true;
                txtShoNoneComolaince.Text = strIdNoncomplianceH;
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
                SetCmb();
                txtDate.Value = DateTime.Now;
                DataTable dt = new DataTable();
                ClsFlw obj = new ClsFlw();
                if (strIdNoncomplianceH == null)
                    strIdNoncomplianceH = "-1";
                dt = obj.Select_NamoHeader(strIdNoncomplianceH).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    lblIdNoncompliance.Text = dt.Rows[0]["IdNoneComolaince"].ToString();
                    strIdNoncomplianceH = lblIdNoncompliance.Text;
                    grpDetail.DataSource = obj.Select_NoneComolaince_D1(lblIdNoncompliance.Text).Tables[0];
                    grpDetail1.DataSource = obj.Select_NoneComolaince_D2(lblIdNoncompliance.Text).Tables[0];
                    cmbType.Text = dt.Rows[0]["Type_"].ToString();
                    cmbLevel.Text = dt.Rows[0]["Stage"].ToString();
                    txtDate.Text = dt.Rows[0]["DateH"].ToString();
                    txtTime.Text = dt.Rows[0]["TimeH"].ToString();
                    txtInspector.Text = dt.Rows[0]["Inspector"].ToString();
                    txtTracker.Text = dt.Rows[0]["Tracker"].ToString();
                    txtNKala.Text = dt.Rows[0]["N_Kala"].ToString();
                    lblCkala.Text = dt.Rows[0]["CKala"].ToString();
                    txtMeghdar.Text = dt.Rows[0]["Meghdar"].ToString();
                    txtWorkShop.Text = dt.Rows[0]["WorkShop"].ToString();
                    txtDevice.Text = dt.Rows[0]["Device"].ToString();
                    txtCommandQualityExp.Text = dt.Rows[0]["CommandQualityExp"].ToString();
                    cmbCommentQualityMng.Text = dt.Rows[0]["CommentQualityMng"].ToString();
                    txtCommentAny.Text = dt.Rows[0]["CommentAny"].ToString();
                    txtDesMng.Text = dt.Rows[0]["DesMng"].ToString();
                    cmbReason.Text = dt.Rows[0]["Reason"].ToString();
                    cmbConstrast.Text = dt.Rows[0]["Constrast"].ToString();
                    cmbAction.Text = dt.Rows[0]["Action_"].ToString();
                    txtDesTerms.Text = dt.Rows[0]["DesTerms"].ToString();
                    txtDesTermsDo.Text = dt.Rows[0]["DesTermsDo"].ToString();
                    chkConfirm.Checked = Convert.ToBoolean(dt.Rows[0]["Confirmn"].ToString());
                    chkRenewal.Checked = Convert.ToBoolean(dt.Rows[0]["Renewal"].ToString());
                    chkResultToQC.Checked = Convert.ToBoolean(dt.Rows[0]["ResultToQC"].ToString());
                    txtShoNoneComolaince.Text = dt.Rows[0]["IdNoneComolaince"].ToString();
                    CmbUnitTaeed.SelectedValue = dt.Rows[0]["IdUnitTaeed"];
                }
                if (strInbox == "1")
                {
                    btnSabtHeader.Enabled = false;
                    btnUpdateHeader.Enabled = true;
                    txtCommandQualityExp.Enabled = false;
                    //cmbCommentQualityMng.Enabled = false;
                    //txtCommentAny.Enabled = false;
                }
                if (IntIdMarhale == "1")
                {
                    txtCommandQualityExp.Enabled = false;
                    //cmbCommentQualityMng.Enabled = false;
                    //txtCommentAny.Enabled = false;
                }
                AccessGrdUnit = 1;
                AccessGrdH = 1;
                if (IntIdMarhale == "3")//واحدها
                {
                    txtCommandQualityExp.Enabled = false;
                    //cmbCommentQualityMng.Enabled = false;
                    //txtCommentAny.Enabled = false;
                    btnSabtHeader.Enabled = false;
                    AccessGrdH = 0;
                    btnUpdateHeader.Enabled = false;
                }
                if (Convert.ToInt16(IntIdMarhale) == 4)
                {
                    btnSabtHeader.Enabled = false;
                    AccessGrdUnit = 0;
                    AccessGrdH = 0;
                    grpEnd.Enabled = true;
                    grpUnits.Enabled = false;
                    grpCreate.Enabled = false;
                    btnUpdateHeader.Enabled = true;
                    btnUpdateHeader2.Enabled = false;
                    txtCommandQualityExp.Enabled = false;
                    cmbCommentQualityMng.Enabled = false;
                    txtCommentAny.Enabled = false;
                }
                if (Convert.ToInt16(IntIdMarhale) > 4)
                {
                    btnSabtHeader.Enabled = false;
                    AccessGrdUnit = 0;
                    AccessGrdH = 0;
                    grpEnd.Enabled = false;
                    grpUnits.Enabled = false;
                    grpCreate.Enabled = false;
                    btnUpdateHeader.Enabled = false;
                    btnUpdateHeader2.Enabled = false;
                    txtCommandQualityExp.Enabled = false;
                    //cmbCommentQualityMng.Enabled = false;
                    //txtCommentAny.Enabled = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
                       
        }
        public FrmFLW_Noncompliance()
        {
            InitializeComponent();
            //Random random = new Random();
            //var rand = random.Next(1000, 9999);
            //txtShoNoneComolaince.Text = rand.ToString();
        }

        private void grpDetail_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {            
            try
            {
                if (e.Column.Name == "btnDelete")
                {
                    if (AccessGrdH != 1)
                    {
                        MessageBox.Show("دسترسی وجود ندارد");
                        return;
                    }
                    //if (strSend == "0")
                    //{
                    //    MessageBox.Show("امکان تغییر وجود ندارد");
                    //    return;
                    //}
                    //if (strGrdEnable == "0")
                    //{
                    //    MessageBox.Show("امکان تغییر اطلاعات وجود ندارد");
                    //    return;
                    //}

                    if (MessageBox.Show("آیا از حذف ردیف اطمینان دارید؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ClsFlw obj = new ClsFlw();
                        obj.IdD1 = grpDetail.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                        MessageBox.Show(obj.Delete_NoneComolaince_D1());
                        obj.IdH = strIdNoncomplianceH;
                        grpDetail.DataSource = obj.Select_NoneComolaince_D1(lblIdNoncompliance.Text).Tables[0];
                    }
                }
                if (e.Column.Name == "btnDoc")
                {
                    FrmFLW_NoncomplianceDoc frm = new FrmFLW_NoncomplianceDoc();
                    frm.AccessGrdH = AccessGrdH;
                    frm.IdNoneComolainceD = grpDetail.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                    frm.ShowDialog();
                }
            }
            catch
            {

            }
        }

        private void grpDetail1_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            int validUnit = 0;
            if (AccessGrdUnit != 1 | strID_PersonelChart != ClsMain.strIdPersonelChart)
            {
                MessageBox.Show("دسترسی وجود ندارد");
                return;
            }
            if (strID_PersonelChart == "292" & grpDetail1.Rows[e.RowIndex].Cells["UnitIndex"].Value.ToString() == "0")
            {
                validUnit = 1;
            }
            if (strID_PersonelChart == "413" & grpDetail1.Rows[e.RowIndex].Cells["UnitIndex"].Value.ToString() == "1")
            {
                validUnit = 1;
            }
            if (strID_PersonelChart == "27" & grpDetail1.Rows[e.RowIndex].Cells["UnitIndex"].Value.ToString() == "2")
            {
                validUnit = 1;
            }
            if (strID_PersonelChart == "303" & grpDetail1.Rows[e.RowIndex].Cells["UnitIndex"].Value.ToString() == "3")
            {
                validUnit = 1;
            }
            if (strID_PersonelChart == "301" & grpDetail1.Rows[e.RowIndex].Cells["UnitIndex"].Value.ToString() == "4")
            {
                validUnit = 1;
            }
            if (strID_PersonelChart == "271" & grpDetail1.Rows[e.RowIndex].Cells["UnitIndex"].Value.ToString() == "5")
            {
                validUnit = 1;
            }
            if (strID_PersonelChart == "355" & grpDetail1.Rows[e.RowIndex].Cells["UnitIndex"].Value.ToString() == "6")
            {
                validUnit = 1;
            }
            if (strID_PersonelChart == "117" & grpDetail1.Rows[e.RowIndex].Cells["UnitIndex"].Value.ToString() == "7")
            {
                validUnit = 1;
            }
            if (strID_PersonelChart == "28" & grpDetail1.Rows[e.RowIndex].Cells["UnitIndex"].Value.ToString() == "8")
            {
                validUnit = 1;
            }
            if (strID_PersonelChart == "283" & grpDetail1.Rows[e.RowIndex].Cells["UnitIndex"].Value.ToString() == "9")
            {
                validUnit = 1;
            }
            if (strID_PersonelChart == "280" & grpDetail1.Rows[e.RowIndex].Cells["UnitIndex"].Value.ToString() == "10")
            {
                validUnit = 1;
            }
            if (strID_PersonelChart == "284" & grpDetail1.Rows[e.RowIndex].Cells["UnitIndex"].Value.ToString() == "11")
            {
                validUnit = 1;
            }
            if (validUnit != 1 & strID_PersonelChart != "381")
            {
                MessageBox.Show("دسترسی وجود ندارد");
                return;
            }
            try
            {
                if (e.Column.Name == "btnDelete")
                {
                    //if (strSend == "0")
                    //{
                    //    MessageBox.Show("امکان تغییر وجود ندارد");
                    //    return;
                    //}
                    //if (strGrdEnable == "0")
                    //{
                    //    MessageBox.Show("امکان تغییر اطلاعات وجود ندارد");
                    //    return;
                    //}
                    
                    if (MessageBox.Show("آیا از حذف ردیف اطمینان دارید؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ClsFlw obj = new ClsFlw();
                        obj.IdD2 = grpDetail1.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                        MessageBox.Show(obj.Delete_NoneComolaince_D2());
                        obj.IdH = strIdNoncomplianceH;
                        grpDetail1.DataSource = obj.Select_NoneComolaince_D2(lblIdNoncompliance.Text).Tables[0];
                    }                                      
                }
                if (e.Column.Name == "btnEdit")
                {
                    ClsFlw obj = new ClsFlw();
                    MessageBox.Show(obj.Update_NoneComolaince_D2(grpDetail1.Rows[e.RowIndex].Cells["Id"].Value.ToString(), grpDetail1.Rows[e.RowIndex].Cells["Fix"].Value.ToString()));
                    obj.IdH = strIdNoncomplianceH;
                    grpDetail1.DataSource = obj.Select_NoneComolaince_D2(lblIdNoncompliance.Text).Tables[0];
                }
            }
            catch
            {

            }
        }

        private void grpDetail_UserAddedRow(object sender, Telerik.WinControls.UI.GridViewRowEventArgs e)
        {
          
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

                    obj.strID_FormUnit = "10";
                    obj.strCodeFormX = lblIdNoncompliance.Text;
                    obj.Insert_CodeFormX();
                    obj.strIdCodeFormX = obj.Select_CodeFormXMax().Tables[0].Rows[0]["IdCodeFormX"].ToString();
                    obj.strTozihat = txtErja.Text;
                    MessageBox.Show(obj.Insert_FormFlowTaeed());

                    obj.strCheckTaeed = "0";
                    obj.strDescTaeed = txtErja.Text;
                    obj.strIdTaeed = obj.Select_TaeedMax().Tables[0].Rows[0][0].ToString();

                    obj.Update_FormFlowTaeed();
                    //obj.Update_FormFlowTaeedActive();
                    this.Close();
                }
                else
                {
                    ClsFlw obj = new ClsFlw();
                    if (IntIdMarhale == "1" )
                    {
                        obj.strValueVariable = Convert.ToInt16(chkConfirm.Checked).ToString();
                        obj.strIdVariable = "13";
                        obj.Update_Variable();
                    }
                    if (IntIdMarhale == "1" | IntIdMarhale == "3")
                    {
                        if (obj.Select_NoneComolaince_D2Find(strIdNoncomplianceH, "0").Tables[0].Rows.Count > 0)
                            obj.strValueVariable = "1";//tolid
                        else
                            obj.strValueVariable = "0";
                        obj.strIdVariable = "14";
                        obj.Update_Variable();

                        if (obj.Select_NoneComolaince_D2Find(strIdNoncomplianceH, "1").Tables[0].Rows.Count > 0)
                            obj.strValueVariable = "1";//تدارکات
                        else
                            obj.strValueVariable = "0";
                        obj.strIdVariable = "15";
                        obj.Update_Variable();

                        if (obj.Select_NoneComolaince_D2Find(strIdNoncomplianceH, "2").Tables[0].Rows.Count > 0)
                            obj.strValueVariable = "1";//مهندسی
                        else
                            obj.strValueVariable = "0";
                        obj.strIdVariable = "16";
                        obj.Update_Variable();

                        if (obj.Select_NoneComolaince_D2Find(strIdNoncomplianceH, "3").Tables[0].Rows.Count > 0)
                            obj.strValueVariable = "1";//r&d
                        else
                            obj.strValueVariable = "0";
                        obj.strIdVariable = "17";
                        obj.Update_Variable();

                        if (obj.Select_NoneComolaince_D2Find(strIdNoncomplianceH, "4").Tables[0].Rows.Count > 0)
                            obj.strValueVariable = "1";//Sale khosoosi
                        else
                            obj.strValueVariable = "0";
                        obj.strIdVariable = "18";
                        obj.Update_Variable();

                        if (obj.Select_NoneComolaince_D2Find(strIdNoncomplianceH, "5").Tables[0].Rows.Count > 0)
                            obj.strValueVariable = "1";//sale dolati
                        else
                            obj.strValueVariable = "0";
                        obj.strIdVariable = "19";
                        obj.Update_Variable();

                        if (obj.Select_NoneComolaince_D2Find(strIdNoncomplianceH, "6").Tables[0].Rows.Count > 0)
                            obj.strValueVariable = "1";//planning
                        else
                            obj.strValueVariable = "0";
                        obj.strIdVariable = "20";
                        obj.Update_Variable();

                        if (obj.Select_NoneComolaince_D2Find(strIdNoncomplianceH, "7").Tables[0].Rows.Count > 0)
                            obj.strValueVariable = "1";//بازرسی
                        else
                            obj.strValueVariable = "0";
                        obj.strIdVariable = "24";
                        obj.Update_Variable();

                        if (obj.Select_NoneComolaince_D2Find(strIdNoncomplianceH, "8").Tables[0].Rows.Count > 0)
                            obj.strValueVariable = "1";//کنتور
                        else
                            obj.strValueVariable = "0";
                        obj.strIdVariable = "59";
                        obj.Update_Variable();

                        if (obj.Select_NoneComolaince_D2Find(strIdNoncomplianceH, "9").Tables[0].Rows.Count > 0)
                            obj.strValueVariable = "1";//کارگاه فورج
                        else
                            obj.strValueVariable = "0";
                        obj.strIdVariable = "63";
                        obj.Update_Variable();

                        if (obj.Select_NoneComolaince_D2Find(strIdNoncomplianceH, "10").Tables[0].Rows.Count > 0)
                            obj.strValueVariable = "1";//کارگاه تزریق
                        else
                            obj.strValueVariable = "0";
                        obj.strIdVariable = "64";
                        obj.Update_Variable();

                        if (obj.Select_NoneComolaince_D2Find(strIdNoncomplianceH, "11").Tables[0].Rows.Count > 0)
                            obj.strValueVariable = "1";//کارگاه ریخته گری
                        else
                            obj.strValueVariable = "0";
                        obj.strIdVariable = "65";
                        obj.Update_Variable();
                    }
                    if (IntIdMarhale == "4")
                    {
                        if (chkConfirm.Checked == true)
                            obj.strValueVariable = "1";//تایید مدیر عامل
                        else
                            obj.strValueVariable = "0";
                        obj.strIdVariable = "21";
                        obj.Update_Variable();
                    }
                    if (IntIdMarhale == "6")
                    {
                        obj.strValueVariable = obj.Select_NamoHeaderTahvilH(lblIdNoncompliance.Text).Tables[0].Rows[0]["IndexAnbardar"].ToString();
                        obj.strIdVariable = "25";
                        obj.Update_Variable();
                    }

                    obj.strCheckTaeed = "1";
                    obj.strDescTaeed = txtErja.Text;
                    obj.strIdTaeed = strIdTaeed;

                    MessageBox.Show(obj.Update_FormFlowTaeed());
                    obj.Update_FormFlowTaeedActive();

                    obj.strIdTaeed = obj.Select_TaeedMax().Tables[0].Rows[0][0].ToString();
                    obj.strIdPersonelChart = CmbUnitTaeed.SelectedValue.ToString();
                    obj.Update_FormFlowTaeedPersonelChart();

                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (AccessGrdUnit != 1)
            {
                MessageBox.Show("دسترسی وجود ندارد");
                return;
            }
            ClsFlw obj = new ClsFlw();
            obj.Unit = cmbUnit.Text;
            obj.UnitIndex = cmbUnit.SelectedIndex.ToString();
            obj.strNazarQC = txtFix.Text;
            obj.IdH = lblIdNoncompliance.Text;
            MessageBox.Show(obj.Ins_NoneComolaince_D2());
            grpDetail1.DataSource = obj.Select_NoneComolaince_D2(lblIdNoncompliance.Text).Tables[0];
        }

        private void grpDetail_UserAddingRow(object sender, GridViewRowCancelEventArgs e)
        {
            try
            {
                ClsFlw obj = new ClsFlw();
                obj.Contradiction = grpDetail.CurrentRow.Cells["Contradiction"].Value.ToString();
                obj.Grade = grpDetail.CurrentRow.Cells["Grade"].Value.ToString();
                obj.MegMax = grpDetail.CurrentRow.Cells["MegMax"].Value.ToString();
                obj.MegMin = grpDetail.CurrentRow.Cells["MegMin"].Value.ToString();
                obj.Range_ = grpDetail.CurrentRow.Cells["Range_"].Value.ToString();
                obj.SampleNumber = grpDetail.CurrentRow.Cells["SampleNumber"].Value.ToString();
                obj.CountNon_ = grpDetail.CurrentRow.Cells["CountNon_"].Value.ToString();
                obj.Command = grpDetail.CurrentRow.Cells["Command"].Value.ToString();
                obj.IdH = lblIdNoncompliance.Text; ;
                MessageBox.Show(obj.Ins_NoneComolaince_D1());
                grpDetail.Rows.AddNew();
                grpDetail.DataSource = obj.Select_NoneComolaince_D1(lblIdNoncompliance.Text).Tables[0];
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
                return;
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
            dr["item"] = "واحد مهندسی";
            dr["id"] = "27";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["item"] = "واحد تحقیق و توسعه";
            dr["id"] = "303";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["item"] = "واحد فروش خصوصی";
            dr["id"] = "301";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["item"] = "واحد فروش دولتی";
            dr["id"] = "271";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["item"] = " واحد برنامه ریزی";
            dr["id"] = "355";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["item"] = " واحد  بازرسی";
            dr["id"] = "117";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["item"] = " واحد کنتور";
            dr["id"] = "28";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["item"] = " واحد تولید";
            dr["id"] = "292";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["item"] = " واحد تدارکات";
            dr["id"] = "413";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["item"] = " واحد فورج";
            dr["id"] = "283";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["item"] = " واحد تزریق";
            dr["id"] = "280";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["item"] = " واحد ریخته گری";
            dr["id"] = "284";
            dt.Rows.Add(dr);

            CmbUnitTaeed.DataSource = dt;
            CmbUnitTaeed.ValueMember = "id";
            CmbUnitTaeed.DisplayMember = "item";
        }
    }
}

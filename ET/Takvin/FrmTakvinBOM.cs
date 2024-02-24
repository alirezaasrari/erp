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
    public partial class FrmTakvinBOM : Telerik.WinControls.UI.RadForm
    {
        public FrmTakvinBOM()
        {
            InitializeComponent();
        }
        ClsTakvin objTakvin = new ClsTakvin();
        public string StrID_BOM;
        public decimal intBeforMavadDarsad = 0;

        private void ClearBOM()
        {
            btnAddBom.Enabled = true;
            btnDelBom.Enabled = false;
            btnUpdBom.Enabled = false;
            btnAddMavad.Enabled = false;
            btnDelMavad.Enabled = false;
            btnUpdMavad.Enabled = false;
            chkBOMTaeed.Enabled = false;
            chkBOMTaeed.Checked = false;
            GrdBOM.DataSource = null;

            txtID_Bom.Clear();
            StrID_BOM = "";
            objTakvin.StrID_Bom = "";
            txtNameBom.Clear();
            cmbVahedsanjeshBom.SelectedIndex = 0;

            txtMavadCode.Enabled = true;
            txtMavadAnabr.Enabled = true;
            txtMavadName.Enabled = true;
            txtMavadCode.Clear();
            txtMavadAnabr.Clear();
            txtMavadName.Clear();

            SEdtMavadDarsad.Value = 100;


        }
        private void ClearDBOM()
        {
            txtMavadCode.Clear();
            txtMavadAnabr.Clear();
            txtMavadName.Clear();
            txtMavadCode.Enabled = true;
            txtMavadAnabr.Enabled = true;
            txtMavadName.Enabled = true;
            SEdtMavadDarsad.Value = 100;

            btnAddMavad.Enabled = true;
            btnUpdMavad.Enabled = false;
            btnDelMavad.Enabled = false;
        }
        private void txtMavadCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                StrID_BOM = txtID_Bom.Text.Trim();
                objTakvin.StrID_Bom = StrID_BOM;
                if (string.IsNullOrEmpty(StrID_BOM))
                {
                    RadMessageBox.Show(" کد ترکیب مواد را وارد نمایید");
                    return;
                }
                FrmKala frmK = new FrmKala();
                frmK.strC_Anbar = "10";     // anbar ghaleb va abzar
                frmK.ShowDialog();
                txtMavadCode.Text = (!string.IsNullOrEmpty(ClsPublic.C_kala) ? ClsPublic.C_kala : txtMavadCode.Text.Trim());
                txtMavadName.Text = (!string.IsNullOrEmpty(ClsPublic.N_kala) ? ClsPublic.N_kala : txtMavadName.Text.Trim());
                txtMavadAnabr.Text = (!string.IsNullOrEmpty(ClsPublic.C_Anbar) ? ClsPublic.C_Anbar : txtMavadAnabr.Text.Trim());

                //if (!string.IsNullOrEmpty(txtMavadCode.Text.Trim()))
                //{
                //    if ((100 - objTakvin.BOMSumMavadDarsad())==0)
                //    {
                //        RadMessageBox.Show(" مقدار درصد مواد برابر 100 است مواد دیگری نمی توان به آن اضافه کرد");
                        
                //    }
                //    else
                //    {
                        SEdtMavadDarsad.Value = 100 - objTakvin.BOMSumMavadDarsad();
                //    }
                    
                //}
                
               
            
                //txtMotealegatCode.ReadOnly = (!string.IsNullOrEmpty(ClsPublic.C_kala) ? true : false);
                //txtMotealegatName.ReadOnly = (!string.IsNullOrEmpty(ClsPublic.N_kala) ? true : false);
            }
        }

        private void FrmTakvinBOM_Load(object sender, EventArgs e)
        {
            cmbVahedsanjeshBom.SelectedIndex = 0;
            ClearBOM();
        }

        private void btnAddBom_Click(object sender, EventArgs e)
        {
            if ( txtNameBom.Text.Trim() == "")
            {
                RadMessageBox.Show(" نام ترکیب مواد را وارد نمایید");
                return;
            }
            if (cmbVahedsanjeshBom.Text.Trim() == "" || cmbVahedsanjeshBom.SelectedIndex != 0)
            {
                RadMessageBox.Show(" واحد سنجش را مشخص نمایید");
                return;
            }
            objTakvin.StrNameBom = txtNameBom.Text.Trim();
            objTakvin.StrFK_Vahedsanjesh = (cmbVahedsanjeshBom.SelectedIndex == 0 ? "1" : "0");  //gram
            objTakvin.StrDescBom = txtDescBom.Text.Trim();
            try
            {

                DataTable dtInsHBOM = objTakvin.InsHBOM().Tables[0];
                if (dtInsHBOM.Rows[0]["Return Value"].ToString() == "0")
                {
                    RadMessageBox.Show(" این نام برای ترکیب مواد تکراری است ");
                    return;
                }
                else
                {
                    StrID_BOM = dtInsHBOM.Rows[0]["Return Value"].ToString();
                    objTakvin.StrID_Bom = StrID_BOM;
                    txtID_Bom.Text = StrID_BOM;
                    RadMessageBox.Show("نام ترکیب مواد ثبت شد \n"+"لطفا مواد آن را نیز ثبت نمایید");

                    chkBOMTaeed.Enabled = true;
                    btnAddBom.Enabled = false;
                    btnDelBom.Enabled = true;
                    btnUpdBom.Enabled = true;
                    btnAddMavad.Enabled = true;

                }
            }
            catch (Exception exp)
            {
                RadMessageBox.Show("خطا در اجرای عملیات \n" + exp.Message);
            }


        }

        private void btnDelBom_Click(object sender, EventArgs e)
        {
            StrID_BOM = txtID_Bom.Text.Trim();
            objTakvin.StrID_Bom = StrID_BOM;
            
            if (string.IsNullOrEmpty(StrID_BOM))
            {
                RadMessageBox.Show(" ترکیب مواد را تعیین نمایید");
                return;
            }
            if (objTakvin.SelectBomMavad().Tables[0].Rows.Count > 0)
            {
                RadMessageBox.Show("این ترکیب دارای مواد است");
                return;
            }
            if (objTakvin.SelectBomGheteh("", "1").Tables[0].Rows.Count > 0)
            {
                RadMessageBox.Show("این ترکیب مواد در قطعات استفاده شده است");
                return;
            }
            try
            {
                
                if (RadMessageBox.Show(this, "آیا مطمئن هستید این ترکیب مواد پاک شود؟", "", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation, MessageBoxDefaultButton.Button3, RightToLeft.Yes) == DialogResult.Yes)
                {
                    RadMessageBox.Show(objTakvin.DelHBOM());

                    ClearBOM();

                }

            }
            catch (Exception exp)
            {
                RadMessageBox.Show("خطا در اجرای عملیات \n" + exp.Message);
            }

        }

        private void btnClearBom_Click(object sender, EventArgs e)
        {
            ClearBOM();
        }

        private void btnUpdBom_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID_Bom.Text.Trim()))
            {
                RadMessageBox.Show(" ترکیب مواد را تعیین نمایید");
                return;
            }
            StrID_BOM = txtID_Bom.Text.Trim();
            objTakvin.StrID_Bom = StrID_BOM;
            objTakvin.StrNameBom = txtNameBom.Text.Trim();
            objTakvin.StrDescBom = txtDescBom.Text.Trim();
            objTakvin.StrFK_Vahedsanjesh = (cmbVahedsanjeshBom.SelectedIndex == 0 ? "1" : "0");  //gram
            if (chkBOMTaeed.Checked == false && objTakvin.SelectBomGheteh("", "1").Tables[0].Rows.Count > 0)
            {
               // RadMessageBox.Show("این ترکیب مواد در قطعات استفاده شده است");
                
                if (RadMessageBox.Show(this, "این ترکیب مواد در قطعات استفاده شده است آیا مطمئن هستید این ترکیب مواد غیر فعال شود؟", "", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation, MessageBoxDefaultButton.Button3, RightToLeft.Yes) == DialogResult.No)
                //----click No
                    return;               
            }
            if (chkBOMTaeed.Checked == true && objTakvin.BOMSumMavadDarsad() != 100)
            {
                    RadMessageBox.Show("مجموع مقدار درصد مواد برابر با 100 درصد نیست");
                    //chkBOMTaeed.Checked = false;
                    //return;
            }
            objTakvin.StrVaziatEjraee = (chkBOMTaeed.Checked == true ? "1" : "0");
            
            try
            {
                RadMessageBox.Show(objTakvin.UpdHBOM());
                GrdBOM.DataSource = objTakvin.SelectBomMavad().Tables[0];

            }
            catch (Exception exp)
            {
                RadMessageBox.Show("خطا در اجرای عملیات \n" + exp.Message);
            }
        }

        private void txtID_Bom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmTakvinBomSearch frmBS = new FrmTakvinBomSearch();
                frmBS.strISVaziatEjraee = "";
                frmBS.ShowDialog();

                if (string.IsNullOrEmpty(ClsTakvin.GetID_Bom))
                {
                    return;
                }

                txtID_Bom.Text = ClsTakvin.GetID_Bom; //(!string.IsNullOrEmpty(ClsTakvin.GetID_Bom) ? ClsTakvin.GetID_Bom : txtID_Bom.Text.Trim());
                txtNameBom.Text = ClsTakvin.GetNameBom;// (!string.IsNullOrEmpty(ClsTakvin.GetNameBom) ? ClsTakvin.GetNameBom : txtNameBom.Text.Trim());
                if (!string.IsNullOrEmpty(ClsTakvin.GetVahedsanjeshBom))
                {
                    cmbVahedsanjeshBom.SelectedIndex = (ClsTakvin.GetVahedsanjeshBom=="1" ? 0 : cmbVahedsanjeshBom.SelectedIndex);
                }
                StrID_BOM = txtID_Bom.Text.Trim();
                objTakvin.StrID_Bom = StrID_BOM;
                if (!string.IsNullOrEmpty(StrID_BOM))
                {
                    chkBOMTaeed.Checked = ClsTakvin.GetVaziatEjraee;
                    chkBOMTaeed.Enabled = true;
                    GrdBOM.DataSource = objTakvin.SelectBomMavad().Tables[0];
                    btnAddBom.Enabled = false;
                    btnDelBom.Enabled = true;
                    btnUpdBom.Enabled = true;
                    btnAddMavad.Enabled = true;
                }
                else
                {
                    chkBOMTaeed.Enabled = false;
                }
                

                
            }
        }

        private void btnClearMavad_Click(object sender, EventArgs e)
        {
            ClearDBOM();
        }

        private void btnAddMavad_Click(object sender, EventArgs e)
        {
            StrID_BOM = txtID_Bom.Text.Trim();
            objTakvin.StrID_Bom = StrID_BOM;
            if (string.IsNullOrEmpty(StrID_BOM))
            {
                RadMessageBox.Show(" کد ترکیب مواد را وارد نمایید");
                return;
            }
            if (objTakvin.SelectBom("1").Tables[0].Rows.Count > 0)
            {
                RadMessageBox.Show("وضعیت اجرایی این ترکیب مواد فعال است\n" + "لطفا ابتدا ترکیب مواد را غیر فعال نمایید ");
                return;
            }
            if (txtMavadCode.Text.Trim() == "")
            {
                RadMessageBox.Show(" کد مواد را وارد نمایید");
                return;
            }
            if (txtMavadName.Text.Trim() == "")
            {
                RadMessageBox.Show(" نام مواد را وارد نمایید");
                return;
            }
            if ((objTakvin.BOMSumMavadDarsad()+SEdtMavadDarsad.Value )> 100)
            {
                RadMessageBox.Show("مجموع درصد مواد وارد شده بیشتر از 100  است");
                //SEdtMavadDarsad.Value = ((100 - objTakvin.BOMSumMavadDarsad()) == 0 ? 1 : (100 - objTakvin.BOMSumMavadDarsad()));
                //return;
                
            }
            objTakvin.StrMavadCode = txtMavadCode.Text.Trim();
            objTakvin.StrMavadAnabr = txtMavadAnabr.Text.Trim();
            objTakvin.StrMavadDarsad =  SEdtMavadDarsad.Value.ToString().Replace("/",".");
            try
            {

                DataTable dtInsDBOM = objTakvin.InsDBOM().Tables[0];
                if (dtInsDBOM.Rows[0]["Return Value"].ToString() == "-1")
                {
                    RadMessageBox.Show(" این مواد تکراری است ");
                    return;
                }
                if (dtInsDBOM.Rows[0]["Return Value"].ToString() == "-2")
                {
                    RadMessageBox.Show("مجموع درصد مواد وارد شده بیشتر از 100  است");
                    //return;
                }
                if (dtInsDBOM.Rows[0]["Return Value"].ToString() == "0")
                {
                    RadMessageBox.Show("مواد مورد نظر ثبت شد");
                    GrdBOM.DataSource = objTakvin.SelectBomMavad().Tables[0];
                }

            }
            catch (Exception exp)
            {
                RadMessageBox.Show("خطا در اجرای عملیات \n" + exp.Message);
            }
        }

        private void GrdBOM_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                txtMavadCode.Text = GrdBOM.Rows[e.RowIndex].Cells["MavadCode"].Value.ToString();
                txtMavadAnabr.Text = GrdBOM.Rows[e.RowIndex].Cells["MavadAnabr"].Value.ToString();
                txtMavadName.Text = GrdBOM.Rows[e.RowIndex].Cells["N_Kala"].Value.ToString();
                SEdtMavadDarsad.Value = Convert.ToDecimal(GrdBOM.Rows[e.RowIndex].Cells["MavadDarsad"].Value);
                intBeforMavadDarsad = Convert.ToDecimal(GrdBOM.Rows[e.RowIndex].Cells["MavadDarsad"].Value);
                txtMavadCode.Enabled = false;
                txtMavadAnabr.Enabled = false;
                txtMavadName.Enabled = false;

                btnClearMavad.Enabled = true;
                btnAddMavad.Enabled = false;
                btnUpdMavad.Enabled = true;
                btnDelMavad.Enabled = true;
            }
            catch (Exception exp)
            {
                return;
            }

        }

        private void chkBOMTaeed_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chkBOMTaeed.Checked == true && objTakvin.BOMSumMavadDarsad() != 100)
            {
                RadMessageBox.Show("مجموع مقدار درصد مواد برابر با 100 درصد نیست");
                //chkBOMTaeed.Checked = false;
                
            }
            ////else
            ////    if (chkBOMTaeed.Checked == false && objTakvin.SelectBomGheteh("", "1").Tables[0].Rows.Count > 0)
            ////    {
            ////        RadMessageBox.Show("این ترکیب مواد در قطعات استفاده شده است");
            ////        chkBOMTaeed.Checked = true;
            ////    }
        }

        private void btnUpdMavad_Click(object sender, EventArgs e)
        {
            StrID_BOM = txtID_Bom.Text.Trim();
            objTakvin.StrID_Bom = StrID_BOM;
            if (string.IsNullOrEmpty(StrID_BOM))
            {
                RadMessageBox.Show(" کد ترکیب مواد را وارد نمایید");
                return;
            }
            if (objTakvin.SelectBom("1").Tables[0].Rows.Count > 0)
            {
                RadMessageBox.Show("وضعیت اجرایی این ترکیب مواد فعال است\n" + "لطفا ابتدا ترکیب مواد را غیر فعال نمایید ");
                return;
            }
            if (txtMavadCode.Text.Trim() == "")
            {
                RadMessageBox.Show(" کد مواد را وارد نمایید");
                return;
            }
            if (txtMavadName.Text.Trim() == "")
            {
                RadMessageBox.Show(" نام مواد را وارد نمایید");
                return;
            }
            if ((objTakvin.BOMSumMavadDarsad() - intBeforMavadDarsad + SEdtMavadDarsad.Value) > 100)
            {
                RadMessageBox.Show("مجموع مقدار درصد مواد بزرگتر از 100 است");
                //return;

            }
            objTakvin.StrMavadCode = txtMavadCode.Text.Trim();
            objTakvin.StrMavadAnabr = txtMavadAnabr.Text.Trim();
            objTakvin.StrMavadDarsad = SEdtMavadDarsad.Value.ToString().Replace("/", ".");
            try
            {
                RadMessageBox.Show(objTakvin.UpdDBOM());
                GrdBOM.DataSource = objTakvin.SelectBomMavad().Tables[0];

            }
            catch (Exception exp)
            {
                RadMessageBox.Show("خطا در اجرای عملیات \n" + exp.Message);
            }
        }

        private void btnDelMavad_Click(object sender, EventArgs e)
        {
            StrID_BOM = txtID_Bom.Text.Trim();
            objTakvin.StrID_Bom = StrID_BOM;
            
            if (string.IsNullOrEmpty(StrID_BOM))
            {
                RadMessageBox.Show(" کد ترکیب مواد را وارد نمایید");
                return;
            }
            if (objTakvin.SelectBom("1").Tables[0].Rows.Count>0)
            {
                RadMessageBox.Show("وضعیت اجرایی این ترکیب مواد فعال است\n" + "لطفا ابتدا ترکیب مواد را غیر فعال نمایید");
                return;
            }
            if (txtMavadCode.Text.Trim() == "")
            {
                RadMessageBox.Show(" کد مواد را وارد نمایید");
                return;
            }
            if (txtMavadName.Text.Trim() == "")
            {
                RadMessageBox.Show(" نام مواد را وارد نمایید");
                return;
            }
            objTakvin.StrMavadCode = txtMavadCode.Text.Trim();
            try
            {

                if (RadMessageBox.Show(this, "آیا مطمئن هستید این ترکیب مواد پاک شود؟", "", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation, MessageBoxDefaultButton.Button3, RightToLeft.Yes) == DialogResult.Yes)
                {
                    RadMessageBox.Show(objTakvin.DelDBOM());
                    GrdBOM.DataSource = objTakvin.SelectBomMavad().Tables[0];
                    ClearDBOM();

                }

            }
            catch (Exception exp)
            {
                RadMessageBox.Show("خطا در اجرای عملیات \n" + exp.Message);
            }


        }
    }
}

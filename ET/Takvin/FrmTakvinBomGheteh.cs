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
    public partial class FrmTakvinBomGheteh : Telerik.WinControls.UI.RadForm
    {
        public FrmTakvinBomGheteh()
        {
            InitializeComponent();
        }
        ClsTakvin objTakvin = new ClsTakvin();
        public string strId_GhetehDtl = "";
        public string StrID_BOM = "";
        public int intBeforolaviat = 0;

        public void ClearBomGheteh()
        {
            txtID_Bom.Clear();
            txtNameBom.Clear();
            SEdtOlaviatBom.Value = 1 ;

            GrdBomGheteh.DataSource = null;
            btnAddBomGheteh.Enabled = true;
            btnUpdBomGheteh.Enabled = false;
            btnDelBomGheteh.Enabled = false;

            txtID_Bom.Enabled = true;
            txtNameBom.Enabled = true;

        }
        private void btnClearBomGheteh_Click(object sender, EventArgs e)
        {
            ClearBomGheteh();
        }

        private void txtID_Bom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmTakvinBomSearch frmBS = new FrmTakvinBomSearch();
                frmBS.strISVaziatEjraee = "1";
                frmBS.ShowDialog();

                txtID_Bom.Text = (!string.IsNullOrEmpty(ClsTakvin.GetID_Bom) ? ClsTakvin.GetID_Bom : txtID_Bom.Text.Trim());
                txtNameBom.Text = (!string.IsNullOrEmpty(ClsTakvin.GetNameBom) ? ClsTakvin.GetNameBom : txtNameBom.Text.Trim());
                

                StrID_BOM = txtID_Bom.Text.Trim();
                objTakvin.StrID_Bom = StrID_BOM;
                if (!string.IsNullOrEmpty(StrID_BOM))
                {

                    GrdBomGheteh.DataSource = objTakvin.SelectBomGheteh("", "0").Tables[0];
                    btnAddBomGheteh.Enabled = true;
                    btnDelBomGheteh.Enabled = false;
                    btnUpdBomGheteh.Enabled = false;
                    
                }
            }
        }

        private void FrmTakvinBomGheteh_Load(object sender, EventArgs e)
        {
            objTakvin.StrID_Bom = "";
            objTakvin.strProcid_GhetehDtl = strId_GhetehDtl;
            GrdBomGheteh.DataSource = objTakvin.SelectBomGheteh("", "0").Tables[0];
        }

        private void btnAddBomGheteh_Click(object sender, EventArgs e)
        {

            StrID_BOM = txtID_Bom.Text.Trim();
            
            if (string.IsNullOrEmpty(StrID_BOM))
            {
                RadMessageBox.Show("ترکیب مواد را مشخص کنید");
                return;
            }
            objTakvin.StrID_Bom = StrID_BOM;
            //objTakvin.strProcid_GhetehDtl = strId_GhetehDtl;
            objTakvin.StrBomOlaviat = SEdtOlaviatBom.Value.ToString();
            try
            {

                DataTable dtInsBOMGheteh = objTakvin.InsBOMGheteh().Tables[0];
                if (dtInsBOMGheteh.Rows[0]["Return Value"].ToString() == "-1")
                {
                    RadMessageBox.Show(" این ترکیب مواد تکراری است ");
                    return;
                }
                if (dtInsBOMGheteh.Rows[0]["Return Value"].ToString() == "-2")
                {
                    RadMessageBox.Show("اولویت تکراری است");
                    return;
                }
                if (dtInsBOMGheteh.Rows[0]["Return Value"].ToString() == "0")
                {
                    RadMessageBox.Show("اطلاعات با موفقیت ثبت شد");
                    GrdBomGheteh.DataSource = objTakvin.SelectBomGheteh("1","0").Tables[0];
                }

            }
            catch (Exception exp)
            {
                RadMessageBox.Show("خطا در اجرای عملیات \n" + exp.Message);
            }

        }

        private void GrdBomGheteh_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                txtID_Bom.Text = GrdBomGheteh.Rows[e.RowIndex].Cells["ID_Bom"].Value.ToString();
                txtNameBom.Text = GrdBomGheteh.Rows[e.RowIndex].Cells["NameBom"].Value.ToString();

                SEdtOlaviatBom.Value = Convert.ToInt32(GrdBomGheteh.Rows[e.RowIndex].Cells["olaviat"].Value);
                intBeforolaviat = Convert.ToInt32(GrdBomGheteh.Rows[e.RowIndex].Cells["olaviat"].Value);
                txtID_Bom.Enabled = false;
                txtNameBom.Enabled = false;

                //btnClearBomGheteh.Enabled = true;
                btnAddBomGheteh.Enabled = false;
                btnUpdBomGheteh.Enabled = true;
                btnDelBomGheteh.Enabled = true;
            }
            catch (Exception exp)
            {
                return;
            }

        }

        private void btnDelBomGheteh_Click(object sender, EventArgs e)
        {
            StrID_BOM = txtID_Bom.Text.Trim();
            if (string.IsNullOrEmpty(StrID_BOM))
            {
                RadMessageBox.Show("ترکیب مواد را مشخص کنید");
                return;
            }
            objTakvin.StrID_Bom = StrID_BOM;
            //objTakvin.strProcid_GhetehDtl = strId_GhetehDtl;
            try
            {

                if (RadMessageBox.Show(this, "آیا مطمئن هستید این ترکیب مواد پاک شود؟", "", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation, MessageBoxDefaultButton.Button3, RightToLeft.Yes) == DialogResult.Yes)
                {
                    RadMessageBox.Show(objTakvin.DelBOMGheteh());
                    
                    ClearBomGheteh();
                    GrdBomGheteh.DataSource = objTakvin.SelectBomGheteh("", "0").Tables[0];

                }

            }
            catch (Exception exp)
            {
                RadMessageBox.Show("خطا در اجرای عملیات \n" + exp.Message);
            }
        }

        private void btnUpdBomGheteh_Click(object sender, EventArgs e)
        {
            StrID_BOM = txtID_Bom.Text.Trim();

            if (string.IsNullOrEmpty(StrID_BOM))
            {
                RadMessageBox.Show("ترکیب مواد را مشخص کنید");
                return;
            }
            objTakvin.StrID_Bom = StrID_BOM;
            //objTakvin.strProcid_GhetehDtl = strId_GhetehDtl;
            objTakvin.StrBomOlaviat = SEdtOlaviatBom.Value.ToString();
            if (objTakvin.CheckBomOlaviat().Tables[0].Rows.Count>0)
            {
                RadMessageBox.Show("اولویت تکراری است");
                return;
            }
            try
            {
                RadMessageBox.Show(objTakvin.UpdBOMGheteh());
                GrdBomGheteh.DataSource = objTakvin.SelectBomGheteh("1", "0").Tables[0];

            }
            catch (Exception exp)
            {
                RadMessageBox.Show("خطا در اجرای عملیات \n" + exp.Message);
            }
        }

    }
    

}

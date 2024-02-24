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
    public partial class FrmPLNGhetehProcess : Telerik.WinControls.UI.RadForm
    {
        public FrmPLNGhetehProcess()
        {
            InitializeComponent();
        }
        ClsPlanning objPlanning = new ClsPlanning();
        public string strId_Gheteh, strIdghetehRoot, stridRootTree, strIsTarkib;
        public double Zaman_standard;
        private void grdProcGheteh_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {            
            strId_Gheteh = grdProcGheteh.Rows[e.RowIndex].Cells["id_Gheteh"].Value.ToString();
            objPlanning.strProcid_Gheteh = strId_Gheteh;
            txtProcFaniNoGH.Text = grdProcGheteh.Rows[e.RowIndex].Cells["FaniNo"].Value.ToString();
            txtProcCodeGH.Text = grdProcGheteh.Rows[e.RowIndex].Cells["GhetehCode"].Value.ToString();
            txtProcNameGH.Text = grdProcGheteh.Rows[e.RowIndex].Cells["GheteName"].Value.ToString();
            txtProcAnbarGH.Text = grdProcGheteh.Rows[e.RowIndex].Cells["GhetehAnbar"].Value.ToString();
            txtProcN_Process.Text = grdProcGheteh.Rows[e.RowIndex].Cells["N_process"].Value.ToString();
            txtProcTime_standard.Text = grdProcGheteh.Rows[e.RowIndex].Cells["Zaman_standard"].Value.ToString();
            objPlanning.strProcTime_standard = grdProcGheteh.Rows[e.RowIndex].Cells["Zaman_standard"].Value.ToString();
            txtProcNafar.Text = grdProcGheteh.Rows[e.RowIndex].Cells["nafar_tedad"].Value.ToString();
            objPlanning.strProcNafar = grdProcGheteh.Rows[e.RowIndex].Cells["nafar_tedad"].Value.ToString();
            if( Convert.ToBoolean(grdProcGheteh.Rows[e.RowIndex].Cells["IsTarkib"].Value)==true)
            {
                strIsTarkib = "1";
                rbtnProcTarkibIn.Checked = Convert.ToBoolean(grdProcGheteh.Rows[e.RowIndex].Cells["IsTarkibIN"].Value);
                rbtnProcTarkibOut.Checked = Convert.ToBoolean(grdProcGheteh.Rows[e.RowIndex].Cells["IsTarkibOUT"].Value);
            }
            else
            {
                strIsTarkib = "0";
                rbtnProcTarkibIn.Checked = false;
                rbtnProcTarkibOut.Checked = false;
            }
            
            btnUpdProc.Enabled = true;
        }

        private void btnClearProc_Click(object sender, EventArgs e)
        {
            strId_Gheteh = "";
            objPlanning.strProcid_Gheteh = "";
            txtProcFaniNoGH.Clear();
            txtProcCodeGH.Clear();
            txtProcNameGH.Clear();
            txtProcAnbarGH.Clear();
            txtProcN_Process.Clear();
            txtProcTime_standard.Clear();
            objPlanning.strProcTime_standard = "";
            txtProcNafar.Clear();
            objPlanning.strProcNafar = "";
            btnUpdProc.Enabled = false;
            stridRootTree = "";
            objPlanning.strRootCKala = "";
            lblTaeedDesign.Text = "";
            txtCkala.Clear();
            txtNKala.Clear();
            objPlanning.stridRootTree = "";
            grdProcGheteh.DataSource = objPlanning.SelectProcessGheteh().Tables[0]; 
        }

        private void btnUpdProc_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(strId_Gheteh))
                {
                    RadMessageBox.Show("قطعه فرآیند را تعیین کنید");
                    return;
                }
                if (string.IsNullOrEmpty(txtProcTime_standard.Text.Trim()))
                {
                    RadMessageBox.Show("زمان استاندارد را تعیین کنید");
                    return;
                }
                if (string.IsNullOrEmpty(txtProcNafar.Text.Trim()))
                {
                    RadMessageBox.Show("تعداد نفر را تعیین کنید");
                    return;
                }
                if (strIsTarkib == "1" && rbtnProcTarkibIn.Checked != true && rbtnProcTarkibOut.Checked != true)
                {
                    RadMessageBox.Show("نوع فرآیند ترکیبی را مشخص کنید");
                    return;
                }
                objPlanning.strProcTime_standard = txtProcTime_standard.Text;
                objPlanning.strProcTime_standard = objPlanning.strProcTime_standard.Replace("/",".");
                objPlanning.strProcNafar = txtProcNafar.Text;
                if (strIsTarkib == "1")
                {
                    objPlanning.strProcIsTarkibIn = (rbtnProcTarkibIn.Checked == true ? "1" : "0");
                    objPlanning.strProcIsTarkibOut = (rbtnProcTarkibOut.Checked == true ? "1" : "0");
                }
                else
                {
                    objPlanning.strProcIsTarkibIn = "0";
                    objPlanning.strProcIsTarkibOut = "0";
                }

                RadMessageBox.Show(objPlanning.UpdGhetehProcess());
                grdProcGheteh.DataSource = objPlanning.SelectProcessGheteh().Tables[0];
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        private void FrmPLNGhetehProcess_Load(object sender, EventArgs e)
        {
            objPlanning.strRootCKala = "";
            stridRootTree = "";
            grdProcGheteh.DataSource = objPlanning.SelectProcessGheteh().Tables[0];
            grdBasteh.DataSource = objPlanning.SelectBastehGheteh().Tables[0]; 
        }

        private void MasterTemplate_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {

                objPlanning.strIdghetehRoot = grdBasteh.Rows[e.RowIndex].Cells["FK_id_Gheteh"].Value.ToString();
                strIdghetehRoot = objPlanning.strIdghetehRoot;
                txtBastehCode.Text = grdBasteh.Rows[e.RowIndex].Cells["BastehCode"].Value.ToString();
                objPlanning.StrBastehCode = txtBastehCode.Text.Trim();
                txtBastehAnbar.Text = grdBasteh.Rows[e.RowIndex].Cells["BastehAnbar"].Value.ToString();
                objPlanning.StrBastehAnbar = txtBastehAnbar.Text.Trim();
                txtBastehTedad.Text = grdBasteh.Rows[e.RowIndex].Cells["BastehTedad"].Value.ToString();
                //objTakvin.StrBastehTedad = txtBastehTedad.Value.ToString();
                txtBastehOlaviat.Text = grdBasteh.Rows[e.RowIndex].Cells["BastehOlaviat"].Value.ToString();
                //objTakvin.StrBastehOlaviat = sEdtBastehOlaviat.Value.ToString();
                txtBastehName.Text = grdBasteh.Rows[e.RowIndex].Cells["N_Kala"].Value.ToString();
                //objTakvin.StrBastehNafar = grdBasteh.Rows[e.RowIndex].Cells["nafar_tedad"].Value.ToString();
                txtBastehNafar.Text = grdBasteh.Rows[e.RowIndex].Cells["nafar_tedad"].Value.ToString();
                txtBastehZaman.Text = grdBasteh.Rows[e.RowIndex].Cells["Zaman_standard"].Value.ToString();
                //objTakvin.StrBastehInTolid = grdBasteh.Rows[e.RowIndex].Cells["InTolidi"].Value.ToString();
               // chkBastehInTolid.Checked = Convert.ToBoolean(grdBasteh.Rows[e.RowIndex].Cells["InTolidi"].Value);

                //txtBastehCode.Enabled = false;
                //txtBastehAnbar.Enabled = false;
                //txtBastehName.Enabled = false;

                //btnAddBasteh.Enabled = false;
                btnUpdBasteh.Enabled = true;
                //btnDelBasteh.Enabled = true;
            }
            catch (Exception exp)
            {
                return;
            }
        }

        private void btnUpdBasteh_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(strIdghetehRoot))
            {
                RadMessageBox.Show("درخت را تعیین کنید");
                return;
            }
            if (string.IsNullOrEmpty(txtBastehZaman.Text.Trim()))
            {
                RadMessageBox.Show("زمان استاندارد را تعیین کنید");
                return;
            }
            if (string.IsNullOrEmpty(txtBastehNafar.Text.Trim()))
            {
                RadMessageBox.Show("تعداد نفر را تعیین کنید");
                return;
            }
            objPlanning.strBastehZaman = txtBastehZaman.Text;
            objPlanning.strBastehZaman = objPlanning.strBastehZaman.Replace("/", ".");
            objPlanning.StrBastehNafar = txtBastehNafar.Text.Trim();
            RadMessageBox.Show(objPlanning.UpdBastehGheteh());
            grdBasteh.DataSource = objPlanning.SelectBastehGheteh().Tables[0];
        }

        private void btnClearBasteh_Click(object sender, EventArgs e)
        {
            txtBastehCode.Clear();
            objPlanning.StrBastehCode = "";
            objPlanning.strBastehZaman = "";
            txtBastehZaman.Clear();
            txtBastehNafar.Clear();
            txtBastehName.Clear();
            txtBastehAnbar.Clear();
            
            txtBastehTedad.Clear();
            txtBastehOlaviat.Clear();

            //txtBastehCode.Enabled = true;
            //btnAddBasteh.Enabled = true;
            btnUpdBasteh.Enabled = false;
            //btnDelBasteh.Enabled = false;
        }

        private void grdBasteh_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {

                objPlanning.strIdghetehRoot = grdBasteh.Rows[e.RowIndex].Cells["FK_id_Gheteh"].Value.ToString();
                strIdghetehRoot = objPlanning.strIdghetehRoot;
                txtBastehCode.Text = grdBasteh.Rows[e.RowIndex].Cells["BastehCode"].Value.ToString();
                objPlanning.StrBastehCode = txtBastehCode.Text.Trim();
                txtBastehAnbar.Text = grdBasteh.Rows[e.RowIndex].Cells["BastehAnbar"].Value.ToString();
                objPlanning.StrBastehAnbar = txtBastehAnbar.Text.Trim();
                txtBastehTedad.Text = grdBasteh.Rows[e.RowIndex].Cells["BastehTedad"].Value.ToString();
                //objTakvin.StrBastehTedad = txtBastehTedad.Value.ToString();
                txtBastehOlaviat.Text = grdBasteh.Rows[e.RowIndex].Cells["BastehOlaviat"].Value.ToString();
                //objTakvin.StrBastehOlaviat = sEdtBastehOlaviat.Value.ToString();
                txtBastehName.Text = grdBasteh.Rows[e.RowIndex].Cells["N_Kala"].Value.ToString();
                //objTakvin.StrBastehNafar = grdBasteh.Rows[e.RowIndex].Cells["nafar_tedad"].Value.ToString();
                txtBastehNafar.Text = grdBasteh.Rows[e.RowIndex].Cells["nafar_tedad"].Value.ToString();
                txtBastehZaman.Text = grdBasteh.Rows[e.RowIndex].Cells["Zaman_standard"].Value.ToString();
                objPlanning.strBastehZaman = grdBasteh.Rows[e.RowIndex].Cells["Zaman_standard"].Value.ToString();
                objPlanning.StrBastehNafar = grdBasteh.Rows[e.RowIndex].Cells["nafar_tedad"].Value.ToString();

                //objTakvin.StrBastehInTolid = grdBasteh.Rows[e.RowIndex].Cells["InTolidi"].Value.ToString();
                // chkBastehInTolid.Checked = Convert.ToBoolean(grdBasteh.Rows[e.RowIndex].Cells["InTolidi"].Value);

                //txtBastehCode.Enabled = false;
                //txtBastehAnbar.Enabled = false;
                //txtBastehName.Enabled = false;

                //btnAddBasteh.Enabled = false;
                btnUpdBasteh.Enabled = true;
                //btnDelBasteh.Enabled = true;
            }
            catch (Exception exp)
            {
                return;
            }
        }

        private void btnCkala_Click(object sender, EventArgs e)
        {
            FrmTakvinSearchTree frmST = new FrmTakvinSearchTree();
            frmST.ShowDialog();
            if (string.IsNullOrEmpty(ClsTakvin.GetRootCode))
                btnClearProc_Click( sender,e); 

                
           // txtFaniNoKala.Text = (!string.IsNullOrEmpty(ClsTakvin.GetRootFaniNo) ? ClsTakvin.GetRootFaniNo : txtFaniNoKala.Text.Trim());
            txtCkala.Text = (!string.IsNullOrEmpty(ClsTakvin.GetRootCode) ? ClsTakvin.GetRootCode : txtCkala.Text.Trim());
            txtNKala.Text = (!string.IsNullOrEmpty(ClsTakvin.GetRootName) ? ClsTakvin.GetRootName : txtNKala.Text.Trim());
            stridRootTree = (!string.IsNullOrEmpty(ClsTakvin.GetidRootTree) ? ClsTakvin.GetidRootTree : stridRootTree);
            objPlanning.stridRootTree = stridRootTree;
            //txtCAnbar.Text = (!string.IsNullOrEmpty(ClsTakvin.GetRootAnbar) ? ClsTakvin.GetRootAnbar : txtCAnbar.Text.Trim());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ClsTakvin objTakvin = new ClsTakvin();
            objTakvin.strCKala=txtCkala.Text.Trim();
            objPlanning.strRootCKala = txtCkala.Text.Trim();
            objPlanning.stridRootTree = stridRootTree;
            DataTable dtProcessGheteh = objPlanning.SelectProcessGheteh().Tables[0];
            if (dtProcessGheteh.Rows.Count>0)
            {
                grdProcGheteh.DataSource = dtProcessGheteh;
            }
            else
            {
                RadMessageBox.Show("این درخت وجود ندارد");
                return;
            }
            
            
            txtNKala.Text = objTakvin.Select_TreeTaeed().Tables[0].Rows[0]["GheteName"].ToString();
            if (objTakvin.Select_TreeTaeed().Tables[0].Rows[0]["Desi"].ToString() == "True")
            {
                lblTaeedDesign.Text=" درخت تایید شده است";
                
            }
            else lblTaeedDesign.Text = " عدم تایید";
        }
       
    }
}

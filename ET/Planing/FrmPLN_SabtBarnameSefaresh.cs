using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI.Export;
using System.Diagnostics;

namespace ET
{
    public partial class FrmPLN_SabtBarnameSefaresh : Telerik.WinControls.UI.RadForm
    {
        public FrmPLN_SabtBarnameSefaresh()
        {
            InitializeComponent();
        }
        public string strIdSefaresh, strorder_code;
        private void FrmPLN_AnalyseSefareshTemp_Load(object sender, EventArgs e)
        {
            ClsPlanning objPlanning = new ClsPlanning();
            txtDateNiazAz.Value = DateTime.Now;
            txtDateNiazTa.Value = DateTime.Now;
            txtDateAz.Value = DateTime.Now;
            txtDateTa.Value = DateTime.Now;
           

            cmbTypeSefaresh.DataSource = objPlanning.Select_TypeSefaresh().Tables[0];
            cmbTypeSefaresh.ValueMember = "SefareshTypeID";
            cmbTypeSefaresh.DisplayMember = "SefareshTypeName";

            grdSodoor.DataSource = objPlanning.Select_OrderdetailTemp().Tables[0];
            grdPreOrder.DataSource = objPlanning.Select_OrderHeaderTemp().Tables[0];

        }

        private void chkSefareshId_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkSefareshId.Checked == true)
                txtOrderCode.Enabled = true;
            else
                txtOrderCode.Enabled = false;
        }

        private void chkDateSefaresh_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkDateSefaresh.Checked == true)
            {
                txtDateAz.Enabled = true;
                txtDateTa.Enabled = true;
            }
            else
            {
                txtDateAz.Enabled = false;
                txtDateTa.Enabled = false;
            }
        }

        private void chkMoshtari_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkMoshtari.Checked == true)
                txtMoshtari.Enabled = true;
            else
                txtMoshtari.Enabled = false;
        }

        private void chkTafsili2_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkTafsili2.Checked == true)
                txtTafsili2.Enabled = true;
            else
                txtTafsili2.Enabled = false;
        }

        private void chkNkala_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkNkala.Checked == true)
                txtNkalaSefaresh.Enabled = true;
            else
                txtNkalaSefaresh.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ClsPlanning objPlanning=new ClsPlanning();
            if (chkSefareshId.Checked == true)
                objPlanning.strIdSefaresh = txtOrderCode.Text;
            if (chkDateSefaresh.Checked == true)
            {
                objPlanning.strAzDate = txtDateAz.Text;
                objPlanning.strTaDate = txtDateTa.Text;
            }
            if (chkDateNiaz.Checked == true)
            {
                objPlanning.strDateStart = txtDateNiazAz.Text;
                objPlanning.strDateEnd = txtDateNiazTa.Text;
            }
            if (chkMoshtari.Checked == true)
                objPlanning.strTafsili = lblCmoshtari.Text;
            if(chkTafsili2.Checked==true)
                objPlanning.strTafsili2 = lblCtafsili2.Text;
            if (chkNkala.Checked == true)
                objPlanning.strCkala = lblCkalaSefaresh.Text;
            if (chkSefareshType.Checked == true)
                objPlanning.strSefareshType = cmbTypeSefaresh.SelectedValue.ToString();

            grdSefaresh.DataSource = objPlanning.Select_Orderdetail().Tables[0];

            btnAdd.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ClsPlanning objPlanning = new ClsPlanning();
            objPlanning.strMohlatErsal = txtDateMohlat.Value.ToString().Substring(0, 10);
            objPlanning.strCountSefaresh = txtCount.Text;
            objPlanning.strIdSefaresh = strIdSefaresh;
            MessageBox.Show(objPlanning.Update_OrderTemp());

            //objPlanning.Update_ExecOrderTemp();
            grdSodoor.DataSource = objPlanning.Select_OrderdetailTemp().Tables[0];

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void grdSodoor_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            
            txtOrderCode.Text = grdSodoor.CurrentRow.Cells["order_code"].Value.ToString();
            strorder_code = grdSodoor.CurrentRow.Cells["order_code"].Value.ToString();
            strIdSefaresh = grdSodoor.CurrentRow.Cells["Id"].Value.ToString();
            txtNkala.Text = grdSodoor.CurrentRow.Cells["product_name"].Value.ToString();
            lblCkala.Text = grdSodoor.CurrentRow.Cells["product_code"].Value.ToString();
            txtCount.Text = grdSodoor.CurrentRow.Cells["count"].Value.ToString();
            txtDateMohlat.Text = grdSodoor.CurrentRow.Cells["mohlat_ersal"].Value.ToString();

            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            
        }

        private void txtTafsili2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmTafsili2 frm = new FrmTafsili2();
                frm.ShowDialog();
                txtTafsili2.Text = frm.strNtafsili2;
                lblCtafsili2.Text = frm.strCtafsili2;
            }
        }

        private void txtMoshtari_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmTafsili frm = new FrmTafsili();
                frm.ShowDialog();
                txtMoshtari.Text = frm.Ntafsili;
                lblCmoshtari.Text = frm.Ctifsili;
            }
        }

        private void txtNkala_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmKala frm = new FrmKala();
                frm.ShowDialog();
                txtNkala.Text = ClsPublic.N_kala;
                lblCkala.Text = ClsPublic.C_kala;
            }
        }

        private void btnReturnSefaresh_Click(object sender, EventArgs e)
        {
            ClsPlanning objPlanning=new ClsPlanning();
            MessageBox.Show(objPlanning.Delete_OrderdetailTemp());

            grdSodoor.DataSource = objPlanning.Select_OrderdetailTemp().Tables[0];
            grdPreOrder.DataSource = objPlanning.Select_OrderHeaderTemp().Tables[0];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClsPlanning objPlanning = new ClsPlanning();
            if (chkSefareshId.Checked == true)
                objPlanning.strIdSefaresh = txtOrderCode.Text;
            if (chkDateSefaresh.Checked == true)
            {
                objPlanning.strAzDate = txtDateAz.Text;
                objPlanning.strTaDate = txtDateTa.Text;
            }
            if (chkMoshtari.Checked == true)
                objPlanning.strTafsili = lblCmoshtari.Text;
            if (chkTafsili2.Checked == true)
                objPlanning.strTafsili = lblCtafsili2.Text;
            if (chkNkala.Checked == true)
                objPlanning.strCkala = lblCkalaSefaresh.Text;
            objPlanning.strDarsad = spnDarsadTaghir.Value.ToString();

            MessageBox.Show(objPlanning.Insert_OrderdetailTemp());
            
            grdSodoor.DataSource = objPlanning.Select_OrderdetailTemp().Tables[0];
            grdPreOrder.DataSource = objPlanning.Select_OrderHeaderTemp().Tables[0];
            //فعلا این پیام نشان داده نمی شود-------------------------------------------------------
            //MessageBox.Show("کلیه محصولات انتخاب شده در صورت وجود در درخت محصول منتقل شد");

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnRefreshDetail_Click(object sender, EventArgs e)
        {
            ClsPlanning objPlanning = new ClsPlanning();
            grdSodoor.DataSource = objPlanning.Select_OrderdetailTemp().Tables[0];
            grdPreOrder.DataSource = objPlanning.Select_OrderHeaderTemp().Tables[0];
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ClsPlanning objPlanning = new ClsPlanning();
            objPlanning.strIdSefaresh = strIdSefaresh;
            objPlanning.strOrderCode  = strorder_code;
            MessageBox.Show(objPlanning.Delete_OrderdetailTemp());


            grdSodoor.DataSource = objPlanning.Select_OrderdetailTemp().Tables[0];
            grdPreOrder.DataSource = objPlanning.Select_OrderHeaderTemp().Tables[0];
            btnEdit.Enabled   = false;
            btnDelete.Enabled = false;
        }

        private void btnSodoor_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا از حذف برنامه قبلی و صدور برنامه جدید اطمینان دارید؟", "اخطار", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ClsPlanning objPlanning = new ClsPlanning();
                using (new PleaseWait(this.Location))
                {
                    objPlanning.Delete_PLN_tblOrderBarname();
                    objPlanning.Insert_OrderBarnameH();
                    objPlanning.Insert_OrderBarnameD();
                    objPlanning.Update_ExecOrderTemp();
                    grdSodoor.DataSource = objPlanning.Select_OrderdetailTemp().Tables[0];
                }
                MessageBox.Show("صدور سفارشات تعیین شده برای تولید انجام شد");
            }
        }

        private void txtNkalaSefaresh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmKala frm = new FrmKala();
                frm.strC_Anbar = "14,19,15";
                frm.ShowDialog();
                txtNkalaSefaresh.Text = ClsBuy.N_kala;
                lblCkalaSefaresh.Text = ClsBuy.C_kala;
            }
        }

        private void btnF2SefareshKala_Click(object sender, EventArgs e)
        {
            FrmKala frm = new FrmKala();
            frm.strC_Anbar = "14,19,15";
            frm.ShowDialog();
            txtNkalaSefaresh.Text = ClsBuy.N_kala;
            lblCkalaSefaresh.Text = ClsBuy.C_kala;
        }

        private void btnF2Moshtari_Click(object sender, EventArgs e)
        {
            FrmTafsili frm = new FrmTafsili();
            frm.ShowDialog();
            txtMoshtari.Text = frm.Ntafsili;
            lblCmoshtari.Text = frm.Ctifsili;
        }

        private void btnF2Tafsili2_Click(object sender, EventArgs e)
        {
            FrmTafsili2 frm = new FrmTafsili2();
            frm.ShowDialog();
            txtTafsili2.Text = frm.strNtafsili2;
            lblCtafsili2.Text = frm.strCtafsili2;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string fileName = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = string.Format("{0} (*{1})|*{1}", "Excel Files", ".xls")
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
            }
                (new ExportToExcelML(this.grdSodoor)).RunExport(fileName);
            if (RadMessageBox.Show("فایل ایجاد شد.آیا می خواهید فایل باز شود؟", "Export to Excel", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Process.Start(fileName);
                }
                catch
                {
                }
            }
        }

        private void grdSodoor_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {

            try
            {
                ClsPlanning objPlanning = new ClsPlanning();
                if (e.Column.Name == "btnOlaviat")
                {
                    objPlanning.strOlaviatMavad = e.Row.Cells["OlaviatMavad"].Value.ToString();
                    objPlanning.strIdSefaresh = e.Row.Cells["Id"].Value.ToString();

                    MessageBox.Show(objPlanning.Update_OrderTempOlaviat());
                }
            }
            catch { }
          
        }

        private void chkSefareshType_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkSefareshType.Checked == true)
                cmbTypeSefaresh.Enabled = true;
            else
                cmbTypeSefaresh.Enabled = false;
        }

        private void chkDateNiaz_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkDateNiaz.Checked == true)
            {
                txtDateNiazAz.Enabled = true;
                txtDateNiazTa.Enabled = true;
            }
            else
            {
                txtDateNiazAz.Enabled = false;
                txtDateNiazTa.Enabled = false;
            }
        }

        private void grdSodoor_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void grdPreOrder_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Return)
                {

                    ClsPlanning objPlanning = new ClsPlanning();
                    //if (e.Column.Name == "isBom")
                    //{
                    //objPlanning.strisBom = e.Row.Cells["isBom"].Value.ToString();
                    objPlanning.strOrderCode = grdPreOrder.CurrentRow.Cells["order_code"].Value.ToString();
                    objPlanning.strOrderCodeprefrence = grdPreOrder.CurrentRow.Cells["prefrenceCustom"].Value.ToString();
                    objPlanning.Update_OrderTempprefrence();
                    //}
                }
            }
            catch { }
        }

        private void btnAnalys_Click(object sender, EventArgs e)
        {
            ClsPlanning objPlanning = new ClsPlanning();
            using (new PleaseWait(this.Location))
            {
                objPlanning.Update_ExecOrderTemp();
                grdSodoor.DataSource = objPlanning.Select_OrderdetailTemp().Tables[0];
                grdPreOrder.DataSource = objPlanning.Select_OrderHeaderTemp().Tables[0];
            }
        }
    }
}

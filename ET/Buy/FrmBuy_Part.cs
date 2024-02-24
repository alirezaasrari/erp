using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI.Export;

namespace ET
{
    public partial class FrmBuy_Part : Telerik.WinControls.UI.RadForm
    {
        public string barnameID, Meghdar_Darkhast;
        public DataSet ds = new DataSet();
        SaveFileDialog sfd = new SaveFileDialog();
        ClsMain objMain = new ClsMain();
        public FrmBuy_Part()
        {
            InitializeComponent();
        }

        private void cmbMasool_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //lblMasool.Visible = false;
                ClsBuy clsBuyObj = new ClsBuy();

                clsBuyObj.strC_Personel = cmbMasool.SelectedValue.ToString();
                clsBuyObj.strC_kala = "";
                clsBuyObj.strActive = "1";
                AgrdBarnameSum.DataSource = clsBuyObj.selectPartSum().Tables[0];
                clsBuyObj.intSabt = 1;
                clsBuyObj.intDone = 0;
                gridViewTemplate1.DataSource = clsBuyObj.Barname().Tables[0];

                lblMasool.Text = cmbMasool.SelectedValue.ToString();
            }
            catch
            { }
        }

        private void FrmBuy_Part_Load(object sender, EventArgs e)
        {
            try
            {
                ////////////////////////////////////
                lblMasool.Text = ClsMain.StrPersonerId;
                ClsBuy clsBuyObj = new ClsBuy();
                clsBuyObj.DelDeleted();

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
                        ctn = Controls[strControl];
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

                clsBuyObj.strC_Personel = "";
                clsBuyObj.strN_Personel = "";
                ds = clsBuyObj.SelectPersonelBuy();
                if (cmbMasool.Enabled == true)
                {
                    cmbMasool.DataSource = ds.Tables[0];
                    cmbMasool.ValueMember = "Personel_ID";
                    cmbMasool.DisplayMember = "name";
                }

                //////////////////////////////////

                clsBuyObj.strDiff = "0";
                clsBuyObj.UpdateBarnameDone();

                clsBuyObj.strC_Personel = lblMasool.Text;
                clsBuyObj.strC_kala = "";
                clsBuyObj.strActive = "1";
                clsBuyObj.strDiff = "";

                AgrdBarnameSum.DataSource = clsBuyObj.selectPartSum().Tables[0];
                clsBuyObj.intSabt = 1;
                clsBuyObj.intDone = 0;
                gridViewTemplate1.DataSource = clsBuyObj.Barname().Tables[0];
            }
            catch (Exception ee)
            { }
        }

        private void AgrdBarnameSum_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            ClsBuy clsBuyObj = new ClsBuy();
            try
            {
                if (AgrdBarnameSum.CurrentRow.HierarchyLevel == 1)
                {
                    txtPartNo.Text = "";
                    txtMeghdar.Text = "0";
                    //txtMeghdarVirtual.Text = "0";
                    txttafsiliNo.Text = "";
                    txtDate.Text = "";
                    //txtDataVirtual.Text = "0";
                    txtTahvil.Text = "";
                    btn_add.Enabled = true;

                    txtDarkhast_No.Text = AgrdBarnameSum.Templates[0].Rows[e.RowIndex].Cells["Sho_Darkhast"].Value.ToString();
                    txtDarkhast_Radif.Text = AgrdBarnameSum.Templates[0].Rows[e.RowIndex].Cells["Radif_Darkhast"].Value.ToString();
                    txtPartNo.Text = (Convert.ToInt32(AgrdBarnameSum.Templates[0].Rows[e.RowIndex].Cells["maxPart"].Value.ToString()) + 1).ToString();
                    barnameID = AgrdBarnameSum.Templates[0].Rows[e.RowIndex].Cells["Barname_ID"].Value.ToString();
                    Meghdar_Darkhast = AgrdBarnameSum.Templates[0].Rows[e.RowIndex].Cells["meghdar_taeed"].Value.ToString();

                    clsBuyObj.Barname_ID = barnameID;
                    clsBuyObj.Tahvil_No = "";
                    grdPart.DataSource = clsBuyObj.selectPart().Tables[0];

                    clsBuyObj.strSho_Darkhast = txtDarkhast_No.Text;
                    clsBuyObj.strDarkhastRadif = txtDarkhast_Radif.Text;
                    grdPartAnbar.DataSource = clsBuyObj.selectPartAnbar().Tables[0];
                }
            }
            catch { }
        }

        private void chbDif_CheckedChanged(object sender, EventArgs e)
        {
            ClsBuy clsBuyObj = new ClsBuy();

            clsBuyObj.strC_kala = "";
            if (cmbMasool.Enabled == true)
                clsBuyObj.strC_Personel = cmbMasool.SelectedValue.ToString();
            else
                clsBuyObj.strC_Personel = lblMasool.Text;

            clsBuyObj.strSho_Darkhast = "";
            clsBuyObj.strActive = "1";
            if (chbDif.Checked == true)
                clsBuyObj.strDiff = "1";
            else
                clsBuyObj.strDiff = "";

            AgrdBarnameSum.DataSource = clsBuyObj.selectPartSum().Tables[0];
            clsBuyObj.intSabt = 1;
            clsBuyObj.intDone = 0;
            gridViewTemplate1.DataSource = clsBuyObj.Barname().Tables[0];
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

            if (!tbFileName.Text.Equals(string.Empty))
            {
                ExportToExcelML exporter = new ExportToExcelML(AgrdBarnameSum);
                exporter.RunExport(tbFileName.Text);
                MessageBox.Show("فایل \n" + sfd.FileName + "\nایجاد شد");
            }  
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            AgrdBarnameSum.PrintPreview();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            ClsBuy clsBuyObj = new ClsBuy();

            string sumMeghdarPart = "";
            //if (txttafsiliNo.Text == "" || txtMeghdar.Text == "" || txtTahvil.Text == "")
            //{
            //    MessageBox.Show("اطلاعات را درست وارد کنید");
            //    return;
            //}
            try
            {
                clsBuyObj.Barname_ID = "";
                clsBuyObj.Tahvil_No = txtTahvil.Text;
                //if (txtTahvil.Text != "")
                //    if (clsBuyObj.selectPart().Tables[0].Rows.Count > 0)
                //    {
                //        MessageBox.Show("این تحویل کالا قبلا ثبت شده است");
                //        return;
                //    }
                clsBuyObj.Barname_ID = barnameID;
                clsBuyObj.Part = "";
                clsBuyObj.Meghdar = txtMeghdar.Text;
                //clsBuyObj.Meghdar_Virtual = txtMeghdarVirtual.Text;
                clsBuyObj.strDateSabt = txtDate.Text;
                clsBuyObj.Tafsili = txttafsiliNo.Text;

                try
                {
                    sumMeghdarPart = clsBuyObj.SumMeghdarPart().Tables[0].Rows[0][0].ToString();
                }
                catch
                {
                    sumMeghdarPart = "0";
                }

                if (Convert.ToDouble(Meghdar_Darkhast) < Convert.ToDouble(sumMeghdarPart))
                {
                    MessageBox.Show("مقدار خرید شده از مقدار درخواستی بیشتر است");
                    return;
                }
                clsBuyObj.Part = txtPartNo.Text;
                clsBuyObj.Meghdar = txtMeghdar.Text;
                //clsBuyObj.Meghdar_Virtual = txtMeghdarVirtual.Text;
                //clsBuyObj.strDateSabt_virtual = txtDataVirtual.Text;

                MessageBox.Show(clsBuyObj.insPart());
                clsBuyObj.Tahvil_No = "";
                grdPart.DataSource = clsBuyObj.selectPart().Tables[0];

                clsBuyObj.strC_Personel = lblMasool.Text;
                //clsBuyObj.strC_Personel = cmbMasool.SelectedValue.ToString();
                clsBuyObj.strSho_Darkhast = "";
                clsBuyObj.strActive = "1";
                AgrdBarnameSum.DataSource = clsBuyObj.selectPartSum().Tables[0];
                clsBuyObj.intSabt = 1;
                clsBuyObj.intDone = 0;
                gridViewTemplate1.DataSource = clsBuyObj.Barname().Tables[0];

                //btn_add.Enabled = false;
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            ClsBuy clsBuyObj = new ClsBuy();
            string sumMeghdarPart = "";
            if (MessageBox.Show("آیا از تغییر اطلاعات پارت اطمینان دارید؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    clsBuyObj.Barname_ID = barnameID;
                    clsBuyObj.Part = txtPartNo.Text;
                    clsBuyObj.Meghdar = txtMeghdar.Text;
                    clsBuyObj.strDateSabt = txtDate.Text;
                    clsBuyObj.Tahvil_No = txtTahvil.Text;
                    clsBuyObj.Tafsili = txttafsiliNo.Text;


                    sumMeghdarPart = clsBuyObj.SumMeghdarPart().Tables[0].Rows[0][0].ToString();


                    if (Convert.ToDouble(Meghdar_Darkhast) < Convert.ToDouble(sumMeghdarPart))
                    {
                        MessageBox.Show("مقدار خرید شده از مقدار درخواستی بیشتر است");
                        return;
                    }

                    clsBuyObj.Meghdar = txtMeghdar.Text;
                    MessageBox.Show(clsBuyObj.UpdatePart());
                    clsBuyObj.Tahvil_No = "";
                    grdPart.DataSource = clsBuyObj.selectPart().Tables[0];

                    clsBuyObj.strC_kala = "";
                    clsBuyObj.strC_Personel = lblMasool.Text;
                    //clsBuyObj.strC_Personel = cmbMasool.SelectedValue.ToString();
                    clsBuyObj.strSho_Darkhast = "";
                    clsBuyObj.strActive = "1";
                    AgrdBarnameSum.DataSource = clsBuyObj.selectPartSum().Tables[0];
                    clsBuyObj.intSabt = 1;
                    clsBuyObj.intDone = 0;
                    gridViewTemplate1.DataSource = clsBuyObj.Barname().Tables[0];

                    btn_edit.Enabled = false;
                    btn_del.Enabled = false;
                }
                catch
                {
                    sumMeghdarPart = "0";
                }
            }
        }
        private void btn_del_Click(object sender, EventArgs e)
        {
            ClsBuy clsBuyObj = new ClsBuy();

            if (MessageBox.Show("آیا از حذف پارت اطمینان دارید؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    clsBuyObj.Barname_ID = barnameID;
                    clsBuyObj.Part = txtPartNo.Text;
                    MessageBox.Show(clsBuyObj.DelPart());
                    clsBuyObj.Tahvil_No = "";
                    grdPart.DataSource = clsBuyObj.selectPart().Tables[0];

                    clsBuyObj.strC_kala = "";
                    clsBuyObj.strC_Personel = lblMasool.Text;
                    //clsBuyObj.strC_Personel = cmbMasool.SelectedValue.ToString();
                    clsBuyObj.strSho_Darkhast = "";
                    clsBuyObj.strActive = "1";
                    AgrdBarnameSum.DataSource = clsBuyObj.selectPartSum().Tables[0];
                    clsBuyObj.intSabt = 1;
                    clsBuyObj.intDone = 0;
                    gridViewTemplate1.DataSource = clsBuyObj.Barname().Tables[0];

                    btn_del.Enabled = false;
                    btn_edit.Enabled = false;
                }
                catch
                {
                    MessageBox.Show("خطا در اجرای عملیات");
                }
            }
        }

        private void grdPart_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txttafsiliNo.Text = grdPart.Rows[e.RowIndex].Cells["Tafsili"].Value.ToString();
            txtPartNo.Text = grdPart.Rows[e.RowIndex].Cells["Part"].Value.ToString();
            txtMeghdar.Text = grdPart.Rows[e.RowIndex].Cells["Meghdar"].Value.ToString();
            txtDate.Text = grdPart.Rows[e.RowIndex].Cells["Date_Buy"].Value.ToString();
            txtTahvil.Text = grdPart.Rows[e.RowIndex].Cells["Tahvil_No"].Value.ToString();
            //txtMeghdarVirtual.Text = grdPart.Rows[e.RowIndex].Cells["Meghdar_Virtual"].Value.ToString();
            //txtDataVirtual.Text = grdPart.Rows[e.RowIndex].Cells["DateBuy_Virtual"].Value.ToString();

            btn_edit.Enabled = true;
            btn_del.Enabled = true;
            btn_add.Enabled = false;
        }

        private void btnExportFile_Click(object sender, EventArgs e)
        {

            sfd.Filter = String.Format("{0} (*{1})|*{1}", "Excel Files", ".xls");
            if (sfd.ShowDialog() == DialogResult.OK)
                tbFileName.Text = sfd.FileName; 
        }

        private void txttafsiliNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmTafsili frm = new FrmTafsili();
                frm.ShowDialog();
                lblTafsili.Text = ClsBuy.tafsili_Name;
                txttafsiliNo.Text = ClsBuy.tafsili_Id;
            }
        }

        private void txttafsiliNo_TextChanged(object sender, EventArgs e)
        {
            ClsBuy clsBuyObj = new ClsBuy();

            try
            {
                lblTafsili.Text = "-";
                clsBuyObj.str_cMoshtari = txttafsiliNo.Text;
                clsBuyObj.str_nMoshtari = "";
                lblTafsili.Text = clsBuyObj.SelectTafsili().Tables[0].Rows[0][1].ToString();
            }
            catch
            {
                lblTafsili.Text = "";
            }
        }
    }
}

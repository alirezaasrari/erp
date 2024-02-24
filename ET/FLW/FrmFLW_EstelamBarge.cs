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
    public partial class FrmFLW_EstelamBarge : Telerik.WinControls.UI.RadForm
    {
        DataTable dt = new DataTable();
        public string strIdEstelamBarge;
        public FrmFLW_EstelamBarge()
        {
            InitializeComponent();
        }
        public string strCkala, strIdTaeed, strIdFormChart, strIdMarhale, strSend, IntIdFormChart, strIdPersonelChart
            , strIdCodeFormX, strCodeFormX, strIdTafsili, strIdEstelamD;

        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            try
            {
                Report objReport = new Report();
                objReport.Load(ClsPublic.strRepPath + "EstelamBarge.frx");
                objReport.SetParameterValue("IdEstelamBarge", lbl_IdEstelamBarge.Text);
                objReport.Print();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnAddEstelam_ImeModeChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ClsFlw obj = new ClsFlw();
                MessageBox.Show(obj.Delete_EstelamBarge(lbl_IdEstelamBarge.Text));
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnAddEstelam_Click(object sender, EventArgs e)
        {
            //if (rdbBuy.Checked == false)
            //{
            //    MessageBox.Show("تیک تدارکات الزامی است");
            //    return;
            //}
            FrmFLW_Estelam frm = new FrmFLW_Estelam();
            frm.strIdEstelamBarge = lbl_IdEstelamBarge.Text;
            frm.strIdMarhale = strIdMarhale;
            frm.strSend = strSend;
            frm.ShowDialog();

            ShowData();
        }

        private void btnSabt_Click(object sender, EventArgs e)
        {
            ClsFlw obj = new ClsFlw();
            obj.strTozihat = txtTozihat.Text;
            obj.strIndexDarkhastKonande = cmbDarkhastKonande.SelectedValue.ToString();
            obj.strIsBuy = Convert.ToInt16(rdbBuy.Checked).ToString();
            obj.strIsQC = Convert.ToInt16(chkIsQC.Checked).ToString();
            obj.strIsFava = Convert.ToInt16(chkIsFava.Checked).ToString();
            MessageBox.Show(obj.Ins_EstelamBarge());

            lbl_IdEstelamBarge.Text = obj.Select_EstelamBargeMax().Tables[0].Rows[0][0].ToString();
            strCodeFormX = lbl_IdEstelamBarge.Text;
            obj.strIdEstelamBarge = lbl_IdEstelamBarge.Text;
            grd.DataSource = obj.Select_EstelamBargeD().Tables[0];

            btnAddEstelam.Enabled = true;

            ShowData();
        }
       
        private void grd_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if(e.Column.Name=="btnDetail")
            {
                FrmFLW_Estelam frm = new FrmFLW_Estelam();
                frm.strIdMarhale = strIdMarhale;
                frm.strSend = strSend;
                frm.strIdEstelamH= grd.Rows[e.RowIndex].Cells["IdEstelamH"].Value.ToString();
                frm.ShowDialog(); 
            }
            string strEstelamH;
            if (e.Column.Name == "btnDelete")
            {
                ClsFlw obj = new ClsFlw();
                strEstelamH = grd.Rows[e.RowIndex].Cells["IdEstelamH"].Value.ToString();
                RadMessageBox.Show(obj.Delete_EstelamH(strEstelamH));
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (strSend == "0")
                {
                    MessageBox.Show("امکان تایید وجود ندارد");
                    return;
                }
                ClsFlw obj = new ClsFlw();

                obj.strValueVariable = "0";
                obj.strIdMarhale = strIdMarhale;
                obj.Update_VariableMarhale();

                obj.strIdVariable = "52";
                if (chkIsFava.Checked == true)
                    obj.strValueVariable = "0";
                else
                    obj.strValueVariable = Convert.ToInt32(rdbBuy.Checked).ToString();
                obj.Update_Variable();

                if (Convert.ToInt16(strIdMarhale) == 2)
                {
                    obj.strIdVariable = "53";
                    obj.strValueVariable = "0";
                    obj.strIdMarhale = strIdMarhale;
                    obj.Update_Variable();
                }
                if (Convert.ToInt16(strIdMarhale) == 7)
                {
                    obj.strIdVariable = "66";
                    obj.strValueVariable = "0";
                    obj.strIdMarhale = strIdMarhale;
                    obj.Update_Variable();
                }

                obj.strCheckTaeed = "2";
                obj.strDescTaeed = txtErja.Text;
                obj.strIdTaeed = strIdTaeed;

                MessageBox.Show(obj.Update_FormFlowTaeed());
                obj.Update_FormFlowTaeedActive();
                obj.strIdTaeed = obj.Select_TaeedMax().Tables[0].Rows[0][0].ToString();
                if (Convert.ToInt16(strIdMarhale) == 3 | Convert.ToInt16(strIdMarhale) == 2)
                {
                    obj.strIdCodeFormX = strIdCodeFormX;
                    obj.strIdPersonelChart = obj.Select_TaeedStartDynamic().Tables[0].Rows[0][0].ToString();
                }
                else
                    obj.strIdPersonelChart = ClsMain.strIdPersonelChart;
                obj.Update_FormFlowTaeedPersonelChart();
                this.Close();
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
       
        private void FrmFLW_EstelamBarge_Load(object sender, EventArgs e)
        {
            try
            {
                txtDateBarge.Value = DateTime.Now;
                SetCmb();
                ShowData();

                if (Convert.ToInt16(strIdMarhale) == 2 | Convert.ToInt16(strIdMarhale) == 3 | Convert.ToInt16(strIdMarhale) == 4 | Convert.ToInt16(strIdMarhale) == 5
                  | Convert.ToInt16(strIdMarhale) == 6 | Convert.ToInt16(strIdMarhale) == 7 | Convert.ToInt16(strIdMarhale) == 8 | Convert.ToInt16(strIdMarhale) == 9 | Convert.ToInt16(strIdMarhale) == 10)
                {
                    btnBack.Visible = true;
                }
                if (Convert.ToInt16(strIdMarhale) == 10)
                {
                    btnEnd.Visible = true;
                }
            }
            catch(Exception ee)
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
                ClsFlw obj = new ClsFlw();
                obj.strIdEstelamBarge = lbl_IdEstelamBarge.Text;
                var idestelamh = Convert.ToInt16(obj.Select_IsTadarokat().Tables[0].Rows[0][0].ToString());
                if (idestelamh == 0)
                {
                    MessageBox.Show("حداقل یک مورد باید تیک تدارکات داشته باشد");
                    return;
                }
                if (string.IsNullOrEmpty(IntIdFormChart))
                {
                    obj.strID_FormUnit = ClsFlw.ID_FormUnit;
                    obj.strCodeFormX = lbl_IdEstelamBarge.Text;
                    obj.Insert_CodeFormX();
                    obj.strIdCodeFormX = obj.Select_CodeFormXMax().Tables[0].Rows[0]["IdCodeFormX"].ToString();
                    obj.strTozihat = txtTozihat.Text;
                    MessageBox.Show(obj.Insert_FormFlowTaeed());

                    obj.strIdVariable = "52";
                    if (chkIsFava.Checked == true)
                        obj.strValueVariable = "0";
                    else
                        obj.strValueVariable = "1";
                    obj.Update_Variable();

                    obj.strCheckTaeed = "1";
                    obj.strDescTaeed = txtErja.Text;
                    obj.strIdTaeed = obj.Select_TaeedMax().Tables[0].Rows[0][0].ToString();
                    obj.Update_FormFlowTaeed();
                    obj.Update_FormFlowTaeedActive();
                    obj.strIdPersonelChart = ClsMain.strIdPersonelChart;
                    obj.Update_FormFlowTaeedPersonelChart();
                    this.Close();
                }
                else
                {
                    obj.strValueVariable = "1";
                    obj.strIdMarhale = strIdMarhale;
                    obj.Update_VariableMarhale();

                    obj.strIdVariable = "52";
                    if (chkIsFava.Checked == true)
                        obj.strValueVariable = "0";
                    else
                        obj.strValueVariable = Convert.ToInt32(rdbBuy.Checked).ToString();
                    obj.Update_Variable();

                    if (Convert.ToInt16(strIdMarhale) == 2)
                    {
                        obj.strIdVariable = "53";
                        obj.strValueVariable = "1";
                        obj.strIdMarhale = strIdMarhale;
                        obj.Update_Variable();
                    }
                    if (Convert.ToInt16(strIdMarhale) == 4)
                    {
                        obj.strIdVariable = "60";
                        obj.strValueVariable = Convert.ToInt32(chkIsQC.Checked).ToString();
                        obj.strIdMarhale = strIdMarhale;
                        obj.Update_Variable();
                    }
                    if (Convert.ToInt16(strIdMarhale) == 5)
                    {
                        obj.strIdVariable = "61";
                        obj.strValueVariable = "1";
                        obj.strIdMarhale = strIdMarhale;
                        obj.Update_Variable();
                    }
                    if (Convert.ToInt16(strIdMarhale) == 6)
                    {
                        obj.strIdVariable = "57";
                        obj.strValueVariable = "1";
                        obj.strIdMarhale = strIdMarhale;
                        obj.Update_Variable();
                    }
                    if (Convert.ToInt16(strIdMarhale) == 7)
                    {
                        obj.strIdVariable = "66";
                        obj.strValueVariable = "1";
                        obj.strIdMarhale = strIdMarhale;
                        obj.Update_Variable();
                    }
                    if (Convert.ToInt16(strIdMarhale) == 8)
                    {
                        obj.strIdVariable = "62";
                        obj.strValueVariable = "1";
                        obj.strIdMarhale = strIdMarhale;
                        obj.Update_Variable();
                    }
                    if (Convert.ToInt16(strIdMarhale) == 9)
                    {
                        obj.strIdVariable = "35";
                        obj.strValueVariable = "1";
                        obj.strIdMarhale = strIdMarhale;
                        obj.Update_Variable();
                    }
                    if (Convert.ToInt16(strIdMarhale) == 10)
                    {
                        obj.strIdVariable = "36";
                        obj.strValueVariable = "1";
                        obj.strIdMarhale = strIdMarhale;
                        obj.Update_Variable();
                    }

                    obj.strCheckTaeed = "1";
                    obj.strDescTaeed = txtErja.Text;
                    obj.strIdTaeed = strIdTaeed;

                    MessageBox.Show(obj.Update_FormFlowTaeed());
                    obj.Update_FormFlowTaeedActive();
                    obj.strIdTaeed = obj.Select_TaeedMax().Tables[0].Rows[0][0].ToString();
                    if (Convert.ToInt16(strIdMarhale) == 3 | Convert.ToInt16(strIdMarhale) == 2)
                        obj.strIdPersonelChart = cmbDarkhastKonande.SelectedValue.ToString();
                    else
                        obj.strIdPersonelChart = ClsMain.strIdPersonelChart;

                    obj.Update_FormFlowTaeedPersonelChart();
                    this.Close();
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
            dr["item"] = "آقای کاربخش";
            dr["id"] = "456";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["item"] = "آقای قهرمانی";
            dr["id"] = "303";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["item"] = "آقای صادقی";
            dr["id"] = "292";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["item"] = "آقای پازیان";
            dr["id"] = "475";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["item"] = "خانم خزائی";
            dr["id"] = "381";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["item"] = "خانم مرادی";
            dr["id"] = "355";
            dt.Rows.Add(dr);

            cmbDarkhastKonande.DataSource = dt;
            cmbDarkhastKonande.ValueMember = "id";
            cmbDarkhastKonande.DisplayMember = "item";

        }
        public void ShowData()
        {
            ClsFlw obj = new ClsFlw();
            strIdEstelamBarge = strCodeFormX;
            lbl_IdEstelamBarge.Text = strIdEstelamBarge;
            obj.strIdEstelamBarge = lbl_IdEstelamBarge.Text;
            grd.DataSource = obj.Select_EstelamBargeD().Tables[0];

            dt = obj.Select_EstelamBarge().Tables[0];
            if (dt.Rows.Count > 0)
            {
                txtDateBarge.Text = dt.Rows[0]["DateBarge"].ToString();
                txtUserInsert.Text = dt.Rows[0]["NAME"].ToString();
                txtTozihat.Text = dt.Rows[0]["TozihatBarge"].ToString();
                if (dt.Rows[0]["IsQC"].ToString() == "True")
                    chkIsQC.Checked = true;
                else
                    chkIsQC.Checked = false;
                if (dt.Rows[0]["IsFava"].ToString() == "True")
                    chkIsFava.Checked = true;
                else
                    chkIsFava.Checked = false;
                cmbDarkhastKonande.SelectedValue = Convert.ToInt32(dt.Rows[0]["IndexDarkhastKonande"].ToString());
                if (dt.Rows[0]["IsBuy"].ToString() == "True")
                    rdbBuy.Checked = true;
                else
                    rdbBuyNo.Checked = false;
            }
        }
    }
}

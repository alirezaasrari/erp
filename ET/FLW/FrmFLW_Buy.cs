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
    public partial class FrmFLW_Buy : Telerik.WinControls.UI.RadForm
    {
        public FrmFLW_Buy()
        {
            InitializeComponent();
        }
        public string strIdDarkhastKharid;
        public string strCkala, strIdTaeed, strIdFormChart, strIdMarhale, strSend, IntIdFormChart, strIdPersonelChart
            , strIdCodeFormX, strCodeFormX, strIdTafsili, strIdBuyH;
        DataTable dt = new DataTable();
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
                    obj.strID_FormUnit = ClsFlw.ID_FormUnit;
                    obj.strCodeFormX = txtIdDarkhastKharid.Text;
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

                    obj.strIdBuyH = strIdBuyH;
                    obj.Update_BuyH(cmbBuyTaeed.SelectedValue.ToString());

                    obj.strCheckTaeed = "1";
                    obj.strDescTaeed = txtErja.Text;
                    obj.strIdTaeed = strIdTaeed;

                    MessageBox.Show(obj.Update_FormFlowTaeed());
                    obj.Update_FormFlowTaeedActive();

                    obj.strIdTaeed = obj.Select_TaeedMax().Tables[0].Rows[0][0].ToString();
                    obj.strIdPersonelChart = cmbBuyTaeed.SelectedValue.ToString();

                    obj.Update_FormFlowTaeedPersonelChart();

                    this.Close();
                }
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
                obj.strIdDarkhastKharid = txtIdDarkhastKharid.Text;
                MessageBox.Show(obj.Ins_BuyHD());
                ShowData();
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }
        private void FrmFLW_Buy_Load(object sender, EventArgs e)
        {
            try
            {
                strIdDarkhastKharid = strCodeFormX;
                if (ClsFlw.Isnew == "1")
                {
                    grpCreate.Enabled = true;
                    btnSabtHeader.Enabled = true;
                }
                if (Convert.ToInt32(strIdMarhale) < 3)
                {
                    grpCreate.Enabled = true;
                }
                if (strIdDarkhastKharid != null)
                {
                    txtIdDarkhastKharid.Text = strIdDarkhastKharid;
                    btnSabtHeader.Enabled = false;
                    SetCmb();
                    ShowData();
                }
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }
        public void ShowData()
        {
            ClsFlw obj = new ClsFlw();
            obj.strIdDarkhastKharid = txtIdDarkhastKharid.Text;
            dt = obj.Select_BuyH().Tables[0];
            if (dt.Rows.Count > 0)
            {
                txtDateInsert.Text = dt.Rows[0]["DateInsert"].ToString();
                txtN_darkhastkonande.Text = dt.Rows[0]["N_darkhastkonande"].ToString();
                cmbBuyTaeed.SelectedValue = Convert.ToInt32(dt.Rows[0]["IdTaeedKonande"].ToString());
                obj.strIdBuyH = dt.Rows[0]["IdBuyH"].ToString();
                grd.DataSource = obj.Select_BuyD().Tables[0];
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
            dr["item"] = "آقای صادقی";
            dr["id"] = "292";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["item"] = "آقای شرفی";
            dr["id"] = "27";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["item"] = "آقای بیناباجی";
            dr["id"] = "50";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["item"] = "آقای اکبری";
            dr["id"] = "472";
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
            dr["item"] = "خانم جوادی";
            dr["id"] = "419";
            dt.Rows.Add(dr);

            cmbBuyTaeed.DataSource = dt;
            cmbBuyTaeed.ValueMember = "id";
            cmbBuyTaeed.DisplayMember = "item";           
        }
    }
}

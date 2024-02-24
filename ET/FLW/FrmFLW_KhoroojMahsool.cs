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
    public partial class FrmFLW_KhoroojMahsool : Telerik.WinControls.UI.RadForm
    {
        public FrmFLW_KhoroojMahsool()
        {
            InitializeComponent();
        }
        public string IdKhoroojAghlam, strSend;
        public string IntLevelTaeed, strIdTaeed, IntIdFormChart, IntIdMarhale, strNew;
        private void FrmFLW_KhoroojMahsool_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            ClsFlw obj = new ClsFlw();
            cmbAghlam.DataSource = obj.Select_AghlamH().Tables[0];
            cmbAghlam.ValueMember = "aghlam_code";
            cmbAghlam.DisplayMember = "aghlam_code";

            cmbKhorooji.DataSource = obj.Select_KhoroojiHOrder(txtIdOrder.Text).Tables[0];
            cmbKhorooji.ValueMember = "KhNO";
            cmbKhorooji.DisplayMember = "KhNO";

            SetCmb();
            dt = obj.Select_KhoroojAghlam(IdKhoroojAghlam).Tables[0];
            if (dt.Rows.Count > 0)
            {
                cmbAghlam.Text = dt.Rows[0]["IdAghlam"].ToString();
                btnAghlam_Click(sender, e);
                cmbKhorooji.Text = dt.Rows[0]["IdKhorooj"].ToString();
                btnKhorooj_Click(sender, e);
                cmbModirForoosh.SelectedValue = Convert.ToInt32(dt.Rows[0]["IdModirForoosh"].ToString());
                cmbkarshenasForoosh.SelectedValue = Convert.ToInt32(dt.Rows[0]["IdKarshenasForoosh"].ToString());
            }

            if (Convert.ToInt32(IntIdMarhale) < 4)
            {
                btnAddKhorooji.Enabled = true;
                btnPrint.Enabled = true;
            }
            if (Convert.ToInt32(IntIdMarhale) == 1)
            {
                btnUpdateAghlam.Enabled = true;
            }
            if (ClsFlw.Isnew == "1")
            {
                btnSabtAghlam.Enabled = true;
            }
            if (Convert.ToInt32(IntIdMarhale) == 4)
            {
                btnBack.Visible = true;
            }
        }

        private void cmbAghlam_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                ClsFlw obj = new ClsFlw();
                DataTable dt = new DataTable();
                obj.strAghlam = cmbAghlam.SelectedValue.ToString();
                dt = obj.Select_AghlamH().Tables[0];
                txtCustomer.Text = dt.Rows[0]["m_name"].ToString();
                txtIdOrder.Text = dt.Rows[0]["order_code"].ToString();
                txtTafsili2.Text = dt.Rows[0]["tafsili_name"].ToString();
                txtTozihat.Text = dt.Rows[0]["Hcomment"].ToString();
                txtDateAghlam.Text = dt.Rows[0]["sabt_date"].ToString();
                grdAghlam.DataSource = obj.Select_AghlamD(obj.strAghlam).Tables[0];
            }
            catch
            { }
        }

        private void btnSabtAghlam_Click(object sender, EventArgs e)
        {
            try
            {
                if (strSend == "0" | IntIdMarhale != null)
                {
                    MessageBox.Show("امکان تغییر اطلاعات وجود ندارد");
                    return;
                }
                ClsFlw obj = new ClsFlw();
                obj.strAghlam = cmbAghlam.Text;
                obj.strIdModirForoosh = cmbModirForoosh.SelectedValue.ToString();
                MessageBox.Show(obj.Ins_KhoroojiAghlamH());
                grdAghlam.DataSource = obj.Select_AghlamD(obj.strAghlam).Tables[0];
                IdKhoroojAghlam = obj.Select_KhoroojAghlamMax().Tables[0].Rows[0][0].ToString();
                btnAghlam.Enabled = false;

                obj.strID_FormUnit = "14";
                obj.strCodeFormX = IdKhoroojAghlam;
                obj.Insert_CodeFormX();
                obj.strIdCodeFormX = obj.Select_CodeFormXMax().Tables[0].Rows[0]["IdCodeFormX"].ToString();
                obj.strTozihat = txtErja.Text;
                MessageBox.Show(obj.Insert_FormFlowTaeed());

                strIdTaeed = obj.Select_TaeedMax().Tables[0].Rows[0][0].ToString();
            }
            catch
            { }
        }

        private void btnUpdateAghlam_Click(object sender, EventArgs e)
        {
            try
            {
                if (strSend == "0" | IntIdMarhale != "1")
                {
                    MessageBox.Show("امکان تغییر اطلاعات وجود ندارد");
                    return;
                }
                ClsFlw obj = new ClsFlw();
                obj.strAghlam = cmbAghlam.Text;
                obj.strKhorooji = cmbKhorooji.Text;
                obj.strIdModirForoosh = cmbModirForoosh.SelectedValue.ToString();
                MessageBox.Show(obj.Update_KhoroojAghlam(IdKhoroojAghlam));
                grdAghlam.DataSource = obj.Select_AghlamD(obj.strAghlam).Tables[0];
            }
            catch
            { }
        }

        private void btnAddKhorooji_Click(object sender, EventArgs e)
        {
            try
            {
                if (strSend == "0" | Convert.ToInt32(IntIdMarhale) > 3)
                {
                    MessageBox.Show("امکان تغییر اطلاعات وجود ندارد");
                    return;
                }
                ClsFlw obj = new ClsFlw();
                obj.strKhorooji = cmbKhorooji.Text;
                obj.strIdModirForoosh = cmbModirForoosh.SelectedValue.ToString();
                obj.strIdKarshenasForoosh = cmbkarshenasForoosh.SelectedValue.ToString();
                obj.strAghlam = cmbAghlam.Text;
                MessageBox.Show(obj.Update_KhoroojAghlam(IdKhoroojAghlam));
                grdAghlam.DataSource = obj.Select_AghlamD(obj.strAghlam).Tables[0];
                IdKhoroojAghlam = obj.Select_KhoroojAghlamMax().Tables[0].Rows[0][0].ToString();
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
                if (strSend == "0")
                {
                    MessageBox.Show("امکان تایید وجود ندارد");
                    return;
                }
                ClsFlw obj = new ClsFlw();

                if (IntIdMarhale == "4")
                {
                    obj.strValueVariable = cmbkarshenasForoosh.SelectedValue.ToString();
                    obj.strIdVariable = "47";
                    obj.Update_Variable();

                    obj.strValueVariable = "0";
                    obj.strIdVariable = "48";
                    obj.Update_Variable();
                }
                if (IntIdMarhale == "2")
                {
                    obj.strValueVariable = cmbkarshenasForoosh.SelectedValue.ToString();
                    obj.strIdVariable = "47";
                    obj.Update_Variable();
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

        private void btnAghlam_Click(object sender, EventArgs e)
        {
            try
            {
                ClsFlw obj = new ClsFlw();
                DataTable dt = new DataTable();
                obj.strAghlam = cmbAghlam.Text;
                dt = obj.Select_AghlamH().Tables[0];
                txtCustomer.Text = dt.Rows[0]["m_name"].ToString();
                txtIdOrder.Text = dt.Rows[0]["order_code"].ToString();
                txtUserSabt.Text = dt.Rows[0]["UserSabtBarge"].ToString();
                txtTafsili2.Text = dt.Rows[0]["tafsili_name"].ToString();
                txtTozihat.Text = dt.Rows[0]["Hcomment"].ToString();
                txtDateAghlam.Text = dt.Rows[0]["sabt_date"].ToString();
                grdAghlam.DataSource = obj.Select_AghlamD(obj.strAghlam).Tables[0];
            }
            catch
            { }
        }

        private void cmbKhorooji_Enter(object sender, EventArgs e)
        {
            ClsFlw obj = new ClsFlw();
            if (txtIdOrder.Text != "")
            {
                cmbKhorooji.DataSource = obj.Select_KhoroojiHOrder(txtIdOrder.Text).Tables[0];
                cmbKhorooji.ValueMember = "KhNO";
                cmbKhorooji.DisplayMember = "KhNO";
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Report objReport = new Report();

                objReport.Load(ClsPublic.strRepPath + "KhoroojAghlam.frx");
                objReport.SetParameterValue("IdKhoroojAghlam", IdKhoroojAghlam);
                objReport.Print();
            }
            catch
            { }
        }

        private void btnKhorooj_Click(object sender, EventArgs e)
        {
            try
            {
                ClsFlw obj = new ClsFlw();
                DataTable dt = new DataTable();
                dt = obj.Select_KhoroojiH(cmbKhorooji.Text, txtIdOrder.Text).Tables[0];
                txtDateKhorooji.Text = dt.Rows[0]["KhDt"].ToString();
                txtHavale.Text = dt.Rows[0]["HvlNO"].ToString();
                txtAddrress.Text = dt.Rows[0]["AddressMaghsad"].ToString();
                grdKhorooji.DataSource = obj.Select_KhoroojiD(cmbKhorooji.Text).Tables[0];
            }
            catch
            { }
        }

        private void cmbKhorooji_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                ClsFlw obj = new ClsFlw();
                DataTable dt = new DataTable();
                dt = obj.Select_KhoroojiH(cmbKhorooji.Text,txtIdOrder.Text).Tables[0];
                txtDateKhorooji.Text = dt.Rows[0]["KhDt"].ToString();
                txtAddrress.Text = dt.Rows[0]["AddressMaghsad"].ToString();
                grdKhorooji.DataSource = obj.Select_KhoroojiD(cmbKhorooji.Text).Tables[0];
            }
            catch
            { }
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
                    //obj.strID_FormUnit = "14";
                    //obj.strCodeFormX = IdKhoroojAghlam;
                    //obj.Insert_CodeFormX();
                    //obj.strIdCodeFormX = obj.Select_CodeFormXMax().Tables[0].Rows[0]["IdCodeFormX"].ToString();
                    //obj.strTozihat = txtErja.Text;
                    //MessageBox.Show(obj.Insert_FormFlowTaeed());
                    obj.strValueVariable = cmbModirForoosh.SelectedValue.ToString();
                    obj.strIdVariable = "45";
                    obj.Update_Variable();

                    obj.strCheckTaeed = "1";
                    obj.strDescTaeed = txtErja.Text;
                    obj.strIdTaeed = strIdTaeed;

                    obj.Update_FormFlowTaeed();
                    obj.Update_FormFlowTaeedActive();
                    this.Close();
                }
                else
                {
                    ClsFlw obj = new ClsFlw();

                    if (IntIdMarhale == "1")
                    {
                        obj.strValueVariable = cmbModirForoosh.SelectedValue.ToString();
                        obj.strIdVariable = "45";
                        obj.Update_Variable();
                    }
                    if (IntIdMarhale == "2")
                    {
                        obj.strValueVariable = cmbkarshenasForoosh.SelectedValue.ToString();
                        obj.strIdVariable = "47";
                        obj.Update_Variable();
                    }
                    if (IntIdMarhale == "3")
                    {
                        obj.strValueVariable = cmbModirForoosh.SelectedValue.ToString();
                        obj.strIdVariable = "50";
                        obj.Update_Variable();
                    }
                    if (IntIdMarhale == "5")
                    {
                        obj.strValueVariable = cmbModirForoosh.SelectedValue.ToString();
                        obj.strIdVariable = "47";
                        obj.Update_Variable();

                        obj.strValueVariable = "1";
                        obj.strIdVariable = "48";
                        obj.Update_Variable();
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
            dr["item"] = "آقای غلامی";
            dr["id"] = "1";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["item"] = "آقای پرهیزگار";
            dr["id"] = "2";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["item"] = "آقای سیدی";
            dr["id"] = "3";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["item"] = "آقای بیدل";
            dr["id"] = "4";
            dt.Rows.Add(dr);

            cmbModirForoosh.DataSource = dt;
            cmbModirForoosh.ValueMember = "id";
            cmbModirForoosh.DisplayMember = "item";
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
            dr2["item"] = "خانم قربانی";
            dr2["id"] = "1";
            dt2.Rows.Add(dr2);

            dr2 = dt2.NewRow();
            dr2["item"] = "خانم موسوی";
            dr2["id"] = "2";
            dt2.Rows.Add(dr2);

            dr2 = dt2.NewRow();
            dr2["item"] = "آقای بيدل";
            dr2["id"] = "3";
            dt2.Rows.Add(dr2);

            dr2 = dt2.NewRow();
            dr2["item"] = "آقای تقوي";
            dr2["id"] = "4";
            dt2.Rows.Add(dr2);

            dr2 = dt2.NewRow();
            dr2["item"] = "خانم طهماسبی";
            dr2["id"] = "5";
            dt2.Rows.Add(dr2);

            dr2 = dt2.NewRow();
            dr2["item"] = "خانم قدردان";
            dr2["id"] = "6";
            dt2.Rows.Add(dr2);

            dr2 = dt2.NewRow();
            dr2["item"] = "خانم عظيمي";
            dr2["id"] = "7";
            dt2.Rows.Add(dr2);

            dr2 = dt2.NewRow();
            dr2["item"] = "آقای خشی";
            dr2["id"] = "8";
            dt2.Rows.Add(dr2);

            dr2 = dt2.NewRow();
            dr2["item"] = "آقای رفاهی";
            dr2["id"] = "9";
            dt2.Rows.Add(dr2);

            dr2 = dt2.NewRow();
            dr2["item"] = "مالی";
            dr2["id"] = "10";
            dt2.Rows.Add(dr2);

            cmbkarshenasForoosh.DataSource = dt2;
            cmbkarshenasForoosh.ValueMember = "id";
            cmbkarshenasForoosh.DisplayMember = "item";

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.SqlClient;
using System.Globalization;
using Telerik.WinControls.UI;

namespace ET
{
    public partial class FrmBuy_Pish : Telerik.WinControls.UI.RadForm
    {
        public FrmBuy_Pish()
        {
            InitializeComponent();
        }

        public string strIdPish, strIdBarname;
        public int intTaeed = 0;
        ClsBuy clsBuyObj = new ClsBuy();
        ClsMain objMain = new ClsMain();
        DataSet ds = new DataSet();
        private void cmbMasool_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                clsBuyObj.strC_Personel = cmbMasool.SelectedValue.ToString();
                clsBuyObj.strC_kala = "";
                clsBuyObj.strActive = "1";
                AgrdPishSum.DataSource = clsBuyObj.Select_PishKala().Tables[0];
                gridViewTemplate1.DataSource = clsBuyObj.Select_PishKalaDetail().Tables[0];
            }
            catch
            { }
        }

        private void FrmBuy_Pish_Load(object sender, EventArgs e)
        {
            txtDate.Value = DateTime.Now;
            ////////////////////////////////////////////////////////////////////////////////
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
                    if(DtControlAccess.Rows[i]["n_control"].ToString()=="AgrdPishSum")
                        if (DtControlAccess.Rows[i]["isActive"].ToString() == "True")
                        {
                            intTaeed = 1;
                        }
                        else
                            intTaeed = 0;
                }
            }
            ////--------------------------
            ClsBuy clsBuyObj = new ClsBuy();
            clsBuyObj.UpdateBarnameDone();

            clsBuyObj.strC_Personel = "";
            clsBuyObj.strN_Personel = "";
            ds = clsBuyObj.SelectPersonelBuy();

            cmbMasool.DataSource = ds.Tables[0];
            cmbMasool.ValueMember = "Personel_ID";
            cmbMasool.DisplayMember = "name";           
            //////////////////////////////////
            //lblMasool.Text = ClsMain.StrPersonerId;
            //clsBuyObj.strC_Personel = lblMasool.Text;
            //clsBuyObj.strC_kala = "";
            //clsBuyObj.strActive = "1";
            //AgrdPishSum.DataSource = clsBuyObj.Select_PishKala().Tables[0];
            //gridViewTemplate1.DataSource = clsBuyObj.Select_PishKalaDetail().Tables[0];
        }

        private void btnSabt_Click(object sender, EventArgs e)
        {
            try
            {
                double intMeghdarIns = 0;
                double intMeghdarDarkhast = 0;
                clsBuyObj.strMeghdarPish = txtMeghdarPart.Text;
                clsBuyObj.strDataPish = txtDate.Text;
                clsBuyObj.strC_Personel = lblMasool.Text;
                clsBuyObj.strC_kala = AgrdPishSum.CurrentRow.Cells["C_kala"].Value.ToString();
                intMeghdarDarkhast = Convert.ToDouble(AgrdPishSum.CurrentRow.Cells["baghimande_Buy"].Value.ToString());
                clsBuyObj.strComment = txtComment.Text;

                while (intMeghdarIns < intMeghdarDarkhast && Convert.ToDouble(clsBuyObj.Select_PishInsPart().Tables[0].Rows[0][3].ToString()) > 0)
                {
                    intMeghdarIns += Convert.ToDouble(clsBuyObj.Select_PishInsPart().Tables[0].Rows[0][3].ToString());
                    clsBuyObj.insPish();
                    if (clsBuyObj.Select_PishInsPart().Tables[0].Rows.Count == 0)
                        break;
                }
                ////////////////////////////////////////////////////////////
                clsBuyObj.strC_Personel = lblMasool.Text;
                clsBuyObj.strC_kala = "";
                clsBuyObj.strActive = "1";
                AgrdPishSum.DataSource = clsBuyObj.Select_PishKala().Tables[0];
                gridViewTemplate1.DataSource = clsBuyObj.Select_PishKalaDetail().Tables[0];
                MessageBox.Show("عملیات با موفقیت انجام شد");
            }
            catch
            {
                MessageBox.Show("خطا در اجرا");
            }
        }

        private void AgrdPishSum_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            txtDarkhast.Text = "";
            txtDate.Text = "";
            txtMeghdarPart.Text = "";
            txtPartNo.Text = "";
            txtRadif.Text = "";
            try
            {
                if (AgrdPishSum.CurrentRow.HierarchyLevel == 1)
                {
                    txtDarkhast.Text = AgrdPishSum.Templates[0].Rows[e.RowIndex].Cells["Sho_Darkhast"].Value.ToString();
                    txtRadif.Text = AgrdPishSum.Templates[0].Rows[e.RowIndex].Cells["Radif_Darkhast"].Value.ToString();
                    strIdBarname = AgrdPishSum.Templates[0].Rows[e.RowIndex].Cells["Barname_ID"].Value.ToString();
                    txtPartNo.Text = AgrdPishSum.Templates[0].Rows[e.RowIndex].Cells["partNo"].Value.ToString();
                    txtMeghdarPart.Text = AgrdPishSum.Templates[0].Rows[e.RowIndex].Cells["Meghdar"].Value.ToString();
                    txtDate.Text = AgrdPishSum.Templates[0].Rows[e.RowIndex].Cells["DatePish"].Value.ToString();
                    txtComment.Text = AgrdPishSum.Templates[0].Rows[e.RowIndex].Cells["CommentPish"].Value.ToString();
                    strIdPish = AgrdPishSum.Templates[0].Rows[e.RowIndex].Cells["IdPish"].Value.ToString();

                    btnInsert.Enabled = true;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                    btnSabt.Enabled = false;

                    txtPartNo.Enabled = true;
                    //txtComment.Enabled = true;
                }
                else
                {
                    btnInsert.Enabled = false;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    btnSabt.Enabled = true;

                    txtPartNo.Enabled = false;
                    //txtComment.Enabled = false;
                }
                    lblNkala.Text = AgrdPishSum.CurrentRow.Cells["Nkala"].Value.ToString();
            }
            catch
            {

            }
        }

        private void cmbMasool_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            clsBuyObj.strIdPish = strIdPish;
            MessageBox.Show(clsBuyObj.DelPish());

            ////////////////////////////////////////////////////////////
            clsBuyObj.strC_Personel = lblMasool.Text;
            clsBuyObj.strC_kala = "";
            clsBuyObj.strActive = "1";
            AgrdPishSum.DataSource = clsBuyObj.Select_PishKala().Tables[0];
            gridViewTemplate1.DataSource = clsBuyObj.Select_PishKalaDetail().Tables[0];
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            clsBuyObj.strIdPish = strIdPish;
            clsBuyObj.strDataPish = txtDate.Text;
            clsBuyObj.strMeghdarPish = txtMeghdarPart.Text;
            clsBuyObj.Part = txtPartNo.Text;
            clsBuyObj.strComment = txtComment.Text;
            //clsBuyObj.intTaeed = 0;
            MessageBox.Show(clsBuyObj.UpdatePish());
            ////////////////////////////////////////////////////////////
            clsBuyObj.strC_Personel = lblMasool.Text;
            clsBuyObj.strC_kala = "";
            clsBuyObj.strActive = "1";
            AgrdPishSum.DataSource = clsBuyObj.Select_PishKala().Tables[0];
            gridViewTemplate1.DataSource = clsBuyObj.Select_PishKalaDetail().Tables[0];
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            clsBuyObj.strIdPish = strIdPish;
            clsBuyObj.strDataPish = txtDate.Text;
            clsBuyObj.strMeghdarPish = txtMeghdarPart.Text;
            clsBuyObj.Part = txtPartNo.Text;
            clsBuyObj.strComment = txtComment.Text;
            clsBuyObj.Barname_ID = strIdBarname;
            MessageBox.Show(clsBuyObj.InsPishDetail());
            ///////////////////////////////////////////////////////////////
            clsBuyObj.strC_Personel = lblMasool.Text;
            clsBuyObj.strC_kala = "";
            clsBuyObj.strActive = "1";
            AgrdPishSum.DataSource = clsBuyObj.Select_PishKala().Tables[0];
            gridViewTemplate1.DataSource = clsBuyObj.Select_PishKalaDetail().Tables[0];
        }

        private void txtComment_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("fa-IR"));
        }

        private void MasterTemplate_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (AgrdPishSum.CurrentRow.HierarchyLevel == 1)
            {
                if (intTaeed == 1)
                {
                    if (AgrdPishSum.Templates[0].CurrentColumn.FieldName == "Taeed")
                    {
                        //MessageBox.Show(AgrdPishSum.Templates[0].Rows[e.RowIndex].Cells["Taeed"].Value.ToString());
                        if (AgrdPishSum.Templates[0].Rows[e.RowIndex].Cells["Taeed"].Value.ToString() == "True")
                        {
                            clsBuyObj.intTaeed = 0;
                            AgrdPishSum.Templates[0].Rows[e.RowIndex].Cells["Taeed"].Value = 0;
                        }
                        else
                        {
                            clsBuyObj.intTaeed = 1;
                            AgrdPishSum.Templates[0].Rows[e.RowIndex].Cells["Taeed"].Value = 1;
                        }
                        clsBuyObj.strIdPish = AgrdPishSum.Templates[0].Rows[e.RowIndex].Cells["IdPish"].Value.ToString();
                        clsBuyObj.strDataPish = AgrdPishSum.Templates[0].Rows[e.RowIndex].Cells["DatePish"].Value.ToString();
                        clsBuyObj.strMeghdarPish = AgrdPishSum.Templates[0].Rows[e.RowIndex].Cells["Meghdar"].Value.ToString();
                        clsBuyObj.Part = AgrdPishSum.Templates[0].Rows[e.RowIndex].Cells["partNo"].Value.ToString();
                        MessageBox.Show(clsBuyObj.UpdatePish());
                    }
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                lblMasool.Text = cmbMasool.SelectedValue.ToString();
                clsBuyObj.strC_Personel = lblMasool.Text;
                clsBuyObj.strC_kala = "";
                clsBuyObj.strActive = "1";
                AgrdPishSum.DataSource = clsBuyObj.Select_PishKala().Tables[0];
                gridViewTemplate1.DataSource = clsBuyObj.Select_PishKalaDetail().Tables[0];
            }
            catch { }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            clsBuyObj.strC_Personel = lblMasool.Text;
            clsBuyObj.strC_kala = "";
            clsBuyObj.strActive = "1";
            clsBuyObj.Barname_ID = "";
            AgrdPishSum.DataSource = clsBuyObj.Select_PishKala().Tables[0];
            gridViewTemplate1.DataSource = clsBuyObj.Select_PishKalaDetail().Tables[0];
        }

        private void AgrdPishSum_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            try
            {
                if (e.RowElement.RowInfo.Cells["MeghdarPart1"].Value.ToString() == "0")
                {
                    e.RowElement.DrawFill = true;
                    //e.RowElement.GradientStyle = GradientStyles.Solid;
                    e.RowElement.BackColor = Color.Aqua;
                }
                else
                {
                    e.RowElement.DrawFill = true;
                    e.RowElement.BackColor = Color.White;
                }
            }
            catch { }
        }

        private void btnTaeedAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا از تایید کلیه پیشبینی های این مسئول خرید اطمینان دارید؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    clsBuyObj.strC_Personel = lblMasool.Text;
                    MessageBox.Show(clsBuyObj.UpdatePishTaeedAll());

                    clsBuyObj.strC_Personel = lblMasool.Text;
                    clsBuyObj.strC_kala = "";
                    clsBuyObj.strActive = "1";
                    AgrdPishSum.DataSource = clsBuyObj.Select_PishKala().Tables[0];
                    gridViewTemplate1.DataSource = clsBuyObj.Select_PishKalaDetail().Tables[0];
                }
                catch
                {
                    MessageBox.Show("خطا در اجرا");
                }
            }                
        }
    }
}

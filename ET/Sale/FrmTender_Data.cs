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
    public partial class FrmTender_Data : Telerik.WinControls.UI.RadForm
    {
        public DataSet ds = new DataSet();
        public DataSet ds2 = new DataSet();
        public string strIdTender, strIdTenderDetail, strIdReason, strIdTenderReason, strIdTakhfifEzafe, strIdTenderStep, Taeed;
        public FrmTender_Data()
        {
            InitializeComponent();
        }

        private void txtTafsili_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmTafsili frm = new FrmTafsili();               
                frm.ShowDialog();
                txtTafsili.Text = frm.Ctifsili;
                lblTafsili.Text = frm.Ntafsili;
            }
        }

        private void btnAddTender_Click(object sender, EventArgs e)
        {
            ClsSale ObjSale = new ClsSale();
            ObjSale.strTenderName = txtTenderName.Text;
            ObjSale.strTenderType = rdbMonaghese.Checked.ToString();
            ObjSale.strTenderResult = cmbType.SelectedIndex.ToString();
            ObjSale.strTafsili= txtTafsili.Text;
            //ObjSale.strIdPFactor = txtPFactor.Text;
            ObjSale.strTafsili2 = txtTafsili2.Text;
            ObjSale.strDateTender = DateTender.Text;
            ObjSale.strDateTenderAZ = DateStart.Text;
            ObjSale.strDateTenderTA = DateEnd.Text;
            ObjSale.strDateSarResidAsnad = dateSarResidAsnad.Text;
            if (rdbJari.Checked == true)
                ObjSale.strTypePardakht = "1";
            else
                if (rdbAsnad.Checked == true)
                    ObjSale.strTypePardakht = "2";
                else
                    ObjSale.strTypePardakht = "3";
            ObjSale.strRank = txtRank.Text;
            ObjSale.strTozihat = txtTozihat.Text;
            ObjSale.strAfzayesh = txtAfzayesh.Text;
            ObjSale.strkahesh = txtKahesh.Text;
            ObjSale.strPishPardakht = txtPishPardakht.Text;
            ObjSale.strtedadRaghib = txtTedadRaghib.Text;

            MessageBox.Show(ObjSale.Insert_TenderHeader());
            
            ObjSale.strIdTender = ObjSale.Select_MaxTenderHeader().Tables[0].Rows[0][0].ToString();
            lblIdTender.Text = ObjSale.strIdTender;
            strIdTender = lblIdTender.Text;
            //ObjSale.Insert_TenderFromPF();

            //grdKala.DataSource = ObjSale.Select_TenderDetail().Tables[0];

            grpDetail.Enabled = true;
            btnAddReason.Enabled = true;
            cmbReason.Enabled = true;
            cmbType.Enabled = false;
        }

        private void btnEditTender_Click(object sender, EventArgs e)
        {
            ClsSale ObjSale = new ClsSale();
            ObjSale.strIdTender = strIdTender;
            ObjSale.strTenderName = txtTenderName.Text;
            //if (rdbMonaghese.Checked == true)
            //    ObjSale.strTenderType = "1";
            //else
            //    ObjSale.strTenderType = "0";
            ObjSale.strTenderType = rdbMonaghese.Checked.ToString();
            ObjSale.strTafsili = txtTafsili.Text;
            ObjSale.strTafsili2 = txtTafsili2.Text;
            //ObjSale.strIdPFactor = txtPFactor.Text;
            ObjSale.strDateTender = DateTender.Text;
            ObjSale.strDateTenderAZ = DateStart.Text;
            ObjSale.strDateTenderTA = DateEnd.Text;
            ObjSale.strDateSarResidAsnad = dateSarResidAsnad.Text;
            if (rdbJari.Checked == true)
                ObjSale.strTypePardakht = "1";
            else
                if (rdbAsnad.Checked == true)
                    ObjSale.strTypePardakht = "2";
                else
                    ObjSale.strTypePardakht = "3";
            ObjSale.strTenderResult = cmbType.SelectedIndex.ToString();
            ObjSale.strRank = txtRank.Text;
            ObjSale.strTozihat = txtTozihat.Text;
            ObjSale.strAfzayesh = txtAfzayesh.Text;
            ObjSale.strkahesh = txtKahesh.Text;
            ObjSale.strPishPardakht = txtPishPardakht.Text;
            ObjSale.strtedadRaghib = txtTedadRaghib.Text;
            MessageBox.Show(ObjSale.Update_TenderHeader());

            //ObjSale.Delete_TenderDetailAll();
            //ObjSale.Insert_TenderFromPF();
            grdKala.DataSource = ObjSale.Select_TenderDetail().Tables[0];
        }

        private void txtTafsili2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmTafsili2 frm = new FrmTafsili2();
                frm.ShowDialog();
                txtTafsili2.Text = frm.strCtafsili2;
                lblTafsili2.Text = frm.strNtafsili2;
            }
        }

        private void btnDelTender_Click(object sender, EventArgs e)
        {
            ClsSale objSale = new ClsSale();
            objSale.strIdTender = strIdTender;
            MessageBox.Show(objSale.Delete_TenderHeader());
            ClearHeader();
        }

        private void txtTenderName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                btnF2Tender_Click(sender, e);
            }
            //DataSet ds = new DataSet();
            //ClsSale objSale = new ClsSale();
            //try
            //{
            //    if (e.KeyCode == Keys.F2)
            //    {
            //        FrmTender_Show frm = new FrmTender_Show();
            //        frm.ShowDialog();
            //        lblIdTender.Text = strIdTender = frm.strIdTender;
            //        txtTenderName.Text = frm.strTenderName;

            //        objSale.strIdTender = strIdTender;
            //        ds = objSale.Select_TenderHeader();
            //        txtTenderName.Text = ds.Tables[0].Rows[0]["TenderName"].ToString();
            //        txtTafsili.Text = ds.Tables[0].Rows[0]["Tafsili"].ToString();
            //        lblTafsili.Text = ds.Tables[0].Rows[0]["nTafsili"].ToString();
            //        txtTafsili2.Text = ds.Tables[0].Rows[0]["Tafsili2"].ToString();
            //        lblTafsili2.Text = ds.Tables[0].Rows[0]["nTafsili2"].ToString();
            //        DateTender.Text = ds.Tables[0].Rows[0]["DateTender"].ToString();
            //        DateStart.Text = ds.Tables[0].Rows[0]["DateStart"].ToString();
            //        DateEnd.Text = ds.Tables[0].Rows[0]["DateEnd"].ToString();
            //        txtRank.Text = ds.Tables[0].Rows[0]["Rank"].ToString();
            //        txtTozihat.Text = ds.Tables[0].Rows[0]["Tozihat"].ToString();

            //        grdKala.DataSource = objSale.Select_TenderDetail().Tables[0];
            //        grdReason.DataSource = objSale.Select_TenderReason().Tables[0];
            //        //grdTakhfifEzafe.DataSource = objSale.Select_TenderTakhfifEzaf().Tables[0];
            //        //grdStep.DataSource = objSale.Select_TenderStep().Tables[0];
            //    }
            //}
            //catch { }
        }

        private void btnAddKala_Click(object sender, EventArgs e)
        {
            ClsSale objSale = new ClsSale();
            objSale.strIdTender = strIdTender;
            objSale.strCKala = lblCkala.Text;
            objSale.strCAnbar = txtCAnbar.Text;
            objSale.strTedad = txtTedad.Text;
            //objSale.strPrice = txtPrice.Text;
            objSale.strTozihatKala = txtTozihatKala.Text;

            MessageBox.Show(objSale.Insert_TenderDetail());
            grdKala.DataSource = objSale.Select_TenderDetail().Tables[0];
        }

        private void txtNkala_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmKala frm = new FrmKala();
                frm.ShowDialog();
                txtNkala.Text = ClsPublic.N_kala;
                lblCkala.Text = ClsPublic.C_kala;
                txtCAnbar.Text = ClsPublic.C_Anbar;
                lblNAnbar.Text = ClsPublic.N_Anbar;
            }
        }

        private void grdKala_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                strIdTenderDetail = grdKala.Rows[e.RowIndex].Cells["IdTenderDetail"].Value.ToString();
                txtNkala.Text = grdKala.Rows[e.RowIndex].Cells["N_Kala"].Value.ToString();
                lblCkala.Text = grdKala.Rows[e.RowIndex].Cells["CKala"].Value.ToString();
                txtCAnbar.Text = grdKala.Rows[e.RowIndex].Cells["CAnbar"].Value.ToString();
                lblNAnbar.Text = grdKala.Rows[e.RowIndex].Cells["N_anbar"].Value.ToString();
                txtTedad.Text = grdKala.Rows[e.RowIndex].Cells["Tedad"].Value.ToString();
                //txtPrice.Text = grdKala.Rows[e.RowIndex].Cells["Price"].Value.ToString();
                txtDarsadSood.Text = grdKala.Rows[e.RowIndex].Cells["DarsadSood"].Value.ToString();
                Taeed = grdKala.Rows[e.RowIndex].Cells["Taeed"].Value.ToString();

                btnEditKala.Enabled = true;
                btnDelKala.Enabled = true;
                btnAddKala.Enabled = false;
            }
            catch { }
        }

        private void btnEditKala_Click(object sender, EventArgs e)
        {
            if(Taeed=="True")
            {
                MessageBox.Show("این سطر تایید شده و امکان تغییر وجود ندارد");
                return;
            }
            ClsSale objSale = new ClsSale();
            objSale.strIdTenderDetail = strIdTenderDetail;
            objSale.strCKala = lblCkala.Text;
            objSale.strCAnbar = txtCAnbar.Text;
            objSale.strTedad = txtTedad.Text;
            //objSale.strPrice = txtPrice.Text;
            objSale.strTozihatKala = txtTozihatKala.Text;
            objSale.strDarsadSood = txtDarsadSood.Text;
            objSale.strTaeed = Taeed;

            MessageBox.Show(objSale.Update_TenderDetail());
            objSale.strIdTender = strIdTender;
            grdKala.DataSource = objSale.Select_TenderDetail().Tables[0];

            btnEditKala.Enabled = false;
            btnDelKala.Enabled = false;
            btnAddKala.Enabled = true;

            CalcFooter();
        }

        private void btnDelKala_Click(object sender, EventArgs e)
        {
            if (Taeed == "True")
            {
                MessageBox.Show("این سطر تایید شده و امکان تغییر وجود ندارد");
                return;
            }
            ClsSale objSale = new ClsSale();
            objSale.strIdTenderDetail = strIdTenderDetail;

            MessageBox.Show(objSale.Delete_TenderDetail());
            objSale.strIdTender = strIdTender;
            grdKala.DataSource = objSale.Select_TenderDetail().Tables[0];

            btnEditKala.Enabled = false;
            btnDelKala.Enabled = false;
            btnAddKala.Enabled = true;

            CalcFooter();
        }

        private void btnAddReason_Click(object sender, EventArgs e)
        {
            ClsSale objSale = new ClsSale();
            //ds = objSale.Select_TenderHeader();
            //if (ds.Tables[0].Rows[0]["TenderResult"].ToString() != cmbType.SelectedIndex.ToString())
            //{
            //    MessageBox.Show("نتیجه جدید با نتیجه قبلی متفاوت است");
            //    return;
            //}
            if (objSale.Select_TenderReason().Tables[0].Rows.Count == 0)
            {
                btnEditTender_Click(sender, e);
                cmbType.Enabled = false;
            }              
            
            lblIdTender.Text = objSale.strIdTender = strIdTender;
            objSale.strIdReason = cmbReason.SelectedValue.ToString();
            objSale.strDescReason = cmbReason.SelectedValue.ToString();
            MessageBox.Show(objSale.Insert_TenderReason());

            grdReason.DataSource = objSale.Select_TenderReason().Tables[0];
            cmbType.Enabled = false;
        }

        private void FrmTender_Data_Load(object sender, EventArgs e)
        {
            ClsSale objSale = new ClsSale();
            objSale.intWin = 1;
            cmbReason.DataSource = objSale.Select_Reason().Tables[0];
            cmbReason.ValueMember = "IdReason";
            cmbReason.DisplayMember = "DescReason";

            //cmbNameStep.DataSource = objSale.Select_Step().Tables[0];
            //cmbNameStep.ValueMember = "IdStep";
            //cmbNameStep.DisplayMember = "NameStep";

            DateTender.Value = DateTime.Now;
            DateStart.Value = DateTime.Now;
            DateEnd.Value = DateTime.Now;
            dateSarResidAsnad.Value = DateTime.Now;
            ClearHeader();
        }

        private void btnDelReason_Click(object sender, EventArgs e)
        {
            ClsSale objSale = new ClsSale();
            objSale.strIdTenderReason = strIdTenderReason;
            MessageBox.Show(objSale.Delete_TenderReason());

            objSale.strIdTender = strIdTender;
            grdReason.DataSource = objSale.Select_TenderReason().Tables[0];

            btnDelReason.Enabled = false;
            btnAddReason.Enabled = true;

            ds2 = objSale.Select_TenderReason();
            if (ds2.Tables[0].Rows.Count == 0)
                cmbType.Enabled = true;
            else
            {
                cmbType.Enabled = false;
            }
        }

        private void grdReason_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            strIdTenderReason = grdReason.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            cmbReason.Text = grdReason.Rows[e.RowIndex].Cells["DescReason"].Value.ToString();

            btnDelReason.Enabled = true;
            btnAddReason.Enabled = false;
        }

        private void btnF2kala_Click(object sender, EventArgs e)
        {
            FrmKala frm = new FrmKala();
            frm.strC_Anbar = "14,15";
            frm.ShowDialog();
            txtNkala.Text = ClsPublic.N_kala;
            lblCkala.Text = ClsPublic.C_kala;
            txtCAnbar.Text = ClsPublic.C_Anbar;
            lblNAnbar.Text = ClsPublic.N_Anbar;
        }

        private void btnF2Tender_Click(object sender, EventArgs e)
        {
                ClearHeader();
                try
                {
                    FrmTender_Show frm = new FrmTender_Show();
                    frm.ShowDialog();
                    if (frm.strIdTender == null)
                        strIdTender = "0";
                    else
                        lblIdTender.Text = strIdTender = frm.strIdTender;
                    txtTenderName.Text = frm.strTenderName;

                    ClsSale objSale = new ClsSale();
                    ClsSale objSale2 = new ClsSale();
                    objSale.strIdTender = strIdTender;
                    objSale2.strIdTender = strIdTender;
                    ds2 = objSale2.Select_TenderReason();
                    ds.Clear();
                    ds = objSale.Select_TenderHeader();
                    if (ds2.Tables[0].Rows.Count == 0)
                        cmbType.Enabled = true;
                    else
                    {
                        cmbType.SelectedIndex = Convert.ToInt16(ds.Tables[0].Rows[0]["TenderResult"].ToString());
                        cmbType.Enabled = false;
                    }

                    txtTenderName.Text = ds.Tables[0].Rows[0]["TenderName"].ToString();
                    if (ds.Tables[0].Rows[0]["TenderType"].ToString() == "True")
                        rdbMonaghese.Checked = true;
                    else
                        rdbEstelam.Checked = true;

                    txtTafsili.Text = ds.Tables[0].Rows[0]["Tafsili"].ToString();
                    lblTafsili.Text = ds.Tables[0].Rows[0]["nTafsili"].ToString();
                    txtTafsili2.Text = ds.Tables[0].Rows[0]["Tafsili2"].ToString();
                    lblTafsili2.Text = ds.Tables[0].Rows[0]["nTafsili2"].ToString();
                    //txtPFactor.Text = ds.Tables[0].Rows[0]["IdPFactor"].ToString();
                    DateTender.Text = ds.Tables[0].Rows[0]["DateTender"].ToString();
                    DateStart.Text = ds.Tables[0].Rows[0]["DateStart"].ToString();
                    DateEnd.Text = ds.Tables[0].Rows[0]["DateEnd"].ToString();
                    dateSarResidAsnad.Text = ds.Tables[0].Rows[0]["DateSarResidAsnad"].ToString();
                    if (ds.Tables[0].Rows[0]["TypePardakht"].ToString() == "1")
                        rdbJari.Checked = true;
                    else
                        if (ds.Tables[0].Rows[0]["TypePardakht"].ToString() == "2")
                            rdbAsnad.Checked = true;
                        else
                            rdbOragh.Checked = true;
                    txtRank.Text = ds.Tables[0].Rows[0]["Rank"].ToString();
                    txtTozihat.Text = ds.Tables[0].Rows[0]["Tozihat"].ToString();
                    txtAfzayesh.Text = ds.Tables[0].Rows[0]["Afzayesh"].ToString();
                    txtKahesh.Text = ds.Tables[0].Rows[0]["kahesh"].ToString();
                    txtPishPardakht.Text = ds.Tables[0].Rows[0]["PishPardakht"].ToString();
                    txtTedadRaghib.Text = ds.Tables[0].Rows[0]["tedadRaghib"].ToString();

                    grpDetail.Enabled = true;
                    btnAddReason.Enabled = true;
                    btnAddKala.Enabled = true;
                    btnEditTender.Enabled = true;
                    btnDelTender.Enabled = true;
                    btnAddTender.Enabled = false;
                    cmbReason.Enabled = true;
                    grdReason.DataSource = objSale.Select_TenderReason().Tables[0];

                    CalcFooter();
                }
                catch { }
        }
        public void ClearHeader()
        {
            txtTenderName.Text = "";
            txtTafsili.Text = "";
            lblTafsili.Text = "";
            txtTafsili2.Text = "";
            lblTafsili2.Text = "";
            txtPFactor.Text = "";
            DateTender.Text = "";
            DateStart.Text = "";
            DateEnd.Text = "";
            dateSarResidAsnad.Text = "";
            txtRank.Text = "";
            cmbType.Text = "";
            cmbReason.Text = "";
            txtTozihat.Text = "";
            txtAfzayesh.Text = "";
            txtKahesh.Text = "";
            txtPishPardakht.Text = "";
            txtTedadRaghib.Text = "";

            txtNkala.Text = "";
            lblCkala.Text = "_";
            txtCAnbar.Text = "";
            lblNAnbar.Text = "_";

            cmbReason.Enabled = false;
            btnAddReason.Enabled = false;
            btnDelReason.Enabled = false;           
            btnAddKala.Enabled = false;
            btnEditKala.EnableAnalytics = false;
            btnDelKala.EnableAnalytics = false;
            btnDelTender.Enabled = false;
            btnEditTender.Enabled = false;
            btnAddTender.Enabled = true;
            grpDetail.Enabled = false;

            grdKala.DataSource = null;
            grdReason.DataSource = null;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearHeader();
            //txtTenderName.Text = "";
            //txtTafsili.Text = "";
            //lblTafsili.Text = "";
            //txtTafsili2.Text = "";
            //lblTafsili2.Text = "";
            //DateTender.Text = "";
            //DateStart.Text = "";
            //DateEnd.Text = "";
            //txtRank.Text = "";
            //txtTozihat.Text = "";

            //grdKala.DataSource = null;
            //grdReason.DataSource = null;
            //grdTakhfifEzafe.DataSource = null;
            //grdStep.DataSource = null;

        }

        private void btnRefreshReason_Click(object sender, EventArgs e)
        {
            btnAddReason.Enabled = true;
            btnDelReason.Enabled = false;
        }

        private void btnRefreshDetail_Click(object sender, EventArgs e)
        {
            lblCkala.Text = "";
            txtCAnbar.Text = "";
            txtTedad.Text = "";
            //txtPrice.Text = "";
            txtTozihatKala.Text = "";
            txtDarsadSood.Text = "";

            btnEditKala.Enabled = false;
            btnDelKala.Enabled = false;
            btnAddKala.Enabled = true;
        }

        private void rdbAsnad_CheckedChanged(object sender, EventArgs e)
        {
            dateSarResidAsnad.Enabled = true;
            txtPishPardakht.Enabled = true;
            txtAfzayesh.Enabled = true;
            txtKahesh.Enabled = true;
        }

        private void rdbOragh_CheckedChanged(object sender, EventArgs e)
        {
            dateSarResidAsnad.Enabled = true;
            txtPishPardakht.Enabled = true;
            txtAfzayesh.Enabled = true;
            txtKahesh.Enabled = true;
        }

        private void rdbJari_CheckedChanged(object sender, EventArgs e)
        {
            dateSarResidAsnad.Enabled = false;
            txtPishPardakht.Enabled = false;
            txtAfzayesh.Enabled = false;
            txtKahesh.Enabled = false;
        }

        private void cmbType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            ClsSale objSale = new ClsSale();
            //objSale.intWin = Convert.ToInt16(chkTenderWin.Checked);
            objSale.intWin = Convert.ToInt16(cmbType.SelectedIndex.ToString());
            cmbReason.DataSource = objSale.Select_Reason().Tables[0];
            cmbReason.ValueMember = "IdReason";
            cmbReason.DisplayMember = "DescReason";
        }

        private void btnAddPFactor_Click(object sender, EventArgs e)
        {
            ClsSale objSale = new ClsSale();
            objSale.strIdPFactor = txtPFactor.Text;
            objSale.strTozihatPFactor = txtTozihatPF.Text;
            ds = objSale.Select_PFactorH();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (txtTafsili.Text == ds.Tables[0].Rows[0]["PfCMoshtari"].ToString())
                {
                    objSale.strIdTender = strIdTender;
                    if (objSale.Select_TenderDetail().Tables[0].Rows.Count > 0)
                        MessageBox.Show("این پیش فاکتور قبلا ثبت شده است");
                    else
                    {
                        MessageBox.Show(objSale.Insert_TenderFromPF());
                        objSale.strIdPFactor = "";
                        grdKala.DataSource = objSale.Select_TenderDetail().Tables[0];
                    }
                }
                else
                    MessageBox.Show("مشتری پیش فاکتور با مشتری مناقصه متفاوت است");
            }
            else
                MessageBox.Show("پیش فاکتور پیدا نشد");
        }

        private void grdKala_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            try
            {
                if (grdKala.Rows.Count > 0)
                    if (grdKala.Rows[e.RowIndex].Cells["taeed"].Value.ToString() == "True")
                    {
                        e.CellElement.DrawFill = true;
                        e.CellElement.ForeColor = Color.White;
                        e.CellElement.NumberOfColors = 1;
                        e.CellElement.BackColor = Color.Green;
                    }
                    else
                    {
                        e.CellElement.DrawFill = true;
                        e.CellElement.ForeColor = Color.Black;
                        e.CellElement.NumberOfColors = 1;
                        e.CellElement.BackColor = Color.White;
                    }
            }
            catch { }
        }

        private void grdKala_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                ClsSale objSale = new ClsSale();
                if (grdKala.CurrentCell.ColumnIndex == 19)
                {
                    if (grdKala.CurrentRow.Cells["Taeed"].Value.ToString() == "False")
                        Taeed = objSale.strTaeed = "True";
                    else
                        Taeed = objSale.strTaeed = "False";
                    objSale.strIdTenderDetail = grdKala.Rows[e.RowIndex].Cells["IdTenderDetail"].Value.ToString();
                    objSale.strPrice = grdKala.Rows[e.RowIndex].Cells["CostFinal"].Value.ToString();
                    objSale.strCKala = lblCkala.Text;
                    objSale.strCAnbar = txtCAnbar.Text;
                    objSale.strTedad = txtTedad.Text;
                    //objSale.strPrice = txtPrice.Text;
                    objSale.strTozihatKala = txtTozihatKala.Text;
                    objSale.strDarsadSood = txtDarsadSood.Text;
                    MessageBox.Show(objSale.Update_TenderDetail());
                    objSale.strIdTender = strIdTender;
                    objSale.strTaeed = Taeed;
                    objSale.Update_TenderDetailKala();
                    objSale.strIdTender = strIdTender;
                    grdKala.DataSource = objSale.Select_TenderDetail().Tables[0];
                }
            }
            catch { }
        }
        public void CalcFooter()
        {
            try
            {
                ClsSale objSale = new ClsSale();
                DataSet DsCalc = new DataSet();
                objSale.strIdTender = strIdTender;
                DsCalc = objSale.Select_TenderDetail();
                grdKala.DataSource = DsCalc.Tables[0];
                lblMablaghForoosh.Text = DsCalc.Tables[0].Compute("Sum(MablaghForoosh)", "1 = 1").ToString();
                lblMablaghFinal.Text = DsCalc.Tables[0].Compute("Sum(MablaghFinal)", "1 = 1").ToString();
                lblMablaghNoMEF.Text = DsCalc.Tables[0].Compute("Sum(MablaghNoMEF)", "1 = 1").ToString();

                lblDarsad.Text = (Convert.ToInt64(lblMablaghForoosh.Text) * 0.09).ToString();

                lblMablaghForooshK.Text = (Convert.ToDouble(lblMablaghForoosh.Text) + Convert.ToDouble(lblDarsad.Text)).ToString();
                lblMablaghFinalK.Text = Math.Round((Convert.ToDouble(lblMablaghForoosh.Text) - Convert.ToDouble(lblMablaghFinal.Text))
                                         / Convert.ToDouble(lblMablaghFinal.Text), 2).ToString();
                lblMablaghNoMEFK.Text = Math.Round((Convert.ToDouble(lblMablaghForoosh.Text) - Convert.ToDouble(lblMablaghNoMEF.Text))
                                         / Convert.ToDouble(lblMablaghNoMEF.Text), 2).ToString();
            }
            catch
            {
                MessageBox.Show("خطا در محاسبه مقادیر");
            }
        }

    }
}

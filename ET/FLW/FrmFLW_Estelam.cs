using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using FastReport;

namespace ET
{
    public partial class FrmFLW_Estelam : Telerik.WinControls.UI.RadForm
    {
        public string strIdMarhale, strSend, strCkala, strNkala, strIdTafsili, strIdEstelamBarge, strIdEstelamH;
        DataTable dt = new DataTable();
        public FrmFLW_Estelam()
        {
            InitializeComponent();
        }
        private void FrmFLW_Estelam_Load(object sender, EventArgs e)
        {           
            txtDateEstelamH.Value = DateTime.Now;
            txtDateEstelamD.Value = DateTime.Now;
            txtDateTahvil.Value = DateTime.Now;
            txtDateNiaz.Value = DateTime.Now;
            txtSabegheDate.Value = DateTime.Now;
            txtDateCheck1.Value = DateTime.Now;
            txtDateCheck2.Value = DateTime.Now;
            txtDateCheck3.Value = DateTime.Now;
            ShowData();

            if (ClsFlw.Isnew == "1")
            {
                grpCreate.Enabled = true;
                btnAdd.Enabled = true;
                btnEditD.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = false;
                btnEditD.Enabled = true;
            }
            if (Convert.ToInt16(strIdMarhale) > 5 & Convert.ToInt16(strIdMarhale) <= 9)
            {
                grpEnd.Enabled = true;
            }
            if (Convert.ToInt16(strIdMarhale) == 1)
            {
                grpDetail.Enabled= true;               
            }
            if (Convert.ToInt16(strIdMarhale) == 4 | Convert.ToInt16(strIdMarhale) == 3)
            {
                grpCreate.Enabled = true;
                btnUpdateHeader.Enabled = true;
            }
        }
        private void btnSabtHeader_Click(object sender, EventArgs e)
        {
            try
            {
                if (strSend == "0")
                {
                    MessageBox.Show("امکان تغییر وجود ندارد");
                    return;
                }
                ClsFlw obj = new ClsFlw();
                obj.strIdEstelamBarge = strIdEstelamBarge;
                obj.strDateEstelam = txtDateEstelamH.Text;
                obj.strIdDarkhastKharid = txtIdDarkhastKharid.Text;
                obj.strCkala = strCkala;
                obj.strNkala = strNkala;
                obj.strIsMojudi = Convert.ToInt16(chkIsMojudi.Checked).ToString();
                obj.strIsSefaresh = Convert.ToInt16(chkIsSefaresh.Checked).ToString();
                obj.strEntebaghBuy = Convert.ToInt16(chkEntebaghBuy.Checked).ToString();
                obj.strDateNiaz = txtDateNiaz.Text;
                obj.strTozihatMojoodi = txtTozihatMojoodi.Text;
                obj.strTozihatMazad = txtTozihatMazad.Text;
                obj.strTozihatModirAmel = txtTozihatModirAmel.Text;
                obj.strMojoodi = txtMojoodi.Text;
                obj.strMazadDarkast = txtMazadDarkast.Text;
                obj.strSabegheMeghdar = txtSabegheMeghdar.Text;
                obj.strSabegheMablagh= txtSabegheMablagh.Text;
                obj.strSabegheDate = txtSabegheDate.Text;
                obj.strSabegheTaminKonande = txtSabegheTaminKonande.Text;
                obj.strAvgMasraf = txtAvgMasraf.Text;
                MessageBox.Show(obj.Ins_EstelamH());
                lbl_IdEstelamH.Text = obj.Select_EstelamHMax().Tables[0].Rows[0][0].ToString();
                strIdEstelamH = lbl_IdEstelamH.Text;
                ShowData();

                grpDetail.Enabled = true;
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Report objReport = new Report();

                objReport.Load(ClsPublic.strRepPath + "Estelam.frx");
                objReport.SetParameterValue("IdEstelamH", lbl_IdEstelamH.Text);
                objReport.Print();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnUpdate2_Click(object sender, EventArgs e)
        {
            try
            {
                if (strSend == "0")
                {
                    MessageBox.Show("امکان تغییر وجود ندارد");
                    return;
                }
                ClsFlw obj = new ClsFlw();
                obj.strMablagh = txtMablaghH.Text;
                obj.strTedadChek = txtTedadChek.Text;
                obj.strDateChek = txtDateChek.Text;
                obj.strTozihat = txtTozihat.Text;
                obj.strTozihatMaliAnbar = txtTozihatMaliAnbar.Text;
                obj.strTozihatMaliModiriat = txtTozihatMaliModiriat.Text;
                MessageBox.Show(obj.Update_EstelamH2(lbl_IdEstelamH.Text));
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        private void btnSearchBuy_Click(object sender, EventArgs e)
        {
            FrmBuy_DarkhastSearch frm = new FrmBuy_DarkhastSearch();
            frm.ShowDialog();
            txtIdDarkhastKharid.Text = frm.strIdDarkhastKharid;
            txtNKala.Text = frm.strNkala;
            strCkala = frm.strCkala;
            txtTozihatMojoodi.Text = frm.strMored_masraf;
            txtDateNiaz.Text = frm.strDateNiaz;
            Sabeghe();
            AvgMasraf();
        }

        private void btnEditD_Click(object sender, EventArgs e)
        {
            try
            {
                if (strSend == "0")
                {
                    MessageBox.Show("امکان تغییر وجود ندارد");
                    return;
                }
                ClsFlw obj = new ClsFlw();
                obj.strIdEstelamH = lbl_IdEstelamH.Text;
                obj.strIdTafsili = strIdTafsili;
                obj.strMeghdar = txtMeghdar.Text;
                obj.strMablagh = txtMablagh.Text;
                obj.strDateCheck1 = txtDateCheck1.Text;
                obj.strDateCheck2 = txtDateCheck2.Text;
                obj.strDateCheck3 = txtDateCheck3.Text;
                obj.strMablaghCheck1 = txtMablaghCheck1.Text;
                obj.strMablaghCheck2 = txtMablaghCheck2.Text;
                obj.strMablaghCheck3 = txtMablaghCheck3.Text;
                obj.strDateEstelam = txtDateEstelamD.Text;
                obj.strPersonelBuy = txtPersonelBuy.Text;
                //obj.strTell = txtTell.Text;
                obj.strDateTahvil = txtDateTahvil.Text;
                obj.strMojoodi = txtMojoodi.Text;
                obj.strDateNiaz = txtDateNiaz.Text;
                obj.strIsJari = Convert.ToInt16(rdbJari.IsChecked).ToString();
                obj.strTozihatD = txtTozihatD.Text;
                MessageBox.Show(obj.Update_EstelamD(txtShomareRadifOk.Text));

                grd.DataSource = obj.Select_EstelamD().Tables[0];
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        private void btnF2Tafsili_Click(object sender, EventArgs e)
        {
            FrmTafsili frm = new FrmTafsili();
            frm.ShowDialog();
            txtNameTaminKonande.Text = frm.Ntafsili;
            strIdTafsili = frm.Ctifsili;
        }

        private void grd_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {           
            if (e.Column.Name == "btnDelete")
            {
                if (strSend == "0")
                {
                    MessageBox.Show("امکان تغییر وجود ندارد");
                    return;
                }
                if (Convert.ToInt16(strIdMarhale) > 2)
                {
                    MessageBox.Show("امکان حذف وجود ندارد");
                    return;
                }
                ClsFlw obj = new ClsFlw();
                obj.strIdEstelamD = grd.Rows[e.RowIndex].Cells["IdEstelamD"].Value.ToString();
                MessageBox.Show(obj.Delete_EstelamD());
                obj.strIdEstelamD = null;
                obj.strIdEstelamH = lbl_IdEstelamH.Text;
                grd.DataSource = obj.Select_EstelamD().Tables[0];
            }
            if (e.Column.Name == "btnDoc")
            {
                FrmFLW_EstelamDoc frm = new FrmFLW_EstelamDoc();
                frm.IdEstelamD = grd.Rows[e.RowIndex].Cells["IdEstelamD"].Value.ToString();
                frm.ShowDialog();
            }
            if (e.Column.Name == "IsOkeyBuy")
            {
                if (strSend == "0")
                {
                    MessageBox.Show("امکان تغییر وجود ندارد");
                    return;
                }
                ClsFlw obj = new ClsFlw();
                if (Convert.ToInt16(strIdMarhale) < 4)
                    obj.Update_EstelamDTaeedBuy(grd.Rows[e.RowIndex].Cells["IdEstelamD"].Value.ToString());
                obj.strIdEstelamH = lbl_IdEstelamH.Text;
                grd.DataSource = obj.Select_EstelamD().Tables[0];
            }
            if (e.Column.Name == "IsOkey")
            {
                if (strSend == "0")
                {
                    MessageBox.Show("امکان تغییر وجود ندارد");
                    return;
                }
                ClsFlw obj = new ClsFlw();
                if (Convert.ToInt16(strIdMarhale) == 4 | Convert.ToInt16(strIdMarhale) == 9 | Convert.ToInt16(strIdMarhale) == 10)
                    obj.Update_EstelamDTaeedFinal(grd.Rows[e.RowIndex].Cells["IdEstelamD"].Value.ToString());
                obj.strIdEstelamH = lbl_IdEstelamH.Text;
                grd.DataSource = obj.Select_EstelamD().Tables[0];
            }
            if (e.Column.Name == "IsOkeyQC")
            {
                if (strSend == "0")
                {
                    MessageBox.Show("امکان تغییر وجود ندارد");
                    return;
                }
                ClsFlw obj = new ClsFlw();
                if (Convert.ToInt16(strIdMarhale) == 5)
                    obj.Update_EstelamDTaeedQC(grd.Rows[e.RowIndex].Cells["IdEstelamD"].Value.ToString());
                obj.strIdEstelamH = lbl_IdEstelamH.Text;
                grd.DataSource = obj.Select_EstelamD().Tables[0];
            }
            if (e.Column.Name == "IsOkeyMali")
            {
                if (strSend == "0")
                {
                    MessageBox.Show("امکان تغییر وجود ندارد");
                    return;
                }
                ClsFlw obj = new ClsFlw();
                if (Convert.ToInt16(strIdMarhale) == 8)
                    obj.Update_EstelamDTaeedMali(grd.Rows[e.RowIndex].Cells["IdEstelamD"].Value.ToString());
                obj.strIdEstelamH = lbl_IdEstelamH.Text;
                grd.DataSource = obj.Select_EstelamD().Tables[0];
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
        }

        private void btnF2Kala_Click(object sender, EventArgs e)
        {
            FrmKala frm = new FrmKala();
            frm.ShowDialog();
            txtNKala.Text = ClsBuy.N_kala;
            strCkala = ClsBuy.C_kala;
            strNkala = ClsBuy.N_kala;
            lblCkala.Text = strCkala;
            Sabeghe();
            AvgMasraf();
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
        }

        private void txtMablagh_TextChanged(object sender, EventArgs e)
        {

        }

        private void grd_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            

            txtNameTaminKonande.Text = grd.Rows[e.RowIndex].Cells["nMoshtari"].Value.ToString();
            txtMeghdar.Text = grd.Rows[e.RowIndex].Cells["Meghdar"].Value.ToString();
            txtMablagh.Text = grd.Rows[e.RowIndex].Cells["Mablagh"].Value.ToString();
            txtDateCheck1.Text = grd.Rows[e.RowIndex].Cells["DateCheck1"].Value.ToString();
            txtDateCheck2.Text = grd.Rows[e.RowIndex].Cells["DateCheck2"].Value.ToString();
            txtDateCheck3.Text = grd.Rows[e.RowIndex].Cells["DateCheck3"].Value.ToString();
            txtMablaghCheck1.Text = grd.Rows[e.RowIndex].Cells["MablaghCheck1"].Value.ToString();
            txtMablaghCheck2.Text = grd.Rows[e.RowIndex].Cells["MablaghCheck2"].Value.ToString();
            txtMablaghCheck3.Text = grd.Rows[e.RowIndex].Cells["MablaghCheck3"].Value.ToString();
            txtDateEstelamD.Text = grd.Rows[e.RowIndex].Cells["DateEstelam"].Value.ToString();
            txtPersonelBuy.Text = grd.Rows[e.RowIndex].Cells["PersonelBuy"].Value.ToString();
            //txtTell.Text = grd.Rows[e.RowIndex].Cells["Tell"].Value.ToString();
            txtDateTahvil.Text = grd.Rows[e.RowIndex].Cells["DateTahvil"].Value.ToString();
            txtMablaghKol.Text = grd.Rows[e.RowIndex].Cells["MablaghKol"].Value.ToString();
            txtMablaghAfz.Text = grd.Rows[e.RowIndex].Cells["MablaghAfz"].Value.ToString();
            txtZamanVariz.Text = grd.Rows[e.RowIndex].Cells["ZamanVariz"].Value.ToString();
            txtMablaghVariz.Text = grd.Rows[e.RowIndex].Cells["MablaghVariz"].Value.ToString();
            txtSharhPardakht.Text = grd.Rows[e.RowIndex].Cells["SharhPardakht"].Value.ToString();
            if (Convert.ToInt32(grd.Rows[e.RowIndex].Cells["Jari"].Value) == 1)
                rdbJari.IsChecked = true;
            else
                rdbBodje.IsChecked = true;
        }

        private void btnUpdateHeader_Click(object sender, EventArgs e)
        {
            try
            {
                if (strSend == "0")
                {
                    MessageBox.Show("امکان تغییر وجود ندارد");
                    return;
                }
                ClsFlw obj = new ClsFlw();
                obj.strDateEstelam = txtDateEstelamH.Text;
                obj.strIdDarkhastKharid = txtIdDarkhastKharid.Text;
                obj.strCkala = strCkala;
                obj.strIsMojudi = Convert.ToInt16(chkIsMojudi.Checked).ToString();
                obj.strIsSefaresh = Convert.ToInt16(chkIsSefaresh.Checked).ToString();
                obj.strEntebaghBuy = Convert.ToInt16(chkEntebaghBuy.Checked).ToString();
                obj.strDateNiaz = txtDateNiaz.Text;
                obj.strSabegheMeghdar = txtSabegheMeghdar.Text;
                obj.strSabegheMablagh = txtSabegheMablagh.Text;
                obj.strSabegheDate = txtSabegheDate.Text;
                obj.strSabegheTaminKonande = txtSabegheTaminKonande.Text;
                if (Convert.ToInt16(strIdMarhale) == 4)
                    MessageBox.Show(obj.Update_EstelamHDateNiaz(lbl_IdEstelamH.Text));
                else
                    MessageBox.Show(obj.Update_EstelamH(lbl_IdEstelamH.Text));
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }       
        public void ShowData()
        {
            try
            {
                ClsFlw obj = new ClsFlw();
                lbl_IdEstelamH.Text = strIdEstelamH;
                obj.strIdEstelamH = lbl_IdEstelamH.Text;
                dt = obj.Select_EstelamH().Tables[0];
                if (dt.Rows.Count > 0)
                {
                    lbl_IdEstelamH.Text = dt.Rows[0]["IdEstelamH"].ToString();
                    txtDateEstelamH.Text = dt.Rows[0]["DateEstelam"].ToString();
                    txtIdDarkhastKharid.Text = dt.Rows[0]["IdDarkhastKharid"].ToString();
                    txtNKala.Text = dt.Rows[0]["N_Kala"].ToString();
                    strCkala = dt.Rows[0]["Ckala"].ToString();
                    lblCkala.Text = strCkala;                    
                    txtTozihat.Text = dt.Rows[0]["Tozihat"].ToString();
                    txtShomareRadifOk.Text = dt.Rows[0]["ShomareRadifOk"].ToString();
                    txtMablaghH.Text = dt.Rows[0]["Mablagh"].ToString();
                    txtDateChek.Text = dt.Rows[0]["DateChek"].ToString();
                    txtTedadChek.Text = dt.Rows[0]["TedadChek"].ToString();
                    txtMojoodi.Text = dt.Rows[0]["Mojoodi"].ToString();
                    txtTozihatMojoodi.Text = dt.Rows[0]["TozihatMojoodi"].ToString();
                    txtMandeDkharid.Text = dt.Rows[0]["MandeDkharid"].ToString();
                    txtDateDarkhastBuy.Text = dt.Rows[0]["DateDarkhastBuy"].ToString();
                    txtMazadDarkast.Text = dt.Rows[0]["MazadDarkast"].ToString();
                    txtTozihatMazad.Text = dt.Rows[0]["TozihatMazadDarkast"].ToString();
                    txtTozihatModirAmel.Text = dt.Rows[0]["TozihatModirAmel"].ToString();
                    txtDateNiaz.Text = dt.Rows[0]["DateNiaz"].ToString();
                    txtSabegheMablagh.Text = (dt.Rows[0]["SabegheMablagh"].ToString());
                    txtSabegheMeghdar.Text = dt.Rows[0]["SabegheMeghdar"].ToString();
                    txtSabegheDate.Text = dt.Rows[0]["SabegheDate"].ToString();
                    txtSabegheTaminKonande.Text = dt.Rows[0]["SabegheTaminKonande"].ToString();

                    obj.strIdEstelamH = lbl_IdEstelamH.Text;
                    grd.DataSource = obj.Select_EstelamD().Tables[0];
                }

                obj.strIdEstelamD = txtShomareRadifOk.Text;
                dt = obj.Select_EstelamD().Tables[0];
                if (dt.Rows.Count > 0)
                {
                    txtNameTaminKonande.Text = dt.Rows[0]["NameTafsili"].ToString();
                    strIdTafsili = dt.Rows[0]["IdTafsili"].ToString();
                    txtMeghdar.Text = dt.Rows[0]["Meghdar"].ToString();
                    txtMablagh.Text = (dt.Rows[0]["Mablagh"].ToString());
                    txtDateCheck1.Text = dt.Rows[0]["DateCheck1"].ToString(); 
                    txtDateCheck2.Text = dt.Rows[0]["DateCheck2"].ToString();
                    txtDateCheck3.Text = dt.Rows[0]["DateCheck3"].ToString();
                    txtMablaghCheck1.Text = dt.Rows[0]["MablaghCheck1"].ToString();
                    txtMablaghCheck2.Text = dt.Rows[0]["MablaghCheck2"].ToString();
                    txtMablaghCheck3.Text = dt.Rows[0]["MablaghCheck3"].ToString();
                    txtDateEstelamD.Text = dt.Rows[0]["DateEstelam"].ToString();
                    txtPersonelBuy.Text = dt.Rows[0]["PersonelBuy"].ToString();
                    //txtTell.Text = dt.Rows[0]["Tell"].ToString();
                    txtDateTahvil.Text = dt.Rows[0]["DateTahvil"].ToString();
                    txtMablaghKol.Text = (dt.Rows[0]["MablaghKol"].ToString());
                    txtMablaghAfz.Text = (dt.Rows[0]["MablaghAfz"].ToString());
                    txtZamanVariz.Text = (dt.Rows[0]["ZamanVariz"].ToString());
                    txtMablaghVariz.Text = (dt.Rows[0]["MablaghVariz"].ToString());
                    txtSharhPardakht.Text = dt.Rows[0]["SharhPardakht"].ToString();
                    if (Convert.ToInt32(dt.Rows[0]["Jari"]) == 1)
                        rdbJari.IsChecked = true;
                    else
                        rdbBodje.IsChecked = true;
                }
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (strSend == "0")
                {
                    MessageBox.Show("امکان تغییر وجود ندارد");
                    return;
                }
                ClsFlw obj = new ClsFlw();
                obj.strIdEstelamH = lbl_IdEstelamH.Text;
                obj.strIdTafsili = strIdTafsili;
                obj.strNameTaminkonande = txtNameTaminKonande.Text;
                obj.strMeghdar = txtMeghdar.Text;
                //obj.strMeghdarFarie = txtMeghdarFarie.Text;
                obj.strMablagh = txtMablagh.Text;

                obj.strDateCheck1 = txtDateCheck1.Text;
                obj.strDateCheck2 = txtDateCheck2.Text;
                obj.strDateCheck3 = txtDateCheck3.Text;
                obj.strMablaghCheck1 = txtMablaghCheck1.Text;
                obj.strMablaghCheck2 = txtMablaghCheck2.Text;
                obj.strMablaghCheck3 = txtMablaghCheck3.Text;

                obj.strDateEstelam = txtDateEstelamD.Text;
                obj.strPersonelBuy = txtPersonelBuy.Text;
                //obj.strTell = txtTell.Text;
                obj.strDateTahvil = txtDateTahvil.Text;
                obj.strMojoodi = txtMojoodi.Text;
                obj.strDateNiaz = txtDateNiaz.Text;
                obj.strTozihatD = txtTozihatD.Text;
                obj.strTellMozakere = txtTellMozakere.Text;
                if (txtMablagh.Text == "" | txtMeghdar.Text == "")
                {
                    MessageBox.Show("وارد کردن فیلدهای مبلغ و مقدار الزامی است");
                    return;
                }
                obj.strIsJari = Convert.ToInt16(rdbJari.IsChecked).ToString();
                txtMablaghKol.Text = (Convert.ToInt32(txtMeghdar.Text) * Convert.ToInt32(txtMablagh.Text)).ToString();
                txtMablaghAfz.Text = (Convert.ToInt32(txtMablaghKol.Text) + Convert.ToInt32(txtMablaghKol.Text) * 0.9).ToString();
                if (txtMablagh.Text == "" | obj.strIdEstelamH == null)
                {
                    MessageBox.Show("شماره استعلام نامشخص است");
                    return;
                }
                MessageBox.Show(obj.Ins_EstelamD());
                
                grd.DataSource = obj.Select_EstelamD().Tables[0];
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }
        public static string ToIranianCurrencyFormat(string numberString)
            {
                if (string.IsNullOrWhiteSpace(numberString))
                {
                    return numberString;
                }

                int groupSize = 3;
                List<string> groups = new List<string>();
                int i;

                for (i = numberString.Length - 1; i >= 0; i -= groupSize)
                {
                    if (i - groupSize + 1 < 0)
                    {
                        groups.Add(numberString.Substring(0, i + 1));
                    }
                    else
                    {
                        groups.Add(numberString.Substring(i - groupSize + 1, groupSize));
                    }
                }

                groups.Reverse();
                return string.Join(",", groups);
            }

        public void Sabeghe()
        {
            try
            {
                DataTable dt = new DataTable();
                ClsFlw obj = new ClsFlw();
                obj.strCkala = strCkala;
                dt = obj.Select_Sabeghe().Tables[0];
                if (dt.Rows.Count > 0)
                {
                    txtSabegheMeghdar.Text = (dt.Rows[0]["meghdar"].ToString());
                    txtSabegheMablagh.Text = (dt.Rows[0]["mablagh"].ToString());
                    txtSabegheDate.Text = dt.Rows[0]["date"].ToString();
                    txtSabegheTaminKonande.Text = dt.Rows[0]["nam_thvl"].ToString();
                }


                ClsAnbar obja = new ClsAnbar();
                obja.strC_Kala = strCkala;
                dt = obja.SelectMojudi().Tables[0];
                txtMojoodi.Text = dt.Rows[0]["Mojodi"].ToString();
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        public void AvgMasraf()
        {
            try
            {
                DataTable dt = new DataTable();
                ClsFlw obj = new ClsFlw();
                obj.strCkala = strCkala;
                dt = obj.Select_AvgMasraf().Tables[0];
                txtAvgMasraf.Text = dt.Rows[0][0].ToString();
            }
            catch { }
        }
    }
}

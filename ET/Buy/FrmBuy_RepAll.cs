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
using System.IO;
using FastReport;

namespace ET
{
    public partial class FrmBuy_RepAll : Telerik.WinControls.UI.RadForm
    {
        public FrmBuy_RepAll()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.rgd.TableElement.BeginUpdate();
            this.rgd.EnableFiltering = true;
            this.rgd.AllowAddNewRow = false;
            this.rgd.ReadOnly = true;
            this.rgd.MasterTemplate.ShowHeaderCellButtons = true;
            this.rgd.MasterTemplate.ShowFilteringRow = false;
            this.rgd.TableElement.EndUpdate();

        }
        DataSet ds = new DataSet();
         SaveFileDialog sfd = new SaveFileDialog();
         public int typeRep;
         private void FrmBuy_RepAll_Load(object sender, EventArgs e)
         {             
             dtpDateDarkhast1.Value = DateTime.Now;
             dtpDateDarkhast2.Value = DateTime.Now;
             ClsBuy clsBuyObj = new ClsBuy();
             //clsBuyObj.UpdateBarnameDone();
             //clsBuyObj.insBarnameAUS();

             clsBuyObj.intSabt = 3;
             clsBuyObj.intDone = 3;
             clsBuyObj.strNum_Darkhast = "";
             clsBuyObj.strDate1 = "";
             clsBuyObj.strdate_niyaz1 = "";
             clsBuyObj.strC_anbar = "";
             clsBuyObj.strC_kala = "";
             clsBuyObj.strNum_Darkhast = "";
             clsBuyObj.strNum_Darkhast = "";
             clsBuyObj.strNum_Darkhast = "";
             rgd_tajmi.Visible = false;
             rgd.Visible = true;
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
             try
             {
                 //if (File.Exists(@"C:\Users\" + Environment.UserName + @"\AppData\Local\rgd.xml"))
                 //    this.rgd.LoadLayout(@"C:\Users\" + Environment.UserName + @"\AppData\Local\rgd.xml");
                 //if (File.Exists(@"C:\Users\" + Environment.UserName + @"\AppData\Local\rgd_tajmi.xml"))
                 //    this.rgd_tajmi.LoadLayout(@"C:\Users\" + Environment.UserName + @"\AppData\Local\rgd_tajmi.xml");

                 if (File.Exists(@"C:\Users\" + Environment.UserName + @"\AppData\Local\rgd.xml"))
                     File.Delete(@"C:\Users\" + Environment.UserName + @"\AppData\Local\rgd.xml");
                 if (File.Exists(@"C:\Users\" + Environment.UserName + @"\AppData\Local\rgd_tajmi.xml"))
                     File.Delete(@"C:\Users\" + Environment.UserName + @"\AppData\Local\rgd_tajmi.xml");
             }
             catch { }
         }
        public void clear_str()
        {
            ClsBuy clsBuyObj = new ClsBuy();
            clsBuyObj.intAll_d = 0;
            clsBuyObj.intMande_d = 0;
            clsBuyObj.intKamel_d = 0;
            clsBuyObj.intEzafe_d = 0;
            clsBuyObj.inttadarokat = 0;
            clsBuyObj.intPeymankar = 0;
            clsBuyObj.intMoghayerat = 0;
            clsBuyObj.strNum_Darkhast = "";
            clsBuyObj.strDate1 = "";
            clsBuyObj.strDate2 = "";
            clsBuyObj.strDate1 = "";
            clsBuyObj.strdate_niyaz1 = "";
            clsBuyObj.strdate_niyaz2 = "";
            clsBuyObj.strC_anbar = "";
            clsBuyObj.strZ_anbar = "";
            clsBuyObj.strC_kala = "";
        }
        private void chkCkala_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCkala.Checked == true)
                txtCkala.Enabled = true;
            else
                txtCkala.Enabled = false;
        }

        private void txtCkala_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmKala frm = new FrmKala();
                frm.ShowDialog();
                txtCkala.Text = ClsBuy.C_kala;
                lbln_kala.Text = ClsBuy.N_kala;
            }
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDate.Checked == true)
            {
                dtpDateDarkhast1.Enabled = true;
                dtpDateDarkhast2.Enabled = true;
            }

            else
            {
                dtpDateDarkhast1.Enabled = false;
                dtpDateDarkhast2.Enabled = false;
            }
        }

        private void chkAnbar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAnbar.Checked == true)
            {
                txtCanbar.Enabled = true;
                txtCanbar2.Enabled = true;
            }
            else
            {
                txtCanbar.Enabled = false;
                txtCanbar2.Enabled = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            typeRep = 0;
            rgd_tajmi.Visible = false;
            ClsBuy clsBuyObj = new ClsBuy();

            if (rbtnAll_d.Checked==true )
            {
               clsBuyObj.intAll_d=1;
            }
            else
            {
                clsBuyObj.intAll_d=0;
            }
            if ( rbtnMande_d.Checked==true )
            {
                clsBuyObj.intMande_d=1;
            }
            else
            {
                clsBuyObj.intMande_d=0;
            }
         
            if (rbtnKamel_d.Checked==true )
            {
                clsBuyObj.intKamel_d=1;
            }
            else
            {
                clsBuyObj.intKamel_d=0;
            }
            if ( rbtnEzafe_d.Checked == true )
            {
                clsBuyObj.intEzafe_d=1;
            }
            else
            {
                clsBuyObj.intEzafe_d=0;
            }
           //------------------------------------------be tafkik
      
            if (rbtn_tadarokat.Checked==true)  //tadarokat
            {
                clsBuyObj.inttadarokat=1;
            }
            else
            {
                clsBuyObj.inttadarokat=0;
            }

            if( rbtn_peymankar.Checked==true )     //peymankar
            {
                clsBuyObj.intPeymankar=1;
            }
            else
            {
                clsBuyObj.intPeymankar=0;
            }

      //----------------------------------------------------
            if ( chkMoghayerat.Checked==true )  //tadarokat
            { 
                clsBuyObj.intMoghayerat=1;
            }
            else
            {
                clsBuyObj.intMoghayerat=0;
            }
            if (chkMoghayerat2.Checked == true)  //tadarokat
            {
                clsBuyObj.intMoghayerat2 = 1;
            }
            else
            {
                clsBuyObj.intMoghayerat2 = 0;
            }

      //------------------------------------------

          if(( chkNumD.Checked==true ) & (txtNum_d.Text !=""))
          {
             clsBuyObj.strNum_Darkhast=txtNum_d.Text;
          }
          else
          {
            clsBuyObj.strNum_Darkhast="";
          }


        //--------------
        if ((chkDate.Checked==true ) &(dtpDateDarkhast1.Text!="") &(dtpDateDarkhast2.Text!=""))
        {
            clsBuyObj.strDate1 = dtpDateDarkhast1.Value.ToString().Substring(0, 10);
            clsBuyObj.strDate2 = dtpDateDarkhast2.Value.ToString().Substring(0, 10);

        }
        else
        {
            clsBuyObj.strDate1 = "";
            clsBuyObj.strDate2 = "";
            
        }
        //------------
          
        if ((chkDate_niyaz.Checked==true )&(date_niyaz1.Text!="")&(date_niyaz2.Text!=""))
        {
            clsBuyObj.strdate_niyaz1 =date_niyaz1.Value.ToString().Substring(0, 10);
            clsBuyObj.strdate_niyaz2 = date_niyaz2.Value.ToString().Substring(0, 10);
        }
        else
        {
            clsBuyObj.strdate_niyaz1 = "";
            clsBuyObj.strdate_niyaz2 = "";
        }
        //------------

        //if(( chkNDarkhast.Checked==true )&(txtN_darkhast.Text !=""))
        //{
        //   clsBuyObj.strNDarkhast=txtN_darkhast.Text;
        //}
        //else
        //{
            
        //}
       
        //--------------
        if ((chkAnbar.Checked == true) & (txtCanbar.Text != ""))
        {
            clsBuyObj.strC_anbar = txtCanbar.Text;
            clsBuyObj.strC_anbar2 = txtCanbar2.Text;
        }
        else
            clsBuyObj.strC_anbar = "";
            
        if ((chkZAnbar.Checked == true) & (txtZanbar.Text != ""))
            clsBuyObj.strZ_anbar = txtZanbar.Text;
        else
            clsBuyObj.strZ_anbar = "";
       
        //---------------------
        if ((chkCkala.Checked==true )& ( txtCkala.Text!=""))
        {
            clsBuyObj.strC_kala=txtCkala.Text;
        }
        else
        {
            clsBuyObj.strC_kala = "";
        }
        if (ShowNoSabt.Enabled == true)
            clsBuyObj.strShowNoSabt = "1";
        else
            clsBuyObj.strShowNoSabt = "0";
        //--------------------------------------------be tartib
        //if( rbtnDate_d.Checked==true )
        //{
        //   clsBuyObj.intDate_d=1;
        //}
        //else
        //{
        //    clsBuyObj.intDate_d=0;
        //}
        //    if( rbtnNum_d.Checked==true )
        //{
        //   clsBuyObj.intNum_d=1;
        //}
        //else
        //{
        //    clsBuyObj.intNum_d=0;
        //}
        //if( rbtnc_kala.Checked==true )
        //{
        //   clsBuyObj.intc_kala=1;
        //}
        //else
        //{
        //    clsBuyObj.intc_kala=0;
        //}

             //     ===

            clsBuyObj.intSabt = 3;
            clsBuyObj.intDone = 3;
            rgd.Visible = true;
            ds= clsBuyObj.Search_RepAll("1");
            rgd.DataSource = ds.Tables[0];
            gridViewTemplate1.DataSource = clsBuyObj.Select_resid().Tables[0];
            gridViewTemplate2.DataSource = clsBuyObj.Select_KhorojAnbar().Tables[0];
            gridViewTemplate3.DataSource = clsBuyObj.Select_Estelam().Tables[0];
            clear_str();
        }
        
        private void txtZanbar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //lblN_Zanbar.Text = txtZanbar.Text;
            }
            catch
            { }
        }

        private void txtZanbar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2)
                {
                    FrmZAnbar frm = new FrmZAnbar();
                    frm.strC_Anbar = txtCanbar.Text;
                    frm.strC_Anbar2 = txtCanbar2.Text;
                    frm.ShowDialog();
                    txtZanbar.Text = ClsAnbar.C_ZAnbar;
                    lblN_Zanbar.Text = ClsAnbar.N_ZAnbar;
                }
            }
            catch { }
        }

        private void chkNumD_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNumD.Checked == true)
                txtNum_d.Enabled = true;
            else
                txtNum_d.Enabled = false;
        }

        private void chkNDarkhast_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkDate_niyaz_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDate_niyaz.Checked == true)
            {
                date_niyaz1.Enabled = true;
                date_niyaz2.Enabled = true;
            }

            else
            {
                date_niyaz1.Enabled = false;
                date_niyaz2.Enabled = false;
            }
        }

        private void btn_serach_tajmie_Click(object sender, EventArgs e)
        {
            typeRep = 1;
            ClsBuy clsBuyObj = new ClsBuy();

            if (rbtnAll_d.Checked == true)
            {
                clsBuyObj.intAll_d = 1;
            }
            else
            {
                clsBuyObj.intAll_d = 0;
            }
            if (rbtnMande_d.Checked == true)
            {
                clsBuyObj.intMande_d = 1;
            }
            else
            {
                clsBuyObj.intMande_d = 0;
            }

            if (rbtnKamel_d.Checked == true)
            {
                clsBuyObj.intKamel_d = 1;
            }
            else
            {
                clsBuyObj.intKamel_d = 0;
            }
            if (rbtnEzafe_d.Checked == true)
            {
                clsBuyObj.intEzafe_d = 1;
            }
            else
            {
                clsBuyObj.intEzafe_d = 0;
            }
            //------------------------------------------be tafkik

            if (rbtn_tadarokat.Checked == true)  //tadarokat
            {
                clsBuyObj.inttadarokat = 1;
            }
            else
            {
                clsBuyObj.inttadarokat = 0;
            }

            if (rbtn_peymankar.Checked == true)     //peymankar
            {
                clsBuyObj.intPeymankar = 1;
            }
            else
            {
                clsBuyObj.intPeymankar = 0;
            }

            //----------------------------------------------------
            if (chkMoghayerat.Checked == true)  //tadarokat
            {
                clsBuyObj.intMoghayerat = 1;
            }
            else
            {
                clsBuyObj.intMoghayerat = 0;
            }
            if (chkMoghayerat2.Checked == true)  //tadarokat
            {
                clsBuyObj.intMoghayerat2 = 1;
            }
            else
            {
                clsBuyObj.intMoghayerat2 = 0;
            }

            //------------------------------------------

            if ((chkNumD.Checked == true) & (txtNum_d.Text != ""))
            {
                clsBuyObj.strNum_Darkhast = txtNum_d.Text;
            }
            else
            {
                clsBuyObj.strNum_Darkhast = "";
            }


            //--------------
            if ((chkDate.Checked == true) & (dtpDateDarkhast1.Text != "") & (dtpDateDarkhast2.Text != ""))
            {
                clsBuyObj.strDate1 = dtpDateDarkhast1.Value.ToString().Substring(0, 10);
                clsBuyObj.strDate2 = dtpDateDarkhast2.Value.ToString().Substring(0, 10);
            }
            else
            {
                clsBuyObj.strDate1 = "";
                clsBuyObj.strDate2 = "";

            }
            //------------

            if ((chkDate_niyaz.Checked == true) & (date_niyaz1.Text != "") & (date_niyaz2.Text != ""))
            {
                clsBuyObj.strdate_niyaz1 = dtpDateDarkhast1.Value.ToString().Substring(0, 10);
                clsBuyObj.strdate_niyaz2 = dtpDateDarkhast2.Value.ToString().Substring(0, 10);
            }
            else
            {
                clsBuyObj.strdate_niyaz1 = "";
                clsBuyObj.strdate_niyaz2 = "";
            }
            //--------------
            if ((chkAnbar.Checked == true) & (txtCanbar.Text != ""))
            {
                clsBuyObj.strC_anbar = txtCanbar.Text;
                clsBuyObj.strC_anbar2 = txtCanbar2.Text;
            }
            else
                clsBuyObj.strC_anbar = "";

            if ((chkZAnbar.Checked == true) & (txtZanbar.Text != ""))
                clsBuyObj.strZ_anbar = txtZanbar.Text;
            else
                clsBuyObj.strZ_anbar = "";
            //---------------------
            if ((chkCkala.Checked == true) & (txtCkala.Text != ""))
            {
                clsBuyObj.strC_kala = txtCkala.Text;
            }
            else
            {
                clsBuyObj.strC_kala = "";
            }
            if (ShowNoSabt.Enabled == true)
                clsBuyObj.strShowNoSabt = "1";
            else
                clsBuyObj.strShowNoSabt = "0";
            //     ===

            clsBuyObj.intSabt = 3;
            clsBuyObj.intDone = 3;
            rgd.Visible = false;
            rgd_tajmi.Visible = true;
            ds=clsBuyObj.Search_RepAll("2");
            rgd_tajmi.DataSource = ds.Tables[0];
            clear_str();

        }

        private void rgd_tajmi_Click(object sender, EventArgs e)
        {

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            //if (!tbFileName.Text.Equals(string.Empty))
            //{
            //    ExportToExcelML exporter = new ExportToExcelML(rgd);
            //    exporter.RunExport(tbFileName.Text);
            //    MessageBox.Show("فایل \n" + sfd.FileName + "\nایجاد شد");
            //}

            string fileName = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = string.Format("{0} (*{1})|*{1}", "Excel Files", ".xls")
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
            }
            if (typeRep == 0)
                (new ExportToExcelML(this.rgd)).RunExport(fileName);
            else
                (new ExportToExcelML(this.rgd_tajmi)).RunExport(fileName);
            if (RadMessageBox.Show("اطلاعات به درستی خارج شد.آیا می خواهید فایل باز شود؟", "Export to Excel", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
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

        private void chkZAnbar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkZAnbar.Checked == true)
            {
                txtZanbar.Enabled = true;
            }
            else
            {
                txtZanbar.Enabled = false;
            }
        }

        private void FrmBuy_RepAll_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.rgd.SaveLayout(@"C:\Users\" + Environment.UserName + @"\AppData\Local\rgd.xml");
            this.rgd_tajmi.SaveLayout(@"C:\Users\" + Environment.UserName + @"\AppData\Local\rgd_tajmi.xml");
        }

        private void txtCanbar2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                txtCanbar2.Text = txtCanbar.Text;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ClsBuy objBuy = new ClsBuy();
            DataSet ds = new DataSet();
            if (txtNum_d.Text=="")
            {
                MessageBox.Show("شماره درخواست جهت چاپ را وارد کنید");
                return;
            }
            objBuy.strSho_Darkhast = txtNum_d.Text;
            ds = objBuy.Select_PrintDarkhast();
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("امکان چاپ وجود ندارد");
                return;
            }

            Report objReport = new Report();

            objReport.Load(ClsPublic.strRepPath + "DarkhastKharid.frx");
            objReport.SetParameterValue("@Sho_Darkhast", ds.Tables[0].Rows[0]["TXTIDDARKHAST"].ToString());
            objReport.SetParameterValue("@picGhaemMagham", ClsPublic.strPicPath + ds.Tables[0].Rows[0]["GhaemMagham"].ToString() + ".png");
            objReport.SetParameterValue("@picSefareshat", ClsPublic.strPicPath + ds.Tables[0].Rows[0]["Sefareshat"].ToString() + ".png");
            objReport.SetParameterValue("@picTaminKonande", ClsPublic.strPicPath + ds.Tables[0].Rows[0]["TaminKonande"].ToString() + ".png");
            objReport.SetParameterValue("@picUser", ClsPublic.strPicPath + ds.Tables[0].Rows[0]["TXTFIRSTIDUSER"].ToString() + ".png");
            objReport.SetParameterValue("@picModir", ClsPublic.strPicPath + ds.Tables[0].Rows[0]["TXTFIRSTUSERIDMODIR"].ToString() + ".png");
            objReport.SetParameterValue("@DateTeed", ds.Tables[0].Rows[0]["TXTDATEGHAEM"].ToString());
            objReport.SetParameterValue("@TYPETAMIN", ds.Tables[0].Rows[0]["RBTNTYPETAMIN_LABEL"].ToString());
            objReport.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (new PleaseWait(this.Location))
            {
                ClsBuy clsBuyObj = new ClsBuy();
                clsBuyObj.UpdateBarnameDone();
                clsBuyObj.insBarnameAUS();
                btnSearch_Click( sender,  e);
            }
        }
    }
}

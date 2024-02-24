using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.OleDb;
using System.Data.SqlClient;
using Telerik.WinControls.UI.Export;
using System.Diagnostics;

namespace ET
{
    public partial class FrmCostPrice : Telerik.WinControls.UI.RadForm
    {
        public FrmCostPrice()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        OleDbDataAdapter daCSV = new OleDbDataAdapter();
        public DataSet Ds = new DataSet();
        public SqlConnection Connect = new SqlConnection();
        ClsConnect Clsconnect = new ClsConnect();
        public string strid_Gheteh, strIdPeymankardata;
        public string strIsOutSource, strIsTarkib, strIsKharid;
        public bool CostBuy;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtGhetehCode.Text.Trim()=="")
            {
                RadMessageBox.Show(" کالا را تعیین کنید");
                return;
            }
            ClsMali objMali = new ClsMali();           
            //objMali.strId_Gheteh = strid_Gheteh;
            objMali.strGhetehCode = txtGhetehCode.Text.Trim();
            objMali.strGhetehAnbar = txtGhetehAnbar.Text.Trim();
            objMali.strPriceKala = txtPriceCustom.Text;
            MessageBox.Show(objMali.InsCostPrice());

            objMali.CostBuy = (CostBuy).ToString();
            grdCostPrice.DataSource = objMali.SelectCostPrice("1").Tables[0];
           //txtC_Tafsili_TextChanged(sender, e);
        }       
        public void ClearControl()
        {
            //txtN_Tafsili.Text = "";
            txtGhetehCode.Text = "";
            txtGheteName.Text = "";
            txtGhetehAnbar.Clear();
            //txtCountInDay.Text = "";
            txtPriceResid.Text = "";
            txtPriceCustom.Text = "";
            ClsMali objMali = new ClsMali();
            objMali.CostBuy = (CostBuy).ToString();
            grdCostPrice.DataSource = objMali.SelectCostPrice("0").Tables[0];
        }
        private void SelectResidGhati_Nerkh()
        {
            ClsMali objMali = new ClsMali();
            objMali.strGhetehCode = txtGhetehCode.Text.Trim();
            objMali.strGhetehAnbar = txtGhetehAnbar.Text.Trim();
            DataTable dtSelectResidGhati_Nerkh = new DataTable();
            dtSelectResidGhati_Nerkh = objMali.SelectResidGhati_Nerkh("1").Tables[0];
            if (dtSelectResidGhati_Nerkh.Rows.Count > 0)
            {
                txtPriceResid.Text = objMali.SelectResidGhati_Nerkh("1").Tables[0].Rows[0]["nerkhvahed"].ToString();
                txtPriceCustom.Text = txtPriceResid.Text;
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //txtC_Tafsili.Text = "";
            //txtN_Tafsili.Text = "";
            ClearControl();

        }

        private void btnF2KalaTree_Click(object sender, EventArgs e)
        {
            ClearControl();
            FrmTakvinKala frmTK = new FrmTakvinKala();
            frmTK.strIsOutSource = strIsOutSource;
            frmTK.strIsTarkib = strIsTarkib;
            frmTK.strIsKharid = strIsKharid;
            frmTK.ShowDialog();
            txtGheteName.Text = FrmTakvinKala.strNkala;
            txtGhetehCode.Text = FrmTakvinKala.strCkala;
            strid_Gheteh = FrmTakvinKala.strIdGhete;
            txtGhetehAnbar.Text = FrmTakvinKala.strAnbar;

            if (!string.IsNullOrEmpty(strid_Gheteh))
            {
                
                    SelectResidGhati_Nerkh();
                
            }
        }

        private void txtGhetehCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                /*
                ClsTakvin objTakvin = new ClsTakvin();
                objTakvin.strCKala = txtGhetehCode.Text;
                ds = objTakvin.SelectTakvinKala();
                txtGheteName.Text = ds.Tables[0].Rows[0]["GheteName"].ToString();
                txtGhetehAnbar.Text = ds.Tables[0].Rows[0]["GhetehAnbar"].ToString();
                strid_Gheteh = ds.Tables[0].Rows[0]["id_Gheteh"].ToString();
                
                ClsMali objMali = new ClsMali();
                objMali.strGhetehCode = txtGhetehCode.Text.Trim(); 
                objMali.strGhetehAnbar = txtGhetehAnbar.Text.Trim();
                //objBuy.strC_Tafsili = txtC_Tafsili.Text;
                //objBuy.strPriceKala = "1";
                txtPriceResid.Text = objMali.SelectResidGhati_Nerkh("1").Tables[0].Rows[0]["nerkhvahed"].ToString();
                 */
            }
            catch { }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //txtC_Tafsili.Enabled = true;
            //btnF2Tafsili.Enabled = true;
            btnF2KalaTree.Enabled = true;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;

            ClsBuy objBuy = new ClsBuy();
            //objBuy.strCountInDay = txtCountInDay.Text;
            objBuy.strIdPeymankardata = strIdPeymankardata;
            objBuy.UpdatePeymankarData();

            objBuy.strIdPeymankardata = strIdPeymankardata;
            objBuy.strPriceKala = txtPriceCustom.Text;
            MessageBox.Show(objBuy.InsPeymankarPrice());

            //txtC_Tafsili_TextChanged(sender, e);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            //txtC_Tafsili.Enabled = true;
            //btnF2Tafsili.Enabled = true;
            btnF2KalaTree.Enabled = true;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;

            if(MessageBox.Show("آیا از حذف اطلاعات این کالا اطمینان دارید؟","",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                ClsBuy objBuy = new ClsBuy();
                objBuy.strIdPeymankardata = strIdPeymankardata;
                MessageBox.Show(objBuy.DelPeymankarData());

                //txtC_Tafsili_TextChanged(sender, e);
            }
        }

        private void grdCostPrice_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {              
                //btnF2KalaTree.Enabled = false;
                //btnEdit.Enabled = true;
                //btnDel.Enabled = true;

                //txtGhetehCode.Text = grdCostPrice.Rows[e.RowIndex].Cells["GhetehCode"].Value.ToString();//ds.Tables[0].Rows[0]["GhetehCode"].ToString();
                //strid_Gheteh = grdCostPrice.Rows[e.RowIndex].Cells["id_Gheteh"].Value.ToString();//ds.Tables[0].Rows[0]["id_Gheteh"].ToString();
                //txtGheteName.Text = grdCostPrice.Rows[e.RowIndex].Cells["GheteName"].Value.ToString();//ds.Tables[0].Rows[0]["GheteName"].ToString();
                
                //txtPriceResid.Text = grdCostPrice.Rows[e.RowIndex].Cells["mablaghResid"].Value.ToString();//ds.Tables[0].Rows[0]["mablaghResid"].ToString();
                //txtPriceCustom.Text = grdCostPrice.Rows[e.RowIndex].Cells["PriceKala"].Value.ToString();//ds.Tables[0].Rows[0]["PriceKala"].ToString();
                //strIdPeymankardata = grdCostPrice.Rows[e.RowIndex].Cells["IdPeymankarData"].Value.ToString();//ds.Tables[0].Rows[0]["PriceKala"].ToString();
            }
            catch
            {
                return;
            }
        }

        private void FrmCostPrice_Load(object sender, EventArgs e)
        {
            DataTable DtControlAccess = new DataTable();
            DataRow[] dr = ClsMain.DtAccessUser.Select("n_form='" + this.Name + "'");
            if (dr.Length > 0) DtControlAccess = dr.CopyToDataTable();
            if (DtControlAccess.Rows.Count > 0)
            {
                for (int i = 0; i < DtControlAccess.Rows.Count; i++)
                {
                    string strControl = DtControlAccess.Rows[i]["n_control"].ToString();
                    if (strControl != null)
                    {
                        bool rv;
                        if (DtControlAccess.Rows[i]["id_user"].ToString() == ClsMain.IDUser)
                        {
                            rv = Convert.ToBoolean(DtControlAccess.Rows[i]["isActive"].ToString());
                            //re = Convert.ToBoolean(DtControlAccess.Rows[i]["isshow"].ToString());
                        }
                        else
                        {
                            rv = false;
                            //re = false;
                        }
                        //ctn.Enabled = re;
                        CostBuy = rv;
                    }
                }
            }
            ////--------------------------
            strIsOutSource = "1";
            strIsTarkib = "1";
            strIsKharid = "1";
            ClsMali objMali = new ClsMali();
            objMali.CostBuy = (CostBuy).ToString();
            grdCostPrice.DataSource = objMali.SelectCostPrice("1").Tables[0];

            ClsBuy obj = new ClsBuy();
            grdGhete.DataSource = obj.Select_ExcelOutGheteProccess().Tables[0];
            grdMalzomat.DataSource = obj.Select_ExcelOutGhete().Tables[0];
            grdMavad.DataSource = obj.Select_ExcelOutMavad().Tables[0];
        }

        private void txtGhetehCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                ClearControl();
                FrmTakvinKala frmTK = new FrmTakvinKala();
                frmTK.strIsOutSource = strIsOutSource;
                frmTK.strIsTarkib = strIsTarkib;
                frmTK.strIsKharid = strIsKharid;
                frmTK.ShowDialog();
                txtGheteName.Text = FrmTakvinKala.strNkala;
                txtGhetehCode.Text = FrmTakvinKala.strCkala;
                strid_Gheteh = FrmTakvinKala.strIdGhete;
                txtGhetehAnbar.Text = FrmTakvinKala.strAnbar;

                if (!string.IsNullOrEmpty(strid_Gheteh))
                {
                    SelectResidGhati_Nerkh();
                }
            }
        }

        private void btnF2KalaAnbar_Click(object sender, EventArgs e)
        {
            FrmKala frmK = new FrmKala();
            frmK.strC_Anbar = "10,11,13";
            frmK.ShowDialog();
            txtGhetehCode.Text = (!string.IsNullOrEmpty(ClsPublic.C_kala) ? ClsPublic.C_kala : txtGhetehCode.Text.Trim());
            txtGheteName.Text = (!string.IsNullOrEmpty(ClsPublic.N_kala) ? ClsPublic.N_kala : txtGheteName.Text.Trim());
            txtGhetehAnbar.Text = (!string.IsNullOrEmpty(ClsPublic.C_Anbar) ? ClsPublic.C_Anbar : txtGhetehAnbar.Text.Trim());
            if (txtGhetehCode.Text.Trim()!="")
            {
                SelectResidGhati_Nerkh();
            }
        }
        //public string getDataFromXLS(string strFilePath)
        //{
        //    Connect.Close();
        //    Connect.ConnectionString = Clsconnect.StrConnectTTS;
        //    try
        //    {
        //        string strConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
        //                                     "Data Source=" + strFilePath + "; Jet OLEDB:Engine Type=5;" + "Extended Properties=Excel 8.0;";
        //        OleDbConnection cnCSV = new OleDbConnection(strConnectionString);
        //        cnCSV.Open();
        //        OleDbCommand cmdSelect = new OleDbCommand(@"SELECT Ckala,PriceKala FROM [Sheet1$]", cnCSV);
        //        daCSV.SelectCommand = cmdSelect;

        //        daCSV.Fill(Ds);
        //        cnCSV.Close();
        //        MessageBox.Show("دریافت اطلاعات از اکسل انجام شد");
        //        if (MessageBox.Show("آیا از انتقال اطلاعات به بانک اطلاعاتی اطمینان دارید", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //        {
        //            ClsMali objMali = new ClsMali();
        //            objMali.Delete_PriceExcel();
        //            SqlBulkCopy bulkCopy = new SqlBulkCopy(Connect);
        //            bulkCopy.DestinationTableName = "Cost_tblPriceExcel";//from 192.168.100.204\TTS because instaled excel
        //            Connect.Open();
        //            bulkCopy.WriteToServer(Ds.Tables[0]);
        //            Connect.Close();
        //            return objMali.Update_CostPriceFromExcel();
        //            //return "انتقال اطلاعات با موفقیت انجام شد";
        //        }
        //        else
        //            return "عملیات لغو شد";
        //    }
        //    catch(Exception ee)
        //    {
        //        //return "دریافت اطلاعات با خطا مواجه شد";
        //        return ee.Message;
        //    }
        //}
        public string getDataFromXLS(string strFilePath)
        {
            Connect.Close();
            //Connect.ConnectionString = Clsconnect.StrConnectTTS;
            Connect.ConnectionString = Clsconnect.Connect;
            try
            {
                //string strConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                //                             "Data Source=" + strFilePath + "; Jet OLEDB:Engine Type=5;" + "Extended Properties=Excel 8.0;";
                string strConnectionString = "Provider=Microsoft.ACE.OLEDB.4.0;" +
                                             "Data Source=" + strFilePath + "; " + "Extended Properties=Excel 8.0;";

                OleDbConnection cnCSV = new OleDbConnection(strConnectionString);
                cnCSV.Close();
                cnCSV.Open();
                OleDbCommand cmdSelect = new OleDbCommand(@" SELECT Ckala,PriceKala FROM [Sheet$]", cnCSV);
                daCSV.SelectCommand = cmdSelect;
                Ds.Clear();
                daCSV.Fill(Ds);
                cnCSV.Close();
                MessageBox.Show("دریافت اطلاعات از اکسل انجام شد");
                if (MessageBox.Show("آیا از انتقال اطلاعات به بانک اطلاعاتی اطمینان دارید", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ClsMali objMali = new ClsMali();
                    objMali.Delete_PriceExcel();
                    SqlBulkCopy bulkCopy = new SqlBulkCopy(Connect);
                    bulkCopy.DestinationTableName = "Cost_tblPriceExcel";//from 192.168.100.204\TTS because instaled excel
                    Connect.Open();
                    bulkCopy.WriteToServer(Ds.Tables[0]);
                    Connect.Close();
                    return objMali.Update_CostPriceFromExcelMis();
                }
                else
                    return "عملیات لغو شد";
            }
            catch (Exception ex)
            {
                return "دریافت اطلاعات با خطا مواجه شد";
            }
        }
        public string getDataFromXLS2(string strFilePath)
        {
            Connect.Close();
            //Connect.ConnectionString = Clsconnect.StrConnectTTS;
            Connect.ConnectionString = Clsconnect.Connect;
            try
            {
                string strConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                             "Data Source=" + strFilePath + "; " + "Extended Properties=Excel 8.0;";
                //string strConnectionString = "Provider=Microsoft.ACE.OLEDB.4.0;" +
                //                             "Data Source=" + strFilePath + "; Jet OLEDB:Engine Type=5;" + "Extended Properties=Excel 8.0;";

                OleDbConnection cnCSV = new OleDbConnection(strConnectionString);
                cnCSV.Close();
                cnCSV.Open();
                OleDbCommand cmdSelect = new OleDbCommand(@" SELECT Ckala,PriceKala FROM [Sheet$]", cnCSV);
                daCSV.SelectCommand = cmdSelect;
                Ds.Clear();
                daCSV.Fill(Ds);
                cnCSV.Close();
                MessageBox.Show("دریافت اطلاعات از اکسل انجام شد");
                if (MessageBox.Show("آیا از انتقال اطلاعات به بانک اطلاعاتی اطمینان دارید", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ClsMali objMali = new ClsMali();
                    objMali.Delete_PriceExcel();
                    SqlBulkCopy bulkCopy = new SqlBulkCopy(Connect);
                    bulkCopy.DestinationTableName = "Cost_tblPriceExcel";//from 192.168.100.204\TTS because instaled excel
                    Connect.Open();
                    bulkCopy.WriteToServer(Ds.Tables[0]);
                    Connect.Close();
                    return objMali.Update_CostPriceFromExcelMis();
                }
                else
                    return "عملیات لغو شد";
            }
            catch (Exception ex)
            {
                return "دریافت اطلاعات با خطا مواجه شد";
            }
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show(getDataFromXLS(openFileDialog1.InitialDirectory + openFileDialog1.FileName));
                    ClearControl();
                }
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        private void btnExcel2_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show(getDataFromXLS2(openFileDialog1.InitialDirectory + openFileDialog1.FileName));
                    ClearControl();
                }
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        private void btnRefreshPrice_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا از انتقال آخرین قیمت رسیدها به بانک اطلاعاتی اطمینان دارید", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ClsMali objMali = new ClsMali();
                using (new PleaseWait(this.Location))
                {
                    objMali.InsCostPriceAll();
                    grdCostPrice.DataSource = objMali.SelectCostPrice("1").Tables[0];
                }
            }
        }

        private void btnExcelGhete_Click(object sender, EventArgs e)
        {
            try
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
                new ExportToExcelML(this.grdGhete).RunExport(fileName);
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
            catch { }
        }

        private void btnExcelMavad_Click(object sender, EventArgs e)
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
            new ExportToExcelML(this.grdMavad).RunExport(fileName);
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

        private void btnExcelMalzomat_Click(object sender, EventArgs e)
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
            new ExportToExcelML(this.grdMalzomat).RunExport(fileName);
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
    }
}

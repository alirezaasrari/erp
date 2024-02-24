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

namespace ET
{
    public partial class FrmCostPriceMahsool : Telerik.WinControls.UI.RadForm
    {
        public FrmCostPriceMahsool()
        {
            InitializeComponent();
        }
        OleDbDataAdapter daCSV = new OleDbDataAdapter();
        public DataSet Ds = new DataSet();
        public SqlConnection Connect = new SqlConnection();
        ClsConnect Clsconnect = new ClsConnect();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtGhetehCode.Text.Trim() == "")
            {
                RadMessageBox.Show(" کالا را تعیین کنید");
                return;
            }
            ClsMali objMali = new ClsMali();
            objMali.strGhetehCode = txtGhetehCode.Text.Trim();
            objMali.strGhetehAnbar = txtGhetehAnbar.Text.Trim();
            objMali.strPriceKala = txtPrice.Text;
            MessageBox.Show(objMali.InsCostPriceBuy());

            grdCostPrice.DataSource = objMali.SelectCostPriceBuy("1").Tables[0];
        }

        private void FrmCostPriceMahsool_Load(object sender, EventArgs e)
        {
            ClsMali objMali = new ClsMali();

            grdCostPrice.DataSource = objMali.SelectCostPriceBuy("1").Tables[0];
        }

        private void txtGhetehCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmKala frmK = new FrmKala();
                frmK.strC_Anbar = "14,15";
                frmK.ShowDialog();
                txtGhetehCode.Text = (!string.IsNullOrEmpty(ClsPublic.C_kala) ? ClsPublic.C_kala : txtGhetehCode.Text.Trim());
                txtGheteName.Text = (!string.IsNullOrEmpty(ClsPublic.N_kala) ? ClsPublic.N_kala : txtGheteName.Text.Trim());
                txtGhetehAnbar.Text = (!string.IsNullOrEmpty(ClsPublic.C_Anbar) ? ClsPublic.C_Anbar : txtGhetehAnbar.Text.Trim());
                //if (txtGhetehCode.Text.Trim() != "")
                //{
                //    SelectResidGhati_Nerkh();
                //}
            }
        }
        public string getDataFromXLS(string strFilePath)
        {
            Connect.Close();
            Connect.ConnectionString = Clsconnect.StrConnectTTS;
            try
            {
                string strConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                             "Data Source=" + strFilePath + "; Jet OLEDB:Engine Type=5;" + "Extended Properties=Excel 8.0;";
                OleDbConnection cnCSV = new OleDbConnection(strConnectionString);
                cnCSV.Close();
                cnCSV.Open();
                OleDbCommand cmdSelect = new OleDbCommand(@"SELECT GhetehCode,GhetehAnbar,Price,MaliEdari FROM [Sheet1$]", cnCSV);
                daCSV.SelectCommand = cmdSelect;

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
                    return objMali.Update_CostPriceFromExcel();
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
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                getDataFromXLS(openFileDialog1.InitialDirectory + openFileDialog1.FileName);
            }
        }

        private void btnF2KalaAnbar_Click(object sender, EventArgs e)
        {
            FrmKala frmK = new FrmKala();
            frmK.strC_Anbar = "14,15";
            frmK.ShowDialog();
            txtGhetehCode.Text = (!string.IsNullOrEmpty(ClsPublic.C_kala) ? ClsPublic.C_kala : txtGhetehCode.Text.Trim());
            txtGheteName.Text = (!string.IsNullOrEmpty(ClsPublic.N_kala) ? ClsPublic.N_kala : txtGheteName.Text.Trim());
            txtGhetehAnbar.Text = (!string.IsNullOrEmpty(ClsPublic.C_Anbar) ? ClsPublic.C_Anbar : txtGhetehAnbar.Text.Trim());
        }
    }
}

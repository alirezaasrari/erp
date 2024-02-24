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
using System.Data.OleDb;
using System.Data.SqlClient;
using Telerik.WinControls.UI;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace ET
{
    public partial class FrmTolid_KontorTestH : Telerik.WinControls.UI.RadForm
    {
        public FrmTolid_KontorTestH()
        {
            InitializeComponent();
        }
        public string strIdPersonel, strIdDastgah;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ClsTolid obj = new ClsTolid();
                obj.DateTest = dtpDateTest.Text;
                obj.strShift = "A";
                obj.KontorDry = cmbKontorDry.Text;
                obj.KontorSize = cmbKontorSize.Text;
                obj.RadeDeghat = cmbRadeDeghat.Text;
                obj.IdDastgah = cmbIdDastgah.SelectedValue.ToString();
                obj.IdOperator = cmbPersonel.SelectedValue.ToString();
                obj.SazandeDarposh = txtSazandeDarposh.Text;
                obj.SazandeMekanizm = cmbSazandeMekanizm.Text;
                obj.TimeStart = txtTimeStart.Text;
                obj.TimeEnd = txtTimeEnd.Text;
                obj.SeriMechanism = cmbSeriMechanism.Text;
                MessageBox.Show(obj.INS_KontorTestH());
                grd.Enabled = true;
                txtIdTest.Text = obj.Select_KontorTestHMax().Tables[0].Rows[0][0].ToString();

                btnAdd.Enabled = false;
                btnAddKontor.Enabled = true;
                btnAddKontorAll.Enabled = true;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void FrmTolid_KontorTestH_Load(object sender, EventArgs e)
        {
            dtpDateTest.Value = DateTime.Now;
            if (txtIdTest.Text == "")
                grd.Enabled = false;
            else
                grd.Enabled = true;

            ClsTolid cp = new ClsTolid();
            cmbPersonel.DataSource = cp.Select_KontorPersonel().Tables[0];
            cmbPersonel.ValueMember = "IdPersonel";
            cmbPersonel.DisplayMember = "NamePersonel";
            cmbPersonel.SelectedIndex = -1;

            ClsPM pm = new ClsPM();
            pm.Idclass = "28";
            cmbIdDastgah.DataSource = pm.selectMachine().Tables[0];
            cmbIdDastgah.ValueMember = "ID_machine";
            cmbIdDastgah.DisplayMember = "N_machine";
            cmbIdDastgah.SelectedIndex = -1;

            cmbPersonel.Text = strIdPersonel;
            cmbIdDastgah.Text = strIdDastgah;
            this.BindGrid();

            //سطح دسترسی کنترلها       
            DataTable DtControlAccess = new DataTable();
            DataRow[] dr = ClsMain.DtAccessUser.Select("n_form='" + this.Name + "'");
            if (dr.Length > 0) DtControlAccess = dr.CopyToDataTable();
            if (DtControlAccess.Rows.Count > 0)
            {
                for (int i = 0; i < DtControlAccess.Rows.Count; i++)
                {
                    string strControl = DtControlAccess.Rows[i]["n_control"].ToString();
                    bool rv, re;
                    if (DtControlAccess.Rows[i]["id_user"].ToString() == ClsMain.IDUser & strControl == "TimeTest")
                    {
                        rv = Convert.ToBoolean(DtControlAccess.Rows[i]["isActive"].ToString());
                        re = Convert.ToBoolean(DtControlAccess.Rows[i]["isshow"].ToString());
                    }
                    else
                    {
                        rv = false;
                        re = false;
                    }
                    txtQ1TimeWater.Enabled = re;
                    txtQ1TimeWater.Visible = rv;
                    txtQ2TimeWater.Enabled = re;
                    txtQ2TimeWater.Visible = rv;
                    txtQ3_1TimeWater.Enabled = re;
                    txtQ3_1TimeWater.Visible = rv;
                    txtQ3_2TimeWater.Enabled = re;
                    txtQ3_2TimeWater.Visible = rv;
                    txtQ3_3TimeWater.Enabled = re;
                    txtQ3_3TimeWater.Visible = rv;
                    txtQ3_4TimeWater.Enabled = re;
                    txtQ3_4TimeWater.Visible = rv;
                }
            }
            ////--------------------------
            ///
            btnAdd.Enabled = true;
            btnAddKontor.Enabled = false;
            btnAddKontorAll.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ClsTolid obj = new ClsTolid();
                obj.DateTest = dtpDateTest.Text;
                obj.strShift = "A";
                obj.KontorDry = cmbKontorDry.Text;
                obj.KontorSize = cmbKontorSize.Text;
                obj.RadeDeghat = cmbRadeDeghat.Text;
                obj.IdDastgah = cmbIdDastgah.SelectedValue.ToString();
                obj.IdOperator = cmbPersonel.SelectedValue.ToString();
                obj.SazandeDarposh = txtSazandeDarposh.Text;
                obj.SazandeMekanizm = cmbSazandeMekanizm.Text;
                //obj.PressHidrostatic = txtPressHidrostatic.Text;
                //obj.TimeHidrostatic = txtTimeHidrostatic.Text;
                obj.TimeStart = txtTimeStart.Text;
                obj.TimeEnd = txtTimeEnd.Text;
                obj.SeriMechanism = cmbSeriMechanism.Text;
                MessageBox.Show(obj.Update_KontorTestH());
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            string fileName = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = string.Format("{0} (*{1})|*{1}", "Excel Files", ".xlsx")
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
            }
                (new ExportToExcelML(this.grd)).RunExport(fileName);
            if (RadMessageBox.Show("فایل به درستی ایجاد شد.آیا می خواهید فایل باز شود؟", "Export to Excel", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
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

        private void btnExcelIn_Click(object sender, EventArgs e)
        {
            try
            {
                ClsTolid obj = new ClsTolid();
                obj.IdTest = txtIdTest.Text;
                obj.DelKontorTestHID();
                string filePath;
                OpenFileDialog fl = new OpenFileDialog();
                if (fl.ShowDialog() == DialogResult.OK)
                {
                    filePath = fl.FileName;
                    SaveFileToDatabase(filePath);
                    obj.Update_KontorTestHID();
                    grd.DataSource = obj.Select_KontorTestD().Tables[0];
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        private void SaveFileToDatabase(string filePath)
        {
            String strConnection = "Data Source=.;Initial Catalog=misDB;Integrated Security=True;User ID=sa;Password=ictmis";

            String excelConnString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0\"", filePath);
            //Create Connection to Excel work book 
            using (OleDbConnection excelConnection = new OleDbConnection(excelConnString))
            {
                //Create OleDbCommand to fetch data from Excel 
                using (OleDbCommand cmd = new OleDbCommand("SELECT [IdTest] \n"
           + "      ,[IdKontor] \n"
           + "      ,[Q3R1_1] \n"
           + "      ,[Q3R2_1] \n"
           + "      ,[Q3R1_2] \n"
           + "      ,[Q3R2_2] \n"
           + "      ,[Q3R1_3] \n"
           + "      ,[Q3R2_3] \n"
           + "      ,[Q3R1_4] \n"
           + "      ,[Q3R2_4] \n"
           + "      ,[Q2R1] \n"
           + "      ,[Q2R2] \n"
           + "      ,[Q1R1] \n"
           + "      ,[Q1R2] \n"
           + "      ,[ResultTest] from [Sheet$]", excelConnection))
                {
                    excelConnection.Open();
                    using (OleDbDataReader dReader = cmd.ExecuteReader())
                    {
                        using (SqlBulkCopy sqlBulk = new SqlBulkCopy(strConnection))
                        {
                            //Give your Destination table name 
                            sqlBulk.DestinationTableName = "Tolid_tblKontorTestD";
                            sqlBulk.WriteToServer(dReader);
                        }
                    }
                }
            }
        }       
        private void grd_UserAddingRow(object sender, Telerik.WinControls.UI.GridViewRowCancelEventArgs e)
        {
            try
            {
                ClsTolid obj = new ClsTolid();
                obj.IdTest = txtIdTest.Text;
                obj.IdKontor = grd.CurrentRow.Cells["IdKontor"].Value.ToString();
                //obj.QData = grd.CurrentRow.Cells["Q3R1_1"].Value.ToString();
                obj.INS_KontorTestD();
                grd.DataSource = obj.Select_KontorTestD().Tables[0];
                grd.Rows.AddNew();
            }
            catch (Exception ee)
            {

            }
        }

        private void grd_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            ClsTolid obj = new ClsTolid();
            try
            {
                //if (e.KeyCode == Keys.Return)
                //{
                obj.IdTestRow = grd.CurrentRow.Cells["ID"].Value.ToString();
                obj.IdKontor = grd.CurrentRow.Cells["IdKontor"].Value.ToString();
                obj.Q3R1_1 = grd.CurrentRow.Cells["Q3R1_1"].Value.ToString();
                obj.Q3R2_1 = grd.CurrentRow.Cells["Q3R2_1"].Value.ToString();
                obj.Q3R1_2 = grd.CurrentRow.Cells["Q3R1_2"].Value.ToString();
                obj.Q3R2_2 = grd.CurrentRow.Cells["Q3R2_2"].Value.ToString();
                obj.Q3R1_3 = grd.CurrentRow.Cells["Q3R1_3"].Value.ToString();
                obj.Q3R2_3 = grd.CurrentRow.Cells["Q3R2_3"].Value.ToString();
                obj.Q3R1_4 = grd.CurrentRow.Cells["Q3R1_4"].Value.ToString();
                obj.Q3R2_4 = grd.CurrentRow.Cells["Q3R2_4"].Value.ToString();
                obj.Q2R1 = grd.CurrentRow.Cells["Q2R1"].Value.ToString();
                obj.Q2R2 = grd.CurrentRow.Cells["Q2R2"].Value.ToString();
                obj.Q1R1 = grd.CurrentRow.Cells["Q1R1"].Value.ToString();
                obj.Q1R2 = grd.CurrentRow.Cells["Q1R2"].Value.ToString();
                obj.ResultTest = grd.CurrentRow.Cells["ResultTest"].Value.ToString();
                if (e.ColumnIndex == 28)
                    obj.Update_KontorTestDHand();
                else
                {
                    obj.Update_KontorTestD();
                    obj.IdTest = txtIdTest.Text;
                    obj.Update_KontorPazireshRate();
                }
                //obj.IdTest = txtIdTest.Text;
                //grd.DataSource = obj.Select_KontorTestD().Tables[0];
                //}                
            }
            catch (Exception ee)
            {
                obj.IdTest = txtIdTest.Text;
                grd.DataSource = obj.Select_KontorTestD().Tables[0];
            }
        }
        private void BindGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ResultTest", typeof(string));
            dt.Columns["ResultTest"].Caption = "کد";
            dt.Columns.Add("NameType", typeof(string));
            dt.Columns["NameType"].Caption = "نتیجه آزمون";
            dt.Rows.Add(0, "");
            dt.Rows.Add(1, "l");
            dt.Rows.Add(6, "R125");
            dt.Rows.Add(2, "R160");
            dt.Rows.Add(7, "R200");
            dt.Rows.Add(3, "TR");
            dt.Rows.Add(4, "تکرار");
            dt.Rows.Add(5, "بازکاری");

            GridViewComboBoxColumn mccbCol = new GridViewComboBoxColumn("ResultTest");
            //GridViewMultiComboBoxColumn mccbCol = new GridViewMultiComboBoxColumn("TypeTolid");
            mccbCol.HeaderText = "نتیجه آزمون";
            mccbCol.DataSource = dt;
            mccbCol.DisplayMember = "NameType";
            mccbCol.ValueMember = "ResultTest";
            mccbCol.Width = 100;
            this.grd.Columns.Add(mccbCol);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClsTolid obj = new ClsTolid();
            obj.IdTest = txtIdTest.Text;
            obj.Update_KontorTestDError();
            //obj.Update_KontorPazireshRate();
            grd.DataSource = obj.Select_KontorTestD().Tables[0];
        }

        private void btnQ31_Click(object sender, EventArgs e)
        {
            try
            {
                ClsTolid obj = new ClsTolid();
                obj.IdTest = txtIdTest.Text;
                obj.Q3_1ValueWater = txtQ3_1ValueWater.Text;

                MessageBox.Show(obj.Update_KontorTestQ31Header());
                txtQ3_1TimeWater.Text = obj.Select_KontorTestQHeader().Tables[0].Rows[0]["Q3_1TimeWater"].ToString();

                btnRefresh_Click(sender, e);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnQ32_Click(object sender, EventArgs e)
        {
            try
            {
                ClsTolid obj = new ClsTolid();
                obj.IdTest = txtIdTest.Text;
                obj.Q3_2ValueWater = txtQ3_2ValueWater.Text;
                MessageBox.Show(obj.Update_KontorTestQ32Header());
                txtQ3_2TimeWater.Text = obj.Select_KontorTestQHeader().Tables[0].Rows[0]["Q3_2TimeWater"].ToString();

                btnRefresh_Click(sender, e);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnQ33_Click(object sender, EventArgs e)
        {
            try
            {
                ClsTolid obj = new ClsTolid();
                obj.IdTest = txtIdTest.Text;
                obj.Q3_3ValueWater = txtQ3_3ValueWater.Text;
                MessageBox.Show(obj.Update_KontorTestQ33Header());
                txtQ3_3TimeWater.Text = obj.Select_KontorTestQHeader().Tables[0].Rows[0]["Q3_3TimeWater"].ToString();

                btnRefresh_Click(sender, e);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnQ34_Click(object sender, EventArgs e)
        {
            try
            {
                ClsTolid obj = new ClsTolid();
                obj.IdTest = txtIdTest.Text;
                obj.Q3_4ValueWater = txtQ3_4ValueWater.Text;
                MessageBox.Show(obj.Update_KontorTestQ34Header());
                txtQ3_4TimeWater.Text = obj.Select_KontorTestQHeader().Tables[0].Rows[0]["Q3_4TimeWater"].ToString();

                btnRefresh_Click(sender, e);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnQ2_Click(object sender, EventArgs e)
        {
            try
            {
                ClsTolid obj = new ClsTolid();
                obj.IdTest = txtIdTest.Text;
                obj.Q2ValueWater = txtQ2ValueWater.Text;
                MessageBox.Show(obj.Update_KontorTestQ2Header());
                txtQ2TimeWater.Text = obj.Select_KontorTestQHeader().Tables[0].Rows[0]["Q2TimeWater"].ToString();

                btnRefresh_Click(sender, e);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnAddKontor_Click(object sender, EventArgs e)
        {
            FrmTolid_KontorTestHAddKontor frm = new FrmTolid_KontorTestHAddKontor();
            frm.IdTest = txtIdTest.Text;
            frm.ShowDialog();
            ClsTolid obj = new ClsTolid();
            obj.IdTest = txtIdTest.Text;
            grd.DataSource = obj.Select_KontorTestD().Tables[0];
        }

        private void grd_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "btnDelete")
                {
                    ClsTolid obj = new ClsTolid();
                    obj.IdTestRow = grd.CurrentRow.Cells["ID"].Value.ToString();
                    if (MessageBox.Show("آیا از حذف سطر اطمینان دارید؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        obj.IdTest = txtIdTest.Text;
                        obj.IdKontor = grd.CurrentRow.Cells["IdKontor"].Value.ToString();
                        obj.DelKontorTestD();
                    }
                    obj.IdTest = txtIdTest.Text;
                    grd.DataSource = obj.Select_KontorTestD().Tables[0];
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnAddKontorAll_Click(object sender, EventArgs e)
        {
            FrmTolid_KontorTestHAddKontorAll frm = new FrmTolid_KontorTestHAddKontorAll();
            frm.IdTest = txtIdTest.Text;
            frm.ShowDialog();
            ClsTolid obj = new ClsTolid();
            obj.IdTest = txtIdTest.Text;
            grd.DataSource = obj.Select_KontorTestD().Tables[0];
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //txtIdTest.Text = "";
            //dtpDateTest.Text="";
            //cmbKontorDry.Text = "";
            //cmbKontorSize.Text = "";
            //cmbRadeDeghat.Text = "";
            //cmbIdDastgah.Text = "";
            //cmbPersonel.Text = "";
            //cmbSazandeMekanizm.Text = "";
            //txtTimeStart.Text = "";
            //txtTimeEnd.Text = "";
            //cmbSeriMechanism.Text = "";

            grd.DataSource = null;

            txtQ3_1ValueWater.Text = "";
            txtQ3_2ValueWater.Text = "";
            txtQ3_3ValueWater.Text = "";
            txtQ3_4ValueWater.Text = "";
            txtQ2ValueWater.Text = "";
            txtQ1ValueWater.Text = "";

            txtQ3_1TimeWater.Text = "";
            txtQ3_2TimeWater.Text = "";
            txtQ3_3TimeWater.Text = "";
            txtQ3_4TimeWater.Text = "";
            txtQ2TimeWater.Text = "";
            txtQ1TimeWater.Text = "";

            btnAdd.Enabled = true;
            btnAddKontor.Enabled = false;
            btnAddKontorAll.Enabled = false;
        }

        private void btnExcelElecronik_Click(object sender, EventArgs e)
        {
            try
            {
                ClsTolid obj = new ClsTolid();
                obj.IdTest = txtIdTest.Text;
                obj.DelKontorTestElectronic2();
                Update_KontorTestElectronicCSV2();
                obj.Update_KontorTestElectronicExcel2();
                grd.DataSource = obj.Select_KontorTestD().Tables[0];
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnQ1_Click(object sender, EventArgs e)
        {
            try
            {
                ClsTolid obj = new ClsTolid();
                obj.IdTest = txtIdTest.Text;
                obj.Q1ValueWater = txtQ1ValueWater.Text;
                MessageBox.Show(obj.Update_KontorTestQ1Header());
                txtQ1TimeWater.Text = obj.Select_KontorTestQHeader().Tables[0].Rows[0]["Q1TimeWater"].ToString();

                btnRefresh_Click(sender, e);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        private string Update_KontorTestElectronicCSV()
        {
            SqlConnection Connect = new SqlConnection();
            ClsConnect Clsconnect = new ClsConnect();
            Connect.Close();
            Connect.ConnectionString = Clsconnect.Connect;
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.ShowDialog();
                if (dialog.FileName != "")
                {
                    if (dialog.FileName.EndsWith(".csv"))
                    {
                        DataTable dtNew = new DataTable();
                        dtNew = GetDataTabletFromCSVFile(dialog.FileName);

                        MessageBox.Show("دریافت اطلاعات از اکسل انجام شد");
                        if (MessageBox.Show("آیا از انتقال اطلاعات به بانک اطلاعاتی اطمینان دارید", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            SqlBulkCopy bulkCopy = new SqlBulkCopy(Connect);
                            bulkCopy.DestinationTableName = "Tolid_tblKontorTestExcel";
                            Connect.Open();
                            bulkCopy.WriteToServer(dtNew);
                            Connect.Close();
                        }
                    }
                    return "1";
                }
                else
                    return "عملیات لغو شد";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "دریافت اطلاعات با خطا مواجه شد";
            }
        }
        private string Update_KontorTestElectronicCSV2()
        {
            SqlConnection Connect = new SqlConnection();
            ClsConnect Clsconnect = new ClsConnect();
            Connect.Close();
            Connect.ConnectionString = Clsconnect.Connect;
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.ShowDialog();
                if (dialog.FileName != "")
                {
                    if (dialog.FileName.EndsWith(".csv"))
                    {
                        DataTable dtNew = new DataTable();
                        dtNew = GetDataTabletFromCSVFile(dialog.FileName);

                        MessageBox.Show("دریافت اطلاعات از اکسل انجام شد");
                        if (MessageBox.Show("آیا از انتقال اطلاعات به بانک اطلاعاتی اطمینان دارید", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            SqlBulkCopy bulkCopy = new SqlBulkCopy(Connect);
                            bulkCopy.DestinationTableName = "Tolid_tblKontorTest2Excel";
                            Connect.Open();
                            bulkCopy.WriteToServer(dtNew);
                            Connect.Close();
                        }
                    }
                    return "1";
                }
                else
                    return "عملیات لغو شد";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "دریافت اطلاعات با خطا مواجه شد";
            }
        }

        private void btnExcelElecronik2_Click(object sender, EventArgs e)
        {
            try
            {
                ClsTolid obj = new ClsTolid();
                obj.IdTest = txtIdTest.Text;
                obj.DelKontorTestElectronic();
                Update_KontorTestElectronicCSV();
                obj.Update_KontorTestElectronicExcel();
                grd.DataSource = obj.Select_KontorTestD().Tables[0];
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private static DataTable GetDataTabletFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        csvData.Columns.Add(datecolumn);
                    }
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return csvData;
        }
    }
}

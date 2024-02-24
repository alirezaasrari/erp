using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Telerik.WinControls.UI.Export;
//using Telerik.QuickStart.WinControls;

namespace ET
{
    public partial class Frm_Sennireport : Telerik.WinControls.UI.RadForm
    {
        public Frm_Sennireport()
        {
            InitializeComponent();
        }

        public DataSet ds = new DataSet();
        //public SqlDataAdapter da = new SqlDataAdapter();
        //public 
        ClsBI bi = new ClsBI();
        string strwhere;
        ClsConnect cls = new ClsConnect();
        public string CTafsilistart, CTafsiliend;

        private void btnOperation_Click(object sender, EventArgs e)
        {
            if (chkMande.Checked == true)
            {
                ClsMali.Mande = 1;
            }
            else
            {
                ClsMali.Mande = 0;
            }

            if (chkMandebedehkar.Checked == true)
            {
                ClsMali.Mandebedehkar = 1;
            }
            else 
            {
                ClsMali.Mandebedehkar = 0;
            }

            if (chkMandebestankar.Checked == true)
            {
                ClsMali.Mandebestankar = 1;
            }
            else
            {
                ClsMali.Mandebestankar = 0;
            }

            if (chkTafsili.Checked == true)
            {
                if ((txttafsilistart.Text == "") || (txttafsiliend.Text == ""))
                {
                    Close();
                    ClsMali.Tafsili = 0;
                    ClsMali.tafsilistart ="";
                    ClsMali.tafsiliend ="";
                    MessageBox.Show("لطفا کد تفصیلی ابتدا و انتها را وارد نمایید");
                }
                else
                {
                    ClsMali.Tafsili = 1;
                    ClsMali.tafsilistart=txttafsilistart.Text;
                    ClsMali.tafsiliend = txttafsiliend.Text;
                }
            }
            else 
            {
                ClsMali.Tafsili = 0;
                ClsMali.tafsilistart = txttafsilistart.Text;
                ClsMali.tafsiliend = txttafsiliend.Text;
            }

            if (chkmablaghbaze.Checked == true)
            {
                if ((txtMablaghstart.Text == "") || (txtMablaghend.Text == ""))
                {
                    Close();
                    ClsMali.mablaghbaze = 0;
                    ClsMali.Mablaghstart = "";
                    ClsMali.Mablaghstart = "";
                    MessageBox.Show("لطفا مبلغ ابتدا و انتهای بازه را وارد نمایید");
                }
                else
                {
                    ClsMali.mablaghbaze = 1;
                    ClsMali.Mablaghstart = txtMablaghstart.Text;
                    ClsMali.Mablaghstart = txtMablaghend.Text;
                }
            }
            else 
            {
                ClsMali.mablaghbaze = 0;
                ClsMali.Mablaghstart = "";
                ClsMali.Mablaghstart = "";
            }

            
                //"	 SELECT  ROW_NUMBER() OVER (ORDER BY(C_Tafsili)) AS radif,  C_Tafsili, N_tafsili, \n"
                //       + "			 ISNULL(mande_aval_101,0) AS mande_aval_101,ISNULL(mande_aval_203,0) AS mande_aval_203, \n"
                //       + "			 forosh , bargasht , variz , check_pish,    \n"
                //       + "			  ISNULL(esterdad_203,0) AS esterdad,    \n"
                //       + "			 ISNULL(forosh,0)-ISNULL(bargasht,0)-ISNULL(variz,0)+ISNULL(mande_aval_101,0)-ISNULL(mande_aval_203,0)-ISNULL(esterdad_203,0)+ISNULL(sanad_dasti101,0)-ISNULL(sanad_dasti203,0) AS mande_bedeh ,   \n"
                //       + "  	     ISNULL(forosh,0)-ISNULL(bargasht,0)-ISNULL(variz,0)-ISNULL(check_pish,0)+ISNULL(mande_aval_101,0)-ISNULL(mande_aval_203,0)-ISNULL(esterdad_203,0)+ISNULL(sanad_dasti101,0)-ISNULL(sanad_dasti203,0) AS  mande_pass_azkasr   \n"
                //       + "	 FROM         dbo.AGL_tbl_sennireport AS ats  \n"
                //       + "	 WHERE    (ats.forosh<>0 OR ats.variz<>0 OR ats.bargasht<>0 OR ats.check_pish<>0 OR ats.mande_aval_101<>0 OR ats.mande_aval_203<>0 OR ats.esterdad_203<>0 OR sanad_dasti101<>0 OR sanad_dasti203<>0  ) ";
          

           

            if (chkMande.Checked == true)
            {
                ClsMali.Mande = 1;
                // strwhere = strwhere + " AND ( ISNULL(forosh,0)-ISNULL(bargasht,0)-ISNULL(variz,0)-ISNULL(check_pish,0)+ISNULL(mande_aval_101,0)-ISNULL(mande_aval_203,0)-ISNULL(esterdad_203,0)+ISNULL(sanad_dasti101,0)-ISNULL(sanad_dasti203,0) )<>0 ";
            }
            else 
            {
                ClsMali.Mande = 0;
            }

            if (chkMandebedehkar.Checked == true)
            {
                ClsMali.Mandebedehkar = 1;
                //strwhere = strwhere + " AND ( ISNULL(forosh,0)-ISNULL(bargasht,0)-ISNULL(variz,0)-ISNULL(check_pish,0)+ISNULL(mande_aval_101,0)-ISNULL(mande_aval_203,0)-ISNULL(esterdad_203,0)+ISNULL(sanad_dasti101,0)-ISNULL(sanad_dasti203,0) )>0 ";
            }
            else
            {
                ClsMali.Mandebedehkar = 0;
            }

            if (chkMandebestankar.Checked == true)
            {
                ClsMali.Mandebestankar = 1;
               // strwhere = strwhere + " AND ( ISNULL(forosh,0)-ISNULL(bargasht,0)-ISNULL(variz,0)-ISNULL(check_pish,0)+ISNULL(mande_aval_101,0)-ISNULL(mande_aval_203,0)-ISNULL(esterdad_203,0)+ISNULL(sanad_dasti101,0)-ISNULL(sanad_dasti203,0) )<0 ";
            }
            else
            {
                ClsMali.Mandebestankar = 0;
            }

            if (chkmablaghbaze.Checked == true)
            {
                ClsMali.mablaghbaze = 1;
                ClsMali.Mablaghstart = txtMablaghstart.Text;
                ClsMali.Mablaghend = txtMablaghend.Text;
                //strwhere = strwhere + " AND ( ISNULL(forosh,0)-ISNULL(bargasht,0)-ISNULL(variz,0)-ISNULL(check_pish,0)+ISNULL(mande_aval_101,0)-ISNULL(mande_aval_203,0)-ISNULL(esterdad_203,0)+ISNULL(sanad_dasti101,0)-ISNULL(sanad_dasti203,0) ) between " + txtMablaghstart.Text + " AND " + txtMablaghend.Text + "";
            }
            else
            {
                ClsMali.mablaghbaze = 0;
            }

            if (rdbtndolati.Checked == true)
            {
                ClsMali.dolati = 1;
                //strwhere = strwhere + " AND ( ats.IS_moshtari=1 AND ats.IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=0 and is_khadamat=0) ";
            }
            else 
            {
                ClsMali.dolati = 0;
            }

            if (rdbtnkhososi.Checked == true)
            {
                ClsMali.khososi = 1;
                //strwhere = strwhere + " AND ( ats.IS_moshtari=1 AND ats.IS_omomi=0 AND IS_Bazaryab=0 AND IS_Bestankardolati=0 and is_khadamat=0) ";
            }
            else
            {
                ClsMali.khososi = 0;
            }

            if (rdbtnkhareji.Checked == true)
            {
                ClsMali.khareji = 1;
                //strwhere = strwhere + " AND ( ats.IS_moshtari=1 AND ats.IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=1 and is_khadamat=0) ";
            }
            else
            {
                ClsMali.khareji = 0;
            }

            if (rdbtnmoshtarekin.Checked == true)
            {
                ClsMali.nmoshtarekin = 1;
                //   strwhere = strwhere + " AND ( ats.IS_moshtari=1 AND ats.IS_omomi=1 AND IS_Bazaryab=1 AND IS_Bestankardolati=0 and is_khadamat=0 ) ";
            }
            else
            {
                ClsMali.nmoshtarekin = 0;
            }
            if (rdbKHadamat.Checked == true)
            {
                ClsMali.KHadamat = 1;
                //strwhere = strwhere + " AND ( ats.IS_moshtari=1 AND ats.IS_omomi=0 AND IS_Bazaryab=0 AND IS_Bestankardolati=0  and is_khadamat=1) ";
            }
            else
            {
                ClsMali.KHadamat = 0;
            }
            if (rdbtnkol.Checked == true)
            {
                strwhere = strwhere + "";
            }

            //----------------------------------------

            ClsMali clskol = new ClsMali();
            ds = clskol.senni_koli();

            //dgw.DataSource = ds.Tables[0];
            radgw.DataSource = ds.Tables[0];
            clskol.clr_var();
            //----------------------------------------
            ClsMali.KHadamat = 0;
            ClsMali.khareji = 0;
            ClsMali.khososi = 0;
            ClsMali.mablaghbaze = 0;
            ClsMali.Mablaghend = "";
            ClsMali.Mablaghstart = "";
            ClsMali.Mande = 0;
            ClsMali.Mandebedehkar = 0;
            ClsMali.Mandebestankar = 0;
            ClsMali.nmoshtarekin = 0;
            ClsMali.Tafsili = 0;
            ClsMali.tafsiliend = "";
            ClsMali.tafsilistart = "";
            ClsMali.dolati = 0;
            
            //----------------------------------------

            foreach (DataGridViewRow row in dgw.Rows)
            {
                if (row.Index % 2 == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.AliceBlue;
                }
            }

            radgw.Columns["mande_aval_101"].FormatString = "{0:#,###}";
            radgw.Columns["mande_aval_203"].FormatString = "{0:#,###}";
            radgw.Columns["forosh"].FormatString = "{0:#,###}";
            radgw.Columns["bargasht"].FormatString = "{0:#,###}";
            radgw.Columns["variz"].FormatString = "{0:#,###}";
            radgw.Columns["check_pish"].FormatString = "{0:#,###}";
            radgw.Columns["esterdad"].FormatString = "{0:#,###}";
            radgw.Columns["mande_bedeh"].FormatString = "{0:#,###}";
            radgw.Columns["mande_pass_azkasr"].FormatString = "{0:#,###}";

        }

        //private void btnExcell_Click(object sender, EventArgs e)
        //{

        //    try
        //    {

        //        string[] str = new string[100];
        //        for (int i = 0; i < dgw.ColumnCount; i++)
        //        {
        //            str[i] = dgw.Columns[i].HeaderText


        //            //MessageBox.Show(dgw.Columns[i].HeaderText);
        //            //MessageBox.Show(str[i]);
        //        }

        //        ExitExcel.ExitExcel ex = new ExitExcel.ExitExcel();
        //        ex.Excel(ds, str);

        //        /*
        //        string[] header = new string[100];

        //        //string[] str = new string[20];
        //        //for (int i = 0; i < dgw.ColumnCount; i++)
        //        //{
        //        //    str[i] = dgw.Columns[i].HeaderText;
        //        //    //MessageBox.Show(dgw.Columns[i].HeaderText);
        //        //    //MessageBox.Show(str[i]);
        //        //}

        //        //ExitExcel.ExitExcel ex = new ExitExcel.ExitExcel();
        //        //ex.Excel(ds, str);

        //        //Infragistics.Documents.Excel.Workbook workbook = new Infragistics.Documents.Excel.Workbook();
        //        //Infragistics.Documents.Excel.Worksheet worksheet = workbook.Worksheets.Add("Sheet1");

        //        // creating Excel Application

        //        Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();

        //        // creating new WorkBook within Excel application

        //        Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);

        //        // creating new Excelsheet in workbook

        //        Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

        //        // see the excel sheet behind the program

        //        app.Visible = true;

        //        // get the reference of first sheet. By default its name is Sheet1.

        //        // store its reference to worksheet

        //        worksheet = workbook.Sheets["Sheet1"];

        //        worksheet = workbook.ActiveSheet;


        //        // changing the name of active sheet

        //        worksheet.DisplayRightToLeft = true;

        //        worksheet.Cells.Font.Name = "B Nazanin";
        //        worksheet.Cells.Font.Size = 12;

        //        //********
        //        if (rdbtndolati.Checked == true)
        //        {
        //            worksheet.get_Range("A1", "C1").Merge(false);
        //            Range rng = worksheet.get_Range("A1", "C1");
        //            rng.Value2 = "گزارش سنی مشتریان";
        //            rng.Font.Bold = true;
        //            //rng.Font.Name = "B Nazanin";
        //            //rng.Font.Size = 12;
        //            rng.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
        //        }

        //        //worksheet.Cells[3, "A"] = "ردیف";               
        //        Range rnghead1 = worksheet.get_Range("A3", "A3");
        //        rnghead1.Value2 = "ردیف";
        //        rnghead1.Font.Bold = true;
        //        //rnghead1.Font.Name = "B Nazanin";
        //        //rnghead1.Font.Size = 12;
        //        rnghead1.WrapText = true;
        //        rnghead1.Cells.Interior.Color = System.Drawing.Color.DarkCyan;
        //        //rnghead1.VerticalAlignment = XlVAlign;

        //        Range rnghead2 = worksheet.get_Range("B3", "B3");
        //        rnghead2.Value2 = "کد تفصیلی";
        //        //rnghead2.Font.Name = "B Nazanin";
        //        //rnghead2.Font.Size = 12;
        //        rnghead2.Font.Bold = true;
        //        rnghead2.WrapText = true;
        //        rnghead2.Cells.Interior.Color = System.Drawing.Color.DarkCyan;
        //        //rnghead2.HorizontalAlignment = HorizontalAlignment.Center;

        //        Range rnghead3 = worksheet.get_Range("C3", "C3");                
        //        rnghead3.Value2 = "نام تفصیلی";
        //        //rnghead3.Font.Name = "B Nazanin";
        //        //rnghead3.Font.Size = 12;
        //        rnghead3.Font.Bold = true;
        //        rnghead3.WrapText = true;
        //        rnghead3.Cells.Interior.Color = System.Drawing.Color.DarkCyan;

        //        Range rnghead4 = worksheet.get_Range("D3", "D3");
        //        rnghead4.Value2 = "مانده بدهکاری اول دوره";
        //        //rnghead4.Font.Name = "B Nazanin";
        //        //rnghead4.Font.Size = 12;
        //        rnghead4.Font.Bold = true;
        //        rnghead4.WrapText = true;
        //        rnghead4.Cells.Interior.Color = System.Drawing.Color.DarkCyan;

        //        Range rnghead5 = worksheet.get_Range("E3", "E3");
        //        rnghead5.Value2 = "مانده پیش دریافت اول دوره";
        //        //rnghead5.Font.Name = "B Nazanin";
        //        //rnghead5.Font.Size = 12;
        //        rnghead5.Font.Bold = true;
        //        rnghead5.WrapText = true;
        //        rnghead5.Cells.Interior.Color = System.Drawing.Color.DarkCyan;

        //        Range rnghead6 = worksheet.get_Range("F3", "F3");
        //        rnghead6.Value2 = "فروش کل";
        //        //rnghead6.Font.Name = "B Nazanin";
        //        //rnghead6.Font.Size = 12;                
        //        rnghead6.Font.Bold = true;
        //        rnghead6.WrapText = true;
        //        rnghead6.Cells.Interior.Color = System.Drawing.Color.DarkCyan;

        //        Range rnghead7 = worksheet.get_Range("G3", "G3");
        //        //rnghead7.Font.Name = "B Nazanin";
        //        //rnghead7.Font.Size = 12;
        //        rnghead7.Value2 = "برگشت از فروش کل";
        //        rnghead7.Font.Bold = true;
        //        rnghead7.WrapText = true;
        //        rnghead7.Cells.Interior.Color = System.Drawing.Color.DarkCyan;

        //        Range rnghead8 = worksheet.get_Range("H3", "H3");
        //        //rnghead8.Font.Name = "B Nazanin";
        //        //rnghead8.Font.Size = 12;
        //        rnghead8.Value2 = "واریز کل";
        //        rnghead8.Font.Bold = true;
        //        rnghead8.WrapText = true;
        //        rnghead8.Cells.Interior.Color = System.Drawing.Color.DarkCyan;

        //        Range rnghead9 = worksheet.get_Range("I3", "I3");
        //        //rnghead9.Font.Name = "B Nazanin";
        //        //rnghead9.Font.Size = 12;
        //        rnghead9.Value2 = "چک/پیش دریافت کل";
        //        rnghead9.Font.Bold = true;
        //        rnghead9.WrapText = true;
        //        rnghead9.Cells.Interior.Color = System.Drawing.Color.DarkCyan;

        //        Range rnghead10 = worksheet.get_Range("J3", "J3");
        //        //rnghead10.Font.Name = "B Nazanin";
        //        //rnghead10.Font.Size = 12;
        //        rnghead10.Value2 = "استرداد کل";
        //        rnghead10.Font.Bold = true;
        //        rnghead10.WrapText = true;
        //        rnghead10.Cells.Interior.Color = System.Drawing.Color.DarkCyan;

        //        Range rnghead11 = worksheet.get_Range("K3", "K3");
        //        //rnghead11.Font.Name = "B Nazanin";
        //        //rnghead11.Font.Size = 12;
        //        rnghead11.Value2 = "مانده بدهکاری";
        //        rnghead11.Font.Bold = true;
        //        rnghead11.WrapText = true;
        //        rnghead11.Cells.Interior.Color = System.Drawing.Color.DarkCyan;

        //        Range rnghead12 = worksheet.get_Range("L3", "L3");
        //        //rnghead12.Font.Name = "B Nazanin";
        //        //rnghead12.Font.Size = 12;
        //        rnghead12.Value2 = "مانده پس از کسر چک/ پیش دریافت";
        //        rnghead12.Font.Bold = true;
        //        rnghead12.WrapText = true;
        //        rnghead12.Cells.Interior.Color = System.Drawing.Color.DarkCyan;
        //        //rnghead12.Borders
        //        //********

        //        //if (rdbtndolati.Checked == true)
        //        //{
        //        //    worksheet.Name = "گزارش سنی مشتریان دولتی";
        //        //    worksheet.Cells[1, 1] = "گزارش سنی مشتریان دولتی";
        //        //}

        //        if (rdbtnkhososi.Checked == true)
        //        {
        //            worksheet.Name = "گزارش سنی مشتریان خصوصی";
        //            worksheet.Cells[1, 1] = "گزارش سنی مشتریان خصوصی";
        //        }



        //        //worksheet.UsedRange()
        //        // storing header part in Excel

        //        //for (int i = 1; i < dgw.Columns.Count + 1; i++)
        //        //{
        //        //    worksheet.Cells[3, i] = dgw.Columns[i - 1].HeaderText;
        //        //}

        //        //worksheet.Cells[1, 1] = header[0];
        //        //worksheet.Cells[2, 1] =  dgw.Columns[2].HeaderText;
        //        //worksheet.Cells[2, 2] =


        //        //for (int i = 1; i < ds.Tables[0].Columns.Count + 1; i++)
        //        //{
        //        //    worksheet.Cells[4, i] = header[i - 1];
        //        //}

        //        //// storing Each row and column value to excel sheet

        //        int i = 0;
        //        int j = 0;

        //        for ( i = 0; i < ds.Tables[0].Rows.Count; i++)
        //        {
        //            for (j = 0; j < ds.Tables[0].Columns.Count; j++)
        //            {
        //                worksheet.Cells[i + 4, j + 1] = ds.Tables[0].Rows[i][j].ToString();
        //            }
        //        }

        //        worksheet.Rows[1].Cells[0].CellFormat.BottomBorderColor = Color.Red;                

        //        int row = i + 4;

        //        MessageBox.Show(row.ToString());

        //        Range rnghead13 = worksheet.get_Range("D" + row, "D" + row);
        //        rnghead13.Formula = "=SUM(D4:D" + row + ")";
        //        rnghead13=rnghead13.Resize[row-6,2];
        //        //rnghead13.Borders.SetAllBorders(Color.Green, BorderLineStyle.Double);

        //        //Range rnghead14 = worksheet.get_Range("E" + row, "E" + row);
        //        //rnghead14.Formula = "=SUM(E4:E" + row + ")";

        //        //Range rnghead15 = worksheet.get_Range("F" + row, "F" + row);
        //        //rnghead15.Formula = "=SUM(F4:F" + row + ")";

        //        //Range rnghead16 = worksheet.get_Range("G" + row, "G" + row);
        //        //rnghead16.Formula = "=SUM(G4:G" + row + ")";

        //        //Range rnghead17 = worksheet.get_Range("H" + row, "H" + row);
        //        //rnghead17.Formula = "=SUM(H4:H" + row + ")";

        //        //Range rnghead21 = worksheet.get_Range("I" + row, "I" + row);
        //        //rnghead21.Formula = "=SUM(I4:I" + row + ")";

        //        //Range rnghead18 = worksheet.get_Range("j" + row, "J" + row);
        //        //rnghead18.Formula = "=SUM(J4:J" + row + ")";

        //        //Range rnghead19 = worksheet.get_Range("K" + row, "K" + row);
        //        //rnghead19.Formula = "=SUM(K4:K" + row + ")";

        //        //Range rnghead20 = worksheet.get_Range("L" + row, "L" + row);
        //        //rnghead20.Formula = "=SUM(L4:L" + row + ")";


        //        //worksheet.Rows.MergeCells("A", "A");

        //        //// save the application

        //        //// Exit from the application

        //        ////app.Quit();
        //    */
        //        GC.Collect();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }


        //}

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkTafsili_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTafsili.Checked == true)
            {
                txttafsilistart.Enabled = true;
                txttafsiliend.Enabled = true;
            }

            if (chkTafsili.Checked == false)
            {
                txttafsilistart.Enabled = false;
                txttafsiliend.Enabled = false;
            }
        }

        private void rdbtnkhososi_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Frmreport_Load(object sender, EventArgs e)
        {


        }

        private void btnExcell_Click(object sender, EventArgs e)
        {
            string[] str = new string[100];
            for (int i = 0; i < dgw.ColumnCount; i++)
            {
                str[i] = dgw.Columns[i].HeaderText;
                //MessageBox.Show(dgw.Columns[i].HeaderText);
                //MessageBox.Show(str[i]);
            }

            //ExportToExcelML exporter = new ExportToExcelML(dgw);
            //exporter.RunExport(tbFileName.Text);

            ExitExcel.ExitExcel ex = new ExitExcel.ExitExcel();
            ex.Excel(ds, str);
        }

        private void txttafsilistart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.F2)
            {
                Frm_Tafsili frt = new Frm_Tafsili();
                frt.ShowDialog();
                txttafsilistart.Text = Frm_Tafsili.CTafsili;
                Frm_Tafsili.CTafsili = "";
            }

            if (e.KeyCode == Keys.Enter)
            {
                txttafsiliend.Focus();
            }
        }

        private void txttafsiliend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                Frm_Tafsili frt = new Frm_Tafsili();
                frt.ShowDialog();
                txttafsiliend.Text = Frm_Tafsili.CTafsili;
                Frm_Tafsili.CTafsili = "";
            }
        }

        private void clr()
        {
            chkTafsili.Checked = false;
            chkmablaghbaze.Checked = false;
            chkMande.Checked = false;
            chkMandebedehkar.Checked = false;
            chkMandebestankar.Checked = false;

            rdbtndolati.Checked = false;
            rdbtnkhareji.Checked = false;
            rdbtnkhososi.Checked = false;
            rdbtnkol.Checked = false;
            rdbtnmoshtarekin.Checked = false;

            txtMablaghend.Clear();
            txtMablaghend.Enabled = false;
            txtMablaghstart.Clear();
            txtMablaghstart.Enabled = false;
            txttafsiliend.Clear();
            txttafsiliend.Enabled = false;
            txttafsilistart.Clear();
            txttafsilistart.Enabled = false;
        }

        private void Frm_Sennireport_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClsMali.KHadamat=0;
            ClsMali.khareji=0;
            ClsMali.khososi=0;
            ClsMali.mablaghbaze=0;
            ClsMali.Mablaghend="";
            ClsMali.Mablaghstart="";
            ClsMali.Mande=0;
            ClsMali.Mandebedehkar=0;
            ClsMali.Mandebestankar=0;
            ClsMali.nmoshtarekin=0;
            ClsMali.Tafsili=0;
            ClsMali.tafsiliend="";
            ClsMali.tafsilistart="";
            ClsMali.dolati=0;
            clr();
        }

        private void Frm_Sennireport_Load(object sender, EventArgs e)
        {
            clr();
        }

        private void chkmablaghbaze_CheckedChanged(object sender, EventArgs e)
        {
            if (chkmablaghbaze.Checked==true)
            {
                txtMablaghend.Enabled = true;
                txtMablaghstart.Enabled = true;
            }
            if (chkmablaghbaze.Checked == false)
            {
                txtMablaghend.Enabled = false;
                txtMablaghstart.Enabled = false;
            }
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMablaghstart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                txtMablaghend.Focus();
            }
        }

        private void radgw_Click(object sender, EventArgs e)
        {

        }



    }
}

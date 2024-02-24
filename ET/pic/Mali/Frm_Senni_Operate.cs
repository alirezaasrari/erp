using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;


namespace ET
{
    public partial class Frm_Senni_Operate : Telerik.WinControls.UI.RadForm
    {
        public string startdate, enddate;

        DataSet ds = new DataSet();

        public Frm_Senni_Operate()
        {
            InitializeComponent();
        }

        private void btnUpdInf_Click(object sender, EventArgs e)
        {
            ClsMali clsmali= new ClsMali();
            //string str = " ";
            //bi.StrQuery = str;

            MessageBox.Show(clsmali.ExceOprate());

            display_date_inf();
        }

        private void btnOperate_Click(object sender, EventArgs e)
        {
            //bgw.WorkerReportsProgress = true;
            //bgw.RunWorkerAsync();
            //string strsql = " EXEC AGL_SP_Gozaresh_n92 	@year = 1392 "
            //              + " EXEC AGL_SP_Gozaresh_n93 	@year = 1393 ";
            
            ClsMali clsmali= new ClsMali();

             MessageBox.Show(clsmali.ExecGozaresh());

            display_date_opr();

        }

        private void FrmOperate_Load(object sender, EventArgs e)
        {
            display_date_inf();
            display_date_opr();
        }

        private void display_date_inf()
        {
            DataSet ds = new DataSet();

            ClsMali clsmali = new ClsMali();
            
            ds = clsmali.SelectDB();

            labeltimeinf.Text = ds.Tables[0].Rows[0][0].ToString();
            labeldateinf.Text = ds.Tables[0].Rows[0][1].ToString();
        }

        private void display_date_opr()
        {
            DataSet ds = new DataSet();

            ClsBI bi = new ClsBI();

            string strsql = " SELECT CONVERT(VARCHAR,DATEPART(hour,Date_Ejra_start))+':'+CONVERT(VARCHAR,DATEPART(minute,Date_Ejra_start))+':'+CONVERT(VARCHAR,DATEPART(second,Date_Ejra_start)) ,  \n"
                          + "        dbo.miladi2shamsi(convert(varchar,Date_Ejra_start,102))  \n"
                          + " FROM AGL_tbl_Ejra    "
                          + " Where  IS_operate=1 AND ID=(SELECT  MAX(ID) FROM   AGL_tbl_Ejra ate  WHERE ate.IS_operate=1)   ";

            bi.StrQuery = strsql;

            ds = bi.SelectDB();

            //labeltimeopr.Text = ds.Tables[0].Rows[0][0].ToString();
            //labeldateopr.Text = ds.Tables[0].Rows[0][1].ToString();

        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.IO;
using System.IO.Ports;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using FastReport;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ET
{
    public partial class FrmTolid_Hack : Telerik.WinControls.UI.RadForm
    {
        public FrmTolid_Hack()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        DataSet dsRadyabi = new DataSet();
        public int ShenaseKitInt, intCountHack;
        public string StrIdArayesh, strCkala, strProc, strTedadSalem, strShift, strBeginShenase;
        public string StrMsg;
        public static string data = null;
        bool isConnected = false;
        string dataSend = "";
        string dataRecived = "";
        bool allowSendData = false, IsSabtDaily = false, IsFirstDaily = false;
        TcpClient tcpClient = new TcpClient();
        Stream strm;
        bool isHak = false;
        private void FrmTolid_Hack_Load(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Now;
            ClsTolid ObjTolid = new ClsTolid();
            //ObjTolid.INS_ExecueShenaseKala();
            ds = ObjTolid.Select_ShenaseKit();

            txtShenase.Text = ds.Tables[0].Rows[0]["ShenaseKitChar"].ToString();
            txtShenaseInt.Text = ds.Tables[0].Rows[0]["ShenaseKitInt"].ToString();
            ShenaseKitInt = Convert.ToInt32(ds.Tables[0].Rows[0]["ShenaseKitInt"].ToString()); 
            /////////////////////////////////////////
            Thread THstartConnect = new Thread(new ThreadStart(startConnect));
            THstartConnect.Start();

            Thread THReciveData = new Thread(new ThreadStart(ReciveData));
            THReciveData.Start();

            Thread THsendData = new Thread(new ThreadStart(sendData));
            THsendData.Start();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if(StrIdArayesh == "")
            {
                MessageBox.Show("آرایش کیت تعیین نشده است");
                return;
            }
            ClsTolid ObjTolid = new ClsTolid();
            grpH.Enabled = false;
            ObjTolid.StrIdArayesh = StrIdArayesh;
            GrdPartKit.DataSource = ObjTolid.SelectKalaArayeshKit().Tables[0];
            //intCountHack = 0;
            IsFirstDaily = true;
            MessageBox.Show("کد ردیابی اجزا کیت را وارد کنید");
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            grp.Enabled = false;
            grpH.Enabled = true;
            //dsRadyabi = ObjTolid.Select_Tolid_tblRadyabiTemp();
            //InsDailyReport();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Report objReport = new Report();
                objReport.Load(ClsPublic.strRepPath + "radyabi.frx");
                //objReport.Load("radyabi.frx");
                objReport.SetParameterValue("IdRadyabi", txtShenase.Text);
                objReport.SetParameterValue("BarcodeShenase", ShenaseKitInt);
                objReport.SetParameterValue("Nkala", txtArayesh.Text);
                //objReport.Show();
                objReport.PrintSettings.ShowDialog = false;
                objReport.PrintSettings.Copies = 1;
                objReport.Print();
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        private void PrintHackDevice()
        {
            ClsTolid ObjTolid = new ClsTolid();
            ObjTolid.strShenase = txtShenase.Text;
            if (ObjTolid.Select_ValidShenase().Tables[0].Rows[0][0].ToString() == "True")
            {
                MessageBox.Show("این کد قبلا حک شده است");
                return;
            }
            if (ObjTolid.Select_ShenaseKitArrange().Tables[0].Rows[0][0].ToString() == "False")
            {
                MessageBox.Show("کد قبلی استفاده نشده است");
                txtShenase.Text = ObjTolid.Select_ShenaseKit().Tables[0].Rows[0]["ShenaseKitChar"].ToString();
                return;
            }
            if (IsSabtDaily == true)
            {
                strBeginShenase = txtShenaseInt.Text;
                InsDailyReport();
                IsSabtDaily = false;
            }            
            ObjTolid.ShenaseKitInt = ShenaseKitInt.ToString();
            ObjTolid.HackPrint();
            //intCountHack++;
            ObjTolid.strIdDailyReport = txtIdDailyReport.Text;
            ObjTolid.Update_tedadDailyReport();
            InsShenaseHack();
            ds = ObjTolid.Select_ShenaseKit();
            txtShenase.Text = ds.Tables[0].Rows[0]["ShenaseKitChar"].ToString();
            txtShenaseInt.Text = ds.Tables[0].Rows[0]["ShenaseKitInt"].ToString();
            ShenaseKitInt = Convert.ToInt32(ds.Tables[0].Rows[0]["ShenaseKitInt"].ToString());
        }
        private void cmbBarname_Enter(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            cmbBarname.Text = "";
            ObjTolid.strBarname = "";
            ObjTolid.strShift = "";
            ObjTolid.strUnit = "150";
            ObjTolid.strDateBarname = dtpDate.Value.ToString().Substring(0, 10);
            cmbBarname.DataSource = ObjTolid.Select_Barname().Tables[0];
            cmbBarname.ValueMember = "IdBarname";
            cmbBarname.DisplayMember = "Id";
        }
        private void cmbBarname_SelectedValueChanged(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            try
            {
                ObjTolid.strBarname = cmbBarname.SelectedValue.ToString();
                ds.Clear();
                ds = ObjTolid.Select_Barname();
                strProc = ds.Tables[0].Rows[0]["FK_ID_process"].ToString();
                strTedadSalem = ds.Tables[0].Rows[0]["TedadTolid"].ToString();
                strShift = ds.Tables[0].Rows[0]["shift"].ToString();
                ObjTolid.StrCodeKala = strCkala = ds.Tables[0].Rows[0]["GhetehCode"].ToString();

                ds = ObjTolid.Select_ArayeshKit();
                ObjTolid.StrIdArayesh = StrIdArayesh = ds.Tables[0].Rows[0]["IdArayesh"].ToString();
                txtArayesh.Text = ds.Tables[0].Rows[0]["N_Kala"].ToString();
                txtCountHack.Text = ObjTolid.Select_ArayeshCountHack().Tables[0].Rows[0]["Tedad"].ToString();

                
            }
            catch
            {
                StrIdArayesh = "";
                txtArayesh.Text = "";
                txtCountHack.Text = "";
                strProc = "";
                strTedadSalem = "";
            }
        }
        private void btnSabtRadyabi_Click(object sender, EventArgs e)
        {
            try
            {
                ClsTolid ObjTolid = new ClsTolid();
                //dsRadyabi = ObjTolid.Select_Tolid_tblRadyabiTemp();
                //if (CheckForChangeRadyabi() == true & IsSabtDaily == true)
                //{
                //    InsDailyReport();
                //    IsSabtDaily = false;
                //}
                if (CheckForChangeRadyabi() == true || IsFirstDaily == true)
                {
                    IsSabtDaily = true;
                    IsFirstDaily = false;
                }
                ObjTolid.DEL_RadyabiDailyReportTemp();
                int i = 0;
                while (i < Convert.ToInt32(txtCountHack.Text))
                {
                    ObjTolid.strIdArayeshTemp = StrIdArayesh;
                    ObjTolid.strIdRadyabiTemp = GrdPartKit.Rows[i].Cells["IdRadyabi"].Value.ToString();
                    ObjTolid.strCkalaTemp = GrdPartKit.Rows[i].Cells["Ckala"].Value.ToString();
                    ObjTolid.INS_Radyabi_DailyReportTemp();
                    if (GrdPartKit.Rows[i].Cells["IdRadyabi"].Value.ToString() == "" || GrdPartKit.Rows[i++].Cells["IdRadyabi"].Value == null)
                    {
                        MessageBox.Show("کد ردیابی را وارد کنید");
                        return;
                    }
                }
                dsRadyabi = ObjTolid.Select_Tolid_tblRadyabiTemp();
                ///////////////////////////////////////////////////
                GrdPartKit.Enabled = false;
                grp.Enabled = true;
                btnSabtRadyabi.Enabled = false;
                btnBarnameRefresh.Enabled = false;
            }
            catch
            {
                MessageBox.Show("کد ردیابی را وارد کنید");
            }
        }
        public bool CheckForChangeRadyabi()
        {
            int i = 0;
            bool isChange = false;
            try
            {
                while (i < Convert.ToInt32(txtCountHack.Text))
                {
                    if (dsRadyabi.Tables[0].Rows[i]["Ckala"].ToString() == GrdPartKit.Rows[i].Cells["Ckala"].Value.ToString())
                        if (dsRadyabi.Tables[0].Rows[i]["IdRadyabi"].ToString() != GrdPartKit.Rows[i].Cells["IdRadyabi"].Value.ToString())
                            isChange = true;
                    i++;
                }
            }
            catch
            {
                return isChange;
            }
            return isChange;
        }
        private void btnChaneRadyabi_Click(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            //InsDailyReport();
            //dsRadyabi = ObjTolid.Select_Tolid_tblRadyabiTemp();
            GrdPartKit.Enabled = true;
            btnSabtRadyabi.Enabled = true;
        }
        private void InsDailyReport()
        {
            try
            {
                ClsTolid ObjTolid = new ClsTolid();

                txtIdDailyReport.Text = ObjTolid.strIdDailyReport = ObjTolid.Select_IdDailyReport().Tables[0].Rows[0][0].ToString();
                ObjTolid.strBarname = cmbBarname.Text;
                ObjTolid.strtarikh = dtpDate.Value.ToString().Substring(0, 10);
                ObjTolid.strShift = strShift;
                ObjTolid.strDastgah = "";
                ObjTolid.strPart_process = strCkala;
                //ObjTolid.strtedad = intCountHack.ToString();
                ObjTolid.strtedad = "0";
                ObjTolid.strProc = strProc;
                ObjTolid.strUnit = "150";
                ObjTolid.ShenaseKitInt = strBeginShenase;
                ObjTolid.INS_DailyReport();
                intCountHack = 0;

                int i = 0;
                while (i < Convert.ToInt32(txtCountHack.Text))
                {
                    if (dsRadyabi.Tables[0].Rows[i]["IdRadyabi"] != null)
                    {
                        ObjTolid.strIdRadyabi = dsRadyabi.Tables[0].Rows[i++]["IdRadyabi"].ToString();
                        ObjTolid.INS_Radyabi_DailyReport();
                    }
                }
            }
            catch
            {
                MessageBox.Show("خطا در ثبت برنامه");
            }
        }
        private void InsShenaseHack()
        {
            try
            {
                ClsTolid ObjTolid = new ClsTolid();

                ObjTolid.strIdDailyReport = txtIdDailyReport.Text; 
                ObjTolid.strPart_process = strCkala;              
                ObjTolid.strShenase = txtShenase.Text;
                ObjTolid.INS_Radyabi_ShenaseKala();
            }
            catch
            {
                MessageBox.Show("خطا در ثبت برنامه");
            }
        }
        private void btnDraw_Click(object sender, EventArgs e)
        {
            PrintHackDevice();           
        }
        public void DataReceive()
        {
            if (StrMsg == "0")
            {
                lblVaziat.Text = "دستگاه درحال کار";
            }
            if (StrMsg == "1")
            {
                lblVaziat.Text = "درحال انجام حک";
                if (isHak == false)
                {
                    isHak = true;
                    PrintHackDevice(); 
                }                
            }
            if (StrMsg == "2")
            {
                lblVaziat.Text = "حک با موفقیت انجام شد";
                isHak = false;
            }
            if (StrMsg == "3")
            {
                lblVaziat.Text = "دستگاه درحال کار است";
            }
            if (StrMsg == "4")
            {
                lblVaziat.Text = "حک مجدد";
            }
            if (StrMsg == "5")
            {
                lblVaziat.Text = "دستگاه متوقف است";
            }
            if (StrMsg == "6")
            {
                lblVaziat.Text = "خطا در عملیات";
            }
        }
        public void ReciveData()
        {
            while (true)
            {
                if (isConnected)
                {
                    strm = tcpClient.GetStream();
                    byte[] byttes = new byte[100];

                    int k = 0;

                    k = strm.Read(byttes, 0, 1);
                    if (k > 0)
                    {
                        ASCIIEncoding asen = new ASCIIEncoding();
                        dataRecived = asen.GetString(byttes);
                        dataRecived = String.Format("{0:X}", byttes[0]);
                    }
                    StrMsg = dataRecived;
                    if (dataRecived == "1")
                    {
                        dataSend = "[1]" + txtShenase.Text;
                        allowSendData = true;
                        dataRecived = "";
                    }
                    if (lblVaziat.InvokeRequired)
                    {
                        lblVaziat.Invoke(new MethodInvoker(delegate { DataReceive(); }));
                        StrMsg = "";
                    }
                }
                Thread.CurrentThread.Join(100);
            }
        }
        public void sendData()
        {
            while (true)
            {
                if (isConnected && dataSend != "" && allowSendData)
                {
                    allowSendData = false;
                    strm = tcpClient.GetStream();
                    byte[] byttes = new byte[dataSend.Length];

                    for (int i = 0; i < dataSend.Length; i++)
                        byttes[i] = Convert.ToByte(dataSend[i]);

                    strm.Write(byttes, 0, byttes.Length);                   
                    dataSend = "";
                }

                Thread.CurrentThread.Join(100);
            }
        }
        public void startConnect()
        {
            while (!isConnected)
            {
                try
                {
                    tcpClient.Connect("172.16.3.25", 1800);
                    isConnected = true;
                    strm = tcpClient.GetStream();

                    StrMsg = "3";
                    if (lblVaziat.InvokeRequired)
                    {
                        lblVaziat.Invoke(new MethodInvoker(delegate { DataReceive(); }));
                        StrMsg = "";
                    }
                }
                catch { }

                Thread.CurrentThread.Join(100);
            }
        }
        private void FrmTolid_Hack_FormClosing(object sender, FormClosingEventArgs e)
        {
            //InsDailyReport();
            tcpClient.Close();
        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            ShenaseKitInt--;
            ObjTolid.ShenaseKitInt = txtShenaseInt.Text = ShenaseKitInt.ToString();
            txtShenase.Text = ObjTolid.Select_ShenaseKitChar().Tables[0].Rows[0][0].ToString();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            ShenaseKitInt++;
            ObjTolid.ShenaseKitInt = txtShenaseInt.Text = ShenaseKitInt.ToString();
            txtShenaseInt.Text = ShenaseKitInt.ToString();
            txtShenase.Text = ObjTolid.Select_ShenaseKitChar().Tables[0].Rows[0][0].ToString();
        }
        private void btnBarnameRefresh_Click(object sender, EventArgs e)
        {
            grpH.Enabled = true;
            GrdPartKit.DataSource = null;
        }
        private void btnRadyabiRefresh_Click(object sender, EventArgs e)
        {
            GrdPartKit.Enabled = true;
            grp.Enabled = false;
            btnSabtRadyabi.Enabled = true;
            btnBarnameRefresh.Enabled = true;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                if (isConnected)
                {
                    strm = tcpClient.GetStream();
                    dataSend = txtShenase.Text;
                    byte[] byttes = new byte[dataSend.Length];

                    for (int i = 0; i < dataSend.Length; i++)
                        byttes[i] = Convert.ToByte(dataSend[i]);

                    strm.Write(byttes, 0, byttes.Length);
                    dataSend = "";
                    //MessageBox.Show("ارتباط برقرار است");
                }
            }
            catch
            {
                MessageBox.Show("خطا در ارتباط");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.IO;
using System.Reflection;
using FastReport;
using System.Diagnostics;
using System.Drawing.Printing;
using SautinSoft;

namespace ET
{
    public partial class FrmTakvinMostanad : Telerik.WinControls.UI.RadForm
    {
        public FrmTakvinMostanad()
        {
            InitializeComponent();
        }
        ClsTakvin objTakvin = new ClsTakvin();
        public string MostanadLocation, strMostanadName;
        DataRow drselectInfoMostanadPrint ;

        private void PrintForm ()
        {
            try
            {
                /*
                PaperSize ps = new PaperSize("", 1366, 768);
                radPdfViewerNavigatorMos.Visible = false;
                //this.radPdfVMostanad.ShowThubnails;
                btnPrint.Visible = false;
                printDlgMostanad.ShowDialog();
                PrintFormMostanad.PrintAction = System.Drawing.Printing.PrintAction.PrintToPreview;
                PrintFormMostanad.Form = this;
                PrintFormMostanad.Print();
                btnPrint.Visible = true;
                radPdfViewerNavigatorMos.Visible = true;

                printDlgMostanad.Document = PrintDocMostanad;
                printDlgMostanad.PrinterSettings = PrintDocMostanad.PrinterSettings;
                printDlgMostanad.AllowSomePages = true;
                if (printDlgMostanad.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    PrintDocMostanad.PrintController = new StandardPrintController();

                    PrintDocMostanad.DefaultPageSettings.Margins.Left = 0;
                    PrintDocMostanad.DefaultPageSettings.Margins.Right = 0;
                    PrintDocMostanad.DefaultPageSettings.Margins.Top = 0;
                    PrintDocMostanad.DefaultPageSettings.Margins.Bottom = 0;
                    PrintDocMostanad.DefaultPageSettings.PaperSize = ps;
                    //PrintDocMostanad.Print();
                    PrintDocMostanad.PrinterSettings = printDlgMostanad.PrinterSettings;
                    PrintDocMostanad.Print();
              
                }
                 */
            }
            catch (Exception exp)
            {
                RadMessageBox.Show(this, exp.Message);
            }
        }
        private void FrmTakvinMostanad_Load(object sender, EventArgs e)
        {
            /*//-----------------fast report
            using (Report report = new Report())
            {
                report.Load("myreport.frx");
                report.RegisterData(dataSet1.Tables["mytable"], "table");
                report.Show();
            }
             */


            /*
             op.Filter = "PDF Files (*.*)|*.pdf";
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                picMostanad.ImageLocation = op.FileName;
            }
             
            picMostanad.ImageLocation = MostanadLocation;
            File.Copy("E:\\1.pdf", "D:\\1.pdf", true);//if false =if file exist not copy
            if (File.Exists("E:\\1.pdf"))
            {
                    RadMessageBox.Show("فایل مورد نظر وجود دارد");
            }
            string StartDirectory = @"d:\test";
            string EndDirectory = @"e:\test";
            string filename ="1.pdf"
            FileStream SourceStream = File.Open(filename, FileMode.Open);
            //FileStream DestinationStream = File.Create(EndDirectory + filename.Substring(filename.LastIndexOf('\\'))) ;
             FileStream DestinationStream = File.Create(EndDirectory + filename);
             await SourceStream.CopyToAsync(DestinationStream); //using System.Threading.Tasks;
              
             */
            //Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("1.pdf");
            //--------------------------------------------------------------------------------------------------------
           // string filename = "E:\\1.pdf";
            //string filename = @"\\mps\MIS\MostanadatFani\1.pdf";
            //string filename = MostanadLocation ;
            //FileStream SourceStream = File.Open(filename, FileMode.Open, FileAccess.Write, FileShare.Write);
            //string filename = "MostanadatFani\\1.pdf";
            //  string filename = "1.pdf";

            //FileStream SourceStream = File.Open(filename, FileMode.Open);
            //Stream stream = SourceStream;
            //SourceStream.Close();
            //stream.Close();

/*
            string filename = MostanadLocation;
            Stream stream = File.OpenRead(filename);
            this.radPdfVMostanad.LoadDocument(stream);
            this.radPdfVMostanad.ShowThubnails();
            
*/
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
            try
            {
                
                radPdfViewerNavigatorMos.OpenButton.Enabled = false;
                if (AllowPrintMostanadat.Visible == true)
                {
                    this.TopMost = false;
                    btnPrintMostanad.Enabled = true;
                }
                else
                {
                   btnPrintMostanad.Enabled  = false;
                }
                radPdfViewerNavigatorMos.PrintButton.Enabled = false;
                drselectInfoMostanadPrint = objTakvin.selectInfoMostanadPrint().Tables[0].Rows[0];
                this.radPdfVMostanad.LoadDocument(MostanadLocation);
               
                //string filename = MostanadLocation;
                //Stream stream = File.OpenRead(filename);
                //this.radPdfVMostanad.LoadDocument(stream);

                //this.radPdfVMostanad.ShowThubnails();

                //----------------------------------------------------------------------create pdf to image
                SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

                //f.Serial = "XXXXX";
                f.OpenPdf(MostanadLocation);
                if (f.PageCount > 0)
                {
                    //Set 200 dpi and jpeg format
                    f.ImageOptions.Dpi = 300;
                    f.ImageOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                    //Save all pages to jpegs into the folder 'Pictures'
                    //P.S. The folder 'Pictures' must be existed
                    if (f.PageCount == 1)
                    {
                        f.ToImage(objTakvin.strDesPathPic + strMostanadName + ".jpg", 1);
                    }
                    else
                    {
                        for (int page = 1; page <= f.PageCount; page++)
                            f.ToImage(objTakvin.strDesPathPic + strMostanadName + "_" + page + ".jpg", page);
                    }
                    
                }
            }
            catch (Exception exp)
            {
                RadMessageBox.Show(this,"خطا در باز کردن فایل");
                this.Close();
            }
            
        }

        private void ToolStripMenuItemCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radPdfVMostanad_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //radPdfVMostanad.ContextMenu.Dispose(); 
                //radPdfVMostanad.ContextMenuStrip = contextMenuStripMos;
                RadMessageBox.Show(this,"شما دسترسی ندارید");
                //Clipboard.Clear();
                //return;
            }  
           
        }

        private void radPdfVMostanad_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.PrintScreen)
           // {
            //    this.Hide();
                Clipboard.Clear();
           // }
        }

        private void FrmTakvinMostanad_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.PrintScreen)
            //{
             //   this.Hide();
                Clipboard.Clear();
            //}
        }

        private void FrmTakvinMostanad_Leave(object sender, EventArgs e)
        {
            Clipboard.Clear();
            
            this.Close();
        }

        private void FrmTakvinMostanad_MouseLeave(object sender, EventArgs e)
        {
            Clipboard.Clear();
        }

        private void FrmTakvinMostanad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clipboard.Clear();
        }

        private void radPdfVMostanad_Leave(object sender, EventArgs e)
        {
            Clipboard.Clear();
        }

        private void radPdfVMostanad_MouseLeave(object sender, EventArgs e)
        {
            Clipboard.Clear();
        }

              

        private void btnPrintMostanad_Click(object sender, EventArgs e)
        {
            
            try
            {       
                //---------------------------------------------------------check not new version or disable mostanad
                objTakvin.IDMostanad = strMostanadName;
                if (objTakvin.checkMosNotNewVersion().Tables[0].Rows.Count>0)
                {
                    RadMessageBox.Show("این سند نا معتبر شد");
                    return;
                }
                //-----------------------------------------------------------
                
                Report objReport = new Report();
                objReport.Load(objTakvin.strPrintPath + "MostanadatFani.frx");
                //objReport.Preview.Buttons = FastReport.PreviewButtons.Close;// +FastReport.PreviewButtons.Print;
                objReport.SetParameterValue("lblIdMostanad", strMostanadName);
                objReport.SetParameterValue("lblDate", drselectInfoMostanadPrint["DatePrint"].ToString());
                objReport.SetParameterValue("lblTime", drselectInfoMostanadPrint["TimePrint"].ToString());
                objReport.SetParameterValue("lblUser", drselectInfoMostanadPrint["username"].ToString());
                objReport.SetParameterValue("PicLocation", objTakvin.strDesPathPic + strMostanadName + ".jpg");
                //----@"\\mps\MIS\MISSecurityFile\MostanadatFaniPic\2.jpg"
                objReport.Print();
                //objReport.Show();
                //---------------------------------------------------------------------insert log print
                objTakvin.IDMostanad = strMostanadName;
                objTakvin.StrMostanadDatePrint = drselectInfoMostanadPrint["DatePrint"].ToString();
                objTakvin.StrMostanadTimePrint = drselectInfoMostanadPrint["TimePrint"].ToString();
                RadMessageBox.Show(objTakvin.InsMostanadLogPrint());
                
            }
            catch (Exception exp)
            {
                RadMessageBox.Show(this," خطا در چاپ" );
            }
        }

       

    }
}

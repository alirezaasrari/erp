using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.Diagnostics;

namespace ET
{
    public partial class Frm_Senni_ForoshReport : Telerik.WinControls.UI.RadForm
    {   
        public Frm_Senni_ForoshReport()
        {
            InitializeComponent();
        }

        public ClsBI BI = new ClsBI();
        public DataSet ds = new DataSet();
        string strwhere;
        string strsql;

        private void StyleCell(GridViewCellInfo cell)
        {
           // cell.Style.Font = myFont;
            cell.Style.CustomizeFill = true;
            //cell.Style.GradientStyle = GradientStyles.Solid;
            cell.Style.BackColor = Color.Beige;
        }

        private void btn_Report_Click(object sender, EventArgs e)
        {
            //Report ******************************************************

            if (rdbtnDolati.Checked == true)
            {
                ClsMali.dolati = 1;
                // strwhere = " AND ( IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=0 and IS_khadamat=0 ) ";
            }
            else
            { 
                ClsMali.dolati = 0;
            }

            if (rdbtnkhososi.Checked == true)
            {
                ClsMali.khososi = 1;
                // strwhere = " AND ( IS_moshtari=1 AND IS_omomi=0 AND IS_Bazaryab=0 AND IS_Bestankardolati=0 and IS_khadamat=0) ";
            }
            else
            {
                ClsMali.khososi = 0;
            }

            if (rdbtnkhareji.Checked == true)
            {
                ClsMali.khareji = 1;
                //strwhere = " AND ( IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=1 and IS_khadamat=0)  ";
            }
            else
            {
                ClsMali.khareji = 0; 
            }

            if (rdbtnMoshtarekin.Checked == true)
            {
                ClsMali.Moshtarekin = 1;
                // strwhere = " AND ( IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=1 AND IS_Bestankardolati=0 and IS_khadamat=0) ";
            }
            else
            {
                ClsMali.Moshtarekin = 0;
            }
            if (rdbtnkhadamat.Checked == true)
            {
                ClsMali.KHadamat = 1;
                // strwhere = " AND ( IS_moshtari=1 AND IS_omomi=0 AND IS_Bazaryab=0 AND IS_Bestankardolati=0 and IS_khadamat=1) ";
            }
            else
            {
                ClsMali.KHadamat = 0;
            }

            if (rdbtnAll.Checked == true)
            {
                strwhere = "";
            }
            if ((chktafsili.Checked == true) & (txttafsilistart.Text != "") & (txttafsiliend.Text != ""))
            {
                ClsMali.Tafsili = 1;
                ClsMali.tafsilistart = txttafsilistart.Text.ToString();
                ClsMali.tafsiliend = txttafsiliend.Text.ToString();
                //strwhere = " and C_Tafsili between " + txttafsilistart.Text.ToString() + " and " + txttafsiliend.Text.ToString();
            }
            else 
            {
                ClsMali.Tafsili = 0;
                ClsMali.tafsilistart = "";
                ClsMali.tafsiliend = "";
            }
            if ((chkBazeforosh.Checked == true) & (pdateBegin.Value.ToString() != "") & (pdateEnd.Value.ToString() != ""))
            {
                ClsMali.Tafsili = 1;
                ClsMali.start_date = pdateBegin.Value.ToString();
                ClsMali.end_date = pdateEnd.Value.ToString();
                //strwhere = " and C_Tafsili between " + txttafsilistart.Text.ToString() + " and " + txttafsiliend.Text.ToString();
            }
            else 
            {
                ClsMali.Tafsili = 0;
                ClsMali.start_date = "";
                ClsMali.end_date = "";
            }
            
            if (rdbtnMande.Checked==true)
            {
                ClsMali.Mande =1;
            }
            else
            {
                ClsMali.Mande = 0;
            }
            if (rdbtnMandeKasr.Checked == true)
            {
                ClsMali.Mandepasazkasr = 1;
            }
            else
            {
                ClsMali.Mandepasazkasr = 0;
            }
            if (rdbtnAll.Checked == true)
            {
                ClsMali.all = 1;
            }
            else
            {
                ClsMali.all = 0;
            }
            
            //ds = BI.SelectDB();
            ClsMali clsmali = new ClsMali();
            ds = clsmali.senni_forosh_report();
            dgw.DataSource = ds.Tables[0];
            clsmali.clr_var();
            for (int i = 0; i <= dgw.Rows.Count - 1; i++)
            {
                this.StyleCell(this.dgw.Rows[i].Cells["C_Tafsili"]);
                this.StyleCell(this.dgw.Rows[i].Cells["pish_daryaft"]);
                this.StyleCell(this.dgw.Rows[i].Cells["mablagh_variz"]);
                this.StyleCell(this.dgw.Rows[i].Cells["takhir2mah"]);
                this.StyleCell(this.dgw.Rows[i].Cells["takhir4mah"]);
                this.StyleCell(this.dgw.Rows[i].Cells["takhir6mah"]);
                this.StyleCell(this.dgw.Rows[i].Cells["takhir18mah"]);
                this.StyleCell(this.dgw.Rows[i].Cells["takhirbishtar"]);                
            }

            dgw.Columns["pish_daryaft"].FormatString = "{0:#,###}";
            dgw.Columns["mablagh_variz"].FormatString = "{0:#,###}";
            dgw.Columns["mablagh_forosh"].FormatString = "{0:#,###}";
            dgw.Columns["takhir1mah"].FormatString = "{0:#,###}";
            dgw.Columns["takhir2mah"].FormatString = "{0:#,###}";
            dgw.Columns["takhir3mah"].FormatString = "{0:#,###}";
            dgw.Columns["takhir4mah"].FormatString = "{0:#,###}";
            dgw.Columns["takhir5mah"].FormatString = "{0:#,###}";
            dgw.Columns["takhir6mah"].FormatString = "{0:#,###}";
            dgw.Columns["takhir12mah"].FormatString = "{0:#,###}";
            dgw.Columns["mande"].FormatString = "{0:#,###}";
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            //if (cmbtedadrooz.Text == "")
            //{
            //    MessageBox.Show("تعداد روز را وارد نمایید");
            //}

            //if (cmbtedadrooz.Text != "")
            //{
            //    //Execute *****************************************************
            //    string tedad_rooz;
            //    tedad_rooz = "0";

            //    if (cmbtedadrooz.Text == "پانزده روزه")
            //    {
            //        tedad_rooz = "15";
            //    }
            //    if (cmbtedadrooz.Text == "یک ماهه")
            //    {
            //        tedad_rooz = "30";
            //    }
            //    if (cmbtedadrooz.Text == "دو ماهه")
            //    {
            //        tedad_rooz = "60"; 
            //    }
            //    if (cmbtedadrooz.Text == "سه ماهه")
            //    {
            //        tedad_rooz = "90";
            //    }
            //    if (cmbtedadrooz.Text == "چهار ماهه")
            //    {
            //        tedad_rooz = "120";
            //    }
            //    if (cmbtedadrooz.Text == "پنج ماهه")
            //    {
            //        tedad_rooz = "150";
            //    }
            //    if (cmbtedadrooz.Text == "شش ماهه")
            //    {
            //        tedad_rooz = "180";
            //    }

            //    strsql = " Exec AGL_SP_Report_Forosh  @tedad_rooz=" + tedad_rooz;
                
            //    BI.strQuery = strsql;
                
            //    MessageBox.Show(BI.ExcecDb());
            //}
            if ( (chkBazeforosh.Checked == true))
            {
                ClsMali.Bazeforosh = 1;
                //BI.strQuery = strsql;
                //MessageBox.Show(BI.ExcecDb());
                ClsMali.start_date=pdateBegin.Value.ToString().Substring(0, 10);
                ClsMali.end_date = pdateEnd.Value.ToString().Substring(0, 10); 
                ClsMali clsmali = new ClsMali();
                MessageBox.Show(clsmali.senni_foroshreport());
            }
            else
            {
                 ClsMali.end_date="";
                 ClsMali.start_date = "";
                ClsMali.Bazeforosh = 0;
                MessageBox.Show("تاریخ را وارد کنید");
            }
        }

        private void btnExcell_Click(object sender, EventArgs e)
        {
            //string[] str = new string[1000];
            //for (int i = 0; i < dgw.ColumnCount; i++)
            //{
            //    str[i] = dgw.Columns[i].HeaderText;
            //    //MessageBox.Show(dgw.Columns[i].HeaderText);
            //    //MessageBox.Show(str[i]);
            //}

            //ExitExcel.ExitExcel ex = new ExitExcel.ExitExcel();
            //ex.Excel(ds, str);

            string fileName = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = string.Format("{0} (*{1})|*{1}", "Excel Files", ".xls")
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
            }
            (new ExportToExcelML(this.dgw)).RunExport(fileName);
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

        private void chkpish_CheckedChanged(object sender, EventArgs e)
        {
            if (chkpish.Checked == true)
            {
                dgw2.Columns[3].Visible = true;
            }

            if (chkpish.Checked == false)
            {
                dgw2.Columns[3].Visible = false;
            }
        }

        private void clr()
        {
            chkpish.Checked = false;
            dgw2.Columns[3].Visible = false;

           // cmbtedadrooz.Items.Clear();

            rdbtnAll.Checked = false;
            rdbtnDolati.Checked = false;
            rdbtnkhareji.Checked = false;
            rdbtnkhososi.Checked = false;
            rdbtnMande.Checked = false;
            rdbtnMandeKasr.Checked = false;
            rdbtnMoshtarekin.Checked = false;
        }

        private void Frm_Senni_ForoshReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClsMali.Tafsili=0;
            ClsMali.Mande=0;
            ClsMali.Mandebedehkar=0;
            ClsMali.Mandebestankar=0;
            ClsMali.mablaghbaze=0;
            ClsMali.khososi=0;
            ClsMali.khareji=0;
            ClsMali.nmoshtarekin=0;
            ClsMali.KHadamat=0;
            ClsMali.Moshtarekin=0;
            ClsMali.Bazeforosh=0;
            ClsMali.Mandepasazkasr=0;
            ClsMali.all=0;

            ClsMali.tafsilistart="";
            ClsMali.tafsiliend="";
            ClsMali.Mablaghstart="";
            ClsMali.Mablaghend="";
            ClsMali.start_date="";
            ClsMali.end_date="";

            clr();
        }

        private void cmbtedadrooz_DropDown(object sender, EventArgs e)
        {
            //cmbtedadrooz.Items.Clear();
            //cmbtedadrooz.Items.Add("پانزده روزه");
            //cmbtedadrooz.Items.Add("یک ماهه");
            //cmbtedadrooz.Items.Add("دو ماهه");
            //cmbtedadrooz.Items.Add("سه ماهه");
            //cmbtedadrooz.Items.Add("چهار ماهه");
            //cmbtedadrooz.Items.Add("پنج ماهه");
            //cmbtedadrooz.Items.Add("شش ماهه");
        }

        private void rdbtnMande_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnMande.Checked == true)
            {
                dgw2.Columns[13].HeaderText = "مانده بدهکاری";
            }
        }

        private void rdbtnMandeKasr_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnMandeKasr.Checked == true)
            {
                dgw2.Columns[13].HeaderText = "مانده پس از کسر چک/پیش دریافت";
            }
        }

        private void Frm_Senni_ForoshReport_Load(object sender, EventArgs e)
        {
            clr();
            pdateBegin.Value = DateTime.Now;
            pdateEnd.Value = DateTime.Now;
        }

        private void dgw_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txttafsilistart_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkBazeforosh_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBazeforosh.Checked == true)
            {
                pdateBegin.Enabled = true;
                pdateEnd.Enabled = true;
            }
            else if (chkBazeforosh.Checked == false)
            {
                pdateBegin.Enabled = false;
                pdateEnd.Enabled = false;
            }
        }

        private void chktafsili_CheckedChanged(object sender, EventArgs e)
        {
            if (chktafsili.Checked == true)
            {
                txttafsiliend.Enabled = true;
                txttafsilistart.Enabled = true;
            }
            else if (chktafsili.Checked == false)
            {
                txttafsiliend.Enabled = false;
                txttafsilistart.Enabled = false;
            }
        }


    }
}
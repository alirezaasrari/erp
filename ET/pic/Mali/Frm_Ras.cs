using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ET
{
    public partial class Frm_Ras : Telerik.WinControls.UI.RadForm
    {
        ClsBI BI = new ClsBI();
        DataSet ds = new DataSet();
        string strwhere, strquery;

        public Frm_Ras()
        {
            InitializeComponent();
        }

        private void clr()
        {
            rdbtnDolati.Checked = false;
            rdbtnKhareji.Checked = false;
            rdbtnKhososi.Checked = false;
            rdbtnMoshtarekin.Checked = false;
            rdbtnTafsili.Checked = false;
            txtTafsili.Clear();
            txtTafsili.Enabled = false;
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            ClsMali clsmali = new ClsMali();
            MessageBox.Show(clsmali.Senni_Ras());
        }

        private void btnReport_Click(object sender, EventArgs e)
        {

            if (rdbtnDolati.Checked == true)
            {
                ClsMali.dolati = 1;
            }
            else
            {
                ClsMali.dolati = 0;
            }

            if (rdbtnKhososi.Checked == true)
            {
                ClsMali.khososi = 1;  
            }
            else
            {
                ClsMali.khososi = 0;  
            }

            if (rdbtnKhareji.Checked == true)
            {
                ClsMali.khareji = 1;
            }
            else 
            {
                ClsMali.khareji = 0;
            }


            if (rdbtnMoshtarekin.Checked == true)
            {
                ClsMali.Moshtarekin = 1;
            }
            else 
            {
                ClsMali.Moshtarekin = 0;
            }
            if (rbtnkhadamat.Checked == true)
            {
                ClsMali.KHadamat = 1;
            }
            else
            {
                ClsMali.KHadamat = 0;
            }


            if ((rdbtnTafsili.Checked == true) &(txtTafsili.Text.ToString()!=""))
            {
                ClsMali.Tafsili = 1;
                ClsMali.tafsilistart=txtTafsili.Text.ToString();
            }
            else 
            {
                ClsMali.Tafsili = 0;
                ClsMali.tafsilistart = "";
            }


            ClsMali cls_mali = new ClsMali();
            ds = cls_mali.Senni_Report_Ras();

            dgw.DataSource=ds.Tables[0];

            //dgw.Columns["Mablagh_Check"].FormatString = "{0:#,###}";
            //dgw.Columns["Mablagh_Factor"].FormatString = "{0:#,###}";

        }

        private void txtTafsili_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.F2)
            {
                Frm_Tafsili frt = new Frm_Tafsili();
                frt.ShowDialog();
                txtTafsili.Text = Frm_Tafsili.CTafsili;
                Frm_Tafsili.CTafsili = "";
            }
        }

        private void Frm_Ras_Load(object sender, EventArgs e)
        {
            clr();
        }

        private void Frm_Ras_FormClosed(object sender, FormClosedEventArgs e)
        {
            clr();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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

            ExitExcel.ExitExcel ex = new ExitExcel.ExitExcel();
            ex.Excel(ds, str);
        }

        private void rdbtnTafsili_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnTafsili.Checked == true)
            {
                txtTafsili.Enabled = true;
            }

            if (rdbtnTafsili.Checked == false)
            {
                txtTafsili.Enabled = false;
            }
        }

        private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


    }
}

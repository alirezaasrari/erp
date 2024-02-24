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
    public partial class Frm_Senni_Ras_Check : Telerik.WinControls.UI.RadForm
    {
        ClsBI BI = new ClsBI();
        DataSet ds = new DataSet();        

        public Frm_Senni_Ras_Check()
        {
            InitializeComponent();
        }

        private void clr()
        {
            txtTafsili.Clear();
            txtTafsili.Enabled = false;

            chkTafsili.Checked = false;

            rdbtnDolati.Checked = false;
            rdbtnKhareji.Checked = false;
            rdbtnKhososi.Checked = false;
            rdbtnMoshtarekin.Checked = false;
        }

        private void Frm_Ras_Check_Load(object sender, EventArgs e)
        {
            clr();   
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            string strwhere, srtsql, strGroup;


            if (rdbtnDolati.Checked == true)
            {
                ClsMali.dolati = 1;
                //strwhere = " AND (IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=0) "; //dolati
            }
            else
            { 
                ClsMali.dolati = 0;
            }

            if (rdbtnKhareji.Checked == true)
            {
                ClsMali.khareji = 1;
                // strwhere = " AND (IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=1) "; //Khareji
            }
            else
            {
                ClsMali.khareji = 0;
            }

            if (rdbtnKhososi.Checked == true)
            {
                ClsMali.khososi = 1;
                // strwhere = " AND (IS_moshtari=1 AND IS_omomi=0 AND IS_Bazaryab=0 AND Tbl_Ras.IS_Bestankardolati=0)  "; //khososi
            }
            else
            { 
                ClsMali.khososi = 0;
            }

            if (rdbtnMoshtarekin.Checked == true)
            {
                ClsMali.Moshtarekin = 1;
                //strwhere = " AND (IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=1 AND IS_Bestankardolati=0)  "; //moshtarekin
            }
            else
            {
                ClsMali.Moshtarekin = 0;
            }

            if ((chkTafsili.Checked == true) & (txtTafsili.Text != ""))
            {
                ClsMali.Tafsili = 1;
                ClsMali.tafsilistart = txtTafsili.Text;
                //strwhere = " AND Ctafsili=" + txtTafsili.Text;
            }
            else
            {
                ClsMali.Tafsili = 0;
                ClsMali.tafsilistart = "";
            }

            // BI.strQuery = srtsql + strwhere + strGroup;
            //ds=BI.SelectDB();

            ClsMali clsmali = new ClsMali();
            ds = clsmali.Senni_Report_Ras_Check();

            dataGridView1.DataSource=ds.Tables[0];
            clsmali.clr_var();

        }

        private void btnExcell_Click(object sender, EventArgs e)
        {
            string[] str = new string[100];
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                str[i] = dataGridView1.Columns[i].HeaderText;
                //MessageBox.Show(dgw.Columns[i].HeaderText);
                //MessageBox.Show(str[i]);
            }

            ExitExcel.ExitExcel ex = new ExitExcel.ExitExcel();
            ex.Excel(ds, str);
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            //BI.strQuery = " Exec AGL_SP_Ras_Check";
            ClsMali clsmali = new ClsMali();

            MessageBox.Show(clsmali.Senni_Ras_chack());

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTafsili_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                Frm_Tafsili frt = new Frm_Tafsili();
                frt.ShowDialog();
                txtTafsili.Text = Frm_Tafsili.CTafsili;
                Frm_Tafsili.CTafsili = "";
            }
        }

        private void chkTafsili_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTafsili.Checked == true)
            {
                txtTafsili.Enabled = true;
            }

            if (chkTafsili.Checked == false)
            {
                txtTafsili.Enabled = false;
            }
        }

        private void Frm_Senni_Ras_Check_FormClosed(object sender, FormClosedEventArgs e)
        {
            clr();
        }


    }
}

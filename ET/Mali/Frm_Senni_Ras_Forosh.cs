using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ET
{
    public partial class Frm_Senni_Ras_Forosh : Telerik.WinControls.UI.RadForm
    {
        ClsBI bi = new ClsBI();
        DataSet ds = new DataSet();

        public Frm_Senni_Ras_Forosh()
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

        private void Frm_Ras_Forosh_Load(object sender, EventArgs e)
        {
            clr();
        }      

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            string strsql, strwhere, strGroup;

            strwhere = "";

            if (rdbtnDolati.Checked == true)
            {
                ClsMali.dolati = 1;
               // strwhere = " AND ( IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=0 )  "; //dolati
            }

            if (rdbtnKhososi.Checked == true)
            {
                ClsMali.khososi = 1;
                //strwhere = " AND ( IS_moshtari=1 AND IS_omomi=0 AND IS_Bazaryab=0 AND Tbl_Ras.IS_Bestankardolati=0 )  ";//khososi
            }

            if (rdbtnKhareji.Checked == true)
            {
                ClsMali.khareji = 1;
               // strwhere = " AND ( IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=1 )  ";  //khareji
            }

            if (rdbtnMoshtarekin.Checked == true)
            {
                ClsMali.Moshtarekin = 1;
               // strwhere = " AND ( IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=1 AND IS_Bestankardolati=0 ) ";  //moshtarekin
            }
            if (chkTafsili.Checked==true)
            {
                if (txtTafsili.Text == "")
                {
                    ClsMali.Tafsili = 0;
                    ClsMali.tafsilistart = "";
                    Close();
                    MessageBox.Show("کد تفصیلی را وارد نمایید");
                }
                else
                {
                    ClsMali.Tafsili = 1;
                    ClsMali.tafsilistart = txtTafsili.Text;

                  //  strwhere = " AND Tbl_Ras.C_customer=" + txtTafsili.Text;
                }
                
            }

            ClsMali clsmali = new ClsMali();
            ds =clsmali.Senni_Report_Ras_Factor();

            dataGridView1.DataSource = ds.Tables[0];
            clsmali.clr_var();
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

        private void Frm_Ras_Forosh_FormClosed(object sender, FormClosedEventArgs e)
        {
            clr();
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

        //private void btnCalc_Click(object sender, EventArgs e)
        //{

        //}

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
    }
}

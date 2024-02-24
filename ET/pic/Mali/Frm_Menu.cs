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
    public partial class Frm_Menu : Form
    {
        public Frm_Menu()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Frm_Senni_Ras_Forosh frf = new Frm_Senni_Ras_Forosh();
            //frf.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Senni_Operate fop = new Frm_Senni_Operate();
            fop.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Frm_Sennireport frm = new Frm_Sennireport();
            //frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //FRM_SenniDetail frm = new FRM_SenniDetail();
            //frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Frm_Senni_Ras_Check frm = new Frm_Senni_Ras_Check();
            //frm.Show();
        }

        private void btn_Reportforosh_Click(object sender, EventArgs e)
        {
            //Frm_Senni_ForoshReport frm=new Frm_Senni_ForoshReport();
            //frm.Show();
        }

        private void Frm_Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Frm_Login frm = new Frm_Login();
            //frm.Show();
        }

        private void btn_Ras_Click(object sender, EventArgs e)
        {
            //Frm_Ras frs = new Frm_Ras();
            //frs.Show();
        }

        private void BtnTotal_Click(object sender, EventArgs e)
        {
            Frm_Total frt = new Frm_Total();
            frt.Show();
        }

        private void Frm_Menu_Load(object sender, EventArgs e)
        {

        }


    }
}

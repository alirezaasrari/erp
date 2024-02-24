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
    public partial class Frm_Tafsili : Telerik.WinControls.UI.RadForm
    {
        public static string CTafsili,NTafsili;
        public string fm;
        ClsBI BI = new ClsBI();
        DataSet ds = new DataSet();

        public Frm_Tafsili()
        {
            InitializeComponent();
        }

        private void txtCTafsili_TextChanged(object sender, EventArgs e)
        {
            if (txtCTafsili.Text != "")
            {
                BI.StrQuery = "SELECT Distinct Ctafsili,Ntafsili  \n"
                            + "FROM AGL_Tbl_Tafsili  \n"
                            + "WHERE  Ctafsili like '%'+'" + txtCTafsili.Text + "'+'%' \n"
                            + "ORDER BY Ctafsili";

                ds = BI.SelectDB();
                dgw.DataSource = ds.Tables[0];
            }

            if (txtCTafsili.Text == "")
            {
                BI.StrQuery = "SELECT Distinct Ctafsili,Ntafsili  \n"
                            + "FROM AGL_Tbl_Tafsili  \n"
                            + "WHERE  Ctafsili='0' ";

                ds = BI.SelectDB();
                dgw.DataSource = ds.Tables[0];
            }

        }

        private void txtNTafsili_TextChanged(object sender, EventArgs e)
        {
            if (txtNTafsili.Text != "")
            {
                BI.StrQuery = "SELECT Ctafsili,Ntafsili  \n"
                            + "FROM AGL_Tbl_Tafsili  \n"
                            + "WHERE  Ntafsili LIKE  '%'+'" + txtNTafsili.Text + "'+'%' \n"
                            + "ORDER BY Ctafsili";

                ds = BI.SelectDB();
                dgw.DataSource = ds.Tables[0];
            }

            if (txtNTafsili.Text == "")
            {
                BI.StrQuery = "SELECT Ctafsili,Ntafsili  \n"
                            + "FROM AGL_Tbl_Tafsili  \n"
                            + "WHERE  Ctafsili='0' ";

                ds = BI.SelectDB();
                dgw.DataSource = ds.Tables[0];
            }

        }

        private void dgw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CTafsili = ds.Tables[0].Rows[e.RowIndex][0].ToString();
            NTafsili = ds.Tables[0].Rows[e.RowIndex][1].ToString();
            Close();
        }

        private void Frm_Tafsili_Load(object sender, EventArgs e)
        {
            txtCTafsili.Clear();
            txtNTafsili.Clear();
        }

        private void Frm_Tafsili_FormClosed(object sender, FormClosedEventArgs e)
        {
            txtCTafsili.Clear();
            txtNTafsili.Clear();
        }


    }
}

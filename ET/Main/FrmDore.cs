using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ET
{
    public partial class FrmDore : Form
    {
        public FrmDore()
        {
            InitializeComponent();
        }
        public DataSet ds = new DataSet();
         ClsMain cm = new ClsMain();

        private void FrmDore_Load(object sender, EventArgs e)
        {
            ds = cm.SelectDB_Curent();
            dgw.DataSource = ds.Tables[0];
        }

        private void dgw_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ClsConnect.Dore = ds.Tables[0].Rows[e.RowIndex]["N_DB"].ToString();
            ClsConnect.Namedore = ds.Tables[0].Rows[e.RowIndex]["DB_Description"].ToString();
            ClsConnect.DbPaya = ds.Tables[0].Rows[e.RowIndex]["DB_Paya"].ToString();
            ClsConnect.DbYear = ds.Tables[0].Rows[e.RowIndex]["DbYear"].ToString();
            this.Close();
        }

        private void dgw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ClsConnect.Dore = dgw.CurrentRow.Cells["N_DB"].Value.ToString();
                ClsConnect.Namedore = dgw.CurrentRow.Cells["DB_Description"].Value.ToString();
                ClsConnect.DbPaya = dgw.CurrentRow.Cells["DB_Paya"].Value.ToString();
                ClsConnect.DbYear = dgw.CurrentRow.Cells["DbYear"].Value.ToString();
                this.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace ET
{
    public partial class FrmTakvinKala : Telerik.WinControls.UI.RadForm
    {
        public FrmTakvinKala()
        {
            InitializeComponent();
        }
        public string strIsOutSource, strIsKharid, strIsTolid, strIsTarkib;
        public static string strNkala, strCkala, strIdGhete,strAnbar;
        private void FrmTakvinKala_Load(object sender, EventArgs e)
        {
            ClsTakvin objTakvin = new ClsTakvin();
            objTakvin.strIsKharid = strIsKharid;
            objTakvin.strIsTolid = strIsTolid;
            objTakvin.strIsOutSource = strIsOutSource;
            objTakvin.strIsTarkib = strIsTarkib;
            grd.DataSource = objTakvin.SelectTakvinKala().Tables[0];
        }

        private void grd_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            strCkala = grd.Rows[e.RowIndex].Cells["GhetehCode"].Value.ToString();
            strNkala = grd.Rows[e.RowIndex].Cells["GheteName"].Value.ToString();
            strIdGhete = grd.Rows[e.RowIndex].Cells["id_Gheteh"].Value.ToString();
            strAnbar = grd.Rows[e.RowIndex].Cells["GhetehAnbar"].Value.ToString();
            this.Close();
        }
    }
}

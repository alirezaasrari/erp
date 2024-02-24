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
    public partial class FrmTafsili2 : Telerik.WinControls.UI.RadForm
    {
        public FrmTafsili2()
        {
            InitializeComponent();
        }
        ClsSale ObjSale = new ClsSale();
        public string strCtafsili2, strNtafsili2;
        private void FrmTafsili2_cs_Load(object sender, EventArgs e)
        {
            grd.DataSource = ObjSale.Select_Tafsili2().Tables[0];
        }

        private void grd_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            strCtafsili2 = grd.Rows[e.RowIndex].Cells[0].Value.ToString();
            strNtafsili2 = grd.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.Close();
        }
    }
}

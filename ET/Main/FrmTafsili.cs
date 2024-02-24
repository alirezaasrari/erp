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
    public partial class FrmTafsili : Telerik.WinControls.UI.RadForm
    {
        public string Ctifsili, Ntafsili;
        public FrmTafsili()
        {
            InitializeComponent();
        }
        ClsBuy clsBuyObj = new ClsBuy();
        private void RadForm1_Load(object sender, EventArgs e)
        {
            grd.DataSource = clsBuyObj.SelectTafsili().Tables[0];
        }

        private void grd_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            Ctifsili = ClsBuy.tafsili_Id = grd.Rows[e.RowIndex].Cells[0].Value.ToString();
            Ntafsili = ClsBuy.tafsili_Name = grd.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.Close();
        }
    }
}

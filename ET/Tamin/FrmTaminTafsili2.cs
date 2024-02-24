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
    public partial class FrmTaminTafsili2 : Telerik.WinControls.UI.RadForm
    {
        public FrmTaminTafsili2()
        {
            InitializeComponent();
        }
        public string strIdTafsili2, strNTafsili2;
        private void FrmTaminTafsili2_Load(object sender, EventArgs e)
        {
            ClsTamin objTamin=new ClsTamin();
            grd.DataSource = objTamin.Select_Tafsili2().Tables[0];
        }

        private void grd_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            strIdTafsili2 = grd.CurrentRow.Cells["IDtafsili2"].Value.ToString();
            strNTafsili2 = grd.CurrentRow.Cells["Ntafsili2"].Value.ToString();
            Close();
        }
    }
}

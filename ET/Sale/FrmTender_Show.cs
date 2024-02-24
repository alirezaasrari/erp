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
    public partial class FrmTender_Show : Telerik.WinControls.UI.RadForm
    {
        public string strIdTender, strTenderName; 
        public FrmTender_Show()
        {
            InitializeComponent();
        }

        private void FrmTender_Show_Load(object sender, EventArgs e)
        {
            ClsSale objSale = new ClsSale();
            grd.DataSource = objSale.Select_TenderHeader().Tables[0];
        }

        private void grd_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            strIdTender = grd.Rows[e.RowIndex].Cells["IdTender"].Value.ToString();
            strTenderName = grd.Rows[e.RowIndex].Cells["TenderName"].Value.ToString();
            this.Close();
        }
    }
}

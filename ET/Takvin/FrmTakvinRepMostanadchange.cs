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
    public partial class FrmTakvinRepMostanadchange : Telerik.WinControls.UI.RadForm
    {
        public FrmTakvinRepMostanadchange()
        {
            InitializeComponent();
        }
        ClsTakvin objTakvin = new ClsTakvin();
        private void FrmTakvinRepMostanadchange_Load(object sender, EventArgs e)
        {
            objTakvin.ShowAllMostanadat = "1";
            GrdRepMostanad.DataSource = objTakvin.selectMostanadAll().Tables[0];
        }

        private void GrdRepMostanad_RowPaint(object sender, Telerik.WinControls.UI.GridViewRowPaintEventArgs e)
        {
           // if (Convert.ToBoolean(GrdRepMostanad.Rows[e.RowIndex].Cells[7].Value)==false) 
            //{
            //    GrdRepMostanad.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Beige;
           // }
        }
        private void GrdRepMostanad_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
           // if (Convert.ToBoolean(GrdRepMostanad.Rows[e.RowIndex].Cells[10].Value) == false) 
           // {
           //     GrdRepMostanad.Rows[e.RowIndex].Cells[10].Style.BackColor = System.Drawing.Color.Green;

           //}
        }
    }
}

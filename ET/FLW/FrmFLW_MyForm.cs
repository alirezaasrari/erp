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
    public partial class FrmFLW_MyForm : Telerik.WinControls.UI.RadForm
    {
        public FrmFLW_MyForm()
        {
            InitializeComponent();
        }

        private void FrmFLW_MyForm_Load(object sender, EventArgs e)
        {
            ClsFlw obj = new ClsFlw();
            grd.DataSource = obj.Select_MyForm().Tables[0];
        }

        private void grd_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "btnDetail")
            {
                FrmFLW_EstelamBarge frmEstelam = new FrmFLW_EstelamBarge();
                frmEstelam.strCodeFormX = grd.Rows[e.RowIndex].Cells["CodeFormX"].Value.ToString();
                ClsFlw.Isnew = "0";
                frmEstelam.ShowDialog();
            }
        }
    }
}

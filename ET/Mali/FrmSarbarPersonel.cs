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
    public partial class FrmSarbarPersonel : Telerik.WinControls.UI.RadForm
    {
        public FrmSarbarPersonel()
        {
            InitializeComponent();
        }

        private void FrmSarbarPersonel_Load(object sender, EventArgs e)
        {
            ClsMali obj = new ClsMali();
            grd.DataSource = obj.SelectSarbarVahedNafar().Tables[0];
        }

        private void grd_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "btnEdit")
            {
                ClsMali obj = new ClsMali();

                obj.strNafar = grd.Rows[e.RowIndex].Cells["Nafar"].Value.ToString();
                obj.stridVahed = grd.Rows[e.RowIndex].Cells["Id_AsliVahed"].Value.ToString();
                MessageBox.Show(obj.Update_SarbarVahedNafar());

                grd.DataSource = obj.SelectSarbarVahedNafar().Tables[0];
            }
        }
    }
}

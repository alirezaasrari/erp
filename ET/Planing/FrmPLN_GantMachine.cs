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
    public partial class FrmPLN_GantMachine : Telerik.WinControls.UI.RadForm
    {
        public FrmPLN_GantMachine()
        {
            InitializeComponent();
        }

        private void FrmPLN_GantMachine_Load(object sender, EventArgs e)
        {
            ClsTolid objTolid = new ClsTolid();
            grd.DataSource = objTolid.Select_Dastgah().Tables[0];
        }

        private void grd_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            ClsTolid.strIdMachine = grd.CurrentRow.Cells["ID_machine"].Value.ToString();
            ClsTolid.strNameMachine = grd.CurrentRow.Cells["N_machine"].Value.ToString();
            this.Close();
        }

        private void grd_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F2)
            {
                ClsTolid.strIdMachine = grd.CurrentRow.Cells["ID_machine"].Value.ToString();
                ClsTolid.strNameMachine = grd.CurrentRow.Cells["N_machine"].Value.ToString();
                this.Close();
            }
        }
    }
}

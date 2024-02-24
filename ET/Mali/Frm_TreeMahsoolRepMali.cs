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
    public partial class Frm_TreeMahsoolRepMali : Telerik.WinControls.UI.RadForm
    {
        public Frm_TreeMahsoolRepMali()
        {
            InitializeComponent();
        }
        ClsMali obj = new ClsMali();
        private void Frm_TreeMahsoolRepMali_Load(object sender, EventArgs e)
        {            
            grdGhete.DataSource = obj.SelectTavin_Gheteh().Tables[0];
        }

        private void grdGhete_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                obj.strCKala = grdGhete.CurrentRow.Cells["rootCode"].Value.ToString();
                obj.strGhetehCode = grdGhete.CurrentRow.Cells["nodeCode"].Value.ToString();
                grdProc.DataSource = obj.SelectTavin_process().Tables[0];
            }
            catch
            { }
        }

        private void grdProc_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                obj.strCKala = grdGhete.CurrentRow.Cells["rootCode"].Value.ToString();
                obj.strGhetehCode = grdGhete.CurrentRow.Cells["nodeCode"].Value.ToString();
                obj.strGhetehCode2 = grdProc.CurrentRow.Cells["GhetehCode"].Value.ToString();
                grdMvd.DataSource = obj.SelectTavin_Mavad().Tables[0];
            }
            catch
            { }
        }
    }
}

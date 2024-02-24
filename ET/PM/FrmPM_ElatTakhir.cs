using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ET
{
    public partial class FrmPM_ElatTakhir : Telerik.WinControls.UI.RadForm
    {
        public FrmPM_ElatTakhir()
        {
            InitializeComponent();
        }
        public ClsPM ClsPM = new ClsPM();
        private void FrmElat_takhir_Load(object sender, EventArgs e)
        {
            rgrdElat.DataSource = ClsPM.select_ElatTakhir().Tables[0];
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if ((txt_Nelat.Text != "") & (txt_Nelat.Text != null))
            {
                ClsPM.NElat = txt_Nelat.Text;
            }
            MessageBox.Show(ClsPM.AddElat());
            rgrdElat.DataSource = ClsPM.select_ElatTakhir().Tables[0];

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            
            if ((txt_Nelat.Text != "") & (txt_Nelat.Text != null) & (ClsPM.id_elat!=""))
            {
                MessageBox.Show(ClsPM.DeleteElat());
                rgrdElat.DataSource = ClsPM.select_ElatTakhir().Tables[0];
            }    
        }

        private void rgrdElat_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                txt_Nelat.Enabled = false;
                txt_Nelat.Text = rgrdElat.CurrentRow.Cells["ReasonHalt"].Value.ToString();
                ClsPM.id_elat = rgrdElat.CurrentRow.Cells["ID_Halt"].Value.ToString();
            }
            catch
            {

            }
        }
    }
}

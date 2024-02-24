using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI.Export;
using System.Diagnostics;

namespace ET
{
    public partial class FrmTolid_Zayeat : Telerik.WinControls.UI.RadForm
    {
        public FrmTolid_Zayeat()
        {
            InitializeComponent();
        }
        public string strIdZayeatShenase, strIdZayeatElat;
        private void FrmTolid_Zayeat_Load(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            cmbKargahSh.DataSource = ObjTolid.Select_Unit().Tables[0];
            cmbKargahElat.DataSource = ObjTolid.Select_Unit().Tables[0];
            cmbKargahSh.ValueMember = "C_unit";
            cmbKargahSh.DisplayMember = "N_unit";
            cmbKargahElat.ValueMember = "C_unit";
            cmbKargahElat.DisplayMember = "N_unit";

            grdShenase.DataSource = ObjTolid.Select_ZayeatShenase().Tables[0];
            grdElat.DataSource = ObjTolid.Select_ZayeatElat().Tables[0];
        }

        private void btnAddSh_Click(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            ObjTolid.strZayeatN_shenase = txtShenase.Text;
            ObjTolid.strUnit = cmbKargahSh.SelectedValue.ToString();
            MessageBox.Show(ObjTolid.INS_ZayeatShenase());
            grdShenase.DataSource = ObjTolid.Select_ZayeatShenase().Tables[0];
        }

        private void btnAddElat_Click(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            ObjTolid.strZayeatN_Elat = txtElat.Text;
            ObjTolid.strUnit = cmbKargahElat.SelectedValue.ToString();
            MessageBox.Show(ObjTolid.INS_ZayeatElat());
            grdElat.DataSource = ObjTolid.Select_ZayeatElat().Tables[0];
        }

        private void grdShenase_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            strIdZayeatShenase = grdShenase.Rows[e.RowIndex].Cells["ID_shenase"].Value.ToString();
            cmbKargahSh.Text = grdShenase.Rows[e.RowIndex].Cells["Nameunit"].Value.ToString();
            txtShenase.Text = grdShenase.Rows[e.RowIndex].Cells["N_shenase"].Value.ToString();
        }

        private void btnUpdateSh_Click(object sender, EventArgs e)
        {
            ClsTolid objTolid = new ClsTolid();
            objTolid.strIdZayeatShenase = strIdZayeatShenase;
            objTolid.strZayeatN_shenase = txtShenase.Text;
            objTolid.strUnit = cmbKargahSh.SelectedValue.ToString();
            MessageBox.Show(objTolid.Update_ZayeatShenase());

            objTolid.strIdZayeatShenase = "";
            grdShenase.DataSource = objTolid.Select_ZayeatShenase().Tables[0];
        }

        private void btnDelSh_Click(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            ObjTolid.strIdZayeatShenase = strIdZayeatShenase;
            MessageBox.Show(ObjTolid.DelZayeatShenase());

            ObjTolid.strIdZayeatShenase = "";
            grdShenase.DataSource = ObjTolid.Select_ZayeatShenase().Tables[0];
        }

        private void btnUpdateElat_Click(object sender, EventArgs e)
        {
            ClsTolid objTolid = new ClsTolid();
            objTolid.strIdZayeatElat = strIdZayeatElat;
            objTolid.strZayeatN_Elat = txtElat.Text;
            objTolid.strUnit = cmbKargahElat.SelectedValue.ToString();
            MessageBox.Show(objTolid.Update_ZayeatElat());

            objTolid.strIdZayeatElat = "";
            grdElat.DataSource = objTolid.Select_ZayeatElat().Tables[0];
        }

        private void btnDelElat_Click(object sender, EventArgs e)
        {
            ClsTolid ObjTolid = new ClsTolid();
            ObjTolid.strIdZayeatElat = strIdZayeatElat;
            MessageBox.Show(ObjTolid.DelZayeatElat());

            ObjTolid.strIdZayeatElat = "";
            grdElat.DataSource = ObjTolid.Select_ZayeatElat().Tables[0];
        }

        private void btnExcelsh_Click(object sender, EventArgs e)
        {
            string fileName = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = string.Format("{0} (*{1})|*{1}", "Excel Files", ".xls")
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
            }
                (new ExportToExcelML(this.grdShenase)).RunExport(fileName);
            if (RadMessageBox.Show("اطلاعات به درستی خارج شد.آیا می خواهید فایل باز شود؟", "Export to Excel", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Process.Start(fileName);
                }
                catch
                {
                }
            }
        }

        private void btnExcelElat_Click(object sender, EventArgs e)
        {
            string fileName = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = string.Format("{0} (*{1})|*{1}", "Excel Files", ".xls")
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
            }
                (new ExportToExcelML(this.grdElat)).RunExport(fileName);
            if (RadMessageBox.Show("اطلاعات به درستی خارج شد.آیا می خواهید فایل باز شود؟", "Export to Excel", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Process.Start(fileName);
                }
                catch
                {
                }
            }
        }

        private void grdElat_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            strIdZayeatElat = grdElat.Rows[e.RowIndex].Cells["ID_ellat"].Value.ToString();
            cmbKargahElat.Text = grdElat.Rows[e.RowIndex].Cells["NameUnit"].Value.ToString();
            txtElat.Text = grdElat.Rows[e.RowIndex].Cells["desc_ellat"].Value.ToString();
        }
    }
}

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
    public partial class FrmTolid_KontorTestList : Telerik.WinControls.UI.RadForm
    {
        public FrmTolid_KontorTestList()
        {
            InitializeComponent();
        }

        private void FrmTolid_KontorTestList_Load(object sender, EventArgs e)
        {
            ClsTolid obj = new ClsTolid();
            grd.DataSource = obj.Select_KontorTestH().Tables[0];
        }

        private void grd_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "btnEdit")
                {
                    DataTable dt = new DataTable();
                    ClsTolid obj = new ClsTolid();
                    FrmTolid_KontorTestH frm = new FrmTolid_KontorTestH();
                    frm.txtIdTest.Text = grd.CurrentRow.Cells["IdTest"].Value.ToString();
                    frm.cmbSeriMechanism.Text = grd.CurrentRow.Cells["SeriMechanism"].Value.ToString();
                    frm.cmbKontorDry.Text = grd.CurrentRow.Cells["KontorDry"].Value.ToString();
                    frm.dtpDateTest.Text = grd.CurrentRow.Cells["DateTest"].Value.ToString();
                    frm.cmbKontorSize.Text = grd.CurrentRow.Cells["KontorSize"].Value.ToString();
                    frm.cmbRadeDeghat.Text = grd.CurrentRow.Cells["RadeDeghat"].Value.ToString();
                    frm.strIdDastgah = grd.CurrentRow.Cells["N_machine"].Value.ToString();
                    frm.txtTimeStart.Text = grd.CurrentRow.Cells["TimeStart"].Value.ToString();
                    frm.txtTimeEnd.Text = grd.CurrentRow.Cells["TimeEnd"].Value.ToString();
                    frm.strIdPersonel = grd.CurrentRow.Cells["NamePersonel"].Value.ToString();
                    //frm.txtIdEmp.Text = grd.CurrentRow.Cells["NamePersonel"].Value.ToString();
                    frm.txtSazandeDarposh.Text = grd.CurrentRow.Cells["SazandeDarposh"].Value.ToString();
                    frm.cmbSazandeMekanizm.Text = grd.CurrentRow.Cells["SazandeMekanizm"].Value.ToString();
                    //frm.txtPressHidrostatic.Text = grd.CurrentRow.Cells["PressHidrostatic"].Value.ToString();
                    //frm.txtTimeHidrostatic.Text = grd.CurrentRow.Cells["TimeHidrostatic"].Value.ToString();
                    obj.IdTest = grd.CurrentRow.Cells["IdTest"].Value.ToString();
                    frm.grd.DataSource = obj.Select_KontorTestD().Tables[0];
                    dt = obj.Select_KontorTestQHeader().Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        frm.txtQ3_1ValueWater.Text = dt.Rows[0]["Q3_1ValueWater"].ToString();
                        frm.txtQ3_1TimeWater.Text = dt.Rows[0]["Q3_1TimeWater"].ToString();
                        frm.txtQ3_2ValueWater.Text = dt.Rows[0]["Q3_2ValueWater"].ToString();
                        frm.txtQ3_2TimeWater.Text = dt.Rows[0]["Q3_2TimeWater"].ToString();
                        frm.txtQ3_3ValueWater.Text = dt.Rows[0]["Q3_3ValueWater"].ToString();
                        frm.txtQ3_3TimeWater.Text = dt.Rows[0]["Q3_3TimeWater"].ToString();
                        frm.txtQ3_4ValueWater.Text = dt.Rows[0]["Q3_4ValueWater"].ToString();
                        frm.txtQ3_4TimeWater.Text = dt.Rows[0]["Q3_4TimeWater"].ToString();
                        frm.txtQ2ValueWater.Text = dt.Rows[0]["Q2ValueWater"].ToString();
                        frm.txtQ2TimeWater.Text = dt.Rows[0]["Q2TimeWater"].ToString();
                        frm.txtQ1ValueWater.Text = dt.Rows[0]["Q1ValueWater"].ToString();
                        frm.txtQ1TimeWater.Text = dt.Rows[0]["Q1TimeWater"].ToString();
                    }
                    frm.ShowDialog();
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            string fileName = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = string.Format("{0} (*{1})|*{1}", "Excel Files", ".xlsx")
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
            }
                (new ExportToExcelML(this.grd)).RunExport(fileName);
            if (RadMessageBox.Show("فایل به درستی ایجاد شد.آیا می خواهید فایل باز شود؟", "Export to Excel", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
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
    }
}

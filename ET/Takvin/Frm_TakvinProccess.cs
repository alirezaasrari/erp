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
    public partial class Frm_TakvinProccess : Telerik.WinControls.UI.RadForm
    {
        public Frm_TakvinProccess()
        {
            InitializeComponent();
        }

        private void Frm_ManabeCoding_Load(object sender, EventArgs e)
        {
            ClsTakvin obj = new ClsTakvin();
            grd.DataSource = obj.SelectProccessList().Tables[0];
        }       
        private void grd_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "btnDelete")
                {
                    ClsTakvin obj = new ClsTakvin();
                    obj.strProcID_process = grd.CurrentRow.Cells["ID_process"].Value.ToString();

                    MessageBox.Show(obj.DelProccess());
                    ShowData();
                }
                if (e.Column.Name == "btnEdit")
                {
                    ClsTakvin obj = new ClsTakvin();
                    obj.strProcID_process = grd.CurrentRow.Cells["ID_process"].Value.ToString();
                    obj.strProcN_process = grd.CurrentRow.Cells["N_process"].Value.ToString();
                    
                    MessageBox.Show(obj.UpdProccess());
                    ShowData();
                }
            }
            catch
            {
                MessageBox.Show("خطا در اجراي عمليات");
            }
        }
        private void grd_UserAddingRow(object sender, Telerik.WinControls.UI.GridViewRowCancelEventArgs e)
        {
            try
            {
                ClsTakvin obj = new ClsTakvin();
                obj.strProcID_process = grd.CurrentRow.Cells["ID_process"].Value.ToString();
                obj.strProcN_process = grd.CurrentRow.Cells["N_process"].Value.ToString();
                
                MessageBox.Show(obj.InsProccess());
                grd.Rows.AddNew();
                ShowData();
            }
            catch
            {
                MessageBox.Show("خطا در اجراي عمليات");
            }
        }
        public void ShowData()
        {
            using (new PleaseWait(this.Location))
            {
                ClsTakvin obj = new ClsTakvin();
                grd.DataSource = obj.SelectProccessList().Tables[0];
            }
        }
    }
}

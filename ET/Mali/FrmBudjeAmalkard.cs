using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.SqlClient;

namespace ET
{
    public partial class FrmBudjeAmalkard : Telerik.WinControls.UI.RadForm
    {
        public FrmBudjeAmalkard()
        {
            InitializeComponent();
        }

        public DataSet DS = new DataSet();
        
        ClsMali objMali = new ClsMali();
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DS = objMali.SelectBudje(txtYear.Text.Trim());
            GrdBudje.DataSource = null;
            GrdBudje.DataSource = DS.Tables[0];
        }

        private void btnAddBudje_Click(object sender, EventArgs e)
        {
            try
            {
                

                if (GrdBudje.CurrentRow.Index + 1 == GrdBudje.Rows.Count)
                {
                    GrdBudje.CurrentRow = GrdBudje.Rows[GrdBudje.CurrentRow.Index - 1];
                    GrdBudje.CurrentRow = GrdBudje.Rows[GrdBudje.CurrentRow.Index + 1];
                }
                else
                {
                    GrdBudje.CurrentRow = GrdBudje.Rows[GrdBudje.CurrentRow.Index + 1];
                    GrdBudje.CurrentRow = GrdBudje.Rows[GrdBudje.CurrentRow.Index - 1];
                }

                objMali.updateGrid(DS);
                DS.AcceptChanges();

                RadMessageBox.Show("عملیات با موفقیت انجام شد");
                GrdBudje.DataSource = null;
                GrdBudje.DataSource = DS.Tables[0];
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message + "خطا در اجرای عملیات");
            }
        }
    }
}

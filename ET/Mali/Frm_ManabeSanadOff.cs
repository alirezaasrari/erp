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
    public partial class Frm_ManabeSanadOff : Telerik.WinControls.UI.RadForm
    {
        public Frm_ManabeSanadOff()
        {
            InitializeComponent();
        }

        private void Frm_ManabeCoding_Load(object sender, EventArgs e)
        {
            ClsMali obj = new ClsMali();
            grd.DataSource = obj.SelectMali_ManabeSanadOff().Tables[0];
        }       
        private void grd_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "IsOff")
                {                    
                    ClsMali obj = new ClsMali();
                    obj.strIdSanad = grd.CurrentRow.Cells["IdSanad"].Value.ToString();
                    if (grd.CurrentRow.Cells["IsOff"].Value.ToString() == "1")
                        MessageBox.Show(obj.Delete_ManabeSanadOff());
                    else
                        MessageBox.Show(obj.Insert_ManabeSanadOff());

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
                ClsMali obj = new ClsMali();
                obj.strIdCode = grd.CurrentRow.Cells["IdCode"].Value.ToString();
                obj.strNameGroup = grd.CurrentRow.Cells["NameGroup"].Value.ToString();
                obj.strKol = grd.CurrentRow.Cells["Kol"].Value.ToString();
                obj.strMoeen = grd.CurrentRow.Cells["Moeen"].Value.ToString();
                if (grd.CurrentRow.Cells["Tafsili"].Value != null)
                    obj.strTafsili = grd.CurrentRow.Cells["Tafsili"].Value.ToString();
                else
                    obj.strTafsili = "";
                if (grd.CurrentRow.Cells["NameTafsili2"].Value != null)
                    obj.strTafsili2 = grd.CurrentRow.Cells["NameTafsili2"].Value.ToString();
                else
                    obj.strTafsili2 = "";
                if (grd.CurrentRow.Cells["TypeManabe"].Value.ToString() == "True")
                    obj.strTypeManabe = "1";
                else
                    obj.strTypeManabe = "0";
                MessageBox.Show(obj.Insert_ManabeCoding());
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
                ClsMali obj = new ClsMali();
                grd.DataSource = obj.SelectMali_ManabeSanadOff().Tables[0];
            }
        }
    }
}

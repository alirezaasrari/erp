using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Globalization;

namespace ET
{
    public partial class FrmChengPass : Telerik.WinControls.UI.RadForm
    {
        public FrmChengPass()
        {
            InitializeComponent();
        }
        ClsMain cm = new ClsMain();
        private void btnEditPass_Click(object sender, EventArgs e)
        {
            if (txtPassOld.Text != null & txtPassOld.Text != "")
            {

                cm.PassNew = txtPassNewS.Text;
                MessageBox.Show(cm.UpdatePass());
                this.Close();
            }
        }

        private void txtPassOld_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-us"));
        }

        private void txtPassOld_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.ActiveControl = txtPassNew;
            }
        }

        private void txtPassNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.ActiveControl = txtPassNewS;
            }
        }

        private void txtPassNewS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.ActiveControl = txtPassNew;
            }

        }

        private void txtPassOld_Leave(object sender, EventArgs e)
        {
                 if (txtPassOld.Text == cm.PassChange().Tables[0].Rows[0][0].ToString().Trim() ) 
            {
                this.ActiveControl = txtPassNew;
            }
                 else
                 {
                     MessageBox.Show("پسورد قبلی درست نیست");
                     this.ActiveControl = txtPassOld;
                 } 
        }

        private void txtPassNew_Leave(object sender, EventArgs e)
        {
            if (txtPassNew.Text != null & txtPassNew.Text != "")
            {
                this.ActiveControl = txtPassNewS;
            }
            else
            {
                MessageBox.Show("پسورد جدید نمی تواند خالی باشد");
                this.ActiveControl = txtPassNew;
            }

        }

        private void txtPassNewS_Leave(object sender, EventArgs e)
        {
            if (txtPassNew.Text == txtPassNewS.Text )
                {
                    this.ActiveControl = btnEditPass;
                }
            else
            {
                MessageBox.Show("پسوردهای جدید برابر نیست");                
                txtPassNew.Text = null;
                txtPassNewS.Text = null;                
            }

        }
    }
}

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
    public partial class FrmTolid_KontorTestHAddKontor : Telerik.WinControls.UI.RadForm
    {
        public string IdTest;
        public FrmTolid_KontorTestHAddKontor()
        {
            InitializeComponent();
        }

        private void txtKontor_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                try
                {
                    ClsTolid obj = new ClsTolid();
                    obj.IdTest = IdTest;
                    obj.IdKontor = txtKontor.Text;
                    obj.INS_KontorTestD();
                    lst.Items.Add(txtKontor.Text);
                    txtKontor.Text = "";
                    if (chkRadif.Checked == true)
                    {
                        obj.IdRadif = txtRadif.Text;
                        obj.Update_KontorTestDRadif();
                    }
                }
                catch (Exception ee)
                {

                }
            }
        }

        private void chkRadif_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRadif.Checked == true)
                txtRadif.Enabled = true;
            else
                txtRadif.Enabled = false;
        }
    }
}

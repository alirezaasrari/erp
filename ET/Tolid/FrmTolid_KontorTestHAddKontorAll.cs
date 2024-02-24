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
    public partial class FrmTolid_KontorTestHAddKontorAll : Telerik.WinControls.UI.RadForm
    {
        public string IdTest;
        public FrmTolid_KontorTestHAddKontorAll()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ClsTolid obj = new ClsTolid();
                obj.IdTest = IdTest;
                obj.IdKontor = txtKontor.Text;
                obj.CountKontor = txtCount.Text;
                obj.INS_KontorTestDAll();
                this.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("شماره کنتور باید عدد باشد");
            }
        }
    }
}

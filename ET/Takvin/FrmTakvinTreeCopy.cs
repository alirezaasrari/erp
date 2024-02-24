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
    public partial class FrmTakvinTreeCopy : Telerik.WinControls.UI.RadForm
    {
        public FrmTakvinTreeCopy()
        {
            InitializeComponent();
        }
        ClsTakvin objTakvin = new ClsTakvin();

        private void FrmTakvinTreeCopy_Load(object sender, EventArgs e)
        {

        }

    }
}

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
    public partial class FrmTakvinBomSearch : Telerik.WinControls.UI.RadForm
    {
        public FrmTakvinBomSearch()
        {
            InitializeComponent();
        }
        ClsTakvin objTakvin = new ClsTakvin();
        public string strISVaziatEjraee = "";
        private void GrdBOM_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {

                ClsTakvin.GetID_Bom = GrdBOM.Rows[e.RowIndex].Cells["ID_Bom"].Value.ToString();
                ClsTakvin.GetNameBom = GrdBOM.Rows[e.RowIndex].Cells["NameBom"].Value.ToString();
                ClsTakvin.GetVahedsanjeshBom = GrdBOM.Rows[e.RowIndex].Cells["FK_Vahedsanjesh"].Value.ToString();
                ClsTakvin.GetVaziatEjraee = Convert.ToBoolean(GrdBOM.Rows[e.RowIndex].Cells["VaziatEjraee"].Value);
                
                this.Close();
            }
            catch(Exception exp)
            {
                RadMessageBox.Show(exp.Message);
                return;
            }
        }

        private void FrmTakvinBomSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close(); 
        }

        private void FrmTakvinBomSearch_Load(object sender, EventArgs e)
        {
            GrdBOM.DataSource = objTakvin.SelectBom(strISVaziatEjraee).Tables[0];
            ClsTakvin.GetID_Bom = "";
            ClsTakvin.GetNameBom = "";
            ClsTakvin.GetVahedsanjeshBom = "";
            ClsTakvin.GetVaziatEjraee = false;
            
        }
    }
}

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
    public partial class FrmPLN_BlockKala : Telerik.WinControls.UI.RadForm
    {
        public FrmPLN_BlockKala()
        {
            InitializeComponent();
        }

        ClsPlanning objPlanning = new ClsPlanning();
        ClsMain objMain = new ClsMain();
        DataSet ds = new DataSet();
        public int intBlock = 0;
        private void FrmPLN_BlockKala_Load(object sender, EventArgs e)
        {
            grdKala.DataSource = objPlanning.Select_BlockKala().Tables[0];

            //سطح دسترسی کنترلها       

            DataTable DtControlAccess = new DataTable();
            DataRow[] dr = ClsMain.DtAccessUser.Select("n_form='" + this.Name + "'");
            if (dr.Length > 0) DtControlAccess = dr.CopyToDataTable();
            if (DtControlAccess.Rows.Count > 0)
            {
                Control ctn;
                for (int i = 0; i < DtControlAccess.Rows.Count; i++)
                {
                    string strControl = DtControlAccess.Rows[i]["n_control"].ToString();
                    ctn = Controls[strControl];

                    if (ctn != null)
                    {
                        bool rv, re;
                        if (DtControlAccess.Rows[i]["id_user"].ToString() == ClsMain.IDUser)
                        {
                            rv = Convert.ToBoolean(DtControlAccess.Rows[i]["isActive"].ToString());
                            re = Convert.ToBoolean(DtControlAccess.Rows[i]["isshow"].ToString());
                        }
                        else
                        {
                            rv = false;
                            re = false;
                        }
                        ctn.Enabled = re;
                        ctn.Visible = rv;
                    }
                }
            }
            ////--------------------------
        }

        private void txtC_Kala_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmKala frm = new FrmKala();
                frm.ShowDialog();
                txtC_Kala.Text = ClsBuy.C_kala;
                lblN_Kala.Text = ClsBuy.N_kala;
                lblC_Anbar.Text = ClsBuy.C_Anbar;
                lblN_Anbar.Text = ClsBuy.N_Anbar;
            }
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            objPlanning.strCkala = txtC_Kala.Text;
            objPlanning.strCabnar = lblC_Anbar.Text;
            objPlanning.strUserBlock = ClsMain.StrUsername;
            objPlanning.strComment = txtBlock.Text;

            MessageBox.Show(objPlanning.Insert_BlockKala());
            grdKala.DataSource = objPlanning.Select_BlockKala().Tables[0];
        }

        private void grdKala_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (intBlock == 1)
            {
                if (MessageBox.Show("آیا از حذف سطر اطمینان دارید؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    objPlanning.strCkala = grdKala.Rows[e.RowIndex].Cells["C_Kala"].Value.ToString();
                    objPlanning.strCabnar = grdKala.Rows[e.RowIndex].Cells["C_Anbar"].Value.ToString();

                    MessageBox.Show(objPlanning.Delete_BlockKala());
                    grdKala.DataSource = objPlanning.Select_BlockKala().Tables[0];
                }
            }
        }
    }
}

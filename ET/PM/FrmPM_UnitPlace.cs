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
    public partial class FrmPM_UnitPlace : Telerik.WinControls.UI.RadForm
    {
        public FrmPM_UnitPlace()
        {
            InitializeComponent();
        }

        ClsPM cp = new ClsPM();

        private void FrmPM_UnitPlace_Load(object sender, EventArgs e)
        {
            atxb_Unit.AutoCompleteDataSource = cp.select_MarkazHazine().Tables[0];
            atxb_Unit.AutoCompleteDisplayMember = "onvan";
            atxb_Unit.AutoCompleteValueMember = "markaz_hazine";
            newUP();
        }

        private void newUP() 
        {
            txb_codUP.Text = cp.autoID_UnitPlased().Tables[0].Rows[0][0].ToString();
            btn_new_UP.Enabled = false;
            btn_edit_UP.Enabled = false;
            btn_del_UP.Enabled = false;
            btn_add_UP.Enabled = true;
            txb_codUP.Enabled = true;
            grd_UP.DataSource = cp.selectUnitPlased().Tables[0];
            cp.Id_UnitPlased = null;
            cp.N_UnitPlased = null;
            cp.IdUnit = null;
            txb_N_UP.Text = null;
            atxb_Unit.Clear();
        }

        private void ins_update_UnitPlase() 
        {
            cp.Id_UnitPlased = txb_codUP.Text ;
            cp.N_UnitPlased = txb_N_UP.Text;
        }

        private void btn_add_UP_Click(object sender, EventArgs e)
        {
            ins_update_UnitPlase();
            MessageBox.Show(cp.InsUnitPlased());
            newUP();
        }

        private void btn_edit_UP_Click(object sender, EventArgs e)
        {
            ins_update_UnitPlase();
            if (MessageBox.Show("آیا مطمئن هستید ویرایش شود؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show(cp.updateUnitPlace());
            }
            newUP();
        }

        private void btn_del_UP_Click(object sender, EventArgs e)
        { 
            if (MessageBox.Show("آیا مطمئن هستید حذف شود؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cp.flag_del_UP = true;
                int rc = cp.selectMachine().Tables[0].Rows.Count;                
                if (rc == 0)
                {
                    MessageBox.Show(cp.DelUnitPlace());
                }
                if (rc > 0)
                {
                    MessageBox.Show("این مکان در دستگاهی ثبت شده است");
                }
            }
            newUP();
        }

        private void btn_new_UP_Click(object sender, EventArgs e)
        {
            newUP();
        }

        private void grd_UP_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try 
            {
                txb_codUP.Enabled = false;
                btn_new_UP.Enabled = true;
                btn_edit_UP.Enabled = true;
                btn_del_UP.Enabled = true;
                btn_add_UP.Enabled = false;
                cp.Id_UnitPlased = txb_codUP.Text = grd_UP.CurrentRow.Cells["ID_UP"].Value.ToString();
                txb_N_UP.Text = grd_UP.CurrentRow.Cells["Unit_Placed"].Value.ToString();
                cp.IdUnit = grd_UP.CurrentRow.Cells["markaz_hazine"].Value.ToString();
                atxb_Unit.Text = grd_UP.CurrentRow.Cells["onvan"].Value.ToString() + ";";
            }
            catch
            {
                MessageBox.Show("روی خطوط گرید کلید نمایید");
            }
        }

        private void atxb_Unit_TextChanged(object sender, EventArgs e)
        {
            if (atxb_Unit.Items.Count == 1)
            {
                lbl_Unit.Text = cp.IdUnit = atxb_Unit.Items[0].Value.ToString();
            }
        }
    }
}
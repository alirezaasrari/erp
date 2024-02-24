using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace ET
{
    public partial class FrmPM_SparePart : Telerik.WinControls.UI.RadForm
    {
        public FrmPM_SparePart()
        {
            InitializeComponent();
        }
        ClsPM cp = new ClsPM();
        string str,str1;//برای نمایش پیام حذف
        
        DialogResult dir;
        private void FrmPM_SparePart_Load(object sender, EventArgs e)
        {
            grid_data();
            drpVahedkala.DataSource = cp.selectVahedKala().Tables[0];
            drpVahedkala.ValueMember = "IdVahed";
            drpVahedkala.DisplayMember = "NameVahed";
            drpVahedkala.SelectedIndex = -1;
            //dt = cp.selectKala().Tables[0];
            //atxb_N_spart.AutoCompleteDataSource = dt;
            //atxb_N_spart.AutoCompleteDisplayMember = "N_Kala";
            //atxb_N_spart.AutoCompleteValueMember = "C_Kala";
            //ColumnGroupsViewDefinition view = new ColumnGroupsViewDefinition();
            //view.ColumnGroups.Add(new GridViewColumnGroup("کالا"));
            //view.ColumnGroups.Add(new GridViewColumnGroup("مشخصات"));
            //view.ColumnGroups[0].Rows.Add(new GridViewColumnGroupRow());
            //view.ColumnGroups[0].Rows[0].Columns.Add(this.grd_SparePart.Columns["N_Kala"]);            
            //view.ColumnGroups[0].Rows.Add(new GridViewColumnGroupRow());
            //view.ColumnGroups[0].Rows[1].Columns.Add(this.grd_SparePart.Columns["N_anbar"]);
            //view.ColumnGroups[0].Rows[1].Columns.Add(this.grd_SparePart.Columns["some_much"]);
            //view.ColumnGroups[0].Rows.Add(new GridViewColumnGroupRow());
            //view.ColumnGroups[0].Rows[2].Columns.Add(this.grd_SparePart.Columns["n_zanbar"]);
            //view.ColumnGroups[0].Rows[2].Columns.Add(this.grd_SparePart.Columns["N_Vahed"]);        
            //view.ColumnGroups[1].Rows.Add(new GridViewColumnGroupRow());            
            //view.ColumnGroups[1].Rows[0].Columns.Add(this.grd_SparePart.Columns["specs"]);
            //view.ColumnGroups[1].Rows.Add(new GridViewColumnGroupRow());  
            //view.ColumnGroups[1].Rows[1].Columns.Add(this.grd_SparePart.Columns["usecas"]);
            //view.ColumnGroups[1].Rows.Add(new GridViewColumnGroupRow());  
            //view.ColumnGroups[1].Rows[2].Columns.Add(this.grd_SparePart.Columns["preamble"]);
            //grd_SparePart.ViewDefinition = view;
        }
        private void grid_data()
        {
            DataTable dt = cp.selectSparPart().Tables[0];

            grd_SparePart.DataSource = dt;
            btn_addSpare.Enabled = true;
            btn_editSpare.Enabled = false;
            btn_delSpare.Enabled = false;
            btn_newSpare.Enabled = false;

            drpSituationSP.DataSource = dt;
            drpSituationSP.DisplayMember = "Nkala";
            drpSituationSP.ValueMember = "ID_spare_part";
            drpSituationSP.SelectedIndex = -1;
        }
        private void ins_update_SparePart()//خواندن از texbox 
        {      
            cp.FkcKala = txtCkala.Text;
            cp.Specs = txtSpecs.Text;
            cp.Usecas = txtUsecas.Text;
            cp.PreambleSP = txtPreambleSP.Text;
            if (drpSituationSP.SelectedValue == null) cp.SituationSP = "";
            else cp.SituationSP = drpSituationSP.SelectedValue.ToString();            
            cp.Nkala = txtNKala.Text;
            
            cp.FKIdVahed = drpVahedkala.SelectedValue.ToString();
            
        }
        private void btn_addSpare_Click(object sender, EventArgs e)
        {        
                    ins_update_SparePart();
                    cp.msg(cp.InsSparpart(), 1);
                    nulling();
                    grid_data();
        }
        private void nulling()
        {
            cp.FkcKala = null;
            txtCkala.Text = null;
            cp.Specs = null;
            txtSpecs.Text = null;
            cp.Usecas = null; 
            txtUsecas.Text = null;
            cp.PreambleSP = null;
            txtPreambleSP.Text = null;
            cp.SituationSP = null;
            drpSituationSP.SelectedIndex = -1;
            cp.Nkala = null;
            txtNKala.Text = null;
            cp.FKIdVahed = null;
            drpVahedkala.SelectedIndex = -1;
        }
        private void btn_delSpare_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            cp.flag_del_sparePart = true;
            ds = cp.selectsparePar_sectionANDsparePart();
            int rc = ds.Tables[0].Rows.Count;
            if (rc==0)
            {
                str1 = "آيا مطمئن هستيد حذف شود؟";
            }
            if (rc > 0)
            {
                for (int i = 0; i < rc; i++)
                {
                    str += ds.Tables[0].Rows[i]["N_section"].ToString() + "\n";
                }
                str1 = ":اين کالا در قسمت\n " + str + " \n ثبت شده است"+"\n" + "آیا حذف شود";
            }
            if (RadMessageBox.Show(str1, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            { 
                cp.msg(cp.DeleteSS(), 1);
                cp.msg(cp.DelSparePart(), 1);
                str = null;
                str1 = null;
                nulling();
                grid_data();
            }
        }
        private void btn_newSpare_Click(object sender, EventArgs e)
        {
            nulling();
            grid_data();
        }
      
        private void grd_SparePart_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (grd_SparePart.CurrentRow.Index > -1)
            {
                drpSituationSP.SelectedIndex = -1;
                cp.ID_SparePart = grd_SparePart.CurrentRow.Cells["ID_spare_part"].Value.ToString();
                txtCkala.Text = grd_SparePart.CurrentRow.Cells["FK_C_Kala"].Value.ToString();
                txtSpecs.Text = grd_SparePart.CurrentRow.Cells["specs"].Value.ToString();
                txtUsecas.Text = grd_SparePart.CurrentRow.Cells["usecas"].Value.ToString();
                txtPreambleSP.Text = grd_SparePart.CurrentRow.Cells["preamble"].Value.ToString();
                txtNKala.Text = grd_SparePart.CurrentRow.Cells["Nkala"].Value.ToString();
                drpVahedkala.SelectedValue = grd_SparePart.CurrentRow.Cells["FKIdVahed"].Value;
                drpSituationSP.SelectedValue = grd_SparePart.CurrentRow.Cells["Nsituation"].Value;
                    
                    btn_addSpare.Enabled = false;
                    btn_editSpare.Enabled = true;
                    btn_delSpare.Enabled = true;
                    btn_newSpare.Enabled = true;               
            }                            
        }
        private void btn_editSpare_Click(object sender, EventArgs e)
        {
            ins_update_SparePart();
            if (RadMessageBox.Show("آيا مطمئن هستيد ويرايش شود؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
          
               cp.msg(cp.updateSparePart(),1);
            }
            nulling();
            grid_data();
        }

        private void txtCKala_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmKala frm = new FrmKala();
                frm.ShowDialog();
                txtCkala.Text = ClsBuy.C_kala;
                //txtCkala.Text = ClsBuy.N_kala;
            }
        }

    }
}
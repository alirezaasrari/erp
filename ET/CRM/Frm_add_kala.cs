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
    public partial class Frm_add_kala : Telerik.WinControls.UI.RadForm
    {
        public Frm_add_kala()
        {
            InitializeComponent();
        }

        Cls_Customer ccr = new Cls_Customer();

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
            Cls_Customer.ID_h = null;
        }
       
        private void add_update_kala() 
        {
            //cc.FK_ID_h = lbl_ID_hE.Text;
            ccr.FK_ID_g = drp_kind.SelectedValue.ToString();
            ccr.namekala = txb_namekala.Text;
            ccr.number = txb_numberkala.Value.ToString();
            ccr.numbersefaresh = txb_sefaresh.Text;
            ccr.description = txb_description.Text;
        }

        private void Frm_add_kala_Load(object sender, EventArgs e)
        {
            radGridView1.DataSource = ccr.selectdkala().Tables[0];            
            drp_part.DataSource = ccr.selectpart().Tables[0];
            drp_part.ValueMember = "ID_part";
            drp_part.DisplayMember = "part";
            btn_show(1);
             drp_part.Text = null;
            drp_kind.Text = null;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            
            
            add_update_kala();
            RadMessageBox.Show(ccr.insdKala());            
            radGridView1.DataSource = ccr.selectdkala().Tables[0];
            disDkala();
            
        }
  
        private void disDkala()
        {
            drp_part.Text = null;
            drp_kind.Text = null;
            txb_namekala.Text = null;
            txb_numberkala.Value = 1;
            txb_sefaresh.Text = null;
            txb_description.Text = null;
            ccr.ID_D_kala = null; 
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            add_update_kala();
            //cc.ID_D_kala = iddkala;
            RadMessageBox.Show(ccr.updatedkala());
            radGridView1.DataSource = ccr.selectdkala().Tables[0];
            disDkala();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            //CCR.ID_D_kala = iddkala;
            RadMessageBox.Show(ccr.DelKala());
            radGridView1.DataSource = ccr.selectdkala().Tables[0];
            disDkala();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
             radGridView1.DataSource = ccr.selectdkala().Tables[0];
            disDkala();
        }

        private void radGridView1_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            ccr.Partselected = radGridView1.CurrentRow.Cells["ID_part"].Value.ToString();
            drpkind_source();
            drp_part.Text = radGridView1.CurrentRow.Cells["part"].Value.ToString();
            drp_kind.Text = radGridView1.CurrentRow.Cells["kind"].Value.ToString();
            
            drp_kind.SelectedValue = radGridView1.CurrentRow.Cells["ID_dGroupkala"].Value.ToString();
            txb_namekala.Text = radGridView1.CurrentRow.Cells["name"].Value.ToString();
            txb_numberkala.Value = Convert.ToInt32(radGridView1.CurrentRow.Cells["number"].Value.ToString());
            txb_sefaresh.Text = radGridView1.CurrentRow.Cells["numbersefaresh"].Value.ToString();
            txb_description.Text = radGridView1.CurrentRow.Cells["des"].Value.ToString();
            ccr.ID_D_kala = radGridView1.CurrentRow.Cells["ID_dGroupkala"].Value.ToString();
            ccr.FK_ID_g = radGridView1.CurrentRow.Cells["FK_ID_g"].Value.ToString();
            btn_show(2);
        }

        private string btn_show(int a) 
        {
            if (a == 1)
            {
                btn_add.Enabled = true;
                btn_del.Enabled = false;
                btn_edit.Enabled = false;
                btn_new.Enabled = false;
            }
            if (a == 2)
            {
                btn_add.Enabled = false;
                btn_del.Enabled = true;
                btn_edit.Enabled = true;
                btn_new.Enabled = true;
            }
            return "";
        }
        private void drpkind_source ()
        {       
                if(ccr.Partselected != null && ccr.Partselected !="" )
                {
                drp_kind.DataSource = ccr.selectgroupkala().Tables[0];
                drp_kind.ValueMember = "ID_g";
                drp_kind.DisplayMember = "kind";
                }
        }

        private void drp_part_SelectedValueChanged(object sender, EventArgs e)
        {
            try 
            {
                ccr.Partselected = drp_part.SelectedValue.ToString();
                drpkind_source();
            }
            catch { }

        }

    }
}
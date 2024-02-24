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
    public partial class Frm_H_Exbition : Telerik.WinControls.UI.RadForm
    {
        public Frm_H_Exbition()
        {
            InitializeComponent();
        }

        int ind;
        //ClsCRM cc = new ClsCRM();
        //ClsSupplier cs = new ClsSupplier();
        Cls_Customer ccr = new Cls_Customer();

        private void Frm_H_Exbition_Load(object sender, EventArgs e)
        {
            drp_nameE.DataSource = ccr.select_N_E().Tables[0];
            drp_nameE.DisplayMember = "N_Exbition";
            drp_nameE.ValueMember = "ID_Exbition";
            drp_nameE.SelectedIndex = 3;
            //****************************************
            drp_group_suggest.DataSource = ccr.selectgroupsuggest().Tables[0] ;
            drp_group_suggest.DisplayMember = "comment" ;
            drp_group_suggest.ValueMember = "ID_s" ;
            drp_group_suggest.SelectedIndex = -1;
            //*****************************************
            atxb_source();
            grd_source();
            btn_show(1); 
        }

        private string btn_show(int a) 
        {
            if (a == 1)
            {
                btn_add.Enabled = true;
                btn_del.Enabled = false;
                btn_edit.Enabled = false;
                btn_new.Enabled = false;
                btn_add_kala.Enabled = false;
                grb1.Enabled = false;
            }
            if (a == 2)
            {
                btn_add.Enabled = false;
                btn_del.Enabled = true;
                btn_edit.Enabled = true;
                btn_new.Enabled = true;
                grb1.Enabled = true;
                btn_add_kala.Enabled = true;
            }
            return "";
        }

        private void atxb_source()
        {
            //*********************************************
            atxb_N.AutoCompleteDataSource = ccr.select_Customer().Tables[0];
            atxb_N.AutoCompleteDisplayMember = "n";
            atxb_N.AutoCompleteValueMember = "ID_real_legal";
        }
  
        private void grd_source()
        {
            //************************************
            grd.DataSource = ccr.select_H_Exbi().Tables[0];
            gridViewTemplate1.DataSource = ccr.selectdsuggest().Tables[0];
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            ccr.shomarebargeh = txb_shomare.Value.ToString();
            ccr.FK_ID_Exbition = drp_nameE.SelectedValue.ToString();            
            ccr.IDselected = ccr.inshExbition().Tables[0].Rows[0][0].ToString();
            grd_source();
            btn_show(2);           
        }

        private void atxb_N_TextChanged(object sender, EventArgs e)
        {
            if (atxb_N.Items.Count == 1)
            {
                int x = atxb_N.Items[0].Value.ToString().Length;
                string cl = atxb_N.Items[0].Value.ToString(), c, l;
                for (int i = 0; i < x; i++)
                { 
                    if (cl.Substring(i, 1) == "-") 
                    {
                        ind = i;
                    }
                }
                ccr.ID_Customer = cl.Substring(0, ind);
                ccr.ID_Legal = cl.Substring(ind + 1, x - (ind + 1));
                if (ccr.ID_Legal == "0")
                    ccr.ID_Legal = "";
            }
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            ccr.IDselected = null;
            btn_show(1);
            atxb_N.Clear();
            txb_shomare.Value = 1;
            drp_nameE.SelectedIndex = 1;
            ccr.ID_D_suggest = null;
            drp_group_suggest.SelectedIndex = -1;
            txb_des_suggest.Clear();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            ccr.shomarebargeh = txb_shomare.Value.ToString();
            ccr.FK_ID_Exbition = drp_nameE.SelectedValue.ToString();
            RadMessageBox.Show(ccr.updatehexibit());
            grd_source();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            RadMessageBox.Show(ccr.DelHexibition());
            grd_source();
            btn_show(1);
            atxb_N.Clear();
            txb_shomare.Value = 1;
        }

        //private void grd_E_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        //{
        //    if (grd_E.CurrentRow.HierarchyLevel == 0) 
        //    {
        //        cc.IDselected = grd_E.CurrentRow.Cells["ID_h"].Value.ToString();
        //        txb_shomare.Value = Convert.ToInt32(grd_E.CurrentRow.Cells["shomarebargeh"].Value.ToString());
        //        drp_nameE.SelectedValue = grd_E.CurrentRow.Cells["ID_Exbition"].Value;
        //        atxb_N.Text = grd_E.CurrentRow.Cells["L_Name"].Value.ToString() + ";";
        //        btn_show(2);
        //    }
        //    if (grd_E.CurrentRow.HierarchyLevel == 1)
        //    {
        //        if (grb1.Enabled == true)
        //        {
        //            cc.ID_D_suggest = grd_E.CurrentRow.Cells["ID_dSuggestions"].Value.ToString();
        //            drp_group_suggest.SelectedValue = grd_E.CurrentRow.Cells["FK_ID_s"].Value;
        //            txb_des_suggest.Text = grd_E.CurrentRow.Cells["description"].Value.ToString();
        //        }
        //        else 
        //        {
        //            RadMessageBox.Show("لطفا ابتدا سطر اصلی را انتخاب کنید");
        //        }
        //    }
        //}

        private void btn_addsuggest_Click(object sender, EventArgs e)
        { 
            ccr.FK_ID_s = drp_group_suggest.SelectedValue.ToString();
            ccr.desDsuggest = txb_des_suggest.Text ; 
            RadMessageBox.Show(ccr.insdsuggection());
            grd_source();
            ccr.ID_D_suggest = null;
            drp_group_suggest.SelectedIndex = -1;
            txb_des_suggest.Clear();
        }

        private void btn_editsuggest_Click(object sender, EventArgs e)
        {
            ccr.FK_ID_s = drp_group_suggest.SelectedValue.ToString();
            ccr.desDsuggest = txb_des_suggest.Text ; 
            RadMessageBox.Show(ccr.updatedsuggest());
            grd_source();
        }

        private void btn_delsuggest_Click(object sender, EventArgs e)
        {
            RadMessageBox.Show(ccr.Delsuggest());
            grd_source();
            ccr.ID_D_suggest = null;
            drp_group_suggest.SelectedIndex = -1;
            txb_des_suggest.Clear();
        }

        private void btn_newsuggest_Click(object sender, EventArgs e)
        {
            ccr.ID_D_suggest = null;
            drp_group_suggest.SelectedIndex = -1;
            txb_des_suggest.Clear();
        }

        private void btn_add_kala_Click(object sender, EventArgs e)
        {
            Cls_Customer.ID_h = ccr.IDselected;
            Frm_add_kala sa = new Frm_add_kala();
            sa.ShowDialog();
        }
        
        private void grd_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (grd.CurrentRow.HierarchyLevel == 0)
            {
                ccr.IDselected = grd.CurrentRow.Cells["ID_h"].Value.ToString();
                txb_shomare.Value = Convert.ToInt32(grd.CurrentRow.Cells["shomarebargeh"].Value.ToString());
                drp_nameE.SelectedValue = grd.CurrentRow.Cells["ID_Exbition"].Value;
                atxb_N.Text = grd.CurrentRow.Cells["n"].Value.ToString() + ";";
                btn_show(2);
            }
            if(grd.CurrentRow.HierarchyLevel == 1)
            {
                drp_group_suggest.SelectedValue = grd.CurrentRow.Cells["FK_ID_s"].Value;                
                txb_des_suggest.Text = grd.CurrentRow.Cells["description"].Value.ToString();
                ccr.ID_D_suggest = grd.CurrentRow.Cells["ID_dSuggestions"].Value.ToString();
            }
        }

        private void btn_refresh_drp_atxb_Click(object sender, EventArgs e)
        {
            atxb_source();
        }
    }
}
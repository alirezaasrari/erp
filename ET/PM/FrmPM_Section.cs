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
    public partial class FrmPM_Section : Telerik.WinControls.UI.RadForm
    {
        public FrmPM_Section()
        {
            InitializeComponent();
        }

        ClsPM cp = new ClsPM();
        public string str,str1;        
        DataTable dt_atxb = new DataTable();        

        private void FrmPM_Section_Load(object sender, EventArgs e)
        {
            grid_datasource();
            //atxb_machine.AutoCompleteDataSource = cp.selectMachine().Tables[0];
            //atxb_machine.AutoCompleteValueMember = "ID_machine";
            //atxb_machine.AutoCompleteDisplayMember = "N_machine";
            dt_atxb = cp.selectSparPart().Tables[0];
            atxb_ID_Spart.AutoCompleteDataSource = dt_atxb;
            atxb_ID_Spart.AutoCompleteValueMember = "ID_spare_part";
            atxb_ID_Spart.AutoCompleteDisplayMember = "NKala";
            gb_R_Section_SparePart.Enabled = false;
            btn_addSection.Enabled = true;
            btn_deleteSection.Enabled = false;
            btn_editSection.Enabled = false;
            btn_newSection.Enabled = false;
        }
  
        private void grid_datasource()
        {                         
            grd_section.DataSource = cp.select_Section().Tables[0];  
            gridViewTemplate1.DataSource = cp.selectSectionANDsparePart().Tables[0];            
        }

        private void btn_addSection_Click(object sender, EventArgs e)
        {
            
            cp.N_Section = txb_namesection.Text;
            cp.ID_Section = cp.Insert_Section().Tables[0].Rows[0][0].ToString();
            cp.FK_ID_Section= null;
            grid_datasource();
            gb_R_Section_SparePart.Enabled = true;
            btn_Add_SS.Enabled = true;
            btn_Del_SS.Enabled = false;
            btn_New_SS.Enabled = false;
            btn_addSection.Enabled = false;
            btn_deleteSection.Enabled = true;
            btn_editSection.Enabled = true;
            btn_newSection.Enabled = true;
            
        }
  
        private void nulling()
        {
            cp.FK_ID_Section = null;
            cp.ID_Section = null;
            cp.N_Section = null;
            txb_namesection.Text = null;
            cp.ID_Machine = null;
        }

        private void btn_editSection_Click(object sender, EventArgs e)
        {
            cp.N_Section = txb_namesection.Text;
            if (MessageBox.Show("آيا مطمئن هستيد ويرايش شود؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show(cp.updateSection());
            }
            nulling();
            grid_datasource();
            
        }

        private void btn_deleteSection_Click(object sender, EventArgs e)
        {        
            str1 = "آیا قسمت \n " + txb_namesection.Text + "\n  حذف شود؟ \n";   
            DataTable dt,dt1 =new DataTable();
            dt = cp.Select_Section_mMachin().Tables[0];
            dt1 = cp.selectSectionANDsparePart().Tables[0];
            int rc = dt.Rows.Count;
            int rc1 = dt1.Rows.Count;
            if (rc > 0)
            {
                for (int i = 0; i < rc; i++)
                {
                    str += dt.Rows[i]["N_machine"].ToString() + "\n";
                }
                str1 += ":اين قسمت در دستگاه\n " +
                                    str +
                                    " .ثبت شده است \n ";                
                str = null;
            }            
            if (rc1 > 0)
            {
                for (int i = 0; i < rc1; i++)
                {
                    str += dt1.Rows[i]["N_Kala"].ToString() + "\n";
                }
                str1 +=":اين قسمت در قطعات\n " +
                                    str +
                                    " ثبت شده است. \n";                
                str = null;
            }
            if (RadMessageBox.Show(this,str1, "", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation, MessageBoxDefaultButton.Button3,RightToLeft.Yes) == DialogResult.Yes)
            {
                if (rc > 0)
                {
                    cp.Del_machine_Sectin();
                }
                if (rc1 > 0)
                {
                    cp.Del_Sectin_sparepart();
                }    
                cp.msg(cp.DelSection(), 1);
                gb_R_Section_SparePart.Enabled = false;
                btn_addSection.Enabled = true;
                btn_deleteSection.Enabled = false;
                btn_editSection.Enabled = false;
                btn_newSection.Enabled = false;
                nulling();
                grid_datasource();
            }          
        }

        private void btn_newSection_Click(object sender, EventArgs e)
        {
            gb_R_Section_SparePart.Enabled = false;
            btn_addSection.Enabled = true;
            btn_deleteSection.Enabled = false;
            btn_editSection.Enabled = false;
            btn_newSection.Enabled = false;
            nulling();
            grid_datasource();
            
        }


        private void grd_section_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (grd_section.CurrentRow.HierarchyLevel == 0)
            {
                cp.FK_ID_Section = cp.ID_Section = grd_section.CurrentRow.Cells["ID_Section"].Value.ToString();
                txb_namesection.Text = grd_section.CurrentRow.Cells["N_section"].Value.ToString();                
                gb_R_Section_SparePart.Enabled = true;
                btn_Add_SS.Enabled = true;
                btn_Del_SS.Enabled = false;
                btn_New_SS.Enabled = false;
                btn_addSection.Enabled = false;
                btn_deleteSection.Enabled = true;
                btn_editSection.Enabled = true;
                btn_newSection.Enabled = true;
            }
            if (grd_section.CurrentRow.HierarchyLevel == 1)
            {
                btn_Add_SS.Enabled = false;
                btn_Del_SS.Enabled = true;
                btn_New_SS.Enabled = true;
                cp.ID_SS = grd_section.CurrentRow.Cells["ID_sectionANDsparepart"].Value.ToString();
                atxb_ID_Spart.Text = grd_section.CurrentRow.Cells["NKala"].Value.ToString() + ";";
                txb_some_much.Text = grd_section.CurrentRow.Cells["some_much"].Value.ToString();
            }
        }

        private void btn_Add_SS_Click(object sender, EventArgs e)
        {
            cp.some_much = txb_some_much.Text;
            int xsp = atxb_ID_Spart.Items.Count;            
                for (var i = 0; i <= xsp - 1; i++)
                {
                        cp.ID_SparePart = atxb_ID_Spart.Items[i].Value.ToString();                        
                        cp.msg(cp.Ins_SparPart_to_Section(),1);                    
                }
                grid_datasource();
                btn_Add_SS.Enabled = true;
                btn_Del_SS.Enabled = false;
                btn_New_SS.Enabled = false;
                atxb_ID_Spart.Clear();
                cp.ID_SparePart = null;
                txb_some_much.Text = "1";
                cp.some_much = null;
        }
        

        private void btn_Del_SS_Click(object sender, EventArgs e)
        {
            if (cp.ID_Section != null & cp.ID_Section != "")
            {
                if (MessageBox.Show("آيا مطمئن هستيد حذف شود؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MessageBox.Show(cp.DelSS());
                    grid_datasource();
                    btn_Add_SS.Enabled = true;
                    btn_Del_SS.Enabled = false;
                    btn_New_SS.Enabled = false;
                    atxb_ID_Spart.Clear();
                    cp.ID_SparePart = null;
                    txb_some_much.Text = "1";
                    lbl_vahed.Text = "_";
                    cp.some_much = null;
                }
                
            }
            else
            {
                cp.msg("يک قسمت را انتخاب کنيد",1);
            }
        }

        private void btn_New_SS_Click(object sender, EventArgs e)
        {
            btn_Add_SS.Enabled = true;
            btn_Del_SS.Enabled = false;
            btn_New_SS.Enabled = false;
            atxb_ID_Spart.Clear();
            cp.ID_SparePart = null;
            txb_some_much.Text = "1";
            lbl_vahed.Text = "_";
            cp.some_much = null;

        }

        private void btn_section_Click(object sender, EventArgs e)
        {
            atxb_ID_Spart.Clear();
            atxb_ID_Spart.AutoCompleteDataSource = null;
            FrmPM_SparePart sa = new FrmPM_SparePart();
            sa.ShowDialog();
            dt_atxb = cp.selectSparPart().Tables[0];
            atxb_ID_Spart.AutoCompleteDataSource = dt_atxb;
            atxb_ID_Spart.AutoCompleteValueMember = "ID_spare_part";
            atxb_ID_Spart.AutoCompleteDisplayMember = "NKala";
        }

        private void atxb_ID_Spart_TextChanged(object sender, EventArgs e)
        {
            if (atxb_ID_Spart.Items.Count == 1)
            {
                cp.ID_SparePart = atxb_ID_Spart.Items[0].Value.ToString();
                System.Data.DataRow[] dr;
                dr = dt_atxb.Select("ID_spare_part = " + cp.ID_SparePart + " ");
                lbl_vahed.Text = dr[0]["NameVahed"].ToString();
            }
        }
    }
}
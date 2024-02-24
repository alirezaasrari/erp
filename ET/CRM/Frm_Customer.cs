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
    public partial class Frm_Customer : Telerik.WinControls.UI.RadForm
    {
        public Frm_Customer()
        {
            InitializeComponent();
        }
        Cls_Customer cc = new Cls_Customer();
        DataTable dt_tafsili = new DataTable();
        private void Frm_Customer_Load(object sender, EventArgs e)
        {
            rbtn_customer.IsChecked = true;
            rbtn_real.IsChecked = true;
            grd_data();
            atxb_data();
        }
        private void grd_data()
        {
            grd_customer.DataSource = cc.select_Customer().Tables[0];
        }
        private void atxb_data() 
        {


            txt_customer_real.AutoCompleteDataSource = cc.select_Customer_legal().Tables[0];
            txt_customer_real.AutoCompleteValueMember = "ID_Customer";
            txt_customer_real.AutoCompleteDisplayMember = "N_Customer";

            txt_adjoint_work.AutoCompleteDataSource = cc.select_adjoint_work().Tables[0];
            txt_adjoint_work.AutoCompleteDisplayMember = "N_adjoint_work";
            txt_adjoint_work.AutoCompleteValueMember = "ID_adjoint_work";

            dt_tafsili = cc.selectTafsili().Tables[0];
            txt_Tafzili.AutoCompleteDataSource = dt_tafsili;
            txt_Tafzili.AutoCompleteValueMember = "cMoshtari";
            txt_Tafzili.AutoCompleteDisplayMember = "nMoshtari";

            drp_Title.DataSource = cc.select_customer_title().Tables[0];
            drp_Title.ValueMember = "ID_Title";
            drp_Title.DisplayMember = "N_Title";
            drp_Title.SelectedIndex = -1;
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            Insert_Update();
            if (rbtn_customer.IsChecked == true)
            {                
                RadMessageBox.Show(cc.Ins_Customer_real());                
            }
            if (rbtn_customer_legal.IsChecked == true)
            {
                RadMessageBox.Show(cc.Ins_Customer_legal());                
            }
            grd_data();            
        }
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            Insert_Update();
            if (rbtn_customer.IsChecked == true)
            {                
                RadMessageBox.Show(cc.UpdateSupplier());                
            }
            if (rbtn_customer_legal.IsChecked == true) 
            {
               RadMessageBox.Show(cc.Update_Customer_legal());
            }
            grd_data();
        }
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (rbtn_customer.IsChecked == true)
            {
                RadMessageBox.Show(cc.Delete_Customer());                
            }
            if (rbtn_customer_legal.IsChecked == true) 
            {
                RadMessageBox.Show(cc.Delete_Customer_legal());                
            }
            grd_data();
        }
        private void btn_ADD_Click(object sender, EventArgs e)
        {
            rbtn_customer.IsChecked = true;
      
            cc.N_Customer = null; txt_N_Customer.Text = null;
            cc.country = null; txt_country.Text=null;
            cc.State = null; txt_state.Text = null;
            cc.City = null; txt_City.Text = null;
            cc.address = null; txt_address.Text = null;
            cc.WebSite = null; txt_website.Text = null;
            cc.Email = null; txt_email.Text = null;
            cc.PObox = null; txt_PObox.Text = null;
            cc.Preamble = null; txt_Preamble.Text = null;
            cc.tell1 = null; txt_Number1.Text = null;
            cc.tell2 = null; txt_Number2.Text = null;
            cc.tell3 = null; txt_Number3.Text = null;
            cc.tell4 = null; txt_Number4.Text = null;
            cc.ID_Title = null; drp_Title.SelectedIndex = -1;
            cc.N_Legal_Customer = null; txt_N_Legal_Customer.Text = null;
            cc.tell_Legal_Customer = null; txt_tell_Legal_Custom.Text = null;
            cc.Preamble_legal = null; txt_Preamble_legal.Text = null;
            txt_adjoint_work.AutoCompleteDataSource = null;
            txt_adjoint_work.Clear();
            txt_Tafzili.AutoCompleteDataSource = null;
            txt_Tafzili.Clear();
            txt_customer_real.AutoCompleteDataSource = null;
            txt_customer_real.Clear();
            grd_data();
            atxb_data();
        }
        private void txt_adjoint_work_TextChanged(object sender, EventArgs e)
        {
            if(txt_adjoint_work.Items.Count==1)
            {
                cc.FK_ID_adjoint_work = txt_adjoint_work.Items[0].Value.ToString();
            }
        }
        private void txt_Tafzili_TextChanged(object sender, EventArgs e)
        {
            if (txt_Tafzili.Items.Count == 1)
            {
                cc.C_tafsili =lbl_codtafzili.Text = txt_Tafzili.Items[0].Value.ToString();
            }
        }
        private void Insert_Update() 
        {
            if (rbtn_customer.IsChecked == true)
            {
                cc.N_Customer = txt_N_Customer.Text;
                if (rbtn_real.IsChecked == true) cc.legal_real = "0";
                if (rbtn_legal.IsChecked == true) cc.legal_real = "1";
                cc.country = txt_country.Text;
                cc.State = txt_state.Text;
                cc.City = txt_City.Text;
                cc.address = txt_address.Text;
                cc.WebSite = txt_website.Text;
                cc.Email = txt_email.Text;
                cc.PObox = txt_PObox.Text;
                cc.Preamble = txt_Preamble.Text;
                cc.tell1 = txt_Number1.Text;
                cc.tell2 = txt_Number2.Text;
                cc.tell3 = txt_Number3.Text;
                cc.tell4 = txt_Number4.Text;
                cc.unite_access = cc.select_Username_vahed().Tables[0].Rows[0]["ID_Unit"].ToString();
            }
            if (rbtn_customer_legal.IsChecked == true)
            {
                cc.ID_Title = drp_Title.SelectedValue.ToString();
                cc.N_Legal_Customer = txt_N_Legal_Customer.Text;
                cc.tell_Legal_Customer = txt_tell_Legal_Custom.Text;
                cc.Preamble_legal = txt_Preamble_legal.Text;
            }

        }
        private void btn_adjoint_work_Click(object sender, EventArgs e)
        {
            txt_adjoint_work.Clear();
            txt_adjoint_work.AutoCompleteDataSource = null;
            atxb_data();
        }
        private void grd_customer_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            cc.ID_Customer = grd_customer.CurrentRow.Cells["ID_Customer"].Value.ToString();
            txt_N_Customer.Text = grd_customer.CurrentRow.Cells["N_Customer"].Value.ToString(); 
            drp_Title.SelectedValue = grd_customer.CurrentRow.Cells["ID_Title"].Value;
            txt_country.Text = grd_customer.CurrentRow.Cells["country"].Value.ToString();
            txt_state.Text = grd_customer.CurrentRow.Cells["State"].Value.ToString();
            txt_City.Text = grd_customer.CurrentRow.Cells["City"].Value.ToString();
            txt_adjoint_work.Text = grd_customer.CurrentRow.Cells["N_adjoint_work"].Value.ToString()+";";
            txt_Tafzili.Text = grd_customer.CurrentRow.Cells["nMoshtari"].Value.ToString() + ";";
            txt_address.Text = grd_customer.CurrentRow.Cells["address"].Value.ToString();
            txt_website.Text = grd_customer.CurrentRow.Cells["WebSite"].Value.ToString();
            txt_email.Text = grd_customer.CurrentRow.Cells["Email"].Value.ToString();
            txt_PObox.Text = grd_customer.CurrentRow.Cells["PObox"].Value.ToString();
            txt_Preamble.Text = grd_customer.CurrentRow.Cells["Preamble"].Value.ToString();
            txt_Number1.Text = grd_customer.CurrentRow.Cells["tell1"].Value.ToString();
            txt_Number2.Text = grd_customer.CurrentRow.Cells["tell2"].Value.ToString();
            txt_Number3.Text = grd_customer.CurrentRow.Cells["tell3"].Value.ToString();
            txt_Number4.Text = grd_customer.CurrentRow.Cells["tell4"].Value.ToString();
            cc.N_Legal_Customer = txt_N_Legal_Customer.Text = grd_customer.CurrentRow.Cells["N_Legal_Customer"].Value.ToString();
            txt_tell_Legal_Custom.Text = grd_customer.CurrentRow.Cells["tell_Legal_Customer"].Value.ToString();
            txt_Preamble_legal.Text = grd_customer.CurrentRow.Cells["Preamble_legal"].Value.ToString();
            txt_customer_real.Text = grd_customer.CurrentRow.Cells["N_Customer"].Value.ToString()+";";
            cc.ID_Legal = grd_customer.CurrentRow.Cells["legal_real"].Value.ToString();
            if (cc.ID_Legal == "False")
            {
                rbtn_real.IsChecked = true;
            }
            else
            {
                rbtn_legal.IsChecked = true;
            }
        }
        private void txt_customer_real_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_customer_real.Items.Count == 1)
                    cc.ID_Customer = txt_customer_real.Items[0].Value.ToString();
            }
            catch { }
        }
        private void btn_refresh_drp_atxb_Click(object sender, EventArgs e)
        {
            grd_data();
            atxb_data();
        }
        private void rbtn_customer_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rbtn_customer.IsChecked == true)
            {
                grb_real.Visible = true;
                grb_legal.Visible = false;
            }
        }

        private void rbtn_customer_legal_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rbtn_customer_legal.IsChecked == true)
            {
                grb_real.Visible = false;
                grb_legal.Visible = true;
            }
        }
    }
}
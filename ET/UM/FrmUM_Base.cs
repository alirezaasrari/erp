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
    public partial class FrmUM_Base : Telerik.WinControls.UI.RadForm
    {
        public FrmUM_Base()
        {
            InitializeComponent();
        }

        ClsUM objum = new ClsUM();
        public string IdForm,IdRole,IdControl;
       
        private void FrmUM_Base_Load(object sender, EventArgs e)
        {

            //سطح دسترسی کنترلها       
           
            DataTable DtControlAccess = new DataTable();
            DataRow[] dr = ClsMain.DtAccessUser.Select("n_form='" + this.Name + "'");
            if (dr.Length > 0)  DtControlAccess = dr.CopyToDataTable();
            if (DtControlAccess.Rows.Count > 0)
            {
                Control ctn;
                for (int i = 0; i < DtControlAccess.Rows.Count; i++)
                { string  strControl = DtControlAccess.Rows[i]["n_control"].ToString();
                    ctn = Controls[strControl];
                    if (ctn == null)
                        ctn = gbRole.Controls[strControl];
                    if (ctn != null)
                    {
                        bool rv,re;
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
            dt = objum.SelectRoleConterol().Tables[0];
            //****
            grdRole.DataSource = objum.SelectRoleUser().Tables[0];
          
            //****
            acbPersonel.AutoCompleteDataSource = objum.SelectUser().Tables[0];
            acbPersonel.AutoCompleteDisplayMember = "NAME";
            acbPersonel.AutoCompleteValueMember = "id";

            //****
            DrpProgram.DataSource = objum.SelectProgram().Tables[0];
            DrpProgram.ValueMember = "id";
            DrpProgram.DisplayMember = "n_program";
            //**** 
            NewForm();
            NewControl();
        }

        private void acbPersonel_TextChanged(object sender, EventArgs e)
        {
            if (acbPersonel.Items.Count == 1)
            {
                objum.IdUser = acbPersonel.Items[0].Value.ToString();
                grdRole.DataSource = objum.SelectRoleUser().Tables[0];
            }
        }

        private void MasterTemplate_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (grdRole.CurrentRow.Index > -1)
            {
                if (grdRole.CurrentRow.Cells["RoleUser"].IsCurrent)
                {
                    if (acbPersonel.Items.Count == 1)
                    {
                        objum.IDRole = grdRole.CurrentRow.Cells["id"].Value.ToString();
                        objum.IdUser = acbPersonel.Items[0].Value.ToString();
                        if (grdRole.CurrentRow.Cells["RoleUser"].Value.ToString() == "1")
                        {
                            objum.DelRoleUser();
                        }
                        if (grdRole.CurrentRow.Cells["RoleUser"].Value.ToString() == "0")
                        {
                            objum.InsRoleUser();
                        }
                        grdRole.DataSource = objum.SelectRoleUser().Tables[0];
                    }
                    else
                    {
                        RadMessageBox.Show("یک کاربر باید انتخاب شود.");
                    }
                }
                if (grdRole.CurrentRow.Cells["n_rol"].IsCurrent)
                {
                }
            }
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            objum.NRole = txtNameRole.Text;
            RadMessageBox.Show(objum.InsRole());
            grdRole.DataSource = objum.SelectRoleUser().Tables[0];
        }

        private void btnAddForm_Click(object sender, EventArgs e)
        {
            objum.NForm = txtFormShenaseh.Text;
            objum.SharhForm = txtNameForm.Text;
            objum.IdProgram = DrpProgram.SelectedValue.ToString();
            if (chkActiveForm.Checked == true)
                objum.FAForm = "1";
            if (chkActiveForm.Checked == false)
                objum.FAForm = "0";
            RadMessageBox.Show(objum.InsForm());
            //****
            NewForm();
        }

        private void NewForm() 
        { 
            btnEditForm.Enabled = false;
            btnDelForm.Enabled = false;
            DrpProgram.SelectedIndex = -1;
            grdForm.DataSource = objum.SelectForm().Tables[0];
            //****
            txtNameForm.Text = null;
            txtFormShenaseh.Text = null;
            chkActiveForm.Checked = false;
            IdForm = null;
        }

        private void btnEditForm_Click(object sender, EventArgs e)
        {
            objum.IdForm = IdForm;
            objum.NForm = txtFormShenaseh.Text;
            objum.SharhForm = txtNameForm.Text;
            objum.IdProgram = DrpProgram.SelectedValue.ToString();
            if (chkActiveForm.Checked == true)
                objum.FAForm = "1";
            if (chkActiveForm.Checked == false)
                objum.FAForm = "0";
            RadMessageBox.Show(objum.UpdForm());
            NewForm();
        }

        private void btnDelForm_Click(object sender, EventArgs e)
        {
            objum.IdForm = IdForm;
            RadMessageBox.Show(objum.DelForm());
            NewForm();
        }

        private void btnNewForm_Click(object sender, EventArgs e)
        {
            NewForm();
        }

        private void grdForm_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            DrpProgram.SelectedValue = grdForm.CurrentRow.Cells["idp"].Value;
            txtNameForm.Text = grdForm.CurrentRow.Cells["sharh"].Value.ToString();
            txtFormShenaseh.Text = grdForm.CurrentRow.Cells["n_form"].Value.ToString();
            chkActiveForm.Checked = Convert.ToBoolean(grdForm.CurrentRow.Cells["flag_active"].Value.ToString());
            IdForm = grdForm.CurrentRow.Cells["id"].Value.ToString();
            btnEditForm.Enabled = true;
            btnDelForm.Enabled = true;
            NewControl();
        }

        private void NewControl()    
        {
            btnDelControl.Enabled = false;
            btnEditControl.Enabled = false;
            txtNameControl.Text = null;
            txtShenasehControl.Text = null;
            chkControl.Checked = false;
            objum.IdForm = IdForm;
            grdControl.DataSource = objum.SelectConterol().Tables[0];
            //NewForm();
        }

        private void btnAddControl_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(IdForm))
            {
                RadMessageBox.Show("لطفا از لیست بالا فرمی را انتخاب کنید");
                return;
            }
            objum.SharhControl = txtNameControl.Text;
            objum.NControl = txtShenasehControl.Text;
            if (chkControl.Checked == true)
                objum.FAControl = "1";
            if (chkControl.Checked == false)
                objum.FAControl = "0";
            RadMessageBox.Show(objum.InsControl());
            //****
            NewControl();
        }

        private void btnEditControl_Click(object sender, EventArgs e)
        {
            objum.SharhControl = txtNameControl.Text;
            objum.NControl = txtShenasehControl.Text;
            if (chkControl.Checked == true)
                objum.FAControl = "1";
            if (chkControl.Checked == false)
                objum.FAControl = "0";
            objum.IdForm = grdForm.CurrentRow.Cells["id"].Value.ToString();
            ;
            objum.IdControl = IdControl;
            RadMessageBox.Show(objum.UpdControl());
            //****
            NewControl();
        }

        private void btnDelControl_Click(object sender, EventArgs e)
        {
            objum.IdControl = IdControl;
            RadMessageBox.Show(objum.DelControl());
            //****
            NewControl();
        }

        private void btnNewControl_Click(object sender, EventArgs e)
        {
            IdForm = null;
            NewControl();
        }

        public DataTable dt = new DataTable();

        private void grdRole_SelectionChanged(object sender, EventArgs e)
        {
            if (grdRole.CurrentRow.Index > -1)
            {
                lblRole.Text = grdRole.CurrentRow.Cells["n_rol"].Value.ToString();
                txtNameRole.Text = grdRole.CurrentRow.Cells["n_rol"].Value.ToString();
                IdRole = grdRole.CurrentRow.Cells["id"].Value.ToString();
               
                DataRow[] dr = dt.Select("id_role='" + IdRole + "'");
                if (dr.Length > 0)
                {
                    DataTable dt1 = dr.CopyToDataTable();
                    grdRoleControl.DataSource = dt1;
                }
                else
                {
                    grdRoleControl.DataSource = null;
                    grdRoleControl.Rows.Clear(); 
                }
            }
        }

        private void grdControl_SelectionChanged(object sender, EventArgs e)
        {
            if (grdControl.CurrentRow.Index > -1)
            {
                lblControl.Text = grdControl.CurrentRow.Cells["sharh"].Value.ToString();
                IdControl = grdControl.CurrentRow.Cells["id"].Value.ToString();
            }
        }

        private void grdControl_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (String.IsNullOrEmpty(IdForm))
            {
                RadMessageBox.Show("لطفا از لیست بالا فرمی را انتخاب کنید");
                return;
            }
            txtNameControl.Text = grdControl.CurrentRow.Cells["sharh"].Value.ToString();
            txtShenasehControl.Text = grdControl.CurrentRow.Cells["n_control"].Value.ToString();
            chkControl.Checked = Convert.ToBoolean(grdControl.CurrentRow.Cells["flag_active"].Value.ToString());
            IdControl = grdControl.CurrentRow.Cells["id"].Value.ToString();
            btnEditControl.Enabled = true;
            btnDelControl.Enabled = true;
        }

        private void btnAddRoleControl_Click(object sender, EventArgs e)
        {
            objum.IDRole = IdRole;
            objum.IdControl = IdControl;
            RadMessageBox.Show(objum.InsRoleControl());
            dt = objum.SelectRoleConterol().Tables[0];
            DataRow[] dr = dt.Select("id_role='" + IdRole + "'");
            if (dr.Length > 0)
            {
                DataTable dt1 = dr.CopyToDataTable();
                grdRoleControl.DataSource = dt1;
            }
            else
            {
                grdRoleControl.DataSource = null;
                grdRoleControl.Rows.Clear();
            }
        }

        private void btnDelRoleControl_Click(object sender, EventArgs e)
        {
            //objum.IDRoleControl = grdRoleControl.CurrentRow.Cells["id"].Value.ToString();
            RadMessageBox.Show(objum.DelRoleControl());
            dt = objum.SelectRoleConterol().Tables[0];
            dt = objum.SelectRoleConterol().Tables[0];
            DataRow[] dr = dt.Select("id_role='" + IdRole + "'");
            if (dr.Length > 0)
            {
                DataTable dt1 = dr.CopyToDataTable();
                grdRoleControl.DataSource = dt1;
            }
            else
            {
                grdRoleControl.DataSource = null;
                grdRoleControl.Rows.Clear();
            }
        }

        private void btnDelRole_Click(object sender, EventArgs e)
        {
            objum.IDRole = IdRole;
            RadMessageBox.Show(objum.DelRole());
            grdRole.DataSource = objum.SelectRoleUser().Tables[0];
        }

        private void btnEditRole_Click(object sender, EventArgs e)
        {
            objum.IDRole = IdRole;
            objum.NRole = txtNameRole.Text;
            RadMessageBox.Show(objum.UpdRole());
            grdRole.DataSource = objum.SelectRoleUser().Tables[0];
        }
        private void grdRoleControl_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            objum.IDRoleControl = grdRoleControl.CurrentRow.Cells["id"].Value.ToString();
            lblControl.Text = grdRoleControl.CurrentRow.Cells["nc"].Value.ToString();
            // if (grdRoleControl.CurrentRow.Index > -1)
            //{ 
            //    if (grdRoleControl.CurrentRow.Cells["isActive"].IsCurrent)
            //    {
            //        objum.IDRoleControl = grdRoleControl.CurrentRow.Cells["id"].Value.ToString();                    
            //        if (grdRoleControl.CurrentRow.Cells["isActive"].Value.ToString() == "True") objum.FisActive = "0";
            //        if (grdRoleControl.CurrentRow.Cells["isActive"].Value.ToString() == "False") objum.FisActive = "1";                    
            //        objum.UpdRCisActive();
                    
            //    }
            //    if (grdRoleControl.CurrentRow.Cells["isshow"].IsCurrent)
            //    {
            //        objum.IDRoleControl = grdRoleControl.CurrentRow.Cells["id"].Value.ToString();
            //        if (grdRoleControl.CurrentRow.Cells["isshow"].Value.ToString() == "True") objum.Fisshow = "0";
            //        if (grdRoleControl.CurrentRow.Cells["isshow"].Value.ToString() == "False") objum.Fisshow = "1";
            //        objum.UpdRCisshow();                    
            //    }
            //    dt = objum.SelectRoleConterol().Tables[0];
            //    DataRow[] dr = dt.Select("id_role='" + IdRole + "'");
            //    if (dr.Length > 0)
            //    {
            //        DataTable dt1 = dr.CopyToDataTable();
            //        grdRoleControl.DataSource = dt1;
            //    }
            //    else
            //    {
            //        grdRoleControl.DataSource = null;
            //        grdRoleControl.Rows.Clear();
            //    }
            //}
        }

        private void grdRoleControl_Click(object sender, EventArgs e)
        {
            if (grdRoleControl.CurrentRow.Index > -1)
            {
                objum.IDRoleControl = grdRoleControl.CurrentRow.Cells["id"].Value.ToString();
                lblControl.Text = grdRoleControl.CurrentRow.Cells["nc"].Value.ToString();
                if (grdRoleControl.CurrentRow.Cells["isActive"].IsCurrent)
                {
                    objum.IDRoleControl = grdRoleControl.CurrentRow.Cells["id"].Value.ToString();
                    if (grdRoleControl.CurrentRow.Cells["isActive"].Value.ToString() == "True") objum.FisActive = "0";
                    if (grdRoleControl.CurrentRow.Cells["isActive"].Value.ToString() == "False") objum.FisActive = "1";
                    objum.UpdRCisActive();

                }
                if (grdRoleControl.CurrentRow.Cells["isshow"].IsCurrent)
                {
                    objum.IDRoleControl = grdRoleControl.CurrentRow.Cells["id"].Value.ToString();
                    if (grdRoleControl.CurrentRow.Cells["isshow"].Value.ToString() == "True") objum.Fisshow = "0";
                    if (grdRoleControl.CurrentRow.Cells["isshow"].Value.ToString() == "False") objum.Fisshow = "1";
                    objum.UpdRCisshow();
                }
                dt = objum.SelectRoleConterol().Tables[0];
                DataRow[] dr = dt.Select("id_role='" + IdRole + "'");
                if (dr.Length > 0)
                {
                    DataTable dt1 = dr.CopyToDataTable();
                    grdRoleControl.DataSource = dt1;
                }
                else
                {
                    grdRoleControl.DataSource = null;
                    grdRoleControl.Rows.Clear();
                }
            }
        }
    }
}
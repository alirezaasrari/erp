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
    public partial class FrmUM_PersonelChart : Telerik.WinControls.UI.RadForm
    {
        public FrmUM_PersonelChart()
        {
            InitializeComponent();
        }

        ClsUM objum = new ClsUM();
        public string IDtblUserl, IDChartLocal;

        private void FrmEdari_PersonelChart_Load(object sender, EventArgs e)
        {
            this.trChart.TreeViewElement.AllowAlternatingRowColor = true;
            this.trChart.DataSource = objum.SelectChart().Tables[0];
            this.trChart.DisplayMember = "titel";
            this.trChart.ParentMember = "Parent_ID_SematUnit";
            this.trChart.ChildMember = "Node_ID_SematUnit";
            this.trChart.ValueMember = "ID_Chart";
            //******

            //acbChild.AutoCompleteDataSource = objum.SelectSematUnite().Tables[0];
            //acbChild.AutoCompleteDisplayMember = "semat";
            //acbChild.AutoCompleteValueMember = "ID_SematUnit";

            cmbFatherNew.DataSource = objum.SelectSematUnite().Tables[0];
            cmbFatherNew.DisplayMember = "semat";
            cmbFatherNew.ValueMember = "ID_SematUnit";

            //******
            grdPersonel.DataSource = objum.SelectPersonel().Tables[0];
            //******
            drpSemat.DataSource = objum.SelectSemat().Tables[0];
            drpSemat.DisplayMember = "TITLE";
            drpSemat.ValueMember = "POS_NO";

            cmbChild.DataSource = objum.SelectSematUnite().Tables[0];
            cmbChild.DisplayMember = "semat";
            cmbChild.ValueMember = "ID_SematUnit";
            cmbParent.DataSource = objum.SelectSematUnite().Tables[0];
            cmbParent.DisplayMember = "semat";
            cmbParent.ValueMember = "ID_SematUnit";

            DrpUnit.DataSource = objum.SelectUnite().Tables[0];
            DrpUnit.DisplayMember = "NameUnit";
            DrpUnit.ValueMember = "IdUnit";

            acbPersonel.AutoCompleteDataSource = objum.SelectP().Tables[0];
            acbPersonel.AutoCompleteDisplayMember = "NAME";
            acbPersonel.AutoCompleteValueMember = "id";
        }

        private void ExpandNodes()
        {
            using (this.trChart.DeferRefresh())
            {
                RadTreeNode root = this.trChart.Nodes[0];
                root.Expand();
                int index = 0;
                foreach (RadTreeNode node in root.Nodes)
                {
                    if (index % 2 == 0)
                    {
                        node.Expand();
                    }
                    index++;
                }
                if (root.Nodes.Count > 0)
                {
                    root.Nodes[root.Nodes.Count - 1].ExpandAll();
                }
            }
        }

        private void btnAddSemateUnit_Click(object sender, EventArgs e)
        {
            //DataTable dtSematUnit = (DataTable)cmbChild.AutoCompleteDataSource;
            //DataRow[] dr = dtSematUnit.Select("ID_Semat='" + drpSemat.SelectedValue + "' and ID_Unit= '" + DrpUnit.SelectedValue + "'");
            //if (dr.Length > 0)
            //{
            //    RadMessageBox.Show("این سمت تکراریست");
            //}
            //else
            //{
                objum.IDSemat = drpSemat.SelectedValue.ToString();
                objum.IDUnit = DrpUnit.SelectedValue.ToString();
                RadMessageBox.Show(objum.InsSematUnit());

                //*****
                cmbChild.Text = null;
                cmbChild.AutoCompleteDataSource = null;
                cmbChild.AutoCompleteDataSource = objum.SelectSematUnite().Tables[0];
                cmbChild.AutoCompleteDisplayMember = "semat";
                cmbChild.AutoCompleteValueMember = "ID_SematUnit";

                cmbParent.Text = null;
                cmbParent.AutoCompleteDataSource = null;
                cmbParent.AutoCompleteDataSource = objum.SelectSematUnite().Tables[0];
                cmbParent.AutoCompleteDisplayMember = "semat";
                cmbParent.AutoCompleteValueMember = "ID_SematUnit";
            //}
        }

        private void btnDelSematUnit_Click(object sender, EventArgs e)
        {
            objum.IDSematUnit = cmbChild.SelectedValue.ToString();
            if (RadMessageBox.Show(this, "آیا مطمئن هستید این سمت پاک شود؟", "", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation, MessageBoxDefaultButton.Button3, RightToLeft.Yes) == DialogResult.Yes)
            {
                RadMessageBox.Show(objum.DelSematUnit());
                //*****
                cmbChild.Text = null;
                cmbChild.AutoCompleteDataSource = null;
                cmbChild.AutoCompleteDataSource = objum.SelectSematUnite().Tables[0];
                cmbChild.AutoCompleteDisplayMember = "semat";
                cmbChild.AutoCompleteValueMember = "ID_SematUnit";

                cmbParent.Text = null;
                cmbParent.AutoCompleteDataSource = null;
                cmbParent.AutoCompleteDataSource = objum.SelectSematUnite().Tables[0];
                cmbParent.AutoCompleteDisplayMember = "semat";
                cmbParent.AutoCompleteValueMember = "ID_SematUnit";
            }
        }

        private void btnADDPersonel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtpersonel = (DataTable)grdPersonel.DataSource;
                DataRow[] dr = dtpersonel.Select("code_personeli='" + acbPersonel.Items[0].Value + "' or username='" + txtUserName.Text + "' ");

                if (dr.Length > 0)
                {
                    RadMessageBox.Show("این کاربر یا نام کاربری تکراریست");
                }
                else
                {
                    objum.CodePersoneli = acbPersonel.Items[0].Value.ToString();
                    objum.UserName = txtUserName.Text;
                    objum.Password = txtPass.Text;
                    if (chkActive.Checked == true)
                        objum.FAPersonel = "1";
                    if (chkActive.Checked == false)
                        objum.FAPersonel = "0";
                    RadMessageBox.Show(objum.InsPersonel());
                    grdPersonel.DataSource = objum.SelectPersonel().Tables[0];
                }
            }
            catch
            {
            }
        }

        private void btnEditPersonel_Click(object sender, EventArgs e)
        {
            //objum.IdUser = grdPersonel.SelectedRows[0].Cells["id"].Value.ToString();
            objum.IdUser = IDtblUserl;
            objum.CodePersoneli = acbPersonel.Items[0].Value.ToString();
            objum.UserName = txtUserName.Text;
            objum.Password = txtPass.Text;
            if (chkActive.Checked == true)
                objum.FAPersonel = "1";
            if (chkActive.Checked == false)
                objum.FAPersonel = "0";
            RadMessageBox.Show(objum.UpdPersonel());
            grdPersonel.DataSource = objum.SelectPersonel().Tables[0];
            NewPersonel();
        }

        private void btnRemovePersonel_Click(object sender, EventArgs e)
        {
            objum.IdUser = IDtblUserl;
            if (RadMessageBox.Show(this, "آیا مطمئن هستید این کاربر پاک شود؟", "", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation, MessageBoxDefaultButton.Button3, RightToLeft.Yes) == DialogResult.Yes)
            {
                RadMessageBox.Show(objum.DelUser());
                grdPersonel.DataSource = objum.SelectPersonel().Tables[0];
                NewPersonel();
            }
        }

        private void acbPersonel_Leave(object sender, EventArgs e)
        {
            if (acbPersonel.Items.Count == 1)
                txtUserName.Text = acbPersonel.Items[0].Value.ToString();
        }

        private void grdPersonel_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                IDtblUserl = grdPersonel.CurrentRow.Cells["id"].Value.ToString();
                acbPersonel.Text = grdPersonel.CurrentRow.Cells["NAME"].Value.ToString() + ";";
                txtUserName.Text = grdPersonel.CurrentRow.Cells["username"].Value.ToString();
                txtPass.Text = grdPersonel.CurrentRow.Cells["password"].Value.ToString();
                if (grdPersonel.CurrentRow.Cells["flag_active"].Value.ToString() == "True")
                    chkActive.Checked = true;
                if (grdPersonel.CurrentRow.Cells["flag_active"].Value.ToString() == "False")
                    chkActive.Checked = false;
                btnEditPersonel.Enabled = true;
                btnRemovePersonel.Enabled = true;
            }
            catch { }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewPersonel();
            FrmEdari_PersonelChart_Load(sender, e);
        }

        private void NewPersonel() 
        {
            btnEditPersonel.Enabled = false;
            btnRemovePersonel.Enabled = false;
            acbPersonel.Clear();
            txtUserName.Text = null;
            txtPass.Text = null;
            chkActive.Checked = false;
        }

        private void trChart_NodeMouseDoubleClick(object sender, RadTreeViewEventArgs e)
        {
            try
            {
                IDChartLocal = trChart.SelectedNode.Value.ToString();
                lblDelChart.Text = trChart.SelectedNode.Text;
                btnDelChart.Enabled = true;
                objum.IDChart = IDChartLocal;
                grdPersonel.DataSource = objum.SelectPersonel().Tables[0];
                if (grdPersonel.RowCount == 0)
                    lblNamePersonel.Text = "-";
            }
            catch { }
        }

        private void trChart_SelectedNodesChanged(object sender, RadTreeViewEventArgs e)
        {
            try
            {
                //if (trChart.SelectedNodes.Count > 0)
                //{
                //    lblParentIDSematUnit.Text = trChart.SelectedNode.Text;
                //}
                IDChartLocal = null;
                lblDelChart.Text = "-";
                btnDelChart.Enabled = false;
                objum.IDChart = null;
                grdPersonel.DataSource = objum.SelectPersonel().Tables[0];
            }
            catch { }
        }

        private void btnAddChart_Click(object sender, EventArgs e)
        {
            //if (acbChild.Items.Count == 0) 
            //{
            //    RadMessageBox.Show("لطفا سمتی را انتخاب کنید");
            //    return;
            //}
            //if (acbChild.Items.Count == 1)
            //{
            //    RadMessageBox.Show("لطفا سمت پدر را انتخاب کنید");
            //    return;
            //}
            //if (acbChild.Items.Count == 2)
            //{
            //objum.NodeIDSematUnit = acbChild.Items[0].Value.ToString();
            objum.NodeIDSematUnit = cmbChild.SelectedValue.ToString();

            //objum.ParentIDSematUnit = acbChild.Items[1].Value.ToString();
            objum.ParentIDSematUnit = cmbParent.SelectedValue.ToString();

            DataTable dtChart = (DataTable)trChart.DataSource;
            DataRow[] dr = dtChart.Select("Node_ID_SematUnit='" + objum.NodeIDSematUnit + "' or Parent_ID_SematUnit= '" + objum.NodeIDSematUnit + "'");
            if (dr.Length > 0)
            {
                RadMessageBox.Show("این پست وجود دارد");
            }
            else
            {
                RadMessageBox.Show(objum.InsChart());
                this.trChart.DataSource = null;
                this.trChart.DataSource = objum.SelectChart().Tables[0];
                this.trChart.DisplayMember = "titel";
                this.trChart.ParentMember = "Parent_ID_SematUnit";
                this.trChart.ChildMember = "Node_ID_SematUnit";
                this.trChart.ValueMember = "ID_Chart";
            }
            //}
        }

        private void btnDelChart_Click(object sender, EventArgs e)
        {
            string a = "";
            try
            {
                a = trChart.SelectedNode.LastNode.Text;
            }
            catch
            {
            }
            if (!String.IsNullOrEmpty(a)) 
            {
                RadMessageBox.Show("این سمت زیر مجموعه دارد");
            }
            else if (grdPersonel.RowCount > 0)
            {
                RadMessageBox.Show("این سمت پرسنل دارد");
            }
            else
            {
                if (RadMessageBox.Show(this, "آیا مطمئن هستید این سمت چارت پاک شود؟", "", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation, MessageBoxDefaultButton.Button3, RightToLeft.Yes) == DialogResult.Yes)
                {
                    RadMessageBox.Show(objum.DelChart());
                    this.trChart.DataSource = null;
                    this.trChart.DataSource = objum.SelectChart().Tables[0];
                    this.trChart.DisplayMember = "titel";
                    this.trChart.ParentMember = "Parent_ID_SematUnit";
                    this.trChart.ChildMember = "Node_ID_SematUnit";
                    this.trChart.ValueMember = "ID_Chart";
                }
            }
        }

        private void btnAddPersonelChart_Click(object sender, EventArgs e)
        {
            if (trChart.SelectedNodes.Count > 0)
                objum.IDChart = trChart.SelectedNode.Value.ToString();
            else
            {
                RadMessageBox.Show("از چارت سمت را انتخاب کنید");
                return;
            }

            if (grdPersonel.SelectedRows.Count > 0)
                objum.CodePersoneli = grdPersonel.CurrentRow.Cells["code_personeli"].Value.ToString();
            else
            {
                RadMessageBox.Show("پرسنلی را انتخاب کنید");
                return;
            }
            //DataTable dtPersonelChart = (DataTable)grdPersonel.DataSource;
            //DataRow[] dr = dtPersonelChart.Select("code_personeli='" + grdPersonel.CurrentRow.Cells["code_personeli"].Value.ToString() + "'and  IsActive='True'");
            //if (dr.Length > 0) 
            //{
            //    RadMessageBox.Show("کاربر دارای سمت فعال می باشد ابتدا سمت کاربر را غیر فعال کنید");
            //}
            //else
            //{
                RadMessageBox.Show(objum.InsPersonelChart());
                grdPersonel.DataSource = objum.SelectPersonel().Tables[0];
            //}
        }

        private void grdPersonel_SelectionChanged(object sender, EventArgs e)
        {
            if (grdPersonel.CurrentRow.Index > -1)
            {
                lblNamePersonel.Text = grdPersonel.CurrentRow.Cells["NAME"].Value.ToString();
                if (String.IsNullOrEmpty(grdPersonel.CurrentRow.Cells["ID_PersonelChart"].Value.ToString()))
                {
                    btnDelPersonelChart.Enabled = false;
                    btnUpdatePersonelChart.Enabled = false;
                }
                else
                {
                    btnDelPersonelChart.Enabled = true;
                    btnUpdatePersonelChart.Enabled = true;
                }
            }
        }

        private void btnDelPersonelChart_Click(object sender, EventArgs e)
        {
            if (RadMessageBox.Show(this, "آیا مطمئن هستید سمت کاربر غیر فعال شود؟", "", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation, MessageBoxDefaultButton.Button3, RightToLeft.Yes) == DialogResult.Yes)
            {
                objum.IDPersonelChart = grdPersonel.CurrentRow.Cells["ID_PersonelChart"].Value.ToString();
                //RadMessageBox.Show(objum.UpdPersonelChart0());
                RadMessageBox.Show(objum.DelPersonelChart());
                grdPersonel.DataSource = objum.SelectPersonel().Tables[0];
            }
        }

        private void btnUpdatePersonelChart_Click(object sender, EventArgs e)
        {
            DataTable dtPersonelChart = (DataTable)grdPersonel.DataSource;
            DataRow[] dr = dtPersonelChart.Select("code_personeli='" + grdPersonel.CurrentRow.Cells["code_personeli"].Value.ToString() + "'and  IsActive='True'");
            if (dr.Length > 0)
            {
                RadMessageBox.Show("کاربر دارای سمت فعال می باشد ابتدا سمت کاربر را غیر فعال کنید");
            }
            else
            {
                objum.IDPersonelChart = grdPersonel.CurrentRow.Cells["ID_PersonelChart"].Value.ToString();
                RadMessageBox.Show(objum.UpdPersonelChart1());
                grdPersonel.DataSource = objum.SelectPersonel().Tables[0];
            }
        }

        private void grdPersonel_Click(object sender, EventArgs e)
        {

        }

        private void acbPersonel_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEditChart_Click(object sender, EventArgs e)
        {
            objum.IDChart = trChart.SelectedNode.Value.ToString();
            objum.IDSematUnit = cmbFatherNew.SelectedValue.ToString();
            MessageBox.Show(objum.UpdChart());
            FrmEdari_PersonelChart_Load(sender, e);
        }
    }
}
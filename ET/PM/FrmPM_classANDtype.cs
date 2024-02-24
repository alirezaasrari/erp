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
    public partial class FrmPM_classANDtype : Telerik.WinControls.UI.RadForm
    {
        public FrmPM_classANDtype()
        {
            InitializeComponent();
        }

        public ClsPM cpm = new ClsPM();
        public string str;

        private void btn_del_Class_Click(object sender, EventArgs e)
        {
            if (cpm.Idclass != null)
            {
                if (MessageBox.Show("آیا مطمئن هستید حذف شود؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DataSet ds = new DataSet();
                    cpm.flag_del_class = true;
                    ds = cpm.Selecttypemachin();
                    int rc = ds.Tables[0].Rows.Count;
                    if (rc == 0)
                    {
                        MessageBox.Show(cpm.Delclass());
                    }
                    if (rc > 0)
                    {

                        for (int i = 0; i < rc; i++)
                        {
                            str += ds.Tables[0].Rows[i]["N_type"].ToString() + "\n";
                        }

                        MessageBox.Show(":این کلاس درنوع دستگاه\n "
                            + str +
                            " ثبت شده است");
                        str = null;
                    }               
                }
                cpm.nameclass = null;
                grd_class.DataSource = cpm.Selectclassmachin().Tables[0];
                autocod();
                txb_nameclass.Text = null;
                cpm.Idclass = null;
                txb_codcalss.Enabled = true;
                drpClass();
            }
            else
            {
                MessageBox.Show("لطفا یک سطر را انتخاب کنید");
            }
        }

        private void btn_edit_Class_Click(object sender, EventArgs e)
        {
            if (cpm.Idclass != null)
            {
                cpm.nameclass = txb_nameclass.Text;
                if (MessageBox.Show("آیا مطمئن هستید ویرایش شود؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                   MessageBox.Show(cpm.Updateclass());
                }
                cpm.nameclass = null;
                grd_class.DataSource = cpm.Selectclassmachin().Tables[0];
                grd_type.DataSource = cpm.Selecttypemachin().Tables[0];
                autocod();
                txb_nameclass.Text = null;
                cpm.Idclass = null;
                txb_codcalss.Enabled = true;
                drpClass();
            }
            else
            {
                MessageBox.Show("لطفا یک سطر را انتخاب کنید");
            }
        }

        private void btn_add_Class_Click(object sender, EventArgs e)
        {
            cpm.nameclass = txb_nameclass.Text;
            if (cpm.Selectclassmachin().Tables[0].Rows.Count == 0)
            {
                cpm.Idclass = txb_codcalss.Text;

                MessageBox.Show(cpm.Insclassmachin());
                cpm.nameclass = null;
                grd_class.DataSource = cpm.Selectclassmachin().Tables[0];
                autocod();
                txb_nameclass.Text = null;
                drpClass();
            }
            else
            {
                MessageBox.Show("نام کلاس تکراریست");
            }
        }

        private void btn_new_Class_Click(object sender, EventArgs e)
        {
            txb_codcalss.Enabled = true;
            cpm.nameclass = null;
            cpm.Idclass = null;
            txb_nameclass.Text = null;
            autocod();
        }

        private void btn_del_type_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا مطمئن هستید حذف شود؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataSet ds = new DataSet();
                cpm.flag_del_type = true;
                ds = cpm.selectMachine();
                int rc = ds.Tables[0].Rows.Count;
                if (rc == 0)
                {
                    MessageBox.Show( cpm.Deltype());
                }
                if (rc > 0)
                {

                    for (int i = 0; i < rc; i++)
                    {
                        str += ds.Tables[0].Rows[i]["codmachine"].ToString() + "\n";
                    }

                    MessageBox.Show(":این نوع دستگاه در دستگاه\n "
                        + str +
                        " ثبت شده است");
                    str = null;

                }               
               
            }
            cpm.nametype = null;
            grd_type.DataSource = cpm.Selecttypemachin().Tables[0];
            newtxb();
        }

        private void btn_edit_type_Click(object sender, EventArgs e)
        {
            if (txb_nametype.Text != null && txb_nametype.Text != "")
            {
                cpm.Idclass = drp_class.SelectedValue.ToString();
                cpm.Idtype = txb_idtype.Text;
                cpm.nametype = txb_nametype.Text;
                if (MessageBox.Show("آیا مطمئن هستید ویرایش شود؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MessageBox.Show(cpm.Updatetype());
                }
                cpm.nametype = null;
                grd_type.DataSource = cpm.Selecttypemachin().Tables[0];
                //----------------------------do insert ------------------
                newtxb();
            }
            else
            {
                MessageBox.Show("نام را وارد  کنید");
            }
        }

        private void btn_add_type_Click(object sender, EventArgs e)
        {
            if (drp_class.SelectedIndex != -1)
            {
                if (txb_idtype.Text != null && txb_idtype.Text != "")
                {
                    if (txb_nametype.Text != null && txb_nametype.Text != "")
                    {
                        cpm.Idclass = drp_class.SelectedValue.ToString();
                        cpm.Idtype = txb_idtype.Text;
                        cpm.nametype = txb_nametype.Text;
                        MessageBox.Show(cpm.Instypemachin());
                        cpm.nametype = null;
                        grd_type.DataSource = cpm.Selecttypemachin().Tables[0];
                        //----------------------------do insert ------------------
                        newtxb();
                    }
                    else
                    {
                        MessageBox.Show("نام را وارد  کنید");
                    }
                }
                else
                {
                    MessageBox.Show("کد نوع را وارد کنید");
                }
            }
            else
            {
                MessageBox.Show("یک کلاس را انتخاب کنید");
            }
        }

        private void btn_new_type_Click(object sender, EventArgs e)
        {
            newtxb();
        }

        private void newtxb()
        {
            drp_class.Text = null;
            drp_class.SelectedIndex = -1;
            cpm.Idclass = null;
            cpm.Idtype = null;
            txb_idtype.Text = cpm.autocodetype().Tables[0].Rows[0][0].ToString();
            txb_nametype.Text = null;
            txb_idtype.Enabled = true;
            btn_del_type.Enabled = false;
            btn_edit_type.Enabled = false;
            btn_new_type.Enabled = false;
            btn_add_type.Enabled = true;
        }

        private void FrmPM_classANDtype_Load(object sender, EventArgs e)
        {
            cpm.nameclass = null;
            grd_class.DataSource = cpm.Selectclassmachin().Tables[0];
            autocod();
            //--------------------------------------type
            drpClass();
            cpm.nametype = null;
            grd_type.DataSource = cpm.Selecttypemachin().Tables[0];
            txb_idtype.Text = cpm.autocodetype().Tables[0].Rows[0][0].ToString();
            newtxb();
        }
  
        private void drpClass()
        {
            //--------------------------------------type
            drp_class.DataSource = cpm.select_drp_type().Tables[0];
            drp_class.ValueMember = "ID_class";
            drp_class.DisplayMember = "N_class";
            drp_class.SelectedIndex = -1;
        }

        private void autocod()
        {
            txb_codcalss.Text = cpm.autocodeclass().Tables[0].Rows[0][0].ToString();
            btn_edit_Class.Enabled = false;
            btn_del_Class.Enabled = false;
            btn_new_Class.Enabled = false;
            btn_add_Class.Enabled = true;
        }

        private void grd_class_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                txb_codcalss.Text = cpm.Idclass = grd_class.CurrentRow.Cells["ID_class"].Value.ToString();
                txb_nameclass.Text = grd_class.CurrentRow.Cells["N_class"].Value.ToString();
                txb_codcalss.Enabled = false;
                btn_edit_Class.Enabled = true;
                btn_del_Class.Enabled = true;
                btn_new_Class.Enabled = true;
                btn_add_Class.Enabled = false;
            }
            catch
            {
                MessageBox.Show("روی خطوط گرید کلید نمایید");
            }
        }

        private void grd_type_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                //drp_class.Text = grd_type.CurrentRow.Cells["N_class"].Value.ToString();
                //cpm.Idclass = grd_type.CurrentRow.Cells["FK_ID_class"].Value.ToString();
                drp_class.SelectedValue = grd_type.CurrentRow.Cells["FK_ID_class"].Value;
                cpm.Idtype = txb_idtype.Text = grd_type.CurrentRow.Cells["ID_type"].Value.ToString();
                txb_nametype.Text = grd_type.CurrentRow.Cells["N_type"].Value.ToString();
                txb_idtype.Enabled = false;
                btn_del_type.Enabled = true;
                btn_edit_type.Enabled = true;
                btn_new_type.Enabled = true;
                btn_add_type.Enabled = false;
            }
            catch
            {
                MessageBox.Show("روی خطوط گرید کلید نمایید");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Diagnostics;
using System.IO;
using Telerik.WinControls.UI.Export;

namespace ET
{
    public partial class FrmTakvin_Taeed : Telerik.WinControls.UI.RadForm
    {
        public FrmTakvin_Taeed()
        {
            InitializeComponent();
        }
        public int TaeedOpr, TaeedDesign, TaeedPlan;  
        private void FrmTakvin_Taeed_Load(object sender, EventArgs e)
        {
            ClsTakvin objTakvin = new ClsTakvin();
            grdTreeTaeed.DataSource = objTakvin.Select_TreeTaeed().Tables[0];
            //////////////////////////////////////////////سطح دسترسی کنترلها       
            DataTable DtControlAccess = new DataTable();
            DataRow[] dr = ClsMain.DtAccessUser.Select("n_form='" + this.Name + "'");
            if (dr.Length > 0) DtControlAccess = dr.CopyToDataTable();
            if (DtControlAccess.Rows.Count > 0)
            {
                string ctn;
                for (int i = 0; i < DtControlAccess.Rows.Count; i++)
                {
                    ctn = DtControlAccess.Rows[i]["n_control"].ToString();                     
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
                        grdTreeTaeed.Columns[ctn].AllowResize = re;
                        grdTreeTaeed.Columns[ctn].IsVisible = rv;
                    }
                }
            }
            ///////////////////////////////////////////////
            objTakvin.InsTreeManage();
        }

        private void grdTreeTaeed_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            ClsTakvin objTakvin = new ClsTakvin();
            try
            {
                if (e.Column.Name == "TaeedOpr")
                {
                    if (Convert.ToInt16(grdTreeTaeed.Rows[e.RowIndex].Cells["desi"].Value) != 1)
                    {
                        objTakvin.strIdRootTree = grdTreeTaeed.Rows[e.RowIndex].Cells["idRootTree"].Value.ToString();
                        objTakvin.strTaeed = (1 - Convert.ToInt16(grdTreeTaeed.Rows[e.RowIndex].Cells["Opr"].Value)).ToString();

                        MessageBox.Show(objTakvin.UpdTreeManageOpr());
                        if (objTakvin.strTaeed == "1")
                        {
                            objTakvin.strTaeed = "0";
                            objTakvin.UpdTreeManageDesign();
                        }
                        grdTreeTaeed.DataSource = objTakvin.Select_TreeTaeed().Tables[0];
                    }
                    else
                    {
                        MessageBox.Show("امکان اعمال تغییرات وجود ندارد");
                        return;
                    }
                }
                if (e.Column.Name == "TaeedDesign")
                {
                    //if (Convert.ToInt16(grdTreeTaeed.Rows[e.RowIndex].Cells["Opr"].Value) == 1
                    //  & Convert.ToInt16(grdTreeTaeed.Rows[e.RowIndex].Cells["Plani"].Value) != 1)
                    //{
                        objTakvin.strIdRootTree = grdTreeTaeed.Rows[e.RowIndex].Cells["idRootTree"].Value.ToString();
                        if (Convert.ToInt16(grdTreeTaeed.Rows[e.RowIndex].Cells["desi"].Value) == 2)
                            objTakvin.strTaeed = "0";
                        else
                            objTakvin.strTaeed = (1 + Convert.ToInt16(grdTreeTaeed.Rows[e.RowIndex].Cells["desi"].Value)).ToString();

                        MessageBox.Show(objTakvin.UpdTreeManageDesign());
                        if (objTakvin.strTaeed == "2")
                        {
                            objTakvin.strTaeed = "0";
                            objTakvin.UpdTreeManageOpr();
                        }
                        if (objTakvin.strTaeed == "1")
                        {
                            objTakvin.strTaeed = "0";
                            objTakvin.UpdTreeManagePlan();
                        }
                        grdTreeTaeed.DataSource = objTakvin.Select_TreeTaeed().Tables[0];
                    //}
                    //else
                    //{
                    //    MessageBox.Show("امکان اعمال تغییرات وجود ندارد");
                    //    return;
                    //}
                }
                if (e.Column.Name == "TaeedPlan")
                {
                    if(Convert.ToInt16(grdTreeTaeed.Rows[e.RowIndex].Cells["Plani"].Value) == 1
                     & grdTreeTaeed.Columns["TaeedPlan"].AllowResize == false)
                    {
                        MessageBox.Show("دسترسی لغو تایید وجود ندارد");
                        return;
                    }

                    if (Convert.ToInt16(grdTreeTaeed.Rows[e.RowIndex].Cells["desi"].Value) == 1)
                    {
                        objTakvin.strIdRootTree = grdTreeTaeed.Rows[e.RowIndex].Cells["idRootTree"].Value.ToString();
                        if (Convert.ToInt16(grdTreeTaeed.Rows[e.RowIndex].Cells["Plani"].Value) == 2)
                            objTakvin.strTaeed = "0";
                        else
                            objTakvin.strTaeed = (1 + Convert.ToInt16(grdTreeTaeed.Rows[e.RowIndex].Cells["Plani"].Value)).ToString();

                        MessageBox.Show(objTakvin.UpdTreeManagePlan());
                        if (objTakvin.strTaeed == "2")
                        {
                            objTakvin.strTaeed = "0";
                            objTakvin.UpdTreeManageDesign();
                            objTakvin.strCKala = grdTreeTaeed.Rows[e.RowIndex].Cells["GhetehCode"].Value.ToString();
                            objTakvin.DelOrderdetailTemp();
                            MessageBox.Show("این محصول از سبد سفارشات برنامه ریزی جهت تولید حذف شد");
                        }
                        grdTreeTaeed.DataSource = objTakvin.Select_TreeTaeed().Tables[0];
                    }
                    else
                    {
                        MessageBox.Show("امکان اعمال تغییرات وجود ندارد");
                        return;
                    }
                }
            }
            catch{}
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClsTakvin objTakvin = new ClsTakvin();
            grdTreeTaeed.DataSource = objTakvin.Select_TreeTaeed().Tables[0];
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string fileName = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = string.Format("{0} (*{1})|*{1}", "Excel Files", ".xls")
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
            }
                (new ExportToExcelML(this.grdTreeTaeed)).RunExport(fileName);
            if (RadMessageBox.Show("اطلاعات به درستی خارج شد.آیا می خواهید فایل باز شود؟", "Export to Excel", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Process.Start(fileName);
                }
                catch
                {
                }
            }
        }
    }
}

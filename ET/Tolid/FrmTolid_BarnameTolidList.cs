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
    public partial class FrmTolid_BarnameTolidList : Telerik.WinControls.UI.RadForm
    {
        public FrmTolid_BarnameTolidList()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.grdBarnameHD.TableElement.BeginUpdate();
            this.grdBarnameHD.EnableFiltering = true;
            this.grdBarnameHD.AllowAddNewRow = false;
            this.grdBarnameHD.ReadOnly = true;
            this.grdBarnameHD.MasterTemplate.ShowHeaderCellButtons = true;
            this.grdBarnameHD.MasterTemplate.ShowFilteringRow = false;
            this.grdBarnameHD.TableElement.EndUpdate();

        }
        private void FrmTolid_BarnameTolidList_Load(object sender, EventArgs e)
        {
            ClsPlanning objPlanning = new ClsPlanning();
            grdBarnameHD.DataSource = objPlanning.Select_BarnameHD().Tables[0];
        }

        private void grdBarnameHD_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                //if (e.Column.Name == "IsStart" | e.Column.Name == "IsEnd")
                //{
                //    if (Convert.ToInt16(grdBarnameHD.CurrentRow.Cells["IsStart"].Value) == 0 & Convert.ToInt16(grdBarnameHD.CurrentRow.Cells["IsEnd"].Value) == 1)
                //    {
                //        MessageBox.Show("برنامه هنوز شروع نشده است");
                //        return;
                //    }
                //    DataTable dt = new DataTable();
                //    ClsPlanning objPlanning = new ClsPlanning();
                //    objPlanning.strIdBarnameD = grdBarnameHD.CurrentRow.Cells["IdBarname"].Value.ToString();
                //    objPlanning.strIsStart = Convert.ToInt16(grdBarnameHD.CurrentRow.Cells["IsStart"].Value).ToString();
                //    objPlanning.strIsEnd = Convert.ToInt16(grdBarnameHD.CurrentRow.Cells["IsEnd"].Value).ToString();
                //    objPlanning.strTozihatPlan = grdBarnameHD.CurrentRow.Cells["TozihatPlan"].Value.ToString();
                //    objPlanning.strTozihatTolid = grdBarnameHD.CurrentRow.Cells["TozihatTolid"].Value.ToString();
                //    if (Convert.ToInt16(grdBarnameHD.CurrentRow.Cells["IsEndOld"].Value) == 1)
                //    {
                //        MessageBox.Show("امکان تغییر برنامه پایان یافته وجود ندارد");
                //        grdBarnameHD.DataSource = objPlanning.Select_BarnameHD().Tables[0];
                //        return;
                //    }
                //    MessageBox.Show(objPlanning.Update_BarnameDTolid());
                //}
                if (e.Column.Name == "IsStart")
                {
                    if (Convert.ToInt16(grdBarnameHD.CurrentRow.Cells["IsStart"].Value) == 0 & Convert.ToInt16(grdBarnameHD.CurrentRow.Cells["IsEnd"].Value) == 1)
                    {
                        MessageBox.Show("برنامه هنوز شروع نشده است");
                        return;
                    }
                    DataTable dt = new DataTable();
                    ClsPlanning objPlanning = new ClsPlanning();
                    objPlanning.strIdBarnameD = grdBarnameHD.CurrentRow.Cells["IdBarname"].Value.ToString();
                    if (Convert.ToInt16(grdBarnameHD.CurrentRow.Cells["IsEndOld"].Value) == 1)
                    {
                        MessageBox.Show("امکان تغییر برنامه پایان یافته وجود ندارد");
                        grdBarnameHD.DataSource = objPlanning.Select_BarnameHD().Tables[0];
                        return;
                    }
                    MessageBox.Show(objPlanning.Update_BarnameIsStartTolid());
                }
                if (e.Column.Name == "IsEnd")
                {
                    if (Convert.ToInt16(grdBarnameHD.CurrentRow.Cells["IsStart"].Value) == 0 & Convert.ToInt16(grdBarnameHD.CurrentRow.Cells["IsEnd"].Value) == 1)
                    {
                        MessageBox.Show("برنامه هنوز شروع نشده است");
                        return;
                    }
                    DataTable dt = new DataTable();
                    ClsPlanning objPlanning = new ClsPlanning();
                    objPlanning.strIdBarnameD = grdBarnameHD.CurrentRow.Cells["IdBarname"].Value.ToString();
                    if (Convert.ToInt16(grdBarnameHD.CurrentRow.Cells["IsEndOld"].Value) == 1)
                    {
                        MessageBox.Show("امکان تغییر برنامه پایان یافته وجود ندارد");
                        grdBarnameHD.DataSource = objPlanning.Select_BarnameHD().Tables[0];
                        return;
                    }
                    MessageBox.Show(objPlanning.Update_BarnameIsEndTolid());
                }
                if (e.Column.Name== "btnShow")
                {
                    FrmPLN_SabtBarname frm = new FrmPLN_SabtBarname();
                    frm.txtIdBarnameH.Text= grdBarnameHD.CurrentRow.Cells["IdBarname"].Value.ToString();
                    frm.strIsView = "1";
                    frm.ShowDialog();
                }
                //ClsPlanning obj = new ClsPlanning();
                //grdBarnameHD.DataSource = obj.Select_BarnameHD().Tables[0];
            }
            catch (Exception ee)
            {
                //MessageBox.Show(ee.Message);
            }
        }

        private void grdBarnameHD_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            try
            {
                e.CellElement.DrawFill = true;
                e.CellElement.ForeColor = Color.Black;
                e.CellElement.NumberOfColors = 1;
                e.CellElement.BackColor = Color.White;

                if (Convert.ToInt16(grdBarnameHD.Rows[e.RowIndex].Cells["IsStart"].Value) == 1)
                {
                    e.CellElement.NumberOfColors = 1;
                    e.CellElement.BackColor = Color.LightGreen;
                }
                if (Convert.ToInt16(grdBarnameHD.Rows[e.RowIndex].Cells["IsEnd"].Value) == 1)
                {
                    e.CellElement.NumberOfColors = 1;
                    e.CellElement.BackColor = Color.PaleGoldenrod;
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
            }
        }
    }
}

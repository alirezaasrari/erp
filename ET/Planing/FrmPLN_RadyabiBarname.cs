using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using FastReport;

namespace ET
{
    public partial class FrmPLN_RadyabiBarname : Telerik.WinControls.UI.RadForm
    {
        public bool NoChange = false;
        public string strIdUnit;
        public FrmPLN_RadyabiBarname()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtIdRadyabi.Text.Trim() == "" || txtCodeKargah.Text.Trim() == "")
            {
                RadMessageBox.Show("کد ردیابی و کارگاه را تعیین نمایید");
                return;
            }
            ClsPlanning ObjPlanning = new ClsPlanning();
            ObjPlanning.strIdRadyabi = txtIdRadyabi.Text.Trim();
            ObjPlanning.strIdUnit = txtCodeKargah.Text.Trim();
            NoChange = true;
            if (ObjPlanning.Select_RadyabiMain().Tables[0].Rows.Count == 0)
            {
                RadMessageBox.Show("کد ردیابی نا معتبر می باشد");
                return;
            }
            if (ObjPlanning.Select_RadyabiMain().Tables[0].Rows[0]["EndAction"].ToString() == "True")
            {
                lblVaziat.Text = "خاتمه یافته";
                chkEndRadyabi.Checked = true;
            }
            else
            {
                lblVaziat.Text = "درجریان";
                chkEndRadyabi.Checked = false;
            }
            NoChange = false;

            GrdBarname.DataSource = ObjPlanning.Select_RadyabiBarname().Tables[0];
            GrdMavad.DataSource = ObjPlanning.Select_RadyabiMavad().Tables[0];
            GrdTahvil.DataSource = ObjPlanning.Select_RadyabiTahvil().Tables[0];  
        }

        private void chkEndRadyabi_CheckedChanged(object sender, EventArgs e)
        {
            if (NoChange == false)
            {
                string msg;
                ClsPlanning ObjPlanning = new ClsPlanning();
                ObjPlanning.strIdRadyabi = txtIdRadyabi.Text;

                if (chkEndRadyabi.Checked == true)
                {
                    ObjPlanning.strEndRadyabi = "1";
                    msg = "آیا از پایان مراحل این کد ردیابی اطمینان دارید؟";
                }
                else
                {
                    ObjPlanning.strEndRadyabi = "0";
                    msg = "آیا از فعال شدن این کد ردیابی اطمینان دارید؟";
                }

                if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    MessageBox.Show(ObjPlanning.Update_SetEndRadyabi());

                if (ObjPlanning.Select_RadyabiMain().Tables[0].Rows[0]["EndAction"].ToString() == "True")
                    lblVaziat.Text = "خاتمه یافته";
                else
                    lblVaziat.Text = "درجریان";
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(txtIdRadyabi.Text.Trim()=="" || txtCodeKargah.Text.Trim()=="")
            {
                RadMessageBox.Show("کد ردیابی و کارگاه را تعیین نمایید");
                return;
            }
            Report objReport = new Report();
            objReport.Load(ClsPublic.strRepPath + "RadyabiReport.frx");
            objReport.SetParameterValue("@IdRadyabi", txtIdRadyabi.Text.Trim());
            objReport.SetParameterValue("@IdUnit", txtCodeKargah.Text.Trim());
            objReport.Show();
        }

        private void cmbProcNameKargah_SelectedValueChanged(object sender, EventArgs e)
        {
            ClsPlanning ObjPlanning = new ClsPlanning();
            if (cmbProcNameKargah.SelectedValue == null || cmbProcNameKargah.Text.ToString().Trim() == "System.Data.DataRowView")
                return;
            try
            {
                ObjPlanning.strIdUnit = cmbProcNameKargah.SelectedValue.ToString();
                txtCodeKargah.Text = ObjPlanning.strIdUnit;
                strIdUnit = ObjPlanning.strIdUnit; 
            }
            catch (System.NullReferenceException exp)
            {
                RadMessageBox.Show("کارگاه را انتخاب نمایید \n " + exp.Message);
            }
        }

        private void cmbProcNameKargah_TextChanged(object sender, EventArgs e)
        {
            ClsPlanning ObjPlanning = new ClsPlanning();
            txtCodeKargah.Clear();
            ObjPlanning.strIdUnit = "";
            strIdUnit = "";
        }

        private void FrmPLN_RadyabiBarname_Load(object sender, EventArgs e)
        {
            //----------------------------------------------------------------------kargah ( unit )
            ClsPlanning ObjPlanning = new ClsPlanning();
            cmbProcNameKargah.DataSource = ObjPlanning.SelectUnit().Tables[0];
            cmbProcNameKargah.ValueMember = "IdUnit";
            cmbProcNameKargah.DisplayMember = "onvan";
            cmbProcNameKargah.SelectedValue = null;
            cmbProcNameKargah.Text = "";
            txtCodeKargah.Clear();
        }
    }
}

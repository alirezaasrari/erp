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
    public partial class FrmPM_AddTask : Telerik.WinControls.UI.RadForm
    {
        public FrmPM_AddTask()
        {
            InitializeComponent();
        }
        ClsPM pm = new ClsPM();
        public string StrMachinCod, TimeDoService, MoreViewsIns, IdCalendar;
        private void FrmPM_AddTask_Load(object sender, EventArgs e)
        {
            this.txtTimeStart.DateTimePickerElement.CustomFormat = "HH:mm";
            this.txtTimeEnd.DateTimePickerElement.CustomFormat = "HH:mm";
            drpPersonel.DataSource = pm.selectPersonelUnit().Tables[0];
            drpPersonel.ValueMember = "ID_Personel";
            drpPersonel.DisplayMember = "NAME";
            drpPersonel.SelectedIndex = -1;
            dt1.Text = DateTime.Now.ToShortDateString();
            txtTimeStart.Text  = DateTime.Now.ToShortTimeString();
            lblMoreViewsIns.Text = MoreViewsIns;
            lblIdCalendar.Text = IdCalendar;
            TimeSpan t1 = new TimeSpan(txtTimeStart.Value.Hour, txtTimeStart.Value.Minute, 0);
            TimeSpan t2 = new TimeSpan(0, Convert.ToInt16(TimeDoService), 0);
            txtTimeEnd.Text = (t1 + t2).ToString();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            pm.IDCases = StrMachinCod;
            pm.DoTimeStart = txtTimeStart.Text;

            pm.DoTimeEnd = txtTimeEnd.Text;
            pm.DesTask = MoreViewsIns;
            pm.DateDoTask = dt1.Value.ToShortDateString();
            pm.IdCalendar = IdCalendar;
            pm.IDMojryInstrution = drpPersonel.SelectedValue.ToString();
            //DataTable dt =;
            if (pm.SelectValidateTime().Tables[0].Rows.Count == 0)
            {
              RadMessageBox.Show(pm.Insert_TaskAction());
              this.Close();
            }
            else 
            {
                RadMessageBox.Show("مجری در این تاریخ و زمان کاری را انجام داده است");
            }
            
        }
    }
}

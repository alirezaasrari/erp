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
    public partial class FrmPM_CalendarHoliday : Telerik.WinControls.UI.RadForm
    {
        public FrmPM_CalendarHoliday()
        {
            InitializeComponent();
        }

        private void btnYears_Click(object sender, EventArgs e)
        {
            pm.DateStart = dt1.Value.ToString().Substring(0, 10);
            pm.DateEnd = dt2.Value.ToString().Substring(0, 10);
            RadMessageBox.Show(pm.InsYareHolidayCalendar());
            grdDayHoliday.DataSource = pm.SelectHoliday().Tables[0];
        }

        ClsPM pm = new ClsPM();

        private void FrmPM_CalendarHoliday_Load(object sender, EventArgs e)
        {
            grdDayHoliday.DataSource = pm.SelectHoliday().Tables[0];
        }

        private void MasterTemplate_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (grdDayHoliday.CurrentRow.Index > -1)
            {
                pm.IdHoliday = grdDayHoliday.CurrentRow.Cells["IdHoliday"].Value.ToString();
                if (!Convert.ToBoolean(grdDayHoliday.CurrentRow.Cells["IsHoliday"].Value))
                    pm.IsHoliday = "1";
                else
                    pm.IsHoliday = "0";
                RadMessageBox.Show(pm.updatHoliday());
                grdDayHoliday.DataSource = pm.SelectHoliday().Tables[0];
            }
        }
    }
}
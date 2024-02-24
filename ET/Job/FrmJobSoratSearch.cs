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
    public partial class FrmJobSoratSearch : Telerik.WinControls.UI.RadForm
    {
        public FrmJobSoratSearch()
        {
            InitializeComponent();
        }

        private void FrmJobSoratSearch_Load(object sender, EventArgs e)
        {
            ClsJob objJob = new ClsJob();
            //objJob.ID_HSoratJ = stridTFather;
            GrdReqSJ.DataSource = objJob.SelectHSorat().Tables[0];
            ClsJob.GetID_HSoratJ = "";
            ClsJob.GetOnvanHSoratJ = "";
        }

        private void GrdReqSJ_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            ClsJob.GetID_HSoratJ = GrdReqSJ.Rows[e.RowIndex].Cells["ID_HSoratJ"].Value.ToString();
            ClsJob.GetOnvanHSoratJ = GrdReqSJ.Rows[e.RowIndex].Cells["OnvanHSoratJ"].Value.ToString();
            ClsJob.GetRaeesHSoratJ = GrdReqSJ.Rows[e.RowIndex].Cells["RaeesHSoratJ"].Value.ToString();
            ClsJob.GetDabirHSoratJ = GrdReqSJ.Rows[e.RowIndex].Cells["DabirHSoratJ"].Value.ToString();
            ClsJob.GetDateHSoratJ = GrdReqSJ.Rows[e.RowIndex].Cells["DateHSoratJ"].Value.ToString();
            ClsJob.GetNRaees = GrdReqSJ.Rows[e.RowIndex].Cells["NRaees"].Value.ToString();
            ClsJob.GetNDabir = GrdReqSJ.Rows[e.RowIndex].Cells["NDabir"].Value.ToString();
            Close();
        }

        private void GrdReqSJ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ClsJob.GetID_HSoratJ = GrdReqSJ.CurrentRow.Cells["ID_HSoratJ"].Value.ToString();
                ClsJob.GetOnvanHSoratJ = GrdReqSJ.CurrentRow.Cells["OnvanHSoratJ"].Value.ToString();
                ClsJob.GetRaeesHSoratJ = GrdReqSJ.CurrentRow.Cells["RaeesHSoratJ"].Value.ToString();
                ClsJob.GetDabirHSoratJ = GrdReqSJ.CurrentRow.Cells["DabirHSoratJ"].Value.ToString();
                ClsJob.GetDateHSoratJ = GrdReqSJ.CurrentRow.Cells["DateHSoratJ"].Value.ToString();
                        
            }
        }
    }
}

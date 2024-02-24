using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace ET
{
    public partial class Frm_Total : Telerik.WinControls.UI.RadForm
    {
        ClsBI BI = new ClsBI();
        public DataSet ds = new DataSet();
        Font myFont = new Font(new FontFamily("Calibri"), 12.0F, FontStyle.Bold);

        private void StyleCell(GridViewCellInfo cell)
        {
            //cell.Style.Font = myFont;
            cell.Style.CustomizeFill = true;
            //cell.Style.GradientStyle = GradientStyles.Solid;
            cell.Style.BackColor = Color.Beige;
        }

        //private void StyleCellFont(GridViewCellInfo cell)
        //{
        //    cell.Style.Font = myFont;
        //    cell.Style.CustomizeFill = true;
        //    cell.Style.GradientStyle = GradientStyles.Solid;
        //    //cell.Style.BackColor = Color.Beige;
        //}

        public Frm_Total()
        {
            InitializeComponent();
        }

        private void btnreport_Click(object sender, EventArgs e)
        {
            ClsMali clsmali = new ClsMali();

            ds = clsmali.selecttotal();

            //dgw.DataSource = ds.Tables[0];
            radgw.DataSource = ds.Tables[0];
            clsmali.clr_var();
            for (int i = 0; i <= radgw.Rows.Count - 1; i++)
            {
                this.StyleCell(this.radgw.Rows[i].Cells["type_report"]);
                this.StyleCell(this.radgw.Rows[i].Cells["mande203"]);
                this.StyleCell(this.radgw.Rows[i].Cells["mah2"]);
                this.StyleCell(this.radgw.Rows[i].Cells["mah4"]);
                this.StyleCell(this.radgw.Rows[i].Cells["mah6"]);
                this.StyleCell(this.radgw.Rows[i].Cells["mah8"]);
                this.StyleCell(this.radgw.Rows[i].Cells["mah10"]);
                this.StyleCell(this.radgw.Rows[i].Cells["mah12"]);
            }

            //for (int j = 0; j <= radgw.ColumnCount; j++)
            //{
            //    this.StyleCellFont(this.radgw.Rows[4].Cells[j]);
            //    this.StyleCellFont(this.radgw.Rows[10].Cells[j]);
            //    this.StyleCellFont(this.radgw.Rows[15].Cells[j]);
            //    this.StyleCellFont(this.radgw.Rows[20].Cells[j]);
            //    this.StyleCellFont(this.radgw.Rows[21].Cells[j]);
            //    this.StyleCellFont(this.radgw.Rows[22].Cells[j]);
            //    this.StyleCellFont(this.radgw.Rows[23].Cells[j]);
            //    this.StyleCellFont(this.radgw.Rows[24].Cells[j]);
            //    this.StyleCellFont(this.radgw.Rows[25].Cells[j]);
            //}

            radgw.Columns["mah1"].FormatString = "{0:#,###}";
            radgw.Columns["mah2"].FormatString = "{0:#,###}";
            radgw.Columns["mah3"].FormatString = "{0:#,###}"; 
            radgw.Columns["mah4"].FormatString = "{0:#,###}";
            radgw.Columns["mah5"].FormatString = "{0:#,###}"; 
            radgw.Columns["mah6"].FormatString = "{0:#,###}";
            radgw.Columns["mah7"].FormatString = "{0:#,###}"; 
            radgw.Columns["mah8"].FormatString = "{0:#,###}";
            radgw.Columns["mah9"].FormatString = "{0:#,###}";
            radgw.Columns["mah10"].FormatString = "{0:#,###}";
            radgw.Columns["mah11"].FormatString = "{0:#,###}";
            radgw.Columns["mah12"].FormatString = "{0:#,###}";
            radgw.Columns["mande203"].FormatString = "{0:#,###}";
            radgw.Columns["mande101"].FormatString = "{0:#,###}";
            radgw.Columns["kol"].FormatString = "{0:#,###}";
            
            
            //GridViewDataColumn ordibehesht = (GridViewDataColumn) this.radgw.Columns["mah2"];
            //ordibehesht.FormatString = "{0:#,###}";
        }

        private void btnExcell_Click(object sender, EventArgs e)
        {
            string[] str = new string[100];
            for (int i = 0; i < dgw.ColumnCount; i++)
            {             
                str[i] = dgw.Columns[i].HeaderText;
                //MessageBox.Show(dgw.Columns[i].HeaderText);
                //MessageBox.Show(str[i]);
            }

            //ExitExcel.ExitExcel ex = new ExitExcel.ExitExcel();
            //ex.Excel(ds, str);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radgw_Click(object sender, EventArgs e)
        {

        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls;

namespace ET
{
    public partial class Frm_Senni_Detail : Telerik.WinControls.UI.RadForm
    {
        public Frm_Senni_Detail()
        {
            InitializeComponent();
        }

        public ClsBI bi = new ClsBI();
        public DataSet ds = new DataSet();
        string strwhere;
        Font myFont = new Font(new FontFamily("Calibri"), 12.0F, FontStyle.Bold);

        private void StyleCell(GridViewCellInfo cell)
        {
           // cell.Style.Font = myFont;
            cell.Style.CustomizeFill = true;
            //cell.Style.GradientStyle = GradientStyles.Solid;
            cell.Style.BackColor = Color.Beige;
        }
       
        private void btnExcell_Click(object sender, EventArgs e)
        {            
            string[] str = new string[100];
            for (int i = 0; i < dgw.ColumnCount; i++)
            {
                str[i] = radgw.Columns[i].HeaderText;
                //MessageBox.Show(dgw.Columns[i].HeaderText);
                //MessageBox.Show(str[i]);
            }

            ExitExcel.ExitExcel ex = new ExitExcel.ExitExcel();
            ex.Excel(ds, str);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnreport_Click(object sender, EventArgs e)
        {

            if (chkMande.Checked == true)
            {
                ClsMali.Mande = 1;
            }
            else
            {
                ClsMali.Mande = 0;
            }

            if (chkMandebedehkar.Checked == true)
            {
                ClsMali.Mandebedehkar = 1;
            }
            else
            {
                ClsMali.Mandebedehkar = 0;
            }

            if (chkMandebestankar.Checked == true)
            {
                ClsMali.Mandebestankar = 1;
            }
            else
            {
                ClsMali.Mandebestankar = 0;
            }
             if (rdbtnTafsili.Checked == true)
             {
                 ClsMali.Tafsili = 1;
                 ClsMali.tafsilistart = txttafsilistart.Text;
                 ClsMali.tafsiliend = txttafsiliend.Text;
                 // strwhere = " AND C_Tafsili BETWEEN '" + txttafsilistart.Text + "' AND '" + txttafsiliend.Text + "' ";
             }
             else
             {
                 ClsMali.Tafsili = 0;
                 ClsMali.tafsilistart = "";
                 ClsMali.tafsiliend = "";
             }

             if (rdbtndolati.Checked == true)
             {
                 ClsMali.dolati = 1;
                 // strwhere = " AND  (IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=0 and IS_khadamat=0) ";
             }
             else
             {
                 ClsMali.dolati = 0;
             }

            if (rdbtnkhososi.Checked == true)
            {
                ClsMali.khososi = 1;
               // strwhere = " AND (IS_moshtari=1 AND IS_omomi=0 AND IS_Bazaryab=0 AND IS_Bestankardolati=0 and IS_khadamat=0) ";
            }
            else
            {
                ClsMali.khososi = 0;
            }

            if (rdbtnKhareji.Checked == true)
            {
                ClsMali.khareji = 1;
                //strwhere = " AND (IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=1 and IS_khadamat=0) ";
            }
            else
            {
                ClsMali.khareji = 0;
            }

            if (rdbtnMoshtarekin.Checked == true)
            {
                ClsMali.Moshtarekin = 1;
                // strwhere = " AND (IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=1 AND IS_Bestankardolati=0 and IS_khadamat=0) ";
            }
            else
            { 
                ClsMali.Moshtarekin = 0; 
            }

            if (rdbKhadamat.Checked == true)
            {
                ClsMali.KHadamat = 1;
                //strwhere = " AND (IS_moshtari=1 AND IS_omomi=0 AND IS_Bazaryab=0 AND IS_Bestankardolati=0 and IS_khadamat=1) ";
            }
            else
            { 
                ClsMali.KHadamat = 0;
            }

            if (chkmablaghbaze.Checked == true)
            {
                if ((txtMablaghstart.Text == "") || (txtMablaghend.Text == ""))
                {
                    Close();
                    ClsMali.mablaghbaze = 0;
                    ClsMali.Mablaghstart = "";
                    ClsMali.Mablaghend = "";
                    MessageBox.Show("لطفا مبلغ ابتدا و انتهای بازه را وارد نمایید");
                }
                else
                {
                    ClsMali.mablaghbaze = 1;
                    ClsMali.Mablaghstart = txtMablaghstart.Text;
                    ClsMali.Mablaghend = txtMablaghend.Text;
                }
            }
            else
            {
                ClsMali.mablaghbaze = 0;
                ClsMali.Mablaghstart = "";
                ClsMali.Mablaghend = "";
            }
            //------------------------------------------------------
            //if (chkTafsili.Checked == true)
            //{
            //    strwhere = strwhere + " AND C_Tafsili BETWEEN " + txttafsilistart.Text + " AND " + txttafsiliend.Text + " ";
            //}
           
            

            //bi.strQuery = strsql + strwhere;

            //ds = bi.SelectDB();

            ClsMali clsmali = new ClsMali();
            ds = clsmali.select_detial();

            //dgw.DataSource = ds.Tables[0];
            radgw.DataSource = ds.Tables[0];

            clsmali.clr_var();

            for (int i = 0; i <= radgw.Rows.Count - 1; i++)
            {
                this.StyleCell(this.radgw.Rows[i].Cells["C_Tafsili"]);
                this.StyleCell(this.radgw.Rows[i].Cells["N_Tafsili"]);
                this.StyleCell(this.radgw.Rows[i].Cells["forosh1"]);
                this.StyleCell(this.radgw.Rows[i].Cells["Bargasht1"]);
                this.StyleCell(this.radgw.Rows[i].Cells["variz1"]);
                this.StyleCell(this.radgw.Rows[i].Cells["check_pish1"]);
                this.StyleCell(this.radgw.Rows[i].Cells["esterdad203_1"]);
                this.StyleCell(this.radgw.Rows[i].Cells["forosh3"]);
                this.StyleCell(this.radgw.Rows[i].Cells["Bargasht3"]);
                this.StyleCell(this.radgw.Rows[i].Cells["variz3"]);
                this.StyleCell(this.radgw.Rows[i].Cells["check_pish3"]);
                this.StyleCell(this.radgw.Rows[i].Cells["esterdad203_3"]);
                this.StyleCell(this.radgw.Rows[i].Cells["forosh5"]);
                this.StyleCell(this.radgw.Rows[i].Cells["Bargasht5"]);
                this.StyleCell(this.radgw.Rows[i].Cells["variz5"]);
                this.StyleCell(this.radgw.Rows[i].Cells["check_pish5"]);
                this.StyleCell(this.radgw.Rows[i].Cells["esterdad203_5"]);
                this.StyleCell(this.radgw.Rows[i].Cells["forosh7"]);
                this.StyleCell(this.radgw.Rows[i].Cells["Bargasht7"]);
                this.StyleCell(this.radgw.Rows[i].Cells["variz7"]);
                this.StyleCell(this.radgw.Rows[i].Cells["check_pish7"]);
                this.StyleCell(this.radgw.Rows[i].Cells["esterdad203_7"]);
                this.StyleCell(this.radgw.Rows[i].Cells["forosh9"]);
                this.StyleCell(this.radgw.Rows[i].Cells["Bargasht9"]);
                this.StyleCell(this.radgw.Rows[i].Cells["variz9"]);
                this.StyleCell(this.radgw.Rows[i].Cells["check_pish9"]);
                this.StyleCell(this.radgw.Rows[i].Cells["esterdad203_9"]);
                this.StyleCell(this.radgw.Rows[i].Cells["forosh11"]);
                this.StyleCell(this.radgw.Rows[i].Cells["Bargasht11"]);
                this.StyleCell(this.radgw.Rows[i].Cells["variz11"]);
                this.StyleCell(this.radgw.Rows[i].Cells["check_pish11"]);
                this.StyleCell(this.radgw.Rows[i].Cells["esterdad203_11"]);
                this.StyleCell(this.radgw.Rows[i].Cells["mande_kol"]);
            }

            GridViewDataColumn discount = (GridViewDataColumn)this.radgw.Columns["forosh1"];
            //discount.FormatString = "0#,0";
            radgw.Columns["forosh1"].FormatString = "{0:#,###}";
            radgw.Columns["Bargasht1"].FormatString = "{0:#,###}";
            radgw.Columns["variz1"].FormatString = "{0:#,###}";
            radgw.Columns["check_pish1"].FormatString = "{0:#,###}";
            radgw.Columns["esterdad203_1"].FormatString = "{0:#,###}";
            radgw.Columns["forosh2"].FormatString = "{0:#,###}";
            radgw.Columns["Bargasht2"].FormatString = "{0:#,###}";
            radgw.Columns["variz2"].FormatString = "{0:#,###}";
            radgw.Columns["check_pish2"].FormatString = "{0:#,###}";
            radgw.Columns["esterdad203_2"].FormatString = "{0:#,###}";
            radgw.Columns["forosh3"].FormatString = "{0:#,###}";
            radgw.Columns["Bargasht3"].FormatString = "{0:#,###}";
            radgw.Columns["variz3"].FormatString = "{0:#,###}";
            radgw.Columns["check_pish3"].FormatString = "{0:#,###}";
            radgw.Columns["esterdad203_3"].FormatString = "{0:#,###}";
            radgw.Columns["forosh4"].FormatString = "{0:#,###}";
            radgw.Columns["Bargasht4"].FormatString = "{0:#,###}";
            radgw.Columns["variz4"].FormatString = "{0:#,###}";
            radgw.Columns["check_pish4"].FormatString = "{0:#,###}";
            radgw.Columns["esterdad203_4"].FormatString = "{0:#,###}";
            radgw.Columns["forosh5"].FormatString = "{0:#,###}";
            radgw.Columns["Bargasht5"].FormatString = "{0:#,###}";
            radgw.Columns["variz5"].FormatString = "{0:#,###}";
            radgw.Columns["check_pish5"].FormatString = "{0:#,###}";
            radgw.Columns["esterdad203_5"].FormatString = "{0:#,###}";
            radgw.Columns["forosh6"].FormatString = "{0:#,###}";
            radgw.Columns["Bargasht6"].FormatString = "{0:#,###}";
            radgw.Columns["variz6"].FormatString = "{0:#,###}";
            radgw.Columns["check_pish6"].FormatString = "{0:#,###}";
            radgw.Columns["esterdad203_6"].FormatString = "{0:#,###}";
            radgw.Columns["forosh7"].FormatString = "{0:#,###}";
            radgw.Columns["Bargasht7"].FormatString = "{0:#,###}";
            radgw.Columns["variz7"].FormatString = "{0:#,###}";
            radgw.Columns["check_pish7"].FormatString = "{0:#,###}";
            radgw.Columns["esterdad203_7"].FormatString = "{0:#,###}";
            radgw.Columns["forosh8"].FormatString = "{0:#,###}";
            radgw.Columns["Bargasht8"].FormatString = "{0:#,###}";
            radgw.Columns["variz8"].FormatString = "{0:#,###}";
            radgw.Columns["check_pish8"].FormatString = "{0:#,###}";
            radgw.Columns["esterdad203_8"].FormatString = "{0:#,###}";
            radgw.Columns["forosh9"].FormatString = "{0:#,###}";
            radgw.Columns["Bargasht9"].FormatString = "{0:#,###}";
            radgw.Columns["variz9"].FormatString = "{0:#,###}";
            radgw.Columns["check_pish9"].FormatString = "{0:#,###}";
            radgw.Columns["esterdad203_9"].FormatString = "{0:#,###}";
            radgw.Columns["forosh10"].FormatString = "{0:#,###}";
            radgw.Columns["Bargasht10"].FormatString = "{0:#,###}";
            radgw.Columns["variz10"].FormatString = "{0:#,###}";
            radgw.Columns["check_pish10"].FormatString = "{0:#,###}";
            radgw.Columns["esterdad203_10"].FormatString = "{0:#,###}";
            radgw.Columns["forosh11"].FormatString = "{0:#,###}";
            radgw.Columns["Bargasht11"].FormatString = "{0:#,###}";
            radgw.Columns["variz11"].FormatString = "{0:#,###}";
            radgw.Columns["check_pish11"].FormatString = "{0:#,###}";
            radgw.Columns["esterdad203_11"].FormatString = "{0:#,###}";
            radgw.Columns["forosh12"].FormatString = "{0:#,###}";
            radgw.Columns["Bargasht12"].FormatString = "{0:#,###}";
            radgw.Columns["variz12"].FormatString = "{0:#,###}";
            radgw.Columns["check_pish12"].FormatString = "{0:#,###}";
            radgw.Columns["esterdad203_12"].FormatString = "{0:#,###}";
            radgw.Columns["mande_kol"].FormatString = "{0:#,###}";
        }

        private void FrmDetail_Load(object sender, EventArgs e)
        {
            clr();

            ColumnGroupsViewDefinition view = new ColumnGroupsViewDefinition();
            
            view.ColumnGroups.Add(new GridViewColumnGroup(""));
            view.ColumnGroups.Add(new GridViewColumnGroup("فروردین"));
            view.ColumnGroups.Add(new GridViewColumnGroup("اردیبهشت"));
            view.ColumnGroups.Add(new GridViewColumnGroup("خرداد"));
            view.ColumnGroups.Add(new GridViewColumnGroup("تیر"));
            view.ColumnGroups.Add(new GridViewColumnGroup("مرداد"));
            view.ColumnGroups.Add(new GridViewColumnGroup("شهریور"));
            view.ColumnGroups.Add(new GridViewColumnGroup("مهر"));
            view.ColumnGroups.Add(new GridViewColumnGroup("آبان"));
            view.ColumnGroups.Add(new GridViewColumnGroup("آذر"));
            view.ColumnGroups.Add(new GridViewColumnGroup("دی"));
            view.ColumnGroups.Add(new GridViewColumnGroup("بهمن"));
            view.ColumnGroups.Add(new GridViewColumnGroup("اسفند"));
            view.ColumnGroups.Add(new GridViewColumnGroup(""));

            view.ColumnGroups[0].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[0].Rows[0].Columns.Add(this.radgw.Columns["radif"]);
            view.ColumnGroups[0].Rows[0].Columns.Add(this.radgw.Columns["C_Tafsili"]);
            view.ColumnGroups[0].Rows[0].Columns.Add(this.radgw.Columns["N_Tafsili"]);
            view.ColumnGroups[0].Rows[0].Columns.Add(this.radgw.Columns["mande_aval_101"]);
            view.ColumnGroups[0].Rows[0].Columns.Add(this.radgw.Columns["mande_aval_203"]);

            view.ColumnGroups[1].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[1].Rows[0].Columns.Add(this.radgw.Columns["forosh1"]);
            view.ColumnGroups[1].Rows[0].Columns.Add(this.radgw.Columns["Bargasht1"]);
            view.ColumnGroups[1].Rows[0].Columns.Add(this.radgw.Columns["variz1"]);
            view.ColumnGroups[1].Rows[0].Columns.Add(this.radgw.Columns["check_pish1"]);
            view.ColumnGroups[1].Rows[0].Columns.Add(this.radgw.Columns["esterdad203_1"]);

            view.ColumnGroups[2].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[2].Rows[0].Columns.Add(this.radgw.Columns["forosh2"]);
            view.ColumnGroups[2].Rows[0].Columns.Add(this.radgw.Columns["Bargasht2"]);
            view.ColumnGroups[2].Rows[0].Columns.Add(this.radgw.Columns["variz2"]);
            view.ColumnGroups[2].Rows[0].Columns.Add(this.radgw.Columns["check_pish2"]);
            view.ColumnGroups[2].Rows[0].Columns.Add(this.radgw.Columns["esterdad203_2"]);

            view.ColumnGroups[3].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[3].Rows[0].Columns.Add(this.radgw.Columns["forosh3"]);
            view.ColumnGroups[3].Rows[0].Columns.Add(this.radgw.Columns["Bargasht3"]);
            view.ColumnGroups[3].Rows[0].Columns.Add(this.radgw.Columns["variz3"]);
            view.ColumnGroups[3].Rows[0].Columns.Add(this.radgw.Columns["check_pish3"]);
            view.ColumnGroups[3].Rows[0].Columns.Add(this.radgw.Columns["esterdad203_3"]);

            view.ColumnGroups[4].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[4].Rows[0].Columns.Add(this.radgw.Columns["forosh4"]);
            view.ColumnGroups[4].Rows[0].Columns.Add(this.radgw.Columns["Bargasht4"]);
            view.ColumnGroups[4].Rows[0].Columns.Add(this.radgw.Columns["variz4"]);
            view.ColumnGroups[4].Rows[0].Columns.Add(this.radgw.Columns["check_pish4"]);
            view.ColumnGroups[4].Rows[0].Columns.Add(this.radgw.Columns["esterdad203_4"]);

            view.ColumnGroups[5].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[5].Rows[0].Columns.Add(this.radgw.Columns["forosh5"]);
            view.ColumnGroups[5].Rows[0].Columns.Add(this.radgw.Columns["Bargasht5"]);
            view.ColumnGroups[5].Rows[0].Columns.Add(this.radgw.Columns["variz5"]);
            view.ColumnGroups[5].Rows[0].Columns.Add(this.radgw.Columns["check_pish5"]);
            view.ColumnGroups[5].Rows[0].Columns.Add(this.radgw.Columns["esterdad203_5"]);

            view.ColumnGroups[6].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[6].Rows[0].Columns.Add(this.radgw.Columns["forosh6"]);
            view.ColumnGroups[6].Rows[0].Columns.Add(this.radgw.Columns["Bargasht6"]);
            view.ColumnGroups[6].Rows[0].Columns.Add(this.radgw.Columns["variz6"]);
            view.ColumnGroups[6].Rows[0].Columns.Add(this.radgw.Columns["check_pish6"]);
            view.ColumnGroups[6].Rows[0].Columns.Add(this.radgw.Columns["esterdad203_6"]);

            view.ColumnGroups[7].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[7].Rows[0].Columns.Add(this.radgw.Columns["forosh7"]);
            view.ColumnGroups[7].Rows[0].Columns.Add(this.radgw.Columns["Bargasht7"]);
            view.ColumnGroups[7].Rows[0].Columns.Add(this.radgw.Columns["variz7"]);
            view.ColumnGroups[7].Rows[0].Columns.Add(this.radgw.Columns["check_pish7"]);
            view.ColumnGroups[7].Rows[0].Columns.Add(this.radgw.Columns["esterdad203_7"]);

            view.ColumnGroups[8].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[8].Rows[0].Columns.Add(this.radgw.Columns["forosh8"]);
            view.ColumnGroups[8].Rows[0].Columns.Add(this.radgw.Columns["Bargasht8"]);
            view.ColumnGroups[8].Rows[0].Columns.Add(this.radgw.Columns["variz8"]);
            view.ColumnGroups[8].Rows[0].Columns.Add(this.radgw.Columns["check_pish8"]);
            view.ColumnGroups[8].Rows[0].Columns.Add(this.radgw.Columns["esterdad203_8"]);

            view.ColumnGroups[9].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[9].Rows[0].Columns.Add(this.radgw.Columns["forosh9"]);
            view.ColumnGroups[9].Rows[0].Columns.Add(this.radgw.Columns["Bargasht9"]);
            view.ColumnGroups[9].Rows[0].Columns.Add(this.radgw.Columns["variz9"]);
            view.ColumnGroups[9].Rows[0].Columns.Add(this.radgw.Columns["check_pish9"]);
            view.ColumnGroups[9].Rows[0].Columns.Add(this.radgw.Columns["esterdad203_9"]);

            view.ColumnGroups[10].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[10].Rows[0].Columns.Add(this.radgw.Columns["forosh10"]);
            view.ColumnGroups[10].Rows[0].Columns.Add(this.radgw.Columns["Bargasht10"]);
            view.ColumnGroups[10].Rows[0].Columns.Add(this.radgw.Columns["variz10"]);
            view.ColumnGroups[10].Rows[0].Columns.Add(this.radgw.Columns["check_pish10"]);
            view.ColumnGroups[10].Rows[0].Columns.Add(this.radgw.Columns["esterdad203_10"]);

            view.ColumnGroups[11].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[11].Rows[0].Columns.Add(this.radgw.Columns["forosh11"]);
            view.ColumnGroups[11].Rows[0].Columns.Add(this.radgw.Columns["Bargasht11"]);
            view.ColumnGroups[11].Rows[0].Columns.Add(this.radgw.Columns["variz11"]);
            view.ColumnGroups[11].Rows[0].Columns.Add(this.radgw.Columns["check_pish11"]);
            view.ColumnGroups[11].Rows[0].Columns.Add(this.radgw.Columns["esterdad203_11"]);

            view.ColumnGroups[12].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[12].Rows[0].Columns.Add(this.radgw.Columns["forosh12"]);
            view.ColumnGroups[12].Rows[0].Columns.Add(this.radgw.Columns["Bargasht12"]);
            view.ColumnGroups[12].Rows[0].Columns.Add(this.radgw.Columns["variz12"]);
            view.ColumnGroups[12].Rows[0].Columns.Add(this.radgw.Columns["check_pish12"]);
            view.ColumnGroups[12].Rows[0].Columns.Add(this.radgw.Columns["esterdad203_12"]);

            view.ColumnGroups[13].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[13].Rows[0].Columns.Add(this.radgw.Columns["mande_kol"]);

            radgw.ViewDefinition = view;

          
        }

        private void chkTafsili_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnTafsili.Checked == true)
            {
                txttafsilistart.Enabled = true;
                txttafsiliend.Enabled = true;
            }

            if (rdbtnTafsili.Checked == false)
            {
                txttafsilistart.Enabled = false;
                txttafsiliend.Enabled = false;
            }
        }

        private void FRM_SenniDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClsMali.Tafsili = 0;
            ClsMali.Mande = 0;
            ClsMali.Mandebedehkar = 0;
            ClsMali.Mandebestankar = 0;
            ClsMali.mablaghbaze = 0;
            ClsMali.khososi = 0;
            ClsMali.khareji = 0;
            ClsMali.nmoshtarekin = 0;
            ClsMali.KHadamat = 0;
            ClsMali.Moshtarekin = 0;
            ClsMali.Bazeforosh = 0;
            ClsMali.Mandepasazkasr = 0;
            ClsMali.all = 0;

            ClsMali.tafsilistart = "";
            ClsMali.tafsiliend = "";
            ClsMali.Mablaghstart = "";
            ClsMali.Mablaghend = "";
            ClsMali.start_date = "";
            ClsMali.end_date = "";
            clr();
        }

        private void txttafsilistart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                Frm_Tafsili frt = new Frm_Tafsili();
                frt.ShowDialog();
                txttafsilistart.Text = Frm_Tafsili.CTafsili;
                Frm_Tafsili.CTafsili = "";
            }
            if (e.KeyCode == Keys.Enter)
            {
                txttafsiliend.Focus();
            }

        }

        private void txttafsiliend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                Frm_Tafsili frt = new Frm_Tafsili();
                frt.ShowDialog();
                txttafsiliend.Text = Frm_Tafsili.CTafsili;
                Frm_Tafsili.CTafsili = "";                    
            }

            if (e.KeyCode==Keys.Enter)
            {
                btnreport.Focus();
            }
        }

        private void clr()
        {
            rdbtnTafsili.Checked = false;

            rdbtndolati.Checked = false;
            rdbtnKhareji.Checked = false;
            rdbtnkhososi.Checked = false;
            rdbtnkol.Checked = false;
            rdbtnMoshtarekin.Checked = false;

            txttafsiliend.Clear();
            txttafsiliend.Enabled = false;
            txttafsilistart.Clear();
            txttafsilistart.Enabled = false;

        }

        private void rdbtnTafsili_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnTafsili.Checked == true)
            {
                txttafsilistart.Enabled = true;
                txttafsiliend.Enabled = true;
            }

            if (rdbtnTafsili.Checked == false)
            {
                txttafsilistart.Enabled = false;
                txttafsiliend.Enabled = false;
            }
        }

        private void chkMande_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkmablaghbaze_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkMandebedehkar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkMandebestankar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radgw_Click(object sender, EventArgs e)
        {

        }



    }
}

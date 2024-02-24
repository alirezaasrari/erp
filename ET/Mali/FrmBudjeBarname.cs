using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.SqlClient;

namespace ET
{
    public partial class FrmBudjeBarname : Telerik.WinControls.UI.RadForm
    {
        public FrmBudjeBarname()
        {
            InitializeComponent();
        }
        public DataSet DS = new DataSet();
        ////public DataSet DSC;
        //public SqlConnection Connect = new SqlConnection();
        //public SqlDataAdapter Da;
        //public SqlCommandBuilder cb;
        //public ClsConnect Clsconnect = new ClsConnect();
        ClsMali objMali = new ClsMali();
        private void GrdBudje_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnAddBudje_Click(object sender, EventArgs e)
        {
            
           // RadMessageBox.Show( objMali.updateGrid(DS));
           
             
            //Connect.Close();
            
            try
            {
                //cb = new SqlCommandBuilder(Da);
                
                //Da.Update(DS);
                
                if (GrdBudje.CurrentRow.Index + 1 == GrdBudje.Rows.Count)
                {
                    GrdBudje.CurrentRow = GrdBudje.Rows[GrdBudje.CurrentRow.Index - 1];
                    GrdBudje.CurrentRow = GrdBudje.Rows[GrdBudje.CurrentRow.Index + 1];
                }
                else
                {
                    GrdBudje.CurrentRow = GrdBudje.Rows[GrdBudje.CurrentRow.Index + 1];
                    GrdBudje.CurrentRow = GrdBudje.Rows[GrdBudje.CurrentRow.Index - 1];
                }
                
                objMali.updateGrid(DS);
                DS.AcceptChanges();
                
                RadMessageBox.Show("عملیات با موفقیت انجام شد");
                GrdBudje.DataSource = null;
                GrdBudje.DataSource = DS.Tables[0];

                
               ////GrdBudje.DataBindingComplete();
               ////DSC = DS.GetChanges();
               ////if (DSC != null)
               //// {
               ////     Da.Update(DSC);
               ////     RadMessageBox.Show("عملیات با موفقیت انجام شد");
               //// }
                
               ////cb.DataAdapter = Da;
               ////Da.UpdateCommand = cb.GetUpdateCommand();
               //// Da.Update(DS);
               //// Connect.Close();
               ////RadMessageBox.Show("عملیات با موفقیت انجام شد");
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message + "خطا در اجرای عملیات");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //string strWhere = " WHERE 1 = 1 ";

            //strWhere += " and BudjeYear ='" + txtYear.Text.Trim() + "'"
            //               + "  ";

            //string StrQuery = " SELECT   FK_ID_DType ,typeHdName, BudjeYear, date_insert                      "
            //          + "     , M_B1  , M_V1, M_B2, M_V2, M_B3, M_V3, M_B4, M_V4, M_B5, M_V5, M_B6, M_V6,     "
            //          + "      M_B7, M_V7, M_B8, M_V8, M_B9, M_V9, M_B10, M_V10, M_B11, M_V11, M_B12, M_V12   "
            //          + "   FROM            Budje_TblDHesabMeghdar                "

            //          + strWhere
            //          + " ";
            

            DS = objMali.SelectBudje(txtYear.Text.Trim());
            ////Da.SelectCommand = new SqlCommand(StrQuery, Connect);
            ////Da.SelectCommand.CommandText = StrQuery;
            ////Da.SelectCommand.Connection = Connect;


            //Da= new SqlDataAdapter(StrQuery, Connect);
            //DS.Clear();
            //Da.Fill(DS);
            
            GrdBudje.DataSource = null;
            GrdBudje.DataSource = DS.Tables[0];
        }

        private void FrmBudjeBarname_Load(object sender, EventArgs e)
        { 
           
            //Connect.ConnectionString = Clsconnect.Connect; 
            //Connect.Open();
            ////Da.SelectCommand.Connection = Connect;
                     
            ////cb.DataAdapter = Da;
        }
    }
}

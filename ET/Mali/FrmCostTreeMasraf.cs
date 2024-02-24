using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.IO;
using Telerik.WinControls.UI.Export;
using System.Diagnostics;

namespace ET
{
    public partial class FrmCostTreeMasraf : Telerik.WinControls.UI.RadForm
    {
        public FrmCostTreeMasraf()
        {
            InitializeComponent();
        }
        ClsTakvin objTakvin = new ClsTakvin();
        ClsMali objMali = new ClsMali();
        public string IDTreeLocal, id_GhetehLocal, strId_GhetehDtl, id_GhetehRoot,idRootTree, StrID_BOM;
        
        
        private void SearchTree()   // ----------------------------------search tree
        {

            this.trMahsul.DataSource = null;
            objMali.strFdateResid = dtpFdateResid.Value.ToString().Substring(0, 10);
            objMali.strLdateResid = dtpLdateResid.Value.ToString().Substring(0, 10);
            DataTable dtselectTree = objMali.selectTreeMasraf().Tables[0];
            if (dtselectTree.Rows.Count == 0)
            {
                RadMessageBox.Show("این درخت وجود ندارد");
                 return;
            }
            //btnAddRootTree.Enabled = false;
            this.trMahsul.TreeViewElement.AllowAlternatingRowColor = true;
            this.trMahsul.DataSource = dtselectTree;
            this.trMahsul.DisplayMember = "nodeName";//"node_name";
            this.trMahsul.ParentMember = "idparentTree";//"parent_name";
            this.trMahsul.ChildMember = "idNodeTree";//"node";
            this.trMahsul.ValueMember = "idNodeTree";
            this.trMahsul.ExpandAll();
            txtFaniNoKala.Text = dtselectTree.Rows[0]["RootFaniNo"].ToString();
            txtCkala.Text = dtselectTree.Rows[0]["RootGhetehCode"].ToString();
            txtNKala.Text = dtselectTree.Rows[0]["RootGheteName"].ToString();
            txtCAnbar.Text = dtselectTree.Rows[0]["RootGhetehAnbar"].ToString();
            id_GhetehRoot = dtselectTree.Rows[0]["Rootid_Gheteh"].ToString();
            objMali.id_GhetehRoot = id_GhetehRoot;
            idRootTree = dtselectTree.Rows[0]["idRootTree"].ToString(); 
            objMali.idRootTree = idRootTree;
            //--------------------------------------------show moshakhasat fani gheteh
            grdGhetehTree.DataSource = dtselectTree;
            //-----------------------------------------------process
            grdProcGheteh.DataSource = null;
            grdProcGheteh.DataSource = objMali.SelectProcessGhetehMasraf("1").Tables[0];
            //--------------------------------------------------motealeghat
            grdMotealeghat.DataSource = null;
            grdMotealeghat.DataSource = objMali.SelectMotealegatMasraf("1", "0").Tables[0];
            
            //----------------------------------------------------BOM

            GrdBomGheteh.DataSource = objMali.SelectBom("1", "0", "1", "0").Tables[0];
            grdBomDTemp.DataSource = objMali.SelectBomGhetehMasraf("1", "0", "1", "0").Tables[0];
            //-------------------------------------------------------Bastebandi
            grdBasteh.DataSource = objMali.SelectGhetehBastehMasraf().Tables[0];

            //--------------------------------------------------------------------------------Cost Tree
            DataRow drSelectCostTreeMasraf = objMali.SelectCostTreeMasraf().Tables[0].Rows[0];
            txtpriceNodeoutsource.Text = drSelectCostTreeMasraf["priceNodeoutsource"].ToString();
            txtpriceNodeTarkib.Text = drSelectCostTreeMasraf["priceNodeTarkib"].ToString();
            txtpriceoutsourceing.Text = drSelectCostTreeMasraf["priceoutsourceing"].ToString();
            txtpriceNodeKharid.Text = drSelectCostTreeMasraf["priceNodeKharid"].ToString();
            txtpriceNodeMavad.Text = drSelectCostTreeMasraf["priceNodeMavad"].ToString();
            txtpricekharidari.Text = drSelectCostTreeMasraf["pricekharidari"].ToString();
            txtpriceSarbarNode.Text = drSelectCostTreeMasraf["priceSarbarNode"].ToString();
            txtpriceDastmozdNode.Text = drSelectCostTreeMasraf["priceDastmozdNode"].ToString();
            txtpriceTolidi.Text = drSelectCostTreeMasraf["priceTolidi"].ToString();
            txtPriceTree.Text = drSelectCostTreeMasraf["PriceTree"].ToString();
            txtPriceBasteh.Text = drSelectCostTreeMasraf["priceBasteh"].ToString();
            txtSarbarbasteh.Text = drSelectCostTreeMasraf["Sarbarbasteh"].ToString();
            txtDastmozdbasteh.Text = drSelectCostTreeMasraf["Dastmozdbasteh"].ToString();
            txtpriceKolBasteh.Text = drSelectCostTreeMasraf["priceKolBasteh"].ToString();
            txtPriceTreeBaste.Text = drSelectCostTreeMasraf["PriceTreeBaste"].ToString();
            //radMaskedEditBox1.Text = drSelectCostTree["PriceTree"].ToString();

        }
        private void ClearSelectNode()
        {
            
            //----------------------------------------Node Tree
            IDTreeLocal = "";
            objTakvin.IDTree = "";
            


            //ClearGhetehNode();

            //----------------------------------process
            txtProcNodeAnbar.Clear();
            txtProcNodeCode.Clear();
            txtProcNodeFaniNo.Clear();
            txtProcNodeName.Clear();





        }
        //private void ClearGhetehNode()
        private void ClearGhetehNode()
        {
            //---------------------------------------------node gheteh
            
            id_GhetehLocal = "";
            objTakvin.id_Gheteh = "";

            
            
           
            
        }
        
        private void ClearProcess( )
        {
            
            strId_GhetehDtl = "";
            objTakvin.strProcid_GhetehDtl = "";
            //-------------------------------------------------------------Motealegat
            grdMotealeghat.DataSource = null;
            grdProcGheteh.DataSource = null;
            //grdMotealeghat.DataSource = objTakvin.SelectMotealegat().Tables[0];
           
            //--------------------------------------------------------------------BOM
            ClearBomGheteh();
            //---------------------------------------------------------------------
            
            

        }
        private void ClearBasteh()
        {
           
            objTakvin.StrBastehCode = "";
            
        }
        public void ClearBomGheteh()
        {
            
            StrID_BOM = "";
            objTakvin.StrID_Bom = "";
            

            GrdBomGheteh.DataSource = null;
            grdBomDTemp.DataSource = null;

            

        }
        private void GetProcessGheteh()
        {
            //if (txtProcCodeGH.Text.Trim() == "")
            //{
            //    RadMessageBox.Show("کد کالا را با انتخاب فرآیند تعیین نمایید ");
            //    return;
            //}
            //objTakvin.strProcCodeGH = txtProcCodeGH.Text.Trim();
            DataTable dtSearchProcessGheteh = objTakvin.SearchProcessGheteh().Tables[0];
            ClearProcess();
            if (dtSearchProcessGheteh.Rows.Count == 0)
            {
                return;
            }
            
            //--------------------------------------------------------------------get parameter
            strId_GhetehDtl = dtSearchProcessGheteh.Rows[0]["id_Gheteh"].ToString();
            
        }
        
        private void txtCkala_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmKala frmK = new FrmKala();
                frmK.strC_Anbar = "14";
                frmK.ShowDialog();
                txtCkala.Text = (!string.IsNullOrEmpty(ClsPublic.C_kala) ? ClsPublic.C_kala : txtCkala.Text.Trim());
                txtNKala.Text =  (!string.IsNullOrEmpty(ClsPublic.N_kala) ? ClsPublic.N_kala : txtNKala.Text.Trim());
                txtCAnbar.Text = (!string.IsNullOrEmpty(ClsPublic.C_Anbar) ? ClsPublic.C_Anbar : txtCAnbar.Text.Trim());

                //txtCkala.ReadOnly = (!string.IsNullOrEmpty(ClsPublic.C_kala) ? true : false);
                //txtNKala.ReadOnly = (!string.IsNullOrEmpty(ClsPublic.N_kala) ? true : false);
               
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ClsTakvin objTakvin = new ClsTakvin();
                objTakvin.strCKala = txtCkala.Text.Trim();
                objTakvin.strFaniNoKala = txtFaniNoKala.Text.Trim();
                
                if (objTakvin.Select_TreeTaeed().Tables[0].Rows[0]["Plani"].ToString() == "1")
                {
                    lblTaeedDesign.Text = " درخت تایید شده است";

                }
                else lblTaeedDesign.Text = "عدم تایید درخت";

                if (txtFaniNoKala.Text.Trim() == "" && txtCkala.Text.Trim() == "")
                {
                    RadMessageBox.Show("لطفا کد کالا و یا شماره فنی را وارد کنید");
                    return;
                }
                objMali.strFaniNoKala = txtFaniNoKala.Text.Trim();
                objMali.strCKala = txtCkala.Text.Trim();
                
                //objTakvin.strCAnbar = txtCAnbar.Text;
                //txtNKala.ReadOnly = (!string.IsNullOrEmpty(ClsPublic.N_kala) ? true : false);
                grdBasteh.DataSource = null;
                ClearSelectNode();
                ClearGhetehNode();
                SearchTree();
                
            }
            catch (Exception exp)
            {
                RadMessageBox.Show("خطا در اجرای عملیات \n" + exp.Message);
            }
        }
 
        private void txtNodeCode_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F2)
            //{
            //    FrmKala frmK = new FrmKala();
            //    frmK.ShowDialog();
            //    txtNodeCode.Text = (!string.IsNullOrEmpty(ClsPublic.C_kala) ? ClsPublic.C_kala : txtNodeCode.Text.Trim());
            //    txtNodeName.Text = (!string.IsNullOrEmpty(ClsPublic.N_kala) ? ClsPublic.N_kala : txtNodeName.Text.Trim());
            //    txtNodeCAnbar.Text = (!string.IsNullOrEmpty(ClsPublic.C_Anbar) ? ClsPublic.C_Anbar : txtNodeCAnbar.Text.Trim());
            //}
        }

        private void trMahsul_NodeMouseDoubleClick(object sender, Telerik.WinControls.UI.RadTreeViewEventArgs e)
        {
            
            ClearSelectNode();
            ClearGhetehNode();
            ClearProcess();

            IDTreeLocal = trMahsul.SelectedNode.Value.ToString();
            objMali.IDTree = IDTreeLocal;

            DataRow drselectNodeTree = objMali.selectNodeTree().Tables[0].Rows[0];
            id_GhetehLocal = drselectNodeTree["id_Gheteh"].ToString();

            objMali.id_Gheteh = id_GhetehLocal;
            
            //----------------------------------------------------------show fani gheteh

            DataRow drselectNodeGheteh = objMali.selectNodeGheteh().Tables[0].Rows[0];

            
            
            //  -------------------------------------------------------------------------------show Process gheteh
            txtProcNodeFaniNo.Text = drselectNodeGheteh["FaniNO"].ToString();
            txtProcNodeCode.Text = drselectNodeGheteh["GhetehCode"].ToString();
            txtProcNodeAnbar.Text = drselectNodeGheteh["GhetehAnbar"].ToString();
            txtProcNodeName.Text = drselectNodeGheteh["GheteName"].ToString();

            objMali.idRootTree = idRootTree;
            //---------------------------------------------------------process
            grdProcGheteh.DataSource = null;
            grdProcGheteh.DataSource = objMali.SelectProcessGhetehMasraf("0").Tables[0];
            //--------------------------------------------------------motealeghat
            grdMotealeghat.DataSource = null;
            grdMotealeghat.DataSource = objMali.SelectMotealegat("0", "1").Tables[0];
            //----------------------------------------------------BOM

            GrdBomGheteh.DataSource = objMali.SelectBom("1", "0", "0", "1").Tables[0];
            grdBomDTemp.DataSource = objMali.SelectBomGhetehMasraf("1", "0", "0", "1").Tables[0];
            

        }
        
        private void btnAddRootTree_Click(object sender, EventArgs e)
        {
           // try
           // {

            
           // string strCheckTree;
           // if (txtFaniNoKala.Text.Trim() == "")
           // {
           //     RadMessageBox.Show("کد فنی درخت را تعیین نمایید");
           //     return;
           // }
           // if (txtCkala.Text.Trim() == "" || txtCkala.Text.Trim() == "0" || txtCAnbar.Text.Trim() == "" || txtCAnbar.Text.Trim() == "0")
           // {
           //     RadMessageBox.Show("کد کالا  یا انبار را وارد نمایید");
           //     return;
           // }
           // if (txtNKala.Text.Trim() == "")
           // {
           //     RadMessageBox.Show("نام درخت را وارد نمایید");
           //     return;
           // }
           // objTakvin.strFaniNoKala = txtFaniNoKala.Text.Trim();
           // objTakvin.strCKala =(!string.IsNullOrEmpty(txtCkala.Text.Trim())?txtCkala.Text.Trim():"0");
           // objTakvin.strNKala = txtNKala.Text.Trim();
           // objTakvin.strCAnbar = (!string.IsNullOrEmpty(txtCAnbar.Text.Trim()) ? txtCAnbar.Text.Trim() : "0");

           // strCheckTree = objTakvin.CheckTree();
           // if (strCheckTree == "FaniNO")
           // {
           //     RadMessageBox.Show(" درخت با این کد فنی وجود دارد");
           //     return;
           // }
           // else if (strCheckTree == "RootCode")
           // {
           //     RadMessageBox.Show(" درخت با این کد کالا وجود دارد");
           //     return;
           // }
           // else if (strCheckTree == "RootName")
           // {
           //     RadMessageBox.Show(" درخت با این نام وجود دارد");
           //     return;
           // }
           // RadMessageBox.Show(objTakvin.InsRootTree());
           // ClearSelectNode();
           // ClearGhetehNode();
           // SearchTree();
           //}
           // catch (Exception exp)
           // {
           //     RadMessageBox.Show("خطا در اجرای عملیات \n"+exp.Message);
           // }

        }

        private void btnClearRoot_Click(object sender, EventArgs e)
        {
            ClearSelectNode();
            ClearGhetehNode();
            ClearProcess();

            txtFaniNoKala.Clear();
            txtCkala.Clear();
            dtpFdateResid.Value = DateTime.Now;
            dtpLdateResid.Value = DateTime.Now;

            //txtCkala.ReadOnly = false;
            //txtNKala.ReadOnly = false;
            txtCAnbar.Clear();
            txtNKala.Clear();
            
            //btnAddRootTree.Enabled = true;
            grdBasteh.DataSource = null;
            this.trMahsul.DataSource = null;
            grdGhetehTree.DataSource = null;
            IDTreeLocal = "";


        }

        private void btnSearchNodeFani_Click(object sender, EventArgs e)
        {
            /*
            if (txtNodeFaniNo.Text.Trim()=="")
            {
                RadMessageBox.Show("لطفا شماره فنی را وارد کنید");
                return;
            }
            
            objTakvin.strSearchGhetehFaniNo = txtNodeFaniNo.Text.Trim();
            objTakvin.strSearchGhetehCode="";
            DataTable dtsearchGheteh = objTakvin.searchGheteh().Tables[0];
            if (dtsearchGheteh.Rows.Count > 0)
            {
                txtNodeFaniNo.Text = dtsearchGheteh.Rows[0]["FaniNo"].ToString();
                txtNodeCode.Text = dtsearchGheteh.Rows[0]["GhetehCode"].ToString();
                txtNodeName.Text = dtsearchGheteh.Rows[0]["GheteName"].ToString();
                txtNodeCAnbar.Text = dtsearchGheteh.Rows[0]["GhetehAnbar"].ToString();
            }
            else
            {
                txtNodeCode.Clear();
                txtNodeName.Clear();
                txtNodeCAnbar.Clear();
            }
             */ 
        }

        private void btnSearchNodeCode_Click(object sender, EventArgs e)
        {
           /*
            if (txtNodeCode.Text.Trim() == "")
            {
                RadMessageBox.Show("لطفا کد کالا را وارد کنید");
                return;
            }
            objTakvin.strSearchGhetehFaniNo = "";
            objTakvin.strSearchGhetehCode = txtNodeCode.Text.Trim();
            DataTable dtsearchGheteh = objTakvin.searchGheteh().Tables[0];
            if (dtsearchGheteh.Rows.Count > 0)
           {
               txtNodeFaniNo.Text = dtsearchGheteh.Rows[0]["FaniNo"].ToString();
               txtNodeCode.Text = dtsearchGheteh.Rows[0]["GhetehCode"].ToString();
               txtNodeName.Text = dtsearchGheteh.Rows[0]["GheteName"].ToString();
               txtNodeCAnbar.Text = dtsearchGheteh.Rows[0]["GhetehAnbar"].ToString();
           }
            else
            {
                txtNodeFaniNo.Clear();
                txtNodeName.Clear();
                txtNodeCAnbar.Clear();
            }
             */
        }

        private void grdGhetehTree_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {


                ClearSelectNode();
                ClearGhetehNode();
                ClearProcess();

                IDTreeLocal = grdGhetehTree.Rows[e.RowIndex].Cells["idNodeTree"].Value.ToString();
                objMali.IDTree = IDTreeLocal;

                //DataRow drselectNodeTree = objMali.selectNodeTree().Tables[0].Rows[0];
                //id_GhetehLocal = drselectNodeTree["id_Gheteh"].ToString();
                id_GhetehLocal = grdGhetehTree.Rows[e.RowIndex].Cells["id_Gheteh"].Value.ToString();
                objMali.id_Gheteh = id_GhetehLocal;

                //----------------------------------------------------------show fani gheteh

                DataRow drselectNodeGheteh = objMali.selectNodeGheteh().Tables[0].Rows[0];

                //grdBasteh.DataSource = objMali.SelectGhetehBasteh().Tables[0];

                //  -------------------------------------------------------------------------------show Process gheteh
                txtProcNodeFaniNo.Text = drselectNodeGheteh["FaniNO"].ToString();
                txtProcNodeCode.Text = drselectNodeGheteh["GhetehCode"].ToString();
                txtProcNodeAnbar.Text = drselectNodeGheteh["GhetehAnbar"].ToString();
                txtProcNodeName.Text = drselectNodeGheteh["GheteName"].ToString();

                objMali.idRootTree = idRootTree;
                //-------------------------------------------------------process
                grdProcGheteh.DataSource = null;
                grdProcGheteh.DataSource = objMali.SelectProcessGhetehMasraf("0").Tables[0];
                //--------------------------------------------------------motealeghat
                grdMotealeghat.DataSource = null;
                grdMotealeghat.DataSource = objMali.SelectMotealegat("0", "1").Tables[0];
                //----------------------------------------------------BOM

                GrdBomGheteh.DataSource = objMali.SelectBom("1", "0", "0", "1").Tables[0];
                grdBomDTemp.DataSource = objMali.SelectBomGhetehMasraf("1", "0", "0", "1").Tables[0];
            }
            catch
            {
                return;
            }

        }
  
        private void btnClearFGh_Click(object sender, EventArgs e)
        {
            ClearGhetehNode();

        }
  
        private void txtFaniNoKala_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmTakvinSearchTree frmST = new FrmTakvinSearchTree();
                frmST.ShowDialog();
                 
                txtFaniNoKala.Text = (!string.IsNullOrEmpty(ClsTakvin.GetRootFaniNo) ? ClsTakvin.GetRootFaniNo : txtFaniNoKala.Text.Trim());
                txtCkala.Text =     (!string.IsNullOrEmpty(ClsTakvin.GetRootCode) ? ClsTakvin.GetRootCode : txtCkala.Text.Trim());
                txtNKala.Text =     (!string.IsNullOrEmpty(ClsTakvin.GetRootName) ? ClsTakvin.GetRootName : txtNKala.Text.Trim());
                txtCAnbar.Text =     (!string.IsNullOrEmpty(ClsTakvin.GetRootAnbar) ? ClsTakvin.GetRootAnbar : txtCAnbar.Text.Trim());
            }
        }
    
        private void btnExpExcel_Click(object sender, EventArgs e)
        {
            string fileName = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = string.Format("{0} (*{1})|*{1}", "Excel Files", ".xlsx")
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;


                (new ExportToExcelML(this.grdGhetehTree)).RunExport(fileName);
            /*
                if (RadMessageBox.Show("اطلاعات به درستی خارج شد.آیا می خواهید فایل باز شود؟", "Export to Excel", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                {
                try
                {
                    Process.Start(fileName);
                }
                catch
                {
                    RadMessageBox.Show("خطا در باز کردن فایل");
                }
                }
             */
            }

        }

        private void txtProcCodeGH_TextChanged(object sender, EventArgs e)
        {
            //GetProcessGheteh();
        }

        private void grdProcGheteh_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {              

                strId_GhetehDtl = grdProcGheteh.Rows[e.RowIndex].Cells["id_Gheteh"].Value.ToString();
                objMali.strProcid_GhetehDtl = strId_GhetehDtl;
                objMali.id_Gheteh = grdProcGheteh.Rows[e.RowIndex].Cells["FK_id_GhetehHead"].Value.ToString();
                objMali.IDTree = grdProcGheteh.Rows[e.RowIndex].Cells["idNodeTree"].Value.ToString();
                
                grdMotealeghat.DataSource = null;
                grdMotealeghat.DataSource = objMali.SelectMotealegat("0", "0").Tables[0];
                //----------------------------------------------------BOM

                GrdBomGheteh.DataSource = objMali.SelectBom("1", "0", "0", "0").Tables[0];
                grdBomDTemp.DataSource = objMali.SelectBomGhetehMasraf("1", "0", "0", "0").Tables[0];
            }
            catch (Exception exp)
            {
                return;
            }
        }

        private void btnFaniNoKala_Click(object sender, EventArgs e)
        {
            FrmTakvinSearchTree frmST = new FrmTakvinSearchTree();
            frmST.ShowDialog();

            txtFaniNoKala.Text = (!string.IsNullOrEmpty(ClsTakvin.GetRootFaniNo) ? ClsTakvin.GetRootFaniNo : txtFaniNoKala.Text.Trim());
            txtCkala.Text = (!string.IsNullOrEmpty(ClsTakvin.GetRootCode) ? ClsTakvin.GetRootCode : txtCkala.Text.Trim());
            txtNKala.Text = (!string.IsNullOrEmpty(ClsTakvin.GetRootName) ? ClsTakvin.GetRootName : txtNKala.Text.Trim());
            txtCAnbar.Text = (!string.IsNullOrEmpty(ClsTakvin.GetRootAnbar) ? ClsTakvin.GetRootAnbar : txtCAnbar.Text.Trim());
        }

        private void btnCkala_Click(object sender, EventArgs e)
        {
            FrmKala frmK = new FrmKala();
            frmK.strC_Anbar = "14";
            frmK.ShowDialog();
            txtCkala.Text = (!string.IsNullOrEmpty(ClsPublic.C_kala) ? ClsPublic.C_kala : txtCkala.Text.Trim());
            txtNKala.Text = (!string.IsNullOrEmpty(ClsPublic.N_kala) ? ClsPublic.N_kala : txtNKala.Text.Trim());
            txtCAnbar.Text = (!string.IsNullOrEmpty(ClsPublic.C_Anbar) ? ClsPublic.C_Anbar : txtCAnbar.Text.Trim());

            //txtCkala.ReadOnly = (!string.IsNullOrEmpty(ClsPublic.C_kala) ? true : false);
            //txtNKala.ReadOnly = (!string.IsNullOrEmpty(ClsPublic.N_kala) ? true : false);
        }

        private void FrmCostTreeMasraf_Load(object sender, EventArgs e)
        {
            dtpFdateResid.Value = DateTime.Now;
            dtpLdateResid.Value = DateTime.Now;
            //سطح دسترسی کنترلها       
            DataTable DtControlAccess = new DataTable();
            DataRow[] dr = ClsMain.DtAccessUser.Select("n_form='" + this.Name + "'");

            if (dr.Length > 0) DtControlAccess = dr.CopyToDataTable();
            if (DtControlAccess.Rows.Count > 0)
            {
                Control ctn;
                for (int i = 0; i < DtControlAccess.Rows.Count; i++)
                {
                    string strControl = DtControlAccess.Rows[i]["n_control"].ToString();
                    ctn = Controls[strControl];
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
                        ctn.Enabled = re;
                        ctn.Visible = rv;
                    }
                }
            }
            //--------------------------------radPageGhProcess
            if (ShowGhProcess.Enabled == true)
            {
                radPageSayerPrice.Enabled = true;
            }
            else
            {
                radPageSayerPrice.Enabled = false;
            }
            ////----------------------------------------------------------------------radPageTakvinTree
            //if (ShowInsNodeTree.Enabled == true)
            //{
            //    radPageTakvinTree.Enabled = true;
            //}
            //else
            //{
            //    radPageTakvinTree.Enabled = false;
            //}    
            //////----------------------------------------------------------------------radpagemostanadat
            //if (ShowInsMostanadat.Enabled == true)
            //{
            //    radPageMostanadat.Enabled = true;
            //}
            //else
            //{
            //    radPageMostanadat.Enabled = false;
            //}             
        }                

    }
}

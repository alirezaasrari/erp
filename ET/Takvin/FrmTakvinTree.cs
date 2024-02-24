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
    public partial class FrmTakvinTree : Telerik.WinControls.UI.RadForm
    {
        public FrmTakvinTree()
        {
            InitializeComponent();
        }
        ClsTakvin objTakvin = new ClsTakvin();
        public string IDTreeLocal, id_GhetehLocal, strId_GhetehDtl, strMostanadPic, strIDMostanad, StrID_BOM;
        public int intBeforolaviat;
        public double BastehZaman;
        private void SearchTree()   // ----------------------------------search tree
        {

            this.trMahsul.DataSource = null;
            //objTakvin.strTaeedOpr = "";
            DataTable dtselectTree = objTakvin.selectTree().Tables[0];
            if (dtselectTree.Rows.Count == 0)
            {
                RadMessageBox.Show("این درخت وجود ندارد");
                 return;
            }
            btnAddRootTree.Enabled = false;
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

            //--------------------------------------------show moshakhasat fani gheteh
            grdGhetehTree.DataSource = dtselectTree;
            //objTakvin.strTaeedOpr = objTakvin.Select_TreeTaeed().Tables[0].Rows[0]["Opr"].ToString();

        }
        private void ClearSelectNode()
        {
            btnDelNode.Enabled = false;

            btnUpdNode.Enabled = false;
            //----------------------------------------Node Tree
            IDTreeLocal = "";
            objTakvin.IDTree = "";
            txtNodeFaniNo.Clear();
            txtNodeName.Clear();
            txtParentFaniNo.Clear();
            txtParentCode.Clear();
            txtParentCAnbar.Clear();
            txtNodeCode.Clear();
            txtNodeCAnbar.Clear();
            txtNodeZm.Clear();


            //ClearGhetehNode();

            //----------------------------------process
            txtProcNodeAnbar.Clear();
            txtProcNodeCode.Clear();
            txtProcNodeFaniNo.Clear();
            txtProcNodeName.Clear();

            grdProcGheteh.DataSource=null;
            grdMotealeghat.DataSource = null;


        }
        //private void ClearGhetehNode()
        private void ClearGhetehNode()
        {
            //---------------------------------------------node gheteh
            btnDelFGh.Enabled = false;
            btnUpdFGh.Enabled = false;
            id_GhetehLocal = "";
            objTakvin.id_Gheteh = "";

            txtFGhFaniNo.Clear();
            txtFGhCode.Clear();
            txtFGhAnbar.Clear();
            txtFGhName.Clear();
            txtFGhJens.Clear();
            rbtnFGhFale.Checked = false;
            rbtnFGhOstovane.Checked = false;
            rbtnFGhChargoosh.Checked = false;
            rbtnFGhSayer.Checked = false;
            txtFGhGhotr.Enabled = true;
            txtFGhHeight.Enabled = true;
            txtFGhTool.Enabled = true;
            txtFGhGSalb.Enabled = true;
            txtFGhChogali.Clear();
            //txtFGhVaznKH.Clear();
            txtFGhGhotr.Clear();
            txtFGhTool.Clear();
            txtFGhHeight.Clear();
            txtFGhGSalb.Clear();
            //txtFGhPert.Clear();
            txtFGhVaznVaghei.Clear();
            rbtnActive.Checked = true;
            rbtnNotActive.Checked = false;
            rbtnAsli.Checked = true;
            rbtnFaree.Checked = false;

            //txtFGhCode.ReadOnly = false;
            //txtFGhName.ReadOnly = false;
            //------------------------------------------basteh
            txtBastehCode.Clear();
            txtBastehAnbar.Clear();
            txtBastehName.Clear();
            sEdtBastehOlaviat.Value = 1;
            sEdtBastehTedad.Value = 1;
            grdBasteh.DataSource = null;
            btnAddBasteh.Enabled = true;
            btnUpdBasteh.Enabled = false;
            btnDelBasteh.Enabled = false;
            //---------------------------------mostanad
            ClearMostanad();
            GrdMostanad.DataSource = null;
            btnAddMos.Enabled = false;
            txtMosFaniNo.Clear();
        }
        private void ClearMostanad()
        {

            btnUpdMos.Enabled = false;
            btnDelMos.Enabled = false;

            dtpDateMos.Value = DateTime.Now;
            btnMosPeyvast.Enabled = true;
            cmbMosType.Enabled = true;
            cmbMosType.SelectedIndex = 0;
            rbtnMosActive.Checked = true;
            txtMosVersion.Clear();
            chkMosIsPeyvast.Checked = true;
            objTakvin.IDMostanad = "";
            strIDMostanad = "";
            txtMosPeyvast.Text = "";
            txtMosVersion.Enabled = true;

        }
        private void ClearProcess(string strSearch )
        {
            cmbProcN_Process.Enabled = true;
            cmbProcN_ProcessPish.Enabled = true;
            SEdtProcMasir.Enabled = true;

            SEdtProcTartibCustom.Value = 5;
            SEdtProcTartibCustom.Enabled = true;
            //txtProcTartibCustom.Enabled = true;
            strId_GhetehDtl = "";
            objTakvin.strProcid_GhetehDtl = "";
            //-------------------------------------------------------------Motealegat
            ClearMotealeghat();
            //--------------------------------------------------------------------BOM
            ClearBomGheteh();
            //---------------------------------------------------------------------
            
            txtProcCodeKargah.Clear();
            txtProcCodeMachin.Clear();
            txtProcDesc.Clear();
            txtProcFaniNoGH.Clear();
            txtProcHofreh.Clear();
            if (strSearch!="process")
            {
                txtProcID_process.Clear();
                cmbProcN_Process.Text = "";
                txtProcCodeGH.Clear();
                txtProcAnbarGH.Clear();
                txtProcNameGH.Clear();
                rbtnProcTolid.Checked = false;
                rbtnProcTarkib.Checked = false;
                SEdtProcTartibCustom.Value = 5;
                //txtProcTartibCustom.Clear();
            }
            cmbProcN_ProcessPish.DataSource = null;
            cmbProcN_ProcessPish.Text = "";
            txtProcID_processPish.Clear();
            cmbProcNameKargah.Text = "";
            objTakvin.strIdUnit = "";
            cmbProcNameMachin.Text = "";
            txtProcNafar.Clear();
            chkProcMovazi.Checked = false;
            
            txtProcDesc.Clear();
            txtProcPert.Clear();
            txtProcTime_standard.Clear();
            txtProcVaznKH.Clear();
            btnAddProc.Enabled = true;
            //btnUpdProc.Enabled = false;
            btnDelProc.Enabled = false;
            if (strSearch != "Kharid")
            {
                rbtnProcKharid.Checked = false;
            }
            if (strSearch != "OutSource")
            {
                rbtnProcOutSource.Checked = false;
            }

            txtProcVaznKamel.Clear();
            rbtnProcActive.Checked = true;
            btnAddBOM.Enabled = false;

        }
        private void ClearBasteh()
        {
            txtBastehCode.Clear();
            objTakvin.StrBastehCode = "";
            txtBastehName.Clear();
            txtBastehAnbar.Clear();

            sEdtBastehTedad.Value = 1;
            sEdtBastehOlaviat.Value = 1;

            txtBastehCode.Enabled = true;
            btnAddBasteh.Enabled = true;
            btnUpdBasteh.Enabled = false;
            btnDelBasteh.Enabled = false;
        }
        public void ClearBomGheteh()
        {
            txtID_Bom.Clear();
            StrID_BOM = "";
            objTakvin.StrID_Bom = "";
            txtNameBom.Clear();
            SEdtOlaviatBom.Value = 1;

            GrdBomGheteh.DataSource = null;
            grdBomDTemp.DataSource = null;

            btnAddBomGheteh.Enabled = true;
            btnUpdBomGheteh.Enabled = false;
            btnDelBomGheteh.Enabled = false;

            txtID_Bom.Enabled = true;
            txtNameBom.Enabled = true;

        }
        public void ClearMotealeghat()
        {
            txtMotealeghatCode.Clear();
            txtMotealeghatAnbar.Clear();
            txtMotealeghatName.Clear();
            txtMotealeghatTedad.Clear();
            grdMotealeghat.DataSource = null;
            objTakvin.StrMotealeghatCode ="";
            objTakvin.strMotealeghatAnbar = "";
            objTakvin.strMotealeghatTedad = "";
            rbtnMotealeghatGhaleb.Checked = true;
            objTakvin.StrMotealeghatType = "1";
            btnAddMotealeghat.Enabled = false;
            btnDelMotealeghat.Enabled = false;
        }
        private void GetProcessGheteh()
        {
            if (txtProcCodeGH.Text.Trim() == "")
            {
                RadMessageBox.Show("کد کالا را با انتخاب فرآیند تعیین نمایید ");
                return;
            }
            objTakvin.strProcCodeGH = txtProcCodeGH.Text.Trim();
            DataTable dtSearchProcessGheteh = objTakvin.SearchProcessGheteh().Tables[0];
            //ClearProcess("process");
            if (dtSearchProcessGheteh.Rows.Count == 0 | dtSearchProcessGheteh.Rows.Count == 1)
            {
                return;
            }
            ClearProcess("process");
            //--------------------------------------------------------------------get parameter
            strId_GhetehDtl = dtSearchProcessGheteh.Rows[0]["id_Gheteh"].ToString();
            txtProcFaniNoGH.Text = dtSearchProcessGheteh.Rows[0]["FaniNo"].ToString();
            txtProcCodeGH.Text = dtSearchProcessGheteh.Rows[0]["GhetehCode"].ToString();
            txtProcNameGH.Text = dtSearchProcessGheteh.Rows[0]["GheteName"].ToString();
            txtProcAnbarGH.Text = dtSearchProcessGheteh.Rows[0]["GhetehAnbar"].ToString();
            cmbProcNameKargah.Text = dtSearchProcessGheteh.Rows[0]["onvan"].ToString();
            txtProcCodeKargah.Text = dtSearchProcessGheteh.Rows[0]["FK_ID_unit"].ToString();
            objTakvin.strIdUnit = dtSearchProcessGheteh.Rows[0]["FK_ID_unit"].ToString();
            cmbProcNameMachin.Text = dtSearchProcessGheteh.Rows[0]["N_machine"].ToString();
            txtProcCodeMachin.Text = dtSearchProcessGheteh.Rows[0]["FK_ID_machine"].ToString();
            txtProcDesc.Text = dtSearchProcessGheteh.Rows[0]["ProcDesc"].ToString();
            
            txtProcHofreh.Text = dtSearchProcessGheteh.Rows[0]["hofre_tedad"].ToString();

            cmbProcN_Process.Text = dtSearchProcessGheteh.Rows[0]["N_process"].ToString();
            txtProcID_process.Text = dtSearchProcessGheteh.Rows[0]["FK_ID_process"].ToString();
            cmbProcN_ProcessPish.Text = dtSearchProcessGheteh.Rows[0]["N_processPish"].ToString();
            txtProcID_processPish.Text = dtSearchProcessGheteh.Rows[0]["FK_ID_processPish"].ToString();
            
            txtProcNafar.Text = dtSearchProcessGheteh.Rows[0]["nafar_tedad"].ToString();
            chkProcMovazi.Checked = Convert.ToBoolean(dtSearchProcessGheteh.Rows[0]["ProcMovazi"]);
            txtProcTime_standard.Text = dtSearchProcessGheteh.Rows[0]["Zaman_standard"].ToString();
            //-----------------------------------------------------------------------------------------
            txtProcPert.Text = dtSearchProcessGheteh.Rows[0]["PertMAval"].ToString();
            txtProcVaznKH.Text = dtSearchProcessGheteh.Rows[0]["VaznKhales"].ToString();
            //-----------------------------------------------------------------------------------------
            btnAddProc.Enabled = true;
            btnUpdProc.Enabled = true;
            btnDelProc.Enabled = true;
            rbtnProcActive.Checked = Convert.ToBoolean(dtSearchProcessGheteh.Rows[0]["VaziatEjraee"]);
            rbtnProcNotActive.Checked = !Convert.ToBoolean(dtSearchProcessGheteh.Rows[0]["VaziatEjraee"]);

            rbtnProcKharid.Checked = Convert.ToBoolean(dtSearchProcessGheteh.Rows[0]["IsKharid"]);
            rbtnProcTolid.Checked = Convert.ToBoolean(dtSearchProcessGheteh.Rows[0]["IsTolid"]);
            rbtnProcOutSource.Checked = Convert.ToBoolean(dtSearchProcessGheteh.Rows[0]["IsOutSource"]);
            rbtnProcTarkib.Checked = Convert.ToBoolean(dtSearchProcessGheteh.Rows[0]["IsTarkib"]);

        }
        private void InsGhetehProcess(string strIsFirstProc)
        {
            string strCheckNodeTree;

            objTakvin.strProcIsFirst = strIsFirstProc;
            objTakvin.strProcMasir = SEdtProcMasir.Value.ToString();
            objTakvin.strProcTartibCustom = SEdtProcTartibCustom.Value.ToString();// txtProcTartibCustom.Text.Trim();
            objTakvin.strProcID_process = txtProcID_process.Text.Trim();
            objTakvin.strProcID_processPish = (!string.IsNullOrEmpty(txtProcID_processPish.Text.Trim()) ? txtProcID_processPish.Text.Trim() : "0");
            objTakvin.strProcDesc = txtProcDesc.Text.Trim();
            objTakvin.strProcFaniNoGH = txtProcFaniNoGH.Text.Trim();
            objTakvin.strProcCodeGH = (!string.IsNullOrEmpty(txtProcCodeGH.Text.Trim()) ? txtProcCodeGH.Text.Trim() : "0");
            objTakvin.strProcAnbarGH = (!string.IsNullOrEmpty(txtProcAnbarGH.Text.Trim()) ? txtProcAnbarGH.Text.Trim() : "0");
            objTakvin.strProcNameGH = txtProcNameGH.Text.Trim();
            objTakvin.strProcCodeKargah = (!string.IsNullOrEmpty(txtProcCodeKargah.Text.Trim()) ? txtProcCodeKargah.Text.Trim() : "0");
            objTakvin.strProcCodeMachin = (!string.IsNullOrEmpty(txtProcCodeMachin.Text.Trim()) ? txtProcCodeMachin.Text.Trim() : "0");
            objTakvin.strProcNafar = (!string.IsNullOrEmpty(txtProcNafar.Text.Trim()) ? txtProcNafar.Text.Trim() : "0");
            objTakvin.strProcMovazi = (chkProcMovazi.Checked == true ? "1" : "0");
            //objTakvin.strProcTime_standard = (!string.IsNullOrEmpty(txtProcTime_standard.Text.Trim()) ? txtProcTime_standard.Text.Trim() : "0");
            objTakvin.strProcTime_standard = txtProcTime_standard.Text;
            objTakvin.strProcTime_standard = objTakvin.strProcTime_standard.Replace("/", ".");
            objTakvin.strProcHofreh = (!string.IsNullOrEmpty(txtProcHofreh.Text.Trim()) ? txtProcHofreh.Text.Trim() : "1");
            objTakvin.strProcVaznKH = (!string.IsNullOrEmpty(txtProcVaznKH.Text.Trim()) ? txtProcVaznKH.Text.Trim() : "0");
            objTakvin.strProcPert = (!string.IsNullOrEmpty(txtProcPert.Text.Trim()) ? txtProcPert.Text.Trim() : "0");
            objTakvin.ProcDesc = txtProcDesc.Text.Trim();
            objTakvin.strProcIsKharid = (rbtnProcKharid.Checked == true ? "1" : "0");
            objTakvin.strProcIstolid = (rbtnProcTolid.Checked == true ? "1" : "0");
            objTakvin.strProcIsOutsource = (rbtnProcOutSource.Checked == true ? "1" : "0");
            objTakvin.strProcIsTarkib = (rbtnProcTarkib.Checked == true ? "1" : "0");
            objTakvin.strProcVaziatEjraee = (rbtnProcActive.Checked == true ? "1" : "0");
            //------------------------------------------------------------

            strCheckNodeTree = objTakvin.CheckNodeTree(objTakvin.strProcCodeGH, objTakvin.strProcNameGH, objTakvin.strProcFaniNoGH);
            if (strCheckNodeTree == "NodeCodeFani")
            {
                RadMessageBox.Show("این شماره فنی برای یک کد کالای دیگر ثبت شده است");
                return;
            }
            else if (strCheckNodeTree == "NodeNameFani")
            {
                RadMessageBox.Show("این شماره فنی برای یک نام کالای دیگر ثبت شده است");
                return;
            }
            else if (strCheckNodeTree == "NodeFaniCode")
            {
                RadMessageBox.Show("این کد کالا برای یک شماره فنی دیگر ثبت شده است");
                return;
            }
            else if (strCheckNodeTree == "NodeNameCode")
            {
                RadMessageBox.Show("این کد کالا برای یک نام کالای دیگر ثبت شده است");
                return;
            }
            else if (strCheckNodeTree == "NodeFaniName")
            {
                RadMessageBox.Show("این نام کالا برای یک شماره فنی دیگر ثبت شده است");
                return;
            }
            else if (strCheckNodeTree == "NodeCodeName")
            {
                RadMessageBox.Show("این نام کالا برای یک کد کالای دیگر ثبت شده است");
                return;
            }


            DataTable dtInsGhetehProcess = objTakvin.InsGhetehProcess().Tables[0];
            if (dtInsGhetehProcess.Rows[0]["Return Value"].ToString() == "0")
            {
                RadMessageBox.Show("این فرآیند برای این کالا قبلا ثبت شده و تکراری است ");
                return;
            }
            else
                if (dtInsGhetehProcess.Rows[0]["Return Value"].ToString() == "-1")
                {
                    if (RadMessageBox.Show(this, "فقط یک فرآیند می تواند بدون پیش فرآیند باشد"+"\n" + "آیا می خواهید این به عنوان اولین فرآیند ثبت شود؟", "", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation, MessageBoxDefaultButton.Button3, RightToLeft.Yes) == DialogResult.Yes)
                    {
                        InsGhetehProcess("1");
                    }
                    else
                    {
                        return;
                    }
                    //RadMessageBox.Show("فقط یک فرآیند می تواند بدون پیش فرآیند باشد ");
                    
                }
                else
                    if (dtInsGhetehProcess.Rows[0]["Return Value"].ToString() == "-2")
                    {
                        RadMessageBox.Show("ترتیب فرآیند تکراری است ");
                        return;
                    }
                    else
                        if (dtInsGhetehProcess.Rows[0]["Return Value"].ToString() == "-3")
                        {
                            RadMessageBox.Show("ترتیب فرآیند باید بزرگتر از ترتیب پیش فرآیند باشد ");
                            return;
                        }
                        else
                            if (dtInsGhetehProcess.Rows[0]["Return Value"].ToString() == "-4")
                            {
                                RadMessageBox.Show("ترتیب فرآیند باید کوچکتر از ترتیب  فرآیند بعدی باشد ");
                                return;
                            }
                            else
                                if (dtInsGhetehProcess.Rows[0]["Return Value"].ToString() == "-5")
                                {
                                    RadMessageBox.Show("فرآیند اصلی یا آخرین فرآیند نمی تواند به عنوان پیش فرآیند باشد");
                                    return;
                                }
                                else
                                {
                                    strId_GhetehDtl = dtInsGhetehProcess.Rows[0]["Return Value"].ToString();
                                    objTakvin.strProcid_GhetehDtl = strId_GhetehDtl;
                                    btnAddBOM.Enabled = true;
                                    RadMessageBox.Show("فرآیند ساخت ثبت شد ");

                                }
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
                if (txtFaniNoKala.Text.Trim() == "" && txtCkala.Text.Trim() == "")
                {
                    RadMessageBox.Show("لطفا کد کالا و یا شماره فنی را وارد کنید");
                    return;
                }
                objTakvin.strFaniNoKala = txtFaniNoKala.Text.Trim();
                objTakvin.strCKala = txtCkala.Text.Trim();

                //objTakvin.strCAnbar = txtCAnbar.Text;
                //txtNKala.ReadOnly = (!string.IsNullOrEmpty(ClsPublic.N_kala) ? true : false);

                ClearSelectNode();
                ClearGhetehNode();
                ClearProcess("");
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
            ClearProcess("");

            btnDelNode.Enabled = true;
            btnUpdNode.Enabled = true;
            btnDelFGh.Enabled  = true;
            btnUpdFGh.Enabled  = true;
            

            //txtNodeName.Text = trMahsul.SelectedNode.Text;
            //btnDelChart.Enabled = true;
            IDTreeLocal = trMahsul.SelectedNode.Value.ToString();
            objTakvin.IDTree = IDTreeLocal;
             
            DataRow drselectNodeTree = objTakvin.selectNodeTree().Tables[0].Rows[0];
            id_GhetehLocal = drselectNodeTree["id_Gheteh"].ToString();    
            

            //id_GhetehLocal = objTakvin.selectNodeTree().Tables[0].Rows[0]["id_Gheteh"].ToString();
            objTakvin.id_Gheteh = id_GhetehLocal;
            txtNodeFaniNo.Text = drselectNodeTree["FaniNO"].ToString();
            txtNodeName.Text = drselectNodeTree["GheteName"].ToString();
            txtParentFaniNo.Text = drselectNodeTree["ParentFaniNo"].ToString();
            txtParentCode.Text = drselectNodeTree["ParentGhetehCode"].ToString();
            txtParentCAnbar.Text = drselectNodeTree["ParentGhetehAnbar"].ToString();
            txtNodeCode.Text = drselectNodeTree["GhetehCode"].ToString();
            txtNodeCAnbar.Text = drselectNodeTree["GhetehAnbar"].ToString();
            txtNodeZm.Text = drselectNodeTree["zm"].ToString();
            //txtNodePBS.Text = objTakvin.selectNodeTree().Tables[0].Rows[0]["NodePBS"].ToString();
            //chkNodeActive.Checked = Convert.ToBoolean(objTakvin.selectNodeTree().Tables[0].Rows[0]["flag_active"].ToString());

            btnUpdNode.Enabled = true;
            btnDelNode.Enabled = true;
            // if (grdNode.RowCount == 0)
            //    txtNodeCode.Text = "-";
            //----------------------------------------------------------show fani gheteh
              
            DataRow drselectNodeGheteh = objTakvin.selectNodeGheteh().Tables[0].Rows[0];
            txtFGhFaniNo.Text = drselectNodeGheteh["FaniNO"].ToString();
            txtFGhCode.Text = drselectNodeGheteh["GhetehCode"].ToString();
            txtFGhAnbar.Text = drselectNodeGheteh["GhetehAnbar"].ToString();
            txtFGhName.Text = drselectNodeGheteh["GheteName"].ToString();

            txtFGhJens.Text = drselectNodeGheteh["JensMAval"].ToString();
            string strTypeMAval = drselectNodeGheteh["TypeMAval"].ToString();
            if (strTypeMAval == "1")
                rbtnFGhFale.Checked = true;
            else
                if (strTypeMAval == "2")
                    rbtnFGhOstovane.Checked = true;
                else
                    if (strTypeMAval == "3")
                        rbtnFGhChargoosh.Checked = true;
                    else
                        if (strTypeMAval == "4")
                            rbtnFGhSayer.Checked = true;
            txtFGhChogali.Text = drselectNodeGheteh["chogaliMAval"].ToString();
            //txtFGhVaznKH.Text = drselectNodeGheteh["VaznKhales"].ToString();
            txtFGhGhotr.Text = drselectNodeGheteh["GhotrMAval"].ToString();
            txtFGhTool.Text = drselectNodeGheteh["ToolMAval"].ToString();
            txtFGhHeight.Text = drselectNodeGheteh["heightMAval"].ToString();
            txtFGhGSalb.Text = drselectNodeGheteh["vaznMAvalGSalb"].ToString();
            //txtFGhPert.Text = drselectNodeGheteh["PertMAval"].ToString();
            txtFGhVaznVaghei.Text = drselectNodeGheteh["VaznVaghei"].ToString();
            rbtnActive.Checked = Convert.ToBoolean(drselectNodeGheteh["VaziatEjraee"].ToString());
            rbtnNotActive.Checked = !Convert.ToBoolean(drselectNodeGheteh["VaziatEjraee"].ToString());
            rbtnAsli.Checked = Convert.ToBoolean(drselectNodeGheteh["VaziatMahsul"].ToString());
            rbtnFaree.Checked = !Convert.ToBoolean(drselectNodeGheteh["VaziatMahsul"].ToString());
            //----------------------------------------------------------------------------------show basteh gheteh
            grdBasteh.DataSource = objTakvin.SelectGhetehBasteh().Tables[0];
            txtBastehCode.Enabled = true;
            //  -------------------------------------------------------------------------------show mostanadat gheteh

            if (ShowAllMostanadat.Visible==true)
               objTakvin.ShowAllMostanadat = "1";
            else
               objTakvin.ShowAllMostanadat = "0";
            txtMosFaniNo.Text = drselectNodeGheteh["FaniNO"].ToString();
            GrdMostanad.DataSource = objTakvin.selectMostanad().Tables[0];
            btnAddMos.Enabled = true;

            //  -------------------------------------------------------------------------------show Process gheteh
            txtProcNodeFaniNo.Text = drselectNodeGheteh["FaniNO"].ToString();
            txtProcNodeCode.Text = drselectNodeGheteh["GhetehCode"].ToString();
            txtProcNodeAnbar.Text = drselectNodeGheteh["GhetehAnbar"].ToString();
            txtProcNodeName.Text = drselectNodeGheteh["GheteName"].ToString();

            rbtnProcKharid.Checked = Convert.ToBoolean(drselectNodeGheteh["IsKharid"].ToString());
            rbtnProcTolid.Checked = Convert.ToBoolean(drselectNodeGheteh["IsTolid"].ToString());
            rbtnProcOutSource.Checked = Convert.ToBoolean(drselectNodeGheteh["IsOutSource"].ToString());
            rbtnProcTarkib.Checked = Convert.ToBoolean(drselectNodeGheteh["IsTarkib"].ToString());

            grdProcGheteh.DataSource = null;
            grdProcGheteh.DataSource = objTakvin.SelectProcessGheteh().Tables[0];
            

        }

        private void btnADDChild_Click(object sender, EventArgs e)
        {
            objTakvin.strFaniNoKala = "";
            if (objTakvin.Select_TreeTaeed().Tables[0].Rows[0]["Opr"].ToString() == "True")
            {
                RadMessageBox.Show(" درخت تایید شده است");
                return;
            }
            try
            {
                string strCheckNodeTree;
                if (string.IsNullOrEmpty(IDTreeLocal))
                {
                    RadMessageBox.Show("پدر کالا را تعیین نمایید");
                    return;
                }
                if (txtChildFaniNo.Text.Trim() == "")
                {
                    RadMessageBox.Show("شماره فنی کالا را تعیین نمایید");
                    return;
                }
                if (txtChildName.Text.Trim() == "")
                {
                    RadMessageBox.Show("نام کالا را وارد نمایید");
                    return;
                }
                if (txtChildCode.Text.Trim() == "" || txtChildCode.Text.Trim() == "0" || txtChildCAnbar.Text.Trim() == "" || txtChildCAnbar.Text.Trim() == "0")
                {
                    RadMessageBox.Show("کد کالا  یا انبار را وارد نمایید");
                    return;
                }
                //if (txtChildCAnbar.Text.Trim() != "10" && txtChildCAnbar.Text.Trim() != "11" && txtChildCAnbar.Text.Trim() != "13" && txtChildCAnbar.Text.Trim() != "15")
                //{
                //    RadMessageBox.Show(" انبار معتبر نیست");
                //    return;
                //}
                if (txtChildZm.Text.Trim()=="")
                {
                    RadMessageBox.Show("ضریب مصرف را وارد نمایید");
                    return;
                }
                if (rbtnChildFale.Checked == false && rbtnChildChargoosh.Checked == false && rbtnChildOstovane.Checked == false && rbtnChildSayer.Checked == false)
                {
                    RadMessageBox.Show("نوع کالا را مشخص نمایید");
                    return;
                }
                if (rbtnChildChargoosh.Checked == true &&(  txtChildHeight.Text.Trim() == "" || txtChildTool.Text.Trim() == ""
                    || txtChildGhotr.Text.Trim() == "" || txtChildChogali.Text.Trim() == "" || txtChildJens.Text.Trim() == ""))
                {
                    RadMessageBox.Show("اطلاعات مربوط به مشخصات فنی فرزند را وارد نمایید");
                    return;
                }
                if (rbtnChildFale.Checked == true && (txtChildGSalb.Text.Trim() == "" 
                     || txtChildChogali.Text.Trim() == "" || txtChildJens.Text.Trim() == ""))
                {
                    RadMessageBox.Show("اطلاعات مربوط به مشخصات فنی فرزند را وارد نمایید");
                    return;
                }
                if (rbtnChildOstovane.Checked == true && ( txtChildTool.Text.Trim() == ""
                    || txtChildGhotr.Text.Trim() == "" || txtChildChogali.Text.Trim() == "" || txtChildJens.Text.Trim() == ""))
                {
                    RadMessageBox.Show("اطلاعات مربوط به مشخصات فنی فرزند را وارد نمایید");
                    return;
                }


                //objTakvin.ChildCode = (!string.IsNullOrEmpty(txtChildCode.Text.Trim()) ? txtChildCode.Text.Trim() : "0");
                objTakvin.ChildCode = txtChildCode.Text.Trim();
                objTakvin.ChildName = txtChildName.Text;
                //objTakvin.ChildAnbar = (!string.IsNullOrEmpty(txtChildCAnbar.Text.Trim()) ? txtChildCAnbar.Text.Trim() : "0");
                objTakvin.ChildAnbar = txtChildCAnbar.Text.Trim();
                //objTakvin.ChildPBS = txtChildPBS.Text;
                objTakvin.Childzm = txtChildZm.Text;
                objTakvin.ChildFaniNo = txtChildFaniNo.Text.Trim();
                //objTakvin.nodeflag_active = chkNodeActive.Checked.ToString();
                //---------------------------------------------------------------------------Fani                                                          
                //objTakvin.PertMAval = (txtFGhPert.Text.Trim() == "" ? "1" : txtFGhPert.Text.Trim());
                objTakvin.ChildvaznMAvalGSalb = (txtChildGSalb.Text.Trim() == "" ? "''" : txtChildGSalb.Text.Trim());
                objTakvin.Childheight = (txtChildHeight.Text.Trim() == "" ? "''" : txtChildHeight.Text.Trim());
                objTakvin.ChildTool = (txtChildTool.Text.Trim() == "" ? "''" : txtChildTool.Text.Trim()); 
                objTakvin.ChildGhotr = (txtChildGhotr.Text.Trim() == "" ? "0" : txtChildGhotr.Text.Trim()); 
                //objTakvin.VaznKhales = (txtFGhVaznKH.Text.Trim() == "" ? "1" : txtFGhVaznKH.Text.Trim());
                objTakvin.Childchogali = (txtChildChogali.Text.Trim() == "" ? "''" : txtChildChogali.Text.Trim()); 
                objTakvin.ChildJens = txtChildJens.Text.Trim();
                if (rbtnChildFale.Checked==true)
                    objTakvin.ChildTypeMAval = "1";
                else if (rbtnChildOstovane.Checked == true)
                        objTakvin.ChildTypeMAval = "2";
                    else if (rbtnChildChargoosh.Checked == true)
                            objTakvin.ChildTypeMAval = "3";
                        else
                            if (rbtnChildSayer.Checked == true)
                                objTakvin.ChildTypeMAval = "4";   
                objTakvin.ChildVaznVaghei = (txtChildVaznVaghei.Text.Trim() == "" ? "0" : txtChildVaznVaghei.Text.Trim());
                objTakvin.ChildVaziatMahsul = (rbtnChildAsli.Checked == true ? "1" : "0");
                objTakvin.ChildVaziatEjraee = (rbtnChildActive.Checked == true ? "1" : "0");


                //-----------------------------------------------------------------------------
                strCheckNodeTree = objTakvin.CheckNodeTree(objTakvin.ChildCode,objTakvin.ChildName,objTakvin.ChildFaniNo);
                if (strCheckNodeTree == "NodeCodeFani")
                {
                    RadMessageBox.Show("این شماره فنی برای یک کد کالای دیگر ثبت شده است");
                    return;
                }
                else if (strCheckNodeTree == "NodeNameFani")
                {
                    RadMessageBox.Show("این شماره فنی برای یک نام کالای دیگر ثبت شده است");
                    return;
                }
                else if (strCheckNodeTree == "NodeFaniCode")
                {
                    RadMessageBox.Show("این کد کالا برای یک شماره فنی دیگر ثبت شده است");
                    return;
                }
                else if (strCheckNodeTree == "NodeNameCode")
                {
                    RadMessageBox.Show("این کد کالا برای یک نام کالای دیگر ثبت شده است");
                    return;
                }
                else if (strCheckNodeTree == "NodeFaniName")
                {
                    RadMessageBox.Show("این نام کالا برای یک شماره فنی دیگر ثبت شده است");
                    return;
                }
                else if (strCheckNodeTree == "NodeCodeName")
                {
                    RadMessageBox.Show("این نام کالا برای یک کد کالای دیگر ثبت شده است");
                    return;
                }

                RadMessageBox.Show(objTakvin.InsNodeTree());

                SearchTree();

                //objTakvin.nodeflag_active = chkNodeActive.Checked.ToString();

            }
            catch (Exception exp)
            {
                RadMessageBox.Show("خطا در اجرای عملیات \n" + exp.Message);
            }
            
        }

        private void txtChildCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmKala frmK = new FrmKala();
                frmK.strC_Anbar = "10,11,13,15";
                frmK.ShowDialog();
                txtChildCode.Text = (!string.IsNullOrEmpty(ClsPublic.C_kala) ? ClsPublic.C_kala : txtChildCode.Text.Trim());
                txtChildName.Text = (!string.IsNullOrEmpty(ClsPublic.N_kala) ? ClsPublic.N_kala : txtChildName.Text.Trim());
                txtChildCAnbar.Text = (!string.IsNullOrEmpty(ClsPublic.C_Anbar) ? ClsPublic.C_Anbar : txtChildCAnbar.Text.Trim());

                //txtChildCode.ReadOnly = (!string.IsNullOrEmpty(ClsPublic.C_kala) ? true : false);
                //txtChildName.ReadOnly = (!string.IsNullOrEmpty(ClsPublic.N_kala) ? true : false);
            }
        }

        private void btnDelNode_Click(object sender, EventArgs e)
        {
            if (objTakvin.Select_TreeTaeed().Tables[0].Rows[0]["Opr"].ToString() == "True")
            {
                RadMessageBox.Show(" درخت تایید شده است");
                return;
            }
            if (txtNodeCode.Text.Trim() == "")
            {
                RadMessageBox.Show("کالا را تعیین نمایید");
                return;
            }
            /*
            string IsChild = "";
            try
            {
                IsChild = trMahsul.SelectedNode.LastNode.Text;
            }
            catch
            {
            }
             
            if (!String.IsNullOrEmpty(IsChild))
            {
                RadMessageBox.Show("این کالا فرزند دارد");
                return;
            }
            */
            if (objTakvin.IsParentTree().Tables[0].Rows.Count>0)
            {
                RadMessageBox.Show("این کالا فرزند دارد");
                return;
            }
            else
            {
                if (RadMessageBox.Show(this, "آیا مطمئن هستید این کالای درخت پاک شود؟", "", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation, MessageBoxDefaultButton.Button3, RightToLeft.Yes) == DialogResult.Yes)
                {
                    RadMessageBox.Show(objTakvin.DelTree());
                    objTakvin.DelTreeManage();
                    ClearSelectNode();
                    SearchTree();
                }
            }
        }

        private void btnUpdNode_Click(object sender, EventArgs e)
        {
            if (objTakvin.Select_TreeTaeed().Tables[0].Rows[0]["Opr"].ToString() == "True")
            {
                RadMessageBox.Show(" درخت تایید شده است");
                return;
            }
            if (txtNodeCode.Text.Trim() == "")
            {
                RadMessageBox.Show("کالا را تعیین نمایید");
                return;
            }
            //objTakvin.nodeCode = txtNodeCode.Text;
            //objTakvin.nodeName = txtNodeName.Text;
            //objTakvin.nodeCAnbar = txtNodeCAnbar.Text;
            //objTakvin.NodePBS = txtNodePBS.Text;
            if (objTakvin.IsRootTree() == "True" && Convert.ToDouble( txtNodeZm.Text.Trim())>1)
            {
                RadMessageBox.Show("ریشه درخت ضریب مصرفش یک است");
                return;
            }
            objTakvin.nodezm = txtNodeZm.Text.Trim();
            RadMessageBox.Show(objTakvin.UpdTree());
            SearchTree();
        }

        private void GrdMostanad_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                btnUpdMos.Enabled = true;
                btnDelMos.Enabled = true;

                dtpDateMos.Text = GrdMostanad.Rows[e.RowIndex].Cells["DateSanad"].Value.ToString();
                //(GrdMostanad.Rows[e.RowIndex].Cells["IsPeyvast"].Value.ToString() == "true");
                cmbMosType.Text = GrdMostanad.Rows[e.RowIndex].Cells["MostanadTypeName"].Value.ToString();
                cmbMosType.SelectedValue = GrdMostanad.Rows[e.RowIndex].Cells["IDMostanadType"].Value;
                cmbMosType.Enabled = false;
                btnMosPeyvast.Enabled = false;
                txtMosVersion.Enabled = false;
                txtMosVersion.Text = GrdMostanad.Rows[e.RowIndex].Cells["MosVersion"].Value.ToString();
                //chkMosIsPeyvast.Checked = Convert.ToBoolean(GrdMostanad.Rows[e.RowIndex].Cells["IsPeyvast"].Value.ToString());
                switch (GrdMostanad.Rows[e.RowIndex].Cells["MostanadVaziat"].Value.ToString())
                {
                    case "1":
                        rbtnMosActive.Checked = true;
                        break;
                    case "2": rbtnMosNotActive.Checked = true;
                        break;
                    case "3": rbtnMosBaygani.Checked = true;
                        break;
                }
                strIDMostanad = GrdMostanad.Rows[e.RowIndex].Cells["IDMostanad"].Value.ToString();
                objTakvin.IDMostanad = strIDMostanad;

            }
            catch (Exception exp)
            {
                return;
            }
 


            //FrmTakvinMostanad frmMos = new FrmTakvinMostanad();
            //if (GrdMostanad.Rows[e.RowIndex].Cells["IsPeyvast"].Value.ToString() == "true")
            //{
            //    frmMos.MostanadLocation = GrdMostanad.Rows[e.RowIndex].Cells["MostanadPic"].Value.ToString();
            //    frmMos.ShowDialog();
            //}
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtChildFaniNo.Clear();
            txtChildCode.Clear();
            txtChildName.Clear();
            txtChildCAnbar.Clear();
            
            txtChildZm.Clear();

            txtChildChogali.Clear();
            txtChildGhotr.Clear();
            txtChildGSalb.Clear();
            txtChildHeight.Clear();
            txtChildJens.Clear();
            rbtnChildFale.Checked = false;
            rbtnChildOstovane.Checked = false;
            rbtnChildChargoosh.Checked = false;
            rbtnChildSayer.Checked = false;
            txtChildGhotr.Enabled = true;
            txtChildHeight.Enabled = true;
            txtChildTool.Enabled = true;
            txtChildGSalb.Enabled = true;
            txtChildTool.Clear();
            txtChildVaznVaghei.Clear();

            rbtnChildActive.Checked = true;
            rbtnChildAsli.Checked = true;

            //txtChildCode.ReadOnly = false;
            //txtChildName.ReadOnly = false;
        }

        private void btnAddRootTree_Click(object sender, EventArgs e)
        {
            try
            {

            
            string strCheckTree;
            if (txtFaniNoKala.Text.Trim() == "")
            {
                RadMessageBox.Show("کد فنی درخت را تعیین نمایید");
                return;
            }
            if (txtCkala.Text.Trim() == "" || txtCkala.Text.Trim() == "0" || txtCAnbar.Text.Trim() == "" || txtCAnbar.Text.Trim() == "0")
            {
                RadMessageBox.Show("کد کالا  یا انبار را وارد نمایید");
                return;
            }
            if (txtNKala.Text.Trim() == "")
            {
                RadMessageBox.Show("نام درخت را وارد نمایید");
                return;
            }
            objTakvin.strFaniNoKala = txtFaniNoKala.Text.Trim();
            objTakvin.strCKala =(!string.IsNullOrEmpty(txtCkala.Text.Trim())?txtCkala.Text.Trim():"0");
            objTakvin.strNKala = txtNKala.Text.Trim();
            objTakvin.strCAnbar = (!string.IsNullOrEmpty(txtCAnbar.Text.Trim()) ? txtCAnbar.Text.Trim() : "0");

            strCheckTree = objTakvin.CheckTree();
            if (strCheckTree == "FaniNO")
            {
                RadMessageBox.Show(" درخت با این کد فنی وجود دارد");
                return;
            }
            else if (strCheckTree == "RootCode")
            {
                RadMessageBox.Show(" درخت با این کد کالا وجود دارد");
                return;
            }
            else if (strCheckTree == "RootName")
            {
                RadMessageBox.Show(" درخت با این نام وجود دارد");
                return;
            }
            RadMessageBox.Show(objTakvin.InsRootTree());
            ClearSelectNode();
            ClearGhetehNode();
            SearchTree();
           }
            catch (Exception exp)
            {
                RadMessageBox.Show("خطا در اجرای عملیات \n"+exp.Message);
            }

        }

        private void btnClearRoot_Click(object sender, EventArgs e)
        {
            ClearSelectNode();
            ClearGhetehNode();
            ClearProcess("");
           // objTakvin.strTaeedOpr = "";
            txtFaniNoKala.Clear();
            txtCkala.Clear();
            //txtCkala.ReadOnly = false;
            //txtNKala.ReadOnly = false;
            txtCAnbar.Clear();
            txtNKala.Clear();
            
            btnAddRootTree.Enabled = true;
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

        private void btnSearchChildFani_Click(object sender, EventArgs e)
        {
           
            if (txtChildFaniNo.Text.Trim() == "")
            {
                RadMessageBox.Show("لطفا شماره فنی را وارد کنید");
                return;
            }
            objTakvin.strSearchGhetehFaniNo = txtChildFaniNo.Text.Trim();
            objTakvin.strSearchGhetehCode = "";
            DataTable dtsearchGheteh = objTakvin.searchGheteh().Tables[0];
            if (dtsearchGheteh.Rows.Count > 0)
            {
                //txtChildFaniNo.Text = dtsearchGheteh.Rows[0]["FaniNo"].ToString();
                txtChildCode.Text = dtsearchGheteh.Rows[0]["GhetehCode"].ToString();
                txtChildName.Text = dtsearchGheteh.Rows[0]["GheteName"].ToString();
                txtChildCAnbar.Text = dtsearchGheteh.Rows[0]["GhetehAnbar"].ToString();

                txtChildChogali.Text = dtsearchGheteh.Rows[0]["chogaliMAval"].ToString();
                txtChildGhotr.Text = dtsearchGheteh.Rows[0]["GhotrMAval"].ToString();
                txtChildGSalb.Text = dtsearchGheteh.Rows[0]["vaznMAvalGSalb"].ToString();
                txtChildHeight.Text = dtsearchGheteh.Rows[0]["heightMAval"].ToString();
                txtChildJens.Text = dtsearchGheteh.Rows[0]["JensMAval"].ToString();

                string strTypeMAval = dtsearchGheteh.Rows[0]["TypeMAval"].ToString();
                if (strTypeMAval == "1")
                    rbtnChildFale.Checked = true;
                else
                    if (strTypeMAval == "2")
                        rbtnChildOstovane.Checked = true;
                    else
                        if (strTypeMAval == "3")
                            rbtnChildChargoosh.Checked = true;
                         else
                            if (strTypeMAval == "4")
                                rbtnChildSayer.Checked = true;
                       
                txtChildTool.Text = dtsearchGheteh.Rows[0]["ToolMAval"].ToString();
                txtChildVaznVaghei.Text = dtsearchGheteh.Rows[0]["VaznVaghei"].ToString();

                rbtnChildActive.Checked = Convert.ToBoolean(dtsearchGheteh.Rows[0]["VaziatEjraee"].ToString());
                rbtnChildNotActive.Checked = !Convert.ToBoolean(dtsearchGheteh.Rows[0]["VaziatEjraee"].ToString());
                rbtnChildAsli.Checked = Convert.ToBoolean(dtsearchGheteh.Rows[0]["VaziatMahsul"].ToString());
                rbtnChildFaree.Checked = !Convert.ToBoolean(dtsearchGheteh.Rows[0]["VaziatMahsul"].ToString());
            }
            else
            {
                txtChildCode.Clear();
                txtChildName.Clear();
                txtChildCAnbar.Clear();

                txtChildChogali.Clear();
                txtChildGhotr.Clear();
                txtChildGSalb.Clear();
                txtChildHeight.Clear();
                txtChildJens.Clear();
                rbtnChildFale.Checked = false;
                rbtnChildOstovane.Checked = false;
                rbtnChildChargoosh.Checked = false;
                rbtnChildSayer.Checked = false;

                txtChildTool.Clear();
                txtChildVaznVaghei.Clear();

                rbtnChildActive.Checked = true;
                rbtnChildAsli.Checked = true;
            }
        }

        private void btnSearchChildCode_Click(object sender, EventArgs e)
        {
            if (txtChildCode.Text.Trim() == "")
            {
                RadMessageBox.Show("لطفا کد کالا را وارد کنید");
                return;
            }
            objTakvin.strSearchGhetehFaniNo = "";
            objTakvin.strSearchGhetehCode = txtChildCode.Text.Trim();
            DataTable dtsearchGheteh = objTakvin.searchGheteh().Tables[0];
            if (dtsearchGheteh.Rows.Count > 0)
            {
                txtChildFaniNo.Text = dtsearchGheteh.Rows[0]["FaniNo"].ToString();
                //txtChildCode.Text = dtsearchGheteh.Rows[0]["GhetehCode"].ToString();
                txtChildName.Text = dtsearchGheteh.Rows[0]["GheteName"].ToString();
                txtChildCAnbar.Text = dtsearchGheteh.Rows[0]["GhetehAnbar"].ToString();

                txtChildChogali.Text = dtsearchGheteh.Rows[0]["chogaliMAval"].ToString();
                txtChildGhotr.Text = dtsearchGheteh.Rows[0]["GhotrMAval"].ToString();
                txtChildGSalb.Text = dtsearchGheteh.Rows[0]["vaznMAvalGSalb"].ToString();
                txtChildHeight.Text = dtsearchGheteh.Rows[0]["heightMAval"].ToString();

                txtChildJens.Text = dtsearchGheteh.Rows[0]["JensMAval"].ToString();
                string strTypeMAval = dtsearchGheteh.Rows[0]["TypeMAval"].ToString();
                if (strTypeMAval == "1")
                    rbtnChildFale.Checked = true;
                else
                    if (strTypeMAval == "2")
                        rbtnChildOstovane.Checked = true;
                    else
                        if (strTypeMAval == "3")
                            rbtnChildChargoosh.Checked = true;
                        else
                            if (strTypeMAval == "4")
                            rbtnChildSayer.Checked = true;
                txtChildTool.Text = dtsearchGheteh.Rows[0]["ToolMAval"].ToString();
                txtChildVaznVaghei.Text = dtsearchGheteh.Rows[0]["VaznVaghei"].ToString();

                rbtnChildActive.Checked = Convert.ToBoolean(dtsearchGheteh.Rows[0]["VaziatEjraee"].ToString());
                rbtnChildNotActive.Checked = !Convert.ToBoolean(dtsearchGheteh.Rows[0]["VaziatEjraee"].ToString());
                rbtnChildAsli.Checked = Convert.ToBoolean(dtsearchGheteh.Rows[0]["VaziatMahsul"].ToString());
                rbtnChildFaree.Checked = !Convert.ToBoolean(dtsearchGheteh.Rows[0]["VaziatMahsul"].ToString());
            }
            else
            {
                txtChildFaniNo.Clear();
                txtChildName.Clear();
                txtChildCAnbar.Clear();

                txtChildChogali.Clear();
                txtChildGhotr.Clear();
                txtChildGSalb.Clear();
                txtChildHeight.Clear();
                txtChildJens.Clear();
                rbtnChildFale.Checked = false;
                rbtnChildOstovane.Checked = false;
                rbtnChildChargoosh.Checked = false;
                rbtnChildSayer.Checked = false;

                txtChildTool.Clear();
                txtChildVaznVaghei.Clear();

                rbtnChildActive.Checked = true;
                rbtnChildAsli.Checked = true;
            }
        }

        private void grdGhetehTree_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            //objTakvin.FaniNO = grdGhetehTree.Rows[e.RowIndex].Cells["FaniNO"].Value.ToString();
            //GrdMostanad.DataSource = objTakvin.selectMostanad().Tables[0];
        }
  
        private void btnClearFGh_Click(object sender, EventArgs e)
        {
            ClearGhetehNode();

        }

        private void btnDelFGh_Click(object sender, EventArgs e)
        {
            if (objTakvin.Select_TreeTaeed().Tables[0].Rows[0]["Opr"].ToString() == "True")
            {
                RadMessageBox.Show(" درخت تایید شده است");
                return;
            }
            try
            {
                if (txtFGhFaniNo.Text.Trim() == "")
                {
                    RadMessageBox.Show("کد فنی را تعیین نمایید");
                    return;
                } 
                if (objTakvin.ISGhetehMostanad().Tables[0].Rows.Count > 0)
                {
                    RadMessageBox.Show("برای این کالا مستندات ثبت شده است");
                    return;
                }
             
                if (objTakvin.ISGhetehProcess() == "True")
                {
                    RadMessageBox.Show(" این کالا دارای فرآیند ساخت است");
                   
                    return;
                }
                if (objTakvin.ISGhetehTree().Tables[0].Rows.Count > 0)
                {
                    RadMessageBox.Show("این کالا در درخت تعریف شده است");
                    return;
                }
                //-----check bom
                else
                {
                    if (RadMessageBox.Show(this, "آیا مطمئن هستید این کالا پاک شود؟", "", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation, MessageBoxDefaultButton.Button3, RightToLeft.Yes) == DialogResult.Yes)
                    {
                        RadMessageBox.Show(objTakvin.DelGheteh());
                        ClearSelectNode();
                        ClearGhetehNode();
                    }
                }
            }
            catch (Exception exp)
            {
                RadMessageBox.Show("خطا در اجرای عملیات \n" + exp.Message);
            }
        }

        private void btnUpdFGh_Click(object sender, EventArgs e)
        {
            objTakvin.strCKala = txtCkala.Text;
            objTakvin.strFaniNoKala = txtFaniNoKala.Text;
            if (objTakvin.Select_TreeTaeed().Tables[0].Rows[0]["Opr"].ToString() == "True")
            {
                RadMessageBox.Show(" درخت تایید شده است");
                return;
            }
            try
            {
                string strCheckGheteh;
                if (txtFGhFaniNo.Text.Trim() == "")
                {
                    RadMessageBox.Show("کد فنی را تعیین نمایید");
                    return;
                }
                if (txtFGhCode.Text.Trim() == "" || txtFGhCode.Text.Trim() == "0" || txtFGhAnbar.Text.Trim() == "" || txtFGhAnbar.Text.Trim() == "0")
                {
                    RadMessageBox.Show("کد کالا  یا انبار را وارد نمایید");
                    return;
                }
                if (string.IsNullOrEmpty(IDTreeLocal))
                {
                    RadMessageBox.Show("درخت را انتخاب نمایید");
                    return;
                }
                //if (objTakvin.IsRootTree() == "True" && txtFGhAnbar.Text.Trim() != "14")
                //{
                //    //RadMessageBox.Show(" محصول انبار 14");
                //    RadMessageBox.Show(" انبار معتبر نیست");
                //    return;
                //}
                //else
                //    if (objTakvin.IsRootTree() != "True" && txtFGhAnbar.Text.Trim() != "10" && txtFGhAnbar.Text.Trim() != "11" && txtFGhAnbar.Text.Trim() != "13" && txtFGhAnbar.Text.Trim() != "15")
                //    {
                //        RadMessageBox.Show(" انبار معتبر نیست");
                //        return;
                //    }
                if (txtFGhName.Text.Trim() == "")
                {
                    RadMessageBox.Show("نام کالا را تعیین نمایید");
                    return;
                }
                if (rbtnFGhFale.Checked == false && rbtnFGhChargoosh.Checked == false && rbtnFGhOstovane.Checked == false && rbtnFGhSayer.Checked == false)
                {
                    RadMessageBox.Show("نوع کالا را مشخص نمایید");
                    return;
                }
                if (rbtnFGhChargoosh.Checked == true && (txtFGhHeight.Text.Trim() == "" || txtFGhTool.Text.Trim() == ""
                    || txtFGhGhotr.Text.Trim() == "" || txtFGhChogali.Text.Trim() == "" || txtFGhJens.Text.Trim() == ""))
                {
                    RadMessageBox.Show("اطلاعات مربوط به مشخصات فنی فرزند را وارد نمایید");
                    return;
                }
                if (rbtnFGhFale.Checked == true && (txtFGhGSalb.Text.Trim() == ""
                     || txtFGhChogali.Text.Trim() == "" || txtFGhJens.Text.Trim() == ""))
                {
                    RadMessageBox.Show("اطلاعات مربوط به مشخصات فنی فرزند را وارد نمایید");
                    return;
                }
                if (rbtnFGhOstovane.Checked == true && (txtFGhTool.Text.Trim() == ""
                    || txtFGhGhotr.Text.Trim() == "" || txtFGhChogali.Text.Trim() == "" || txtFGhJens.Text.Trim() == ""))
                {
                    RadMessageBox.Show("اطلاعات مربوط به مشخصات فنی فرزند را وارد نمایید");
                    return;
                }

                objTakvin.GhetehFaniNo = txtFGhFaniNo.Text.Trim();                                        //-------
                objTakvin.GhetehCode = (txtFGhCode.Text.Trim() == "" ? "0" : txtFGhCode.Text.Trim());      //------- 
                objTakvin.GhetehAnbar = (txtFGhAnbar.Text.Trim() == "" ? "0" : txtFGhAnbar.Text.Trim());
                objTakvin.GheteName = txtFGhName.Text.Trim();                                             //--------
                //objTakvin.PertMAval = (txtFGhPert.Text.Trim() == "" ? "1" : txtFGhPert.Text.Trim());
                objTakvin.vaznMAvalGSalb = (txtFGhGSalb.Text.Trim() == "" ? "''" : txtFGhGSalb.Text.Trim());
                objTakvin.heightMAval = (txtFGhHeight.Text.Trim() == "" ? "''" : txtFGhHeight.Text.Trim());
                objTakvin.ToolMAval = (txtFGhTool.Text.Trim() == "" ? "''" : txtFGhTool.Text.Trim());
                objTakvin.GhotrMAval = (txtFGhGhotr.Text.Trim() == "" ? "0" : txtFGhGhotr.Text.Trim());
                //objTakvin.VaznKhales = (txtFGhVaznKH.Text.Trim() == "" ? "1" : txtFGhVaznKH.Text.Trim());
                objTakvin.chogaliMAval = (txtFGhChogali.Text.Trim() == "" ? "1" : txtFGhChogali.Text.Trim());
                objTakvin.JensMAval = txtFGhJens.Text.Trim();
                if (rbtnFGhFale.Checked == true)
                    objTakvin.strTypeMAval = "1";
                else
                    if (rbtnFGhOstovane.Checked == true)
                        objTakvin.strTypeMAval = "2";
                    else
                        if (rbtnFGhChargoosh.Checked == true)
                            objTakvin.strTypeMAval = "3";
                        else
                            if (rbtnFGhSayer.Checked == true)
                                objTakvin.strTypeMAval = "4";
                objTakvin.VaznVaghei = (txtFGhVaznVaghei.Text.Trim() == "" ? "0" : txtFGhVaznVaghei.Text.Trim()); 
                objTakvin.VaziatMahsul = (rbtnAsli.Checked == true ? "1" : "0");
                objTakvin.VaziatEjraee = (rbtnActive.Checked == true ? "1" : "0");

                //strCheckGheteh = "";
                strCheckGheteh = objTakvin.CheckGheteh();
                //if (strCheckGheteh == "GhetehCode")
                //{
                //    RadMessageBox.Show("این کد کالا تکراری است");
                //    return;
                //}
                //else 
                //if (strCheckGheteh == "FaniNo")
                //{
                //    RadMessageBox.Show("این شماره فنی تکراری است");
                //    return;
                //}
                //else if (strCheckGheteh == "GheteName")
                //{
                //    RadMessageBox.Show("این نام تکراری است");
                //    return;
                //}
                if( objTakvin.ISGhetehProcess()=="True")
                {
                    RadMessageBox.Show("این قطعه دارای فرآیند ساخت است و کد کالای آن قابل ویرایش نیست");
                    RadMessageBox.Show(objTakvin.UpdGheteh("True"));
                }
                else
                {
                    RadMessageBox.Show(objTakvin.UpdGheteh("False"));
                }
             
                SearchTree();
            }
            catch (Exception exp)
            {
                RadMessageBox.Show("خطا در اجرای عملیات \n" + exp.Message);
            }
        }

        private void txtFGhCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (string.IsNullOrEmpty(IDTreeLocal))
                {
                    RadMessageBox.Show("درخت را انتخاب نمایید");
                    return;
                }
                ClsTakvin obj = new ClsTakvin();
                obj.InsGheteFromPaya();

                FrmKala frmK = new FrmKala();

                //if (objTakvin.IsRootTree() == "True")
                //{
                //    //RadMessageBox.Show(" محصول انبار 14");
                //    frmK.strC_Anbar = "14";
                //}
                //else
                //{
                //    frmK.strC_Anbar = "10,11,13,15";
                //}
                frmK.ShowDialog();
                txtFGhCode.Text = (!string.IsNullOrEmpty(ClsPublic.C_kala) ? ClsPublic.C_kala : txtFGhCode.Text.Trim());
                txtFGhName.Text = (!string.IsNullOrEmpty(ClsPublic.N_kala) ? ClsPublic.N_kala : txtFGhName.Text.Trim());
                txtFGhAnbar.Text = (!string.IsNullOrEmpty(ClsPublic.C_Anbar) ? ClsPublic.C_Anbar : txtFGhAnbar.Text.Trim());

                //txtFGhCode.ReadOnly = (!string.IsNullOrEmpty(ClsPublic.C_kala) ? true : false);
                //txtFGhName.ReadOnly = (!string.IsNullOrEmpty(ClsPublic.N_kala) ? true : false);
            }
        }

        private void btnClearMos_Click(object sender, EventArgs e)
        {
            ClearMostanad();
        }

        private void btnUpdMos_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbMosType.Text.Trim() == "")
                {
                    RadMessageBox.Show("نوع مستند را تعیین نمایید");
                    return;
                }
                // if (strMostanadPic.Trim() == "")
                //
                //     RadMessageBox.Show("فایل پیوست را تعیین نمایید");
                //     return;
                // }
                if (txtMosFaniNo.Text.Trim() == "")
                {
                    RadMessageBox.Show("شماره فنی را تعیین نمایید");
                    return;
                }
                if (strIDMostanad.Trim() == "")
                {
                    RadMessageBox.Show("مستند را تعیین نمایید");
                    return;
                }



                objTakvin.FK_IDMostanadType = cmbMosType.SelectedValue.ToString();
                objTakvin.DateSanad = dtpDateMos.Text.Trim();

                objTakvin.MostanadVaziat = (rbtnMosActive.Checked == true ? "1" : (rbtnMosNotActive.Checked == true ? "2" : "3"));
                objTakvin.MosNotBaznegari = (chkMosNotBaznegari.Checked == true ? "1" : "0");
                //objTakvin.IsPeyvast = (chkMosIsPeyvast.Checked==true ? "1" : "0");
                //objTakvin.MostanadPic = strMostanadPic ;


                if (rbtnMosActive.Checked == true)
                {

                    if (objTakvin.IsActiveMostanad() == "ISActive")
                    {
                        RadMessageBox.Show("از هر نوع مستند فقط یکی می تواند فعال باشد");
                        return;
                    }

                }


                RadMessageBox.Show(objTakvin.UpdMostanad());

                GrdMostanad.DataSource = objTakvin.selectMostanad().Tables[0];

            }
            catch (Exception exp)
            {
                RadMessageBox.Show("خطا در اجرای عملیات \n" + exp.Message);
            }
        }

        private void FrmTakvinTree_Load(object sender, EventArgs e)
        {
            try
            {
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
                    radPageGhProcess.Enabled = true;
                }
                else
                {
                    radPageGhProcess.Enabled = false;
                }
                ////----------------------------------------------------------------------radPageTakvinTree
                if (ShowInsNodeTree.Enabled == true)
                {
                    radPageTakvinTree.Enabled = true;
                }
                else
                {
                    radPageTakvinTree.Enabled = false;
                }
                ////----------------------------------------------------------------------radpagemostanadat
                if (ShowInsMostanadat.Enabled == true)
                {
                    radPageMostanadat.Enabled = true;
                }
                else
                {
                    radPageMostanadat.Enabled = false;
                }
                //radPageMostanadat.Enabled = false;
                //radPageTakvin.Pages[1].Hide();
                dtpDateMos.Value = DateTime.Now;

                //---------------------------------------------------------------------type mostanadat
                cmbMosType.DataSource = objTakvin.SelectMosType().Tables[0];
                cmbMosType.ValueMember = "IDMostanadType";
                cmbMosType.DisplayMember = "MostanadTypeName";
                cmbMosType.SelectedValue = 1;

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }

        private void btnMosPeyvast_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFDMos = new OpenFileDialog();
            OFDMos.Filter = "PDF Files (*.*)|*.pdf";
            if (OFDMos.ShowDialog() == DialogResult.OK)
            {
                strMostanadPic = OFDMos.FileName;
                txtMosPeyvast.Text = OFDMos.FileName;
            }
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

        private void txtChildFaniNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmTakvin_GhetehSearch frmST = new FrmTakvin_GhetehSearch();
                frmST.ShowDialog();

                //txtChildFaniNo.Text = (!string.IsNullOrEmpty(ClsTakvin.GetGhetehFaniNo) ? ClsTakvin.GetGhetehFaniNo : txtChildFaniNo.Text.Trim());
                //txtChildCode.Text = (!string.IsNullOrEmpty(ClsTakvin.GetGhetehCode) ? ClsTakvin.GetGhetehCode : txtChildCode.Text.Trim());
                //txtChildName.Text = (!string.IsNullOrEmpty(ClsTakvin.GetGheteName) ? ClsTakvin.GetGheteName : txtChildName.Text.Trim());
                //txtChildCAnbar.Text = (!string.IsNullOrEmpty(ClsTakvin.GetGhetehAnbar) ? ClsTakvin.GetGhetehAnbar : txtChildCAnbar.Text.Trim());
                txtChildFaniNo.Text = (!string.IsNullOrEmpty(ClsPublic.FaniNo) ? ClsPublic.FaniNo : txtChildFaniNo.Text.Trim());
                txtChildCode.Text = (!string.IsNullOrEmpty(ClsPublic.C_kala) ? ClsPublic.C_kala : txtChildCode.Text.Trim());
                txtChildName.Text = (!string.IsNullOrEmpty(ClsPublic.N_kala) ? ClsPublic.N_kala : txtChildName.Text.Trim());
                txtChildCAnbar.Text = (!string.IsNullOrEmpty(ClsPublic.C_Anbar) ? ClsPublic.C_Anbar : txtChildCAnbar.Text.Trim());
            }
        }

        private void btnAddMos_Click(object sender, EventArgs e)
        {
            try
            {
                //if (File.Exists("E:\\1.pdf"))
                //{
                //    RadMessageBox.Show("فایل مورد نظر وجود دارد");
                //return;
                //}
                //if (txtMosFaniNo.Text.Trim() == "" || string.IsNullOrEmpty(id_GhetehLocal))
                if (txtMosFaniNo.Text.Trim() == "")
                {
                    RadMessageBox.Show("شماره فنی را مشخص کنید");
                    return;
                }
                if (txtMosPeyvast.Text.Trim() == "")
                {
                    RadMessageBox.Show("فایل پیوست را مشخص کنید");
                    return;
                }
                if (txtMosVersion.Text.Trim()=="")
                {
                    RadMessageBox.Show("شماره ویرایش مستند را مشخص کنید");
                    return;
                }

                objTakvin.FK_IDMostanadType = cmbMosType.SelectedValue.ToString();
                objTakvin.DateSanad = dtpDateMos.Text.Trim();

                objTakvin.MostanadVaziat = (rbtnMosActive.Checked == true ? "1" : (rbtnMosNotActive.Checked == true ? "2" : "3"));
                objTakvin.MosVersion = txtMosVersion.Text.Trim();
                objTakvin.MosNotBaznegari = (chkMosNotBaznegari.Checked == true ? "1" : "0");
                //objTakvin.IsPeyvast = (chkMosIsPeyvast.Checked==true ? "1" : "0");
                //objTakvin.MostanadPic = strMostanadPic ;
                objTakvin.id_Gheteh = id_GhetehLocal;

                if (RadMessageBox.Show(this, "در صورت ثبت مستند قادر به حذف آن نیستسید؟", "", 
                    MessageBoxButtons.YesNo, RadMessageIcon.Exclamation, MessageBoxDefaultButton.Button3, RightToLeft.Yes) == DialogResult.Yes)
                {
                    DataTable dtselectIDMostanad = objTakvin.InsMostanad().Tables[0];
                    if (dtselectIDMostanad.Rows[0]["Return Value"].ToString() == "0")
                    {
                        RadMessageBox.Show("از هر نوع مستند فقط یکی می تواند فعال باشد");
                        return;
                    }
                    else if (dtselectIDMostanad.Rows[0]["Return Value"].ToString() == "-1")
                    {
                        RadMessageBox.Show("شماره ویرایش مستند تکراری است");
                        return;
                    }

                    string strfilenameMos = dtselectIDMostanad.Rows[0]["Return Value"].ToString() + ".pdf";
                    string strDesPathKol = objTakvin.strDesPathS + strfilenameMos;
                    string strSourcePath = @txtMosPeyvast.Text;
                    //RadMessageBox.Show(strSourcePath);
                    try
                    {
                        File.Copy(strSourcePath, strDesPathKol, false);//if false =if file exist not copy
                        RadMessageBox.Show("مستند با موفقیت اضافه شد");
                    }
                    catch (Exception expfile)
                    {
                        RadMessageBox.Show("خطا در ذخیره کردن فایل");
                    }
                    GrdMostanad.DataSource = objTakvin.selectMostanad().Tables[0];
                    
                    txtMosPeyvast.Clear();
                }
            }
            catch (Exception exp)
            {
                //RadMessageBox.Show("خطا در اجرای عملیات \n" + exp.Message);
                RadMessageBox.Show("خطا در اجرای عملیات \n" );
            }
        }

        private void btnDelMos_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMosFaniNo.Text.Trim() == "")
                {
                    RadMessageBox.Show("شماره فنی را تعیین نمایید");
                    return;
                }
                if (strIDMostanad.Trim() == "")
                {
                    RadMessageBox.Show("مستند را تعیین نمایید");
                    return;
                }
                //-----------------CONTROL ba tavajoh be shomareh virayesh , vaziat mostanad
                if (RadMessageBox.Show(this, "آیا مطمئن هستید این مستند پاک شود؟", "", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation, MessageBoxDefaultButton.Button3, RightToLeft.Yes) == DialogResult.Yes)
                {
                    RadMessageBox.Show(objTakvin.DelMostanad());
                    ClearMostanad();

                }
                GrdMostanad.DataSource = objTakvin.selectMostanad().Tables[0];
            }
            catch (Exception exp)
            {
                RadMessageBox.Show("خطا در اجرای عملیات \n" + exp.Message);
            }
        }

        private void GrdMostanad_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 11)
                {
                    FrmTakvinMostanad frmMos = new FrmTakvinMostanad();

                    // if (GrdMostanad.Rows[e.RowIndex].Cells["IsPeyvast"].Value.ToString() == "True")
                    // {
                    string strfilenameMos = GrdMostanad.Rows[e.RowIndex].Cells["IDMostanad"].Value.ToString() ;
                    string strDesPathKol = objTakvin.strDesPath + strfilenameMos + ".pdf";
                    try
                    {
                        frmMos.strMostanadName = strfilenameMos;
                        frmMos.MostanadLocation = strDesPathKol;
                        frmMos.ShowDialog();
                    }
                    catch (Exception exp)
                    {
                        RadMessageBox.Show("خطا در باز کردن فایل");
                    }

                    //}
                }
            }
            catch (Exception exp)
            {
                return;
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
       
        private void cmbProcN_Process_TextChanged(object sender, EventArgs e)
        {
            //txtProcID_process.Clear();
            //txtProcCodeGH.Clear();
            //txtProcAnbarGH.Clear();
            //txtProcNameGH.Clear();
        }

        private void cmbProcNameKargah_TextChanged(object sender, EventArgs e)
        {
            txtProcCodeKargah.Clear();
            objTakvin.strIdUnit = "";
        }

        private void cmbProcNameKargah_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbProcNameKargah.SelectedValue == null || cmbProcNameKargah.Text.ToString().Trim() == "System.Data.DataRowView")
                return;
            try
            {
                //----------------------------------------------------------combobox  DASTGAH
                cmbProcNameMachin.SelectedValue = null;
                cmbProcNameMachin.Text = "";
                txtProcCodeMachin.Text = "";


                objTakvin.strIdUnit = cmbProcNameKargah.SelectedValue.ToString();
                txtProcCodeKargah.Text = objTakvin.strIdUnit;
                 
                
                //objTakvin.strDastgah = txtProcCodeMachin.Text;
                //cmbProcNameMachin.DataSource = null;



            }
            catch (System.NullReferenceException exp)
            {
                RadMessageBox.Show("کارگاه را انتخاب نمایید \n " + exp.Message);
            }
        }

        private void cmbProcNameMachin_Enter(object sender, EventArgs e)
        {
            /*
            if (txtProcCodeKargah.Text.Trim() == "")
            {
                RadMessageBox.Show("کارگاه را انتخاب نمایید ");
                return;
            }
            else
            {
                DataTable dtSelectDastgah = objTakvin.SelectDastgah().Tables[0];
                if (dtSelectDastgah.Rows.Count==0)
                {
                    return;
                }
                
                cmbProcNameMachin.DataSource = dtSelectDastgah;
                cmbProcNameMachin.ValueMember = "ID_machine";
                cmbProcNameMachin.DisplayMember = "N_machine";
                //cmbProcNameMachin.SelectedIndex = 1;

                try
                {
                    txtProcCodeMachin.Text = cmbProcNameMachin.SelectedValue.ToString();
                    objTakvin.strDastgah = txtProcCodeMachin.Text;
                }
                catch (System.NullReferenceException exp)
                {
                    RadMessageBox.Show("دستگاه را انتخاب نمایید \n " + exp.Message);
                }
            }
             */ 
        }

        private void cmbProcNameMachin_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbProcNameMachin.SelectedValue == null || cmbProcNameMachin.Text.ToString().Trim() == "System.Data.DataRowView")
                return;
            try
            {
                objTakvin.strDastgah = cmbProcNameMachin.SelectedValue.ToString();
                txtProcCodeMachin.Text = objTakvin.strDastgah;
                
            }
            catch (System.NullReferenceException exp)
            {
                RadMessageBox.Show("کارگاه را انتخاب نمایید \n " + exp.Message);//change
            }
        }

        private void cmbProcNameMachin_TextChanged(object sender, EventArgs e)
        {
            txtProcCodeMachin.Clear();
            objTakvin.strDastgah = "";
        }

        private void cmbProcN_Process_Enter(object sender, EventArgs e)
        {
            try
            {


                //----------------------------------------------------------------------process
                if (string.IsNullOrEmpty(id_GhetehLocal))
                {
                    RadMessageBox.Show(this, "کالا را از درخت انتخاب نمایید");
                    return;
                }
                if (txtProcNodeAnbar.Text.Trim() != "13")
                {
                    RadMessageBox.Show(this, "فقط برای انبار در جریان می توان فرآیند ثبت نمود");
                    return;
                }
                cmbProcN_Process.DataSource = null;
                cmbProcN_Process.DataSource = objTakvin.SelectProccess().Tables[0];
                cmbProcN_Process.ValueMember = "ID_process";
                cmbProcN_Process.DisplayMember = "N_process";
                cmbProcN_Process.SelectedValue = null;
                cmbProcN_Process.Text = "";
                txtProcID_process.Clear();
            }
            catch
            {
                return;
            }
        }
        private void cmbProcN_Process_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbProcN_Process.SelectedValue == null || cmbProcN_Process.SelectedValue.ToString() == "System.Data.DataRowView"|| cmbProcN_Process.SelectedText.ToString() == "System.Data.DataRowView" )
                return;
            try
            {
                //this.ActiveControl = txtProcID_process;
                txtProcID_process.Text = cmbProcN_Process.SelectedValue.ToString();
                if (txtProcNodeCode.Text.Trim() != "" && txtProcID_process.Text.Trim() != "System.Data.DataRowView" && txtProcID_process.Text.Trim() != "") //change
                {
                    if (txtProcNodeCode.Text.Length!=12)
                    {
                        RadMessageBox.Show(this, "کد کالا کمتر از 12 رقم است");
                        cmbProcN_Process.SelectedValue = null;
                        cmbProcN_Process.Text="";
                        
                        return;
                    }
                    if (txtProcNodeAnbar.Text.Trim() != "13" && cmbProcN_Process.SelectedValue != null)
                    {
                        RadMessageBox.Show(this, "فقط برای انبار در جریان می توان فرآیند ثبت نمود");
                        cmbProcN_Process.SelectedValue = null;
                        cmbProcN_Process.Text = "";

                        return;
                    }
                    txtProcCodeGH.Text = txtProcNodeCode.Text.Substring(0, 9) + txtProcID_process.Text.Trim();
                    txtProcAnbarGH.Text = "13";
                    txtProcNameGH.Text = txtProcNodeName.Text + " - " + cmbProcN_Process.SelectedText.ToString().Trim();
                    GetProcessGheteh();
                }

                
            }
            catch (System.NullReferenceException exp)
            {
                RadMessageBox.Show("فرآیند را انتخاب نمایید \n " + exp.Message);
            }



        }

        private void txtProcNodeFaniNo_TextChanged(object sender, EventArgs e)
        {
            SEdtProcMasir.Value = 1;
            objTakvin.strProcMasir = SEdtProcMasir.Value.ToString();
            
            //----------------------------------------------------------------------kargah ( unit )
            cmbProcNameKargah.DataSource = objTakvin.SelectUnit().Tables[0];
            cmbProcNameKargah.ValueMember = "IdUnit";
            cmbProcNameKargah.DisplayMember = "onvan";
            cmbProcNameKargah.SelectedValue = null;
            cmbProcNameKargah.Text = "";
            txtProcCodeKargah.Clear();
            //--------------------------------------------------------------------
           
        }

        private void txtProcCodeKargah_TextChanged(object sender, EventArgs e)
        {
            cmbProcNameMachin.DataSource = null;
            if (txtProcCodeKargah.Text.Trim() == "" || cmbProcNameKargah.SelectedValue == null)
            {
                return;
            }
            else
            {
                objTakvin.strIdUnit = txtProcCodeKargah.Text;
                DataTable dtSelectDastgah = new DataTable();
                try
                {
                     cmbProcNameMachin.DataSource = null;
                     dtSelectDastgah = objTakvin.SelectDastgah().Tables[0];
                }
                catch
                {
                    return;
                }
                if (dtSelectDastgah.Rows.Count == 0)
                {
                    return;
                }
                //cmbProcNameMachin.it
                cmbProcNameMachin.DataSource = null;
                cmbProcNameMachin.DataSource = dtSelectDastgah;
                cmbProcNameMachin.ValueMember = "ID_machine";
                cmbProcNameMachin.DisplayMember = "N_machine";
                cmbProcNameMachin.SelectedValue = null;
                cmbProcNameMachin.Text = "";
            }
        }

        private void btnClearProc_Click(object sender, EventArgs e)
        {
            ClearProcess("");
        }

        private void txtMotealegatCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmKala frmK = new FrmKala();
                frmK.strC_Anbar = "10,11,18";     // anbar ghaleb va abzar
                frmK.ShowDialog();
                txtMotealeghatCode.Text = (!string.IsNullOrEmpty(ClsPublic.C_kala) ? ClsPublic.C_kala : txtMotealeghatCode.Text.Trim());
                txtMotealeghatName.Text = (!string.IsNullOrEmpty(ClsPublic.N_kala) ? ClsPublic.N_kala : txtMotealeghatName.Text.Trim());
                txtMotealeghatAnbar.Text = (!string.IsNullOrEmpty(ClsPublic.C_Anbar) ? ClsPublic.C_Anbar : txtMotealeghatAnbar.Text.Trim());

                //txtMotealegatCode.ReadOnly = (!string.IsNullOrEmpty(ClsPublic.C_kala) ? true : false);
                //txtMotealegatName.ReadOnly = (!string.IsNullOrEmpty(ClsPublic.N_kala) ? true : false);
            }
        }

        private void btnAddProc_Click(object sender, EventArgs e)
        {
            objTakvin.strFaniNoKala = "";
            if (objTakvin.Select_TreeTaeed().Tables[0].Rows[0]["Opr"].ToString() == "True")
            {
                RadMessageBox.Show(" درخت تایید شده است");
                return;
            }
            try
            {
                
                if (string.IsNullOrEmpty(id_GhetehLocal) || txtProcNodeFaniNo.Text.Trim() == "")
                {
                    RadMessageBox.Show(" کالا را از درخت تعیین نمایید");
                    return;
                }
                //if (objTakvin.IsRootTree() == "True")
                //{
                //    RadMessageBox.Show(" ریشه نمی تواند فرآیند ساخت داشته باشد");
                //    return;
                //}
                if (rbtnProcKharid.Checked != true && rbtnProcOutSource.Checked != true && rbtnProcTolid.Checked != true && rbtnProcTarkib.Checked != true)
                {
                    RadMessageBox.Show("نوع فرآیند را مشخص کنید");
                    return;
                }
                if (txtProcNodeAnbar.Text.Trim() != "13")
                {
                    RadMessageBox.Show(this, "فقط برای انبار در جریان می توان فرآیند ثبت نمود");
                    return;
                }
                if (txtProcFaniNoGH.Text.Trim() == "")
                {
                    RadMessageBox.Show("شماره فنی قطعه فرآیند را تعیین نمایید");
                    return;
                }
                if (SEdtProcMasir.Value.ToString() == "")
                {
                    RadMessageBox.Show("مسیر فرآیند را تعیین نمایید");
                    return;
                }
                if (txtProcID_process.Text.Trim() == "")
                {
                    RadMessageBox.Show("فرآیند را تعیین نمایید");
                    return;
                }
                if (SEdtProcTartibCustom.Value.ToString() == "")
                {
                    RadMessageBox.Show(" ترتیب فرآیند را تعیین نمایید");
                    return;
                }
                if (txtProcCodeGH.Text.Trim() == "")
                {
                    RadMessageBox.Show(" کد قطعه فرآیند را تعیین نمایید");
                    return;
                }
                if (txtProcCodeKargah.Text.Trim() == "" && rbtnProcTolid.Checked==true)
                {
                    RadMessageBox.Show(" کارگاه تولیدی را تعیین نمایید");
                    return;
                }
                //if (txtProcNafar.Text.Trim() == "" && rbtnProcTolid.Checked == true)
                //{
                //    RadMessageBox.Show(" نفر ساعت را تعیین نمایید");
                //    return;
                //}
                if (txtProcCodeKargah.Text.Trim() == "" && rbtnProcTarkib.Checked == true)
                {
                    RadMessageBox.Show(" کارگاه تولیدی را تعیین نمایید");
                    return;
                }
                //if (txtProcNafar.Text.Trim() == "" && rbtnProcTarkib.Checked == true)
                //{
                //    RadMessageBox.Show(" نفر ساعت را تعیین نمایید");
                //    return;
                //}
                //if (txtProcTime_standard.Text.Trim() == "" && rbtnProcTolid.Checked == true)
                //{
                 //   RadMessageBox.Show(" زمان استاندارد را تعیین نمایید");
                //    return;
                //}
                if (txtProcVaznKH.Text.Trim() == "")
                {
                    RadMessageBox.Show(" وزن خالص را تعیین نمایید");
                    return;
                }
                if (txtProcPert.Text.Trim() == "")
                {
                    RadMessageBox.Show(" پرت مواد را تعیین نمایید");
                    return;
                }
                InsGhetehProcess("0");
                
                //if (txtChildName.Text.Trim() == "")
                //{
                //    RadMessageBox.Show("نام کالا را وارد نمایید");
                //    return;
                //}


                
                
                 //-------------------------------------------------------------Motealegat
                 grdMotealeghat.DataSource = null;
                 grdMotealeghat.DataSource = objTakvin.SelectMotealegat().Tables[0];
                //------------------------------------------------------------------process
                 grdProcGheteh.DataSource = null;
                 grdProcGheteh.DataSource = objTakvin.SelectProcessGheteh().Tables[0];
                 btnAddMotealeghat.Enabled = true;
                     
                
            }


            catch (Exception exp)
            {
                RadMessageBox.Show("خطا در اجرای عملیات \n" + exp.Message);
            }
        }

        private void cmbProcN_ProcessPish_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbProcN_ProcessPish.SelectedValue == null)
                return;
            try
            {
                txtProcID_processPish.Text = cmbProcN_ProcessPish.SelectedValue.ToString();
                
            }
            catch (System.NullReferenceException exp)
            {
                return;
                //RadMessageBox.Show("پیش فرآیند را انتخاب نمایید \n " + exp.Message);
            }
        }

        private void cmbProcN_ProcessPish_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(id_GhetehLocal))
            {
                RadMessageBox.Show(this, "کالا را از درخت انتخاب نمایید");
                return;
            }
            DataTable dtSelectProcessPish = new DataTable();
            try
            {
                cmbProcN_ProcessPish.DataSource = null;
                if(chkProcAllPishProcess.Checked==true)
                {
                    dtSelectProcessPish = objTakvin.SelectProcessPish("1").Tables[0];
                }
                else
                {
                    dtSelectProcessPish = objTakvin.SelectProcessPish("0").Tables[0];
                }
            }
            catch
            {
                return;
            }
            if (dtSelectProcessPish.Rows.Count == 0)
            {
                return;
            }
            //cmbProcNameMachin.it
            cmbProcN_ProcessPish.DataSource = null;
            cmbProcN_ProcessPish.DataSource = dtSelectProcessPish;
            cmbProcN_ProcessPish.ValueMember = "FK_ID_process";
            cmbProcN_ProcessPish.DisplayMember = "N_process";
            cmbProcN_ProcessPish.SelectedValue = null;
            cmbProcN_ProcessPish.Text = "";
            txtProcID_processPish.Clear();
        }

        private void btnProcSearchCode_Click(object sender, EventArgs e)
        {
           
           GetProcessGheteh();
        }
       
        private void txtProcCodeGH_TextChanged(object sender, EventArgs e)
        {
            //GetProcessGheteh();
        }

        private void grdProcGheteh_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                //ClearProcess("");

                SEdtProcMasir.Value = Convert.ToDecimal(grdProcGheteh.Rows[e.RowIndex].Cells["MasirProcess"].Value);
                objTakvin.strProcMasir = SEdtProcMasir.Value.ToString();
                cmbProcN_Process.Text = grdProcGheteh.Rows[e.RowIndex].Cells["N_process"].Value.ToString();
                txtProcID_process.Text = grdProcGheteh.Rows[e.RowIndex].Cells["FK_ID_process"].Value.ToString();
                cmbProcN_ProcessPish.Text = grdProcGheteh.Rows[e.RowIndex].Cells["N_processPish"].Value.ToString();
                txtProcID_processPish.Text = grdProcGheteh.Rows[e.RowIndex].Cells["FK_ID_processPish"].Value.ToString();
                SEdtProcTartibCustom.Value  = Convert.ToInt32(grdProcGheteh.Rows[e.RowIndex].Cells["TartibCustom"].Value);

                strId_GhetehDtl = grdProcGheteh.Rows[e.RowIndex].Cells["id_Gheteh"].Value.ToString();
                objTakvin.strProcid_GhetehDtl = strId_GhetehDtl;


                txtProcFaniNoGH.Text = grdProcGheteh.Rows[e.RowIndex].Cells["FaniNo"].Value.ToString();
                txtProcCodeGH.Text = grdProcGheteh.Rows[e.RowIndex].Cells["GhetehCode"].Value.ToString();
                txtProcNameGH.Text = grdProcGheteh.Rows[e.RowIndex].Cells["GheteName"].Value.ToString();
                txtProcAnbarGH.Text = grdProcGheteh.Rows[e.RowIndex].Cells["GhetehAnbar"].Value.ToString();
                cmbProcNameKargah.Text = grdProcGheteh.Rows[e.RowIndex].Cells["onvan"].Value.ToString();
                cmbProcNameKargah.SelectedValue = grdProcGheteh.Rows[e.RowIndex].Cells["FK_ID_unit"].Value;
                txtProcCodeKargah.Text = grdProcGheteh.Rows[e.RowIndex].Cells["FK_ID_unit"].Value.ToString();
                cmbProcNameMachin.Text = grdProcGheteh.Rows[e.RowIndex].Cells["N_machine"].Value.ToString();
                cmbProcNameMachin.SelectedValue = grdProcGheteh.Rows[e.RowIndex].Cells["FK_ID_machine"].Value;
                txtProcCodeMachin.Text = grdProcGheteh.Rows[e.RowIndex].Cells["FK_ID_machine"].Value.ToString();
                txtProcDesc.Text = grdProcGheteh.Rows[e.RowIndex].Cells["ProcDesc"].Value.ToString();

                txtProcHofreh.Text = grdProcGheteh.Rows[e.RowIndex].Cells["hofre_tedad"].Value.ToString();


                txtProcNafar.Text = grdProcGheteh.Rows[e.RowIndex].Cells["nafar_tedad"].Value.ToString();
                chkProcMovazi.Checked = Convert.ToBoolean(grdProcGheteh.Rows[e.RowIndex].Cells["ProcMovazi"].Value);

                txtProcPert.Text = grdProcGheteh.Rows[e.RowIndex].Cells["PertMAval"].Value.ToString();
                BastehZaman = Convert.ToDouble(grdProcGheteh.Rows[e.RowIndex].Cells["Zaman_standard"].Value);
                txtProcTime_standard.Text = BastehZaman.ToString();
                txtProcVaznKH.Text = grdProcGheteh.Rows[e.RowIndex].Cells["VaznKhales"].Value.ToString();

                rbtnProcActive.Checked = Convert.ToBoolean(grdProcGheteh.Rows[e.RowIndex].Cells["VaziatEjraee"].Value);
                rbtnProcNotActive.Checked = !Convert.ToBoolean(grdProcGheteh.Rows[e.RowIndex].Cells["VaziatEjraee"].Value);
                chkProcMovazi.Checked= Convert.ToBoolean(grdProcGheteh.Rows[e.RowIndex].Cells["ProcMovazi"].Value);
                rbtnProcKharid.Checked = Convert.ToBoolean(grdProcGheteh.Rows[e.RowIndex].Cells["IsKharid"].Value);
                rbtnProcTolid.Checked = Convert.ToBoolean(grdProcGheteh.Rows[e.RowIndex].Cells["IsTolid"].Value);
                rbtnProcOutSource.Checked = Convert.ToBoolean(grdProcGheteh.Rows[e.RowIndex].Cells["IsOutSource"].Value);
                rbtnProcTarkib.Checked = Convert.ToBoolean(grdProcGheteh.Rows[e.RowIndex].Cells["IsTarkib"].Value);

                btnUpdProc.Enabled = true;
                btnDelProc.Enabled = true;
                //btnAddProc.Enabled = false;
                //cmbProcN_Process.Enabled = false;
                cmbProcN_ProcessPish.Enabled = false;
                SEdtProcMasir.Enabled = false;
                SEdtProcTartibCustom.Enabled = false;

                //-------------------------------------------------Motealegat
                ClearMotealeghat();
                btnAddMotealeghat.Enabled = true;
                grdMotealeghat.DataSource = null;
                grdMotealeghat.DataSource = objTakvin.SelectMotealegat().Tables[0];
                //----------------------------------------------------BOM
                btnAddBomGheteh.Enabled = true;
                GrdBomGheteh.DataSource = objTakvin.SelectBom("", "0").Tables[0];
                grdBomDTemp.DataSource =  objTakvin.SelectBomGheteh("", "0").Tables[0];
            }
            catch (Exception exp)
            {
                return;
            }
        }

        private void chkProcKharid_CheckStateChanged(object sender, EventArgs e)
        {
            /*
            if (chkProcKharid.Checked == true)
            {
                if (objTakvin.ISGhetehProcess() == "True")
                {
                    RadMessageBox.Show(" این کالا دارای فرآیند ساخت است");
                    chkProcKharid.Checked = false;
                    return;
                }
                ClearProcess("Kharid");
                chkProcTolid.Enabled = false;
                chkProcTolid.Checked = false;
                chkProcOutSource.Enabled = false;
                chkProcOutSource.Checked = false;
                
                btnUpdProc.Enabled = true;
                btnAddProc.Enabled = false;
                btnDelProc.Enabled = false;
                cmbProcN_Process.Enabled = false;
                SEdtProcMasir.Enabled = false;
                
                
            }
            else
            {
                chkProcTolid.Enabled = true;
                chkProcOutSource.Enabled = true;

                cmbProcN_Process.Enabled = true;
                SEdtProcMasir.Enabled = true;
            }
             */
        }

        private void chkProcOutSource_CheckStateChanged(object sender, EventArgs e)
        {
            /*
            if (chkProcOutSource.Checked == true)
            {
                if (objTakvin.ISGhetehProcess() == "True")
                {
                    RadMessageBox.Show(" این کالا دارای فرآیند ساخت است");
                    chkProcOutSource.Checked = false;
                    return;
                }
                ClearProcess("OutSource");

                chkProcTolid.Enabled = false;
                chkProcTolid.Checked = false;
                chkProcKharid.Enabled = false;
                chkProcKharid.Checked = false;

                btnUpdProc.Enabled = true;
                btnAddProc.Enabled = false;
                btnDelProc.Enabled = false;
                cmbProcN_Process.Enabled = false;
                SEdtProcMasir.Enabled = false;

            }
            else
            {
                chkProcTolid.Enabled = true;
                chkProcKharid.Enabled = true;

                cmbProcN_Process.Enabled = true;
                SEdtProcMasir.Enabled = true;
            }
             */ 
        }

        private void chkProcTolid_CheckStateChanged(object sender, EventArgs e)
        {
            /*
            if (chkProcTolid.Checked == true)
            {

                chkProcOutSource.Enabled = false;
                chkProcOutSource.Checked = false;
                chkProcKharid.Enabled = false;
                chkProcKharid.Checked = false;

            }
            else
            {
                chkProcOutSource.Enabled = true;
                chkProcKharid.Enabled = true;
            }
             */ 
        }

        private void btnUpdProc_Click(object sender, EventArgs e)
        {
            try
            {
                if (objTakvin.Select_TreeTaeed().Tables[0].Rows[0]["Opr"].ToString() == "True")
                {
                    RadMessageBox.Show(" درخت تایید شده است");
                    return;
                }
                if (string.IsNullOrEmpty(id_GhetehLocal))
                {
                    RadMessageBox.Show("کالا را از درخت تعیین کنید");
                    return;
                }
                //if (objTakvin.IsRootTree() == "True")
                //{
                //    RadMessageBox.Show(" ریشه نمی تواند فرآیند ساخت داشته باشد");
                //    return;
                //}
                if (rbtnProcKharid.Checked != true && rbtnProcOutSource.Checked != true && rbtnProcTolid.Checked != true && rbtnProcTarkib.Checked != true)
                {
                    RadMessageBox.Show("نوع فرآیند را مشخص کنید");
                    return;
                }
                //---------------------------------------------if kharid ari bashad
                if (rbtnProcKharid.Checked == true)
                {
                    objTakvin.strProcIsKharid = "1";
                    objTakvin.strProcIstolid = "0";
                    objTakvin.strProcIsOutsource = "0";
                    objTakvin.strProcIsTarkib = "0";
                    RadMessageBox.Show(objTakvin.UpdGhetehProcess());
                    grdProcGheteh.DataSource = null;
                    return;

                }
                //---------------------------------------------if outsource bashad
                if (rbtnProcOutSource.Checked == true)
                {
                    objTakvin.strProcIsKharid = "0";
                    objTakvin.strProcIstolid = "0";
                    objTakvin.strProcIsOutsource = "1";
                    objTakvin.strProcIsTarkib = "0";
                    RadMessageBox.Show(objTakvin.UpdGhetehProcess());
                    grdProcGheteh.DataSource = null;
                    return;

                }


                if (string.IsNullOrEmpty(strId_GhetehDtl))
                {
                    RadMessageBox.Show(" قطعه فرآیند را تعیین نمایید");
                    return;
                }
                if (txtProcFaniNoGH.Text.Trim() == "")
                {
                    RadMessageBox.Show("شماره فنی قطعه فرآیند را تعیین نمایید");
                    return;
                }
                if (txtProcCodeGH.Text.Trim() == "")
                {
                    RadMessageBox.Show(" کد قطعه فرآیند را تعیین نمایید");
                    return;
                }
                //if (txtProcNafar.Text.Trim() == "" && rbtnProcTolid.Checked == true)
                //{
                //    RadMessageBox.Show(" تعداد نفر  را تعیین نمایید ");
                //    return;
                //}
                //if (txtProcTime_standard.Text.Trim() == "")
                //{
                //    RadMessageBox.Show(" زمان استاندارد را تعیین نمایید");
                //    return;
                //}
                if (txtProcVaznKH.Text.Trim() == "")
                {
                    RadMessageBox.Show(" وزن خالص را تعیین نمایید");
                    return;
                }
                if (txtProcPert.Text.Trim() == "")
                {
                    RadMessageBox.Show(" پرت مواد را تعیین نمایید");
                    return;
                }
                objTakvin.strProcid_GhetehDtl = strId_GhetehDtl;
                objTakvin.strProcMasir = SEdtProcMasir.Value.ToString();
                objTakvin.strProcTartibCustom = SEdtProcTartibCustom.Value.ToString();
                objTakvin.strProcID_process = txtProcID_process.Text.Trim();
                objTakvin.strProcID_processPish = (!string.IsNullOrEmpty(txtProcID_processPish.Text.Trim()) ? txtProcID_processPish.Text.Trim() : "0");
                objTakvin.strProcDesc = txtProcDesc.Text.Trim();
                objTakvin.strProcFaniNoGH = txtProcFaniNoGH.Text.Trim();
                objTakvin.strProcCodeGH = (!string.IsNullOrEmpty(txtProcCodeGH.Text.Trim()) ? txtProcCodeGH.Text.Trim() : "0");
                objTakvin.strProcAnbarGH = (!string.IsNullOrEmpty(txtProcAnbarGH.Text.Trim()) ? txtProcAnbarGH.Text.Trim() : "0");
                objTakvin.strProcNameGH = txtProcNameGH.Text.Trim();
                objTakvin.strProcCodeKargah = (!string.IsNullOrEmpty(txtProcCodeKargah.Text.Trim()) ? txtProcCodeKargah.Text.Trim() : "0");
                objTakvin.strProcCodeMachin = (!string.IsNullOrEmpty(txtProcCodeMachin.Text.Trim()) ? txtProcCodeMachin.Text.Trim() : "0");
                objTakvin.strProcNafar = (!string.IsNullOrEmpty(txtProcNafar.Text.Trim()) ? txtProcNafar.Text.Trim() : "0");
                objTakvin.strProcMovazi = (chkProcMovazi.Checked == true ? "1" : "0");
                //objTakvin.strProcTime_standard = (!string.IsNullOrEmpty(txtProcTime_standard.Text.Trim()) ? txtProcTime_standard.Text.Trim() : "0");
                objTakvin.strProcTime_standard = txtProcTime_standard.Text;
                objTakvin.strProcTime_standard = objTakvin.strProcTime_standard.Replace("/", ".");
                objTakvin.strProcHofreh = (!string.IsNullOrEmpty(txtProcHofreh.Text.Trim()) ? txtProcHofreh.Text.Trim() : "0");
                //objTakvin.strProcVaznKH = (!string.IsNullOrEmpty(txtProcVaznKH.Text.Trim()) ? txtProcVaznKH.Text.Trim() : "0");
                //objTakvin.strProcPert = (!string.IsNullOrEmpty(txtProcPert.Text.Trim()) ? txtProcPert.Text.Trim() : "0");
                objTakvin.strProcVaznKH = txtProcVaznKH.Text;
                objTakvin.strProcVaznKH = objTakvin.strProcVaznKH.Replace("/", ".");
                objTakvin.strProcPert = txtProcPert.Text;
                objTakvin.strProcPert = objTakvin.strProcPert.Replace("/", ".");
                objTakvin.ProcDesc = txtProcDesc.Text.Trim();
                objTakvin.strProcIsKharid = (rbtnProcKharid.Checked == true ? "1" : "0");
                objTakvin.strProcIstolid = (rbtnProcTolid.Checked == true ? "1" : "0");
                objTakvin.strProcIsOutsource = (rbtnProcOutSource.Checked == true ? "1" : "0");
                objTakvin.strProcIsTarkib = (rbtnProcTarkib.Checked == true ? "1" : "0");
                objTakvin.strProcVaziatEjraee = (rbtnProcActive.Checked == true ? "1" : "0");

                //----------------------------------------------------------------tekrari bodan fanicode
                //string strCheckGhetehProcess = objTakvin.CheckGhetehProcess();
                //if (strCheckGhetehProcess == "GhetehCode")
                //{
                //    RadMessageBox.Show("این کد کالا تکراری است");
                //    return;
                //}
                //else if (strCheckGhetehProcess == "FaniNo")
                //{
                //    RadMessageBox.Show("این شماره فنی تکراری است");
                //    return;
                //}
                //else if (strCheckGhetehProcess == "GheteName")
                //{
                //    RadMessageBox.Show("این نام تکراری است");
                //    return;
                //}

                RadMessageBox.Show(objTakvin.UpdGhetehProcess());
                grdProcGheteh.DataSource = null;
                grdProcGheteh.DataSource = objTakvin.SelectProcessGheteh().Tables[0];
            }
            catch (Exception exp)
            {
                RadMessageBox.Show("خطا در اجرای عملیات \n" + exp.Message);
            }
        }

        private void btnDelProc_Click(object sender, EventArgs e)
        {
            try
            {
                if (objTakvin.Select_TreeTaeed().Tables[0].Rows[0]["Opr"].ToString() == "True")
                {
                    RadMessageBox.Show(" درخت تایید شده است");
                    return;
                }

                if (string.IsNullOrEmpty(strId_GhetehDtl))
                {
                    RadMessageBox.Show(" قطعه فرآیند را تعیین نمایید");
                    return;
                }

                objTakvin.strProcid_GhetehDtl = strId_GhetehDtl;
                objTakvin.strProcMasir = SEdtProcMasir.Value.ToString();
                if (objTakvin.SelectBomGheteh("", "0").Tables[0].Rows.Count > 0)
                {
                    RadMessageBox.Show(" قطعه فرآیند دارای ترکیب مواد است");
                    return;
                }
                DataTable dtDelGhetehProcess = new DataTable();
                if (RadMessageBox.Show(this, "آیا مطمئن هستید این قطعه فرآیند پاک شود؟", "", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation, MessageBoxDefaultButton.Button3, RightToLeft.Yes) == DialogResult.Yes)
                {

                    dtDelGhetehProcess = objTakvin.DelGhetehProcess().Tables[0];
                }
                //if (dtDelGhetehProcess.Rows[0]["Return Value"].ToString() == "-1")
                //{
                //    RadMessageBox.Show("قطعه فرآیند دارای متعلقات است ");
                //    RadMessageBox.Show("قطعه فرآیند دارای برنامه تولید است ");
                //    return;
                //}
                //else
                //{
                if (dtDelGhetehProcess.Rows[0]["Return Value"].ToString() == "0")
                {
                    RadMessageBox.Show("قطعه فرآیند حذف شد ");
                    strId_GhetehDtl = "";
                    objTakvin.strProcid_GhetehDtl = "";
                    //btnAddMotealeghat.Enabled = false;
                    //btnDelProc.Enabled = false;
                    ClearProcess("");
                }


                //----------------------------------------------------------------process
                grdProcGheteh.DataSource = null;
                grdProcGheteh.DataSource = objTakvin.SelectProcessGheteh().Tables[0];
                //}

            }
            catch (Exception exp)
            {
                RadMessageBox.Show("خطا در اجرای عملیات \n" + exp.Message);
            }
        }

        private void btnAddMotealeghat_Click(object sender, EventArgs e)
        {
             /*//////////////////////////////////////////////////////////////////////////////////////movaghat
            if (objTakvin.Select_TreeTaeed().Tables[0].Rows[0]["Opr"].ToString() == "True")
            {
                RadMessageBox.Show(" درخت تایید شده است");
                return;
            }
              */ 
            if (string.IsNullOrEmpty(strId_GhetehDtl))
            {
                RadMessageBox.Show("ابتدا قطعه فرآیند را انتخاب یا ثبت نمایید");
                return;
            }
            if (txtMotealeghatCode.Text.Trim() == "")
            {
                RadMessageBox.Show("کد کالا را برای متعلقات انتخاب نمایید");
                return;
            }
            if (txtMotealeghatTedad.Text.Trim() == "")
            {
                RadMessageBox.Show("مقدار مربوطه را وارد کنید");
                return;
            }
            
            objTakvin.StrMotealeghatCode = txtMotealeghatCode.Text.Trim();
            objTakvin.strMotealeghatAnbar = txtMotealeghatAnbar.Text.Trim();
            objTakvin.strMotealeghatTedad = txtMotealeghatTedad.Text.Trim();
            if (rbtnMotealeghatGhaleb.Checked == true)
                objTakvin.StrMotealeghatType = "1";
            else
                if (rbtnMotealeghatAbzar.Checked == true)
                    objTakvin.StrMotealeghatType = "2";
                else
                    if (rbtnMotealeghatFix.Checked == true)
                        objTakvin.StrMotealeghatType = "3";
                    else
                        if (rbtnMotealeghatFarman.Checked == true)
                            objTakvin.StrMotealeghatType = "4";
                        else
                            if (rbtnMotealeghatSayer.Checked == true)
                                objTakvin.StrMotealeghatType = "5";
                            else
                                if (rbtnMotealeghatMasraf.Checked == true)
                                    objTakvin.StrMotealeghatType = "6";

            //----------------------------------------------check for tekrari 
            if (objTakvin.CheckMotealeghatCode() == "tekrari")
            {
                RadMessageBox.Show(" متعلقات تکراری است");
                return;
            }
            RadMessageBox.Show(objTakvin.InsMotealegat());
            //-------------------------------------------------------------Motealegat
            grdMotealeghat.DataSource = null;
            grdMotealeghat.DataSource = objTakvin.SelectMotealegat().Tables[0];
        }

        private void btnDelMotealeghat_Click(object sender, EventArgs e)
        {
            /*//////////////////////////////////////////////////////////////////////////////////////movaghat
            if (objTakvin.Select_TreeTaeed().Tables[0].Rows[0]["Opr"].ToString() == "True")
            {
                RadMessageBox.Show(" درخت تایید شده است");
                return;
            }
             */ 
            if (txtMotealeghatCode.Text.Trim() == "" || strId_GhetehDtl == "")
            {
                RadMessageBox.Show("قطعه فرآیند را انتخاب نمایید");
                return;
            }

            objTakvin.StrMotealeghatCode = txtMotealeghatCode.Text.Trim();


            if (RadMessageBox.Show(this, "آیا مطمئن هستید این متعلقات پاک شود؟", "", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation, MessageBoxDefaultButton.Button3, RightToLeft.Yes) == DialogResult.Yes)
            {

                RadMessageBox.Show(objTakvin.DelMotealegat());
                //-------------------------------------------------------------Motealegat
                grdMotealeghat.DataSource = null;
                grdMotealeghat.DataSource = objTakvin.SelectMotealegat().Tables[0];
            }
        }

        private void grdMotealeghat_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                txtMotealeghatCode.Text = grdMotealeghat.Rows[e.RowIndex].Cells["MotealegatCode"].Value.ToString();
                txtMotealeghatAnbar.Text = grdMotealeghat.Rows[e.RowIndex].Cells["Motealegatanbar"].Value.ToString();
                txtMotealeghatName.Text = grdMotealeghat.Rows[e.RowIndex].Cells["N_Kala"].Value.ToString();
                txtMotealeghatTedad.Text = grdMotealeghat.Rows[e.RowIndex].Cells["MotealegatTedad"].Value.ToString();
                string StrMotType = grdMotealeghat.Rows[e.RowIndex].Cells["MotealegatType"].Value.ToString();
                if (StrMotType == "1")
                    rbtnMotealeghatGhaleb.Checked = true;
                else
                    if (StrMotType == "2")
                        rbtnMotealeghatAbzar.Checked = true;
                    else
                        if (StrMotType == "3")
                            rbtnMotealeghatFix.Checked = true;
                        else
                            if (StrMotType == "4")
                                rbtnMotealeghatFarman.Checked = true;
                            else
                                if (StrMotType == "5")
                                    rbtnMotealeghatSayer.Checked = true;
                                else
                                    if (StrMotType == "6")
                                        rbtnMotealeghatMasraf.Checked = true;
                btnDelMotealeghat.Enabled = true;
            }
            catch (Exception exp)
            {
                return;
            }
        }

        private void SEdtProcMasir_ValueChanged(object sender, EventArgs e)
        {
            objTakvin.strProcMasir = SEdtProcMasir.Value.ToString();
            ClearProcess("");
        }

        private void txtChildCode_TextChanged(object sender, EventArgs e)
        {
            txtChildCAnbar.Clear();
        }

        private void txtFGhCode_TextChanged(object sender, EventArgs e)
        {
            //txtFGhAnbar.Clear();
        }

        private void btnAddBOM_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(strId_GhetehDtl))
            {
                RadMessageBox.Show("ابتدا قطعه فرآیند را انتخاب یا ثبت نمایید");
                return;
            }
            if (string.IsNullOrEmpty(txtProcFaniNoGH.Text.Trim()) || string.IsNullOrEmpty(txtProcCodeGH.Text.Trim()) || string.IsNullOrEmpty(txtProcAnbarGH.Text.Trim()))
            {
                RadMessageBox.Show("ابتدا قطعه فرآیند را انتخاب یا ثبت نمایید");
                return;
            }
            FrmTakvinBomGheteh frmBomGheteh = new FrmTakvinBomGheteh();
            frmBomGheteh.strId_GhetehDtl = strId_GhetehDtl;
            frmBomGheteh.txtBOMNodeFaniNo.Text = txtProcFaniNoGH.Text.Trim();
            frmBomGheteh.txtBOMNodeCode.Text = txtProcCodeGH.Text.Trim();
            frmBomGheteh.txtBOMNodeAnbar.Text = txtProcAnbarGH.Text.Trim();
            frmBomGheteh.txtBOMNodeName.Text = txtProcNameGH.Text.Trim();
            frmBomGheteh.txtBOMVaznKamel.Text = Convert.ToString(Convert.ToDouble(txtProcVaznKH.Text.Trim()) + Convert.ToDouble(txtProcPert.Text.Trim()));
            frmBomGheteh.ShowDialog();
        }

        private void txtKartonCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmKala frmK = new FrmKala();
                frmK.strC_Anbar = "10";
                //frmK.strC_zAnbar = "53";
                frmK.ShowDialog();
                txtBastehCode.Text = (!string.IsNullOrEmpty(ClsPublic.C_kala) ? ClsPublic.C_kala : txtBastehCode.Text.Trim());
                txtBastehName.Text = (!string.IsNullOrEmpty(ClsPublic.N_kala) ? ClsPublic.N_kala : txtBastehName.Text.Trim());
                txtBastehAnbar.Text = (!string.IsNullOrEmpty(ClsPublic.C_Anbar) ? ClsPublic.C_Anbar : txtBastehAnbar.Text.Trim());

                //txtFGhCode.ReadOnly = (!string.IsNullOrEmpty(ClsPublic.C_kala) ? true : false);
                //txtFGhName.ReadOnly = (!string.IsNullOrEmpty(ClsPublic.N_kala) ? true : false);
            }
        }

        private void btnClearBasteh_Click(object sender, EventArgs e)
        {
            ClearBasteh();
        }

        private void btnAddBasteh_Click(object sender, EventArgs e)
        {
            if (objTakvin.Select_TreeTaeed().Tables[0].Rows[0]["Opr"].ToString() == "True")
            {
                RadMessageBox.Show(" درخت تایید شده است");
                return;
            }
            if (IDTreeLocal == "")
            {
                RadMessageBox.Show("کالا را از درخت تعیین نمایید");
                return;
            }
            if (objTakvin.IsRootTree() == "False")
            {
                RadMessageBox.Show(" بسته بندی فقط بر روی ریشه تعریف می شود");
                return;
            }
            if (txtBastehCode.Text.Trim() == "")
            {
                RadMessageBox.Show(" بسته بندی را انتخاب نمایید");
                return;
            }
            objTakvin.StrBastehCode = txtBastehCode.Text.Trim();
            objTakvin.StrBastehAnbar = txtBastehAnbar.Text.Trim();
            objTakvin.StrBastehTedad = sEdtBastehTedad.Value.ToString();
            objTakvin.StrBastehMeghdar = txtMeghdarBaste.Text;
            objTakvin.StrBastehOlaviat = sEdtBastehOlaviat.Value.ToString();
            //objTakvin.StrBastehNafar = txtBastehNafar.Text.Trim();
            objTakvin.StrBastehInTolid=(chkBastehInTolid.Checked == true ? "1" : "0");
            //objTakvin.StrBastehZaman=string.IsNullOrEmpty(txt)
            try
            {

                DataTable dtInsGhetehBasteh = objTakvin.InsGhetehBasteh().Tables[0];
                if (dtInsGhetehBasteh.Rows[0]["Return Value"].ToString() == "-1")
                {
                    RadMessageBox.Show(" این بسته تکراری است ");
                    return;
                }
                //if (dtInsGhetehBasteh.Rows[0]["Return Value"].ToString() == "-2")
                //{
                //    RadMessageBox.Show("اولویت تکراری است");
                //    return;
                //}
                if (dtInsGhetehBasteh.Rows[0]["Return Value"].ToString() == "0")
                {
                    RadMessageBox.Show("اطلاعات با موفقیت ثبت شد");
                    grdBasteh.DataSource = objTakvin.SelectGhetehBasteh().Tables[0];
                }

            }
            catch (Exception exp)
            {
                RadMessageBox.Show("خطا در اجرای عملیات \n" + exp.Message);
            }

        }

        private void grdBasteh_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                txtBastehCode.Text = grdBasteh.Rows[e.RowIndex].Cells["BastehCode"].Value.ToString();
                objTakvin.StrBastehCode = txtBastehCode.Text.Trim();
                txtBastehAnbar.Text = grdBasteh.Rows[e.RowIndex].Cells["BastehAnbar"].Value.ToString();
                objTakvin.StrBastehAnbar = txtBastehAnbar.Text.Trim();
                sEdtBastehTedad.Value = Convert.ToInt32(grdBasteh.Rows[e.RowIndex].Cells["BastehTedad"].Value);
                txtMeghdarBaste.Text = grdBasteh.Rows[e.RowIndex].Cells["BastehMeghdar"].Value.ToString();
                objTakvin.StrBastehTedad = sEdtBastehTedad.Value.ToString();
                sEdtBastehOlaviat.Value = Convert.ToInt32(grdBasteh.Rows[e.RowIndex].Cells["BastehOlaviat"].Value);
                objTakvin.StrBastehOlaviat = sEdtBastehOlaviat.Value.ToString();
                txtBastehName.Text = grdBasteh.Rows[e.RowIndex].Cells["N_Kala"].Value.ToString();
                objTakvin.StrBastehNafar = grdBasteh.Rows[e.RowIndex].Cells["nafar_tedad"].Value.ToString();
                txtBastehNafar.Text = grdBasteh.Rows[e.RowIndex].Cells["nafar_tedad"].Value.ToString();
                objTakvin.StrBastehInTolid = grdBasteh.Rows[e.RowIndex].Cells["InTolidi"].Value.ToString();
                chkBastehInTolid.Checked = Convert.ToBoolean(grdBasteh.Rows[e.RowIndex].Cells["InTolidi"].Value);

                txtBastehCode.Enabled = false;
                //txtBastehAnbar.Enabled = false;
                //txtBastehName.Enabled = false;

                btnAddBasteh.Enabled = false;
                btnUpdBasteh.Enabled = true;
                btnDelBasteh.Enabled = true;
            }
            catch(Exception exp)
            {
                return;
            }

        }

        private void btnUpdBasteh_Click(object sender, EventArgs e)
        {
            if (objTakvin.Select_TreeTaeed().Tables[0].Rows[0]["Opr"].ToString() == "True")
            {
                RadMessageBox.Show(" درخت تایید شده است");
                return;
            }
            objTakvin.StrBastehTedad = sEdtBastehTedad.Value.ToString();
            objTakvin.StrBastehMeghdar = txtMeghdarBaste.Text;
            objTakvin.StrBastehOlaviat = sEdtBastehOlaviat.Value.ToString();
            // objTakvin.StrBastehNafar = txtBastehNafar.Text.Trim();
            objTakvin.StrBastehInTolid = (chkBastehInTolid.Checked == true ? "1" : "0");

            //if (objTakvin.CheckBastehOlaviat().Tables[0].Rows.Count > 0)
            //{
            //    RadMessageBox.Show("اولویت تکراری است");
            //    return;
            //}
            try
            {
                RadMessageBox.Show(objTakvin.UpdGhetehBasteh());
                grdBasteh.DataSource = objTakvin.SelectGhetehBasteh().Tables[0];

            }
            catch (Exception exp)
            {
                RadMessageBox.Show("خطا در اجرای عملیات \n" + exp.Message);
            }
        }

        private void btnDelBasteh_Click(object sender, EventArgs e)
        {
            if (objTakvin.Select_TreeTaeed().Tables[0].Rows[0]["Opr"].ToString() == "True")
            {
                RadMessageBox.Show(" درخت تایید شده است");
                return;
            }
            try
            {

                if (RadMessageBox.Show(this, "آیا مطمئن هستید این بسته بندی پاک شود؟", "", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation, MessageBoxDefaultButton.Button3, RightToLeft.Yes) == DialogResult.Yes)
                {
                    RadMessageBox.Show(objTakvin.DelGhetehBasteh());
                    grdBasteh.DataSource = objTakvin.SelectGhetehBasteh().Tables[0];
                    ClearBasteh();

                }

            }
            catch (Exception exp)
            {
                RadMessageBox.Show("خطا در اجرای عملیات \n" + exp.Message);
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

        private void rbtnProcKharid_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnProcKharid.Checked == true)
            {
                if (objTakvin.ISGhetehProcess() == "True")
                {
                    RadMessageBox.Show(" این کالا دارای فرآیند ساخت است");
                    rbtnProcKharid.Checked = false;
                    return;
                }
                ClearProcess("Kharid");
                //chkProcTolid.Enabled = false;
                //chkProcTolid.Checked = false;
                //chkProcOutSource.Enabled = false;
                //chkProcOutSource.Checked = false;

                btnUpdProc.Enabled = true;
                //btnAddProc.Enabled = false;
                btnDelProc.Enabled = false;
                cmbProcN_Process.Enabled = false;
                SEdtProcMasir.Enabled = false;


            }
            else
            {
                //chkProcTolid.Enabled = true;
                //chkProcOutSource.Enabled = true;

                cmbProcN_Process.Enabled = true;
                SEdtProcMasir.Enabled = true;
            }
        }

        private void rbtnProcOutSource_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnProcOutSource.Checked == true)
            {
                if (objTakvin.ISGhetehProcess() == "True")
                {
                    RadMessageBox.Show(" این کالا دارای فرآیند ساخت است");
                    rbtnProcOutSource.Checked = false;
                    return;
                }
                ClearProcess("OutSource");

                //chkProcTolid.Enabled = false;
                //chkProcTolid.Checked = false;
                //chkProcKharid.Enabled = false;
                //chkProcKharid.Checked = false;

                btnUpdProc.Enabled = true;
                //btnAddProc.Enabled = false;
                btnDelProc.Enabled = false;
                cmbProcN_Process.Enabled = false;
                SEdtProcMasir.Enabled = false;

            }
            else
            {
                //chkProcTolid.Enabled = true;
              //  chkProcKharid.Enabled = true;

                cmbProcN_Process.Enabled = true;
                SEdtProcMasir.Enabled = true;
            }
        }

        private void rbtnProcTolid_CheckedChanged(object sender, EventArgs e)
        {
            //if (rbtnProcTolid.Checked == true)
            //{

            //    //chkProcOutSource.Enabled = false;
            //    //chkProcOutSource.Checked = false;
            //    //chkProcKharid.Enabled = false;
            //    //chkProcKharid.Checked = false;

            //}
            //else
            //{
            //    chkProcOutSource.Enabled = true;
            //    chkProcKharid.Enabled = true;
            //}
        }

        private void txtProcVaznKH_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtProcVaznKamel.Text = Convert.ToString(Convert.ToDouble((txtProcVaznKH.Text.Trim() == "" ? "0" : txtProcVaznKH.Text.Trim())) + Convert.ToDouble(txtProcPert.Text.Trim() == "" ? "0" : txtProcPert.Text.Trim()));
            }
            catch { }
        }

        private void txtProcPert_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtProcVaznKamel.Text = Convert.ToString(Convert.ToDouble((txtProcVaznKH.Text.Trim() == "" ? "0" : txtProcVaznKH.Text.Trim())) + Convert.ToDouble(txtProcPert.Text.Trim() == "" ? "0" : txtProcPert.Text.Trim()));
            }
            catch { }
        }

        private void btnAddBomGheteh_Click(object sender, EventArgs e)
        {
            //if (objTakvin.Select_TreeTaeed().Tables[0].Rows[0]["Opr"].ToString() == "True")
            //{
            //    RadMessageBox.Show(" درخت تایید شده است");
            //    return;
            //}
            if (string.IsNullOrEmpty(strId_GhetehDtl))
            {
                RadMessageBox.Show("ابتدا قطعه فرآیند را انتخاب یا ثبت نمایید");
                return;
            }
            if (string.IsNullOrEmpty(txtProcFaniNoGH.Text.Trim()) || string.IsNullOrEmpty(txtProcCodeGH.Text.Trim()) || string.IsNullOrEmpty(txtProcAnbarGH.Text.Trim()))
            {
                RadMessageBox.Show("ابتدا قطعه فرآیند را انتخاب یا ثبت نمایید");
                return;
            }


            StrID_BOM = txtID_Bom.Text.Trim();

            if (string.IsNullOrEmpty(StrID_BOM))
            {
                RadMessageBox.Show("ترکیب مواد را مشخص کنید");
                return;
            }
            objTakvin.StrID_Bom = StrID_BOM;
            //objTakvin.strProcid_GhetehDtl = strId_GhetehDtl;
            objTakvin.StrBomOlaviat = SEdtOlaviatBom.Value.ToString();
            try
            {

                DataTable dtInsBOMGheteh = objTakvin.InsBOMGheteh().Tables[0];
                if (dtInsBOMGheteh.Rows[0]["Return Value"].ToString() == "-1")
                {
                    RadMessageBox.Show(" این ترکیب مواد تکراری است ");
                    return;
                }
                if (dtInsBOMGheteh.Rows[0]["Return Value"].ToString() == "-2")
                {
                    RadMessageBox.Show("اولویت تکراری است");
                    return;
                }
                if (dtInsBOMGheteh.Rows[0]["Return Value"].ToString() == "0")
                {
                    RadMessageBox.Show("اطلاعات با موفقیت ثبت شد");
                    GrdBomGheteh.DataSource = objTakvin.SelectBom("1", "0").Tables[0];
                    grdBomDTemp.DataSource = objTakvin.SelectBomGheteh("1", "0").Tables[0];
                }

            }
            catch (Exception exp)
            {
                RadMessageBox.Show("خطا در اجرای عملیات \n" + exp.Message);
            }

        }

        private void txtID_Bom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (string.IsNullOrEmpty(strId_GhetehDtl))
                {
                    RadMessageBox.Show("ابتدا قطعه فرآیند را انتخاب یا ثبت نمایید");
                    return;
                }
                if (string.IsNullOrEmpty(txtProcFaniNoGH.Text.Trim()) || string.IsNullOrEmpty(txtProcCodeGH.Text.Trim()) || string.IsNullOrEmpty(txtProcAnbarGH.Text.Trim()))
                {
                    RadMessageBox.Show("ابتدا قطعه فرآیند را انتخاب یا ثبت نمایید");
                    return;
                }
                FrmTakvinBomSearch frmBS = new FrmTakvinBomSearch();
                frmBS.strISVaziatEjraee = "1";
                frmBS.ShowDialog();

                txtID_Bom.Text = (!string.IsNullOrEmpty(ClsTakvin.GetID_Bom) ? ClsTakvin.GetID_Bom : txtID_Bom.Text.Trim());
                txtNameBom.Text = (!string.IsNullOrEmpty(ClsTakvin.GetNameBom) ? ClsTakvin.GetNameBom : txtNameBom.Text.Trim());


                StrID_BOM = txtID_Bom.Text.Trim();
                objTakvin.StrID_Bom = StrID_BOM;
                if (!string.IsNullOrEmpty(StrID_BOM))
                {
                    GrdBomGheteh.DataSource = objTakvin.SelectBom("", "0").Tables[0];
                    grdBomDTemp.DataSource = objTakvin.SelectBomGheteh("", "0").Tables[0];
                    btnAddBomGheteh.Enabled = true;
                    btnDelBomGheteh.Enabled = false;
                    btnUpdBomGheteh.Enabled = false;

                }
            }
        }

        private void btnUpdBomGheteh_Click(object sender, EventArgs e)
        {
            //if (objTakvin.Select_TreeTaeed().Tables[0].Rows[0]["Opr"].ToString() == "True")
            //{
            //    RadMessageBox.Show(" درخت تایید شده است");
            //    return;
            //}
            if (string.IsNullOrEmpty(strId_GhetehDtl))
            {
                RadMessageBox.Show("ابتدا قطعه فرآیند را انتخاب یا ثبت نمایید");
                return;
            }
            if (string.IsNullOrEmpty(txtProcFaniNoGH.Text.Trim()) || string.IsNullOrEmpty(txtProcCodeGH.Text.Trim()) || string.IsNullOrEmpty(txtProcAnbarGH.Text.Trim()))
            {
                RadMessageBox.Show("ابتدا قطعه فرآیند را انتخاب یا ثبت نمایید");
                return;
            }
            StrID_BOM = txtID_Bom.Text.Trim();

            if (string.IsNullOrEmpty(StrID_BOM))
            {
                RadMessageBox.Show("ترکیب مواد را مشخص کنید");
                return;
            }
            objTakvin.StrID_Bom = StrID_BOM;
            //objTakvin.strProcid_GhetehDtl = strId_GhetehDtl;
            objTakvin.StrBomOlaviat = SEdtOlaviatBom.Value.ToString();
            if (objTakvin.CheckBomOlaviat().Tables[0].Rows.Count > 0)
            {
                RadMessageBox.Show("اولویت تکراری است");
                return;
            }
            try
            {
                RadMessageBox.Show(objTakvin.UpdBOMGheteh());
                GrdBomGheteh.DataSource = objTakvin.SelectBom("1", "0").Tables[0];
                grdBomDTemp.DataSource = objTakvin.SelectBomGheteh("1", "0").Tables[0];

            }
            catch (Exception exp)
            {
                RadMessageBox.Show("خطا در اجرای عملیات \n" + exp.Message);
            }
        }

        private void btnDelBomGheteh_Click(object sender, EventArgs e)
        {
            if (objTakvin.Select_TreeTaeed().Tables[0].Rows[0]["Opr"].ToString() == "True")
            {
                RadMessageBox.Show(" درخت تایید شده است");
                return;
            }
            if (string.IsNullOrEmpty(strId_GhetehDtl))
            {
                RadMessageBox.Show("ابتدا قطعه فرآیند را انتخاب یا ثبت نمایید");
                return;
            }
            if (string.IsNullOrEmpty(txtProcFaniNoGH.Text.Trim()) || string.IsNullOrEmpty(txtProcCodeGH.Text.Trim()) || string.IsNullOrEmpty(txtProcAnbarGH.Text.Trim()))
            {
                RadMessageBox.Show("ابتدا قطعه فرآیند را انتخاب یا ثبت نمایید");
                return;
            }

            StrID_BOM = txtID_Bom.Text.Trim();
            if (string.IsNullOrEmpty(StrID_BOM))
            {
                RadMessageBox.Show("ترکیب مواد را مشخص کنید");
                return;
            }
            objTakvin.StrID_Bom = StrID_BOM;
            //objTakvin.strProcid_GhetehDtl = strId_GhetehDtl;
            try
            {

                if (RadMessageBox.Show(this, "آیا مطمئن هستید این ترکیب مواد پاک شود؟", "", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation, MessageBoxDefaultButton.Button3, RightToLeft.Yes) == DialogResult.Yes)
                {
                    RadMessageBox.Show(objTakvin.DelBOMGheteh());

                    ClearBomGheteh();
                    GrdBomGheteh.DataSource = objTakvin.SelectBom("", "0").Tables[0];
                    grdBomDTemp.DataSource = objTakvin.SelectBomGheteh("", "0").Tables[0];

                }

            }
            catch (Exception exp)
            {
                RadMessageBox.Show("خطا در اجرای عملیات \n" + exp.Message);
            }
        }

        private void btnClearBomGheteh_Click(object sender, EventArgs e)
        {
            ClearBomGheteh();
        }

        private void rbtnFGhFale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnFGhFale.Checked==true)
            {
                txtFGhGhotr.Enabled = false;
                txtFGhHeight.Enabled = false;
                txtFGhTool.Enabled = false;
                txtFGhGSalb.Enabled = true;
                txtFGhJens.Enabled = true;
                txtFGhChogali.Enabled = true;
            }
        }

        private void rbtnFGhOstovane_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnFGhOstovane.Checked == true)
            {
                txtFGhGhotr.Enabled = true;
                txtFGhHeight.Enabled = false;
                txtFGhTool.Enabled = true;
                txtFGhGSalb.Enabled = false;
                txtFGhJens.Enabled = true;
                txtFGhChogali.Enabled = true;
            }
        }

        private void rbtnFGhChargoosh_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnFGhChargoosh.Checked == true)
            {
                txtFGhGhotr.Enabled = true;
                txtFGhHeight.Enabled = true;
                txtFGhTool.Enabled = true;
                txtFGhGSalb.Enabled = false;
                txtFGhJens.Enabled = true;
                txtFGhChogali.Enabled = true;
            }
        }

        private void rbtnChildFale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnChildFale.Checked == true)
            {
                txtChildGhotr.Enabled = false;
                txtChildHeight.Enabled = false;
                txtChildTool.Enabled = false;
                txtChildGSalb.Enabled = true;
                txtChildChogali.Enabled = true;
                txtChildJens.Enabled = true;
            }
            
        }

        private void rbtnChildOstovane_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnChildOstovane.Checked == true)
            {
                txtChildGhotr.Enabled = true;
                txtChildHeight.Enabled = false;
                txtChildTool.Enabled = true;
                txtChildGSalb.Enabled = false;
                txtChildChogali.Enabled = true;
                txtChildJens.Enabled = true;
            }
            
        }

        private void rbtnChildChargoosh_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnChildChargoosh.Checked == true)
            {
                txtChildGhotr.Enabled = true;
                txtChildHeight.Enabled = true;
                txtChildTool.Enabled = true;
                txtChildGSalb.Enabled = false;
            }
            
        }

        private void GrdBomGheteh_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                txtID_Bom.Text = GrdBomGheteh.Rows[e.RowIndex].Cells["ID_Bom"].Value.ToString();
                txtNameBom.Text = GrdBomGheteh.Rows[e.RowIndex].Cells["NameBom"].Value.ToString();

                SEdtOlaviatBom.Value = Convert.ToInt32(GrdBomGheteh.Rows[e.RowIndex].Cells["olaviat"].Value);
                intBeforolaviat = Convert.ToInt32(GrdBomGheteh.Rows[e.RowIndex].Cells["olaviat"].Value);
                txtID_Bom.Enabled = false;
                txtNameBom.Enabled = false;

                //btnClearBomGheteh.Enabled = true;
                btnAddBomGheteh.Enabled = false;
                btnUpdBomGheteh.Enabled = true;
                btnDelBomGheteh.Enabled = true;
            }
            catch (Exception exp)
            {
                return;
            }
        }

        private void grdProcGheteh_Click(object sender, EventArgs e)
        {

        }

        private void rbtnFGhSayer_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnFGhSayer.Checked == true)
            {
                txtFGhGhotr.Enabled = false;
                txtFGhHeight.Enabled = false;
                txtFGhTool.Enabled = false;
                txtFGhGSalb.Enabled = false;
                txtFGhJens.Enabled = false;
                txtFGhChogali.Enabled = false;
            }
        }

        private void rbtnChildSayer_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnChildSayer.Checked == true)
            {
                txtChildGhotr.Enabled = false;
                txtChildHeight.Enabled = false;
                txtChildTool.Enabled = false;
                txtChildGSalb.Enabled = false;
                txtChildChogali.Enabled = false;
                txtChildJens.Enabled = false;
            }
        }

        private void btnCkalaDoc_Click(object sender, EventArgs e)
        {
            FrmKala frmK = new FrmKala();
            //frmK.strC_Anbar = "14";
            frmK.ShowDialog();
            txtMosFaniNo.Text = (!string.IsNullOrEmpty(ClsPublic.C_kala) ? ClsPublic.C_kala : txtCkala.Text.Trim());
            id_GhetehLocal = (!string.IsNullOrEmpty(ClsPublic.id_Gheteh) ? ClsPublic.id_Gheteh : txtCkala.Text.Trim());
            //txtNKala.Text = (!string.IsNullOrEmpty(ClsPublic.N_kala) ? ClsPublic.N_kala : txtNKala.Text.Trim());
            //txtCAnbar.Text = (!string.IsNullOrEmpty(ClsPublic.C_Anbar) ? ClsPublic.C_Anbar : txtCAnbar.Text.Trim());
        }
    }
}

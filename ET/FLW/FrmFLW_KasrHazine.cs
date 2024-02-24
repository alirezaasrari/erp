using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using FastReport;

namespace ET
{
    public partial class FrmFLW_KasrHazine : Telerik.WinControls.UI.RadForm
    {
        public FrmFLW_KasrHazine()
        {
            InitializeComponent();
        }
        public string strSend, strID_FormUnit;
        public string IntLevelTaeed, strIdTaeed, IntIdFormChart, IntIdMarhale;
        public int AccessGrdUnit = 0;
        private void FrmFLW_KasrHazine_Load(object sender, EventArgs e)
        {
            try
            {
                txtDateReport.Value = DateTime.Now;
                if (ClsFlw.Isnew != "1")
                    btnAddHeader.Enabled = false;
                if (string.IsNullOrEmpty(IntIdFormChart))
                {
                    txtIdKasr.Text = "";
                }
                
                ClsFlw obj = new ClsFlw();
                if (IntIdMarhale == "4")
                {
                    btnEnd.Enabled = true;
                    txtDescNamayande.Enabled = true;
                    txtDescMali.Enabled = false;
                }
                else
                {
                    if (IntIdMarhale == "5"| IntIdMarhale == "6")
                    {
                        btnEnd.Enabled = true;
                        txtDescMali.Enabled = true;
                        txtDescNamayande.Enabled = false;
                    }
                    else
                    {
                        btnEnd.Enabled = false;
                        txtDescNamayande.Enabled = false;
                        txtDescMali.Enabled = false;
                    }
                }

                DataTable dt = new DataTable();
                dt = obj.Select_KasrHazine(txtIdKasr.Text).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (IntIdMarhale != "1")
                    {
                        grpH.Enabled = false;
                    }
                    txtNameReporter.Text = dt.Rows[0]["NameReporter"].ToString();
                    txtDateReport.Text = dt.Rows[0]["DateReport"].ToString();
                    txtNameTaminkonande.Text = dt.Rows[0]["NameTaminkonande"].ToString();
                    txtEllat.Text = dt.Rows[0]["Ellat"].ToString();
                    txtTozihat.Text = dt.Rows[0]["Tozihat"].ToString();
                    txtDescNamayande.Text = dt.Rows[0]["DescNamayande"].ToString();
                    txtDescMali.Text = dt.Rows[0]["DescMali"].ToString();
                    cmbMarjaeShenasaie.Text = dt.Rows[0]["MarjaeShenasaie"].ToString();
                    txtSharh1.Text = dt.Rows[0]["Sharh1"].ToString();
                    txtSharh2.Text = dt.Rows[0]["Sharh2"].ToString();
                    txtSharh3.Text = dt.Rows[0]["Sharh3"].ToString();
                    txtSharh4.Text = dt.Rows[0]["Sharh4"].ToString();
                    grpDetail1.DataSource = obj.Select_KasrHazineUnits(txtIdKasr.Text).Tables[0];

                    dt = obj.Select_KasrHazineDoc(txtIdKasr.Text).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        if (IntIdMarhale != "1")
                        {
                            //grdDoc.Enabled = false;
                            //btnSabtDoc.Enabled = false;
                        }
                        grdDoc.DataSource = dt;
                    }
                }
                if (ClsFlw.IsOutBox == 1)
                {
                    btnAddHeader.Enabled = false;
                    btnEditHeader.Enabled = false;
                    btnSabtDoc.Enabled = false;
                    btnAdd.Enabled = false;
                    btnSend.Enabled = false;
                    btnBack.Enabled = false;
                    btnEnd.Enabled = false;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        private void btnAddHeader_Click(object sender, EventArgs e)
        {
            try
            {
                ClsFlw obj = new ClsFlw();
                obj.strIdKasr = "";
                obj.strNameReporter = txtNameReporter.Text;
                obj.strDateReport = txtDateReport.Text;
                obj.strNameTaminkonande = txtNameTaminkonande.Text;
                obj.strEllat = txtEllat.Text;
                obj.strTozihat = txtTozihat.Text;
                obj.strDescNamayande = txtDescNamayande.Text;
                obj.strDescMali = txtDescMali.Text;
                obj.strMarjaeShenasaie = cmbMarjaeShenasaie.Text;
                obj.strSharh1 = txtSharh1.Text;
                obj.strSharh2 = txtSharh2.Text;
                obj.strSharh3 = txtSharh3.Text;
                obj.strSharh4 = txtSharh4.Text;

                MessageBox.Show(obj.Ins_KasrHazineInsUpdate(1));
                txtIdKasr.Text = obj.Select_KasrHazineMax().Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ee)
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            try
            {
                ClsFlw obj = new ClsFlw();
                //if (IntIdMarhale == "4")
                //{
                //    obj.strValueVariable = "0";
                //    obj.strIdVariable = "43";
                //    obj.Update_Variable();
                //}
                //if (IntIdMarhale == "6")
                //{
                //    obj.strValueVariable = "0";
                //    obj.strIdVariable = "44";
                //    obj.Update_Variable();
                //}

                obj.strCheckTaeed = "3";
                obj.strDescTaeed = txtErja.Text;
                obj.strIdTaeed = strIdTaeed;

                MessageBox.Show(obj.Update_FormFlowTaeed());
                obj.Update_FormFlowTaeedActive();
                this.Close();
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        private void btnSabtDoc_Click(object sender, EventArgs e)
        {
            try
            {
                ClsFlw obj = new ClsFlw();
                obj.strIdKasr = txtIdKasr.Text;
                string filepath;
                if (LoadPic.ShowDialog() == DialogResult.OK)
                {
                    filepath = LoadPic.FileName;
                    byte[] filebyte = File.ReadAllBytes(filepath);
                    obj.bytPic = filebyte;
                    obj.strTitleDoc = Path.GetFileNameWithoutExtension(LoadPic.FileName);
                    obj.strcontentType = Path.GetExtension(LoadPic.FileName);
                    MessageBox.Show(obj.Ins_KasrHazineDocument());
                    grdDoc.DataSource = obj.Select_KasrHazineDoc(txtIdKasr.Text).Tables[0];
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        private void grdDoc_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "btnEdit")
                {
                    byte[] bytes;
                    string fileName, contentType;
                    bytes = (Byte[])grdDoc.Rows[e.RowIndex].Cells["DocKasr"].Value;
                    fileName = grdDoc.Rows[e.RowIndex].Cells["TitleDoc"].Value.ToString();
                    contentType = grdDoc.Rows[e.RowIndex].Cells["contentType"].Value.ToString();
                    Stream stream;
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "All files (*.*)|*.*";
                    saveFileDialog.FilterIndex = 1;
                    saveFileDialog.RestoreDirectory = true;
                    saveFileDialog.FileName = fileName + contentType;
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        stream = saveFileDialog.OpenFile();
                        stream.Write(bytes, 0, bytes.Length);
                        stream.Close();
                    }
                }
                if (e.Column.Name == "btnDelete")
                {
                    if (ClsFlw.IsOutBox == 1)
                    {
                        MessageBox.Show("امکان حذف سند وجود ندارد");
                        return;
                    }
                    ClsFlw obj = new ClsFlw();
                    obj.stridRow = grdDoc.Rows[e.RowIndex].Cells["IdRow"].Value.ToString();
                    MessageBox.Show(obj.Delete_KasrHazineDoc());
                    grdDoc.DataSource = obj.Select_KasrHazineDoc(txtIdKasr.Text).Tables[0];
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Report objReport = new Report();

            objReport.Load(ClsPublic.strRepPath + "KasrHazine.frx");
            objReport.SetParameterValue("IdKasr", txtIdKasr.Text);
            objReport.Print();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ClsFlw obj = new ClsFlw();
                obj.Unit = cmbUnit.Text;
                obj.UnitIndex = cmbUnit.SelectedIndex.ToString();
                obj.Fix = "";
                obj.IdH = txtIdKasr.Text;
                MessageBox.Show(obj.Ins_KasrHazineUnits());
                grpDetail1.DataSource = obj.Select_KasrHazineUnits(txtIdKasr.Text).Tables[0];
            }
            catch (Exception ee)
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        private void grpDetail1_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            //if (AccessGrdUnit != 1)
            //{
            //    MessageBox.Show("دسترسی وجود ندارد");
            //    return;
            //}
            try
            {
                if (ClsFlw.IsOutBox == 1)
                {
                    MessageBox.Show("امکان حذف سند وجود ندارد");
                    return;
                }
                if (e.Column.Name == "btnDelete")
                {
                    if (MessageBox.Show("آیا از حذف ردیف اطمینان دارید؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ClsFlw obj = new ClsFlw();
                        obj.IdD2 = grpDetail1.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                        MessageBox.Show(obj.Delete_NoneComolaince_D2());
                        grpDetail1.DataSource = obj.Select_KasrHazineUnits(txtIdKasr.Text).Tables[0];
                    }
                }
                if (e.Column.Name == "btnEdit")
                {
                    if (MessageBox.Show("آیا از تغییر ردیف اطمینان دارید؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ClsFlw obj = new ClsFlw();
                        MessageBox.Show(obj.Update_KasrHazineUnits(grpDetail1.Rows[e.RowIndex].Cells["Id"].Value.ToString(), grpDetail1.Rows[e.RowIndex].Cells["Fix"].Value.ToString()));
                        grpDetail1.DataSource = obj.Select_KasrHazineUnits(txtIdKasr.Text).Tables[0];
                    }
                }
            }
            catch
            {

            }
        }

        private void btnEditHeader_Click(object sender, EventArgs e)
        {
            try
            {
                ClsFlw obj = new ClsFlw();
                obj.strIdKasr = txtIdKasr.Text;
                obj.strNameReporter = txtNameReporter.Text;
                obj.strDateReport = txtDateReport.Text;
                obj.strNameTaminkonande = txtNameTaminkonande.Text;
                obj.strEllat = txtEllat.Text;
                obj.strTozihat = txtTozihat.Text;
                obj.strDescNamayande = txtDescNamayande.Text;
                obj.strDescMali = txtDescMali.Text;
                obj.strMarjaeShenasaie = cmbMarjaeShenasaie.Text;
                obj.strSharh1 = txtSharh1.Text;
                obj.strSharh2 = txtSharh2.Text;
                obj.strSharh3 = txtSharh3.Text;
                obj.strSharh4 = txtSharh4.Text;

                MessageBox.Show(obj.Ins_KasrHazineInsUpdate(2));
            }
            catch (Exception ee)
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (strSend == "0")
                {
                    MessageBox.Show("امکان تایید وجود ندارد");
                    return;
                }
                if (string.IsNullOrEmpty(IntIdFormChart))
                {
                    ClsFlw obj = new ClsFlw();
                    obj.strID_Form = "3";
                    //obj.strID_Unit = strIdUnit;
                    obj.strID_FormUnit = ClsFlw.ID_FormUnit;
                    obj.strCodeFormX = txtIdKasr.Text;
                    obj.Insert_CodeFormX();
                    obj.strIdCodeFormX = obj.Select_CodeFormXMax().Tables[0].Rows[0]["IdCodeFormX"].ToString();
                    obj.strTozihat = txtErja.Text;
                    MessageBox.Show(obj.Insert_FormFlowTaeed());

                    //obj.strCheckTaeed = "1";
                    //obj.strDescTaeed = txtErja.Text;
                    //obj.strIdTaeed = obj.Select_TaeedMax().Tables[0].Rows[0][0].ToString();
                    //obj.Update_FormFlowTaeed();
                    //obj.Update_FormFlowTaeedActive();

                    this.Close();
                }
                else
                {
                    ClsFlw obj = new ClsFlw();
                    if (Convert.ToInt16(IntIdMarhale) < 4)
                    {
                        if (obj.Select_KasrHazineUnitsFind(txtIdKasr.Text, "0").Tables[0].Rows.Count > 0)
                            obj.strValueVariable = "1";//tolid
                        else
                            obj.strValueVariable = "0";
                        obj.strIdVariable = "35";
                        obj.Update_Variable();

                        if (obj.Select_KasrHazineUnitsFind(txtIdKasr.Text, "1").Tables[0].Rows.Count > 0)
                            obj.strValueVariable = "1";//تدارکات
                        else
                            obj.strValueVariable = "0";
                        obj.strIdVariable = "36";
                        obj.Update_Variable();

                        if (obj.Select_KasrHazineUnitsFind(txtIdKasr.Text, "2").Tables[0].Rows.Count > 0)
                            obj.strValueVariable = "1";//اداری
                        else
                            obj.strValueVariable = "0";
                        obj.strIdVariable = "37";
                        obj.Update_Variable();

                        if (obj.Select_KasrHazineUnitsFind(txtIdKasr.Text, "3").Tables[0].Rows.Count > 0)
                            obj.strValueVariable = "1";//انتظامات
                        else
                            obj.strValueVariable = "0";
                        obj.strIdVariable = "38";
                        obj.Update_Variable();

                        if (obj.Select_KasrHazineUnitsFind(txtIdKasr.Text, "4").Tables[0].Rows.Count > 0)
                            obj.strValueVariable = "1";//Sale دولتی
                        else
                            obj.strValueVariable = "0";
                        obj.strIdVariable = "39";
                        obj.Update_Variable();

                        if (obj.Select_KasrHazineUnitsFind(txtIdKasr.Text, "5").Tables[0].Rows.Count > 0)
                            obj.strValueVariable = "1";//sale خصوصی
                        else
                            obj.strValueVariable = "0";
                        obj.strIdVariable = "40";
                        obj.Update_Variable();

                        if (obj.Select_KasrHazineUnitsFind(txtIdKasr.Text, "6").Tables[0].Rows.Count > 0)
                            obj.strValueVariable = "1";//بازرسی
                        else
                            obj.strValueVariable = "0";
                        obj.strIdVariable = "41";
                        obj.Update_Variable();

                        if (obj.Select_KasrHazineUnitsFind(txtIdKasr.Text, "7").Tables[0].Rows.Count > 0)
                            obj.strValueVariable = "1";//مالی
                        else
                            obj.strValueVariable = "0";
                        obj.strIdVariable = "42";
                        obj.Update_Variable();
                    }
                    if(IntIdMarhale=="4")
                    {
                        obj.strValueVariable = "1";
                        obj.strIdVariable = "43";
                        obj.Update_Variable();
                    }
                    if (IntIdMarhale == "6")
                    {
                        obj.strValueVariable = "1";
                        obj.strIdVariable = "44";
                        obj.Update_Variable();
                    }

                    obj.strCheckTaeed = "1";
                    obj.strDescTaeed = txtErja.Text;
                    obj.strIdTaeed = strIdTaeed;

                    MessageBox.Show(obj.Update_FormFlowTaeed());
                    obj.Update_FormFlowTaeedActive();
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }
    }
}

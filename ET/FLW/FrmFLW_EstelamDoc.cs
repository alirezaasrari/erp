using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.IO;

namespace ET
{
    public partial class FrmFLW_EstelamDoc : Telerik.WinControls.UI.RadForm
    {
        public FrmFLW_EstelamDoc()
        {
            InitializeComponent();
        }
        public string IdEstelamD;
        private void btnSabtDoc_Click(object sender, EventArgs e)
        {
            try
            {
                ClsFlw obj = new ClsFlw();
                obj.strIdEstelamD = IdEstelamD.ToString();
                string filepath;
                if (LoadPic.ShowDialog() == DialogResult.OK)
                {
                    filepath = LoadPic.FileName;
                    byte[] filebyte = File.ReadAllBytes(filepath);
                    obj.bytPic = filebyte;
                    obj.strTitleDoc = Path.GetFileNameWithoutExtension(LoadPic.FileName);
                    obj.strcontentType = Path.GetExtension(LoadPic.FileName);
                    MessageBox.Show(obj.Ins_EstelamDocument());
                    grdDoc.DataSource = obj.Select_EstelamDoc(IdEstelamD).Tables[0];
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        private void FrmFLW_EstelamDoc_Load(object sender, EventArgs e)
        {
            ClsFlw obj = new ClsFlw();
            grdDoc.DataSource = obj.Select_EstelamDoc(IdEstelamD).Tables[0];
        }

        private void grdDoc_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "btnEdit")
                {
                    byte[] bytes;
                    string fileName, contentType;
                    bytes = (Byte[])grdDoc.Rows[e.RowIndex].Cells["DocEstelam"].Value;
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
                    obj.strIdEstelamDoc = grdDoc.Rows[e.RowIndex].Cells["IdEstelamDoc"].Value.ToString();
                    MessageBox.Show(obj.Delete_EstelamDoc());
                    grdDoc.DataSource = obj.Select_EstelamDoc(IdEstelamD).Tables[0];
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }
    }
}

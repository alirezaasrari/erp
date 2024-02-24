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
    public partial class FrmFLW_NoncomplianceDoc : Telerik.WinControls.UI.RadForm
    {
        public int AccessGrdH = 0;
        public FrmFLW_NoncomplianceDoc()
        {
            InitializeComponent();
        }

        public string IdNoneComolainceD;
        private void btnSabtDoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (AccessGrdH != 1)
                {
                    MessageBox.Show("دسترسی وجود ندارد");
                    return;
                }
                ClsFlw obj = new ClsFlw();
                obj.IdNoneComolainceD = IdNoneComolainceD;
                string filepath;
                if (LoadPic.ShowDialog() == DialogResult.OK)
                {
                    filepath = LoadPic.FileName;
                    byte[] filebyte = File.ReadAllBytes(filepath);
                    obj.bytPic = filebyte;
                    obj.strTitleDoc = Path.GetFileNameWithoutExtension(LoadPic.FileName);
                    obj.strcontentType = Path.GetExtension(LoadPic.FileName);
                    MessageBox.Show(obj.Ins_NoneComolainceDDocument());
                    grdDoc.DataSource = obj.Select_NoneComolainceDoc(IdNoneComolainceD).Tables[0];
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
                    bytes = (Byte[])grdDoc.Rows[e.RowIndex].Cells["DocNoneComolaince"].Value;
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
                    if (AccessGrdH != 1)
                    {
                        MessageBox.Show("دسترسی وجود ندارد");
                        return;
                    }
                    if (ClsFlw.IsOutBox == 1)
                    {
                        MessageBox.Show("امکان حذف سند وجود ندارد");
                        return;
                    }
                    ClsFlw obj = new ClsFlw();
                    obj.IdNoneComolainceDoc = grdDoc.Rows[e.RowIndex].Cells["IdNoneComolainceDoc"].Value.ToString();
                    MessageBox.Show(obj.Delete_NoneComolainceDoc());
                    grdDoc.DataSource = obj.Select_NoneComolainceDoc(IdNoneComolainceD).Tables[0];
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        private void FrmFLW_NoncomplianceDoc_Load(object sender, EventArgs e)
        {
            ClsFlw obj = new ClsFlw();
            grdDoc.DataSource = obj.Select_NoneComolainceDoc(IdNoneComolainceD).Tables[0];
        }
    }
}

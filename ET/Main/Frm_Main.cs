using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

namespace ET
{
    public partial class Frm_Main : Telerik.WinControls.UI.RadForm
    {
        private CultureInfo m_culture;
        public static DataTable dt = new DataTable();
        public static DataRow[] dr;      
        public DataTable DtTreeAccess = new DataTable();
        ClsMain cm = new ClsMain();
        public int CountKartabl = 0, isMsg = 1;
        public Frm_Main()
        { 
            ThemeResolutionService.ApplicationThemeName = "Office2010Blue";
            InitializeComponent();
            radDock1.AutoDetectMdiChildren = true;
            IsMdiContainer = true;            
        }

        private void radMenuButtonItem1_Click(object sender, EventArgs e)
        {
            toolWindow3.Show();
        }

        private void radTreeView1_NodeMouseClick(object sender, RadTreeViewEventArgs e)
        {
            try
            {
                var typ = Type.GetType("ET." + radTreeView1.SelectedNode.Name);
                var form = Activator.CreateInstance(typ) as RadForm;
                if (typ != null)
                {
                    dr = dt.Select("name_form = '" + radTreeView1.SelectedNode.Name + "1" + "'");
                    if (dr.Length == 0)
                    {
                        using (new PleaseWait(this.Location))
                        {
                            DataRow dr1 = dt.NewRow();
                            dr1["text_form"] = radTreeView1.SelectedNode.Text;
                            dr1["name_form"] = radTreeView1.SelectedNode.Name + "1";
                            if (radTreeView1.SelectedNode.Text == "فن آوری اطلاعات")
                            {
                                ClsFlw.ID_FormUnit = "1";
                                ClsFlw.Isnew = "1";
                            }
                            if (radTreeView1.SelectedNode.Text == "مواد اولیه")
                            {
                                ClsFlw.ID_FormUnit = "2";
                                ClsFlw.Isnew = "1";
                            }
                            if (radTreeView1.SelectedNode.Text == "خروج دستگاه جهت تعمیر")
                            {
                                ClsFlw.ID_FormUnit = "4";
                                ClsFlw.Isnew = "1";
                            }
                            if (radTreeView1.SelectedNode.Text == "خروج دستگاه جهت پیمانکار")
                            {
                                ClsFlw.ID_FormUnit = "5";
                                ClsFlw.Isnew = "1";
                            }
                            if (radTreeView1.SelectedNode.Text == "خروج دستگاه جهت فروش")
                            {
                                ClsFlw.ID_FormUnit = "6";
                                ClsFlw.Isnew = "1";
                            }
                            if (radTreeView1.SelectedNode.Text == "خروج تجهیزات ایمنی")
                            {
                                ClsFlw.ID_FormUnit = "7";
                                ClsFlw.Isnew = "1";
                            }
                            if (radTreeView1.SelectedNode.Text == "خروج قالب جهت پیمانکار")
                            {
                                ClsFlw.ID_FormUnit = "8";
                                ClsFlw.Isnew = "1";
                            }
                            if (radTreeView1.SelectedNode.Text == "خروج قالب جهت تعمیر")
                            {
                                ClsFlw.ID_FormUnit = "9";
                                ClsFlw.Isnew = "1";
                            }
                            if (radTreeView1.SelectedNode.Text == "تحویل و تطبیق کالا")
                            {
                                ClsFlw.ID_FormUnit = "3";
                                ClsFlw.Isnew = "1";
                            }
                            if (radTreeView1.SelectedNode.Text == "عدم انطباق_تحویل کالا")
                            {
                                ClsFlw.ID_FormUnit = "10";
                                ClsFlw.Isnew = "1";
                            }
                            if (radTreeView1.SelectedNode.Text == "فروش ضایعات سایت")
                            {
                                ClsFlw.ID_FormUnit = "11";
                                ClsFlw.Isnew = "1";
                            }
                            if (radTreeView1.SelectedNode.Text == "فروش ضایعات تولید")
                            {
                                ClsFlw.ID_FormUnit = "12";
                                ClsFlw.Isnew = "1";
                            }
                            if (radTreeView1.SelectedNode.Text == "کسر هزینه")
                            {
                                ClsFlw.ID_FormUnit = "13";
                                ClsFlw.Isnew = "1";
                            }
                            if (radTreeView1.SelectedNode.Text == "اقلام آماده ارسال")
                            {
                                ClsFlw.Isnew = "1";
                            }
                            if (radTreeView1.SelectedNode.Text == "درخواست تعمیر")
                            {
                                ClsFlw.IsRequest = "1"; 
                            }
                            if (radTreeView1.SelectedNode.Text == "استعلام")
                            {
                                ClsFlw.ID_FormUnit = "15";
                                ClsFlw.Isnew = "1";
                            }
                            if (radTreeView1.SelectedNode.Text == "درخواست خرید")
                            {
                                ClsFlw.ID_FormUnit = "16";
                                ClsFlw.Isnew = "1";
                            }
                            if (radTreeView1.SelectedNode.Text == "ارسال شده ها")
                                ClsFlw.IsOutBox = 1;
                            else
                                ClsFlw.IsOutBox = 0;
                            if (radTreeView1.SelectedNode.Text == "کارتابل")
                                ClsFlw.Isnew = "0";
                            dt.Rows.Add(dr1);
                            form.MdiParent = this;
                            form.Show();
                        }
                    }
                    else
                    {
                        RadMessageBox.Show("فرم باز است");
                    }
                }
            }
            catch
            {
                //dr = dt.Select("name_form = '" + radDock1.DocumentManager.ActiveDocument.Name + "'");
                //dt.Rows.Remove(dr[0]);
                //MessageBox.Show("خطا در اجرای عملیات");
            }
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            try
            {
                ClsMain.DtAccessUser = cm.SelectAccessUser().Tables[0];

                lblNameUser.Text = ClsMain.StrNameUser;
                lblDore.Text = ClsConnect.Namedore;
                lblSemat.Text = ClsMain.StrSemat;
                //سطح دسترسی درخت
                DataRow[] dr = ClsMain.DtAccessUser.Select("n_form='" + this.Name + "'");
                DtTreeAccess = dr.CopyToDataTable();
                //--------------------------

                int[] indexes = new int[4];
                for (int i = 0; i < DtTreeAccess.Rows.Count; i++)
                {
                    int x = 0;
                    string Str_control = DtTreeAccess.Rows[i]["n_control"].ToString();
                    for (int index = 0; index != -1; index++)
                    {
                        index = Str_control.IndexOf('$', index);
                        if (index == -1)
                            break;
                        indexes[x++] = index;
                    }
                    if (x < 5)
                    {
                        bool R;
                        if (DtTreeAccess.Rows[i]["id_user"].ToString() == ClsMain.IDUser)
                            R = Convert.ToBoolean(DtTreeAccess.Rows[i]["isActive"].ToString());
                        else
                            R = false;
                        if (x == 0)
                            radTreeView1.Nodes[Str_control].Visible = R;
                        if (x == 1)
                            radTreeView1.Nodes[Str_control.Substring(0, indexes[0])].Nodes[Str_control.Substring(indexes[0] + 1, Str_control.Length - indexes[0] - 1)].Visible = R;
                        if (x == 2)
                            radTreeView1.Nodes[Str_control.Substring(0, indexes[0])].Nodes[Str_control.Substring(indexes[0] + 1, indexes[1] - indexes[0] - 1)].Nodes[Str_control.Substring(indexes[1] + 1, Str_control.Length - indexes[1] - 1)].Visible = R;
                        if (x == 3)
                            radTreeView1.Nodes[Str_control.Substring(0, indexes[0])].Nodes[Str_control.Substring(indexes[0] + 1, indexes[1] - indexes[0] - 1)].Nodes[Str_control.Substring(indexes[1] + 1, indexes[2])].Nodes[Str_control.Substring(indexes[2] + 1, Str_control.Length - indexes[2] - 1)].Visible = R;
                    }
                }
                //--------------------------

                dt.Columns.Add("text_form");
                dt.Columns.Add("name_form");
                m_culture = PersianCultureHelper.FixAndSetCurrentCulture();
            }
            catch(Exception ee) 
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void radDock1_DockWindowClosing(object sender, DockWindowCancelEventArgs e)
        {
            try
            { 
                dr = dt.Select("name_form = '" + radDock1.DocumentManager.ActiveDocument.Name + "'");
                dt.Rows.Remove(dr[0]);
            }
            catch
            {
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            //فعال کردن کلیدهای صفحه اصلی
            switch (keyData)
            {
                case Keys.F6:
                    toolWindow3.Show();
                    break;
                case Keys.F5:
                    FrmDore fd = new FrmDore();
                    fd.ShowDialog();
                    lblDore.Text = ClsConnect.Namedore;
                    break;
                case Keys.F4:
                    FrmChengPass fcp = new FrmChengPass();
                    fcp.ShowDialog();
                    break;
                case Keys.F3:
                    this.Close();
                    break;
                //case Keys.F7:
                //    login fdl = new login();
                //    fdl.ShowDialog();
                //    break;
                default:
                    break;
            }
            return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string strCount;
            ClsFlw obj = new ClsFlw();
            strCount = obj.Select_FormFlowTaeedHCountInbox().Tables[0].Rows[0][0].ToString();
            if (strCount != "0")
            {
                strCount = "(" + strCount + ")";
                if (CountKartabl > 100 & isMsg == 1)
                {
                    isMsg = 0;
                    MessageBox.Show("نامه خوانده نشده وجود دارد");
                    isMsg = 1;
                    CountKartabl = 0;
                }
                CountKartabl++;
            }
            else
                strCount = "";
            radTreeView1.Nodes[15].Text = "گردش الکترونیک" + strCount;
        }
    }
}
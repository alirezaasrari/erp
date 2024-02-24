using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Globalization;
using Telerik.WinControls.UI;

namespace ET
{
    public partial class FrmPM_codeMachine : Telerik.WinControls.UI.RadForm
    {
        public FrmPM_codeMachine()
        {
            InitializeComponent();
        }

        ClsPM objPM = new ClsPM();
        Cls_Customer objCustomer = new Cls_Customer();
        public string str,str1;
        public Boolean flagNew = false;
        DataTable dt = new DataTable();
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.grd_machine.TableElement.BeginUpdate();
            //this.customersTableAdapter.Fill(this.nwindRadGridView.Customers);
            this.grd_machine.EnableFiltering = true;
            this.grd_machine.AllowAddNewRow = false;
            //this.grd.ReadOnly = true;
            this.grd_machine.MasterTemplate.ShowHeaderCellButtons = true;
            this.grd_machine.MasterTemplate.ShowFilteringRow = false;
            this.grd_machine.TableElement.EndUpdate();
            //this.grd.FilterPopupRequired += new FilterPopupRequiredEventHandler(grd_FilterPopupRequired);
            //this.radRadioButton1.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On; 
        }
        private void FrmPM_codeMachine_Load(object sender, EventArgs e)
        {
            //*********************************tab group selected****************************************
            grp7.Visible = true;
            grp1.Visible = false;
            grp3.Visible = false;
            grp6.Visible = false;
            gb_Section.Visible = false;
            //MessageBox.Show("");
            //******************************************نام دستگاه*********************************
            //objPM.flagkala = true;
            //atxb_N_machine.AutoCompleteDataSource = cp.selectKala().Tables[0];
            //atxb_N_machine.AutoCompleteDisplayMember = "N_Kala";
            //atxb_N_machine.AutoCompleteValueMember = "C_Kala";
            dtp_date_buy.Value = DateTime.Now;
            dtp_date_create.Value = DateTime.Now;
            drp();
            atxb_datasours();
            NewMachineCod();
            grdSource();
            atxb_source();
        }

        private void drp()
        {
            drp_M_E.Items.Add("ماشین آلات");
            drp_M_E.Items.Add("تجهیزات و تاسیسات");
            drp_M_E.Items[0].Value = "M";
            drp_M_E.Items[1].Value = "E";
            drp_M_E_Detail.Items.Add("ماشین های تولیدی (Product)");
            drp_M_E_Detail.Items[0].Value = "P";
            drp_M_E_Detail.Items.Add("ماشین های مونتاژ (Assemble)");
            drp_M_E_Detail.Items[1].Value = "A";
            drp_M_E_Detail.Items.Add("ماشین های آزمایشگاهی و کنترل کیفیت (Quality)");
            drp_M_E_Detail.Items[2].Value = "Q";
            drp_M_E_Detail.Items.Add("وسایل انتقال موارد نظیر خودروها، نوار نقاله، لیفتراک و غیره(Transportation)");
            drp_M_E_Detail.Items[3].Value = "T";
            drp_M_E_Detail.Items.Add("وسایل رفاهی و خدماتی(Service)");
            drp_M_E_Detail.Items[4].Value = "S";
            drp_M_E_Detail.Items.Add("تجهزات جانبی (Equipment)");
            drp_M_E_Detail.Items[5].Value = "E";
            drp_M_E_Detail.Items.Add("شبکه های تاسیسات ضروری(Installation)");
            drp_M_E_Detail.Items[6].Value = "I";
            drp_M_E_Detail.Items.Add("سیستمهای تهویه مطبوع(Ventilation)");
            drp_M_E_Detail.Items[7].Value = "V";
            drp_M_E_Detail.Items.Add("ساختمان ها و راه ها(Building)");
            drp_M_E_Detail.Items[8].Value = "B";
            drp_M_E_Detail.Items.Add("ماشینهای ساخت قالب و ابزار(Mold)");
            drp_M_E_Detail.Items[9].Value = "M";
            drp_M_E.SelectedIndex = 0;
        }

        private void drp_M_E_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            drp_M_E_Detail.SelectedIndex = -1;
            if (drp_M_E.SelectedValue.ToString() == "M")
            {
                drp_M_E_Detail.Items[0].Enabled = true;
                drp_M_E_Detail.Items[1].Enabled = true;
                drp_M_E_Detail.Items[2].Enabled = true;
                drp_M_E_Detail.Items[3].Enabled = true;
                drp_M_E_Detail.Items[4].Enabled = true;
                drp_M_E_Detail.Items[5].Enabled = false;
                drp_M_E_Detail.Items[6].Enabled = false;
                drp_M_E_Detail.Items[7].Enabled = false;
                drp_M_E_Detail.Items[8].Enabled = false;
            }
            if (drp_M_E.SelectedValue.ToString() == "E")
            {
                drp_M_E_Detail.Items[0].Enabled = false;
                drp_M_E_Detail.Items[1].Enabled = false;
                drp_M_E_Detail.Items[2].Enabled = false;
                drp_M_E_Detail.Items[3].Enabled = false;
                drp_M_E_Detail.Items[4].Enabled = false;
                drp_M_E_Detail.Items[5].Enabled = true;
                drp_M_E_Detail.Items[6].Enabled = true;
                drp_M_E_Detail.Items[7].Enabled = true;
                drp_M_E_Detail.Items[8].Enabled = true;
            }
        }

        private void drp_M_E_Detail_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                lbl_cod_Part1.Text = drp_M_E.SelectedValue.ToString() + drp_M_E_Detail.SelectedValue.ToString();
            }
            catch
            {
            }
        }

        private void rbtn1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            grp7.Visible = false;
            grp1.Visible = true;
            grp3.Visible = false;
            grp6.Visible = false;
            gb_Section.Visible = false;
            btn_edit_machine.Enabled = true;
        }

        private void rbtn3_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            grp7.Visible = false;
            grp1.Visible = false;
            grp3.Visible = true;
            grp6.Visible = false;
            gb_Section.Visible = false;
            btn_edit_machine.Enabled = true;
        }

        private void rbtn6_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            grp7.Visible = false;
            grp1.Visible = false;
            grp3.Visible = false;
            grp6.Visible = true;
            gb_Section.Visible = false;
            btn_edit_machine.Enabled = true;
        }

        private void rbtn7_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            grp7.Visible = true;
            grp1.Visible = false;
            grp3.Visible = false;
            grp6.Visible = false;
            gb_Section.Visible = false;
            btn_edit_machine.Enabled = true;
        }

        private void rbtn5_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            grp7.Visible = false;
            grp1.Visible = false;
            grp3.Visible = false;
            grp6.Visible = false;
            gb_Section.Visible = true;
            btn_edit_machine.Enabled = false;
            btn_Delete_Section.Enabled = false;
            btn_Delete_Supplier.Enabled = false;
        }

        private void atxb_type_TextChanged(object sender, EventArgs e)
        {
            if (atxb_type.Items.Count == 1)
            {
                System.Data.DataRow[] drow;
                objPM.Idtype = atxb_type.Items[0].Value.ToString();
                drow = dt.Select("ID_type = " + objPM.Idtype + " ");
                lbl_cod_Part3.Text = drow[0]["FK_ID_class"].ToString();
            }
        }

        private void atxb_UnitPlased_TextChanged(object sender, EventArgs e)
        {
            if (atxb_UnitPlased.Items.Count == 1)
            {
                lbl_cod_Part2.Text = atxb_UnitPlased.Items[0].Value.ToString();
            }
        }

        private void NewMachineCod()
        {
            //cp.ID_Machine = cp.AutoNumberMachine().Tables[1].Rows[0][0].ToString();
            nullstring();
            btn_add_machine.Enabled = true;
            btn_del_machine.Enabled = false;
            btn_new_machine.Enabled = false;
            btn_edit_machine.Enabled = false;
            rbtn2.Enabled = false;
            rbtn3.Enabled = false;
            rbtn4.Enabled = false;
            rbtn5.Enabled = false;
            atxb_type.Enabled = true;
            radButton2.Enabled = true;
            drp_M_E.Enabled = true;
            drp_M_E_Detail.Enabled = true;
        }

        private void grdSource()
        {
            grd_machine.DataSource = objPM.selectMachine().Tables[0];
            gridViewTemplate1.DataSource = objPM.select_SCSectin().Tables[0];
            gridViewTemplate1.Caption = "قسمت";
            gridViewTemplate4.DataSource = objPM.selectSectionANDsparePart().Tables[0];
            gridViewTemplate2.DataSource = objPM.select_Customer().Tables[0];
            gridViewTemplate2.Caption = "تامین کننده";
            gridViewTemplate3.DataSource = objPM.select_Unit_place_machine().Tables[0];
            gridViewTemplate3.Caption = "تاریخچه مکان";
        }

        private void atxb_datasours()
        {
            if (atxb_type.Items.Count == 0)
            {
                //****************************************انتخاب نوع ماشین*********************************                 
                dt.Clear();
                dt = objPM.Selecttypemachin().Tables[0];
                atxb_type.AutoCompleteDataSource = dt;
                atxb_type.AutoCompleteDisplayMember = "ntnc";
                atxb_type.AutoCompleteValueMember = "ID_type";
            }
            if (atxb_UnitPlased.Items.Count == 0)
            {
                //****************************************انتخاب واحد*********************************
                atxb_UnitPlased.AutoCompleteDataSource = objPM.selectUnitPlased().Tables[0];
                atxb_UnitPlased.AutoCompleteDisplayMember = "Unit_Placed";
                atxb_UnitPlased.AutoCompleteValueMember = "ID_UP";
            }
        }
        private void btn_add_machine_Click(object sender, EventArgs e)
        {
            if (lbl_cod_Part1.Text != null && lbl_cod_Part1.Text != "")
            {
                if (lbl_cod_Part2.Text != null && lbl_cod_Part2.Text != "")
                {
                    if (lbl_cod_Part3.Text != null && lbl_cod_Part3.Text != "")
                    {
                        if (MessageBox.Show("ایا دستگاه\n" + lbl_cod_Part1.Text + lbl_cod_Part2.Text + lbl_cod_Part3.Text + lbl_cod_Part4.Text + "\n" + "ثبت شود",
                            "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) == DialogResult.Yes)
                        {
                            ins_update_machine();
                            objPM.ID_Machine = objPM.InsMachine_Select_ID().Tables[0].Rows[0][0].ToString();
                            grdSource();
                            btn_add_machine.Enabled = false;
                            btn_del_machine.Enabled = true;
                            btn_new_machine.Enabled = true;
                            btn_edit_machine.Enabled = true;
                            rbtn2.Enabled = true;
                            rbtn3.Enabled = true;
                            rbtn4.Enabled = true;
                            rbtn5.Enabled = true;
                            rbtn2.IsChecked = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("لطفا نوع دستگاه را انتخاب کنید");
                    }
                }
                else
                {
                    MessageBox.Show("لطفا سالن دستگاه را انتخاب کنید");
                }
            }
            else
            {
                MessageBox.Show("لطفا مدل دستگاه را انتخاب کنید");
            }
        }
        private void ins_update_machine()
        {
            if (rbtn2.IsChecked == true)
            {
                //string b;
                //if (atxb_N_machine.Items.Count != 0)
                //{
                //    int n = atxb_N_machine.Text.Length;
                //    b = atxb_N_machine.Text.Substring(0, n - 1);
                //}
                //else
                //{
                //    b = atxb_N_machine.Text;
                //}
                objPM.N_machine = atxb_N_machine.Text;
                objPM.model_machine = txb_model.Text;
                objPM.shomare_serial = txb_serial.Text;
                objPM.cod_amval = txb_cod_amval.Text;
                objPM.year_buy = dtp_date_buy.Text;
                objPM.year_create = dtp_date_create.Text;
                objPM.country = txb_country.Text;
                objPM.company = txb_company.Text;
                objPM.number_personal = txb_person.Text;
                if (chk_nonautomatic.Checked == true)
                {
                    objPM.nonautomatic = "1";
                }
                else
                {
                    objPM.nonautomatic = "0";
                }
                if (chk_halfautomatic.Checked == true)
                {
                    objPM.halfautomatic = "1";
                }
                else
                {
                    objPM.halfautomatic = "0";
                }
                if (chk_automatic.Checked == true)
                {
                    objPM.automatic = "1";
                }
                else
                {
                    objPM.automatic = "0";
                }
                objPM.height = txb_heigh.Text;
                objPM.width = txb_width.Text;
                objPM.artefa = txb_artefa.Text;
                objPM.fazay_ashghali = txb_fazay_ashghali.Text;
                objPM.wall = txb_wall.Text;
                objPM.faselehazmacine = txb_faselehazmacine.Text;
                if (rbtn_importance0.IsChecked == true)
                    objPM.importance = "0";
                if (rbtn_importance1.IsChecked == true)
                    objPM.importance = "1";
                if (rbtn_Status0.IsChecked == true)
                    objPM.Status_machin = "0";
                if (rbtn_Status1.IsChecked == true)
                    objPM.Status_machin = "1";
                objPM.color = txb_color.Text;
            }
            if (rbtn3.IsChecked == true)
            {
                if (chk_electric.Checked == true)
                {
                    objPM.electric = "1";
                }
                else
                {
                    objPM.electric = "0";
                }
                if (chk_water.Checked == true)
                {
                    objPM.water = "1";
                }
                else
                {
                    objPM.water = "0";
                }
                if (chk_wather.Checked == true)
                {
                    objPM.wather = "1";
                }
                else
                {
                    objPM.wather = "0";
                }
                if (chk_bokhar.Checked == true)
                {
                    objPM.bokhar = "1";
                }
                else
                {
                    objPM.bokhar = "0";
                }
                objPM.ether = txb_ether.Text;
                if (chk_onefaz.Checked == true)
                {
                    objPM.onefaz = "1";
                }
                else
                {
                    objPM.onefaz = "0";
                }
                if (chk_treefaz.Checked == true)
                {
                    objPM.treefaz = "1";
                }
                else
                {
                    objPM.treefaz = "0";
                }
                objPM.power_kol = txb_power_kol.Text;
                objPM.power_hot = txb_power_hot.Text;
                objPM.power_electromotor = txb_power_electromotor.Text;
                objPM.number_motor = txb_number_motor.Text;
                objPM.fiuz = txb_fiuz.Text;
                objPM.volta = txb_volta.Text;
                objPM.amper = txb_amper.Text;
                if (chk_w_hot.Checked == true)
                {
                    objPM.w_hot = "1";
                }
                else
                {
                    objPM.w_hot = "0";
                }
                if (chk_w_cool.Checked == true)
                {
                    objPM.w_cool = "1";
                }
                else
                {
                    objPM.w_cool = "0";
                }
                if (chk_w_bedashti.Checked == true)
                {
                    objPM.w_bedashti = "1";
                }
                else
                {
                    objPM.w_bedashti = "0";
                }
                objPM.size_input = txb_size_input.Text;
                objPM.mizan_masraf = txb_mizan_masraf.Text;
                objPM.percent_shkti = txb_percent_shkti.Text;
                objPM.size_input_hava = txb_size_input_hava.Text;
                objPM.push_hava = txb_push_hava.Text;
                objPM.mizan_masraf_hava = txb_mizan_masraf_hava.Text;
                objPM.size_input_bokhar = txb_size_input_bokhar.Text;
                objPM.push_bokhar = txb_push_bokhar.Text;
                objPM.mizan_masraf_bokhar = txb_mizan_masraf_bokhar.Text;
            }
            if (rbtn4.IsChecked == true)
            {
                objPM.des_use = txb_des_use.Text;
                objPM.product_tolid = txb_product_tolid.Text;
                objPM.equpment_janebi = txt_equpment_janebi.Text;
                objPM.description = txb_description.Text;
            }
            if (rbtn1.IsChecked == true)
            {
                objPM.p1 = lbl_cod_Part1.Text;
                objPM.p2 = lbl_cod_Part2.Text;
                objPM.p3 = lbl_cod_Part3.Text;
                objPM.p4 = lbl_cod_Part4.Text;
            }
        }

        private void btn_edit_machine_Click(object sender, EventArgs e)
        {
            ins_update_machine();
            if (rbtn2.IsChecked == true)
            {
                MessageBox.Show(objPM.updateCodMachine2());
            }
            if (rbtn3.IsChecked == true)
            {
                MessageBox.Show(objPM.updateCodMachine3());
            }
            if (rbtn4.IsChecked == true)
            {
                MessageBox.Show(objPM.updateCodMachine4());
            }
            if (rbtn1.IsChecked == true)
            {
                if (objPM.Id_UnitPlased != lbl_cod_Part2.Text)
                {
                    objPM.updateCodMachine_Unite_Place();
                }
                MessageBox.Show(objPM.updateCodMachine1());
            }
            grdSource();
        }

        private void btn_del_machine_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا مطمئن هستید حذف شود؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataSet ds = new DataSet();
                ds = objPM.selectIDmachine();
                int rct1 = ds.Tables[0].Rows.Count;
                int rct2 = ds.Tables[1].Rows.Count;
                if (rct1 == 0 & rct2 == 0)
                {
                    MessageBox.Show(objPM.delMachine());
                }
                else
                {
                    for (int i = 0; i < rct1; i++)
                    {
                        str += ds.Tables[0].Rows[i]["N_section"].ToString() + "\n";
                    }
                    for (int i = 0; i < rct2; i++)
                    {
                        str1 += ds.Tables[1].Rows[i]["L_Name"].ToString() + "\n";
                    }

                    string message = (":این دستگاه دارای قسمت\n " +
                                      str +
                                      ":و تامین کننده\n " +
                                      str1 +
                                      "  است");

                    DialogResult result;
                    result = MessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    str = null;
                }
            }
            grdSource();
            NewMachineCod();
        }

        private void btn_new_machine_Click(object sender, EventArgs e)
        {
            NewMachineCod();
        }

        private void nullstring()
        {
            atxb_type.Text = null; objPM.p1 = null; objPM.p2 = null; objPM.p3 = null; objPM.p4 = null;
            atxb_UnitPlased.Text = null;
            objPM.N_machine = null; atxb_N_machine.Text = null;
            objPM.model_machine = null; txb_model.Text = null;
            objPM.shomare_serial = null; txb_serial.Text = null;
            objPM.cod_amval = null; txb_cod_amval.Text = null;
            objPM.year_create = null;
            objPM.year_buy = null;
            objPM.country = null; txb_country.Text = null;
            objPM.company = null; txb_company.Text = null;
            objPM.number_personal = null; txb_person.Text = null;
            objPM.height = null; txb_heigh.Text = null;
            objPM.width = null; txb_width.Text = null;
            objPM.artefa = null; txb_artefa.Text = null;
            objPM.fazay_ashghali = null; txb_fazay_ashghali.Text = null;
            objPM.wall = null; txb_wall.Text = null;
            objPM.faselehazmacine = null; txb_faselehazmacine.Text = null;
            objPM.ether = null; txb_ether.Text = null;
            objPM.power_kol = null; txb_power_kol.Text = null;
            objPM.power_hot = null; txb_power_hot.Text = null;
            objPM.power_electromotor = null; txb_power_electromotor.Text = null;
            objPM.number_motor = null; txb_number_motor.Text = null;
            objPM.fiuz = null; txb_fiuz.Text = null;
            objPM.volta = null; txb_volta.Text = null;
            objPM.amper = null; txb_amper.Text = null;
            objPM.size_input = null; txb_size_input.Text = null;
            objPM.mizan_masraf = null; txb_mizan_masraf.Text = null;
            objPM.percent_shkti = null; txb_percent_shkti.Text = null;
            objPM.size_input_hava = null; txb_size_input_hava.Text = null;
            objPM.push_hava = null; txb_push_hava.Text = null;
            objPM.mizan_masraf_hava = null; txb_mizan_masraf_hava.Text = null;
            objPM.size_input_bokhar = null; txb_size_input_bokhar.Text = null;
            objPM.push_bokhar = null; txb_push_bokhar.Text = null;
            objPM.mizan_masraf_bokhar = null; txb_mizan_masraf_bokhar.Text = null;
            objPM.des_use = null; txb_des_use.Text = null;
            objPM.product_tolid = null; txb_product_tolid.Text = null;
            objPM.description = null; txb_description.Text = null; txt_equpment_janebi.Text = null;
            lbl_cod_Part1.Text = null; lbl_cod_Part2.Text = null;
            lbl_cod_Part3.Text = null; lbl_cod_Part4.Text = null;
            chk_nonautomatic.Checked = false;
            chk_halfautomatic.Checked = false;
            chk_automatic.Checked = false;
            chk_electric.Checked = false;
            chk_water.Checked = false;
            chk_wather.Checked = false;
            chk_bokhar.Checked = false;
            chk_onefaz.Checked = false;
            chk_treefaz.Checked = false;
            chk_w_hot.Checked = false;
            chk_w_cool.Checked = false;
            chk_w_bedashti.Checked = false;
            drp_M_E.SelectedIndex = 0;
            drp_M_E_Detail.SelectedIndex = -1;
        }

        private void grd_machine_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (grd_machine.CurrentRow.HierarchyLevel == 0)
                {
                    objPM.ID_Machine = grd_machine.CurrentRow.Cells["ID_machine"].Value.ToString();
                    lbl_cod_Part1.Text = grd_machine.CurrentRow.Cells["codpart1"].Value.ToString();
                    drp_M_E.SelectedValue = grd_machine.CurrentRow.Cells["codpart1"].Value.ToString().Substring(0, 1);
                    drp_M_E_Detail.SelectedValue = grd_machine.CurrentRow.Cells["codpart1"].Value.ToString().Substring(1, 1);
                    txb_number_machine.Value = Convert.ToInt16(grd_machine.CurrentRow.Cells["codpart4"].Value);
                    lbl_cod_Part3.Text = grd_machine.CurrentRow.Cells["FK_ID_class"].Value.ToString();
                    objPM.Id_UnitPlased = grd_machine.CurrentRow.Cells["FK_ID_UP"].Value.ToString();
                    atxb_type.Text = grd_machine.CurrentRow.Cells["ntnc"].Value.ToString() + ";";
                    atxb_UnitPlased.Text = grd_machine.CurrentRow.Cells["Unit_Placed"].Value.ToString() + ";";
                    atxb_N_machine.Text = grd_machine.CurrentRow.Cells["N_machine"].Value.ToString();
                    txb_model.Text = grd_machine.CurrentRow.Cells["model_machine"].Value.ToString();
                    txb_serial.Text = grd_machine.CurrentRow.Cells["shomare_serial"].Value.ToString();
                    txb_cod_amval.Text = grd_machine.CurrentRow.Cells["cod_amval"].Value.ToString();
                    txb_country.Text = grd_machine.CurrentRow.Cells["country"].Value.ToString();
                    txb_company.Text = grd_machine.CurrentRow.Cells["company"].Value.ToString();
                    txb_person.Text = grd_machine.CurrentRow.Cells["number_personal"].Value.ToString();
                    if (grd_machine.CurrentRow.Cells["nonautomatic"].Value.ToString() == "True")
                        chk_nonautomatic.Checked = true;
                    else
                        chk_nonautomatic.Checked = false;
                    if (grd_machine.CurrentRow.Cells["halfautomatic"].Value.ToString() == "True")
                        chk_halfautomatic.Checked = true;
                    else
                        chk_halfautomatic.Checked = false;
                    if (grd_machine.CurrentRow.Cells["automatic"].Value.ToString() == "True")
                        chk_automatic.Checked = true;
                    else
                        chk_automatic.Checked = false;
                    txb_heigh.Text = grd_machine.CurrentRow.Cells["height"].Value.ToString();
                    txb_width.Text = grd_machine.CurrentRow.Cells["width"].Value.ToString();
                    txb_artefa.Text = grd_machine.CurrentRow.Cells["artefa"].Value.ToString();
                    txb_fazay_ashghali.Text = grd_machine.CurrentRow.Cells["fazay_ashghali"].Value.ToString();
                    txb_wall.Text = grd_machine.CurrentRow.Cells["wall"].Value.ToString();
                    txb_faselehazmacine.Text = grd_machine.CurrentRow.Cells["faselehazmacine"].Value.ToString();
                    if (grd_machine.CurrentRow.Cells["electric"].Value.ToString() == "True")
                        chk_electric.Checked = true;
                    else
                        chk_electric.Checked = false;
                    if (grd_machine.CurrentRow.Cells["water"].Value.ToString() == "True")
                        chk_water.Checked = true;
                    else
                        chk_water.Checked = false;
                    if (grd_machine.CurrentRow.Cells["wather"].Value.ToString() == "True")
                        chk_wather.Checked = true;
                    else
                        chk_wather.Checked = false;
                    if (grd_machine.CurrentRow.Cells["bokhar"].Value.ToString() == "True")
                        chk_bokhar.Checked = true;
                    else
                        chk_bokhar.Checked = false;
                    txb_ether.Text = grd_machine.CurrentRow.Cells["ether"].Value.ToString();
                    if (grd_machine.CurrentRow.Cells["onefaz"].Value.ToString() == "True")
                        chk_onefaz.Checked = true;
                    else
                        chk_onefaz.Checked = false;
                    if (grd_machine.CurrentRow.Cells["treefaz"].Value.ToString() == "True")
                        chk_treefaz.Checked = true;
                    else
                        chk_treefaz.Checked = false;
                    txb_power_kol.Text = grd_machine.CurrentRow.Cells["power_kol"].Value.ToString();
                    txb_power_hot.Text = grd_machine.CurrentRow.Cells["power_hot"].Value.ToString();
                    txb_power_electromotor.Text = grd_machine.CurrentRow.Cells["power_electromotor"].Value.ToString();
                    txb_number_motor.Text = grd_machine.CurrentRow.Cells["number_motor"].Value.ToString();
                    txb_fiuz.Text = grd_machine.CurrentRow.Cells["fiuz"].Value.ToString();
                    txb_volta.Text = grd_machine.CurrentRow.Cells["volta"].Value.ToString();
                    txb_amper.Text = grd_machine.CurrentRow.Cells["amper"].Value.ToString();
                    if (grd_machine.CurrentRow.Cells["w_hot"].Value.ToString() == "True")
                        chk_w_hot.Checked = true;
                    else
                        chk_w_hot.Checked = false;
                    if (grd_machine.CurrentRow.Cells["w_cool"].Value.ToString() == "True")
                        chk_w_cool.Checked = true;
                    else
                        chk_w_cool.Checked = false;
                    if (grd_machine.CurrentRow.Cells["w_bedashti"].Value.ToString() == "True")
                        chk_w_bedashti.Checked = true;
                    else
                        chk_w_bedashti.Checked = false;
                    txb_size_input.Text = grd_machine.CurrentRow.Cells["size_input"].Value.ToString();
                    txb_mizan_masraf.Text = grd_machine.CurrentRow.Cells["mizan_masraf"].Value.ToString();
                    txb_percent_shkti.Text = grd_machine.CurrentRow.Cells["percent_shkti"].Value.ToString();
                    txb_size_input_hava.Text = grd_machine.CurrentRow.Cells["size_input_hava"].Value.ToString();
                    txb_push_hava.Text = grd_machine.CurrentRow.Cells["push_hava"].Value.ToString();
                    txb_mizan_masraf_hava.Text = grd_machine.CurrentRow.Cells["mizan_masraf_hava"].Value.ToString();
                    txb_size_input_bokhar.Text = grd_machine.CurrentRow.Cells["size_input_bokhar"].Value.ToString();
                    txb_push_bokhar.Text = grd_machine.CurrentRow.Cells["push_bokhar"].Value.ToString();
                    txb_mizan_masraf_bokhar.Text = grd_machine.CurrentRow.Cells["mizan_masraf_bokhar"].Value.ToString();
                    txb_des_use.Text = grd_machine.CurrentRow.Cells["des_use"].Value.ToString();
                    txb_product_tolid.Text = grd_machine.CurrentRow.Cells["product_tolid"].Value.ToString();
                    txt_equpment_janebi.Text = grd_machine.CurrentRow.Cells["equpment_janebi"].Value.ToString();
                    txb_description.Text = grd_machine.CurrentRow.Cells["description"].Value.ToString();
                    dtp_date_buy.Text = grd_machine.CurrentRow.Cells["year_buy"].Value.ToString();
                    dtp_date_create.Text = grd_machine.CurrentRow.Cells["year_create"].Value.ToString();
                    btn_add_machine.Enabled = false;
                    btn_del_machine.Enabled = true;
                    btn_new_machine.Enabled = true;
                    btn_edit_machine.Enabled = true;
                    rbtn2.Enabled = true;
                    rbtn3.Enabled = true;
                    rbtn4.Enabled = true;
                    rbtn5.Enabled = true;
                    rbtn1.IsChecked = true;
                    //atxb_type.Enabled = false;
                    //radButton2.Enabled = false;
                    //drp_M_E.Enabled = false;
                    //drp_M_E_Detail.Enabled = false;
                    objPM.ID_Machine_UnitePlace = grd_machine.CurrentRow.Cells["ID_Machine_UnitePlace"].Value.ToString();

                    if (grd_machine.CurrentRow.Cells["importance"].Value.ToString() == "True")
                        rbtn_importance1.IsChecked = true;
                    else
                        rbtn_importance0.IsChecked = true;

                    if (grd_machine.CurrentRow.Cells["Status"].Value.ToString() == "True")
                        rbtn_Status1.IsChecked = true;
                    else
                        rbtn_Status0.IsChecked = true;
                    txb_color.Text = grd_machine.CurrentRow.Cells["color"].Value.ToString();
                }
                if (grd_machine.CurrentRow.HierarchyLevel == 1)
                {
                    if (grd_machine.CurrentRow.ViewTemplate.Caption == "قسمت")
                    {
                        objPM.ID_CodMachine_Section = grd_machine.CurrentRow.Cells["ID_C_S"].Value.ToString();
                        atxb_Section.Text = grd_machine.CurrentRow.Cells["N_section"].Value.ToString() + ";";
                        btn_ADD_Section.Enabled = false;
                        btn_Delete_Section.Enabled = true;
                    }
                    if (grd_machine.CurrentRow.ViewTemplate.Caption == "تامین کننده")
                    {
                        objPM.ID_CodMachine_Supplier = grd_machine.CurrentRow.Cells["ID"].Value.ToString();
                        atxb_Supplier.Text = grd_machine.CurrentRow.Cells["L_Name"].Value.ToString() + ";";
                        btn_ADD_Supplier.Enabled = false;
                        btn_Delete_Supplier.Enabled = true;
                    }
                }
            }
            catch
            {
                MessageBox.Show("روی خطوط گرید کلید نمایید");
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            atxb_UnitPlased.Clear();
            atxb_UnitPlased.AutoCompleteDataSource = null;
            FrmPM_UnitPlace sa = new FrmPM_UnitPlace();
            sa.ShowDialog();
            atxb_datasours();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            atxb_type.Clear();
            atxb_type.AutoCompleteDataSource = null;
            FrmPM_classANDtype sa = new FrmPM_classANDtype();
            sa.ShowDialog();
            atxb_datasours();
        }

        private void btn_ADD_Section_Click(object sender, EventArgs e)
        {
            int ats = atxb_Section.Items.Count;
            if (ats > 0)
            {
                for (var i = 0; i < ats; i++)
                {
                    objPM.ID_Section = atxb_Section.Items[i].Value.ToString();
                    MessageBox.Show(objPM.Ins_C_Sectin());
                }
            }
            grdSource();
            atxb_Section.Clear();
        }

        private void btn_Delete_Section_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا مطمئن هستید حذف شود؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show(objPM.Del_C_Sectin());
            }
            grdSource();
            atxb_Section.Clear();
            objPM.ID_CodMachine_Section = null;
        }

        private void btn_section_Click(object sender, EventArgs e)
        {
            atxb_Section.Clear();
            atxb_Section.AutoCompleteDataSource = null;
            FrmPM_Section sa = new FrmPM_Section();
            sa.ShowDialog();
            atxb_source();
        }

        private void atxb_source()
        {
            atxb_Section.AutoCompleteDataSource = objPM.select_Section().Tables[0];
            atxb_Section.AutoCompleteValueMember = "ID_Section";
            atxb_Section.AutoCompleteDisplayMember = "N_section";

            //atxb_Supplier.AutoCompleteDataSource = objCustomer.select_Customer().Tables[0];
            //atxb_Supplier.AutoCompleteValueMember = "ID_Customer";
            //atxb_Supplier.AutoCompleteDisplayMember = "n";

        }

        private void btn_New_Section_Click(object sender, EventArgs e)
        {
            atxb_Section.Clear();
            objPM.ID_CodMachine_Section = null;
            btn_ADD_Section.Enabled = true;
            btn_Delete_Section.Enabled = false;
        }

        private void btn_ADD_Supplier_Click(object sender, EventArgs e)
        {
            int atsup = atxb_Supplier.Items.Count;
            if (atsup > 0)
            {
                for (var i = 0; i < atsup; i++)
                {
                    objPM.ID_Customer = atxb_Supplier.Items[i].Value.ToString();
                    RadMessageBox.Show(objPM.Ins_codmachine_customer());
                }
            }
            grdSource();
            atxb_Supplier.Clear();
        }

        private void btn_Delete_Supplier_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا مطمئن هستید حذف شود؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show(objPM.Del_C_Suppleir());
            }
            grdSource();
            atxb_Supplier.Clear();
            objPM.ID_CodMachine_Supplier = null;
        }

        private void btn_New_Supplier_Click(object sender, EventArgs e)
        {
            atxb_Supplier.Clear();
            objPM.ID_CodMachine_Supplier = null;
            btn_ADD_Supplier.Enabled = true;
            //atxb_Supplier.Enabled = false;
        }

        private void btn_supplier_Click(object sender, EventArgs e)
        {
            atxb_Supplier.Clear();
            atxb_Supplier.AutoCompleteDataSource = null;
            //Frm_Supplier sa = new Frm_Supplier();
            //sa.ShowDialog();
            atxb_source();
        }

        private void txb_number_machine_ValueChanged(object sender, EventArgs e)
        {
            str = txb_number_machine.Value.ToString();
            if (str.Length == 1)
            {
                str = "0" + str;
            }
            lbl_cod_Part4.Text = str;
        }

        private void lbl_cod_Part1_TextChanged(object sender, EventArgs e)
        {
            ins_update_machine();
            try
            {
                txb_number_machine.Value = objPM.Machine_cod_part4().Tables[0].Rows.Count + 1;
            }
            catch
            {
            }
        }
    }
}
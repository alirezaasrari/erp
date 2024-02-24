namespace ET
{
    partial class FrmFLW_KhoroojPaya
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.grd = new Telerik.WinControls.UI.RadGridView();
            this.txtCodeKhoroojPaya = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTozihat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBack = new Telerik.WinControls.UI.RadButton();
            this.btnEnd = new Telerik.WinControls.UI.RadButton();
            this.btnSend = new Telerik.WinControls.UI.RadButton();
            this.label10 = new System.Windows.Forms.Label();
            this.txtErja = new System.Windows.Forms.TextBox();
            this.txtTypeKhorooj = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPrint = new Telerik.WinControls.UI.RadButton();
            this.grdKhorooj = new Telerik.WinControls.UI.RadGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.lblKhorooj = new System.Windows.Forms.Label();
            this.txtHavale = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKhorooj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKhorooj.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grd
            // 
            this.grd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grd.Cursor = System.Windows.Forms.Cursors.Default;
            this.grd.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.grd.ForeColor = System.Drawing.Color.Black;
            this.grd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grd.Location = new System.Drawing.Point(12, 81);
            // 
            // 
            // 
            this.grd.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "KhCKala";
            gridViewTextBoxColumn1.HeaderText = "کد کالا";
            gridViewTextBoxColumn1.Name = "KhCKala";
            gridViewTextBoxColumn1.Width = 136;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "N_Kala";
            gridViewTextBoxColumn2.HeaderText = "نام کالا";
            gridViewTextBoxColumn2.Name = "N_Kala";
            gridViewTextBoxColumn2.Width = 265;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "KhTedad";
            gridViewTextBoxColumn3.HeaderText = "مقدار";
            gridViewTextBoxColumn3.Name = "KhTedad";
            gridViewTextBoxColumn3.Width = 85;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "N_UnitKala";
            gridViewTextBoxColumn4.HeaderText = "واحد شمارش";
            gridViewTextBoxColumn4.Name = "N_UnitKala";
            gridViewTextBoxColumn4.Width = 135;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "NameTafsili";
            gridViewTextBoxColumn5.HeaderText = "مقصد";
            gridViewTextBoxColumn5.Name = "NameTafsili";
            gridViewTextBoxColumn5.Width = 189;
            this.grd.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.grd.MasterTemplate.EnableGrouping = false;
            this.grd.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grd.Name = "grd";
            this.grd.ReadOnly = true;
            this.grd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grd.Size = new System.Drawing.Size(942, 173);
            this.grd.TabIndex = 4;
            this.grd.TabStop = false;
            // 
            // txtCodeKhoroojPaya
            // 
            this.txtCodeKhoroojPaya.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodeKhoroojPaya.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodeKhoroojPaya.Location = new System.Drawing.Point(721, 6);
            this.txtCodeKhoroojPaya.Name = "txtCodeKhoroojPaya";
            this.txtCodeKhoroojPaya.ReadOnly = true;
            this.txtCodeKhoroojPaya.Size = new System.Drawing.Size(137, 21);
            this.txtCodeKhoroojPaya.TabIndex = 260;
            this.txtCodeKhoroojPaya.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(864, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 259;
            this.label5.Text = "شماره برگه خروج:";
            // 
            // txtDate
            // 
            this.txtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDate.Location = new System.Drawing.Point(486, 6);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(137, 21);
            this.txtDate.TabIndex = 262;
            this.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(629, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 261;
            this.label1.Text = "تاریخ خروج:";
            // 
            // txtTozihat
            // 
            this.txtTozihat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTozihat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTozihat.Location = new System.Drawing.Point(72, 6);
            this.txtTozihat.Name = "txtTozihat";
            this.txtTozihat.ReadOnly = true;
            this.txtTozihat.Size = new System.Drawing.Size(295, 21);
            this.txtTozihat.TabIndex = 264;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(373, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 263;
            this.label2.Text = "توضیحات:";
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnBack.Image = global::ET.Properties.Resources.Next;
            this.btnBack.Location = new System.Drawing.Point(537, 499);
            this.btnBack.Name = "btnBack";
            this.btnBack.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnBack.Size = new System.Drawing.Size(131, 25);
            this.btnBack.TabIndex = 267;
            this.btnBack.Text = "عدم تایید و برگشت";
            this.btnBack.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.Visible = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnEnd.Image = global::ET.Properties.Resources.Remove;
            this.btnEnd.Location = new System.Drawing.Point(693, 499);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnEnd.Size = new System.Drawing.Size(115, 25);
            this.btnEnd.TabIndex = 266;
            this.btnEnd.Text = "عدم تایید و اتمام";
            this.btnEnd.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSend.Image = global::ET.Properties.Resources.ok;
            this.btnSend.Location = new System.Drawing.Point(836, 499);
            this.btnSend.Name = "btnSend";
            this.btnSend.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnSend.Size = new System.Drawing.Size(115, 25);
            this.btnSend.TabIndex = 265;
            this.btnSend.Text = "تایید و ارسال";
            this.btnSend.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(896, 475);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 268;
            this.label10.Text = "شرح ارجاء:";
            // 
            // txtErja
            // 
            this.txtErja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtErja.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtErja.Location = new System.Drawing.Point(12, 472);
            this.txtErja.Name = "txtErja";
            this.txtErja.Size = new System.Drawing.Size(878, 21);
            this.txtErja.TabIndex = 269;
            // 
            // txtTypeKhorooj
            // 
            this.txtTypeKhorooj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTypeKhorooj.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTypeKhorooj.Location = new System.Drawing.Point(721, 33);
            this.txtTypeKhorooj.Name = "txtTypeKhorooj";
            this.txtTypeKhorooj.ReadOnly = true;
            this.txtTypeKhorooj.Size = new System.Drawing.Size(137, 21);
            this.txtTypeKhorooj.TabIndex = 271;
            this.txtTypeKhorooj.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(901, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 270;
            this.label3.Text = "نوع خروج:";
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnPrint.Image = global::ET.Properties.Resources.print;
            this.btnPrint.Location = new System.Drawing.Point(72, 38);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnPrint.Size = new System.Drawing.Size(71, 25);
            this.btnPrint.TabIndex = 272;
            this.btnPrint.Text = "چاپ";
            this.btnPrint.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // grdKhorooj
            // 
            this.grdKhorooj.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdKhorooj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grdKhorooj.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdKhorooj.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.grdKhorooj.ForeColor = System.Drawing.Color.Black;
            this.grdKhorooj.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdKhorooj.Location = new System.Drawing.Point(12, 290);
            // 
            // 
            // 
            this.grdKhorooj.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "CKala";
            gridViewTextBoxColumn6.HeaderText = "کد کالا";
            gridViewTextBoxColumn6.Name = "CKala";
            gridViewTextBoxColumn6.Width = 136;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "N_Kala";
            gridViewTextBoxColumn7.HeaderText = "نام کالا";
            gridViewTextBoxColumn7.Name = "N_Kala";
            gridViewTextBoxColumn7.Width = 275;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "Meghdar";
            gridViewTextBoxColumn8.HeaderText = "مقدار";
            gridViewTextBoxColumn8.Name = "Meghdar";
            gridViewTextBoxColumn8.Width = 85;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "N_Vahed";
            gridViewTextBoxColumn9.HeaderText = "واحد شمارش";
            gridViewTextBoxColumn9.Name = "N_Vahed";
            gridViewTextBoxColumn9.Width = 126;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "Tozihat";
            gridViewTextBoxColumn10.HeaderText = "توضیحات";
            gridViewTextBoxColumn10.Name = "Tozihat";
            gridViewTextBoxColumn10.Width = 189;
            this.grdKhorooj.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10});
            this.grdKhorooj.MasterTemplate.EnableGrouping = false;
            this.grdKhorooj.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grdKhorooj.Name = "grdKhorooj";
            this.grdKhorooj.ReadOnly = true;
            this.grdKhorooj.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdKhorooj.Size = new System.Drawing.Size(942, 176);
            this.grdKhorooj.TabIndex = 273;
            this.grdKhorooj.TabStop = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(848, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 274;
            this.label4.Text = "اطلاعات فرم خروج پایا";
            // 
            // lblKhorooj
            // 
            this.lblKhorooj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKhorooj.AutoSize = true;
            this.lblKhorooj.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhorooj.Location = new System.Drawing.Point(836, 274);
            this.lblKhorooj.Name = "lblKhorooj";
            this.lblKhorooj.Size = new System.Drawing.Size(116, 13);
            this.lblKhorooj.TabIndex = 275;
            this.lblKhorooj.Text = "اطلاعات فرم مجوز خروج";
            // 
            // txtHavale
            // 
            this.txtHavale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHavale.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHavale.Location = new System.Drawing.Point(486, 33);
            this.txtHavale.Name = "txtHavale";
            this.txtHavale.ReadOnly = true;
            this.txtHavale.Size = new System.Drawing.Size(137, 21);
            this.txtHavale.TabIndex = 277;
            this.txtHavale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(629, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 276;
            this.label6.Text = "شماره حواله:";
            // 
            // FrmFLW_KhoroojPaya
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 536);
            this.Controls.Add(this.txtHavale);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblKhorooj);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.grdKhorooj);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtTypeKhorooj);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtErja);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtTozihat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodeKhoroojPaya);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.grd);
            this.Name = "FrmFLW_KhoroojPaya";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اطلاعات مجوز خروج پایا";
            this.Load += new System.EventHandler(this.FrmFLW_KhoroojPaya_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grd.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKhorooj.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKhorooj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grd;
        private System.Windows.Forms.TextBox txtCodeKhoroojPaya;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTozihat;
        private System.Windows.Forms.Label label2;
        public Telerik.WinControls.UI.RadButton btnBack;
        public Telerik.WinControls.UI.RadButton btnEnd;
        public Telerik.WinControls.UI.RadButton btnSend;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtErja;
        private System.Windows.Forms.TextBox txtTypeKhorooj;
        private System.Windows.Forms.Label label3;
        public Telerik.WinControls.UI.RadButton btnPrint;
        private Telerik.WinControls.UI.RadGridView grdKhorooj;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblKhorooj;
        private System.Windows.Forms.TextBox txtHavale;
        private System.Windows.Forms.Label label6;
    }
}

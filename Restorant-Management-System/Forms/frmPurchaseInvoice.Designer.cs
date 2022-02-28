namespace Restorant_Management_System.Forms
{
    partial class frmPurchaseInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPurchaseInvoice));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PnlMain = new System.Windows.Forms.Panel();
            this.cmbPmtType = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblCourierAmt = new System.Windows.Forms.Label();
            this.lblTrackingID = new System.Windows.Forms.Label();
            this.txtSumGST = new System.Windows.Forms.TextBox();
            this.txtSumDisc = new System.Windows.Forms.TextBox();
            this.txtCourierAmount = new System.Windows.Forms.TextBox();
            this.txtTrackingID = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbCourier = new System.Windows.Forms.ComboBox();
            this.txtGSTPer = new System.Windows.Forms.TextBox();
            this.txtGSTAmt = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.txtTotalQauntity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.PnlBtn = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkRePrint = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.txtPaidAmount = new System.Windows.Forms.TextBox();
            this.txtNetAmount = new System.Windows.Forms.TextBox();
            this.txtDiscPer = new System.Windows.Forms.TextBox();
            this.txtDiscAmt = new System.Windows.Forms.TextBox();
            this.txtInvoiceTotal = new System.Windows.Forms.TextBox();
            this.lblSTaxAmount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblItemDiscount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtPartyID = new System.Windows.Forms.TextBox();
            this.btnSchVendor = new System.Windows.Forms.Button();
            this.txtPartyDetail = new System.Windows.Forms.TextBox();
            this.Grd = new DGV.DGV();
            this.label11 = new System.Windows.Forms.Label();
            this.PnlMain.SuspendLayout();
            this.PnlBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.BackColor = System.Drawing.Color.SteelBlue;
            this.PnlMain.Controls.Add(this.cmbPmtType);
            this.PnlMain.Controls.Add(this.label15);
            this.PnlMain.Controls.Add(this.label18);
            this.PnlMain.Controls.Add(this.label17);
            this.PnlMain.Controls.Add(this.lblCourierAmt);
            this.PnlMain.Controls.Add(this.lblTrackingID);
            this.PnlMain.Controls.Add(this.txtSumGST);
            this.PnlMain.Controls.Add(this.txtSumDisc);
            this.PnlMain.Controls.Add(this.txtCourierAmount);
            this.PnlMain.Controls.Add(this.txtTrackingID);
            this.PnlMain.Controls.Add(this.label14);
            this.PnlMain.Controls.Add(this.cmbCourier);
            this.PnlMain.Controls.Add(this.txtGSTPer);
            this.PnlMain.Controls.Add(this.txtGSTAmt);
            this.PnlMain.Controls.Add(this.label12);
            this.PnlMain.Controls.Add(this.label13);
            this.PnlMain.Controls.Add(this.txtRemarks);
            this.PnlMain.Controls.Add(this.label9);
            this.PnlMain.Controls.Add(this.btnDelete);
            this.PnlMain.Controls.Add(this.label8);
            this.PnlMain.Controls.Add(this.txtUserName);
            this.PnlMain.Controls.Add(this.label6);
            this.PnlMain.Controls.Add(this.cmbBranch);
            this.PnlMain.Controls.Add(this.txtTotalQauntity);
            this.PnlMain.Controls.Add(this.label5);
            this.PnlMain.Controls.Add(this.label10);
            this.PnlMain.Controls.Add(this.PnlBtn);
            this.PnlMain.Controls.Add(this.chkRePrint);
            this.PnlMain.Controls.Add(this.label2);
            this.PnlMain.Controls.Add(this.dtpPurchaseDate);
            this.PnlMain.Controls.Add(this.txtPaidAmount);
            this.PnlMain.Controls.Add(this.txtNetAmount);
            this.PnlMain.Controls.Add(this.txtDiscPer);
            this.PnlMain.Controls.Add(this.txtDiscAmt);
            this.PnlMain.Controls.Add(this.txtInvoiceTotal);
            this.PnlMain.Controls.Add(this.lblSTaxAmount);
            this.PnlMain.Controls.Add(this.label1);
            this.PnlMain.Controls.Add(this.lblItemDiscount);
            this.PnlMain.Controls.Add(this.label3);
            this.PnlMain.Controls.Add(this.label7);
            this.PnlMain.Controls.Add(this.label4);
            this.PnlMain.Controls.Add(this.txtBillNo);
            this.PnlMain.Controls.Add(this.txtID);
            this.PnlMain.Controls.Add(this.txtPartyID);
            this.PnlMain.Controls.Add(this.btnSchVendor);
            this.PnlMain.Controls.Add(this.txtPartyDetail);
            this.PnlMain.Controls.Add(this.Grd);
            this.PnlMain.Controls.Add(this.label11);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(1133, 639);
            this.PnlMain.TabIndex = 0;
            this.PnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlMain_Paint);
            // 
            // cmbPmtType
            // 
            this.cmbPmtType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPmtType.FormattingEnabled = true;
            this.cmbPmtType.Items.AddRange(new object[] {
            "Cash",
            "Credit"});
            this.cmbPmtType.Location = new System.Drawing.Point(406, 92);
            this.cmbPmtType.Name = "cmbPmtType";
            this.cmbPmtType.Size = new System.Drawing.Size(121, 21);
            this.cmbPmtType.TabIndex = 184;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(325, 96);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 13);
            this.label15.TabIndex = 185;
            this.label15.Text = "Payment Mode";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label18.Location = new System.Drawing.Point(719, 395);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 13);
            this.label18.TabIndex = 164;
            this.label18.Text = "Item Disc:";
            this.label18.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label17.Location = new System.Drawing.Point(545, 395);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 13);
            this.label17.TabIndex = 163;
            this.label17.Text = "Item GST:";
            this.label17.Visible = false;
            // 
            // lblCourierAmt
            // 
            this.lblCourierAmt.AutoSize = true;
            this.lblCourierAmt.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCourierAmt.Location = new System.Drawing.Point(69, 380);
            this.lblCourierAmt.Name = "lblCourierAmt";
            this.lblCourierAmt.Size = new System.Drawing.Size(82, 13);
            this.lblCourierAmt.TabIndex = 162;
            this.lblCourierAmt.Text = "Courier Amount:";
            // 
            // lblTrackingID
            // 
            this.lblTrackingID.AutoSize = true;
            this.lblTrackingID.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTrackingID.Location = new System.Drawing.Point(85, 354);
            this.lblTrackingID.Name = "lblTrackingID";
            this.lblTrackingID.Size = new System.Drawing.Size(66, 13);
            this.lblTrackingID.TabIndex = 161;
            this.lblTrackingID.Text = "Tracking ID:";
            // 
            // txtSumGST
            // 
            this.txtSumGST.Location = new System.Drawing.Point(609, 391);
            this.txtSumGST.Name = "txtSumGST";
            this.txtSumGST.ReadOnly = true;
            this.txtSumGST.Size = new System.Drawing.Size(76, 20);
            this.txtSumGST.TabIndex = 160;
            this.txtSumGST.Visible = false;
            // 
            // txtSumDisc
            // 
            this.txtSumDisc.Location = new System.Drawing.Point(781, 392);
            this.txtSumDisc.Name = "txtSumDisc";
            this.txtSumDisc.ReadOnly = true;
            this.txtSumDisc.Size = new System.Drawing.Size(75, 20);
            this.txtSumDisc.TabIndex = 159;
            this.txtSumDisc.Visible = false;
            // 
            // txtCourierAmount
            // 
            this.txtCourierAmount.Location = new System.Drawing.Point(161, 377);
            this.txtCourierAmount.Name = "txtCourierAmount";
            this.txtCourierAmount.Size = new System.Drawing.Size(142, 20);
            this.txtCourierAmount.TabIndex = 158;
            // 
            // txtTrackingID
            // 
            this.txtTrackingID.Location = new System.Drawing.Point(161, 351);
            this.txtTrackingID.Name = "txtTrackingID";
            this.txtTrackingID.Size = new System.Drawing.Size(142, 20);
            this.txtTrackingID.TabIndex = 157;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(465, 43);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 13);
            this.label14.TabIndex = 156;
            this.label14.Text = "Courier Service : ";
            this.label14.Visible = false;
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // cmbCourier
            // 
            this.cmbCourier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourier.FormattingEnabled = true;
            this.cmbCourier.Location = new System.Drawing.Point(557, 40);
            this.cmbCourier.Name = "cmbCourier";
            this.cmbCourier.Size = new System.Drawing.Size(206, 21);
            this.cmbCourier.TabIndex = 155;
            this.cmbCourier.Visible = false;
            this.cmbCourier.SelectedIndexChanged += new System.EventHandler(this.cmbCourier_SelectedIndexChanged);
            this.cmbCourier.SelectedValueChanged += new System.EventHandler(this.cmbCourier_SelectedValueChanged);
            // 
            // txtGSTPer
            // 
            this.txtGSTPer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtGSTPer.Location = new System.Drawing.Point(826, 263);
            this.txtGSTPer.Name = "txtGSTPer";
            this.txtGSTPer.Size = new System.Drawing.Size(30, 20);
            this.txtGSTPer.TabIndex = 154;
            this.txtGSTPer.Visible = false;
            this.txtGSTPer.Leave += new System.EventHandler(this.txtGSTPer_Leave);
            // 
            // txtGSTAmt
            // 
            this.txtGSTAmt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtGSTAmt.Location = new System.Drawing.Point(878, 263);
            this.txtGSTAmt.Name = "txtGSTAmt";
            this.txtGSTAmt.Size = new System.Drawing.Size(60, 20);
            this.txtGSTAmt.TabIndex = 153;
            this.txtGSTAmt.Visible = false;
            this.txtGSTAmt.TextChanged += new System.EventHandler(this.txtGSTAmt_TextChanged);
            this.txtGSTAmt.Leave += new System.EventHandler(this.txtGSTAmt_Leave);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(785, 265);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 151;
            this.label12.Text = "GST :";
            this.label12.Visible = false;
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(855, 270);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 13);
            this.label13.TabIndex = 152;
            this.label13.Text = "%=";
            this.label13.Visible = false;
            this.label13.Click += new System.EventHandler(this.label13_Click);
            this.label13.Leave += new System.EventHandler(this.label13_Leave);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtRemarks.Location = new System.Drawing.Point(76, 491);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(281, 57);
            this.txtRemarks.TabIndex = 148;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(18, 494);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 147;
            this.label9.Text = "Remarks:";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(126)))), ((int)(((byte)(50)))));
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(19, 599);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(66, 34);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(16, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 145;
            this.label8.Text = "User:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(96, 22);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(143, 20);
            this.txtUserName.TabIndex = 146;
            this.txtUserName.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(226, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 144;
            this.label6.Text = "Branch : ";
            this.label6.Visible = false;
            // 
            // cmbBranch
            // 
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.Enabled = false;
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(278, 224);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(208, 21);
            this.cmbBranch.TabIndex = 143;
            this.cmbBranch.Visible = false;
            // 
            // txtTotalQauntity
            // 
            this.txtTotalQauntity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalQauntity.Location = new System.Drawing.Point(1010, 492);
            this.txtTotalQauntity.Name = "txtTotalQauntity";
            this.txtTotalQauntity.ReadOnly = true;
            this.txtTotalQauntity.Size = new System.Drawing.Size(112, 20);
            this.txtTotalQauntity.TabIndex = 142;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(923, 494);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 141;
            this.label5.Text = "Total Quantity :";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(819, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Supplier Account:";
            // 
            // PnlBtn
            // 
            this.PnlBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PnlBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.PnlBtn.Controls.Add(this.btnNew);
            this.PnlBtn.Controls.Add(this.btnEdit);
            this.PnlBtn.Controls.Add(this.btnSave);
            this.PnlBtn.Location = new System.Drawing.Point(432, 579);
            this.PnlBtn.Name = "PnlBtn";
            this.PnlBtn.Size = new System.Drawing.Size(247, 41);
            this.PnlBtn.TabIndex = 140;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnNew.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(20, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(66, 34);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(126)))), ((int)(((byte)(50)))));
            this.btnEdit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(92, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(66, 34);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(164, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 34);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkRePrint
            // 
            this.chkRePrint.AutoSize = true;
            this.chkRePrint.ForeColor = System.Drawing.Color.White;
            this.chkRePrint.Location = new System.Drawing.Point(19, 574);
            this.chkRePrint.Name = "chkRePrint";
            this.chkRePrint.Size = new System.Drawing.Size(132, 17);
            this.chkRePrint.TabIndex = 139;
            this.chkRePrint.Text = "Add To Print Bar Code";
            this.chkRePrint.UseVisualStyleBackColor = true;
            this.chkRePrint.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(16, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 138;
            this.label2.Text = "Invoice Date :";
            // 
            // dtpPurchaseDate
            // 
            this.dtpPurchaseDate.Location = new System.Drawing.Point(96, 92);
            this.dtpPurchaseDate.Name = "dtpPurchaseDate";
            this.dtpPurchaseDate.Size = new System.Drawing.Size(207, 20);
            this.dtpPurchaseDate.TabIndex = 0;
            this.dtpPurchaseDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpPurchaseDate_KeyDown);
            // 
            // txtPaidAmount
            // 
            this.txtPaidAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPaidAmount.Location = new System.Drawing.Point(596, 308);
            this.txtPaidAmount.Name = "txtPaidAmount";
            this.txtPaidAmount.Size = new System.Drawing.Size(112, 20);
            this.txtPaidAmount.TabIndex = 136;
            this.txtPaidAmount.Visible = false;
            // 
            // txtNetAmount
            // 
            this.txtNetAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNetAmount.Location = new System.Drawing.Point(1010, 520);
            this.txtNetAmount.Name = "txtNetAmount";
            this.txtNetAmount.ReadOnly = true;
            this.txtNetAmount.Size = new System.Drawing.Size(112, 20);
            this.txtNetAmount.TabIndex = 135;
            // 
            // txtDiscPer
            // 
            this.txtDiscPer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDiscPer.Location = new System.Drawing.Point(826, 286);
            this.txtDiscPer.Name = "txtDiscPer";
            this.txtDiscPer.Size = new System.Drawing.Size(30, 20);
            this.txtDiscPer.TabIndex = 134;
            this.txtDiscPer.Visible = false;
            this.txtDiscPer.Leave += new System.EventHandler(this.txtDiscPer_Leave);
            // 
            // txtDiscAmt
            // 
            this.txtDiscAmt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDiscAmt.Location = new System.Drawing.Point(878, 286);
            this.txtDiscAmt.Name = "txtDiscAmt";
            this.txtDiscAmt.Size = new System.Drawing.Size(60, 20);
            this.txtDiscAmt.TabIndex = 133;
            this.txtDiscAmt.Visible = false;
            this.txtDiscAmt.TextChanged += new System.EventHandler(this.txtDiscAmt_TextChanged);
            this.txtDiscAmt.Leave += new System.EventHandler(this.txtDiscAmt_Leave);
            // 
            // txtInvoiceTotal
            // 
            this.txtInvoiceTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtInvoiceTotal.Location = new System.Drawing.Point(917, 373);
            this.txtInvoiceTotal.Name = "txtInvoiceTotal";
            this.txtInvoiceTotal.ReadOnly = true;
            this.txtInvoiceTotal.Size = new System.Drawing.Size(112, 20);
            this.txtInvoiceTotal.TabIndex = 132;
            this.txtInvoiceTotal.Visible = false;
            // 
            // lblSTaxAmount
            // 
            this.lblSTaxAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSTaxAmount.AutoSize = true;
            this.lblSTaxAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSTaxAmount.ForeColor = System.Drawing.Color.White;
            this.lblSTaxAmount.Location = new System.Drawing.Point(510, 311);
            this.lblSTaxAmount.Name = "lblSTaxAmount";
            this.lblSTaxAmount.Size = new System.Drawing.Size(86, 13);
            this.lblSTaxAmount.TabIndex = 127;
            this.lblSTaxAmount.Text = "Paid Amount :";
            this.lblSTaxAmount.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(923, 522);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 128;
            this.label1.Text = "Net Amount :";
            // 
            // lblItemDiscount
            // 
            this.lblItemDiscount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblItemDiscount.AutoSize = true;
            this.lblItemDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemDiscount.ForeColor = System.Drawing.Color.White;
            this.lblItemDiscount.Location = new System.Drawing.Point(718, 289);
            this.lblItemDiscount.Name = "lblItemDiscount";
            this.lblItemDiscount.Size = new System.Drawing.Size(107, 13);
            this.lblItemDiscount.TabIndex = 129;
            this.lblItemDiscount.Text = "Invoice Discount:";
            this.lblItemDiscount.Visible = false;
            this.lblItemDiscount.Click += new System.EventHandler(this.lblItemDiscount_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(826, 375);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 130;
            this.label3.Text = "Invoice Total :";
            this.label3.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(16, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 118;
            this.label7.Text = "Bill No :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(16, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Invoice No:";
            // 
            // txtBillNo
            // 
            this.txtBillNo.Location = new System.Drawing.Point(96, 69);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Size = new System.Drawing.Size(143, 20);
            this.txtBillNo.TabIndex = 1;
            this.txtBillNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBillNo_KeyDown);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(96, 46);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(143, 20);
            this.txtID.TabIndex = 113;
            this.txtID.TabStop = false;
            // 
            // txtPartyID
            // 
            this.txtPartyID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPartyID.Location = new System.Drawing.Point(916, 47);
            this.txtPartyID.Name = "txtPartyID";
            this.txtPartyID.Size = new System.Drawing.Size(176, 20);
            this.txtPartyID.TabIndex = 2;
            this.txtPartyID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPartyID.TextChanged += new System.EventHandler(this.txtPartyID_TextChanged);
            this.txtPartyID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyID_KeyDown);
            this.txtPartyID.Validating += new System.ComponentModel.CancelEventHandler(this.txtPartyID_Validating);
            // 
            // btnSchVendor
            // 
            this.btnSchVendor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSchVendor.Image = ((System.Drawing.Image)(resources.GetObject("btnSchVendor.Image")));
            this.btnSchVendor.Location = new System.Drawing.Point(1093, 46);
            this.btnSchVendor.Name = "btnSchVendor";
            this.btnSchVendor.Size = new System.Drawing.Size(29, 23);
            this.btnSchVendor.TabIndex = 3;
            this.btnSchVendor.TabStop = false;
            this.btnSchVendor.UseVisualStyleBackColor = true;
            this.btnSchVendor.Click += new System.EventHandler(this.btnSchVendor_Click);
            // 
            // txtPartyDetail
            // 
            this.txtPartyDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPartyDetail.Location = new System.Drawing.Point(916, 70);
            this.txtPartyDetail.Multiline = true;
            this.txtPartyDetail.Name = "txtPartyDetail";
            this.txtPartyDetail.ReadOnly = true;
            this.txtPartyDetail.Size = new System.Drawing.Size(205, 43);
            this.txtPartyDetail.TabIndex = 109;
            this.txtPartyDetail.TabStop = false;
            // 
            // Grd
            // 
            this.Grd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grd.DefaultCellStyle = dataGridViewCellStyle4;
            this.Grd.Location = new System.Drawing.Point(12, 119);
            this.Grd.MoveLeftToRight = true;
            this.Grd.Name = "Grd";
            this.Grd.Size = new System.Drawing.Size(1109, 358);
            this.Grd.StandardTab = true;
            this.Grd.TabIndex = 3;
            this.Grd.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grd_CellDoubleClick);
            this.Grd.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grd_CellEndEdit);
            this.Grd.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.Grd_RowsAdded);
            this.Grd.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.Grd_RowsRemoved);
            this.Grd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grd_KeyDown);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(856, 296);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 13);
            this.label11.TabIndex = 131;
            this.label11.Text = "%=";
            this.label11.Visible = false;
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // frmPurchaseInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 639);
            this.Controls.Add(this.PnlMain);
            this.Name = "frmPurchaseInvoice";
            this.Tag = "7";
            this.Text = "Purchase Invoice";
            this.Load += new System.EventHandler(this.frmPurchaseInvoice_Load);
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            this.PnlBtn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblSTaxAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblItemDiscount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBillNo;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtPartyID;
        private System.Windows.Forms.Button btnSchVendor;
        private System.Windows.Forms.TextBox txtPartyDetail;
        private DGV.DGV Grd;
        private System.Windows.Forms.TextBox txtPaidAmount;
        private System.Windows.Forms.TextBox txtNetAmount;
        private System.Windows.Forms.TextBox txtDiscPer;
        private System.Windows.Forms.TextBox txtDiscAmt;
        private System.Windows.Forms.TextBox txtInvoiceTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpPurchaseDate;
        private System.Windows.Forms.CheckBox chkRePrint;
        private System.Windows.Forms.Panel PnlBtn;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTotalQauntity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtGSTPer;
        private System.Windows.Forms.TextBox txtGSTAmt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbCourier;
        private System.Windows.Forms.Label lblCourierAmt;
        private System.Windows.Forms.Label lblTrackingID;
        private System.Windows.Forms.TextBox txtSumGST;
        private System.Windows.Forms.TextBox txtSumDisc;
        private System.Windows.Forms.TextBox txtCourierAmount;
        private System.Windows.Forms.TextBox txtTrackingID;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cmbPmtType;
        private System.Windows.Forms.Label label15;
    }
}
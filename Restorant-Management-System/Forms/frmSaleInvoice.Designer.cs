namespace Restorant_Management_System.Forms
{
    partial class frmSaleInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaleInvoice));
            this.PnlMain = new System.Windows.Forms.Panel();
            this.PnlSub = new System.Windows.Forms.Panel();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtTotalQuantity = new System.Windows.Forms.TextBox();
            this.btnPending = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBranchID = new System.Windows.Forms.TextBox();
            this.GrpCustomer = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtPartyID = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtPartyDetail = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.pnlUper = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblPendingCount = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSaleid = new System.Windows.Forms.TextBox();
            this.lblid = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.txtCardNo = new System.Windows.Forms.TextBox();
            this.lblCardNo = new System.Windows.Forms.Label();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.lblBank = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtCustomerCell = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.cmbCreditCard = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCashPayment = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtReturnAmount = new System.Windows.Forms.TextBox();
            this.txtInvDiscPer = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtInvDiscount = new System.Windows.Forms.TextBox();
            this.PnlBtn = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtDeductionPer = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDeduction = new System.Windows.Forms.TextBox();
            this.txtCardPayment = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtNetAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGrandTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Grd = new DGV.DGV();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PnlMain.SuspendLayout();
            this.PnlSub.SuspendLayout();
            this.GrpCustomer.SuspendLayout();
            this.pnlUper.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.PnlBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.BackColor = System.Drawing.Color.SteelBlue;
            this.PnlMain.Controls.Add(this.PnlSub);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(1097, 626);
            this.PnlMain.TabIndex = 0;
            this.PnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlMain_Paint);
            // 
            // PnlSub
            // 
            this.PnlSub.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlSub.BackColor = System.Drawing.Color.SteelBlue;
            this.PnlSub.Controls.Add(this.cmbBranch);
            this.PnlSub.Controls.Add(this.label21);
            this.PnlSub.Controls.Add(this.label16);
            this.PnlSub.Controls.Add(this.dtpDate);
            this.PnlSub.Controls.Add(this.btnCancel);
            this.PnlSub.Controls.Add(this.txtTotalQuantity);
            this.PnlSub.Controls.Add(this.btnPending);
            this.PnlSub.Controls.Add(this.label12);
            this.PnlSub.Controls.Add(this.txtBranchID);
            this.PnlSub.Controls.Add(this.GrpCustomer);
            this.PnlSub.Controls.Add(this.button2);
            this.PnlSub.Controls.Add(this.label19);
            this.PnlSub.Controls.Add(this.txtUserName);
            this.PnlSub.Controls.Add(this.pnlUper);
            this.PnlSub.Controls.Add(this.pnlBottom);
            this.PnlSub.Controls.Add(this.txtInvDiscPer);
            this.PnlSub.Controls.Add(this.label10);
            this.PnlSub.Controls.Add(this.txtInvDiscount);
            this.PnlSub.Controls.Add(this.PnlBtn);
            this.PnlSub.Controls.Add(this.label11);
            this.PnlSub.Controls.Add(this.label13);
            this.PnlSub.Controls.Add(this.lblDate);
            this.PnlSub.Controls.Add(this.txtDeductionPer);
            this.PnlSub.Controls.Add(this.label8);
            this.PnlSub.Controls.Add(this.txtDeduction);
            this.PnlSub.Controls.Add(this.txtCardPayment);
            this.PnlSub.Controls.Add(this.label15);
            this.PnlSub.Controls.Add(this.txtNetAmount);
            this.PnlSub.Controls.Add(this.label6);
            this.PnlSub.Controls.Add(this.txtGrandTotal);
            this.PnlSub.Controls.Add(this.label4);
            this.PnlSub.Controls.Add(this.txtDiscount);
            this.PnlSub.Controls.Add(this.label3);
            this.PnlSub.Controls.Add(this.Grd);
            this.PnlSub.Controls.Add(this.txtID);
            this.PnlSub.Controls.Add(this.label1);
            this.PnlSub.Location = new System.Drawing.Point(12, 12);
            this.PnlSub.Name = "PnlSub";
            this.PnlSub.Size = new System.Drawing.Size(1073, 602);
            this.PnlSub.TabIndex = 0;
            this.PnlSub.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlSub_Paint);
            // 
            // cmbBranch
            // 
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.Enabled = false;
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(87, 156);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(212, 21);
            this.cmbBranch.TabIndex = 172;
            this.cmbBranch.Visible = false;
            this.cmbBranch.SelectedIndexChanged += new System.EventHandler(this.cmbBranch_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(39, 160);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(44, 13);
            this.label21.TabIndex = 171;
            this.label21.Text = "Branch:";
            this.label21.Visible = false;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(589, 92);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 13);
            this.label16.TabIndex = 170;
            this.label16.Text = "Invoice Date:";
            // 
            // dtpDate
            // 
            this.dtpDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDate.Location = new System.Drawing.Point(665, 90);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 169;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(126)))), ((int)(((byte)(50)))));
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Tomato;
            this.btnCancel.Location = new System.Drawing.Point(331, 319);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 34);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtTotalQuantity
            // 
            this.txtTotalQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalQuantity.Location = new System.Drawing.Point(924, 497);
            this.txtTotalQuantity.Name = "txtTotalQuantity";
            this.txtTotalQuantity.ReadOnly = true;
            this.txtTotalQuantity.Size = new System.Drawing.Size(140, 20);
            this.txtTotalQuantity.TabIndex = 168;
            // 
            // btnPending
            // 
            this.btnPending.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPending.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnPending.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(126)))), ((int)(((byte)(50)))));
            this.btnPending.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPending.ForeColor = System.Drawing.Color.White;
            this.btnPending.Location = new System.Drawing.Point(413, 317);
            this.btnPending.Name = "btnPending";
            this.btnPending.Size = new System.Drawing.Size(76, 34);
            this.btnPending.TabIndex = 6;
            this.btnPending.Text = "Pending";
            this.btnPending.UseVisualStyleBackColor = false;
            this.btnPending.Visible = false;
            this.btnPending.Click += new System.EventHandler(this.btnPending_Click);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(839, 500);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 13);
            this.label12.TabIndex = 167;
            this.label12.Text = "Total Quantity :";
            // 
            // txtBranchID
            // 
            this.txtBranchID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBranchID.Location = new System.Drawing.Point(259, 293);
            this.txtBranchID.Name = "txtBranchID";
            this.txtBranchID.Size = new System.Drawing.Size(80, 20);
            this.txtBranchID.TabIndex = 166;
            this.txtBranchID.Visible = false;
            // 
            // GrpCustomer
            // 
            this.GrpCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpCustomer.Controls.Add(this.label20);
            this.GrpCustomer.Controls.Add(this.txtPartyID);
            this.GrpCustomer.Controls.Add(this.btnSearch);
            this.GrpCustomer.Controls.Add(this.txtPartyDetail);
            this.GrpCustomer.Location = new System.Drawing.Point(880, 3);
            this.GrpCustomer.Name = "GrpCustomer";
            this.GrpCustomer.Size = new System.Drawing.Size(186, 108);
            this.GrpCustomer.TabIndex = 165;
            this.GrpCustomer.TabStop = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(15, 13);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(108, 13);
            this.label20.TabIndex = 112;
            this.label20.Text = "Department Account:";
            // 
            // txtPartyID
            // 
            this.txtPartyID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPartyID.Location = new System.Drawing.Point(17, 32);
            this.txtPartyID.Name = "txtPartyID";
            this.txtPartyID.Size = new System.Drawing.Size(128, 20);
            this.txtPartyID.TabIndex = 110;
            this.txtPartyID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(144, 31);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(29, 23);
            this.btnSearch.TabIndex = 111;
            this.btnSearch.TabStop = false;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtPartyDetail
            // 
            this.txtPartyDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPartyDetail.Location = new System.Drawing.Point(17, 55);
            this.txtPartyDetail.Multiline = true;
            this.txtPartyDetail.Name = "txtPartyDetail";
            this.txtPartyDetail.ReadOnly = true;
            this.txtPartyDetail.Size = new System.Drawing.Size(156, 43);
            this.txtPartyDetail.TabIndex = 113;
            this.txtPartyDetail.TabStop = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(348, 308);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(29, 23);
            this.button2.TabIndex = 164;
            this.button2.TabStop = false;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(7, 69);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(32, 13);
            this.label19.TabIndex = 162;
            this.label19.Text = "User:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(69, 66);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(143, 20);
            this.txtUserName.TabIndex = 163;
            this.txtUserName.TabStop = false;
            // 
            // pnlUper
            // 
            this.pnlUper.Controls.Add(this.button1);
            this.pnlUper.Controls.Add(this.textBox1);
            this.pnlUper.Controls.Add(this.lblPendingCount);
            this.pnlUper.Controls.Add(this.label14);
            this.pnlUper.Controls.Add(this.txtReference);
            this.pnlUper.Controls.Add(this.label2);
            this.pnlUper.Controls.Add(this.txtSaleid);
            this.pnlUper.Controls.Add(this.lblid);
            this.pnlUper.Location = new System.Drawing.Point(38, 244);
            this.pnlUper.Name = "pnlUper";
            this.pnlUper.Size = new System.Drawing.Size(330, 55);
            this.pnlUper.TabIndex = 161;
            this.pnlUper.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(-220, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 20);
            this.button1.TabIndex = 153;
            this.button1.TabStop = false;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(-331, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(110, 20);
            this.textBox1.TabIndex = 152;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPendingCount
            // 
            this.lblPendingCount.Location = new System.Drawing.Point(235, 3);
            this.lblPendingCount.Name = "lblPendingCount";
            this.lblPendingCount.ReadOnly = true;
            this.lblPendingCount.Size = new System.Drawing.Size(39, 20);
            this.lblPendingCount.TabIndex = 132;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(31, 4);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 13);
            this.label14.TabIndex = 151;
            this.label14.Text = "Pend. Inv:";
            // 
            // txtReference
            // 
            this.txtReference.Location = new System.Drawing.Point(88, 24);
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(68, 20);
            this.txtReference.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Reference By:";
            // 
            // txtSaleid
            // 
            this.txtSaleid.Location = new System.Drawing.Point(213, 24);
            this.txtSaleid.Name = "txtSaleid";
            this.txtSaleid.Size = new System.Drawing.Size(110, 20);
            this.txtSaleid.TabIndex = 158;
            this.txtSaleid.TextChanged += new System.EventHandler(this.txtSaleid_TextChanged);
            this.txtSaleid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSaleid_KeyDown);
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.ForeColor = System.Drawing.Color.White;
            this.lblid.Location = new System.Drawing.Point(163, 26);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(42, 13);
            this.lblid.TabIndex = 159;
            this.lblid.Text = "SaleID:";
            this.lblid.Click += new System.EventHandler(this.label16_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.txtCardNo);
            this.pnlBottom.Controls.Add(this.lblCardNo);
            this.pnlBottom.Controls.Add(this.cmbBank);
            this.pnlBottom.Controls.Add(this.lblBank);
            this.pnlBottom.Controls.Add(this.label18);
            this.pnlBottom.Controls.Add(this.label17);
            this.pnlBottom.Controls.Add(this.txtCustomerCell);
            this.pnlBottom.Controls.Add(this.txtCustomerName);
            this.pnlBottom.Controls.Add(this.cmbCreditCard);
            this.pnlBottom.Controls.Add(this.label7);
            this.pnlBottom.Controls.Add(this.txtCashPayment);
            this.pnlBottom.Controls.Add(this.label9);
            this.pnlBottom.Controls.Add(this.label5);
            this.pnlBottom.Controls.Add(this.txtReturnAmount);
            this.pnlBottom.Location = new System.Drawing.Point(666, 191);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(178, 180);
            this.pnlBottom.TabIndex = 160;
            this.pnlBottom.Visible = false;
            // 
            // txtCardNo
            // 
            this.txtCardNo.Location = new System.Drawing.Point(110, 152);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(23, 20);
            this.txtCardNo.TabIndex = 137;
            // 
            // lblCardNo
            // 
            this.lblCardNo.AutoSize = true;
            this.lblCardNo.ForeColor = System.Drawing.Color.White;
            this.lblCardNo.Location = new System.Drawing.Point(52, 156);
            this.lblCardNo.Name = "lblCardNo";
            this.lblCardNo.Size = new System.Drawing.Size(52, 13);
            this.lblCardNo.TabIndex = 138;
            this.lblCardNo.Text = "Card No :";
            // 
            // cmbBank
            // 
            this.cmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Items.AddRange(new object[] {
            "MCB",
            "Bank Al-Falah",
            "HBL"});
            this.cmbBank.Location = new System.Drawing.Point(110, 126);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(22, 21);
            this.cmbBank.TabIndex = 135;
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.ForeColor = System.Drawing.Color.White;
            this.lblBank.Location = new System.Drawing.Point(60, 129);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(44, 13);
            this.lblBank.TabIndex = 136;
            this.lblBank.Text = "Banck :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(25, 126);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 13);
            this.label18.TabIndex = 134;
            this.label18.Text = "Customer Cell :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(15, 101);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(88, 13);
            this.label17.TabIndex = 133;
            this.label17.Text = "Customer Name :";
            // 
            // txtCustomerCell
            // 
            this.txtCustomerCell.Location = new System.Drawing.Point(107, 123);
            this.txtCustomerCell.Name = "txtCustomerCell";
            this.txtCustomerCell.Size = new System.Drawing.Size(44, 20);
            this.txtCustomerCell.TabIndex = 132;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(107, 99);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(44, 20);
            this.txtCustomerName.TabIndex = 131;
            // 
            // cmbCreditCard
            // 
            this.cmbCreditCard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCreditCard.FormattingEnabled = true;
            this.cmbCreditCard.Items.AddRange(new object[] {
            "Cash",
            "Credit Card",
            "Cash & Credit Card",
            "Credit Sale"});
            this.cmbCreditCard.Location = new System.Drawing.Point(107, 6);
            this.cmbCreditCard.Name = "cmbCreditCard";
            this.cmbCreditCard.Size = new System.Drawing.Size(44, 21);
            this.cmbCreditCard.TabIndex = 125;
            this.cmbCreditCard.SelectedIndexChanged += new System.EventHandler(this.cmbCreditCard_SelectedIndexChanged);
            this.cmbCreditCard.SelectedValueChanged += new System.EventHandler(this.cmbCreditCard_SelectedValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(19, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 126;
            this.label7.Text = "Payment Mode :";
            // 
            // txtCashPayment
            // 
            this.txtCashPayment.Location = new System.Drawing.Point(106, 40);
            this.txtCashPayment.Name = "txtCashPayment";
            this.txtCashPayment.Size = new System.Drawing.Size(45, 20);
            this.txtCashPayment.TabIndex = 129;
            this.txtCashPayment.TextChanged += new System.EventHandler(this.txtCashPayment_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(22, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 130;
            this.label9.Text = "Cash Payment :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(19, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 123;
            this.label5.Text = "Return Amount :";
            // 
            // txtReturnAmount
            // 
            this.txtReturnAmount.Location = new System.Drawing.Point(106, 65);
            this.txtReturnAmount.Name = "txtReturnAmount";
            this.txtReturnAmount.ReadOnly = true;
            this.txtReturnAmount.Size = new System.Drawing.Size(45, 20);
            this.txtReturnAmount.TabIndex = 124;
            // 
            // txtInvDiscPer
            // 
            this.txtInvDiscPer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtInvDiscPer.Location = new System.Drawing.Point(102, 296);
            this.txtInvDiscPer.Name = "txtInvDiscPer";
            this.txtInvDiscPer.Size = new System.Drawing.Size(43, 20);
            this.txtInvDiscPer.TabIndex = 155;
            this.txtInvDiscPer.Visible = false;
            this.txtInvDiscPer.Leave += new System.EventHandler(this.txtInvDiscPer_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(44, 311);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 142;
            this.label10.Text = "Inv Discount";
            this.label10.Visible = false;
            // 
            // txtInvDiscount
            // 
            this.txtInvDiscount.Location = new System.Drawing.Point(187, 314);
            this.txtInvDiscount.Name = "txtInvDiscount";
            this.txtInvDiscount.Size = new System.Drawing.Size(80, 20);
            this.txtInvDiscount.TabIndex = 143;
            this.txtInvDiscount.Visible = false;
            this.txtInvDiscount.Leave += new System.EventHandler(this.txtInvDiscount_Leave);
            // 
            // PnlBtn
            // 
            this.PnlBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PnlBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.PnlBtn.Controls.Add(this.btnNew);
            this.PnlBtn.Controls.Add(this.btnSave);
            this.PnlBtn.Controls.Add(this.btnEdit);
            this.PnlBtn.Location = new System.Drawing.Point(367, 557);
            this.PnlBtn.Name = "PnlBtn";
            this.PnlBtn.Size = new System.Drawing.Size(315, 41);
            this.PnlBtn.TabIndex = 141;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnNew.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(54, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(66, 34);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(194, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 34);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(126)))), ((int)(((byte)(50)))));
            this.btnEdit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(125, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(66, 34);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click_1);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(40, 338);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 144;
            this.label11.Text = "Deduction";
            this.label11.Visible = false;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(147, 326);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 13);
            this.label13.TabIndex = 148;
            this.label13.Text = "%=";
            this.label13.Visible = false;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Yellow;
            this.lblDate.Location = new System.Drawing.Point(116, 32);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(42, 19);
            this.lblDate.TabIndex = 131;
            this.lblDate.Text = "Date";
            this.lblDate.Visible = false;
            // 
            // txtDeductionPer
            // 
            this.txtDeductionPer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDeductionPer.Location = new System.Drawing.Point(102, 322);
            this.txtDeductionPer.Name = "txtDeductionPer";
            this.txtDeductionPer.Size = new System.Drawing.Size(42, 20);
            this.txtDeductionPer.TabIndex = 150;
            this.txtDeductionPer.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(380, 266);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 128;
            this.label8.Text = "Card Payment";
            this.label8.Visible = false;
            // 
            // txtDeduction
            // 
            this.txtDeduction.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDeduction.Location = new System.Drawing.Point(173, 321);
            this.txtDeduction.Name = "txtDeduction";
            this.txtDeduction.Size = new System.Drawing.Size(80, 20);
            this.txtDeduction.TabIndex = 149;
            this.txtDeduction.Visible = false;
            // 
            // txtCardPayment
            // 
            this.txtCardPayment.Location = new System.Drawing.Point(455, 263);
            this.txtCardPayment.Name = "txtCardPayment";
            this.txtCardPayment.Size = new System.Drawing.Size(157, 20);
            this.txtCardPayment.TabIndex = 127;
            this.txtCardPayment.Visible = false;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(147, 299);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 13);
            this.label15.TabIndex = 154;
            this.label15.Text = "%=";
            this.label15.Visible = false;
            // 
            // txtNetAmount
            // 
            this.txtNetAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNetAmount.Location = new System.Drawing.Point(924, 525);
            this.txtNetAmount.Name = "txtNetAmount";
            this.txtNetAmount.ReadOnly = true;
            this.txtNetAmount.Size = new System.Drawing.Size(140, 20);
            this.txtNetAmount.TabIndex = 122;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(849, 527);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 121;
            this.label6.Text = "Net Amount :";
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.Location = new System.Drawing.Point(405, 193);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.ReadOnly = true;
            this.txtGrandTotal.Size = new System.Drawing.Size(140, 20);
            this.txtGrandTotal.TabIndex = 120;
            this.txtGrandTotal.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(332, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 119;
            this.label4.Text = "Gross Total :";
            this.label4.Visible = false;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(405, 219);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.ReadOnly = true;
            this.txtDiscount.Size = new System.Drawing.Size(140, 20);
            this.txtDiscount.TabIndex = 118;
            this.txtDiscount.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(344, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 117;
            this.label3.Text = "Discount :";
            this.label3.Visible = false;
            // 
            // Grd
            // 
            this.Grd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grd.Location = new System.Drawing.Point(3, 118);
            this.Grd.MoveLeftToRight = true;
            this.Grd.Name = "Grd";
            this.Grd.Size = new System.Drawing.Size(1067, 373);
            this.Grd.TabIndex = 116;
            this.Grd.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grd_CellEndEdit);
            this.Grd.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grd_CellLeave);
            this.Grd.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.Grd_RowsAdded);
            this.Grd.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.Grd_RowsRemoved);
            this.Grd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grd_KeyDown);
            this.Grd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Grd_KeyPress);
            this.Grd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Grd_KeyUp);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(69, 92);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(143, 20);
            this.txtID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Invoice ID:";
            // 
            // frmSaleInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(221)))), ((int)(((byte)(190)))));
            this.ClientSize = new System.Drawing.Size(1097, 626);
            this.Controls.Add(this.PnlMain);
            this.KeyPreview = true;
            this.Name = "frmSaleInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "10";
            this.Text = "Sale Invoice";
            this.Load += new System.EventHandler(this.frmSaleInvoice_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSaleInvoice_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmSaleInvoice_KeyPress);
            this.PnlMain.ResumeLayout(false);
            this.PnlSub.ResumeLayout(false);
            this.PnlSub.PerformLayout();
            this.GrpCustomer.ResumeLayout(false);
            this.GrpCustomer.PerformLayout();
            this.pnlUper.ResumeLayout(false);
            this.pnlUper.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.PnlBtn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.Panel PnlSub;
        private System.Windows.Forms.TextBox txtReference;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label1;
        private DGV.DGV Grd;
        private System.Windows.Forms.TextBox txtReturnAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNetAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGrandTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCashPayment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCardPayment;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbCreditCard;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox lblPendingCount;
        private System.Windows.Forms.Panel PnlBtn;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtInvDiscount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDeductionPer;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnPending;
        private System.Windows.Forms.TextBox txtInvDiscPer;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtDeduction;
        private System.Windows.Forms.Label lblid;
        private System.Windows.Forms.TextBox txtSaleid;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlUper;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtCustomerCell;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox GrpCustomer;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtPartyID;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtPartyDetail;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtBranchID;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.TextBox txtCardNo;
        private System.Windows.Forms.Label lblCardNo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtTotalQuantity;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.Label label21;
    }
}
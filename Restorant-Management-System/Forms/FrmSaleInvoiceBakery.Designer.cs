namespace Restorant_Management_System.Forms
{
    partial class FrmSaleInvoiceBakery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSaleInvoiceBakery));
            this.PnlSub = new System.Windows.Forms.Panel();
            this.txtGrossAmt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.txtCardNo = new System.Windows.Forms.TextBox();
            this.lblCardNo = new System.Windows.Forms.Label();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.lblBank = new System.Windows.Forms.Label();
            this.cmbCreditCard = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCashPayment = new System.Windows.Forms.TextBox();
            this.lblCPmt = new System.Windows.Forms.Label();
            this.lblRAmt = new System.Windows.Forms.Label();
            this.txtReturnAmount = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtInvDiscPer = new System.Windows.Forms.TextBox();
            this.txtInvDisc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtTotalQuantity = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.GrpCustomer = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtPartyID = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtPartyDetail = new System.Windows.Forms.TextBox();
            this.txtNetAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Grd = new DGV.DGV();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PnlSub.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.GrpCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlSub
            // 
            this.PnlSub.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PnlSub.BackColor = System.Drawing.Color.SteelBlue;
            this.PnlSub.Controls.Add(this.txtGrossAmt);
            this.PnlSub.Controls.Add(this.label2);
            this.PnlSub.Controls.Add(this.pnlBottom);
            this.PnlSub.Controls.Add(this.btnClose);
            this.PnlSub.Controls.Add(this.label15);
            this.PnlSub.Controls.Add(this.txtInvDiscPer);
            this.PnlSub.Controls.Add(this.txtInvDisc);
            this.PnlSub.Controls.Add(this.label3);
            this.PnlSub.Controls.Add(this.btnNew);
            this.PnlSub.Controls.Add(this.btnSave);
            this.PnlSub.Controls.Add(this.btnEdit);
            this.PnlSub.Controls.Add(this.label16);
            this.PnlSub.Controls.Add(this.dtpDate);
            this.PnlSub.Controls.Add(this.txtTotalQuantity);
            this.PnlSub.Controls.Add(this.label12);
            this.PnlSub.Controls.Add(this.GrpCustomer);
            this.PnlSub.Controls.Add(this.txtNetAmount);
            this.PnlSub.Controls.Add(this.label6);
            this.PnlSub.Controls.Add(this.Grd);
            this.PnlSub.Controls.Add(this.txtID);
            this.PnlSub.Controls.Add(this.label1);
            this.PnlSub.Location = new System.Drawing.Point(-2, 0);
            this.PnlSub.Name = "PnlSub";
            this.PnlSub.Size = new System.Drawing.Size(1146, 639);
            this.PnlSub.TabIndex = 1;
            // 
            // txtGrossAmt
            // 
            this.txtGrossAmt.Location = new System.Drawing.Point(978, 471);
            this.txtGrossAmt.Name = "txtGrossAmt";
            this.txtGrossAmt.ReadOnly = true;
            this.txtGrossAmt.Size = new System.Drawing.Size(156, 20);
            this.txtGrossAmt.TabIndex = 185;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(893, 474);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 184;
            this.label2.Text = "Gross Amount :";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.txtCardNo);
            this.pnlBottom.Controls.Add(this.lblCardNo);
            this.pnlBottom.Controls.Add(this.cmbBank);
            this.pnlBottom.Controls.Add(this.lblBank);
            this.pnlBottom.Controls.Add(this.cmbCreditCard);
            this.pnlBottom.Controls.Add(this.label7);
            this.pnlBottom.Controls.Add(this.txtCashPayment);
            this.pnlBottom.Controls.Add(this.lblCPmt);
            this.pnlBottom.Controls.Add(this.lblRAmt);
            this.pnlBottom.Controls.Add(this.txtReturnAmount);
            this.pnlBottom.Location = new System.Drawing.Point(18, 443);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(539, 90);
            this.pnlBottom.TabIndex = 183;
            // 
            // txtCardNo
            // 
            this.txtCardNo.Location = new System.Drawing.Point(323, 31);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(200, 20);
            this.txtCardNo.TabIndex = 137;
            // 
            // lblCardNo
            // 
            this.lblCardNo.AutoSize = true;
            this.lblCardNo.ForeColor = System.Drawing.Color.White;
            this.lblCardNo.Location = new System.Drawing.Point(265, 33);
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
            this.cmbBank.Location = new System.Drawing.Point(324, 4);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(199, 21);
            this.cmbBank.TabIndex = 135;
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.ForeColor = System.Drawing.Color.White;
            this.lblBank.Location = new System.Drawing.Point(274, 6);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(44, 13);
            this.lblBank.TabIndex = 136;
            this.lblBank.Text = "Banck :";
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
            this.cmbCreditCard.Size = new System.Drawing.Size(128, 21);
            this.cmbCreditCard.TabIndex = 125;
            this.cmbCreditCard.SelectedIndexChanged += new System.EventHandler(this.cmbCreditCard_SelectedIndexChanged);
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
            this.txtCashPayment.Size = new System.Drawing.Size(129, 20);
            this.txtCashPayment.TabIndex = 129;
            this.txtCashPayment.TextChanged += new System.EventHandler(this.txtCashPayment_TextChanged);
            // 
            // lblCPmt
            // 
            this.lblCPmt.AutoSize = true;
            this.lblCPmt.ForeColor = System.Drawing.Color.White;
            this.lblCPmt.Location = new System.Drawing.Point(22, 43);
            this.lblCPmt.Name = "lblCPmt";
            this.lblCPmt.Size = new System.Drawing.Size(81, 13);
            this.lblCPmt.TabIndex = 130;
            this.lblCPmt.Text = "Cash Payment :";
            // 
            // lblRAmt
            // 
            this.lblRAmt.AutoSize = true;
            this.lblRAmt.ForeColor = System.Drawing.Color.White;
            this.lblRAmt.Location = new System.Drawing.Point(19, 68);
            this.lblRAmt.Name = "lblRAmt";
            this.lblRAmt.Size = new System.Drawing.Size(84, 13);
            this.lblRAmt.TabIndex = 123;
            this.lblRAmt.Text = "Return Amount :";
            // 
            // txtReturnAmount
            // 
            this.txtReturnAmount.Location = new System.Drawing.Point(106, 65);
            this.txtReturnAmount.Name = "txtReturnAmount";
            this.txtReturnAmount.ReadOnly = true;
            this.txtReturnAmount.Size = new System.Drawing.Size(129, 20);
            this.txtReturnAmount.TabIndex = 124;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(631, 593);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 34);
            this.btnClose.TabIndex = 182;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(1019, 501);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 13);
            this.label15.TabIndex = 181;
            this.label15.Text = "%=";
            // 
            // txtInvDiscPer
            // 
            this.txtInvDiscPer.Location = new System.Drawing.Point(978, 496);
            this.txtInvDiscPer.Name = "txtInvDiscPer";
            this.txtInvDiscPer.Size = new System.Drawing.Size(40, 20);
            this.txtInvDiscPer.TabIndex = 180;
            this.txtInvDiscPer.Leave += new System.EventHandler(this.txtInvDiscPer_Leave);
            // 
            // txtInvDisc
            // 
            this.txtInvDisc.Location = new System.Drawing.Point(1045, 496);
            this.txtInvDisc.Name = "txtInvDisc";
            this.txtInvDisc.Size = new System.Drawing.Size(89, 20);
            this.txtInvDisc.TabIndex = 179;
            this.txtInvDisc.Leave += new System.EventHandler(this.txtInvDisc_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(899, 499);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 178;
            this.label3.Text = "Inv Discount :";
            // 
            // btnNew
            // 
            this.btnNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnNew.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(485, 593);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(66, 34);
            this.btnNew.TabIndex = 173;
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
            this.btnSave.Location = new System.Drawing.Point(559, 593);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 34);
            this.btnSave.TabIndex = 174;
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
            this.btnEdit.Location = new System.Drawing.Point(59, 405);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(66, 34);
            this.btnEdit.TabIndex = 175;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(19, 108);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 13);
            this.label16.TabIndex = 170;
            this.label16.Text = "Invoice Date:";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(95, 106);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(185, 20);
            this.dtpDate.TabIndex = 169;
            // 
            // txtTotalQuantity
            // 
            this.txtTotalQuantity.Location = new System.Drawing.Point(978, 446);
            this.txtTotalQuantity.Name = "txtTotalQuantity";
            this.txtTotalQuantity.ReadOnly = true;
            this.txtTotalQuantity.Size = new System.Drawing.Size(156, 20);
            this.txtTotalQuantity.TabIndex = 168;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(893, 449);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 13);
            this.label12.TabIndex = 167;
            this.label12.Text = "Total Quantity :";
            // 
            // GrpCustomer
            // 
            this.GrpCustomer.Controls.Add(this.label20);
            this.GrpCustomer.Controls.Add(this.txtPartyID);
            this.GrpCustomer.Controls.Add(this.btnSearch);
            this.GrpCustomer.Controls.Add(this.txtPartyDetail);
            this.GrpCustomer.Location = new System.Drawing.Point(948, 21);
            this.GrpCustomer.Name = "GrpCustomer";
            this.GrpCustomer.Size = new System.Drawing.Size(186, 104);
            this.GrpCustomer.TabIndex = 165;
            this.GrpCustomer.TabStop = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(15, 13);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(80, 13);
            this.label20.TabIndex = 112;
            this.label20.Text = "Buyer Account:";
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
            // txtNetAmount
            // 
            this.txtNetAmount.Location = new System.Drawing.Point(978, 520);
            this.txtNetAmount.Name = "txtNetAmount";
            this.txtNetAmount.ReadOnly = true;
            this.txtNetAmount.Size = new System.Drawing.Size(156, 20);
            this.txtNetAmount.TabIndex = 122;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(903, 522);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 121;
            this.label6.Text = "Net Amount :";
            // 
            // Grd
            // 
            this.Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grd.Location = new System.Drawing.Point(15, 131);
            this.Grd.MoveLeftToRight = true;
            this.Grd.Name = "Grd";
            this.Grd.Size = new System.Drawing.Size(1120, 309);
            this.Grd.TabIndex = 116;
            this.Grd.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grd_CellEndEdit);
            this.Grd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grd_KeyDown);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(95, 82);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(185, 20);
            this.txtID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(33, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Invoice ID:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // FrmSaleInvoiceBakery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 637);
            this.Controls.Add(this.PnlSub);
            this.Name = "FrmSaleInvoiceBakery";
            this.Tag = "15";
            this.Text = "FrmSaleInvoiceBakery";
            this.Load += new System.EventHandler(this.FrmSaleInvoiceBakery_Load);
            this.PnlSub.ResumeLayout(false);
            this.PnlSub.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.GrpCustomer.ResumeLayout(false);
            this.GrpCustomer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlSub;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox txtTotalQuantity;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox GrpCustomer;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtPartyID;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtPartyDetail;
        private System.Windows.Forms.TextBox txtNetAmount;
        private System.Windows.Forms.Label label6;
        private DGV.DGV Grd;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtInvDiscPer;
        private System.Windows.Forms.TextBox txtInvDisc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.TextBox txtCardNo;
        private System.Windows.Forms.Label lblCardNo;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.ComboBox cmbCreditCard;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCashPayment;
        private System.Windows.Forms.Label lblCPmt;
        private System.Windows.Forms.Label lblRAmt;
        private System.Windows.Forms.TextBox txtReturnAmount;
        private System.Windows.Forms.TextBox txtGrossAmt;
        private System.Windows.Forms.Label label2;
    }
}
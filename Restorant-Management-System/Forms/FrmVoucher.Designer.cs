namespace Restorant_Management_System.Forms
{
    partial class FrmVoucher
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
            this.txtVoucherNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbTrasactionFlow = new System.Windows.Forms.ComboBox();
            this.cmbVoucherType = new System.Windows.Forms.ComboBox();
            this.lblFlow = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCheckNo = new System.Windows.Forms.TextBox();
            this.cmbBankAccount = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCheckNo = new System.Windows.Forms.Label();
            this.lblBankAccount = new System.Windows.Forms.Label();
            this.dtpDated = new System.Windows.Forms.DateTimePicker();
            this.lblCheckDate = new System.Windows.Forms.Label();
            this.dtpCheckDate = new System.Windows.Forms.DateTimePicker();
            this.Grd = new DGV.DGV();
            this.txtCredit = new System.Windows.Forms.TextBox();
            this.txtDebit = new System.Windows.Forms.TextBox();
            this.lblCredit = new System.Windows.Forms.Label();
            this.lblDebit = new System.Windows.Forms.Label();
            this.chkPrint = new System.Windows.Forms.CheckBox();
            this.dtpDatedPrv = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblAmountInWords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblBankAccNo = new System.Windows.Forms.Label();
            this.lblBankAccName = new System.Windows.Forms.Label();
            this.txtBankAccNo = new System.Windows.Forms.TextBox();
            this.txtBankAccName = new System.Windows.Forms.TextBox();
            this.btnSchBanck = new System.Windows.Forms.Button();
            this.txtPreveBarnchid = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtVoucherNo
            // 
            this.txtVoucherNo.Location = new System.Drawing.Point(98, 102);
            this.txtVoucherNo.Name = "txtVoucherNo";
            this.txtVoucherNo.ReadOnly = true;
            this.txtVoucherNo.Size = new System.Drawing.Size(93, 20);
            this.txtVoucherNo.TabIndex = 95;
            this.txtVoucherNo.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(17, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 94;
            this.label4.Text = "Voucher No:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(198, 130);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(49, 23);
            this.btnSearch.TabIndex = 100;
            this.btnSearch.TabStop = false;
            this.btnSearch.Text = "Searc&h";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Visible = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbTrasactionFlow
            // 
            this.cmbTrasactionFlow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrasactionFlow.FormattingEnabled = true;
            this.cmbTrasactionFlow.Location = new System.Drawing.Point(98, 158);
            this.cmbTrasactionFlow.Name = "cmbTrasactionFlow";
            this.cmbTrasactionFlow.Size = new System.Drawing.Size(93, 21);
            this.cmbTrasactionFlow.TabIndex = 96;
            this.cmbTrasactionFlow.SelectedIndexChanged += new System.EventHandler(this.cmbTrasactionFlow_SelectedIndexChanged);
            // 
            // cmbVoucherType
            // 
            this.cmbVoucherType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVoucherType.FormattingEnabled = true;
            this.cmbVoucherType.Location = new System.Drawing.Point(98, 130);
            this.cmbVoucherType.Name = "cmbVoucherType";
            this.cmbVoucherType.Size = new System.Drawing.Size(93, 21);
            this.cmbVoucherType.TabIndex = 97;
            this.cmbVoucherType.SelectedIndexChanged += new System.EventHandler(this.cmbVoucherType_SelectedIndexChanged);
            this.cmbVoucherType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbVoucherType_KeyDown);
            this.cmbVoucherType.Leave += new System.EventHandler(this.cmbVoucherType_Leave);
            // 
            // lblFlow
            // 
            this.lblFlow.AutoSize = true;
            this.lblFlow.ForeColor = System.Drawing.Color.White;
            this.lblFlow.Location = new System.Drawing.Point(17, 160);
            this.lblFlow.Name = "lblFlow";
            this.lblFlow.Size = new System.Drawing.Size(32, 13);
            this.lblFlow.TabIndex = 98;
            this.lblFlow.Text = "Flow:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 99;
            this.label1.Text = "VoucherType:";
            // 
            // txtCheckNo
            // 
            this.txtCheckNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCheckNo.Location = new System.Drawing.Point(391, 153);
            this.txtCheckNo.Name = "txtCheckNo";
            this.txtCheckNo.Size = new System.Drawing.Size(267, 20);
            this.txtCheckNo.TabIndex = 103;
            // 
            // cmbBankAccount
            // 
            this.cmbBankAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBankAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBankAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBankAccount.FormattingEnabled = true;
            this.cmbBankAccount.Location = new System.Drawing.Point(894, 45);
            this.cmbBankAccount.Name = "cmbBankAccount";
            this.cmbBankAccount.Size = new System.Drawing.Size(76, 21);
            this.cmbBankAccount.TabIndex = 102;
            this.cmbBankAccount.Visible = false;
            this.cmbBankAccount.SelectedValueChanged += new System.EventHandler(this.cmbBankAccount_SelectedValueChanged);
            this.cmbBankAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBankAccount_KeyDown);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(723, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 106;
            this.label5.Text = "Voucher Date:";
            // 
            // lblCheckNo
            // 
            this.lblCheckNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCheckNo.AutoSize = true;
            this.lblCheckNo.ForeColor = System.Drawing.Color.White;
            this.lblCheckNo.Location = new System.Drawing.Point(292, 156);
            this.lblCheckNo.Name = "lblCheckNo";
            this.lblCheckNo.Size = new System.Drawing.Size(46, 13);
            this.lblCheckNo.TabIndex = 104;
            this.lblCheckNo.Text = "Chq No:";
            // 
            // lblBankAccount
            // 
            this.lblBankAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBankAccount.AutoSize = true;
            this.lblBankAccount.ForeColor = System.Drawing.Color.White;
            this.lblBankAccount.Location = new System.Drawing.Point(811, 47);
            this.lblBankAccount.Name = "lblBankAccount";
            this.lblBankAccount.Size = new System.Drawing.Size(78, 13);
            this.lblBankAccount.TabIndex = 105;
            this.lblBankAccount.Text = "Bank Account:";
            this.lblBankAccount.Visible = false;
            // 
            // dtpDated
            // 
            this.dtpDated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDated.Location = new System.Drawing.Point(803, 115);
            this.dtpDated.Name = "dtpDated";
            this.dtpDated.Size = new System.Drawing.Size(164, 20);
            this.dtpDated.TabIndex = 107;
            // 
            // lblCheckDate
            // 
            this.lblCheckDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCheckDate.AutoSize = true;
            this.lblCheckDate.ForeColor = System.Drawing.Color.White;
            this.lblCheckDate.Location = new System.Drawing.Point(723, 145);
            this.lblCheckDate.Name = "lblCheckDate";
            this.lblCheckDate.Size = new System.Drawing.Size(55, 13);
            this.lblCheckDate.TabIndex = 108;
            this.lblCheckDate.Text = "Chq Date:";
            // 
            // dtpCheckDate
            // 
            this.dtpCheckDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpCheckDate.Location = new System.Drawing.Point(803, 140);
            this.dtpCheckDate.Name = "dtpCheckDate";
            this.dtpCheckDate.Size = new System.Drawing.Size(164, 20);
            this.dtpCheckDate.TabIndex = 109;
            // 
            // Grd
            // 
            this.Grd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grd.Location = new System.Drawing.Point(14, 190);
            this.Grd.MoveLeftToRight = true;
            this.Grd.Name = "Grd";
            this.Grd.RowTemplate.Height = 24;
            this.Grd.Size = new System.Drawing.Size(956, 258);
            this.Grd.StandardTab = true;
            this.Grd.TabIndex = 110;
            this.Grd.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grd_CellEndEdit);
            this.Grd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grd_KeyDown);
            // 
            // txtCredit
            // 
            this.txtCredit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCredit.Location = new System.Drawing.Point(869, 454);
            this.txtCredit.Name = "txtCredit";
            this.txtCredit.ReadOnly = true;
            this.txtCredit.Size = new System.Drawing.Size(100, 20);
            this.txtCredit.TabIndex = 113;
            this.txtCredit.TabStop = false;
            this.txtCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDebit
            // 
            this.txtDebit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDebit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDebit.Location = new System.Drawing.Point(694, 454);
            this.txtDebit.Name = "txtDebit";
            this.txtDebit.ReadOnly = true;
            this.txtDebit.Size = new System.Drawing.Size(100, 20);
            this.txtDebit.TabIndex = 114;
            this.txtDebit.TabStop = false;
            this.txtDebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCredit
            // 
            this.lblCredit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCredit.AutoSize = true;
            this.lblCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCredit.ForeColor = System.Drawing.Color.White;
            this.lblCredit.Location = new System.Drawing.Point(820, 458);
            this.lblCredit.Name = "lblCredit";
            this.lblCredit.Size = new System.Drawing.Size(37, 13);
            this.lblCredit.TabIndex = 111;
            this.lblCredit.Text = "Credit:";
            // 
            // lblDebit
            // 
            this.lblDebit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDebit.AutoSize = true;
            this.lblDebit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebit.ForeColor = System.Drawing.Color.White;
            this.lblDebit.Location = new System.Drawing.Point(646, 458);
            this.lblDebit.Name = "lblDebit";
            this.lblDebit.Size = new System.Drawing.Size(35, 13);
            this.lblDebit.TabIndex = 112;
            this.lblDebit.Text = "Debit:";
            // 
            // chkPrint
            // 
            this.chkPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkPrint.AutoSize = true;
            this.chkPrint.Checked = true;
            this.chkPrint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrint.ForeColor = System.Drawing.Color.White;
            this.chkPrint.Location = new System.Drawing.Point(28, 458);
            this.chkPrint.Name = "chkPrint";
            this.chkPrint.Size = new System.Drawing.Size(114, 17);
            this.chkPrint.TabIndex = 115;
            this.chkPrint.TabStop = false;
            this.chkPrint.Text = "(Print while saving)";
            this.chkPrint.UseVisualStyleBackColor = true;
            // 
            // dtpDatedPrv
            // 
            this.dtpDatedPrv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDatedPrv.Location = new System.Drawing.Point(803, 91);
            this.dtpDatedPrv.Name = "dtpDatedPrv";
            this.dtpDatedPrv.Size = new System.Drawing.Size(165, 20);
            this.dtpDatedPrv.TabIndex = 116;
            this.dtpDatedPrv.TabStop = false;
            this.dtpDatedPrv.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Location = new System.Drawing.Point(296, 492);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(309, 50);
            this.panel2.TabIndex = 117;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnPrint.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(296, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(68, 33);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(84, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(68, 33);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnNew.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(15, 6);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(68, 33);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnEdit.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(153, 6);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(68, 33);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(222, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 33);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtID
            // 
            this.txtID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtID.Location = new System.Drawing.Point(872, 166);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(77, 20);
            this.txtID.TabIndex = 10;
            this.txtID.TabStop = false;
            this.txtID.Visible = false;
            // 
            // lblAmountInWords
            // 
            this.lblAmountInWords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAmountInWords.AutoSize = true;
            this.lblAmountInWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountInWords.Location = new System.Drawing.Point(659, 489);
            this.lblAmountInWords.Name = "lblAmountInWords";
            this.lblAmountInWords.Size = new System.Drawing.Size(109, 13);
            this.lblAmountInWords.TabIndex = 118;
            this.lblAmountInWords.Text = "lblAmountInWords";
            this.lblAmountInWords.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(304, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 119;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(455, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 120;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(42, 517);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 121;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(347, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 156;
            this.label7.Text = "Branch : ";
            this.label7.Visible = false;
            // 
            // cmbBranch
            // 
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.Enabled = false;
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(400, 226);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(267, 21);
            this.cmbBranch.TabIndex = 155;
            this.cmbBranch.Visible = false;
            // 
            // lblType
            // 
            this.lblType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.ForeColor = System.Drawing.Color.White;
            this.lblType.Location = new System.Drawing.Point(390, 29);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(84, 31);
            this.lblType.TabIndex = 157;
            this.lblType.Text = "Type?";
            // 
            // lblBankAccNo
            // 
            this.lblBankAccNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblBankAccNo.AutoSize = true;
            this.lblBankAccNo.ForeColor = System.Drawing.Color.White;
            this.lblBankAccNo.Location = new System.Drawing.Point(292, 105);
            this.lblBankAccNo.Name = "lblBankAccNo";
            this.lblBankAccNo.Size = new System.Drawing.Size(95, 13);
            this.lblBankAccNo.TabIndex = 158;
            this.lblBankAccNo.Text = "Bank Account No:";
            // 
            // lblBankAccName
            // 
            this.lblBankAccName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblBankAccName.AutoSize = true;
            this.lblBankAccName.ForeColor = System.Drawing.Color.White;
            this.lblBankAccName.Location = new System.Drawing.Point(292, 131);
            this.lblBankAccName.Name = "lblBankAccName";
            this.lblBankAccName.Size = new System.Drawing.Size(66, 13);
            this.lblBankAccName.TabIndex = 159;
            this.lblBankAccName.Text = "Bank Name:";
            // 
            // txtBankAccNo
            // 
            this.txtBankAccNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBankAccNo.Location = new System.Drawing.Point(391, 101);
            this.txtBankAccNo.Name = "txtBankAccNo";
            this.txtBankAccNo.ReadOnly = true;
            this.txtBankAccNo.Size = new System.Drawing.Size(112, 20);
            this.txtBankAccNo.TabIndex = 160;
            // 
            // txtBankAccName
            // 
            this.txtBankAccName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBankAccName.Location = new System.Drawing.Point(391, 127);
            this.txtBankAccName.Name = "txtBankAccName";
            this.txtBankAccName.ReadOnly = true;
            this.txtBankAccName.Size = new System.Drawing.Size(267, 20);
            this.txtBankAccName.TabIndex = 161;
            // 
            // btnSchBanck
            // 
            this.btnSchBanck.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSchBanck.Location = new System.Drawing.Point(511, 99);
            this.btnSchBanck.Name = "btnSchBanck";
            this.btnSchBanck.Size = new System.Drawing.Size(49, 23);
            this.btnSchBanck.TabIndex = 162;
            this.btnSchBanck.TabStop = false;
            this.btnSchBanck.Text = "Searc&h";
            this.btnSchBanck.UseVisualStyleBackColor = true;
            this.btnSchBanck.Click += new System.EventHandler(this.btnSchBanck_Click_1);
            // 
            // txtPreveBarnchid
            // 
            this.txtPreveBarnchid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPreveBarnchid.Location = new System.Drawing.Point(780, 166);
            this.txtPreveBarnchid.Name = "txtPreveBarnchid";
            this.txtPreveBarnchid.ReadOnly = true;
            this.txtPreveBarnchid.Size = new System.Drawing.Size(77, 20);
            this.txtPreveBarnchid.TabIndex = 163;
            this.txtPreveBarnchid.TabStop = false;
            this.txtPreveBarnchid.Visible = false;
            // 
            // FrmVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(984, 551);
            this.Controls.Add(this.txtPreveBarnchid);
            this.Controls.Add(this.btnSchBanck);
            this.Controls.Add(this.txtBankAccName);
            this.Controls.Add(this.txtBankAccNo);
            this.Controls.Add(this.lblBankAccName);
            this.Controls.Add(this.lblBankAccNo);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbBranch);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAmountInWords);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dtpDatedPrv);
            this.Controls.Add(this.chkPrint);
            this.Controls.Add(this.txtCredit);
            this.Controls.Add(this.txtDebit);
            this.Controls.Add(this.lblCredit);
            this.Controls.Add(this.lblDebit);
            this.Controls.Add(this.Grd);
            this.Controls.Add(this.dtpCheckDate);
            this.Controls.Add(this.lblCheckDate);
            this.Controls.Add(this.dtpDated);
            this.Controls.Add(this.txtCheckNo);
            this.Controls.Add(this.cmbBankAccount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblCheckNo);
            this.Controls.Add(this.lblBankAccount);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cmbTrasactionFlow);
            this.Controls.Add(this.cmbVoucherType);
            this.Controls.Add(this.lblFlow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVoucherNo);
            this.Controls.Add(this.label4);
            this.Name = "FrmVoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "11";
            this.Text = "Voucher";
            this.Load += new System.EventHandler(this.FrmVoucher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtVoucherNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.ComboBox cmbTrasactionFlow;
        public System.Windows.Forms.ComboBox cmbVoucherType;
        private System.Windows.Forms.Label lblFlow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCheckNo;
        private System.Windows.Forms.ComboBox cmbBankAccount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCheckNo;
        private System.Windows.Forms.Label lblBankAccount;
        private System.Windows.Forms.DateTimePicker dtpDated;
        private System.Windows.Forms.Label lblCheckDate;
        private System.Windows.Forms.DateTimePicker dtpCheckDate;
        private DGV.DGV Grd;
        private System.Windows.Forms.TextBox txtCredit;
        private System.Windows.Forms.TextBox txtDebit;
        private System.Windows.Forms.Label lblCredit;
        private System.Windows.Forms.Label lblDebit;
        private System.Windows.Forms.CheckBox chkPrint;
        private System.Windows.Forms.DateTimePicker dtpDatedPrv;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblAmountInWords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblBankAccNo;
        private System.Windows.Forms.Label lblBankAccName;
        private System.Windows.Forms.TextBox txtBankAccNo;
        private System.Windows.Forms.TextBox txtBankAccName;
        private System.Windows.Forms.Button btnSchBanck;
        private System.Windows.Forms.TextBox txtPreveBarnchid;
    }
}
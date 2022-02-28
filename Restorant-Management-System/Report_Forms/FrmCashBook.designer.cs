namespace Accounts
{
    partial class FrmCahBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCahBook));
            this.FrmCurrentStock_Fill_Panel = new System.Windows.Forms.Panel();
            this.grpParty = new System.Windows.Forms.GroupBox();
            this.btnAllParties = new System.Windows.Forms.Button();
            this.btnSch = new System.Windows.Forms.Button();
            this.txtPartName = new System.Windows.Forms.TextBox();
            this.txtPartyID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.grpFilterBranch = new System.Windows.Forms.GroupBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpFormats = new System.Windows.Forms.GroupBox();
            this.rdbCashBook = new System.Windows.Forms.RadioButton();
            this.rdbCashInHand = new System.Windows.Forms.RadioButton();
            this.chkLevel = new System.Windows.Forms.CheckBox();
            this.gbADay = new System.Windows.Forms.GroupBox();
            this.dtpADay = new System.Windows.Forms.DateTimePicker();
            this.gbDateRange = new System.Windows.Forms.GroupBox();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.rdbToday = new System.Windows.Forms.RadioButton();
            this.rdbADay = new System.Windows.Forms.RadioButton();
            this.rdbDateRange = new System.Windows.Forms.RadioButton();
            this.rdbAllDates = new System.Windows.Forms.RadioButton();
            this.lblVoucherType = new System.Windows.Forms.Label();
            this.cmbVoucherType = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.FrmCurrentStock_Fill_Panel.SuspendLayout();
            this.grpParty.SuspendLayout();
            this.grpFilterBranch.SuspendLayout();
            this.grpFormats.SuspendLayout();
            this.gbADay.SuspendLayout();
            this.gbDateRange.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FrmCurrentStock_Fill_Panel
            // 
            this.FrmCurrentStock_Fill_Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FrmCurrentStock_Fill_Panel.BackColor = System.Drawing.Color.SteelBlue;
            this.FrmCurrentStock_Fill_Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.grpParty);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.grpFilterBranch);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.lblName);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.btnPrint);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.btnPreview);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.btnNew);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.btnClose);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.grpFormats);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.chkLevel);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.gbADay);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.gbDateRange);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.rdbToday);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.rdbADay);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.rdbDateRange);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.rdbAllDates);
            this.FrmCurrentStock_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.FrmCurrentStock_Fill_Panel.Location = new System.Drawing.Point(10, 14);
            this.FrmCurrentStock_Fill_Panel.Name = "FrmCurrentStock_Fill_Panel";
            this.FrmCurrentStock_Fill_Panel.Size = new System.Drawing.Size(555, 497);
            this.FrmCurrentStock_Fill_Panel.TabIndex = 0;
            this.FrmCurrentStock_Fill_Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmCurrentStock_Fill_Panel_Paint);
            // 
            // grpParty
            // 
            this.grpParty.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.grpParty.Controls.Add(this.btnAllParties);
            this.grpParty.Controls.Add(this.btnSch);
            this.grpParty.Controls.Add(this.txtPartName);
            this.grpParty.Controls.Add(this.txtPartyID);
            this.grpParty.Controls.Add(this.label8);
            this.grpParty.Controls.Add(this.label9);
            this.grpParty.ForeColor = System.Drawing.Color.White;
            this.grpParty.Location = new System.Drawing.Point(15, 340);
            this.grpParty.Name = "grpParty";
            this.grpParty.Size = new System.Drawing.Size(520, 65);
            this.grpParty.TabIndex = 160;
            this.grpParty.TabStop = false;
            this.grpParty.Text = "Account  Detail";
            // 
            // btnAllParties
            // 
            this.btnAllParties.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAllParties.Location = new System.Drawing.Point(431, 31);
            this.btnAllParties.Name = "btnAllParties";
            this.btnAllParties.Size = new System.Drawing.Size(83, 23);
            this.btnAllParties.TabIndex = 3;
            this.btnAllParties.TabStop = false;
            this.btnAllParties.Text = "All Accounts";
            this.btnAllParties.UseVisualStyleBackColor = true;
            this.btnAllParties.Visible = false;
            this.btnAllParties.Click += new System.EventHandler(this.btnAllParties_Click);
            // 
            // btnSch
            // 
            this.btnSch.Image = ((System.Drawing.Image)(resources.GetObject("btnSch.Image")));
            this.btnSch.Location = new System.Drawing.Point(117, 31);
            this.btnSch.Name = "btnSch";
            this.btnSch.Size = new System.Drawing.Size(33, 23);
            this.btnSch.TabIndex = 1;
            this.btnSch.TabStop = false;
            this.btnSch.UseVisualStyleBackColor = true;
            this.btnSch.Click += new System.EventHandler(this.btnSch_Click);
            // 
            // txtPartName
            // 
            this.txtPartName.BackColor = System.Drawing.Color.White;
            this.txtPartName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPartName.ForeColor = System.Drawing.Color.IndianRed;
            this.txtPartName.Location = new System.Drawing.Point(152, 32);
            this.txtPartName.Name = "txtPartName";
            this.txtPartName.ReadOnly = true;
            this.txtPartName.Size = new System.Drawing.Size(277, 20);
            this.txtPartName.TabIndex = 2;
            this.txtPartName.TabStop = false;
            // 
            // txtPartyID
            // 
            this.txtPartyID.Location = new System.Drawing.Point(30, 32);
            this.txtPartyID.Name = "txtPartyID";
            this.txtPartyID.Size = new System.Drawing.Size(87, 20);
            this.txtPartyID.TabIndex = 0;
            this.txtPartyID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyID_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(149, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Account Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Account No";
            // 
            // grpFilterBranch
            // 
            this.grpFilterBranch.Controls.Add(this.cmbType);
            this.grpFilterBranch.Controls.Add(this.label1);
            this.grpFilterBranch.Controls.Add(this.label7);
            this.grpFilterBranch.Controls.Add(this.cmbBranch);
            this.grpFilterBranch.ForeColor = System.Drawing.Color.White;
            this.grpFilterBranch.Location = new System.Drawing.Point(110, 229);
            this.grpFilterBranch.Name = "grpFilterBranch";
            this.grpFilterBranch.Size = new System.Drawing.Size(313, 89);
            this.grpFilterBranch.TabIndex = 159;
            this.grpFilterBranch.TabStop = false;
            this.grpFilterBranch.Text = "Selection";
            this.grpFilterBranch.Visible = false;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(93, 20);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(203, 21);
            this.cmbType.TabIndex = 161;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 162;
            this.label1.Text = "Voucher Type:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(41, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 160;
            this.label7.Text = "Branch : ";
            this.label7.Visible = false;
            // 
            // cmbBranch
            // 
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.Enabled = false;
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(94, 54);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(202, 21);
            this.cmbBranch.TabIndex = 159;
            this.cmbBranch.Visible = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(214, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(71, 26);
            this.lblName.TabIndex = 26;
            this.lblName.Text = "Name";
            this.lblName.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(352, 441);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 29);
            this.btnPrint.TabIndex = 25;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Location = new System.Drawing.Point(269, 441);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 29);
            this.btnPreview.TabIndex = 24;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(187, 441);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 29);
            this.btnNew.TabIndex = 23;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(106, 441);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grpFormats
            // 
            this.grpFormats.Controls.Add(this.rdbCashBook);
            this.grpFormats.Controls.Add(this.rdbCashInHand);
            this.grpFormats.ForeColor = System.Drawing.Color.White;
            this.grpFormats.Location = new System.Drawing.Point(424, 86);
            this.grpFormats.Name = "grpFormats";
            this.grpFormats.Size = new System.Drawing.Size(115, 41);
            this.grpFormats.TabIndex = 22;
            this.grpFormats.TabStop = false;
            this.grpFormats.Text = "Formats";
            this.grpFormats.Visible = false;
            // 
            // rdbCashBook
            // 
            this.rdbCashBook.AutoSize = true;
            this.rdbCashBook.Location = new System.Drawing.Point(63, 18);
            this.rdbCashBook.Name = "rdbCashBook";
            this.rdbCashBook.Size = new System.Drawing.Size(31, 17);
            this.rdbCashBook.TabIndex = 0;
            this.rdbCashBook.TabStop = true;
            this.rdbCashBook.Text = "2";
            this.rdbCashBook.UseVisualStyleBackColor = true;
            // 
            // rdbCashInHand
            // 
            this.rdbCashInHand.AutoSize = true;
            this.rdbCashInHand.Checked = true;
            this.rdbCashInHand.Location = new System.Drawing.Point(12, 18);
            this.rdbCashInHand.Name = "rdbCashInHand";
            this.rdbCashInHand.Size = new System.Drawing.Size(31, 17);
            this.rdbCashInHand.TabIndex = 0;
            this.rdbCashInHand.TabStop = true;
            this.rdbCashInHand.Text = "1";
            this.rdbCashInHand.UseVisualStyleBackColor = true;
            // 
            // chkLevel
            // 
            this.chkLevel.AutoSize = true;
            this.chkLevel.ForeColor = System.Drawing.Color.White;
            this.chkLevel.Location = new System.Drawing.Point(435, 133);
            this.chkLevel.Name = "chkLevel";
            this.chkLevel.Size = new System.Drawing.Size(104, 17);
            this.chkLevel.TabIndex = 21;
            this.chkLevel.Text = "At PO/DO Level";
            this.chkLevel.UseVisualStyleBackColor = true;
            this.chkLevel.Visible = false;
            this.chkLevel.CheckedChanged += new System.EventHandler(this.chkLevel_CheckedChanged);
            // 
            // gbADay
            // 
            this.gbADay.Controls.Add(this.dtpADay);
            this.gbADay.ForeColor = System.Drawing.Color.White;
            this.gbADay.Location = new System.Drawing.Point(127, 144);
            this.gbADay.Name = "gbADay";
            this.gbADay.Size = new System.Drawing.Size(114, 45);
            this.gbADay.TabIndex = 5;
            this.gbADay.TabStop = false;
            this.gbADay.Text = "A Day";
            this.gbADay.Visible = false;
            // 
            // dtpADay
            // 
            this.dtpADay.CustomFormat = "dd/MM/yyyy";
            this.dtpADay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpADay.Location = new System.Drawing.Point(6, 19);
            this.dtpADay.Name = "dtpADay";
            this.dtpADay.Size = new System.Drawing.Size(102, 20);
            this.dtpADay.TabIndex = 0;
            this.dtpADay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdbAllDates_KeyDown);
            // 
            // gbDateRange
            // 
            this.gbDateRange.Controls.Add(this.dtpFrom);
            this.gbDateRange.Controls.Add(this.label11);
            this.gbDateRange.Controls.Add(this.label10);
            this.gbDateRange.Controls.Add(this.dtpTo);
            this.gbDateRange.ForeColor = System.Drawing.Color.White;
            this.gbDateRange.Location = new System.Drawing.Point(127, 81);
            this.gbDateRange.Name = "gbDateRange";
            this.gbDateRange.Size = new System.Drawing.Size(231, 61);
            this.gbDateRange.TabIndex = 3;
            this.gbDateRange.TabStop = false;
            this.gbDateRange.Text = "Date Range";
            this.gbDateRange.Visible = false;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(7, 35);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(102, 20);
            this.dtpFrom.TabIndex = 0;
            this.dtpFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdbAllDates_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(120, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "To";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "From";
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(120, 35);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(105, 20);
            this.dtpTo.TabIndex = 1;
            this.dtpTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdbAllDates_KeyDown);
            // 
            // rdbToday
            // 
            this.rdbToday.AutoSize = true;
            this.rdbToday.ForeColor = System.Drawing.Color.White;
            this.rdbToday.Location = new System.Drawing.Point(40, 188);
            this.rdbToday.Name = "rdbToday";
            this.rdbToday.Size = new System.Drawing.Size(55, 17);
            this.rdbToday.TabIndex = 6;
            this.rdbToday.TabStop = true;
            this.rdbToday.Text = "Today";
            this.rdbToday.UseVisualStyleBackColor = true;
            this.rdbToday.CheckedChanged += new System.EventHandler(this.rdbToday_CheckedChanged);
            this.rdbToday.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdbAllDates_KeyDown);
            // 
            // rdbADay
            // 
            this.rdbADay.AutoSize = true;
            this.rdbADay.ForeColor = System.Drawing.Color.White;
            this.rdbADay.Location = new System.Drawing.Point(40, 144);
            this.rdbADay.Name = "rdbADay";
            this.rdbADay.Size = new System.Drawing.Size(54, 17);
            this.rdbADay.TabIndex = 4;
            this.rdbADay.TabStop = true;
            this.rdbADay.Text = "A Day";
            this.rdbADay.UseVisualStyleBackColor = true;
            this.rdbADay.CheckedChanged += new System.EventHandler(this.rdbADay_CheckedChanged);
            this.rdbADay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdbAllDates_KeyDown);
            // 
            // rdbDateRange
            // 
            this.rdbDateRange.AutoSize = true;
            this.rdbDateRange.ForeColor = System.Drawing.Color.White;
            this.rdbDateRange.Location = new System.Drawing.Point(40, 99);
            this.rdbDateRange.Name = "rdbDateRange";
            this.rdbDateRange.Size = new System.Drawing.Size(83, 17);
            this.rdbDateRange.TabIndex = 2;
            this.rdbDateRange.TabStop = true;
            this.rdbDateRange.Text = "Date Range";
            this.rdbDateRange.UseVisualStyleBackColor = true;
            this.rdbDateRange.CheckedChanged += new System.EventHandler(this.rdbDateRange_CheckedChanged);
            this.rdbDateRange.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdbAllDates_KeyDown);
            // 
            // rdbAllDates
            // 
            this.rdbAllDates.AutoSize = true;
            this.rdbAllDates.ForeColor = System.Drawing.Color.White;
            this.rdbAllDates.Location = new System.Drawing.Point(40, 57);
            this.rdbAllDates.Name = "rdbAllDates";
            this.rdbAllDates.Size = new System.Drawing.Size(67, 17);
            this.rdbAllDates.TabIndex = 1;
            this.rdbAllDates.TabStop = true;
            this.rdbAllDates.Text = "All Dates";
            this.rdbAllDates.UseVisualStyleBackColor = true;
            this.rdbAllDates.CheckedChanged += new System.EventHandler(this.rdbAllDates_CheckedChanged);
            this.rdbAllDates.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdbAllDates_KeyDown);
            // 
            // lblVoucherType
            // 
            this.lblVoucherType.AutoSize = true;
            this.lblVoucherType.ForeColor = System.Drawing.Color.White;
            this.lblVoucherType.Location = new System.Drawing.Point(722, 189);
            this.lblVoucherType.Name = "lblVoucherType";
            this.lblVoucherType.Size = new System.Drawing.Size(74, 13);
            this.lblVoucherType.TabIndex = 7;
            this.lblVoucherType.Text = "Voucher Type";
            this.lblVoucherType.Visible = false;
            // 
            // cmbVoucherType
            // 
            this.cmbVoucherType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVoucherType.ForeColor = System.Drawing.Color.Black;
            this.cmbVoucherType.FormattingEnabled = true;
            this.cmbVoucherType.Location = new System.Drawing.Point(776, 141);
            this.cmbVoucherType.Name = "cmbVoucherType";
            this.cmbVoucherType.Size = new System.Drawing.Size(29, 21);
            this.cmbVoucherType.TabIndex = 5;
            this.cmbVoucherType.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.FrmCurrentStock_Fill_Panel);
            this.panel1.Controls.Add(this.lblVoucherType);
            this.panel1.Controls.Add(this.cmbVoucherType);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(581, 524);
            this.panel1.TabIndex = 1;
            // 
            // FrmCahBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(221)))), ((int)(((byte)(190)))));
            this.ClientSize = new System.Drawing.Size(581, 524);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmCahBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cash Book Report...";
            this.Load += new System.EventHandler(this.FrmCurrentStock_Load);
            this.FrmCurrentStock_Fill_Panel.ResumeLayout(false);
            this.FrmCurrentStock_Fill_Panel.PerformLayout();
            this.grpParty.ResumeLayout(false);
            this.grpParty.PerformLayout();
            this.grpFilterBranch.ResumeLayout(false);
            this.grpFilterBranch.PerformLayout();
            this.grpFormats.ResumeLayout(false);
            this.grpFormats.PerformLayout();
            this.gbADay.ResumeLayout(false);
            this.gbDateRange.ResumeLayout(false);
            this.gbDateRange.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel FrmCurrentStock_Fill_Panel;
        private System.Windows.Forms.RadioButton rdbToday;
        private System.Windows.Forms.RadioButton rdbADay;
        private System.Windows.Forms.RadioButton rdbDateRange;
        private System.Windows.Forms.RadioButton rdbAllDates;
        private System.Windows.Forms.GroupBox gbDateRange;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpADay;
        private System.Windows.Forms.GroupBox gbADay;
        private System.Windows.Forms.Label lblVoucherType;
        private System.Windows.Forms.ComboBox cmbVoucherType;
        private System.Windows.Forms.CheckBox chkLevel;
        private System.Windows.Forms.GroupBox grpFormats;
        private System.Windows.Forms.RadioButton rdbCashBook;
        private System.Windows.Forms.RadioButton rdbCashInHand;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox grpParty;
        private System.Windows.Forms.Button btnAllParties;
        private System.Windows.Forms.Button btnSch;
        private System.Windows.Forms.TextBox txtPartName;
        private System.Windows.Forms.TextBox txtPartyID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox grpFilterBranch;
        public System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbBranch;
    }
}
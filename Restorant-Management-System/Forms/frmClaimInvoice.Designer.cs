namespace Restorant_Management_System.Forms
{
    partial class frmClaimInvoice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClaimInvoice));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.lblInvNo = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbInvoiceType = new System.Windows.Forms.ComboBox();
            this.lblHeading = new System.Windows.Forms.Label();
            this.lblCourierAmt = new System.Windows.Forms.Label();
            this.lblTrackingID = new System.Windows.Forms.Label();
            this.txtCourierAmount = new System.Windows.Forms.TextBox();
            this.txtTrackingID = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbCourier = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.chkAdjustEntry = new System.Windows.Forms.CheckBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtNaration = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.txtTotalQuantity = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.PnlBtn = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtInvDiscPer = new System.Windows.Forms.TextBox();
            this.txtPaid = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRemainingAmt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtInvDisc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotalAmt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Grd = new DGV.DGV();
            this.cmbClaimType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPartyID = new System.Windows.Forms.TextBox();
            this.btnSchVendor = new System.Windows.Forms.Button();
            this.txtPartyDetail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDated = new System.Windows.Forms.DateTimePicker();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.PnlBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.txtInvoiceNo);
            this.panel1.Controls.Add(this.lblInvNo);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.cmbInvoiceType);
            this.panel1.Controls.Add(this.lblHeading);
            this.panel1.Controls.Add(this.lblCourierAmt);
            this.panel1.Controls.Add(this.lblTrackingID);
            this.panel1.Controls.Add(this.txtCourierAmount);
            this.panel1.Controls.Add(this.txtTrackingID);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.cmbCourier);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtRemarks);
            this.panel1.Controls.Add(this.chkAdjustEntry);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.txtNaration);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.cmbBranch);
            this.panel1.Controls.Add(this.txtTotalQuantity);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.PnlBtn);
            this.panel1.Controls.Add(this.txtInvDiscPer);
            this.panel1.Controls.Add(this.txtPaid);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtRemainingAmt);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtInvDisc);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtTotalAmt);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.Grd);
            this.panel1.Controls.Add(this.cmbClaimType);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtPartyID);
            this.panel1.Controls.Add(this.btnSchVendor);
            this.panel1.Controls.Add(this.txtPartyDetail);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpDated);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1108, 644);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(395, 135);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(75, 20);
            this.txtInvoiceNo.TabIndex = 511;
            this.txtInvoiceNo.Visible = false;
            this.txtInvoiceNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInvoiceNo_KeyDown);
            // 
            // lblInvNo
            // 
            this.lblInvNo.AutoSize = true;
            this.lblInvNo.ForeColor = System.Drawing.Color.White;
            this.lblInvNo.Location = new System.Drawing.Point(327, 138);
            this.lblInvNo.Name = "lblInvNo";
            this.lblInvNo.Size = new System.Drawing.Size(62, 13);
            this.lblInvNo.TabIndex = 512;
            this.lblInvNo.Text = "Invoice No:";
            this.lblInvNo.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(13, 132);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 13);
            this.label15.TabIndex = 510;
            this.label15.Text = "Invoice Type:";
            // 
            // cmbInvoiceType
            // 
            this.cmbInvoiceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInvoiceType.FormattingEnabled = true;
            this.cmbInvoiceType.Location = new System.Drawing.Point(96, 129);
            this.cmbInvoiceType.Name = "cmbInvoiceType";
            this.cmbInvoiceType.Size = new System.Drawing.Size(208, 21);
            this.cmbInvoiceType.TabIndex = 509;
            this.cmbInvoiceType.TabStop = false;
            this.cmbInvoiceType.SelectedIndexChanged += new System.EventHandler(this.cmbInvoiceType_SelectedIndexChanged);
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.ForeColor = System.Drawing.Color.White;
            this.lblHeading.Location = new System.Drawing.Point(382, 20);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(91, 25);
            this.lblHeading.TabIndex = 508;
            this.lblHeading.Text = "Heading";
            // 
            // lblCourierAmt
            // 
            this.lblCourierAmt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCourierAmt.AutoSize = true;
            this.lblCourierAmt.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCourierAmt.Location = new System.Drawing.Point(16, 487);
            this.lblCourierAmt.Name = "lblCourierAmt";
            this.lblCourierAmt.Size = new System.Drawing.Size(82, 13);
            this.lblCourierAmt.TabIndex = 175;
            this.lblCourierAmt.Text = "Courier Amount:";
            // 
            // lblTrackingID
            // 
            this.lblTrackingID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTrackingID.AutoSize = true;
            this.lblTrackingID.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTrackingID.Location = new System.Drawing.Point(32, 461);
            this.lblTrackingID.Name = "lblTrackingID";
            this.lblTrackingID.Size = new System.Drawing.Size(66, 13);
            this.lblTrackingID.TabIndex = 174;
            this.lblTrackingID.Text = "Tracking ID:";
            // 
            // txtCourierAmount
            // 
            this.txtCourierAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCourierAmount.Location = new System.Drawing.Point(103, 485);
            this.txtCourierAmount.Name = "txtCourierAmount";
            this.txtCourierAmount.Size = new System.Drawing.Size(142, 20);
            this.txtCourierAmount.TabIndex = 173;
            // 
            // txtTrackingID
            // 
            this.txtTrackingID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTrackingID.Location = new System.Drawing.Point(103, 459);
            this.txtTrackingID.Name = "txtTrackingID";
            this.txtTrackingID.Size = new System.Drawing.Size(142, 20);
            this.txtTrackingID.TabIndex = 172;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(559, 237);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 13);
            this.label14.TabIndex = 171;
            this.label14.Text = "Courier Service : ";
            this.label14.Visible = false;
            // 
            // cmbCourier
            // 
            this.cmbCourier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourier.FormattingEnabled = true;
            this.cmbCourier.Location = new System.Drawing.Point(650, 233);
            this.cmbCourier.Name = "cmbCourier";
            this.cmbCourier.Size = new System.Drawing.Size(206, 21);
            this.cmbCourier.TabIndex = 170;
            this.cmbCourier.Visible = false;
            this.cmbCourier.SelectedValueChanged += new System.EventHandler(this.cmbCourier_SelectedValueChanged);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(43, 513);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 169;
            this.label13.Text = "Remarks :";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtRemarks.Location = new System.Drawing.Point(103, 511);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(410, 20);
            this.txtRemarks.TabIndex = 168;
            // 
            // chkAdjustEntry
            // 
            this.chkAdjustEntry.AutoSize = true;
            this.chkAdjustEntry.ForeColor = System.Drawing.Color.White;
            this.chkAdjustEntry.Location = new System.Drawing.Point(685, 135);
            this.chkAdjustEntry.Name = "chkAdjustEntry";
            this.chkAdjustEntry.Size = new System.Drawing.Size(105, 17);
            this.chkAdjustEntry.TabIndex = 151;
            this.chkAdjustEntry.Text = "Adjustment Entry";
            this.chkAdjustEntry.UseVisualStyleBackColor = true;
            this.chkAdjustEntry.Visible = false;
            this.chkAdjustEntry.CheckedChanged += new System.EventHandler(this.chkAdjustEntry_CheckedChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(126)))), ((int)(((byte)(50)))));
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(870, 363);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(66, 34);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtNaration
            // 
            this.txtNaration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNaration.Location = new System.Drawing.Point(567, 401);
            this.txtNaration.Name = "txtNaration";
            this.txtNaration.Size = new System.Drawing.Size(234, 20);
            this.txtNaration.TabIndex = 150;
            this.txtNaration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNaration.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(506, 404);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 149;
            this.label5.Text = "Narration:";
            this.label5.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(54, 79);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 13);
            this.label12.TabIndex = 148;
            this.label12.Text = "User:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(96, 77);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(208, 20);
            this.txtUserName.TabIndex = 147;
            this.txtUserName.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(431, 114);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 13);
            this.label11.TabIndex = 145;
            this.label11.Text = "Warehouse : ";
            this.label11.Visible = false;
            // 
            // cmbBranch
            // 
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.Enabled = false;
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(509, 109);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(208, 21);
            this.cmbBranch.TabIndex = 144;
            this.cmbBranch.Visible = false;
            this.cmbBranch.SelectedIndexChanged += new System.EventHandler(this.cmbBranch_SelectedIndexChanged);
            // 
            // txtTotalQuantity
            // 
            this.txtTotalQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalQuantity.Location = new System.Drawing.Point(949, 458);
            this.txtTotalQuantity.Name = "txtTotalQuantity";
            this.txtTotalQuantity.ReadOnly = true;
            this.txtTotalQuantity.Size = new System.Drawing.Size(140, 20);
            this.txtTotalQuantity.TabIndex = 143;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(856, 462);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 142;
            this.label10.Text = "Total Qunatity:";
            // 
            // PnlBtn
            // 
            this.PnlBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PnlBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.PnlBtn.Controls.Add(this.btnNew);
            this.PnlBtn.Controls.Add(this.btnEdit);
            this.PnlBtn.Controls.Add(this.btnSave);
            this.PnlBtn.Location = new System.Drawing.Point(423, 588);
            this.PnlBtn.Name = "PnlBtn";
            this.PnlBtn.Size = new System.Drawing.Size(272, 41);
            this.PnlBtn.TabIndex = 141;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnNew.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(33, 4);
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
            this.btnEdit.Location = new System.Drawing.Point(105, 4);
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
            this.btnSave.Location = new System.Drawing.Point(178, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 34);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtInvDiscPer
            // 
            this.txtInvDiscPer.Location = new System.Drawing.Point(630, 292);
            this.txtInvDiscPer.Name = "txtInvDiscPer";
            this.txtInvDiscPer.Size = new System.Drawing.Size(36, 20);
            this.txtInvDiscPer.TabIndex = 130;
            this.txtInvDiscPer.Visible = false;
            this.txtInvDiscPer.Leave += new System.EventHandler(this.txtInvDiscPer_Leave);
            // 
            // txtPaid
            // 
            this.txtPaid.Location = new System.Drawing.Point(650, 358);
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.Size = new System.Drawing.Size(140, 20);
            this.txtPaid.TabIndex = 129;
            this.txtPaid.Visible = false;
            this.txtPaid.TextChanged += new System.EventHandler(this.txtPaid_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(554, 362);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 128;
            this.label9.Text = "Paid";
            this.label9.Visible = false;
            // 
            // txtRemainingAmt
            // 
            this.txtRemainingAmt.Location = new System.Drawing.Point(650, 332);
            this.txtRemainingAmt.Name = "txtRemainingAmt";
            this.txtRemainingAmt.Size = new System.Drawing.Size(140, 20);
            this.txtRemainingAmt.TabIndex = 127;
            this.txtRemainingAmt.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(554, 336);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 126;
            this.label8.Text = "Remaining Amount";
            this.label8.Visible = false;
            // 
            // txtInvDisc
            // 
            this.txtInvDisc.Location = new System.Drawing.Point(690, 291);
            this.txtInvDisc.Name = "txtInvDisc";
            this.txtInvDisc.Size = new System.Drawing.Size(80, 20);
            this.txtInvDisc.TabIndex = 125;
            this.txtInvDisc.Visible = false;
            this.txtInvDisc.TextChanged += new System.EventHandler(this.txtInvDisc_TextChanged);
            this.txtInvDisc.Leave += new System.EventHandler(this.txtInvDisc_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(534, 295);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 124;
            this.label7.Text = "Invoice Discount";
            this.label7.Visible = false;
            // 
            // txtTotalAmt
            // 
            this.txtTotalAmt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalAmt.Location = new System.Drawing.Point(949, 488);
            this.txtTotalAmt.Name = "txtTotalAmt";
            this.txtTotalAmt.ReadOnly = true;
            this.txtTotalAmt.Size = new System.Drawing.Size(140, 20);
            this.txtTotalAmt.TabIndex = 123;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(856, 492);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 122;
            this.label6.Text = "Total Amount:";
            // 
            // Grd
            // 
            this.Grd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grd.DefaultCellStyle = dataGridViewCellStyle2;
            this.Grd.Location = new System.Drawing.Point(20, 163);
            this.Grd.MoveLeftToRight = true;
            this.Grd.Name = "Grd";
            this.Grd.Size = new System.Drawing.Size(1069, 289);
            this.Grd.StandardTab = true;
            this.Grd.TabIndex = 121;
            this.Grd.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grd_CellEndEdit);
            this.Grd.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.Grd_RowsAdded);
            this.Grd.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.Grd_RowsRemoved);
            this.Grd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grd_KeyDown);
            // 
            // cmbClaimType
            // 
            this.cmbClaimType.FormattingEnabled = true;
            this.cmbClaimType.Location = new System.Drawing.Point(404, 362);
            this.cmbClaimType.Name = "cmbClaimType";
            this.cmbClaimType.Size = new System.Drawing.Size(121, 21);
            this.cmbClaimType.TabIndex = 118;
            this.cmbClaimType.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(322, 365);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 117;
            this.label4.Text = "Claimnm Type";
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(842, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 116;
            this.label3.Text = "Party:";
            // 
            // txtPartyID
            // 
            this.txtPartyID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPartyID.Location = new System.Drawing.Point(881, 86);
            this.txtPartyID.Name = "txtPartyID";
            this.txtPartyID.Size = new System.Drawing.Size(176, 20);
            this.txtPartyID.TabIndex = 113;
            this.txtPartyID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSchVendor
            // 
            this.btnSchVendor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSchVendor.Image = ((System.Drawing.Image)(resources.GetObject("btnSchVendor.Image")));
            this.btnSchVendor.Location = new System.Drawing.Point(1058, 84);
            this.btnSchVendor.Name = "btnSchVendor";
            this.btnSchVendor.Size = new System.Drawing.Size(29, 23);
            this.btnSchVendor.TabIndex = 115;
            this.btnSchVendor.TabStop = false;
            this.btnSchVendor.UseVisualStyleBackColor = true;
            this.btnSchVendor.Click += new System.EventHandler(this.btnSchVendor_Click);
            // 
            // txtPartyDetail
            // 
            this.txtPartyDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPartyDetail.Location = new System.Drawing.Point(881, 112);
            this.txtPartyDetail.Multiline = true;
            this.txtPartyDetail.Name = "txtPartyDetail";
            this.txtPartyDetail.ReadOnly = true;
            this.txtPartyDetail.Size = new System.Drawing.Size(206, 43);
            this.txtPartyDetail.TabIndex = 114;
            this.txtPartyDetail.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(827, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Tag = "";
            this.label2.Text = "Date:";
            // 
            // dtpDated
            // 
            this.dtpDated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDated.Location = new System.Drawing.Point(870, 45);
            this.dtpDated.Name = "dtpDated";
            this.dtpDated.Size = new System.Drawing.Size(206, 20);
            this.dtpDated.TabIndex = 2;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(96, 103);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(208, 20);
            this.txtID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(65, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // frmClaimInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 644);
            this.Controls.Add(this.panel1);
            this.Name = "frmClaimInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "12";
            this.Text = "Purchase Return";
            this.Load += new System.EventHandler(this.frmClaimInvoice_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PnlBtn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDated;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbClaimType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPartyID;
        private System.Windows.Forms.Button btnSchVendor;
        private System.Windows.Forms.TextBox txtPartyDetail;
        private System.Windows.Forms.TextBox txtPaid;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRemainingAmt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtInvDisc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotalAmt;
        private System.Windows.Forms.Label label6;
        private DGV.DGV Grd;
        private System.Windows.Forms.TextBox txtInvDiscPer;
        private System.Windows.Forms.Panel PnlBtn;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtTotalQuantity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNaration;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkAdjustEntry;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbCourier;
        private System.Windows.Forms.Label lblCourierAmt;
        private System.Windows.Forms.Label lblTrackingID;
        private System.Windows.Forms.TextBox txtTrackingID;
        private System.Windows.Forms.TextBox txtCourierAmount;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.ComboBox cmbInvoiceType;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label lblInvNo;
    }
}
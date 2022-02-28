namespace Restorant_Management_System.Report_Forms
{
    partial class frmRegisterInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegisterInvoice));
            this.PnlMain = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBranch = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.gbPartyDetails = new System.Windows.Forms.GroupBox();
            this.btnAllParties = new System.Windows.Forms.Button();
            this.txtPartName = new System.Windows.Forms.TextBox();
            this.txtPartyID = new System.Windows.Forms.TextBox();
            this.btnSch = new System.Windows.Forms.Button();
            this.grpProductDetail = new System.Windows.Forms.GroupBox();
            this.cmbCompanyName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbProductName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtItemID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbADay = new System.Windows.Forms.GroupBox();
            this.dtpADay = new System.Windows.Forms.DateTimePicker();
            this.gbDateRange = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.rdbToday = new System.Windows.Forms.RadioButton();
            this.rdbAllDates = new System.Windows.Forms.RadioButton();
            this.rdbADay = new System.Windows.Forms.RadioButton();
            this.rdbDateRange = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.PnlMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbPartyDetails.SuspendLayout();
            this.grpProductDetail.SuspendLayout();
            this.gbADay.SuspendLayout();
            this.gbDateRange.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.BackColor = System.Drawing.Color.SteelBlue;
            this.PnlMain.Controls.Add(this.panel1);
            this.PnlMain.Controls.Add(this.panel2);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(1097, 514);
            this.PnlMain.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblBranch);
            this.panel1.Controls.Add(this.cmbBranch);
            this.panel1.Controls.Add(this.gbPartyDetails);
            this.panel1.Controls.Add(this.grpProductDetail);
            this.panel1.Controls.Add(this.gbADay);
            this.panel1.Controls.Add(this.gbDateRange);
            this.panel1.Controls.Add(this.rdbToday);
            this.panel1.Controls.Add(this.rdbAllDates);
            this.panel1.Controls.Add(this.rdbADay);
            this.panel1.Controls.Add(this.rdbDateRange);
            this.panel1.Location = new System.Drawing.Point(72, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(940, 403);
            this.panel1.TabIndex = 30;
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.ForeColor = System.Drawing.Color.White;
            this.lblBranch.Location = new System.Drawing.Point(55, 249);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(50, 13);
            this.lblBranch.TabIndex = 156;
            this.lblBranch.Text = "Branch : ";
            this.lblBranch.Visible = false;
            // 
            // cmbBranch
            // 
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.Enabled = false;
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(108, 245);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(267, 21);
            this.cmbBranch.TabIndex = 155;
            this.cmbBranch.Visible = false;
            // 
            // gbPartyDetails
            // 
            this.gbPartyDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPartyDetails.Controls.Add(this.btnAllParties);
            this.gbPartyDetails.Controls.Add(this.txtPartName);
            this.gbPartyDetails.Controls.Add(this.txtPartyID);
            this.gbPartyDetails.Controls.Add(this.btnSch);
            this.gbPartyDetails.ForeColor = System.Drawing.Color.White;
            this.gbPartyDetails.Location = new System.Drawing.Point(43, 289);
            this.gbPartyDetails.Name = "gbPartyDetails";
            this.gbPartyDetails.Size = new System.Drawing.Size(821, 53);
            this.gbPartyDetails.TabIndex = 29;
            this.gbPartyDetails.TabStop = false;
            this.gbPartyDetails.Text = "Party Detail";
            // 
            // btnAllParties
            // 
            this.btnAllParties.Location = new System.Drawing.Point(707, 19);
            this.btnAllParties.Name = "btnAllParties";
            this.btnAllParties.Size = new System.Drawing.Size(99, 23);
            this.btnAllParties.TabIndex = 18;
            this.btnAllParties.Text = "All Parties";
            this.btnAllParties.UseVisualStyleBackColor = true;
            this.btnAllParties.Click += new System.EventHandler(this.btnAllParties_Click);
            // 
            // txtPartName
            // 
            this.txtPartName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPartName.Location = new System.Drawing.Point(216, 21);
            this.txtPartName.Name = "txtPartName";
            this.txtPartName.Size = new System.Drawing.Size(485, 20);
            this.txtPartName.TabIndex = 17;
            // 
            // txtPartyID
            // 
            this.txtPartyID.Location = new System.Drawing.Point(39, 22);
            this.txtPartyID.Name = "txtPartyID";
            this.txtPartyID.Size = new System.Drawing.Size(132, 20);
            this.txtPartyID.TabIndex = 16;
            this.txtPartyID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyID_KeyDown);
            this.txtPartyID.Validating += new System.ComponentModel.CancelEventHandler(this.txtPartyID_Validating);
            // 
            // btnSch
            // 
            this.btnSch.Image = ((System.Drawing.Image)(resources.GetObject("btnSch.Image")));
            this.btnSch.Location = new System.Drawing.Point(177, 19);
            this.btnSch.Name = "btnSch";
            this.btnSch.Size = new System.Drawing.Size(33, 23);
            this.btnSch.TabIndex = 9;
            this.btnSch.TabStop = false;
            this.btnSch.UseVisualStyleBackColor = true;
            this.btnSch.Click += new System.EventHandler(this.btnSch_Click);
            // 
            // grpProductDetail
            // 
            this.grpProductDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpProductDetail.Controls.Add(this.cmbCompanyName);
            this.grpProductDetail.Controls.Add(this.label3);
            this.grpProductDetail.Controls.Add(this.cmbProductName);
            this.grpProductDetail.Controls.Add(this.label2);
            this.grpProductDetail.Controls.Add(this.txtItemID);
            this.grpProductDetail.Controls.Add(this.label6);
            this.grpProductDetail.Controls.Add(this.cmbCategory);
            this.grpProductDetail.Controls.Add(this.label1);
            this.grpProductDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpProductDetail.ForeColor = System.Drawing.Color.White;
            this.grpProductDetail.Location = new System.Drawing.Point(542, 32);
            this.grpProductDetail.Name = "grpProductDetail";
            this.grpProductDetail.Size = new System.Drawing.Size(362, 193);
            this.grpProductDetail.TabIndex = 2;
            this.grpProductDetail.TabStop = false;
            this.grpProductDetail.Text = "Product Detail";
            this.grpProductDetail.Visible = false;
            // 
            // cmbCompanyName
            // 
            this.cmbCompanyName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompanyName.FormattingEnabled = true;
            this.cmbCompanyName.Location = new System.Drawing.Point(104, 140);
            this.cmbCompanyName.Name = "cmbCompanyName";
            this.cmbCompanyName.Size = new System.Drawing.Size(239, 21);
            this.cmbCompanyName.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Company Name:";
            // 
            // cmbProductName
            // 
            this.cmbProductName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductName.FormattingEnabled = true;
            this.cmbProductName.Location = new System.Drawing.Point(104, 111);
            this.cmbProductName.Name = "cmbProductName";
            this.cmbProductName.Size = new System.Drawing.Size(239, 21);
            this.cmbProductName.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "ProdcutName:";
            // 
            // txtItemID
            // 
            this.txtItemID.Location = new System.Drawing.Point(104, 56);
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.Size = new System.Drawing.Size(132, 20);
            this.txtItemID.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Item ID:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(104, 83);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(239, 21);
            this.cmbCategory.TabIndex = 0;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            this.cmbCategory.SelectedValueChanged += new System.EventHandler(this.cmbCategory_SelectedValueChanged);
            this.cmbCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCategory_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Category:";
            // 
            // gbADay
            // 
            this.gbADay.Controls.Add(this.dtpADay);
            this.gbADay.ForeColor = System.Drawing.Color.White;
            this.gbADay.Location = new System.Drawing.Point(146, 142);
            this.gbADay.Name = "gbADay";
            this.gbADay.Size = new System.Drawing.Size(167, 54);
            this.gbADay.TabIndex = 28;
            this.gbADay.TabStop = false;
            this.gbADay.Text = "A Day";
            // 
            // dtpADay
            // 
            this.dtpADay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpADay.Location = new System.Drawing.Point(47, 23);
            this.dtpADay.Name = "dtpADay";
            this.dtpADay.Size = new System.Drawing.Size(101, 20);
            this.dtpADay.TabIndex = 10;
            // 
            // gbDateRange
            // 
            this.gbDateRange.Controls.Add(this.label8);
            this.gbDateRange.Controls.Add(this.dtpTo);
            this.gbDateRange.Controls.Add(this.label9);
            this.gbDateRange.Controls.Add(this.dtpFrom);
            this.gbDateRange.ForeColor = System.Drawing.Color.White;
            this.gbDateRange.Location = new System.Drawing.Point(146, 84);
            this.gbDateRange.Name = "gbDateRange";
            this.gbDateRange.Size = new System.Drawing.Size(244, 70);
            this.gbDateRange.TabIndex = 27;
            this.gbDateRange.TabStop = false;
            this.gbDateRange.Text = "Date Range";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(128, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "To";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(127, 42);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(101, 20);
            this.dtpTo.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "From";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(20, 42);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(101, 20);
            this.dtpFrom.TabIndex = 10;
            // 
            // rdbToday
            // 
            this.rdbToday.AutoSize = true;
            this.rdbToday.ForeColor = System.Drawing.Color.White;
            this.rdbToday.Location = new System.Drawing.Point(57, 193);
            this.rdbToday.Name = "rdbToday";
            this.rdbToday.Size = new System.Drawing.Size(55, 17);
            this.rdbToday.TabIndex = 26;
            this.rdbToday.TabStop = true;
            this.rdbToday.Text = "Today";
            this.rdbToday.UseVisualStyleBackColor = true;
            this.rdbToday.CheckedChanged += new System.EventHandler(this.rdbToday_CheckedChanged);
            // 
            // rdbAllDates
            // 
            this.rdbAllDates.AutoSize = true;
            this.rdbAllDates.ForeColor = System.Drawing.Color.White;
            this.rdbAllDates.Location = new System.Drawing.Point(57, 32);
            this.rdbAllDates.Name = "rdbAllDates";
            this.rdbAllDates.Size = new System.Drawing.Size(67, 17);
            this.rdbAllDates.TabIndex = 23;
            this.rdbAllDates.TabStop = true;
            this.rdbAllDates.Text = "All Dates";
            this.rdbAllDates.UseVisualStyleBackColor = true;
            this.rdbAllDates.CheckedChanged += new System.EventHandler(this.rdbAllDates_CheckedChanged);
            // 
            // rdbADay
            // 
            this.rdbADay.AutoSize = true;
            this.rdbADay.ForeColor = System.Drawing.Color.White;
            this.rdbADay.Location = new System.Drawing.Point(57, 142);
            this.rdbADay.Name = "rdbADay";
            this.rdbADay.Size = new System.Drawing.Size(54, 17);
            this.rdbADay.TabIndex = 25;
            this.rdbADay.TabStop = true;
            this.rdbADay.Text = "A Day";
            this.rdbADay.UseVisualStyleBackColor = true;
            this.rdbADay.CheckedChanged += new System.EventHandler(this.rdbADay_CheckedChanged);
            // 
            // rdbDateRange
            // 
            this.rdbDateRange.AutoSize = true;
            this.rdbDateRange.ForeColor = System.Drawing.Color.White;
            this.rdbDateRange.Location = new System.Drawing.Point(57, 84);
            this.rdbDateRange.Name = "rdbDateRange";
            this.rdbDateRange.Size = new System.Drawing.Size(83, 17);
            this.rdbDateRange.TabIndex = 24;
            this.rdbDateRange.TabStop = true;
            this.rdbDateRange.Text = "Date Range";
            this.rdbDateRange.UseVisualStyleBackColor = true;
            this.rdbDateRange.CheckedChanged += new System.EventHandler(this.rdbDateRange_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.btnPreview);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Location = new System.Drawing.Point(420, 442);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(225, 48);
            this.panel2.TabIndex = 22;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnNew.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(13, 6);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(68, 33);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnPreview.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.ForeColor = System.Drawing.Color.White;
            this.btnPreview.Location = new System.Drawing.Point(79, 6);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(68, 33);
            this.btnPreview.TabIndex = 3;
            this.btnPreview.Text = "&Preview";
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(145, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 33);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Print";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmRegisterInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(221)))), ((int)(((byte)(190)))));
            this.ClientSize = new System.Drawing.Size(1097, 514);
            this.Controls.Add(this.PnlMain);
            this.Name = "frmRegisterInvoice";
            this.Text = "Register Invoice";
            this.Load += new System.EventHandler(this.frmRegisterInvoice_Load);
            this.PnlMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbPartyDetails.ResumeLayout(false);
            this.gbPartyDetails.PerformLayout();
            this.grpProductDetail.ResumeLayout(false);
            this.grpProductDetail.PerformLayout();
            this.gbADay.ResumeLayout(false);
            this.gbDateRange.ResumeLayout(false);
            this.gbDateRange.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.GroupBox grpProductDetail;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtItemID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gbPartyDetails;
        private System.Windows.Forms.GroupBox gbADay;
        private System.Windows.Forms.DateTimePicker dtpADay;
        private System.Windows.Forms.GroupBox gbDateRange;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.RadioButton rdbToday;
        private System.Windows.Forms.RadioButton rdbADay;
        private System.Windows.Forms.RadioButton rdbDateRange;
        private System.Windows.Forms.RadioButton rdbAllDates;
        private System.Windows.Forms.Button btnSch;
        private System.Windows.Forms.Button btnAllParties;
        private System.Windows.Forms.TextBox txtPartName;
        private System.Windows.Forms.TextBox txtPartyID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.ComboBox cmbProductName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCompanyName;
        private System.Windows.Forms.Label label3;
    }
}
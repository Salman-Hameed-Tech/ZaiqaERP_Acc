namespace Restorant_Management_System
{
    partial class FrmAccountLedger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAccountLedger));
            this.FrmCurrentStock_Fill_Panel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.chkIsPosted = new System.Windows.Forms.CheckBox();
            this.cbxBookCategories = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbADay = new System.Windows.Forms.GroupBox();
            this.dtpADay = new System.Windows.Forms.DateTimePicker();
            this.gbDateRange = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.grpParty = new System.Windows.Forms.GroupBox();
            this.btnAllParties = new System.Windows.Forms.Button();
            this.btnSch = new System.Windows.Forms.Button();
            this.txtPartName = new System.Windows.Forms.TextBox();
            this.txtPartyID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.rdbToday = new System.Windows.Forms.RadioButton();
            this.rdbADay = new System.Windows.Forms.RadioButton();
            this.rdbDateRange = new System.Windows.Forms.RadioButton();
            this.rdbAllDates = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.FrmCurrentStock_Fill_Panel.SuspendLayout();
            this.gbADay.SuspendLayout();
            this.gbDateRange.SuspendLayout();
            this.grpParty.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FrmCurrentStock_Fill_Panel
            // 
            this.FrmCurrentStock_Fill_Panel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FrmCurrentStock_Fill_Panel.BackColor = System.Drawing.Color.SteelBlue;
            this.FrmCurrentStock_Fill_Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.label7);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.cmbBranch);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.lblName);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.btnPreview);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.BtnClose);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.btnPrint);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.btnNew);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.chkIsPosted);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.cbxBookCategories);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.label2);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.gbADay);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.gbDateRange);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.grpParty);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.rdbToday);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.rdbADay);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.rdbDateRange);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.rdbAllDates);
            this.FrmCurrentStock_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.FrmCurrentStock_Fill_Panel.Location = new System.Drawing.Point(81, 12);
            this.FrmCurrentStock_Fill_Panel.Name = "FrmCurrentStock_Fill_Panel";
            this.FrmCurrentStock_Fill_Panel.Size = new System.Drawing.Size(556, 461);
            this.FrmCurrentStock_Fill_Panel.TabIndex = 0;
            this.FrmCurrentStock_Fill_Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmCurrentStock_Fill_Panel_Paint);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(21, 263);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 513;
            this.label7.Text = "Branch : ";
            this.label7.Visible = false;
            // 
            // cmbBranch
            // 
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.Enabled = false;
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(79, 260);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(322, 21);
            this.cmbBranch.TabIndex = 512;
            this.cmbBranch.Visible = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(215, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(63, 24);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "Name";
            this.lblName.Visible = false;
            // 
            // btnPreview
            // 
            this.btnPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Location = new System.Drawing.Point(300, 396);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(69, 31);
            this.btnPreview.TabIndex = 511;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClose.Location = new System.Drawing.Point(142, 396);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(69, 31);
            this.BtnClose.TabIndex = 510;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(378, 396);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(69, 31);
            this.btnPrint.TabIndex = 509;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(221, 396);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(69, 31);
            this.btnNew.TabIndex = 508;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // chkIsPosted
            // 
            this.chkIsPosted.AutoSize = true;
            this.chkIsPosted.ForeColor = System.Drawing.Color.White;
            this.chkIsPosted.Location = new System.Drawing.Point(20, 206);
            this.chkIsPosted.Name = "chkIsPosted";
            this.chkIsPosted.Size = new System.Drawing.Size(95, 17);
            this.chkIsPosted.TabIndex = 20;
            this.chkIsPosted.Text = "Posted Ledger";
            this.chkIsPosted.UseVisualStyleBackColor = true;
            // 
            // cbxBookCategories
            // 
            this.cbxBookCategories.ForeColor = System.Drawing.Color.Black;
            this.cbxBookCategories.FormattingEnabled = true;
            this.cbxBookCategories.Location = new System.Drawing.Point(407, 102);
            this.cbxBookCategories.Name = "cbxBookCategories";
            this.cbxBookCategories.Size = new System.Drawing.Size(121, 21);
            this.cbxBookCategories.TabIndex = 16;
            this.cbxBookCategories.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(317, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Book\'s Category";
            this.label2.Visible = false;
            // 
            // gbADay
            // 
            this.gbADay.Controls.Add(this.dtpADay);
            this.gbADay.ForeColor = System.Drawing.Color.White;
            this.gbADay.Location = new System.Drawing.Point(105, 136);
            this.gbADay.Name = "gbADay";
            this.gbADay.Size = new System.Drawing.Size(102, 45);
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
            this.dtpADay.Size = new System.Drawing.Size(88, 20);
            this.dtpADay.TabIndex = 0;
            this.dtpADay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxCategory_KeyDown);
            // 
            // gbDateRange
            // 
            this.gbDateRange.Controls.Add(this.label11);
            this.gbDateRange.Controls.Add(this.label10);
            this.gbDateRange.Controls.Add(this.dtpTo);
            this.gbDateRange.Controls.Add(this.dtpFrom);
            this.gbDateRange.ForeColor = System.Drawing.Color.White;
            this.gbDateRange.Location = new System.Drawing.Point(100, 98);
            this.gbDateRange.Name = "gbDateRange";
            this.gbDateRange.Size = new System.Drawing.Size(201, 61);
            this.gbDateRange.TabIndex = 3;
            this.gbDateRange.TabStop = false;
            this.gbDateRange.Text = "Date Range";
            this.gbDateRange.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(100, 19);
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
            this.dtpTo.Location = new System.Drawing.Point(100, 35);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(88, 20);
            this.dtpTo.TabIndex = 1;
            this.dtpTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxCategory_KeyDown);
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(6, 35);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(88, 20);
            this.dtpFrom.TabIndex = 0;
            this.dtpFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxCategory_KeyDown);
            // 
            // grpParty
            // 
            this.grpParty.Controls.Add(this.btnAllParties);
            this.grpParty.Controls.Add(this.btnSch);
            this.grpParty.Controls.Add(this.txtPartName);
            this.grpParty.Controls.Add(this.txtPartyID);
            this.grpParty.Controls.Add(this.label8);
            this.grpParty.Controls.Add(this.label9);
            this.grpParty.ForeColor = System.Drawing.Color.White;
            this.grpParty.Location = new System.Drawing.Point(19, 310);
            this.grpParty.Name = "grpParty";
            this.grpParty.Size = new System.Drawing.Size(448, 58);
            this.grpParty.TabIndex = 7;
            this.grpParty.TabStop = false;
            this.grpParty.Text = "Party Detail";
            // 
            // btnAllParties
            // 
            this.btnAllParties.Location = new System.Drawing.Point(431, 25);
            this.btnAllParties.Name = "btnAllParties";
            this.btnAllParties.Size = new System.Drawing.Size(67, 23);
            this.btnAllParties.TabIndex = 3;
            this.btnAllParties.TabStop = false;
            this.btnAllParties.Text = "All Parties";
            this.btnAllParties.UseVisualStyleBackColor = true;
            this.btnAllParties.Visible = false;
            this.btnAllParties.Click += new System.EventHandler(this.btnAllParties_Click);
            // 
            // btnSch
            // 
            this.btnSch.Image = ((System.Drawing.Image)(resources.GetObject("btnSch.Image")));
            this.btnSch.Location = new System.Drawing.Point(117, 25);
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
            this.txtPartName.Location = new System.Drawing.Point(152, 26);
            this.txtPartName.Name = "txtPartName";
            this.txtPartName.ReadOnly = true;
            this.txtPartName.Size = new System.Drawing.Size(277, 20);
            this.txtPartName.TabIndex = 2;
            this.txtPartName.TabStop = false;
            // 
            // txtPartyID
            // 
            this.txtPartyID.Location = new System.Drawing.Point(30, 26);
            this.txtPartyID.Name = "txtPartyID";
            this.txtPartyID.Size = new System.Drawing.Size(87, 20);
            this.txtPartyID.TabIndex = 0;
            this.txtPartyID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyID_KeyDown);
            this.txtPartyID.Validating += new System.ComponentModel.CancelEventHandler(this.txtPartyID_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(149, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Account Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Account No";
            // 
            // rdbToday
            // 
            this.rdbToday.AutoSize = true;
            this.rdbToday.ForeColor = System.Drawing.Color.White;
            this.rdbToday.Location = new System.Drawing.Point(20, 176);
            this.rdbToday.Name = "rdbToday";
            this.rdbToday.Size = new System.Drawing.Size(55, 17);
            this.rdbToday.TabIndex = 6;
            this.rdbToday.TabStop = true;
            this.rdbToday.Text = "Today";
            this.rdbToday.UseVisualStyleBackColor = true;
            this.rdbToday.CheckedChanged += new System.EventHandler(this.rdbToday_CheckedChanged);
            this.rdbToday.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxCategory_KeyDown);
            // 
            // rdbADay
            // 
            this.rdbADay.AutoSize = true;
            this.rdbADay.ForeColor = System.Drawing.Color.White;
            this.rdbADay.Location = new System.Drawing.Point(20, 136);
            this.rdbADay.Name = "rdbADay";
            this.rdbADay.Size = new System.Drawing.Size(54, 17);
            this.rdbADay.TabIndex = 4;
            this.rdbADay.TabStop = true;
            this.rdbADay.Text = "A Day";
            this.rdbADay.UseVisualStyleBackColor = true;
            this.rdbADay.CheckedChanged += new System.EventHandler(this.rdbADay_CheckedChanged);
            this.rdbADay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxCategory_KeyDown);
            // 
            // rdbDateRange
            // 
            this.rdbDateRange.AutoSize = true;
            this.rdbDateRange.ForeColor = System.Drawing.Color.White;
            this.rdbDateRange.Location = new System.Drawing.Point(18, 96);
            this.rdbDateRange.Name = "rdbDateRange";
            this.rdbDateRange.Size = new System.Drawing.Size(83, 17);
            this.rdbDateRange.TabIndex = 2;
            this.rdbDateRange.TabStop = true;
            this.rdbDateRange.Text = "Date Range";
            this.rdbDateRange.UseVisualStyleBackColor = true;
            this.rdbDateRange.CheckedChanged += new System.EventHandler(this.rdbDateRange_CheckedChanged);
            this.rdbDateRange.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxCategory_KeyDown);
            // 
            // rdbAllDates
            // 
            this.rdbAllDates.AutoSize = true;
            this.rdbAllDates.ForeColor = System.Drawing.Color.White;
            this.rdbAllDates.Location = new System.Drawing.Point(19, 59);
            this.rdbAllDates.Name = "rdbAllDates";
            this.rdbAllDates.Size = new System.Drawing.Size(67, 17);
            this.rdbAllDates.TabIndex = 1;
            this.rdbAllDates.TabStop = true;
            this.rdbAllDates.Text = "All Dates";
            this.rdbAllDates.UseVisualStyleBackColor = true;
            this.rdbAllDates.CheckedChanged += new System.EventHandler(this.rdbAllDates_CheckedChanged);
            this.rdbAllDates.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxCategory_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.FrmCurrentStock_Fill_Panel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(714, 485);
            this.panel1.TabIndex = 1;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(396, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // FrmAccountLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(221)))), ((int)(((byte)(190)))));
            this.ClientSize = new System.Drawing.Size(714, 485);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmAccountLedger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Ledger Report...";
            this.Load += new System.EventHandler(this.FrmCurrentStock_Load);
            this.FrmCurrentStock_Fill_Panel.ResumeLayout(false);
            this.FrmCurrentStock_Fill_Panel.PerformLayout();
            this.gbADay.ResumeLayout(false);
            this.gbDateRange.ResumeLayout(false);
            this.gbDateRange.PerformLayout();
            this.grpParty.ResumeLayout(false);
            this.grpParty.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.Panel FrmCurrentStock_Fill_Panel;

        private System.Windows.Forms.RadioButton rdbToday;
        private System.Windows.Forms.RadioButton rdbADay;
        private System.Windows.Forms.RadioButton rdbDateRange;
        private System.Windows.Forms.RadioButton rdbAllDates;
        private System.Windows.Forms.GroupBox grpParty;
        private System.Windows.Forms.Button btnSch;
        private System.Windows.Forms.TextBox txtPartName;
        private System.Windows.Forms.TextBox txtPartyID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnAllParties;
        private System.Windows.Forms.GroupBox gbDateRange;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpADay;
        private System.Windows.Forms.GroupBox gbADay;
        private System.Windows.Forms.ComboBox cbxBookCategories;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkIsPosted;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnNew;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbBranch;
    }
}
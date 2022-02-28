namespace Restorant_Management_System.Forms
{
    partial class frmSummary
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotalPaid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalDisc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalAmt = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.Grd = new System.Windows.Forms.DataGridView();
            this.CrVoucher = new System.Windows.Forms.CheckBox();
            this.DrVoucher = new System.Windows.Forms.CheckBox();
            this.chkSaleInvoice = new System.Windows.Forms.CheckBox();
            this.cmbSummaryNo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.label42 = new System.Windows.Forms.Label();
            this.cmbUsers = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(80)))), ((int)(((byte)(137)))));
            this.panel1.Controls.Add(this.dtpDate);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cmbBranch);
            this.panel1.Controls.Add(this.label42);
            this.panel1.Controls.Add(this.cmbUsers);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtTotalPaid);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtTotalDisc);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTotalAmt);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.Grd);
            this.panel1.Controls.Add(this.CrVoucher);
            this.panel1.Controls.Add(this.DrVoucher);
            this.panel1.Controls.Add(this.chkSaleInvoice);
            this.panel1.Controls.Add(this.cmbSummaryNo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(743, 622);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(499, 509);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Total Paid:";
            // 
            // txtTotalPaid
            // 
            this.txtTotalPaid.Location = new System.Drawing.Point(563, 505);
            this.txtTotalPaid.Name = "txtTotalPaid";
            this.txtTotalPaid.ReadOnly = true;
            this.txtTotalPaid.Size = new System.Drawing.Size(168, 20);
            this.txtTotalPaid.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(478, 483);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Total Discount:";
            // 
            // txtTotalDisc
            // 
            this.txtTotalDisc.Location = new System.Drawing.Point(563, 479);
            this.txtTotalDisc.Name = "txtTotalDisc";
            this.txtTotalDisc.ReadOnly = true;
            this.txtTotalDisc.Size = new System.Drawing.Size(168, 20);
            this.txtTotalDisc.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(484, 456);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Total Amount:";
            // 
            // txtTotalAmt
            // 
            this.txtTotalAmt.Location = new System.Drawing.Point(563, 453);
            this.txtTotalAmt.Name = "txtTotalAmt";
            this.txtTotalAmt.ReadOnly = true;
            this.txtTotalAmt.Size = new System.Drawing.Size(168, 20);
            this.txtTotalAmt.TabIndex = 11;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(46, 568);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 34);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClear.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(129, 568);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(87, 34);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPrint.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(432, 353);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(125, 34);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "Finalize Summary";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // Grd
            // 
            this.Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grd.Location = new System.Drawing.Point(12, 134);
            this.Grd.Name = "Grd";
            this.Grd.ReadOnly = true;
            this.Grd.Size = new System.Drawing.Size(719, 313);
            this.Grd.TabIndex = 6;
            this.Grd.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.Grd_RowPostPaint);
            this.Grd.DoubleClick += new System.EventHandler(this.Grd_DoubleClick);
            // 
            // CrVoucher
            // 
            this.CrVoucher.AutoSize = true;
            this.CrVoucher.ForeColor = System.Drawing.Color.White;
            this.CrVoucher.Location = new System.Drawing.Point(630, 111);
            this.CrVoucher.Name = "CrVoucher";
            this.CrVoucher.Size = new System.Drawing.Size(96, 17);
            this.CrVoucher.TabIndex = 4;
            this.CrVoucher.Text = "Credit Voucher";
            this.CrVoucher.UseVisualStyleBackColor = true;
            this.CrVoucher.CheckedChanged += new System.EventHandler(this.CrVoucher_CheckedChanged);
            // 
            // DrVoucher
            // 
            this.DrVoucher.AutoSize = true;
            this.DrVoucher.ForeColor = System.Drawing.Color.White;
            this.DrVoucher.Location = new System.Drawing.Point(630, 87);
            this.DrVoucher.Name = "DrVoucher";
            this.DrVoucher.Size = new System.Drawing.Size(94, 17);
            this.DrVoucher.TabIndex = 3;
            this.DrVoucher.Text = "Debit Voucher";
            this.DrVoucher.UseVisualStyleBackColor = true;
            this.DrVoucher.CheckedChanged += new System.EventHandler(this.DrVoucher_CheckedChanged);
            // 
            // chkSaleInvoice
            // 
            this.chkSaleInvoice.AutoSize = true;
            this.chkSaleInvoice.ForeColor = System.Drawing.Color.White;
            this.chkSaleInvoice.Location = new System.Drawing.Point(630, 62);
            this.chkSaleInvoice.Name = "chkSaleInvoice";
            this.chkSaleInvoice.Size = new System.Drawing.Size(85, 17);
            this.chkSaleInvoice.TabIndex = 2;
            this.chkSaleInvoice.Text = "Sale Invoice";
            this.chkSaleInvoice.UseVisualStyleBackColor = true;
            this.chkSaleInvoice.CheckedChanged += new System.EventHandler(this.SaleInvoice_CheckedChanged);
            // 
            // cmbSummaryNo
            // 
            this.cmbSummaryNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSummaryNo.FormattingEnabled = true;
            this.cmbSummaryNo.Location = new System.Drawing.Point(46, 102);
            this.cmbSummaryNo.Name = "cmbSummaryNo";
            this.cmbSummaryNo.Size = new System.Drawing.Size(210, 21);
            this.cmbSummaryNo.TabIndex = 1;
            this.cmbSummaryNo.SelectedIndexChanged += new System.EventHandler(this.cmbUser_SelectedIndexChanged);
            this.cmbSummaryNo.SelectedValueChanged += new System.EventHandler(this.cmbUser_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(43, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Summary No";
            // 
            // cmbBranch
            // 
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(332, 23);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(209, 21);
            this.cmbBranch.TabIndex = 91;
            this.cmbBranch.SelectedIndexChanged += new System.EventHandler(this.cmbBranch_SelectedIndexChanged);
            this.cmbBranch.Leave += new System.EventHandler(this.cmbBranch_Leave);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.ForeColor = System.Drawing.Color.White;
            this.label42.Location = new System.Drawing.Point(279, 26);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(47, 13);
            this.label42.TabIndex = 90;
            this.label42.Text = "Branch :";
            // 
            // cmbUsers
            // 
            this.cmbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsers.FormattingEnabled = true;
            this.cmbUsers.Location = new System.Drawing.Point(331, 56);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(210, 21);
            this.cmbUsers.TabIndex = 88;
            this.cmbUsers.SelectedIndexChanged += new System.EventHandler(this.cmbUsers_SelectedIndexChanged);
            this.cmbUsers.Leave += new System.EventHandler(this.cmbUsers_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(256, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 89;
            this.label5.Text = "Select User :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(26, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 92;
            this.label6.Text = "Date :";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(64, 22);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(198, 20);
            this.dtpDate.TabIndex = 93;
            // 
            // frmSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 622);
            this.Controls.Add(this.panel1);
            this.Name = "frmSummary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSummary";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSummary_FormClosed);
            this.Load += new System.EventHandler(this.frmSummary_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbSummaryNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CrVoucher;
        private System.Windows.Forms.CheckBox DrVoucher;
        private System.Windows.Forms.CheckBox chkSaleInvoice;
        private System.Windows.Forms.DataGridView Grd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtTotalAmt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotalPaid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalDisc;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.ComboBox cmbUsers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpDate;
    }
}
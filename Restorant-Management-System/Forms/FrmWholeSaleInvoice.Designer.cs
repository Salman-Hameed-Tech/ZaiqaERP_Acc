namespace Restorant_Management_System.Forms
{
    partial class FrmWholeSaleInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWholeSaleInvoice));
            this.Grd = new DGV.DGV();
            this.label19 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GrpCustomer = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtBuyerID = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtBuyerName = new System.Windows.Forms.TextBox();
            this.txtNetAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGrossTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInvDiscount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPmtType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalItemDisc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTotalQty = new System.Windows.Forms.TextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).BeginInit();
            this.GrpCustomer.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grd
            // 
            this.Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grd.Location = new System.Drawing.Point(12, 127);
            this.Grd.MoveLeftToRight = true;
            this.Grd.Name = "Grd";
            this.Grd.Size = new System.Drawing.Size(1097, 305);
            this.Grd.TabIndex = 117;
            this.Grd.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grd_CellEndEdit);
            this.Grd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grd_KeyDown);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(44, 30);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(32, 13);
            this.label19.TabIndex = 166;
            this.label19.Text = "User:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(79, 25);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(188, 20);
            this.txtUserName.TabIndex = 167;
            this.txtUserName.TabStop = false;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(79, 50);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(188, 20);
            this.txtID.TabIndex = 165;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 164;
            this.label1.Text = "Invoice ID:";
            // 
            // GrpCustomer
            // 
            this.GrpCustomer.Controls.Add(this.label20);
            this.GrpCustomer.Controls.Add(this.txtBuyerID);
            this.GrpCustomer.Controls.Add(this.btnSearch);
            this.GrpCustomer.Controls.Add(this.txtBuyerName);
            this.GrpCustomer.Location = new System.Drawing.Point(922, 14);
            this.GrpCustomer.Name = "GrpCustomer";
            this.GrpCustomer.Size = new System.Drawing.Size(186, 108);
            this.GrpCustomer.TabIndex = 169;
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
            // txtBuyerID
            // 
            this.txtBuyerID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuyerID.Location = new System.Drawing.Point(17, 32);
            this.txtBuyerID.Name = "txtBuyerID";
            this.txtBuyerID.Size = new System.Drawing.Size(128, 20);
            this.txtBuyerID.TabIndex = 110;
            this.txtBuyerID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // txtBuyerName
            // 
            this.txtBuyerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuyerName.Location = new System.Drawing.Point(17, 55);
            this.txtBuyerName.Multiline = true;
            this.txtBuyerName.Name = "txtBuyerName";
            this.txtBuyerName.ReadOnly = true;
            this.txtBuyerName.Size = new System.Drawing.Size(156, 43);
            this.txtBuyerName.TabIndex = 113;
            this.txtBuyerName.TabStop = false;
            // 
            // txtNetAmount
            // 
            this.txtNetAmount.Location = new System.Drawing.Point(969, 514);
            this.txtNetAmount.Name = "txtNetAmount";
            this.txtNetAmount.ReadOnly = true;
            this.txtNetAmount.Size = new System.Drawing.Size(140, 20);
            this.txtNetAmount.TabIndex = 176;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(900, 518);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 175;
            this.label6.Text = "Net Total:";
            // 
            // txtGrossTotal
            // 
            this.txtGrossTotal.Location = new System.Drawing.Point(969, 462);
            this.txtGrossTotal.Name = "txtGrossTotal";
            this.txtGrossTotal.ReadOnly = true;
            this.txtGrossTotal.Size = new System.Drawing.Size(140, 20);
            this.txtGrossTotal.TabIndex = 174;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(900, 466);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 173;
            this.label4.Text = "Gross Total:";
            // 
            // txtInvDiscount
            // 
            this.txtInvDiscount.Location = new System.Drawing.Point(969, 488);
            this.txtInvDiscount.Name = "txtInvDiscount";
            this.txtInvDiscount.Size = new System.Drawing.Size(140, 20);
            this.txtInvDiscount.TabIndex = 172;
            this.txtInvDiscount.TextChanged += new System.EventHandler(this.txtInvDiscount_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(877, 491);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 171;
            this.label3.Text = "Invoice Discount:";
            // 
            // btnNew
            // 
            this.btnNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnNew.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(414, 567);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(66, 34);
            this.btnNew.TabIndex = 177;
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
            this.btnSave.Location = new System.Drawing.Point(561, 567);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 34);
            this.btnSave.TabIndex = 178;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(79, 103);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(188, 20);
            this.dtpDate.TabIndex = 180;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(43, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 181;
            this.label2.Text = "Date:";
            // 
            // cmbPmtType
            // 
            this.cmbPmtType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPmtType.FormattingEnabled = true;
            this.cmbPmtType.Items.AddRange(new object[] {
            "Cash",
            "Credit"});
            this.cmbPmtType.Location = new System.Drawing.Point(371, 100);
            this.cmbPmtType.Name = "cmbPmtType";
            this.cmbPmtType.Size = new System.Drawing.Size(185, 21);
            this.cmbPmtType.TabIndex = 182;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(290, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 183;
            this.label7.Text = "Payment Mode";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(90, 437);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(409, 20);
            this.txtRemarks.TabIndex = 184;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(32, 441);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 185;
            this.label5.Text = "Remarks:";
            // 
            // txtTotalItemDisc
            // 
            this.txtTotalItemDisc.Location = new System.Drawing.Point(748, 436);
            this.txtTotalItemDisc.Name = "txtTotalItemDisc";
            this.txtTotalItemDisc.Size = new System.Drawing.Size(97, 20);
            this.txtTotalItemDisc.TabIndex = 186;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(643, 439);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 13);
            this.label8.TabIndex = 187;
            this.label8.Text = "Total Item Discount:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(891, 439);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 189;
            this.label9.Text = "Total Quantity:";
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.Location = new System.Drawing.Point(970, 436);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.Size = new System.Drawing.Size(139, 20);
            this.txtTotalQty.TabIndex = 188;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(126)))), ((int)(((byte)(50)))));
            this.btnEdit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(490, 567);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(66, 34);
            this.btnEdit.TabIndex = 190;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // cmbBranch
            // 
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.Enabled = false;
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Items.AddRange(new object[] {
            "Cash",
            "Credit"});
            this.cmbBranch.Location = new System.Drawing.Point(79, 76);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(188, 21);
            this.cmbBranch.TabIndex = 191;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(32, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 192;
            this.label10.Text = "Branch:";
            // 
            // FrmWholeSaleInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1121, 614);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbBranch);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTotalQty);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtTotalItemDisc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.cmbPmtType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNetAmount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtGrossTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtInvDiscount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GrpCustomer);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Grd);
            this.Name = "FrmWholeSaleInvoice";
            this.Tag = "49";
            this.Text = "FrmWholeSaleInvoice";
            this.Load += new System.EventHandler(this.FrmWholeSaleInvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).EndInit();
            this.GrpCustomer.ResumeLayout(false);
            this.GrpCustomer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DGV.DGV Grd;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox GrpCustomer;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtBuyerID;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtBuyerName;
        private System.Windows.Forms.TextBox txtNetAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGrossTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInvDiscount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPmtType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotalItemDisc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTotalQty;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.Label label10;
    }
}
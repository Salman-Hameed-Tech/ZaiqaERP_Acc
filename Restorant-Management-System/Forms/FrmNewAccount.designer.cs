namespace Accounts
{
    partial class FrmNewAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNewAccount));
            this.FrmNewAccount_Fill_Panel = new System.Windows.Forms.Panel();
            this.Grd = new DGV.DGV();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
            this.tsbtnClear = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSave = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtGRVAccountName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGRVAccount = new System.Windows.Forms.TextBox();
            this.btnSchVendor = new System.Windows.Forms.Button();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAccountType = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAccountNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAccountExtention = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtParentAccount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FrmNewAccount_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).BeginInit();
            this.tsMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FrmNewAccount_Fill_Panel
            // 
            this.FrmNewAccount_Fill_Panel.BackColor = System.Drawing.Color.SteelBlue;
            this.FrmNewAccount_Fill_Panel.Controls.Add(this.Grd);
            this.FrmNewAccount_Fill_Panel.Controls.Add(this.tsMain);
            this.FrmNewAccount_Fill_Panel.Controls.Add(this.groupBox1);
            this.FrmNewAccount_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.FrmNewAccount_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FrmNewAccount_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.FrmNewAccount_Fill_Panel.Name = "FrmNewAccount_Fill_Panel";
            this.FrmNewAccount_Fill_Panel.Size = new System.Drawing.Size(574, 304);
            this.FrmNewAccount_Fill_Panel.TabIndex = 0;
            // 
            // Grd
            // 
            this.Grd.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.Grd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grd.Location = new System.Drawing.Point(543, 62);
            this.Grd.MoveLeftToRight = false;
            this.Grd.Name = "Grd";
            this.Grd.RowHeadersVisible = false;
            this.Grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Grd.Size = new System.Drawing.Size(20, 195);
            this.Grd.TabIndex = 169;
            this.Grd.Visible = false;
            // 
            // tsMain
            // 
            this.tsMain.BackColor = System.Drawing.Color.SteelBlue;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnClose,
            this.tsbtnClear,
            this.tsbtnSave});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(574, 40);
            this.tsMain.TabIndex = 14;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsbtnClose
            // 
            this.tsbtnClose.AutoSize = false;
            this.tsbtnClose.ForeColor = System.Drawing.Color.White;
            this.tsbtnClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnClose.Image")));
            this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnClose.Name = "tsbtnClose";
            this.tsbtnClose.Size = new System.Drawing.Size(53, 37);
            this.tsbtnClose.Text = "&Close";
            this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
            // 
            // tsbtnClear
            // 
            this.tsbtnClear.ForeColor = System.Drawing.Color.White;
            this.tsbtnClear.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnClear.Image")));
            this.tsbtnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnClear.Name = "tsbtnClear";
            this.tsbtnClear.Size = new System.Drawing.Size(51, 37);
            this.tsbtnClear.Text = "&New";
            this.tsbtnClear.Click += new System.EventHandler(this.tsbtnClear_Click);
            // 
            // tsbtnSave
            // 
            this.tsbtnSave.ForeColor = System.Drawing.Color.White;
            this.tsbtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSave.Image")));
            this.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSave.Name = "tsbtnSave";
            this.tsbtnSave.Size = new System.Drawing.Size(51, 37);
            this.tsbtnSave.Text = "&Save";
            this.tsbtnSave.Click += new System.EventHandler(this.tsbtnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtGRVAccountName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtGRVAccount);
            this.groupBox1.Controls.Add(this.btnSchVendor);
            this.groupBox1.Controls.Add(this.txtNarration);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtAccountType);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtAccountName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtAccountNo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAccountExtention);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtParentAccount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(525, 236);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account Detail";
            // 
            // txtGRVAccountName
            // 
            this.txtGRVAccountName.Location = new System.Drawing.Point(143, 198);
            this.txtGRVAccountName.Name = "txtGRVAccountName";
            this.txtGRVAccountName.ReadOnly = true;
            this.txtGRVAccountName.Size = new System.Drawing.Size(280, 20);
            this.txtGRVAccountName.TabIndex = 120;
            this.txtGRVAccountName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(17, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 13);
            this.label7.TabIndex = 119;
            this.label7.Text = "Gross Revenue Account:";
            // 
            // txtGRVAccount
            // 
            this.txtGRVAccount.Location = new System.Drawing.Point(19, 198);
            this.txtGRVAccount.Name = "txtGRVAccount";
            this.txtGRVAccount.ReadOnly = true;
            this.txtGRVAccount.Size = new System.Drawing.Size(91, 20);
            this.txtGRVAccount.TabIndex = 117;
            this.txtGRVAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSchVendor
            // 
            this.btnSchVendor.Image = ((System.Drawing.Image)(resources.GetObject("btnSchVendor.Image")));
            this.btnSchVendor.Location = new System.Drawing.Point(112, 196);
            this.btnSchVendor.Name = "btnSchVendor";
            this.btnSchVendor.Size = new System.Drawing.Size(29, 23);
            this.btnSchVendor.TabIndex = 118;
            this.btnSchVendor.TabStop = false;
            this.btnSchVendor.UseVisualStyleBackColor = true;
            this.btnSchVendor.Click += new System.EventHandler(this.btnSchVendor_Click);
            // 
            // txtNarration
            // 
            this.txtNarration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNarration.Location = new System.Drawing.Point(18, 150);
            this.txtNarration.MaxLength = 100;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(493, 20);
            this.txtNarration.TabIndex = 5;
            this.txtNarration.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtParentAccount_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(15, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Narration";
            // 
            // txtAccountType
            // 
            this.txtAccountType.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtAccountType.Location = new System.Drawing.Point(411, 61);
            this.txtAccountType.Name = "txtAccountType";
            this.txtAccountType.ReadOnly = true;
            this.txtAccountType.Size = new System.Drawing.Size(100, 20);
            this.txtAccountType.TabIndex = 2;
            this.txtAccountType.TabStop = false;
            this.txtAccountType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtParentAccount_KeyDown);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(408, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Account Type";
            // 
            // txtAccountName
            // 
            this.txtAccountName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccountName.Location = new System.Drawing.Point(153, 103);
            this.txtAccountName.MaxLength = 100;
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(358, 20);
            this.txtAccountName.TabIndex = 4;
            this.txtAccountName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtParentAccount_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(150, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Account Name";
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.Location = new System.Drawing.Point(18, 103);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.ReadOnly = true;
            this.txtAccountNo.Size = new System.Drawing.Size(129, 20);
            this.txtAccountNo.TabIndex = 3;
            this.txtAccountNo.TabStop = false;
            this.txtAccountNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtParentAccount_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Account No";
            // 
            // txtAccountExtention
            // 
            this.txtAccountExtention.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccountExtention.Location = new System.Drawing.Point(153, 61);
            this.txtAccountExtention.Name = "txtAccountExtention";
            this.txtAccountExtention.Size = new System.Drawing.Size(252, 20);
            this.txtAccountExtention.TabIndex = 1;
            this.txtAccountExtention.TextChanged += new System.EventHandler(this.txtAccountExtention_TextChanged);
            this.txtAccountExtention.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtParentAccount_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(152, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Account Extension";
            // 
            // txtParentAccount
            // 
            this.txtParentAccount.Location = new System.Drawing.Point(18, 60);
            this.txtParentAccount.Name = "txtParentAccount";
            this.txtParentAccount.ReadOnly = true;
            this.txtParentAccount.Size = new System.Drawing.Size(129, 20);
            this.txtParentAccount.TabIndex = 0;
            this.txtParentAccount.TabStop = false;
            this.txtParentAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtParentAccount_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Parent Account No.";
            // 
            // FrmNewAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(211)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(574, 304);
            this.Controls.Add(this.FrmNewAccount_Fill_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmNewAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create or Change Account";
            this.Load += new System.EventHandler(this.FrmNewAccount_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmNewAccount_KeyDown);
            this.FrmNewAccount_Fill_Panel.ResumeLayout(false);
            this.FrmNewAccount_Fill_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).EndInit();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel FrmNewAccount_Fill_Panel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtNarration;
        public System.Windows.Forms.TextBox txtAccountType;
        public System.Windows.Forms.TextBox txtAccountName;
        public System.Windows.Forms.TextBox txtAccountNo;
        public System.Windows.Forms.TextBox txtAccountExtention;
        public System.Windows.Forms.TextBox txtParentAccount;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbtnClose;
        private System.Windows.Forms.ToolStripButton tsbtnClear;
        private System.Windows.Forms.ToolStripButton tsbtnSave;
        private DGV.DGV Grd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSchVendor;
        public System.Windows.Forms.TextBox txtGRVAccountName;
        public System.Windows.Forms.TextBox txtGRVAccount;
    }
}
namespace Accounts.Forms
{
    partial class FrmOpeningBalances
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOpeningBalances));
            this.label1 = new System.Windows.Forms.Label();
            this.cbxAccountType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.rdbSortAccNo = new System.Windows.Forms.RadioButton();
            this.rdbSortAccName = new System.Windows.Forms.RadioButton();
            this.Grd = new DGV.DGV();
            this.FrmOpeningBalances_Fill_Panel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
            this.tsbtnClear = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSave = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).BeginInit();
            this.FrmOpeningBalances_Fill_Panel.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select Account Type:";
            // 
            // cbxAccountType
            // 
            this.cbxAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAccountType.FormattingEnabled = true;
            this.cbxAccountType.Location = new System.Drawing.Point(131, 99);
            this.cbxAccountType.Name = "cbxAccountType";
            this.cbxAccountType.Size = new System.Drawing.Size(121, 21);
            this.cbxAccountType.TabIndex = 0;
            this.cbxAccountType.SelectedIndexChanged += new System.EventHandler(this.cbxAccountType_SelectedIndexChanged);
            this.cbxAccountType.SelectionChangeCommitted += new System.EventHandler(this.cbxAccountType_SelectionChangeCommitted);
            this.cbxAccountType.SelectedValueChanged += new System.EventHandler(this.cbxAccountType_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(43, 130);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Account Name:";
            // 
            // txtAccountName
            // 
            this.txtAccountName.Location = new System.Drawing.Point(131, 129);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(493, 20);
            this.txtAccountName.TabIndex = 1;
            this.txtAccountName.TextChanged += new System.EventHandler(this.txtAccountName_TextChanged);
            // 
            // rdbSortAccNo
            // 
            this.rdbSortAccNo.AutoSize = true;
            this.rdbSortAccNo.ForeColor = System.Drawing.Color.White;
            this.rdbSortAccNo.Location = new System.Drawing.Point(272, 102);
            this.rdbSortAccNo.Name = "rdbSortAccNo";
            this.rdbSortAccNo.Size = new System.Drawing.Size(119, 17);
            this.rdbSortAccNo.TabIndex = 3;
            this.rdbSortAccNo.TabStop = true;
            this.rdbSortAccNo.Text = "Sort By Account No";
            this.rdbSortAccNo.UseVisualStyleBackColor = true;
            this.rdbSortAccNo.Visible = false;
            this.rdbSortAccNo.CheckedChanged += new System.EventHandler(this.rdbSortAccNo_CheckedChanged);
            // 
            // rdbSortAccName
            // 
            this.rdbSortAccName.AutoSize = true;
            this.rdbSortAccName.ForeColor = System.Drawing.Color.White;
            this.rdbSortAccName.Location = new System.Drawing.Point(397, 102);
            this.rdbSortAccName.Name = "rdbSortAccName";
            this.rdbSortAccName.Size = new System.Drawing.Size(133, 17);
            this.rdbSortAccName.TabIndex = 4;
            this.rdbSortAccName.TabStop = true;
            this.rdbSortAccName.Text = "Sort By Account Name";
            this.rdbSortAccName.UseVisualStyleBackColor = true;
            this.rdbSortAccName.Visible = false;
            this.rdbSortAccName.CheckedChanged += new System.EventHandler(this.rdbSortAccName_CheckedChanged);
            // 
            // Grd
            // 
            this.Grd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grd.Location = new System.Drawing.Point(16, 155);
            this.Grd.MoveLeftToRight = true;
            this.Grd.Name = "Grd";
            this.Grd.Size = new System.Drawing.Size(621, 374);
            this.Grd.StandardTab = true;
            this.Grd.TabIndex = 11;
            this.Grd.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grd_CellEndEdit);
            // 
            // FrmOpeningBalances_Fill_Panel
            // 
            this.FrmOpeningBalances_Fill_Panel.BackColor = System.Drawing.Color.SteelBlue;
            this.FrmOpeningBalances_Fill_Panel.Controls.Add(this.label7);
            this.FrmOpeningBalances_Fill_Panel.Controls.Add(this.cmbBranch);
            this.FrmOpeningBalances_Fill_Panel.Controls.Add(this.tsMain);
            this.FrmOpeningBalances_Fill_Panel.Controls.Add(this.Grd);
            this.FrmOpeningBalances_Fill_Panel.Controls.Add(this.rdbSortAccName);
            this.FrmOpeningBalances_Fill_Panel.Controls.Add(this.rdbSortAccNo);
            this.FrmOpeningBalances_Fill_Panel.Controls.Add(this.txtAccountName);
            this.FrmOpeningBalances_Fill_Panel.Controls.Add(this.label2);
            this.FrmOpeningBalances_Fill_Panel.Controls.Add(this.cbxAccountType);
            this.FrmOpeningBalances_Fill_Panel.Controls.Add(this.label1);
            this.FrmOpeningBalances_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.FrmOpeningBalances_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FrmOpeningBalances_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.FrmOpeningBalances_Fill_Panel.Name = "FrmOpeningBalances_Fill_Panel";
            this.FrmOpeningBalances_Fill_Panel.Size = new System.Drawing.Size(649, 532);
            this.FrmOpeningBalances_Fill_Panel.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(80, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 515;
            this.label7.Text = "Branch: ";
            // 
            // cmbBranch
            // 
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.Enabled = false;
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(131, 70);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(215, 21);
            this.cmbBranch.TabIndex = 514;
            this.cmbBranch.SelectedValueChanged += new System.EventHandler(this.cmbBranch_SelectedValueChanged);
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnClose,
            this.tsbtnClear,
            this.tsbtnSave});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(649, 40);
            this.tsMain.TabIndex = 19;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsbtnClose
            // 
            this.tsbtnClose.AutoSize = false;
            this.tsbtnClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnClose.Image")));
            this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnClose.Name = "tsbtnClose";
            this.tsbtnClose.Size = new System.Drawing.Size(53, 37);
            this.tsbtnClose.Text = "&Close";
            this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
            // 
            // tsbtnClear
            // 
            this.tsbtnClear.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnClear.Image")));
            this.tsbtnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnClear.Name = "tsbtnClear";
            this.tsbtnClear.Size = new System.Drawing.Size(66, 37);
            this.tsbtnClear.Text = "&Refresh";
            this.tsbtnClear.Click += new System.EventHandler(this.tsbtnClear_Click);
            // 
            // tsbtnSave
            // 
            this.tsbtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSave.Image")));
            this.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSave.Name = "tsbtnSave";
            this.tsbtnSave.Size = new System.Drawing.Size(51, 37);
            this.tsbtnSave.Text = "&Save";
            this.tsbtnSave.Click += new System.EventHandler(this.tsbtnSave_Click);
            // 
            // FrmOpeningBalances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(649, 532);
            this.Controls.Add(this.FrmOpeningBalances_Fill_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmOpeningBalances";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "3";
            this.Text = "Opening Balances";
            this.Load += new System.EventHandler(this.FrmOpeningBalances_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).EndInit();
            this.FrmOpeningBalances_Fill_Panel.ResumeLayout(false);
            this.FrmOpeningBalances_Fill_Panel.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxAccountType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.RadioButton rdbSortAccNo;
        private System.Windows.Forms.RadioButton rdbSortAccName;
        private DGV.DGV Grd;
        private System.Windows.Forms.Panel FrmOpeningBalances_Fill_Panel;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbtnClose;
        private System.Windows.Forms.ToolStripButton tsbtnClear;
        private System.Windows.Forms.ToolStripButton tsbtnSave;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbBranch;
    }
}
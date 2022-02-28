namespace Restorant_Management_System
{
    partial class FrmMain
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Users & Rights");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Chart Of Accounts");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Opening Balances");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Administrator", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Item Category");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Item");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("City Creation");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Setup", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Purchase Invoice");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Issue Invoice");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Vouchers");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Claim Invoice");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Menu Receipe");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Menu Category Relationship");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Points Opening Stock");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Transactions", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15});
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Cash Book");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Account Ledger");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("General Journal");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Trail Balance");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Income Statement");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Accounts Payable");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Accounts Receiveable");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Account Reports", new System.Windows.Forms.TreeNode[] {
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode23});
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Purchase Register");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Purchase Return Register");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Issue Register");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Issue Return Register");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Current Stock");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("CurrentStock With Amount");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Item Ledger");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Inventory Reports", new System.Windows.Forms.TreeNode[] {
            treeNode25,
            treeNode26,
            treeNode27,
            treeNode28,
            treeNode29,
            treeNode30,
            treeNode31});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.PnlSubLeft = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tV = new System.Windows.Forms.TreeView();
            this.PnlLeft = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblHeading = new System.Windows.Forms.Label();
            this.PnlFormClose = new System.Windows.Forms.Panel();
            this.cmbControls = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnShowPnl = new System.Windows.Forms.Button();
            this.btnHidePnl = new System.Windows.Forms.Button();
            this.pkbFormName = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.PnlSubLeft.SuspendLayout();
            this.panel5.SuspendLayout();
            this.PnlLeft.SuspendLayout();
            this.panel6.SuspendLayout();
            this.PnlFormClose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pkbFormName)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlSubLeft
            // 
            this.PnlSubLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(80)))), ((int)(((byte)(137)))));
            this.PnlSubLeft.Controls.Add(this.panel5);
            this.PnlSubLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlSubLeft.Location = new System.Drawing.Point(0, 0);
            this.PnlSubLeft.Name = "PnlSubLeft";
            this.PnlSubLeft.Size = new System.Drawing.Size(230, 595);
            this.PnlSubLeft.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(80)))), ((int)(((byte)(137)))));
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.tV);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(230, 595);
            this.panel5.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 22);
            this.label2.TabIndex = 508;
            this.label2.Text = "ZAIQA RESTAURANT";
            // 
            // tV
            // 
            this.tV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(80)))), ((int)(((byte)(137)))));
            this.tV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tV.ForeColor = System.Drawing.Color.White;
            this.tV.Location = new System.Drawing.Point(-1, 69);
            this.tV.Name = "tV";
            treeNode1.Name = "Users";
            treeNode1.Tag = "1";
            treeNode1.Text = "Users & Rights";
            treeNode2.Name = "ChartOfAccounts";
            treeNode2.Tag = "2";
            treeNode2.Text = "Chart Of Accounts";
            treeNode3.Name = "OpeningBalances";
            treeNode3.Tag = "3";
            treeNode3.Text = "Opening Balances";
            treeNode4.Name = "Administrator";
            treeNode4.Text = "Administrator";
            treeNode5.Name = "ItemCategory";
            treeNode5.Tag = "5";
            treeNode5.Text = "Item Category";
            treeNode6.Name = "Item";
            treeNode6.Tag = "6";
            treeNode6.Text = "Item";
            treeNode7.Name = "CityCreation";
            treeNode7.Text = "City Creation";
            treeNode8.Name = "Setup";
            treeNode8.Text = "Setup";
            treeNode9.Name = "PurchaseInvoice";
            treeNode9.Tag = "7";
            treeNode9.Text = "Purchase Invoice";
            treeNode10.Name = "SaleInvoice";
            treeNode10.Tag = "10";
            treeNode10.Text = "Issue Invoice";
            treeNode11.Name = "Vouchers";
            treeNode11.Tag = "11";
            treeNode11.Text = "Vouchers";
            treeNode12.Name = "ClaimInvoice";
            treeNode12.Tag = "12";
            treeNode12.Text = "Claim Invoice";
            treeNode13.Name = "MenuReceipe";
            treeNode13.Tag = "40";
            treeNode13.Text = "Menu Receipe";
            treeNode14.Name = "MCategoryRelationship";
            treeNode14.Tag = "41";
            treeNode14.Text = "Menu Category Relationship";
            treeNode15.Name = "PointsOpeningStock";
            treeNode15.Tag = "42";
            treeNode15.Text = "Points Opening Stock";
            treeNode16.Name = "Transaction";
            treeNode16.Text = "Transactions";
            treeNode17.Name = "CashBook";
            treeNode17.Tag = "16";
            treeNode17.Text = "Cash Book";
            treeNode18.Name = "AccountLedger";
            treeNode18.Tag = "17";
            treeNode18.Text = "Account Ledger";
            treeNode19.Name = "GeneralJournal";
            treeNode19.Tag = "18";
            treeNode19.Text = "General Journal";
            treeNode20.Name = "TrailBalance";
            treeNode20.Tag = "19";
            treeNode20.Text = "Trail Balance";
            treeNode21.Name = "IncomeStatement";
            treeNode21.Tag = "20";
            treeNode21.Text = "Income Statement";
            treeNode22.Name = "AccountsPayable";
            treeNode22.Tag = "21";
            treeNode22.Text = "Accounts Payable";
            treeNode23.Name = "AccountsReceiveable";
            treeNode23.Tag = "22";
            treeNode23.Text = "Accounts Receiveable";
            treeNode24.Name = "AccountReports";
            treeNode24.Text = "Account Reports";
            treeNode25.Name = "PurchaseRegister";
            treeNode25.Tag = "23";
            treeNode25.Text = "Purchase Register";
            treeNode26.Name = "PurchaseReturnRegister";
            treeNode26.Tag = "24";
            treeNode26.Text = "Purchase Return Register";
            treeNode27.Name = "SaleRegister";
            treeNode27.Tag = "25";
            treeNode27.Text = "Issue Register";
            treeNode28.Name = "SaleReturnRegister";
            treeNode28.Tag = "26";
            treeNode28.Text = "Issue Return Register";
            treeNode29.Name = "CurrentStock";
            treeNode29.Tag = "27";
            treeNode29.Text = "Current Stock";
            treeNode30.Name = "CurrentStockWA";
            treeNode30.Tag = "28";
            treeNode30.Text = "CurrentStock With Amount";
            treeNode31.Name = "ItemLedgerBranch";
            treeNode31.Tag = "31";
            treeNode31.Text = "Item Ledger";
            treeNode32.Name = "InventoryReports";
            treeNode32.Text = "Inventory Reports";
            this.tV.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode8,
            treeNode16,
            treeNode24,
            treeNode32});
            this.tV.Size = new System.Drawing.Size(228, 512);
            this.tV.TabIndex = 9;
            this.tV.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // PnlLeft
            // 
            this.PnlLeft.Controls.Add(this.PnlSubLeft);
            this.PnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlLeft.Location = new System.Drawing.Point(0, 0);
            this.PnlLeft.Name = "PnlLeft";
            this.PnlLeft.Size = new System.Drawing.Size(230, 595);
            this.PnlLeft.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(80)))), ((int)(((byte)(137)))));
            this.panel6.Controls.Add(this.lblHeading);
            this.panel6.Controls.Add(this.PnlFormClose);
            this.panel6.Controls.Add(this.btnShowPnl);
            this.panel6.Controls.Add(this.btnHidePnl);
            this.panel6.Controls.Add(this.pkbFormName);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(230, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(867, 55);
            this.panel6.TabIndex = 7;
            this.panel6.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Times New Roman", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.ForeColor = System.Drawing.Color.White;
            this.lblHeading.Location = new System.Drawing.Point(71, 14);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(85, 32);
            this.lblHeading.TabIndex = 507;
            this.lblHeading.Text = "Home";
            // 
            // PnlFormClose
            // 
            this.PnlFormClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlFormClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(80)))), ((int)(((byte)(137)))));
            this.PnlFormClose.Controls.Add(this.cmbControls);
            this.PnlFormClose.Controls.Add(this.label1);
            this.PnlFormClose.Controls.Add(this.button1);
            this.PnlFormClose.Location = new System.Drawing.Point(423, 0);
            this.PnlFormClose.Name = "PnlFormClose";
            this.PnlFormClose.Size = new System.Drawing.Size(444, 55);
            this.PnlFormClose.TabIndex = 506;
            // 
            // cmbControls
            // 
            this.cmbControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(116)))), ((int)(((byte)(157)))));
            this.cmbControls.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbControls.ForeColor = System.Drawing.Color.White;
            this.cmbControls.FormattingEnabled = true;
            this.cmbControls.Location = new System.Drawing.Point(103, 16);
            this.cmbControls.Name = "cmbControls";
            this.cmbControls.Size = new System.Drawing.Size(178, 24);
            this.cmbControls.TabIndex = 500;
            this.cmbControls.TabStop = false;
            this.cmbControls.SelectedIndexChanged += new System.EventHandler(this.cmbControls_SelectedIndexChanged);
            this.cmbControls.Click += new System.EventHandler(this.cmbControls_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Opened Forms";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(116)))), ((int)(((byte)(157)))));
            this.button1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(310, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 30);
            this.button1.TabIndex = 502;
            this.button1.TabStop = false;
            this.button1.Text = "Close All Forms";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnShowPnl
            // 
            this.btnShowPnl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnShowPnl.BackgroundImage")));
            this.btnShowPnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShowPnl.FlatAppearance.BorderSize = 0;
            this.btnShowPnl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowPnl.Location = new System.Drawing.Point(26, 11);
            this.btnShowPnl.Name = "btnShowPnl";
            this.btnShowPnl.Size = new System.Drawing.Size(33, 33);
            this.btnShowPnl.TabIndex = 505;
            this.btnShowPnl.UseVisualStyleBackColor = true;
            this.btnShowPnl.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnHidePnl
            // 
            this.btnHidePnl.BackgroundImage = global::Restorant_Management_System.Properties.Resources.icons8_menu_1_32;
            this.btnHidePnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHidePnl.FlatAppearance.BorderSize = 0;
            this.btnHidePnl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHidePnl.Location = new System.Drawing.Point(24, 11);
            this.btnHidePnl.Name = "btnHidePnl";
            this.btnHidePnl.Size = new System.Drawing.Size(33, 33);
            this.btnHidePnl.TabIndex = 504;
            this.btnHidePnl.UseVisualStyleBackColor = true;
            this.btnHidePnl.Click += new System.EventHandler(this.btnHalfPnl_Click);
            // 
            // pkbFormName
            // 
            this.pkbFormName.Location = new System.Drawing.Point(526, 4);
            this.pkbFormName.Name = "pkbFormName";
            this.pkbFormName.Size = new System.Drawing.Size(49, 40);
            this.pkbFormName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pkbFormName.TabIndex = 503;
            this.pkbFormName.TabStop = false;
            // 
            // button2
            // 
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(1147, 142);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 23);
            this.button2.TabIndex = 501;
            this.button2.TabStop = false;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1097, 595);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.PnlLeft);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1091, 572);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.PnlSubLeft.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.PnlLeft.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.PnlFormClose.ResumeLayout(false);
            this.PnlFormClose.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pkbFormName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlSubLeft;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel PnlLeft;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cmbControls;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pkbFormName;
        private System.Windows.Forms.Button btnHidePnl;
        private System.Windows.Forms.Panel PnlFormClose;
        private System.Windows.Forms.Button btnShowPnl;
        private System.Windows.Forms.TreeView tV;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Label label2;
    }
}
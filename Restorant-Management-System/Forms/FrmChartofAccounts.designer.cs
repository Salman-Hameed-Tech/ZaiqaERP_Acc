namespace Accounts.Forms
{
    partial class FrmChartofAccounts
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChartofAccounts));
            this.FrmChartofAccounts_Fill_Panel = new System.Windows.Forms.Panel();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lvChartofAccounts = new System.Windows.Forms.ListView();
            this.hdrAccountNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrAccountName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cMnuListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuCreateAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuModAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuDeleteAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAccountType = new System.Windows.Forms.TextBox();
            this.txtAccountNo = new System.Windows.Forms.TextBox();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.rbParties = new System.Windows.Forms.RadioButton();
            this.rbAccounts = new System.Windows.Forms.RadioButton();
            this.tvChartofAccounts = new System.Windows.Forms.TreeView();
            this.cMnuTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuNewGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuModGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuDelGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.ILTreeView = new System.Windows.Forms.ImageList(this.components);
            this.ILForm = new System.Windows.Forms.ImageList(this.components);
            this.FrmChartofAccounts_Fill_Panel.SuspendLayout();
            this.cMnuListView.SuspendLayout();
            this.cMnuTreeView.SuspendLayout();
            this.SuspendLayout();
            // 
            // FrmChartofAccounts_Fill_Panel
            // 
            this.FrmChartofAccounts_Fill_Panel.BackColor = System.Drawing.Color.SteelBlue;
            this.FrmChartofAccounts_Fill_Panel.Controls.Add(this.txtAccountName);
            this.FrmChartofAccounts_Fill_Panel.Controls.Add(this.label6);
            this.FrmChartofAccounts_Fill_Panel.Controls.Add(this.lvChartofAccounts);
            this.FrmChartofAccounts_Fill_Panel.Controls.Add(this.label2);
            this.FrmChartofAccounts_Fill_Panel.Controls.Add(this.label1);
            this.FrmChartofAccounts_Fill_Panel.Controls.Add(this.txtAccountType);
            this.FrmChartofAccounts_Fill_Panel.Controls.Add(this.txtAccountNo);
            this.FrmChartofAccounts_Fill_Panel.Controls.Add(this.rbAll);
            this.FrmChartofAccounts_Fill_Panel.Controls.Add(this.rbParties);
            this.FrmChartofAccounts_Fill_Panel.Controls.Add(this.rbAccounts);
            this.FrmChartofAccounts_Fill_Panel.Controls.Add(this.tvChartofAccounts);
            this.FrmChartofAccounts_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.FrmChartofAccounts_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FrmChartofAccounts_Fill_Panel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FrmChartofAccounts_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.FrmChartofAccounts_Fill_Panel.Name = "FrmChartofAccounts_Fill_Panel";
            this.FrmChartofAccounts_Fill_Panel.Size = new System.Drawing.Size(848, 494);
            this.FrmChartofAccounts_Fill_Panel.TabIndex = 0;
            // 
            // txtAccountName
            // 
            this.txtAccountName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccountName.Location = new System.Drawing.Point(392, 103);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(440, 21);
            this.txtAccountName.TabIndex = 5;
            this.txtAccountName.TextChanged += new System.EventHandler(this.txtAccountName_TextChanged);
            this.txtAccountName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccountName_KeyDown);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(327, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "A/C Name";
            // 
            // lvChartofAccounts
            // 
            this.lvChartofAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lvChartofAccounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hdrAccountNo,
            this.hdrAccountName});
            this.lvChartofAccounts.ContextMenuStrip = this.cMnuListView;
            this.lvChartofAccounts.FullRowSelect = true;
            this.lvChartofAccounts.GridLines = true;
            this.lvChartofAccounts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvChartofAccounts.HideSelection = false;
            this.lvChartofAccounts.HoverSelection = true;
            this.lvChartofAccounts.Location = new System.Drawing.Point(330, 126);
            this.lvChartofAccounts.Name = "lvChartofAccounts";
            this.lvChartofAccounts.Size = new System.Drawing.Size(502, 296);
            this.lvChartofAccounts.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvChartofAccounts.TabIndex = 6;
            this.lvChartofAccounts.UseCompatibleStateImageBehavior = false;
            this.lvChartofAccounts.View = System.Windows.Forms.View.Details;
            // 
            // hdrAccountNo
            // 
            this.hdrAccountNo.Text = "Account No";
            this.hdrAccountNo.Width = 100;
            // 
            // hdrAccountName
            // 
            this.hdrAccountName.Text = "Account Name";
            this.hdrAccountName.Width = 1000;
            // 
            // cMnuListView
            // 
            this.cMnuListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuCreateAccount,
            this.cmnuModAccount,
            this.cmnuDeleteAccount});
            this.cMnuListView.Name = "cMnuListView";
            this.cMnuListView.Size = new System.Drawing.Size(235, 70);
            this.cMnuListView.Opening += new System.ComponentModel.CancelEventHandler(this.cMnuListView_Opening);
            // 
            // cmnuCreateAccount
            // 
            this.cmnuCreateAccount.Name = "cmnuCreateAccount";
            this.cmnuCreateAccount.Size = new System.Drawing.Size(234, 22);
            this.cmnuCreateAccount.Text = "Create Account for This Group";
            this.cmnuCreateAccount.Click += new System.EventHandler(this.cmnuCreateAccount_Click);
            // 
            // cmnuModAccount
            // 
            this.cmnuModAccount.Name = "cmnuModAccount";
            this.cmnuModAccount.Size = new System.Drawing.Size(234, 22);
            this.cmnuModAccount.Text = "Modify Selected Account";
            this.cmnuModAccount.Click += new System.EventHandler(this.cmnuModAccount_Click);
            // 
            // cmnuDeleteAccount
            // 
            this.cmnuDeleteAccount.Name = "cmnuDeleteAccount";
            this.cmnuDeleteAccount.Size = new System.Drawing.Size(234, 22);
            this.cmnuDeleteAccount.Text = "Delete Selected Account";
            this.cmnuDeleteAccount.Click += new System.EventHandler(this.cmnuDeleteAccount_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(127, 429);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Account Type";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 429);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Account No";
            // 
            // txtAccountType
            // 
            this.txtAccountType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAccountType.Location = new System.Drawing.Point(127, 445);
            this.txtAccountType.Name = "txtAccountType";
            this.txtAccountType.Size = new System.Drawing.Size(100, 21);
            this.txtAccountType.TabIndex = 8;
            this.txtAccountType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccountName_KeyDown);
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAccountNo.Location = new System.Drawing.Point(21, 445);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.Size = new System.Drawing.Size(100, 21);
            this.txtAccountNo.TabIndex = 7;
            this.txtAccountNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccountName_KeyDown);
            // 
            // rbAll
            // 
            this.rbAll.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAll.ForeColor = System.Drawing.Color.White;
            this.rbAll.Location = new System.Drawing.Point(200, 103);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(41, 19);
            this.rbAll.TabIndex = 1;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "All";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.CheckedChanged += new System.EventHandler(this.rbAccounts_CheckedChanged);
            // 
            // rbParties
            // 
            this.rbParties.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbParties.AutoSize = true;
            this.rbParties.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbParties.ForeColor = System.Drawing.Color.White;
            this.rbParties.Location = new System.Drawing.Point(120, 103);
            this.rbParties.Name = "rbParties";
            this.rbParties.Size = new System.Drawing.Size(70, 19);
            this.rbParties.TabIndex = 2;
            this.rbParties.Text = "Parties";
            this.rbParties.UseVisualStyleBackColor = true;
            this.rbParties.CheckedChanged += new System.EventHandler(this.rbAccounts_CheckedChanged);
            // 
            // rbAccounts
            // 
            this.rbAccounts.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbAccounts.AutoSize = true;
            this.rbAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAccounts.ForeColor = System.Drawing.Color.White;
            this.rbAccounts.Location = new System.Drawing.Point(32, 103);
            this.rbAccounts.Name = "rbAccounts";
            this.rbAccounts.Size = new System.Drawing.Size(82, 19);
            this.rbAccounts.TabIndex = 3;
            this.rbAccounts.Text = "Accounts";
            this.rbAccounts.UseVisualStyleBackColor = true;
            this.rbAccounts.CheckedChanged += new System.EventHandler(this.rbAccounts_CheckedChanged);
            // 
            // tvChartofAccounts
            // 
            this.tvChartofAccounts.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tvChartofAccounts.ContextMenuStrip = this.cMnuTreeView;
            this.tvChartofAccounts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tvChartofAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvChartofAccounts.ImageIndex = 0;
            this.tvChartofAccounts.ImageList = this.ILTreeView;
            this.tvChartofAccounts.Location = new System.Drawing.Point(21, 126);
            this.tvChartofAccounts.Name = "tvChartofAccounts";
            this.tvChartofAccounts.SelectedImageIndex = 1;
            this.tvChartofAccounts.ShowRootLines = false;
            this.tvChartofAccounts.Size = new System.Drawing.Size(300, 296);
            this.tvChartofAccounts.TabIndex = 4;
            this.tvChartofAccounts.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvChartofAccounts_AfterSelect);
            // 
            // cMnuTreeView
            // 
            this.cMnuTreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuNewGroup,
            this.cmnuModGroup,
            this.cmnuDelGroup});
            this.cMnuTreeView.Name = "cMnuTreeView";
            this.cMnuTreeView.Size = new System.Drawing.Size(171, 70);
            // 
            // cmnuNewGroup
            // 
            this.cmnuNewGroup.Name = "cmnuNewGroup";
            this.cmnuNewGroup.Size = new System.Drawing.Size(170, 22);
            this.cmnuNewGroup.Text = "New Group";
            this.cmnuNewGroup.Click += new System.EventHandler(this.cmnuNewGroup_Click);
            // 
            // cmnuModGroup
            // 
            this.cmnuModGroup.Name = "cmnuModGroup";
            this.cmnuModGroup.Size = new System.Drawing.Size(170, 22);
            this.cmnuModGroup.Text = "Modify this Group";
            this.cmnuModGroup.Click += new System.EventHandler(this.cmnuModGroup_Click);
            // 
            // cmnuDelGroup
            // 
            this.cmnuDelGroup.Name = "cmnuDelGroup";
            this.cmnuDelGroup.Size = new System.Drawing.Size(170, 22);
            this.cmnuDelGroup.Text = "Delete this Group";
            this.cmnuDelGroup.Click += new System.EventHandler(this.cmnuDelGroup_Click);
            // 
            // ILTreeView
            // 
            this.ILTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ILTreeView.ImageStream")));
            this.ILTreeView.TransparentColor = System.Drawing.Color.Transparent;
            this.ILTreeView.Images.SetKeyName(0, "folder.gif");
            this.ILTreeView.Images.SetKeyName(1, "current_folder.gif");
            // 
            // ILForm
            // 
            this.ILForm.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ILForm.ImageSize = new System.Drawing.Size(16, 16);
            this.ILForm.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // FrmChartofAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(211)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(848, 494);
            this.Controls.Add(this.FrmChartofAccounts_Fill_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmChartofAccounts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "2";
            this.Text = "Chart of Accounts";
            this.Load += new System.EventHandler(this.FrmChartofAccounts_Load);
            this.FrmChartofAccounts_Fill_Panel.ResumeLayout(false);
            this.FrmChartofAccounts_Fill_Panel.PerformLayout();
            this.cMnuListView.ResumeLayout(false);
            this.cMnuTreeView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel FrmChartofAccounts_Fill_Panel;
        private System.Windows.Forms.TreeView tvChartofAccounts;
        private System.Windows.Forms.ContextMenuStrip cMnuTreeView;
        private System.Windows.Forms.ImageList ILTreeView;
        private System.Windows.Forms.RadioButton rbAccounts;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.RadioButton rbParties;
        private System.Windows.Forms.TextBox txtAccountType;
        private System.Windows.Forms.TextBox txtAccountNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvChartofAccounts;
        private System.Windows.Forms.ColumnHeader hdrAccountNo;
        private System.Windows.Forms.ColumnHeader hdrAccountName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.ContextMenuStrip cMnuListView;
        private System.Windows.Forms.ToolStripMenuItem cmnuNewGroup;
        private System.Windows.Forms.ToolStripMenuItem cmnuModGroup;
        private System.Windows.Forms.ToolStripMenuItem cmnuDelGroup;
        private System.Windows.Forms.ToolStripMenuItem cmnuCreateAccount;
        private System.Windows.Forms.ToolStripMenuItem cmnuModAccount;
        private System.Windows.Forms.ToolStripMenuItem cmnuDeleteAccount;
        private System.Windows.Forms.ImageList ILForm;
        
        
    }
}
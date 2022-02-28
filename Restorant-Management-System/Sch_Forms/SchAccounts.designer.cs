namespace Accounts.SchForms
{
    partial class SchAccounts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchAccounts));
            this.SchAccounts_Fill_Panel = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnClose = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSelect = new System.Windows.Forms.ToolStripButton();
            this.Grd = new DGV.DGV();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SchAccounts_Fill_Panel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).BeginInit();
            this.SuspendLayout();
            // 
            // SchAccounts_Fill_Panel
            // 
            this.SchAccounts_Fill_Panel.BackColor = System.Drawing.Color.SteelBlue;
            this.SchAccounts_Fill_Panel.Controls.Add(this.toolStrip1);
            this.SchAccounts_Fill_Panel.Controls.Add(this.Grd);
            this.SchAccounts_Fill_Panel.Controls.Add(this.txtAccountName);
            this.SchAccounts_Fill_Panel.Controls.Add(this.label1);
            this.SchAccounts_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.SchAccounts_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SchAccounts_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.SchAccounts_Fill_Panel.Name = "SchAccounts_Fill_Panel";
            this.SchAccounts_Fill_Panel.Size = new System.Drawing.Size(562, 397);
            this.SchAccounts_Fill_Panel.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnClose,
            this.tsBtnSelect});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(562, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "&Select";
            // 
            // tsBtnClose
            // 
            this.tsBtnClose.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnClose.Image")));
            this.tsBtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnClose.Name = "tsBtnClose";
            this.tsBtnClose.Size = new System.Drawing.Size(56, 22);
            this.tsBtnClose.Text = "&Close";
            this.tsBtnClose.Click += new System.EventHandler(this.tsBtnClose_Click);
            // 
            // tsBtnSelect
            // 
            this.tsBtnSelect.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSelect.Image")));
            this.tsBtnSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSelect.Name = "tsBtnSelect";
            this.tsBtnSelect.Size = new System.Drawing.Size(58, 22);
            this.tsBtnSelect.Text = "&Select";
            this.tsBtnSelect.Click += new System.EventHandler(this.tsBtnSelect_Click);
            // 
            // Grd
            // 
            this.Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grd.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Grd.Location = new System.Drawing.Point(3, 73);
            this.Grd.MoveLeftToRight = false;
            this.Grd.Name = "Grd";
            this.Grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grd.Size = new System.Drawing.Size(556, 321);
            this.Grd.TabIndex = 2;
            this.Grd.DoubleClick += new System.EventHandler(this.Grd_DoubleClick);
            this.Grd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grd_KeyDown);
            // 
            // txtAccountName
            // 
            this.txtAccountName.Location = new System.Drawing.Point(141, 36);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(382, 20);
            this.txtAccountName.TabIndex = 0;
            this.txtAccountName.TextChanged += new System.EventHandler(this.txtAccountName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(45, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Account Name";
            // 
            // SchAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(211)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(562, 397);
            this.Controls.Add(this.SchAccounts_Fill_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "SchAccounts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Accounts";
            this.Load += new System.EventHandler(this.SchAccounts_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SchAccounts_KeyDown);
            this.SchAccounts_Fill_Panel.ResumeLayout(false);
            this.SchAccounts_Fill_Panel.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SchAccounts_Fill_Panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAccountName;
        private DGV.DGV Grd;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnClose;
        private System.Windows.Forms.ToolStripButton tsBtnSelect;
    }
}
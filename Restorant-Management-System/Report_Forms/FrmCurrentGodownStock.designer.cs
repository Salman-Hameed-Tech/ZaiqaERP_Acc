namespace Accounts
{
    partial class FrmCurrentStoreStock
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCurrentStoreStock));
            this.FrmCurrentStock_Fill_Panel = new System.Windows.Forms.Panel();
            this.grpParty = new System.Windows.Forms.GroupBox();
            this.chkAllVendor = new System.Windows.Forms.CheckBox();
            this.Grd = new DGV.DGV();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpStore = new System.Windows.Forms.GroupBox();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.lblBranch = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.txtItemID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbDesign = new System.Windows.Forms.ComboBox();
            this.cmbSize = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCompanyName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbProductName = new System.Windows.Forms.ComboBox();
            this.FrmCurrentStock_Fill_Panel.SuspendLayout();
            this.grpParty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).BeginInit();
            this.panel2.SuspendLayout();
            this.grpStore.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FrmCurrentStock_Fill_Panel
            // 
            this.FrmCurrentStock_Fill_Panel.BackColor = System.Drawing.Color.SteelBlue;
            this.FrmCurrentStock_Fill_Panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.grpParty);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.panel2);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.grpStore);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.groupBox2);
            this.FrmCurrentStock_Fill_Panel.Controls.Add(this.groupBox1);
            this.FrmCurrentStock_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.FrmCurrentStock_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FrmCurrentStock_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.FrmCurrentStock_Fill_Panel.Name = "FrmCurrentStock_Fill_Panel";
            this.FrmCurrentStock_Fill_Panel.Size = new System.Drawing.Size(928, 511);
            this.FrmCurrentStock_Fill_Panel.TabIndex = 0;
            this.FrmCurrentStock_Fill_Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmCurrentStock_Fill_Panel_Paint);
            // 
            // grpParty
            // 
            this.grpParty.Controls.Add(this.chkAllVendor);
            this.grpParty.Controls.Add(this.Grd);
            this.grpParty.ForeColor = System.Drawing.Color.Black;
            this.grpParty.Location = new System.Drawing.Point(836, 57);
            this.grpParty.Name = "grpParty";
            this.grpParty.Size = new System.Drawing.Size(80, 390);
            this.grpParty.TabIndex = 22;
            this.grpParty.TabStop = false;
            this.grpParty.Visible = false;
            // 
            // chkAllVendor
            // 
            this.chkAllVendor.AutoSize = true;
            this.chkAllVendor.ForeColor = System.Drawing.Color.White;
            this.chkAllVendor.Location = new System.Drawing.Point(6, 8);
            this.chkAllVendor.Name = "chkAllVendor";
            this.chkAllVendor.Size = new System.Drawing.Size(79, 17);
            this.chkAllVendor.TabIndex = 163;
            this.chkAllVendor.Text = "All Vendors";
            this.chkAllVendor.UseVisualStyleBackColor = true;
            // 
            // Grd
            // 
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
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grd.DefaultCellStyle = dataGridViewCellStyle2;
            this.Grd.Location = new System.Drawing.Point(10, 31);
            this.Grd.MoveLeftToRight = true;
            this.Grd.MultiSelect = false;
            this.Grd.Name = "Grd";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grd.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Grd.Size = new System.Drawing.Size(57, 343);
            this.Grd.StandardTab = true;
            this.Grd.TabIndex = 161;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.btnPreview);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Location = new System.Drawing.Point(324, 451);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(228, 48);
            this.panel2.TabIndex = 21;
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
            this.btnPreview.Location = new System.Drawing.Point(79, 7);
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
            // grpStore
            // 
            this.grpStore.Controls.Add(this.cmbBranch);
            this.grpStore.Controls.Add(this.lblBranch);
            this.grpStore.Controls.Add(this.cmbCategory);
            this.grpStore.Controls.Add(this.label1);
            this.grpStore.Location = new System.Drawing.Point(287, 159);
            this.grpStore.Name = "grpStore";
            this.grpStore.Size = new System.Drawing.Size(314, 101);
            this.grpStore.TabIndex = 0;
            this.grpStore.TabStop = false;
            // 
            // cmbBranch
            // 
            this.cmbBranch.Enabled = false;
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(101, 29);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(184, 21);
            this.cmbBranch.TabIndex = 0;
            this.cmbBranch.SelectedIndexChanged += new System.EventHandler(this.cbxGodown_SelectedIndexChanged);
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.ForeColor = System.Drawing.Color.White;
            this.lblBranch.Location = new System.Drawing.Point(51, 31);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(44, 13);
            this.lblBranch.TabIndex = 15;
            this.lblBranch.Text = "Branch:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(101, 61);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(184, 21);
            this.cmbCategory.TabIndex = 0;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            this.cmbCategory.SelectedValueChanged += new System.EventHandler(this.cmbCategory_SelectedValueChanged);
            this.cmbCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCategory_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Category Name:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBarCode);
            this.groupBox2.Controls.Add(this.txtItemID);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(12, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(355, 80);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // txtBarCode
            // 
            this.txtBarCode.Location = new System.Drawing.Point(63, 54);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(30, 20);
            this.txtBarCode.TabIndex = 1;
            this.txtBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCategory_KeyDown);
            // 
            // txtItemID
            // 
            this.txtItemID.Location = new System.Drawing.Point(63, 28);
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.Size = new System.Drawing.Size(30, 20);
            this.txtItemID.TabIndex = 0;
            this.txtItemID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCategory_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(-2, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Bar Code:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(16, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Item ID:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbDesign);
            this.groupBox1.Controls.Add(this.cmbSize);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbCompanyName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbProductName);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 159);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(135, 154);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product Detail";
            this.groupBox1.Visible = false;
            // 
            // cmbDesign
            // 
            this.cmbDesign.FormattingEnabled = true;
            this.cmbDesign.Location = new System.Drawing.Point(82, 46);
            this.cmbDesign.Name = "cmbDesign";
            this.cmbDesign.Size = new System.Drawing.Size(28, 21);
            this.cmbDesign.TabIndex = 3;
            this.cmbDesign.TextChanged += new System.EventHandler(this.cbxDesign_TextChanged);
            this.cmbDesign.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCategory_KeyDown);
            // 
            // cmbSize
            // 
            this.cmbSize.FormattingEnabled = true;
            this.cmbSize.Location = new System.Drawing.Point(84, 107);
            this.cmbSize.Name = "cmbSize";
            this.cmbSize.Size = new System.Drawing.Size(26, 21);
            this.cmbSize.TabIndex = 4;
            this.cmbSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCategory_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Manufacturer:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Size:";
            // 
            // cmbCompanyName
            // 
            this.cmbCompanyName.FormattingEnabled = true;
            this.cmbCompanyName.Location = new System.Drawing.Point(82, 19);
            this.cmbCompanyName.Name = "cmbCompanyName";
            this.cmbCompanyName.Size = new System.Drawing.Size(28, 21);
            this.cmbCompanyName.TabIndex = 1;
            this.cmbCompanyName.TextChanged += new System.EventHandler(this.cbxCompanyName_TextChanged);
            this.cmbCompanyName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCategory_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Product Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Design:";
            // 
            // cmbProductName
            // 
            this.cmbProductName.FormattingEnabled = true;
            this.cmbProductName.Location = new System.Drawing.Point(84, 80);
            this.cmbProductName.Name = "cmbProductName";
            this.cmbProductName.Size = new System.Drawing.Size(26, 21);
            this.cmbProductName.TabIndex = 2;
            this.cmbProductName.TextChanged += new System.EventHandler(this.cbxProductName_TextChanged);
            this.cmbProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCategory_KeyDown);
            // 
            // FrmCurrentStoreStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(221)))), ((int)(((byte)(190)))));
            this.ClientSize = new System.Drawing.Size(928, 511);
            this.Controls.Add(this.FrmCurrentStock_Fill_Panel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmCurrentStoreStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Current Stock With Value";
            this.Load += new System.EventHandler(this.FrmCurrentStock_Load);
            this.Leave += new System.EventHandler(this.FrmCurrentStoreStock_Leave);
            this.FrmCurrentStock_Fill_Panel.ResumeLayout(false);
            this.grpParty.ResumeLayout(false);
            this.grpParty.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).EndInit();
            this.panel2.ResumeLayout(false);
            this.grpStore.ResumeLayout(false);
            this.grpStore.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel FrmCurrentStock_Fill_Panel;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbDesign;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbProductName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCompanyName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.TextBox txtItemID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grpStore;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grpParty;
        private System.Windows.Forms.CheckBox chkAllVendor;
        private DGV.DGV Grd;
    }
}
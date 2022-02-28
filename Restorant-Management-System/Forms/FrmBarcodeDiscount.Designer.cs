namespace Restorant_Management_System.Forms
{
    partial class FrmBarcodeDiscount
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
            this.Grd = new DGV.DGV();
            this.button1 = new System.Windows.Forms.Button();
            this.PnlBtn = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.GrdCategory = new DGV.DGV();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtCategorySearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnAddBarcodes = new System.Windows.Forms.Button();
            this.GrdBranch = new DGV.DGV();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.chkExcel = new System.Windows.Forms.CheckBox();
            this.grbExcel = new System.Windows.Forms.GroupBox();
            this.txtFileNmae = new System.Windows.Forms.TextBox();
            this.btnBrowes = new System.Windows.Forms.Button();
            this.txtFileID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).BeginInit();
            this.PnlBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdBranch)).BeginInit();
            this.grbExcel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grd
            // 
            this.Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grd.Location = new System.Drawing.Point(353, 91);
            this.Grd.MoveLeftToRight = false;
            this.Grd.Name = "Grd";
            this.Grd.Size = new System.Drawing.Size(776, 332);
            this.Grd.TabIndex = 0;
            this.Grd.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.Grd_RowsAdded);
            this.Grd.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.Grd_RowsRemoved);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(2, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 21);
            this.button1.TabIndex = 21;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PnlBtn
            // 
            this.PnlBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PnlBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(80)))), ((int)(((byte)(137)))));
            this.PnlBtn.Controls.Add(this.btnDelete);
            this.PnlBtn.Controls.Add(this.btnClose);
            this.PnlBtn.Controls.Add(this.btnNew);
            this.PnlBtn.Controls.Add(this.btnEdit);
            this.PnlBtn.Controls.Add(this.btnSelect);
            this.PnlBtn.Controls.Add(this.btnSave);
            this.PnlBtn.Location = new System.Drawing.Point(173, 584);
            this.PnlBtn.Name = "PnlBtn";
            this.PnlBtn.Size = new System.Drawing.Size(424, 41);
            this.PnlBtn.TabIndex = 22;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(176, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(66, 33);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(126)))), ((int)(((byte)(50)))));
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(310, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(71, 33);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnNew.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(40, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(68, 33);
            this.btnNew.TabIndex = 6;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnEdit.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(108, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(68, 33);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnSelect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSelect.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.ForeColor = System.Drawing.Color.White;
            this.btnSelect.Location = new System.Drawing.Point(-28, -1);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(47, 34);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Visible = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(242, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 33);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // GrdCategory
            // 
            this.GrdCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdCategory.Location = new System.Drawing.Point(12, 87);
            this.GrdCategory.MoveLeftToRight = false;
            this.GrdCategory.Name = "GrdCategory";
            this.GrdCategory.Size = new System.Drawing.Size(299, 333);
            this.GrdCategory.TabIndex = 23;
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDepartment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(78, 57);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(233, 21);
            this.cmbDepartment.TabIndex = 157;
            this.cmbDepartment.SelectedIndexChanged += new System.EventHandler(this.cmbDepartment_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(12, 61);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(62, 13);
            this.label19.TabIndex = 156;
            this.label19.Text = "Department";
            // 
            // txtCategorySearch
            // 
            this.txtCategorySearch.Location = new System.Drawing.Point(34, 165);
            this.txtCategorySearch.Name = "txtCategorySearch";
            this.txtCategorySearch.Size = new System.Drawing.Size(233, 20);
            this.txtCategorySearch.TabIndex = 158;
            this.txtCategorySearch.Visible = false;
            this.txtCategorySearch.TextChanged += new System.EventHandler(this.txtCategorySearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(31, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 159;
            this.label1.Text = "Search";
            this.label1.Visible = false;
            // 
            // BtnAddBarcodes
            // 
            this.BtnAddBarcodes.Location = new System.Drawing.Point(314, 176);
            this.BtnAddBarcodes.Name = "BtnAddBarcodes";
            this.BtnAddBarcodes.Size = new System.Drawing.Size(36, 58);
            this.BtnAddBarcodes.TabIndex = 160;
            this.BtnAddBarcodes.Text = ">>";
            this.BtnAddBarcodes.UseVisualStyleBackColor = true;
            this.BtnAddBarcodes.Click += new System.EventHandler(this.BtnAddBarcodes_Click);
            // 
            // GrdBranch
            // 
            this.GrdBranch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdBranch.Location = new System.Drawing.Point(709, 428);
            this.GrdBranch.MoveLeftToRight = false;
            this.GrdBranch.Name = "GrdBranch";
            this.GrdBranch.Size = new System.Drawing.Size(420, 221);
            this.GrdBranch.TabIndex = 161;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkIsActive.Location = new System.Drawing.Point(161, 517);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(64, 17);
            this.chkIsActive.TabIndex = 162;
            this.chkIsActive.Text = "IsActive";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(375, 482);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 13);
            this.label10.TabIndex = 166;
            this.label10.Text = "To";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(118, 481);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 165;
            this.label9.Text = "From";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(404, 478);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(193, 20);
            this.dtpToDate.TabIndex = 164;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(161, 478);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(193, 20);
            this.dtpFromDate.TabIndex = 163;
            // 
            // chkExcel
            // 
            this.chkExcel.AutoSize = true;
            this.chkExcel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkExcel.Location = new System.Drawing.Point(353, 62);
            this.chkExcel.Name = "chkExcel";
            this.chkExcel.Size = new System.Drawing.Size(117, 17);
            this.chkExcel.TabIndex = 167;
            this.chkExcel.Text = "Choose From Excel";
            this.chkExcel.UseVisualStyleBackColor = true;
            this.chkExcel.CheckedChanged += new System.EventHandler(this.chkExcel_CheckedChanged);
            // 
            // grbExcel
            // 
            this.grbExcel.Controls.Add(this.txtFileNmae);
            this.grbExcel.Controls.Add(this.btnBrowes);
            this.grbExcel.Location = new System.Drawing.Point(476, 45);
            this.grbExcel.Name = "grbExcel";
            this.grbExcel.Size = new System.Drawing.Size(653, 44);
            this.grbExcel.TabIndex = 168;
            this.grbExcel.TabStop = false;
            // 
            // txtFileNmae
            // 
            this.txtFileNmae.Location = new System.Drawing.Point(17, 15);
            this.txtFileNmae.Name = "txtFileNmae";
            this.txtFileNmae.Size = new System.Drawing.Size(536, 20);
            this.txtFileNmae.TabIndex = 3;
            // 
            // btnBrowes
            // 
            this.btnBrowes.Location = new System.Drawing.Point(562, 13);
            this.btnBrowes.Name = "btnBrowes";
            this.btnBrowes.Size = new System.Drawing.Size(75, 23);
            this.btnBrowes.TabIndex = 2;
            this.btnBrowes.Text = "Choose File";
            this.btnBrowes.UseVisualStyleBackColor = true;
            this.btnBrowes.Click += new System.EventHandler(this.btnBrowes_Click);
            // 
            // txtFileID
            // 
            this.txtFileID.Location = new System.Drawing.Point(447, 12);
            this.txtFileID.Name = "txtFileID";
            this.txtFileID.ReadOnly = true;
            this.txtFileID.Size = new System.Drawing.Size(121, 20);
            this.txtFileID.TabIndex = 170;
            this.txtFileID.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(391, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 169;
            this.label6.Text = "File ID:";
            // 
            // FrmBarcodeDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(80)))), ((int)(((byte)(137)))));
            this.ClientSize = new System.Drawing.Size(1142, 657);
            this.Controls.Add(this.txtFileID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.grbExcel);
            this.Controls.Add(this.chkExcel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.GrdBranch);
            this.Controls.Add(this.BtnAddBarcodes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCategorySearch);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.GrdCategory);
            this.Controls.Add(this.PnlBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Grd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmBarcodeDiscount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barcode Discount";
            this.Load += new System.EventHandler(this.FrmBarcodeDiscount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).EndInit();
            this.PnlBtn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdBranch)).EndInit();
            this.grbExcel.ResumeLayout(false);
            this.grbExcel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DGV.DGV Grd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel PnlBtn;
        private System.Windows.Forms.Button btnClose;
        private DGV.DGV GrdCategory;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtCategorySearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnAddBarcodes;
        private DGV.DGV GrdBranch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.CheckBox chkExcel;
        private System.Windows.Forms.GroupBox grbExcel;
        private System.Windows.Forms.TextBox txtFileNmae;
        private System.Windows.Forms.Button btnBrowes;
        private System.Windows.Forms.TextBox txtFileID;
        private System.Windows.Forms.Label label6;
    }
}
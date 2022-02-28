namespace Restorant_Management_System.Report_Forms
{
    partial class frmValuationSale
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
            this.PnlMain = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkAllVendor = new System.Windows.Forms.CheckBox();
            this.Grd = new DGV.DGV();
            this.lblBank = new System.Windows.Forms.Label();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.grpDiscount = new System.Windows.Forms.GroupBox();
            this.rdbWithouDiscount = new System.Windows.Forms.RadioButton();
            this.rdbDiscount = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.gbADay = new System.Windows.Forms.GroupBox();
            this.dtpADay = new System.Windows.Forms.DateTimePicker();
            this.gbDateRange = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.rdbToday = new System.Windows.Forms.RadioButton();
            this.rdbAllDates = new System.Windows.Forms.RadioButton();
            this.rdbADay = new System.Windows.Forms.RadioButton();
            this.rdbDateRange = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.PnlMain.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).BeginInit();
            this.grpDiscount.SuspendLayout();
            this.gbADay.SuspendLayout();
            this.gbDateRange.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.BackColor = System.Drawing.Color.SteelBlue;
            this.PnlMain.Controls.Add(this.panel1);
            this.PnlMain.Controls.Add(this.panel2);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(923, 504);
            this.PnlMain.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.chkAllVendor);
            this.panel1.Controls.Add(this.Grd);
            this.panel1.Controls.Add(this.lblBank);
            this.panel1.Controls.Add(this.cmbBank);
            this.panel1.Controls.Add(this.grpDiscount);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbBranch);
            this.panel1.Controls.Add(this.gbADay);
            this.panel1.Controls.Add(this.gbDateRange);
            this.panel1.Controls.Add(this.rdbToday);
            this.panel1.Controls.Add(this.rdbAllDates);
            this.panel1.Controls.Add(this.rdbADay);
            this.panel1.Controls.Add(this.rdbDateRange);
            this.panel1.Location = new System.Drawing.Point(78, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 394);
            this.panel1.TabIndex = 30;
            // 
            // chkAllVendor
            // 
            this.chkAllVendor.AutoSize = true;
            this.chkAllVendor.ForeColor = System.Drawing.Color.White;
            this.chkAllVendor.Location = new System.Drawing.Point(377, 60);
            this.chkAllVendor.Name = "chkAllVendor";
            this.chkAllVendor.Size = new System.Drawing.Size(79, 17);
            this.chkAllVendor.TabIndex = 160;
            this.chkAllVendor.Text = "All Vendors";
            this.chkAllVendor.UseVisualStyleBackColor = true;
            this.chkAllVendor.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
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
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grd.DefaultCellStyle = dataGridViewCellStyle2;
            this.Grd.Location = new System.Drawing.Point(355, 88);
            this.Grd.MoveLeftToRight = true;
            this.Grd.MultiSelect = false;
            this.Grd.Name = "Grd";
            this.Grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Grd.Size = new System.Drawing.Size(400, 295);
            this.Grd.StandardTab = true;
            this.Grd.TabIndex = 159;
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.ForeColor = System.Drawing.Color.White;
            this.lblBank.Location = new System.Drawing.Point(13, 156);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(41, 13);
            this.lblBank.TabIndex = 157;
            this.lblBank.Text = "Bank : ";
            // 
            // cmbBank
            // 
            this.cmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(66, 154);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(240, 21);
            this.cmbBank.TabIndex = 156;
            // 
            // grpDiscount
            // 
            this.grpDiscount.Controls.Add(this.rdbWithouDiscount);
            this.grpDiscount.Controls.Add(this.rdbDiscount);
            this.grpDiscount.Location = new System.Drawing.Point(63, 260);
            this.grpDiscount.Name = "grpDiscount";
            this.grpDiscount.Size = new System.Drawing.Size(194, 64);
            this.grpDiscount.TabIndex = 155;
            this.grpDiscount.TabStop = false;
            this.grpDiscount.Visible = false;
            // 
            // rdbWithouDiscount
            // 
            this.rdbWithouDiscount.AutoSize = true;
            this.rdbWithouDiscount.ForeColor = System.Drawing.Color.White;
            this.rdbWithouDiscount.Location = new System.Drawing.Point(7, 36);
            this.rdbWithouDiscount.Name = "rdbWithouDiscount";
            this.rdbWithouDiscount.Size = new System.Drawing.Size(155, 17);
            this.rdbWithouDiscount.TabIndex = 29;
            this.rdbWithouDiscount.TabStop = true;
            this.rdbWithouDiscount.Text = "Without Discount Barcodes";
            this.rdbWithouDiscount.UseVisualStyleBackColor = true;
            // 
            // rdbDiscount
            // 
            this.rdbDiscount.AutoSize = true;
            this.rdbDiscount.ForeColor = System.Drawing.Color.White;
            this.rdbDiscount.Location = new System.Drawing.Point(7, 10);
            this.rdbDiscount.Name = "rdbDiscount";
            this.rdbDiscount.Size = new System.Drawing.Size(115, 17);
            this.rdbDiscount.TabIndex = 28;
            this.rdbDiscount.TabStop = true;
            this.rdbDiscount.Text = "Discount Barcodes";
            this.rdbDiscount.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(14, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 154;
            this.label3.Text = "Branch : ";
            // 
            // cmbBranch
            // 
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(66, 188);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(240, 21);
            this.cmbBranch.TabIndex = 153;
            // 
            // gbADay
            // 
            this.gbADay.Controls.Add(this.dtpADay);
            this.gbADay.ForeColor = System.Drawing.Color.White;
            this.gbADay.Location = new System.Drawing.Point(701, 44);
            this.gbADay.Name = "gbADay";
            this.gbADay.Size = new System.Drawing.Size(55, 22);
            this.gbADay.TabIndex = 28;
            this.gbADay.TabStop = false;
            this.gbADay.Text = "A Day";
            // 
            // dtpADay
            // 
            this.dtpADay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpADay.Location = new System.Drawing.Point(47, 23);
            this.dtpADay.Name = "dtpADay";
            this.dtpADay.Size = new System.Drawing.Size(101, 20);
            this.dtpADay.TabIndex = 10;
            // 
            // gbDateRange
            // 
            this.gbDateRange.Controls.Add(this.label8);
            this.gbDateRange.Controls.Add(this.dtpTo);
            this.gbDateRange.Controls.Add(this.label9);
            this.gbDateRange.Controls.Add(this.dtpFrom);
            this.gbDateRange.ForeColor = System.Drawing.Color.White;
            this.gbDateRange.Location = new System.Drawing.Point(101, 60);
            this.gbDateRange.Name = "gbDateRange";
            this.gbDateRange.Size = new System.Drawing.Size(225, 70);
            this.gbDateRange.TabIndex = 27;
            this.gbDateRange.TabStop = false;
            this.gbDateRange.Text = "Date Range";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(113, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "To";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(112, 41);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(101, 20);
            this.dtpTo.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "From";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(8, 42);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(101, 20);
            this.dtpFrom.TabIndex = 10;
            // 
            // rdbToday
            // 
            this.rdbToday.AutoSize = true;
            this.rdbToday.ForeColor = System.Drawing.Color.White;
            this.rdbToday.Location = new System.Drawing.Point(701, 23);
            this.rdbToday.Name = "rdbToday";
            this.rdbToday.Size = new System.Drawing.Size(55, 17);
            this.rdbToday.TabIndex = 26;
            this.rdbToday.TabStop = true;
            this.rdbToday.Text = "Today";
            this.rdbToday.UseVisualStyleBackColor = true;
            this.rdbToday.Visible = false;
            // 
            // rdbAllDates
            // 
            this.rdbAllDates.AutoSize = true;
            this.rdbAllDates.ForeColor = System.Drawing.Color.White;
            this.rdbAllDates.Location = new System.Drawing.Point(12, 18);
            this.rdbAllDates.Name = "rdbAllDates";
            this.rdbAllDates.Size = new System.Drawing.Size(67, 17);
            this.rdbAllDates.TabIndex = 23;
            this.rdbAllDates.TabStop = true;
            this.rdbAllDates.Text = "All Dates";
            this.rdbAllDates.UseVisualStyleBackColor = true;
            this.rdbAllDates.CheckedChanged += new System.EventHandler(this.rdbAllDates_CheckedChanged);
            // 
            // rdbADay
            // 
            this.rdbADay.AutoSize = true;
            this.rdbADay.ForeColor = System.Drawing.Color.White;
            this.rdbADay.Location = new System.Drawing.Point(701, 5);
            this.rdbADay.Name = "rdbADay";
            this.rdbADay.Size = new System.Drawing.Size(54, 17);
            this.rdbADay.TabIndex = 25;
            this.rdbADay.TabStop = true;
            this.rdbADay.Text = "A Day";
            this.rdbADay.UseVisualStyleBackColor = true;
            this.rdbADay.Visible = false;
            // 
            // rdbDateRange
            // 
            this.rdbDateRange.AutoSize = true;
            this.rdbDateRange.ForeColor = System.Drawing.Color.White;
            this.rdbDateRange.Location = new System.Drawing.Point(12, 60);
            this.rdbDateRange.Name = "rdbDateRange";
            this.rdbDateRange.Size = new System.Drawing.Size(83, 17);
            this.rdbDateRange.TabIndex = 24;
            this.rdbDateRange.TabStop = true;
            this.rdbDateRange.Text = "Date Range";
            this.rdbDateRange.UseVisualStyleBackColor = true;
            this.rdbDateRange.CheckedChanged += new System.EventHandler(this.rdbDateRange_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.btnPreview);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Location = new System.Drawing.Point(354, 444);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(228, 48);
            this.panel2.TabIndex = 22;
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
            this.btnPreview.Location = new System.Drawing.Point(79, 6);
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
            // 
            // frmValuationSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 504);
            this.Controls.Add(this.PnlMain);
            this.Name = "frmValuationSale";
            this.Text = "Report";
            this.Load += new System.EventHandler(this.frmValuationSale_Load);
            this.PnlMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).EndInit();
            this.grpDiscount.ResumeLayout(false);
            this.grpDiscount.PerformLayout();
            this.gbADay.ResumeLayout(false);
            this.gbDateRange.ResumeLayout(false);
            this.gbDateRange.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbADay;
        private System.Windows.Forms.DateTimePicker dtpADay;
        private System.Windows.Forms.GroupBox gbDateRange;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.RadioButton rdbToday;
        private System.Windows.Forms.RadioButton rdbAllDates;
        private System.Windows.Forms.RadioButton rdbADay;
        private System.Windows.Forms.RadioButton rdbDateRange;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.GroupBox grpDiscount;
        private System.Windows.Forms.RadioButton rdbWithouDiscount;
        private System.Windows.Forms.RadioButton rdbDiscount;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.ComboBox cmbBank;
        private DGV.DGV Grd;
        private System.Windows.Forms.CheckBox chkAllVendor;
    }
}
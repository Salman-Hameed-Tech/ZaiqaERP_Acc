namespace Restorant_Management_System.Report_Forms
{
    partial class frmStockAdjRpt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockAdjRpt));
            this.PnlMain = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBranch = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.gbADay = new System.Windows.Forms.GroupBox();
            this.dtpADay = new System.Windows.Forms.DateTimePicker();
            this.gbDateRange = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.btnSch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtItemID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbToday = new System.Windows.Forms.RadioButton();
            this.rdbADay = new System.Windows.Forms.RadioButton();
            this.rdbDateRange = new System.Windows.Forms.RadioButton();
            this.rdbAllDates = new System.Windows.Forms.RadioButton();
            this.PnlMain.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbADay.SuspendLayout();
            this.gbDateRange.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.BackColor = System.Drawing.Color.SteelBlue;
            this.PnlMain.Controls.Add(this.panel2);
            this.PnlMain.Controls.Add(this.panel1);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(941, 479);
            this.PnlMain.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.btnPreview);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Location = new System.Drawing.Point(366, 410);
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
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.lblBranch);
            this.panel1.Controls.Add(this.cmbBranch);
            this.panel1.Controls.Add(this.gbADay);
            this.panel1.Controls.Add(this.gbDateRange);
            this.panel1.Controls.Add(this.btnSch);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtItemName);
            this.panel1.Controls.Add(this.txtItemID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rdbToday);
            this.panel1.Controls.Add(this.rdbADay);
            this.panel1.Controls.Add(this.rdbDateRange);
            this.panel1.Controls.Add(this.rdbAllDates);
            this.panel1.Location = new System.Drawing.Point(175, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(642, 286);
            this.panel1.TabIndex = 1;
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.ForeColor = System.Drawing.Color.White;
            this.lblBranch.Location = new System.Drawing.Point(49, 232);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(50, 13);
            this.lblBranch.TabIndex = 156;
            this.lblBranch.Text = "Branch : ";
            // 
            // cmbBranch
            // 
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(105, 229);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(267, 21);
            this.cmbBranch.TabIndex = 155;
            // 
            // gbADay
            // 
            this.gbADay.Controls.Add(this.dtpADay);
            this.gbADay.ForeColor = System.Drawing.Color.White;
            this.gbADay.Location = new System.Drawing.Point(285, 16);
            this.gbADay.Name = "gbADay";
            this.gbADay.Size = new System.Drawing.Size(167, 41);
            this.gbADay.TabIndex = 14;
            this.gbADay.TabStop = false;
            this.gbADay.Text = "A Day";
            // 
            // dtpADay
            // 
            this.dtpADay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpADay.Location = new System.Drawing.Point(47, 12);
            this.dtpADay.Name = "dtpADay";
            this.dtpADay.Size = new System.Drawing.Size(101, 20);
            this.dtpADay.TabIndex = 10;
            // 
            // gbDateRange
            // 
            this.gbDateRange.Controls.Add(this.label4);
            this.gbDateRange.Controls.Add(this.dtpTo);
            this.gbDateRange.Controls.Add(this.label3);
            this.gbDateRange.Controls.Add(this.dtpFrom);
            this.gbDateRange.ForeColor = System.Drawing.Color.White;
            this.gbDateRange.Location = new System.Drawing.Point(144, 115);
            this.gbDateRange.Name = "gbDateRange";
            this.gbDateRange.Size = new System.Drawing.Size(244, 70);
            this.gbDateRange.TabIndex = 9;
            this.gbDateRange.TabStop = false;
            this.gbDateRange.Text = "Date Range";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(128, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "To";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(127, 42);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(101, 20);
            this.dtpTo.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "From";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(20, 42);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(101, 20);
            this.dtpFrom.TabIndex = 10;
            // 
            // btnSch
            // 
            this.btnSch.Image = ((System.Drawing.Image)(resources.GetObject("btnSch.Image")));
            this.btnSch.Location = new System.Drawing.Point(590, 82);
            this.btnSch.Name = "btnSch";
            this.btnSch.Size = new System.Drawing.Size(33, 23);
            this.btnSch.TabIndex = 8;
            this.btnSch.TabStop = false;
            this.btnSch.UseVisualStyleBackColor = true;
            this.btnSch.Click += new System.EventHandler(this.btnSch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(394, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Item Name";
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(456, 115);
            this.txtItemName.Multiline = true;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(170, 49);
            this.txtItemName.TabIndex = 6;
            // 
            // txtItemID
            // 
            this.txtItemID.Location = new System.Drawing.Point(456, 84);
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.Size = new System.Drawing.Size(128, 20);
            this.txtItemID.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(394, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Item ID";
            // 
            // rdbToday
            // 
            this.rdbToday.AutoSize = true;
            this.rdbToday.ForeColor = System.Drawing.Color.White;
            this.rdbToday.Location = new System.Drawing.Point(206, 40);
            this.rdbToday.Name = "rdbToday";
            this.rdbToday.Size = new System.Drawing.Size(55, 17);
            this.rdbToday.TabIndex = 3;
            this.rdbToday.TabStop = true;
            this.rdbToday.Text = "Today";
            this.rdbToday.UseVisualStyleBackColor = true;
            this.rdbToday.Visible = false;
            this.rdbToday.CheckedChanged += new System.EventHandler(this.rdbToday_CheckedChanged);
            // 
            // rdbADay
            // 
            this.rdbADay.AutoSize = true;
            this.rdbADay.ForeColor = System.Drawing.Color.White;
            this.rdbADay.Location = new System.Drawing.Point(206, 16);
            this.rdbADay.Name = "rdbADay";
            this.rdbADay.Size = new System.Drawing.Size(54, 17);
            this.rdbADay.TabIndex = 2;
            this.rdbADay.TabStop = true;
            this.rdbADay.Text = "A Day";
            this.rdbADay.UseVisualStyleBackColor = true;
            this.rdbADay.Visible = false;
            this.rdbADay.CheckedChanged += new System.EventHandler(this.rdbADay_CheckedChanged);
            // 
            // rdbDateRange
            // 
            this.rdbDateRange.AutoSize = true;
            this.rdbDateRange.ForeColor = System.Drawing.Color.White;
            this.rdbDateRange.Location = new System.Drawing.Point(55, 115);
            this.rdbDateRange.Name = "rdbDateRange";
            this.rdbDateRange.Size = new System.Drawing.Size(83, 17);
            this.rdbDateRange.TabIndex = 1;
            this.rdbDateRange.TabStop = true;
            this.rdbDateRange.Text = "Date Range";
            this.rdbDateRange.UseVisualStyleBackColor = true;
            this.rdbDateRange.CheckedChanged += new System.EventHandler(this.rdbDateRange_CheckedChanged);
            // 
            // rdbAllDates
            // 
            this.rdbAllDates.AutoSize = true;
            this.rdbAllDates.ForeColor = System.Drawing.Color.White;
            this.rdbAllDates.Location = new System.Drawing.Point(55, 83);
            this.rdbAllDates.Name = "rdbAllDates";
            this.rdbAllDates.Size = new System.Drawing.Size(67, 17);
            this.rdbAllDates.TabIndex = 0;
            this.rdbAllDates.TabStop = true;
            this.rdbAllDates.Text = "All Dates";
            this.rdbAllDates.UseVisualStyleBackColor = true;
            this.rdbAllDates.CheckedChanged += new System.EventHandler(this.rdbAllDates_CheckedChanged);
            // 
            // frmStockAdjRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 479);
            this.Controls.Add(this.PnlMain);
            this.Name = "frmStockAdjRpt";
            this.Text = "Item Ledger";
            this.Load += new System.EventHandler(this.frmStockAdjRpt_Load);
            this.PnlMain.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbADay.ResumeLayout(false);
            this.gbDateRange.ResumeLayout(false);
            this.gbDateRange.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.TextBox txtItemID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbToday;
        private System.Windows.Forms.RadioButton rdbADay;
        private System.Windows.Forms.RadioButton rdbDateRange;
        private System.Windows.Forms.RadioButton rdbAllDates;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSch;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.GroupBox gbDateRange;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.GroupBox gbADay;
        private System.Windows.Forms.DateTimePicker dtpADay;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.ComboBox cmbBranch;
    }
}
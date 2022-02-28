namespace FFMS.Forms
{
    partial class FrmDaySettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDaySettings));
            this.btnDayEnd = new System.Windows.Forms.Button();
            this.btnDayStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
            this.cbxInvPrinter = new System.Windows.Forms.ComboBox();
            this.btnSeclect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDayEnd
            // 
            this.btnDayEnd.Location = new System.Drawing.Point(264, 143);
            this.btnDayEnd.Name = "btnDayEnd";
            this.btnDayEnd.Size = new System.Drawing.Size(67, 20);
            this.btnDayEnd.TabIndex = 11;
            this.btnDayEnd.Text = "Day End";
            this.btnDayEnd.UseVisualStyleBackColor = true;
            this.btnDayEnd.Click += new System.EventHandler(this.btnDayEnd_Click);
            // 
            // btnDayStart
            // 
            this.btnDayStart.Location = new System.Drawing.Point(112, 232);
            this.btnDayStart.Name = "btnDayStart";
            this.btnDayStart.Size = new System.Drawing.Size(109, 24);
            this.btnDayStart.TabIndex = 9;
            this.btnDayStart.Text = "Day Start";
            this.btnDayStart.UseVisualStyleBackColor = true;
            this.btnDayStart.UseWaitCursor = true;
            this.btnDayStart.Visible = false;
            this.btnDayStart.Click += new System.EventHandler(this.btnDayStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(6, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Running Date:";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "";
            this.dtpDate.Enabled = false;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(85, 143);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(173, 20);
            this.dtpDate.TabIndex = 8;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(358, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnClose
            // 
            this.tsbtnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbtnClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnClose.Image")));
            this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnClose.Name = "tsbtnClose";
            this.tsbtnClose.Size = new System.Drawing.Size(55, 22);
            this.tsbtnClose.Text = "&Close";
            this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
            // 
            // cbxInvPrinter
            // 
            this.cbxInvPrinter.FormattingEnabled = true;
            this.cbxInvPrinter.Location = new System.Drawing.Point(85, 177);
            this.cbxInvPrinter.Name = "cbxInvPrinter";
            this.cbxInvPrinter.Size = new System.Drawing.Size(173, 21);
            this.cbxInvPrinter.TabIndex = 13;
            this.cbxInvPrinter.Leave += new System.EventHandler(this.cbxInvPrinter_Leave);
            // 
            // btnSeclect
            // 
            this.btnSeclect.Location = new System.Drawing.Point(264, 178);
            this.btnSeclect.Name = "btnSeclect";
            this.btnSeclect.Size = new System.Drawing.Size(67, 20);
            this.btnSeclect.TabIndex = 14;
            this.btnSeclect.Text = "Select";
            this.btnSeclect.UseVisualStyleBackColor = true;
            this.btnSeclect.Click += new System.EventHandler(this.btnSeclect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(32, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Printers:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(32, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 156;
            this.label3.Text = "Branch : ";
            // 
            // cmbBranch
            // 
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.Enabled = false;
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(85, 82);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(246, 21);
            this.cmbBranch.TabIndex = 155;
            this.cmbBranch.SelectedIndexChanged += new System.EventHandler(this.cmbBranch_SelectedIndexChanged);
            this.cmbBranch.SelectedValueChanged += new System.EventHandler(this.cmbBranch_SelectedValueChanged);
            // 
            // FrmDaySettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(358, 268);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbBranch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSeclect);
            this.Controls.Add(this.cbxInvPrinter);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnDayEnd);
            this.Controls.Add(this.btnDayStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpDate);
            this.Name = "FrmDaySettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "41";
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.FrmDaySettings_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDayEnd;
        private System.Windows.Forms.Button btnDayStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnClose;
        private System.Windows.Forms.ComboBox cbxInvPrinter;
        private System.Windows.Forms.Button btnSeclect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBranch;
    }
}
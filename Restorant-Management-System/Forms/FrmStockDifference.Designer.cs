namespace Restorant_Management_System.Forms
{
    partial class FrmStockDifference
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
            this.grbExcel = new System.Windows.Forms.GroupBox();
            this.txtFileNmae = new System.Windows.Forms.TextBox();
            this.btnBrowes = new System.Windows.Forms.Button();
            this.Grd = new DGV.DGV();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.grbExcel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).BeginInit();
            this.SuspendLayout();
            // 
            // grbExcel
            // 
            this.grbExcel.Controls.Add(this.txtFileNmae);
            this.grbExcel.Controls.Add(this.btnBrowes);
            this.grbExcel.Location = new System.Drawing.Point(386, 30);
            this.grbExcel.Name = "grbExcel";
            this.grbExcel.Size = new System.Drawing.Size(653, 44);
            this.grbExcel.TabIndex = 169;
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
            // Grd
            // 
            this.Grd.AllowUserToAddRows = false;
            this.Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grd.Location = new System.Drawing.Point(12, 81);
            this.Grd.MoveLeftToRight = false;
            this.Grd.Name = "Grd";
            this.Grd.ReadOnly = true;
            this.Grd.Size = new System.Drawing.Size(1031, 332);
            this.Grd.TabIndex = 170;
            this.Grd.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.Grd_RowsAdded);
            this.Grd.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.Grd_RowsRemoved);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(968, 430);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 171;
            this.button1.Text = "Print";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(26, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 173;
            this.label3.Text = "Branch : ";
            // 
            // cmbBranch
            // 
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(78, 44);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(212, 21);
            this.cmbBranch.TabIndex = 172;
            this.cmbBranch.SelectedIndexChanged += new System.EventHandler(this.cmbBranch_SelectedIndexChanged);
            // 
            // FrmStockDifference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1055, 480);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbBranch);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Grd);
            this.Controls.Add(this.grbExcel);
            this.Name = "FrmStockDifference";
            this.Text = "Stock Difference";
            this.Load += new System.EventHandler(this.FrmStockDifference_Load);
            this.grbExcel.ResumeLayout(false);
            this.grbExcel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbExcel;
        private System.Windows.Forms.TextBox txtFileNmae;
        private System.Windows.Forms.Button btnBrowes;
        private DGV.DGV Grd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBranch;
    }
}
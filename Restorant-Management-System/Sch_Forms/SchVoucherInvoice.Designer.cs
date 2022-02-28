namespace Restorant_Management_System.Sch_Forms
{
    partial class SchVoucherInvoice
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
            this.grdTemp = new DGV.DGV();
            this.Grd = new DGV.DGV();
            this.PnlBtn = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnTotal = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).BeginInit();
            this.PnlBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdTemp
            // 
            this.grdTemp.AllowUserToAddRows = false;
            this.grdTemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTemp.Location = new System.Drawing.Point(1, 2);
            this.grdTemp.MoveLeftToRight = true;
            this.grdTemp.Name = "grdTemp";
            this.grdTemp.Size = new System.Drawing.Size(938, 61);
            this.grdTemp.StandardTab = true;
            this.grdTemp.TabIndex = 1;
            this.grdTemp.EditValueChanged += new System.EventHandler(this.grdTemp_EditValueChanged);
            // 
            // Grd
            // 
            this.Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grd.ColumnHeadersVisible = false;
            this.Grd.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.Grd.Location = new System.Drawing.Point(1, 49);
            this.Grd.MoveLeftToRight = false;
            this.Grd.Name = "Grd";
            this.Grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grd.Size = new System.Drawing.Size(938, 343);
            this.Grd.StandardTab = true;
            this.Grd.TabIndex = 2;
            this.Grd.DoubleClick += new System.EventHandler(this.Grd_DoubleClick);
            // 
            // PnlBtn
            // 
            this.PnlBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PnlBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(80)))), ((int)(((byte)(137)))));
            this.PnlBtn.Controls.Add(this.btnClose);
            this.PnlBtn.Controls.Add(this.btnSelect);
            this.PnlBtn.Location = new System.Drawing.Point(375, 398);
            this.PnlBtn.Name = "PnlBtn";
            this.PnlBtn.Size = new System.Drawing.Size(216, 41);
            this.PnlBtn.TabIndex = 8;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(126)))), ((int)(((byte)(50)))));
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(115, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 34);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnSelect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSelect.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.ForeColor = System.Drawing.Color.White;
            this.btnSelect.Location = new System.Drawing.Point(16, 4);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(89, 34);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnTotal
            // 
            this.btnTotal.Location = new System.Drawing.Point(865, 407);
            this.btnTotal.Name = "btnTotal";
            this.btnTotal.Size = new System.Drawing.Size(74, 27);
            this.btnTotal.TabIndex = 10;
            this.btnTotal.Text = "Total";
            this.btnTotal.UseVisualStyleBackColor = true;
            this.btnTotal.Click += new System.EventHandler(this.btnTotal_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(770, 411);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(89, 20);
            this.txtTotal.TabIndex = 9;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotal.TextChanged += new System.EventHandler(this.txtTotal_TextChanged);
            // 
            // SchVoucherInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(943, 450);
            this.Controls.Add(this.btnTotal);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.PnlBtn);
            this.Controls.Add(this.Grd);
            this.Controls.Add(this.grdTemp);
            this.Name = "SchVoucherInvoice";
            this.Text = "SchVoucherInvoice";
            this.Load += new System.EventHandler(this.SchVoucherInvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).EndInit();
            this.PnlBtn.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DGV.DGV grdTemp;
        private DGV.DGV Grd;
        private System.Windows.Forms.Panel PnlBtn;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnTotal;
        private System.Windows.Forms.TextBox txtTotal;
    }
}
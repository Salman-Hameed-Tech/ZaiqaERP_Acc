namespace Restorant_Management_System.Sch_Forms
{
    partial class SchVoucher
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
            this.lblHeading = new System.Windows.Forms.Label();
            this.grdTemp = new DGV.DGV();
            this.Grd = new DGV.DGV();
            this.GrdDetail = new DGV.DGV();
            this.PnlBtn = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.Bsrc = new System.Windows.Forms.BindingSource(this.components);
            this.txtCredit = new System.Windows.Forms.TextBox();
            this.txtDebit = new System.Windows.Forms.TextBox();
            this.lblCredit = new System.Windows.Forms.Label();
            this.lblDebit = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdDetail)).BeginInit();
            this.PnlBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Bsrc)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.ForeColor = System.Drawing.Color.White;
            this.lblHeading.Location = new System.Drawing.Point(3, 9);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(122, 29);
            this.lblHeading.TabIndex = 95;
            this.lblHeading.Text = "Vouchers";
            // 
            // grdTemp
            // 
            this.grdTemp.AllowUserToAddRows = false;
            this.grdTemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTemp.Location = new System.Drawing.Point(8, 52);
            this.grdTemp.MoveLeftToRight = true;
            this.grdTemp.Name = "grdTemp";
            this.grdTemp.Size = new System.Drawing.Size(502, 61);
            this.grdTemp.StandardTab = true;
            this.grdTemp.TabIndex = 96;
            this.grdTemp.EditValueChanged += new System.EventHandler(this.grdTemp_EditValueChanged);
            this.grdTemp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdTemp_KeyDown);
            // 
            // Grd
            // 
            this.Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grd.ColumnHeadersVisible = false;
            this.Grd.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Grd.Location = new System.Drawing.Point(8, 94);
            this.Grd.MoveLeftToRight = false;
            this.Grd.Name = "Grd";
            this.Grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grd.Size = new System.Drawing.Size(502, 273);
            this.Grd.StandardTab = true;
            this.Grd.TabIndex = 97;
            this.Grd.SelectionChanged += new System.EventHandler(this.Grd_SelectionChanged);
            this.Grd.Click += new System.EventHandler(this.Grd_Click);
            this.Grd.DoubleClick += new System.EventHandler(this.Grd_DoubleClick);
            // 
            // GrdDetail
            // 
            this.GrdDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GrdDetail.Location = new System.Drawing.Point(530, 11);
            this.GrdDetail.MoveLeftToRight = false;
            this.GrdDetail.Name = "GrdDetail";
            this.GrdDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdDetail.Size = new System.Drawing.Size(597, 358);
            this.GrdDetail.StandardTab = true;
            this.GrdDetail.TabIndex = 98;
            this.GrdDetail.DoubleClick += new System.EventHandler(this.GrdDetail_DoubleClick);
            // 
            // PnlBtn
            // 
            this.PnlBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PnlBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.PnlBtn.Controls.Add(this.btnClose);
            this.PnlBtn.Controls.Add(this.btnSelect);
            this.PnlBtn.Location = new System.Drawing.Point(482, 443);
            this.PnlBtn.Name = "PnlBtn";
            this.PnlBtn.Size = new System.Drawing.Size(216, 41);
            this.PnlBtn.TabIndex = 99;
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
            // Bsrc
            // 
            this.Bsrc.DataSource = typeof(Common.Item);
            // 
            // txtCredit
            // 
            this.txtCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCredit.Location = new System.Drawing.Point(1026, 375);
            this.txtCredit.Name = "txtCredit";
            this.txtCredit.ReadOnly = true;
            this.txtCredit.Size = new System.Drawing.Size(100, 20);
            this.txtCredit.TabIndex = 117;
            this.txtCredit.TabStop = false;
            this.txtCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDebit
            // 
            this.txtDebit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDebit.Location = new System.Drawing.Point(852, 375);
            this.txtDebit.Name = "txtDebit";
            this.txtDebit.ReadOnly = true;
            this.txtDebit.Size = new System.Drawing.Size(100, 20);
            this.txtDebit.TabIndex = 118;
            this.txtDebit.TabStop = false;
            this.txtDebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCredit
            // 
            this.lblCredit.AutoSize = true;
            this.lblCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCredit.ForeColor = System.Drawing.Color.White;
            this.lblCredit.Location = new System.Drawing.Point(977, 379);
            this.lblCredit.Name = "lblCredit";
            this.lblCredit.Size = new System.Drawing.Size(44, 13);
            this.lblCredit.TabIndex = 115;
            this.lblCredit.Text = "Credit:";
            // 
            // lblDebit
            // 
            this.lblDebit.AutoSize = true;
            this.lblDebit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebit.ForeColor = System.Drawing.Color.White;
            this.lblDebit.Location = new System.Drawing.Point(804, 379);
            this.lblDebit.Name = "lblDebit";
            this.lblDebit.Size = new System.Drawing.Size(41, 13);
            this.lblDebit.TabIndex = 116;
            this.lblDebit.Text = "Debit:";
            // 
            // SchVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1138, 491);
            this.Controls.Add(this.txtCredit);
            this.Controls.Add(this.txtDebit);
            this.Controls.Add(this.lblCredit);
            this.Controls.Add(this.lblDebit);
            this.Controls.Add(this.PnlBtn);
            this.Controls.Add(this.GrdDetail);
            this.Controls.Add(this.Grd);
            this.Controls.Add(this.grdTemp);
            this.Controls.Add(this.lblHeading);
            this.Name = "SchVoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SchVoucher";
            this.Load += new System.EventHandler(this.SchVoucher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdDetail)).EndInit();
            this.PnlBtn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Bsrc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeading;
        private DGV.DGV grdTemp;
        private DGV.DGV Grd;
        private DGV.DGV GrdDetail;
        private System.Windows.Forms.Panel PnlBtn;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.BindingSource Bsrc;
        private System.Windows.Forms.TextBox txtCredit;
        private System.Windows.Forms.TextBox txtDebit;
        private System.Windows.Forms.Label lblCredit;
        private System.Windows.Forms.Label lblDebit;
    }
}
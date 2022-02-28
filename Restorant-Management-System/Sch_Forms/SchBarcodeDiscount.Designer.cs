namespace Restorant_Management_System.Sch_Forms
{
    partial class SchBarcodeDiscount
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
            this.PnlBtn = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.GrdBranch = new DGV.DGV();
            this.Grd = new DGV.DGV();
            this.GrdTemp = new DGV.DGV();
            this.GrdDetail = new DGV.DGV();
            this.PnlBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdBranch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlBtn
            // 
            this.PnlBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PnlBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.PnlBtn.Controls.Add(this.btnClose);
            this.PnlBtn.Controls.Add(this.btnSelect);
            this.PnlBtn.Location = new System.Drawing.Point(325, 552);
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
            // GrdBranch
            // 
            this.GrdBranch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdBranch.Location = new System.Drawing.Point(534, 64);
            this.GrdBranch.MoveLeftToRight = false;
            this.GrdBranch.Name = "GrdBranch";
            this.GrdBranch.ReadOnly = true;
            this.GrdBranch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.GrdBranch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdBranch.Size = new System.Drawing.Size(317, 207);
            this.GrdBranch.TabIndex = 12;
            // 
            // Grd
            // 
            this.Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grd.ColumnHeadersVisible = false;
            this.Grd.Location = new System.Drawing.Point(14, 64);
            this.Grd.MoveLeftToRight = false;
            this.Grd.Name = "Grd";
            this.Grd.ReadOnly = true;
            this.Grd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grd.Size = new System.Drawing.Size(512, 207);
            this.Grd.TabIndex = 10;
            this.Grd.SelectionChanged += new System.EventHandler(this.Grd_SelectionChanged);
            this.Grd.Click += new System.EventHandler(this.Grd_Click);
            this.Grd.DoubleClick += new System.EventHandler(this.Grd_DoubleClick);
            // 
            // GrdTemp
            // 
            this.GrdTemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdTemp.Location = new System.Drawing.Point(14, 22);
            this.GrdTemp.MoveLeftToRight = false;
            this.GrdTemp.Name = "GrdTemp";
            this.GrdTemp.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.GrdTemp.Size = new System.Drawing.Size(512, 41);
            this.GrdTemp.TabIndex = 11;
            this.GrdTemp.EditValueChanged += new System.EventHandler(this.GrdTemp_EditValueChanged);
            // 
            // GrdDetail
            // 
            this.GrdDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdDetail.Location = new System.Drawing.Point(12, 277);
            this.GrdDetail.MoveLeftToRight = false;
            this.GrdDetail.Name = "GrdDetail";
            this.GrdDetail.ReadOnly = true;
            this.GrdDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.GrdDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdDetail.Size = new System.Drawing.Size(839, 252);
            this.GrdDetail.TabIndex = 13;
            // 
            // SchBarcodeDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(865, 606);
            this.Controls.Add(this.GrdDetail);
            this.Controls.Add(this.GrdBranch);
            this.Controls.Add(this.Grd);
            this.Controls.Add(this.GrdTemp);
            this.Controls.Add(this.PnlBtn);
            this.Name = "SchBarcodeDiscount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SchBarcodeDiscount";
            this.Load += new System.EventHandler(this.SchBarcodeDiscount_Load);
            this.PnlBtn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdBranch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlBtn;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSelect;
        private DGV.DGV GrdBranch;
        private DGV.DGV Grd;
        private DGV.DGV GrdTemp;
        private DGV.DGV GrdDetail;
    }
}
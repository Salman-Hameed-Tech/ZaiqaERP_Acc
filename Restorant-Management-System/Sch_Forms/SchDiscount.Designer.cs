namespace Restorant_Management_System.Sch_Forms
{
    partial class SchDiscount
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
            this.PnlMain = new System.Windows.Forms.Panel();
            this.PnlBtn = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.Grd = new DGV.DGV();
            this.GrdTemp = new DGV.DGV();
            this.GrdBranch = new DGV.DGV();
            this.PnlMain.SuspendLayout();
            this.PnlBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdBranch)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.BackColor = System.Drawing.Color.SteelBlue;
            this.PnlMain.Controls.Add(this.GrdBranch);
            this.PnlMain.Controls.Add(this.Grd);
            this.PnlMain.Controls.Add(this.GrdTemp);
            this.PnlMain.Controls.Add(this.PnlBtn);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(960, 467);
            this.PnlMain.TabIndex = 1;
            // 
            // PnlBtn
            // 
            this.PnlBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PnlBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.PnlBtn.Controls.Add(this.btnClose);
            this.PnlBtn.Controls.Add(this.btnSelect);
            this.PnlBtn.Location = new System.Drawing.Point(358, 406);
            this.PnlBtn.Name = "PnlBtn";
            this.PnlBtn.Size = new System.Drawing.Size(216, 41);
            this.PnlBtn.TabIndex = 7;
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
            // Grd
            // 
            this.Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grd.ColumnHeadersVisible = false;
            this.Grd.Location = new System.Drawing.Point(25, 84);
            this.Grd.MoveLeftToRight = false;
            this.Grd.Name = "Grd";
            this.Grd.ReadOnly = true;
            this.Grd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grd.Size = new System.Drawing.Size(598, 285);
            this.Grd.TabIndex = 0;
            this.Grd.SelectionChanged += new System.EventHandler(this.Grd_SelectionChanged);
            this.Grd.Click += new System.EventHandler(this.Grd_Click);
            this.Grd.DoubleClick += new System.EventHandler(this.Grd_DoubleClick);
            // 
            // GrdTemp
            // 
            this.GrdTemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdTemp.Location = new System.Drawing.Point(25, 37);
            this.GrdTemp.MoveLeftToRight = false;
            this.GrdTemp.Name = "GrdTemp";
            this.GrdTemp.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.GrdTemp.Size = new System.Drawing.Size(598, 41);
            this.GrdTemp.TabIndex = 0;
            this.GrdTemp.EditValueChanged += new System.EventHandler(this.GrdTemp_EditValueChanged);
            // 
            // GrdBranch
            // 
            this.GrdBranch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdBranch.ColumnHeadersVisible = false;
            this.GrdBranch.Location = new System.Drawing.Point(629, 84);
            this.GrdBranch.MoveLeftToRight = false;
            this.GrdBranch.Name = "GrdBranch";
            this.GrdBranch.ReadOnly = true;
            this.GrdBranch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.GrdBranch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdBranch.Size = new System.Drawing.Size(317, 285);
            this.GrdBranch.TabIndex = 9;
            // 
            // SchDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 467);
            this.Controls.Add(this.PnlMain);
            this.Name = "SchDiscount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serach Discount";
            this.Load += new System.EventHandler(this.frmDiscount_Load);
            this.PnlMain.ResumeLayout(false);
            this.PnlBtn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdBranch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.Panel PnlBtn;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSelect;
        private DGV.DGV Grd;
        private DGV.DGV GrdTemp;
        private DGV.DGV GrdBranch;
    }
}
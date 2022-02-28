namespace Restorant_Management_System.Sch_Forms
{
    partial class SchBarcodeTitle
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
            this.PnlHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.PnlBtn = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PnlGrd = new System.Windows.Forms.Panel();
            this.Grd = new DGV.DGV();
            this.PnlGrd_Temp = new System.Windows.Forms.Panel();
            this.Grd_Temp = new DGV.DGV();
            this.PnlMain.SuspendLayout();
            this.PnlHeader.SuspendLayout();
            this.PnlBtn.SuspendLayout();
            this.panel2.SuspendLayout();
            this.PnlGrd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).BeginInit();
            this.PnlGrd_Temp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd_Temp)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.BackColor = System.Drawing.Color.SteelBlue;
            this.PnlMain.Controls.Add(this.PnlHeader);
            this.PnlMain.Controls.Add(this.PnlBtn);
            this.PnlMain.Controls.Add(this.panel2);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(458, 450);
            this.PnlMain.TabIndex = 1;
            // 
            // PnlHeader
            // 
            this.PnlHeader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.PnlHeader.Controls.Add(this.label1);
            this.PnlHeader.Controls.Add(this.button1);
            this.PnlHeader.Location = new System.Drawing.Point(38, 12);
            this.PnlHeader.Name = "PnlHeader";
            this.PnlHeader.Size = new System.Drawing.Size(380, 32);
            this.PnlHeader.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(123, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search Barcode Title";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(334, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PnlBtn
            // 
            this.PnlBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PnlBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.PnlBtn.Controls.Add(this.btnClose);
            this.PnlBtn.Controls.Add(this.btnSelect);
            this.PnlBtn.Location = new System.Drawing.Point(107, 397);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.PnlGrd);
            this.panel2.Controls.Add(this.PnlGrd_Temp);
            this.panel2.Location = new System.Drawing.Point(38, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(380, 326);
            this.panel2.TabIndex = 0;
            // 
            // PnlGrd
            // 
            this.PnlGrd.Controls.Add(this.Grd);
            this.PnlGrd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlGrd.Location = new System.Drawing.Point(0, 41);
            this.PnlGrd.Name = "PnlGrd";
            this.PnlGrd.Size = new System.Drawing.Size(380, 285);
            this.PnlGrd.TabIndex = 1;
            // 
            // Grd
            // 
            this.Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grd.ColumnHeadersVisible = false;
            this.Grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grd.Location = new System.Drawing.Point(0, 0);
            this.Grd.MoveLeftToRight = false;
            this.Grd.Name = "Grd";
            this.Grd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Grd.Size = new System.Drawing.Size(380, 285);
            this.Grd.TabIndex = 0;
            this.Grd.DoubleClick += new System.EventHandler(this.Grd_DoubleClick);
            this.Grd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grd_KeyDown);
            // 
            // PnlGrd_Temp
            // 
            this.PnlGrd_Temp.Controls.Add(this.Grd_Temp);
            this.PnlGrd_Temp.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlGrd_Temp.Location = new System.Drawing.Point(0, 0);
            this.PnlGrd_Temp.Name = "PnlGrd_Temp";
            this.PnlGrd_Temp.Size = new System.Drawing.Size(380, 41);
            this.PnlGrd_Temp.TabIndex = 0;
            // 
            // Grd_Temp
            // 
            this.Grd_Temp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grd_Temp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grd_Temp.Location = new System.Drawing.Point(0, 0);
            this.Grd_Temp.MoveLeftToRight = false;
            this.Grd_Temp.Name = "Grd_Temp";
            this.Grd_Temp.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Grd_Temp.Size = new System.Drawing.Size(380, 41);
            this.Grd_Temp.TabIndex = 0;
            this.Grd_Temp.EditValueChanged += new System.EventHandler(this.Grd_Temp_EditValueChanged);
            // 
            // SchBarcodeTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 450);
            this.Controls.Add(this.PnlMain);
            this.Name = "SchBarcodeTitle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SchBarcodeTitle";
            this.Load += new System.EventHandler(this.SchBarcodeTitle_Load);
            this.PnlMain.ResumeLayout(false);
            this.PnlHeader.ResumeLayout(false);
            this.PnlHeader.PerformLayout();
            this.PnlBtn.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.PnlGrd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).EndInit();
            this.PnlGrd_Temp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grd_Temp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.Panel PnlHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel PnlBtn;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel PnlGrd;
        private DGV.DGV Grd;
        private System.Windows.Forms.Panel PnlGrd_Temp;
        private DGV.DGV Grd_Temp;
    }
}
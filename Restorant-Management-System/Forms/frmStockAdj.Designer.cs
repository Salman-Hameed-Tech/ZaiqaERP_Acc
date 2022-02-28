namespace Restorant_Management_System.Forms
{
    partial class frmStockAdj
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtAdjPrice = new System.Windows.Forms.TextBox();
            this.txtAdjStock = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCurrentStock = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCurrentPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxCategory = new System.Windows.Forms.ComboBox();
            this.Grd = new DGV.DGV();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtItemID = new System.Windows.Forms.TextBox();
            this.FrmStockAdj_Fill_Panel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.FrmStockAdj_Fill_Panel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtAdjPrice);
            this.groupBox2.Controls.Add(this.txtAdjStock);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtCurrentStock);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtCurrentPrice);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(642, 165);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 206);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stock Detail";
            // 
            // txtAdjPrice
            // 
            this.txtAdjPrice.BackColor = System.Drawing.Color.White;
            this.txtAdjPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdjPrice.ForeColor = System.Drawing.Color.IndianRed;
            this.txtAdjPrice.Location = new System.Drawing.Point(96, 149);
            this.txtAdjPrice.Name = "txtAdjPrice";
            this.txtAdjPrice.ReadOnly = true;
            this.txtAdjPrice.Size = new System.Drawing.Size(131, 20);
            this.txtAdjPrice.TabIndex = 24;
            this.txtAdjPrice.TabStop = false;
            this.txtAdjPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAdjStock
            // 
            this.txtAdjStock.BackColor = System.Drawing.Color.White;
            this.txtAdjStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdjStock.ForeColor = System.Drawing.Color.IndianRed;
            this.txtAdjStock.Location = new System.Drawing.Point(96, 114);
            this.txtAdjStock.Name = "txtAdjStock";
            this.txtAdjStock.ReadOnly = true;
            this.txtAdjStock.Size = new System.Drawing.Size(131, 20);
            this.txtAdjStock.TabIndex = 23;
            this.txtAdjStock.TabStop = false;
            this.txtAdjStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(17, 114);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(73, 26);
            this.label5.TabIndex = 20;
            this.label5.Text = "Adjusted Stock:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtCurrentStock
            // 
            this.txtCurrentStock.BackColor = System.Drawing.Color.White;
            this.txtCurrentStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentStock.ForeColor = System.Drawing.Color.IndianRed;
            this.txtCurrentStock.Location = new System.Drawing.Point(96, 30);
            this.txtCurrentStock.Name = "txtCurrentStock";
            this.txtCurrentStock.ReadOnly = true;
            this.txtCurrentStock.Size = new System.Drawing.Size(131, 20);
            this.txtCurrentStock.TabIndex = 0;
            this.txtCurrentStock.TabStop = false;
            this.txtCurrentStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(17, 32);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Current Stock:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(17, 149);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(73, 28);
            this.label6.TabIndex = 22;
            this.label6.Text = "Adjusted Avg. Price:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtCurrentPrice
            // 
            this.txtCurrentPrice.BackColor = System.Drawing.Color.White;
            this.txtCurrentPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentPrice.ForeColor = System.Drawing.Color.IndianRed;
            this.txtCurrentPrice.Location = new System.Drawing.Point(96, 62);
            this.txtCurrentPrice.Name = "txtCurrentPrice";
            this.txtCurrentPrice.ReadOnly = true;
            this.txtCurrentPrice.Size = new System.Drawing.Size(131, 20);
            this.txtCurrentPrice.TabIndex = 1;
            this.txtCurrentPrice.TabStop = false;
            this.txtCurrentPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(17, 58);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(73, 28);
            this.label4.TabIndex = 18;
            this.label4.Text = "Current Avg. Price:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // cbxCategory
            // 
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.Location = new System.Drawing.Point(276, 75);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(143, 21);
            this.cbxCategory.TabIndex = 1;
            this.cbxCategory.SelectedIndexChanged += new System.EventHandler(this.cbxCategory_SelectedIndexChanged);
            this.cbxCategory.TextChanged += new System.EventHandler(this.cbxCategory_TextChanged);
            this.cbxCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxCategory_KeyDown);
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
            this.Grd.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Grd.Location = new System.Drawing.Point(186, 165);
            this.Grd.MoveLeftToRight = false;
            this.Grd.Name = "Grd";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grd.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grd.Size = new System.Drawing.Size(450, 233);
            this.Grd.StandardTab = true;
            this.Grd.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtItemID);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(200, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 55);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search By";
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(14, 25);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(43, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "ItemID:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtItemID
            // 
            this.txtItemID.Location = new System.Drawing.Point(63, 23);
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.Size = new System.Drawing.Size(197, 20);
            this.txtItemID.TabIndex = 2;
            this.txtItemID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtItemID.TextChanged += new System.EventHandler(this.txtItemID_TextChanged);
            this.txtItemID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemID_KeyDown);
            // 
            // FrmStockAdj_Fill_Panel
            // 
            this.FrmStockAdj_Fill_Panel.BackColor = System.Drawing.Color.SteelBlue;
            this.FrmStockAdj_Fill_Panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FrmStockAdj_Fill_Panel.Controls.Add(this.panel2);
            this.FrmStockAdj_Fill_Panel.Controls.Add(this.Grd);
            this.FrmStockAdj_Fill_Panel.Controls.Add(this.groupBox2);
            this.FrmStockAdj_Fill_Panel.Controls.Add(this.groupBox1);
            this.FrmStockAdj_Fill_Panel.Controls.Add(this.cbxCategory);
            this.FrmStockAdj_Fill_Panel.Controls.Add(this.label1);
            this.FrmStockAdj_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.FrmStockAdj_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FrmStockAdj_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.FrmStockAdj_Fill_Panel.Name = "FrmStockAdj_Fill_Panel";
            this.FrmStockAdj_Fill_Panel.Size = new System.Drawing.Size(999, 496);
            this.FrmStockAdj_Fill_Panel.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Location = new System.Drawing.Point(350, 424);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(176, 48);
            this.panel2.TabIndex = 22;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnNew.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(20, 6);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(68, 33);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(94, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 33);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(218, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Category:";
            // 
            // frmStockAdj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 496);
            this.Controls.Add(this.FrmStockAdj_Fill_Panel);
            this.Name = "frmStockAdj";
            this.Text = "frmStockAdj";
            this.Load += new System.EventHandler(this.frmStockAdj_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.FrmStockAdj_Fill_Panel.ResumeLayout(false);
            this.FrmStockAdj_Fill_Panel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCurrentStock;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCurrentPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxCategory;
        private DGV.DGV Grd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtItemID;
        private System.Windows.Forms.Panel FrmStockAdj_Fill_Panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAdjPrice;
        private System.Windows.Forms.TextBox txtAdjStock;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
    }
}
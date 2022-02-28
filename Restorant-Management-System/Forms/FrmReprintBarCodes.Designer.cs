namespace Restorant_Management_System.Forms
{
    partial class FrmReprintBarCodes
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
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtpaperheight = new System.Windows.Forms.TextBox();
            this.txtpaperwidth = new System.Windows.Forms.TextBox();
            this.txtpapername = new System.Windows.Forms.TextBox();
            this.txtstartingcol = new System.Windows.Forms.TextBox();
            this.txtstartingrow = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInStock = new System.Windows.Forms.TextBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtItemID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtBarCodeCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.Grd = new DGV.DGV();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbBarcode = new System.Windows.Forms.ComboBox();
            this.btnTitleBarcode = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(399, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Paper Height";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(308, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Paper Width";
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(217, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Paper Name";
            this.label8.Visible = false;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(126, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Starting Col. #";
            this.label9.Visible = false;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(35, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Starting Row #";
            this.label10.Visible = false;
            // 
            // txtpaperheight
            // 
            this.txtpaperheight.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtpaperheight.Location = new System.Drawing.Point(402, 42);
            this.txtpaperheight.Name = "txtpaperheight";
            this.txtpaperheight.Size = new System.Drawing.Size(85, 20);
            this.txtpaperheight.TabIndex = 28;
            this.txtpaperheight.Text = "1160";
            this.txtpaperheight.Visible = false;
            // 
            // txtpaperwidth
            // 
            this.txtpaperwidth.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtpaperwidth.Location = new System.Drawing.Point(311, 42);
            this.txtpaperwidth.Name = "txtpaperwidth";
            this.txtpaperwidth.Size = new System.Drawing.Size(85, 20);
            this.txtpaperwidth.TabIndex = 29;
            this.txtpaperwidth.Text = "860";
            this.txtpaperwidth.Visible = false;
            // 
            // txtpapername
            // 
            this.txtpapername.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtpapername.Location = new System.Drawing.Point(220, 42);
            this.txtpapername.Name = "txtpapername";
            this.txtpapername.Size = new System.Drawing.Size(85, 20);
            this.txtpapername.TabIndex = 30;
            this.txtpapername.Text = "A4";
            this.txtpapername.Visible = false;
            // 
            // txtstartingcol
            // 
            this.txtstartingcol.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtstartingcol.Location = new System.Drawing.Point(129, 42);
            this.txtstartingcol.Name = "txtstartingcol";
            this.txtstartingcol.Size = new System.Drawing.Size(85, 20);
            this.txtstartingcol.TabIndex = 31;
            this.txtstartingcol.Visible = false;
            // 
            // txtstartingrow
            // 
            this.txtstartingrow.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtstartingrow.Location = new System.Drawing.Point(38, 42);
            this.txtstartingrow.Name = "txtstartingrow";
            this.txtstartingrow.Size = new System.Drawing.Size(85, 20);
            this.txtstartingrow.TabIndex = 32;
            this.txtstartingrow.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(332, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "In Stock";
            // 
            // txtInStock
            // 
            this.txtInStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInStock.Location = new System.Drawing.Point(332, 91);
            this.txtInStock.Name = "txtInStock";
            this.txtInStock.ReadOnly = true;
            this.txtInStock.Size = new System.Drawing.Size(49, 20);
            this.txtInStock.TabIndex = 40;
            this.txtInStock.TabStop = false;
            this.txtInStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtItemName
            // 
            this.txtItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemName.Location = new System.Drawing.Point(115, 91);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.ReadOnly = true;
            this.txtItemName.Size = new System.Drawing.Size(211, 20);
            this.txtItemName.TabIndex = 34;
            this.txtItemName.TabStop = false;
            // 
            // txtItemID
            // 
            this.txtItemID.Location = new System.Drawing.Point(20, 91);
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.Size = new System.Drawing.Size(84, 20);
            this.txtItemID.TabIndex = 33;
            this.txtItemID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtItemID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemID_KeyDown);
            this.txtItemID.Leave += new System.EventHandler(this.txtItemID_Leave);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(384, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Quantity";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(111, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Item Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(17, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Item ID";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(450, 90);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(61, 23);
            this.btnAdd.TabIndex = 36;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuantity.Location = new System.Drawing.Point(387, 91);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(43, 20);
            this.txtQuantity.TabIndex = 35;
            this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQuantity.Leave += new System.EventHandler(this.txtQuantity_Leave);
            // 
            // txtBarCodeCount
            // 
            this.txtBarCodeCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarCodeCount.Location = new System.Drawing.Point(412, 350);
            this.txtBarCodeCount.Name = "txtBarCodeCount";
            this.txtBarCodeCount.Size = new System.Drawing.Size(99, 20);
            this.txtBarCodeCount.TabIndex = 44;
            this.txtBarCodeCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(324, 353);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "Bar Code Count";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Location = new System.Drawing.Point(88, 390);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(318, 48);
            this.panel2.TabIndex = 45;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnNew.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(38, 8);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(68, 33);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(122, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 33);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnPrint.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(201, 8);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(68, 33);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // Grd
            // 
            this.Grd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.Grd.Location = new System.Drawing.Point(12, 152);
            this.Grd.MoveLeftToRight = true;
            this.Grd.Name = "Grd";
            this.Grd.Size = new System.Drawing.Size(499, 182);
            this.Grd.StandardTab = true;
            this.Grd.TabIndex = 42;
         //   this.Grd.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grd_CellClick);
            this.Grd.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grd_CellContentClick);
        //    this.Grd.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Grd_CellMouseUp);
            this.Grd.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grd_CellValueChanged);
         //   this.Grd.Click += new System.EventHandler(this.Grd_Click);
      //      this.Grd.Leave += new System.EventHandler(this.Grd_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(33, 124);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 13);
            this.label11.TabIndex = 48;
            this.label11.Text = "Barcode Text";
            // 
            // cmbBarcode
            // 
            this.cmbBarcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBarcode.FormattingEnabled = true;
            this.cmbBarcode.Location = new System.Drawing.Point(115, 118);
            this.cmbBarcode.Name = "cmbBarcode";
            this.cmbBarcode.Size = new System.Drawing.Size(315, 21);
            this.cmbBarcode.TabIndex = 49;
            // 
            // btnTitleBarcode
            // 
            this.btnTitleBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTitleBarcode.Location = new System.Drawing.Point(450, 119);
            this.btnTitleBarcode.Name = "btnTitleBarcode";
            this.btnTitleBarcode.Size = new System.Drawing.Size(61, 23);
            this.btnTitleBarcode.TabIndex = 50;
            this.btnTitleBarcode.Text = "Create";
            this.btnTitleBarcode.UseVisualStyleBackColor = true;
            this.btnTitleBarcode.Click += new System.EventHandler(this.btnTitleBarcode_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(26, 383);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 50);
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // FrmReprintBarCodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(523, 450);
            this.Controls.Add(this.btnTitleBarcode);
            this.Controls.Add(this.cmbBarcode);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtBarCodeCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Grd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInStock);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.txtItemID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtstartingrow);
            this.Controls.Add(this.txtstartingcol);
            this.Controls.Add(this.txtpapername);
            this.Controls.Add(this.txtpaperwidth);
            this.Controls.Add(this.txtpaperheight);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Name = "FrmReprintBarCodes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print Bar Codes";
            this.Load += new System.EventHandler(this.FrmReprintBarCodes_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtpaperheight;
        private System.Windows.Forms.TextBox txtpaperwidth;
        private System.Windows.Forms.TextBox txtpapername;
        private System.Windows.Forms.TextBox txtstartingcol;
        private System.Windows.Forms.TextBox txtstartingrow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInStock;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.TextBox txtItemID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtBarCodeCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DGV.DGV Grd;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbBarcode;
        private System.Windows.Forms.Button btnTitleBarcode;
    }
}
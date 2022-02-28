namespace RMS.Search_Forms
{
    partial class SchMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchMenu));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SchAccounts_Fill_Panel = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnClose = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSelect = new System.Windows.Forms.ToolStripButton();
            this.Grd = new DGV.DGV();
            this.txtMenuName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SchAccounts_Fill_Panel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).BeginInit();
            this.SuspendLayout();
            // 
            // SchAccounts_Fill_Panel
            // 
            this.SchAccounts_Fill_Panel.BackColor = System.Drawing.Color.SteelBlue;
            this.SchAccounts_Fill_Panel.Controls.Add(this.toolStrip1);
            this.SchAccounts_Fill_Panel.Controls.Add(this.Grd);
            this.SchAccounts_Fill_Panel.Controls.Add(this.txtMenuName);
            this.SchAccounts_Fill_Panel.Controls.Add(this.label1);
            this.SchAccounts_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.SchAccounts_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SchAccounts_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.SchAccounts_Fill_Panel.Name = "SchAccounts_Fill_Panel";
            this.SchAccounts_Fill_Panel.Size = new System.Drawing.Size(800, 406);
            this.SchAccounts_Fill_Panel.TabIndex = 4;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnClose,
            this.tsBtnSelect});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "&Select";
            // 
            // tsBtnClose
            // 
            this.tsBtnClose.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnClose.Image")));
            this.tsBtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnClose.Name = "tsBtnClose";
            this.tsBtnClose.Size = new System.Drawing.Size(56, 22);
            this.tsBtnClose.Text = "&Close";
            this.tsBtnClose.Click += new System.EventHandler(this.tsBtnClose_Click);
            // 
            // tsBtnSelect
            // 
            this.tsBtnSelect.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSelect.Image")));
            this.tsBtnSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSelect.Name = "tsBtnSelect";
            this.tsBtnSelect.Size = new System.Drawing.Size(58, 22);
            this.tsBtnSelect.Text = "&Select";
            this.tsBtnSelect.Click += new System.EventHandler(this.tsBtnSelect_Click);
            // 
            // Grd
            // 
            this.Grd.BackgroundColor = System.Drawing.Color.Silver;
            this.Grd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grd.DefaultCellStyle = dataGridViewCellStyle1;
            this.Grd.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Grd.Location = new System.Drawing.Point(5, 80);
            this.Grd.MoveLeftToRight = false;
            this.Grd.Name = "Grd";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grd.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Black;
            this.Grd.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.Grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grd.Size = new System.Drawing.Size(792, 320);
            this.Grd.TabIndex = 2;
            this.Grd.DoubleClick += new System.EventHandler(this.Grd_DoubleClick);
            this.Grd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grd_KeyDown);
            // 
            // txtMenuName
            // 
            this.txtMenuName.Location = new System.Drawing.Point(148, 54);
            this.txtMenuName.Name = "txtMenuName";
            this.txtMenuName.Size = new System.Drawing.Size(441, 20);
            this.txtMenuName.TabIndex = 0;
            this.txtMenuName.TextChanged += new System.EventHandler(this.txtMenuName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(69, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Menu Name";
            // 
            // SchMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 406);
            this.Controls.Add(this.SchAccounts_Fill_Panel);
            this.Name = "SchMenu";
            this.Text = "SchMenu";
            this.Load += new System.EventHandler(this.SchMenu_Load);
            this.SchAccounts_Fill_Panel.ResumeLayout(false);
            this.SchAccounts_Fill_Panel.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SchAccounts_Fill_Panel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnClose;
        private System.Windows.Forms.ToolStripButton tsBtnSelect;
        private DGV.DGV Grd;
        private System.Windows.Forms.TextBox txtMenuName;
        private System.Windows.Forms.Label label1;
    }
}
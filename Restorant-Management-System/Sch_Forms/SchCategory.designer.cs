namespace Accounts.SchForms
{
    partial class SchCategory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchCategory));
            this.SchItems_Fill_Panel = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnClose = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSelect = new System.Windows.Forms.ToolStripButton();
            this.Grd = new DGV.DGV();
            this.grdTemp = new DGV.DGV();
            this.Bsrc = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SchItems_Fill_Panel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bsrc)).BeginInit();
            this.SuspendLayout();
            // 
            // SchItems_Fill_Panel
            // 
            this.SchItems_Fill_Panel.Controls.Add(this.toolStrip1);
            this.SchItems_Fill_Panel.Controls.Add(this.Grd);
            this.SchItems_Fill_Panel.Controls.Add(this.grdTemp);
            this.SchItems_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.SchItems_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SchItems_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.SchItems_Fill_Panel.Name = "SchItems_Fill_Panel";
            this.SchItems_Fill_Panel.Size = new System.Drawing.Size(455, 342);
            this.SchItems_Fill_Panel.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnClose,
            this.tsBtnSelect});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(455, 25);
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
            this.tsBtnClose.Click += new System.EventHandler(this.tsBtnClose_Click_1);
            // 
            // tsBtnSelect
            // 
            this.tsBtnSelect.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSelect.Image")));
            this.tsBtnSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSelect.Name = "tsBtnSelect";
            this.tsBtnSelect.Size = new System.Drawing.Size(58, 22);
            this.tsBtnSelect.Text = "&Select";
            this.tsBtnSelect.Click += new System.EventHandler(this.tsBtnSelect_Click_1);
            // 
            // Grd
            // 
            this.Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grd.ColumnHeadersVisible = false;
            this.Grd.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Grd.Location = new System.Drawing.Point(2, 73);
            this.Grd.MoveLeftToRight = false;
            this.Grd.Name = "Grd";
            this.Grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grd.Size = new System.Drawing.Size(450, 256);
            this.Grd.TabIndex = 1;
            this.Grd.DoubleClick += new System.EventHandler(this.Grd_DoubleClick);
            this.Grd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grd_KeyDown);
            // 
            // grdTemp
            // 
            this.grdTemp.AllowUserToAddRows = false;
            this.grdTemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTemp.Location = new System.Drawing.Point(2, 26);
            this.grdTemp.MoveLeftToRight = true;
            this.grdTemp.Name = "grdTemp";
            this.grdTemp.Size = new System.Drawing.Size(450, 61);
            this.grdTemp.StandardTab = true;
            this.grdTemp.TabIndex = 0;
            this.grdTemp.EditValueChanged += new System.EventHandler(this.dgv1_EditValueChanged);
            // 
            // Bsrc
            // 
            this.Bsrc.DataSource = typeof(Common.Item);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Item ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Item Category";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Company Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Product Name";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Design";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Size";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Total";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // SchCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(455, 342);
            this.Controls.Add(this.SchItems_Fill_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "SchCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Categories";
            this.Load += new System.EventHandler(this.SchItems_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SchItems_KeyDown);
            this.SchItems_Fill_Panel.ResumeLayout(false);
            this.SchItems_Fill_Panel.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bsrc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SchItems_Fill_Panel;
        private System.Windows.Forms.BindingSource Bsrc;
        private DGV.DGV grdTemp;
        private DGV.DGV Grd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnClose;
        private System.Windows.Forms.ToolStripButton tsBtnSelect;
    }
}
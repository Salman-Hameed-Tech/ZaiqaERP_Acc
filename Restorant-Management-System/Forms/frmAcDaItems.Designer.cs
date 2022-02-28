namespace Restorant_Management_System.Forms
{
    partial class frmAcDaItems
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GrdDa = new DGV.DGV();
            this.GrdAc = new DGV.DGV();
            this.dgv2 = new DGV.DGV();
            this.grdTemp = new DGV.DGV();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdDa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdAc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTemp)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.label2);
            this.PnlMain.Controls.Add(this.label1);
            this.PnlMain.Controls.Add(this.GrdDa);
            this.PnlMain.Controls.Add(this.GrdAc);
            this.PnlMain.Controls.Add(this.dgv2);
            this.PnlMain.Controls.Add(this.grdTemp);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(1136, 603);
            this.PnlMain.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(511, 283);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "De-Active Items";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(511, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Active Items";
            // 
            // GrdDa
            // 
            this.GrdDa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdDa.Location = new System.Drawing.Point(54, 357);
            this.GrdDa.MoveLeftToRight = false;
            this.GrdDa.Name = "GrdDa";
            this.GrdDa.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.GrdDa.Size = new System.Drawing.Size(1018, 205);
            this.GrdDa.TabIndex = 1;
            // 
            // GrdAc
            // 
            this.GrdAc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdAc.Location = new System.Drawing.Point(54, 81);
            this.GrdAc.MoveLeftToRight = false;
            this.GrdAc.Name = "GrdAc";
            this.GrdAc.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.GrdAc.Size = new System.Drawing.Size(1018, 190);
            this.GrdAc.TabIndex = 0;
            this.GrdAc.EditValueChanged += new System.EventHandler(this.grdTemp_EditValueChanged);
            // 
            // dgv2
            // 
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Location = new System.Drawing.Point(54, 312);
            this.dgv2.MoveLeftToRight = false;
            this.dgv2.Name = "dgv2";
            this.dgv2.Size = new System.Drawing.Size(1018, 59);
            this.dgv2.TabIndex = 5;
            // 
            // grdTemp
            // 
            this.grdTemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTemp.Location = new System.Drawing.Point(54, 38);
            this.grdTemp.MoveLeftToRight = false;
            this.grdTemp.Name = "grdTemp";
            this.grdTemp.Size = new System.Drawing.Size(1018, 45);
            this.grdTemp.TabIndex = 4;
            // 
            // frmAcDaItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 603);
            this.Controls.Add(this.PnlMain);
            this.Name = "frmAcDaItems";
            this.Text = "frmAcDaItems";
            this.Load += new System.EventHandler(this.frmAcDaItems_Load);
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdDa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdAc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTemp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private DGV.DGV GrdDa;
        private DGV.DGV GrdAc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DGV.DGV dgv2;
        private DGV.DGV grdTemp;
    }
}
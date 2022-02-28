namespace Restorant_Management_System.Sch_Forms
{
    partial class SchRecipieProdcution
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
            this.lblHeading = new System.Windows.Forms.Label();
            this.Grd = new DGV.DGV();
            this.grdTemp = new DGV.DGV();
            this.lblHeading2 = new System.Windows.Forms.Label();
            this.GrdDetail = new DGV.DGV();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeading
            // 
            this.lblHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.ForeColor = System.Drawing.Color.White;
            this.lblHeading.Location = new System.Drawing.Point(16, 15);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(919, 54);
            this.lblHeading.TabIndex = 97;
            this.lblHeading.Text = "View/Edit Recipie Production";
            this.lblHeading.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Grd
            // 
            this.Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grd.ColumnHeadersVisible = false;
            this.Grd.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Grd.Location = new System.Drawing.Point(6, 102);
            this.Grd.MoveLeftToRight = false;
            this.Grd.Name = "Grd";
            this.Grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grd.Size = new System.Drawing.Size(938, 224);
            this.Grd.StandardTab = true;
            this.Grd.TabIndex = 96;
            this.Grd.SelectionChanged += new System.EventHandler(this.Grd_SelectionChanged);
            this.Grd.DoubleClick += new System.EventHandler(this.Grd_DoubleClick);
            // 
            // grdTemp
            // 
            this.grdTemp.AllowUserToAddRows = false;
            this.grdTemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTemp.Location = new System.Drawing.Point(6, 67);
            this.grdTemp.MoveLeftToRight = true;
            this.grdTemp.Name = "grdTemp";
            this.grdTemp.Size = new System.Drawing.Size(938, 61);
            this.grdTemp.StandardTab = true;
            this.grdTemp.TabIndex = 95;
            this.grdTemp.EditValueChanged += new System.EventHandler(this.grdTemp_EditValueChanged);
            this.grdTemp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdTemp_KeyDown);
            // 
            // lblHeading2
            // 
            this.lblHeading2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading2.ForeColor = System.Drawing.Color.White;
            this.lblHeading2.Location = new System.Drawing.Point(17, 329);
            this.lblHeading2.Name = "lblHeading2";
            this.lblHeading2.Size = new System.Drawing.Size(919, 34);
            this.lblHeading2.TabIndex = 100;
            this.lblHeading2.Text = "Recipie Production Details";
            this.lblHeading2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GrdDetail
            // 
            this.GrdDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GrdDetail.Location = new System.Drawing.Point(5, 368);
            this.GrdDetail.MoveLeftToRight = false;
            this.GrdDetail.Name = "GrdDetail";
            this.GrdDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdDetail.Size = new System.Drawing.Size(940, 214);
            this.GrdDetail.StandardTab = true;
            this.GrdDetail.TabIndex = 99;
            // 
            // SchRecipieProdcution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(950, 584);
            this.Controls.Add(this.lblHeading2);
            this.Controls.Add(this.GrdDetail);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.Grd);
            this.Controls.Add(this.grdTemp);
            this.Name = "SchRecipieProdcution";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SchRecipieProdcution";
            this.Load += new System.EventHandler(this.SchRecipieProdcution_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHeading;
        private DGV.DGV Grd;
        private DGV.DGV grdTemp;
        private System.Windows.Forms.Label lblHeading2;
        private DGV.DGV GrdDetail;
    }
}
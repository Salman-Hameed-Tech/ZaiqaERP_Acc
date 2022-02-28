namespace Restorant_Management_System.Forms
{
    partial class FrmExcelDiscount
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowes = new System.Windows.Forms.Button();
            this.txtFileNmae = new System.Windows.Forms.TextBox();
            this.Grd = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnBrowes
            // 
            this.btnBrowes.Location = new System.Drawing.Point(682, 314);
            this.btnBrowes.Name = "btnBrowes";
            this.btnBrowes.Size = new System.Drawing.Size(75, 23);
            this.btnBrowes.TabIndex = 0;
            this.btnBrowes.Text = "Choose File";
            this.btnBrowes.UseVisualStyleBackColor = true;
            this.btnBrowes.Click += new System.EventHandler(this.btnBrowes_Click);
            // 
            // txtFileNmae
            // 
            this.txtFileNmae.Location = new System.Drawing.Point(131, 316);
            this.txtFileNmae.Name = "txtFileNmae";
            this.txtFileNmae.Size = new System.Drawing.Size(532, 20);
            this.txtFileNmae.TabIndex = 1;
            this.txtFileNmae.TextChanged += new System.EventHandler(this.txtFileNmae_TextChanged);
            // 
            // Grd
            // 
            this.Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grd.Location = new System.Drawing.Point(12, 12);
            this.Grd.Name = "Grd";
            this.Grd.Size = new System.Drawing.Size(985, 261);
            this.Grd.TabIndex = 2;
            // 
            // FrmExcelDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 349);
            this.Controls.Add(this.Grd);
            this.Controls.Add(this.txtFileNmae);
            this.Controls.Add(this.btnBrowes);
            this.Name = "FrmExcelDiscount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excel Discount";
            ((System.ComponentModel.ISupportInitialize)(this.Grd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnBrowes;
        private System.Windows.Forms.TextBox txtFileNmae;
        private System.Windows.Forms.DataGridView Grd;
    }
}
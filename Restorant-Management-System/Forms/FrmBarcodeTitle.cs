using CategoryControlle;
using Common;
using Restorant_Management_System.Sch_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restorant_Management_System.Forms
{
    public partial class FrmBarcodeTitle : Form
    {
        bool IsNew = true;
        public FrmBarcodeTitle()
        {
            InitializeComponent();
        }

        private void FrmBarcodeTitle_Load(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
           
        }

        private void ClearControls()
        {
            txtID.Text = new ItemController().GetMaxTitleID();
            txtBarcodeTitle.Clear();
            IsNew = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Barcodes common = new Barcodes();
            common.ID = Convert.ToInt32(txtID.Text);
            common.Barcode=txtBarcodeTitle.Text.Trim();
            
         
            if(new ItemController().SaveBarocdeTitle(common, IsNew))
            {
                if (IsNew)
                {
                    MessageBox.Show("Barcode Title Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Barcode Title Updated Successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                ClearControls();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SchBarcodeTitle sch = new SchBarcodeTitle();
            sch.ShowDialog();
            if (sch.title != null)
            {
                IsNew = false;
                txtID.Text = sch.title.ID.ToString();
                txtBarcodeTitle.Text = sch.title.Barcode;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
           int id = Convert.ToInt32(txtID.Text);
            if(new ItemController().DetelteBracodeTitle(id))
            {
                MessageBox.Show("Deleted Successfully","Deleted",MessageBoxButtons.OK,MessageBoxIcon.Information);
                ClearControls();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

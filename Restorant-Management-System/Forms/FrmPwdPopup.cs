using CategoryControlle;
using Common;
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
    public partial class FrmPwdPopup : Form
    {
        public bool EnableDisc;
        public FrmPwdPopup()
        {
            InitializeComponent();
        }

        private void btnEnableDisc_Click(object sender, EventArgs e)
        {
            try
            {
                string ExistedPwd = new SaleInvoiceController().GetPassword(Globals.BranchID);
                if (ExistedPwd == txtConfirmPassword.Text)
                {
                    EnableDisc = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Password Not Correct ", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

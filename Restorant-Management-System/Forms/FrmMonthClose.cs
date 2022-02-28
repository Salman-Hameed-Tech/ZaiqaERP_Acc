using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using CategoryControlle;

namespace Accounts.Forms
{
    public partial class FrmMonthClose : Form
    {
        private DateTime date;
        private bool close;
        public FrmMonthClose()
        {
            InitializeComponent();
        }

        private void FrmMonthClose_Load(object sender, EventArgs e)
        {

        }
        private void tsbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tsbtnMClose_Click(object sender, EventArgs e)
        {
           
        }
        private void tsbtnUnClose_Click(object sender, EventArgs e)
        {
          
        
        }

        private void dtpMonth_ValueChanged(object sender, EventArgs e)
        {
            date =  Convert.ToDateTime( this.dtpMonth.Value.Date);
        }
        private bool Allowed()
        {
            if (User._IsAdmin == true)
                return true;
            else return false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (Allowed())
                {
                    close = true;
                    if ((new CategoryControlle.VoucherController().CloseMonth(close, dtpMonth.Value) == true))
                    {
                        MessageBox.Show("Month is closed Successfully !");
                    }
                }
                else
                {
                    MessageBox.Show("You can not Close Month. Please contact to the Administrator");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MClose", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Allowed())
                {
                    close = false;
                    if ((new VoucherController().CloseMonth(close, date) == true))
                    {
                        MessageBox.Show("Month is Unclosed Successfully !");
                    }
                }
                else
                {
                    MessageBox.Show("You can not Close Month. Please contact to the Administrator");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MClose", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

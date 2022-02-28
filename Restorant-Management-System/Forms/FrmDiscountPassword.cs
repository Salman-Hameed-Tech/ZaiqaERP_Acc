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
    public partial class FrmDiscountPassword : Form
    {

        bool IsNew = true;
        public FrmDiscountPassword()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void ClearControls()
        {
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            txtOldPassword.Clear();
            txtPassword.Enabled = false;
            txtConfirmPassword.Enabled = false;
            chkIsNew.Checked = false;

            List<Branch> counters = new BranchController().GetBranch("  where 1=1  ");
            cmbBranch.DataSource = counters;
            cmbBranch.ValueMember = "ID";
            cmbBranch.DisplayMember = "BranchName";
        }



        private void FrmDiscountPassword_Load(object sender, EventArgs e)
        {
            ClearControls();
        }

       

        private bool Validation()
        {

            if (this.txtOldPassword.Text.Trim().Length == 0 && chkIsNew.Checked==false)
            {
                MessageBox.Show("Please Enter Old Password.", "Enter Password...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtOldPassword.Focus();
                return false;
            }

            if (this.txtPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please Enter  Password.", "Enter Password...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtPassword.Focus();
                return false;
            }
            if (this.txtConfirmPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please Confirm Password.", "Confirm Password...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtConfirmPassword.Focus();
                return false;
            }
            if (this.txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Password not Matched", "Incorrect Password...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtConfirmPassword.Focus();
                return false;
            }

            else
                return true;

        }



      

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (Validation())
                {
                    Common.DiscountPassword common = new Common.DiscountPassword();
                    common.BranchID = Convert.ToInt32(cmbBranch.SelectedValue);
                    common.Password = txtPassword.Text;

                    // //CountExistedPwd = new DiscountOfferController().CheckExistedPwd(Convert.ToInt32(cmbBranch.SelectedValue));            
                    if (new DiscountOfferController().SavePassword(common,chkIsNew.Checked))
                    {

                        MessageBox.Show(" Password Updated Successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearControls();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnSave_Click_1", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtOldPassword_Leave_1(object sender, EventArgs e)
        {
            try
            {
                if (cmbBranch.SelectedIndex > -1)
                {
                    string ExistedPwd = new SaleInvoiceController().GetPassword(Convert.ToInt32(cmbBranch.SelectedValue));
                    if (ExistedPwd == txtOldPassword.Text)
                    {
                        txtPassword.Enabled = true;
                        txtConfirmPassword.Enabled = true;
                        txtPassword.Focus();

                    }
                    else
                    {
                        MessageBox.Show("Incorrect Old Password.", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtPassword.Enabled = false;
                        txtConfirmPassword.Enabled = false;
                        txtOldPassword.Clear();
                        txtOldPassword.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "txtOldPassword_Leave_1", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkIsNew_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsNew.Checked)
            {
                txtPassword.Enabled = true;
                txtConfirmPassword.Enabled = true;
                txtOldPassword.Enabled = false;
                int count = new DiscountOfferController().CheckExistedPwd(Convert.ToInt16(cmbBranch.SelectedValue));
                if (count > 0 )
                {
                    MessageBox.Show("Password Already exist on this Branch. Do not create new Password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPassword.Enabled = false;
                    txtConfirmPassword.Enabled = false;
                    txtOldPassword.Enabled = true;
                    chkIsNew.Checked = false;
                }

            }
            else
            {
                txtPassword.Enabled = false;
                txtConfirmPassword.Enabled = false;
                txtOldPassword.Enabled = true;
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using CategoryControlle;
using Accounts;

namespace Restorant_Management_System.Forms
{
    public partial class FrmBranch : Form
    {
        Branch b;
        private bool IsNew;
        
        public FrmBranch()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
        private bool LoadCity()
        {
            try
            {
                List<City> st = new CityController().GetCity();
                this.cmbCity.DataSource = st;
                cmbCity.ValueMember = "CityID";
                cmbCity.DisplayMember = "CityName";
                cmbCity.SelectedIndex = -1;


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadCategories", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool ClearControls()
        {
            try
            {
                this.txtID.Text = new BranchController().GetMaxID().ToString();
                this.txtName.Clear();
                txtPhone.Clear();
                txtEmail.Clear();
                txtAddress.Clear();
                txtSaleNote.Clear();
                this.IsNew = true;
                this.btnDelete.Enabled = false;
                txtName.Focus();
                LoadCity();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ClearControls", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void FrmBranch_Load(object sender, EventArgs e)
        {
            if (!User._IsAdmin)
            {
                CheckRights(Convert.ToInt16(this.Tag));
            }
            ClearControls();
        }
        private void CheckRights(int formid)
        {
            try
            {

                List<UserRight> right = new List<UserRight>();
                right = AccountsGlobals.UserRights;
                for (int i = 0; i < right.Count; i++)
                {
                    if (right[i].ID == formid)
                    {
                        btnEdit.Enabled = right[i].CanEdit;
                        btnDelete.Enabled = right[i].CanDelete;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message , "CheckRights", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validation())
                {
                    b = new Branch(Convert.ToInt32(this.txtID.Text), Convert.ToString(this.txtName.Text), Convert.ToInt32(this.cmbCity.SelectedValue), Convert.ToBoolean(this.chkIsWarehouse.Checked), Convert.ToString(this.txtPhone.Text), Convert.ToString(this.txtEmail.Text), Convert.ToString(this.txtAddress.Text), Convert.ToString(this.txtSaleNote.Text));

                    if (new BranchController().Save(b, IsNew))
                    {
                        if (IsNew)
                        {
                            MessageBox.Show("Branch saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Branch Updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        ClearControls();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save_Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private bool Validation()
        {
            if (txtName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please Enter Branch Name", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtName.Focus();
                return false;
            }
            if (cmbCity.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please Enter City", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cmbCity.Focus();
                return false;
            }
            if (txtPhone.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please Enter Phone No.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtPhone.Focus();
                return false;
            }
            if (txtEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please Enter Email.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtEmail.Focus();
                return false;
            }
            if (txtAddress.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please Enter Address.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtAddress.Focus();
                return false;
            }
            if (txtSaleNote.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please Enter Sale Note.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtSaleNote.Focus();
                return false;
            }

            return true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (new BranchController().Delete(this.txtID.Text))
                {
                    MessageBox.Show("Please Enter Branch Name", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    ClearControls();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Sch_Forms.SchBranch frm = new Sch_Forms.SchBranch();
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                frm.ShowDialog();
                b = frm.branch;
                if (b != null)
                {
                    this.txtID.Text = b.ID.ToString();
                    this.txtName.Text = b.BranchName;
                    cmbCity.Text = b.CityName;
                    chkIsWarehouse.Checked = b.IsWarehouse;
                    txtPhone.Text = b.Phone;
                    txtEmail.Text = b.Email;
                    txtAddress.Text = b.Address;
                    txtSaleNote.Text = b.SaleNote;
                    txtName.Focus();
                    IsNew = false;
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

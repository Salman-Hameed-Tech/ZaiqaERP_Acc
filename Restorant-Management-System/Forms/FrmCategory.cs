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
    public partial class FrmCategory : Form
    {
        private bool IsNew;
        
        public FrmCategory()
        {
            InitializeComponent();
        }
       
        private bool ClearControls()
        {
            try
            {
                this.txtID.Text  = new CategoryController().GetMaxID().ToString();
                this.txtName.Clear();
              
                this.IsNew = true;
                this.btnDelete.Enabled = false;
                txtName.Focus();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ClearControls", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void LoadDepartment()
        {
            DataSet ds = new DataSet();
            ds = new CategoryControlle.DepartmentController().LoadDepartment();
            cmbDepartment.DataSource = ds.Tables[0];
            cmbDepartment.DisplayMember = "DepartName";
            cmbDepartment.ValueMember = "DepartID";
        }

        private bool ValidateControls()
        {
            try
            {
                if (txtName.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Please Enter Category Name!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Focus();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ValidateControls", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool Save()
        {
            try
            {
                if (ValidateControls())
                {
                    Category category = new Category(Convert.ToInt32(txtID.Text.Trim()), txtName.Text.Trim());
                    if (new CategoryController().SaveCategory(category, IsNew))
                    {
                        MessageBox.Show("Category Saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information );
                        ClearControls();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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
                MessageBox.Show("" + ex + "", "CheckRights", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FrmCategory_Load(object sender, EventArgs e)
        {
            try
            {
                if (!User._IsAdmin)
                {
                    CheckRights(Convert.ToInt16(this.Tag));
                }
                ClearControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load_Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void tsbtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you really want to delete this Category?", "Confirmation", MessageBoxButtons.YesNo , MessageBoxIcon.Question );
                if (result == DialogResult.Yes)
                {
                    new CategoryController().DeleteCategory(new Category(Convert.ToInt32(txtID.Text.Trim()), ""));
                    MessageBox.Show("Category has been Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information );
                    ClearControls();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "tsbtnDelete_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                SchForms.SchCategory sch = new SchForms.SchCategory();
                sch.ShowDialog();
                Category category = sch.item;

                if (category != null)
                {
                    this.txtID.Text = category.Id.ToString();
                    this.txtName.Text = category.Name.ToString();
                  


                    IsNew = false;
                    btnDelete.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "tsbtnEdit_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Category c = new Category();
            c.Id = Convert.ToInt32(txtID.Text);
            if(new CategoryControlle.CategoryController().DeleteCategory(c))
            {
                MessageBox.Show("Category has been Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearControls();
            }
        }
    }
}

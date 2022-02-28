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
    public partial class frmDepartment : Form
    {
        Department dept;
        private bool IsNew = true;
        public frmDepartment()
        {
            InitializeComponent();
        }

        private void frmDepartment_Load(object sender, EventArgs e)
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
                        //btnDelete.Enabled = right[i].CanDelete;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex + "", "CheckRights", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearControls()
        {
            txtDepartID.Text = new CategoryControlle.DepartmentController().GetMaxID();
            txtDepartName.Clear();
            txtDepartName.Focus();
            btnDelete.Enabled = false;
            IsNew = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validation())
                {
                    dept = new Department(Convert.ToInt32(txtDepartID.Text), Convert.ToString(txtDepartName.Text),false);
                    if(new DepartmentController().Save(dept, IsNew))
                    {
                        if(IsNew)
                        {
                            MessageBox.Show("Department saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Department Updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        ClearControls();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Save_Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool Validation()
        {
            if(txtDepartName.Text.Trim().Length==0)
            {
                MessageBox.Show("Please Enter Department Name", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtDepartName.Focus();
                return false;
            }
            return true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
               if( new DepartmentController().Delete(txtDepartID.Text))
                {
                    MessageBox.Show("Please Enter Department Name", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                Sch_Forms.SchDepartment frm = new Sch_Forms.SchDepartment();
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                frm.ShowDialog();
                 dept= frm.Depart;
                if (dept != null)
                {
                    txtDepartID.Text = dept.DepartID.ToString();
                    txtDepartName.Text = dept.DepartName;
                    txtDepartName.Focus();
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

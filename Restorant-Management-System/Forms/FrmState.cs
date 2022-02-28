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
    
    public partial class FrmState : Form
    {
        States S;

        private bool IsNew;
        public FrmState()
        {
            InitializeComponent();
        }

        private void FrmState_Load(object sender, EventArgs e)
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
                MessageBox.Show("" + ex + "", "CheckRights", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool Validation()
        {
            if (txtName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please Enter State Name", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtName.Focus();
                return false;
            }
            return true;
        }
        private bool ClearControls()
        {
            try
            {
                this.txtID.Text = new StateController().GetMaximumID().ToString();
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validation())
                {
                    S = new States(Convert.ToInt32(this.txtID.Text), Convert.ToString(this.txtName.Text));
                    if (new StateController().Save(S, IsNew))
                    {
                        if (IsNew)
                        {
                            MessageBox.Show("State saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("State Updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (new StateController().Delete(this.txtID.Text))
                {
                    MessageBox.Show("Please Enter State Name", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                Sch_Forms.SchState frm = new Sch_Forms.SchState();
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                frm.ShowDialog();
                S = frm.counter;
                if (S != null)
                {
                    this.txtID.Text = S.ID.ToString();
                    this.txtName.Text = S.StateName;
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

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
    public partial class FrmCounter : Form
    {
        Counter c;
        private bool IsNew;
        public FrmCounter()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void FrmCounter_Load(object sender, EventArgs e)
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
        private bool ClearControls()
        {
            try
            {
                this.txtID.Text = new CounterController().GetMaxID().ToString();
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
        private bool Validation()
        {
            if (txtName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please Enter Counter Name", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtName.Focus();
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validation())
                {
                    c = new Counter(Convert.ToInt32(this.txtID.Text), Convert.ToString(this.txtName.Text));
                    if (new CounterController().Save(c, IsNew))
                    {
                        if (IsNew)
                        {
                            MessageBox.Show("Counter saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Counter Updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (new CounterController().Delete(this.txtID.Text))
                {
                    MessageBox.Show("Please Enter Counter Name", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                Sch_Forms.SchCounter frm = new Sch_Forms.SchCounter();
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                frm.ShowDialog();
                c = frm.counter;
                if (c != null)
                {
                    this.txtID.Text = c.ID.ToString();
                    this.txtName.Text = c.CounterName;
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

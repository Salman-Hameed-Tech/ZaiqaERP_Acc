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

namespace Accounts
{
    public partial class FrmCity : Form
    {
        private City city;
        private CityController cc = new CityController();
        private List<City> cities = new List<City>();
        private bool IsNew;
        public FrmCity()
        {
            InitializeComponent();
        }

        private void FrmGodown_Load(object sender, EventArgs e)
        {
            if (!User._IsAdmin)
            {
                CheckRights(Convert.ToInt16(this.Tag));
            }

            this.BackColor = AccountsGlobals.FormColor;
            this.txtCategoryID.Text = cc.GetMaximimID().ToString();
            //LoadStates();
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

        private bool LoadStates()
        {
            try
            {
                List<States> st = new StateController().GetStates();
                this.cmbState.DataSource = st;
                cmbState.ValueMember = "ID";
                cmbState.DisplayMember = "StateName";


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadCategories", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private Boolean ValidateControl()
        {

            if (this.txtCategoryName.Text.Trim().Length == 0)
                return false;
            else
                return true;
        }

        public void ClearControls()
        {
            this.txtCategoryID.Text = cc.GetMaximimID().ToString();
            this.txtCategoryName.Text = "";
          
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

      

        private void tsbtnClear_Click(object sender, EventArgs e)
        {
            
        }

        private void tsbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
           
        }
        private void Save()
        {
            try
            {
                if (ValidateControl() == true)
                {
                    //txtCategoryID.Text = Convert.ToString(0);
                    City c = new City(Convert.ToInt32(this.txtCategoryID.Text.Trim()), this.txtCategoryName.Text);
                    c.StateID = Convert.ToInt32(this.cmbState.SelectedValue);
                    cc.SaveCity(c, IsNew);
                    MessageBox.Show("City has been Saved.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearControls();
                }
                else
                {
                    MessageBox.Show("Please Enter City Name.");
                    this.txtCategoryName.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmCity SaveRecord", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FrmCity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmCity_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Restorant_Management_System.Sch_Forms.SchCity frm = new Restorant_Management_System.Sch_Forms.SchCity();
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                frm.ShowDialog();
                city= frm.counter;
                if (city != null)
                {
                    this.txtCategoryID.Text = city.CityID.ToString();
                    this.txtCategoryName.Text = city.CityName;
                    cmbState.Text = city.StateName;
                    txtCategoryName.Focus();
                     IsNew= false;
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (new CityController().Delete(this.txtCategoryID.Text))
                {
                    MessageBox.Show("Please Enter city Name", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    ClearControls();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

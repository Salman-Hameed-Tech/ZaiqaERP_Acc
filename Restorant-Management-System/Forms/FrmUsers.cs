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
    public partial class FrmUsers : Form
    {
        private User user;
        private bool isNew = true;

        byte[] signature;

        public FrmUsers()
        {
            InitializeComponent();
        }
        private void FrmUsers_Load(object sender, EventArgs e)
        {
            try
            {
                if (!User._IsAdmin)
                {
                    CheckRights(Convert.ToInt16(this.Tag));
                }


           
                ClearControls();
                
                //this.tsbtnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmUsers_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        this.tsbtnEdit.Enabled = right[i].CanEdit;
                        this.tsbtnDelete.Enabled = right[i].CanDelete;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex + "", "CheckRights", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool LoadGrid()
        {
            try
            {
                //Set Grid.
                ///////////////////////////////////////////////////////////////////////////////////////////////////
                AccountsGlobals.SetGridStyle(ref Grd);

                //////////////////////////////////////////////////////////////////////////////////////////////////              
                //Specify which type of cell in this column (DataGridViewTextBoxCell,DataGridViewCheckBoxCell,
                //DataGridViewComboBoxCell,DataGridViewImageColumn,DataGridViewButtonColumn,DataGridViewLinkColumn


                DataGridViewCell TextCell = new DataGridViewTextBoxCell();
                DataGridViewCell CheckCell = new DataGridViewCheckBoxCell();
                //DataGridViewCell IntCell = new TNumEditDataGridViewCell(0);


                // To avoid all the annoying error messages, handle the DataError event of the DataGridView:
                Grd.DataError += new DataGridViewDataErrorEventHandler(Grd_DataError); 

                //Col 1
                //////////////////////////////////////////////////////////////////////////////////////////////////                

                DataGridViewColumn newCol = new DataGridViewColumn(); // add a column to the grid                        
                newCol.CellTemplate = TextCell;
                newCol.HeaderText = "Form No.";
                newCol.Name = "FormID";
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.ReadOnly = true;
                newCol.Width = 60;
                Grd.Columns.Add(newCol);

                //Col 2
                //////////////////////////////////////////////////////////////////////////////////////////////////                
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Form Name";
                newCol.Name = "FormName";
                newCol.CellTemplate = TextCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                newCol.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                newCol.ReadOnly = true;
                newCol.Width = 100;
                Grd.Columns.Add(newCol);

                //Col 3
                //////////////////////////////////////////////////////////////////////////////////////////////////                
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Can Access";
                newCol.Name = "CanAccess";
                newCol.CellTemplate = CheckCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = false;
                newCol.Width = 50;
                Grd.Columns.Add(newCol);


                //Col 4
                //////////////////////////////////////////////////////////////////////////////////////////////////                
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Can Edit";
                newCol.Name = "CanEdit";
                newCol.CellTemplate = CheckCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = false;
                newCol.Width = 50;
                Grd.Columns.Add(newCol);

                //Col 5
                //////////////////////////////////////////////////////////////////////////////////////////////////                
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Can Delete";
                newCol.Name = "CanDelete";
                newCol.CellTemplate = CheckCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = false;
                newCol.Width = 50;
                Grd.Columns.Add(newCol);


                Grd.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                AccountsGlobals.ExtendCol(ref Grd, "FormName");

              


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Grd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
        }
        private bool LoadGrdDepartment()
        {
            try
            {
                //Set Grid.
                ///////////////////////////////////////////////////////////////////////////////////////////////////
                AccountsGlobals.SetGridStyle(ref GrdDepartment);

                //////////////////////////////////////////////////////////////////////////////////////////////////              
                //Specify which type of cell in this column (DataGridViewTextBoxCell,DataGridViewCheckBoxCell,
                //DataGridViewComboBoxCell,DataGridViewImageColumn,DataGridViewButtonColumn,DataGridViewLinkColumn


                DataGridViewCell TextCell = new DataGridViewTextBoxCell();
                DataGridViewCell CheckCell = new DataGridViewCheckBoxCell();
                //DataGridViewCell IntCell = new TNumEditDataGridViewCell(0);


                // To avoid all the annoying error messages, handle the DataError event of the DataGridView:
                GrdDepartment.DataError += new DataGridViewDataErrorEventHandler(Grd_DataError);

                //Col 1
                //////////////////////////////////////////////////////////////////////////////////////////////////                

                DataGridViewColumn newCol = new DataGridViewColumn(); // add a column to the grid                        
                newCol.CellTemplate = TextCell;
                newCol.HeaderText = "Department ID";
                newCol.Name = "ID";
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.ReadOnly = true;
                newCol.Width = 70;
                GrdDepartment.Columns.Add(newCol);

                //Col 2
                //////////////////////////////////////////////////////////////////////////////////////////////////                
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Department Name";
                newCol.Name = "DepartmentName";
                newCol.CellTemplate = TextCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;
                newCol.Width = 100;
                GrdDepartment.Columns.Add(newCol);

                //Col 3
                //////////////////////////////////////////////////////////////////////////////////////////////////                
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Can Login";
                newCol.Name = "CanLogin";
                newCol.CellTemplate = CheckCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = false;
                newCol.Width = 60;
                GrdDepartment.Columns.Add(newCol);


               



                AccountsGlobals.ExtendCol(ref GrdDepartment, "DepartmentName");




                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Grd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
        }

        private bool LoadRights(List<UserRight > lines)
        {
            try
            {
                Grd.Rows.Clear();
                for (int i = 0; i < lines.Count; i++)
                {
                    int rowIndex = Grd.Rows.Add();

                    Grd.Rows[rowIndex].Cells["FormID"].Value = lines[i].ID;
                    Grd.Rows[rowIndex].Cells["FormName"].Value = lines[i].FormName;
                    Grd.Rows[rowIndex].Cells["CanAccess"].Value = lines[i].CanAccess;
                    Grd.Rows[rowIndex].Cells["CanEdit"].Value = lines[i].CanEdit;
                    Grd.Rows[rowIndex].Cells["CanDelete"].Value = lines[i].CanDelete;                    
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadRights", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool LoadDepartments(List<DepartmentRights> lines)
        {
            try
            {
                GrdDepartment.Rows.Clear();
                for (int i = 0; i < lines.Count; i++)
                {
                    int rowIndex = GrdDepartment.Rows.Add();

                    GrdDepartment.Rows[rowIndex].Cells["ID"].Value = lines[i].ID;
                    GrdDepartment.Rows[rowIndex].Cells["DepartmentName"].Value = lines[i].DepartmentName;
                    GrdDepartment.Rows[rowIndex].Cells["CanLogin"].Value = lines[i].CanLogin;
                   
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadRights", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private List<UserRight > PopulateRights()
        {
            try
            {
                List<UserRight> rights = new List<UserRight>();

                for (int i = 0; i < Grd.Rows .Count ; i++)
                {
                    if (Grd.Rows[i].Cells["FormID"].Value != null)
                    {
                        UserRight right = new UserRight();
                        int rowIndex = Grd.Rows.Add();

                        right.ID = Convert.ToInt32(Grd.Rows[i].Cells["FormID"].Value);
                        right.FormName = Grd.Rows[i].Cells["FormName"].Value.ToString();
                        right.CanAccess = Convert.ToBoolean(Grd.Rows[i].Cells["CanAccess"].Value);
                        right.CanEdit = Convert.ToBoolean(Grd.Rows[i].Cells["CanEdit"].Value);
                        right.CanDelete = Convert.ToBoolean(Grd.Rows[i].Cells["CanDelete"].Value);

                        rights.Add(right);
                    }
                }
                return rights;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PopulateRights", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
 
        }

        void Grd_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // (No need to write anything in here) 
        } 

        private bool  ValidateControls()
        {
            try
            {
                if (this.txtUserName.Text.Trim().Length ==0)
                {
                    MessageBox.Show("Please Enter User Name.","Enter User Name...",MessageBoxButtons.OK ,MessageBoxIcon.Error);
                    this.txtUserName.Focus();
                    return false;
                }
                else if (this.txtUserName.Text.Trim().Contains("'"))
                {
                    MessageBox.Show("Please Enter Valid User Name.", "Enter Valid User Name...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtUserName.Focus();
                    return false;
                }
                else if (this.txtPassword.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Please Enter User Password.", "Enter Password...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtPassword.Focus();
                    return false;
                }
                else if (this.txtConfirmPassword.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Please Confirm User Password.", "Confirm Password...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtConfirmPassword.Focus();
                    return false;
                }
                else if (this.txtPassword.Text.Trim() != this.txtConfirmPassword.Text.Trim ())
                {
                    MessageBox.Show("Password and Confirm Password fields does not Match.", "Confirm Password...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtPassword.Focus();
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {               
                MessageBox.Show(ex.Message,"FrmUsers ValidateControls",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
        }
        private void ClearControls()
        {
            try
            {
                this.txtUserName.Clear();
                this.txtPassword.Clear();
                this.txtConfirmPassword.Clear();
                cmbBranch.Enabled = true;
                this.chkIsAdmin.Checked = false;
                this.chkIsActive.Checked = true;

                this.txtUserName.Focus();
                this.signature = new byte[0];
                this.pictureBox.Image = null;
                this.txtUserID.Text = new UserController().GetMaximumID().ToString();

                this.tsbtnDelete.Enabled = false;
                chkIsActive.Visible = true ;
             
                LoadGrid();
             

                LoadRights(new UserController().GetUserRights(0));
          
                this.isNew = true;
              
                LoadBranch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"FrmUsers ClearControls",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private bool LoadCounters()
        {
            try
            {
                List<DepartmentRights> counters = new DepartmentController().GetDepatment(0);
               
                cmbCounter.DataSource = counters;
                cmbCounter.ValueMember = "ID";
                cmbCounter.DisplayMember = "DepartmentName";


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadCategories", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool LoadBranch()
        {
            try
            {
                List<Branch> counters = new BranchController().GetBranch("");
                cmbBranch.DataSource = counters;
                cmbBranch.ValueMember = "ID";
                cmbBranch.DisplayMember = "BranchName";


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadCategories", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {                
                if (e.KeyCode == Keys.Enter)
                {
                    System.Windows.Forms.SendKeys.Send("\t");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmUser txtUserName_KeyDown.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbtnClear_Click(object sender, EventArgs e)
        {
            this.ClearControls();
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateControls())
                {
                    if (isNew == true)
                    {
                        this.txtUserID.Text = Convert.ToString(0);
                    }
                    User u = new User(Convert.ToInt32(this.txtUserID.Text), this.txtUserName.Text, this.txtPassword.Text, this.chkIsActive.Checked, this.chkIsAdmin.Checked,0,this.chkIsCashCounter.Checked);
                    u.Signatures = signature;

                    u.BranchID = Globals.BranchID;// Convert.ToInt32(cmbBranch.SelectedValue);
                    u.Allusers = (chkAllAccess.Checked);
                   
              
                    txtUserName.Focus();
                    
                    u.Rights = PopulateRights();
                    u.DepRights = PopulateDeprtRights();

                    if (new UserController().SaveUser(u))
                    {
                        MessageBox.Show("User is Saved Seccessfully.", "Saved...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    ClearControls();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "tsbtnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<DepartmentRights> PopulateDeprtRights()
        {
            try
            {
                List<DepartmentRights> rights = new List<DepartmentRights>();

                for (int i = 0; i < GrdDepartment.Rows.Count; i++)
                {
                    if (this.GrdDepartment.Rows[i].Cells["ID"].Value != null)
                    {
                        DepartmentRights right = new DepartmentRights();
                        int rowIndex = GrdDepartment.Rows.Add();

                        right.ID = Convert.ToInt32(GrdDepartment.Rows[i].Cells["ID"].Value);
                        right.DepartmentName = GrdDepartment.Rows[i].Cells["DepartmentName"].Value.ToString();
                        right.CanLogin = Convert.ToBoolean(GrdDepartment.Rows[i].Cells["CanLogin"].Value);
                      

                        rights.Add(right);
                    }
                }
                return rights;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PopulateRights", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void tsbtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
             

                SchForms.SchUsers frm = new  SchForms.SchUsers();
                frm.ShowDialog();
               
                if (frm.item  != null)
                {
                    ClearControls();
                    cmbBranch.Enabled = false;
                    this.user = frm.item;

                    this.txtUserID.Text = frm.item.UserID.ToString();
                    this.txtUserName.Text = frm.item.UserName;
                    this.txtPassword.Text = frm.item.UserPassword;
                    this.txtConfirmPassword.Text = frm.item.UserPassword;
                    this.chkIsActive.Checked = frm.item.IsActive;
                    this.chkIsAdmin.Checked = frm.item.IsAdmin;
                    this.cmbBranch.Text = frm.item.BranchName;
                   // this.cmbCounter.Text = frm.item.CounterName;
                  //  chkIsCashCounter.Checked = frm.item.IsCashCounter;
                    if (this.signature != null)
                    {
                        this.signature = frm.item.Signatures;
                    }
                  

                    this.tsbtnDelete.Enabled = true;
                    this.isNew = false;
                   // LoadDepartments(frm.item.DepRights);
                    LoadRights(frm.item.Rights);

                 

                }                   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "tsbtnEdit_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tsbtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult r = MessageBox.Show("Are you sure you want to delete this user.", "Confirm Deleteion...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    if (new UserController().DeleteUser(user))
                    {
                        MessageBox.Show("User has been Deleted Successfully.", "Deletion Success...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearControls();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "tsbtnDelete_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmUsers_Fill_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Filter = "Image Files (*.jpg)|*.jpg";
                DialogResult result = op.ShowDialog();

                if (result == DialogResult.OK)
                {
                    Image myImg = Image.FromFile(op.FileName);
                    signature = AccountsGlobals.imageToByteArray(myImg);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Image = myImg;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnBrowse_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void chkIsAdmin_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkAllAccess_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAllAccess.Checked)
                {
                    for (int i = 0; i < Grd.Rows.Count; i++)
                    {
                        Grd.Rows[i].Cells["CanAccess"].Value = true;
                        Grd.Rows[i].Cells["CanEdit"].Value = true;
                        Grd.Rows[i].Cells["CanDelete"].Value = true;
                    }
                }
                else
                {
                    for (int i = 0; i < Grd.Rows.Count; i++)
                    {
                        Grd.Rows[i].Cells["CanAccess"].Value = false;
                        Grd.Rows[i].Cells["CanEdit"].Value = false;
                        Grd.Rows[i].Cells["CanDelete"].Value = false;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "chkAllAccess_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

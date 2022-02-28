using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Common;
using CategoryControlle;
using Restorant_Management_System;

namespace Accounts
{
    public partial class FrmLogin : Form
    {
        public static int UserID;

        public FrmLogin()
        {
            InitializeComponent();
        }


        private Forms. Test frmSplash;


        public delegate void UpdateUIDelegate(bool IsDataLoaded);

        private void UpdateUI(bool IsDataLoaded)
        {
            if (IsDataLoaded)
            {

                // close the splash form
                if (this.frmSplash != null)
                {
                    frmSplash.Close();
                }
            }

        }

        public void setCompanyInfo()
        {
           /* try
            {
                SysLocal.InfoCls.ProjName = "ACC";
                //Like Prosofmods.com

                SysLocal.InfoCls.CompnyName = "Prosofmods.com";

                SysLocal.InfoCls.ProjDBName = "ACC";

                SysLocal.InfoCls.NoOfHits = 10;
                SysLocal.InfoCls.MyREG_Code = SysLocal.InfoCls.Get_Reg_Code().ToString();
                SysLocal.InfoCls.MyACT_Code = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmLogIn setCompanyInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
        }

        private void DoSomeWork()
        {
            // This is time consuming operation - loading data, etc.
            System.Threading.Thread.Sleep(10000);

            // Update UI
            Invoke(new UpdateUIDelegate(UpdateUI), new object[] { true });
        }

        
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.BackColor = AccountsGlobals.FormColor;
           // cmbUserName.Focus();
            cmbUserName.Select();
            cmbUserName.DataSource = new UserController().GetUsers(0);
            cmbUserName.DisplayMember = "UserName";
            cmbUserName.ValueMember = "Userid";


          
            this.FormBorderStyle = FormBorderStyle.None;
            txtPassword.Focus();
           
        }


        public bool validateControls()
        {
            try
            {
                if (this.cmbUserName.Text.Trim ().Length == 0)
                {
                    MessageBox.Show("Please Enter User Name.","Enter User...",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    this.cmbUserName.Focus();
                    return false;
                }
                else if (this.txtPassword.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Please Enter Password.", "Enter Password...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtPassword.Focus();
                    return false;
                }
               
                


                return true;
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message,"FrmLogIn BtnLogIn_Click",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateControls ())
                {
                    User u = new User(0, this.cmbUserName.Text, this.txtPassword.Text);
                    User verifiedUser = new UserController().VerifyUser(u);

                    UserID = Convert.ToInt32(cmbUserName.SelectedValue);
                    if (verifiedUser!=null)
                    {
                         setCompanyInfo();
                        AccountsGlobals.ServerDate = new UserController().GetServerDate(); 
                      
                     
                          User._IsAdmin = verifiedUser.IsAdmin;
                          User._UserName = verifiedUser.UserName;
                           

                          User.UserNo = verifiedUser.UserID;
                          Globals.BranchID = verifiedUser.BranchID;
                          Globals.IsCashCounter = verifiedUser.IsCashCounter;

                            AccountsGlobals.UserRights = new UserController().GetUserRights(User.UserNo);

                        Summary.SummaryNo = new SummaryController().MakeSummary(verifiedUser.UserID);
                         
                        //if(new UserController().)
                        string branchname = new BranchController().GetCurrentBranch( Globals.BranchID);
                        FrmMain frm = new FrmMain();                   
                        frm._departmentName = "    You are Login with  Branch -  ( "+ branchname+" )   and User - ( "+User._UserName+" )";
                      
                        this.Hide();
                        frm.ShowDialog();
                        

                    }
                    else
                    {
                        MessageBox.Show("Invalid User Name and/or Password.","Invalid user...",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                        this.txtPassword.Clear();
                        this.cmbUserName.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"FrmLogIn BtnLogIn_Click",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys .Enter )
                {
                    System.Windows.Forms.SendKeys.Send("\t");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmLogIn txtUserName_keyDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmLogIn btnExit_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    User u = new User(0, this.cmbUserName.Text, this.txtPassword.Text);
            //    User verifiedUser = new UserController().VerifyUser(u);

            //    if (verifiedUser.IsAdmin)
            //    {
            //        cmbDepartments.DataSource = new UserController().GetDepart(" where dr.CanLogin=1  ");
            //    }
            //    else
            //    {
            //        cmbDepartments.DataSource = new UserController().GetDepart(" where UserID=" + Convert.ToInt32(cmbUserName.SelectedValue) + " and dr.CanLogin=1 ");
                   
            //    }


            //    cmbDepartments.DisplayMember = "DepartName";
            //    cmbDepartments.ValueMember = "DepartID";
            //    cmbDepartments.SelectedIndex = -1;

            //}
            //catch(Exception)
            //{ }
          
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

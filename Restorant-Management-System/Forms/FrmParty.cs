
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
using Accounts.Forms;
using Accounts.SchForms;

namespace Accounts
{
    public partial class FrmParty : Form
    {
        public int Opt, Operation, IsDetailed, IsEditable, IsLocked, AccountDepth,cityID;
        List<Branch> Branchlist = new List<Branch>();
        public bool isNew=true;
        private string type;
        public string  partyName = "";
        ChartofAccountsController cc = new ChartofAccountsController();
        VendorController vc = new VendorController();
        public List<Branch> branches = new List<Branch>();

        public FrmParty()
        {
            InitializeComponent();
        }

        private void FrmNewAccount_Load(object sender, EventArgs e)
        {
            try
            {
              //  this.BackColor = AccountsGlobals.FormColor;
                if (this.Operation == 1)
                {
                    string ext = cc.GetPartyExtension(this.txtParentAccount.Text,this.txtAccountType.Text);

                    if (ext.Trim().Length > 0)
                    {
                        this.txtAccountExtention.Text = ext.Substring(this.txtParentAccount.Text.Length);
                    }
                    else
                    {
                        this.txtAccountExtention.Text = "1";
                    }   
                    
                }
                LoadCity();

          //      LoadBranchGrid();
                LoadBranches();
                PopulateEditBranches();
                this.cmbPartyName.DataSource = new ChartofAccountsController().GetNames("Select AccountName as Name from ChartOfAccounts where AccountNo like '6%'");
                this.cmbPartyName.Text = partyName;
                this.cbxCity.SelectedValue = cityID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"FrmNewAccount_Load",MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }            
        }

        private void PopulateEditBranches()
        {
            if (branches.Count > 0)
            {
                for (int i = 0; i < branches.Count; i++)
                {
                    for (int j = 0; j < Grd.Rows.Count - 1; j++)
                    {

                        if (Convert.ToInt32(Grd.Rows[j].Cells["ID"].Value) == branches[i].ID)
                        {
                            Grd.Rows[j].Cells["Select"].Value = branches[i].Select;
                        }

                    }
                }

            }
        }

        private void LoadBranches()
        {
            branches.Clear();
           // LoadBranchGrid();
            Branchlist = new CategoryControlle.BranchController().GetBranch("");
            branches = Branchlist;
            //if (Branchlist.Count > 0)
            //{
            //    for (int i = 0; i < Branchlist.Count; i++)
            //    {
            //        int rowIndex = Grd.Rows.Add();

            //        Grd.Rows[i].Cells["ID"].Value = Branchlist[i].ID;
            //        Grd.Rows[i].Cells["Branch"].Value = Branchlist[i].BranchName;                  
            //    }

            //}
            //Grd.Columns["Branch"].Width = 185;
            //Grd.Columns["ID"].Width = 30;
        }
        private bool LoadBranchGrid()
        {
            try
            {
                //Set Grid.
                ///////////////////////////////////////////////////////////////////////////////////////////////////
                AccountsGlobals.SetGridStyle(ref Grd);

                Grd.EnableHeadersVisualStyles = false;
                //////////////////////////////////////////////////////////////////////////////////////////////////              
                //Specify which type of cell in this column (DataGridViewTextBoxCell,DataGridViewCheckBoxCell,
                //DataGridViewComboBoxCell,DataGridViewImageColumn,DataGridViewButtonColumn,DataGridViewLinkColumn



                DataGridViewCell TextCell = new DataGridViewTextBoxCell();
                DataGridViewCell DecimalCell = new TNumEditDataGridViewCell(2);
                DataGridViewCell RateCell = new TNumEditDataGridViewCell(4);
                DataGridViewCell IntCell = new TNumEditDataGridViewCell(0);

                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                DataGridViewComboBoxColumn comboCol = new DataGridViewComboBoxColumn();
                DataGridViewCell ComboCell = new DataGridViewComboBoxCell();

                DataGridViewComboBoxColumn comboCol2 = new DataGridViewComboBoxColumn();
                DataGridViewCell ComboCell2 = new DataGridViewComboBoxCell();

                //Col 1
                //////////////////////////////////////////////////////////////////////////////////////////////////                


                DataGridViewColumn newCol = new DataGridViewColumn(); // add a column to the grid     

                ////////////////////
                newCol = new DataGridViewColumn();
                newCol.CellTemplate = TextCell;
                newCol.HeaderText = "ID";
                newCol.Name = "ID";
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.ReadOnly = true;
                newCol.Width = 50;
                Grd.Columns.Add(newCol);
                /////////////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.CellTemplate = TextCell;
                newCol.HeaderText = "Branch";
                newCol.Name = "Branch";
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.ReadOnly = true;
                newCol.Width = 200;
                Grd.Columns.Add(newCol);
                //////////////////////////////////////////
                checkColumn = new DataGridViewCheckBoxColumn();
                checkColumn.HeaderText = "Select";
                checkColumn.Name = "Select";
                // checkColumn.CellTemplate = IntCell;
                checkColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                checkColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                checkColumn.Visible = true;
                checkColumn.Width = 40;
                Grd.Columns.Add(checkColumn);
                /////////////////////////////////////
                ///
            
                AccountsGlobals.ExtendCol(ref Grd, "Branch");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void LoadCity()
        {
            try
            {
                this.cbxCity.DataSource = new CityController().GetCity();
                this.cbxCity.DisplayMember = "CityName";
                this.cbxCity.ValueMember = "CityId";

                this.cbxCity.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cbxCity.AutoCompleteSource = AutoCompleteSource.ListItems;

                this.cbxCity.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmItem LoadCategory");
            }
        }
        private bool ValidateControls()
        {
            try
            {

                if (this.txtAccountExtention.Text.Trim().Length == 0)
                {
                    if (this.Operation == 1) //Incase of new account
                    {
                        MessageBox.Show("Please enter Account Extension.", "Check Extension...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtAccountExtention.Focus();
                        return false;
                    }
                    else //Incase of updating old account
                    {
                        return true;
                    }
                    
                }
                else if (this.cmbPartyName.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Please enter Account Name.", "Check Account Name...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.cmbPartyName.Focus();
                    return false;
                }
                else if (this.txtAddress.Text .Trim ().Length ==0)
                {
                    MessageBox.Show("Please enter Address.", "Check Address...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtAddress.Focus();
                    return false;
                }
                else if (this.cbxCity.SelectedIndex == -1)
                {
                    MessageBox.Show("Please enter City.", "Check City...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.cbxCity.Focus();
                    return false;
                }
                else if (this.txtAddress.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Please enter Address.", "Check Address...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtAddress.Focus();
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"FrmNewAccounts ValidateControls",MessageBoxButtons.OK ,MessageBoxIcon.Exclamation);
                return false;
            }
        }

        private void ClearControls()
        {
            try
            {
                this.txtAccountExtention.Clear();
                string ext = cc.GetPartyExtension(this.txtParentAccount.Text, this.txtAccountType.Text);

                if (ext.Trim().Length > 0)
                {
                    this.txtAccountExtention.Text = ext.Substring(this.txtParentAccount.Text.Length);
                }
                else
                {
                    this.txtAccountExtention.Text = "1";
                }                
                this.txtAddress.Clear();
                this.txtContactPerson.Clear();
                this.txtEmail.Clear();
                this.txtFax.Clear();
                this.txtFaxCity.Clear();
                this.txtFaxCountry.Clear();
                this.txtHomeCity.Clear();
                this.txtHomeCountry.Clear();
                this.txtMobile.Clear();
                this.txtMobileCity.Clear();
                this.txtMobileCountry.Clear();
                this.txtOfficeCity.Clear();
                this.txtOfficeCountry.Clear();
                this.cmbPartyName.Text = "";
                this.txtPhoneHome.Clear();
                this.txtPhoneOffice.Clear();

                this.chkPurchase.Checked = false;
                this.chkSale.Checked = false;
                this.chkIsPos.Checked = false;
                this.txtVisaNo.Text = "";
                this.txtpassportno.Text = "";
                this.txtTenacyContact.Text = "";
                this.txtVehiclesRegNo.Text = "";
                this.VisadateTimePicker.Value = DateTime.Now;
                this.passportdateTimePicker.Value = DateTime.Now;
                this.TradedateTimePicker.Value = DateTime.Now;
                this.TenancydateTimePicker.Value = DateTime.Now;
                this.VehiclesdateTimePicker.Value = DateTime.Now;
                this.txtTradeLicenseNo.Text = "";
                txtGRVAccount.Clear();
                txtGRVAccountName.Clear();

                this.cbxCity.SelectedIndex = -1;
                if (isNew == false )
                {
                    isNew = true;
                    this.txtAccountExtention.Enabled = true;
                }
                this.txtAccountExtention.Focus();
                LoadBranches();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"FrmNewAccounts ClearControls",MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
        }

        private void AddBranches()
        {
            try
            {
                branches = new List<Branch>();
                Branch b = new Branch();
                b.ID = Globals.BranchID; 
                branches.Add(b);
                //for (int i = 0; i <= Grd.Rows.Count-1; i++)
                //{

                //    if (Convert.ToBoolean(Grd.Rows[i].Cells["Select"].Value) == true)
                //    {
                //        Branch b = new Branch();
                //        b.ID = Convert.ToInt32(Grd.Rows[i].Cells["ID"].Value);

                //        branches.Add(b);
                //    }

                //}
                //this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool SaveAccount()
        {
            try
            {
                //Grd.Rows[Grd.CurrentRow.Index].Cells["ID"].Selected = true;
                //branches.Clear();
                if (this.Operation == 1)//For Insertion of Account
                {
                    ChartOfAccounts acc = new ChartOfAccounts();

                    acc = cc.GetAccountDetail(txtParentAccount.Text,"");
                    this.AccountDepth = acc.AccountDepth + 1;

                    acc = new ChartOfAccounts();

                    if (this.Opt == 1)     //For Group Account.
                    {
                        acc.IsDetailed = false;                        
                    }
                    else if (this.Opt == 2)//For Detailed Account.
                    {
                        acc.IsDetailed = true;
                    }

                    acc.AccountDepth = this.AccountDepth;
                    acc.AccountName = this.cmbPartyName.Text;
                    acc.AccountNo = this.txtAccountNo.Text;
                    acc.AccountType = (AccountType)Enum.Parse(typeof(AccountType), this.txtAccountType.Text, true);
                    acc.AdjustedCredit = 0;
                    acc.AdjustedDebit = 0;
                    acc.Narration = this.txtAddress.Text;
                    acc.BalFlag = false;
                    acc.ExpFlag = false;
                    acc.IsEditable = true;
                    acc.IsLocked = false;
                    acc.IsPosted = false;
                    acc.OpeningCredit = 0;
                    acc.OpeningDebit = 0;
                    acc.GRVAccount = txtGRVAccount.Text.Trim().Length == 0 ? "NULL" : txtGRVAccount.Text;
                    acc.ParentAccount = new ChartOfAccounts(this.txtParentAccount.Text, "");
                    acc.PlFlag = "-";


                    //PartyData

                     Vendor v = new Vendor();
                        Address add = new Address();

                        v.Id.AccountNo  = acc.AccountNo;
                        v.Name = acc.AccountName;

                        add.AdressLine = this.txtAddress.Text;
                        add.City = this.cbxCity.Text;
                        add.Sector = Convert.ToInt32 (this.cbxCity.SelectedValue);

                        v.Address = add;
                        v.PhoneHome = this.txtPhoneHome.Text.Trim().Length == 0 ? "":this.txtPhoneHome.Text.Trim ();
                        v.PhoneOffice = this.txtPhoneOffice.Text.Trim().Length == 0 ? "": this.txtPhoneOffice.Text.Trim ();
                        v.Mobile = this.txtMobile.Text.Trim ().Length ==0 ? "": this.txtMobile.Text .Trim ();
                        v.Fax =  this.txtFax.Text.Trim ().Length ==0 ? "":this .txtFax.Text .Trim ();
                        v.Email = this.txtEmail.Text.Trim().Length == 0 ? "" : this.txtEmail.Text.Trim();
                        v.ContactPerson = this.txtContactPerson.Text.Trim().Length == 0 ? "" : this.txtContactPerson.Text.Trim();
                        v.InPurchase = this.chkPurchase.Checked;
                        v.InSale = this.chkSale.Checked;
                        v.IsPos = this.chkIsPos.Checked;
                        AddBranches();
                        v.BranchList = branches;
                        

                        if (this.txtAccountType.Text == "Party")
                        {
                            type = "V";
                        }

                        vc.SaveParty(v,acc, isNew, type);                        
                    
                    return true;
                }
                else if (this.Operation == 3)//For Updation of Account
                {                    
                    ChartOfAccounts acc = new ChartOfAccounts();

                    acc.AccountNo = this.txtAccountNo.Text;
                    acc.AccountName = this.cmbPartyName.Text;
                    acc.GRVAccount = txtGRVAccount.Text.Trim().Length == 0 ? "NULL" : txtGRVAccount.Text;
                   
                        
                            Vendor v = new Vendor();
                            Address add = new Address();

                            v.Id.AccountNo = acc.AccountNo;
                            v.Name = acc.AccountName;

                            add.AdressLine = this.txtAddress.Text;
                            add.City = this.cbxCity.Text;
                            add.Sector = Convert.ToInt32(this.cbxCity.SelectedValue);

                            v.Address = add;
                            v.PhoneHome = this.txtPhoneHome.Text.Trim().Length == 0 ? "" : this.txtPhoneHome.Text.Trim();
                            v.PhoneOffice = this.txtPhoneOffice.Text.Trim().Length == 0 ? "" : this.txtPhoneOffice.Text.Trim();
                            v.Mobile = this.txtMobile.Text.Trim().Length == 0 ? "" : this.txtMobile.Text.Trim();
                            v.Fax = this.txtFax.Text.Trim().Length == 0 ? "" : this.txtFax.Text.Trim();
                            v.Email = this.txtEmail.Text.Trim().Length == 0 ? "" : this.txtEmail.Text.Trim();
                            v.ContactPerson = this.txtContactPerson.Text.Trim().Length == 0 ? "" : this.txtContactPerson.Text.Trim();
                            v.InPurchase = this.chkPurchase.Checked;
                            v.InSale = this.chkSale.Checked;
                            v.IsPos = this.chkIsPos.Checked;
                             AddBranches();
                           v.BranchList = branches;


                        if (this.txtAccountType.Text == "Party")
                            {
                                type = "V";
                            }

                            vc.SaveParty(v,acc, isNew, type);                        
                        
                }
                
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message ,"FrmNewAccount SaveAccount",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }            
        }

        private void txtAccountExtention_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtParentAccount_KeyDown(object sender, KeyEventArgs e)
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
                MessageBox.Show(ex.Message, "FrmChartofAccounts txtParentAccount_KeyDown.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateControls())
                {
                    if (SaveAccount())
                    {
                        MessageBox.Show("Account has been Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearControls();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "tsbtnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tsbtnClear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void FrmParty_KeyDown(object sender, KeyEventArgs e)
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
                MessageBox.Show(ex.Message, "SchItem_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkIsPos_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSchVendor_Click(object sender, EventArgs e)
        {
            try
            {
                SchAccounts Sch = new SchAccounts();

                Sch.accountType = " and accountno like '4%'";


                Sch.ShowDialog();
                if (Sch.SelectedAccount != null)
                {

                    this.txtGRVAccount.Text = Sch.SelectedAccount.AccountNo;
                    this.txtGRVAccountName.Text = Sch.SelectedAccount.AccountName;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void FrmNewAccount_Fill_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtAccountNo_TextChanged(object sender, EventArgs e)
        {
            //this.txtAccountNo.Text = this.txtParentAccount.Text + this.txtAccountExtention.Text;
        }

        private void txtAccountExtention_TextChanged_1(object sender, EventArgs e)
        {
            this.txtAccountNo.Text = this.txtParentAccount.Text + this.txtAccountExtention.Text;
        }

        private void cbxCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmCity frm = new FrmCity();
                frm.ShowDialog();
                cbxCity.DataSource = new CityController().GetCity();
            }
        }

      
    }
}

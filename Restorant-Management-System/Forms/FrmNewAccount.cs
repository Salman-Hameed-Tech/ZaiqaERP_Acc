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
    public partial class FrmNewAccount : Form
    {
        public int Opt, Operation, IsDetailed, IsEditable, IsLocked, AccountDepth;

        ChartofAccountsController cc = new ChartofAccountsController();

        List<Branch> Branchlist = new List<Branch>();
        public List<Branch> branches = new List<Branch>();
        public FrmNewAccount()
        {
            InitializeComponent();
        }

        private void FrmNewAccount_Load(object sender, EventArgs e)
        {
            try
            {
                //this.BackColor = AccountsGlobals.FormColor;

                if (this.Operation == 1)
                {
                    string ext;
                    if (this.Opt == 1)
                    {
                        ext = cc.GetAccountExtension(this.txtParentAccount.Text, "");
                    }
                    else
                    {
                        ext = cc.GetAccountExtension(this.txtParentAccount.Text, this .txtAccountType.Text);
                    }

                    if (ext.Trim().Length > 0)
                    {
                        this.txtAccountExtention.Text = ext;
                    }
                    else
                    {
                        this.txtAccountExtention.Text = "1";
                    }   
                }
                LoadBranches();
                PopulateEditBranches();

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
            //LoadBranchGrid();
            branches.Clear();
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
                //GrdBranch.Columns["CityID"].Visible = false;
                //GrdBranch.Columns["CityName"].Visible = false;
                //GrdBranch.Columns["IsWherehouse"].Visible = false;
                //GrdBranch.Columns["Phone"].Visible = false;
                //GrdBranch.Columns["Email"].Visible = false;
                //GrdBranch.Columns["Address"].Visible = false;
                //GrdBranch.Columns["SaleNote"].Visible = false;
                AccountsGlobals.ExtendCol(ref Grd, "Branch");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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
                        MessageBox.Show("Please enter Account Extension.", "FrmNewAccounts ValidateControls", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtAccountExtention.Focus();
                        return false;
                    }
                    else //Incase of updating old account
                    {
                        return true;
                    }
                    
                }
                else if (this.txtAccountName.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Please enter Account Name.", "FrmNewAccounts ValidateControls", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtAccountName.Focus();
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"FrmNewAccounts ValidateControls",MessageBoxButtons.OK ,MessageBoxIcon.Error);
                return false;
            }
        }

        private void ClearControls()
        {
            try
            {
                this.txtAccountExtention.Clear();
                this.txtAccountExtention.Text = cc.GetAccountExtension(this.txtParentAccount.Text, this.txtAccountType.Text);
                this.txtAccountName.Clear();
                this.txtNarration.Clear();
                txtGRVAccount.Clear();
                txtGRVAccountName.Clear();
                LoadBranches();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"FrmNewAccounts ClearControls",MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
        }

        private bool SaveAccount()
        {
            try
            {
                //Grd.Rows[Grd.CurrentRow.Index].Cells["ID"].Selected = true;
                branches.Clear();
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
                    acc.AccountName = this.txtAccountName.Text;
                    acc.AccountNo = this.txtAccountNo.Text;
                    acc.AccountType = (AccountType)Enum.Parse(typeof(AccountType), this.txtAccountType.Text, true);
                    acc.AdjustedCredit = 0;
                    acc.AdjustedDebit = 0;
                    acc.Narration = this.txtNarration.Text;
                    acc.BalFlag = false;
                    acc.ExpFlag = false;
                    acc.IsEditable = true;
                    acc.IsLocked = false;
                    acc.IsPosted = false;
                    acc.OpeningCredit = 0;
                    acc.OpeningDebit = 0;
                    acc.ParentAccount = new ChartOfAccounts(this.txtParentAccount.Text, "");
                    acc.PlFlag = "-";
                    acc.GRVAccount = txtGRVAccount.Text.Trim().Length==0 ? "NULL": txtGRVAccount.Text;

                    AddBranches();
                    acc.Branches = branches;


                    return cc.SaveAccount(acc);
                }
                else if (this.Operation == 3)//For Updation of Account
                {                    
                    ChartOfAccounts acc = new ChartOfAccounts();

                    acc.AccountNo = this.txtAccountNo.Text;
                    acc.AccountName = this.txtAccountName.Text;
                    acc.Narration = this.txtNarration.Text;
                    acc.GRVAccount = txtGRVAccount.Text.Trim().Length == 0 ? "NULL" : txtGRVAccount.Text;
                    AddBranches();
                    acc.Branches = branches;
                    return cc.UpdateAccount(acc);                 
                }
                
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message ,"FrmNewAccount SaveAccount",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }            
        }
        private void AddBranches()
        {
            try
            {
                Branch b = new Branch();
                b.ID = Globals.BranchID;

                branches.Add(b);
                //for (int i = 0; i <= Grd.Rows.Count - 1; i++)
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

        private void tsbtnClear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void txtAccountExtention_TextChanged(object sender, EventArgs e)
        {
            this.txtAccountNo.Text = this.txtParentAccount.Text + this.txtAccountExtention.Text;
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
                        MessageBox.Show("Account Group has been Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearControls();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "tsbtnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmNewAccount_KeyDown(object sender, KeyEventArgs e)
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

       
    }
}

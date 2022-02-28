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
    public partial class FrmOpeningBalances : Form
    {
        private List<ChartOfAccounts> accounts = new List<ChartOfAccounts>();
        private List<ChartOfAccounts> subAccounts = new List<ChartOfAccounts>();


        ChartOfAccounts coa = new ChartOfAccounts();

   

        private string accountType = "";

        private bool flg = false;

        public FrmOpeningBalances()
        {
            InitializeComponent();
        }

        private void FrmOpeningBalances_Load(object sender, EventArgs e)
        {
            try
            {
                Grd.ScrollBars = ScrollBars.Vertical;

                //InsertOpBal();

                LoadBranch();
                LoadAccountType();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmOpeningBalances_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #region Grid Functions      
        
        private void LoadGrid()
        {
            try
            {

                AccountsGlobals.SetGridStyle(ref Grd);
                //Set Data Source for Grid.
                if (subAccounts.Count > 0)
                {
                    Grd.DataSource = subAccounts;
                }
                else
                    Grd.DataSource = accounts;

                //Grd.Columns["AccountNo"].HeaderText = "Account No";
                //Grd.Columns["AccountNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft ;
                //Grd.Columns["AccountNo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //Grd.Columns["AccountNo"].Width = 70;
                //Grd.Columns["AccountNo"].ReadOnly = true;

                Grd.Columns["AccountName"].HeaderText = "Account Name";
                Grd.Columns["AccountName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft  ;
                Grd.Columns["AccountName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["AccountName"].Width = 280;
            
                Grd.Columns["AccountName"].AutoSizeMode= DataGridViewAutoSizeColumnMode.Fill;
                Grd.Columns["AccountName"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                Grd.Columns["AccountName"].ReadOnly = true;

                Grd.Columns["OpeningDebit"].HeaderText = "Opening Debit";
                Grd.Columns["OpeningDebit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight   ;
                Grd.Columns["OpeningDebit"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["OpeningDebit"].Width = 85;

                Grd.Columns["OpeningCredit"].HeaderText = "Opening Credit";
                Grd.Columns["OpeningCredit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ;
                Grd.Columns["OpeningCredit"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["OpeningCredit"].Width = 85;

                //Grd.Columns["PreviousBalance"].HeaderText = "";
                //Grd.Columns["PreviousBalance"].Width = 15;
                


                Grd.Columns["GRVAccount"].Visible = false;
                Grd.Columns["GRVAccountName"].Visible = false;
                Grd.Columns["Narration"].Visible = false;
                Grd.Columns["ParentAccount"].Visible = false;
                Grd.Columns["AccountType"].Visible = false;
                Grd.Columns["AdjustedDebit"].Visible = false;
                Grd.Columns["AdjustedCredit"].Visible = false;
                Grd.Columns["IsDetailed"].Visible = false;
                Grd.Columns["IsLocked"].Visible = false;
                Grd.Columns["IsEditable"].Visible = false;
                Grd.Columns["IsPosted"].Visible = false;
                Grd.Columns["BalFlag"].Visible = false;
                Grd.Columns["PlFlag"].Visible = false;
                Grd.Columns["ExpFlag"].Visible = false;
                Grd.Columns["IsDeleted"].Visible = false;
                Grd.Columns["Dr"].Visible = false;
                Grd.Columns["Cr"].Visible = false;
                Grd.Columns["PartyAccount"].Visible = false;
                Grd.Columns["Prefix"].Visible = false;
                Grd.Columns["AccountDepth"].Visible = false;
                Grd.Columns["PreviousBalance"].Visible = false;
                Grd.Columns["Chqno"].Visible = false;
                Grd.Columns["VoucherDate"].Visible = false;
                Grd.Columns["InvoiceNo"].Visible = false;

              //  Grd.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                AccountsGlobals .ExtendCol(ref Grd, "AccountName");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SchAccounts LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //private void Grd_AfterColEdit(object sender, C1.Win.C1TrueDBGrid.ColEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Column == Grd.Splits[0].DisplayColumns["OpeningDebit"] || e.Column == Grd.Splits[0].DisplayColumns["OpeningCredit"])
        //        {
        //            flg = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "FrmOpeningBalances Grd_AfterColEdit", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        
        #endregion
       
        
        private void LoadAccountType()
        {
            try
            {
                this.cbxAccountType.Items.Add("All");
                this.cbxAccountType.Items.Add(AccountType.Asset);
                this.cbxAccountType.Items.Add(AccountType.Capital);
                this.cbxAccountType.Items.Add(AccountType.Expense);
                this.cbxAccountType.Items.Add(AccountType.Liability);
                this.cbxAccountType.Items.Add(AccountType.Party);
                this.cbxAccountType.Items.Add(AccountType.Revenue);

                this.cbxAccountType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmOpeningBalances LoadAccountType", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearControls()
        {
            try
            {
                this.cbxAccountType.SelectedIndex = 0;
                this.txtAccountName.Clear();

                this.rdbSortAccName.Checked = false;
                this.rdbSortAccNo.Checked = false;

                flg = false;

                accounts = new ChartofAccountsController().GetAccounts(accountType, "", Convert.ToInt32(cmbBranch.SelectedValue));
                subAccounts.Clear();
                LoadGrid();

                this.cbxAccountType.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmOpeningBalances ClearControls", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool FilterAccounts(ChartOfAccounts a)
        {
            return a.AccountName.ToUpper().Contains(this.txtAccountName.Text.ToUpper());
        }

        private void PopulateAccounts()
        {
            try
            {
                subAccounts = new List<ChartOfAccounts>();
                ChartOfAccounts ac;

                for (int i = 0; i < Grd.Rows.Count ; i++)
                {
                    ac = new ChartOfAccounts();

                    ac.AccountNo = Grd.Rows[i].Cells["AccountNo"].Value.ToString() ;
                    ac.AccountName = Grd.Rows[i].Cells["AccountName"].Value.ToString();
                    ac.OpeningDebit = Convert.ToDecimal(Grd.Rows[i].Cells["OpeningDebit"].Value.ToString() );
                    ac.OpeningCredit = Convert.ToDecimal(Grd.Rows[i].Cells["OpeningCredit"].Value.ToString());

                    subAccounts.Add(ac);
                }
                coa.coaList = subAccounts;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmOpeningBalances UpdateOpBal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private  void InsertOpBal()
        {
            try
            {
                subAccounts = new ChartofAccountsController().GetAccounts(" and accountno not in (select accountno from openingbalances)","");

                foreach (ChartOfAccounts  acc in subAccounts)
                {
                    if (new ChartofAccountsController().SaveOpBal(acc))
                    {
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmOpeningBalances InsertOpBal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBranch()
        {

            cmbBranch.ValueMember = "ID";
            cmbBranch.DisplayMember = "BranchName";

            List<Branch> counters = new BranchController().GetBranch(" where 1=1 ");
            cmbBranch.DataSource = counters;
            cmbBranch.ValueMember = "ID";
            cmbBranch.DisplayMember = "BranchName";
           // cmbBranch.SelectedIndex = 0;
        }

        private  bool UpdateOpBal()
        {
            try
            {
                PopulateAccounts();

              
              
                if(new ChartofAccountsController().UpdateOpBal(coa, Convert.ToInt32(cmbBranch.SelectedValue)))
                {

                }
               

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmOpeningBalances UpdateOpBal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        #region Other Control Event Functions

       

        private void cbxAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (this.cbxAccountType.Text)
                {
                    case "Asset":
                        this.accountType = " and AccountType='" + AccountType.Asset.ToString() + "'";
                        break;
                    case "Capital":
                        this.accountType = " and AccountType='" + AccountType.Capital.ToString() + "'";
                        break;
                    case "Expense":
                        this.accountType = " and AccountType='" + AccountType.Expense.ToString() + "'";
                        break;
                    case "Liability":
                        this.accountType = " and AccountType='" + AccountType.Liability.ToString() + "'";
                        break;
                    case "Party":
                        this.accountType = " and AccountType='" + AccountType.Party.ToString() + "'";
                        break;
                    case "Revenue":
                        this.accountType = " and AccountType='" + AccountType.Revenue.ToString() + "'";
                        break;
                    default:
                        this.accountType = "";
                        break;
                }

                accounts = new ChartofAccountsController().GetAccounts(accountType,"", Convert.ToInt32(cmbBranch.SelectedValue  )  );
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmOpeningBalances cbxAccountType_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void rdbSortAccNo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //if (this.rdbSortAccNo.Checked)
                //{
                //    this.Grd.AllowSort = true;
                //    this.Grd.Columns["AccountNo"].SortDirection = C1.Win.C1TrueDBGrid.SortDirEnum.Ascending;
                //    this.Grd.Columns["AccountName"].SortDirection = C1.Win.C1TrueDBGrid.SortDirEnum.None;
                //}                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmOpeningBalances rdbSortAccNo_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbSortAccName_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //if (this.rdbSortAccName.Checked)
                //{
                //    this.Grd.AllowSort = true;
                //    this.Grd.Columns["AccountName"].SortDirection = C1.Win.C1TrueDBGrid.SortDirEnum.Ascending;
                //    this.Grd.Columns["AccountNo"].SortDirection = C1.Win.C1TrueDBGrid.SortDirEnum.None;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmOpeningBalances rdbSortAccName_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAccountName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int cIndex;

                if (this.txtAccountName.Text.Trim().Length == 0)
                {
                    subAccounts.Clear();
                    LoadGrid();
                    //this.Grd.SelectedRows.Clear();
                    //this.Grd.MoveRelative(0,0);
                }
                else
                {
                    subAccounts = accounts.FindAll(FilterAccounts);
                    if (subAccounts.Count > 0)
                    {
                        LoadGrid();
                    }
                    else
                    {
                        this.Grd.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmOpeningBalances txtAccountname_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxAccountType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (flg)
                {
                    DialogResult r = MessageBox.Show("Do you want to save changes to Database?", "Confirm save...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (UpdateOpBal())
                        {
                            MessageBox.Show("Data is updated successfully.", "Balances Updated...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearControls();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmOpeningBalances cbxAccountType_SelectionChangeComitted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion                                 

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
             if (UpdateOpBal())
             {
                 MessageBox.Show("Data is updated successfully.", "Balances Updated...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 ClearControls();
             }

        }

        private void tsbtnClear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void tsbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Grd_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            flg = true;
        }

        private void cmbBranch_SelectedValueChanged(object sender, EventArgs e)
        {
            accounts = new List<ChartOfAccounts>();
            accounts = new ChartofAccountsController().GetAccounts(accountType, "", Convert.ToInt32(cmbBranch.SelectedValue));
            LoadGrid();
        }

        private void cbxAccountType_SelectedValueChanged(object sender, EventArgs e)
        {

        }
    }
}

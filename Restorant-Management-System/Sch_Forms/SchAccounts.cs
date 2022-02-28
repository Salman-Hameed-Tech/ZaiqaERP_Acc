using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using CategoryControlle ;

namespace Accounts.SchForms
{
    public partial class SchAccounts : Form
    {
        private List<ChartOfAccounts> accounts = new List<ChartOfAccounts>();
        private List<ChartOfAccounts> subAccounts = new List<ChartOfAccounts>();

        private ChartOfAccounts selectedAccount;
        public bool isVendorAcc = false;
        public string POS = "";

        public ChartOfAccounts SelectedAccount
        {
            get { return selectedAccount; }
            set { selectedAccount = value; }
        }

        public string accountType="";

        public SchAccounts()
        {
            InitializeComponent();
        }

        private void SchAccounts_Load(object sender, EventArgs e)
        {
            try
            {
             
                accounts = new ChartofAccountsController().GetAccounts(accountType,POS);
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SchAccounts_Load",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void LoadGrid()
        {
            try
            {
                //Set Data Source for Grid.
                if (subAccounts.Count > 0)
                {
                    Grd.DataSource = subAccounts;
                }
                else 
                    Grd.DataSource = accounts;

                //Set First Column.
                Grd. Columns["AccountNo"].HeaderText  = "Account No";

                Grd.Columns["AccountNo"].Width = 70;

                //Set Second Column.
                Grd.Columns["AccountName"].HeaderText = "Account Name";

                Grd.Columns["AccountName"].Width = 375;

                //Set Second Column.




                Grd.Columns["GRVAccountName"].Visible = false;
                Grd.Columns["GRVAccount"].Visible = false;

                Grd.Columns["AccountDepth"].Visible = false;
                Grd.Columns["Narration"].Visible = false;
                Grd.Columns["ParentAccount"].Visible = false;
                Grd.Columns["OpeningDebit"].Visible = false;
                Grd.Columns["OpeningCredit"].Visible = false;
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
               Grd.Columns["InvoiceNo"].Visible = false;
                Grd.Columns["Prefix"].Visible = false;
               Grd.Columns["PreviousBalance"].Visible = false;
                Grd.Columns["PartyAccount"].Visible = false;
                Grd.Columns["Chqno"].Visible = false;
                Grd.Columns["VoucherDate"].Visible = false;

                //Grd.Columns["VDate"].Visible = false;
                //Grd.Columns["VNDate"].Visible = false;
                //Grd.Columns["VNO"].Visible = false;

                AccountsGlobals. ExtendCol(ref Grd, "AccountName");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SchAccounts LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

      

        private Boolean SelectValue()
        {
            try
            {
                if (Grd.SelectedCells .Count  == 0)
                    return false;
                else
                {
                    if (subAccounts.Count >0)
                    {
                        this.selectedAccount = subAccounts[Grd.CurrentRow.Index  ];
                    }
                    else
                        this.selectedAccount = accounts[Grd.CurrentRow.Index ];

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SchGodown SelectValue",MessageBoxButtons.OK ,MessageBoxIcon.Error);
                return false;
            }
        }
        private void SchAccounts_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys .Escape )
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"SchAccounts_KeyDown",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private bool FilterAccounts(ChartOfAccounts a)
        {
            return a.AccountName.ToUpper().Contains(this.txtAccountName.Text.ToUpper());
        }

        private void txtAccountName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //PopulateListView(vNode);
                int cIndex = 0;

                if (this.txtAccountName.Text.Trim().Length == 0)
                {
                    subAccounts.Clear();
                    LoadGrid();
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
                MessageBox.Show(ex.Message ,"SchAccounts AccountName_TextChanged",MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
        }

       

        private void Grd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys .Enter )
                {
                    SelectValue();
                    this.Close();
                }                
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message ,"SchAccounts toolbar_ToolClick",MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
        }

        private void Grd_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                    SelectValue();
                    this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SchAccounts toolbar_ToolClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsBtnSelect_Click(object sender, EventArgs e)
        {
            SelectValue();
        }        
    }
}

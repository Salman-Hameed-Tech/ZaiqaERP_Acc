using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CategoryControlle;
using Accounts;
using Accounts.Forms;
using Accounts.SchForms;
using Common;
using CommonController;
using Microsoft.Reporting.WinForms;

namespace Restorant_Management_System.Forms
{
    public partial class FrmVoucher : Form
    {
        private List<ChartOfAccounts> accounts;
        ChartOfAccounts account;
        private Voucher voucher;
        public VoucherType voucherType;
        public List<ChartOfAccounts> bankAccounts;

        private TransactionFlow Flow = TransactionFlow.None;
        Report_Forms.FrmReportViewer frmViewer = new Report_Forms.FrmReportViewer();

        private bool isNew = true;

        public FrmVoucher()
        {
            InitializeComponent();
        }

        private List<Item> items;

        public void DoNothing()
        {

        }
        private void FrmVoucher_Load(object sender, EventArgs e)
        {
            try
            {
                this.Font = AccountsGlobals.Font;              
                cmbTrasactionFlow.DataSource = Enum.GetValues(typeof(TransactionFlow));
                List<User> users = new UserController().GetUsers(0);
                List<string> val = new List<string>();
                string VType = "";
                if (Common.User._IsAdmin )
                {
                    foreach (int item in Enum.GetValues(typeof(VoucherType)))
                    {
                        if (item < 300)
                        {
                            VoucherType objv = (VoucherType)item;
                            val.Add(objv.ToString());
                        }
                    }
                }
                else
                {
                    foreach (int item in Enum.GetValues(typeof(VoucherType)))
                    {
                        if (item < 300)
                        {
                            if (AccountsGlobals.UserRights[item-1].CanAccess  )
                            {
                                VoucherType objv = (VoucherType)item;
                                VType = objv.ToString();
                                val.Add(objv.ToString());
                            }
                        }
                    }
                }
                if (val.Count > 0)
                {
 
                    cmbVoucherType.DataSource = val;
                }
                else
                {
                    MessageBox.Show("Not Authorize To Enter Any Voucher", "Contact Administrator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }


                bankAccounts = new ChartofAccountsController().GetAccounts(" and accountno like '" + Globals.BankAccountNo + "%'", "");
                cmbBankAccount.DataSource = bankAccounts;
                cmbBankAccount.DisplayMember = "AccountName";
                cmbBankAccount.ValueMember = "AccountNo";
                cmbBankAccount.SelectedIndex = -1;


                LoadBranch();

                if (!User._IsAdmin)
                {

                    dtpDated.Enabled = AccountsGlobals.UserRights[AccountsGlobals.DateRights].CanAccess;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmPurchaseRegister_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBranch()
        {
            string where = "";
            if (User._IsAdmin)
            {
                where = "  where 1=1  ";
            }
            else
            {
                where = "  where b.id="+Globals.BranchID+"  ";
            }
            List<Branch> counters = new BranchController().GetBranch(where);
            cmbBranch.DataSource = counters;
            cmbBranch.ValueMember = "ID";
            cmbBranch.DisplayMember = "BranchName";
            cmbBranch.SelectedValue = Globals.BranchID;
           

            //if (User._IsAdmin)
            //{
            //    cmbBranch.Enabled = true;
            //}
            //else
            //{
            //    cmbBranch.Enabled = false;
            //}
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
        void Grd_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // (No need to write anything in here) 
        }
        private Nullable<int> SetMaxID()
        {
            try
            {
                Voucher v = new Voucher();
                v.VoucherType = voucherType;
                v.VoucherDate = dtpDated.Value;
                v.BankAccNo = new ChartOfAccounts((cmbBankAccount.SelectedValue == null ? "NULL" : cmbBankAccount.SelectedValue.ToString()), "");
                return new VoucherController().GetMaximumID(v);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetMaxID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public string SetVoucherNo()
        {
            try
            {
                string voucherNo = "";
                string bankCode = "";

                if (cmbBankAccount.SelectedValue != null)
                {
                    bankCode = cmbBankAccount.SelectedValue.ToString().Substring(4, 2);
                }
                else
                {
                    bankCode = "00";
                }

                voucherNo = voucherType.ToString() + "-" + bankCode + "-" + dtpDated.Value.ToString("MMM").ToUpper() + "-" + txtID.Text.Trim();


                return voucherNo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetVoucherNo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private void ClearControls()
        {
            try
            {
                txtBankAccNo.Clear();
                txtBankAccName.Clear();
                this.dtpDated.Value = AccountsGlobals.ServerDate;  

                this.txtID.Text = SetMaxID().ToString();
                this.btnDelete.Enabled = false;
                //this.bt.Enabled = false;
                this.txtDebit.Text = "0";
                this.txtCredit.Text = "0";
                this.dtpDatedPrv.Value = DateTime.Now;
                this.txtCheckNo.Clear();
                this.dtpCheckDate.Value = DateTime.Now;
                this.btnSave.Enabled = true;
                txtVoucherNo.Clear();
                txtVoucherNo.Text = SetVoucherNo();
              //  lblAmountInWords.Text = "";
                //cmbBankAccount.SelectedIndex = -1;

                cmbBankAccount.Enabled = true;

                LoadGrid();
                LoadBranch();

                this.isNew = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ClearControls", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormatVoucher()
        {
            try
            {
                ClearControls();

                this.txtDebit.Visible = true;
                this.lblDebit.Visible = true;
                this.txtCredit.Visible = true;
                this.lblCredit.Visible = true;

                this.lblFlow.Visible = false;
                this.cmbTrasactionFlow.Visible = false;

                this.lblBankAccount.Visible = false;
                this.cmbBankAccount.Visible = false;
                this.dtpCheckDate.Visible = false;
                this.lblCheckDate.Visible = false;
                this.txtCheckNo.Visible = false;
                this.lblCheckNo.Visible = false;

                this.btnEdit.Enabled = true;
                this.btnSearch.Visible = false;

                if (voucherType == VoucherType.CRV)
                {
                    this.Text = "Cash Receiving Voucher";
                    this.txtDebit.Visible = false;
                    this.lblDebit.Visible = false;
                    cmbBankAccount.Visible = false;
                    this.lblBankAccount.Visible = false;
                    this.Flow = TransactionFlow.Receiving;
                    lblType.Text = this.Text;

                    lblBankAccName.Visible = false;
                    lblBankAccNo.Visible = false;
                    txtBankAccNo.Visible = false;
                    txtBankAccName.Visible = false;
                    btnSchBanck.Visible = false;
                }
                else if (voucherType == VoucherType.CPV)
                {
                    this.Text = "Cash Payment Voucher";
                    this.txtCredit.Visible = false;
                    this.lblCredit.Visible = false;
                    cmbBankAccount.Visible = false;
                    this.lblBankAccount.Visible = false;
                    this.Flow = TransactionFlow.Payment;
                    lblType.Text = this.Text;

                    lblBankAccName.Visible = false;
                    lblBankAccNo.Visible = false;
                    txtBankAccNo.Visible = false;
                    txtBankAccName.Visible = false;
                    btnSchBanck.Visible = false;
                }
                else if (voucherType == VoucherType.JV)
                {
                    this.Text = "Journal Voucher";
                    cmbBankAccount.Visible = false;
                    this.lblBankAccount.Visible = false;
                    this.Flow = TransactionFlow.None;
                    lblType.Text = this.Text;
                    this.cmbTrasactionFlow.SelectedItem = TransactionFlow.None;
                    this.lblFlow.Visible = true;
                    this.cmbTrasactionFlow.Visible = true;

                    lblBankAccName.Visible = false;
                    lblBankAccNo.Visible = false;
                    txtBankAccNo.Visible = false;
                    txtBankAccName.Visible = false;
                    btnSchBanck.Visible = false;
                }
                else if (voucherType == VoucherType.BPV)
                {
                    this.Text = "Bank Payment Voucher";
                    this.txtCredit.Visible = false;
                    this.lblCredit.Visible = false;
                    this.Flow = TransactionFlow.Payment;
                    SetCheckControls();
                    lblType.Text = this.Text;


                    lblBankAccName.Visible = true;
                    lblBankAccNo.Visible = true;
                    txtBankAccNo.Visible = true;
                    txtBankAccName.Visible = true;
                    btnSchBanck.Visible = true;

                    lblBankAccount.Visible = false;
                    cmbBankAccount.Visible = false;
                }
                else if (voucherType == VoucherType.BRV)
                {
                    this.Text = "Bank Receiving Voucher";
                    this.txtDebit.Visible = false;
                    this.lblDebit.Visible = false;
                    this.Flow = TransactionFlow.Receiving;
                    SetCheckControls();
                    lblType.Text = this.Text;

                    lblBankAccName.Visible = true;
                    lblBankAccNo.Visible = true;
                    txtBankAccNo.Visible = true;
                    txtBankAccName.Visible = true;
                    btnSchBanck.Visible = true;

                    lblBankAccount.Visible = false;
                    cmbBankAccount.Visible = false;
                }
                else if (voucherType == VoucherType.BCV)
                {
                    SetCheckControls();
                    this.Text = "Bank Credit Voucher";
                    this.txtCredit.Visible = false;
                    this.lblCredit.Visible = false;
                    this.txtCheckNo.Visible = false;
                    this.dtpCheckDate.Visible = false;
                    this.lblCheckNo.Visible = false;
                    this.lblCheckDate.Visible = false;
                    this.Flow = TransactionFlow.Payment;
                    lblType.Text = this.Text;

                    lblBankAccName.Visible = true;
                    lblBankAccNo.Visible = true;
                    txtBankAccNo.Visible = true;
                    txtBankAccName.Visible = true;
                    btnSchBanck.Visible = true;

                    lblBankAccount.Visible = false;
                    cmbBankAccount.Visible = false;
                }
                else if (voucherType == VoucherType.BDV)
                {
                    SetCheckControls();
                    this.Text = "Bank Debit Voucher";
                    this.txtDebit.Visible = false;
                    this.lblDebit.Visible = false;
                    this.txtCheckNo.Visible = false;
                    this.dtpCheckDate.Visible = false;
                    this.lblCheckNo.Visible = false;
                    this.lblCheckDate.Visible = false;
                    this.Flow = TransactionFlow.Receiving;
                    lblType.Text = this.Text;


                    lblBankAccName.Visible = true;
                    lblBankAccNo.Visible = true;
                    txtBankAccNo.Visible = true;
                    txtBankAccName.Visible = true;
                    btnSchBanck.Visible = true;

                    lblBankAccount.Visible = false;
                    cmbBankAccount.Visible = false;
                }
                else if (voucherType == VoucherType.LPJ)
                {
                    this.Text = "Local Purchase Voucher";
                    this.Flow = TransactionFlow.None;
                    btnSave.Enabled = true;

                    btnSearch.Visible = true;
                    lblType.Text = this.Text;
                    //SetCheckControls();  
                }
                else if (voucherType == VoucherType.FPJ)
                {
                    this.Text = "Foreign Purchase Voucher";
                    this.Flow = TransactionFlow.None;
                    btnSave.Enabled = true;
                    this.btnDelete.Enabled = false;
                    this.btnEdit.Enabled = true;
                    btnSearch.Visible = true;
                    lblType.Text = this.Text;
                    //SetCheckControls();  
                    lblBankAccName.Visible = false;
                    lblBankAccNo.Visible = false;
                    txtBankAccNo.Visible = false;
                    txtBankAccName.Visible = false;
                }
                else if (voucherType == VoucherType.SJV)
                {
                    this.Text = "Sale Voucher";
                    this.Flow = TransactionFlow.None;
                    btnSave.Enabled = true;
                    this.btnDelete.Enabled = false;
                    this.btnEdit.Enabled = true;
                    btnSearch.Visible = true;
                    lblType.Text = this.Text;

                    //SetCheckControls();
                }
                else if (voucherType == VoucherType.SRV)
                {
                    this.Text = "Sale Return Voucher";
                    this.Flow = TransactionFlow.None;
                    btnSave.Enabled = true;
                    this.btnDelete.Enabled = false;
                    this.btnEdit.Enabled = true;
                    btnSearch.Visible = true;
                    lblType.Text = this.Text;
                    //SetCheckControls();  
                }
                else if (voucherType == VoucherType.PRV)
                {
                    this.Text = "Purchase Return Voucher";
                    this.Flow = TransactionFlow.None;
                    btnSave.Enabled = true;
                    this.btnDelete.Enabled = false;
                    this.btnEdit.Enabled = true;
                    btnSearch.Visible = true;
                    lblType.Text = this.Text;
                    //SetCheckControls();  
                }

                cmbBankAccount.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FormatVoucher", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetCheckControls()
        {
            try
            {
                this.lblBankAccount.Visible = true;
                this.cmbBankAccount.Visible = true;
                this.txtCheckNo.Visible = true;
                this.lblCheckNo.Visible = true;
                this.lblCheckDate.Visible = true;
                this.dtpCheckDate.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetBankControls", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                // To avoid all the annoying error messages, handle the DataError event of the DataGridView:
                Grd.DataError += new DataGridViewDataErrorEventHandler(Grd_DataError);

                DataGridViewCell TextCell = new DataGridViewTextBoxCell();
                DataGridViewCell DecimalCell = new TNumEditDataGridViewCell(2);
                DataGridViewCell IntCell = new TNumEditDataGridViewCell(0);

                DataGridViewCell ComboCell = new DataGridViewComboBoxCell();
                //Col 1
                //////////////////////////////////////////////////////////////////////////////////////////////////                

                DataGridViewColumn newCol = new DataGridViewColumn(); // add a column to the grid                


                //Col 2
                //////////////////////////////////////////////////////////////////////////////////////////////////                
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Account No";
                newCol.Name = "AccountNo";

                newCol.CellTemplate = IntCell;

                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;
                newCol.Width = 100;
                Grd.Columns.Add(newCol);

                //Col 2
                //////////////////////////////////////////////////////////////////////////////////////////////////                
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Account Name";
                newCol.Name = "AccountName";
                newCol.CellTemplate = TextCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;
              
                newCol.Width = 300;
                Grd.Columns.Add(newCol);

                DataGridViewComboBoxColumn comboCol = new DataGridViewComboBoxColumn();
                comboCol.CellTemplate = ComboCell;
               // comboCol.DataSource = new PrefixController().GetPrefixs(0);
                comboCol.DisplayMember = "Name";
                comboCol.ValueMember = "ID";
                comboCol.HeaderText = "Prefix";
                comboCol.Name = "Prefix";
                comboCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                comboCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                comboCol.Width = 180;
                comboCol.Visible = false;
                //if (voucherType == VoucherType.BCV  || voucherType == VoucherType.BPV  || voucherType == VoucherType.JV )
                //{
                //    comboCol.Visible = true ;
                //}
                Grd.Columns.Add(comboCol);


                //Col 2
                //////////////////////////////////////////////////////////////////////////////////////////////////                
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Narration";
                newCol.Name = "Narration";
                newCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                newCol.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
                newCol.CellTemplate = TextCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Width = 200;
                newCol.Visible = false;
                Grd.Columns.Add(newCol);



                //////////////////////////////////////////////////////////////////////////////////////////////////               

                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Invoice No";
                newCol.Name = "InvoiceNo";
                newCol.CellTemplate = IntCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //if (cmbVoucherType.Text == Common.VoucherType.BRV.ToString() || cmbVoucherType.Text == Common.VoucherType.CRV.ToString())
                //    newCol.Visible = true;
                //else
                    newCol.Visible = false;

                newCol.ReadOnly = true;
                newCol.Width = 80;
                Grd.Columns.Add(newCol);


                //Col 3
                //////////////////////////////////////////////////////////////////////////////////////////////////               
                newCol = new DataGridViewColumn();
                newCol.CellTemplate = DecimalCell;
                newCol.HeaderText = "Debit";
                newCol.Name = "Debit";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.Width = 80;
                Grd.Columns.Add(newCol);


                //Col 3
                //////////////////////////////////////////////////////////////////////////////////////////////////               
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Credit";
                newCol.Name = "Credit";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.Width = 80;
                Grd.Columns.Add(newCol);




                //Col 3
                //////////////////////////////////////////////////////////////////////////////////////////////////               
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "RemainingAmt";
                newCol.Name = "RemainingAmt";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = false;
                newCol.Width = 80;
                Grd.Columns.Add(newCol);

                if (voucherType == VoucherType.CRV || voucherType == VoucherType.BRV || voucherType == VoucherType.BDV)
                {
                    Grd.Columns["Debit"].Visible = false;
                }

                if (voucherType == VoucherType.CPV || voucherType == VoucherType.BPV || voucherType == VoucherType.BCV)
                {
                    Grd.Columns["Credit"].Visible = false;
                }



                Grd.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                AccountsGlobals.ExtendCol(ref Grd, "Narration");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
        private bool CheckCloseMonth(DateTime date)
        {
            try
            {
                return new VoucherController().CheckCloseMonth(date);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool ValidateControls()
        {
            try
            {
                DateTime date = Convert.ToDateTime(this.dtpDated.Value);
                if (Common.User._IsAdmin == false)
                {
                    if (!CheckCloseMonth(date))
                    {
                        MessageBox.Show("Month Is Closed ", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }

                int Count = 0;
                for (int i = 0; i < Grd.Rows.Count; i++)
                {
                    if (Grd.Rows[i].Visible)
                    {
                        if (Convert.ToInt64(Grd.Rows[i].Cells["AccountNo"].Value) != 0)
                        {
                            Count++;
                        }
                    }
                }
                if (Count == 0)
                {
                    MessageBox.Show("Please Enter some Voucher Lines.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Grd.Focus();
                    return false;
                }

                if (voucherType == VoucherType.JV)
                {
                    if (Convert.ToDecimal(txtDebit.Text.Trim()) != Convert.ToDecimal(txtCredit.Text.Trim()))
                    {
                        MessageBox.Show("Total Debit Amount should be equal to Total Credit Amount.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Grd.Focus();
                        return false;
                    }
                }

                if (voucherType == VoucherType.BPV || voucherType == VoucherType.BRV || voucherType == VoucherType.BCV || voucherType == VoucherType.BDV)
                {
                    if (txtBankAccNo.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Please Select a Bank Account", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cmbBankAccount.Focus();
                        return false;
                    }
                    else
                    {
                        string banckaccount = txtBankAccNo.Text.Trim();
                        for (int i = 0; i < Grd.Rows.Count - 1; i++)
                        {
                            if (Grd.Rows[i].Cells["AccountNo"].Value.ToString() == banckaccount)
                            {
                                MessageBox.Show("Please do not select Banck Account in data Gird. ", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }

                        }
                    }
                }
               
              



                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ValidateControls", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool AddVoucher()
        {
            try
            {
                voucher = new Voucher();

                voucher.VoucherType = voucherType;
                voucher.VoucherNo = Convert.ToInt32(txtID.Text.Trim());
                if (isNew) // New Voucher then Deletetion should not be made to avoid deletion Previous date is set to New Voucher selected date.
                {
                    dtpDatedPrv.Value = dtpDated.Value.Date;
                }
                else
                {
                    voucher.PrevBranchID = Convert.ToInt32(txtPreveBarnchid.Text.Trim());
                }
                voucher.PreVoucherDate = dtpDatedPrv.Value;
                voucher.VoucherDate = dtpDated.Value.Date;
                voucher.User = new User(User.UserNo, "", "");
                AddVoucherLines();
                voucher.Accounts = accounts;
                voucher.CheckNo = txtCheckNo.Text.Trim();
                voucher.CheckDate = dtpCheckDate.Value.Date;
                voucher.Flow = Flow;
                voucher.IsPrinted = true;
                voucher.BranchID = Globals.BranchID;//Convert.ToInt16(cmbBranch.SelectedValue);
              
               
                if(voucherType == VoucherType.CRV && voucherType == VoucherType.CRV)
                {
                    voucher.SummaryNo = (Summary.SummaryNo);
                }


                voucher.BankAccNo = new ChartOfAccounts((txtBankAccNo.Text.Trim().Length == 0 ? "" : txtBankAccNo.Text.Trim()), "");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool AddVoucherLines()
        {
            try
            {
                if (Grd.Rows.Count > 0)
                {
                    accounts = new List<ChartOfAccounts>();

                    for (int i = 0; i < Grd.Rows.Count; i++)
                    {
                        if (Grd.Rows[i].Visible)
                        {
                            if (Convert.ToInt64(Grd.Rows[i].Cells["AccountNo"].Value) != 0)
                            {
                                account = new ChartOfAccounts();
                                account.AccountNo = Grd.Rows[i].Cells["AccountNo"].Value.ToString();
                                account.AccountName = Grd.Rows[i].Cells["AccountName"].Value.ToString();
                                account.Narration = Grd.Rows[i].Cells["Narration"].Value.ToString();
                                account.Dr = Convert.ToDecimal(Grd.Rows[i].Cells["Debit"].Value);
                                account.Cr = Convert.ToDecimal(Grd.Rows[i].Cells["Credit"].Value);
                                account.InvoiceNo = Convert.ToInt32(Grd.Rows[i].Cells["InvoiceNo"].Value);
                                Prefix prefix = new Prefix(Grd.Rows[i].Cells["Prefix"].Value == null ? 0 : Convert.ToInt32(Grd.Rows[i].Cells["Prefix"].Value), "");

                                account.Prefix = prefix;
                                accounts.Add(account);
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AddLines", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void PrintInvoice(string p, Voucher voucher, VoucherType voucherType)
        {


            PrintDialog pd = new PrintDialog();
            string oldPrinter = pd.PrinterSettings.DefaultPageSettings.PrinterSettings.PrinterName;
            DataSet ds = new DataSet();
            ds = new VoucherController().GetVoucherData(Convert.ToInt32(txtID.Text.Trim()),voucher);

            Report_Forms.frmViewer Viewer = new Report_Forms.frmViewer();
            Viewer.reportViewer1.Reset();

            if (ds.Tables[0].Rows.Count > 0)
            {
                ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
                Viewer.reportViewer1.LocalReport.DataSources.Add(rds);
                Viewer.reportViewer1.LocalReport.ReportPath = "../../Report/RptSaleInvoice.rdlc";
                //    ReportParameter[] rptParams = new ReportParameter[]
                //    {
                //new ReportParameter("Date",Date),
                //    };
                //   Viewer.reportViewer1.LocalReport.SetParameters(rptParams);
                Viewer.reportViewer1.LocalReport.Refresh();
                Viewer.ShowDialog();

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateControls())
                {
                    if (AddVoucher())
                    {
                        if (voucherType == VoucherType.POS || voucherType == VoucherType.Fn || voucherType == VoucherType.SJV || voucherType == VoucherType.SRV || voucherType == VoucherType.PRV || voucherType == VoucherType.FPJ)
                        {
                            if (new VoucherController().SetPrinted(Convert.ToInt32(voucher.VoucherNo), voucher.VoucherType, true, isNew))
                            {
                                MessageBox.Show("Voucher Saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                              
                                ClearControls();
                            }
                        }
                        else
                        {
                            int vid = new VoucherController().SaveVoucher(voucher, isNew);
                            if (vid > 0)
                            {
                                MessageBox.Show("Voucher Saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (chkPrint.Checked)
                                {
                                    ClearControls();
                                    voucher.VoucherNo = vid;
                                    AccountsGlobals.PrintVoucher("w", voucher, voucherType);
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "tsbtnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you really want to Delete this Voucher", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    if (voucherType == VoucherType.LPJ || voucherType == VoucherType.SJV || voucherType == VoucherType.SRV || voucherType == VoucherType.PRV || voucherType == VoucherType.FPJ)
                    {
                        //if (new VoucherController().SetPrinted(Convert.ToInt32(voucher.VoucherNo), voucher.VoucherType, false,isNew   ))
                        if (1 == 1)
                        {
                            MessageBox.Show("Access Denied", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearControls();
                        }
                    }
                    else
                    {
                        Voucher v = new Voucher();
                        v.VoucherNo = Convert.ToInt32(txtID.Text.Trim());
                        v.VoucherType = voucherType;
                        v.PreVoucherDate = dtpDated.Value;
                        v.BankAccNo = new ChartOfAccounts((cmbBankAccount.SelectedValue == null ? "" : cmbBankAccount.SelectedValue.ToString()), "");
                        v.PrevBranchID = Convert.ToInt32(txtPreveBarnchid.Text.Trim());
                        if (new VoucherController().DeleteVoucher(v))
                        {
                            MessageBox.Show("Voucher has been Deleted", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearControls();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit(true, false);
        }
        private bool PopulateLines(List<ChartOfAccounts> lines)
        { 
            try
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    int rowIndex = Grd.Rows.Add();

                    string[] narration = lines[i].Narration.Split('~');

                    Grd.Rows[i].Cells["AccountNo"].Value = lines[i].AccountNo;
                    Grd.Rows[i].Cells["AccountName"].Value = lines[i].AccountName;
                    Grd.Rows[i].Cells["Narration"].Value = (narration.Length > 1 ? narration[1] : narration[0]);
                    Grd.Rows[i].Cells["Debit"].Value = lines[i].Dr;
                    Grd.Rows[i].Cells["Credit"].Value = lines[i].Cr;
                  //  Grd.Rows[i].Cells["InvoiceNo"].Value = lines[i].InvoiceNo;
                  //  Grd.Rows[i].Cells["Prefix"].Value = lines[i].Prefix.Id;

                    if (voucherType == VoucherType.BCV || voucherType == VoucherType.BPV || voucherType == VoucherType.JV)
                    {
                        if (lines[i].AccountNo.Length > 3)
                        {
                            //if (lines[i].AccountNo.Substring(0, Globals.LCAccountGroup.Length) == Globals.LCAccountGroup || lines[i].AccountNo.Substring(0, Globals.LCExpenseGroup.Length) == Globals.LCExpenseGroup)
                            {
                                //Grd.Columns["Prefix"].Visible = true  ;
                                AccountsGlobals.ExtendCol(ref Grd, "Narration");
                            }
                        }
                    }

                    if (voucherType != VoucherType.PRV && voucherType != VoucherType.SJV && voucherType != VoucherType.JV && voucherType != VoucherType.SRV && voucherType != VoucherType.PRV && voucherType != VoucherType.FPJ)
                    {
                        if (lines[i].AccountNo.Length > 2)
                        {
                            if (lines[i].AccountNo.Substring(0, 1) == "6")
                            {
                                Grd.Columns["InvoiceNo"].Visible = true;
                                AccountsGlobals.ExtendCol(ref Grd, "Narration");
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AddLines", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        private void Edit(bool isPrinted, bool isPosted)
        {
            try
            {

                if (cmbVoucherType.Text == "POS")
                {
                    MessageBox.Show("You cannot edit voucher for this voucher type", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbVoucherType.Focus();
                    return;
                }
                if (cmbVoucherType.Text == "Fn")
                {
                    MessageBox.Show("You cannot edit voucher for this voucher type", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbVoucherType.Focus();
                    return;
                }
                Sch_Forms.SchVoucher sch = new Sch_Forms.SchVoucher();
                sch.isPrinted = isPrinted;
                sch.isPosted = isPosted;
                sch.isPrinted = isPrinted;
                sch.isPosted = isPosted;

                sch.type = voucherType;
                sch.voucher = new Voucher();
                sch.voucher.VoucherType = voucherType;
                sch.voucher.VoucherNo = 0;
                sch.voucher.BankAccNo = new ChartOfAccounts((txtBankAccNo.Text.Trim().Length == 0 ? "" : txtBankAccNo.Text.Trim()), "");
                
                sch.Heading = this.Text;
                sch.ShowDialog();
                voucher = sch.item;
                if (voucher != null)
                {
                    ClearControls();
                    
                   
                    this.dtpDatedPrv.Value = voucher.VoucherDate;
                    txtPreveBarnchid.Text = voucher.BranchID.ToString();

                    this.txtID.Text = voucher.VoucherNo.ToString();
                    this.txtBankAccNo.Text = voucher.BankAccNo.AccountNo;
                    txtBankAccName.Text = voucher.BankName.ToString();

                    cmbBranch.SelectedValue = voucher.BranchID;
                 
                    this.txtCheckNo.Text = voucher.CheckNo;
                    dtpDated.Value = voucher.VoucherDate;
                    this.dtpCheckDate.Value = voucher.CheckDate;
                    txtCheckNo.Text = voucher.CheckNo;
                    this.txtVoucherNo.Text = SetVoucherNo();
                    PopulateLines(voucher.Accounts);

                    CalculateTotal();
                    if (isPrinted || isPosted)
                    {
                        this.isNew = false;
                    }
                    this.btnDelete.Enabled = true;
                   // tsbtnPrint.Enabled = true;
                   // cmbBankAccount.Enabled = false;
                    //if (voucherType == VoucherType.LPJ || voucherType == VoucherType.SJV || voucherType == VoucherType.SRV || voucherType == VoucherType.PRV || voucherType == VoucherType.FPJ )
                    //{                       
                    //    this.btnSearch.Enabled  = true;                                           
                    //}
                    this.lblAmountInWords.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "tsbtnEdit_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool CalculateTotal()
        {
            try
            {
                decimal totalDebit = 0;
                decimal totalCredit = 0;

                for (int i = 0; i < Grd.Rows.Count; i++)
                {
                    if (Grd.Rows[i].Visible == true && Convert.ToInt64(Grd.Rows[i].Cells["AccountNo"].Value) != 0)
                    {
                        totalDebit += Convert.ToDecimal(Grd.Rows[i].Cells["Debit"].Value);
                        totalCredit += Convert.ToDecimal(Grd.Rows[i].Cells["Credit"].Value);

                    }
                }

                lblAmountInWords.Text = Globals.NumberToText(Convert.ToInt64((totalCredit == 0 ? totalDebit : totalCredit)));
                txtDebit.Text = totalDebit.ToString();
                txtCredit.Text = totalCredit.ToString();

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CalculateTotal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Edit(false, false);
        }

        private void cmbVoucherType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               
                this.voucherType = (VoucherType)Enum.Parse(typeof(VoucherType), cmbVoucherType.Text);

                FormatVoucher();

                if (Common.User._IsAdmin == false)
                {
                    btnEdit.Enabled = AccountsGlobals.UserRights[Convert.ToInt32(this.voucherType) -1].CanEdit;
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmbVoucherType_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbVoucherType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("\t");
                e.SuppressKeyPress = true;
            }
        }

        private void cmbTrasactionFlow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.voucherType == VoucherType.JV)
            {
                this.Flow = (TransactionFlow)cmbTrasactionFlow.SelectedItem;
            }
        }

        private void cmbVoucherType_Leave(object sender, EventArgs e)
        {
            if (cmbVoucherType.Text == "POS")
            {
                MessageBox.Show("You cannot enter voucher for this voucher type", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbVoucherType.Focus();
            }
        }

        private void cmbBankAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("\t");
                e.SuppressKeyPress = true;
            }
        }

        private void cmbBankAccount_SelectedValueChanged(object sender, EventArgs e)
        {
            this.txtID.Text = SetMaxID().ToString();
            txtVoucherNo.Text = SetVoucherNo();
        }

        private void Grd_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = Grd.CurrentRow.Index;
                int colIndex = Grd.CurrentCell.ColumnIndex;

                if (voucherType == VoucherType.JV)
                {
                    if (colIndex == Grd.Columns["Debit"].Index)
                    {
                        if (Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Debit"].Value) == 0)
                        {
                            Grd.Rows[rowIndex].Cells["Credit"].Value = Convert.ToDecimal(txtDebit.Text) - Convert.ToDecimal(txtCredit.Text);
                            CalculateTotal();
                            //Grd.Rows.Add();
                        }
                    }
                }

                if (colIndex == Grd.Columns["Credit"].Index)
                {
                    if (Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Debit"].Value) != 0)
                    {
                        if (Convert.ToDecimal(Grd.Rows[rowIndex].Cells[colIndex].Value) > 0)
                        {
                            MessageBox.Show("You can not enter both Debit and Credit amount in single line", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Grd.Rows[rowIndex].Cells[colIndex].Value = 0;
                            Grd.Rows[rowIndex].Cells["Credit"].Selected = true;
                            System.Windows.Forms.SendKeys.Send("{Left}");
                        }
                    }
                }

                if (colIndex == Grd.Columns["Debit"].Index)
                {
                    if (Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Credit"].Value) != 0)
                    {
                        if (Convert.ToDecimal(Grd.Rows[rowIndex].Cells[colIndex].Value) > 0)
                        {
                            MessageBox.Show("You can not enter both Debit and Credit amount in single line", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Grd.Rows[rowIndex].Cells[colIndex].Value = 0;
                            Grd.Rows[rowIndex].Cells["Debit"].Selected = true;
                            System.Windows.Forms.SendKeys.Send("{Left}");
                        }
                    }
                }

                CalculateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Grd_CellEndEdit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetRowNo(ref DGV.DGV grd)
        {
            try
            {
                int count = 0;

                for (int i = 0; i < grd.Rows.Count; i++)
                {
                    if (grd.Rows[i].Visible == true)
                    {
                        grd.Rows[i].HeaderCell.Value = (count + 1).ToString();
                        count++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetRowNo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetAccountDetails(ChartOfAccounts acc)
        {
            try
            {
                int rowIndex = Grd.CurrentRow.Index;
                int colIndex = Grd.CurrentCell.ColumnIndex;

                if (acc != null)
                {
                    Grd.Rows[rowIndex].Cells["AccountNo"].Value = acc.AccountNo;
                    Grd.Rows[rowIndex].Cells["AccountName"].Value = acc.AccountName;
                    Grd.Rows[rowIndex].Cells["Narration"].Value = "";
                    Grd.Rows[rowIndex].Cells["Debit"].Value = 0;
                    Grd.Rows[rowIndex].Cells["Credit"].Value = 0;
                    Grd.Rows[rowIndex].Cells["InvoiceNo"].Value = "";

                    if (voucherType == VoucherType.BCV || voucherType == VoucherType.BPV || voucherType == VoucherType.JV)
                    {
                        if (acc.AccountNo.Length > 3)
                        {
                            if (acc.AccountNo.Substring(0, Globals.LCAccountGroup.Length) == Globals.LCAccountGroup || acc.AccountNo.Substring(0, Globals.LCExpenseGroup.Length) == Globals.LCExpenseGroup)
                            {
                                //Grd.Columns["Prefix"].Visible = true;
                                AccountsGlobals.ExtendCol(ref Grd, "Narration");
                            }
                        }
                    }

                    if (Flow != TransactionFlow.None)
                    {
                        if (acc.AccountNo.Substring(0, 1) == "6")
                        {
                            Grd.Columns["InvoiceNo"].Visible = true;
                            AccountsGlobals.ExtendCol(ref Grd, "Narration");
                        }
                        //else
                        //{
                        //    Grd.Columns["InvoiceNo"].Visible = false;
                        //    AccountsGlobals.ExtendCol(ref Grd, "Narration");
                        //}
                    }
                    Grd.Rows[rowIndex].Cells["Narration"].Selected = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetAccountDetails", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Grd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                int rowIndex = Grd.CurrentRow.Index;
                int colIndex = Grd.CurrentCell.ColumnIndex;

                if (e.KeyCode == Keys.F1)
                {
                    if (colIndex == Grd.Columns["AccountNo"].Index) // Account No column is selected.
                    {
                        SchAccounts sch = new SchAccounts();
                        sch.accountType = this.voucherType.ToString();
                        sch.POS = "VA";
                        sch.ShowDialog();

                        ChartOfAccounts acc = sch.SelectedAccount;
                        SetAccountDetails(acc);

                    }
                    if (colIndex == Grd.Columns["InvoiceNo"].Index) // Invoice No column is selected.
                    {
                        if (Grd.Rows[rowIndex].Cells["Narration"].Value != null)
                        {
                            Sch_Forms.SchVoucherInvoice sch = new Sch_Forms.SchVoucherInvoice();
                            sch.flow = Flow;
                            sch.accountNo = Grd.Rows[rowIndex].Cells["AccountNo"].Value.ToString();
                            sch.ShowDialog();

                            List<VoucherInvoice> invoices = sch.items;

                            ChartOfAccounts accountInfo = new ChartOfAccounts();
                            accountInfo.AccountNo = Grd.Rows[rowIndex].Cells["AccountNo"].Value.ToString();
                            accountInfo.AccountName = Grd.Rows[rowIndex].Cells["AccountName"].Value.ToString();
                            accountInfo.Narration = Grd.Rows[rowIndex].Cells["Narration"].Value.ToString();

                            if (invoices != null)
                            {
                                if (invoices.Count != 0)
                                {
                                    Grd.Rows.Remove(Grd.CurrentRow);

                                    for (int i = 0; i < invoices.Count; i++)
                                    {
                                        int row = Grd.Rows.Add();

                                        Grd.Rows[row].Cells["AccountNo"].Value = accountInfo.AccountNo;
                                        Grd.Rows[row].Cells["AccountName"].Value = accountInfo.AccountName;
                                        Grd.Rows[row].Cells["Narration"].Value = accountInfo.Narration;
                                        Grd.Rows[row].Cells["InvoiceNo"].Value = invoices[i].ID;
                                        if (Flow == TransactionFlow.Payment)
                                        {
                                            Grd.Rows[row].Cells["Debit"].Value = invoices[i].RemainingAmt;
                                        }
                                        else if (Flow == TransactionFlow.Receiving)
                                        {
                                            Grd.Rows[row].Cells["Credit"].Value = invoices[i].RemainingAmt;
                                        }
                                    }
                                    CalculateTotal();
                                }
                            }
                        }
                        else
                        {
                            Grd.Rows[rowIndex].Cells["Narration"].Selected = true;
                        }
                    }

                }

                if (e.KeyCode == Keys.F3)
                {
                    if (colIndex == Grd.Columns["Narration"].Index) // Account No column is selected.
                    {
                        Grd.Rows[rowIndex].Cells[colIndex].Value = Grd.Rows[rowIndex - 1].Cells[colIndex].Value;
                    }
                    if (colIndex == Grd.Columns["AccountNo"].Index) // Account No column is selected.
                    {
                        Grd.Rows[rowIndex].Cells[colIndex].Value = Grd.Rows[rowIndex - 1].Cells[colIndex].Value;
                        Grd.Rows[rowIndex].Cells["AccountName"].Value = Grd.Rows[rowIndex - 1].Cells["AccountName"].Value;
                        Grd.Rows[rowIndex].Cells["Narration"].Selected = true;
                    }
                }

                if (e.KeyCode == Keys.Delete)
                {
                    DialogResult result = MessageBox.Show("Do really want to delete this Row?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        int currentRow = Grd.CurrentRow.Index;


                        //Grd.Rows.Remove(Grd.Rows [Grd.CurrentRow .Index ]);
                        //Grd.Rows[Grd.CurrentRow.Index].Cells["IsDeleted"].Value = true;
                        Grd.Rows[Grd.CurrentRow.Index].Visible = false;

                        CalculateTotal();

                        int selectRow = 0;
                        for (int i = currentRow + 1; i < Grd.Rows.Count; i++)
                        {
                            if (Grd.Rows[i].Visible == true)
                            {
                                selectRow = i;
                                break;
                            }
                        }

                        Grd.Rows[selectRow].Cells["AccountNo"].Selected = true;
                        SetRowNo(ref Grd);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Grd_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private int ChkExistingItem(int id)
        {
            try
            {

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ChkExistingItem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            AccountsGlobals.PrintVoucher("w", voucher, voucherType);
        }

        private void btnSchBanck_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSchBanck_Click_1(object sender, EventArgs e)
        {
            SchAccounts Sch = new SchAccounts();

            Sch.accountType = " and accountno like '112%'";

            Sch.POS = "B";
            Sch.ShowDialog();
            if (Sch.SelectedAccount != null)
            {
                txtBankAccNo.Text = Sch.SelectedAccount.AccountNo;
                txtBankAccName.Text = Sch.SelectedAccount.AccountName;
             
            }   
        }
    }

  
}

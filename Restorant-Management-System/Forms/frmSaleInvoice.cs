
using Accounts;
using Accounts.Forms;
using Accounts.SchForms;
using Common;
using CategoryControlle;
using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using System.Drawing.Imaging;

namespace Restorant_Management_System.Forms
{
    public partial class frmSaleInvoice : Form
    {
        public List<ChartOfAccounts> BankAccounts;
        public Boolean VDis;
        public Boolean VEdit;
        public bool Enabledisc;
        private int m_currentPageIndex;
        private IList<Stream> m_streams;

        public bool IsEditSale=false;
        public SaleInvoice obj = null;


        private List<SaleInvoiceLine> saleLines = new List<SaleInvoiceLine>();
        private List<SaleInvoice> sales = new List<SaleInvoice>();

        SaleInvoice sale = new SaleInvoice();
        SaleInvoiceLine saleLine;

        SaleInvoice pendingSale;


        private SaleInvoiceController sc = new SaleInvoiceController();
        
        private bool noSale = true;

        private bool isNew = true;

        private bool isPen = false;

        private int preQuantity = 0;

        string invPrinter;
        RegistryKey regKeyAppRoot;

        String startDay;
        String endDay;
        public frmSaleInvoice()
        {
            InitializeComponent();
        }
        private bool LoadGrid()
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

                DataGridViewComboBoxColumn comboCol = new DataGridViewComboBoxColumn();
                DataGridViewCell ComboCell = new DataGridViewComboBoxCell();

                DataGridViewComboBoxColumn comboCol2 = new DataGridViewComboBoxColumn();
                DataGridViewCell ComboCell2 = new DataGridViewComboBoxCell();

                //Col 1
                //////////////////////////////////////////////////////////////////////////////////////////////////                

                DataGridViewColumn newCol = new DataGridViewColumn(); // add a column to the grid                

                //////////////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.CellTemplate = TextCell;
                newCol.HeaderText = "Bar Code";
                newCol.Name = "BarCode";
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = false;
                newCol.Width = 120;
                Grd.Columns.Add(newCol);



                //Col 2
                //////////////////////////////////////////////////////////////////////////////////////////////////                
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Short key";
                newCol.Name = "Shortkey";

                newCol.CellTemplate = TextCell;

                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = false;
                newCol.Visible = false;
                newCol.Width = 80;
                Grd.Columns.Add(newCol);

                //Col 2
                //////////////////////////////////////////////////////////////////////////////////////////////////                
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Item ID";
                newCol.Name = "ItemID";

                newCol.CellTemplate = IntCell;

                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = false;
                // newCol.Visible = Globals.PackingColumnVisible;
                newCol.Width = 70;
                Grd.Columns.Add(newCol);


                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Item Name";
                newCol.Name = "Item";

                newCol.CellTemplate = TextCell;

                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;
                newCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                newCol.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                newCol.Width = 170;
                Grd.Columns.Add(newCol);

                //Col 4
                //////////////////////////////////////////////////////////////////////////////////////////////////                
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Stock";
                newCol.Name = "Stock";
                newCol.CellTemplate = DecimalCell;//RateCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.ReadOnly = true;
                newCol.Width = 80;
                Grd.Columns.Add(newCol);


                //// To avoid all the annoying error messages, handle the DataError event of the DataGridView:
                //Grd.DataError += new DataGridViewDataErrorEventHandler(Grd_DataError); 

                //Col 3
                //////////////////////////////////////////////////////////////////////////////////////////////////               
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Quantity";
                newCol.Name = "Quantity";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.Width = 80;
                Grd.Columns.Add(newCol);


            
                //////////////////////////////////////////////////////////////////////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderCell.Style.BackColor = Color.Yellow;
                newCol.HeaderText = "Disc %";
                newCol.Name = "Disc%";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = false;
                newCol.ReadOnly = true;
                newCol.Width = 60;
                Grd.Columns.Add(newCol);

                //Col 6
                //////////////////////////////////////////////////////////////////////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderCell.Style.BackColor = Color.Yellow;
                newCol.HeaderText = "Disc Amt";
                newCol.Name = "DiscAmt";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;
                newCol.Visible = false;
                newCol.Width = 60;
                Grd.Columns.Add(newCol);

                //Col 5
                //////////////////////////////////////////////////////////////////////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderCell.Style.BackColor = Color.Salmon;
                newCol.HeaderText = "Rate";
                newCol.Name = "Rate";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //newCol.Visible = Globals.SaleTaxColumnVisisble;
                newCol.ReadOnly = false;
                newCol.Width = 80;
                Grd.Columns.Add(newCol);



                //Col 6
                //////////////////////////////////////////////////////////////////////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Total";
                newCol.Name = "Total";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;
                newCol.Width = 120;
                Grd.Columns.Add(newCol);





                //Col 7
                //////////////////////////////////////////////////////////////////////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "SrNo";
                newCol.Name = "SrNo";
                newCol.CellTemplate = IntCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = false;
                newCol.Width = 70;
                Grd.Columns.Add(newCol);

                //Col 7
                //////////////////////////////////////////////////////////////////////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "SaleID";
                newCol.Name = "SaleID";
                newCol.CellTemplate = IntCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = false;
                newCol.Width = 70;
                Grd.Columns.Add(newCol);

                //Col 8
                //////////////////////////////////////////////////////////////////////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "IsDeleted";
                newCol.Name = "IsDeleted";
                newCol.CellTemplate = IntCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = false;
                newCol.Width = 70;
                Grd.Columns.Add(newCol);


                Grd.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                AccountsGlobals.ExtendCol(ref Grd, "Item");





                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
       
        private void frmSaleInvoice_Load(object sender, EventArgs e)
        {
            try
            {                            
                ClearControls();

                if (IsEditSale)
                {
                    pnlUper.Visible = false;
                    btnPending.Visible = false;
                    btnNew.Visible = false;
                    lblid.Visible = false;
                    txtSaleid.Visible = false;
                    isNew = false;
                   
                }            

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void PopulateEditLines(List<SaleInvoiceLine> saleLines)
        {
            LoadGrid();
            for (int i = 0; i < saleLines.Count; i++)
            {
                int rowindex = Grd.Rows.Add();
                if (saleLines[i].SerialNumber != 0)
                {
                    Grd.Rows[rowindex].Cells["ItemID"].ReadOnly = true;
                   
                }
                Grd.Rows[rowindex].Cells["ItemID"].Value = saleLines[i].Vitem.ItemID;
                Grd.Rows[rowindex].Cells["Barcode"].Value = saleLines[i].Vitem.BarCode;
                Grd.Rows[rowindex].Cells["Item"].Value = saleLines[i].ItemName;
                Grd.Rows[rowindex].Cells["Quantity"].Value = saleLines[i].Quantity;
                Grd.Rows[rowindex].Cells["Stock"].Value = saleLines[i].CStk + saleLines[i].Quantity;
                Grd.Rows[rowindex].Cells["Rate"].Value = saleLines[i].SalePrice;
                Grd.Rows[rowindex].Cells["Total"].Value = saleLines[i].Quantity * saleLines[i].SalePrice;
                Grd.Rows[rowindex].Cells["SrNo"].Value = saleLines[i].SerialNumber;

            }
            
        }

        private void LoadCreditCards()
        {
            try
            {
                this.cmbCreditCard.DataSource = new ChartofAccountsController().GetCreditCardAccounts();
                this.cmbCreditCard.DisplayMember = "AccountName";
                this.cmbCreditCard.ValueMember = "AccountNo";

                this.cmbCreditCard.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmbCreditCard.AutoCompleteSource = AutoCompleteSource.ListItems;


                //this.CmbCreditCard.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmItem LoadCategory");
            }
        }
      
         int userid=   FrmLogin.UserID;

         
       // Int32 counterid = new CounterController().GetCounterid(FrmLogin.UserID);
        private void Grd_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = Grd.CurrentRow.Index;
            int colIndex = Grd.CurrentCell.ColumnIndex;
            
            if (colIndex == Grd.Columns["ItemID"].Index)
            {

                if (Grd.Rows[rowIndex].Cells["ItemID"].Value != null)
                {

                    saleLines = new SaleInvoiceController().VerifyAllItem(Grd.Rows[rowIndex].Cells["ItemID"].Value.ToString().Trim(), "i", Convert.ToInt32(cmbBranch.SelectedValue));

                    if (saleLines.Count == 0)
                    {
                        MessageBox.Show("No item with this Item ID exists.", "Choose Valid Item...", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                        SetSaleLine();
                }

                
            }
           
            else if (colIndex == Grd.Columns["Quantity"].Index)
            {
                    
                if (Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Quantity"].Value) <= Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Stock"].Value))
                {
                      
                    decimal total = Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Quantity"].Value) * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Rate"].Value);
                        
                    Grd.Rows[rowIndex].Cells["Total"].Value = total;

                    CalculateTotal();
                }
                else
                {
                    MessageBox.Show("Quantity cannot be greater than Stock.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Grd.Rows[rowIndex].Cells["Quantity"].Value = 0;
                    Grd.Rows[rowIndex].Cells["Total"].Value = 0;
                }

            }

            else if (colIndex == Grd.Columns["Rate"].Index)
            {

     
                Grd.Rows[rowIndex].Cells["DiscAmt"].Value = SetLineDiscount(rowIndex);
                Grd.Rows[rowIndex].Cells["Total"].Value = (Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Quantity"].Value) * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Rate"].Value)) - Convert.ToDecimal(Grd.Rows[rowIndex].Cells["DiscAmt"].Value);

                CalculateTotal();
            }
            else if (colIndex == Grd.Columns["Disc%"].Index)
            {
                if (Grd.Rows[rowIndex].Cells["Disc%"].Value != null)
                {
                    if (Grd.Rows[rowIndex].Cells["Disc%"].Value.ToString().Trim().Length != 0)
                    {
                        Grd.Rows[rowIndex].Cells["DiscAmt"].Value = SetLineDiscount(rowIndex);   //Grd.GetData(Grd.Row, Grd.Cols["Disc Amt"].Index) == null ? SetLineDiscount() : Grd.GetData(Grd.Row, Grd.Cols["Disc Amt"].Index)
                        Grd.Rows[rowIndex].Cells["Disc%"].Value = Math.Abs(Convert.ToInt32(Grd.Rows[rowIndex].Cells["Disc%"].Value));
                        decimal gross = Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Quantity"].Value) * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Rate"].Value);
                        decimal total = 0;
                        if (gross < 0)
                        {
                            total=Math.Abs(gross) - Convert.ToDecimal(Grd.Rows[rowIndex].Cells["DiscAmt"].Value);
                            total = -total;
                        }
                        else
                        {
                            total = gross - Convert.ToDecimal(Grd.Rows[rowIndex].Cells["DiscAmt"].Value);
                        }
                        Grd.Rows[rowIndex].Cells["Total"].Value = total;

                        CalculateTotal();
                    }
                }
            }
            else if (colIndex == Grd.Columns["DiscAmt"].Index)
            {
                Grd.Rows[rowIndex].Cells["Disc%"].Value = Math.Abs(Convert.ToDecimal(Grd.Rows[rowIndex].Cells["DiscAmt"].Value)) / Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Quantity"].Value) * 100 / Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Rate"].Value);
                Grd.Rows[rowIndex].Cells["Disc%"].Value = Math.Abs(Convert.ToInt32(Grd.Rows[rowIndex].Cells["Disc%"].Value));
                //Grd.Rows[rowIndex].Cells["Total"].Value = (Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Quantity"].Value) * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Rate"].Value)) - Convert.ToDecimal(Grd.Rows[rowIndex].Cells["DiscAmt"].Value);
                decimal gross = Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Quantity"].Value) * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Rate"].Value);
                decimal total = 0;
                if (gross < 0)
                {
                    total = Math.Abs(gross) - Convert.ToDecimal(Grd.Rows[rowIndex].Cells["DiscAmt"].Value);
                    total = -total;
                }
                else
                {
                    total = gross - Convert.ToDecimal(Grd.Rows[rowIndex].Cells["DiscAmt"].Value);
                }
                Grd.Rows[rowIndex].Cells["Total"].Value = total;
                CalculateTotal();
            }
        }
        private decimal SetLineDiscount(int RowIndex)
        {
            decimal discount = 0;
            discount = Convert.ToDecimal(Grd.Rows[RowIndex].Cells["Quantity"].Value) * (decimal)(Convert.ToDecimal(Grd.Rows[RowIndex].Cells["Rate"].Value) * Math.Abs(Convert.ToDecimal(Grd.Rows[RowIndex].Cells["Disc%"].Value)) / 100);
            return Math.Abs(discount);
        }
        private void SetSaleLine()
        {
            try
            {
                int RowIndex = Grd.CurrentRow.Index;
                int colIndex = Grd.CurrentCell.ColumnIndex;

                foreach (SaleInvoiceLine saleLine in saleLines)
                {
                    if (ChkExistingItem(saleLine.Vitem.ItemID) == 0)
                    {
                        Grd.Rows[RowIndex].Cells["ItemID"].Value = saleLine.Vitem.ItemID.ToString();
                        Grd.Rows[RowIndex].Cells["BarCode"].Value = saleLine.Vitem.BarCode.ToString();
                        Grd.Rows[RowIndex].Cells["Item"].Value = saleLine.Vitem.ItemName.ToString();
                        Grd.Rows[RowIndex].Cells["Rate"].Value = saleLine.SalePrice;
                        Grd.Rows[RowIndex].Cells["Stock"].Value = saleLine.CStk;
                        Grd.Rows[RowIndex].Cells["Total"].Value = Convert.ToDecimal(Grd.Rows[RowIndex].Cells["Quantity"].Value) * Convert.ToDecimal(Grd.Rows[RowIndex].Cells["Rate"].Value) - Convert.ToDecimal(Grd.Rows[RowIndex].Cells["DiscAmt"].Value);
                        Grd.Rows[RowIndex].Cells["IsDeleted"].Value = saleLine.IsDeleted;
                    }
                    else
                    {
                        MessageBox.Show("This Item has already been added!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ResetRow();
                        
                    }

                }

                CalculateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmSaleInvoice SetSaleLine", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ResetRow()
        {
            try
            {
                int rowIndex = Grd.CurrentRow.Index;
                int colIndex = Grd.CurrentCell.ColumnIndex;

                Grd.Rows[rowIndex].Cells["ItemID"].Value = "";




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ResetRow", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private int ChkExistingItem(int itemID)
        {
            try
            {
                for (int i = 0; i < Grd.Rows.Count; i++)
                {
                    if (Grd.Rows[i].Cells["ItemID"].Visible == true)
                    {
                        if (itemID == Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value)  && i != Grd.CurrentRow.Index)
                        {
                            return itemID;
                        }
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ChkExistingItem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

      
        private decimal CalculateTotal()
        {
            try
            {
                decimal total = 0;
                decimal totalRem = 0;
                decimal totalDisc = 0;
                decimal totalRetAmt = 0;
                int TotalQty = 0;
                decimal Grand = 0;
                for (int i = 0; i < Grd.Rows.Count ; i++)
                {
                    if (Grd.Rows[i].Visible == true)
                    {
                        if (Grd.Rows[i].Cells["Quantity"].Value != null || Grd.Rows[i].Cells["Rate"].Value != null)
                        {
                            if (Grd.Rows[i].Cells["Quantity"].Value.ToString().Trim().Length != 0 || Grd.Rows[i].Cells["Rate"].Value.ToString().Trim().Length != 0)
                            {
                                if (Convert.ToBoolean(Grd.Rows[i].Cells["IsDeleted"].Value) == false)
                                {
                                    TotalQty += Convert.ToInt32(Grd.Rows[i].Cells["Quantity"].Value);
                                    total += Convert.ToDecimal(Grd.Rows[i].Cells["Quantity"].Value) * Convert.ToDecimal(Grd.Rows[i].Cells["Rate"].Value);
                                    if (Convert.ToDecimal(Grd.Rows[i].Cells["Quantity"].Value) < 0)
                                    {
                                        totalDisc += -Convert.ToDecimal(Grd.Rows[i].Cells["DiscAmt"].Value);
                                    }
                                    else
                                    {
                                        totalDisc += Convert.ToDecimal(Grd.Rows[i].Cells["DiscAmt"].Value);
                                    }
                                }
                            }
                        }
                      
                    }
                }
                txtTotalQuantity.Text = TotalQty.ToString();
                this.txtGrandTotal.Text = Math.Round(total,2).ToString();
                this.txtDiscount.Text = (totalDisc + Convert.ToDecimal(this.txtDiscount.Text.Trim().Length == 0 ? "0" : this.txtDiscount.Text.Trim())).ToString();
                txtDiscount.Text = totalDisc.ToString();
                decimal nettotal = 0;
                if (total < 0)
                {
                    nettotal = Math.Abs(total) - Math.Abs(totalDisc);
                    nettotal = -nettotal;
                }
                else
                {
                    nettotal = total - Math.Abs(totalDisc);
                }
                txtNetAmount.Text = nettotal.ToString();
                if (this.txtCashPayment.Text.Trim().Length != 0)
                {
                    decimal totalbill = (txtNetAmount.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtNetAmount.Text.Trim()));
                    decimal cashpaid = (txtCashPayment.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtCashPayment.Text.Trim()));
                    txtReturnAmount.Text = Math.Round((totalbill - cashpaid),2).ToString();
                }
                else
                {
                    txtReturnAmount.Text = "0";
                }
                
                if(Convert.ToDecimal(txtNetAmount.Text.Trim()) < 0)
                {
                    txtCashPayment.Text = "0";
                    txtCashPayment.ReadOnly = true;
                    cmbCreditCard.Enabled = false;
               
                }
                else
                {
                    txtCashPayment.ReadOnly = false;
                    cmbCreditCard.Enabled = true;
                }

                return (total);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmSaleIvoice CalculateTotal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }


        private void ClearControls()
        {
            try
            {

                this.txtID.Text = new SaleInvoiceController().GetMaximumID().ToString();

                this.txtUserName.Text = User._UserName;
                txtCashPayment.Enabled = true;
               

                LoadBranches();

                isNew = true;
                isPen = false;
                noSale = true;
                btnCancel.Visible = false;
                cmbCreditCard.Enabled = true;

             
             
                txtSaleid.Clear();
                this.txtPartyID.Clear();
                this.txtPartyDetail.Clear();
         
                this.cmbCreditCard.SelectedIndex = 0;
                this.txtCardPayment.ReadOnly = true;
             
                txtCardPayment.Text = null;
                txtCashPayment.Text = null;
                txtDiscount.Text = null;
                
                txtGrandTotal.Text = "0";
                txtNetAmount.Text = "0";
                txtReturnAmount.Text = "0";
                txtCustomerCell.Clear();
                txtCustomerName.Clear();
                txtTotalQuantity.Text = "0";
            
                txtCardNo.Clear();

                LoadBanckAcc();
                LoadGrid();
                Grd.Focus();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBranches()
        {
            try
            {

                List<Branch> counters = new BranchController().GetBranch(" where 1=1  ");
                cmbBranch.DataSource = counters;
                cmbBranch.ValueMember = "ID";
                cmbBranch.DisplayMember = "BranchName";
                
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadBranches", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
            }
        }

        private void LoadBanckAcc()
        {
            BankAccounts = new ChartofAccountsController().GetBankAccounts();
            cmbBank.DataSource = BankAccounts;
            cmbBank.DisplayMember = "AccountName";
            cmbBank.ValueMember = "AccountNo";
            cmbBank.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            { 
                if (ValidateControls())
                {
                    if (SaveSale())
                    {
                        if (!IsEditSale)
                        {
                            int VID = sc.SaveSale(sale, isNew);
                            if (VID != 0)
                            {
                                MessageBox.Show("Invoice is saved successfully.", "Invoic is saved...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                PrintInvoice(sale.Saledate, VID);
                                ClearControls();
                                txtCashPayment.Enabled = true;
                            }
                        }
                       

                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmSaleInvoice SaveRecord", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearControls();
            }
        }
       
        private bool SaveSale()
        {
            try
            {
                if (ValidationControls())
                {
                    DateTime d = new DateTime();
                    sale.BranchID = Globals.BranchID;//Convert.ToInt32(cmbBranch.SelectedValue);
                    sale = new SaleInvoice(Convert.ToInt32(txtID.Text), d, false, new Customer(new ChartOfAccounts(this.txtPartyID.Text.Trim(), ""), null, null, null), Convert.ToDouble((txtInvDiscount.Text.Trim().Length == 0 ? "0" : txtInvDiscount.Text.Trim())), (long)Convert.ToDouble((this.cmbCreditCard.SelectedValue)), Convert.ToDouble((this.txtCardPayment.Text.Trim().Length == 0 ? "0" : this.txtCardPayment.Text.Trim())), Convert.ToDouble((this.txtCashPayment.Text.Trim().Length == 0 ? "0" : this.txtCashPayment.Text.Trim())), Convert.ToDouble((this.txtNetAmount.Text.Trim().Length == 0 ? "0" : this.txtNetAmount.Text.Trim())), Convert.ToDouble((this.txtDiscount.Text.Trim().Length == 0 ? "0" : this.txtDiscount.Text.Trim())), saleLines, Summary.SummaryNo, Convert.ToDouble(this.txtDeduction.Text.Trim().Length == 0 ? "0" : this.txtDeduction.Text.Trim()), Convert.ToDouble(this.txtReturnAmount.Text.Trim().Length == 0 ? "0" : this.txtReturnAmount.Text.Trim()), /*Convert.ToDouble(this.txtBalance.Text.Trim().Length == 0 ? "0" : this.txtBalance.Text.Trim()) */0);
                    sale.Saledate = Convert.ToDateTime(dtpDate.Value);
                    sale.PartyID = txtPartyID.Text;
                    sale.BranchID = Globals.BranchID;
                    sale.IsFinalInvoice = true;
                    PopulateSalesLines();
                    sale.SaleLines = saleLines;



                    return true;
                }
                else
                    return false;
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmSaleInvoice SaveRecord", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool ValidationControls()
        {
            try
            {
                int rowIndex = Grd.CurrentRow.Index;
                int colIndex = Grd.CurrentCell.ColumnIndex;



                int Count = 0;
                for (int i = 0; i < Grd.Rows.Count; i++)
                {
                    if (Grd.Rows[i].Visible)
                    {
                        if (Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value) != 0)
                        {
                            Count++;
                        }
                    }
                }

                if (Count == 0)
                {
                    MessageBox.Show("Please Enter some items", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Grd.Focus();
                    return false;
                }


                for (int i = 0; i < Grd.Rows.Count - 1; i++)
                {
                    if (Convert.ToDecimal(Grd.Rows[i].Cells["Quantity"].Value) == 0 && Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value) > 0 && Grd.Rows[i].Visible == true)
                    {
                        MessageBox.Show("Add Some Quantity.", "Check Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                

               
                if (this.txtPartyID.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Please Select  Department Account First", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbBranch.Focus();
                    return false;
                }


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ValidateControls", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool ValidateControls()
        {
            try
            {

             

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmSaleInvoice ValidateCtrls", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void PrintInvoice(DateTime date,int VID)
        {

            PrintDialog pd = new PrintDialog();
            string oldPrinter = pd.PrinterSettings.DefaultPageSettings.PrinterSettings.PrinterName;
            DataSet ds = new DataSet();
            Common.Data_Sets.DSSaleInvoice dSSale = new Common.Data_Sets.DSSaleInvoice();
            if (new SaleInvoiceController().GetReportData(ref dSSale, date, VID))
            {
                Report_Forms.frmViewer Viewer = new Report_Forms.frmViewer();
                Viewer.reportViewer1.Reset();

                if (dSSale.Tables["SPSaleInvoice"].Rows.Count > 0)
                {
                    ReportDataSource rds = new ReportDataSource("DataSet1", dSSale.Tables["SPSaleInvoice"]);
                    LocalReport report = new LocalReport();
                    Viewer.reportViewer1.LocalReport.DataSources.Add(rds);
                    Viewer.reportViewer1.LocalReport.ReportEmbeddedResource = "Restorant_Management_System.Report.RptSaleInvoice.rdlc";
                    ReportParameter[] rptParams = new ReportParameter[]
                             {
                                        new ReportParameter("Username",User._UserName),
                                       
                             };
                    Viewer.reportViewer1.LocalReport.SetParameters(rptParams);
                    Viewer.reportViewer1.LocalReport.Refresh();
                    Viewer.ShowDialog();


                }
                else
                {
                    MessageBox.Show("No Data Found", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("No Data Found", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        private void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = new SaleInvoiceController().GetPrinterName(Globals.BranchID);
       
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                PaperSize pkCustomSize1 = new PaperSize("First custom size", 350, 6000);
                printDoc.DefaultPageSettings.PaperSize = pkCustomSize1;
                printDoc.Print();
            }
        }
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
               Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }
        private Stream CreateStream(string name,
        string fileNameExtension, Encoding encoding,
        string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }
        private void Export(LocalReport report)
        {
            //   <PageHeight>11in</PageHeight>
            string deviceInfo =
              @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>3.5in</PageWidth>
             
                <MarginTop>0.01</MarginTop>
                <MarginLeft>0.01</MarginLeft>
                <MarginRight>0.01</MarginRight>
                <MarginBottom>0.01</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream,
               out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }
        private bool PopulateSalesLines()
        {
            try
            {
                saleLines.Clear();
                for (int i = 0; i < Grd.Rows.Count-1; i++)
                {
                    if (Grd.Rows[i].Cells["ItemID"].Value != null && Grd.Rows[i].Cells["ItemID"].Value != "")
                    {
                        Item it = new Item();
                        saleLine = new SaleInvoiceLine();
                        saleLine.Vitem.ItemID = Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value);
                        saleLine.Vitem.BarCode = Convert.ToString(Grd.Rows[i].Cells["Barcode"].Value);
                        saleLine.Quantity = (decimal)Grd.Rows[i].Cells["Quantity"].Value;
                        saleLine.SalePrice = Convert.ToDecimal(Grd.Rows[i].Cells["Rate"].Value);
                        saleLine.SerialNumber = Convert.ToInt32(Grd.Rows[i].Cells["SrNo"].Value);
                        saleLine.IsDeleted = Convert.ToBoolean(Grd.Rows[i].Cells["IsDeleted"].Value);
                        saleLines.Add(saleLine);
                        noSale = false;
                    }
                }

                if (noSale)
                {
                    return false;
                }
                else
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmSaleInvoice PopulateSaleLines", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnSchVendor_Click(object sender, EventArgs e)
        {
            ShowSearch(ref txtPartyID, ref txtPartyDetail);
        }

        private void ShowSearch(ref TextBox txtPartyID, ref TextBox txtPartyDetail)
        {
            try
            {
                SchAccounts Sch = new SchAccounts();
                Sch.accountType = " and isdetailed=1 and accountno like '6%'";
                Sch.POS = "S";
                Sch.ShowDialog();
                if (Sch.SelectedAccount != null)
                {
                    txtPartyID.Text = Sch.SelectedAccount.AccountNo;
                    txtPartyDetail.Text = Sch.SelectedAccount.AccountName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //Sch_Forms.SchSaleInvoice frm = new Sch_Forms.SchSaleInvoice();
            //frm.ShowDialog();
        }

        private void btnPending_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidatePendings())
                {
                    Grd.Update();
                    if (PopulateSalesLines())
                    {
                        //startDay = new CommonController.VoucherController().GetStartDay();
                        //endDay = new VoucherController().GetEndDay();

                        if ((System.DateTime.Now > Convert.ToDateTime(endDay)) && (System.DateTime.Now < Convert.ToDateTime(startDay)))
                        {
                            //Check Time if, betwen end or start time, then StartNew Day.
                            bool b = new DayLogController().StartDay();
                        }
                        //Get Active Day.
                        DateTime d = new DayLogController().GetDay(Globals.BranchID);

                        sale = new SaleInvoice(Convert.ToInt32(txtID.Text), d, true, new Customer(new ChartOfAccounts(this.txtPartyID.Text.Trim(), ""), null, null, null), Convert.ToDouble((txtInvDiscount.Text.Trim().Length == 0 ? "0" : txtInvDiscount.Text.Trim())), (long)Convert.ToDouble((this.cmbCreditCard.SelectedValue)), Convert.ToDouble((this.txtCardPayment.Text.Trim().Length == 0 ? "0" : this.txtCardPayment.Text.Trim())), Convert.ToDouble((this.txtCashPayment.Text.Trim().Length == 0 ? "0" : this.txtCashPayment.Text.Trim())), Convert.ToDouble((this.txtNetAmount.Text.Trim().Length == 0 ? "0" : this.txtNetAmount.Text.Trim())), Convert.ToDouble((this.txtDiscount.Text.Trim().Length == 0 ? "0" : this.txtDiscount.Text.Trim())), saleLines, Summary.SummaryNo, Convert.ToDouble(this.txtDeduction.Text.Trim().Length == 0 ? "0" : this.txtDeduction.Text.Trim()), Convert.ToDouble(this.txtReturnAmount.Text.Trim().Length == 0 ? "0" : this.txtReturnAmount.Text.Trim()),/* Convert.ToDouble(this.txtBalance.Text.Trim().Length == 0 ? "0" : this.txtBalance.Text.Trim())*/0);
                        sale.SDateTime = System.DateTime.Now;
                        sale.Reference = txtReference.Text;
                        sale.BranchID = Globals.BranchID;
                        int VID = sc.SaveSale(sale, isNew);
                        if (VID != 0)
                        {
                            MessageBox.Show("Invoice is saved successfully. But in Pending state", "Invoic is saved...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearControls();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Some sale to save.", "No Sale...", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    ClearControls();
                    return;
                }
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmSaleInvoice SaveRecord", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool ValidatePendings()
        {
            try
            {
                int gridcount = 0;
                for(int i = 0; i < Grd.Rows.Count; i++)
                {
                    if(Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value) > 0)
                    {
                        gridcount++;
                    }
                }
               

                if (gridcount==0)
                {                  
                  
                    MessageBox.Show("Select Some Item", "FrmSaleInvoice ValidateControls", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                   
                }
             

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmSaleInvoice ValidateCtrls", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Sch_Forms.frmSchPending frm = new Sch_Forms.frmSchPending();
                frm.ShowDialog();
                string where = "";
                List<SaleInvoice> sales = new List<SaleInvoice>();
                if (frm.SaleID != 0)
                {
                    where = " and SaleInvoice.isPending=1 and SaleInvoice.Saleid=" + frm.SaleID + "";

                    //sales = new SaleInvoiceController().GetPendingSales(where);
                    isNew = false;
                    btnCancel.Visible = true;
                    pendingSale = sales[0];
                    this.txtID.Text = pendingSale.SaleID.ToString();
                    this.txtPartyID.Text = pendingSale.Party.Id.AccountNo.ToString();

                    if (pendingSale.Party.Id.AccountNo.ToString().Trim().Length > 0)
                    {
                        //  VerifyAcc(ref TxtPartyID, ref TxtPartyName);
                    }

                    this.txtCardPayment.Text = pendingSale.Crcamt.ToString();
                    this.txtCashPayment.Text = pendingSale.Cashamt.ToString();
                    this.txtInvDiscount.Text = pendingSale.Invdisc.ToString();
                    this.txtGrandTotal.Text = pendingSale.Total.ToString();
                    this.txtDiscount.Text = pendingSale.Totaldisc.ToString();
                    this.txtReference.Text = pendingSale.Reference;
                    //this.pendingSale = frm.SelectedSale;
                    ChartOfAccounts Ca;
                    Ca = new ChartofAccountsController().GetAccountDetail(pendingSale.Crcid.ToString(), " and isdetailed=1");

                    if (Ca == null)
                    {
                        this.cmbCreditCard.SelectedIndex = 0;

                        this.txtCardPayment.ReadOnly = true;
                    }
                    else
                    {
                        this.cmbCreditCard.Text = Ca.AccountName;
                        this.txtCardPayment.ReadOnly = false;
                    }

                    if (pendingSale.CardDeduction > 0)
                    {
                        this.txtDeduction.Text = pendingSale.CardDeduction.ToString();

                        this.txtDeductionPer.Text = Convert.ToDecimal(pendingSale.CardDeduction * 100 / pendingSale.Crcamt).ToString();
                    }


                    this.txtNetAmount.Text = (pendingSale.Total - pendingSale.Totaldisc).ToString();

                    int i = 0;
                    foreach (SaleInvoiceLine saleLine in pendingSale.SaleLines)
                    {
                        int RowIndex = Grd.Rows.Add();
                        Grd.Rows[RowIndex].Cells["ItemID"].Value = saleLine.Vitem.ItemID.ToString();
                        Grd.Rows[RowIndex].Cells["Item"].Value = saleLine.Vitem.ItemName.ToString();
                      //  Grd.Rows[RowIndex].Cells["Sticker"].Value = saleLine.Vitem.Sticker.ToString();
                        Grd.Rows[RowIndex].Cells["Barcode"].Value = saleLine.Vitem.BarCode.ToString();
                        Grd.Rows[RowIndex].Cells["ShortKey"].Value = saleLine.Vitem.ShortKey.ToString();
                        Grd.Rows[RowIndex].Cells["Rate"].Value = saleLine.SalePrice;
                        //Grd.SetData(i, Grd.Cols["Sale Price"].Index, saleLine.Vitem.SalePrice, true);
                        //Grd.SetData(i, Grd.Cols["Purchase Price"].Index, saleLine.PurchasePrice, true);
                        //Grd.SetData(i, Grd.Cols["Disc Limit"].Index, saleLine.Vitem.DiscountLimit, true);
                        Grd.Rows[RowIndex].Cells["Quantity"].Value = saleLine.Quantity;

                        Grd.Rows[RowIndex].Cells["Disc%"].Value = 0;
                        Grd.Rows[RowIndex].Cells["DiscAmt"].Value = saleLine.Disc;
                        Grd.Rows[RowIndex].Cells["Stock"].Value = saleLine.CStk;
                        Grd.Rows[RowIndex].Cells["Total"].Value = Convert.ToDecimal(Grd.Rows[RowIndex].Cells["Quantity"].Value) * Convert.ToDecimal(Grd.Rows[RowIndex].Cells["Rate"].Value) - Convert.ToDecimal(Grd.Rows[RowIndex].Cells["DiscAmt"].Value);
                        Grd.Rows[RowIndex].Cells["SrNo"].Value = saleLine.SerialNumber;
                        Grd.Rows[RowIndex].Cells["IsDeleted"].Value = saleLine.IsDeleted;
                        //Grd.SetData(Grd.Row, Grd.Cols["New Row"].Index, false, true);

                        decimal dis = new ItemController().GetDiscountOffer(saleLine.Vitem.ItemID);

                        //if (dis > 0)
                        //{
                        //    Grd.SetData(i, Grd.Cols["Disc Offer"].Index, true, true);
                        //    Grd.SetData(i, Grd.Cols["Disc%"].Index, Convert.ToDecimal(saleLine.Disc * 100) / (Convert.ToDecimal(saleLine.Quantity) * Convert.ToDecimal(saleLine.SalePrice)), true);
                        //    Grd.SetData(i, Grd.Cols["Disc Limit"].Index, dis, true);
                        //}
                        //else
                        //{
                        //    Grd.SetData(i, Grd.Cols["Disc Offer"].Index, false, true);
                        //    Grd.SetData(i, Grd.Cols["Disc%"].Index, Convert.ToDecimal(saleLine.Disc * 100) / (Convert.ToDecimal(saleLine.Quantity) * Convert.ToDecimal(saleLine.SalePrice)), true);
                        //    Grd.SetData(i, Grd.Cols["Disc Limit"].Index, saleLine.Vitem.DiscountLimit, true);
                        //}

                        i++;
                    }
                    /// SetRowNo();
                    CalculateTotal();

                    Grd.Focus();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Pending Invoice Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void SetPendingLines()
        {
            try
            {
               
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmSaleInvoice SetSaleLine", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmSaleInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            //if(e.KeyCode==Keys.F12)
            //{
            //    if (SaveSale())
            //    {
            //        PrintInvoice(sale.Saledate);
            //        ClearControls();
            //    }
            //}


          

        }

        private void txtCashPayment_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void cmbCreditCard_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbCreditCard_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            //if (cmbCreditCard.SelectedItem.ToString() == "Credit Sale")
            //{
               
            //    GrpCustomer.Visible = true;
            //    txtCashPayment.Enabled = false;
            //    lblBank.Visible = false;
            //    cmbBank.Visible = false;
            //    lblCardNo.Visible = false;
            //    txtCardNo.Visible = false;
            //    txtCashPayment.ReadOnly = true;
            //}
            //else if(cmbCreditCard.SelectedItem.ToString() == "Credit Card")
            //{
            //   // txtCashPayment.Enabled = false;
            //    GrpCustomer.Visible = false;
            //    lblBank.Visible = true;
            //    cmbBank.Visible = true;
            //    lblCardNo.Visible = true;
            //    txtCardNo.Visible = true;
            //    txtCashPayment.ReadOnly = true;


            //}
            //else if (cmbCreditCard.SelectedItem.ToString() == "Cash & Credit Card")
            //{
            //    //txtCashPayment.Enabled = true;
            //    txtCashPayment.ReadOnly = false;
            //    GrpCustomer.Visible = false;
            //    lblBank.Visible = true;
            //    cmbBank.Visible = true;
            //    lblCardNo.Visible = true;
            //    txtCardNo.Visible = true;
            //}
            //else if (cmbCreditCard.SelectedItem.ToString() == "Cash")
            //{
            //    txtCashPayment.ReadOnly = false;
            //    txtCashPayment.Enabled = true;
            //    GrpCustomer.Visible = false;
            //    lblBank.Visible = false;
            //    cmbBank.Visible = false;
            //    lblCardNo.Visible = false;
            //    txtCardNo.Visible = false;
            //}

        }

        private void txtInvDiscPer_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtNetAmount.Text.Trim()) != 0)
                {
                    txtInvDiscount.Text = Math.Round(((((txtNetAmount.Text.Trim().Length ==0 ? 0 : Convert.ToDecimal(txtNetAmount.Text.Trim())) ) /100) * (txtInvDiscPer.Text.Trim().Length ==0 ? 0 : Convert.ToDecimal(txtInvDiscPer.Text.Trim()))), 2).ToString();
                    CalculateTotal();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Percentage", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtInvDiscount_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (Convert.ToDecimal(txtNetAmount.Text.Trim()) != 0)
            //    {
            //        decimal numirator = txtInvDiscount.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtInvDiscount.Text.Trim());
            //        decimal denominator = txtNetAmount.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtNetAmount.Text.Trim());

            //        txtInvDiscPer.Text = ((numirator * 100) / denominator).ToString();
            //        CalculateTotal();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error Percentage", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void Grd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                int rowIndex = 0;
                int colIndex = 0;
                if (Grd.Rows.Count > 1)
                {
                     rowIndex = Grd.CurrentRow.Index;
                     colIndex = Grd.CurrentCell.ColumnIndex;
                }

                if (e.KeyCode == Keys.F1)
                {

                    SearchItems();

                }
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    int iColumn = Grd.CurrentCell.ColumnIndex;
                    int iRow = Grd.CurrentCell.RowIndex;
                    if (iColumn == Grd.ColumnCount - 1)
                    {
                        if (Grd.RowCount > (iRow + 1))
                        {
                            Grd.CurrentCell = Grd[1, iRow + 1];
                        }
                        else
                        {
                            //focus next control
                        }
                    }
                    else
                        Grd.CurrentCell = Grd[iColumn + 1, iRow];
                }



                if (e.KeyCode == Keys.F3)
                {
                    FrmPwdPopup popup = new FrmPwdPopup();
                    popup.ShowDialog();
                    if (popup.EnableDisc)
                    {
                        Grd.Columns["Disc%"].ReadOnly = false;
                        Grd.Columns["DiscAmt"].ReadOnly = false;
                    }
                }

                if (e.KeyCode == Keys.F2)
                {
                    AccountsGlobals.ShowItemCreation();
                    e.Handled = true;
                }
                if (e.KeyCode == Keys.Delete)
                {
                    DialogResult result = MessageBox.Show("Do really want to delete this Row?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        int currentRow = Grd.CurrentRow.Index;
                        int selectRow = 0;

                        //Grd.Rows.Remove(Grd.Rows [Grd.CurrentRow .Index ]);
                        Grd.Rows[Grd.CurrentRow.Index].Cells["IsDeleted"].Value = true;
                        Grd.Rows[Grd.CurrentRow.Index].Visible = false;

                        CalculateTotal();

                        for (int i = currentRow + 1; i < Grd.Rows.Count; i++)
                        {
                            if (Grd.Rows[i].Visible == true)
                            {
                                selectRow = i;
                                break;
                            }
                        }

                        Grd.Rows[selectRow].Cells["ItemID"].Selected = true;
                        // SetRowNo(ref Grd);
                    }
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Grd_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchItems()
        {
            int rowIndex = Grd.CurrentRow.Index;

            if (Convert.ToInt32(Grd.Rows[rowIndex].Cells["SrNo"].Value) == 0)
            {
                Accounts.SchForms.SchItems sch = new Accounts.SchForms.SchItems();
                sch.BranchId = Convert.ToInt32(cmbBranch.SelectedValue);
                sch.ShowDialog();
                List<Item> lstitem = new List<Item>();

                lstitem = sch.subList1;
                if (lstitem.Count > 0)
                {
                   
                    for (int i = 0; i < lstitem.Count; i++)
                    {
                        if (ChkExistingItem(lstitem[i].ItemID) == 0)
                        {
                            Grd.Rows.Add();
                            Grd.Rows[rowIndex].Cells["ItemID"].Value = lstitem[i].ItemID.ToString();
                            Grd.Rows[rowIndex].Cells["Barcode"].Value = lstitem[i].BarCode.ToString();
                            Grd.Rows[rowIndex].Cells["Item"].Value = lstitem[i].ItemName.ToString();
                            Grd.Rows[rowIndex].Cells["Rate"].Value = lstitem[i].SalePrice;
                            Grd.Rows[rowIndex].Cells["Stock"].Value = lstitem[i].CurrentStock;
                            Grd.Rows[rowIndex].Cells["Quantity"].Value = 0;
                            Grd.Rows[rowIndex].Cells["IsDeleted"].Value = false;
                            noSale = false;
                            CalculateTotal();
                        }
                        else
                        {
                            MessageBox.Show("This Item has already been added!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ResetRow();
                        }
                    }

                }
            }
        }

        private void txtPartyID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                Grd.Focus();               
            }
        }

        private void txtSaleid_KeyDown(object sender, KeyEventArgs e)


            {

                try
                {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtSaleid.Text.Length > 0)
                    {
                        sales = (new SaleInvoiceController().GetAllSale(Convert.ToInt32(txtSaleid.Text)));
                        if (sales.Count > 0)
                        {
                            pendingSale = sales[0];


                            //int i = 0;
                            foreach (SaleInvoiceLine saleLine in pendingSale.SaleLines)
                            {

                                int RowIndex = Grd.Rows.Add();
                                for (int k = 0; k < Grd.RowCount; k++)
                                {

                                    if (Convert.ToString((Grd.Rows[k].Cells["SaleID"].Value)) == (txtSaleid.Text))
                                    {

                                        MessageBox.Show("Item Already Exist.", "...", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                                        txtSaleid.Clear();

                                    }
                                    else
                                    {



                                        Grd.Rows[RowIndex].Cells["SaleID"].Value = saleLine.SaleID.ToString();
                                        Grd.Rows[RowIndex].Cells["ItemID"].Value = saleLine.Vitem.ItemID.ToString();
                                        Grd.Rows[RowIndex].Cells["Item"].Value = saleLine.Vitem.ItemName.ToString();
                                        //  Grd.Rows[RowIndex].Cells["Sticker"].Value = saleLine.Vitem.Sticker.ToString();
                                        Grd.Rows[RowIndex].Cells["Barcode"].Value = saleLine.Vitem.BarCode.ToString();
                                        Grd.Rows[RowIndex].Cells["ShortKey"].Value = saleLine.Vitem.ShortKey.ToString();
                                        Grd.Rows[RowIndex].Cells["Rate"].Value = saleLine.SalePrice;
                                        //Grd.SetData(i, Grd.Cols["Sale Price"].Index, saleLine.Vitem.SalePrice, true);
                                        //Grd.SetData(i, Grd.Cols["Purchase Price"].Index, saleLine.PurchasePrice, true);
                                        //Grd.SetData(i, Grd.Cols["Disc Limit"].Index, saleLine.Vitem.DiscountLimit, true);
                                        Grd.Rows[RowIndex].Cells["Quantity"].Value = saleLine.Quantity;

                                        Grd.Rows[RowIndex].Cells["Disc%"].Value = 0;
                                        Grd.Rows[RowIndex].Cells["DiscAmt"].Value = saleLine.Disc;
                                        // Grd.Rows[RowIndex].Cells["Stock"].Value = saleLine.CStk;
                                        Grd.Rows[RowIndex].Cells["Total"].Value = Convert.ToDecimal(Grd.Rows[RowIndex].Cells["Quantity"].Value) * Convert.ToDecimal(Grd.Rows[RowIndex].Cells["Rate"].Value) - Convert.ToDecimal(Grd.Rows[RowIndex].Cells["DiscAmt"].Value);
                                        //Grd.Rows[RowIndex].Cells["SrNo"].Index, saleLine.SerialNumber, true);
                                        Grd.Rows[RowIndex].Cells["IsDeleted"].Value = saleLine.IsDeleted;
                                        //Grd.SetData(Grd.Row, Grd.Cols["New Row"].Index, false, true);
                                        txtSaleid.Clear();
                                        //decimal dis = new ItemController().GetDiscountOffer(saleLine.Vitem.ItemID);
                                    }
                                }



                                //i++;
                            }
                        }

                        CalculateTotal();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "FrmSaleInvoice SetSaleLine", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        grd.Rows[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        count++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetRowNo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Grd_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            SetRowNo(ref Grd);
        }

        private void Grd_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            SetRowNo(ref Grd);
        }

        private void PnlSub_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Grd_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Grd_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Grd_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (Grd.CurrentCell.ColumnIndex == 6)
                    {
                        Grd.Rows[Grd.CurrentRow.Index + 1].Cells[0].Selected = true;
                    }
                }
                base.OnKeyUp(e);
            }
            catch (Exception)
            { }
        }

        private void txtSaleid_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          

        }

        private void frmSaleInvoice_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SchAccounts Sch = new SchAccounts();
                Sch.accountType = " and p.inSale=1 ";
                Sch.POS = "S";
                Sch.ShowDialog();
                if (Sch.SelectedAccount != null)
                {
                    txtPartyID.Text = Sch.SelectedAccount.AccountNo;
                    txtPartyDetail.Text = Sch.SelectedAccount.AccountName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (cmbBranch.SelectedIndex > -1)
            {
                Sch_Forms.SchSaleInvoice frm = new Sch_Forms.SchSaleInvoice();
                frm.Branchid = Convert.ToInt32(cmbBranch.SelectedValue);
                frm.ShowDialog();

                if (frm.item!=null)
                {
                    ClearControls();
                    isNew = false;

                    txtID.Text = frm.item.SaleID.ToString();
                    cmbBranch.SelectedValue = frm.item.BranchID;
                    cmbBranch.Enabled = false;

                    txtUserName.Text = frm.item.UserName;
                    dtpDate.Value = frm.item.Saledate;
                    txtPartyID.Text = frm.item.PartyID;
                    txtPartyDetail.Text = frm.item.PartyName;
                    txtGrandTotal.Text = frm.item.Total.ToString();

                    PopulateEditLines(frm.item.SaleLines);
                    CalculateTotal();
                }
            }
            else
            {
                MessageBox.Show("Select Branch First", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void PnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidatePendings())
                {
                    int saleid = Convert.ToInt32(txtID.Text);
                    DateTime date = Convert.ToDateTime(lblDate.Text);
                    int branchid = Globals.BranchID;
                    if (SaveSale())
                    {
                        if (new SaleInvoiceController().CancelSale(sale, date, branchid))
                        {
                            MessageBox.Show("Invoice cancelled successfully.", "Invoic is cancelled...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                          
                            ClearControls();
                        }
                    }
                }


               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public void PhoneBook()
        {
            try
            {
                Common.Data_Sets.DSPhoneBook dSPhoneBook = new Common.Data_Sets.DSPhoneBook();
                if (new SaleInvoiceController().GetPhoneBook(ref dSPhoneBook))
                {

                    Report_Forms.frmViewer Viewer = new Report_Forms.frmViewer();
                    Viewer.reportViewer1.Reset();

                    if (dSPhoneBook.Tables["SPPhoneBook"].Rows.Count > 0)
                    {
                        ReportDataSource rds = new ReportDataSource("DataSet1", dSPhoneBook.Tables["SPPhoneBook"]);
                        Viewer.reportViewer1.LocalReport.DataSources.Add(rds);
                        Viewer.reportViewer1.LocalReport.ReportPath = Globals.ReportPath + "/Report/RptPhoneBook.rdlc";
                        Viewer.reportViewer1.LocalReport.Refresh();
                        Viewer.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("No Data Found", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No Data Found", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "PhoneBook", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Grd.Rows.Count > 1)
                {
                   
                   LoadGrid();
                   
                }
                if (cmbBranch.Text.Trim().Length == 0)
                {
                    Grd.Enabled = false;
                }
                else
                {
                  
                    Grd.Enabled = true;
                }
            }
            catch(Exception ex) { }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (Grd.Rows.Count > 1)
            {
                DialogResult result = MessageBox.Show("If you change Date, Data will be Clear. Do you want to change Date?", "Validtion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    LoadGrid();
                }
            }
        }
    }
    
}
    


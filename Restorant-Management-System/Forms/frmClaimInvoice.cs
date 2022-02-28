
using Common;
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
using Microsoft.Reporting.WinForms;
using System.IO;
using CommonController;

namespace Restorant_Management_System.Forms
{
    public partial class frmClaimInvoice : Form
    {
        private List<ClaimInvoiceLine> claimLines;
        private ClaimInvoice claim;
        private bool isNew = true;

        public List<PurchaseInvoice> InvoiceLines = new List<PurchaseInvoice>();
        private ClaimInvoiceType invoiceType;
        public List<ChartOfAccounts> CourierAccounts;
        private SaleReturn saleReturn;
        private SaleReturnLine saleReturnLine;
        private List<SaleReturnLine> saleReturnLines = new List<SaleReturnLine>();

        private PurchaseReturn purchaseReturn;
        private PurchaseReturnLine purchaseReturnLine;
        private List<PurchaseReturnLine> purchaseReturnLines = new List<PurchaseReturnLine>();
        private List<PurchaseLine> purchaseLines = new List<PurchaseLine>();

        private SaleReturnController src = new SaleReturnController();
        private PurchaseReturnController prc = new PurchaseReturnController();

        private SaleInvoice sale;
        private Purchase purchase;
        private PurchaseLine purchaseLine;

        string invPrinter;

        private int serialNo = 0;

        private int oi = 0;

        private bool NoReturn = true;
    
      
        public frmClaimInvoice()
        {
            InitializeComponent();
        }

        private void frmClaimInvoice_Load(object sender, EventArgs e)
        {
            cmbInvoiceType.DataSource = Enum.GetValues(typeof(ClaimInvoiceType));
           

            ClearControls();
            if (!User._IsAdmin)
            {
                CheckRights(Convert.ToInt16(this.Tag));
                dtpDated.Enabled = AccountsGlobals.UserRights[AccountsGlobals.DateRights].CanAccess;
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
        private void LoadCourierAcc()
        {
            CourierAccounts = new ChartofAccountsController().GetCourierAccounts();
            cmbCourier.DataSource = CourierAccounts;
            cmbCourier.DisplayMember = "AccountName";
            cmbCourier.ValueMember = "AccountNo";
            cmbCourier.SelectedIndex = -1;
        }
        private void ClearControls()
        {
            try
            {
                cmbClaimType.Enabled = true;
                chkAdjustEntry.Enabled = true;
                this.txtUserName.Text = User._UserName;
                txtTotalQuantity.Clear();
                txtPartyID.Clear();
                txtPartyDetail.Clear();
                txtInvoiceNo.Clear();
                chkAdjustEntry.Checked = false;
                this.oi = 0;
                this.cmbClaimType.Enabled = true;
                chkAdjustEntry.Checked = false;
                PopulateClaimType();
                this.txtID.Text = new ClaimInvoiceController().GetMaximumID(invoiceType).ToString();

                LoadWarehouse();
                LoadGrid();
                txtRemarks.Clear();
                this.dtpDated.Value = AccountsGlobals.ServerDate;  

                this.txtInvDisc.Text= "0";
                this.txtInvDiscPer.Text= "0";
                txtInvDisc.Text = "0";
                this.txtPaid.Text = "0";
                txtCourierAmount.Text = "0";
                txtTrackingID.Clear();
                this.dtpDated.Value = System.DateTime.Now.Date;

                LoadCourierAcc();

                this.dtpDated.Focus();
                txtTotalAmt.Clear();
                txtInvDisc.Clear();
                txtInvDiscPer.Clear();
                txtPaid.Clear();
                this.isNew = true;
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmSaleInvoice ClearControls", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool LoadWarehouse()
        {
            try
            {

                List<Branch> counters = new BranchController().GetBranch(" where b.IsWarehouse=1 ");
                cmbBranch.DataSource = counters;
                cmbBranch.ValueMember = "ID";
                cmbBranch.DisplayMember = "BranchName";
                //if (User._IsAdmin)
                //{
                //    cmbBranch.Enabled = true;
                //    cmbBranch.SelectedIndex = -1;
                //}
                //else
                //{
                //    cmbBranch.Enabled = false;
                //    cmbBranch.SelectedValue = Globals.BranchID;
                //}

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadCategories", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void PopulateClaimType()
        {
            try
            {
                this.cmbClaimType.Items.Clear();

                //this.cbxClaimType.Items.Add(ClaimType.SaleReturn);
                //this.cbxClaimType.Items.Add(ClaimType.SaleDamage);
                this.cmbClaimType.Items.Add(ClaimType.PurchaseReturn);
                //this.cbxClaimType.Items.Add(ClaimType.PurchaseDamage);
                this.cmbClaimType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmClaimInvoice PopulateClaimType", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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


                ////Col 2
                ////////////////////////////////////////////////////////////////////////////////////////////////////                
                //comboCol2.CellTemplate = ComboCell2;
                //comboCol2.DataSource = stores;
                //comboCol2.DisplayMember = "Name";
                //comboCol2.ValueMember = "ID";
                //comboCol2.HeaderText = "Store";
                //comboCol2.Name = "Store";
                //comboCol2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                //comboCol2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //comboCol2.Width = 90;
                //comboCol2.Visible = Globals.StoreColumnVisible;
                //Grd.Columns.Add(comboCol2);


                //Col 2
                //////////////////////////////////////////////////////////////////////////////////////////////////   

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
                newCol.Width = 80;
                newCol.Visible = false;
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
                ////////////////////////////

                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Product";
                newCol.Name = "Item";

                newCol.CellTemplate = TextCell;

                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;
                newCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                newCol.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //  newCol.Visible = Globals.PackingColumnVisible;
                newCol.Width = 250;
                Grd.Columns.Add(newCol);

                //Col 4
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Inv ID";
                newCol.Name = "InvID";

                newCol.CellTemplate = IntCell;

                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = false;
                if (cmbInvoiceType.SelectedValue.ToString() == "SR")
                {
                    newCol.Visible = false;
                }
                else
                {
                    newCol.Visible = true;
                }
                newCol.Width = 80;
                Grd.Columns.Add(newCol);

                //Col 3
                //////////////////////////////////////////////////////////////////////////////////////////////////               
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Stock";
                newCol.Name = "Stock";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (cmbInvoiceType.SelectedValue.ToString() == "SR")
                {
                    newCol.Visible = false;
                }
                else
                {
                    newCol.Visible = true;
                }
                newCol.ReadOnly = true;
                newCol.Width = 70;
                Grd.Columns.Add(newCol);
                //////////////////////////////////////////////////////////////////////////////////////////////////    
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Quantity";
                newCol.Name = "Quantity";
                newCol.CellTemplate = DecimalCell;//RateCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.Width = 60;
                Grd.Columns.Add(newCol);
                ////////////////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Return Qty";
                newCol.Name = "ReturnQty";
                newCol.CellTemplate = DecimalCell;//RateCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.Width = 60;
                Grd.Columns.Add(newCol);


                //// To avoid all the annoying error messages, handle the DataError event of the DataGridView:
                //Grd.DataError += new DataGridViewDataErrorEventHandler(Grd_DataError); 

               
                
                ////Col 5
                //////////////////////////////////////////////////////////////////////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderCell.Style.BackColor = Color.Yellow;
                newCol.HeaderText = "Disc %";
                newCol.Name = "Disc%";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = false;
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
                newCol.Width = 60;
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
                newCol.Width = 80;
                Grd.Columns.Add(newCol);





                //Col 7
                //////////////////////////////////////////////////////////////////////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "SrNo";
                newCol.Name = "SrNo";
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

        private void Grd_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int rowIndex = Grd.CurrentRow.Index;
                int colIndex = Grd.CurrentCell.ColumnIndex;

                if (Grd.Rows.Count > 1)
                {
                
                    if (colIndex == Grd.Columns["ItemID"].Index)
                    {
                     
                        purchaseLines.Clear();
                        purchaseLines = new PurchaseController().VerifyItem(Grd.Rows[rowIndex].Cells["ItemID"].Value.ToString().Trim(), "i", Convert.ToInt32(cmbBranch.SelectedValue), txtPartyID.Text.Trim());
                        AddLines(rowIndex, purchaseLines);
                      
                        
                    }
                    else if (colIndex == Grd.Columns["ReturnQty"].Index)
                    {


                        if ((Convert.ToDecimal(Grd.Rows[rowIndex].Cells["ReturnQty"].Value) > Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Stock"].Value)) && invoiceType == ClaimInvoiceType.PR)
                        {
                            MessageBox.Show("Quantity can not be greater then Current Stock.", "Check Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Grd.Rows[rowIndex].Cells["ReturnQty"].Value = 0;

                        }
                        else
                        {
                            if (Grd.Rows[rowIndex].Cells["ReturnQty"].Value != null)
                            {

                                if (Grd.Rows[rowIndex].Cells["Rate"].Value.ToString().Trim().Length != 0)
                                {
                                    Grd.Rows[rowIndex].Cells["Total"].Value = Convert.ToDecimal(Grd.Rows[rowIndex].Cells["ReturnQty"].Value) * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Rate"].Value);

                                    // Grd.SetData(Grd.Row, Grd.Cols["Deleted"].Index, false);
                                    CalculateTotal(sender);
                                }
                            }
                        }
                    
                }
                else if (colIndex == Grd.Columns["Rate"].Index)
                {


                    Grd.Rows[rowIndex].Cells["Total"].Value = Convert.ToDecimal(Grd.Rows[rowIndex].Cells["ReturnQty"].Value) * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Rate"].Value);
                    CalculateTotal(sender);



                }
            }   
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmClaimInvoice Grd_BeforeRowColChange", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearRow()
        {
            int rowIndex = Grd.CurrentRow.Index;
            Grd.Rows[rowIndex].Cells["ItemID"].Value = null;
            Grd.Rows[rowIndex].Cells["BarCode"].Value = null;
            Grd.Rows[rowIndex].Cells["Item"].Value = null;
            Grd.Rows[rowIndex].Cells["Stock"].Value = null;
            Grd.Rows[rowIndex].Cells["ReturnQty"].Value = null;
            Grd.Rows[rowIndex].Cells["Rate"].Value = null;
            Grd.Rows[rowIndex].Cells["Disc%"].Value = null;
            Grd.Rows[rowIndex].Cells["DiscAmt"].Value = null;
          
            Grd.Rows[rowIndex].Cells["Total"].Value = null;
        }

        private void AddLines(int rowIndex, List<PurchaseLine> purchaseLines)
        {
            try
            {
                if (ChkExistingItem(purchaseLines[0].Item.ItemID) == 0)
                {
                    Grd.Rows[rowIndex].Cells["BarCode"].Value = purchaseLines[0].Item.BarCode;
                    Grd.Rows[rowIndex].Cells["ItemID"].Value = purchaseLines[0].Item.ItemID;
                    Grd.Rows[rowIndex].Cells["Item"].Value = purchaseLines[0].Item.ItemName;
                    Grd.Rows[rowIndex].Cells["Stock"].Value = purchaseLines[0].Item.CurrentStock;
                    Grd.Rows[rowIndex].Cells["ReturnQty"].Value = 0;               
                    Grd.Rows[rowIndex].Cells["Rate"].Value = purchaseLines[0].PurchasePrice;
                    Grd.Rows[rowIndex].Cells["Total"].Value = Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Rate"].Value) * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["ReturnQty"].Value);
                }
                else
                {
                    MessageBox.Show("This Item has already been added!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ResetRow();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "AddLines", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private int ChkExistingItem(int id)
        {
            try
            {
                for (int i = 0; i < Grd.Rows.Count; i++)
                {
                    if (Grd.Rows[i].Cells["ItemID"].Visible == true)
                    {
                        if (id == Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value) && i != Grd.CurrentRow.Index)
                        {
                            return id;
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

        private void CalculateTotal(object sender)

            {
            decimal totalAmt = 0;
            decimal InvoiceDiscount = 0;
            decimal Discount = 0;
            decimal totalQuantity = 0;



            InvoiceDiscount = (txtInvDisc.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtInvDisc.Text.Trim()));
            Discount = (txtInvDiscPer.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtInvDiscPer.Text.Trim()));

            for (int i = 0; i < Grd.Rows.Count; i++)
            {
                if (Grd.Rows[i].Visible == true)
                {
                    totalAmt += Convert.ToDecimal(Grd.Rows[i].Cells["Total"].Value);
                    totalQuantity += Math.Round(Convert.ToDecimal(Grd.Rows[i].Cells["ReturnQty"].Value), 2);

                }
            }

            if (sender is TextBox)
            {
                if (totalAmt > 0)
                {
                    if ((TextBox)sender == txtInvDiscPer)
                    {
                        InvoiceDiscount = totalAmt * Convert.ToDecimal((txtInvDiscPer.Text.Trim().Length == 0 ? "0" : txtInvDiscPer.Text.Trim())) / 100;
                        this.txtInvDisc.Text = Math.Round(InvoiceDiscount, 2).ToString();
                    }
                    else if ((TextBox)sender == txtInvDisc)
                    {
                        txtInvDiscPer.Text = Math.Round((Convert.ToDecimal((txtInvDisc.Text.Trim().Length == 0 ? "0" : txtInvDisc.Text.Trim()))) * 100 / totalAmt, 2).ToString();
                    }
                }
            }


           
            this.txtTotalAmt.Text = totalAmt.ToString();
            this.txtTotalQuantity.Text = totalQuantity.ToString();

          txtPaid.Text = (totalAmt - InvoiceDiscount).ToString();
           // txtPaid.Text = (totalAmount). ToString();
        }

        private void btnSchVendor_Click(object sender, EventArgs e)
        {
            ShowSearch(ref txtPartyID, ref txtPartyDetail);
        }
        private void ShowSearch(ref System.Windows.Forms.TextBox txtno, ref System.Windows.Forms.TextBox txtname)
        {
            try
            {                        
                SchAccounts Sch = new SchAccounts();
                Sch.accountType = " and accountno like '6%'";
                Sch.POS = "P";
                Sch.ShowDialog();
                if (Sch.SelectedAccount != null)
                {
                   
                    txtno.Text = Sch.SelectedAccount.AccountNo;
                    txtname.Text = Sch.SelectedAccount.AccountName;
                 
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private Boolean ValidateControls()
        {



            if (this.txtPartyID.Text.Trim().Length == 0 && (this.cmbClaimType.Text == ClaimType.PurchaseReturn.ToString()))// (this.txtCustomerID.Text.Trim().Length == 0 && (this.cbxClaimType.Text == ClaimType.SaleDamage.ToString()))
            {
                MessageBox.Show("Please Select or Enter Party.", "Party", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtPartyID.Focus();
                return false;
            }
          
            else if (LineCount() == 0)
            {
                MessageBox.Show("Please Enter some item to Save.", "Enter Details...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Grd.Focus();
                return false;
            }
            else
                return true;
        }
        private Nullable<Int32> LineCount()
        {
            try
            {
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
                return Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LineCount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public void PopulateSaleReturnLines()
        {
            try
            {
                if (saleReturnLines == null) saleReturnLines = new List<SaleReturnLine>();
                saleReturnLines.Clear();

                for (int i = 0; i < Grd.Rows.Count; i++)
                {
                    if (Grd.Rows[i].Cells["ReturnQty"].Value != null)
                    {
                        if (Grd.Rows[i].Cells["ReturnQty"].Value.ToString().Trim().Length != 0)
                        {
                            saleReturnLine = new SaleReturnLine();
                            //purchaseReturnLine.Category = new Category(0, (string)Grd.GetData(i, Grd.Cols["Department"].Index));
                            saleReturnLine.Item = new Item(Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value));
                            saleReturnLine.Quantity = (decimal)Grd.Rows[i].Cells["ReturnQty"].Value;
                            saleReturnLine.PurchasePrice = (decimal)Grd.Rows[i].Cells["Rate"].Value;
                            //saleReturnLine.SalePrice = (decimal)Grd.GetData(i, Grd.Cols["Sale Price"].Index);
                            purchaseReturnLine.TotalAmount = (decimal)Grd.Rows[i].Cells["Total"].Value;
                            saleReturnLine.SerialNumber = Convert.ToInt32(Grd.Rows[i].Cells["SrNo"].Value);
                            saleReturnLine.IsDeleted = (bool)Grd.Rows[i].Cells["IsDeleted"].Value;
                            saleReturnLine.BranchID = BranchID;
                            saleReturnLines.Add(saleReturnLine);

                            NoReturn = false;
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "FrmPurchaseInvoice PopulatePurchaseList.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void PopulatePurchaseReturnLines()
        {
            try
            {
                if (purchaseReturnLines == null)
                {
                    purchaseReturnLines = new List<PurchaseReturnLine>();
                }
                purchaseReturnLines.Clear();

                for (int i = 0; i < Grd.Rows.Count; i++)
                {
                    if (Grd.Rows[i].Cells["ReturnQty"].Value != null)
                    {
                        if (Grd.Rows[i].Cells["ReturnQty"].Value.ToString().Trim().Length != 0 && Grd.Rows[i].Cells["ReturnQty"].Value.ToString().Trim() != "0")
                        {
                            purchaseReturnLine = new PurchaseReturnLine();
                            //purchaseReturnLine.Category = new Category(0, (string)Grd.GetData(i, Grd.Cols["Department"].Index));
                            purchaseReturnLine.Item = new Item(Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value), new ItemName(Grd.Rows[i].Cells["Item"].Value.ToString(), "", "", ""));
                            purchaseReturnLine.Quantity = (decimal)Grd.Rows[i].Cells["ReturnQty"].Value;
                            purchaseReturnLine.PurchasePrice = (decimal)Grd.Rows[i].Cells["Rate"].Value;
                            purchaseReturnLine.TotalAmount = (decimal)Grd.Rows[i].Cells["Total"].Value;
                            purchaseReturnLine.SerialNumber = Convert.ToInt32(Grd.Rows[i].Cells["SrNo"].Value == null ? "0" : Grd.Rows[i].Cells["SrNo"].Value.ToString());
                            purchaseReturnLine.IsDeleted = Convert.ToBoolean(Grd.Rows[i].Cells["IsDeleted"].Value);
                            purchaseReturnLine.BranchID = BranchID;

                            purchaseReturnLines.Add(purchaseReturnLine);
                            NoReturn = false;


                        }
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "FrmPurchaseInvoice PopulatePurchaseList.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
     
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateControls())
                {
                    if (AddSale())
                    {
                        int VID = (new ClaimInvoiceController().SaveClaim(claim, isNew));
                        if (VID > 0)
                        {
                            MessageBox.Show("Claim Invoice has been Saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           

                            DialogResult result = MessageBox.Show("Do you want to print this Invoice?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                
                                SetReport(VID);
                                ClearControls();
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

        private void SetReport(int VID)
        {
            try
            {
               
                Common.Data_Sets.DSClaim ds = new Common.Data_Sets.DSClaim();
                string where = " where  ci.id="+ VID + " and ci.type='"+ invoiceType + "' ";
                if (new ClaimInvoiceController().GetReportData(ref ds, where, invoiceType))
                {

                    Report_Forms.frmViewer Viewer = new Report_Forms.frmViewer();
                    Viewer.reportViewer1.Reset();

                    if (ds.Tables["SPClaim"].Rows.Count > 0)
                    {
                        ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables["SPClaim"]);
                        Viewer.reportViewer1.LocalReport.DataSources.Add(rds);
                        Viewer.reportViewer1.LocalReport.ReportEmbeddedResource = "Restorant_Management_System.Report.RptClaimInvoice.rdlc";

                        ReportParameter[] rptParams = new ReportParameter[]
                        {
                                     new ReportParameter("User",User._UserName),
                        };
                        Viewer.reportViewer1.LocalReport.SetParameters(rptParams);
                        Viewer.reportViewer1.LocalReport.Refresh();
                        Viewer.ShowDialog();

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "SetReport", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private bool AddSale()
        {
            try
            {

                claim = new ClaimInvoice();
                claim.Party = new ChartOfAccounts(txtPartyID.Text.Trim(), "");
                claim.BranchID = Globals.BranchID;//Convert.ToInt32(cmbBranch.SelectedValue);
                claim.ID = Convert.ToInt32(txtID.Text.Trim());
                claim.Type = invoiceType;
                claim.Dated = dtpDated.Value;
                claim.TotalAmt = Convert.ToDecimal(txtTotalAmt.Text.Trim());
                claim.CreatedBy = User.UserNo;
                claim.Remarks = txtRemarks.Text.Trim();
                claim.InvoiceNo = txtID.Text.ToString();
                claim.IsAdjEntry = chkAdjustEntry.Checked;
                
                if (!AddClaimLines())
                {
                    return false;
                }

                claim.ClaimLines = claimLines;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool AddClaimLines()
        {
            try
            {
                if (Grd.Rows.Count > 0)
                {
                    claimLines = new List<ClaimInvoiceLine>();

                    for (int i = 0; i < Grd.Rows.Count; i++)
                    {

                        if (Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value) != 0)
                        {
                            if (Convert.ToDecimal(Grd.Rows[i].Cells["ReturnQty"].Value) != 0)
                            {
                                ClaimInvoiceLine line = new ClaimInvoiceLine();
                                Item item = new Item();
                                item.ItemID = Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value);
                                line.Item = item;
                               
                                line.Quantity = Convert.ToDecimal(Grd.Rows[i].Cells["ReturnQty"].Value);
                                if (invoiceType == ClaimInvoiceType.PR)
                                {
                                    line.InvID = Convert.ToInt32(Grd.Rows[i].Cells["InvID"].Value);
                                }
                                else
                                {
                                    line.InvID = Convert.ToInt32(txtInvoiceNo.Text);
                                }
                                line.Rate = Convert.ToDecimal(Grd.Rows[i].Cells["Rate"].Value);
                                //line.PurPrice = Convert.ToDecimal(Grd.Rows[i].Cells["PurPrice"].Value);
                                line.SrNo = Convert.ToInt32(Grd.Rows[i].Cells["SrNo"].Value);
                                line.IsDeleted = Convert.ToBoolean(Grd.Rows[i].Cells["IsDeleted"].Value);
                         

                                claimLines.Add(line);
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
        private void PrintInvoice(int VID)
        {
            try
            {
                PrintDialog pd = new PrintDialog();
                string oldPrinter = pd.PrinterSettings.DefaultPageSettings.PrinterSettings.PrinterName;
                Common.Data_Sets.DSPurchaseReturn dSPurchaseReturn = new Common.Data_Sets.DSPurchaseReturn();

                if (new PurchaseReturnController().GetPurchaseReturn(ref dSPurchaseReturn, VID))
                {

                    Report_Forms.frmViewer Viewer = new Report_Forms.frmViewer();
                    Viewer.reportViewer1.Reset();

                    if (dSPurchaseReturn.Tables["SPPurchaseReturn"].Rows.Count > 0)
                    {
                        ReportDataSource rds = new ReportDataSource("DataSet1", dSPurchaseReturn.Tables["SPPurchaseReturn"]);
                        Viewer.reportViewer1.LocalReport.DataSources.Add(rds);

                        Viewer.reportViewer1.LocalReport.ReportPath = Globals.ReportPath + "/Report/RptClaimInvoice.rdlc";

                        Viewer.reportViewer1.LocalReport.Refresh();
                        Viewer.ShowDialog();

                        


                    }
                }
                else
                {
                    MessageBox.Show("No Data Found.", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                Accounts.SchForms.SchClaim sch = new Accounts.SchForms.SchClaim();
                sch.type = invoiceType;
                sch.ShowDialog();
                ClaimInvoice p = sch.item;
                if (p != null)
                {
                    SetFormControls(p);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "tsbtnEdit_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SetFormControls(ClaimInvoice p)
        {
            try
            {
                if (p != null)
                {
                    ClearControls();


                  
                    this.txtRemarks.Text = p.Remarks;
                    chkAdjustEntry.Enabled = false;
                    cmbBranch.SelectedValue = p.BranchID;
                    this.txtPartyDetail.Text = p.Party.AccountName;
                    this.txtPartyID.Text = p.Party.AccountNo;
                    this.txtTotalAmt.Text = p.TotalAmt.ToString();
                    txtInvoiceNo.Text = p.ClaimLines[0].InvID.ToString();


                    PopulateSaleLines(p.ClaimLines);
                    this.txtID.Text = p.ID.ToString();
               
                    this.isNew = false;
                    this.cmbInvoiceType.Enabled = false;
                    //this.tsbtnDelete.Enabled = true;
                    this.dtpDated.Value = p.Dated;

                  
                    CalculateTotal(0);


                    //if (new VoucherController().CheckVoucherEntry(Convert.ToInt32(txtID.Text.Trim()), (invoiceType == ClaimInvoiceType .PR ?  VoucherType.PRV : VoucherType .SRV )))
                    //{
                    //    this.tsbtnDelete.Enabled = false;
                    //    this.tsbtnSave.Enabled = false;
                    //    MessageBox.Show("Please delete the relevant Voucher before editing this Claim Invoice", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //}

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadControls", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private bool PopulateSaleLines(List<ClaimInvoiceLine> lines)
        {
            try
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    int rowIndex = Grd.Rows.Add();

                    Grd.Rows[rowIndex].Cells["ItemID"].Value = lines[i].Item.ItemID;
                    Grd.Rows[rowIndex].Cells["Item"].Value = lines[i].Item.ItemName.ProductName;
                    Grd.Rows[rowIndex].Cells["ReturnQty"].Value = lines[i].Quantity;
                   
                    Grd.Rows[rowIndex].Cells["Rate"].Value = lines[i].Rate;
                    Grd.Rows[rowIndex].Cells["Quantity"].Value = lines[i].SaleQty;
                    Grd.Rows[rowIndex].Cells["Stock"].Value = lines[i].Csqty;
                   
                    Grd.Rows[rowIndex].Cells["InvID"].Value = lines[i].InvID;
                  
                    Grd.Rows[rowIndex].Cells["Total"].Value = lines[i].Rate * lines[i].Quantity;
                   
                    Grd.Rows[rowIndex].Cells["SrNo"].Value = lines[i].SrNo;
                    Grd.Rows[rowIndex].Cells["IsDeleted"].Value = lines[i].IsDeleted;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AddLines", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public void PopulatePurhaseReturns()
        {
            try
            {

                this.txtID.Text = purchaseReturn.RetInvoiceNo.ToString();
                txtUserName.Text = purchaseReturn.UserName;
                cmbBranch.SelectedValue = purchaseReturn.BranchID;
                chkAdjustEntry.Checked = purchaseReturn.IsAdjust;
                this.dtpDated.Value = purchaseReturn.PurchaseReturnDate.Date;
                txtRemarks.Text = purchaseReturn.Remarks;
                cmbCourier.SelectedValue = purchaseReturn.CourierAccount;
                txtTrackingID.Text = purchaseReturn.TrackingID;
                txtCourierAmount.Text = purchaseReturn.CourierAmount.ToString();
                if (purchaseReturn.Narration != null)
                {
                    txtNaration.Text = purchaseReturn.Narration.ToString();

                }

                this.txtPartyID.Text = purchaseReturn.Vendor.Id.AccountNo;
                this.txtPartyDetail.Text = purchaseReturn.Vendor.Name;
                this.txtPartyID.Focus();

                this.cmbClaimType.Text = ClaimType.PurchaseReturn.ToString();
                this.cmbClaimType.Enabled = false;
                LoadGrid();

                //this.txtNarration.Text = saleReturn.Narration;

                this.txtTotalAmt.Text = purchaseReturn.TotalAmount.ToString();
               // this.txtPaid.Text = purchaseReturn.AmountPaid.ToString();

                this.txtInvDisc.Text = purchaseReturn.Discount.ToString();
                this.txtInvDiscPer.Text = (purchaseReturn.Discount * 100 / purchaseReturn.TotalAmount).ToString();

               // this.txtPaid.Text = Convert.ToString(Convert.ToDecimal(this.txtTotalAmount.Text) - Convert.ToDecimal(this.txtInvDisc.Text.Trim().Length == 0 ? "0" : this.txtInvDisc.Text.Trim()));

                int i = 1;
                foreach (PurchaseReturnLine pl in purchaseReturn.PurchaseReturnLines)
                {
                    int RowIndex = Grd.Rows.Add();

                    if (pl.SerialNumber != 0)
                    {
                        Grd.Rows[RowIndex].Cells["ItemID"].ReadOnly = true;
                        Grd.Rows[RowIndex].Cells["BarCode"].ReadOnly = true;
                    }               
                  //  Grd.Rows[RowIndex].Cells["Department"].Value= pl.Category.Name;
                    Grd.Rows[RowIndex].Cells["ItemID"].Value= pl.Item.ItemID;
                    Grd.Rows[RowIndex].Cells["BarCode"].Value = pl.Item.ItemName.Color;//Geting Barcode in as Color
                    Grd.Rows[RowIndex].Cells["Item"].Value= pl.Item.ItemName;
                    Grd.Rows[RowIndex].Cells["ReturnQty"].Value= pl.Quantity;
                    //Grd.SetData(i, Grd.Cols["Quantity"].Index, pl.PurQuantity);
                    Grd.Rows[RowIndex].Cells["Stock"].Value= pl.Quantity + pl.Item.CurrentStock;
                    Grd.Rows[RowIndex].Cells["Rate"].Value= pl.PurchasePrice;
                    //Grd.SetData(i, Grd.Cols["Sale Price"].Index, sl.SalePrice);
                    Grd.Rows[RowIndex].Cells["Total"].Value= pl.Quantity * pl.PurchasePrice;
                    Grd.Rows[RowIndex].Cells["SrNo"].Value= pl.SerialNumber;
                    Grd.Rows[RowIndex].Cells["IsDeleted"].Value= pl.IsDeleted;

                    i++;
                }
                //                this.Grd.AllowAddNew = false;
                //SetRowNo();
                CalculateTotal(0);
                this.dtpDated.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmPurchaseInvoice PopulateControls.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
        int BranchID = new UserController().GetBranchID(User.UserNo);
        private void txtInvDiscPer_Leave(object sender, EventArgs e)
        {
            try
            {
                CalculateTotal(sender);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmPurchaseInvoice txtDiscP_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtInvDisc_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtTotalAmt.Text.Trim()) != 0)
                {
                    txtInvDiscPer.Text = Math.Round(((txtInvDisc.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtInvDisc.Text.Trim()) * txtTotalAmt.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtTotalAmt.Text.Trim())) / 100), 2).ToString();
                    CalculateTotal(sender);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Percentage", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {

            txtRemainingAmt.Text = (txtPaid.Text.Trim().Length ==0 ? 0 : Convert.ToDecimal(txtPaid.Text.Trim())- (txtInvDisc.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtInvDisc.Text.Trim())- txtTotalAmt.Text.Trim().Length ==0 ? 0 : Convert.ToDecimal(txtTotalAmt.Text.Trim())) ).ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult r = MessageBox.Show("Are You Sure You want to delete this Claim?", "Confirm Deletion!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    bool b = new PurchaseReturnController().DeletePurchaseReturn(purchaseReturn);
                    if (b == true)
                    {
                        ClearControls();
                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmPurchaseInvoice DeleteRecord", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
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
                    if (colIndex == Grd.Columns["ItemID"].Index)
                    {                                          
                       EdirReturn(rowIndex);                                            
                    }
                    if (colIndex == Grd.Columns["InvID"].Index)
                    {
                        int ItemID = Convert.ToInt32(Grd.CurrentRow.Cells[Grd.Columns["ItemID"].Index].Value);
                        FrmClaim frm = new FrmClaim();
                        frm.ItemId = Convert.ToInt32(Grd.CurrentRow.Cells[Grd.Columns["ItemID"].Index].Value);
                        frm.InvoiceNo = Convert.ToInt32(this.txtPartyID.Text.Trim().Length == 0 ? "0" : this.txtPartyID.Text.Trim());
                        frm.ShowDialog();

                        InvoiceLines = frm.Invoice;
                        if (InvoiceLines.Count > 0)
                        {
                            for (int i = 0; i < InvoiceLines.Count; i++)
                            {

                                if (i != 0)
                                {
                                    rowIndex = Grd.Rows.Add();
                                }

                                Grd.Rows[rowIndex].Cells["InvID"].Value = InvoiceLines[i].InvoiceNo;
                                Grd.Rows[rowIndex].Cells["ItemID"].Value = InvoiceLines[i].ItemID;
                                Grd.Rows[rowIndex].Cells["Item"].Value = InvoiceLines[i].ItemName;
                                Grd.Rows[rowIndex].Cells["Quantity"].Value = InvoiceLines[i].Quantity;
                                if (InvoiceLines[i].ReturnQuantity <= Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Stock"].Value) && invoiceType == ClaimInvoiceType.PR)
                                {
                                    Grd.Rows[rowIndex].Cells["ReturnQty"].Value = InvoiceLines[i].ReturnQuantity;
                                }
                                else
                                {
                                    MessageBox.Show("Return Quantity cannot be greater than Stock.", "Validtaion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Grd.Rows[rowIndex].Cells["ReturnQty"].Value = 0;
                                }
                                Grd.Rows[rowIndex].Cells["Rate"].Value = InvoiceLines[i].Rate;
                                decimal Total = (Convert.ToDecimal(Grd.Rows[rowIndex].Cells["ReturnQty"].Value) * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Rate"].Value));
                                (Grd.Rows[rowIndex].Cells["Total"].Value) = Total;
                            
                                CalculateTotal(0);

                            }
                        }
                    }

                }
                if (e.KeyCode == Keys.F2)
                {
                    AccountsGlobals.ShowItemCreation();
                    e.Handled = true;
                }
                if (e.KeyCode == Keys.Delete)
                {
                    if (!isNew)
                    {
                        DialogResult result = MessageBox.Show("Do really want to delete this Row?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            int currentRow = Grd.CurrentRow.Index;
                            int selectRow = 0;

                            //Grd.Rows.Remove(Grd.Rows [Grd.CurrentRow .Index ]);
                            Grd.Rows[Grd.CurrentRow.Index].Cells["IsDeleted"].Value = true;
                            Grd.Rows[Grd.CurrentRow.Index].Visible = false;

                            CalculateTotal(sender);

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



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Grd_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EdirReturn(int rowIndex)
        {
            if (Convert.ToInt32(Grd.Rows[rowIndex].Cells["SrNo"].Value) == 0)
            {
                Accounts.SchForms.SchItems sch = new Accounts.SchForms.SchItems();
                sch.partyid = txtPartyID.Text.Trim();
                sch.BranchId = Convert.ToInt32(cmbBranch.SelectedValue);
                sch.ShowDialog();
                List<Item> lstitem = new List<Item>();
                lstitem = sch.subList1;
                    
                for (int i = 0; i < lstitem.Count; i++)
                {
                    if (ChkExistingItem(lstitem[i].ItemID) == 0)
                    {
                        Grd.Rows.Add();
                        Grd.Rows[rowIndex].Cells["ItemID"].Value = lstitem[i].ItemID.ToString();
                        Grd.Rows[rowIndex].Cells["Item"].Value = lstitem[i].ItemName.ToString();
                        Grd.Rows[rowIndex].Cells["Rate"].Value = lstitem[i].PurchasePrice == 0 ? 1 : lstitem[i].PurchasePrice;
                        Grd.Rows[rowIndex].Cells["Stock"].Value = lstitem[i].CurrentStock;
                        Grd.Rows[rowIndex].Cells["Disc%"].Value = "0";
                        Grd.Rows[rowIndex].Cells["DiscAmt"].Value = "0";
                        Grd.Rows[rowIndex].Cells["IsDeleted"].Value = false;

                        CalculateTotal(0);
                    }
                    else
                    {
                        MessageBox.Show("This Item has already been added!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ResetRow();
                    }
                }               
            }
        }

        private void txtInvDisc_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtNaration_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Grd_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            SetRowNo(ref Grd);
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

        private void Grd_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            SetRowNo(ref Grd);
        }

        private void chkAdjustEntry_CheckedChanged(object sender, EventArgs e)
        {
            if (Grd.Rows.Count > 1)
            {
                if (MessageBox.Show("If you want to change Party ID data will be clear . Do you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Grd.Rows.Clear();
                    txtPartyID.Clear();
                    txtPartyDetail.Clear();

                }
            }
        }

        private void cmbCourier_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbCourier.Text.Trim().Length == 0)
            {
                lblCourierAmt.Visible = false;
                lblTrackingID.Visible = false;
                txtTrackingID.Visible = false;
                txtCourierAmount.Visible = false;
            }
            else
            {
                lblCourierAmt.Visible = true;
                lblTrackingID.Visible = true;
                txtTrackingID.Visible = true;
                txtCourierAmount.Visible = true;
            }
        }

        private void cmbInvoiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
              
                if (cmbInvoiceType.Text == ClaimInvoiceType.PR.ToString())
                {

                    lblHeading.Text = "Purchase Return";
                    invoiceType = (ClaimInvoiceType)cmbInvoiceType.SelectedValue;

                    lblInvNo.Visible = false;
                    txtInvoiceNo.Visible = false;

                  
                }
                else if (cmbInvoiceType.Text == ClaimInvoiceType.SR.ToString())
                {
                    lblHeading.Text = "Sale Return";
                    invoiceType = (ClaimInvoiceType)cmbInvoiceType.SelectedValue;
                    
                    lblInvNo.Visible = true;
                    txtInvoiceNo.Visible = true;

                }
                ClearControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmbInvoiceType_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Grd.Rows.Count > 1)
            {
                DialogResult result = MessageBox.Show("If you change Branch, Data will be Clear. Do you want to change Branch?", "Validtion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    LoadGrid();
                }
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

        private void txtInvoiceNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (cmbInvoiceType.SelectedValue.ToString() == "SR" )
                {
                    if (cmbBranch.SelectedIndex > -1)
                    {
                        Sch_Forms.SchSaleInvoice sch = new Sch_Forms.SchSaleInvoice();
                        sch.Branchid = Convert.ToInt32(cmbBranch.SelectedValue);
                        sch.ShowDialog();
                        SaleInvoice p = sch.item;
                        if (p != null)
                        {
                           
                         
                            txtInvoiceNo.Text = p.SaleID.ToString();
                            txtPartyID.Text = p.PartyID;
                            txtPartyDetail.Text = p.PartyName;
                       
                            PopulateLines(p.SaleLines);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Select Branch First", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }

            }
        }

        private void PopulateLines(List<SaleInvoiceLine> lines)
        {
            try
            {
                for (int i = 0; i < lines.Count; i++)
                {

                    int rowIndex = Grd.Rows.Add();

                    Grd.Rows[rowIndex].Cells["ItemID"].Value = lines[i].Vitem.ItemID;
                    Grd.Rows[rowIndex].Cells["Item"].Value = lines[i].ItemName;
                    Grd.Rows[rowIndex].Cells["Quantity"].Value = lines[i].Quantity;
                    Grd.Rows[rowIndex].Cells["Stock"].Value=lines[i].CStk;
                    Grd.Rows[rowIndex].Cells["Rate"].Value = lines[i].SalePrice;
                
                    decimal TotalAmt = 0;


                    TotalAmt = lines[i].SalePrice * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["ReturnQty"].Value);
                    
                    

                    Grd.Rows[rowIndex].Cells["Total"].Value = TotalAmt;
                    //Grd.Rows[rowIndex].Cells["SrNo"].Value = lines[i].SrNo;
                    //Grd.Rows[rowIndex].Cells["IsDeleted"].Value = lines[i].IsDeleted;
                   


                      CalculateTotal(0);
                  
                }

            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AddLines", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }

        }
    }
}

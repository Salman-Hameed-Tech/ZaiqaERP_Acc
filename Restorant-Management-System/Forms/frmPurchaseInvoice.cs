
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accounts;
using Accounts.Forms;
using Accounts.SchForms;
using Common;
using CategoryControlle;
using Microsoft.Reporting.WinForms;
using Restorant_Management_System.Sch_Forms;
using System.IO;
using System.Reflection;

namespace Restorant_Management_System.Forms
{
    public partial class frmPurchaseInvoice : Form
    {
        //Fields.
        private PurchaseController pc = new PurchaseController();
        private CategoryController cc = new CategoryController();
        private ItemController ic = new ItemController();
        public List<ChartOfAccounts> CourierAccounts;

        private List<Category> categories = new List<Category>();
        private List<Item> items = new List<Item>();
        private List<PurchaseLine> purchaseLines = new List<PurchaseLine>();

        private Dictionary<string, int> CategoryListDictionary = new Dictionary<string, int>();
        private Dictionary<string, int> ItemListDictionary = new Dictionary<string, int>();

        private ListDictionary[] myNameDictionary = new ListDictionary[1];

        private Category checkCategory = new Category();
        private Purchase purchase;
        private PurchaseLine purchaseLine;

        private decimal totalAmount;
        private int serialNo = 0;
        private bool NoPurchase = true;
        private bool isNew = true;
        private bool newRow = true;
        public frmPurchaseInvoice()
        {
            InitializeComponent();
        }

        private void PnlMain_Paint(object sender, PaintEventArgs e)
        {

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

                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = false;
                newCol.Visible = false;
                newCol.Width =70;
                Grd.Columns.Add(newCol);

                //Col 2
                //////////////////////////////////////////////////////////////////////////////////////////////////                
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Item ID";
                newCol.Name = "ItemID";

                newCol.CellTemplate = TextCell;

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



                //// To avoid all the annoying error messages, handle the DataError event of the DataGridView:
                //Grd.DataError += new DataGridViewDataErrorEventHandler(Grd_DataError); 
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "CS Qty";
                newCol.Name = "CSQty";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = false;
                newCol.ReadOnly = true;
                newCol.Width = 90;
                Grd.Columns.Add(newCol);
                //Col 3
                //////////////////////////////////////////////////////////////////////////////////////////////////               
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Quantity";
                newCol.Name = "Quantity";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.Width = 90;
                Grd.Columns.Add(newCol);




                ////Col 3
                ////////////////////////////////////////////////////////////////////////////////////////////////////               
                //newCol = new DataGridViewColumn();
                //newCol.HeaderText = "Multiplier";
                //newCol.Name = "Multiplier";
                //newCol.CellTemplate = DecimalCell;
                //newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //newCol.Visible = false;
                //newCol.ReadOnly = true;
                //newCol.Width = 80;
                //Grd.Columns.Add(newCol);


                //Col 4
                //////////////////////////////////////////////////////////////////////////////////////////////////                
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Pur. Price";
                newCol.Name = "Rate";
                newCol.CellTemplate = DecimalCell;//RateCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.ReadOnly = false;
                newCol.Width = 90;
                Grd.Columns.Add(newCol);



                ////Col 9
                ////////////////////////////////////////////////////////////////////////////////////////////////////
                //newCol = new DataGridViewColumn();
                //newCol.HeaderText = "Gross Total";
                //newCol.Name = "Total";
                //newCol.CellTemplate = DecimalCell;
                //newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //newCol.ReadOnly = true;
                //newCol.Width = 60;
                //Grd.Columns.Add(newCol);

                ////Col 5
                //////////////////////////////////////////////////////////////////////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderCell.Style.BackColor = Color.Yellow;
                newCol.HeaderText = "GST %";
                newCol.Name = "GST%";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = false;
                newCol.Width = 90;
                Grd.Columns.Add(newCol);

                //Col 6
                //////////////////////////////////////////////////////////////////////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderCell.Style.BackColor = Color.Yellow;
                newCol.HeaderText = "GST Amt";
                newCol.Name = "GSTAmt";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = false;
                newCol.Visible = false;
                Grd.Columns.Add(newCol);
                // newCol.Visible = Globals.PurchaseDiscountColumnVisible;
                //////////////////////////////////////////////////////////////////////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderCell.Style.BackColor = Color.Yellow;
                newCol.HeaderText = "Disc %";
                newCol.Name = "Disc%";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
               // newCol.Visible = Globals.PurchaseDiscountColumnVisible;
                newCol.Width = 90;
                newCol.Visible = false;
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
                newCol.ReadOnly = false;
                newCol.Visible = false;
                // newCol.Visible = Globals.PurchaseDiscountColumnVisible;
                newCol.Width = 90;
                Grd.Columns.Add(newCol);

                //Col 5
                //////////////////////////////////////////////////////////////////////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderCell.Style.BackColor = Color.Salmon;
                newCol.HeaderText = "S Price";
                newCol.Name = "SPrice";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = false;
                newCol.Width = 90;
                newCol.ReadOnly = true;
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
        private void frmPurchaseInvoice_Load(object sender, EventArgs e)
        {

            ClearControls();
            if (!User._IsAdmin)
            {
                CheckRights(Convert.ToInt16(this.Tag));
                dtpPurchaseDate.Enabled = AccountsGlobals.UserRights[AccountsGlobals.DateRights].CanAccess;
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
                       // btnDelete.Enabled = right[i].CanDelete;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex + "", "CheckRights", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        public void ClearControls()
        {
            try
            {
                cmbPmtType.DataSource = Enum.GetValues(typeof(PaymentType));
                cmbPmtType.SelectedIndex = 1;


                this.txtUserName.Text = User._UserName;
                this.txtID.Text = pc.GetMaximumID().ToString();
                txtRemarks.Clear();
                this.txtBillNo.Clear();
                this.txtPartyDetail.Clear();
                this.txtPartyID.Clear();

                this.txtDiscAmt.Text = "0";
                this.txtDiscPer.Text= "0";
                this.txtPaidAmount.Text= "0";
                this.txtInvoiceTotal.Text = "0";
                this.txtNetAmount.Text = "0";
                txtGSTAmt.Text = "0";
                txtGSTPer.Text = "0";
                txtCourierAmount.Text="0";
                txtTrackingID.Clear();
                LoadBranch();
                LoadCourierAcc();

                txtTotalQauntity.Clear();
              

                this.chkRePrint.Checked = false;

                this.dtpPurchaseDate.Value = AccountsGlobals.ServerDate;  

                LoadGrid();
               
             
                purchaseLines.Clear();

                this.txtBillNo.Focus();
                isNew = true;
                btnDelete.Enabled = false;
                dtpPurchaseDate.Focus();
                //txtPartyID.Focus();
                this.ActiveControl = dtpPurchaseDate;
                dtpPurchaseDate.Select();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "FrmPurchaseInvocie ClearControls.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private bool LoadBranch()
        {
            try
            {

                List<Branch> counters = new BranchController().GetBranch(" where b.IsWarehouse=1 ");
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
        private void Grd_CellEndEdit(object sender, DataGridViewCellEventArgs e)

        {
            int rowIndex = Grd.CurrentRow.Index;
            int colIndex = Grd.CurrentCell.ColumnIndex;
            if (colIndex == Grd.Columns["BarCode"].Index)
            {
                
                purchaseLines = new PurchaseController().VerifyItem(Grd.Rows[rowIndex].Cells[colIndex].Value.ToString().Trim(), "b", 0, txtPartyID.Text.Trim());
                if (purchaseLines.Count > 0)
                {
                    SetPurchaseLine();
                }
                else
                {
                    MessageBox.Show("No item with this Barcode  exists.", "Choose Valid Item...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ClearRows();
                }

            }
            else if (colIndex == Grd.Columns["ItemID"].Index)
            {
                

                purchaseLines.Clear();
                if (Grd.Rows[rowIndex].Cells["ItemID"].Value != null)
                {
                    int BranchID = Convert.ToInt32(cmbBranch.SelectedValue);
                    //Grd.SetData(Grd.Row, Grd.Cols["Bar Code"].Index, "", true);
                    purchaseLines = new PurchaseController().VerifyItem(Grd.Rows[rowIndex].Cells["ItemID"].Value.ToString(), "i", BranchID, txtPartyID.Text.Trim());
                    if (purchaseLines.Count == 0)
                    {
                        MessageBox.Show("No item with this Item ID  exists.", "Choose Valid Item...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ClearRows();
                    }
                    else
                        SetPurchaseLine();

                }
                   
              

            }
            else if (colIndex == Grd.Columns["ShortKey"].Index)
            {

                purchaseLines.Clear();

                if (Grd.Rows[rowIndex].Cells["ShortKey"].Value != null)
                {
                    //Grd.SetData(Grd.Row, Grd.Cols["Bar Code"].Index, "", true);
                    purchaseLines = new PurchaseController().VerifyItem(Grd.Rows[rowIndex].Cells["ShortKey"].Value.ToString().Trim(), "s",0, txtPartyID.Text.Trim());
                    if (purchaseLines.Count == 0)
                    {
                        MessageBox.Show("No item with this Short Key exists.", "Choose Valid Item...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                    else
                        SetPurchaseLine();
                }

            }
            else if (colIndex == Grd.Columns["Quantity"].Index)// || (Grd.Col == Grd.Cols["Purchase Price"].Index))
            {

               
                    if (Grd.Rows[rowIndex].Cells["Quantity"].Value != null && Grd.Rows[rowIndex].Cells["Rate"].Value != null)
                    {
                    if (Grd.Rows[rowIndex].Cells["Quantity"].Value.ToString().Trim().Length != 0 && Grd.Rows[rowIndex].Cells["Rate"].Value.ToString().Trim().Length != 0)
                    {
                       
                        CalculateTotal();
                        Grd.Rows[rowIndex].Cells["DiscAmt"].Value = SetLineDiscount();
                        Grd.Rows[rowIndex].Cells["GSTAmt"].Value = ((Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Quantity"].Value) * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Rate"].Value)) * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["GST%"].Value)) / 100;

                        CalculateTotal();
                    }
                }
            }
            else if (colIndex==Grd.Columns["Rate"].Index)
            {
               
                CalculateTotal();
                Grd.Rows[rowIndex].Cells["DiscAmt"].Value= SetLineDiscount();
                Grd.Rows[rowIndex].Cells["GSTAmt"].Value = ((Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Quantity"].Value) * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Rate"].Value)) * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["GST%"].Value)) / 100;

                Grd.Rows[rowIndex].Cells["Total"].Selected = true;

                CalculateTotal();

              
            }
            else if (colIndex == Grd.Columns["Disc%"].Index)
            {
                if (Grd.Rows[rowIndex].Cells["Disc%"].Value != null)
                {
                    if (Grd.Rows[rowIndex].Cells["Disc%"].Value.ToString().Trim().Length != 0)
                    {
                        Grd.Rows[rowIndex].Cells["DiscAmt"].Value= SetLineDiscount();   //Grd.GetData(Grd.Row, Grd.Cols["Disc Amt"].Index) == null ? SetLineDiscount() : Grd.GetData(Grd.Row, Grd.Cols["Disc Amt"].Index)
                        CalculateTotal();
                    }
                }
            }
            else if (colIndex == Grd.Columns["DiscAmt"].Index)
            {
                Grd.Rows[rowIndex].Cells["Disc%"].Value= (Convert.ToDecimal(Grd.Rows[rowIndex].Cells["DiscAmt"].Value) *100) / ((Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Quantity"].Value) * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Rate"].Value)) );
                CalculateTotal();
            }
            else if (colIndex == Grd.Columns["GSTAmt"].Index)
            {
                Grd.Rows[rowIndex].Cells["GST%"].Value = (Convert.ToDecimal(Grd.Rows[rowIndex].Cells["GSTAmt"].Value) * 100) / (Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Quantity"].Value) *  Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Rate"].Value));
                CalculateTotal();
            }
            else if (colIndex == Grd.Columns["GST%"].Index)
            {
                Grd.Rows[rowIndex].Cells["GSTAmt"].Value = ((Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Quantity"].Value) * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Rate"].Value) )   * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["GST%"].Value)) / 100 ;
                CalculateTotal();
            }
        }

        private void ClearRows()
        {
            int rowIndex = Grd.CurrentRow.Index;
            Grd.Rows[rowIndex].Cells["BarCode"].Value = null;
            Grd.Rows[rowIndex].Cells["ItemID"].Value = null;
            Grd.Rows[rowIndex].Cells["Item"].Value = null;
            Grd.Rows[rowIndex].Cells["CsQty"].Value = null;
            Grd.Rows[rowIndex].Cells["Quantity"].Value = null;
            Grd.Rows[rowIndex].Cells["Rate"].Value = null;
            Grd.Rows[rowIndex].Cells["Disc%"].Value = null;
            Grd.Rows[rowIndex].Cells["DiscAmt"].Value = null;
            Grd.Rows[rowIndex].Cells["SPrice"].Value = null;
            Grd.Rows[rowIndex].Cells["Total"].Value = null;
            CalculateTotal();

        }

        private decimal SetLineDiscount()
        {
            decimal discount = 0;
          //  decimal gstamt = Convert.ToDecimal(Grd.Rows[Grd.CurrentRow.Index].Cells["GSTAmt"].Value);
            decimal qty = Convert.ToDecimal(Grd.Rows[Grd.CurrentRow.Index].Cells["Quantity"].Value);
            decimal rate = Convert.ToDecimal(Grd.Rows[Grd.CurrentRow.Index].Cells["Rate"].Value);
            decimal disper = Convert.ToDecimal(Grd.Rows[Grd.CurrentRow.Index].Cells["Disc%"].Value);

            discount = (qty * rate) * disper / 100;
            return discount;
        }
        private void SetPurchaseLine()
        {

            try
            {
                int rowIndex = Grd.CurrentRow.Index;
                int colIndex = Grd.CurrentCell.ColumnIndex;
  
                foreach (PurchaseLine purchaseLine in purchaseLines)
                {
                    if (ChkExistingItem(purchaseLine.Item.ItemID) == 0)
                    {

                        Grd.Rows[rowIndex].Cells["ItemID"].Value = purchaseLine.Item.ItemID.ToString();
                        Grd.Rows[rowIndex].Cells["BarCode"].Value = purchaseLine.Item.BarCode;
                        Grd.Rows[rowIndex].Cells["Item"].Value = purchaseLine.Item.ItemName.ToString();
                        Grd.Rows[rowIndex].Cells["Rate"].Value = purchaseLine.PurchasePrice;
                        Grd.Rows[rowIndex].Cells["SPrice"].Value = purchaseLine.SalePrice;
                        Grd.Rows[rowIndex].Cells["Quantity"].Value = "1";                    
                        Grd.Rows[rowIndex].Cells["IsDeleted"].Value = false;
                        Grd.Rows[rowIndex].Cells["Item"].Selected = true;

                        CalculateTotal();
                        NoPurchase = false;
                    }
                    else
                    {
                        MessageBox.Show("This Item has already been added!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ResetRow();

                    
                    }
                   

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmPurchaseInvoice SetPurchaseLine", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch (Exception)
            {
               
                return 0;
            }
        }

        private void CalculateTotal()
        {
            totalAmount = 0;
            decimal totalitemdiscount = 0;
            decimal totalgst = 0;
            decimal totalQuantity = 0;
          
            for (int i = 0; i < Grd.Rows.Count ; i++)
            {
                if (Grd.Rows[i].Visible == true)
                {
                    decimal quantity = Convert.ToDecimal(Grd.Rows[i].Cells["Quantity"].Value);
                    decimal rate = Convert.ToDecimal(Grd.Rows[i].Cells["Rate"].Value);
                    decimal discAmt = Convert.ToDecimal(Grd.Rows[i].Cells["DiscAmt"].Value);
                    decimal gstAmt = Convert.ToDecimal(Grd.Rows[i].Cells["GSTAmt"].Value);                 

                    Grd.Rows[i].Cells["Total"].Value = (quantity * rate) + gstAmt - discAmt;
                    //totalAmount += Math.Round(Convert.ToDecimal(Grd.Rows[i].Cells["Quantity"].Value) * Convert.ToDecimal(Grd.Rows[i].Cells["Rate"].Value)) - Convert.ToDecimal(Grd.Rows[i].Cells["DiscAmt"].Value);
                    totalAmount += Math.Round(Convert.ToDecimal(Grd.Rows[i].Cells["Total"].Value),2);
                    totalQuantity+= Math.Round(Convert.ToDecimal(Grd.Rows[i].Cells["Quantity"].Value), 2);
                    totalitemdiscount += Math.Round(Convert.ToDecimal(Grd.Rows[i].Cells["DiscAmt"].Value), 2);
                    totalgst += Math.Round(Convert.ToDecimal(Grd.Rows[i].Cells["GSTAmt"].Value), 2);

                }
            }
            txtTotalQauntity.Text = totalQuantity.ToString();
            txtSumDisc.Text = totalitemdiscount.ToString();
            txtSumGST.Text = totalgst.ToString();

            txtInvoiceTotal.Text = totalAmount.ToString();
            decimal gstamt= Convert.ToDecimal(this.txtGSTAmt.Text.Trim().Length == 0 ? "0" : this.txtGSTAmt.Text);
            decimal disamt = Convert.ToDecimal(txtDiscAmt.Text.Trim().Length == 0 ? "0" : this.txtDiscAmt.Text);
            txtNetAmount.Text = (totalAmount + gstamt - disamt).ToString(); 
        }




        private Boolean ValidateControls()
        {
            int Count = 0;
            for (int i = 0; i < Grd.Rows.Count; i++)
            {
                if (Grd.Rows[i].Visible)
                {
                    if (Grd.Rows[i].Cells["ItemID"].Value != "")
                    {
                        if (Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value) != 0)
                        {
                            Count++;
                        }
                    }
                }
            }

            if (Count == 0)
            {
                MessageBox.Show("Please Enter some items", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Grd.Focus();
                return false;
            }



            //&& Convert.ToDecimal(Grd.Rows[i].Cells["Rate"].Value) > 0
            if (this.txtPartyID.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please Select or Enter Vendor.", "Enter Vendor...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtPartyID.Focus();
                return false;
            }

           
            else if (cmbCourier.Text.Trim().Length > 0)
            {
                if (this.txtTrackingID.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Please Enter Tracking ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtTrackingID.Focus();
                    return false;
                }
                else if (this.txtCourierAmount.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Please Enter Courier Amount.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtCourierAmount.Focus();
                    return false;
                }
                   
            }
           

            for (int i = 0; i < Grd.Rows.Count - 1; i++)
            {
                if (Convert.ToDecimal(Grd.Rows[i].Cells["Rate"].Value) == 0 && Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value) > 0 && Grd.Rows[i].Visible == true)
                {
                    MessageBox.Show("Please Add Rate.", "Check Rate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
            dtpPurchaseDate.Focus();
        }
      
        //int BranchID = new UserController().GetBranchID(User.UserNo);

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                Grd.Focus();
                Grd.Update();
              
                if (ValidateControls())
                {
                 
                    ChartOfAccounts coa = new ChartOfAccounts(this.txtPartyID.Text, "");
                   
                    purchase = new Purchase(Convert.ToInt32(txtID.Text), Convert.ToDateTime(dtpPurchaseDate.Value), Convert.ToDecimal(txtDiscAmt.Text.Trim().Length == 0 ? "0" : txtDiscAmt.Text.Trim()), new Vendor(coa, null, ""), purchaseLines, txtBillNo.Text == "" ? "" : (string)txtBillNo.Text, Convert.ToDecimal(txtInvoiceTotal.Text), Convert.ToDecimal(txtPaidAmount.Text), 0,"","",false,0);
                    purchase.BranchID = Globals.BranchID;//Convert.ToInt32(cmbBranch.SelectedValue) ;
                    purchase.UserNo = User.UserNo;
                    purchase.Remarks = txtRemarks.Text.Trim();

                    purchase.PaymentMode = cmbPmtType.SelectedIndex;

                    PopulatePurchaseLines();

                    if (purchase.PurchaseLines.Count > 0)
                    {
                        int VID = pc.SavePurchase(purchase, isNew);
                        if (VID > 0)
                        {
                            MessageBox.Show("Purchase Invoice Save successfully.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Print(VID);
                            ClearControls();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Something went Wrong.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }




                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmPurchaseInvoice SaveRecord", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
        }

        private void Print(int VID)
        {
            PrintDialog pd = new PrintDialog();
            string oldPrinter = pd.PrinterSettings.DefaultPageSettings.PrinterSettings.PrinterName;
            Common.Data_Sets.DSPurchaseInvoice ds = new Common.Data_Sets.DSPurchaseInvoice();

            if (new PurchaseController().GetReportData(ref ds, Convert.ToInt32(txtID.Text.Trim())))
            {
              
              Report_Forms.frmViewer Viewer = new Report_Forms.frmViewer();
                Viewer.reportViewer1.Reset();

                if (ds.Tables["SPPurchaseInvoice"].Rows.Count > 0)
                {
                    ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables["SPPurchaseInvoice"]);
                    Viewer.reportViewer1.LocalReport.DataSources.Add(rds);
                    Viewer.reportViewer1.LocalReport.ReportEmbeddedResource = "Restorant_Management_System.Report.RptPurchaseInvoice.rdlc";

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

        private bool AddInvoice()
        {
            try
            {
                //invoice = new PurchaseInvoice();
                //invoice.ID = Convert.ToInt32(txtID.Text.Trim());
               
              
                //AddInvoiceLines();
                //invoice.InvoiceLines = invoiceLines;


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void PopulatePurchaseLines()
        {
            try
            {
                purchase.PurchaseLines.Clear();

                for (int i = 0; i < Grd.Rows.Count-1; i++)
                {
                    if (Grd.Rows[i].Cells["ItemID"].Value != null && Grd.Rows[i].Cells["ItemID"].Value != "")
                    {
                        purchaseLine = new PurchaseLine();
                        purchaseLine.Category = new Category(0, "");
                        // purchaseLine.Item = new ItemController().GetItemDetail(Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value));
                        //purchaseLine.Item = new Item();
                        purchaseLine.Item.ItemID= Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value);
                        purchaseLine.Quantity = (decimal)Grd.Rows[i].Cells["Quantity"].Value;
                        purchaseLine.PurchasePrice = (decimal)Grd.Rows[i].Cells["Rate"].Value;
                        purchaseLine.SalePrice = (decimal)Grd.Rows[i].Cells["SPrice"].Value;

                        purchaseLine.TotalAmount = Convert.ToDecimal(Grd.Rows[i].Cells["Quantity"].Value) * Convert.ToDecimal(Grd.Rows[i].Cells["Rate"].Value);
                        //purchaseLine.SerialNumber = (int)Grd.GetData(i, Grd.Cols["Serial No"].Index);
                        purchaseLine.IsDeleted = Convert.ToBoolean(Grd.Rows[i].Cells["IsDeleted"].Value);
                        purchaseLine.Itemname = Convert.ToString(Grd.Rows[i].Cells["Item"].Value);
                        purchaseLine.SerialNumber = Convert.ToInt32(Grd.Rows[i].Cells["SrNo"].Value);
                       
                           
                        
                        purchase.PurchaseLines.Add(purchaseLine);
                      
                       
                    }

                  

                }



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "FrmPurchaseInvoice PopulatePurchaseList.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                SchPurchase frm = new SchPurchase();
                frm.ShowDialog();
                if (frm.SelectedPurchase != null)
                {
                    ClearControls();
                    NoPurchase = false;
                    isNew = false;
                    purchase = frm.SelectedPurchase;
                    purchaseLines = purchase.PurchaseLines;
                    cmbBranch.SelectedValue = purchase.BranchID;
                    txtUserName.Text = purchase.UserName;
                    txtRemarks.Text = purchase.Remarks;
                    cmbPmtType.SelectedIndex = purchase.PaymentMode;
                    PopulateControls();
                    
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmPurchaseInvoice EditRecord", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
        }
        public void PopulateControls()
        {
            try
            {
                this.txtID.Text = purchase.InvoiceNo.ToString();
                this.txtBillNo.Text = purchase.BillNumber;
                this.dtpPurchaseDate.Value = purchase.PurchaseDate;
                this.txtPartyID.Text = purchase.Vendor.Id.AccountNo;
                VerifyAcc(ref txtPartyID, ref txtPartyDetail);
                txtGSTPer.Text = purchase.GSTPer.ToString();
                txtGSTAmt.Text = purchase.GSTAmt.ToString();
                this.txtInvoiceTotal.Text = purchase.TotalAmount.ToString();
                //this.txtDiscAmt.Text = purchase.Discount.ToString();
                //this.txtDiscPer.Text =( purchase.Discount * 100 / purchase.TotalAmount).ToString();
                this.txtPaidAmount.Text = purchase.AmountPaid.ToString();
                this.chkRePrint.Checked = purchase.AddToPrint;
                int i = 1;
                foreach (PurchaseLine pl in purchase.PurchaseLines)
                {
                    int RowIndex= Grd.Rows.Add();
                    if (pl.SerialNumber != 0)
                    {
                        Grd.Rows[RowIndex].Cells["ItemID"].ReadOnly = true;
                        Grd.Rows[RowIndex].Cells["Barcode"].ReadOnly = true;
                    }
                    Grd.Rows[RowIndex].Cells["ShortKey"].Value= pl.ShortKey;
                    Grd.Rows[RowIndex].Cells["ItemID"].Value= pl.Item.ItemID;
                    Grd.Rows[RowIndex].Cells["Item"].Value= pl.Item.ItemName;
                    Grd.Rows[RowIndex].Cells["Quantity"].Value= pl.Quantity;
                    Grd.Rows[RowIndex].Cells["Barcode"].Value = pl.Item.BarCode;
                    Grd.Rows[RowIndex].Cells["Rate"].Value= pl.PurchasePrice;
                    Grd.Rows[RowIndex].Cells["SPrice"].Value= pl.SalePrice;
                    Grd.Rows[RowIndex].Cells["GST%"].Value = pl.GstPer;
                    Grd.Rows[RowIndex].Cells["GSTAmt"].Value = pl.GstAmt;
                    //Grd.Rows[RowIndex].Cells["DiscAmt"].Value= pl.Disc;
                    //Grd.Rows[RowIndex].Cells["Disc%"].Value= (Convert.ToDecimal(pl.Disc) * 100 / pl.PurchasePrice) / pl.Quantity;
                    Grd.Rows[RowIndex].Cells["Total"].Value= pl.TotalAmount - Convert.ToDecimal(pl.Disc);
                    Grd.Rows[RowIndex].Cells["SrNo"].Value= pl.SerialNumber;
                    Grd.Rows[RowIndex].Cells["IsDeleted"].Value= pl.IsDeleted;
                    i++;
                }
                CalculateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmPurchaseInvoice PopulateControls.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void VerifyAcc(ref System.Windows.Forms.TextBox txtno, ref System.Windows.Forms.TextBox txtname)
        {
            ChartOfAccounts Ca;
            Ca = new ChartofAccountsController().GetAccountDetail(txtno.Text, " and isdetailed=1 and accountno like '6%'");
            if (Ca == null)
            {
                txtno.Clear();
                ShowSearch(ref txtno, ref txtname);
            }

            else
            {
                txtno.Text = Ca.AccountNo;
                txtname.Text = Ca.AccountName;
            }
        }

        private void txtPartyID_Validating(object sender, CancelEventArgs e)
        {
            if (txtPartyID.Text.ToString().Trim().Length == 0) return;
            VerifyAcc(ref txtPartyID, ref txtPartyDetail);
        }

        private void txtPartyID_TextChanged(object sender, EventArgs e)
        {
            if (txtPartyID.Text.ToString().Trim().Length == 0)
            {
                txtPartyDetail.Clear();
            }
        }

        private void txtDiscPer_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this.txtDiscPer.Text.Trim().Length > 0)
                {
                    decimal invtotal = Convert.ToDecimal((this.txtInvoiceTotal.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(this.txtInvoiceTotal.Text)));
                    decimal dicper = Convert.ToDecimal((this.txtDiscPer.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(this.txtDiscPer.Text.Trim())));
                   // decimal gstamt = Convert.ToDecimal((this.txtGSTAmt.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(this.txtGSTAmt.Text.Trim())));

                    this.txtDiscAmt.Text= (dicper * (invtotal) / 100).ToString();
                }
                else
                {
                    this.txtDiscPer.Text= null;
                    this.txtDiscAmt.Text = null;
                }
                CalculateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmPurchaseInvoice txtDiscP_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDiscAmt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(this.txtInvoiceTotal.Text.Trim().Length == 0 ? "0" : this.txtInvoiceTotal.Text.Trim()) >= Convert.ToDecimal(this.txtDiscAmt.Text.Trim().Length == 0 ? "0" : this.txtDiscAmt.Text.Trim()))
                {
                    this.txtNetAmount.Text = Math.Round(Convert.ToDecimal(this.txtInvoiceTotal.Text.Trim().Length == 0 ? "0" : this.txtInvoiceTotal.Text.Trim()) - Convert.ToDecimal(this.txtDiscAmt.Text.Trim().Length == 0 ? "0" : this.txtDiscAmt.Text.Trim()), 0).ToString();
                }
                else
                {
                    //MessageBox.Show("Discount can not be greater then Total Amount", "Check Discount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                CalculateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmPurchaseInvocie InvoiceDiscount_TextChange", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDiscAmt_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this.txtDiscAmt.Text.Trim().Length > 0)
                {
                    if (Convert.ToDecimal(txtDiscAmt.Text.Trim().Length ==  0 ? 0 :Convert.ToDecimal( txtDiscAmt.Text) )> Convert.ToDecimal(txtInvoiceTotal.Text.Trim().Length == 0 ? 0 :Convert.ToDecimal( txtInvoiceTotal.Text)))
                    {
                        MessageBox.Show("Discount can not be greater then Total Amount.", "Check Discount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtDiscAmt.Focus();
                    }
                    if (this.txtDiscAmt.Text.Trim().Length == 0)
                    {
                        this.txtDiscAmt.Text = null;
                    }
                    if (Convert.ToDecimal(this.txtDiscAmt.Text.Trim().Length == 0 ? "0" : this.txtDiscAmt.Text.Trim()) > 0)
                    {
                        decimal disamt = Convert.ToDecimal(this.txtDiscAmt.Text.Trim().Length == 0 ? "0" : this.txtDiscAmt.Text);
                       // decimal gstamt = Convert.ToDecimal(this.txtGSTAmt.Text.Trim().Length == 0 ? "0" : this.txtGSTAmt.Text);
                        decimal invtotal = Convert.ToDecimal(this.txtInvoiceTotal.Text);

                        if (Convert.ToDecimal(this.txtInvoiceTotal.Text.Trim().Length == 0 ? 0 :Convert.ToDecimal( this.txtInvoiceTotal.Text)) > 0)
                        {
                            //this.txtDiscPercent.Text = Convert.ToString(Convert.ToDecimal(this.txtInvoiceDiscount.Text.Trim().Length == 0 ? "0" : this.txtInvoiceDiscount.Text) * 100 / Convert.ToDecimal(this.txtInvoiceTotal.Text));
                            this.txtDiscPer.Text = Math.Round(disamt * 100 / (invtotal),2).ToString();
                        }
                    }
                    else
                    {
                        this.txtDiscAmt.Text = null;
                        this.txtDiscPer.Text = null;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmPurchaseInvocie invoiceDiscount_Leave.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = Grd.CurrentRow.Index;
                DialogResult r = MessageBox.Show("Are You Sure You want to delete this Purchase?", "Confirm Deletion!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    
                    //int cid = 0;
                    //cid = new PurchaseController().VerifyItem((Grd.Rows[rowIndex].Cells["ItemID"].Value).ToString());
                    //if (cid > 0)
                    //{
                    //    MessageBox.Show("Purchase Register Invoice cannot be Deleted, Delete from DeliveryChallan First", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return;
                    //}
                    //else
                    {
                       
                        pc.DeletePurchase(purchase);
                        ClearControls();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmPurchaseInvoice DeleteRecord", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
        }
        private bool SetItemRow(Item i)
        {
            try
            {
                if (i != null)
                {
                    decimal Qty = 0;
                    int rowIndex = Grd.CurrentRow.Index;
                    int colIndex = Grd.CurrentCell.ColumnIndex;

                  
                    Grd.Rows[rowIndex].Cells["ItemID"].Value = i.ItemID;

                    Grd.Rows[rowIndex].Cells["Item"].Value = i.ItemName.ToString();

                    Grd.Rows[rowIndex].Cells["Unit"].Value = Qty;

                    Grd.Rows[rowIndex].Cells["Quantity"].Value = "";

                   

                    //Grd.Rows[rowIndex].Cells["Multiplier"].Value = i.Multiplier;


                    Grd.Rows[rowIndex].Cells["IsDeleted"].Value = 0;

                    decimal total = (Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Quantity"].Value) * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Unit"].Value));
                    Grd.Rows[rowIndex].Cells["NetTotal"].Value = total;

                    //Grd.Rows[rowIndex].Cells["Unit"].Value = i.Unit;
                    Grd.Rows[rowIndex].Cells["Quantity"].Selected = true;

                    return true;
                }
                else
                {
                  
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetItemRow", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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
                    EditPurchase(rowIndex);

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
                            SetRowNo(ref Grd);
                        }
                    }
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Grd_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditPurchase(int rowIndex)
        {
            if (Convert.ToInt32(Grd.Rows[rowIndex].Cells["SrNo"].Value) == 0)
            {
                Accounts.SchForms.SchItems sch = new Accounts.SchForms.SchItems();
              
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
                            Grd.Rows[rowIndex].Cells["BarCode"].Value = lstitem[i].BarCode;
                            Grd.Rows[rowIndex].Cells["Item"].Value = lstitem[i].ItemName.ToString();
                            Grd.Rows[rowIndex].Cells["Rate"].Value = lstitem[i].PurchasePrice;
                            Grd.Rows[rowIndex].Cells["SPrice"].Value = lstitem[i].SalePrice;
                            Grd.Rows[rowIndex].Cells["Quantity"].Value = "1";
                            Grd.Rows[rowIndex].Cells["IsDeleted"].Value = false;
                            Grd.Rows[rowIndex].Cells["CSQty"].Value = lstitem[i].CurrentStock;
                            Grd.Rows[rowIndex].Cells["Quantity"].Selected =true;
                            CalculateTotal();
                            NoPurchase = false;
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

        private void checkitem()
        {
           
        }

        private void dtpPurchaseDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.txtBillNo.Focus();
            }
        }

        private void txtBillNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.txtPartyID.Focus();
            }
        }

        private void txtPartyID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.Grd.Focus();
            }
            if (e.KeyCode == Keys.F1)
            {
                ShowSearch(ref txtPartyID, ref txtPartyDetail);
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
        private void Grd_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            SetRowNo(ref Grd);
        }

        private void Grd_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            SetRowNo(ref Grd);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtGSTPer_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this.txtGSTPer.Text.Trim().Length > 0)
                {
                    this.txtGSTAmt.Text = (Convert.ToDecimal((this.txtGSTPer.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(this.txtGSTPer.Text.Trim()))) * Convert.ToDecimal((this.txtInvoiceTotal.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(this.txtInvoiceTotal.Text)) / 100)).ToString();
                }
                else
                {
                    this.txtDiscPer.Text = null;
                    this.txtDiscAmt.Text = null;
                }
                CalculateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmPurchaseInvoice txtDiscP_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtGSTAmt_Leave(object sender, EventArgs e)
        {
          //  if (Convert.ToDecimal(this.txtGSTAmt.Text.Trim().Length == 0 ? "0" : this.txtGSTAmt.Text.Trim()) > 0)
            {
                if (Convert.ToDecimal(this.txtInvoiceTotal.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(this.txtInvoiceTotal.Text)) > 0)
                {
                  
                    //this.txtDiscPercent.Text = Convert.ToString(Convert.ToDecimal(this.txtInvoiceDiscount.Text.Trim().Length == 0 ? "0" : this.txtInvoiceDiscount.Text) * 100 / Convert.ToDecimal(this.txtInvoiceTotal.Text));
                    this.txtGSTPer.Text = Math.Round(Convert.ToDecimal(this.txtGSTAmt.Text.Trim().Length == 0 ? "0" : this.txtGSTAmt.Text) * 100 / Convert.ToDecimal(this.txtInvoiceTotal.Text),2).ToString();
                }
            }
            CalculateTotal();
        }

        private void chkAdjustEntry_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void label13_Leave(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void cmbCourier_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void lblItemDiscount_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtGSTAmt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void Grd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

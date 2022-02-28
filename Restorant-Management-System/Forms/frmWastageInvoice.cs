using Accounts;
using Accounts.Forms;
using Common;
using CategoryControlle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accounts.SchForms;

namespace Restorant_Management_System.Forms
{
    public partial class frmWastageInvoice : Form
    {
        private Wastage wastage;
        private WastageReturn wastageReturn;
        private WastageController pc = new WastageController();
        private WastageLine wastageLine;
        private List<WastageLine> wastageLines = new List<WastageLine>();
        private List<WastageReturnLine> wastageReturnLines = new List<WastageReturnLine>();

        private PurchaseReturn purchaseReturn;
        private PurchaseReturnLine purchaseReturnLine;
        private List<PurchaseReturnLine> purchaseReturnLines = new List<PurchaseReturnLine>();
        private List<PurchaseLine> purchaseLines = new List<PurchaseLine>();

        private SaleReturn saleReturn;
        private SaleReturnLine saleReturnLine;
        private List<SaleReturnLine> saleReturnLines = new List<SaleReturnLine>();


        private WastageController wc = new WastageController();
        private WastageReturnController wrc = new WastageReturnController();

      
        private PurchaseReturnController prc = new PurchaseReturnController();

        private SaleInvoice sale;
        private Purchase purchase;
        private PurchaseLine purchaseLine;

        string invPrinter;

        private int serialNo = 0;

        private int oi = 0;

        private bool NoReturn = true;
        private bool isNew = true;
        public frmWastageInvoice()
        {
            InitializeComponent();
        }

        private void frmWastageInvoice_Load(object sender, EventArgs e)
        {
            ClearControls();
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
                
                //Col 2
                //////////////////////////////////////////////////////////////////////////////////////////////////   

                newCol.CellTemplate = TextCell;
                newCol.HeaderText = "Bar Code";
                newCol.Name = "BarCode";
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.Width = 60;
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
                newCol.Width = 80;
                newCol.Visible = false;
                Grd.Columns.Add(newCol);

                //Col 2
                //////////////////////////////////////////////////////////////////////////////////////////////////                
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Item ID";
                newCol.Name = "ItemID";

                newCol.CellTemplate = IntCell;

                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = false;
                // newCol.Visible = Globals.PackingColumnVisible;
                newCol.Width = 80;
                Grd.Columns.Add(newCol);


                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Product";
                newCol.Name = "Item";

                newCol.CellTemplate = TextCell;

                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;
                //  newCol.Visible = Globals.PackingColumnVisible;
                newCol.Width = 250;
                Grd.Columns.Add(newCol);

                //Col 4
                //////////////////////////////////////////////////////////////////////////////////////////////////                
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Wastage Qty";
                newCol.Name = "WastageQty";
                newCol.CellTemplate = DecimalCell;//RateCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.Width = 60;
                Grd.Columns.Add(newCol);


                //// To avoid all the annoying error messages, handle the DataError event of the DataGridView:
                //Grd.DataError += new DataGridViewDataErrorEventHandler(Grd_DataError); 

                //Col 3
                //////////////////////////////////////////////////////////////////////////////////////////////////               
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Stock";
                newCol.Name = "Stock";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.Width = 70;
                Grd.Columns.Add(newCol);

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
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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


                AccountsGlobals.ExtendCol(ref Grd, "Item");





                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void ClearControls()
        {
            try
            {

                this.oi = 0;
                this.cmbClaimType.Enabled = true;
                PopulateClaimType();

                LoadGrid();
                this.txtPartyDetail.Clear();
                this.txtPartyID.Clear();
                this.dtClaim.Value = System.DateTime.Now;

                this.txtInvDisc.Text = "0";
                this.txtInvDiscPer.Text = "0";

                
                this.txtTotalAmount.Text = "0";
                
                this.txtPaid.Text = "0";

                this.dtClaim.Value = System.DateTime.Now.Date;

                this.dtClaim.Focus();

                this.txtID.Text = new WastageController().GetMaximumID().ToString();
                this.isNew = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmSaleInvoice ClearControls", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateClaimType()
        {
            try
            {
                this.cmbClaimType.Items.Clear();
                this.cmbClaimType.Items.Add(ClaimType.WastageDamage);
                this.cmbClaimType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmClaimInvoice PopulateClaimType", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (colIndex == Grd.Columns["BarCode"].Index)
                    {

                        purchaseLines.Clear();

                        purchaseLines = new PurchaseController().VerifyItem(Grd.Rows[rowIndex].Cells["BarCode"].Value.ToString().Trim(), "b",0,"");
                        if (purchaseLines.Count == 0)
                        {
                            MessageBox.Show("No item with this Bar code exists.", "Choose Valid Item...", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else
                        {
                            Grd.Rows[rowIndex].Cells["ItemID"].Value = purchaseLines[0].Item.ItemID;
                            Grd.Rows[rowIndex].Cells["Item"].Value = purchaseLines[0].Item.ItemName;
                            Grd.Rows[rowIndex].Cells["Stock"].Value = purchaseLines[0].Item.CurrentStock;
                            Grd.Rows[rowIndex].Cells["WastageQty"].Value = 0;
                            //Grd.SetData(Grd.Row, Grd.Cols["Pur. Price"].Index, purchaseLines[0].PurchasePrice);
                            Grd.Rows[rowIndex].Cells["Rate"].Value = purchaseLines[0].SalePrice;
                            Grd.Rows[rowIndex].Cells["Total"].Value = Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Rate"].Value) * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["WastageQty"].Value);
                        }


                    }
                    else if (colIndex == Grd.Columns["ItemID"].Index)
                    {
                        purchaseLines.Clear();

                        purchaseLines = new PurchaseController().VerifyItem(Grd.Rows[rowIndex].Cells["ItemID"].Value.ToString().Trim(), "i",0,"");
                        if (purchaseLines.Count == 0)
                        {
                            MessageBox.Show("No item with this Item ID exists.", "Choose Valid Item...", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else
                        {
                            Grd.Rows[rowIndex].Cells["ItemID"].Value = purchaseLines[0].Item.ItemID;
                            Grd.Rows[rowIndex].Cells["Item"].Value = purchaseLines[0].Item.ItemName;
                            Grd.Rows[rowIndex].Cells["Stock"].Value = purchaseLines[0].Item.CurrentStock;
                            Grd.Rows[rowIndex].Cells["WastageQty"].Value = 0;
                            //Grd.SetData(Grd.Row, Grd.Cols["Pur. Price"].Index, purchaseLines[0].PurchasePrice);
                            Grd.Rows[rowIndex].Cells["Rate"].Value = purchaseLines[0].SalePrice;
                            Grd.Rows[rowIndex].Cells["Total"].Value = Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Rate"].Value) * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["WastageQty"].Value);
                        }


                    }
                    else if (colIndex == Grd.Columns["WastageQty"].Index)
                    {


                        if ((Convert.ToDecimal(Grd.Rows[rowIndex].Cells["WastageQty"].Value) > Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Stock"].Value)) && (Grd.Columns["Stock"].Visible == true))
                        {
                            MessageBox.Show("Quantity can not be greater then Current Stock.", "Check Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else if (Grd.Rows[rowIndex].Cells["WastageQty"].Value != null)
                        {
                            if (Grd.Rows[rowIndex].Cells["Rate"].Value.ToString().Trim().Length != 0)
                            {
                                Grd.Rows[rowIndex].Cells["Total"].Value = Convert.ToDecimal(Grd.Rows[rowIndex].Cells["WastageQty"].Value) * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Rate"].Value);

                                // Grd.SetData(Grd.Row, Grd.Cols["Deleted"].Index, false);
                                CalculateTotal();
                            }
                        }

                    }
                    else if (colIndex == Grd.Columns["Rate"].Index)
                    {


                        Grd.Rows[rowIndex].Cells["Total"].Value = Convert.ToDecimal(Grd.Rows[rowIndex].Cells["WastageQty"].Value) * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Rate"].Value);
                        CalculateTotal();



                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmClaimInvoice Grd_BeforeRowColChange", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CalculateTotal()

        {
            decimal totalAmount = 0;
            for (int i = 0; i < Grd.Rows.Count - 1; i++)
            {

                totalAmount += Math.Round((Convert.ToDecimal(Grd.Rows[i].Cells["Rate"].Value)) * (Convert.ToDecimal(Grd.Rows[i].Cells["WastageQty"].Value)));
            }

            this.txtTotalAmount.Text = totalAmount.ToString();

            txtPaid.Text = (totalAmount - Convert.ToDecimal(txtInvDisc.Text.Trim())).ToString();
        }
        private Boolean ValidateControls()
        {
            if (this.txtPartyID.Text.Trim().Length == 0 && (this.cmbClaimType.Text == ClaimType.PurchaseReturn.ToString()))// (this.txtCustomerID.Text.Trim().Length == 0 && (this.cbxClaimType.Text == ClaimType.SaleDamage.ToString()))
            {
                MessageBox.Show("Please Select or Enter Party.", "Party", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtPartyID.Focus();
                return false;
            }
            //else if (this.txtPaid.Text.Trim().Length == 0)// (this.txtCustomerID.Text.Trim().Length == 0 && (this.cbxClaimType.Text == ClaimType.SaleDamage.ToString()))
            //{
            //    MessageBox.Show("Please Enter Payable amount.", "Payable", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.txtPaid.Focus();
            //    return false;
            //}
            else if (this.txtPaid.Text.Trim().Length == 0)// (this.txtCustomerID.Text.Trim().Length == 0 && (this.cbxClaimType.Text == ClaimType.SaleDamage.ToString()))
            {
                MessageBox.Show("Please Enter Paid amount.", "Paid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtPaid.Focus();
                return false;
            }

            //else if (NoReturn == true)
            //{
            //    MessageBox.Show("Please Enter some item to Save.", "Enter Details...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.Grd.Focus();
            //    return false;
            //}
            else if (PopulateWastages())
            {
                return true;
            }
            else { return false; }

            return true;
        }
        public bool PopulateWastages()
        {
            wastage = new Wastage();
            wastage.InvoiceNo = Convert.ToInt32(txtID.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(txtID.Text));
            wastage.Narration = txtNaration.Text;
            //wastage.Vendorname = txtCustomerID.Text;

            wastage.Discount = Convert.ToDecimal(txtInvDisc.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtInvDisc.Text));
            wastage.AmountPaid = Convert.ToDecimal(txtPaid.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtPaid.Text));
            wastage.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtTotalAmount.Text));
            wastage.WastageDate = Convert.ToDateTime(dtClaim.Value);


            //wastage.AddToPrint = false;
            //wastage.BillNumber = txtClaimID.Text;

            return true;
        }
        public void PopulateWastageLines()
        {
            try
            {
                if (wastageLines == null) wastageLines = new List<WastageLine>();
                wastageLines.Clear();

                for (int i =0; i < Grd.Rows.Count; i++)
                {
                    if (Grd.Rows[i].Cells["WastageQty"].Value != null)
                    {

                        if (Grd.Rows[i].Cells["WastageQty"].Value.ToString().Trim().Length != 0 &&
                            Convert.ToInt32(Grd.Rows[i].Cells["WastageQty"].Value) > 0)
                        {
                            //int l = Convert.ToInt32(Grd.GetData(i, Grd.Cols["Was Qty"].Index));
                            //if (Grd.GetData(i, Grd.Cols["Was Qty"].Index).ToString().Trim())
                            wastageLine = new WastageLine();
                            //purchaseReturnLine.Category = new Category(0, (string)Grd.GetData(i, Grd.Cols["Department"].Index));
                            wastageLine.Item = new Item(Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value));
                            wastageLine.Quantity = (decimal)Grd.Rows[i].Cells["WastageQty"].Value; //3233
                            wastageLine.PurchasePrice = (decimal)Grd.Rows[i].Cells["Rate"].Value;
                            //wastageLine.SalePrice = (decimal)Grd.GetData(i, Grd.Cols["Sale Price"].Index);
                            //purchaseReturnLine.TotalAmount = (decimal)Grd.GetData(i, Grd.Cols["Total"].Index);
                            wastageLine.SerialNumber = Convert.ToInt32(Grd.Rows[i].Cells["SrNo"].Value);
                            wastageLine.BranchID = BranchID;
                            wastage.BranchID = BranchID;
                            CalculateTotal();
                            //wastageLine.IsDeleted = (bool)Grd.GetData(i, Grd.Cols["Deleted"].Value;
                            //wastageLines.Add(wastageLine);
                            // wastage.WastageLines = wastageLines;

                            wastage.WastageLines.Add(wastageLine);
                            NoReturn = false;
                        }
                        //else
                        //    MessageBox.Show("Quantity of One or more items is less than 1");
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "FrmPurchaseInvoice PopulatePurchaseList.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void PopulateWastageReturns()
        {
            try
            {
                this.txtID.Text = wastageReturn.RetInvoiceNo.ToString();
                if (wastageReturn.Narration != null)
                {
                    txtNaration.Text = wastageReturn.Narration;
                }
                this.txtNaration.Text = wastageReturn.Narration.ToString();

                this.dtClaim.Value = wastageReturn.PurchaseReturnDate.Date;


                this.cmbClaimType.Enabled = false;
                LoadGrid();

                //this.txtPayable.Text = wastageReturn.TotalAmount.ToString();
                CalculateTotal();



                this.txtInvDisc.Text = wastageReturn.Discount.ToString();
                this.txtPaid.Text = wastageReturn.AmountPaid.ToString();

                int i = 1;
                foreach (WastageReturnLine sl in wastageReturn.WastageReturnLines)
                {

                    int RowIndex = Grd.Rows.Add();

                    Grd.Rows[RowIndex].Cells["ItemID"].Value = sl.Item.ItemID;
                    Grd.Rows[RowIndex].Cells["Item"].Value = sl.Item.ItemName;
                    Grd.Rows[RowIndex].Cells["WastageQty"].Value = sl.Quantity;
                    //Grd.SetData(i, Grd.Cols["Was Qty"].Index, -5);
                    //Grd.Rows[RowIndex].Cells["Quantity"].Value= sl.PurQuantity;

                    Grd.Rows[RowIndex].Cells["Stock"].Value = sl.Item.CurrentStock + sl.Quantity;
                    Grd.Rows[RowIndex].Cells["Rate"].Value = sl.PurchasePrice;
                    //Grd.Rows[RowIndex].Cells["Sale Price"].Index, sl.PurchasePrice);
                    Grd.Rows[RowIndex].Cells["Total"].Value = sl.Quantity * sl.PurchasePrice;
                    Grd.Rows[RowIndex].Cells["SrNo"].Value = sl.SerialNumber;
                    Grd.Rows[RowIndex].Cells["IsDeleted"].Value = sl.IsDeleted;
                    i++;

                    //I added
                    CalculateTotal();
                }

                this.dtClaim.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmPurchaseInvoice PopulateControls.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        if (Grd.Rows[i].Cells["WastageQty"].Value != null)
                        {
                            if (Grd.Rows[i].Cells["WastageQty"].Value.ToString().Trim().Length != 0 && Grd.Rows[i].Cells["WastageQty"].Value.ToString().Trim() != "0")
                            {
                                purchaseReturnLine = new PurchaseReturnLine();
                                //purchaseReturnLine.Category = new Category(0, (string)Grd.GetData(i, Grd.Cols["Department"].Index));
                                purchaseReturnLine.Item = new Item(Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value), new ItemName(Grd.Rows[i].Cells["Item"].Value.ToString(), "", "", ""));
                                purchaseReturnLine.Quantity = (decimal)Grd.Rows[i].Cells["WastageQty"].Value;
                                purchaseReturnLine.PurchasePrice = (decimal)Grd.Rows[i].Cells["Rate"].Value;
                                purchaseReturnLine.TotalAmount = (decimal)Grd.Rows[i].Cells["Total"].Value;
                                purchaseReturnLine.SerialNumber = Convert.ToInt32(Grd.Rows[i].Cells["SrNo"].Value == null ? "0" : Grd.Rows[i].Cells["SrNo"].Value.ToString());
                                purchaseReturnLine.IsDeleted = Convert.ToBoolean(Grd.Rows[i].Cells["IsDeleted"].Value);

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
        public void PopulateSaleeReturns()
        {
            try
            {
                this.txtID.Text = wastageReturn.RetInvoiceNo.ToString();
                this.dtClaim.Value = wastageReturn.PurchaseReturnDate.Date;

                if (wastageReturn.Narration != null)
                {
                    txtNaration.Text = wastageReturn.Narration.ToString();
                }

                this.txtPartyID.Text = wastageReturn.Vendor.Id.AccountNo;
                this.txtPartyID.Focus();

                this.cmbClaimType.Text = ClaimType.PurchaseReturn.ToString();
                this.cmbClaimType.Enabled = false;

                LoadGrid();

                //this.txtNarration.Text = saleReturn.Narration;

                this.txtTotalAmount.Text = purchaseReturn.TotalAmount.ToString();
                this.txtPaid.Text = purchaseReturn.AmountPaid.ToString();

                this.txtInvDisc.Text= purchaseReturn.Discount.ToString();
                this.txtInvDiscPer.Text= (purchaseReturn.Discount * 100 / purchaseReturn.TotalAmount).ToString();

                this.txtRemainingAmt.Text = Convert.ToString(Convert.ToDecimal(this.txtTotalAmount.Text) - Convert.ToDecimal(this.txtInvDisc.Text.Trim().Length == 0 ? "0" : this.txtInvDisc.Text.Trim()));

                int i = 1;
                foreach (PurchaseReturnLine pl in purchaseReturn.PurchaseReturnLines)
                {
                    
                    int RowIndex=Grd.Rows.Add();
                    
                    Grd.Rows[RowIndex].Cells["ItemID"].Value= pl.Item.ItemID;
                    Grd.Rows[RowIndex].Cells["Item"].Value= pl.Item.ItemName;
                    Grd.Rows[RowIndex].Cells["WastageQty"].Value= pl.Quantity;
                    //Grd.SetData(i, Grd.Cols["Quantity"].Value= pl.PurQuantity;
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

                this.dtClaim.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmPurchaseInvoice PopulateControls.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtInvDiscPer_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this.txtInvDiscPer.Text.Trim().Length > 0)
                {
                    this.txtInvDisc.Text=(( Convert.ToDecimal(this.txtInvDiscPer.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtInvDiscPer.Text.Trim()) * Convert.ToDecimal(this.txtTotalAmount.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtTotalAmount.Text.Trim())) / 100))).ToString();

                    this.txtRemainingAmt.Text = Convert.ToString(Convert.ToDecimal(this.txtTotalAmount.Text) - Convert.ToDecimal(this.txtInvDisc.Text));
                }
                else
                {
                    this.txtInvDiscPer.Text= null;
                    this.txtInvDisc.Text= null;
                    this.txtRemainingAmt.Clear();
                }
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
                if (this.txtInvDisc.Text.Trim().Length > 0)
                {
                    if (Convert.ToDecimal(txtInvDisc.Text.Trim().Length == 0 ? 0 :Convert.ToDecimal(txtInvDisc.Text.Trim())) > Convert.ToDecimal(this.txtTotalAmount.Text.Trim().Length == 0 ? 0 :Convert.ToDecimal(txtTotalAmount.Text.Trim())))
                    {
                        MessageBox.Show("Discount can not be greater then Total Amount.", "Check Discount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtInvDisc.Focus();
                    }
                    if (this.txtInvDisc.Text.Trim().Length == 0)
                    {
                        this.txtInvDisc.Text= null;
                    }
                    if (Convert.ToDecimal(this.txtInvDisc.Text.Trim().Length == 0 ? 0 :Convert.ToDecimal(txtInvDisc.Text.Trim())) > 0)
                    {
                        if (Convert.ToDecimal(this.txtTotalAmount.Text.Trim().Length == 0 ? 0 :Convert.ToDecimal(txtTotalAmount.Text.Trim()) )> 0)
                        {
                            this.txtRemainingAmt.Text = Convert.ToString(Convert.ToDecimal(this.txtTotalAmount.Text) - Convert.ToDecimal(this.txtInvDisc.Text));
                            this.txtInvDiscPer.Text = Convert.ToDecimal(this.txtInvDisc.Text.Trim().Length == 0 ? 0 :Convert.ToDecimal( txtInvDisc.Text) * 100 / Convert.ToDecimal(this.txtTotalAmount.Text)).ToString();
                        }
                    }
                    else
                    {
                        this.txtInvDisc.Text= null;
                        this.txtInvDiscPer.Text= null;

                        this.txtRemainingAmt.Clear();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmPurchaseInvocie invoiceDiscount_Leave.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPaid_Leave(object sender, EventArgs e)
        {
            this.txtRemainingAmt.Text = Convert.ToString(Convert.ToDecimal(this.txtTotalAmount.Text) - Convert.ToDecimal(this.txtInvDisc.Text.Trim().Length == 0 ? 0 :Convert.ToDecimal( txtInvDisc.Text.Trim())));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                dtClaim.Focus();

                if (this.cmbClaimType.Text == ClaimType.WastageDamage.ToString() || this.cmbClaimType.Text == ClaimType.WastageDamage.ToString() || this.cmbClaimType.Text == ClaimType.WastageDamage.ToString())
                {
                    wastage = new Wastage();

                    if (ValidateControls())
                    {
                        PopulateWastageLines();
                        if (wastage.WastageLines.Count <= 0)
                        {
                            MessageBox.Show("No item added in the list");
                            return;
                        }

                        ChartOfAccounts coa = new ChartOfAccounts(this.txtPartyID.Text.Trim().Length == 0 ? null : this.txtPartyID.Text.Trim(), "");
                        Vendor v = new Vendor(coa, new Address(), "");


                        saleReturn = new SaleReturn(Convert.ToInt32(this.txtID.Text.Trim().Length == 0 ? 0 :Convert.ToDecimal( txtID.Text.Trim())), sale, Convert.ToDateTime(this.dtClaim.Value), saleReturnLines, Convert.ToDecimal(this.txtTotalAmount.Text), Convert.ToDecimal(this.txtPaid.Text.Trim().Length== 0 ? 0 :Convert.ToDecimal( txtPaid.Text.Trim())), v, (ClaimType)this.cmbClaimType.SelectedItem, this.txtNaration.Text);
                        saleReturn.BranchID = BranchID;
                        wc.SaveWastage(saleReturn, wastage, isNew);

                        ClearControls();
                        MessageBox.Show("Saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (this.cmbClaimType.Text == ClaimType.PurchaseReturn.ToString())
                {
                    PopulatePurchaseReturnLines();
                    if (ValidateControls())
                    {
                        ChartOfAccounts coa = new ChartOfAccounts(this.txtPartyID.Text.Trim().Length == 0 ? null :Convert.ToString(txtPartyID.Text.Trim()), "");
                        Vendor v = new Vendor(coa, new Address(), "");
                        if (txtNaration.Text.Trim() == "")
                        {
                            txtNaration.Text = "Purchase Return Invoice";
                        }
                        purchaseReturn = new PurchaseReturn(Convert.ToInt32(this.txtID.Text.Trim().Length == 0 ? 0 :Convert.ToDecimal( txtID.Text)), purchase, Convert.ToDateTime(this.dtClaim.Value), purchaseReturnLines, Convert.ToDecimal(this.txtTotalAmount.Text),  v, this.txtNaration.Text.Trim());
                        purchaseReturn.Discount = Convert.ToDecimal(txtInvDisc.Text.Trim().Length == 0 ? 0 :Convert.ToDecimal( txtInvDisc.Text.Trim()));
                        purchaseReturn.Vendor.Id.AccountName = txtPartyDetail.Text.Trim();
                        int ViD=prc.SavePurchaseReturn(purchaseReturn, isNew);
                        if (MessageBox.Show("Do You Want To Print It", "Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                           // PrintInvoice();
                        }
                        ClearControls();



                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmPurchaseInvoice SaveRecord", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult r = MessageBox.Show("Are You Sure You want to delete this Invoice?", "Confirm Deletion!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {


                    pc.DeleteWastage(Convert.ToInt32(this.txtID.Text));
                    ClearControls();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmChallan DeleteRecord", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
        int BranchID = new UserController().GetBranchID(User.UserNo);
        private void btnSchVendor_Click(object sender, EventArgs e)
        {

        }

        private void Grd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                int rowIndex = Grd.CurrentRow.Index;
                int colIndex = Grd.CurrentCell.ColumnIndex;
                if (e.KeyCode == Keys.F1)
                {

                    Accounts.SchForms.SchItems sch = new Accounts.SchForms.SchItems();

                    sch.ShowDialog();
                    List<Item> lstitem = new List<Item>();
                    lstitem = sch.subList1;
                    if (lstitem.Count > 0)
                    {
                        // ClearControls();

                        for (int i = 0; i < lstitem.Count; i++)
                        {
                            Grd.Rows[rowIndex].Cells["ItemID"].Value = lstitem[i].ItemID.ToString();

                            Grd.Rows[rowIndex].Cells["Item"].Value = lstitem[i].ItemName.ToString();
                            Grd.Rows[rowIndex].Cells["Rate"].Value = lstitem[i].PurchasePrice == 0 ? 1 : lstitem[i].PurchasePrice;
                            Grd.Rows[rowIndex].Cells["Stock"].Value = lstitem[i].CurrentStock;
                            // Grd.Rows[rowIndex].Cells["ReturnQty"].Value = "1";
                            //Grd.Rows[rowIndex].Cells["Shortkey"].Value = lstitem[i].ShortKey.ToString();
                            Grd.Rows[rowIndex].Cells["Disc%"].Value = "0";
                            Grd.Rows[rowIndex].Cells["DiscAmt"].Value = "0";
                            Grd.Rows[rowIndex].Cells["IsDeleted"].Value = false;



                            //  noSale = false;
                            CalculateTotal();


                        }


                    }
                    //*   Item i = sch.ite*/m;

                    //SetItemRow(i);

                    //SetPurchaseLine();
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
        private void SetPurchaseRows(List<WastageLine> lines)
        {
            try
            {
                if (lines != null)
                {

                    for (int i = 0; i < lines.Count; i++)
                    {
                        int rowIndex = Grd.Rows.Add();


                        Grd.Rows[i].Cells["ItemID"].Value = lines[i].itemid.ToString();
                        Grd.Rows[i].Cells["Item"].Value = lines[i].Itemname.ToString();
                        
                        Grd.Rows[i].Cells["WastageQty"].Value = lines[i].Quantity.ToString();
                        Grd.Rows[i].Cells["Rate"].Value = lines[i].PurchasePrice.ToString();

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetItemRow", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void PapulateData(Wastage order)
        {
            try
            {
                this.txtID.Text = order.InvoiceNo.ToString();
                this.dtClaim.Value = order.WastageDate;

                this.txtNaration.Text = order.Narration.ToString();
                this.txtInvDisc.Text = order.Discount.ToString();

                //EditGriddata
                SetPurchaseRows(order.WastageLines);



                isNew = false;
            }
            catch (Exception ex)
            {

            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Sch_Forms.SchWastage frm = new Sch_Forms.SchWastage();

                frm.ShowDialog();

                Common.Wastage order = frm.item;
                if (order != null)
                {
                    PapulateData(order);
                    isNew = false;

                    CalculateTotal();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmPurchaseInvoice EditRecord", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnSchVendor_Click_1(object sender, EventArgs e)
        {
            ShowSearch(ref txtPartyID, ref txtPartyDetail);
        }
        private void ShowSearch(ref System.Windows.Forms.TextBox txtno, ref System.Windows.Forms.TextBox txtname)
        {
            try
            {
                SchAccounts Sch = new SchAccounts();
                Sch.accountType = " and accountno like '61%'";
              
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
    }
    
}

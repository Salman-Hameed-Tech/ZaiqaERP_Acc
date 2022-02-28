using Accounts;
using Accounts.Forms;
using Accounts.SchForms;
using CategoryControlle;
using Common;
using CommonController;
using Microsoft.Reporting.WinForms;
using Restorant_Management_System.Sch_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restorant_Management_System.Forms
{
    public partial class FrmWholeSaleInvoice : Form
    {
        private List<WholeSaleLines> saleLines = new List<WholeSaleLines>();
        private List<WholeSale> sales = new List<WholeSale>();
        WholeSale sale = new WholeSale();
        WholeSaleLines saleLine;
        bool IsNew = true;
        public FrmWholeSaleInvoice()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void ClearControls()
        {
            cmbPmtType.DataSource = Enum.GetValues(typeof(PaymentType));
            cmbPmtType.SelectedIndex = 1;

            txtUserName.Text = User._UserName;
            this.txtID.Text = new WholesaleController().GetMaximumID().ToString();
            cmbPmtType.DataSource = Enum.GetValues(typeof(PaymentType));
            cmbPmtType.SelectedIndex = 1;
            LoadGrid();

            List<Branch> counters = new BranchController().GetBranch("  where 1=1  ");
            cmbBranch.DataSource = counters;
            cmbBranch.ValueMember = "ID";
            cmbBranch.DisplayMember = "BranchName";    
           

            dtpDate.Value = AccountsGlobals.ServerDate;  
            txtBuyerID.Clear();
            txtBuyerName.Clear();
            txtTotalQty.Text = "0";
            txtTotalItemDisc.Text = "0";
            txtGrossTotal.Text = "0";
            txtInvDiscount.Text = "0";
            txtNetAmount.Text = "0";
            txtRemarks.Clear();
            IsNew = true;
            dtpDate.Enabled = true;
            if (!User._IsAdmin)
            {
                btnEdit.Enabled = AccountsGlobals.UserRights[Convert.ToInt32(this.Tag)].CanEdit;
                dtpDate.Enabled = AccountsGlobals.UserRights[AccountsGlobals.DateRights].CanAccess;   

            }


        }

        private void FrmWholeSaleInvoice_Load(object sender, EventArgs e)
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

                //////////////////////////////////////////
                newCol = new DataGridViewColumn();
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
                newCol.HeaderText = "Item ID";
                newCol.Name = "ItemID";
                newCol.CellTemplate = IntCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = false;       
                newCol.Width = 80;
                Grd.Columns.Add(newCol);
                /////////////////////////////////////////////

                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Item Name";
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
                newCol.HeaderText = "Stock";
                newCol.Name = "Stock";
                newCol.CellTemplate = DecimalCell;//RateCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.ReadOnly = true;
                newCol.Width = 60;
                Grd.Columns.Add(newCol);

                //Col 3
                //////////////////////////////////////////////////////////////////////////////////////////////////               
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Quantity";
                newCol.Name = "Quantity";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.Width = 70;
                Grd.Columns.Add(newCol);


                //////////////////////////////////////////////////////////////////////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderCell.Style.BackColor = Color.Yellow;
                newCol.HeaderText = "Disc %";
                newCol.Name = "Disc%";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                // newCol.Visible = Globals.PurchaseDiscountColumnVisible;
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
                // newCol.Visible = Globals.PurchaseDiscountColumnVisible;
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
                newCol.ReadOnly = true;
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateControls())
                {
                    if (AddInvoice())
                    {

                        int VID = new WholesaleController().Save(sale,IsNew);
                             
                        if (VID != 0)
                        {
                            MessageBox.Show("Invoice is saved successfully.", "Invoic is saved...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PrintInvoice(sale, VID);
                            ClearControls();
                        }
                     

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmSaleInvoice SaveRecord", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void PrintInvoice(WholeSale sale, int VID)
        {
            try
            {
                PrintDialog pd = new PrintDialog();
                string oldPrinter = pd.PrinterSettings.DefaultPageSettings.PrinterSettings.PrinterName;
                DataSet ds = new DataSet();
                Common.Data_Sets.DSWholeSale dSSale = new Common.Data_Sets.DSWholeSale();
                if (new WholesaleController().GetReportData(ref dSSale, sale.Dated, VID))
                {
                    Report_Forms.frmViewer Viewer = new Report_Forms.frmViewer();
                    Viewer.reportViewer1.Reset();

                    if (dSSale.Tables["SPWholeSale"].Rows.Count > 0)
                    {
                        ReportDataSource rds = new ReportDataSource("DataSet1", dSSale.Tables["SPWholeSale"]);
                        LocalReport report = new LocalReport();
                        Viewer.reportViewer1.LocalReport.DataSources.Add(rds);
                        Viewer.reportViewer1.LocalReport.ReportPath = Globals.ReportPath + "/Report/RptWholeSale.rdlc";
                        ReportParameter[] rptParams = new ReportParameter[]
                                 {
                                        new ReportParameter("Username",User._UserName),
                                        new ReportParameter("IsRegister",false.ToString()),

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
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "PrintInvoice", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private bool AddInvoice()
        {
            try
            {
                sale.ID = Convert.ToInt32(txtID.Text.Trim());
                sale.Dated = dtpDate.Value;
                sale.BranchID = Convert.ToInt32(cmbBranch.SelectedValue);
                sale.BuyerID = txtBuyerID.Text.Trim();
                sale.InvoiceDiscount = Convert.ToDecimal(txtInvDiscount.Text.Trim().Length == 0 ? "0" : txtInvDiscount.Text.Trim());
                sale.UserNo = User.UserNo;
                sale.NetTotal = Convert.ToDecimal(txtNetAmount.Text);
                sale.Remarks = txtRemarks.Text;
                sale.PaymentMode = cmbPmtType.Text;
                PopulateSalesLines();
                sale.wholeSaleLines = saleLines;
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "AddInvoice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
          
         
         
        }

        private void PopulateSalesLines()
        {
            try
            {
                saleLines.Clear();
                for (int i = 0; i < Grd.Rows.Count - 1; i++)
                {
                    saleLine = new WholeSaleLines();
                    saleLine.ItemID= Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value);
                    saleLine.ItemName = Convert.ToString(Grd.Rows[i].Cells["Item"].Value);
                    saleLine.Barcode =Grd.Rows[i].Cells["Barcode"].Value.ToString();
                    saleLine.Quantity = Convert.ToDecimal(Grd.Rows[i].Cells["Quantity"].Value);
                    saleLine.Rate = Convert.ToDecimal(Grd.Rows[i].Cells["Rate"].Value);
                    saleLine.DiscPer = Convert.ToDecimal(Grd.Rows[i].Cells["Disc%"].Value);
                    saleLine.DiscAmt = Convert.ToDecimal(Grd.Rows[i].Cells["DiscAmt"].Value);
                    saleLine.TotalAmount = Convert.ToDecimal(Grd.Rows[i].Cells["Total"].Value);
                    saleLine.IsDeleted = Convert.ToBoolean(Grd.Rows[i].Cells["IsDeleted"].Value);
                    
                    saleLine.SrNo = Convert.ToInt32(Grd.Rows[i].Cells["SrNo"].Value);
                    saleLines.Add(saleLine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PopulateSalesLines", MessageBoxButtons.OK, MessageBoxIcon.Error);
         

            }
        }

        private bool ValidateControls()
        {
            try
            {
             
                if (txtBuyerID.Text.Trim().Length==0)
                {
                    MessageBox.Show("Select Buyer Account", " ValidateCtrls", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtBuyerID.Focus();

                    return false;
                }
                if (Grd.Rows.Count < 2 )
                {
                    MessageBox.Show("Add Some Items", " ValidateCtrls", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtBuyerID.Focus();

                    return false;
                }




                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ValidateCtrls", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void Grd_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = Grd.CurrentRow.Index;
                int colIndex = Grd.CurrentCell.ColumnIndex;
                if (colIndex == Grd.Columns["BarCode"].Index)
                {

                    Int32 counterid = new CounterController().GetCounterid(FrmLogin.UserID);
                    string opStr = Grd.Rows[rowIndex].Cells["Barcode"].Value == null ? "0" : Grd.Rows[rowIndex].Cells["Barcode"].Value.ToString();
                    char sap = '~';
                    string[] split = opStr.Split(sap);
                    //saleLines = new SaleInvoiceController().VerifyItem(Grd.GetData(Grd.Row, Grd.Cols["Barcode"].Index).ToString().Trim() , "b");
                    saleLines = new WholesaleController().VerifyItem(split[0], "b");

                    if (saleLines.Count == 0)
                    {
                        MessageBox.Show("No item with this Bar code exists.", "Choose Valid Item...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    else
                    {
                        int i = split.Count();
                        SetSaleLine();
                        if (i > 1)
                        {
                            Grd.Rows[rowIndex].Cells["Quantity"].Value = Convert.ToDecimal(split[1]);
                            //   SendKeys.Send("Enter");
                            Grd.Rows[rowIndex].Cells["Barcode"].Value = split[0];
                            /////////////////by haroon
                            Grd.Rows[rowIndex].Cells["DiscAmt"].Value = Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Quantity"].Value) * (decimal)(Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Rate"].Value) * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Disc%"].Value) / 100);
                            Grd.Rows[rowIndex].Cells["Total"].Value = Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Quantity"].Value) * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Rate"].Value) - Convert.ToDecimal(Grd.Rows[rowIndex].Cells["DiscAmt"].Value);
                            //TxtStk.Text = Convert.ToString(Grd.GetData(Grd.Row, Grd.Cols["Stock"].Index));
                            //CalStk();
                            CalculateTotal();


                            /////////////

                        }
                        Grd.Rows[rowIndex].Cells[4].Selected = true;
                    }
                }
                else if (colIndex == Grd.Columns["ItemID"].Index)
                {
                    Int32 adminid = new CounterController().GetAdmin(FrmLogin.UserID);
                    Int32 Alluser = new CounterController().GetAllusers(FrmLogin.UserID);
                    var resultadmin = new CounterController().Getusers(adminid);
                    var resultusers = new CounterController().Getusers(Alluser);


                    //Int32 counterid = new CounterController().GetCounterid(FrmLogin.UserID);

                    //  saleLine.Clear();
                    if (resultadmin == true || resultusers == true)
                    {
                        if (Grd.Rows[rowIndex].Cells["ItemID"].Value != null)
                        {

                            saleLines = new WholesaleController().VerifyAllItem(Grd.Rows[rowIndex].Cells["ItemID"].Value.ToString().Trim(), "i");

                            if (saleLines.Count == 0)
                            {
                                MessageBox.Show("No item with this Item ID exists.", "Choose Valid Item...", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                            else
                                SetSaleLine();
                        }
                    }
                    else
                    if (Grd.Rows[rowIndex].Cells["ItemID"].Value != null)
                    {

                       saleLines = new WholesaleController().VerifyItem(Grd.Rows[rowIndex].Cells["ItemID"].Value.ToString().Trim(), "i");

                        if (saleLines.Count == 0)
                        {
                            MessageBox.Show("No item with this Item ID exists.", "Choose Valid Item...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }
                        else
                            SetSaleLine();
                    }
                    Grd.Rows[rowIndex].Cells[4].Selected = true;
                }
                else if (colIndex == Grd.Columns["Quantity"].Index)// || (Grd.Col == Grd.Cols["Purchase Price"].Index))
                {

                    if (Grd.Rows[rowIndex].Cells["Quantity"].Value != null && Grd.Rows[rowIndex].Cells["Rate"].Value != null)
                    {
                        if (Grd.Rows[rowIndex].Cells["Quantity"].Value.ToString().Trim().Length != 0 && Grd.Rows[rowIndex].Cells["Rate"].Value.ToString().Trim().Length != 0)
                        {
                            Grd.Rows[rowIndex].Cells["DiscAmt"].Value = SetLineDiscount(rowIndex);
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
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Grd_CellEndEdit",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void SetSaleLine()
        {
            try
            {
                int RowIndex = Grd.CurrentRow.Index;
                int colIndex = Grd.CurrentCell.ColumnIndex;

                foreach (WholeSaleLines saleLine in saleLines)
                {

                    decimal Categorydisc = new ItemController().GetDiscountOffer(saleLine.ItemID);

                    Grd.Rows[RowIndex].Cells["ItemID"].Value = saleLine.ItemID.ToString();
                    Grd.Rows[RowIndex].Cells["BarCode"].Value = saleLine.Barcode.ToString();
                 
                    Grd.Rows[RowIndex].Cells["Item"].Value = saleLine.ItemName.ToString();
                    Grd.Rows[RowIndex].Cells["Rate"].Value = saleLine.Rate;
                    Grd.Rows[RowIndex].Cells["Quantity"].Value = 1;
                    Grd.Rows[RowIndex].Cells["Disc%"].Value = Categorydisc;
                    Grd.Rows[RowIndex].Cells["DiscAmt"].Value = SetLineDiscount(RowIndex);
                    Grd.Rows[RowIndex].Cells["Stock"].Value = saleLine.CsQty;
                    Grd.Rows[RowIndex].Cells["Total"].Value = Convert.ToDecimal(Grd.Rows[RowIndex].Cells["Quantity"].Value) * Convert.ToDecimal(Grd.Rows[RowIndex].Cells["Rate"].Value) - Convert.ToDecimal(Grd.Rows[RowIndex].Cells["DiscAmt"].Value);
                    Grd.Rows[RowIndex].Cells["IsDeleted"].Value = saleLine.IsDeleted;
                    decimal reOrderLevel = Convert.ToDecimal(new ItemController().GetItemDetail(Convert.ToInt32(Grd.Rows[RowIndex].Cells["ItemID"].Value)).ReorderLimit);


                }

                CalculateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmSaleInvoice SetSaleLine", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private decimal SetLineDiscount(int RowIndex)
        {
            decimal discount = 0;
            discount = Convert.ToDecimal(Grd.Rows[RowIndex].Cells["Quantity"].Value) * (decimal)(Convert.ToDecimal(Grd.Rows[RowIndex].Cells["Rate"].Value) * Math.Abs(Convert.ToDecimal(Grd.Rows[RowIndex].Cells["Disc%"].Value)) / 100);
            return Math.Abs(discount);
        }
        private decimal CalculateTotal()
        {
            try
            {
                decimal total = 0;
                decimal totalRem = 0;
                decimal totalDisc = 0;
                decimal totalRetAmt = 0;
                decimal Grand = 0;
                int  qty=0;
                for (int i = 0; i < Grd.Rows.Count; i++)
                {
                    if (Grd.Rows[i].Visible == true)
                    {
                        if (Grd.Rows[i].Cells["Quantity"].Value != null || Grd.Rows[i].Cells["Rate"].Value != null)
                        {
                            if (Grd.Rows[i].Cells["Quantity"].Value.ToString().Trim().Length != 0 || Grd.Rows[i].Cells["Rate"].Value.ToString().Trim().Length != 0)
                            {
                                if (Convert.ToBoolean(Grd.Rows[i].Cells["IsDeleted"].Value) == false)
                                {
                                      qty += Convert.ToInt32(Grd.Rows[i].Cells["Quantity"].Value);
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

                txtTotalQty.Text = qty.ToString();
                this.txtGrossTotal.Text = Math.Round(total, 2).ToString();
                this.txtTotalItemDisc.Text = (totalDisc + Convert.ToDecimal(this.txtTotalItemDisc.Text.Trim().Length == 0 ? "0" : this.txtTotalItemDisc.Text.Trim())).ToString();
                txtTotalItemDisc.Text = totalDisc.ToString();
                decimal nettotal = 0;
                if (total < 0)
                {
                    nettotal = Math.Abs(total) - totalDisc;
                    nettotal = -nettotal;
                }
                else
                {
                    nettotal = total - totalDisc;
                }
                decimal invdiscount = Convert.ToDecimal(txtInvDiscount.Text.Trim().Length == 0 ? "0" : txtInvDiscount.Text.Trim());
                nettotal = nettotal - invdiscount;
                txtNetAmount.Text = nettotal.ToString();
               

                return (total);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmSaleIvoice CalculateTotal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SchAccounts Sch = new SchAccounts();
                Sch.accountType = " and accountno like '6004%' and p.inSale=1 ";
                Sch.POS = "S";
                Sch.ShowDialog();
                if (Sch.SelectedAccount != null)
                {
                    txtBuyerID.Text = Sch.SelectedAccount.AccountNo;
                    txtBuyerName.Text = Sch.SelectedAccount.AccountName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

                if (e.KeyCode == Keys.F1)
                {

                    SearchItems();

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

                sch.ShowDialog();
                List<Item> lstitem = new List<Item>();
                lstitem = sch.subList1;
                if (lstitem.Count > 0)
                {
                    // ClearControls();

                    for (int i = 0; i < lstitem.Count; i++)
                    {
                        Grd.Rows.Add();
                        Grd.Rows[rowIndex].Cells["ItemID"].Value = lstitem[i].ItemID.ToString();

                        Grd.Rows[rowIndex].Cells["Item"].Value = lstitem[i].ItemName.ToString();
                        Grd.Rows[rowIndex].Cells["Rate"].Value = lstitem[i].PurchasePrice == 0 ? 1 : lstitem[i].PurchasePrice;
                        Grd.Rows[rowIndex].Cells["Stock"].Value = lstitem[i].CurrentStock;
                        Grd.Rows[rowIndex].Cells["Quantity"].Value = "1";
                    
                        Grd.Rows[rowIndex].Cells["Disc%"].Value = "0";
                        Grd.Rows[rowIndex].Cells["DiscAmt"].Value = "0";
                        Grd.Rows[rowIndex].Cells["IsDeleted"].Value = false;

                
                        CalculateTotal();

                    }

                }
            }
        }

        private void txtInvDiscount_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                SchWholesaleInvoice frm = new SchWholesaleInvoice();
                frm.ShowDialog();
                if (frm.sale != null)
                {
                    ClearControls();
                    IsNew = false;
                    dtpDate.Enabled = false;
                    txtUserName.Text = frm.sale.UserName;
                    txtID.Text = frm.sale.ID.ToString();
                    dtpDate.Value = frm.sale.Dated;
                    txtBuyerID.Text = frm.sale.BuyerID;
                    txtBuyerName.Text = frm.sale.BuyerName;
                    txtRemarks.Text = frm.sale.Remarks;
                    cmbPmtType.Text = frm.sale.PaymentMode;
                    cmbBranch.SelectedValue = frm.sale.BranchID;

                    AddLines(frm.sale.wholeSaleLines);
                    CalculateTotal();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "btnEdit_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }

        private void AddLines(List<WholeSaleLines> lines)
        {
           for(int i = 0; i < lines.Count; i++)
           {
                int rowindex=Grd.Rows.Add();
                if (lines[i].SrNo != 0)
                {
                    Grd.Rows[rowindex].Cells["ItemID"].ReadOnly = true;
                    Grd.Rows[rowindex].Cells["Barcode"].ReadOnly = true;
                }
                Grd.Rows[rowindex].Cells["ItemID"].Value = lines[i].ItemID;
                Grd.Rows[rowindex].Cells["Item"].Value = lines[i].ItemName;
                Grd.Rows[rowindex].Cells["Barcode"].Value = lines[i].Barcode;
                Grd.Rows[rowindex].Cells["Rate"].Value = lines[i].Rate;
                Grd.Rows[rowindex].Cells["Quantity"].Value = lines[i].Quantity;
                Grd.Rows[rowindex].Cells["Disc%"].Value = Math.Abs(lines[i].DiscAmt / (lines[i].Quantity * lines[i].Rate) * 100);
                Grd.Rows[rowindex].Cells["DiscAmt"].Value = lines[i].DiscAmt;
                Grd.Rows[rowindex].Cells["Total"].Value = lines[i].Quantity * lines[i].Rate;
                Grd.Rows[rowindex].Cells["SrNo"].Value = lines[i].SrNo;


            }
        }
    }
}

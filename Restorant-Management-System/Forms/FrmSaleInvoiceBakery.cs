using Accounts;
using Accounts.Forms;
using Accounts.SchForms;
using CategoryControlle;
using Common;
using Common.Data_Sets;
using CommonController;
using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restorant_Management_System.Forms
{
    public partial class FrmSaleInvoiceBakery : Form
    {
        string invPrinter;
        RegistryKey regKeyAppRoot;

        private int m_currentPageIndex;
        private IList<Stream> m_streams;

        public List<ChartOfAccounts> BankAccounts;
        private SaleInvoiceBakery invoice;
        private List<SaleInvoiceBakeryLine> lines;
        private List<SaleInvoiceLine> saleLines = new List<SaleInvoiceLine>();//for fetching itemdetail
        bool isNew = true;
        public FrmSaleInvoiceBakery()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
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
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.Width = 120;
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
                newCol.Name = "ItemName";

                newCol.CellTemplate = TextCell;

                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;
                //  newCol.Visible = Globals.PackingColumnVisible;
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

                /////////////////////////////////
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
                //////////////////////////////////////////////////////////////////////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderCell.Style.BackColor = Color.Yellow;
                newCol.HeaderText = "Disc %";
                newCol.Name = "Disc%";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
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
                newCol.Visible = true;
                newCol.Width = 60;
                Grd.Columns.Add(newCol);

                //Col 5
                //////////////////////////////////////////////////////////////////////////////////////////////////
              

                /////////////////////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderCell.Style.BackColor = Color.Salmon;
                newCol.HeaderText = "Actual Rate";
                newCol.Name = "ActualRate";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //newCol.Visible = Globals.SaleTaxColumnVisisble;
                newCol.ReadOnly = true;
                newCol.Visible = false;
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


                AccountsGlobals.ExtendCol(ref Grd, "ItemName");





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
                txtID.Text = new SaleInvoiceBakeryController().GetMaxID();
                LoadGrid();
                LoadBankAcc();

                dtpDate.Value = DateTime.Now;
                txtPartyID.Clear();
                txtPartyDetail.Clear();
                txtInvDisc.Text = "0";
                txtInvDiscPer.Text = "0";
                txtCashPayment.Text = "0";
                txtNetAmount.Text = "0";
                txtTotalQuantity.Text = "0";
                txtReturnAmount.Clear();
                txtCardNo.Clear();
                cmbBank.SelectedIndex = -1;
                cmbCreditCard.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ClearControls", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void LoadBankAcc()
        {
          
                BankAccounts = new ChartofAccountsController().GetBankAccounts();
                cmbBank.DataSource = BankAccounts;
                cmbBank.DisplayMember = "AccountName";
                cmbBank.ValueMember = "AccountNo";
                cmbBank.SelectedIndex = -1;
           
        }

        private bool ValidateControls()
        {
            if (this.txtPartyID.Text.Trim().Length == 0 && cmbCreditCard.Text=="Credit Sale")
            {
                MessageBox.Show("Please Select or Enter Vendor.", "Enter Vendor...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtPartyID.Focus();
                return false;
            }
            if (Convert.ToDecimal(txtNetAmount.Text) > Convert.ToDecimal(txtCashPayment.Text)  && cmbCreditCard.Text == "Cash")
            {
                MessageBox.Show("Cash Payment cannot be less than Net Amount", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCashPayment.Focus();
                return false;
            }



            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateControls())
                {
                    if (AddInvoice())
                    {
                        int VID = new SaleInvoiceBakeryController().Save(invoice,isNew);
                        if (VID > 0)
                        {
                            MessageBox.Show("Invoice is saved successfully.", "Invoic is saved...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PrintInvoice( VID);
                            ClearControls();
                        }

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void PrintInvoice(int VID)
        {
            PrintDialog pd = new PrintDialog();
            string oldPrinter = pd.PrinterSettings.DefaultPageSettings.PrinterSettings.PrinterName;
            DataSet ds = new DataSet();
            DSaleInvoiceBakery dSaleInvoiceBakery = new DSaleInvoiceBakery();
            if (new SaleInvoiceBakeryController().GetReportData(ref dSaleInvoiceBakery, VID))
            {
                Report_Forms.frmViewer Viewer = new Report_Forms.frmViewer();
                Viewer.reportViewer1.Reset();

                if (dSaleInvoiceBakery.Tables["SPSaleInvoiceBakery"].Rows.Count > 0)
                {
                    ReportDataSource rds = new ReportDataSource("DataSet1", dSaleInvoiceBakery.Tables["SPSaleInvoiceBakery"]);
                    LocalReport report = new LocalReport();

                    report.DataSources.Add(rds);
                    report.ReportEmbeddedResource = "Restorant_Management_System.Report.RptSaleInvoiceBakery.rdlc";
                    ReportParameter[] rptParams = new ReportParameter[]
                             {
                                        new ReportParameter("Username",User._UserName),

                             };
                    report.SetParameters(rptParams);
                    report.Refresh();

                    Export(report);
                    Print();

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
            regKeyAppRoot = Registry.LocalMachine.CreateSubKey("SOFTWARE\\POSPrinter");
            invPrinter = Convert.ToString(regKeyAppRoot.GetValue("InvPrinter"));


            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = invPrinter;

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

        private bool AddInvoice()
        {
            invoice = new SaleInvoiceBakery();
            
           
            invoice.ID = Convert.ToInt32(txtID.Text.Trim());
            invoice.Dated = dtpDate.Value;
            invoice.DiscPer = Convert.ToDecimal(txtInvDiscPer.Text);
            invoice.DiscAmt = Convert.ToDecimal(txtInvDisc.Text);
            invoice.TotalAmt = Convert.ToDecimal(txtNetAmount.Text.Trim());
            invoice.PaymentMode = cmbCreditCard.Text;
           
            if (cmbCreditCard.Text == "Credi Card" || cmbCreditCard.Text == "Cash & Credit Card")
            {
                invoice.Bank = cmbCreditCard.SelectedValue.ToString();
            }
            else
            {
                invoice.Bank = "NULL";
            }
            invoice.CardNo = txtCardNo.Text.Trim().Length==0?"NULL" : txtCardNo.Text.Trim();
            invoice.PartyID = txtPartyID.Text.Trim().Length == 0 ? "NULL" : txtPartyID.Text.Trim();          
            invoice.AmtPaid = Convert.ToDecimal(txtCashPayment.Text.Trim().Length == 0 ? "0": txtCashPayment.Text.Trim());
            invoice.ReturnAmt = Convert.ToDecimal(txtReturnAmount.Text.Trim().Length== 0? "0" : txtReturnAmount.Text.Trim());
            invoice.BranchID = Globals.BranchID;
            invoice.UserNo = User.UserNo;
           

            if (!AddInvoiceLines())
            {
                return false;
            }

            invoice.bakeryLines = lines;

            return true;
        }

        private bool AddInvoiceLines()
        {
            try
            {
                if (Grd.Rows.Count > 0)
                {
                    lines = new List<SaleInvoiceBakeryLine>();

                    for (int i = 0; i < Grd.Rows.Count; i++)
                    {

                        if (Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value) != 0 && Convert.ToDecimal(Grd.Rows[i].Cells["Quantity"].Value) != 0)
                        {
                            
                            SaleInvoiceBakeryLine line = new SaleInvoiceBakeryLine();
                            line.ItemID = Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value);
                            line.Barcode = Convert.ToString(Grd.Rows[i].Cells["Barcode"].Value);
                            line.Quantity = Convert.ToDecimal(Grd.Rows[i].Cells["Quantity"].Value);                                
                            line.Rate = Convert.ToDecimal(Grd.Rows[i].Cells["Rate"].Value);     
                            line.DiscPer= Convert.ToDecimal(Grd.Rows[i].Cells["Disc%"].Value);
                            line.DiscAmt = Convert.ToDecimal(Grd.Rows[i].Cells["DiscAmt"].Value);
                            line.SrNo = Convert.ToInt32(Grd.Rows[i].Cells["SrNo"].Value);
                            line.IsDeleted = Convert.ToBoolean(Grd.Rows[i].Cells["IsDeleted"].Value);

                            lines.Add(line);
                          
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbCreditCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCreditCard.SelectedItem.ToString() == "Credit Sale")
            {

                GrpCustomer.Visible = true;
                txtCashPayment.Visible = false;
                lblCPmt.Visible = false;
                lblRAmt.Visible = false;
                txtReturnAmount.Visible = false;
                lblBank.Visible = false;
                cmbBank.Visible = false;
                lblCardNo.Visible = false;
                txtCardNo.Visible = false;
               
            }
            else if (cmbCreditCard.SelectedItem.ToString() == "Credit Card")
            {
                // txtCashPayment.Enabled = false;
                GrpCustomer.Visible = false;
                lblBank.Visible = true;
                cmbBank.Visible = true;
                lblCardNo.Visible = true;
                txtCardNo.Visible = true;
                txtCashPayment.ReadOnly = true;


            }
            else if (cmbCreditCard.SelectedItem.ToString() == "Cash & Credit Card")
            {
                //txtCashPayment.Enabled = true;
                txtCashPayment.ReadOnly = false;
                GrpCustomer.Visible = false;
                lblBank.Visible = true;
                cmbBank.Visible = true;
                lblCardNo.Visible = true;
                txtCardNo.Visible = true;
            }
            else if (cmbCreditCard.SelectedItem.ToString() == "Cash")
            {
                txtCashPayment.ReadOnly = false;
                txtCashPayment.Enabled = true;
                GrpCustomer.Visible = false;
                lblBank.Visible = false;
                cmbBank.Visible = false;
                lblCardNo.Visible = false;
                txtCardNo.Visible = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
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

        private void FrmSaleInvoiceBakery_Load(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void Grd_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = Grd.CurrentRow.Index;
                int colIndex = Grd.CurrentCell.ColumnIndex;

                if (colIndex == Grd.Columns["BarCode"].Index)
                {
                    if (Grd.Rows[rowIndex].Cells["BarCode"].Value != null)
                    {
                        saleLines = new SaleInvoiceController().VerifyAllItem(Grd.Rows[rowIndex].Cells["BarCode"].Value.ToString().Trim(), "BIbarcode", Globals.BranchID);

                        if (saleLines.Count == 0)
                        {
                            MessageBox.Show("No item with this Item ID exists.", "Choose Valid Item...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            SetSaleLine();
                    }
                }


                if (colIndex == Grd.Columns["ItemID"].Index)
                {
                    if (Grd.Rows[rowIndex].Cells["ItemID"].Value != null)
                    {
                        saleLines = new SaleInvoiceController().VerifyAllItem(Grd.Rows[rowIndex].Cells["ItemID"].Value.ToString().Trim(), "BI", Globals.BranchID);

                        if (saleLines.Count == 0)
                        {
                            MessageBox.Show("No item with this Item ID exists.", "Choose Valid Item...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            SetSaleLine();
                    }
                }
                if (colIndex == Grd.Columns["Quantity"].Index)
                {
                    Grd.Rows[rowIndex].Cells["Total"].Value = Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Quantity"].Value) * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Rate"].Value);
                    Grd.Rows[rowIndex].Cells["DiscAmt"].Value = (Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Quantity"].Value) * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Rate"].Value)) * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Disc%"].Value) / 100;
                    Grd.Rows[rowIndex].Cells["Rate"].Selected = true;
                }
                if (colIndex == Grd.Columns["Rate"].Index)
                {
                    Grd.Rows[rowIndex].Cells["Total"].Value = Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Quantity"].Value) * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Rate"].Value);
                    Grd.Rows[rowIndex].Cells["DiscAmt"].Value = (Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Quantity"].Value) * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Rate"].Value)) * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Disc%"].Value) / 100;

                    Grd.Rows[rowIndex].Cells["Quantity"].Value = Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Rate"].Value) / Convert.ToDecimal(Grd.Rows[rowIndex].Cells["ActualRate"].Value);
                }
                if (colIndex == Grd.Columns["Disc%"].Index)
                {
                    Grd.Rows[rowIndex].Cells["DiscAmt"].Value = (Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Quantity"].Value) * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Rate"].Value)) * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Disc%"].Value) / 100;
                    Grd.Rows[rowIndex].Cells["Disc%"].Selected = true;
                }
                if (colIndex == Grd.Columns["DiscAmt"].Index)
                {
                    Grd.Rows[rowIndex].Cells["Disc%"].Value = (Convert.ToDecimal(Grd.Rows[rowIndex].Cells["DiscAmt"].Value) * 100) / ((Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Quantity"].Value) * Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Rate"].Value)));
                    Grd.Rows[rowIndex].Cells["Total"].Selected = true;
                }
                CalculateTotal();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Grd_CellEndEdit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetSaleLine()
        {
            try
            {
                int RowIndex = Grd.CurrentRow.Index;
                int colIndex = Grd.CurrentCell.ColumnIndex;

                foreach (SaleInvoiceLine saleLine in saleLines)
                {
                    Grd.Rows[RowIndex].Cells["ItemID"].Value = saleLine.Vitem.ItemID.ToString();
                 
                    Grd.Rows[RowIndex].Cells["BarCode"].Value = saleLine.Vitem.BarCode.ToString();
                    Grd.Rows[RowIndex].Cells["ItemName"].Value = saleLine.Vitem.ItemName.ToString();
                    Grd.Rows[RowIndex].Cells["ActualRate"].Value = saleLine.PurchasePrice;
                    Grd.Rows[RowIndex].Cells["Rate"].Value = saleLine.PurchasePrice;
                    Grd.Rows[RowIndex].Cells["Stock"].Value = saleLine.CStk;
                    Grd.Rows[RowIndex].Cells["Total"].Value = Convert.ToDecimal(Grd.Rows[RowIndex].Cells["Quantity"].Value) * Convert.ToDecimal(Grd.Rows[RowIndex].Cells["Rate"].Value) - Convert.ToDecimal(Grd.Rows[RowIndex].Cells["DiscAmt"].Value);
                    Grd.Rows[RowIndex].Cells["IsDeleted"].Value = saleLine.IsDeleted;
                }

                CalculateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmSaleInvoice SetSaleLine", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateTotal()
        {
            decimal totalAmount = 0;
            decimal totalitemdiscount = 0;
            decimal totalgst = 0;
            decimal totalQuantity = 0;

            for (int i = 0; i < Grd.Rows.Count; i++)
            {
                if (Grd.Rows[i].Visible == true)
                {
                    decimal quantity = Convert.ToDecimal(Grd.Rows[i].Cells["Quantity"].Value);
                    decimal rate = Convert.ToDecimal(Grd.Rows[i].Cells["Rate"].Value);
                    decimal discAmt = Convert.ToDecimal(Grd.Rows[i].Cells["DiscAmt"].Value);
                    

                    Grd.Rows[i].Cells["Total"].Value = (quantity * rate) - discAmt;
                    totalAmount += Math.Round(Convert.ToDecimal(Grd.Rows[i].Cells["Total"].Value), 2);
                    totalQuantity += Math.Round(Convert.ToDecimal(Grd.Rows[i].Cells["Quantity"].Value), 4);
                    totalitemdiscount += Math.Round(Convert.ToDecimal(Grd.Rows[i].Cells["DiscAmt"].Value), 2);
                  

                }
            }
            txtTotalQuantity.Text = totalQuantity.ToString();         
            txtGrossAmt.Text = totalAmount.ToString();
          
            decimal disamt = Convert.ToDecimal(txtInvDisc.Text.Trim().Length == 0 ? "0" : this.txtInvDisc.Text);
            txtNetAmount.Text = (totalAmount - disamt).ToString();
        }

        private void txtInvDiscPer_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this.txtInvDiscPer.Text.Trim().Length > 0)
                {
                    decimal invtotal = Convert.ToDecimal((this.txtGrossAmt.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(this.txtGrossAmt.Text)));
                    decimal dicper = Convert.ToDecimal((this.txtInvDiscPer.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(this.txtInvDiscPer.Text.Trim())));
                    this.txtInvDisc.Text = (dicper * (invtotal) / 100).ToString();
                }
                else
                {
                    this.txtInvDiscPer.Text = null;
                    this.txtInvDisc.Text = null;
                }
                CalculateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmPurchaseInvoice txtDiscP_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtInvDisc_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(this.txtInvDisc.Text.Trim().Length == 0 ? "0" : this.txtInvDisc.Text.Trim()) > 0)
            {
                decimal disamt = Convert.ToDecimal(this.txtInvDisc.Text.Trim().Length == 0 ? "0" : this.txtInvDisc.Text);
                decimal invtotal = Convert.ToDecimal(this.txtGrossAmt.Text);

                if (Convert.ToDecimal(this.txtGrossAmt.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(this.txtGrossAmt.Text)) > 0)
                {
                    this.txtInvDiscPer.Text = Math.Round(disamt * 100 / (invtotal), 2).ToString();
                }
            }
            else
            {
                this.txtInvDisc.Text = null;
                this.txtInvDiscPer.Text = null;
            }
            CalculateTotal();
        }

        private void txtCashPayment_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtCashPayment.Text.Trim().Length > 0)
                {
                    txtReturnAmount.Text = (Convert.ToDecimal(txtNetAmount.Text) - Convert.ToDecimal(txtCashPayment.Text)).ToString();

                }
                
                else
                {
                    txtReturnAmount.Clear();
                }
            }
            catch (Exception)
            {

            }
        }

        private void Grd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {

                    SearchItems();

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmPurchaseInvoice txtDiscP_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SearchItems()
        {
            int rowIndex = Grd.CurrentRow.Index;

            if (Convert.ToInt32(Grd.Rows[rowIndex].Cells["SrNo"].Value) == 0)
            {
                Accounts.SchForms.SchItems sch = new Accounts.SchForms.SchItems();
                sch.BranchId = Globals.BranchID;
                sch.condition = " and i.isBakery=1 ";
                sch.ShowDialog();
                List<Item> lstitem = new List<Item>();

                lstitem = sch.subList1;
                if (lstitem.Count > 0)
                {

                    for (int i = 0; i < lstitem.Count; i++)
                    {
                        
                        Grd.Rows.Add();
                        Grd.Rows[rowIndex].Cells["ItemID"].Value = lstitem[i].ItemID.ToString();
                        Grd.Rows[rowIndex].Cells["BarCode"].Value = lstitem[i].BarCode.ToString();
                        Grd.Rows[rowIndex].Cells["ItemName"].Value = lstitem[i].ItemName.ToString();
                        Grd.Rows[rowIndex].Cells["ActualRate"].Value = lstitem[i].SalePrice;
                        Grd.Rows[rowIndex].Cells["Rate"].Value = lstitem[i].SalePrice;
                        Grd.Rows[rowIndex].Cells["Stock"].Value = lstitem[i].CurrentStock;
                        Grd.Rows[rowIndex].Cells["Quantity"].Value = 0;
                        Grd.Rows[rowIndex].Cells["IsDeleted"].Value = false;
                        Grd.Rows[rowIndex].Cells["Quantity"].Selected = true;


                        CalculateTotal();
                 
                       
                    }

                }
            }
        }
    }
}

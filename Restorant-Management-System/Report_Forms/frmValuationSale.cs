using Accounts;
using Accounts.Forms;
using Accounts.SchForms;
using CategoryControlle;
using Common;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restorant_Management_System.Report_Forms
{
    public partial class frmValuationSale : Form
    {
        public List<ChartOfAccounts> BankAccounts;
        List<ChartOfAccounts> vendors = new List<ChartOfAccounts>();
        private string fromDate;
        int BranchID;
        private string toDate;
        public string ValuationType = "";
        DataSet ds=new DataSet();
        public frmValuationSale()
        {
            InitializeComponent();
        }

        private void frmValuationSale_Load(object sender, EventArgs e)
        {
            try
            {
                ClearControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmCurrentStock_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                //If Barcode column is visible then pressing enter on grid will make downward move. Else Left to right.
                //Grid.MoveLeftToRight = !Globals.BarcodeColumnVisisble;

                DataGridViewCell TextCell = new DataGridViewTextBoxCell();
                DataGridViewCell DecimalQtyCell = new TNumEditDataGridViewCell(4);
                DataGridViewCell DecimalCell = new TNumEditDataGridViewCell(2);
                DataGridViewCell RateCell = new TNumEditDataGridViewCell(3);
                DataGridViewCell IntCell = new TNumEditDataGridViewCell(0);

                DataGridViewComboBoxColumn comboCol = new DataGridViewComboBoxColumn();
                DataGridViewCell ComboCell = new DataGridViewComboBoxCell();

                DataGridViewCheckBoxColumn Checkbox = new DataGridViewCheckBoxColumn();
                DataGridViewCell checkcell = new DataGridViewCheckBoxCell();


                DataGridViewComboBoxColumn comboCol2 = new DataGridViewComboBoxColumn();
                DataGridViewCell ComboCell2 = new DataGridViewComboBoxCell();

                DataGridViewComboBoxColumn comboCol3 = new DataGridViewComboBoxColumn();
                DataGridViewCell ComboCell3 = new DataGridViewComboBoxCell();

                //Col 1
                ////////////////////////////////////////////////////////////////////////////////////////////////// 

                DataGridViewColumn newCol = new DataGridViewColumn(); // add a column to the grid 

                //Col 1
                ////////////////////////////////////////////////////////////////////////////////////////////////// 

                newCol = new DataGridViewColumn();
                newCol.CellTemplate = TextCell;
                newCol.HeaderText = "Vendor ID";
                newCol.Name = "ID";
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.Width = 80;
                newCol.ReadOnly = true;

                Grd.Columns.Add(newCol);

                //Col 2
                ////////////////////////////////////////////////////////////////////////////////////////////////// 
                newCol = new DataGridViewColumn();
                newCol.CellTemplate = TextCell;
                newCol.HeaderText = "Vendor Name";
                newCol.Name = "Vendor";
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.Width = 300;
                newCol.ReadOnly = true;

                Grd.Columns.Add(newCol);

                ////////////////////////////////
                Checkbox = new DataGridViewCheckBoxColumn();
                Checkbox.CellTemplate = checkcell;
                Checkbox.HeaderText = "Select";
                Checkbox.Name = "Chkbox";
                Checkbox.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Checkbox.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Checkbox.Visible = true;
                Checkbox.Width = 50;
                Checkbox.ReadOnly = false;

                Grd.Columns.Add(Checkbox);

                AccountsGlobals.ExtendCol(ref Grd, "Vendor");

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

                this.rdbAllDates.Checked = true;
                this.rdbDateRange.Checked = false;
                this.rdbADay.Checked = false;
                this.rdbToday.Checked = false;

                this.gbDateRange.Visible = false;
                this.gbADay.Visible = false;
                if (ValuationType == "CCSaleSummary")
                {
                    List<Branch> counters = new BranchController().GetBranch("  where IsWarehouse=0  ");
                    cmbBranch.DataSource = counters;
                    cmbBranch.ValueMember = "ID";
                    cmbBranch.DisplayMember = "BranchName";
                    cmbBranch.SelectedIndex = -1;

                    BankAccounts = new ChartofAccountsController().GetBankAccounts();
                    cmbBank.DataSource = BankAccounts;
                    cmbBank.DisplayMember = "AccountName";
                    cmbBank.ValueMember = "AccountNo";
                    cmbBank.SelectedIndex = -1;

                    cmbBank.Visible = true;
                    lblBank.Visible = true;
                 
                    Grd.Visible = false;
                    chkAllVendor.Visible = false;
                }
                if (ValuationType == "Sale")
                {
                    List<Branch> counters = new BranchController().GetBranch("  where IsWarehouse=0  ");
                    cmbBranch.DataSource = counters;
                    cmbBranch.ValueMember = "ID";
                    cmbBranch.DisplayMember = "BranchName";
                    cmbBranch.SelectedIndex = -1;
                    cmbBank.Visible = false;
                    lblBank.Visible = false;
                 
                  
                    Grd.Visible = true;
                    chkAllVendor.Visible = true;
                    LoadGrid();
                    PopulateVendors();
                }

                else if(ValuationType == "Inventory")
                {
                    List<Branch> counters = new BranchController().GetBranch("  where 1=1  ");
                    cmbBranch.DataSource = counters;
                    cmbBranch.ValueMember = "ID";
                    cmbBranch.DisplayMember = "BranchName";
                    cmbBank.Visible = false;
                    lblBank.Visible = false;
                
                    Grd.Visible = false;
                    chkAllVendor.Visible = false;


                }
                else if (ValuationType == "DiscountOffers")
                {
                    List<Branch> counters = new BranchController().GetBranch("  where IsWarehouse=0 ");
                    cmbBranch.DataSource = counters;
                    cmbBranch.ValueMember = "ID";
                    cmbBranch.DisplayMember = "BranchName";
                    cmbBranch.SelectedIndex = -1;

                    this.grpDiscount.Visible = true;
                    rdbAllDates.Visible = true ;
                    rdbDateRange.Visible = true;
                    gbDateRange.Visible = false ;
                    cmbBank.Visible = false;
                    lblBank.Visible = false;
             
                    Grd.Visible = false;
                    chkAllVendor.Visible = false;
                    rdbDiscount.Checked = true;  

                }





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmCurrentStock ClearControls()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateVendors()
        {
            try
            {
                List<ChartOfAccounts> accounts = new List<ChartOfAccounts>();
                accounts = new ChartofAccountsController().GetVendors();
                for(int i = 0; i < accounts.Count; i++)
                {
                    int rowindex = Grd.Rows.Add();
                    Grd.Rows[rowindex].Cells["ID"].Value = accounts[i].AccountNo;
                    Grd.Rows[rowindex].Cells["Vendor"].Value = accounts[i].AccountName;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "PopulateVendors()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            SetReport("w");
        }
        private void SetWhere()
        {
            try
            {
               

                if (cmbBranch.Text.Trim().Length != 0)
                {
                    BranchID = Convert.ToInt32(cmbBranch.SelectedValue);
                }

                if (rdbAllDates.Checked)
                {
                   
                    fromDate = "1/1/2020";
                    toDate = "1/1/2050";
                }
                else if (this.rdbDateRange.Checked)
                {
                  
                    fromDate = this.dtpFrom.Value.Date.ToString("yyyy-MM-dd 00:00:00");
                    toDate = this.dtpTo.Value.Date.ToString("yyyy-MM-dd 00:00:00");
                }
                //else if (this.rdbADay.Checked)
                //{
                //    where += " and PIn.PurchaseDate between '" + this.dtpADay.Value.Date.ToString("yyyy-MM-dd 00:00:00") + "' and '" + this.dtpADay.Value.Date.ToString("yyyy-MM-dd 00:00:00") + "'";
                //    fromDate = this.dtpADay.Value.Date.ToShortDateString();
                //    toDate = this.dtpADay.Value.Date.ToShortDateString();
                //}
                //else if (this.rdbToday.Checked)
                //{
                //    where += " and PIn.PurchaseDate between '" + System.DateTime.Now.Date.ToString("yyyy-MM-dd 00:00:00") + "' and '" + System.DateTime.Now.Date.ToString("yyyy-MM-dd 00:00:00") + "'";
                //    fromDate = System.DateTime.Now.Date.ToShortDateString();
                //    toDate = System.DateTime.Now.Date.ToShortDateString();
                //}

                //Set Condition for Party.
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmCurrentStock SetReport", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetReport(string v)
        {
            try
            {
                BranchID = 0;
                Restorant_Management_System.Report_Forms.frmViewer frmViwer = new Restorant_Management_System.Report_Forms.frmViewer();
                DataTable dt = new DataTable();            
                SetWhere();
               

                if (ValuationType == "Sale")
                {
                    vendors.Clear();
                    if (!chkAllVendor.Checked)
                    {
                        FetchVendors();
                    }
                   List<Branch> counters = new BranchController().GetBranch("  where IsWarehouse=0  ");
            
                    
                    Common.Data_Sets.DSValuationSale dSValuationSale = new Common.Data_Sets.DSValuationSale();

                    if (new SaleInvoiceController().GetValuationSale(ref dSValuationSale, fromDate, toDate, BranchID, counters, vendors))
                    {
                        if (dSValuationSale.Tables["SPValuationSale"].Rows.Count > 0)
                        {

                            ReportDataSource rds = new ReportDataSource("DataSet1", dSValuationSale.Tables["SPValuationSale"]);
                            frmViwer.reportViewer1.LocalReport.DataSources.Add(rds);

                            // frmViwer.reportViewer1.LocalReport.ReportPath = "../../Report/RptPurchaseRegister.rdlc";
                            frmViwer.reportViewer1.LocalReport.ReportPath = Globals.ReportPath + "/Report/RptValuationSale.rdlc";
                            string paraBranch = "All Branches";
                            if(cmbBranch.Text.Trim().Length > 0)
                            {
                                paraBranch = cmbBranch.Text;
                            }
                            ReportParameter[] rptParams = new ReportParameter[]
                                {
                                new ReportParameter("DateRange"," From:  "+fromDate+"  To:  "+toDate+""),
                                new ReportParameter("Branch",paraBranch),
                                 
                                };
                            frmViwer.reportViewer1.LocalReport.SetParameters(rptParams);

                            frmViwer.ShowDialog();

                        }
                        else
                        {
                            MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }
                else if(ValuationType== "Inventory")
                {
                    Common.Data_Sets.DSInventoryValuation dSInventory = new Common.Data_Sets.DSInventoryValuation();
                    if (new SaleInvoiceController().GetInventoryValuation(ref dSInventory, fromDate, toDate, BranchID))
                    {
                        if (dSInventory.Tables["SPInventoryValuation"].Rows.Count > 0)
                        {

                            ReportDataSource rds = new ReportDataSource("DataSet1", dSInventory.Tables["SPInventoryValuation"]);
                            frmViwer.reportViewer1.LocalReport.DataSources.Add(rds);
                            // frmViwer.reportViewer1.LocalReport.ReportPath = "../../Report/RptPurchaseRegister.rdlc";
                            frmViwer.reportViewer1.LocalReport.ReportPath = Globals.ReportPath + "/Report/RptInventoryValuation.rdlc";
                            ReportParameter[] rptParams = new ReportParameter[]
                                {
                                new ReportParameter("DateRange"," From:  "+fromDate+"  To:  "+toDate+""),
                                new ReportParameter("Branch",cmbBranch.Text),
                                };
                            frmViwer.reportViewer1.LocalReport.SetParameters(rptParams);

                            frmViwer.ShowDialog();

                        }
                        else
                        {
                            MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (ValuationType == "CCSaleSummary")
                {
                    int branchid = 0;
                    string bank = "";
                    if (cmbBranch.Text.Trim().Length > 0)
                    {
                        branchid=Convert.ToInt32(cmbBranch.SelectedValue);
                    }
                    if (cmbBank.Text.Trim().Length > 0)
                    {
                        bank = Convert.ToString(cmbBank.SelectedValue);
                    }



                    Common.Data_Sets.DSCCSaleSummary dSCC = new Common.Data_Sets.DSCCSaleSummary();
                    if (new SaleInvoiceController().GetCCSaleSummary(ref dSCC, fromDate, toDate, branchid, bank))
                    {
                        if (dSCC.Tables["CCSaleSummary"].Rows.Count > 0)
                        {

                            ReportDataSource rds = new ReportDataSource("DataSet1", dSCC.Tables["CCSaleSummary"]);
                            frmViwer.reportViewer1.LocalReport.DataSources.Add(rds);
                            // frmViwer.reportViewer1.LocalReport.ReportPath = "../../Report/RptPurchaseRegister.rdlc";
                            frmViwer.reportViewer1.LocalReport.ReportPath = Globals.ReportPath + "/Report/RptCCSaleSummary.rdlc";
                            ReportParameter[] rptParams = new ReportParameter[]
                                {
                                new ReportParameter("DateRange"," From:  "+fromDate+"  To:  "+toDate+""),
                              new ReportParameter("PrintedBy", User._UserName ),
                                };
                            frmViwer.reportViewer1.LocalReport.SetParameters(rptParams);

                            frmViwer.ShowDialog();

                        }
                        else
                        {
                            MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (ValuationType == "DiscountOffers")
                {
                    int brnachid = 0;
                    if (cmbBranch.Text.Trim().Length != 0)
                    {
                        brnachid = Convert.ToInt32(cmbBranch.SelectedValue);
                    }
                    ////////////////////////////
                    if (rdbDiscount.Checked)
                    {
                        Common.Data_Sets.DSOffers dSOffers = new Common.Data_Sets.DSOffers();
                        if (new DiscountOfferController().GetOffers(ref dSOffers, brnachid, fromDate , toDate  ))
                        {
                            Report_Forms.frmViewer Viewer = new Report_Forms.frmViewer();
                            Viewer.reportViewer1.Reset();

                            if (dSOffers.Tables["SPOffers"].Rows.Count > 0)
                            {
                                ReportDataSource rds = new ReportDataSource("DataSet1", dSOffers.Tables["SPOffers"]);
                                Viewer.reportViewer1.LocalReport.DataSources.Add(rds);
                                Viewer.reportViewer1.LocalReport.ReportPath = Globals.ReportPath + "/Report/RptDiscountOffers.rdlc";
                                Viewer.reportViewer1.LocalReport.Refresh();
                                ReportParameter[] rptParams = new ReportParameter[]
                                {
                                new ReportParameter("CurrentDate"," From:  "+fromDate+"  To:  "+toDate+""),
                                new ReportParameter("PrintedBy",User._UserName  ),

                                };
                                Viewer.reportViewer1.LocalReport.SetParameters(rptParams);
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
                    /////////////////////////////
                    else
                    {
                        Common.Data_Sets.DSItems dSItems = new Common.Data_Sets.DSItems();
                        if (new DiscountOfferController().GetItemsWithoutDiscount(ref dSItems, brnachid))
                        {
                            Report_Forms.frmViewer Viewer = new Report_Forms.frmViewer();
                            Viewer.reportViewer1.Reset();

                            if (dSItems.Tables["SPItems"].Rows.Count > 0)
                            {
                                ReportDataSource rds = new ReportDataSource("DataSet1", dSItems.Tables["SPItems"]);
                                Viewer.reportViewer1.LocalReport.DataSources.Add(rds);
                                Viewer.reportViewer1.LocalReport.ReportPath = Globals.ReportPath + "/Report/RptBarcodesWithoutDisc.rdlc";
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
                      
                        
                   
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmCurrentStock SetReport", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FetchVendors()
        {
        
            for (int i=0;i < Grd.Rows.Count-1;i++)
            {
                if (Convert.ToBoolean(Grd.Rows[i].Cells["Chkbox"].Value) && Grd.Rows[i].Cells["ID"].Value.ToString().Trim().Length > 0 )
                {
                    ChartOfAccounts v = new ChartOfAccounts();
                    v.AccountNo = Grd.Rows[i].Cells["ID"].Value.ToString();
                    v.AccountName = Grd.Rows[i].Cells["Vendor"].Value.ToString();
                    vendors.Add(v);
                }
            }
        }

        private void rdbAllDates_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rdbAllDates.Checked == true)
                {
                    this.rdbDateRange.Checked = false;
                    this.gbDateRange.Visible = false;

                    this.rdbADay.Checked = false;
                    this.gbADay.Visible = false;

                    this.rdbToday.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmSaleRegister AllDates_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbDateRange_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rdbDateRange.Checked == true)
                {
                    this.gbDateRange.Visible = true;
                    this.rdbAllDates.Checked = false;

                    this.rdbADay.Checked = false;
                    this.gbADay.Visible = false;

                    this.rdbToday.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmSaleRegister DateRange_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

       

        private void btnAllParties_Click(object sender, EventArgs e)
        {
          
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllVendor.Checked)
            {
                Grd.ReadOnly = true;
            }
            else
                Grd.ReadOnly = false;
        }
    }
}

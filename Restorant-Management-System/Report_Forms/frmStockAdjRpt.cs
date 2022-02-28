using Accounts.SchForms;
using Common;
using CategoryControlle;
using Microsoft.Reporting.WinForms;
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

namespace Restorant_Management_System.Report_Forms
{
    public partial class frmStockAdjRpt : Form
    {
        private List<Purchase> purchases;
        private List<PurchaseReturn> purchaseReturns;

        private List<SaleInvoice> sales;
        private List<SaleInvoice> saleReturns;

        string fromDate;
        string toDate;
        public string LedgerType = "";

        public bool IsItemLedger = false;
        public frmStockAdjRpt()
        {
            InitializeComponent();
        }

        private void frmStockAdjRpt_Load(object sender, EventArgs e)
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

        private void ClearControls()
        {
            try
            {
                txtItemID.Clear();
                txtItemName.Clear();

                this.rdbAllDates.Checked = true;
                this.rdbDateRange.Checked = false;
                this.rdbADay.Checked = false;
                this.rdbToday.Checked = false;

                this.gbDateRange.Visible = false;
                this.gbADay.Visible = false;
                cmbBranch.Visible = true;
                lblBranch.Visible = true;

                List<Branch> counters = new BranchController().GetBranch("  where 1=1  ");
                cmbBranch.DataSource = counters;
                cmbBranch.ValueMember = "ID";
                cmbBranch.DisplayMember = "BranchName";
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmCurrentStock ClearControls", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetReport(string p)
        {
            try
            {
                Common.Data_Sets.DSItemLedger dsItemLedger = new Common.Data_Sets.DSItemLedger();
                Common.Data_Sets.DSStockAdj dsStockAdj = new Common.Data_Sets.DSStockAdj();
                this.txtItemID.Focus();
                DataTable dt = new DataTable();
                Restorant_Management_System.Report_Forms.frmViewer frmViwer = new Restorant_Management_System.Report_Forms.frmViewer();
                //Set Condition for Date.
                if (this.rdbAllDates.Checked)
                {
                    fromDate = "1/1/2019";
                    toDate = "1/1/2040";
                }
                else if (this.rdbDateRange.Checked)
                {
                    fromDate = this.dtpFrom.Value.Date.ToShortDateString();
                    toDate = this.dtpTo.Value.Date.ToShortDateString();
                }
                else if (this.rdbADay.Checked)
                {
                    fromDate = this.dtpADay.Value.Date.ToShortDateString();
                    toDate = this.dtpADay.Value.Date.ToShortDateString();
                }
                else if (this.rdbToday.Checked)
                {
                    fromDate = System.DateTime.Now.Date.ToShortDateString();
                    toDate = System.DateTime.Now.Date.ToShortDateString();
                }
                if (IsItemLedger) 
                {
                    int itemid = 0;
                    if (txtItemID.Text.Trim().Length > 0)
                    {
                        itemid = Convert.ToInt32(this.txtItemID.Text);
                    }

                    if (new ItemLedgerController().GetData(ref dsItemLedger, itemid, fromDate, toDate,Convert.ToInt32(cmbBranch.SelectedValue),LedgerType))
                    {
                        
                        if (dsItemLedger.Tables["ItemLedger"].Rows.Count > 0)
                        {
                            


                            ReportDataSource rds = new ReportDataSource("DataSet1", dsItemLedger.Tables["ItemLedger"]);
                            frmViwer.reportViewer1.LocalReport.DataSources.Add(rds);
                            if (LedgerType == "Branch")
                            {

                                frmViwer.reportViewer1.LocalReport.ReportEmbeddedResource = "Restorant_Management_System.Report.RptItemLedger.rdlc";
                               
                            }
                            else
                            {
                                frmViwer.reportViewer1.LocalReport.ReportEmbeddedResource = "Restorant_Management_System.Report.RptItemLadgerCombined.rdlc";

                            }

                         
                            if (p == "w")
                            {
                                frmViwer.reportViewer1.LocalReport.Refresh();
                                frmViwer.ShowDialog();
                            }
                        }
                        else
                        {
                            MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        
                    }
                    else
                    {
                        if (new StockAdjRptController().GetData(ref dsStockAdj, Convert.ToInt32(this.txtItemID.Text.Trim().Length == 0 ? "0" : this.txtItemID.Text.Trim()), fromDate, toDate))
                        {
                            if (dsStockAdj.Tables["StockAdj"].Rows.Count > 0)
                            {
                                dt = dsStockAdj.Tables["StockAdj"];
                                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                                frmViwer.reportViewer1.LocalReport.DataSources.Add(rds);
                                //frmViwer.reportViewer1.LocalReport.ReportPath = "../../Report/RptStockAdj.rdlc";
                                frmViwer.reportViewer1.LocalReport.ReportEmbeddedResource = "Restorant_Management_System.Report.RptStockAdj.rdlc";

                                if (p == "w")
                                {
                                    frmViwer.ShowDialog();
                                }
                                //  else
                                //   frmViwer.crystalReportViewer1.PrintReport();
                            }
                            else
                                MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmCurrentStock SetReport", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void rdbADay_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rdbADay.Checked == true)
                {
                    this.rdbAllDates.Checked = false;

                    this.gbDateRange.Visible = false;
                    this.rdbDateRange.Checked = false;

                    this.rdbToday.Checked = false;

                    this.gbADay.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmSaleRegister ADay_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbToday_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rdbToday.Checked == true)
                {
                    this.rdbDateRange.Checked = false;
                    this.gbDateRange.Visible = false;

                    this.rdbADay.Checked = false;
                    this.gbADay.Visible = false;

                    this.rdbAllDates.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmSaleRegister ToDay_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSch_Click(object sender, EventArgs e)
        {
            Accounts.SchForms.SchItems sch = new Accounts.SchForms.SchItems();
           
            sch.ShowDialog();
            if (sch.subList1.Count > 0)
            {
                txtItemID.Text = sch.subList1[0].ItemID.ToString();
                txtItemName.Text = sch.subList1[0].ItemName.ToString();
            }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            SetReport("p");
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            SetReport("w");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
    }
}

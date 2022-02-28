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
using CommonController;

namespace Restorant_Management_System.Report_Forms
{
    public partial class frmRegisterInvoice : Form
    {
        public string type = "";
        private List<Purchase> purchases;
     //   Reports.CrpPurchaseRegister crp = new PointOfSale.Reports.CrpPurchaseRegister();
      //  Report_Forms.FrmReportViewer frmViewer = new PointOfSale.Report_Forms.FrmReportViewer();

        Common.Data_Sets.DSPurchaseRegister dsPurchaseReg = new Common.Data_Sets.DSPurchaseRegister();
        public bool isReceivedChallan;
      
        int supvervisorID = 0;

        string wCancel = "";

        public bool isPending = false;
        public bool isCancelled = false;
        private string fromDate;
        string where = "";
        private string toDate;

       
        private string itemFilter;

        public bool isHot;
        public bool isCold;

        public frmRegisterInvoice()
        {
            InitializeComponent();
        }

        private void frmRegisterInvoice_Load(object sender, EventArgs e)
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
        private void LoadCategory()
        {
            try
            {
                this.cmbCategory.DataSource = new CategoryController().GetCategories();
                this.cmbCategory.DisplayMember = "Name";
                this.cmbCategory.ValueMember = "Id";

             

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmItem LoadCategory");
            }
        }
       
        
        private void LoadProductName(string company)
        {
            try
            {
                this.cmbProductName.DataSource = new ItemController().GetProductNames("", false);

               

                this.cmbProductName.SelectedIndex = -1;
                this.cmbProductName.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmItem LoadProductName");
            }
        }
        
       
        private void ClearControls()
        {
            try
            {
                   LoadCategory();

             
                 LoadCompanyName();

                 LoadProductName("");
             

                this.txtItemID.Clear();
           

                this.rdbAllDates.Checked = true;
                this.rdbDateRange.Checked = false;
                this.rdbADay.Checked = false;
                this.rdbToday.Checked = false;

                this.gbDateRange.Visible = false;
                this.gbADay.Visible = false;

                this.txtPartyID.Clear();
                this.PnlMain.Text = "All Parties";
          
                this.cmbCategory.Focus();

                LoadBranches();

                if (type== "SaleRegister")
                {
                  
                    gbPartyDetails.Visible = false;
                    lblBranch.Visible = true;
                    cmbBranch.Visible = true;
                    grpProductDetail.Visible = true;
                    gbPartyDetails.Visible = true;

                }
              
               
                else if (type == "PurchaseRegister")
                {
                    lblBranch.Visible = true;
                    cmbBranch.Visible = true;
                    grpProductDetail.Visible = true;
                  
                }
                else if (type == "PurchaseReturnRegister")
                {
                    grpProductDetail.Visible = true;

                    lblBranch.Visible = true;
                    cmbBranch.Visible = true;
                }
                else if (type == "SaleReturnRegister")
                {
                    grpProductDetail.Visible = true;
                    lblBranch.Visible = true;
                    cmbBranch.Visible = true;
                }


                else if (type == "ChallanRegister")
                {
                    gbPartyDetails.Visible = false;
                    cmbBranch.Visible = false;
                    grpProductDetail.Visible = true;                
                    grpProductDetail.Visible = false;
                }
              
             
             
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmCurrentStock ClearControls()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCompanyName()
        {
            try
            {
                this.cmbProductName.DataSource = new ItemController().GetCompanyNames(0, false);

           
                this.cmbProductName.SelectedIndex = -1;
                this.cmbProductName.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmItem LoadProductName");
            }
        }

        void LoadBranches()
        {
            List<Branch> counters = new BranchController().GetBranch("  where 1=1  ");
            cmbBranch.DataSource = counters;
            cmbBranch.ValueMember = "ID";
            cmbBranch.DisplayMember = "BranchName";
           
        }
        private void ShowSearch(ref System.Windows.Forms.TextBox txtno, ref System.Windows.Forms.TextBox txtname)
        {
            try
            {
                SchAccounts Sch = new SchAccounts();
                Sch.accountType = " and accountno like '6%'";
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
        private void SetWhere()
        {
            try
            {
                where = " where 1=1 ";

               
                if (cmbBranch.SelectedIndex > -1)
                {
                    where += " and  pin.BranchID=" + Convert.ToInt32(cmbBranch.SelectedValue)+"  ";
                }

               // Set Condition for Item.
                if (this.cmbCategory.SelectedValue != null)
                    {
                        if ((int)cmbCategory.SelectedValue > 0)
                        {
                            if (this.cmbCategory.Text.Trim().Length != 0)
                            {
                                where += " and IC.CategoryID=" + (this.cmbCategory.SelectedValue);
                            }
                        }
                    }
                    else
                        MessageBox.Show("Please Enter valid Category.", "Check Category...", MessageBoxButtons.OK, MessageBoxIcon.Information);


                if (cmbCompanyName.Text.Trim().Length != 0)
                {
                    where += " and I.CompanyName='" + this.cmbCompanyName.Text.Replace("'", "''") + "'";
                }
                if (cmbProductName.Text.Trim().Length != 0)
                {
                    where += " and I.ProductName='" + this.cmbProductName.Text.Replace("'", "''") + "'";
                }
               

                if (this.txtItemID.Text.Trim().Length != 0)
                {
                    where += " and I.ItemID=" + this.txtItemID.Text;
                }
                if (this.txtPartyID.Text.Trim().Length != 0)
                {
                    where += " and PIn.VendorID =" + this.txtPartyID.Text;
                }


                //Set Condition for Date.

                if (rdbAllDates.Checked)
                {
                    where += " and PIn.PurchaseDate between '1980/1/1' and '2050/1/1' ";
                    fromDate = "1/1/1980";
                    toDate = "1/1/2050";
                }
                else if (this.rdbDateRange.Checked)
                {
                    where += " and PIn.PurchaseDate between '" + this.dtpFrom.Value.Date.ToString("yyyy-MM-dd 00:00:00") +"' and '" + this.dtpTo.Value.Date.ToString("yyyy-MM-dd 00:00:00") +"' "; //string.Format("{MM/dd/yyyy 00:00:00}", this.dtpFrom.Value.Date)
                    fromDate = this.dtpFrom.Value.Date.ToShortDateString();
                    toDate = this.dtpTo.Value.Date.ToShortDateString();
                }
                else if (this.rdbADay.Checked)
                {
                    where += " and PIn.PurchaseDate between '" + this.dtpADay.Value.Date.ToString("yyyy-MM-dd 00:00:00") + "' and '" + this.dtpADay.Value.Date.ToString("yyyy-MM-dd 00:00:00") +"'";
                    fromDate = this.dtpADay.Value.Date.ToShortDateString();
                    toDate = this.dtpADay.Value.Date.ToShortDateString();
                }
                else if (this.rdbToday.Checked)
                {
                    where += " and PIn.PurchaseDate between '" + System.DateTime.Now.Date.ToString("yyyy-MM-dd 00:00:00") +"' and '" + System.DateTime.Now.Date.ToString("yyyy-MM-dd 00:00:00") +"'";
                    fromDate = System.DateTime.Now.Date.ToShortDateString();
                    toDate = System.DateTime.Now.Date.ToShortDateString();
                }

                //Set Condition for Party.
                if (this.txtPartyID.Text.Trim().Length != 0)
                {
                    where += " and P.PartyID=" + this.txtPartyID.Text;
                }

                wCancel = "";
                if (isCancelled)
                {
                    wCancel = " and IsCancelled=1";
                }
                else
                    wCancel = " and IsCancelled=0";
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmCurrentStock SetReport", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetWheresale()
        {
            try
            {
                where = " where 1=1  ";

                //Set Condition for Item.
                if (this.cmbCategory.SelectedValue != null)
                {
                    if ((int)cmbCategory.SelectedValue > 0)
                    {
                        if (this.cmbCategory.Text.Trim().Length != 0)
                        {
                            where += " and IC.CategoryID=" + (this.cmbCategory.SelectedValue);
                        }
                    }
                }
                else
                    MessageBox.Show("Please Enter valid Category.", "Check Category...", MessageBoxButtons.OK, MessageBoxIcon.Information);


                if (cmbCompanyName.Text.Trim().Length != 0)
                {
                    where += " and I.CompanyName='" + this.cmbCompanyName.Text.Replace("'", "''") + "'";
                }
                if (cmbProductName.Text.Trim().Length != 0)
                {
                    where += " and I.ProductName='" + this.cmbProductName.Text.Replace("'", "''") + "'";
                }
               

                if (this.txtItemID.Text.Trim().Length != 0)
                {
                    where += " and I.ItemID=" + this.txtItemID.Text;
                }
                
                if (cmbBranch.SelectedIndex > -1)
                {
                    where += " and si.branchid="+Convert.ToInt32(cmbBranch.SelectedValue)+"  ";
                }
                if (txtPartyID.Text.Trim().Length > 0 )
                {
                    where += " and si.supplierid='" + txtPartyID.Text.Trim() + "'  ";
                }


                //Set Condition for Date.

                if (rdbAllDates.Checked)
                {
                    where += " and si.saledate between '1980/1/1' and '2050/1/1' ";
                    fromDate = "1/1/1980";
                    toDate = "1/1/2050";
                }
                else if (this.rdbDateRange.Checked)
                {
                    where += " and si.saledate between '" + this.dtpFrom.Value.Date.ToString("yyyy-MM-dd 00:00:00") + "' and '" + this.dtpTo.Value.Date.ToString("yyyy-MM-dd 00:00:00") + "' "; //string.Format("{MM/dd/yyyy 00:00:00}", this.dtpFrom.Value.Date)
                    fromDate = this.dtpFrom.Value.Date.ToShortDateString();
                    toDate = this.dtpTo.Value.Date.ToShortDateString();
                }
                else if (this.rdbADay.Checked)
                {
                    where += " and si.saledate between '" + this.dtpADay.Value.Date.ToString("yyyy-MM-dd 00:00:00") + "' and '" + this.dtpADay.Value.Date.ToString("yyyy-MM-dd 00:00:00") + "'";
                    fromDate = this.dtpADay.Value.Date.ToShortDateString();
                    toDate = this.dtpADay.Value.Date.ToShortDateString();
                }
                else if (this.rdbToday.Checked)
                {
                    where += " and si.saledate between '" + System.DateTime.Now.Date.ToString("yyyy-MM-dd 00:00:00") + "' and '" + System.DateTime.Now.Date.ToString("yyyy-MM-dd 00:00:00") + "'";
                    fromDate = System.DateTime.Now.Date.ToShortDateString();
                    toDate = System.DateTime.Now.Date.ToShortDateString();
                }

                //Set Condition for Party.
                if (this.txtPartyID.Text.Trim().Length != 0)
                {
                    where += " and p.PartyID=" + this.txtPartyID.Text;
                }
                
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmCurrentStock SetReport", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetWhereWholesale()
        {
            try
            {
                where = " where 1=1  ";

                

                //Set Condition for Item.
                if (this.cmbCategory.SelectedValue != null)
                {
                    if ((int)cmbCategory.SelectedValue > 0)
                    {
                        if (this.cmbCategory.Text.Trim().Length != 0)
                        {
                            where += " and IC.CategoryID=" + (this.cmbCategory.SelectedValue);
                        }
                    }
                }
                else
                    MessageBox.Show("Please Enter valid Category.", "Check Category...", MessageBoxButtons.OK, MessageBoxIcon.Information);


                if (cmbCompanyName.Text.Trim().Length != 0)
                {
                    where += " and I.CompanyName='" + this.cmbCompanyName.Text.Replace("'", "''") + "'";
                }
                if (cmbProductName.Text.Trim().Length != 0)
                {
                    where += " and I.ProductName='" + this.cmbProductName.Text.Replace("'", "''") + "'";
                }
                

                if (this.txtItemID.Text.Trim().Length != 0)
                {
                    where = " and I.ItemID=" + this.txtItemID.Text;
                }
                
                //Set Condition for Date.

                if (rdbAllDates.Checked)
                {
                    where += " and wi.Dated between '1980/1/1' and '2050/1/1' ";
                    fromDate = "1/1/1980";
                    toDate = "1/1/2050";
                }
                else if (this.rdbDateRange.Checked)
                {
                    where += " and  wi.Dated  between '" + this.dtpFrom.Value.Date.ToString("yyyy-MM-dd 00:00:00") + "' and '" + this.dtpTo.Value.Date.ToString("yyyy-MM-dd 00:00:00") + "' "; //string.Format("{MM/dd/yyyy 00:00:00}", this.dtpFrom.Value.Date)
                    fromDate = this.dtpFrom.Value.Date.ToShortDateString();
                    toDate = this.dtpTo.Value.Date.ToShortDateString();
                }
                else if (this.rdbADay.Checked)
                {
                    where += " and  wi.Dated  between '" + this.dtpADay.Value.Date.ToString("yyyy-MM-dd 00:00:00") + "' and '" + this.dtpADay.Value.Date.ToString("yyyy-MM-dd 00:00:00") + "'";
                    fromDate = this.dtpADay.Value.Date.ToShortDateString();
                    toDate = this.dtpADay.Value.Date.ToShortDateString();
                }
                else if (this.rdbToday.Checked)
                {
                    where += " and  wi.Dated  between '" + System.DateTime.Now.Date.ToString("yyyy-MM-dd 00:00:00") + "' and '" + System.DateTime.Now.Date.ToString("yyyy-MM-dd 00:00:00") + "'";
                    fromDate = System.DateTime.Now.Date.ToShortDateString();
                    toDate = System.DateTime.Now.Date.ToShortDateString();
                }

                //Set Condition for Party.
                if (this.txtPartyID.Text.Trim().Length != 0)
                {
                    where += " and wi.BuyerID=" + this.txtPartyID.Text;
                }
                if (this.cmbBranch.Text.Trim().Length != 0)
                {
                    where += " and wi.Branchid=" + Convert.ToInt32(cmbBranch.SelectedValue);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmCurrentStock SetReport", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetItemFilter()
        {
            try
            {
                itemFilter = "";

                if (this.cmbCategory.SelectedValue != null)
                {
                    if ((int)cmbCategory.SelectedValue > 0)
                    {
                        if (this.cmbCategory.Text.Trim().Length != 0)
                        {
                            itemFilter += " and IC.CategoryID=" + (this.cmbCategory.SelectedValue);
                        }
                    }
                }
                else
                    MessageBox.Show("Please Enter valid Category.", "Check Category...", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (cmbCompanyName.Text.Trim().Length != 0)
                {
                    itemFilter += " and Item.CompanyName='" + this.cmbCompanyName.Text.Replace("'", "''") + "'";
                }
                if (cmbProductName.Text.Trim().Length != 0)
                {
                    itemFilter += " and Item.ProductName='" + this.cmbProductName.Text.Replace("'", "''") + "'";
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmCurrentStock SetItemFilter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetReport(string p)
        {
            try
            {
                
                
                Restorant_Management_System.Report_Forms.frmViewer frmViwer = new Restorant_Management_System.Report_Forms.frmViewer();
                DataTable dt = new DataTable();
                if (type == "PurchaseRegister")
                {
                    SetWhere();
                    Common.Data_Sets.DSPurchaseInvoice dsPurchaseReg = new Common.Data_Sets.DSPurchaseInvoice();
                    if (new PurchaseRegController().GetData(ref dsPurchaseReg, where))
                    {
                        if (dsPurchaseReg.Tables["SPPurchaseInvoice"].Rows.Count > 0)
                        {
                            dt = dsPurchaseReg.Tables["SPPurchaseInvoice"];
                            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                            frmViwer.reportViewer1.LocalReport.DataSources.Add(rds);
                            // frmViwer.reportViewer1.LocalReport.ReportPath = "../../Report/RptPurchaseRegister.rdlc";
                            frmViwer.reportViewer1.LocalReport.ReportEmbeddedResource = "Restorant_Management_System.Report.RptPurchaseInvoice.rdlc";
                            ReportParameter[] rptParams = new ReportParameter[]
                            {
                                     new ReportParameter("User",User._UserName),
                            };
                            frmViwer.reportViewer1.LocalReport.SetParameters(rptParams);
                            frmViwer.reportViewer1.LocalReport.Refresh();
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
                if (type == "VendorWInventory")
                {
             
                    Common.Data_Sets.DSVendorWInventory dSVendorWInventory = new Common.Data_Sets.DSVendorWInventory();
                    if (new PurchaseRegController().GetVWInventory(ref dSVendorWInventory, txtPartyID.Text.Trim()))
                    {
                        if (dSVendorWInventory.Tables["SPVendroWInventory"].Rows.Count > 0)
                        {
                            dt = dSVendorWInventory.Tables["SPVendroWInventory"];
                            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                            frmViwer.reportViewer1.LocalReport.DataSources.Add(rds);
                            // frmViwer.reportViewer1.LocalReport.ReportPath = "../../Report/RptPurchaseRegister.rdlc";
                            frmViwer.reportViewer1.LocalReport.ReportPath = Globals.ReportPath + "/Report/RptVendorWInventory.rdlc";

                            if (p == "w")
                            {
                                frmViwer.ShowDialog();
                            }
                            //   else
                            //    frmViewer.crystalReportViewer1.PrintReport();
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
                else if (type == "PurchaseReturnRegister")
                {
                    SetWhereReturn();
                    where += "  and ci.type='PR' ";
                    //  Reports.CrpPurchaseReturnReg crp = new PointOfSale.Reports.CrpPurchaseReturnReg();
                    Common.Data_Sets.DSClaim dSPurchaseReturn = new Common.Data_Sets.DSClaim();
                    if (new ClaimInvoiceController().GetReportData(ref dSPurchaseReturn, where, ClaimInvoiceType.PR))
                    {
                        if (dSPurchaseReturn.Tables["SPClaim"].Rows.Count > 0)
                        {
                            Report_Forms.frmViewer Viewer = new Report_Forms.frmViewer();
                            Viewer.reportViewer1.Reset();

                            if (dSPurchaseReturn.Tables["SPClaim"].Rows.Count > 0)
                            {
                                ReportDataSource rds = new ReportDataSource("DataSet1", dSPurchaseReturn.Tables["SPClaim"]);
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
                else if (type == "SaleRegister")
                {
                    SetWheresale();
                    Common.Data_Sets.DSSaleRegister dsSaleReg = new Common.Data_Sets.DSSaleRegister();
                    dsSaleReg = new Common.Data_Sets.DSSaleRegister();

                   
                    if (new SaleRegController().GetData(ref dsSaleReg, where))
                    {
                        if (dsSaleReg.Tables["SPSaleInvoice"].Rows.Count > 0)
                        {
                            
                            dt = dsSaleReg.Tables["SPSaleInvoice"];
                            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                            frmViwer.reportViewer1.LocalReport.DataSources.Add(rds);
                            frmViwer.reportViewer1.LocalReport.ReportEmbeddedResource = "Restorant_Management_System.Report.RptSaleInvoice.rdlc";                 
                           
                            ReportParameter[] rptParams = new ReportParameter[]
                            {
                                new ReportParameter("Username",User._UserName),
                            };
                          
                            frmViwer.reportViewer1.LocalReport.SetParameters(rptParams);
                            frmViwer.reportViewer1.LocalReport.Refresh();
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
                else if (type == "SaleReturnRegister")
                {
                    SetWhereReturn();
                    where += "  and ci.type='SR' ";
                    //  Reports.CrpPurchaseReturnReg crp = new PointOfSale.Reports.CrpPurchaseReturnReg();
                    Common.Data_Sets.DSClaim dSPurchaseReturn = new Common.Data_Sets.DSClaim();
                    if (new ClaimInvoiceController().GetReportData(ref dSPurchaseReturn, where, ClaimInvoiceType.SR))
                    {
                        if (dSPurchaseReturn.Tables["SPClaim"].Rows.Count > 0)
                        {
                            Report_Forms.frmViewer Viewer = new Report_Forms.frmViewer();
                            Viewer.reportViewer1.Reset();

                            if (dSPurchaseReturn.Tables["SPClaim"].Rows.Count > 0)
                            {
                                ReportDataSource rds = new ReportDataSource("DataSet1", dSPurchaseReturn.Tables["SPClaim"]);
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
                else if (type == "WholesaleRegister")
                {
                    SetWhereWholesale();
                    Common.Data_Sets.DSWholeSale dSWhole = new Common.Data_Sets.DSWholeSale();
                


                    if (new WholesaleController().GetWSData(ref dSWhole, where))
                    {
                        if (dSWhole.Tables["SPWholeSale"].Rows.Count > 0)
                        {
                                                  
                            dt = dSWhole.Tables["SPWholeSale"];
                            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                            frmViwer.reportViewer1.LocalReport.DataSources.Add(rds);
                            frmViwer.reportViewer1.LocalReport.ReportPath = Globals.ReportPath + "/Report/RptWholeSale.rdlc";
                            ReportParameter[] rptParams = new ReportParameter[]
                                            {
                                                    new ReportParameter("Username",User._UserName),
                                                          new ReportParameter("IsRegister",true.ToString()),

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
                else if (type == "ChallanRegister")
                {
                    string where = " where 1=1 and  c.Received="+Convert.ToInt16(isReceivedChallan)+"  ";
                    //if(cmbBranch.Text.Trim().Length > 0)
                    //{
                    //    where += " and cb.BranchID="+Convert.ToInt32(cmbBranch.SelectedValue)+" ";
                    //}
                    //else if (txtItemID.Text.Trim().Length != 0)
                    //{
                    //    where += " and cb.Itemid="+Convert.ToInt32(txtItemID.Text)+" ";
                    //}
                   
                    Common.Data_Sets.DsChallan dsChallan = new Common.Data_Sets.DsChallan();
                    if (new ChallanController().GetChallanData(ref dsChallan, 0, where,0))
                    {

                        Report_Forms.frmViewer Viewer = new Report_Forms.frmViewer();
                        Viewer.reportViewer1.Reset();

                        if (dsChallan.Tables["DsChallan"].Rows.Count > 0)
                        {
                            ReportDataSource rds = new ReportDataSource("DataSet1", dsChallan.Tables["DsChallan"]);
                            Viewer.reportViewer1.LocalReport.DataSources.Add(rds);

                            // Viewer.reportViewer1.LocalReport.ReportPath = "../../Report/RptChallan.rdlc";
                            Viewer.reportViewer1.LocalReport.ReportEmbeddedResource = "Restorant_Management_System.Report.RptChallan.rdlc";
                            ReportParameter[] rptParams = new ReportParameter[]
                                           {
                                                    new ReportParameter("User",User._UserName),
                                                      new ReportParameter("Header","Delivery Challan Regsiter"),
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
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmCurrentStock SetReport", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetWhereReturn()
        {
            try
            {
                where = " where 1=1 ";

                //Set Condition for Supervisor.
               

               // Set Condition for Item.
                if (this.cmbCategory.SelectedValue != null)
                {
                    if ((int)cmbCategory.SelectedValue > 0)
                    {
                        if (this.cmbCategory.Text.Trim().Length != 0)
                        {
                            where += " and IC.CategoryID=" + (this.cmbCategory.SelectedValue);
                        }
                    }
                }
                else
                    MessageBox.Show("Please Enter valid Category.", "Check Category...", MessageBoxButtons.OK, MessageBoxIcon.Information);


                if (cmbCompanyName.Text.Trim().Length != 0)
                {
                    where += " and I.CompanyName='" + this.cmbCompanyName.Text.Replace("'", "''") + "'";
                }
                if (cmbProductName.Text.Trim().Length != 0)
                {
                    where += " and I.ProductName='" + this.cmbProductName.Text.Replace("'", "''") + "'";
                }
                

                if (this.txtItemID.Text.Trim().Length != 0)
                {
                    where += " and I.ItemID=" + this.txtItemID.Text;
                }
                if (this.txtPartyID.Text.Trim().Length != 0)
                {
                    where += " and ci.partyid=" + this.txtPartyID.Text;
                }

                //Set Condition for Date.

                if (rdbAllDates.Checked)
                {
                    where += " and ci.Dated between '1980/1/1' and '2050/1/1' ";
                    fromDate = "1/1/1980";
                    toDate = "1/1/2050";
                }
                else if (this.rdbDateRange.Checked)
                {
                    where += " and  ci.Dated between '" + this.dtpFrom.Value.Date.ToString("yyyy-MM-dd 00:00:00") + "' and '" + this.dtpTo.Value.Date.ToString("yyyy-MM-dd 00:00:00") + "' "; //string.Format("{MM/dd/yyyy 00:00:00}", this.dtpFrom.Value.Date)
                    fromDate = this.dtpFrom.Value.Date.ToShortDateString();
                    toDate = this.dtpTo.Value.Date.ToShortDateString();
                }
                else if (this.rdbADay.Checked)
                {
                    where += " and  ci.Dated between '" + this.dtpADay.Value.Date.ToString("yyyy-MM-dd 00:00:00") + "' and '" + this.dtpADay.Value.Date.ToString("yyyy-MM-dd 00:00:00") + "'";
                    fromDate = this.dtpADay.Value.Date.ToShortDateString();
                    toDate = this.dtpADay.Value.Date.ToShortDateString();
                }
                else if (this.rdbToday.Checked)
                {
                    where += " and  ci.Dated between '" + System.DateTime.Now.Date.ToString("yyyy-MM-dd 00:00:00") + "' and '" + System.DateTime.Now.Date.ToString("yyyy-MM-dd 00:00:00") + "'";
                    fromDate = System.DateTime.Now.Date.ToShortDateString();
                    toDate = System.DateTime.Now.Date.ToShortDateString();
                }

                //Set Condition for Party.
                if (this.txtPartyID.Text.Trim().Length != 0)
                {
                    where += " and p.PartyID=" + this.txtPartyID.Text;
                }

             
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmCurrentStock SetReport", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCategory_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    System.Windows.Forms.SendKeys.Send("\t");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmCurrentStock cbxCategory_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                ShowSearch(ref this.txtPartyID, ref this.txtPartName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmSaleRegister btnSch_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAllParties_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtPartyID.Clear();
                this.txtPartName.Text = "All Parties";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmSaleRegister btnAllParties_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPartyID_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (this.txtPartyID.Text.ToString().Trim().Length == 0) return;
                VerifyAcc(ref this.txtPartyID, ref this.txtPartName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmCurrentStock txtPartyID_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPartyID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    ShowSearch(ref this.txtPartyID, ref this.txtPartName);
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    System.Windows.Forms.SendKeys.Send("\t");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmCurrentStock txtPartyID_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                //if (typeof(System.Int32) == cmbCategory.SelectedValue.GetType())
                //{
                //    if ((int)cmbCategory.SelectedValue >= 0)
                //    {
                //        LoadCompanyName((int)cmbCategory.SelectedValue);
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmItem cbxCategory_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCompanyName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadProductName(this.cmbCompanyName.Text.Replace("'", "''"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmItem cbxCompany_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
              //  LoadDesign(this.cmbProductName.Text.Replace("'", "''"), this.cmbCompanyName.Text.Replace("'", "''"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmItem cbxProduct_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbDesign_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ///LoadSize(this.cmbDesign.Text.Replace("'", "''"), this.cmbProductName.Text, this.cmbCompanyName.Text.Replace("'", "''"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmItem cbxDesign_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}

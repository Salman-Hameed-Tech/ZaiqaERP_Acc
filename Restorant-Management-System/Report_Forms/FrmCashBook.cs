using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using CategoryControlle;
//using CrystalDecisions.CrystalReports.Engine;
using Microsoft.Reporting.WinForms;
using Restorant_Management_System.Report_Forms;
using System.IO;

namespace Accounts
{
    public partial class FrmCahBook : Form
    {       
        private string fromDate;
        private string toDate;

        public bool IsDepAtt;
        public bool IsStkBalance;
        public bool isCashBook;
        public bool isGeneral;
        public bool isTrial;
        public bool isPay;
        public bool isRec;
        public bool isIncome;
        public bool isIncStmt;
        public bool isBal;
        public bool IsGTrial;
        public bool IsRRegister;
        public bool IsSvcIncStmnt;
        public bool IsIncomeStmntFirst;
        //Reports.rptCashBook crp;
        //Reports.rptCashInHand crp1;
        //Reports.rptGeneralJournal crpGeneral;
        //Reports.rptTrialBalance crpTrial;
        //Reports.RptGTrialBalance crpGTrial;
        //Reports.rptProfitandLoss crpIncome;
        //Reports.rptAccountsPayable crpPayable;
        //Accounts.Reports.CrpPayableGraph crpPayable;
        //Reports.rptAccountsPayablePO crpPayablePO;
        //Reports.rptAccountsReceiveable crpReceiveable;
        //Reports.rptAccountsReceiveableDO crpReceiveableDO;
        //Reports.CrpBalanceSheet  crpBalanceSheet;

       

        public FrmCahBook()
        {
            InitializeComponent();
        }

        private void FrmCurrentStock_Load(object sender, EventArgs e)
        {
            try
            {
                grpParty.Visible = false;  
                rdbCashInHand.Visible = false;
                rdbCashBook.Checked = true;
               // FrmCurrentStock_Fill_Panel.BackColor = AccountsGlobals.FormColor;
                if (this.isCashBook || this.isTrial || this.isPay || this.isRec || this.isIncome || this.isBal || this.IsStkBalance || this.IsRRegister || this.isIncStmt || this.IsSvcIncStmnt || this.IsIncomeStmntFirst)
                {
                    

                    if (this.isCashBook)
                    {
                        grpFormats.Visible = false ;
                        lblVoucherType.Visible = false;
                        cmbVoucherType.Visible = false ;
                        label1.Visible = false;
                        cmbType.Visible = false;
                        grpFilterBranch.Visible = false;
                    }

                    if (this.isTrial)
                    {                       
                        this.Text = "Trial Balance Report...";
                        grpFilterBranch.Visible = false;
                    }
                    else if (this.isPay)
                    {
                        //chkLevel.Visible = true;
                        this.Text = "Payable Report...";
                        grpFilterBranch.Visible = false;
                    }
                    else if (this.isRec)
                    {
                       // chkLevel.Visible = true;
                        this.Text = "Receiveable Report...";
                        grpFilterBranch.Visible = false;
                    }
                    else if (this.isIncome)
                    {
                        this.Text = "Income Statement Report...";
                        grpFilterBranch.Visible = false;
                    }
                    else if (this.IsSvcIncStmnt) 
                    {
                        this.Text = "Service Income Statement Report...";
                        grpFilterBranch.Visible = false;
                    }
                    else if (this.IsIncomeStmntFirst) 
                    {
                        this.Text = "First Income Statement Report...";
                        grpFilterBranch.Visible = false;
                    }
                    else if (this.isIncStmt)
                    {
                        this.Text = "Income Statement Report...";
                        grpFilterBranch.Visible = false;
                    }
                    else if (this.isBal)
                    {
                        this.Text = "Balance Sheet Report...";
                        grpFilterBranch.Visible = false;
                    }
                    else if (this.IsStkBalance)
                    {
                        this.Text = " Stock Balances";
                        grpFilterBranch.Visible = false;
                    }
                    else if (this.IsRRegister)
                    {
                        this.Text = "Receipe Register";
                        grpFilterBranch.Visible = false;
                    }
                    
                }
                else if (this.isGeneral)
                {
                    this.Text = "General Journal Report...";
                    grpParty.Visible = true;  
                    //lblVoucherType.Visible = true;
                    //cmbVoucherType.Visible = true;
                    
                    grpFilterBranch.Visible = true;

                }
                else if (this.IsDepAtt)
                {
                    this.Text = "Dept. Wise Attendance";
                    grpFilterBranch.Visible = false;
                }
                

                ClearControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"FrmCurrentStock_Load",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void LoadBranch()
        {
            List<Branch> counters = new BranchController().GetBranch(" where 1=1 ");
            cmbBranch.DataSource = counters;
            cmbBranch.ValueMember = "ID";
            cmbBranch.DisplayMember = "BranchName";
            cmbBranch.SelectedValue = Globals.BranchID;
          
        }

        private void LoadVoucherType()
        {
            try
            {
              
                List<VoucherType> list = new List<VoucherType>();
                list.Add(VoucherType.All );
                list.Add(VoucherType.CRV);
                list.Add(VoucherType.CPV);
                list.Add(VoucherType.JV);
                list.Add(VoucherType.BPV);
                list.Add(VoucherType.BRV);
                list.Add(VoucherType.BCV);
                list.Add(VoucherType.BDV);
                list.Add(VoucherType.LPJ);
                list.Add(VoucherType.PRV);
                list.Add(VoucherType.SJV);
                list.Add(VoucherType.SRV);
                list.Add(VoucherType.POS);
                cmbType.DataSource = list;


                cmbType.DataSource = list;

                this.cmbType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmCurrentStock LoadVoucherType()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadPAcc()
        {
            try
            {
                lblVoucherType.Visible = true;
                lblVoucherType.Text = "Account Name";
                cmbVoucherType.Visible = true;
                List<ChartOfAccounts> lstacc = new List<ChartOfAccounts>();
                if (IsStkBalance)
                {
                    lstacc = new ChartofAccountsController().GetPAcc(1);
                }
                else
                {
                    lstacc = new ChartofAccountsController().GetPAcc(0);
                }
                cmbVoucherType.DataSource = lstacc;
                cmbVoucherType.DisplayMember = "AccountName";
                cmbVoucherType.ValueMember = "Accountno";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool LoadCategory()
        {
            try
            {
                List<Category> lstcat = new CategoryController().GetCategories  (0);

                cmbVoucherType.DisplayMember = "Name";
                cmbVoucherType.ValueMember = "ID";
                cmbVoucherType.DataSource = lstcat;

                return true;
            }
            catch (Exception)
            {

                throw;
                return false;
            }
        }

        private void ClearControls()
        {
            try
            {
                LoadVoucherType();
                LoadBranch();
                if (IsGTrial ||IsStkBalance  )
                {
                    LoadPAcc();
                }
                else if (this.IsDepAtt)
                {
                    rdbAllDates.Visible = false;
                    rdbADay.Visible = false;
                    rdbToday.Visible = false;
                    
                    LoadCategory();
                }
                else
                {
                    LoadVoucherType();
                }

                this.rdbAllDates.Checked = true;
                this.rdbDateRange.Checked = false;
                this.rdbADay.Checked = false;
                this.rdbToday.Checked = false;

                this.gbDateRange.Visible = false;
                this.gbADay.Visible = false;
                if (this.IsDepAtt)
                {
                    rdbDateRange.Checked = true;  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"FrmCurrentStock ClearControls()",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }


        //Reports.CrpStkBalance CrpStk;
        private void SetReport(string p)
        {
            string FromDate = "";
            if (rdbAllDates.Checked)
            {
                FromDate = "1/06/2019";
            }
            else if (rdbDateRange.Checked)
            {
                FromDate = dtpFrom.Text; 
            }
            else if (rdbADay.Checked) 
            {
                FromDate = dtpADay.Text; 
            }
            else if (rdbToday.Checked) 
            {
                FromDate = System.DateTime.Now.ToShortDateString();
            }
            
            try
            {
                //Report_Forms.FrmReportViewer frmViewer = new Accounts.Report_Forms.FrmReportViewer();
                Common.Data_Sets.DSCashBook dsCashBook = new Common.Data_Sets.DSCashBook();
                Common.Data_Sets.DSAccLedger dsAccLedger = new Common.Data_Sets.DSAccLedger();
                Common.Data_Sets.DSCOA dsCOA = new Common.Data_Sets.DSCOA();
                Common.Data_Sets.DSBalanceSheet  dsBalanceSheet = new Common.Data_Sets.DSBalanceSheet();
                Common.Data_Sets.DSIncomeStatement  dsIS = new Common.Data_Sets.DSIncomeStatement();
              ////  Common.Data_Sets.DsEmpAttendance DsEmp = new Common.Data_Sets.DsEmpAttendance();
                //Common.Data_Sets.DSIncomeStatementService DsSvcIncStmnt = new Common.Data_Sets.DSIncomeStatementService();

                string DateRange = "";

                //Set Condition for Date.
                if (this.rdbAllDates.Checked)
                {
                    fromDate = "1/06/2019";
                    toDate = "1/1/2050";
                    DateRange = "All Dates";
                }
                else if (this.rdbDateRange.Checked)
                {
                    fromDate = this.dtpFrom.Value.ToString("yyyy-MM-dd 00:00:00");
                    toDate = this.dtpTo.Value.ToString("yyyy-MM-dd 00:00:00");
                    //fromDate = this.dtpFrom.Value.ToString("dd-MM-yyyy 00:00:00");
                    //toDate = this.dtpTo.Value.ToString("dd-MM-yyyy 00:00:00");


                    DateRange = "From     " + dtpFrom.Value.ToString ("dd/MM/yyyy") + "     To   " + dtpTo.Value.ToString ("dd/MM/yyyy") ;
                }
                else if (this.rdbADay.Checked)
                {
                    fromDate = this.dtpADay.Value.ToString ("yyyy-MM-dd 00:00:00") ;
                    toDate = this.dtpADay.Value.ToString ("yyyy-MM-dd 00:00:00") ;
                    DateRange = "From    " + dtpADay.Value.ToString ("dd/MM/yyyy") + "    To    " + dtpADay.Value.ToString ("dd/MM/yyyy") ;
                }
                else if (this.rdbToday.Checked)
                {
                    fromDate = System.DateTime.Now.Date.ToShortDateString ();
                    toDate = System.DateTime.Now.Date.ToShortDateString ();
                    DateRange = "From    " + System.DateTime.Now.Date.ToString("dd/MM/yyyy") + "     To    " + System.DateTime.Now.Date.ToString("dd/MM/yyyy");

                }

                string username = User._UserName;
                if (this.IsRRegister)
                {
                    System.Data.DataSet DsStk = new System.Data.DataSet();
                    DsStk = new CashBookController().GetRRegister(fromDate, toDate);
                    if (DsStk.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("No Data  Found", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                   // Reports.CrpRRetgister crprr = new Accounts.Reports.CrpRRetgister();
                    //crprr.SetDataSource(DsStk.Tables[0]);
                   // crprr.SetParameterValue("dat", DateRange);
                    //frmViewer.crystalReportViewer1.ReportSource = crprr;
                    if (p == "w")
                    {
                        //frmViewer.Show();
                    }
                    else { }
                      //  frmViewer.crystalReportViewer1.PrintReport();
                }
                if (this.IsDepAtt)
                {
                    //Reports.CrpDepWiseEmpAtt crpdw = new Accounts.Reports.CrpDepWiseEmpAtt();
                    string where = " where   A.InDateTime BETWEEN '" + dtpFrom.Value.ToString("yyyy-MM-dd 00:00:00") + "' and '" + dtpTo.Value.ToString("yyyy-MM-dd 23:59:00") + "'";
                    if (Convert.ToInt32(cmbVoucherType.SelectedValue  ) != 0)
                    {
                        where += " and e.categoryid=" + cmbVoucherType.SelectedValue  ;
                    }
                    //Set Condition for Date. 

                  /*  if (new CategoryController().GetEmpAttendanceDW(ref DsEmp  , where))
                    {
                        if (DsEmp.Tables[0].Rows.Count > 0)
                        {
                            //crpdw.SetDataSource(DsEmp);
                           // TextObject x = (TextObject)crpdw.ReportDefinition.ReportObjects["txtdate"];
                           // x.Text = " From Date:" + dtpFrom.Value.ToString("dd/MM/yyyy") + " To Date : " + dtpTo.Value.ToString("dd/MM/yyyy");
                          //  frmViewer.crystalReportViewer1.ReportSource = crpdw;

                            //frmViewer.crystalReportViewer2.RefreshReport();

                            if (p == "w")
                            {
                                //frmViewer.ShowDialog();
                            }
                            else { }
                               // frmViewer.crystalReportViewer1.PrintReport();
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
                    */
                }               
                if (this.IsStkBalance)
                {
                    System.Data.DataSet DsStk = new System.Data.DataSet();
                    string PartyID = "";
                    if (cmbVoucherType.Text != "All")
                    {
                        PartyID = cmbVoucherType.SelectedValue.ToString();   
                    }
                    DsStk = new CashBookController().GetStkBalance(fromDate, toDate, PartyID );
                    if (DsStk.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("No Data  Found", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //CrpStk = new Reports.CrpStkBalance();
                    //CrpStk.SetDataSource(DsStk.Tables[0]);
                    //CrpStk.SetParameterValue(0, DateRange);
                    //frmViewer.crystalReportViewer1.ReportSource = CrpStk;
                    if (p == "w")
                    {
                        //rmViewer.Show();
                    }
                    else { }
                        //frmViewer.crystalReportViewer1.PrintReport();
                }
                if (this.isCashBook)
                {
                    dsCashBook = new Common.Data_Sets.DSCashBook();

                    string procedure = "";
                    int branchid = 0;
                    string branchname = "All Branches";
                    
                    if (cmbBranch.Text.Trim().Length > 0)
                    {
                        branchid = Convert.ToInt32(cmbBranch.SelectedValue);
                        branchname = cmbBranch.Text;
                    }
                    if (rdbCashInHand.Checked )
                    {
                        procedure = "SPCashInHand";
                    }
                    else if(rdbCashBook .Checked )
                    {
                        procedure = "SPCashBook";
                    }
                   string VoucherType= cmbVoucherType.Text;
                   if (new CashBookController().GetData(ref dsCashBook, fromDate, toDate, procedure, VoucherType,branchid ))
                    {
                        frmViewer frmViwer=new frmViewer();
                        if (dsCashBook.Tables["SPCashBook"].Rows.Count >= 1)
                        {
                            if (rdbCashInHand.Checked)
                            {
                                //crp1 = new Accounts.Reports.rptCashInHand ();
                                //crp1.SetDataSource(dsCashBook);
                                //crp1.SetParameterValue(1, username);
                                
                                //frmViewer.crystalReportViewer1.ReportSource = crp1;
                            }
                            else if (rdbCashBook.Checked)
                            {
                                DataTable dt = new DataTable();
                                dt = dsCashBook.Tables["SPCashBook"];
                                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                                frmViwer.reportViewer1.LocalReport.DataSources.Add(rds);
                                //frmViwer.reportViewer1.LocalReport.ReportPath = "../../Reports/rptCashBook.rdlc";
                                frmViwer.reportViewer1.LocalReport.ReportEmbeddedResource = "Restorant_Management_System.Report.rptCashBook.rdlc";
                                if (DateRange == "All Dates")
                                {
                                    ReportParameter[] rptParams = new ReportParameter[]
                                    {
                                        new ReportParameter("Dat",DateRange),
                                        new ReportParameter("opbit","false"),
                                        new ReportParameter("PrintedBy",User._UserName ),
                                    };
                                    frmViwer.reportViewer1.LocalReport.SetParameters(rptParams);
                                }
                                else
                                {
                                    ReportParameter[] rptParams = new ReportParameter[]
                                    {
                                         new ReportParameter("Dat",DateRange),
                                        new ReportParameter("opbit","true"),
                                        new ReportParameter("PrintedBy",User._UserName ),
                                    };
                                    frmViwer.reportViewer1.LocalReport.SetParameters(rptParams);
                                }
                                frmViwer.reportViewer1.LocalReport.Refresh();
                                frmViwer.ShowDialog();
                              
                            }

                        //frmViewer.crystalReportViewer1.RefreshReport();

                        if (p == "w")
                        {
                            //frmViewer.Show();
                        }
                            else { }
                            //frmViewer.crystalReportViewer1.PrintReport();
                        }
                        else
                            MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);   
                    }
                    else
                        MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(this.isGeneral)
                {
                    dsAccLedger = new Common.Data_Sets.DSAccLedger();
                    frmViewer frmViwer = new frmViewer();
                    int branchid = 0;
                    string branchname = "All Branches";
                    string voucherType = this.cmbType.Text.Trim().Length == 0 ? "All" : cmbType.Text.Trim();
                    if (cmbBranch.Text.Trim().Length > 0)
                    {
                        branchid = Convert.ToInt32(cmbBranch.SelectedValue);
                        branchname = cmbBranch.Text;
                    }

                    if (new AccLedgerController().GetGeneralData(ref dsAccLedger,fromDate,toDate, voucherType, branchid, txtPartyID.Text  ))
                    {
                     
                        if (dsAccLedger.Tables["SPAccountsLedger"].Rows.Count >= 1)
                        {
                            ReportDataSource rds = new ReportDataSource("DSAccLedger", dsAccLedger.Tables["SPAccountsLedger"]);
                            frmViwer.reportViewer1.LocalReport.DataSources.Add(rds);
                           // frmViwer.reportViewer1.LocalReport.ReportPath = "../../Report/RptGeneralJournal.rdlc";
                            frmViwer.reportViewer1.LocalReport.ReportEmbeddedResource = "Restorant_Management_System.Report.RptGeneralJournal.rdlc";
                            ReportParameter[] rptParams = new ReportParameter[]
                                   {
                                        new ReportParameter("PrintDateAndTime",System.DateTime.Now.ToString("dd/MM/yyyy")),
                                        new ReportParameter("Branch",branchname),

                                   };
                            frmViwer.reportViewer1.LocalReport.SetParameters(rptParams);
                            frmViwer.reportViewer1.LocalReport.Refresh();
                            frmViwer.ShowDialog();
                            if (p == "w")
                            {
                                //frmViewer.Show();
                            }
                            else { }
                               //frmViewer.crystalReportViewer1.PrintReport();
                        }
                        else
                            MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);   
                    }
                    else
                        MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);   
                }
                else if (this.isTrial)
                {
                    dsCOA = new Common.Data_Sets.DSCOA();
                    frmViewer frmViwer = new frmViewer();
                    if (new COAReportController().GetTrialData(ref dsCOA, fromDate, toDate))
                    {
                     

                        if (dsCOA.Tables["ChartOfAccounts"].Rows.Count >= 1)
                        {
                            DataTable dt = new DataTable();
                            dt = dsCOA.Tables["ChartOfAccounts"];
                            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                            frmViwer.reportViewer1.LocalReport.DataSources.Add(rds);
                           // frmViwer.reportViewer1.LocalReport.ReportPath = "../../Report/RptTrialBalance.rdlc";
                            frmViwer.reportViewer1.LocalReport.ReportEmbeddedResource = "Restorant_Management_System.Report.RptTrialBalance.rdlc";

                            ReportParameter[] rptParams = new ReportParameter[]
                                {                                      
                                    new ReportParameter("Date",DateRange),
                                };
                            frmViwer.reportViewer1.LocalReport.SetParameters(rptParams);
                            frmViwer.reportViewer1.LocalReport.Refresh();
                            frmViwer.ShowDialog();


                            if (p == "w")
                            {
                                //frmViewer.Show();
                            }
                            else { }
                               // frmViewer.crystalReportViewer1.PrintReport();
                        }
                        else
                            MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                }
                else if (this.IsGTrial )
                {
                    frmViewer frmViwer = new frmViewer();
                    dsCOA = new Common.Data_Sets.DSCOA();
                    if (new COAReportController().GetTrialData(ref dsCOA, fromDate, toDate,cmbVoucherType.SelectedValue.ToString () + "%" ))
                    {          
                        if (dsCOA.Tables["ChartOfAccounts"].Rows.Count >= 1)
                        {
                            //DataTable dt = new DataTable();
                            //dt = dsCOA.Tables["ChartOfAccounts"];
                            ReportDataSource rds = new ReportDataSource("DataSet1", dsCOA.Tables["ChartOfAccounts"]);
                            frmViwer.reportViewer1.LocalReport.DataSources.Add(rds);
                           // frmViwer.reportViewer1.LocalReport.ReportPath = "../../Report/RptGTrialBalance.rdlc";
                            frmViwer.reportViewer1.LocalReport.ReportEmbeddedResource = "Restorant_Management_System.Report.RptGTrialBalance.rdlc";

                            ReportParameter[] rptParams = new ReportParameter[]
                                {
                                    new ReportParameter("Date",DateRange),
                                };
                            frmViwer.reportViewer1.LocalReport.SetParameters(rptParams);
                            frmViwer.reportViewer1.LocalReport.Refresh();
                            frmViwer.ShowDialog();

                            if (p == "w")
                            {
                               //frmViewer.Show();
                            }
                            else { }
                               //frmViewer.crystalReportViewer1.PrintReport();
                        }
                        else
                            MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (this.isIncome)
                {
                    dsIS = new Common.Data_Sets.DSIncomeStatement ();
                  
                    if (new COAReportController().GetIncomeData(ref dsIS, fromDate, toDate,false))
                    {

                        frmViewer frmViewer = new frmViewer();
                        if (dsIS.Tables["SPIncomeStatement"].Rows.Count >= 1)
                        {
                            ReportDataSource rds = new ReportDataSource("DSIncomeStatement", dsIS.Tables["SPIncomeStatement"]);
                            frmViewer.reportViewer1.LocalReport.DataSources.Add(rds);
                            frmViewer.reportViewer1.LocalReport.ReportEmbeddedResource = "Restorant_Management_System.Report.RptIncomeStatement.rdlc";
                           

                            ReportParameter[] rptParams = new ReportParameter[]
                                   {
                                       new ReportParameter("DateRange",DateRange.ToString()),
                                       new ReportParameter("PrintDateAndTime",System.DateTime.Now.ToString("dd/MM/yyyy")),

                                   };
                            frmViewer.reportViewer1.LocalReport.SetParameters(rptParams);
                            frmViewer.reportViewer1.LocalReport.Refresh();
                            frmViewer.ShowDialog();
                            if (p == "w")
                            {
                                //frmViewer.Show();
                            }
                            else { }
                                //frmViewer.crystalReportViewer1.PrintReport();
                        }
                        else
                            MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
             
                ///Income Stmt
                else if (this.isIncStmt)
                {
                    System.Data.DataSet DsInc = new DataSet();
                   // Reports.CrpIncStmt CrpIncStmt = new Accounts.Reports.CrpIncStmt();
                    if (new COAReportController().GetIncStmtData(ref DsInc, fromDate, toDate))
                    {

                        if (DsInc.Tables[0].Rows.Count >= 1)
                        {
                            //CrpIncStmt.SetDataSource(DsInc.Tables[0]);
                            //TextObject x = (TextObject)CrpIncStmt.ReportDefinition.ReportObjects["txtdate"];
                            //x.Text = "For The Month: " + Convert.ToDateTime(fromDate).ToString("MMM-yyyy");

                            //frmViewer.crystalReportViewer1.ReportSource = CrpIncStmt;


                            if (p == "w")
                            {
                                //frmViewer.Show();
                            }
                            else { }
                               // frmViewer.crystalReportViewer1.PrintReport();
                        }
                        else
                            MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (this.isPay || this.isRec)
                {
                    string type = "";
                    if (this.isPay)
                    {
                        type = "Cr";

                        if (chkLevel.Checked)
                        {
                            //crpPayablePO = new Accounts.Reports.rptAccountsPayablePO();
                        }
                        else
                        {
                           // crpPayable = new Accounts.Reports.rptAccountsPayable();
                            //crpPayable = new Accounts.Reports.CrpPayableGraph();
                        }
                    }
                    else if (this.isRec)
                    {
                        type = "Dr";
                        if (chkLevel.Checked)
                        {
                           // crpReceiveableDO = new Accounts.Reports.rptAccountsReceiveableDO();
                        }
                        else
                        {
                           // crpReceiveable = new Accounts.Reports.rptAccountsReceiveable();
                        }
                    }

                    dsCOA = new Common.Data_Sets.DSCOA();
                    if (new COAReportController().GetPayRecData(ref dsCOA, fromDate, toDate, type, chkLevel.Checked, Convert.ToInt32(cmbBranch.SelectedValue  ) ))
                    {
                        if (dsCOA.Tables["ChartOfAccounts"].Rows.Count >= 1)
                        {
                            frmViewer frmViewer = new frmViewer();
                            ReportDataSource rds = new ReportDataSource("DSCOA", dsCOA.Tables["ChartOfAccounts"]);
                            frmViewer.reportViewer1.LocalReport.DataSources.Add(rds);
                            
                          

                            if (this.isPay)
                            {

                                if (chkLevel.Checked)
                                {
                                    
                                }
                                else
                                {
                                   // frmViewer.reportViewer1.LocalReport.ReportPath = "../../Report/RptAccountPayable.rdlc";
                                    frmViewer.reportViewer1.LocalReport.ReportEmbeddedResource = "Restorant_Management_System.Report.RptAccountPayable.rdlc";
                                    ReportParameter[] rptParams = new ReportParameter[]
                                           {
                                       new ReportParameter("DateRange",DateRange.ToString()),
                                       new ReportParameter("PrintDateAndTime",System.DateTime.Now.ToString("dd/MM/yyyy")),

                                           };
                                    frmViewer.reportViewer1.LocalReport.SetParameters(rptParams);
                                    frmViewer.reportViewer1.LocalReport.Refresh();
                                    frmViewer.ShowDialog();
                                }
                            }
                            else if (this.isRec)
                            {
                                if (chkLevel.Checked)
                                {
                                    
                                }
                                else
                                {
                                  //  frmViewer.reportViewer1.LocalReport.ReportPath = "../../Report/RptAccountReceivable.rdlc";
                                    frmViewer.reportViewer1.LocalReport.ReportEmbeddedResource = "Restorant_Management_System.Report.RptAccountReceivable.rdlc";
                                    ReportParameter[] rptParams = new ReportParameter[]
                                           {
                                       new ReportParameter("DateRange",DateRange.ToString()),
                                       new ReportParameter("PrintDateAndTime",System.DateTime.Now.ToString("dd/MM/yyyy")),

                                           };
                                    frmViewer.reportViewer1.LocalReport.SetParameters(rptParams);
                                    frmViewer.reportViewer1.LocalReport.Refresh();
                                    frmViewer.ShowDialog();
                                }
                            }


                          

                            if (p == "w")
                            {
                               // frmViewer.Show();
                            }
                            else { }
                                //frmViewer.crystalReportViewer1.PrintReport();
                        }
                        else
                            MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (this.isBal)
                {
                    dsBalanceSheet = new Common.Data_Sets.DSBalanceSheet();
                    if (new COAReportController().GetBalanceSheetData(ref dsBalanceSheet, fromDate, toDate))
                    {
                       // crpBalanceSheet = new Accounts.Reports.CrpBalanceSheet();
                        if (dsBalanceSheet.Tables["SPBalanceSheet"].Rows.Count >= 1)
                        {
                            //crpBalanceSheet.SetDataSource(dsBalanceSheet);
                            //crpBalanceSheet.SetParameterValue(0, username);
                            //crpBalanceSheet.SetParameterValue(1, "From :" + fromDate + " To " + toDate);
                            //frmViewer.crystalReportViewer1.ReportSource = crpBalanceSheet;

                            // frmViewer.crystalReportViewer1.RefreshReport();

                            if (p == "w")
                            {
                                //frmViewer.Show();
                            }
                            else { }
                               // frmViewer.crystalReportViewer1.PrintReport();
                        }
                        else
                            MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"FrmCurrentStock SetReport",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        #region Other Controls Event Functions
                
        //private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        //{
        //    try
        //    {
        //        switch (e.Tool.Key)
        //        {
        //            case "Close":
        //                this.Close();
        //                break;
        //            case "New":
        //                ClearControls();
        //                break;
        //            case "Print":                     
        //                SetReport("p");                                              
        //                break;
        //            case "Preview":
        //                SetReport("w");                                              
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "FrmCurrentStock Toolbar_ToolClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        
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
        private void rdbAllDates_KeyDown(object sender, KeyEventArgs e)
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
                
        #endregion                           

        private void FrmCurrentStock_Fill_Panel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void tsbtnPreview_Click(object sender, EventArgs e)
        {
            SetReport("w");
        }

        private void stbtnPrint_Click(object sender, EventArgs e)
        {
            SetReport("p");
        }

        private void tsbtnClear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void tsbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            SetReport("w");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void chkLevel_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ShowSearch(ref System.Windows.Forms.TextBox txtno, ref System.Windows.Forms.TextBox txtname)
        {
            try
            {
                Accounts.SchForms.SchAccounts Sch = new Accounts.SchForms.SchAccounts();
                Sch.accountType = " and accountno <> (Select CashAcc From FixedAccounts)";
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
                this.txtPartName.Text = "All Accounts";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmSaleRegister btnAllParties_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

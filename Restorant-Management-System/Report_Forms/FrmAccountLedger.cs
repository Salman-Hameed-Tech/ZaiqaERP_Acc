using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using CategoryControlle;
using Microsoft.Reporting.WinForms;
//using PetrolPump.Reports_Forms;

namespace Restorant_Management_System
{
    public partial class FrmAccountLedger : Form
    {
        //PetrolPump.Reports.rptAccountLedger crp = new PetrolPump.Reports.rptAccountLedger();
        //  Reports rpt =new Reports():
       
           


      public LedgerFor ledgerFor = LedgerFor.All;

        string where = "";
        string fromDate;
        string toDate;

        public FrmAccountLedger()
        {
            InitializeComponent();
        }

        private void FrmCurrentStock_Load(object sender, EventArgs e)
        {
            try
            {
                if (ledgerFor == LedgerFor.Banks)
                {
                    this.Text = "Funds Flow Statement";
                    grpParty.Visible = false;
                    chkIsPosted.Visible = false;
                }
               

               // FrmCurrentStock_Fill_Panel.BackColor = AccountsGlobals.FormColor;
              //  this.BackColor = AccountsGlobals.FormColor;
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
           
        }
        private void ClearControls()
        {
            try
            {            
                this.rdbAllDates.Checked = true;
                this.rdbDateRange.Checked = false;
                this.rdbADay.Checked = false;
                this.rdbToday.Checked = false;
                LoadBranch();
                this.gbDateRange.Visible = false;
                this.gbADay.Visible = false;

                this.txtPartyID.Clear();
                this.txtPartName.Text = "All Parties";                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"FrmCurrentStock ClearControls()",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
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
        private void VerifyAcc(ref System.Windows.Forms.TextBox txtno, ref System.Windows.Forms.TextBox txtname)
        {
            ChartOfAccounts Ca;
            Ca = new ChartofAccountsController().GetAccountDetail(txtno.Text, " and isdetailed=1 and accountno <> (Select CashAcc from FixedAccounts)");
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

         
        private void SetReport(string p)
        {
            string DateforAll = "";
            try
            {
                //PetrolPump.Reports_Forms.FrmReportViewer frmViewer = new PetrolPump.Reports_Forms.FrmReportViewer();
               
                //Set Condition for Date.
                if (this.rdbAllDates.Checked)
                {
                    fromDate = "2019-06-01 00:00:00";
                    //toDate = "1/1/2050";
                    toDate = System.DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
                }
                else if (this.rdbDateRange.Checked)
                {
                    fromDate = this.dtpFrom.Value.Date.ToString("yyyy-MM-dd 00:00:00");
                    toDate = this.dtpTo.Value.Date.ToString("yyyy-MM-dd 00:00:00");
                }
                else if (this.rdbADay.Checked)
                {
                    fromDate = this.dtpADay.Value.Date.ToString("yyyy-MM-dd 00:00:00");
                    toDate = this.dtpADay.Value.Date.ToString("yyyy-MM-dd 00:00:00");
                }
                else if (this.rdbToday.Checked)
                {
                    fromDate = System.DateTime.Now.Date.ToString("yyyy-MM-dd 00:00:00");
                    toDate = System.DateTime.Now.Date.ToString("yyyy-MM-dd 00:00:00");
                }
                int branchid = 0;
                //if (cmbBranch.SelectedIndex > -1)
                //{
                //    branchid = Convert.ToInt32(cmbBranch.SelectedValue);
                //}
                // string username = User._UserName;
                branchid = Globals.BranchID;
               string username = "Admin";
                if (ledgerFor == LedgerFor.All)
                {
                    Common.Data_Sets.DSAccLedger dsAccLedger = new Common.Data_Sets.DSAccLedger();

                    if (new AccLedgerController().GetData(ref dsAccLedger, fromDate, toDate, this.txtPartyID.Text, (chkIsPosted.Checked ? 1 : -1),-1, branchid))
                    {
                        if (dsAccLedger.Tables["SPAccountsLedger"].Rows.Count > 0)
                        {
                            Restorant_Management_System.Report_Forms.frmViewer frmViwer = new Report_Forms.frmViewer();
                         
                       
                          
                            ReportDataSource rds = new ReportDataSource("DataSet1", dsAccLedger.Tables["SPAccountsLedger"]);
                            frmViwer.reportViewer1.LocalReport.DataSources.Add(rds);
                  
                            frmViwer.reportViewer1.LocalReport.ReportEmbeddedResource = "Restorant_Management_System.Report.RptAccLedger.rdlc";
                            if (toDate == "1/1/2050")
                            {
                                ReportParameter[] rptParams = new ReportParameter[]
                                {
                                        new ReportParameter("opbit","false"),
                                        new ReportParameter("toDate",toDate),
                                };
                                frmViwer.reportViewer1.LocalReport.SetParameters(rptParams);
                            }
                            else
                            {
                                ReportParameter[] rptParams = new ReportParameter[]
                                {
                                        new ReportParameter("opbit","true"),
                                        new ReportParameter("toDate",toDate),
                                };
                                frmViwer.reportViewer1.LocalReport.SetParameters(rptParams);
                            }

                            frmViwer.reportViewer1.LocalReport.Refresh();
                            frmViwer.ShowDialog();

                            if (p == "w")
                            {
                                
                            }
                           // else
                               // frmViewer.CrpViewer.ReportSource.PrintReport();
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

                else if (ledgerFor == LedgerFor.Banks )
                {
                    Common.Data_Sets.DSFundsFlow dsAccLedger = new Common.Data_Sets.DSFundsFlow();

                                //crp.SetParameterValue(0, true);
                    if (new AccLedgerController().GetFundsFlow (ref dsAccLedger, fromDate, toDate))
                    {
                        if (dsAccLedger.Tables["SPFundsFlow"].Rows.Count > 0)
                        {
                            //crp1.SetDataSource(dsAccLedger.Tables["SPFundsFlow"]);                           
                            ////crp1.Subreports [0].SetDataSource (dsAccLedger.Tables ["SPTotal"]);

                            //frmViewer.crystalReportViewer1.ReportSource = crp1;


                            if (p == "w")
                            {
                                //frmViewer.Show();
                            }
                            else { }
                                //frmViewer.crystalReportViewer1.PrintReport();
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
                

               
                    
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"FrmAccountsledger SetReport",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        #region Other Controls Event Functions

        private void cbxCategory_KeyDown(object sender, KeyEventArgs e)
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

        #endregion

        private void tsbtnClose_Click(object sender, EventArgs e)
        {
          
        }

        private void tsbtnClear_Click(object sender, EventArgs e)
        {
        
        }

        private void tsbtnPreview_Click(object sender, EventArgs e)
        {
         
        }

        private void stbtnPrint_Click(object sender, EventArgs e)
        {
           
        }

        private void FrmCurrentStock_Fill_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
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
            SetReport("p");
        }
    }
}

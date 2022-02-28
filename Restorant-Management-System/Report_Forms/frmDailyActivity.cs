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
    public partial class frmDailyActivity : Form
    {
        DateTime fromDate;
        DateTime toDate;
        public string type = "";
        public frmDailyActivity()
        {
            InitializeComponent();
        }

        private void frmDailyActivity_Load(object sender, EventArgs e)
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
                this.dtpFrom.Value = System.DateTime.Now.Date;
                this.dtpTo.Value = System.DateTime.Now.Date;

                List<Branch> counters = new BranchController().GetBranch("  where 1=1  ");
                cmbBranch.DataSource = counters;
                cmbBranch.ValueMember = "ID";
                cmbBranch.DisplayMember = "BranchName";
                cmbBranch.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmCurrentStock ClearControls()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetWhere()
        {
            try
            {
                fromDate = this.dtpFrom.Value;
                toDate = this.dtpTo.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmCurrentStock SetReport", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetReport(string p)
        {
            try
            {
                SetWhere();

                Common.Data_Sets.DSActivity dsProductSales = new Common.Data_Sets.DSActivity();
                //this.txtItemID.Focus();                 
                Restorant_Management_System.Report_Forms.frmViewer frmViwer = new Restorant_Management_System.Report_Forms.frmViewer();
                DataTable dt = new DataTable();
                int branchid = 0;
                if (cmbBranch.Text.Trim().Length != 0)
                {
                    branchid = Convert.ToInt32(cmbBranch.SelectedValue);
                }
                if (type == "DA")
                {
                    if (new ActivityController().GetData(ref dsProductSales, fromDate, toDate, branchid))
                    {
                        if (dsProductSales.Tables["Activity"].Rows.Count >= 1)
                        {
                            dt = dsProductSales.Tables["Activity"];
                            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                            frmViwer.reportViewer1.LocalReport.DataSources.Add(rds);
                            //  frmViwer.reportViewer1.LocalReport.ReportPath = "../../Report/RptActivity.rdlc";
                            frmViwer.reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "Report/RptActivity.rdlc");

                            if (p == "w")
                            {
                                frmViwer.ShowDialog();
                            }

                            //else
                            //   frmViewer.crystalReportViewer1.PrintReport();
                        }
                        else
                            MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (type == "SCCS")
                {
                    Common.Data_Sets.DSPettyCash dSPetty = new Common.Data_Sets.DSPettyCash();
                    if (new SummaryController().GetSCCSummary(ref dSPetty, fromDate, toDate, branchid))
                    {
                        if (dSPetty.Tables["SPPettyCash"].Rows.Count > 0)
                        {
                            dt = dSPetty.Tables["SPPettyCash"];
                            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                            frmViwer.reportViewer1.LocalReport.DataSources.Add(rds);
                            //  frmViwer.reportViewer1.LocalReport.ReportPath = "../../Report/RptActivity.rdlc";
                            frmViwer.reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "Report/RptShopCashCSummary.rdlc");

                            if (p == "w")
                            {
                                frmViwer.ShowDialog();
                            }

                          
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
                MessageBox.Show(ex.Message, "FrmCurrentStock SetReport", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("\t");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            SetReport("w");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SetReport("p");
        }
    }
}

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
using Accounts;
using Accounts.Forms;
using Microsoft.Reporting.WinForms;

namespace Restorant_Management_System.Forms
{
    public partial class frmSummary : Form
    {
        Common.Data_Sets.DSSummary dsSummary;
        public SaleInvoice sale = null;

      //  Reports.CrpSummary crp = new PointOfSale.Reports.CrpSummary();
      //  Report_Forms.FrmReportViewer frmViewer = new PointOfSale.Report_Forms.FrmReportViewer();

        string where;
        int count = 0;
        bool isUpdated = false;
        public frmSummary()
        {
            InitializeComponent();
        }

   
        private void frmSummary_Load(object sender, EventArgs e)
        {
            try
            {
                dsSummary = new Common.Data_Sets.DSSummary();
                where = "";

               // LoadCombo();
                LoadBranches();
               // LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmSummary_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private void LoadBranches()
        {
            string where = " where 1=1 ";
            if (!User._IsAdmin)
            {
                where += " and b.ID=" + Globals.BranchID + "  ";
            }

            List<Branch> counters = new BranchController().GetBranch(where);
            cmbBranch.DataSource = counters;
            cmbBranch.ValueMember = "ID";
            cmbBranch.DisplayMember = "BranchName";
            //cmbBranch.SelectedIndex = -1;
        }

        private void LoadCombo()
        {
            try
            {
         
                DataSet ds = new DataSet();
                ds = new SummaryController().GetSummaries( Convert.ToInt16(cmbUsers.SelectedValue), dtpDate.Value.ToString("yyyy-MM-dd"));
                cmbSummaryNo.DataSource = ds.Tables[0];
              
                cmbSummaryNo.DisplayMember = "SummaryNo";
                cmbSummaryNo.ValueMember = "SummaryNo";
                cmbSummaryNo.SelectedIndex = -1;
                count = count + 1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmSummary LoadCombo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbUser_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbSummaryNo.Text.Trim().Length > 0)
                {
                    if (count > 0)
                    {
                        dsSummary = new Common.Data_Sets.DSSummary();
                        bool c = new SummaryRptController().GetData(ref dsSummary, Convert.ToInt64(this.cmbSummaryNo.SelectedValue), where);
                        PopulateGrd();
                        CalculateTotal();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmSummary cbxUser_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void SaleInvoice_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                if (chkSaleInvoice.Checked)
                {
                    dsSummary = new Common.Data_Sets.DSSummary();
                    bool c = new SummaryRptController().GetData(ref dsSummary, Convert.ToInt64(this.cmbSummaryNo.SelectedValue), where);

                    PopulateGrd();
                    CalculateTotal();
                }
                else
                {
                    Grd.DataSource = null;
                }

            

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmSummary cbxUser_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private void SetWhere()
        {
            try
            {
                where = "";

                if (this.chkSaleInvoice.Checked)
                {
                    where = " and (VoucherType='SI')";
                }
                if (this.DrVoucher.Checked)
                {
                    where = " and (VoucherType='CPV')";
                }
                if (this.CrVoucher.Checked)
                {
                    where = " and (VoucherType='CRV')";
                }
                if (this.chkSaleInvoice.Checked && this.DrVoucher.Checked)
                {
                    where = " and (VoucherType='SI' or VoucherType='CPV')";
                }
                if (this.chkSaleInvoice.Checked && this.CrVoucher.Checked)
                {
                    where = " and (VoucherType='SI' or VoucherType='CRV')";
                }
                if (this.DrVoucher.Checked && this.CrVoucher.Checked)
                {
                    where = " and (VoucherType='CPV' or VoucherType='CRV')";
                }
                if (this.chkSaleInvoice.Checked && this.DrVoucher.Checked && this.CrVoucher.Checked)
                {
                    where = " and (VoucherType='SI' or VoucherType='CPV' or VoucherType='CRV')";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmSummary SetWhere", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateGrd()
        {
            Grd.DataSource = dsSummary.Tables["Summary"];
            Grd.Columns["Title"].Width = 160;
            Grd.Columns["VoucherType"].Visible = false;
            Grd.Columns["SummaryNo"].Visible = false;
            Grd.Columns["UserName"].Visible = false;
            CalculateTotal();
            
        }

        private void CalculateTotal()
        {
            try
            {
                decimal totalamt = 0;
                decimal totaldisc = 0;
                decimal totalpaid = 0;
                for (int i = 0; i < Grd.RowCount; i++)
                {
                    totalamt += Convert.ToDecimal(Grd.Rows[i].Cells["TotalAmt"].Value);
                    totaldisc += Convert.ToDecimal(Grd.Rows[i].Cells["TotalDiscount"].Value);
                    totalpaid += Convert.ToDecimal(Grd.Rows[i].Cells["Paid"].Value);
                }

                txtTotalAmt.Text = totalamt.ToString();
                txtTotalDisc.Text = totaldisc.ToString();
                txtTotalPaid.Text = totalpaid.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "CalculateTotal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DrVoucher_CheckedChanged(object sender, EventArgs e)
        {
            SetWhere();

            dsSummary = new Common.Data_Sets.DSSummary();
            bool c = new SummaryRptController().GetData(ref dsSummary, Convert.ToInt64(this.cmbSummaryNo.SelectedValue), where);
            PopulateGrd();
            CalculateTotal();
        }

       

        private void CrVoucher_CheckedChanged(object sender, EventArgs e)
        {
            SetWhere();

            dsSummary = new Common.Data_Sets.DSSummary();
            bool c = new SummaryRptController().GetData(ref dsSummary, Convert.ToInt64(this.cmbSummaryNo.SelectedValue), where);
            PopulateGrd();
            CalculateTotal();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Report_Forms.frmViewer Viewer = new Report_Forms.frmViewer();
                Viewer.reportViewer1.Reset();

                if (dsSummary.Tables["Summary"].Rows.Count > 0)
                {


                    DialogResult r = MessageBox.Show("Are you sure you want to finalize your summary?", "Confirm Summary Finalization...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (r == DialogResult.Yes)
                    {
                        if (new SummaryController().UpdateSummary(Convert.ToInt64(this.cmbSummaryNo.SelectedValue)))
                        {
                            isUpdated = true;
                        }
                    }


                    ReportDataSource rds = new ReportDataSource("DataSet1", dsSummary.Tables["Summary"]);
                    Viewer.reportViewer1.LocalReport.DataSources.Add(rds);                  
                    Viewer.reportViewer1.LocalReport.ReportPath = Globals.ReportPath + "/Report/RptSummary.rdlc";
                    Viewer.reportViewer1.LocalReport.Refresh();
                    Viewer.ShowDialog();

                    

                }
                else
                {
                    MessageBox.Show("No Data Found", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void frmSummary_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (isUpdated)
                {
                    MessageBox.Show("This is an information message.\nIt is Necessary To Open This Software Again Due To Some Techinical Reasons.\nSorry!!! For Inconvenience.", "Confirm Summary Finalization...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmSummary_FormClosed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Grd_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(Grd.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void cmbBranch_Leave(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();

                if (cmbBranch.Text.Trim().Length != 0)
                {
                    if (User._IsAdmin)
                    {

                        string where = "  u.BranchID=" + Convert.ToInt32(cmbBranch.SelectedValue) + "   ";
                        ds = new UserController().GetUserList(where);
                        cmbUsers.DataSource = ds.Tables[0];
                        cmbUsers.DisplayMember = "UserName";
                        cmbUsers.ValueMember = "UserID";
                        cmbUsers.SelectedIndex = -1;

                    }
                }
            }
            catch (Exception)
            { }
        }

        private void cmbUsers_Leave(object sender, EventArgs e)
        {
            LoadCombo();
        }

        private void Grd_DoubleClick(object sender, EventArgs e)
        {
           
            int rowindex = Grd.CurrentRow.Index;
            if (Grd.Rows[rowindex].Cells["Title"].Value.ToString() == "Sale Invoice")
            {
                int Saleid = Convert.ToInt32(Grd.Rows[rowindex].Cells["VoucherNo"].Value);
                DateTime Saledate = Convert.ToDateTime(Grd.Rows[rowindex].Cells["VoucherDate"].Value);
                int branchid = Convert.ToInt32(cmbBranch.SelectedValue);
                sale = new SummaryController().GetSaleInvoie(Saleid, Saledate.ToString("yyyy-MM-dd 00:00:00"), branchid);
                frmSaleInvoice frm = new frmSaleInvoice();
                frm.IsEditSale = true;
                frm.obj = sale;
                frm.ShowDialog();

                if (cmbSummaryNo.Text.Trim().Length > 0)
                {
                    if (count > 0)
                    {
                        dsSummary = new Common.Data_Sets.DSSummary();
                        bool c = new SummaryRptController().GetData(ref dsSummary, Convert.ToInt64(this.cmbSummaryNo.SelectedValue), where);
                        PopulateGrd();
                        CalculateTotal();
                    }
                }
            }


        }
    }
}

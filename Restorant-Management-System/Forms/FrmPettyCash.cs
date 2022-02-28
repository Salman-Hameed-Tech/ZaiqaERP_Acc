using CategoryControlle;
using Common;
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

namespace Restorant_Management_System.Forms
{
    public partial class FrmPettyCash : Form
    {
        int count = 0;
        public FrmPettyCash()
        {
            InitializeComponent();
        }

        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void GetSummary(int summaryno)
        {
            Summary summary = new Summary();
            int baranchid = 0;
            
                if (User._IsAdmin)
                {
                    baranchid = Convert.ToInt32(cmbBranch.SelectedValue);
                }
                else
                {
                    baranchid = Globals.BranchID;
                }
                summary = new SummaryController().GetSummary(summaryno, baranchid);
                txtCashSale.Text = summary.TotalSale.ToString();
                txtCashPayment.Text = summary.TotalPayment.ToString();
                txtCreditCard.Text = summary.CreditCard.ToString();
                txtOpeningCash.Text = new SummaryController().GetOpeningCash(cmbShift.Text, baranchid,dtpDate.Value);
                CalculateTotals();
           
        }

        private void CalculateTotals()
        {
            decimal salecash = (txtCashSale.Text.Trim().Length==0 ? 0 : Convert.ToDecimal(txtCashSale.Text.Trim()));
            decimal creditcard= (txtCreditCard.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtCreditCard.Text.Trim()));
            decimal Payment = (txtCashPayment.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtCashPayment.Text.Trim()));
            decimal openingCash= (txtOpeningCash.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtOpeningCash.Text.Trim()));
            decimal Total5000Rs = (txtTotal5000Rs.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtTotal5000Rs.Text.Trim()));
            decimal Total1000Rs = (txtTotal1000Rs.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtTotal1000Rs.Text.Trim()));
            decimal Total500Rs = (txtTotal500Rs.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtTotal500Rs.Text.Trim()));



            decimal totalSale = salecash + creditcard;
            txtTotalSale.Text = totalSale.ToString();
            decimal systemcash = totalSale + openingCash - creditcard-Payment;
            decimal physicalcash= (txtPhysicalCash.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtPhysicalCash.Text.Trim()));

            txtSystemCash.Text = systemcash.ToString();
            txtCashDifference.Text = (systemcash - physicalcash).ToString();
          
            txtBankDeposite.Text = (Total5000Rs + Total1000Rs + Total500Rs).ToString();
            txtClosingCash.Text = physicalcash.ToString();



        }

        private void FrmPettyCash_Load(object sender, EventArgs e)
        {
            LoadBranches();
            ClearControlls();
        }

        private void ClearControlls()
        {
            try
            {
               // if (!User._IsAdmin)
              //  {
                    
                    //Summary ss = new Summary();
                    //DataSet ds = new DataSet();
                    //string where = " and u.UserNo="+User.UserNo+"   ";
                    //ds = new UserController().GetUserList(where);
                    //cmbUser.DataSource = ds.Tables[0];
                    //cmbUser.DisplayMember = "UserName";
                    //cmbUser.ValueMember = "UserID";

                    //cmbBranch.Enabled = false;
                    //cmbUser.Enabled = false;

                    //ss = new SummaryController().GetUser(User.UserNo);
                  
                    //txtSummaryNo.Text = ss.SummaryID.ToString();
                    
            //    }


                //DateTime day = new DayLogController().GetDay();
                //dtpDate.Value = day;

                cmbShift.DataSource = Enum.GetValues(typeof(Shift));
                cmbShift.SelectedIndex = -1;
                //LoadDepartments();


                count = count + 1;

                txtSummaryNo.Clear();
                txtOpeningCash.Clear();
                txtClosingCash.Clear();
                txtPhysicalCash.Clear();
                txtCashSale.Clear();
                txtCashPayment.Clear();
                txtSystemCash.Clear();
                txtBankDeposite.Clear();
                txtCashDifference.Clear();
                txtTotalSale.Clear();
                txtCreditCard.Clear();
                
               //txtSummaryNo.Clear();
                txtCash.Clear();
                txt1Rs.Clear();
                txt2Rs.Clear();
                txt5Rs.Clear();
                txt10Rs.Clear();
                txt20Rs.Clear();
                txt50Rs.Clear();
                txt100Rs.Clear();
                txt500Rs.Clear();
                txt1000Rs.Clear();
                txt5000Rs.Clear();

                txtTotal1Rs.Clear();
                txtTotal2Rs.Clear();
                txtTotal5Rs.Clear();
                txtTotal10Rs.Clear();
                txtTotal20Rs.Clear();
                txtTotal50Rs.Clear();
                txtTotal100Rs.Clear();
                txtTotal500Rs.Clear();
                txtTotal1000Rs.Clear();
                txtTotal5000Rs.Clear();
            }
            catch (Exception) { }
        }

        private void LoadDepartments()
        {
            
        }

        private void LoadBranches()
        {
            string where= " where 1=1 ";
            if (!User._IsAdmin)
            {
                where += " and b.ID="+Globals.BranchID+"  ";
            }
           
            List<Branch> counters = new BranchController().GetBranch(where);
            cmbBranch.DataSource = counters;
            cmbBranch.ValueMember = "ID";
            cmbBranch.DisplayMember = "BranchName";
            //cmbBranch.SelectedIndex = -1;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            ClearControlls();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtSummaryNo.Text.Trim().Length > 0 && txtCash.Text.Trim().Length > 0)
                {
                    Summary sum = new Summary();
                    sum.SummaryID = Convert.ToInt32(txtSummaryNo.Text);
                    sum.PettyCash = Convert.ToDecimal(txtCash.Text);
                    sum.OpeningCash = Convert.ToDecimal(this.txtOpeningCash.Text.Trim().Length == 0 ? "0" : this.txtOpeningCash.Text.Trim());
                    sum.TotalSale= Convert.ToDecimal(this.txtCashSale.Text.Trim().Length == 0 ? "0" : this.txtCashSale.Text.Trim());
                    sum.CreditCard = Convert.ToDecimal(this.txtCreditCard.Text.Trim().Length == 0 ? "0" : this.txtCreditCard.Text.Trim());
                    sum.BankDeposite= Convert.ToDecimal(this.txtBankDeposite.Text.Trim().Length == 0 ? "0" : this.txtBankDeposite.Text.Trim());
                    sum.ClosingCash= Convert.ToDecimal(this.txtClosingCash.Text.Trim().Length == 0 ? "0" : this.txtClosingCash.Text.Trim());
                    sum.TotalPayment= Convert.ToDecimal(this.txtCashPayment.Text.Trim().Length == 0 ? "0" : this.txtCashPayment.Text.Trim());
                    sum.Shift = cmbShift.Text;
                    sum.PrintedDate = dtpDate.Value;
                    if (User._IsAdmin)
                    {
                        sum.BarnchID = Convert.ToInt32(cmbBranch.SelectedValue);
                    }
                    else
                    {
                        sum.BarnchID = Globals.BranchID;
                    }
                    //this.txt2Rs.Text.Trim().Length == 0 ? "0" : this.txt2Rs.Text.Trim()
                    sum.Coin1= Convert.ToInt32(this.txt1Rs.Text.Trim().Length == 0 ? "0" : this.txt1Rs.Text.Trim());
                    sum.Coin2 = Convert.ToInt32(this.txt2Rs.Text.Trim().Length == 0 ? "0" : this.txt2Rs.Text.Trim());
                    sum.Coin5 = Convert.ToInt32(this.txt5Rs.Text.Trim().Length == 0 ? "0" : this.txt5Rs.Text.Trim());
                    sum.Note10 = Convert.ToInt32(this.txt10Rs.Text.Trim().Length == 0 ? "0" : this.txt10Rs.Text.Trim());
                    sum.Note20 = Convert.ToInt32(this.txt20Rs.Text.Trim().Length == 0 ? "0" : this.txt20Rs.Text.Trim());
                    sum.Note50 = Convert.ToInt32(this.txt50Rs.Text.Trim().Length == 0 ? "0" : this.txt50Rs.Text.Trim());
                    sum.Note100 = Convert.ToInt32(this.txt100Rs.Text.Trim().Length == 0 ? "0" : this.txt100Rs.Text.Trim());
                    sum.Note500 = Convert.ToInt32(this.txt500Rs.Text.Trim().Length == 0 ? "0" : this.txt500Rs.Text.Trim());
                    sum.Note1000 = Convert.ToInt32(this.txt1000Rs.Text.Trim().Length == 0 ? "0" : this.txt1000Rs.Text.Trim());
                    sum.Note5000 = Convert.ToInt32(this.txt5000Rs.Text.Trim().Length == 0 ? "0" : this.txt5000Rs.Text.Trim());

                    if (new SummaryController().SaveCash(sum))
                    {
                        MessageBox.Show("Cash Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (MessageBox.Show("Do You Want To Print It", "Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            PrintInvoice(sum.SummaryID);
                        }
                        ClearControlls();
                    }
                }
                else
                    MessageBox.Show("Please Provide Summary No or Cash", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void PrintInvoice(int summaryID)
        {
            try
            {
                Common.Data_Sets.DSPettyCash dSPetty = new Common.Data_Sets.DSPettyCash();
                if (new SummaryController().GetPettyCashData(ref dSPetty, summaryID))
                {
                    Report_Forms.frmViewer Viewer = new Report_Forms.frmViewer();
                    Viewer.reportViewer1.Reset();

                    if (dSPetty.Tables["DSPettyCash"].Rows.Count > 0)
                    {
                        ReportDataSource rds = new ReportDataSource("DataSet1", dSPetty.Tables["DSPettyCash"]);
                        Viewer.reportViewer1.LocalReport.DataSources.Add(rds);
                         Viewer.reportViewer1.LocalReport.ReportPath = Globals.ReportPath + "/Report/RptPettyCash.rdlc";
                       
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txt5000Rs_Leave(object sender, EventArgs e)
        {
           //
        }

        private void txt1000Rs_Leave(object sender, EventArgs e)
        {
            //
        }

        private void txt500Rs_Leave(object sender, EventArgs e)
        {
           ///
        }

        private void txt100Rs_Leave(object sender, EventArgs e)
        {
           ///
        }

        private void txt50Rs_Leave(object sender, EventArgs e)
        {
            //
            
        }

        private void txt5000Rs_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt5000Rs.Text.Trim().Length > 0)
                {
                    txtTotal5000Rs.Text = (Convert.ToDecimal(txt5000Rs.Text) * 5000).ToString();
                    CalculateCash();
                    
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void txt1000Rs_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt1000Rs.Text.Trim().Length > 0)
                {
                    txtTotal1000Rs.Text = (Convert.ToDecimal(txt1000Rs.Text) * 1000).ToString();
                    CalculateCash();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txt500Rs_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt500Rs.Text.Trim().Length > 0)
                {
                    txtTotal500Rs.Text = (Convert.ToDecimal(txt500Rs.Text) * 500).ToString();
                    CalculateCash();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txt100Rs_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt100Rs.Text.Trim().Length > 0)
                {
                    txtTotal100Rs.Text = (Convert.ToDecimal(txt100Rs.Text) * 100).ToString();
                    CalculateCash();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txt50Rs_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt50Rs.Text.Trim().Length > 0)
                {
                    txtTotal50Rs.Text = (Convert.ToDecimal(txt50Rs.Text) * 50).ToString();
                    CalculateCash();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txt20Rs_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt20Rs.Text.Trim().Length > 0)
                {
                    txtTotal20Rs.Text = (Convert.ToDecimal(txt20Rs.Text) * 20).ToString();
                    CalculateCash();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txt10Rs_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt10Rs.Text.Trim().Length > 0)
                {
                    txtTotal10Rs.Text = (Convert.ToDecimal(txt10Rs.Text) * 10).ToString();
                    CalculateCash();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txt5Rs_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt5Rs.Text.Trim().Length > 0)
                {
                    txtTotal5Rs.Text = (Convert.ToDecimal(txt5Rs.Text) * 5).ToString();
                    CalculateCash();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txt2Rs_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt2Rs.Text.Trim().Length > 0)
                {
                    txtTotal2Rs.Text = (Convert.ToDecimal(txt2Rs.Text) * 2).ToString();
                    CalculateCash();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txt1Rs_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt1Rs.Text.Trim().Length > 0)
                {
                    txtTotal1Rs.Text = (Convert.ToDecimal(txt1Rs.Text) * 1).ToString();
                    CalculateCash();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void CalculateCash()
        {
            int Rs1 = 0;
            int Rs2 = 0;
            int Rs5 = 0;
            int Rs10 = 0;
            int Rs20 = 0;
            int Rs50 = 0;
            int Rs100 = 0;
            int Rs500 = 0;
            int Rs1000 = 0;
            int Rs5000 = 0;

            if (txt1Rs.Text.Trim().Length > 0)
            {
                Rs1=Convert.ToInt32(txtTotal1Rs.Text);
            }
            if (txt2Rs.Text.Trim().Length > 0)
            {
                Rs2= Convert.ToInt32(txtTotal2Rs.Text);
            }
            if (txt5Rs.Text.Trim().Length > 0)
            {
                Rs5 = Convert.ToInt32(txtTotal5Rs.Text);
            }
            if (txt10Rs.Text.Trim().Length > 0)
            {
                Rs10= Convert.ToInt32(txtTotal10Rs.Text);
            }
            if (txt20Rs.Text.Trim().Length > 0)
            {
                Rs20 = Convert.ToInt32(txtTotal20Rs.Text);
            }
            if (txt50Rs.Text.Trim().Length > 0)
            {
                Rs50 = Convert.ToInt32(txtTotal50Rs.Text);
            }
            if (txt100Rs.Text.Trim().Length > 0)
            {
                Rs100 = Convert.ToInt32(txtTotal100Rs.Text);
            }
            if (txt500Rs.Text.Trim().Length > 0)
            {
                Rs500 = Convert.ToInt32(txtTotal500Rs.Text);
            }
            if (txt1000Rs.Text.Trim().Length > 0)
            {
                Rs1000 = Convert.ToInt32(txtTotal1000Rs.Text);
            }
            if (txt5000Rs.Text.Trim().Length > 0)
            {
                Rs5000 = Convert.ToInt32(txtTotal5000Rs.Text);
            }

            decimal Totalcash = Rs1 + Rs2 + Rs5 + Rs10+ Rs20 + Rs50 + Rs100 + Rs500 + Rs1000 + Rs5000;

            txtCash.Text = Totalcash.ToString();
            txtPhysicalCash.Text = Totalcash.ToString();
            CalculateTotals();
        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                
                if (cmbBranch.Text.Trim().Length != 0)
                {
                    //if (User._IsAdmin)
                    {

                        string where = "  u.BranchID=" + Convert.ToInt32(cmbBranch.SelectedValue) + "   ";
                        ds = new UserController().GetUserList(where);
                        cmbUser.DataSource = ds.Tables[0];
                        cmbUser.DisplayMember = "UserName";
                        cmbUser.ValueMember = "UserID";
                        cmbUser.SelectedIndex = -1;
                        ClearControlls();
                       
                    }
                }
            }
            catch (Exception)
            { }
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            try
            {

                if (ValidateFilter())
                {
                    if (count > 0)
                    {
                        int Summaryno = new SummaryController().GetSummaryNo(Convert.ToInt32(cmbUser.SelectedValue));
                        if (Summaryno > 0)
                        {
                            txtSummaryNo.Text = Summaryno.ToString();
                            GetSummary(Summaryno);
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnGet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private bool ValidateFilter()
        {
            try
            {
              
                if (this.cmbBranch.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Please Select  Branch First", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbBranch.Focus();
                    return false;
                }
                if (this.cmbUser.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Please Select  User First", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbUser.Focus();
                    return false;
                }
                if (this.cmbShift.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Please Select  Shift First", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbShift.Focus();
                    return false;
                }




                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ValidateFilter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void label35_Click(object sender, EventArgs e)
        {

        }
    }
}

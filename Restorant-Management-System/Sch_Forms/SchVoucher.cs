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
using CategoryControlle;
using Common;

namespace Restorant_Management_System.Sch_Forms
{
    public partial class SchVoucher : Form
    {
        List<Voucher> lstitem = new List<Voucher>();
        List<Voucher> subList = new List<Voucher>();
        public string where = "";
        public Voucher voucher;
        public bool isPrinted = false;
        public bool isPosted = false;
        public VoucherType type;
        public string Heading = "";

        public Voucher item = null;
        public SchVoucher()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool FilterBarFun(Voucher p)
        {
            try
            {
                String[] st = new String[1];
                st[0] = "AND";
                string s = Common.Globals.condition;
                string[] sr = s.Split(st, StringSplitOptions.RemoveEmptyEntries);
                string res = "";

                for (int i = 0; i < sr.Length; i++)
                {
                    string fieldName = sr[i].Split('=').GetValue(0).ToString().Trim();

                    string fieldValue = sr[i].Split('=').GetValue(1).ToString().Trim().ToUpper();


                    if (fieldValue.ToString().Trim().Length == 0)
                        break;

                    switch (fieldName)
                    {
                        case "[VoucherNo]":
                            res = res + " " + Convert.ToString((p.VoucherNo.ToString().ToUpper().Contains(fieldValue.ToString().ToUpper())));
                            break;
                        case "[VoucherDate]":
                            res = res + " " + Convert.ToString((p.VoucherDate.ToString().ToUpper().Contains(fieldValue.ToString().ToUpper())));
                            break;
                        case "[BranchName]":
                            res = res + " " + Convert.ToString((p.BranchName.ToString().ToUpper().Contains(fieldValue.ToString().ToUpper())));
                            break;
                    }
                }
                if (res.Contains(" False") == true)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SchPurchases FilterPurchase", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return false;
            }
        }
        private void LoadTempGrid()
        {
            try
            {

                grdTemp.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
                grdTemp.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                grdTemp.ColumnHeadersDefaultCellStyle.Font = new Font(grdTemp.Font, FontStyle.Bold);
                grdTemp.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                grdTemp.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdTemp.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                grdTemp.GridColor = Color.Black;

                grdTemp.MultiSelect = false;

                DataGridViewCell TextCell = new DataGridViewTextBoxCell();
                DataGridViewColumn newCol = new DataGridViewColumn();

                for (int i = 0; i < Grd.Columns.Count; i++)
                {
                    newCol = new DataGridViewColumn();
                    newCol.CellTemplate = TextCell;
                    newCol.HeaderText = Grd.Columns[i].HeaderText;
                    newCol.Name = Grd.Columns[i].Name;
                    newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    newCol.Visible = Grd.Columns[i].Visible;
                    newCol.Width = Grd.Columns[i].Width;
                    grdTemp.Columns.Add(newCol);

                }
                grdTemp.Rows.Add(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadTempGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void FormatCondition()
        {
            try
            {
                String oldcon = Common.Globals.condition;
                String newCon = "";

                while (oldcon.IndexOf(" Like ") > 0)
                {
                    newCon = oldcon.Substring(oldcon.IndexOf(" Like ") + " Like ".Length + 1, oldcon.IndexOf("*'") - (oldcon.IndexOf(" Like ") + " Like ".Length + 1));
                    oldcon = oldcon.Replace("Like '" + newCon + "*'", "= " + newCon);
                }

                Common.Globals.condition = oldcon;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "SchItem FormatCondition", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SetParaOut()
        {
            try
            {
                if (Grd.SelectedRows.Count > 0)
                {
                    voucher = new Voucher();
                    voucher.VoucherNo = Convert.ToInt32(Grd.Rows[Grd.SelectedRows[0].Index].Cells["VoucherNo"].Value);
                    voucher.VoucherDate = Convert.ToDateTime(Grd.Rows[Grd.SelectedRows[0].Index].Cells["VoucherDate"].Value);
                    voucher.BankAccNo = (ChartOfAccounts)Grd.Rows[Grd.SelectedRows[0].Index].Cells["BankAccNo"].Value;
                    voucher.VoucherType = type;
                    item = new VoucherController().GetVouchers(voucher, isPrinted, isPosted)[0];
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetParaOut", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGrid()
        {
            try
            {
                Grd.ScrollBars = ScrollBars.Vertical;
                Grd.Columns["VoucherString"].HeaderText = "Voucher";
                Grd.Columns["VoucherString"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["VoucherString"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["VoucherString"].Width = 100;

                Grd.Columns["VoucherNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["VoucherNo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["VoucherNo"].Width = 80;

                Grd.Columns["SummaryNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["SummaryNo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["SummaryNo"].Width = 80;

                Grd.Columns["IsPrinted"].Width = 15;
                Grd.Columns["IsPrinted"].HeaderText = "";

                if (voucher.VoucherType == VoucherType.LPJ)
                {
                    Grd.Columns["VoucherNo"].HeaderText = "LGRN No";
                }
                if (voucher.VoucherType == VoucherType.SJV)
                {
                    Grd.Columns["VoucherNo"].HeaderText = "OGP No";
                }


                Grd.Columns["VoucherDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["VoucherDate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["VoucherDate"].Width = 120;
                if (voucher.VoucherType == VoucherType.LPJ)
                {
                    Grd.Columns["VoucherDate"].HeaderText = "LGRN Date";
                }
                if (voucher.VoucherType == VoucherType.SJV)
                {
                    Grd.Columns["VoucherDate"].HeaderText = "OGP Date";
                }

                Grd.Columns["IsPostDated"].Visible = false;
                Grd.Columns["VoucherType"].Visible = false;
                Grd.Columns["PreVoucherNo"].Visible = false;
                Grd.Columns["PreVoucherDate"].Visible = false;
                Grd.Columns["BankAccNo"].Visible = false;
                Grd.Columns["User"].Visible = false;
                Grd.Columns["CheckNo"].Visible = false;
                Grd.Columns["CheckDate"].Visible = false;
                Grd.Columns["Flow"].Visible = false;
                Grd.Columns["IsClosed"].Visible = false;
                Grd.Columns["accountsdetail"].Visible = false;


                if (Grd.Rows.Count > 0)
                {
                    Grd.Rows[0].Selected = true;
                }

                AccountsGlobals.ExtendCol(ref Grd, "VoucherDate");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SchVoucher_Load(object sender, EventArgs e)
        {
           
            FormateDesign();
            
          //  this.Font = AccountsGlobals.Font;
          //  this.BackColor = AccountsGlobals.FormColor;
            lstitem = (new VoucherController().GetVouchers(voucher, isPrinted, isPosted));
            Grd.DataSource = lstitem;

            //////////////////////////////////////////////////////////////
            FormatGrid();
            LoadTempGrid();
            //////////////////////////////////////////////////////////////
        }

        private void FormateDesign()
        {
            lblHeading.Text = Heading;

            if (type == VoucherType.CPV || type==VoucherType.BPV || type == VoucherType.BCV)
            {
                txtCredit.Visible = false;
                lblCredit.Visible = false;
            }
            else if(type == VoucherType.CRV || type == VoucherType.BRV || type == VoucherType.BDV)
            {
                txtDebit.Visible = false;
                lblDebit.Visible = false;
            }
        }

        private void grdTemp_EditValueChanged(object sender, EventArgs e)
        {
            if (grdTemp.filterCondition.Length != 0)
            {
                Common.Globals.condition = grdTemp.filterCondition;
                FormatCondition();
                subList = lstitem.FindAll(FilterBarFun);

                Grd.DataSource = null;
                Grd.DataSource = subList;
                FormatGrid();

            }
            else
            {
                Grd.DataSource = lstitem;
                FormatGrid();
            }

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SetParaOut();
        }

        private void Grd_DoubleClick(object sender, EventArgs e)
        {
            SetParaOut();
        }

        private void Grd_Click(object sender, EventArgs e)
        {
            PopulateDetailGrid();
           
        }

        private void PopulateDetailGrid()
        {
            try
            {
                voucher = new Voucher();
                voucher.VoucherNo = Convert.ToInt32(Grd.Rows[Grd.SelectedRows[0].Index].Cells["VoucherNo"].Value);
                voucher.VoucherDate = Convert.ToDateTime(Grd.Rows[Grd.SelectedRows[0].Index].Cells["VoucherDate"].Value);
                voucher.BankAccNo = (ChartOfAccounts)Grd.Rows[Grd.SelectedRows[0].Index].Cells["BankAccNo"].Value;

                voucher.VoucherType = type;
                item = new VoucherController().GetVouchers(voucher, isPrinted, isPosted)[0];
                GrdDetail.DataSource = item.Accounts;

                GrdDetail.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
                GrdDetail.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                GrdDetail.ColumnHeadersDefaultCellStyle.Font = new Font(grdTemp.Font, FontStyle.Bold);
                GrdDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                GrdDetail.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                GrdDetail.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                GrdDetail.GridColor = Color.Black;

                GrdDetail.Columns["AccountNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdDetail.Columns["AccountNo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdDetail.Columns["AccountNo"].Width = 80;

                GrdDetail.Columns["Narration"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdDetail.Columns["Narration"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdDetail.Columns["Narration"].Width = 150;

                GrdDetail.Columns["AccountName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdDetail.Columns["AccountName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdDetail.Columns["AccountName"].Width = 150;

                GrdDetail.Columns["Dr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdDetail.Columns["Dr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdDetail.Columns["Dr"].Width = 80;

                GrdDetail.Columns["Cr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdDetail.Columns["Cr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdDetail.Columns["Cr"].Width = 80;

                if (type == VoucherType.CRV)
                {
                    GrdDetail.Columns["Dr"].Visible = false;
                }
                if (type == VoucherType.CPV)
                {
                    GrdDetail.Columns["Cr"].Visible = false;
                }

                GrdDetail.Columns["AccountType"].Visible = false;
                GrdDetail.Columns["AccountDepth"].Visible = false;
                GrdDetail.Columns["ParentAccount"].Visible = false;
                GrdDetail.Columns["OpeningDebit"].Visible = false;
                GrdDetail.Columns["OpeningCredit"].Visible = false;
                GrdDetail.Columns["AdjustedDebit"].Visible = false;
                GrdDetail.Columns["AdjustedCredit"].Visible = false;
                GrdDetail.Columns["IsDetailed"].Visible = false;
                GrdDetail.Columns["IsLocked"].Visible = false;
                GrdDetail.Columns["IsEditable"].Visible = false;
                GrdDetail.Columns["IsPosted"].Visible = false;
                GrdDetail.Columns["BalFlag"].Visible = false;
                GrdDetail.Columns["PlFlag"].Visible = false;
                GrdDetail.Columns["ExpFlag"].Visible = false;
                GrdDetail.Columns["IsDeleted"].Visible = false;
                GrdDetail.Columns["InvoiceNo"].Visible = false;
                GrdDetail.Columns["Prefix"].Visible = false;
                GrdDetail.Columns["PreviousBalance"].Visible = false;

                AccountsGlobals.ExtendCol(ref GrdDetail, "Narration");
                item = null;

                CalculateDrCr();
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message, "Grd_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateDrCr()
        {
            decimal Debit = 0;
            decimal Credit = 0;

            for(int i=0;i< GrdDetail.Rows.Count; i++)
            {
                Debit += Convert.ToDecimal(GrdDetail.Rows[i].Cells["Dr"].Value);
                Credit += Convert.ToDecimal(GrdDetail.Rows[i].Cells["Cr"].Value);
            }
            
            txtDebit.Text = Debit.ToString();
            txtCredit.Text = Credit.ToString();
        }

        private void grdTemp_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    SendKeys.Send("\t");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GrdTemp_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GrdDetail_DoubleClick(object sender, EventArgs e)
        {
            SetParaOut();
        }

        private void Grd_SelectionChanged(object sender, EventArgs e)
        {
            PopulateDetailGrid();
        }
    }
}

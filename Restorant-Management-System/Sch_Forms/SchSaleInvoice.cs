using Accounts;
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

namespace Restorant_Management_System.Sch_Forms
{
    public partial class SchSaleInvoice : Form
    {
        private SaleInvoice sale;
        private List<SaleInvoice> sales = new List<SaleInvoice>();
        private List<SaleInvoice> subList = new List<SaleInvoice>();

        public SaleInvoice item = null;

        private List<SaleInvoice> SaleSelected = new List<SaleInvoice>();

        public int purchaseID;

        public bool isPending = true;
        public int Branchid = 0;
        public List<SaleInvoice> SelectedSale
        {
            get { return SaleSelected; }
            set { SaleSelected = value; }
        }
        public SchSaleInvoice()
        {
            InitializeComponent();
        }

        private void SchSaleInvoice_Load(object sender, EventArgs e)
        {
            try
            {             
              
              
                sales = new SaleInvoiceController().GetSalesInv(Branchid);
                //Set Data Source for Grid.
                sales = sales.OrderByDescending(x => x.SaleID).ToList();
                Grd.DataSource = sales;

                LoadGrid();

                LoadTempGrid();
               

                if (sales.Count <= 0)
                {
                    Grd.Visible = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "SchPurchase Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadGrid()
        {
            try
            {

                ////Set First Column.
                ///

                Grd.Columns["Saleid"].HeaderText = "Invoice No";
                Grd.Columns["Saleid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Saleid"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Saleid"].Width = 50;

                Grd.Columns["Saledate"].HeaderText = "Sale Date";
                Grd.Columns["Saledate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Saledate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Saledate"].Width = 120;

                Grd.Columns["PartyID"].HeaderText = "Party ID";
                Grd.Columns["PartyID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["PartyID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["PartyID"].Width = 100;

                Grd.Columns["PartyName"].HeaderText = "Party Name";
                Grd.Columns["PartyName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["PartyName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["PartyName"].Width = 200;

                Grd.Columns["Total"].HeaderText = "Total";
                Grd.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Total"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Total"].Width = 100;

              

                Grd.Columns["CardNo"].Visible = false;
                Grd.Columns["UserName"].Visible = false;
                Grd.Columns["BankAcc"].Visible = false;
                Grd.Columns["Name"].Visible = false;
                Grd.Columns["CustomerCell"].Visible = false;
                Grd.Columns["CustomerName"].Visible = false;
                Grd.Columns["TotalRetAmt"].Visible = false;

                Grd.Columns["Name"].Visible = false;
              
                Grd.Columns["IsGst"].Visible = false;
               Grd.Columns["TotalRetAmt"].Visible = true;
                Grd.Columns["Pending"].Visible = false;
                Grd.Columns["Invdisc"].Visible = false;
                Grd.Columns["Crcid"].Visible = false;
                Grd.Columns["Crcamt"].Visible = false;
                Grd.Columns["CardDeduction"].Visible = false;
                Grd.Columns["Cashamt"].Visible = false;
              
                Grd.Columns["Totaldisc"].Visible = false;
                //   Grd.Columns["TotalRetAmt"].Visible = true;IsFinalInvoice
                Grd.Columns["Balance"].Visible = false;
                Grd.Columns["SummaryNo"].Visible = false;
                Grd.Columns["IsFinalInvoice"].Visible = false;
                Grd.Columns["Party"].Visible = false;
                Grd.Columns["IsGST"].Visible = false;
                Grd.Columns["BranchID"].Visible = false;
                Grd.Columns["Reference"].Visible = false;
                Grd.Columns["PmtType"].Visible = false;
                Grd.Columns["SDateTime"].Visible = false;



                AccountsGlobals.ExtendCol(ref Grd, "PartyName");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SchPurchase LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void LoadTempGrid()
        {
            try
            {

                //  grdTemp.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Navy;
                grdTemp.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
                grdTemp.ColumnHeadersDefaultCellStyle.Font = new Font(grdTemp.Font, FontStyle.Bold);
                grdTemp.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                grdTemp.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdTemp.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                grdTemp.GridColor = System.Drawing.Color.Black;

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
        private bool FilterPurchases(SaleInvoice p)
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
                        case "[Name]":
                            res = res + " " + Convert.ToString((p.Name.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
                            break;
                        
                        case "[Saleid]":
                            res = res + " " + Convert.ToString((p.SaleID == Convert.ToInt32(fieldValue)));
                            break;
                      
                        default:
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

        private void grdTemp_EditValueChanged(object sender, EventArgs e)
        {
            if (grdTemp.filterCondition.Length != 0)
            {
                Common.Globals.condition = grdTemp.filterCondition;
                FormatCondition();
                subList = sales.FindAll(FilterPurchases);

                Grd.DataSource = null;
                Grd.DataSource = subList;
                LoadGrid();

            }
            else
            {
                Grd.DataSource = sale;
                LoadGrid();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SetParaout();
        }

        private void SetParaout()
        {
            try
            {
                if (Grd.Rows[Grd.CurrentRow.Index].Cells["SaleID"].Value != null)//if (Grd.SelectedRows.Count > 0)
                {
                    int Id = Convert.ToInt32((Grd.Rows[Grd.CurrentRow.Index].Cells["SaleID"].Value.ToString()));
                   
                
                    item = new SaleInvoiceController().GetSelectedSale(Id,Branchid);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetParaOut", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Grd_DoubleClick(object sender, EventArgs e)
        {
            SetParaout();
        }
    }
}

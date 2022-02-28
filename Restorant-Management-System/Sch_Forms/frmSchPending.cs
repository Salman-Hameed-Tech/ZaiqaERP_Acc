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
    public partial class frmSchPending : Form
    {
        private SaleInvoice sale;
        private List<SaleInvoice> sales = new List<SaleInvoice>();
        private List<SaleInvoice> subList = new List<SaleInvoice>();

        private SaleInvoice selectedSale;

        public int purchaseID;

        public int SaleID=0;

        public bool isPending = true;
        public SaleInvoice SelectedSale
        {
            get { return selectedSale; }
            set { selectedSale = value; }
        }
        public frmSchPending()
        {
            InitializeComponent();
        }

        private void frmSchPending_Load(object sender, EventArgs e)
        {
            try
            {
                //Get Purchase List.
                string where = "";

                if (this.isPending == true)
                {
                    where = "  and SaleInvoice.isPending=1  and  SaleInvoice.BranchID="+Globals.BranchID+"   ";
                }
                else
                    where = " and SaleInvoice.isPending=0";

               // sales = new SaleInvoiceController().GetPendingSales(where);
                //Set Data Source for Grid.
                sales = sales.OrderByDescending(x => x.SaleID).ToList();
                Grd.DataSource = sales;
                //FilterGrd.DataSource = sales;
                LoadGrid();
                LoadTempGrid();
               
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
                Grd.Columns["Saleid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Saleid"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Saleid"].Width = 50;
                Grd.Columns["Saleid"].ReadOnly = true;
                ///



                //////Set Second Column.
                //Grd.Columns["Saledate"].Caption = "Date";
                //Grd.Splits[0].DisplayColumns["Saledate"].HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
                //Grd.Splits[0].DisplayColumns["Saledate"].Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
                //Grd.Splits[0].DisplayColumns["Saledate"].Locked = true;
                //Grd.Splits[0].DisplayColumns["Saledate"].Width = 58;
                Grd.Columns["Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Name"].Width = 120;
                Grd.Columns["Name"].HeaderText = "Item";
                ////Set 3rd Column.

              //  Grd.Columns["IsGst"].Visible = false;
                Grd.Columns["Saledate"].Visible = false;
                Grd.Columns["Pending"].Visible = false;
                Grd.Columns["Invdisc"].Visible = false;
                Grd.Columns["Crcid"].Visible = false;
                Grd.Columns["Crcamt"].Visible = false;
                Grd.Columns["CardDeduction"].Visible = false;
                Grd.Columns["Cashamt"].Visible = false;
                Grd.Columns["Total"].Visible = false;
                Grd.Columns["Totaldisc"].Visible = false;
                Grd.Columns["TotalRetAmt"].Visible = false;
                Grd.Columns["Balance"].Visible = false;
                Grd.Columns["SummaryNo"].Visible = false;
                Grd.Columns["Party"].Visible = false;
                Grd.Columns["IsGST"].Visible = false;
                Grd.Columns["Reference"].Visible = false;
                Grd.Columns["SDateTime"].Visible = false;
                Grd.Columns["BranchID"].Visible = false;
                Grd.Columns["PmtType"].Visible = false;
             

                AccountsGlobals.ExtendCol(ref Grd, "Name");
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SchPurchase LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private bool FilterBarFun(SaleInvoice p)
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
                        case "[Saleid]":
                            res = res + " " + Convert.ToString((p.SaleID.ToString() == (fieldValue).ToString()));
                            break;
                        case "[Name]":
                            res = res + " " + Convert.ToString((p.Name.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
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
                subList = sales.FindAll(FilterBarFun);

                Grd.DataSource = null;
                Grd.DataSource = subList;
                LoadGrid();

            }
            else
            {
                Grd.DataSource = sales;
                LoadGrid();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            
                SetParaOut();
            
        }
        public void SetParaOut()
        {
            try
            {
                if (Grd.Rows[Grd.CurrentRow.Index].Cells["Saleid"].Value !=null)
                {
                    SaleID = Convert.ToInt32(Grd.Rows[Grd.CurrentRow.Index].Cells["Saleid"].Value);
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
            SetParaOut();
        }
    }
}

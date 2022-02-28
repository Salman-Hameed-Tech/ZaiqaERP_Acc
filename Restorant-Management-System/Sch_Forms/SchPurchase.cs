using Accounts;
using Accounts.Forms;
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
    public partial class SchPurchase : Form
    {
        private Purchase purchase;
        private List<Purchase> purchases = new List<Purchase>();
        private List<Purchase> subList = new List<Purchase>();

        private Purchase selectedPurchase;

        public int purchaseID;

        //Properties.
        public Purchase SelectedPurchase
        {
            get { return selectedPurchase; }
            set { selectedPurchase = value; }
        }
        public SchPurchase()
        {
            InitializeComponent();
        }

        private void SchPurchase_Load(object sender, EventArgs e)
        {
            try
            {
                //Get Purchase List.
                purchases = new PurchaseController().GetPurhcases();
                //Set Data Source for Grid.
                purchases = purchases.OrderByDescending(x => x.InvoiceNo).ToList();
                Grd.DataSource = purchases;

                FormatGrid();
                LoadTempGrid();
                if (purchases.Count <= 0)
                {
                    Grd.Visible = false;
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "SchPurchase Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void FormatGrid()
        {
            try
            {
                Grd.Columns["InvoiceNo"].HeaderText = "Invoice No";
                Grd.Columns["InvoiceNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["InvoiceNo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["InvoiceNo"].Width = 50;

                Grd.Columns["PurchaseDate"].HeaderText = "Date";
                Grd.Columns["PurchaseDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["PurchaseDate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["PurchaseDate"].Width = 120;

                Grd.Columns["BillNumber"].HeaderText = "Bill No";
                Grd.Columns["BillNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["BillNumber"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
               Grd.Columns["BillNumber"].Width = 100;

                Grd.Columns["Vendor"].HeaderText = "Vendor";
                Grd.Columns["Vendor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Vendor"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Vendor"].Width = 110;

                Grd.Columns["Remarks"].HeaderText = "Remarks";
                Grd.Columns["Remarks"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Remarks"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Remarks"].Width = 200;

                Grd.Columns["Discount"].Visible = false;
                Grd.Columns["IsAdjust"].Visible = false;
                Grd.Columns["CourierAccount"].Visible = false;
                Grd.Columns["CourierAmount"].Visible = false;
                Grd.Columns["TrackingID"].Visible = false;
                Grd.Columns["PaymentMode"].Visible = false;//  
                Grd.Columns["GSTPer"].Visible = false;
                Grd.Columns["GSTAmt"].Visible = false;
                Grd.Columns["GSTPer"].Visible = false;
                Grd.Columns["UserNo"].Visible = false;
               Grd.Columns["BillNumber"].Visible = true;
                Grd.Columns["AmountPaid"].Visible = false;
                Grd.Columns["AddToPrint"].Visible = false;
                Grd.Columns["BranchID"].Visible = false;
                Grd.Columns["vendorname"].Visible = false;

                if (Grd.Rows.Count > 0)
                {
                    Grd.Rows[0].Selected = true;
                }

                AccountsGlobals.ExtendCol(ref Grd, "Vendor");
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool FilterPurchases(Purchase p)
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
                        case "[Vendor]":
                            res = res + " " + Convert.ToString((p.Vendor.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
                            break;
                        case "[BillNumber]":
                            res = res + " " + Convert.ToString((p.BillNumber.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
                            break;
                        case "[InvoiceNo]":
                            res = res + " " + Convert.ToString((p.InvoiceNo == Convert.ToInt32(fieldValue)));
                            break;
                        case "[PurchaseDate]":
                            res = res + " " + Convert.ToString((p.PurchaseDate.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
                            break;
                        case "[TotalAmount]":
                            res = res + " " + Convert.ToString((p.TotalAmount.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
                            break;
                        case "[CourierAccount]":
                            res = res + " " + Convert.ToString((p.CourierAccount.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
                            break;
                        case "[TrackingID]":
                            res = res + " " + Convert.ToString((p.TrackingID.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
                            break;
                        case "[CourierAmount]":
                            res = res + " " + Convert.ToString((p.CourierAmount.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
                            break;
                        case "[Remarks]":
                            res = res + " " + Convert.ToString((p.Remarks.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
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
                subList = purchases.FindAll(FilterPurchases);

                Grd.DataSource = null;
                Grd.DataSource = subList;
                FormatGrid();

            }
            else
            {
                Grd.DataSource = purchases;
                FormatGrid();
            }
        }
        public void SetParaOut()
        {
            try
            {
                if (Grd.CurrentRow!=null)
                {
                    selectedPurchase = new PurchaseController().GetSinglePurchase(Convert.ToInt32((Grd.Rows[Grd.CurrentRow.Index].Cells["InvoiceNo"].Value.ToString())));
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SetParaOut();
        }
    }
}

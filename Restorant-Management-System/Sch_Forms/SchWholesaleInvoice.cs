using Accounts;
using Common;
using CommonController;
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
    public partial class SchWholesaleInvoice : Form
    {
        public WholeSale sale;
        private List<WholeSale> salelist = new List<WholeSale>();
        private List<WholeSale> subList = new List<WholeSale>();
      
        public SchWholesaleInvoice()
        {
            InitializeComponent();
        }

        private void SchWholesaleInvoice_Load(object sender, EventArgs e)
        {
          
            salelist = new WholesaleController().GetWSale();
        
            salelist = salelist.OrderByDescending(x => x.ID).ToList();
            Grd.DataSource = salelist;

            FormatGrid();
            LoadTempGrid();
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
                Grd.Columns["ID"].HeaderText = "Invoice No";
                Grd.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["ID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["ID"].Width = 50;

                Grd.Columns["Dated"].HeaderText = "Date";
                Grd.Columns["Dated"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Dated"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Dated"].Width = 100;

                Grd.Columns["BuyerName"].HeaderText = "Buyer Name";
                Grd.Columns["BuyerName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["BuyerName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["BuyerName"].Width = 100;

                Grd.Columns["InvoiceDiscountPer"].HeaderText = "Discount%";
                Grd.Columns["InvoiceDiscountPer"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["InvoiceDiscountPer"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["InvoiceDiscountPer"].Width = 60;

                Grd.Columns["InvoiceDiscount"].HeaderText = "Disc Amount";
                Grd.Columns["InvoiceDiscount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["InvoiceDiscount"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["InvoiceDiscount"].Width = 70;

                Grd.Columns["NetTotal"].HeaderText = "Total Amount";
                Grd.Columns["NetTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["NetTotal"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["NetTotal"].Width = 80;

                Grd.Columns["BranchName"].HeaderText = "Branch Name";
                Grd.Columns["BranchName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["BranchName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["BranchName"].Width = 150;

                Grd.Columns["UserName"].HeaderText = "Created By";
                Grd.Columns["UserName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["UserName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["UserName"].Width = 150;


                Grd.Columns["Remarks"].HeaderText = "Remarks";
                Grd.Columns["Remarks"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Remarks"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Remarks"].Width = 200;

               
                Grd.Columns["UserNo"].Visible = false;
                Grd.Columns["BuyerID"].Visible = false;
                Grd.Columns["BranchID"].Visible = false;
                Grd.Columns["PaymentMode"].Visible = false;

               
                AccountsGlobals.ExtendCol(ref Grd, "BuyerName");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool FilterPurchases(WholeSale p)
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
                        case "[BuyerName]":
                            res = res + " " + Convert.ToString((p.BuyerName.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
                            break;
                        case "[Dated]":
                            res = res + " " + Convert.ToString((p.Dated.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
                            break;
                        case "[ID]":
                            res = res + " " + Convert.ToString((p.ID == Convert.ToInt32(fieldValue)));
                            break;
                        case "[BranchName]":
                            res = res + " " + Convert.ToString((p.BranchName.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
                            break;
                        case "[InvoiceDiscountPer]":
                            res = res + " " + Convert.ToString((p.InvoiceDiscountPer.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
                            break;
                        case "[InvoiceDiscount]":
                            res = res + " " + Convert.ToString((p.InvoiceDiscount.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
                            break;
                        case "[NetTotal]":
                            res = res + " " + Convert.ToString((p.NetTotal.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
                            break;
                        case "[UserName]":
                            res = res + " " + Convert.ToString((p.UserName.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
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
      
        public void SetParaOut()
        {
            try
            {
                if (Grd.Rows[Grd.CurrentRow.Index].Cells["ID"].Value != null)//if (Grd.SelectedRows.Count > 0)
                {
                    sale = new WholesaleController().GetSingleWSale(Convert.ToInt32(Grd.Rows[Grd.CurrentRow.Index].Cells["ID"].Value), Convert.ToDateTime(Grd.Rows[Grd.CurrentRow.Index].Cells["Dated"].Value));
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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SetParaOut();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdTemp_EditValueChanged(object sender, EventArgs e)
        {
            if (grdTemp.filterCondition.Length != 0)
            {
                Common.Globals.condition = grdTemp.filterCondition;
                FormatCondition();
                subList = salelist.FindAll(FilterPurchases);

                Grd.DataSource = null;
                Grd.DataSource = subList;
                FormatGrid();

            }
            else
            {
                Grd.DataSource = salelist;
                FormatGrid();
            }
        }

        private void Grd_DoubleClick_1(object sender, EventArgs e)
        {
            SetParaOut();
        }
    }
}

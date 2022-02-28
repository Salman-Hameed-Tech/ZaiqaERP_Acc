using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using CategoryControlle;

namespace Restorant_Management_System.Sch_Forms
{
    public partial class SchWastage : Form
    {
        private Wastage purchase;
        public Wastage item = null;
        private List<Wastage> purchases = new List<Wastage>();
        private List<Wastage> subList = new List<Wastage>();
        public string where = "";
        public SchWastage()
        {
            InitializeComponent();
        }


        private void SchWastage_Load(object sender, EventArgs e)
        {
            try
            {
                //Get Purchase List.
                purchases = new WastageController().GetWastageData(0, where);
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
        public void SetValues()
        {
            try
            {

                if (Grd.SelectedRows.Count > 0)
                {

                    item = new Wastage();

                    item.InvoiceNo = Convert.ToInt32(Grd.CurrentRow.Cells["InvoiceNo"].Value);
                    item.WastageDate = Convert.ToDateTime(Grd.CurrentRow.Cells["WastageDate"].Value);
                    item.Discount = Convert.ToDecimal(Grd.CurrentRow.Cells["Discount"].Value);
                    item.Narration = Convert.ToString(Grd.CurrentRow.Cells["Narration"].Value);
                    item.AmountPaid = Convert.ToDecimal(Grd.CurrentRow.Cells["totalAmount"].Value);


                    item.WastageLines = new WastageController().GetWastagesline(item.InvoiceNo);


                    this.Close();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetValues", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private bool FilterPurchases(Wastage p)
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
                        case "[InvoiceNo]":
                            res = res + " " + Convert.ToString((p.InvoiceNo.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
                            break;
                        case "[WastageDate]":
                            res = res + " " + Convert.ToString((p.WastageDate.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
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
                MessageBox.Show(ex.Message, "SchChallan FilterChallan", MessageBoxButtons.OK, MessageBoxIcon.Question);
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
        private void FormatGrid()
        {
            try
            {
                Grd.Columns["invoiceNo"].HeaderText = "InvoiceNo";
                Grd.Columns["invoiceNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["invoiceNo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["invoiceNo"].Width = 100;

                Grd.Columns["wastageDate"].HeaderText = "WastageDate";
                Grd.Columns["wastageDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["wastageDate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["wastageDate"].Width = 100;



                Grd.Columns["totalAmount"].HeaderText = "TotalAmount";
                Grd.Columns["totalAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["totalAmount"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["totalAmount"].Width = 220;

                //Grd.Columns["CounterName"].HeaderText = "CounterName";
                //Grd.Columns["CounterName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //Grd.Columns["CounterName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //Grd.Columns["CounterName"].Width = 200;

                //Grd.Columns["BranchID"].Visible = false;
            


                if (Grd.Rows.Count > 0)
                {
                    Grd.Rows[0].Selected = true;
                }

                //AccountsGlobals.ExtendCol(ref Grd, "Vendor");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Grd_DoubleClick(object sender, EventArgs e)
        {
            SetValues();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SetValues();
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
    }
}

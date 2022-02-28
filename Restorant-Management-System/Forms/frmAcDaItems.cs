using Accounts;
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

namespace Restorant_Management_System.Forms
{
    public partial class frmAcDaItems : Form
    {

        List<Common.SchItems> lstitem = new List<Common.SchItems>();
        List<Common.SchItems> subList = new List<Common.SchItems>();
        public int ParaOutID;
        public frmAcDaItems()
        {
            InitializeComponent();
        }

        private void frmAcDaItems_Load(object sender, EventArgs e)
        {
            ParaOutID = 0;


            lstitem = (new SchItemController().LoadGrid());
            GrdAc.DataSource = lstitem;


            LoadGrid();
           // LoadTempGrid();
          // FormatGrid();

        }
        public void LoadGrid()
        {
            try
            {

                GrdAc.Columns["itemid"].HeaderText = "Item ID";
                GrdAc.Columns["itemid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdAc.Columns["itemid"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdAc.Columns["itemid"].Width = 50;

                GrdAc.Columns["categoryname"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdAc.Columns["categoryname"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdAc.Columns["categoryname"].Width = 120;
                GrdAc.Columns["categoryname"].HeaderText = "Department Name";

                GrdAc.Columns["companyname"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdAc.Columns["companyname"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdAc.Columns["companyname"].Width = 120;
                GrdAc.Columns["companyname"].HeaderText = "Company Name";

                GrdAc.Columns["productname"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdAc.Columns["productname"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdAc.Columns["productname"].Width = 120;
                GrdAc.Columns["productname"].HeaderText = "Product Name";

                GrdAc.Columns["design"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdAc.Columns["design"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdAc.Columns["design"].Width = 90;
                GrdAc.Columns["design"].HeaderText = "Design";

                GrdAc.Columns["Size"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdAc.Columns["Size"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdAc.Columns["Size"].Width = 90;
                GrdAc.Columns["Size"].HeaderText = "Size";

                GrdAc.Columns["VSelect1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdAc.Columns["VSelect1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdAc.Columns["VSelect1"].Width = 90;
                GrdAc.Columns["VSelect1"].HeaderText = "Select";

                /*
                Grd.Columns["companyname"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["companyname"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["companyname"].Width = 50;
                Grd.Columns["productname"].HeaderText = "Product Name";

                Grd.Columns["itemid"].ReadOnly = true;
                Grd.Columns["ItemName"].ReadOnly = true;

                Grd.Columns["companyname"].Visible = false;
                Grd.Columns["OpQty1"].Visible = false;
                Grd.Columns["Purprice1"].Visible = false;
                Grd.Columns["AddToPrint"].Visible = false;
                Grd.Columns["CurrentStock"].Visible = false;
                Grd.Columns["IsLoacked"].Visible = false;
                Grd.Columns["PurchasePrice"].Visible = false;
                Grd.Columns["SalePrice"].Visible = false;
                Grd.Columns["Isactive"].Visible = false;
                Grd.Columns["ShortKey"].Visible = false;
                Grd.Columns["DiscountLimit"].Visible = false;
                Grd.Columns["ReorderLimit"].Visible = false;
                Grd.Columns["PurchaseAccount"].Visible = false;
                Grd.Columns["SaleAccount"].Visible = false;
                Grd.Columns["IsActive"].Visible = false;
                Grd.Columns["Category"].Visible = false;
                Grd.Columns["BarCode"].Visible = false;
                //  Grd.Splits[0].DisplayColumns[15].Visible = false;
                */
                AccountsGlobals.ExtendCol(ref GrdAc, "categoryname");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "FrmStockAdj LoadGrid.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadTempGrid()
        {
            try
            {

                //  grdTemp.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Navy;
                GrdAc.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
                GrdAc.ColumnHeadersDefaultCellStyle.Font = new Font(GrdAc.Font, FontStyle.Bold);
                GrdAc.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                GrdAc.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                GrdAc.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                GrdAc.GridColor = System.Drawing.Color.Black;

                GrdAc.MultiSelect = false;

                DataGridViewCell TextCell = new DataGridViewTextBoxCell();
                DataGridViewColumn newCol = new DataGridViewColumn();

                for (int i = 0; i < GrdAc.Columns.Count; i++)
                {
                    newCol = new DataGridViewColumn();
                    newCol.CellTemplate = TextCell;
                    newCol.HeaderText = GrdAc.Columns[i].HeaderText;
                    newCol.Name = GrdAc.Columns[i].Name;
                    newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    newCol.Visible = GrdAc.Columns[i].Visible;
                    newCol.Width = GrdAc.Columns[i].Width;
                    GrdAc.Columns.Add(newCol);

                }
                GrdAc.Rows.Add(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadTempGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private bool FilterBarFun(Common.SchItems p)
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
                        case "[ItemID]":
                            res = res + " " + Convert.ToString((p.ItemID == Convert.ToInt16(fieldValue)));
                            break;
                        case "[Categoryname]":
                            res = res + " " + Convert.ToString((p.Categoryname.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
                            break;
                        case "[Companyname]":
                            res = res + " " + Convert.ToString((p.Companyname.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
                            break;
                        case "[Productname]":
                            res = res + " " + Convert.ToString((p.Productname.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
                            break;
                        case "[Design]":
                            res = res + " " + Convert.ToString((p.Design.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
                            break;
                        case "[Size]":
                            res = res + " " + Convert.ToString(p.Size.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper()));
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
            if (GrdAc.filterCondition.Length != 0)
            {
                Common.Globals.condition = GrdAc.filterCondition;
                FormatCondition();
                subList = lstitem.FindAll(FilterBarFun);

                GrdAc.DataSource = null;
                GrdAc.DataSource = subList;
                LoadGrid();

            }
            else
            {
                GrdAc.DataSource = lstitem;
                LoadGrid();
            }
        }

        private void Grd_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    new SchItemController().UpdateItem(Convert.ToInt32(Grd.Rows[Grd.CurrentRow.Index].Cells["itemid"].Value), Convert.ToBoolean((Convert.ToBoolean(Grd.Rows[Grd.CurrentRow.Index].Cells["VSelect1"].Value) == false ? 0 : 1)));
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }

        private void Grd_Click(object sender, EventArgs e)
        {
            
        }

        private void Grd_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
           
        }

        private void Grd_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                new SchItemController().UpdateItem(Convert.ToInt32(GrdAc.Rows[GrdAc.CurrentRow.Index].Cells["itemid"].Value), Convert.ToBoolean((Convert.ToBoolean(GrdAc.Rows[GrdAc.CurrentRow.Index].Cells["VSelect1"].Value) == false ? 0 : 1)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

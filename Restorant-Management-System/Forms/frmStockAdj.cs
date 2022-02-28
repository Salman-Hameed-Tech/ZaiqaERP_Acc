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

namespace Restorant_Management_System.Forms
{
    public partial class frmStockAdj : Form
    {
        private List<Common.Item> items;
        private List<Common.Item> subItems = new List<Common.Item>();
        private Common.Item item;

        public frmStockAdj()
        {
            InitializeComponent();
        }

        private void frmStockAdj_Load(object sender, EventArgs e)
        {
            try
            {
                if (items == null)
                {
                    items = new List<Common.Item>();
                }

                LoadCategory();
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmStockAdj_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadGrid()
        {
            try
            {
                items = new ItemController().GetItems(this.cbxCategory.Text);

                //Set Data Source for Grid.

                Grd.DataSource = items;

                Grd.Columns["itemid"].HeaderText = "Item ID";
                Grd.Columns["ItemName"].HeaderText = "Item Name";

                Grd.Columns["itemid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["itemid"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["itemid"].Width = 50;

                Grd.Columns["ItemName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["ItemName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["ItemName"].Width = 50;

                //Grd.Splits[0].DisplayColumns["itemid"].HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
                //Grd.Splits[0].DisplayColumns["ItemName"].HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;


                //Grd.Columns["itemid"].Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
                //Grd.Columns["ItemName"].Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;

            

                Grd.Columns["itemid"].ReadOnly = true;
                Grd.Columns["ItemName"].ReadOnly = true;

                Grd.Columns["Sticker"].Visible = false;
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

                AccountsGlobals.ExtendCol(ref Grd, "ItemName");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "FrmStockAdj LoadGrid.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadCategory()
        {
            try
            {
                List<Category> cats = new CategoryController().GetCategories();
                cats.RemoveAt(0);

                this.cbxCategory.DataSource = cats;
                this.cbxCategory.DisplayMember = "Name";
                this.cbxCategory.ValueMember = "Id";

                this.cbxCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cbxCategory.AutoCompleteSource = AutoCompleteSource.ListItems;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmItem LoadCategory");
            }
        }
        private bool FilterItems(Common.Item i)
        {
            return i.ItemID == Convert.ToInt32(this.txtItemID.Text);
        }
        private bool ValidateControls()
        {
            try
            {
                if (this.txtAdjStock.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Please Enter New Stock.", "Check Stock...", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.txtAdjStock.Focus();
                    return false;
                }
                else if (this.txtAdjPrice.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Please Enter New Price.", "Check Price...", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.txtAdjPrice.Focus();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmStockAdj ValidateControls", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void ClearControls()
        {
            try
            {
                this.txtItemID.Clear();

                this.txtAdjStock.Clear();
                this.txtAdjStock.Text = null;

                this.txtAdjPrice.Clear();
                this.txtAdjPrice.Text = null;

                this.cbxCategory.Text = "";
                LoadCategory();

                this.cbxCategory.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmStockAdj ClearControls", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetStock()
        {
            try
            {

                if (Grd.CurrentRow != null)
                {
                    this.txtCurrentStock.Clear();
                    this.txtCurrentPrice.Clear();

                    if (items.Count > 0)
                    {
                        int rowIndex = Grd.CurrentRow.Index;
                        int colIndex = Grd.CurrentCell.ColumnIndex;

                        item = new ItemController().GetItemDetail(Convert.ToInt32(Grd.Rows[rowIndex].Cells["ItemID"].Value));

                        if (item != null)
                        {
                            this.txtCurrentStock.Text = item.CurrentStock.ToString();
                            this.txtCurrentPrice.Text = item.PurchasePrice.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmStockAdj SetStock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtItemID_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyCode == Keys.F1)
            //    {
            //        Accounts.SchForms.SchItems frm = new PointOfSale.SchForms.SchItems();
            //        frm.ShowDialog();

            //        if (frm.ParaOutID > 0)
            //        {
            //            this.txtItemID.Text = frm.ParaOutID.ToString();
            //        }
            //    }
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        System.Windows.Forms.SendKeys.Send("\t");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "FrmStockAdj cbxItemID_KeyDown.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                StockAdj adj = new StockAdj();

                adj.AdjDate = System.DateTime.Now.Date;
                adj.Item = new Item(Convert.ToInt32(Grd.Rows[Grd.SelectedRows[0].Index].Cells["ItemID"].Value));
                adj.PreviousQuantity = Convert.ToDecimal(this.txtCurrentStock.Text);
                adj.PreviousPrice = Convert.ToDecimal(this.txtCurrentPrice.Text);
                adj.CurrentQuantity = Convert.ToDecimal(this.txtAdjStock.Text);
                adj.CurrentPrice = Convert.ToDecimal(this.txtAdjPrice.Text);
                adj.User = User.UserNo;

                if (new StockAdjController().SaveAdjustment(adj))
                {
                    MessageBox.Show("Saved Successfully.", "Saved...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearControls();
                }
            }
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (typeof(System.Int32) == cbxCategory.SelectedValue.GetType())
                {
                    if ((int)cbxCategory.SelectedValue >= 0)
                    {
                        LoadGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmStockAdjustment cbxCategory_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxCategory_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadGrid();

                SetStock();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmStockAdj cbxCategory_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtItemID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int cIndex;

                if (this.txtItemID.Text.Trim().Length == 0)
                {
                    subItems.Clear();
                    LoadGrid();
                    //this.Grd.SelectedRows.Clear();
                    //this.Grd.MoveRelative(0,0);
                }
                else
                {
                    subItems = items.FindAll(FilterAccounts);
                    if (subItems.Count > 0)
                    {
                        LoadGrid();
                    }
                    else
                    {
                        this.Grd.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmStockAdj txtItemID_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool FilterAccounts(Item a)
        {
            return a.ItemName.ToString().ToUpper().Contains(this.txtItemID.Text.ToUpper());
        }

        private void cbxCategory_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    System.Windows.Forms.SendKeys.Send("\t");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmStockAdj cbxCategory_KeyDown.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

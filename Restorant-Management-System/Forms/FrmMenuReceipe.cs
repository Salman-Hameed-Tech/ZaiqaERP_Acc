using Accounts;
using Accounts.Forms;
using CategoryControlle;
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

namespace Restorant_Management_System.Forms
{
    public partial class FrmMenuReceipe : Form
    {
        private Item item;
        private List<Item> menuList;
        public FrmMenuReceipe()
        {
            InitializeComponent();
        }

        private void FrmMenuReceipe_Load(object sender, EventArgs e)
        {
            ClearControls();
        }
        private void ClearControls()
        {
            this.txtId.Text = "";
            this.txtName.Clear();
            LoadGrid();
        }

        private bool LoadGrid()
        {
            try
            {
                //Set Grid.
                ///////////////////////////////////////////////////////////////////////////////////////////////////
                AccountsGlobals.SetGridStyle(ref Grd);

                Grd.EnableHeadersVisualStyles = false;
                //////////////////////////////////////////////////////////////////////////////////////////////////              
                //Specify which type of cell in this column (DataGridViewTextBoxCell,DataGridViewCheckBoxCell,
                //DataGridViewComboBoxCell,DataGridViewImageColumn,DataGridViewButtonColumn,DataGridViewLinkColumn



                DataGridViewCell TextCell = new DataGridViewTextBoxCell();
                DataGridViewCell DecimalCell = new TNumEditDataGridViewCell(2);
                DataGridViewCell RateCell = new TNumEditDataGridViewCell(4);
                DataGridViewCell IntCell = new TNumEditDataGridViewCell(0);

                DataGridViewComboBoxColumn comboCol = new DataGridViewComboBoxColumn();
                DataGridViewCell ComboCell = new DataGridViewComboBoxCell();

                DataGridViewComboBoxColumn comboCol2 = new DataGridViewComboBoxColumn();
                DataGridViewCell ComboCell2 = new DataGridViewComboBoxCell();

                //Col 1
                //////////////////////////////////////////////////////////////////////////////////////////////////                

                DataGridViewColumn newCol = new DataGridViewColumn(); // add a column to the grid                


               
                //////////////////////////////////////////////////////////////////////////////////////////////////                
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Item ID";
                newCol.Name = "ItemID";
                newCol.CellTemplate = TextCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = false;
                // newCol.Visible = Globals.PackingColumnVisible;
                newCol.Width = 80;
                Grd.Columns.Add(newCol);

                /////////////////////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Item Name";
                newCol.Name = "ItemName";
                newCol.CellTemplate = TextCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;
                newCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                newCol.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                newCol.Width = 250;
                Grd.Columns.Add(newCol);
                
                //////////////////////////////////////////////////////////////////////////////////////////////////               
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Quantity";
                newCol.Name = "Quantity";
                newCol.CellTemplate = RateCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.Width = 90;
                Grd.Columns.Add(newCol);
                
                //Col 7
                //////////////////////////////////////////////////////////////////////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "SrNo";
                newCol.Name = "SrNo";
                newCol.CellTemplate = IntCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = false;
                newCol.Width = 70;
                Grd.Columns.Add(newCol);

                //Col 8
                //////////////////////////////////////////////////////////////////////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "IsDeleted";
                newCol.Name = "IsDeleted";
                newCol.CellTemplate = IntCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = false;
                newCol.Width = 70;
                Grd.Columns.Add(newCol);

                Grd.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                AccountsGlobals.ExtendCol(ref Grd, "ItemName");





                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveRecord())
                {
                    MessageBox.Show("Record is Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ClearControls();
                }
                else
                {
                    MessageBox.Show("Give some items in the Grid First.", "Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Saving()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool SaveRecord()
        {
            DialogResult r = MessageBox.Show("Do you Want to Save Record?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                if (PopulateMenus())
                {
                    if (new RecipieController().SaveRecipie(item))
                    {
                        return true;
                    }

                }
            }

            return false;
        }

        private bool PopulateMenus()
        {
            try
            {
                this.item = new Item();
                item.BranchID = Globals.BranchID;
                this.item.ItemID = Convert.ToInt16(this.txtId.Text.Trim());
               // this.item.ItemName.ProductName = this.txtName.Text.Trim();
                AddReceipes();
                this.item.ReceipeList = this.menuList;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PopulateMenus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool AddReceipes()
        {
            try
            {
                if (Grd.Rows.Count > 0)
                {
                    menuList = new List<Item>();

                    for (int i = 0; i < Grd.Rows.Count-1; i++)
                    {
                        if (Grd.Rows[i].Cells["ItemID"].Value != null)
                        {
                            Item obj = new Item();
                            obj.ItemID = Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value);
                            obj.Quantity = Convert.ToDecimal(Grd.Rows[i].Cells["Quantity"].Value);
                            menuList.Add(obj);
                        }

                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AddReceipes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnSch_Click(object sender, EventArgs e)
        {
            SearchItem();
        }

        private void SearchItem()
        {
            try
            {
                
                Accounts.SchForms.SchItems sch = new Accounts.SchForms.SchItems();
                sch.isMarination =true;
                sch.condition = " where ismarinated=1 ";
                sch.ShowDialog();
                List<Item> lstitem = new List<Item>();
                lstitem = sch.subList1;
                if (lstitem.Count > 0)
                {
                    ClearControls();
                    for (int i = 0; i < lstitem.Count; i++)
                    {
                      
                        txtId.Text = lstitem[i].ItemID.ToString();
                        txtName.Text= lstitem[i].ItemName.ToString();
                        if (GetReceipe(lstitem[i].ItemID))
                        {
                            PopulateGrid();
                            Grd.Focus();
                        }

                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "SearchItem", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
        }

        private void PopulateGrid()
        {
            try
            {
                if (menuList.Count > 0)
                {
                    Grd.DataSource = null;
                    LoadGrid();
                    int i = 0;
                    foreach (Item m in menuList)
                    {
                        Grd.Rows.Add();

                        Grd.Rows[i].Cells["ItemID"].Value = m.ItemID;
                        Grd.Rows[i].Cells["ItemName"].Value = m.ItemName.ProductName;
                        Grd.Rows[i].Cells["Quantity"].Value = m.Quantity;

                        i++;
                    }
                }
                else
                {
                    //throw new Exception("No Menu Receipe found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        private bool GetReceipe(int itemID)
        {
            try
            {
                menuList = new RecipieController().GetRecipieList(itemID);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Grd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                int rowIndex = Grd.CurrentRow.Index;
                int colIndex = Grd.CurrentCell.ColumnIndex;


                if (e.KeyCode == Keys.F1)
                {

                    Accounts.SchForms.SchItems sch = new Accounts.SchForms.SchItems();
                    sch.isMarination = true;
                    sch.condition = " where isnull(ismarinated,0)=0 ";
                    sch.ShowDialog();

                    if (sch.subList1.Count>0)
                    {
                        Grd.Rows[rowIndex].Cells["ItemID"].Value = sch.subList1[0].ItemID;
                        Grd.Rows[rowIndex].Cells["ItemName"].Value = sch.subList1[0].ItemName;
                        Grd.Rows[rowIndex].Cells["Quantity"].Selected = true;

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Grd_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void Grd_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = Grd.CurrentRow.Index;
                int colIndex = Grd.CurrentCell.ColumnIndex;

                if (colIndex == Grd.Columns["ItemID"].Index)
                {
                    if (Grd.Rows[Grd.CurrentRow.Index].Cells["ItemID"].Value != null && Convert.ToInt16(Grd.Rows[Grd.CurrentRow.Index].Cells["ItemID"].Value) != 0)
                    {
                        if (VerifyItem(Convert.ToInt16(Grd.Rows[Grd.CurrentRow.Index].Cells["ItemID"].Value)))
                        {
                            Grd.Rows[rowIndex].Cells["ItemID"].Value = item.ItemID;
                            Grd.Rows[rowIndex].Cells["ItemName"].Value = item.ItemName.ProductName;
                            Grd.Rows[rowIndex].Cells["ItemName"].Selected = true;
                        }
                        else
                        {
                            MessageBox.Show("No Item Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Grd.Rows[rowIndex].Cells["ItemID"].Value = null;
                            Grd.Rows[rowIndex].Cells["ItemID"].Selected = true;

                        }


                    }

                 
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Grd_CellEndEdit", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private bool VerifyItem(int itemid)
        {
            try
            {
                item = new ItemController().GetRecipieItem(itemid);
                if(item.ItemID==0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "VerifyItem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void txtId_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    SearchItem();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "txtId_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtId_Leave(object sender, EventArgs e)
        {
            try
            {
                List<SchItems> items = new List<SchItems>();
                items= new ItemController().GetMarinatedIems(" where ismarinated=1 and Itemid="+Convert.ToInt32(txtId.Text.Trim().Length==0?"0" : txtId.Text.Trim())+" ");
                if (items.Count > 0)
                {
                    txtId.Text = items[0].ItemID.ToString();
                    txtName.Text = items[0].Productname;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "txtId_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

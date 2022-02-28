using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using Accounts.Forms;

using RMS.Search_Forms;

namespace Accounts
{
    public partial class FrmReceipe : Form
    {
        private Menus menu;
        private List<Menus> menuList;
        private List<MenuReceipe> receipeList;
        private Item item;
        private MenuReceipe menureceipe;
        public List<MenuReceipe> menuReceipe { get; set; }
        public FrmReceipe()
        {
            InitializeComponent();
        }

        private void FrmMenuReceipe_Load(object sender, EventArgs e)
        {            
            ClearControls();

            //Grd.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(DataGridViewEditingControlShowing);
        }

        private void ClearControls()
        {
            this.txtId.Text = "";
            this.txtName.Clear();                       
            LoadGrid();             
        }

        private void tsbtnNew_Click(object sender, EventArgs e)
        {
           
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void tsbtnEdit_Click(object sender, EventArgs e)
        {
            //ShowSchDeals();
        }

        private void tsbtnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private bool LoadGrid()
        {
            try
            {
                //Set Grid.
                ///////////////////////////////////////////////////////////////////////////////////////////////////
                AccountsGlobals.SetGridStyle(ref Grd);
                //////////////////////////////////////////////////////////////////////////////////////////////////              
                //Specify which type of cell in this column (DataGridViewTextBoxCell,DataGridViewCheckBoxCell,
                //DataGridViewComboBoxCell,DataGridViewImageColumn,DataGridViewButtonColumn,DataGridViewLinkColumn
                //DataGridViewComboBoxColumn comboCol = new DataGridViewComboBoxColumn();

                DataGridViewCell TextCell = new DataGridViewTextBoxCell();
                DataGridViewCell DecimalCell = new TNumEditDataGridViewCell(3);
                DataGridViewCell IntCell = new TNumEditDataGridViewCell(0);
                DataGridViewCell ChkCell = new DataGridViewCheckBoxCell();
                DataGridViewCell ComboCell = new DataGridViewComboBoxCell();
                //DataGridViewCell ComboCell1 = new DataGridViewComboBoxCell();
                //// To avoid all the annoying error messages, handle the DataError event of the DataGridView:
                Grd.DataError += new DataGridViewDataErrorEventHandler(Grd_DataError);
                ////Col 1
               
                DataGridViewColumn newCol = new DataGridViewColumn(); // add a column to the grid   
                newCol = new DataGridViewColumn();
                
                //Col 1
                //////////////////////////////////////////////////////////////////////////////////////////////// 
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "ItemID";
                newCol.Name = "ItemID";
                newCol.CellTemplate = IntCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //newCol.ReadOnly = true;                
                newCol.Width = 50;               
                Grd.Columns.Add(newCol);

                //Col 1
                //////////////////////////////////////////////////////////////////////////////////////////////// 
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "ItemName";
                newCol.Name = "ItemName";
                newCol.CellTemplate = TextCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;
                newCol.Width = 100;
                newCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                newCol.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                Grd.Columns.Add(newCol);


                //Col 3
                //////////////////////////////////////////////////////////////////////////////////////////////// 
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Qty";
                newCol.Name = "Qty";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //newCol.ReadOnly = true;
                newCol.Width = 85;
                Grd.Columns.Add(newCol);

                //Col 4
                //////////////////////////////////////////////////////////////////////////////////////////////// 
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Rate";
                newCol.Name = "Rate";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;
                newCol.Width = 85;
                newCol.Visible = false;
                Grd.Columns.Add(newCol);

                //Col 5
                //////////////////////////////////////////////////////////////////////////////////////////////// 
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Divisor";
                newCol.Name = "Divisor";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //newCol.ReadOnly = true;
                newCol.Width = 85;
                newCol.Visible = false;
                Grd.Columns.Add(newCol);

                //Col 6
                //////////////////////////////////////////////////////////////////////////////////////////////// 
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Amount";
                newCol.Name = "Amount";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;
                newCol.Width = 85;
                newCol.Visible = false;
                Grd.Columns.Add(newCol);

                Grd.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                AccountsGlobals.ExtendCol(ref Grd, "ItemName");


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }



        void Grd_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // (No need to write anything in here) 
        } 

      

        private bool VerifyItem(int itemid)
        {
            try
            {
                menureceipe = new CommonController.MenusController().VerifyItem(itemid);
                if (menureceipe.ItemID > 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("No Item Exist", "Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Grd.Rows[Grd.CurrentRow.Index].Cells["ItemID"].Value = 0;
                    return false;
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private bool SaveRecord()
        {
            DialogResult r = MessageBox.Show("Do you Want to Save Record?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                if (PopulateMenus())
                {
                    return new CommonController.MenusController().SaveMenu(this.menu);

                }
            }
            
            return false;
        }

        private bool PopulateMenus()
        {
            try
            {
                this.menu = new Menus();

                this.menu.MenuID = Convert.ToInt16(this.txtId.Text.Trim());
                this.menu.MenuName = this.txtName.Text.Trim();
                AddReceipes();
                this.menu.menuReceipe = this.receipeList;
                return true;
            }
            catch (Exception ex)
            {                
                throw ex;
            }            
        }

        private void PopulateGrid()
        {            
            try
            {
                if (receipeList.Count > 0)
                {
                    Grd.DataSource = null;
                    LoadGrid();
                    int i = 0;
                    foreach (Common.MenuReceipe m in receipeList)
                    {
                        Grd.Rows.Add();

                        Grd.Rows[i].Cells["ItemID"].Value = m.ItemID;
                        Grd.Rows[i].Cells["ItemName"].Value = m.ItemName;
                        Grd.Rows[i].Cells["Qty"].Value = m.Qty;
                        
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

        private void tsbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtId_Leave(object sender, EventArgs e)
        {
            //SearchMenu();
        }

    

        private void SearchMenu()
        {
            try
            {
                if (txtId.Text.Trim().Length == 0)
                {
                    SchMenu sch = new SchMenu();
                    sch.ShowDialog();
                    if (sch.SelectedMenu != null)
                    {
                        txtId.Text = sch.SelectedMenu.MenuID.ToString();
                        txtName.Text = sch.SelectedMenu.MenuName;
                     
                        if (GetMenuReceipe(sch.SelectedMenu.MenuID))
                        {
                            PopulateGrid();
                            Grd.Focus();
                        }
                    }
                }
                else
                {
                    this.menu = (new CommonController.MenusController().LoadGrid(Convert.ToInt16(txtId.Text)))[0];
                    this.txtId.Text = this.menu.MenuID.ToString();
                    this.txtName.Text = this.menu.MenuName.ToString();
                    if (GetMenuReceipe(Convert.ToInt16(this.txtId.Text.Trim())))
                    {                        
                        PopulateGrid();
                        Grd.Focus();
                    }
                    else
                    {
                        MessageBox.Show("No Menu ID exists with given MenuID","SearchMenu()",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {                
                    throw ex;
            }
        }

        private bool GetMenuReceipe(int menuid)
        {
            try
            {
                receipeList = new CommonController.MenusController().GetMenuReceipe(menuid);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool AddReceipes()
        {
            try
            {
                if (Grd.Rows.Count > 0)
                {
                    receipeList = new List<MenuReceipe>();

                    for (int i = 0; i < Grd.Rows.Count; i++)
                    {
                        int l = Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value);
                        decimal m = Convert.ToDecimal(Grd.Rows[i].Cells["Qty"].Value);
                        if (Grd.Rows[i].Cells["ItemID"].Value != null && Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value) != 0 && Grd.Rows[i].Cells["Qty"].Value != null && Convert.ToDecimal(Grd.Rows[i].Cells["Qty"].Value) != 0)
                        {
                            MenuReceipe mr = new MenuReceipe(Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value), Convert.ToString(Grd.Rows[i].Cells["ItemName"].Value), Convert.ToDecimal(Grd.Rows[i].Cells["Qty"].Value)
                                , Convert.ToDecimal(Grd.Rows[i].Cells["Divisor"].Value));
                            
                            receipeList.Add(mr);
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;                
            }
        }

        private void txtId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { System.Windows.Forms.SendKeys.Send("\t"); }
            if (e.KeyCode == Keys.F1)
            {
                SearchMenu();
            }

        }

        private void btnSch_Click_1(object sender, EventArgs e)
        {
            SearchMenu();
        }

        private void Grd_KeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {
                int rowIndex = Grd.CurrentRow.Index;
                int colIndex = Grd.CurrentCell.ColumnIndex;
                if (e.KeyCode == Keys.F1)
                {
                    SchForms.SchItems sch = new SchForms.SchItems();
                    sch.ShowDialog();
                    if (sch.subList1.Count>0)
                    {
                        Grd.Rows.Add();
                        Grd.Rows[rowIndex].Cells[colIndex].Value = sch.subList1[0].ItemID;
                        Grd.Rows[rowIndex].Cells["ItemName"].Value = sch.subList1[0].ItemName;
                      
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                            if (this.menureceipe != null)
                            {
                                //Grd.Rows[rowIndex].Cells["ItemID"].Value = ((DGV.DGV)sender).CurrentCell.Value;
                                Grd.Rows[rowIndex].Cells["ItemName"].Value = this.menureceipe.ItemName;
                                Grd.Rows[rowIndex].Cells["ItemName"].Selected = true;

                            }
                            else
                            {
                                Grd.Rows[rowIndex].Cells[colIndex].Value = null;
                                Accounts.SchForms.SchItems sch = new Accounts.SchForms.SchItems();
                                sch.ShowDialog();
                                if (sch.item != null)
                                {
                                    Grd.Rows[rowIndex].Cells[colIndex].Value = sch.item.ItemID;
                                    Grd.Rows[rowIndex].Cells["ItemName"].Value = sch.item.ItemName;
                                    Grd.Rows[rowIndex].Cells["ItemName"].Selected = true;
                                }
                            }
                        }
                    }

                    //Grd.Rows[rowIndex].Cells["MenuID"].Value = ((DataGridViewComboBoxCell)sender).Value;
                }
                if (colIndex == Grd.Columns["Qty"].Index)
                {
                    if (Grd.Rows[Grd.CurrentRow.Index].Cells["Qty"].Value == null || Convert.ToDecimal(Grd.Rows[Grd.CurrentRow.Index].Cells["Qty"].Value) == 0)
                    {
                        MessageBox.Show("Please Provide Quantity Greater than zero.", "CellEndEdit()", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Grd.CurrentCell = Grd[e.RowIndex, e.ColumnIndex];

                        //Grd.Select(Grd.Rows[Grd.CurrentRow.Index].Index, Grd.Columns["Quantity"].Index);
                        // Grd.Rows[Grd.CurrentRow.Index].Cells["Quantity"];
                    }

                }
                if (colIndex == Grd.Columns["Divisor"].Index)
                {
                    if (Grd.Rows[Grd.CurrentRow.Index].Cells["Divisor"].Value == null || Convert.ToDecimal(Grd.Rows[Grd.CurrentRow.Index].Cells["Divisor"].Value) == 0)
                    {
                        MessageBox.Show("Please Provide Divisor Greater than zero.", "CellEndEdit()", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Grd.CurrentCell = Grd[e.RowIndex, e.ColumnIndex];

                        //Grd.Select(Grd.Rows[Grd.CurrentRow.Index].Index, Grd.Columns["Quantity"].Index);
                        // Grd.Rows[Grd.CurrentRow.Index].Cells["Quantity"];
                    }
                    else
                    {
                        decimal qty = Convert.ToDecimal(Grd.Rows[Grd.CurrentRow.Index].Cells["Qty"].Value);
                        decimal rate = Convert.ToDecimal(Grd.Rows[Grd.CurrentRow.Index].Cells["Rate"].Value);
                        decimal divzr = Convert.ToDecimal(Grd.Rows[Grd.CurrentRow.Index].Cells["Divisor"].Value);
                        decimal amount = (rate / divzr) * qty;
                        Grd.Rows[Grd.CurrentRow.Index].Cells["Amount"].Value = amount;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CellEndEdit()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
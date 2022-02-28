using Accounts;
using Accounts.Forms;
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
using Common;
using Restorant_Management_System.Sch_Forms;
using CategoryControlle;

namespace Restorant_Management_System.Forms
{
    public partial class FrmRecipieProduction : Form
    {
        private List<Item> lstRecipie = new List<Item>();

        private ProductionRecipie production;
        private List<ProductionRecipieLines> recipiesLines;

        private bool isNew = true;
        public FrmRecipieProduction()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
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
                newCol.ReadOnly = true;
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
                //  newCol.Visible = Globals.PackingColumnVisible;
                newCol.Width = 250;
                Grd.Columns.Add(newCol);

                //////////////////////////////////////////////////////////////////////////////////////////////////  
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Cs.Qty";
                newCol.Name = "CsQty";
                newCol.CellTemplate = RateCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.ReadOnly = true;
                newCol.Width = 90;
                Grd.Columns.Add(newCol);

              ////////////////////////////////////////////////         
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Quantity";
                newCol.Name = "Quantity";
                newCol.CellTemplate = RateCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.ReadOnly = true;
                newCol.Width = 90;
                Grd.Columns.Add(newCol);

                ///Adding Receipe quantity
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Quantity";
                newCol.Name = "rQuantity";
                newCol.CellTemplate = RateCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                
                newCol.ReadOnly = true;
                newCol.Visible = false;  
                newCol.Width = 90;
                Grd.Columns.Add(newCol);
                //////////////////////////////////////////////////////////////////////////////////////////////////               
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Rate";
                newCol.Name = "Rate";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.ReadOnly = true;
                newCol.Width = 90;
                Grd.Columns.Add(newCol);
                //////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Total";
                newCol.Name = "Total";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.ReadOnly = true;
                newCol.Width = 90;
                Grd.Columns.Add(newCol);
                //Col 7Total
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


                AccountsGlobals.ExtendCol(ref Grd, "ItemName");





                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void ClearControls()
        {
            txtID.Text = new RecipieController().GetMaxInvID();
            dtpDated.Value = DateTime.Now;
            txtMItemID.Clear();
            txtName.Clear();
            txtMQuantity.Clear();
            this.isNew = true;
            txtMItemID.Enabled = true;
            btnSch.Enabled = true;
            dtpDated.Enabled = true;
            LoadGrid();
        }

        private void FrmRecipieProduction_Load(object sender, EventArgs e)
        {
            ClearControls();
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
                sch.isMarination = true;
                sch.condition = " where ismarinated=1 ";
                sch.ShowDialog();
                List<Item> lstitem = new List<Item>();
                lstitem = sch.subList1;
                if (lstitem.Count > 0)
                {
                    for (int i = 0; i < lstitem.Count; i++)
                    {
                        txtMItemID.Text = lstitem[i].ItemID.ToString();
                        txtName.Text = lstitem[i].ItemName.ToString();
                        txtMQuantity.Text = "1";
                        txtMQuantity.Focus();
                        PopulateGrid(lstitem[i].ItemID);

                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "SearchItem", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void PopulateGrid(int itemID)
        {
            try
            {
                LoadGrid();
                lstRecipie = new RecipieController().GetRecipieList(itemID);
                for(int i = 0; i < lstRecipie.Count; i++)
                {
                    int rowIndex = Grd.Rows.Add();

                    Grd.Rows[rowIndex].Cells["ItemID"].Value = lstRecipie[i].ItemID;
                    Grd.Rows[rowIndex].Cells["ItemName"].Value = lstRecipie[i].ItemName.ProductName;
                    Grd.Rows[rowIndex].Cells["CsQty"].Value = lstRecipie[i].CurrentStock;
                    Grd.Rows[rowIndex].Cells["rQuantity"].Value = lstRecipie[i].Quantity  ;
                    Grd.Rows[rowIndex].Cells["Rate"].Value = lstRecipie[i].PurchasePrice;
                   // Grd.Rows[rowIndex].Cells["Total"].Value = lstRecipie[i].Quantity * lstRecipie[i].PurchasePrice;
                }
                CalculateLines();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "btnSch_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtMQuantity_Leave(object sender, EventArgs e)
        {
            try
            {
                CalculateLines();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "txtMQuantity_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void CalculateLines()
        {
            decimal Mqty = 0;
          
            decimal grdqty = 0;
            decimal rate = 0;
            decimal TotalAmt = 0;
            for (int i = 0; i < Grd.Rows.Count - 1; i++)
            {
                if (Grd.Rows[i].Cells["ItemID"].Value != null)
                {
                    

                    Mqty = Convert.ToDecimal(txtMQuantity.Text.Trim().Length == 0 ? "0" : txtMQuantity.Text.Trim());
                    grdqty = Convert.ToDecimal(Grd.Rows[i].Cells["rQuantity"].Value);
                    rate = Convert.ToDecimal(Grd.Rows[i].Cells["Rate"].Value);
                   
                   
                   Grd.Rows[i].Cells["Quantity"].Value = Mqty * grdqty;
                    
                 

                    if (Convert.ToDecimal(Grd.Rows[i].Cells["Quantity"].Value) > Convert.ToDecimal(Grd.Rows[i].Cells["Csqty"].Value))
                    {
                        MessageBox.Show("Unavilable Stock on Item " + Grd.Rows[i].Cells["ItemName"].Value.ToString() + " containg Item ID =" + Grd.Rows[i].Cells["ItemID"].Value + "", "txtMQuantity_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Grd.Rows[i].Cells["Quantity"].Value = grdqty;
                        return;//if stock is less then qty then return without populate qty and totals
                    }
                 
                    Grd.Rows[i].Cells["Total"].Value = rate * Convert.ToDecimal(Grd.Rows[i].Cells["Quantity"].Value);


                    TotalAmt += Convert.ToDecimal(Grd.Rows[i].Cells["Total"].Value);
                   


                }
            }
            txtTotalAmt.Text = TotalAmt.ToString();


        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validation())
                {
                    if (AddInvoice())
                    {
                        int VID = new RecipieController().Save(production, isNew);
                        if (VID > 0)
                        {
                            MessageBox.Show("Recipie Prodcution has been Saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearControls();

                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private bool AddInvoice()
        {
            try
            {

                production = new ProductionRecipie();
                production.ID = Convert.ToInt32(txtID.Text.Trim());
                production.BranchID = Globals.BranchID;
                production.Dated = Convert.ToDateTime(dtpDated.Value);
                production.MItemID = Convert.ToInt32(txtMItemID.Text);
                production.MQuantity= Convert.ToDecimal(txtMQuantity.Text);
                production.TotalAmt = Convert.ToDecimal(txtTotalAmt.Text.Trim());
               
                if (!AddInvoiceLines())
                {
                    return false;
                }

                production.productionRecipieLines = recipiesLines;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool AddInvoiceLines()
        {
            try
            {
                if (Grd.Rows.Count > 0)
                {
                    recipiesLines = new List<ProductionRecipieLines>();

                    for (int i = 0; i < Grd.Rows.Count; i++)
                    {

                        if (Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value) != 0)
                        {
                            ProductionRecipieLines line = new ProductionRecipieLines();
                            line.ItemID = Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value);                   
                            line.Quantity = Convert.ToDecimal(Grd.Rows[i].Cells["Quantity"].Value);                      
                            line.Rate = Convert.ToDecimal(Grd.Rows[i].Cells["Rate"].Value);
                            line.Total = Convert.ToDecimal(Grd.Rows[i].Cells["Total"].Value);
                            line.SrNo = Convert.ToInt32(Grd.Rows[i].Cells["SrNo"].Value);
                            line.IsDeleted = Convert.ToBoolean(Grd.Rows[i].Cells["IsDeleted"].Value);         
                            recipiesLines.Add(line);
                        }

                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AddLines", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool Validation()
        {
            try
            {

                if (this.txtMItemID.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Please Select Marinated Item", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMItemID.Focus();
                    return false;
                }

                if (this.txtMQuantity.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Please Select Marinated Item Qunatity", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMQuantity.Focus();
                    return false;
                }
                //--------------Checking Line stock for all

                for (int i = 0; i < Grd.Rows.Count - 1; i++)
                {
                    if (Grd.Rows[i].Cells["ItemID"].Value != null)
                    {
                        
                        if (Convert.ToDecimal(Grd.Rows[i].Cells["Quantity"].Value) > Convert.ToDecimal(Grd.Rows[i].Cells["Csqty"].Value))
                        {
                            MessageBox.Show("Unavilable Stock on Item " + Grd.Rows[i].Cells["ItemName"].Value.ToString() + " containg Item ID =" + Grd.Rows[i].Cells["ItemID"].Value + "", "txtMQuantity_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                     
                    }
                }
                //--------------Checking Line Existence
                int Count = 0;
                for (int i = 0; i < Grd.Rows.Count; i++)
                {
                    if (Grd.Rows[i].Visible)
                    {
                        if (Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value) != 0)
                        {
                            Count++;
                        }
                    }
                }

                if (Count == 0)
                {
                    MessageBox.Show("Please Enter some items", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Grd.Focus();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                
                SchRecipieProdcution sch = new SchRecipieProdcution();
                
                sch.ShowDialog();
                ProductionRecipie p = sch.item;
                if (p != null)
                {
                    ClearControls();
                    txtMItemID.Enabled = false;
                    btnSch.Enabled = false;
                    dtpDated.Enabled = false;
                    this.isNew = false;
                    this.txtID.Text = p.ID.ToString();
                    this.txtMItemID.Text = p.MItemID.ToString();
                    this.txtName.Text = p.MItemName;
                    txtMQuantity.Text = p.MQuantity.ToString();
                    this.dtpDated.Value = p.Dated;                     
                    this.txtTotalAmt.Text = p.TotalAmt.ToString();                 
                    PopulatePurchaseLines(p.productionRecipieLines);
                       
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "tsbtnEdit_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool PopulatePurchaseLines(List<ProductionRecipieLines> lines)
        {
            try
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    int rowIndex = Grd.Rows.Add();

                    Grd.Rows[rowIndex].Cells["ItemID"].Value = lines[i].ItemID;
                    Grd.Rows[rowIndex].Cells["ItemName"].Value = lines[i].ItemName;
                    Grd.Rows[rowIndex].Cells["Quantity"].Value = lines[i].Quantity;
                    Grd.Rows[rowIndex].Cells["rQuantity"].Value = lines[i].Quantity/Convert.ToDecimal(txtMQuantity.Text.Trim());
                    Grd.Rows[rowIndex].Cells["CsQty"].Value = lines[i].Quantity + lines[i].CsQty;
                    Grd.Rows[rowIndex].Cells["Rate"].Value = lines[i].Rate;
                    Grd.Rows[rowIndex].Cells["Total"].Value = lines[i].Rate * lines[i].Quantity;


                    Grd.Rows[rowIndex].Cells["SrNo"].Value = lines[i].SrNo;
                    Grd.Rows[rowIndex].Cells["IsDeleted"].Value = lines[i].IsDeleted;
                 


                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AddLines", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        private void txtMItemID_Leave(object sender, EventArgs e)
        {
            try
            {
                List<SchItems> items = new List<SchItems>();
                items = new ItemController().GetMarinatedIems(" where ismarinated=1 and Itemid=" + Convert.ToInt32(txtMItemID.Text.Trim().Length == 0 ? "0" : txtMItemID.Text.Trim()) + " ");
                if (items.Count > 0)
                {
                    txtMItemID.Text = items[0].ItemID.ToString();
                    txtName.Text = items[0].Productname;
                    txtMQuantity.Focus();
                    PopulateGrid(Convert.ToInt32(txtMItemID.Text));
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "txtMItemID_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMItemID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode==Keys.F1)
                {
                    SearchItem();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "txtMItemID_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Grd.Focus();
            }
        }
    }
}

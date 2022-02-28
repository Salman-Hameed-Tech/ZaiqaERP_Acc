using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using CommonController;
using Accounts.Forms;
using CategoryControlle;

namespace Accounts.Forms
{
    public partial class FrmClaim : Form
    {
        private BindingSource source = new BindingSource();
        Purchase PurInvoice = new Purchase();
        private bool IsNew = true;

        public List<PurchaseInvoice> InvoiceLines = new List<PurchaseInvoice>();
        public List<PurchaseInvoice> Invoice = new List<PurchaseInvoice>();
        List<PurchaseInvoice> lstitem = new List<PurchaseInvoice>();
        public int ItemId = 0;
        public int InvoiceNo = 0;

        public FrmClaim()
        {
            InitializeComponent();
        }
        public void GridBind()
        {
            lstitem = (new PurchaseController().GetPurchaseInvoice(ItemId, InvoiceNo));
            if (lstitem.Count > 0)
            {
                for (int i = 0; i < lstitem.Count; i++)
                {
                    int rowIndex = Grid.Rows.Add();
                    (Grid.Rows[rowIndex].Cells["InvoiceNo"].Value) = lstitem[i].ID.ToString();
                    (Grid.Rows[rowIndex].Cells["ItemID"].Value) = lstitem[i].ItemID.ToString();
                    (Grid.Rows[rowIndex].Cells["ItemName"].Value) = lstitem[i].ItemName.ToString();
                    (Grid.Rows[rowIndex].Cells["Quantity"].Value) = lstitem[i].Quantity.ToString();
                    (Grid.Rows[rowIndex].Cells["Dated"].Value) = lstitem[i].Dated.ToString();
                   // (Grid.Rows[rowIndex].Cells["AccountName"].Value) = lstitem[i].AccountName.ToString();
                    (Grid.Rows[rowIndex].Cells["Rate"].Value) = lstitem[i].Rate.ToString();
                    decimal Total = (Convert.ToDecimal(Grid.Rows[rowIndex].Cells["SoldQuantity"].Value) * Convert.ToDecimal(Grid.Rows[rowIndex].Cells["Rate"].Value));
                    (Grid.Rows[rowIndex].Cells["Total"].Value) = Total;
                  
                }
            }
            //Grid.DataSource = lstitem;
        }
        private void FrmClaim_Load(object sender, EventArgs e)
        {
            LoadGrid();
            GridBind();
            if (lstitem.Count > 0)
            {
                Grid.Rows[0].Cells["SoldQuantity"].Selected = true;
            }

          
        }
        private bool LoadGrid()
        {
            try
            {
                //Set Grid.
                ///////////////////////////////////////////////////////////////////////////////////////////////////
                AccountsGlobals.SetGridStyle(ref Grid);

                Grid.EnableHeadersVisualStyles = false;
                //////////////////////////////////////////////////////////////////////////////////////////////////              
                //Specify which type of cell in this column (DataGridViewTextBoxCell,DataGridViewCheckBoxCell,
                //DataGridViewComboBoxCell,DataGridViewImageColumn,DataGridViewButtonColumn,DataGridViewLinkColumn



                DataGridViewCell TextCell = new DataGridViewTextBoxCell();
                DataGridViewCell DecimalCell = new TNumEditDataGridViewCell(2);
                DataGridViewCell RateCell = new TNumEditDataGridViewCell(4);
                DataGridViewCell IntCell = new TNumEditDataGridViewCell(0);




                //////////////////////////////////////////////////////////////////////////////////////////////////                

                DataGridViewColumn newCol = new DataGridViewColumn(); // add a column to the grid                

                //Grid.DataSource = null;
                //source.DataSource = lstitem;
                //Grid.DataSource = source;


                //Col 1
                //////////////////////////////////////////////////////////////////////////////////////////////////   

                newCol.CellTemplate = IntCell;
                newCol.HeaderText = "Item ID";
                newCol.Name = "ItemID";
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.Width = 40;
                Grid.Columns.Add(newCol);

                //Col 2
                //////////////////////////////////////////////////////////////////////////////////////////////////                
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Invoice No";
                newCol.Name = "InvoiceNo";

                newCol.CellTemplate = TextCell;

                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;
                newCol.Width = 150;
                Grid.Columns.Add(newCol);

                //Col 3
                //////////////////////////////////////////////////////////////////////////////////////////////////                
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Item Name";
                newCol.Name = "ItemName";

                newCol.CellTemplate = TextCell;

                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;
                //newCol.Visible = Globals.PackingColumnVisible;
                newCol.Width = 120;
                Grid.Columns.Add(newCol);



                ////Col 4
                ////////////////////////////////////////////////////////////////////////////////////////////////////                
                //newCol = new DataGridViewColumn();
                //newCol.HeaderText = "Account Name";
                //newCol.Name = "AccountName";

                //newCol.CellTemplate = TextCell;

                //newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                //newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //newCol.ReadOnly = true;
                //newCol.Width = 150;
                //Grid.Columns.Add(newCol);

                //Col 5
                //////////////////////////////////////////////////////////////////////////////////////////////////                
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Dated";
                newCol.Name = "Dated";

                newCol.CellTemplate = TextCell;

                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;
                newCol.Width = 150;
                Grid.Columns.Add(newCol);

                //Col 6
                //////////////////////////////////////////////////////////////////////////////////////////////////                
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Qty";
                newCol.Name = "Quantity";

                newCol.CellTemplate = TextCell;

                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;
                newCol.Width = 80;
                Grid.Columns.Add(newCol);

                //Col 7
                //////////////////////////////////////////////////////////////////////////////////////////////////                
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Return Quantity";
                newCol.Name = "SoldQuantity";

                newCol.CellTemplate = TextCell;

                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = false;
                newCol.Width = 120;
                Grid.Columns.Add(newCol);


                //Col 8
                //////////////////////////////////////////////////////////////////////////////////////////////////                
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Rate";
                newCol.Name = "Rate";

                newCol.CellTemplate = TextCell;

                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;
                newCol.Width = 120;
                Grid.Columns.Add(newCol);

                //Col 8
                //////////////////////////////////////////////////////////////////////////////////////////////////                
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Total";
                newCol.Name = "Total";

                newCol.CellTemplate = TextCell;

                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;
                newCol.Width = 120;
                Grid.Columns.Add(newCol);



                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        Purchase pin = new Purchase();
       
        private void tsBtnSave_Click(object sender, EventArgs e)
        {
           
          
            for (int i = 0; i < Grid.Rows.Count; i++)
            {
                if (Grid.Rows[i].Cells["SoldQuantity"].Value != null)
                {
                    PurchaseInvoice purin = new PurchaseInvoice();
                    purin.InvoiceNo = Convert.ToInt32(Grid.Rows[i].Cells["InvoiceNo"].Value);
                    purin.ItemID = Convert.ToInt32(Grid.Rows[i].Cells["ItemID"].Value);
                    purin.ItemName = Convert.ToString(Grid.Rows[i].Cells["ItemName"].Value);
                    purin.Quantity = Convert.ToDecimal(Grid.Rows[i].Cells["Quantity"].Value);
                    purin.Rate = Convert.ToDecimal(Grid.Rows[i].Cells["Rate"].Value);
                    purin.ReturnQuantity = Convert.ToDecimal(Grid.Rows[i].Cells["SoldQuantity"].Value);
                    purin.Dated = Convert.ToDateTime(Grid.Rows[i].Cells["Dated"].Value);
                    Invoice.Add(purin);

                }
              
            }
            this.Close();

              
            
        }

        private void Grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = Grid.CurrentRow.Index;
                int colIndex = Grid.CurrentCell.ColumnIndex;
                if (colIndex == Grid.Columns["SoldQuantity"].Index)
                {
                    decimal returnqty=Convert.ToDecimal(Grid.Rows[rowIndex].Cells["SoldQuantity"].Value);
                    decimal rate=Convert.ToDecimal(Grid.Rows[rowIndex].Cells["Rate"].Value);
                    decimal csqty=Convert.ToDecimal(Grid.Rows[rowIndex].Cells["Quantity"].Value);
                    if (returnqty <= csqty)
                    {
                        Grid.Rows[rowIndex].Cells["Total"].Value = Convert.ToDecimal(Grid.Rows[rowIndex].Cells["SoldQuantity"].Value) * Convert.ToDecimal(Grid.Rows[rowIndex].Cells["Rate"].Value);

                    }
                    else 
                    {
                        Grid.Rows[rowIndex].Cells["SoldQuantity"].Value=0;
                        MessageBox.Show("Return quantity cannot be greater than invoice quantity.", "Validtion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Grid_CellEndEdit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

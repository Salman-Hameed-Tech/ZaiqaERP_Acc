using Accounts;
using Accounts.Forms;
using Accounts.SchForms;
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
    public partial class FrmPartywiseOpeningStock : Form
    {
        bool isnew = true;
        private List<OpeningStockLine> stockLine;
        public FrmPartywiseOpeningStock()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void ClearControls()
        {
            try
            {
                txtID.Text = new OpeningStockController().GetMaxID();
                dtp.Value = DateTime.Now;
                txtPartyDetail.Clear();
                txtPartyID.Clear();
                LoadGrid();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "FrmPurchaseInvocie ClearControls.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSchVendor_Click(object sender, EventArgs e)
        {
            try
            {
                ShowSearch(ref this.txtPartyID, ref this.txtPartyDetail);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmSaleRegister btnSch_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ShowSearch(ref System.Windows.Forms.TextBox txtno, ref System.Windows.Forms.TextBox txtname)
        {
            try
            {
                Accounts.SchForms.SchAccounts Sch = new Accounts.SchForms.SchAccounts();
                Sch.accountType = " and accountno <> (Select CashAcc From FixedAccounts)";
                Sch.ShowDialog();
                if (Sch.SelectedAccount != null)
                {
                    txtno.Text = Sch.SelectedAccount.AccountNo;
                    txtname.Text = Sch.SelectedAccount.AccountName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtPartyID_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (this.txtPartyID.Text.ToString().Trim().Length == 0) return;
                VerifyAcc(ref this.txtPartyID, ref this.txtPartyDetail);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmCurrentStock txtPartyID_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void VerifyAcc(ref System.Windows.Forms.TextBox txtno, ref System.Windows.Forms.TextBox txtname)
        {
            ChartOfAccounts Ca;
            Ca = new ChartofAccountsController().GetAccountDetail(txtno.Text, " and isdetailed=1 and accountno <> (Select CashAcc from FixedAccounts)");
            if (Ca == null)
            {
                txtno.Clear();
                ShowSearch(ref txtno, ref txtname);
            }
            else
            {
                txtno.Text = Ca.AccountNo;
                txtname.Text = Ca.AccountName;
            }
        }

        private void FrmPartywiseOpeningStock_Load(object sender, EventArgs e)
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
                DataGridViewCell DecimalCell = new TNumEditDataGridViewCell(3);
                DataGridViewCell RateCell = new TNumEditDataGridViewCell(4);
                DataGridViewCell IntCell = new TNumEditDataGridViewCell(0);

                //Col 1
                //////////////////////////////////////////////////////////////////////////////////////////////////   
                DataGridViewColumn newCol = new DataGridViewColumn(); // add a column to the grid                 
                newCol.CellTemplate = IntCell;
                newCol.HeaderText = "Item ID";
                newCol.Name = "ItemID";
                newCol.ReadOnly = false;
                newCol.CellTemplate = IntCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Width = 60;
                Grd.Columns.Add(newCol);

                //Col 2
                //////////////////////////////////////////////////////////////////////////////////////////////////                
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Item Name";
                newCol.Name = "ItemName";
                newCol.ReadOnly = false;
                newCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                newCol.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                newCol.CellTemplate = TextCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Width = 250;
                Grd.Columns.Add(newCol);

               
                //Col5
                ///////////////////////////////////////////////////////////////////////////////////
                newCol = new DataGridViewColumn(); // add a column to the grid                 
                newCol.HeaderText = "Quantity";
                newCol.Name = "Quantity";
                newCol.ReadOnly = false;

                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Width = 80;
                Grd.Columns.Add(newCol);
                ///////////////////////////////

                newCol = new DataGridViewColumn();
                newCol.CellTemplate = IntCell;
                newCol.HeaderText = "SrNo";
                newCol.Name = "SrNo";
                newCol.ReadOnly = true;
                newCol.Visible = false;
                newCol.CellTemplate = IntCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Width = 60;
                Grd.Columns.Add(newCol);

                Grd.Rows[0].Cells["ItemID"].Selected = true;

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
         
                if (ValidateControls())
                {
                    if (PopulateOpeningStock())
                    {
                        if (new CommonController.OpeningStockController().SaveOpeningStock(stockLine, isnew))
                        {
                            MessageBox.Show("Party wise opening stock is saved", "btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadGrid();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
             
            }
        }
        private bool PopulateOpeningStock()
        {
            try
            {
                if (Grd.Rows.Count > 0)
                {
                    stockLine = new List<OpeningStockLine>();
                   

                    for (int i = 0; i < Grd.Rows.Count; i++)//adding lines
                    {
                        if (Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value) != 0)
                        {
                            OpeningStockLine line = new OpeningStockLine();
                            line.ItemID = Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value);
                            line.ItemName = (Grd.Rows[i].Cells["ItemName"].Value).ToString();
                            line.Quantity = Convert.ToDecimal(Grd.Rows[i].Cells["Quantity"].Value);
                            line.SrNo = Convert.ToInt32(Grd.Rows[i].Cells["SrNo"].Value);

                            line.ID= Convert.ToInt32(txtID.Text.Trim());
                            line.PartyID = Convert.ToInt32(txtPartyID.Text.Trim());
                            line.PartyName = (txtPartyDetail.Text.Trim()).ToString();
                            line.Dated = Convert.ToDateTime(dtp.Value.ToShortDateString());



                            stockLine.Add(line);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Opening stock is not populated", "PopulateOpeningStock()", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool ValidateControls()
        {
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

        private void Grd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.Alt == true) return;
                if (Grd.CurrentRow == null) return;
                int rowIndex = Grd.CurrentRow.Index;
                int colIndex = Grd.CurrentCell.ColumnIndex;

                if (e.KeyCode == Keys.F1)
                {
                    if (colIndex == Grd.Columns["ItemID"].Index)
                    {
                        try
                        {
                            Grd.MoveLeftToRight = true;
                            Accounts.SchForms.SchItems sch = new Accounts.SchForms.SchItems();
                            sch.ShowDialog();

                            if (sch.subList1.Count >0)
                            {
                                Grd.Rows[rowIndex].Cells["ItemID"].Value = sch.subList1[0].ItemID;
                                Grd.Rows[rowIndex].Cells["ItemName"].Value = sch.subList1[0].ItemName;

                              
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("No Item selected", "Grd_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Grd_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
           
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                SchPartywiseOStock frm = new SchPartywiseOStock();
                frm.ShowDialog();
                ClearControls();
                List<OpeningStockLine> line = frm.lstSelectedOS;
                if (line != null)
                {
                    //Enabling editing
                    isnew = false;
                    PopulateOpeningStockLines(line);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnEdit_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void PopulateOpeningStockLines(List<OpeningStockLine> line)
        {
            try
            {
                txtPartyID.Text = line[0].PartyID.ToString();
                txtPartyDetail.Text = line[0].PartyName;
                txtID.Text = line[0].ID.ToString();

                for (int i = 0; i < line.Count; i++)
                {
                    int rowIndex = Grd.Rows.Add();
                    Grd.Rows[rowIndex].Cells["ItemID"].Value = line[i].ItemID;
                    Grd.Rows[rowIndex].Cells["ItemName"].Value = line[i].ItemName;
                    
                    Grd.Rows[rowIndex].Cells["Quantity"].Value = line[i].Quantity;
                    Grd.Rows[rowIndex].Cells["SrNo"].Value = line[i].SrNo;


                    dtp.Value = line[i].Dated;
                }
            }
            catch (Exception ex)
            {
                throw ex;
              
            }
        }
    }
}

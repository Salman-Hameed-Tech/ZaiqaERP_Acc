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
using CommonController;
using RMS.Search_Forms;
using CategoryControlle;
using Accounts.SchForms;

namespace Accounts.Forms
{
    public partial class FrmCategoryPartyRelation : Form
    {
        private ChartOfAccounts party;
        private List<ChartOfAccounts> listParty;
        private Category category;
        private List<Category> listCategory;
        private CategoryPartyRelation CPRelation;
        private List<CategoryPartyRelation> listCPRelation;


        public FrmCategoryPartyRelation()
        {
            InitializeComponent();
        }

        private void FrmCategoryPartyRelation_Load(object sender, EventArgs e)
        {            
            ClearControls();
            //Grd.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(DataGridViewEditingControlShowing);
        }

        private void ClearControls()
        {            
            Grd.DataSource = null;
            LoadGrid();
            LoadCPRelation();             
        }

        

       

        private void tsbtnEdit_Click(object sender, EventArgs e)
        {
            //ShowSchDeals();
        }

        private void tsbtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //if (DeleteDeal())
                //{
                //    MessageBox.Show("Menu is Deleted Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Deleting()",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
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
                DataGridViewCell DecimalCell = new TNumEditDataGridViewCell(2);
                DataGridViewCell IntCell = new TNumEditDataGridViewCell(0);
                DataGridViewCell ChkCell = new DataGridViewCheckBoxCell();

                DataGridViewCell ComboCell = new DataGridViewComboBoxCell();
                //DataGridViewCell ComboCell1 = new DataGridViewComboBoxCell();


                //    // To avoid all the annoying error messages, handle the DataError event of the DataGridView:
                //Grd.DataError += new DataGridViewDataErrorEventHandler(Grd_DataError);


                ////Col 1
                //////////////////////////////////////////////////////////////////////////////////////////////////// 
                //DataGridViewComboBoxColumn comboCol = new DataGridViewComboBoxColumn();
                //comboCol.AutoComplete = true;



                //comboCol.CellTemplate = ComboCell;
                //comboCol.DisplayMember = "MenuName";
                //comboCol.ValueMember = "MenuID";
                //comboCol.HeaderText = "Menu Name";
                ////comboCol.DataSource = menuList;
                //comboCol.Name = "MenuName";
                //comboCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //comboCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //comboCol.Width = 120;
                //Grd.Columns.Add(comboCol);


                ////////////////////////////////////////////////////////////////////////////////////////////////// 
                DataGridViewColumn newCol = new DataGridViewColumn(); // add a column to the grid   
                newCol = new DataGridViewColumn();

                ////Col 4
                ////////////////////////////////////////////////////////////////////////////////////////////////// 
                //newCol = new DataGridViewColumn();
                //newCol.HeaderText = "SrNo";
                //newCol.Name = "SrNo";
                //newCol.CellTemplate = IntCell;
                //newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                //newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //newCol.ReadOnly = true;                
                //newCol.Width = 100;
                //newCol.Visible = false;
                //Grd.Columns.Add(newCol);

               

                //Col 4
                //////////////////////////////////////////////////////////////////////////////////////////////// 
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "PointID";
                newCol.Name = "PartyID";
                newCol.CellTemplate = IntCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //newCol.ReadOnly = true;                
                newCol.Width = 100;    
           
                Grd.Columns.Add(newCol);

                //Col 4
                //////////////////////////////////////////////////////////////////////////////////////////////// 
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "PointName";
                newCol.Name = "PartyName";
                newCol.CellTemplate = TextCell; ;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                newCol.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                newCol.ReadOnly = true;
                newCol.Width = 200;
                Grd.Columns.Add(newCol);


                //Col 4
                //////////////////////////////////////////////////////////////////////////////////////////////// 
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "MCategoryID";
                newCol.Name = "MCategoryID";
                newCol.CellTemplate = IntCell; ;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //newCol.ReadOnly = true;
                newCol.Width = 80;
                Grd.Columns.Add(newCol);


                //Col 4
                //////////////////////////////////////////////////////////////////////////////////////////////// 
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "MCategoryName";
                newCol.Name = "MCategoryName";
                newCol.CellTemplate = TextCell; ;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;
                newCol.Width = 200;                
                Grd.Columns.Add(newCol);


                Grd.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                AccountsGlobals.ExtendCol(ref Grd, "PartyName");


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        
        private void Grd_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = Grd.CurrentRow.Index;
                int colIndex = Grd.CurrentCell.ColumnIndex;

                if (colIndex == Grd.Columns["PartyID"].Index)
                {
                    if (Grd.Rows[rowIndex].Cells["PartyID"].Value!=null &&  Convert.ToInt32(Grd.Rows[rowIndex].Cells["PartyID"].Value) != 0)
                    {
                        VerifyAcc();
                        Grd.Rows[rowIndex].Cells["PartyName"].Selected = true;
                      
                    }                    
                }

                if (colIndex == Grd.Columns["MCategoryID"].Index)
                {
                    if (Grd.Rows[Grd.CurrentRow.Index].Cells["MCategoryID"].Value != null && Convert.ToInt32(Grd.Rows[Grd.CurrentRow.Index].Cells["MCategoryID"].Value) != 0)
                    {
                        VerifyCategory();
                        Grd.Rows[rowIndex].Cells["MCategoryName"].Selected = true;
                       
                    }
                    else
                    {
                        Grd.Rows[Grd.CurrentRow.Index].Cells[Grd.CurrentCell.ColumnIndex].Value = null;
                        Grd.Rows[Grd.CurrentRow.Index].Cells[Grd.CurrentCell.ColumnIndex + 1].Value = null;
                     
                    }
                }

              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Grd.Rows[Grd.CurrentRow.Index].Cells[Grd.CurrentCell.ColumnIndex].Value = null;
                Grd.Rows[Grd.CurrentRow.Index].Cells[Grd.CurrentCell.ColumnIndex+1].Value = null;
            }
        }

        void Grd_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // (No need to write anything in here) 
        } 

        private void Grd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                int rowIndex = Grd.CurrentRow.Index;
                int colIndex = Grd.CurrentCell.ColumnIndex;

                if (e.KeyCode == Keys.Delete)
                {
                    DialogResult r = MessageBox.Show("Do You Want to Delete The Current Row?","Perminant Row Deletion.",MessageBoxButtons.YesNo,MessageBoxIcon.Question);                    
                    if(r==DialogResult.Yes)
                    {
                     
                        Grd.Rows.Remove(Grd.Rows [rowIndex]);                       
                      
                    }
                }
                if (e.KeyCode == Keys.F1)
                {
                    if (colIndex == Grd.Columns["PartyID"].Index)
                    {
                        ShowAccount();
                    }
                    else if(colIndex == Grd.Columns["MCategoryID"].Index)
                    {
                        ShowCategory();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void ShowAccount()
        {
            try
            {                
                int rowIndex = Grd.CurrentRow.Index;
                int colIndex = Grd.CurrentCell.ColumnIndex;

                SchAccounts Sch = new SchAccounts();
               // Sch.isPointsAccounts = true;
                Sch.accountType = " and isdetailed=1 and accountno <> (Select CashAcc from FixedAccounts) and accountno like '6%'";
                Sch.ShowDialog();
                if (Sch.SelectedAccount != null)
                {
                    Grd.Rows[rowIndex].Cells[colIndex].Value = Sch.SelectedAccount.AccountNo;
                    Grd.Rows[rowIndex].Cells["PartyName"].Value = Sch.SelectedAccount.AccountName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void VerifyAcc()
        {
            int rowIndex = Grd.CurrentRow.Index;
            int colIndex = Grd.CurrentCell.ColumnIndex;

            ChartOfAccounts Ca;
            string accno= Grd.Rows[rowIndex].Cells[colIndex].Value.ToString();
            Ca = new ChartofAccountsController().GetAccountDetail(accno, " and isdetailed=1 and accountno <> (Select CashAcc from FixedAccounts) and accountno like '6%'");
            if (Ca == null)
            {
                Grd.Rows[rowIndex].Cells[colIndex].Value = null;
                ShowAccount();
            }
            else
            {
                Grd.Rows[rowIndex].Cells[colIndex].Value = Ca.AccountNo;
                Grd.Rows[rowIndex].Cells["PartyName"].Value = Ca.AccountName;
            }
        }

        private void ShowCategory()
        {
            try
            {
                int rowIndex = Grd.CurrentRow.Index;
                int colIndex = Grd.CurrentCell.ColumnIndex;
                SchMCategory sch = new SchMCategory();
              
                sch.ShowDialog();

                if (sch.SelectedMCategory != null)
                    {
                        Grd.Rows[rowIndex].Cells["MCategoryID"].Value = sch.SelectedMCategory.MCategoryID;
                        Grd.Rows[rowIndex].Cells["MCategoryName"].Value = sch.SelectedMCategory.MCategoryName;                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowMenus() 
        {
            try
            {
                 int rowIndex = Grd.CurrentRow.Index;
                int colIndex = Grd.CurrentCell.ColumnIndex;
               
                SchMenu sch = new SchMenu();
                sch.ShowDialog();
 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void VerifyCategory()
        {
            try
            {                
                int rowIndex = Grd.CurrentRow.Index;
                int colIndex = Grd.CurrentCell.ColumnIndex;

                int cid = Convert.ToInt32(Grd.Rows[rowIndex].Cells[colIndex].Value);
                listCategory =( new CommonController.CategoryPartyController().GetCategories(cid));

                if (listCategory.Count == 0 || listCategory[0] == null)
                {
                    Grd.Rows[rowIndex].Cells[colIndex].Value = null;
                    ShowCategory();
                }
                else
                {
                    Grd.Rows[rowIndex].Cells[colIndex].Value = listCategory[0].Id;
                    Grd.Rows[rowIndex].Cells["MCategoryName"].Value = listCategory[0].Name;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool GetCategoryPartyRelations()
        {
            try
            {
                this.listCPRelation = new CategoryPartyController().GetCategoryPartyRelations();
                return true;
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool SaveRecord()
        {
            if (ValidateControls())
            {
                DialogResult r = MessageBox.Show("Do you Want to Save Record?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    if (PopulateCPRelations())
                    {
                        return new CommonController.CategoryPartyController().SaveCPRelation(this.listCPRelation) ;
                    }
                }
            }
            return false;
        }

        private bool ValidateControls()
        {
            
            if (Grd.Rows.Count == 0 )
            {
                MessageBox.Show("Please Give Some Menu in The grid.");
                this.Grd.Focus();
                return false;
            }

            return true;
        }

        private bool PopulateCPRelations()
        {
            listCPRelation = new List<CategoryPartyRelation>();
            for (int i = 0; i < Grd.Rows.Count; i++)
            {
                if (Convert.ToString(Grd.Rows[i].Cells["PartyID"].Value) != "" && Convert.ToInt32(Grd.Rows[i].Cells["PartyID"].Value) != 0 && Convert.ToString(Grd.Rows[i].Cells["MCategoryID"].Value) != "" && Convert.ToInt32(Grd.Rows[i].Cells["MCategoryID"].Value) != 0)
                {
                    Common.CategoryPartyRelation cpr = new Common.CategoryPartyRelation(Convert.ToInt32(Grd.Rows[i].Cells["PartyID"].Value), Convert.ToString(Grd.Rows[i].Cells["PartyName"].Value), Convert.ToInt32(Grd.Rows[i].Cells["MCategoryID"].Value), Convert.ToString(Grd.Rows[i].Cells["MCategoryName"].Value));
                    listCPRelation.Add(cpr);
                }
            }
            if (listCPRelation.Count > 0)
            {                
                return true;
            }
            else
            {
                return false;
            }
        }

        private void LoadCPRelation()
        {
            if (GetCategoryPartyRelations())
            {
                int i = 0;
                foreach (Common.CategoryPartyRelation cpr in this.listCPRelation)
                {
                    Grd.Rows.Add();
                    //Grd.Rows[i].Cells["SrNo"].Value = cpr.SrNo;
                    Grd.Rows[i].Cells["PartyID"].Value = cpr.PartyID;
                    Grd.Rows[i].Cells["PartyName"].Value = cpr.PartyName;
                    Grd.Rows[i].Cells["MCategoryID"].Value = cpr.MCategoryID;
                    Grd.Rows[i].Cells["MCategoryName"].Value = cpr.MCategoryName;
                    i++;
                }
            }
        }

        

        private void Grd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
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

    
    }
}

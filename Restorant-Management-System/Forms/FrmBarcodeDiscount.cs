
using Accounts;
using Accounts.Forms;
using CategoryControlle;
using Common;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restorant_Management_System.Forms
{
    public partial class FrmBarcodeDiscount : Form
    {
        DataTable tables = new DataTable();
        List<DiscountOffer> ExcelBarcodes = new List<DiscountOffer>();
        List<Branch> Branchlist = new List<Branch>();
        List<DiscountOffer> selectedBracodes = new List<DiscountOffer>();
        List<Category> lstitem = new List<Category>();
        List<Category> subList = new List<Category>();
        int fileNo = 0;

        List<Branch> branchlist = new List<Branch>();
        List<DiscountOffer> barcodeList = new List<DiscountOffer>();
        bool isNew = true;
        DiscountOffer offer;
        public FrmBarcodeDiscount()
        {
            InitializeComponent();
        }

        private void FrmBarcodeDiscount_Load(object sender, EventArgs e)
        {
            
            ClearControls();
            //LoadGrid();
            //GetDepartments();


        }
        private void GetDepartments()
        {
            DataSet ds = new DataSet();
            ds = new DepartmentController().LoadDepartment();
            cmbDepartment.DataSource = ds.Tables[0];
            cmbDepartment.DisplayMember = "DepartName";
            cmbDepartment.ValueMember = "DepartID";
            cmbDepartment.SelectedIndex = -1;
        }
        private void LoadData(List<DiscountOffer> BarcodeList)
        {
            try
            {
                LoadGrid();
                if (BarcodeList.Count > 0)
                {
                    for (int i = 0; i < BarcodeList.Count; i++)
                    {
                        if (CheckExistingBarcode(BarcodeList[i].Barcode))
                        {
                            int RowIndex = Grd.Rows.Add();
                            Grd.Rows[RowIndex].Cells["Barcode"].Value = BarcodeList[i].Barcode;
                            Grd.Rows[RowIndex].Cells["Item"].Value = BarcodeList[i].ItemName;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadData", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private bool LoadCategoryGrid()
        {
            try
            {
                //Set Grid.
                ///////////////////////////////////////////////////////////////////////////////////////////////////
                AccountsGlobals.SetGridStyle(ref GrdCategory);

                Grd.EnableHeadersVisualStyles = false;
                //////////////////////////////////////////////////////////////////////////////////////////////////              
                //Specify which type of cell in this column (DataGridViewTextBoxCell,DataGridViewCheckBoxCell,
                //DataGridViewComboBoxCell,DataGridViewImageColumn,DataGridViewButtonColumn,DataGridViewLinkColumn



                DataGridViewCell TextCell = new DataGridViewTextBoxCell();
                DataGridViewCell DecimalCell = new TNumEditDataGridViewCell(2);
                DataGridViewCell RateCell = new TNumEditDataGridViewCell(4);
                DataGridViewCell IntCell = new TNumEditDataGridViewCell(0);

                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                DataGridViewComboBoxColumn comboCol = new DataGridViewComboBoxColumn();
                DataGridViewCell ComboCell = new DataGridViewComboBoxCell();

                DataGridViewComboBoxColumn comboCol2 = new DataGridViewComboBoxColumn();
                DataGridViewCell ComboCell2 = new DataGridViewComboBoxCell();

                //Col 1
                //////////////////////////////////////////////////////////////////////////////////////////////////                

                if (subList.Count > 0)
                {
                    GrdCategory.DataSource = subList;
                }
                else
                    GrdCategory.DataSource = lstitem;



                DataGridViewColumn newCol = new DataGridViewColumn(); // add a column to the grid                
                /////////////////////////////////////////
                newCol.CellTemplate = TextCell;
                newCol.HeaderText = "Category";
                newCol.Name = "Category";
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.ReadOnly = true;
                newCol.Width = 80;
                GrdCategory.Columns.Add(newCol);
                ////////////////////////////////////////////
                checkColumn = new DataGridViewCheckBoxColumn();
                checkColumn.HeaderText = "Select";
                checkColumn.Name = "Select";
                // checkColumn.CellTemplate = IntCell;
                checkColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                checkColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                checkColumn.Visible = true;
                checkColumn.Width = 50;
                GrdCategory.Columns.Add(checkColumn);
                /////////////////////////////////////
                ///
                GrdCategory.Columns["id"].Visible = false;
                GrdCategory.Columns["IsService"].Visible = false;
                GrdCategory.Columns["DepartID"].Visible = false;
                GrdCategory.Columns["DepartName"].Visible = false;
                GrdCategory.Columns["Category"].Visible = false;
                GrdCategory.Columns["Name"].Width = 200;
                // AccountsGlobals.ExtendCol(ref GrdCategory, "Category");

               
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return false;
            }
            return true;
        }
        private bool LoadBranchGrid()
        {
            try
            {
                //Set Grid.
                ///////////////////////////////////////////////////////////////////////////////////////////////////
                AccountsGlobals.SetGridStyle(ref GrdBranch);

                Grd.EnableHeadersVisualStyles = false;
                //////////////////////////////////////////////////////////////////////////////////////////////////              
                //Specify which type of cell in this column (DataGridViewTextBoxCell,DataGridViewCheckBoxCell,
                //DataGridViewComboBoxCell,DataGridViewImageColumn,DataGridViewButtonColumn,DataGridViewLinkColumn



                DataGridViewCell TextCell = new DataGridViewTextBoxCell();
                DataGridViewCell DecimalCell = new TNumEditDataGridViewCell(2);
                DataGridViewCell RateCell = new TNumEditDataGridViewCell(4);
                DataGridViewCell IntCell = new TNumEditDataGridViewCell(0);

                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                DataGridViewComboBoxColumn comboCol = new DataGridViewComboBoxColumn();
                DataGridViewCell ComboCell = new DataGridViewComboBoxCell();

                DataGridViewComboBoxColumn comboCol2 = new DataGridViewComboBoxColumn();
                DataGridViewCell ComboCell2 = new DataGridViewComboBoxCell();

                //Col 1
                //////////////////////////////////////////////////////////////////////////////////////////////////                


                DataGridViewColumn newCol = new DataGridViewColumn(); // add a column to the grid     

                ////////////////////
                newCol = new DataGridViewColumn();
                newCol.CellTemplate = TextCell;
                newCol.HeaderText = "ID";
                newCol.Name = "ID";
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.ReadOnly = true;
                newCol.Width = 50;
                GrdBranch.Columns.Add(newCol);
                /////////////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.CellTemplate = TextCell;
                newCol.HeaderText = "Branch";
                newCol.Name = "Branch";
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.ReadOnly = true;
                newCol.Width = 80;
                GrdBranch.Columns.Add(newCol);
                //////////////////////////////////////////
                checkColumn = new DataGridViewCheckBoxColumn();
                checkColumn.HeaderText = "Select";
                checkColumn.Name = "Select";
                // checkColumn.CellTemplate = IntCell;
                checkColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                checkColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                checkColumn.Visible = true;
                checkColumn.Width = 50;
                GrdBranch.Columns.Add(checkColumn);
                /////////////////////////////////////
                ///
                //GrdBranch.Columns["CityID"].Visible = false;
                //GrdBranch.Columns["CityName"].Visible = false;
                //GrdBranch.Columns["IsWherehouse"].Visible = false;
                //GrdBranch.Columns["Phone"].Visible = false;
                //GrdBranch.Columns["Email"].Visible = false;
                //GrdBranch.Columns["Address"].Visible = false;
                //GrdBranch.Columns["SaleNote"].Visible = false;
                AccountsGlobals.ExtendCol(ref GrdBranch, "Branch");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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




                //Col 2
                //////////////////////////////////////////////////////////////////////////////////////////////////   

                newCol.CellTemplate = TextCell;
                newCol.HeaderText = "Bar Code";
                newCol.Name = "BarCode";
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.ReadOnly = true;
                newCol.Width = 80;
                Grd.Columns.Add(newCol);





                ////////////////////////////////////

                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Product Name";
                newCol.Name = "Item";

                newCol.CellTemplate = TextCell;

                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;
                //  newCol.Visible = Globals.PackingColumnVisible;
                newCol.Width = 250;
                Grd.Columns.Add(newCol);

                /////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Discount";
                newCol.Name = "Discount";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.Width = 120;
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




                AccountsGlobals.ExtendCol(ref Grd, "Item");





                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectBarcodes();
        }
        private void SelectBarcodes()
        {
            try
            {

                for (int i = 0; i <= Grd.Rows.Count - 1; i++)
                {

                    if (Convert.ToString(Grd.Rows[i].Cells["Barcode"].Value) != "" && Convert.ToDecimal(Grd.Rows[i].Cells["Discount"].Value) != 0)
                    {
                        DiscountOffer b = new DiscountOffer();
                        b.Barcode = Convert.ToString(Grd.Rows[i].Cells["Barcode"].Value);
                        b.ItemName = Convert.ToString(Grd.Rows[i].Cells["Item"].Value);
                        b.Discount = Convert.ToDecimal(Grd.Rows[i].Cells["Discount"].Value);
                        barcodeList.Add(b);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                lstitem = new CategoryController().GetCategorylist(Convert.ToInt32(cmbDepartment.SelectedValue));
                LoadCategoryGrid();
                //lstitem = ds;

                PopulateCateogries();

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "cmbDepartment_SelectedIndexChanged",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void PopulateCateogries()
        {
            if (lstitem.Count > 0)
            {
                for (int i = 0; i < lstitem.Count; i++)
                {
                    int rowIndex = GrdCategory.Rows.Add();

                    GrdCategory.Rows[i].Cells["Category"].Value = lstitem[i].Name;

                }

            }
        }

        private void txtCategorySearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //PopulateListView(vNode);
                int cIndex = 0;

                if (this.txtCategorySearch.Text.Trim().Length == 0)
                {
                    subList.Clear();
                    LoadCategoryGrid();
                }
                else
                {
                    subList = lstitem.FindAll(FilterAccounts);
                    if (subList.Count > 0)
                    {
                        LoadCategoryGrid();
                    }
                    else
                    {
                        this.GrdCategory.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SchAccounts AccountName_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool FilterAccounts(Category a)
        {
            return a.Name.ToUpper().Contains(this.txtCategorySearch.Text.ToUpper());
        }

        private void BtnAddBarcodes_Click(object sender, EventArgs e)
        {
            try
            {

                List<Category> Selectcategories = new List<Category>();
                for (int i = 0; i < GrdCategory.Rows.Count - 1; i++)
                {
                    Category c = new Category();
                    if (Convert.ToBoolean(GrdCategory.Rows[i].Cells["Select"].Value) == true)
                    {
                        c.Id = Convert.ToInt32(GrdCategory.Rows[i].Cells["id"].Value);
                        Selectcategories.Add(c);
                    }
                }

                selectedBracodes = new ItemController().GetSeletedBarcodes(Selectcategories);
                if (selectedBracodes.Count > 0)
                {
                    LoadData(selectedBracodes);
                }

                LoadBranches();

            }
            catch (Exception ex)
            {

            }

        }

        private void LoadBranches()
        {
            LoadBranchGrid();
            Branchlist = new CategoryControlle.BranchController().GetBranch("");
            if (Branchlist.Count > 0)
            {
                for (int i = 0; i < Branchlist.Count; i++)
                {
                    int rowIndex = GrdBranch.Rows.Add();

                    GrdBranch.Rows[i].Cells["ID"].Value = Branchlist[i].ID;
                    GrdBranch.Rows[i].Cells["Branch"].Value = Branchlist[i].BranchName;



                }


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearControls();
           

        }

        private void ClearControls()
        {
            btnSave.Enabled = true;
            LoadCategoryGrid();
            LoadGrid();
            LoadBranches();
            GetDepartments();
            chkExcel.Checked = false;
            grbExcel.Visible = false;
            chkIsActive.Checked = true;
            dtpFromDate.Value = DateTime.Now;
            dtpToDate.Value = DateTime.Now;
            txtFileID.Text = new DiscountOfferController().GetMaxFileNo();
            barcodeList.Clear();
            branchlist.Clear();
            txtFileNmae.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (ValidateControls())
                {
                    if (AddData())
                    {
                        ItemName itn = new ItemName("", "", "", "");
                        Item i = new Item(0, itn);

                        Category c = new Category(Convert.ToInt32(0), "");

                        int FileNo = 0;
                        if (isNew == false)
                        {
                            FileNo = Convert.ToInt32(txtFileID.Text);
                        }
                        DiscountOffer DO = new DiscountOffer(FileNo, c, i, Convert.ToDecimal(0), this.chkIsActive.Checked, this.dtpFromDate.Value, this.dtpToDate.Value, branchlist, barcodeList);

                        if (new DiscountOfferController().CheckBarcodeOffer(DO, isNew) == false)
                        {
                            if (new DiscountOfferController().SaveBracodeOffer(DO, isNew))
                            {
                                MessageBox.Show("Offer is saved successfully.", "Saved successfully...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearControls();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Offer already has been defined for this combination.", "Check Combination...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private bool AddData()
        {

            SelectBarcodes();
            AddBranches();

            return true;
        }

        private void AddBranches()
        {
            try
            {

                for (int i = 0; i <= GrdBranch.Rows.Count - 1; i++)
                {

                    if (Convert.ToBoolean(GrdBranch.Rows[i].Cells["Select"].Value) == true)
                    {
                        Branch b = new Branch();
                        b.ID = Convert.ToInt32(GrdBranch.Rows[i].Cells["ID"].Value);
                        //b.BranchName = Convert.ToString(GrdBranch.Rows[i].Cells["Bracnh"].Value);
                        //b.Select = Convert.ToBoolean(GrdBranch.Rows[i].Cells["Select"].Value);
                        branchlist.Add(b);
                    }

                }
                //this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidateControls()
        {
            try
            {
                if (Grd.Rows.Count <= 1)
                {
                    MessageBox.Show("Please add some items ", " ValidateControls", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                int count = 0;
                for (int i=0; i<GrdBranch.Rows.Count-1;i++)
                {
                  
                    if (Convert.ToBoolean(GrdBranch.Rows[i].Cells["Select"].Value) == true)
                    {
                        count = count + 1;
                    }                 
                   
                }
                if (count == 0)
                {
                    MessageBox.Show("Please Select Branch First ", " ValidateControls", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
              

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmDiscounts ValidateControls", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Sch_Forms.SchBarcodeDiscount frm = new Sch_Forms.SchBarcodeDiscount();
            frm.IsCategoryDisc = false;
           // frm.FormBorderStyle = FormBorderStyle.None;
            frm.ShowDialog();
            if (frm.ParaOutID != 0)
            {
              
                List<DiscountOffer> editlist = new List<DiscountOffer>();
                editlist = new DiscountOfferController().GetBarcodeItems(frm.ParaOutID,false);
                if (editlist.Count > 0 )
                {
                    btnDelete.Enabled = true;
                    btnSave.Enabled = false;
                    ClearControls();
                    fileNo = frm.ParaOutID;
                    txtFileID.Text = fileNo.ToString();
                    for (int i = 0; i < editlist[0].barcodeList.Count; i++)
                    {
                        int rowIndex = Grd.Rows.Add();


                        Grd.Rows[i].Cells["Barcode"].Value = editlist[0].barcodeList[i].Barcode.ToString();
                        Grd.Rows[i].Cells["Item"].Value =  editlist[0].barcodeList[i].ItemName.ToString();
                        Grd.Rows[i].Cells["Discount"].Value = editlist[0].barcodeList[i].Discount.ToString();
                        

                    }
                    //////////////
                    
                    isNew = false;

                    dtpFromDate.Value = editlist[0].FromDate;
                    dtpToDate.Value = editlist[0].ToDate;
                    chkIsActive.Checked = editlist[0].IsActive;


                    //FillBarcodes(offer);
                    FillBranches(editlist[0].branchList);
                }
            }
        }

        private void FillBranches(List<Branch> list)
        {
            //branchlist = offer.branchList;
            LoadBranchGrid();
          
           // Branchlist = new CategoryControlle.DiscountOfferController().GetOfferBranches(offer.OfferID);
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    int rowIndex = GrdBranch.Rows.Add();
                    GrdBranch.Rows[i].Cells["ID"].Value = list[i].ID;
                    GrdBranch.Rows[i].Cells["Branch"].Value = list[i].BranchName;
                   
                    GrdBranch.Rows[i].Cells["Select"].Value = list[i].Select;

                }

            }

        }

        private void FillBarcodes(DiscountOffer offer)
        {
            int Rowindex=Grd.Rows.Add();
            Grd.Rows[Rowindex].Cells["Barcode"].Value = offer.barcodeList[0].Barcode;
            Grd.Rows[Rowindex].Cells["Item"].Value = offer.barcodeList[0].ItemName;
            Grd.Rows[Rowindex].Cells["Discount"].Value = offer.barcodeList[0].Discount;
        }

        private void chkExcel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExcel.Checked)
            {
                grbExcel.Visible = true;
            }
            else
                grbExcel.Visible = false;
        }

        private void btnBrowes_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx" })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        txtFileNmae.Text = ofd.FileName;
                        using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                        {
                            using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                DataSet data = reader.AsDataSet(new ExcelDataSetConfiguration() { ConfigureDataTable = __ => new ExcelDataTableConfiguration() { UseHeaderRow = true } });

                                tables = data.Tables[0];
                                PopulateData(tables);
                                //Grd.DataSource = tables;


                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "btnBrowes_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void PopulateData(DataTable dt)
        {
            try
            {


                ExcelBarcodes.Clear();
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    DiscountOffer offer = new DiscountOffer();
                    string itemname = new ItemController().GetItemName(dt.Rows[i]["BARCODE"].ToString());
                    if (itemname != "")
                    {
                        offer.Barcode = dt.Rows[i]["BARCODE"].ToString();
                        offer.ItemName = itemname;
                        offer.Discount = Convert.ToDecimal(dt.Rows[i]["DISCOUNT"]);
                        ExcelBarcodes.Add(offer);
                    }
              
                }

                if (ExcelBarcodes.Count > 0)
                {
                    for (int i = 0; i < ExcelBarcodes.Count; i++)
                    {
                        if (CheckExistingBarcode(ExcelBarcodes[i].Barcode))
                        {
                            int RowIndex = Grd.Rows.Add();
                            Grd.Rows[RowIndex].Cells["Barcode"].Value = ExcelBarcodes[i].Barcode;
                            Grd.Rows[RowIndex].Cells["Item"].Value = ExcelBarcodes[i].ItemName;
                            Grd.Rows[RowIndex].Cells["Discount"].Value = ExcelBarcodes[i].Discount;
                        }

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "PopulateData", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckExistingBarcode(string barcode)
        {
           for(int i = 0; i < Grd.Rows.Count - 1; i++)
           {
                if(barcode==Grd.Rows[i].Cells["Barcode"].Value.ToString())
                {
                    return false;
                }
                
           }
            return true;
        }

        private void Grd_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            SetRowNo(ref Grd);
        }

        private void SetRowNo(ref DGV.DGV grd)
        {
            try
            {
                int count = 0;

                for (int i = 0; i < grd.Rows.Count; i++)
                {
                    if (grd.Rows[i].Visible == true)
                    {
                        grd.Rows[i].HeaderCell.Value = (count + 1).ToString();
                        grd.Rows[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        count++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetRowNo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Grd_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            SetRowNo(ref Grd);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you want to Delete ", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (new DiscountOfferController().DeleteBarcode(fileNo))
                    {
                        MessageBox.Show("Deleted Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearControls();
                    }
                }
                 
            }
            catch (Exception  ex)
            {

                MessageBox.Show(ex.Message, "btnDelete_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

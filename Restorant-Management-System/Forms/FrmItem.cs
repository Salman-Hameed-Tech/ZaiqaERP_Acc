using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CategoryControlle;
using Common;
using Accounts.SchForms;
using System.Text.RegularExpressions;

namespace Accounts.Forms
{
    public partial class FrmItem : Form
    {
        private bool IsNew;
       

        List<Barcode > barcodes = new List<Barcode >();
        private BindingSource source = new BindingSource();
        public List<Item> lst = new List<Item>();
        public FrmItem()
        {
            InitializeComponent();
        }
        ChartofAccountsController cc = new ChartofAccountsController();
        public void LoadGrid()
        {
            try
            {
               
                Grd.Columns["BarCode"].HeaderText = "Bar Code";
                Grd.Columns["BarCode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["BarCode"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["BarCode"].Width = 150;

                AccountsGlobals.ExtendCol(ref Grd, "BarCode");

                if (Grd.Rows.Count > 0)
                {
                    Grd.Rows[0].Selected = true;
                }
                //Grd.ExtendRightColumn = true;                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "frmItem LoadGrid.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool LoadCategories()
        {
            try
            {
                List<Category> categories = new CategoryController().GetCategories(0);
                cmbCategory.DataSource = categories;
                cmbCategory.ValueMember = "ID";
                cmbCategory.DisplayMember = "Name";

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadCategories", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool LoadCounters()
        {
            try
            {
                List<Counter> counters = new CounterController().GetCounter();
                cmbCounter.DataSource = counters;
                cmbCounter.ValueMember = "ID";
                cmbCounter.DisplayMember = "CounterName";
                cmbCategory.SelectedIndex = -1;               

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadCategories", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool ClearControls()
        {
            try
            {
                this.txtItemID.Text  = new ItemController().MaxID().ToString();
                btnDelete.Enabled = false;
                barcodes.Clear();
                FormatGrid();
                chkBakeryItem.Checked = false;
                
                chkIsMarinatedItem.Checked = false;
                // LoadGrid();
                txtVenorID.Clear();
                txtVendorName.Clear();
                TxtSticker.Clear();
                IsNew = true;
                txtItemName.Clear();
                txtBarCode.Clear();
                cmbCompanyName.Text = "";
                txtPacking.Clear();
                cmbProductName.Text = "";
                cmbDesign.Text = "";
                cmbOrigin.Text  = "";
                txtPrintName.Clear();
                txtUnit.Clear();
                txtPurchasePrice.Text  = "0";
                txtReOrderLevel.Text  = "0";
                txtDiscountLimit.Text  = "0";
                TxtPurPrice.Text = "0";
                TxtOpQty.Text = "0";

                chkIsActive.Checked  = true ;
                chkRePrint.Checked = false;
                //txtOpeningQuantity.Text  = "0";
                txtPurchasePrice.Text  = "0";
                txtSalePrice.Text  = "0";
                cmbSeasons.Text = "";
                txtSaleTaxAccNo.Clear();
                 txtPurchaseAccNo .  Clear();
                 txtPurchaseAccName.Clear();
              //   txtMultiplier.Text = "1";
                 txtPacking.Text.Trim();
                 txtSaleAccNo.Clear();
                 txtSaleAccName.Clear();

                 txtSaleTaxAccNo.Clear();
                 txtSalTaxAccNam.Clear();
                txtPurchaseAccNo.Enabled = false;
                txtPurchaseAccNo.Text = "11017";
                txtPurchaseAccName.Text = "Purchase Account";
                txtSaleAccNo.Text = "40021";
                 txtSaleAccName.Text = "Sale Account";

                //BarCode

                Barcode objBar = new Barcode();
                barcodes.Clear();
                objBar.Itembarcode = objBar.MakeBarcode(Convert.ToString(txtItemID.Text));
                barcodes.Add(objBar);
                Grd.DataSource = barcodes;
                Grd.Columns["itembarcode"].HeaderText = "Bar Code";
                Grd.Columns["itembarcode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["itembarcode"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                AccountsGlobals.ExtendCol(ref Grd, "itembarcode");

                cmbCategory.SelectedIndex = -1;
                cmbDepartment.SelectedIndex = -1;
                cmbColor.Text = "";
                txtMarginAmt.Text = "0";
                txtMarginPer.Text = "0";
                cmbDepartment.Text = "";

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ClearControls", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool ValidateControls()
        {
            try
            {
                if (txtItemName.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Please Enter Product Name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbCompanyName.Focus();
                    return false;
                }
                if (cmbCategory.SelectedIndex < 0 )
                {
                    MessageBox.Show("Please select category.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbCategory.Focus();
                    return false;
                }



                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ValidateControls", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //private string CreateAccount(string parentAccount,int depth,AccountType accountType,string nameExtension)
        //{
        //    try
        //    {
                
        //            ChartOfAccounts acc = new ChartOfAccounts();
        //            string accountExtension = new ChartofAccountsController().GetAccountExtension(parentAccount, accountType.ToString ());
        //            acc = cc.GetAccountDetail(parentAccount, "");
                   
        //            acc = new ChartOfAccounts();

        //            acc.IsDetailed = true ;                   

        //            acc.AccountDepth = depth ;
        //            acc.AccountName = this.txtItemName.Text.Trim() + " " + nameExtension ;
        //            acc.AccountNo = parentAccount + accountExtension;
        //            //acc.AccountType = (AccountType)Enum.Parse(typeof(AccountType), this.txtAccountType.Text, true);
        //            acc.AccountType = accountType;
        //            acc.AdjustedCredit = 0;
        //            acc.AdjustedDebit = 0;
        //            acc.Narration = "";
        //            acc.BalFlag = false;
        //            acc.ExpFlag = false;
        //            acc.IsEditable = true;
        //            acc.IsLocked = false;
        //            acc.IsPosted = false;
        //            acc.OpeningCredit = 0;
        //            acc.OpeningDebit = 0;
        //            acc.ParentAccount = new ChartOfAccounts(parentAccount, "");
        //            acc.PlFlag = "-";

        //            cc.SaveAccount(acc);               

        //        return acc.AccountNo ;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "FrmNewAccount SaveAccount", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return null ;
        //    }            
        //}

        private void InsertAccounts()
        {
            
        }
        private bool Save()
        {
            try
            {
                bool accountTrans = false;

                if (Globals.AccountForEachItem) // If Set to true each item will have separte account for Purchase(in assets) and Sale(In Revenue).
                {
                    ChartOfAccounts saleAccount = new ChartOfAccounts(txtSaleAccNo.Text.Trim(), txtItemName.Text.Trim() + "(Sale)");
                    saleAccount.Narration = "";
                    ChartOfAccounts purchaseAccount = new ChartOfAccounts(txtPurchaseAccNo.Text.Trim(), txtItemName.Text.Trim() + "(Purchase)");
                    purchaseAccount.Narration = "";

                   

                    if (IsNew == false)
                    {

                        new ChartofAccountsController().UpdateAccount(purchaseAccount);
                        new ChartofAccountsController().UpdateAccount(saleAccount);
                        accountTrans = true;
                    }
                    else
                    {                       
                        accountTrans = true;
                    }
                }
                else // All the accounts transactions of item will be done in single sale account and single purchase account.
                {
                  
                    accountTrans = true; 
                }

                if (accountTrans)
                {

                    Item i = new Item(Convert.ToInt32(txtBarCode.Text), Convert.ToInt32(cmbCategory.SelectedValue), new ItemName(this.cmbCompanyName.Text, this.cmbProductName.Text, this.cmbDesign.Text, this.cmbOrigin.Text), Convert.ToDecimal(txtPurchasePrice.Text), Convert.ToDecimal(txtSalePrice.Text), Convert.ToDecimal(txtDiscountLimit.Text), Convert.ToDecimal(txtReOrderLevel.Text), new ChartOfAccounts(Convert.ToString(txtSaleAccNo.Text), "Purchase Account"), new ChartOfAccounts(Convert.ToString(txtPurchaseAccNo.Text), "Sale Account"), chkIsActive.Checked, txtshortkey.Text, Convert.ToDouble(TxtOpQty.Text), Convert.ToDouble(txtPurchasePrice.Text), Convert.ToString(TxtSticker.Text), this.chkRePrint.Checked);

                    if (new ItemController().SaveItem(i, barcodes))
                    {
                        MessageBox.Show("Item Saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearControls();
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void CheckRights(int formid)
        {
            try
            {
                List<UserRight> right = new List<UserRight>();
                right = AccountsGlobals.UserRights;
                for (int i = 0; i < right.Count; i++)
                {
                    if (right[i].ID == formid)
                    {
                        btnEdit.Enabled = right[i].CanEdit;
                        btnDelete.Enabled = right[i].CanDelete;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex + "", "CheckRights", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FrmItem_Load(object sender, EventArgs e)
        {
            try
            {

                if (!User._IsAdmin)
                {
                    CheckRights(Convert.ToInt16(this.Tag));
                }

                //tsbtnEdit.Visible = (AccountsGlobals.FormRights(4).CanEdit);
                //tsbtnEdit.Visible = (AccountsGlobals.FormRights(4).CanEdit);
                this.BackColor = AccountsGlobals.FormColor;
                ClearControls();
                LoadCategories();
                //LoadCounters();
                //GetDepartments();

                //  txtMultiplier.Visible = Globals.PackingColumnVisible;

                SetCmbBoxs(" Select distinct(CompanyName) as Name from Item I", ref  cmbCompanyName);
                SetCmbBoxs(" Select distinct(ProductName) as Name from Item I ", ref  cmbProductName);
                SetCmbBoxs(" Select distinct(Design) as Name from Item I ", ref  cmbDesign);
                //SetCmbBoxs(" Select distinct(Size) as Name from Item I ", ref  cmbOrigin);
                //SetCmbBoxs(" Select distinct(Color) as Name from Item I ", ref cmbColor);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmItem_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

        private void tsbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbtnClear_Click(object sender, EventArgs e)
        {
            this.ClearControls();
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                Save();
            }
        }

        public  void tsbtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                SchForms.SchItems frm = new SchForms.SchItems();
                frm.ShowDialog();

                Item i = frm.item;

                if (frm.item  != null )
                {                 

                    if (i != null)
                    {
                        ClearControls();
                        this.txtItemID.Text = i.ItemID.ToString();

                        cmbCategory.Text = i.Category.Name;
                        cmbCategory.SelectedValue = i.Category.Id;
                        txtItemName.Text = i.ItemName.ToString();
                        cmbCompanyName.Text = i.ItemName.CompanyName ;
                        cmbProductName.Text = i.ItemName.ProductName;
                        cmbDesign.Text = i.ItemName.Design ;
                        cmbOrigin.Text = i.ItemName.Size ;
                        txtUnit.Text = i.Unit;
                        //txtPurchasePrice.Text  = i.PurchasePrice.ToString ();
                        //txtReOrderLevel.Text  =  i.ReorderLimit.ToString ();
                        //txtDiscountLimit.Text  = i.DiscountLimit.ToString ();
                        //chkIsActive.Checked = i.IsActive;
                        //chkAddToPrint.Checked = i.AddToPrint;
                        //txtOpeningQuantity.Text  =i.OpQty1.ToString ();
                        //txtPurchasePrice.Text  = i.PurchasePrice.ToString ();
                        //txtSalePrice.Text  = i.SalePrice.ToString ();
                      //  txtPacking.Text = i.Packing;
                        //txtMultiplier.Text  = i.Multiplier.ToString();
                       // txtPrintName.Text = i.PrintName;
                        txtPurchaseAccNo.Text  = i.PurchaseAccount .AccountNo ;
                        txtPurchaseAccName.Text = i.PurchaseAccount.AccountName;

                        txtSaleAccNo.Text = i.SaleAccount.AccountNo;
                        txtSaleAccName.Text = i.SaleAccount.AccountName;

                      //  txtSaleTaxAccNo.Text = i.SaleTaxAccount.AccountNo;
                      //  txtSalTaxAccNam.Text = i.SaleTaxAccount.AccountName;

                      //  this.barcodes = i.Barcodes;
                        FormatGrid();
                        IsNew = false ;
                    }

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "tsbtnEdit_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowSearch(ref System.Windows.Forms.TextBox txtno, ref System.Windows.Forms.TextBox txtname)
        {
            try
            {
                SchAccounts Sch = new SchAccounts();
                Sch.accountType = " and AccountNo <> 111";
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

        private bool SetCmbBoxs(string Select, ref ComboBox cmb)
        {
            try
            {
                cmb.DataSource = null;
                List<string> names = new List<string>();
                names = new ItemController().GetNames(Select );
                cmb.DataSource = names;
                cmb.SelectedIndex = -1;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadNames", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }          
        
        }
        int departmentid = 0;
        private void SetName()
        {
            try
            {
                txtItemName.Text = (cmbCompanyName.Text.Trim().Length == 0 ? "" : cmbCompanyName.Text.Trim() + "-")+(cmbProductName.Text.Trim().Length == 0 ? "" : cmbProductName.Text.Trim() + "-") + (cmbDesign.Text.Trim().Length == 0 ? "" : cmbDesign.Text.Trim() + "-") +(cmbColor.Text.Trim().Length==0 ? "" : cmbColor.Text.Trim() + "-") + (cmbSeasons.Text.Trim().Length==0 ? "" : cmbSeasons.Text.Trim() + "-") + (cmbOrigin.Text.Trim().Length == 0 ? "" : cmbOrigin.Text.Trim());

                //txtItemName.Text = (cmbProductName.Text.Trim().Length == 0 ? "" : cmbProductName.Text.Trim() + "-") + (cmbDesign.Text.Trim().Length == 0 ? "" : cmbDesign.Text.Trim() + "-") + (cmbOrigin.Text.Trim().Length == 0 ? "" : cmbOrigin.Text.Trim() + "-") + (cmbCompanyName.Text.Trim().Length == 0 ? "" : cmbCompanyName.Text.Trim()+"-")+(cmbColor.Text.Trim().Length==0 ? "" : cmbColor.Text.Trim());
                //cmbDepartment.Text = new CategoryControlle.ItemController().GetDapartment(Convert.ToInt32(cmbCategory.SelectedValue));
                //if (cmbDepartment.Text != "")
                //{
                //     departmentid = new CategoryControlle.ItemController().GetDapartmentid(cmbDepartment.Text);
                //    cmbDepartment.SelectedValue = departmentid;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetName", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCategory_Leave(object sender, EventArgs e)
        {
            
            //SetCmbBoxs(" Select distinct(CompanyName) as Name from Item I inner Join ItemCategory C on I.CategoryID = C.CategoryID where C.CategoryID = " + cmbCategory.SelectedValue, ref  cmbCompanyName);
            
            SetName();
        }
       
        private void cmbCompanyName_Leave(object sender, EventArgs e)
        {
            //SetCmbBoxs(" Select distinct(ProductName) as Name from Item I inner Join ItemCategory C on I.CategoryID = C.CategoryID where C.CategoryID = " + cmbCategory.SelectedValue + " and CompanyName = '" + cmbCompanyName.Text.Trim() + "'", ref  cmbProductName);
            
            SetName();
        }       
        

        private void cmbProductName_Leave(object sender, EventArgs e)
        {
            //SetCmbBoxs(" Select distinct(Design) as Name from Item I inner Join ItemCategory C on I.CategoryID = C.CategoryID where C.CategoryID = " + cmbCategory.SelectedValue + " and CompanyName = '" + cmbCompanyName.Text.Trim() + "' and ProductName = '" + cmbProductName.Text.Trim() + "'", ref  cmbDesign);
            
            
            SetName();
        }
        
        private void cmbDesign_Leave(object sender, EventArgs e)
        {
            //SetCmbBoxs(" Select distinct(Origin) as Name from Item I inner Join ItemCategory C on I.CategoryID = C.CategoryID where C.CategoryID = " + cmbCategory.SelectedValue + " and CompanyName = '" + cmbCompanyName.Text.Trim() + "' and ProductName = '" + cmbProductName.Text.Trim() + "' and Design = '" + cmbDesign.Text.Trim() + "'", ref  cmbOrigin);
            
           
            SetName();
        }

        private void cmbSize_Leave(object sender, EventArgs e)
        {
            //txtItemName.Text = cmbCategory.Text.Trim() + "-" + cmbCompanyName.Text.Trim() + "-" + cmbProductName.Text.Trim() + "-" + cmbDesign.Text.Trim() + "-" + cmbOrigin .Text .Trim ();
            SetName();
        }

        private void btnPurchaseAcc_Click(object sender, EventArgs e)
        {
            ShowSearch(ref txtPurchaseAccNo, ref  txtPurchaseAccName);
        }

        private void btnSaleAcc_Click(object sender, EventArgs e)
        {
            ShowSearch(ref txtSaleAccNo, ref txtSaleAccName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowSearch(ref txtSaleTaxAccNo , ref txtSalTaxAccNam );
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmItem_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmItem_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddBarcode_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBarCode.Text.Trim().Length == 0) return;
                if (new ItemController().VerifyBarcodes(txtBarCode.Text))
                {
                    Barcode objBar = new Barcode();
                    objBar.Itembarcode = txtBarCode.Text;

                    if (barcodes.Contains(objBar) == false)
                    {
                        Grd.DataSource = null;
                        barcodes.Add(objBar);
                        Grd.DataSource = barcodes;
                       
                        Grd.Columns["itembarcode"].HeaderText = "Bar Code";
                        Grd.Columns["itembarcode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        Grd.Columns["itembarcode"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        AccountsGlobals.ExtendCol(ref Grd, "itembarcode");

                        txtBarCode.Clear();
                    }
                    else
                        MessageBox.Show("Barcode Already Exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    MessageBox.Show("Barcode Already Exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void FormatGrid()
        {
            try
            {
                Barcode objBar = new Barcode();
                objBar.Itembarcode = objBar.MakeBarcode(Convert.ToString(txtBarCode.Tag));
                barcodes.Add(objBar);
                Grd.DataSource = null;    
                source.DataSource = barcodes;
            
                Grd.ScrollBars = ScrollBars.Vertical;


                //Grd.Columns["itembarcode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //Grd.Columns["itembarcode"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //Grd.ExtendCol("itembarcode");
                SetRowNo(ref Grd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FormatGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddBarcode_Click(null,null);
            }
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

        private void Grd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    DialogResult result = MessageBox.Show("Are sure you want to delete this barcode?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (barcodes .Count > 1)
                        {
                            barcodes.Remove(barcodes[Grd.CurrentRow.Index]);
                            FormatGrid();
                        }
                        else
                        {
                            MessageBox.Show("There must be atleast 1 barcode in the list.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Grd_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                try
                {
                    cmbCategory.Focus();
                    if (cmbCategory.Focus() == false) return;
                    if (ValidateControl() == true)
                    {
                        Boolean check;
                        if (chkIsActive.Checked)
                            check = true;
                        else
                            check = false;

                        Item i = new Item(Convert.ToInt32(txtItemID.Text), Convert.ToInt32(this.cmbCategory.SelectedValue), new ItemName(this.cmbCompanyName.Text, this.cmbProductName.Text, this.cmbDesign.Text, this.cmbOrigin.Text), Convert.ToDecimal(txtPurchasePrice.Text), Convert.ToDecimal(txtSalePrice.Text), Convert.ToDecimal(txtDiscountLimit.Text), Convert.ToDecimal(txtReOrderLevel.Text), new ChartOfAccounts(Convert.ToString(txtSaleAccNo.Text), "Purchase Account"), new ChartOfAccounts(Convert.ToString(txtPurchaseAccNo.Text), "Sale Account"), check, txtshortkey.Text, Convert.ToDouble(TxtOpQty.Text), Convert.ToDouble(TxtPurPrice.Text), Convert.ToString(TxtSticker.Text), this.chkRePrint.Checked);
                        i.Unit = this.txtUnit.Text.Trim();

                        i.DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue);
                        i.Seasons = this.cmbSeasons.Text.Trim();
                        i.PartyID = this.txtVenorID.Text.Trim();                    
                        i.MarginAmt = Convert.ToDecimal(txtMarginAmt.Text);
                        i.IsMarinated = chkIsMarinatedItem.Checked;
                        i.SalePrice = Convert.ToDecimal(txtSalePrice.Text.Trim().Length == 0 ? "0" : txtSalePrice.Text.Trim());
                        i.IsBakeryItem = chkBakeryItem.Checked;


                        if (new ItemController().SaveItem(i, barcodes))
                        {

                            MessageBox.Show("Item Saved Successfully.", "Saved Successfully...", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            DialogResult result = MessageBox.Show("Do you Want to Clear Fields?", "Validation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (result == DialogResult.Yes)
                            {
                                ClearControls();
                            }
                            this.txtItemID.Text = new ItemController().MaxID().ToString();

                                Barcode objBar = new Barcode();
                                barcodes.Clear();
                                objBar.Itembarcode = objBar.MakeBarcode(Convert.ToString(txtItemID.Text));
                                barcodes.Add(objBar);
                                Grd.DataSource = barcodes;
                                Grd.Columns["itembarcode"].HeaderText = "Bar Code";
                                Grd.Columns["itembarcode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                Grd.Columns["itembarcode"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                AccountsGlobals.ExtendCol(ref Grd, "itembarcode");


                         
                           
                        }
                        else
                        {
                            MessageBox.Show("Item can not be saved due to some reason.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.cmbCategory.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
             
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {


                SchForms.SchItems frm = new SchForms.SchItems();
                frm.ShowDialog();
                List<Item> lstitem = new List<Item>();
                lstitem = frm.subList1;
                if (lstitem.Count > 0)
                {
                    ClearControls();
         
                    for (int i = 0; i < lstitem.Count; i++)
                    {
                        btnDelete.Enabled = true;
                        txtItemID.Text = Convert.ToString(lstitem[i].ItemID);
                        txtBarCode.Text = Convert.ToString(lstitem[i].ItemID);
                        cmbCategory.SelectedValue = Convert.ToInt32(lstitem[i].CategoryID);
                        cmbCompanyName.Text = lstitem[i].ItemName.CompanyName;
                        cmbProductName.Text = lstitem[i].ItemName.ProductName;
                        cmbDesign.Text = lstitem[i].ItemName.Design;
                        cmbOrigin.Text= lstitem[i].ItemName.Size;
                        txtSalePrice.Text= lstitem[i].SalePrice.ToString();
                        chkBakeryItem.Checked = lstitem[i].IsBakeryItem;

                        txtItemName.Text = lstitem[i].ItemName.CompanyName + "-" + lstitem[i].ItemName.ProductName + "-" + lstitem[i].ItemName.Design + "-" + lstitem[i].ItemName.Size +" " + lstitem[i].ItemName.Color ;
                      
                        //txtPurchaseAccNo.Text = Convert.ToString(lstitem[i].PurchaseAccount.AccountNo);
                      
                        VerifyAcc(ref txtPurchaseAccNo, ref txtPurchaseAccName);
                        //txtPurchaseAccName.Text = lstitem [i].PurchaseAccount.AccountName ;
                        txtSaleAccNo.Text = Convert.ToString(lstitem[i].SaleAccount.AccountNo);
                        VerifyAcc(ref txtSaleAccNo, ref txtSaleAccName);
                        //txtPurchaseAccName.Text = lstitem [i].SaleAccount.AccountName ;
                      //  TxtSticker.Text = lstitem[i].Sticker;

                       
                        chkIsActive.Checked = Convert.ToBoolean(lstitem[i].IsActive);
                        chkIsMarinatedItem.Checked= Convert.ToBoolean(lstitem[i].IsMarinated);


                    }

                    Grd.DataSource = null;
                    barcodes = (new ItemController().LoadBarcode(Convert.ToUInt16(txtBarCode.Text)));
                    Grd.DataSource = barcodes;
                    Grd.DataSource = barcodes;
                    Grd.Columns["itembarcode"].HeaderText = "Bar Code";
                    Grd.Columns["itembarcode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    Grd.Columns["itembarcode"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    AccountsGlobals.ExtendCol(ref Grd, "itembarcode");
                   
                 
                    txtBarCode.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

            /*try
             {
                 SchForms.SchItems frm = new SchForms.SchItems();
                 frm.ShowDialog();
                 List<Item> lstitem = new List<Item>();
                 lstitem = frm.subList1;
                 if (lstitem.Count > 0)
                 {
                     ClearControls();
                     for (int i = 0; i < lstitem.Count; i++)
                     {
                         txtDepartment.Text = lstitem[i].DepartName.ToString();
                         txtBarCode.Text = Convert.ToString(lstitem[i].ItemID);
                         cmbCategory.SelectedValue = Convert.ToInt32(lstitem[i].Category.Id);
                         cmbCompanyName.Text = lstitem[i].ItemName.CompanyName;
                         cmbProductName.Text = lstitem[i].ItemName.ProductName;
                         cmbDesign.Text = lstitem[i].ItemName.Design;
                         cmbOrigin.Text = lstitem[i].ItemName.Size;
                         txtItemName.Text = lstitem[i].ItemName.CompanyName + " " + lstitem[i].ItemName.ProductName + " " + lstitem[i].ItemName.Design + " " + lstitem[i].ItemName.Size;
                         this.txtUnit.Text = lstitem[i].Unit;
                         txtPurchaseAccNo.Text = Convert.ToString(lstitem[i].PurchaseAccount.AccountNo);
                        VerifyAcc(ref txtPurchaseAccNo, ref txtPurchaseAccName);

                         txtSaleAccNo.Text = Convert.ToString(lstitem[i].SaleAccount.AccountNo);
                         VerifyAcc(ref txtSaleAccNo, ref txtSaleAccName);

                         TxtSticker.Text = lstitem[i].Sticker;

                         txtPurchasePrice.Text = (lstitem[i].PurchasePrice).ToString();
                         txtSalePrice.Text = (lstitem[i].SalePrice).ToString();
                         txtDiscountLimit.Text = (lstitem[i].DiscountLimit).ToString();
                         txtReOrderLevel.Text = (lstitem[i].ReorderLimit).ToString();
                         txtshortkey.Text = Convert.ToString(lstitem[i].ShortKey);
                         TxtOpQty.Text = lstitem[i].OpQty1.ToString();
                         //TxtPurPrice.Value = lstitem[i].Purprice1;
                         chkIsActive.Checked = Convert.ToBoolean(lstitem[i].IsActive);
                         if (lstitem[i].CurrentStock < 0)
                             txtPurchasePrice.Enabled = false;
                         else
                             txtPurchasePrice.Enabled = true;
                         if (lstitem[i].Isloacked == true)
                         {
                             TxtOpQty.Enabled = false;
                            // TxtPurPrice.Enabled = false; ;
                         }
                         else
                         {
                            // TxtPurPrice.Enabled = true;
                             TxtOpQty.Enabled = true;
                         }

                         this.chkRePrint.Checked = lstitem[i].AddToPrint;

                     }
                     PnlSub.DataSource = null;
                     barcodes = (new ItemController().LoadBarcode(Convert.ToUInt16(txtBarCode.Text)));
                     PnlSub.DataSource = barcodes;
                     PnlSub.Columns["itembarcode"].HeaderText = "Bar Code";
                     PnlSub.Columns["itembarcode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     PnlSub.Columns["itembarcode"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     AccountsGlobals.ExtendCol(ref PnlSub, "itembarcode");
                     txtBarCode.Clear();
                 }





             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "tsbtnEdit_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }*/
        }

        
        private void VerifyAcc(ref System.Windows.Forms.TextBox txtno, ref System.Windows.Forms.TextBox txtname)
        {
            ChartOfAccounts Ca;
            Ca = new ChartofAccountsController().GetAccountDetail(txtno.Text, " and c1.isdetailed=1");
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

        private void txtshortkey_Validating(object sender, CancelEventArgs e)
        {
            if (txtshortkey.Text.Trim().Length == 0) return;
            if (new ItemController().ChkShortkey(txtshortkey.Text))
            {
                MessageBox.Show("Short Key Already Exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private Boolean ValidateControl()
        {

            if (this.txtItemName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please Enter Item Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }



            if (this.cmbCategory.SelectedIndex == 0)
            {
                MessageBox.Show("Please select Category.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            else if (this.txtPurchaseAccNo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please Enter Purchase Account.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPurchaseAccNo.Focus();
                return false;
            }
            else if (this.txtSaleAccNo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please Enter Sale Account.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSaleAccNo.Focus();
                return false;
            }
          
            else
                return true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPurchasePrice_Leave(object sender, EventArgs e)
        {
            //CalculateMargin(sender);
        }

        private void CalculateMargin(object sender)
        {
            try
            {
                //decimal purPrice = Convert.ToDecimal(this.txtPurchasePrice.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtPurchasePrice.Text.Trim()));
                //decimal salePrice = Convert.ToDecimal(this.txtSalePrice.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtSalePrice.Text.Trim()));
                //decimal marginPer= Convert.ToDecimal(this.txtMarginPer.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtMarginPer.Text.Trim()));
                //decimal marginAmt= Convert.ToDecimal(this.txtMarginAmt.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtMarginAmt.Text.Trim()));

               
               


                if (sender != null)
                {
                    if ((TextBox)sender == txtMarginPer)
                    {
                        txtMarginAmt.Text = (Convert.ToDecimal(this.txtMarginPer.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtMarginPer.Text.Trim()))  / Convert.ToDecimal(this.txtPurchasePrice.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtPurchasePrice.Text.Trim()) * 100)).ToString();
                    }
                    if ((TextBox)sender == txtMarginAmt)
                    {
                        txtMarginPer.Text = (Convert.ToDecimal(this.txtMarginAmt.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtMarginAmt.Text.Trim()) / Convert.ToDecimal(this.txtPurchasePrice.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtPurchasePrice.Text.Trim()) * 100)).ToString());
                    }
                }



            }
            catch (Exception)
            { }
           
        }

        private void txtMarginPer_Leave(object sender, EventArgs e)
        {
            if (txtMarginPer.Text.Trim().Length != 0 && txtMarginPer.Text!="0")
            {
                txtMarginAmt.Text = (Convert.ToDecimal(this.txtMarginPer.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtMarginPer.Text.Trim())) / 100 * Convert.ToDecimal(this.txtPurchasePrice.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtPurchasePrice.Text.Trim()))).ToString();
                txtSalePrice.Text = (Convert.ToDecimal(txtMarginAmt.Text.Trim()) + Convert.ToDecimal(this.txtPurchasePrice.Text.Trim())).ToString();
            }
        }

        private void txtMarginAmt_Leave(object sender, EventArgs e)
        {
            if (txtMarginAmt.Text.Trim().Length != 0 && txtMarginAmt.Text!="0")
            {
                txtMarginPer.Text = (Convert.ToDecimal(this.txtMarginAmt.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtMarginAmt.Text.Trim()) / Convert.ToDecimal(this.txtPurchasePrice.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtPurchasePrice.Text.Trim())) * 100).ToString());
                txtSalePrice.Text = (Convert.ToDecimal(txtMarginAmt.Text.Trim()) + Convert.ToDecimal(this.txtPurchasePrice.Text.Trim())).ToString();
            }
        }

        private void txtSalePrice_Leave(object sender, EventArgs e)
        {
            if (txtSalePrice.Text.Trim().Length != 0 && txtSalePrice.Text !="0")
            {
                decimal salePrice = Convert.ToDecimal(this.txtSalePrice.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtSalePrice.Text.Trim()));
                decimal purchasePrice = Convert.ToDecimal(this.txtPurchasePrice.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtPurchasePrice.Text.Trim()));
                txtMarginAmt.Text = (salePrice - purchasePrice).ToString();
                txtMarginPer.Text = ((salePrice - purchasePrice) / Convert.ToDecimal(this.txtPurchasePrice.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(txtPurchasePrice.Text.Trim())) * 100).ToString();
            }
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cmbDepartment_Leave(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = new CategoryController().GetSelectedCategories(Convert.ToInt32(cmbDepartment.SelectedValue));
                cmbCategory.DataSource = ds.Tables[0];
                cmbCategory.DisplayMember = "CategoryName";
                cmbCategory.ValueMember = "CategoryID";

            }
            catch (Exception ex)
            {

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you Want Delete this Item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                  
                    int itemid = Convert.ToInt32(txtItemID.Text);
                    
                  
                        if (new ItemController().DeleteItem(itemid))
                        {
                            MessageBox.Show("Item Delete Successfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearControls();
                        }
                        else
                            MessageBox.Show("Item Cannot be Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                   
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void cmbColor_Leave(object sender, EventArgs e)
        {
            SetName();
        }

        private void cmbSeasons_Leave(object sender, EventArgs e)
        {
            SetName();
        }

        private void btnVendor_Click(object sender, EventArgs e)
        {
            try
            {
                SchAccounts Sch = new SchAccounts();
                Sch.POS = "P";
                Sch.ShowDialog();
                if (Sch.SelectedAccount != null)
                {
                    txtVenorID.Text = Sch.SelectedAccount.AccountNo;
                    txtVendorName.Text = Sch.SelectedAccount.AccountName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void txtVenorID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtVendorName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSalePrice_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}

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
using Accounts;
using Microsoft.Reporting.WinForms;

namespace Restorant_Management_System.Forms
{
    public partial class frmDiscount : Form
    {
        string where = "";
        DiscountOffer offer;
        bool isNew = true;
        Branch b;
        List<Branch> branchlist = new List<Branch>();
        List<DiscountOffer> barcodeList = new List<DiscountOffer>();
        int departmentid = 0;
        public frmDiscount()
        {
            InitializeComponent();
        }

        private void frmDiscount_Load(object sender, EventArgs e)
        {
            try
            {
                
                if (!User._IsAdmin)
                {
                    CheckRights(Convert.ToInt16(this.Tag));
                }
                ClearControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmCurrentStock_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void LoadCategory()
        {
            try
            {
                List<Category> cats = new CategoryController().GetCategories(0);
                cats.RemoveAt(0);
                this.cmbCategory.DataSource = cats;
                this.cmbCategory.DisplayMember = "Name";
                this.cmbCategory.ValueMember = "Id";
              

              //  this.cmbCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
               // this.cmbCategory.AutoCompleteSource = AutoCompleteSource.ListItems;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmItem LoadCategory");
            }
        }
        private void LoadCompanyName(int cat)
        {
            try
            {
                this.cmbCompanyName.DataSource = new ItemController().GetCompanyNames(cat, true);

               // this.cmbCompanyName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //this.cmbCompanyName.AutoCompleteSource = AutoCompleteSource.ListItems;

                this.cmbCompanyName.SelectedIndex = -1;
                this.cmbCompanyName.Text = "";
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "FrmItem LoadCompanyName"); }
        }
        private void LoadProductName(string company)
        {
            try
            {
                this.cmbProductName.Text = "";
                this.cmbProductName.DataSource = new ItemController().GetProductNames(company, true);

               // this.cmbProductName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //this.cmbProductName.AutoCompleteSource = AutoCompleteSource.ListItems;

                this.cmbProductName.SelectedIndex = -1;
                this.cmbProductName.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmItem LoadProductName");
            }
        }
        private void LoadDesign(string product, string company)
        {
            try
            {
                this.cmbDesign.Text = "";
                this.cmbDesign.DataSource = new ItemController().GetDesigns(product, company, true);

              //  this.cmbDesign.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //this.cmbDesign.AutoCompleteSource = AutoCompleteSource.ListItems;

                this.cmbDesign.SelectedIndex = -1;
                this.cmbDesign.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmItem LoadDesign");
            }
        }
        private void LoadSize(string design, string product, string company)
        {
            try
            {
                this.cmbSize.Text = "";
                this.cmbSize.DataSource = new ItemController().GetSizes(design, product, company, true);

             //   this.cmbSize.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
               // this.cmbSize.AutoCompleteSource = AutoCompleteSource.ListItems;

                this.cmbSize.SelectedIndex = -1;
                this.cmbSize.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmItem LoadSizes");
            }
        }
        private void ClearControls()
        {
            try
            {
                LoadCategory();
                GetDepartments();

                SetCmbBoxs(" Select distinct(CompanyName) as Name from Item I where CategoryID="+Convert.ToInt32(cmbCategory.SelectedValue)+" ", ref cmbCompanyName);
                SetCmbBoxs(" Select distinct(ProductName) as Name from Item I ", ref cmbProductName);
                SetCmbBoxs(" Select distinct(Design) as Name from Item I ", ref cmbDesign);
                SetCmbBoxs(" Select distinct(Size) as Name from Item I ", ref cmbSize);

                this.txtItemID.Clear();
                this.txtBarCode.Clear();
                this.txtDiscount.Text = "";
                this.chkIsActive.Checked = true;
                this.cmbCategory.Focus();
                this.dtpFromDate.Value = DateTime.Now;
                this.dtpToDate.Value = DateTime.Now;
                txtOfferID.Text = new DiscountOfferController().GetMaxID();

                isNew = true;
                btnDelete.Enabled = false;

                branchlist=null;
                barcodeList = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmCurrentStock ClearControls()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool SetCmbBoxs(string Select, ref ComboBox cmb)
        {
            try
            {
                cmb.DataSource = null;
                List<string> names = new List<string>();
                names = new ItemController().GetNames(Select);
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
        private void GetDepartments()
        {
            DataSet ds = new DataSet();
            ds = new DepartmentController().LoadDepartment();
            cmbDepartment.DataSource = ds.Tables[0];
            cmbDepartment.DisplayMember = "DepartName";
            cmbDepartment.ValueMember = "DepartID";
            cmbDepartment.SelectedIndex = -1;
        }
        private void SetWhere()
        {
            try
            {
                where = "";

                if (this.cmbCategory.SelectedValue != null)
                {
                    if ((int)cmbCategory.SelectedValue > 0)
                    {
                        if (this.cmbCategory.Text.Trim().Length != 0)
                        {
                            where += " and IC.CategoryID=" + (this.cmbCategory.SelectedValue);
                        }
                    }
                }
                else
                    MessageBox.Show("Please Enter valid Category.", "Check Category...", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (cmbCompanyName.Text.Trim().Length != 0)
                {
                    where += " and I.CompanyName='" + this.cmbCompanyName.Text.Replace("'", "''") + "'";
                }
                if (cmbProductName.Text.Trim().Length != 0)
                {
                    where += " and I.ProductName='" + this.cmbProductName.Text.Replace("'", "''") + "'";
                }
                if (cmbDesign.Text.Trim().Length != 0)
                {
                    where += " and I.Design='" + this.cmbDesign.Text.Replace("'", "''") + "'";
                }
                if (cmbSize.Text.Trim().Length != 0)
                {
                    where += " and I.Size='" + this.cmbSize.Text.Replace("'", "''") + "'";
                }

                if (this.txtItemID.Text.Trim().Length != 0)
                {
                    where = " and I.ItemID=" + this.txtItemID.Text;
                }
                if (this.txtBarCode.Text.Trim().Length != 0)
                {
                    where = "and I.ItemID=(select itemid  from itembarcodes where barcode='" + this.txtBarCode.Text + "')";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmCurrentStock SetWhere", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidateControls()
        {
            try
            {
                if (Convert.ToInt32(this.cmbCategory.SelectedValue) == 0)
                {
                    MessageBox.Show("Please Choose some Category.", "Enter Category...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.cmbCategory.Focus();
                    return false;
                }
                else if (this.txtDiscount.Text.Trim().Length==0)
                {
                    MessageBox.Show("Please enter some discount", "Enter Discount...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtDiscount.Focus();
                    return false;
                }
                else  if (branchlist == null || branchlist.Count == 0)
                {
                    MessageBox.Show("Please select Branch", "Enter Branch...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtDiscount.Focus();
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

        private void cmbCategory_KeyDown(object sender, KeyEventArgs e)
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
                MessageBox.Show(ex.Message, "FrmCurrentStock cbxCategory_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (typeof(System.Int32) == cmbCategory.SelectedValue.GetType())
                {
                    if ((int)cmbCategory.SelectedValue >= 0)
                    {
                        LoadCompanyName((int)cmbCategory.SelectedValue);
                    }
                }
            }
            catch (Exception )
            {
                //MessageBox.Show(ex.Message, "FrmItem cbxCategory_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                ItemName itn = new ItemName(this.cmbCompanyName.Text.Trim().Replace("'", "''"), this.cmbProductName.Text.Trim().Replace("'", "''"), this.cmbDesign.Text.Trim().Replace("'", "''"), this.cmbSize.Text.Trim().Replace("'", "''"));
                Item i = new Item(0, itn);

                Category c = new Category(Convert.ToInt32(this.cmbCategory.SelectedValue), "");

                int offerID = 0;
                if (isNew == false)
                {
                    offerID = offer.OfferID;
                }
                 
                   DiscountOffer DO = new DiscountOffer(offerID, c, i,  Convert.ToDecimal((this.txtDiscount.Text.Trim().Length == 0 ? "0" : this.txtDiscount.Text.Trim())),  this.chkIsActive.Checked,this.dtpFromDate.Value,this.dtpToDate.Value,branchlist, barcodeList);

                if (new DiscountOfferController().CheckOffer(DO, isNew) == false)
                {
                    if (new DiscountOfferController().SaveOffer(DO,isNew))
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.offer != null)
            {
                if (new DiscountOfferController().DeleteOffer(offer.OfferID))
                {
                    MessageBox.Show("Offer has been deleted successfully.", "Deleted...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearControls();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Sch_Forms.SchDiscount frm = new Sch_Forms.SchDiscount();
            frm.IsCategoryDisc = true;
        //    frm.FormBorderStyle = FormBorderStyle.None;
            frm.ShowDialog();

            if (frm.ParaOutID != 0)
            {
                offer = new DiscountOfferController().GetOfferDetail(frm.ParaOutID,true);

                if (offer != null)
                {
                    this.cmbCategory.SelectedValue = offer.Category.Id;
                    txtOfferID.Text = offer.OfferID.ToString() ;
                    this.cmbCompanyName.Text = offer.Item.ItemName.CompanyName;
                    this.cmbProductName.Text = offer.Item.ItemName.ProductName;
                    this.cmbDesign.Text = offer.Item.ItemName.Design;
                    this.cmbSize.Text = offer.Item.ItemName.Size;

                    this.txtDiscount.Text = offer.Discount.ToString();
                    this.chkIsActive.Checked = offer.IsActive;
                    dtpFromDate.Value = offer.FromDate;
                    dtpToDate.Value = offer.ToDate;
                    branchlist = offer.branchList;
                    barcodeList = offer.barcodeList;
                    isNew = false;
                    btnDelete.Enabled = true;
                }
            }
        }

        private void cmbCompanyName_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void cmbDesign_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               LoadSize(this.cmbDesign.Text.Replace("'", "''"), this.cmbProductName.Text.Replace("'", "''"), this.cmbCompanyName.Text.Replace("'", "''"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmItem cbxDesign_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadDesign(this.cmbProductName.Text.Replace("'", "''"), this.cmbCompanyName.Text.Replace("'", "''"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmItem cbxProduct_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCategory_Leave(object sender, EventArgs e)
        {
            SetDeaprtment();
            // txtDepartment.Text = new CategoryControlle.ItemController().GetDapartment(Convert.ToInt32(cmbCategory.SelectedValue));
            SetBarcodes("  where i.CategoryID="+ Convert.ToInt32(cmbCategory.SelectedValue) + "  ");
        }

        private void SetBarcodes(string where)
        {
            DataSet ds1 = new DataSet();
            ds1 = new ItemController().GetBarcodes(where);
            cmbBarcode.DataSource = ds1.Tables[0];
            cmbBarcode.DisplayMember = "Barcode";
            cmbBarcode.ValueMember = "ItemID";
        }

        private void SetDeaprtment()
        {
            try
            {
                //txtItemName.Text = (cmbProductName.Text.Trim().Length == 0 ? "" : cmbProductName.Text.Trim() + "-") + (cmbDesign.Text.Trim().Length == 0 ? "" : cmbDesign.Text.Trim() + "-") + (cmbOrigin.Text.Trim().Length == 0 ? "" : cmbOrigin.Text.Trim() + "-") + (cmbCompanyName.Text.Trim().Length == 0 ? "" : cmbCompanyName.Text.Trim() + "-") + (cmbColor.Text.Trim().Length == 0 ? "" : cmbColor.Text.Trim());
                cmbDepartment.Text = new CategoryControlle.ItemController().GetDapartment(Convert.ToInt32(cmbCategory.SelectedValue));
                if (cmbDepartment.Text != "")
                {
                    departmentid = new CategoryControlle.ItemController().GetDapartmentid(cmbDepartment.Text);
                    cmbDepartment.SelectedValue = departmentid;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetName", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SchBranches_Click(object sender, EventArgs e)
        {
            try
            {
                Sch_Forms.SchBranch frm = new Sch_Forms.SchBranch();
                frm.IsBranchDisc = true;
                if (txtOfferID.Text.Trim().Length != 0)
                {
                    frm.OfferID = Convert.ToInt32(txtOfferID.Text.Trim());
                }
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                frm.ShowDialog();
               
                    branchlist = frm.selectedBranches;
              

             
              
                frm.Close();
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                SetBarcodes("  where i.DepartmentID="+ Convert.ToInt32(cmbDepartment.SelectedValue) + "  ");
               

            }
            catch (Exception ex)
            {

            }
        }

        private void cmbCompanyName_Leave(object sender, EventArgs e)
        {
            try
            {
                LoadProductName(this.cmbCompanyName.Text.Replace("'", "''"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " cbxCompany_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnApplyBarcode_Click(object sender, EventArgs e)
        {
            FrmBarcodeDiscount frm = new FrmBarcodeDiscount();           
            frm.ShowDialog();
          
        }

        private void BtnChooseExcel_Click(object sender, EventArgs e)
        {
            FrmExcelDiscount frm = new FrmExcelDiscount();
            frm.ShowDialog();
        }
    }
}

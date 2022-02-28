using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using CategoryControlle;
using Microsoft.Reporting.WinForms;
using System.IO;
using Accounts.SchForms;
using Accounts.Forms;

namespace Accounts
{
    public partial class FrmCurrentStoreStock : Form
    {
       
       
        private List<Item> items;
        List<ChartOfAccounts> vendors = new List<ChartOfAccounts>();
        Restorant_Management_System.Report_Forms.frmViewer frmViewer = new Restorant_Management_System.Report_Forms.frmViewer();
        public string ReportFor = "";
        Common.Data_Sets.DSGodownStock dsGodownStock = new Common.Data_Sets.DSGodownStock();
        Common.Data_Sets.DSCurrentStock dsCurrentStock = new Common.Data_Sets.DSCurrentStock();

        public string Type = "";
        string where = "";
        public FrmCurrentStoreStock()
        {
            InitializeComponent();
        }

        private void FrmCurrentStock_Load(object sender, EventArgs e)
        {
            try
            {
                ClearControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmCurrentStock_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                //If Barcode column is visible then pressing enter on grid will make downward move. Else Left to right.
                //Grid.MoveLeftToRight = !Globals.BarcodeColumnVisisble;

                DataGridViewCell TextCell = new DataGridViewTextBoxCell();
                DataGridViewCell DecimalQtyCell = new TNumEditDataGridViewCell(4);
                DataGridViewCell DecimalCell = new TNumEditDataGridViewCell(2);
                DataGridViewCell RateCell = new TNumEditDataGridViewCell(3);
                DataGridViewCell IntCell = new TNumEditDataGridViewCell(0);

                DataGridViewComboBoxColumn comboCol = new DataGridViewComboBoxColumn();
                DataGridViewCell ComboCell = new DataGridViewComboBoxCell();

                DataGridViewCheckBoxColumn Checkbox = new DataGridViewCheckBoxColumn();
                DataGridViewCell checkcell = new DataGridViewCheckBoxCell();


                DataGridViewComboBoxColumn comboCol2 = new DataGridViewComboBoxColumn();
                DataGridViewCell ComboCell2 = new DataGridViewComboBoxCell();

                DataGridViewComboBoxColumn comboCol3 = new DataGridViewComboBoxColumn();
                DataGridViewCell ComboCell3 = new DataGridViewComboBoxCell();

                //Col 1
                ////////////////////////////////////////////////////////////////////////////////////////////////// 

                DataGridViewColumn newCol = new DataGridViewColumn(); // add a column to the grid 

                //Col 1
                ////////////////////////////////////////////////////////////////////////////////////////////////// 

                newCol = new DataGridViewColumn();
                newCol.CellTemplate = TextCell;
                newCol.HeaderText = "Vendor ID";
                newCol.Name = "ID";
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.Width = 80;
                newCol.ReadOnly = true;

                Grd.Columns.Add(newCol);

                //Col 2
                ////////////////////////////////////////////////////////////////////////////////////////////////// 
                newCol = new DataGridViewColumn();
                newCol.CellTemplate = TextCell;
                newCol.HeaderText = "Vendor Name";
                newCol.Name = "Vendor";
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.Width = 300;
                newCol.ReadOnly = true;

                Grd.Columns.Add(newCol);

                ////////////////////////////////
                Checkbox = new DataGridViewCheckBoxColumn();
                Checkbox.CellTemplate = checkcell;
                Checkbox.HeaderText = "Select";
                Checkbox.Name = "Chkbox";
                Checkbox.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Checkbox.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Checkbox.Visible = true;
                Checkbox.Width = 50;
                Checkbox.ReadOnly = false;

                Grd.Columns.Add(Checkbox);

                AccountsGlobals.ExtendCol(ref Grd, "Vendor");

                return true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void LoadGodown()
        {
            try
            {
                this.cmbBranch.DataSource = new GodownController().GetGodown();
                this.cmbBranch.DisplayMember = "GodownName";
                this.cmbBranch.ValueMember = "GodownId";
              
                this.cmbBranch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmbBranch.AutoCompleteSource = AutoCompleteSource.ListItems;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmCurrentStock LoadCategory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateVendors()
        {
            try
            {
                List<ChartOfAccounts> accounts = new List<ChartOfAccounts>();
                accounts = new ChartofAccountsController().GetVendors();
                for (int i = 0; i < accounts.Count; i++)
                {
                    int rowindex = Grd.Rows.Add();
                    Grd.Rows[rowindex].Cells["ID"].Value = accounts[i].AccountNo;
                    Grd.Rows[rowindex].Cells["Vendor"].Value = accounts[i].AccountName;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "PopulateVendors()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadCategory()
        {
            try
            {
                this.cmbCategory.DataSource = new CategoryController().GetCategories();
                this.cmbCategory.DisplayMember = "Name";
                this.cmbCategory.ValueMember = "Id";

                this.cmbCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmbCategory.AutoCompleteSource = AutoCompleteSource.ListItems;

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

                this.cmbCompanyName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmbCompanyName.AutoCompleteSource = AutoCompleteSource.ListItems;

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
                //string where = "";
                //if (cmbCategory.SelectedValue != null)
                //{
                //    where = "   where C.CategoryID = " + cmbCategory.SelectedValue;
                //}
                //SetCmbBoxs(" Select distinct(ProductName) as Name from Item I inner Join ItemCategory C on I.CategoryID = C.CategoryID" + where /*  + " and CompanyName = '" + cmbCompanyName.Text.Trim() + "'" */, ref cmbProductName);
                //this.cmbProductName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //this.cmbProductName.AutoCompleteSource = AutoCompleteSource.ListItems;

               // cmbProductName.Text = "All";
                this.cmbProductName.DataSource = new ItemController().GetProductNames(cmbCategory.SelectedValue.ToString(), true);

                this.cmbProductName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmbProductName.AutoCompleteSource = AutoCompleteSource.ListItems;

                this.cmbProductName.SelectedIndex = -1;
                this.cmbProductName.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmItem LoadProductName");
            }
        }
        private bool SetCmbBoxs(string Select, ref ComboBox cmb)
        {
            try
            {
                cmb.DataSource = null;
                List<string> names = new List<string>();
                names = new ItemController().GetNames(Select);
                names.Add("All");
                cmb.DataSource = names;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadNames", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }




        private void LoadDesign(string product, string company)
        {
            try
            {
                SetCmbBoxs(" Select distinct(Design) as Name from Item I inner Join ItemCategory C on I.CategoryID = C.CategoryID" /* where C.CategoryID = " + cmbCategory.SelectedValue + " and CompanyName = '" + cmbCompanyName.Text.Trim() + "' and ProductName = '" + cmbProductName.Text.Trim() + "'" */, ref cmbDesign);

                this.cmbDesign.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmbDesign.AutoCompleteSource = AutoCompleteSource.ListItems;

                this.cmbDesign.SelectedIndex = -1;
                this.cmbDesign.Text = "";
                //this.cmbDesign.DataSource = new ItemController().GetDesigns(product, company, true);

                //this.cmbDesign.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //this.cmbDesign.AutoCompleteSource = AutoCompleteSource.ListItems;

                //this.cmbDesign.SelectedIndex = -1;
                //this.cmbDesign.Text = "";
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
                SetCmbBoxs(" Select distinct(Size) as Name from Item I inner Join ItemCategory C on I.CategoryID = C.CategoryID " /* where C.CategoryID = " + cmbCategory.SelectedValue + " and CompanyName = '" + cmbCompanyName.Text.Trim() + "' and ProductName = '" + cmbProductName.Text.Trim() + "' and Design = '" + cmbDesign.Text.Trim() + "'" */, ref cmbSize);

                this.cmbSize.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmbSize.AutoCompleteSource = AutoCompleteSource.ListItems;

                this.cmbSize.SelectedIndex = -1;
                this.cmbSize.Text = "";
                //this.cmbSize.DataSource = new ItemController().GetSizes(design, product, company, true);

                //this.cmbSize.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //this.cmbSize.AutoCompleteSource = AutoCompleteSource.ListItems;

                //this.cmbSize.SelectedIndex = -1;
                //this.cmbSize.Text = "";
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
                LoadGrid();
                PopulateVendors();
                LoadGodown();
                LoadCategory();
              //  LoadCompanyName(-1);
                LoadProductName("");
                LoadDesign("","");
                LoadSize("","","");

                this.txtItemID.Clear();
                this.txtBarCode.Clear();
                if (ReportFor == "CurrentStock")
                {
                    
                    LoadGrid();
                    PopulateVendors();
                }
                else if (ReportFor=="ItemShortKeys")
                {
                    grpParty.Visible = false;
                    grpStore.Visible = false;
                }
                else if(ReportFor == "MIS")
                {
                  
                    lblBranch.Visible = false;
                    cmbBranch.Visible = false;
                }
                else if (ReportFor == "Items")
                {
                 
                    lblBranch.Visible = false;
                    cmbBranch.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmCurrentStock ClearControls()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SetWhere()
        {
            try
            {
                where = " where 1=1 ";

                if (cmbBranch.SelectedIndex > -1)
                {
                    where += " and branchid="+Convert.ToInt32(cmbBranch.SelectedValue)+"";
                }
                

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
                MessageBox.Show(ex.Message, "FrmCurrentStock SetReport", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SetCTReport(string p)
        {
            try
            {

                Restorant_Management_System.Report_Forms.frmViewer frmViewer = new Restorant_Management_System.Report_Forms.frmViewer();
                Common.Data_Sets.DSStoreStockCT DSCT = new Common.Data_Sets.DSStoreStockCT();
                
                SetWhere();
                if (new StoreController().GetData(ref DSCT , where))
                {
                    if (DSCT.Tables["SPStoreStockCT"].Rows.Count > 0)
                    {
                        //this.Ncrp2.SetDataSource(DSCT);
                       // frmViewer.crystalReportViewer1.ReportSource = Ncrp2;
                        //frmViewer.crystalReportViewer1.RefreshReport();

                        if (p == "w")
                        {
                            frmViewer.Show();
                        }
                      //  else
                          //  frmViewer.crystalReportViewer1.PrintReport();
                    }
                    else
                    {
                        MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmCurrentStock SetReport", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
/*
        private void SetProfitLose(string p)
        {
            try
            {
                string username = User._UserName;

                Restorant_Management_System.Report_Forms.frmViewer frmViewer = new Restorant_Management_System.Report_Forms.frmViewer();
                dsProfitLose  = new Common.Data_Sets.DSProfitLose ();
                SetWhere();
                if (new ItemController ().GetProfitLose (ref dsProfitLose , where))
                {
                    if (dsProfitLose.Tables["SPProfitLose"].Rows.Count > 0)
                    {
                      //  crp2.SetDataSource(dsProfitLose );
                      //  crp2.SetParameterValue(0, username);
                       // frmViewer.crystalReportViewer1.ReportSource = crp2;
                        

                        if (p == "w")
                        {
                            frmViewer.Show();
                        }
                        //else
                        //    frmViewer.crystalReportViewer1.PrintReport();
                    }
                    else
                    {
                        MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmCurrentStock SetReport", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        */
        private void SetReport(string p)
        {
            try
            {
                dsGodownStock = new Common.Data_Sets.DSGodownStock();
                dsCurrentStock = new Common.Data_Sets.DSCurrentStock();
                SetWhere();
                Restorant_Management_System.Report_Forms.frmViewer frmViwer = new Restorant_Management_System.Report_Forms.frmViewer();
                DataTable dt = new DataTable();
                string category = cmbCategory.Text.Trim();
               
                if(Type == "CurrentStock")
                {
                   
                    if (new GodownStockController().GetData(ref dsGodownStock,  where))
                    {

                        if (dsGodownStock.Tables["GodownStock"].Rows.Count > 0)
                        {
                            dt = dsGodownStock.Tables["GodownStock"];
                            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                            frmViwer.reportViewer1.LocalReport.DataSources.Add(rds);
                           // frmViwer.reportViewer1.LocalReport.ReportPath = "../../Report/RptGodownStockrdlc.rdlc";
                            frmViwer.reportViewer1.LocalReport.ReportEmbeddedResource = "Restorant_Management_System.Report.RptCurrentStock.rdlc";
                            //ReportParameter[] rptParams = new ReportParameter[]
                            //         {
                            //            new ReportParameter("Category",category),
                            //            new ReportParameter("Branch",cmbBranch.Text.ToString()),
                            //        new ReportParameter("CurrentDate", System.DateTime.Now.Date.ToString("dd/MMM/yyyy")      ),
                            //        new ReportParameter("PrintedBy",User._UserName ),
                            //         };
                            //frmViwer.reportViewer1.LocalReport.SetParameters(rptParams);
                            
                            frmViwer.reportViewer1.LocalReport.Refresh();
                            frmViwer.ShowDialog();
                            
                           
                        }
                        else
                        {
                            MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    else
                    {
                        MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (Type == "CurrentStockWA")
                {

                    if (new GodownStockController().GetData(ref dsGodownStock, where))
                    {

                        if (dsGodownStock.Tables["GodownStock"].Rows.Count > 0)
                        {
                            dt = dsGodownStock.Tables["GodownStock"];
                            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                            frmViwer.reportViewer1.LocalReport.DataSources.Add(rds);
                         
                            frmViwer.reportViewer1.LocalReport.ReportEmbeddedResource = "Restorant_Management_System.Report.RptGodownStockrdlc.rdlc";
                            ReportParameter[] rptParams = new ReportParameter[]
                                     {
                                      
                                    new ReportParameter("CurrentDate", System.DateTime.Now.Date.ToString("dd/MMM/yyyy")      ),
                                    new ReportParameter("PrintedBy",User._UserName ),
                                     };
                            frmViwer.reportViewer1.LocalReport.SetParameters(rptParams);

                            frmViwer.reportViewer1.LocalReport.Refresh();
                            frmViwer.ShowDialog();


                        }
                        else
                        {
                            MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    else
                    {
                        MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (Type == "MIS")
                {
                    vendors.Clear();
                    if (!chkAllVendor.Checked)
                    {
                        FetchVendors();
                    }
                    string categoryid = null;
                    if (cmbCategory.SelectedIndex > 0)
                    {
                        categoryid = cmbCategory.SelectedValue.ToString();
                    }
                        
                    Common.Data_Sets.DSMIS dSMIS = new Common.Data_Sets.DSMIS();
                    if (new SaleInvoiceController().GetInventoryMIS(ref dSMIS, categoryid,vendors ))
                    {
                        if (dSMIS.Tables["SPInventoryMIS"].Rows.Count > 0)
                        {

                            ReportDataSource rds = new ReportDataSource("DataSet1", dSMIS.Tables["SPInventoryMIS"]);
                            frmViwer.reportViewer1.LocalReport.DataSources.Add(rds);
                            // frmViwer.reportViewer1.LocalReport.ReportPath = "../../Report/RptPurchaseRegister.rdlc";
                            frmViwer.reportViewer1.LocalReport.ReportPath = Globals.ReportPath + "/Report/RptMIS.rdlc";
                            ReportParameter[] rptParams = new ReportParameter[]
                                  {
                                        new ReportParameter("Category",category),
                                        new ReportParameter("PrintedBy",User._UserName  ),

                                  };
                            frmViwer.reportViewer1.LocalReport.SetParameters(rptParams);

                            frmViwer.ShowDialog();

                        }
                        else
                        {
                            MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (Type == "Items")
                {
                    string categoryid = null;
                    if (cmbCategory.SelectedIndex > 0)
                    {
                        categoryid = cmbCategory.SelectedValue.ToString();
                    }

                    Common.Data_Sets.DSItems dSItems = new Common.Data_Sets.DSItems();
                    if (new ItemController().GetItemsList(ref dSItems, categoryid))
                    {
                        if (dSItems.Tables["SPItems"].Rows.Count > 0)
                        {

                            ReportDataSource rds = new ReportDataSource("DataSet1", dSItems.Tables["SPItems"]);
                            frmViwer.reportViewer1.LocalReport.DataSources.Add(rds);
                            // frmViwer.reportViewer1.LocalReport.ReportPath = "../../Report/RptPurchaseRegister.rdlc";
                            frmViwer.reportViewer1.LocalReport.ReportPath = Globals.ReportPath + "/Report/RptItems.rdlc";
                            //ReportParameter[] rptParams = new ReportParameter[]
                            //      {
                            //            new ReportParameter("Category",category),

                            //      };
                            //frmViwer.reportViewer1.LocalReport.SetParameters(rptParams);

                            frmViwer.ShowDialog();

                        }
                        else
                        {
                            MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Data Found.", "No Data...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmCurrentStock SetReport", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FetchVendors()
        {

            for (int i = 0; i < Grd.Rows.Count - 1; i++)
            {
                if (Convert.ToBoolean(Grd.Rows[i].Cells["Chkbox"].Value) && Grd.Rows[i].Cells["ID"].Value.ToString().Trim().Length > 0)
                {
                    ChartOfAccounts v = new ChartOfAccounts();
                    v.AccountNo = Grd.Rows[i].Cells["ID"].Value.ToString();
                    v.AccountName = Grd.Rows[i].Cells["Vendor"].Value.ToString();
                    vendors.Add(v);
                }
            }
        }

        #region Other Controls Event Functions

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

                if (cmbCategory.SelectedIndex > -1)
                {
                    if (typeof(System.Int32) == cmbCategory.SelectedValue.GetType())
                    {
                        if ((int)cmbCategory.SelectedValue >= 0)
                        {
                            //LoadCompanyName((int)cmbCategory.SelectedValue);
                            LoadProductName("");
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmItem cbxCategory_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxCompanyName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //LoadProductName(  this.cmbCompanyName.Text.Replace ("'","''")) ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmItem cbxCompany_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //LoadDesign(this.cmbProductName.Text.Replace ("'","''") , this.cmbCompanyName.Text.Replace ("'","''"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmItem cbxProduct_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxDesign_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //LoadSize(this.cmbDesign.Text.Replace ("'","''") , this.cmbProductName.Text, this.cmbCompanyName.Text.Replace ("'","''") );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmItem cbxDesign_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        #endregion

        private void cbxGodown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tsbtnPreview_Click(object sender, EventArgs e)
        {
            SetReport("w");
        }

        private void stbtnPrint_Click(object sender, EventArgs e)
        {
            SetReport("p");
        }

        private void tsbtnClear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void tsbtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmCurrentStock_Fill_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            SetReport("w");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SetReport("p");
        }

        private void FrmCurrentStoreStock_Leave(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Restorant_Management_System;
using Accounts;
using Common;
using Accounts.Forms;
using FFMS.Forms;
using Restorant_Management_System.Report_Forms;
using CategoryControlle;
using Restorant_Management_System.Forms;

namespace Restorant_Management_System
{
    public partial class FrmMain : Form
    {

        public static Form ActiveForm = new Form();
        public string _departmentName="";
        
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
               
                this.ShowIcon = false;
                btnShowPnl.Visible = true;
                btnHidePnl.Visible = true;
                btnShowPnl.Visible = false;

                this.Text = _departmentName;
                #region Set Rights

                if (!User._IsAdmin)
                {
                    List<UserRight> right = new List<UserRight>();
                    List<UserRight> Dummyright = new List<UserRight>();
                    right = AccountsGlobals.UserRights;

                    foreach (TreeNode node in tV.Nodes)
                    {
                        if (node != null)
                        {
                            foreach (TreeNode child1 in node.Nodes)
                            {
                                foreach (TreeNode child in node.Nodes)
                                {
                                    if (child != null)
                                    {
                                        if ((child.Tag == null) || (child.Tag == ""))
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            bool CanAcess = false;
                                            right = AccountsGlobals.UserRights;
                                            var obj = Convert.ToInt32(child.Tag);
                                            for (int i = 0; i < right.Count; i++)
                                            {
                                                if (obj == Convert.ToInt16(right[i].ID))
                                                {
                                                    if (right[i].CanAccess == true)
                                                    {
                                                        CanAcess = true;
                                                        break;
                                                    }
                                                    else
                                                        CanAcess = false;
                                                }

                                            }
                                            if (CanAcess)
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                TreeNode tn1 = new TreeNode(node.Name);
                                                tV.Nodes[node.Index].Nodes[child.Index].Remove();
                                            }

                                        }
                                    }
                                }
                            }

                        }

                    }
                }
                #endregion
                #region DayCheck
              
              
                //DateTime dayStartTime = Convert.ToDateTime("05:00:00");
                //if(DateTime.Now.TimeOfDay > dayStartTime.TimeOfDay)
                //{
                //    StartDay();
                //}
              
                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmLogIn BtnLogIn_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void StartDay()
        {
            try
            {
                
                    if (new CommonController.DaySettingController().StartDay(Globals.BranchID))
                    {
                       
                        MessageBox.Show("Day Start Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    //else
                    //{
                    //    MessageBox.Show("Some Error Occoured on Starting Day", "StartDay", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmSettings StartDay", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ShowForms(Form frm)
        {
            try
            {
                frm.MdiParent = this;
                frm.Dock = DockStyle.Fill;
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                frm.Show();
               // LoadFormPictures(frm);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void LoadFormPictures(Form frm)
        {
            try
            {
                if (frm != null)
                {
                    string PicName = frm.Name;
                    pkbFormName.Image = Image.FromFile(Application.StartupPath + "\\Images\\" + PicName + ".png");
                }
                else
                {
                    pkbFormName.Image = null;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        private void cmbControls_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (cmbControls.SelectedItem == frm.Name)
                {
                    if (frm.Name != "FrmMain" || frm.Name!="FrmLogin")
                    {
                        frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                        frm.Activate();
                        lblHeading.Text = frm.Text;
                       // LoadFormPictures(frm);
                        break;
                    }
                }

            }
        }
        private void cmbControls_Click(object sender, EventArgs e)
        {
            LoadForms();
        }
        void LoadForms()
        {
            try
            {
                cmbControls.Items.Clear();
                foreach (Form frm in Application.OpenForms)
                {
                    for (int i = 0; i < cmbControls.Items.Count; i++)
                    {
                        if (cmbControls.Items[i].ToString() == frm.Name)
                        {
                            if (frm.Name != "FrmMain" || frm.Name !="FrmLogin")
                            {
                                cmbControls.Items.RemoveAt(i);
                            }
                            break;
                        }
                    }
                    if (frm.Name != "FrmMain" && frm.Name !="FrmLogin")
                    {
                        cmbControls.Items.Add(frm.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void ClosAllChildForms()
        {
            try
            {
                foreach (Form frm in this.MdiChildren)
                {
                    if (frm != Parent)
                    {
                        frm.Close();
                    }
                }
                pkbFormName.Image = null;
                LoadForms();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClosAllChildForms();
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                //ItemsReport StcokDifferenceReport   
                if (e.Node.Name == "DiscountPassword")
                {
                    FrmDiscountPassword frm = new FrmDiscountPassword();
                    lblHeading.Text = "Discount Password";

                    ShowForms(frm);
                }
                if (e.Node.Name == "PointsOpeningStock")
                {
                    FrmPartywiseOpeningStock frm = new FrmPartywiseOpeningStock();
                    lblHeading.Text = "Points Opening Stock";

                    ShowForms(frm);
                }
                if (e.Node.Name == "CityCreation")
                {
                    FrmCity frm = new FrmCity();
                    lblHeading.Text = "City Creation";

                    ShowForms(frm);
                }
                if (e.Node.Name == "ReceipeProduction")//
                {
                    FrmRecipieProduction frm = new FrmRecipieProduction();
                    lblHeading.Text = "Receipe Production";

                    ShowForms(frm);
                }
                if (e.Node.Name == "MCategoryRelationship")//MCategoryRelationship
                {
                    FrmCategoryPartyRelation frm = new FrmCategoryPartyRelation();
                    lblHeading.Text = "Menu Category Relationship";

                    ShowForms(frm);
                }
                if (e.Node.Name == "SaleInvoiceBakery")
                {
                    FrmSaleInvoiceBakery frm = new FrmSaleInvoiceBakery();
                    lblHeading.Text = "Sale Invoice";

                    ShowForms(frm);
                }
                if (e.Node.Name == "Receipe")//
                {
                    FrmMenuReceipe frm = new FrmMenuReceipe();
                    lblHeading.Text = "Receipe";
                   
                    ShowForms(frm);
                }
                if (e.Node.Name == "MenuReceipe")//MenuReceipe
                {
                    FrmReceipe frm = new FrmReceipe();
                    lblHeading.Text = "Menu Receipe";

                    ShowForms(frm);
                }
                if (e.Node.Name == "ItemsReport")
                {
                    FrmCurrentStoreStock frm = new FrmCurrentStoreStock();
                    lblHeading.Text = "Items Report";
                    frm.ReportFor = "Items";
                    frm.Type = "Items";
                    ShowForms(frm);
                }             
                if (e.Node.Name == "ItemsDiscount")
                {
                    FrmBarcodeDiscount frm = new FrmBarcodeDiscount();
                    lblHeading.Text = "Items Discount";
                  
                    ShowForms(frm);
                }
                if (e.Node.Name == "UserPettyCash")
                {
                    Forms.FrmPettyCash frm = new Forms.FrmPettyCash();
                    lblHeading.Text = "Shift Closing";
                    ShowForms(frm);
                }
                if (e.Node.Name == "Department")
                {
                    Forms.frmDepartment frm = new Forms.frmDepartment();
                    lblHeading.Text = "Department";
                    ShowForms(frm);
                }
                else if (e.Node.Name == "ItemCategory")
                {
                    FrmCategory frm = new FrmCategory();
                    lblHeading.Text = "Item Category";
                    ShowForms(frm);
                }            
                else if (e.Node.Name == "Vouchers")
                {
                    Forms.FrmVoucher frm = new Forms.FrmVoucher();
                    lblHeading.Text = "Vouchers";
                    ShowForms(frm);
                }
                else if (e.Node.Name == "ChangeUser")
                {
                    Forms.FrmChangeusers frm = new Forms.FrmChangeusers();
                    lblHeading.Text = "Change User";
                    ShowForms(frm);
                }                  
                else if (e.Node.Name == "Item")
                {
                    FrmItem frm = new FrmItem();
                    lblHeading.Text = "Item";
                    ShowForms(frm);
                }            
                else if (e.Node.Name == "PurchaseInvoice")
                {
                    Forms.frmPurchaseInvoice frm = new Forms.frmPurchaseInvoice();
                    lblHeading.Text = "Purchase Invoice";
                    ShowForms(frm);

                   
                }
                else if (e.Node.Name == "SaleInvoice")
                {
                    Forms.frmSaleInvoice frm = new Forms.frmSaleInvoice();
                    lblHeading.Text = "Issue Invoice";
                    ShowForms(frm);
                }
                else if (e.Node.Name == "StockAdjustment")
                {
                    Forms.frmStockAdj frm = new Forms.frmStockAdj();
                    lblHeading.Text = "Stock Adjustment";
                    ShowForms(frm);
                }
                else if (e.Node.Name == "ActiveDeActiveItem")
                {
                    Forms.frmAcDaItems frm = new Forms.frmAcDaItems();
                    lblHeading.Text = "Active DeActive Item";
                    ShowForms(frm);
                }              
                else if (e.Node.Name == "WastageInvoice")
                {
                    Forms.frmWastageInvoice frm = new Forms.frmWastageInvoice();
                    lblHeading.Text = "Wastage Invoice";
                    ShowForms(frm);
                }
                else if (e.Node.Name == "Summary") 
                {
                    Forms.frmSummary frm = new Forms.frmSummary();
                    lblHeading.Text = "Summary";
                    ShowForms(frm);
                }
                else if (e.Node.Name == "CurrentGoDownStock") 
                {
                    FrmCurrentStoreStock frm = new FrmCurrentStoreStock();
                    lblHeading.Text = "Current GoDown Stock";
                    frm.ReportFor = "CurrentGoDownStock";
                    ShowForms(frm);
                }
                else if (e.Node.Name == "DeliveryChallan")
                {
                    Forms.FrmChallan frm = new Forms.FrmChallan();
                    lblHeading.Text = "Delivery Challan";
                    ShowForms(frm);
                }
                else if (e.Node.Name == "Challan")
                {
                    Forms.FrmDeliveryChallan frm = new Forms.FrmDeliveryChallan();
                    lblHeading.Text = "Challan";
                    ShowForms(frm);
                }
                else if (e.Node.Name == "StockAdjustments")
                {
                    Report_Forms.frmStockAdjRpt frm = new Report_Forms.frmStockAdjRpt();
                    lblHeading.Text = "Stock Adjustments";
                    ShowForms(frm);
                }
                else if (e.Node.Name == "PurchaseRegister")
                {
                    Report_Forms.frmRegisterInvoice frm = new Report_Forms.frmRegisterInvoice();
                    frm.type = "PurchaseRegister";
                    lblHeading.Text = "Purchase Register";
                    ShowForms(frm);
                }
                else if (e.Node.Name == "PurchaseReturnRegister")
                {
                    Report_Forms.frmRegisterInvoice frm = new Report_Forms.frmRegisterInvoice();
                    lblHeading.Text = "Purchase Return Register";
                    frm.type = "PurchaseReturnRegister";
                    ShowForms(frm);
                    //
                }
                else if (e.Node.Name == "SaleReturnRegister")
                {
                    Report_Forms.frmRegisterInvoice frm = new Report_Forms.frmRegisterInvoice();
                    lblHeading.Text = "Sale Return Register";
                    frm.type = "SaleReturnRegister";
                    ShowForms(frm);
                    //
                }
                else if (e.Node.Name == "VendorWInventory")
                {
                    Report_Forms.frmRegisterInvoice frm = new Report_Forms.frmRegisterInvoice();
                    lblHeading.Text = "Vendors Wise Inventory";
                    frm.type = "VendorWInventory";
                    ShowForms(frm);
                 
                }
                else if (e.Node.Name == "SaleRegister")
                {
                    Report_Forms.frmRegisterInvoice frm = new Report_Forms.frmRegisterInvoice();
                    lblHeading.Text = "Sale Register";
                    frm.type = "SaleRegister";
                    frm.isPending = false;
                    ShowForms(frm);
                }
                else if (e.Node.Name == "WholesaleRegister")
                {
                    Report_Forms.frmRegisterInvoice frm = new Report_Forms.frmRegisterInvoice();
                    lblHeading.Text = "Wholesale Register";
                    frm.type = "WholesaleRegister";
                    frm.isPending = false;
                    ShowForms(frm);
                }                      
               
                else if (e.Node.Name == "ItemLedgerBranch")
                {
                    Report_Forms.frmStockAdjRpt frm = new Report_Forms.frmStockAdjRpt();
                    lblHeading.Text = "Item Ledger Branch";
                    frm.LedgerType = "Branch";
                    frm.IsItemLedger = true;
                
                    
                    ShowForms(frm);
                }
                else if (e.Node.Name == "ItemLedger")
                {
                    Report_Forms.frmStockAdjRpt frm = new Report_Forms.frmStockAdjRpt();
                    lblHeading.Text = "Item Ledger";
                    frm.IsItemLedger = true;
                 
                    ShowForms(frm);
                }
               
                else if (e.Node.Name == "DailyActivity")
                {
                    Report_Forms.frmDailyActivity frm = new Report_Forms.frmDailyActivity();
                    lblHeading.Text = "Daily Activity";
                    frm.type = "DA";
                    ShowForms(frm);
                }
                else if (e.Node.Name == "ShopCashCounterSummary")
                {
                    Report_Forms.frmDailyActivity frm = new Report_Forms.frmDailyActivity();
                    lblHeading.Text = "Shop Cash Counter Summary";
                    frm.type = "SCCS";
                    ShowForms(frm);
                }
                
                else if (e.Node.Name == "ChartOfAccounts")
                {
                    FrmChartofAccounts frm = new FrmChartofAccounts();
                    lblHeading.Text = "Chart Of Accounts";
                    ShowForms(frm);
                }
                else if (e.Node.Name == "OpeningBalances")
                {
                    FrmOpeningBalances frm = new FrmOpeningBalances();
                    lblHeading.Text = "Opening Balances";
                    ShowForms(frm);
                }
                else if (e.Node.Name == "City")
                {
                    FrmCity frm = new FrmCity();
                    lblHeading.Text = "City";
                    ShowForms(frm);
                }
                else if (e.Node.Name == "FixAccounts")
                {
                    FrmFixedAccounts frm = new FrmFixedAccounts();
                    lblHeading.Text = "Fixed Accounts";
                    ShowForms(frm);
                }
                else if (e.Node.Name == "CloseMonth")
                {
                    FrmMonthClose frm = new FrmMonthClose();
                    lblHeading.Text = "Close Month";
                    ShowForms(frm);
                }              
                else if (e.Node.Name == "AccountLedger")
                {
                    FrmAccountLedger frm = new FrmAccountLedger();
                    lblHeading.Text = "Account Ledger";
                   // frm.lblName.Text = "Account Ledger";
                    ShowForms(frm);
                }
                else if (e.Node.Name == "CashBook")
                {
                    FrmCahBook frm = new FrmCahBook();
                    lblHeading.Text = "Cash Book";
                    frm.isCashBook = true;
                  //  frm.lblName.Text = "Cash Book";
                    ShowForms(frm);
                }
                else if (e.Node.Name == "GeneralJournal")
                {
                    FrmCahBook frm = new FrmCahBook();
                    lblHeading.Text = "General Journal";
                    frm.isGeneral = true;
                   // frm.lblName.Text = "General Journal";
                    ShowForms(frm);
                }            
                else if (e.Node.Name == "TrailBalance")
                {
                    FrmCahBook frm = new FrmCahBook();
                    lblHeading.Text = "Trail Balance";
                    frm.isTrial = true;
                   // frm.lblName.Text = "Trail Balance";
                    ShowForms(frm);
                }
                else if (e.Node.Name == "IncomeStatement")
                {
                    FrmCahBook frm = new FrmCahBook();
                    lblHeading.Text = "Income Statement";
                    frm.isIncome = true;
                  //  frm.lblName.Text = "Income Statement";
                    ShowForms(frm);
                }
                else if (e.Node.Name == "AccountsPayable")
                {
                    FrmCahBook frm = new FrmCahBook();
                    lblHeading.Text = "Accounts Payable";
                    frm.isPay = true;
                    //frm.lblName.Text = "Accounts Payable";
                    ShowForms(frm);
                }
                else if (e.Node.Name == "AccountsReceiveable") 
                {
                    FrmCahBook frm = new FrmCahBook();
                    lblHeading.Text = "Accounts Receiveable";
                    //frm.lblName.Text = "Accounts Receiveable";
                    frm.isRec = true;
                    ShowForms(frm);
                    
                }
               
                else if (e.Node.Name == "Branch")
                {
                    Forms.FrmBranch frm = new Forms.FrmBranch();
                    lblHeading.Text = "Branch";
                    ShowForms(frm);
                }
                else if (e.Node.Name == "Users")
                {
                    FrmUsers frm = new FrmUsers();
                    lblHeading.Text = "Users";
                    ShowForms(frm);
                }
                else if (e.Node.Name == "CurrentStock")
                {
                   FrmCurrentStoreStock frm = new FrmCurrentStoreStock();
                    lblHeading.Text = "Current Stock";
                    frm.ReportFor = "CurrentStock";//
                    frm.Type= "CurrentStock";
                    ShowForms(frm);
                }
                else if (e.Node.Name == "CurrentStockWA")
                {
                    FrmCurrentStoreStock frm = new FrmCurrentStoreStock();
                    lblHeading.Text = "Current Stock with Amount";
                    frm.ReportFor = "CurrentStockWA";//CurrentStockBW
                    frm.Type = "CurrentStockWA";
                    ShowForms(frm);
                }
                else if (e.Node.Name == "Configuration")
                {
                    FrmDaySettings frm = new FrmDaySettings();
                    lblHeading.Text = "Configuration";

                    ShowForms(frm);
                }               
                else if (e.Node.Name == "ClaimInvoice")
                {
                    frmClaimInvoice frm = new frmClaimInvoice();
                    lblHeading.Text = "Claim Invoice";

                    ShowForms(frm);
                }
                else if (e.Node.Name == "CCSaleSummary")
                {
                    frmValuationSale frm = new frmValuationSale();
                    lblHeading.Text = "Credit Card Sale Summary";
                    frm.Text = "Credit Card Sale Summary";
                    frm.ValuationType = "CCSaleSummary";

                    ShowForms(frm);
                }
                else if (e.Node.Name == "ValuationSaleReport")
                {
                    frmValuationSale frm = new frmValuationSale();
                    lblHeading.Text = "Valuation Sale Report";
                    frm.Text= "Valuation Sale Report";
                    frm.ValuationType = "Sale";

                    ShowForms(frm);
                }
                else if (e.Node.Name == "InventoryValuation")
                {
                    frmValuationSale frm = new frmValuationSale();
                    lblHeading.Text = "Inventory Valuation";
                    frm.Text = "Inventory Valuation";
                    frm.ValuationType = "Inventory";

                    ShowForms(frm);
                }
              
                else if (e.Node.Name == "MISReport")
                {

                    FrmCurrentStoreStock frm = new FrmCurrentStoreStock();
                    lblHeading.Text = "Miscellaneous Report";
                    frm.ReportFor = "MIS";
                    frm.Type = "MIS";
                    ShowForms(frm);
                    //DiscountOffers

                }
             
                else if (e.Node.Name == "DeliveryChallanRegister")
                {
                    Report_Forms.frmRegisterInvoice frm = new Report_Forms.frmRegisterInvoice();
                    lblHeading.Text = "Delivery Challan Register";
                    frm.type = "ChallanRegister";
                    frm.Text = "Delivery Challan Register";
                    frm.isReceivedChallan = false;
                    ShowForms(frm);
                }
                else if (e.Node.Name == "ReceivedChallanRegister")
                {
                    Report_Forms.frmRegisterInvoice frm = new Report_Forms.frmRegisterInvoice();
                    lblHeading.Text = "Received Challan Register";
                    frm.type = "ChallanRegister";
                    frm.Text = "Received Challan Register";
                    frm.isReceivedChallan = true;
                    ShowForms(frm);
                }
                //DeliveryChallanRegister
                #region comments
                /*  MISReport  else if (e.Node.Name == "ActiveDeActiveItem")ValuationSaleReport
                    {
                        DataTable dt = new CommonController.MenusController().GetMenuListReport();
                        decimal paidAmt = 0;
                        Report_Forms.frmViewer Viewer = new Report_Forms.frmViewer();

                        Viewer.reportViewer1.Reset();

                        if (dt.Rows.Count > 0)
                        {
                            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                            Viewer.reportViewer1.LocalReport.DataSources.Add(rds);
                            Viewer.reportViewer1.LocalReport.ReportPath = "Report/RptMenuList.rdlc";
                          //  Viewer.reportViewer1.LocalReport.ReportPath = "../../Report/RptMenuList.rdlc";
                           // Viewer.reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\Report\\.RptMenuList.rdlc";
                            ReportParameter[] rptParams = new ReportParameter[]
                                {
                                new ReportParameter("UserName","admin"),
                                };
                            Viewer.reportViewer1.LocalReport.SetParameters(rptParams);


                            Viewer.reportViewer1.LocalReport.Refresh();
                            ShowForms(Viewer);
                            //Viewer.Show();
                        }
                    }
                    else if (e.Node.Name == "DailySalesAnd Receipts")
                    {
                        Report_Forms.frmRptOrderSummery frm = new Report_Forms.frmRptOrderSummery();
                        frm.OrderSummeryType = "DailySalesAndReceipts";
                        ShowForms(frm);
                    }
                    else if(e.Node.Name== "MonthlySalesAndReciepts")
                    {
                        Report_Forms.frmRptOrderSummery frm = new Report_Forms.frmRptOrderSummery();
                        frm.OrderSummeryType = "MonthlySalesAndReciepts";
                        ShowForms(frm);
                    }

                    else if (e.Node.Name == "KitchenExecution")
                    {
                        Forms.frmKitchenExecution frm = new Forms.frmKitchenExecution();
                        frm.FormBorderStyle = FormBorderStyle.None;
                        frm.ShowDialog();
                        // ShowForms(frm);
                    }
                    else if (e.Node.Name == "OrderDetail")
                    {
                        Report_Forms.frmOrderDetail frm = new Report_Forms.frmOrderDetail();
                        ShowForms(frm);
                    }
                    else if(e.Node.Name== "MenuSaleSummary")
                    {
                        Report_Forms.frmMenuWiseSaleReport frm = new Report_Forms.frmMenuWiseSaleReport();
                        ShowForms(frm);
                    }
                    else if (e.Node.Name == "DeletionAuditTrail")
                    {
                        Report_Forms.frmRptOrderSummery frm = new Report_Forms.frmRptOrderSummery();
                        frm.OrderSummeryType = "DeletionAuditTrail";
                        ShowForms(frm);
                    }
                    else if(e.Node.Name== "CustomerPhoneBook")
                    {
                        Report_Forms.frmRptOrderSummery frm = new Report_Forms.frmRptOrderSummery();
                        frm.OrderSummeryType = "CustomerPhoneBook";
                        ShowForms(frm);
                    }
                    else if(e.Node.Name== "MenuAuditTrail")
                    {
                        Report_Forms.frmMenuAuditTrail frm = new Report_Forms.frmMenuAuditTrail();
                        ShowForms(frm);
                    }
                    else if(e.Node.Name== "DailySaleSummary")
                    {
                        Report_Forms.frmRptOrderSummery frm = new Report_Forms.frmRptOrderSummery();
                        frm.OrderSummeryType = "DailySaleSummary";
                        ShowForms(frm);
                    }
                    else if(e.Node.Name=="Rights")
                    {
                        Forms.frmRights frm = new Forms.frmRights();
                        ShowForms(frm);
                    }
                    */
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            CloseActiveForm();
        }
       private void CloseActiveForm()
        {
            try
            {
                if (Application.OpenForms.Count > 2)
                {
                    ActiveMdiChild.Close();
                }
               // LoadFormPictures(ActiveMdiChild);
                LoadForms();
               
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void btnHalfPnl_Click(object sender, EventArgs e)
        {
            PnlLeft.Visible = false;
            btnShowPnl.Visible = true;
            btnHidePnl.Visible = false;
            ActiveForm = ActiveMdiChild;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PnlLeft.Visible = true;
            btnHidePnl.Visible = true;
            btnShowPnl.Visible = false;
            if (ActiveForm != null)
            {
                ActiveForm.Activate();
            }
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        { 
           
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}


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
using Accounts.Forms;
using Common;
using CategoryControlle;
using Microsoft.Reporting.WinForms;
using System.IO;

namespace Restorant_Management_System.Forms
{
    public partial class FrmChallan : Form
    {
        private bool Isnew = true;
        Challan ch = new Challan();
        private Challan purchase;
        public List<Challan> PurchaseLines;
        private ChallanController pc = new ChallanController();
        public List<ChartOfAccounts> CourierAccounts;
        public FrmChallan()
        {
            InitializeComponent();
        }

        private void FrmChallan_Load(object sender, EventArgs e)
        {

            ClearControl();
            if (!User._IsAdmin)
            {
                CheckRights(Convert.ToInt16(this.Tag));
                dtpFromDate.Enabled = AccountsGlobals.UserRights[AccountsGlobals.DateRights].CanAccess;
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
                        //btnDelete.Enabled = right[i].CanDelete;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex + "", "CheckRights", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadCategories", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void ClearControl()
        {
            txtUserName.Text = User._UserName;
            this.txtID.Text = pc.GetMaximumID().ToString();
            txtRemarks.Clear();
            LoadBranchSender();
            LoadBranchReciver();
            txtTrackingID.Clear();
            //LoadCourierAcc();
            LoadGrid();
            //LoadCounters();
            Isnew = true;
            dtpFromDate.Value = AccountsGlobals.ServerDate;    
        }
        private void LoadCourierAcc()
        {
            CourierAccounts = new ChartofAccountsController().GetCourierAccounts();
            cmbCourier.DataSource = CourierAccounts;
            cmbCourier.DisplayMember = "AccountName";
            cmbCourier.ValueMember = "AccountNo";
            cmbCourier.SelectedIndex = -1;
        }
        private bool LoadBranchSender()
        {
            try
            {

                List<Branch> counters = new BranchController().GetBranch(" where 1=1 ");
                cmbSenderBranch.DataSource = counters;
                cmbSenderBranch.ValueMember = "ID";
                cmbSenderBranch.DisplayMember = "BranchName";
                if (!User._IsAdmin)
                {
                    cmbSenderBranch.SelectedValue = Globals.BranchID;
                    cmbSenderBranch.Enabled = false;  
                }
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadCategories", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                newCol.Width = 120;
                Grd.Columns.Add(newCol);



               
                //Col 2
                //////////////////////////////////////////////////////////////////////////////////////////////////                
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Item ID";
                newCol.Name = "ItemID";

                newCol.CellTemplate = IntCell;

                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = false;
                // newCol.Visible = Globals.PackingColumnVisible;
                newCol.Width = 70;
                Grd.Columns.Add(newCol);


                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Item Name";
                newCol.Name = "Item";

                newCol.CellTemplate = TextCell;

                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;
                //  newCol.Visible = Globals.PackingColumnVisible;
                newCol.Width = 250;
                Grd.Columns.Add(newCol);

                //Col 4
                //////////////////////////////////////////////////////////////////////////////////////////////////                
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Stock";
                newCol.Name = "Stock";
                newCol.CellTemplate = DecimalCell;//RateCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.ReadOnly = true;
                newCol.Width = 90;
                Grd.Columns.Add(newCol);


                //// To avoid all the annoying error messages, handle the DataError event of the DataGridView:
                //Grd.DataError += new DataGridViewDataErrorEventHandler(Grd_DataError); 

                //Col 3
                //////////////////////////////////////////////////////////////////////////////////////////////////               
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Quantity";
                newCol.Name = "Quantity";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.Width = 90;
                Grd.Columns.Add(newCol);

                //Col 3
                //////////////////////////////////////////////////////////////////////////////////////////////////               
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Rate";
                newCol.Name = "Rate";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true  ;
                newCol.Width = 90;
                Grd.Columns.Add(newCol);

                ///Adding Cost column
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Cost";
                newCol.Name = "Cost";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true ;
                newCol.Width = 90;
                Grd.Columns.Add(newCol);

                ///Adding Total column
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Total";
                newCol.Name = "Total";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.Width = 100;
                Grd.Columns.Add(newCol);
                //Col 7
                //////////////////////////////////////////////////////////////////////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "SrNo";
                newCol.Name = "SrNo";
                newCol.CellTemplate = IntCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
                /////////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "IsReceived";
                newCol.Name = "IsReceived";
                newCol.CellTemplate = IntCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = false;
                newCol.Width = 70;
                Grd.Columns.Add(newCol);
                /////////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "IsTransition";
                newCol.Name = "IsTransition";
                newCol.CellTemplate = IntCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = false;
                newCol.Width = 70;
                Grd.Columns.Add(newCol);

                AccountsGlobals.ExtendCol(ref Grd, "Item");





                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool LoadBranchReciver()
        {
            try
            {
                
                List<Branch> counters = new BranchController().GetBranch(" where 1=1  " );
                cmbBranch.DataSource = counters;
                cmbBranch.ValueMember = "ID";
                cmbBranch.DisplayMember = "BranchName";

                cmbBranch.SelectedIndex = -1;


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadCategories", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearControl();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControl();
        }
        private bool ValidateControl()
        {
            try
            {
                int rowIndex = Grd.CurrentRow.Index;
                int colIndex = Grd.CurrentCell.ColumnIndex;

                for (int i = 0; i < Grd.Rows.Count - 1; i++)
                {
                    if (Convert.ToDecimal(Grd.Rows[i].Cells["Quantity"].Value) == 0 && Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value) > 0 && Grd.Rows[i].Visible==true)
                    {
                        MessageBox.Show("Add Some Quantity.", "Check Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }


                if (this.cmbBranch.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Please Select Receiver Branch First", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbBranch.Focus();
                    return false;
                }
                if (this.cmbSenderBranch.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Please Select Sender Branch First", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSenderBranch.Focus();
                    return false;
                }

                if (Convert.ToInt32(cmbSenderBranch.SelectedValue) == Convert.ToInt32(cmbBranch.SelectedValue))
                {
                    MessageBox.Show("Don't Select Same Branches.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSenderBranch.Focus();
                    return false;
                }
                else if (cmbCourier.Text.Trim().Length > 0)
                {
                    if (this.txtTrackingID.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Please Enter Tracking ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtTrackingID.Focus();
                        return false;
                    }
                    

                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ValidateControls", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool AddData()
        {
            try
            {
                ch.ID = Convert.ToInt32(txtID.Text.ToString().Trim().Length == 0 ? "0" : txtID.Text.ToString());

                ch.FromDate = this.dtpFromDate.Value.Date;
                ch.ToDate = this.dtpToDate.Value.Date;
                ch.BranchID = Convert.ToInt32(cmbBranch.SelectedValue);
                ch.EntryBranchID = Convert.ToInt32(this.cmbSenderBranch.SelectedValue);
                ch.Remarks = txtRemarks.Text.Trim();
                ch.CounterID = Convert.ToInt32(this.cmbCounter.SelectedValue);
                ch.CourierAccount = Convert.ToString((cmbCourier.SelectedValue) == null ? "" : cmbCourier.SelectedValue);
                ch.TrackingID = txtTrackingID.Text.Trim();
                //AddData

                PurchaseLines = new List<Challan>();
                for (int i = 0; i < Grd.Rows.Count; i++)
                {
                    if (Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value) != 0)
                    {
                      
                        Common.Challan Obj = new Common.Challan();
                        Obj.ItemID = Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value);
                        Obj.Barcode = Convert.ToString(Grd.Rows[i].Cells["Barcode"].Value);
                        Obj.ItemName = Grd.Rows[i].Cells["Item"].Value.ToString();
                        Obj.serialno = Convert.ToInt32(Grd.Rows[i].Cells["SrNo"].Value);
                        Obj.Quantity = Convert.ToDecimal(Grd.Rows[i].Cells["Quantity"].Value);
                        Obj.Purate = Convert.ToDecimal(Grd.Rows[i].Cells["Rate"].Value);
                        Obj.Cost = Convert.ToDecimal(Grd.Rows[i].Cells["Cost"].Value);
                        Obj.BranchID = Convert.ToInt32(cmbBranch.SelectedValue);
                        Obj.IsDeleted = Convert.ToBoolean(Grd.Rows[i].Cells["IsDeleted"].Value);
                        Obj.IsReceived = Convert.ToBoolean(Grd.Rows[i].Cells["IsReceived"].Value);
                        Obj.IsTarnsition = Convert.ToBoolean(Grd.Rows[i].Cells["IsTransition"].Value);
                        Obj.EntryBranchID = Convert.ToInt32(cmbSenderBranch.SelectedValue);
                        Obj.CounterID = Convert.ToInt32(this.cmbCounter.SelectedValue);
                        PurchaseLines.Add(Obj);

                        }
                }
                ch.ChallanLines = PurchaseLines;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
       // int BranchID = new UserController().GetBranchID(User.UserNo);
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateControl())
                {
                    DialogResult result = MessageBox.Show("Do you want to Send Challan to Branch "+cmbBranch.Text+" from Baranch "+cmbSenderBranch.Text+" ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (AddData())
                        {
                            int VID = (new ChallanController().SaveOrder(ch, Isnew));
                            {
                                if (true)

                                {
                                    MessageBox.Show("Save Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    PrintDialog pd = new PrintDialog();
                                    string oldPrinter = pd.PrinterSettings.DefaultPageSettings.PrinterSettings.PrinterName;
                                    Common.Data_Sets.DsChallan dsChallan = new Common.Data_Sets.DsChallan();
                                    if (new ChallanController().GetChallanData(ref dsChallan, Convert.ToInt32(txtID.Text.Trim()),"",ch.EntryBranchID))
                                    {

                                        Report_Forms.frmViewer Viewer = new Report_Forms.frmViewer();
                                        Viewer.reportViewer1.Reset();

                                        if (dsChallan.Tables["DsChallan"].Rows.Count > 0)
                                        {
                                            ReportDataSource rds = new ReportDataSource("DataSet1", dsChallan.Tables["DsChallan"]);
                                            Viewer.reportViewer1.LocalReport.DataSources.Add(rds);

                                        
                                            Viewer.reportViewer1.LocalReport.ReportEmbeddedResource ="Restorant_Management_System.Report.RptChallan.rdlc";
                                            ReportParameter[] rptParams = new ReportParameter[]
                                            {
                                                    new ReportParameter("User",User._UserName),
                                                      new ReportParameter("Header","Delivery Challan"),
                                             };
                                            Viewer.reportViewer1.LocalReport.SetParameters(rptParams);
                                            Viewer.reportViewer1.LocalReport.Refresh();
                                            Viewer.ShowDialog();

                                        }
                                        else
                                        {
                                            MessageBox.Show("No Data Found", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No Data Found", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }

                                    //ClearControls();
                                    //DialogResult result = MessageBox.Show("Do you want to print this Record?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    //if (result == DialogResult.Yes)
                                    //{
                                    //    //where = " where ID = " +order.ID;
                                    //    SetReport("w");
                                    //}
                                    ClearControl();
                                }

                                else
                                {
                                    MessageBox.Show("Not Saved");
                                }
                            }
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                {
                    DialogResult result = MessageBox.Show("Do you really want to Delete this Invoice", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        if (new ChallanController().DeletePurchase(Convert.ToInt32(txtID.Text.Trim())))
                        {
                            MessageBox.Show("Challan Invoice has been Deleted", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearControl();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetPurchaseRows(List<Challan> lines)
        {
            try
            {
                if (lines != null)
                {

                    for (int i = 0; i < lines.Count; i++)
                    {
                        int rowIndex = Grd.Rows.Add();
                        if (lines[i].serialno > 0)
                        {
                            Grd.Rows[rowIndex].Cells["ItemID"].ReadOnly = true;
                            Grd.Rows[rowIndex].Cells["BarCode"].ReadOnly = true;
                        }
                     
                        Grd.Rows[i].Cells["ItemID"].Value = lines[i].ItemID.ToString();
                        Grd.Rows[i].Cells["BarCode"].Value = lines[i].Barcode;
                        Grd.Rows[i].Cells["Item"].Value = lines[i].ItemName.ToString();                     
                        Grd.Rows[i].Cells["Quantity"].Value = lines[i].Quantity.ToString();
                        Grd.Rows[i].Cells["Cost"].Value = lines[i].Cost.ToString();
                        Grd.Rows[i].Cells["Rate"].Value = lines[i].Purate.ToString();
                        Grd.Rows[i].Cells["Total"].Value = (lines[i].Purate * lines[i].Quantity) + lines[i].Cost ;

                        Grd.Rows[i].Cells["Srno"].Value = lines[i].serialno.ToString();
                         Grd.Rows[i].Cells["IsReceived"].Value = lines[i].IsReceived.ToString();
                         Grd.Rows[i].Cells["IsTransition"].Value = lines[i].IsTarnsition.ToString();

                        Grd.Rows[i].Cells["Stock"].Value = (lines[i].stock + lines[i].Quantity).ToString();

                    }
                    CalculateTotal();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetItemRow", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void PapulateData(Challan order)
        {
            try
            {
                ClearControl();
                this.txtID.Text = order.ID.ToString();
                this.dtpFromDate.Value = order.FromDate;
            
                cmbSenderBranch.SelectedValue = order.ChallanLines[0].EntryBranchID;
                cmbBranch.SelectedValue = order.ChallanLines[0].BranchID;
             
                //this.cmbCounter.Text = order.CounterName.ToString();
                txtRemarks.Text = order.ChallanLines[0].Remarks;
              
                //EditGriddata
                SetPurchaseRows(order.ChallanLines);

             

                Isnew = false;
            }
            catch (Exception ex)
            {
                
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Sch_Forms.SchChallan frm = new Sch_Forms.SchChallan();
              
                frm.ShowDialog();

                Common.Challan order = frm.item;
                if (order != null)
                {
                    ClearControl();
                    PapulateData(order);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmPurchaseInvoice EditRecord", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Grd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                int rowIndex = Grd.CurrentRow.Index;
                int colIndex = Grd.CurrentCell.ColumnIndex;

                if (e.KeyCode == Keys.F1)
                {
                    if (Convert.ToInt32(Grd.Rows[rowIndex].Cells["SrNo"].Value) == 0)
                    {

                        Accounts.SchForms.SchItems sch = new Accounts.SchForms.SchItems();
                        sch.BranchId = Convert.ToInt32(cmbSenderBranch.SelectedValue  );
                        sch.ShowDialog();
                        List<Item> lstitem = new List<Item>();
                        lstitem = sch.subList1;
                       
                        for (int i = 0; i < lstitem.Count; i++)
                        {
                            if (ChkExistingItem(lstitem[i].ItemID) == 0)
                            {
                                Grd.Rows[rowIndex].Cells["ItemID"].Value = lstitem[i].ItemID.ToString();
                                Common.Item objitem = new Common.Item();
                                objitem = new ItemController().GetChallanItem(Convert.ToString(lstitem[i].ItemID), "I", Convert.ToInt32(cmbSenderBranch.SelectedValue));
                                Grd.Rows[rowIndex].Cells["Item"].Value = lstitem[i].ItemName.ToString();
                                Grd.Rows[rowIndex].Cells["Barcode"].Value = lstitem[i].BarCode.ToString();
                                Grd.Rows[rowIndex].Cells["Stock"].Value = objitem.CurrentStock;
                                Grd.Rows[rowIndex].Cells["Rate"].Value = new ItemController().ItemPrice(Convert.ToInt32(lstitem[i].ItemID), Convert.ToInt32(cmbSenderBranch.SelectedValue));
                                Grd.Rows[rowIndex].Cells["Quantity"].Value = "";
                            }
                            else
                            {
                                MessageBox.Show("This Item has already been added!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                ResetRow();
                            }
                        }                   
                    }
                  
                }
                if (e.KeyCode == Keys.F2)
                {
                    AccountsGlobals.ShowItemCreation();
                    e.Handled = true;
                }
                if (e.KeyCode == Keys.Delete)
                {
                    if (!Isnew)
                    {
                        DialogResult result = MessageBox.Show("Do really want to delete this Row?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            int currentRow = Grd.CurrentRow.Index;
                            int selectRow = 0;

                            //Grd.Rows.Remove(Grd.Rows [Grd.CurrentRow .Index ]);
                            Grd.Rows[Grd.CurrentRow.Index].Cells["IsDeleted"].Value = true;
                            Grd.Rows[Grd.CurrentRow.Index].Visible = false;



                            for (int i = currentRow + 1; i < Grd.Rows.Count; i++)
                            {
                                if (Grd.Rows[i].Visible == true)
                                {
                                    selectRow = i;
                                    break;
                                }
                            }

                            Grd.Rows[selectRow].Cells["ItemID"].Selected = true;
                            SetRowNo(ref Grd);
                            CalculateTotal();
                        }
                    }
                }
            



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Grd_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ResetRow()
        {
            try
            {
                int rowIndex = Grd.CurrentRow.Index;
                int colIndex = Grd.CurrentCell.ColumnIndex;
                Grd.Rows[rowIndex].Cells["ItemID"].Value = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ResetRow", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void btnNew_Click_1(object sender, EventArgs e)
        {
            ClearControl();
        }
        private bool SetItemRow(Item i)
        {
            try
            {
                if (i != null)
                {
                    int rowIndex = Grd.CurrentRow.Index;
                    int colIndex = Grd.CurrentCell.ColumnIndex;

                    if (ChkExistingItem(i.ItemID) == 0)
                    {
                        if (i.ItemID > 0)
                        {

                            Grd.Rows[rowIndex].Cells["ItemID"].Value = i.ItemID;
                            Grd.Rows[rowIndex].Cells["BarCode"].Value = i.BarCode;
                            Grd.Rows[rowIndex].Cells["Item"].Value = i.ItemName.ToString();
                            Grd.Rows[rowIndex].Cells["Stock"].Value = i.CurrentStock;                           
                            Grd.Rows[rowIndex].Cells["Rate"].Value = new ItemController().ItemPrice(Convert.ToInt32(i.ItemID), Convert.ToInt32(cmbSenderBranch.SelectedValue));
                            Grd.Rows[rowIndex].Cells["Quantity"].Value = "";
                            Grd.Rows[rowIndex].Cells["Stock"].Selected = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("This Item has already been added!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ResetRow();
                    }

                    return true;
                }                               
                else
                {
                  
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetItemRow", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private int ChkExistingItem(int itemID)
        {
            try
            {
                for (int i = 0; i < Grd.Rows.Count; i++)
                {
                    if (Grd.Rows[i].Cells["ItemID"].Visible == true)
                    {
                        if (itemID == Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value) && i != Grd.CurrentRow.Index)
                        {
                            return itemID;
                        }
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ChkExistingItem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void Grd_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = Grd.CurrentRow.Index;
                int colIndex = Grd.CurrentCell.ColumnIndex;

                if (colIndex == Grd.Columns["BarCode"].Index)
                {

                    string barcode = Grd.Rows[rowIndex].Cells["BarCode"].Value == null ? "0" : Grd.Rows[rowIndex].Cells["BarCode"].Value.ToString().Trim();

                    if (!SetItemRow(new ItemController().GetChallanItem(barcode, "B", Convert.ToInt32(cmbSenderBranch.SelectedValue))))
                    {
                        if (Convert.ToInt32(Grd.Rows[rowIndex].Cells[colIndex].Value) != 0)
                        {
                            Grd.Rows[rowIndex].Cells["ItemID"].Selected = true;
                            MessageBox.Show("No item with this ID exists", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }

                if (colIndex == Grd.Columns["ItemID"].Index)
                {
                    string itemid = Grd.Rows[rowIndex].Cells["ItemID"].Value.ToString().Trim() == null ? "0" : Grd.Rows[rowIndex].Cells["ItemID"].Value.ToString();

                    if (!SetItemRow(new ItemController().GetChallanItem(itemid, "I",Convert.ToInt32(cmbSenderBranch.SelectedValue  ) )))
                    {
                        if (Convert.ToInt32(Grd.Rows[rowIndex].Cells[colIndex].Value) != 0)
                        {
                            Grd.Rows[rowIndex].Cells["ItemID"].Selected = true;
                            MessageBox.Show("No item with this ID exists", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        
                    }
                  
                 
                }
                else if (colIndex == Grd.Columns["Quantity"].Index)
                {
                    if ((Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Quantity"].Value) > Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Stock"].Value)) && (Grd.Columns["Stock"].Visible == true))
                    {
                        if (Grd.Rows[rowIndex].Cells["Stock"].Value != null)
                        {
                            Grd.Rows[rowIndex].Cells["Quantity"].Value = 0;
                            MessageBox.Show("Quantity can not be greater then Current Stock.", "Check Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        decimal qty = Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Quantity"].Value);
                        decimal rate = Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Rate"].Value);
                        decimal cost = Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Cost"].Value);
                        Grd.Rows[rowIndex].Cells["Total"].Value = (qty * rate) + cost;
                        Grd.Rows[rowIndex].Cells["Rate"].Selected = true;
                    }

                }
                else if (colIndex == Grd.Columns["Cost"].Index)
                {
                    decimal qty = Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Quantity"].Value);
                    decimal rate = Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Rate"].Value);
                    decimal cost= Convert.ToDecimal(Grd.Rows[rowIndex].Cells["Cost"].Value);
                    Grd.Rows[rowIndex].Cells["Total"].Value = (qty * rate) + cost;

                    Grd.Rows[rowIndex+1].Cells["Total"].Selected = true;
                }


                CalculateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Grd_CellEndEdit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Grd_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            SetRowNo(ref Grd);
        }

        private void Grd_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            SetRowNo(ref Grd);
        }

        private void CalculateTotal()
        {
            decimal totalqty = 0;
            decimal cost = 0;
            decimal total = 0;
            for(int i = 0; i < Grd.RowCount; i++)
            {
                if (Grd.Rows[i].Visible == true)
                {
                    if (Grd.Rows[i].Cells["Itemid"].Value != null)
                    {
                        totalqty += Convert.ToDecimal(Grd.Rows[i].Cells["Quantity"].Value);
                        cost += Convert.ToDecimal(Grd.Rows[i].Cells["Cost"].Value);
                        total += Convert.ToDecimal(Grd.Rows[i].Cells["Total"].Value);
                    }
                }
            }

            txtTotalQuantity.Text = totalqty.ToString();
            txtTotalCost.Text = cost.ToString();
            txtTotalAmt.Text = total.ToString();
        }

        private void Grd_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            
        }

        private void cmbCourier_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbCourier.Text.Trim().Length == 0)
            {
              
                lblTrackingID.Visible = false;
                txtTrackingID.Visible = false;
            
            }
            else
            {
                
                lblTrackingID.Visible = true;
                txtTrackingID.Visible = true;
          
            }
        }
    }
}

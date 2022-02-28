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
using CategoryControlle;
using Accounts;
using Accounts.Forms;
using CommonController;
using Microsoft.Reporting.WinForms;

namespace Restorant_Management_System.Forms
{
    public partial class FrmDeliveryChallan : Form
    {
        private List<Challan> Item = new List<Challan>();
        public Challan item = null;
        private Challan delchalan;
        private List<Challan> Lines;
        
        bool isNew = true;
        
        private List<Challan> PDCIline;
        public FrmDeliveryChallan()
        {
            InitializeComponent();
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

                DataGridViewCheckBoxColumn chekbox = new DataGridViewCheckBoxColumn();
                DataGridViewCell checkcell = new DataGridViewCheckBoxCell();

                //Col 1
                //////////////////////////////////////////////////////////////////////////////////////////////////                

                DataGridViewColumn newCol = new DataGridViewColumn(); // add a column to the grid                




                //Col 1
                //////////////////////////////////////////////////////////////////////////////////////////////////   
                chekbox = new DataGridViewCheckBoxColumn();
                chekbox.CellTemplate = checkcell;
                chekbox.HeaderText = "Select";
                chekbox.Name = "Select";
                chekbox.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                chekbox.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                chekbox.Visible = false;
                chekbox.ReadOnly = false;
                chekbox.Width = 70;
                Grd.Columns.Add(chekbox);


                //Col 2
                //////////////////////////////////////////////////////////////////////////////////////////////////                
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "ID";
                newCol.Name = "ID";
                newCol.CellTemplate = TextCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = false;
                newCol.Width = 60;
                Grd.Columns.Add(newCol);
                //////////////////////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Date";
                newCol.Name = "Date";
                newCol.CellTemplate = TextCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;
                newCol.Width = 100;
                Grd.Columns.Add(newCol);

                //////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Sender Branch";
                newCol.Name = "SenderBranch";
                newCol.CellTemplate = TextCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;
                newCol.Width = 200;
                Grd.Columns.Add(newCol);
                ////////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Created By";
                newCol.Name = "CreatedBy";
                newCol.CellTemplate = TextCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;
                newCol.Width = 150;
                Grd.Columns.Add(newCol);
                ///////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Courier Service";
                newCol.Name = "CourierService";
                newCol.CellTemplate = TextCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;
                newCol.Visible = false;
                newCol.Width = 150;
                Grd.Columns.Add(newCol);
                /////////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Tracking ID";
                newCol.Name = "TrackingID";
                newCol.CellTemplate = TextCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;
                newCol.Visible = false;
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
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "IsDeleted";
                newCol.Name = "IsDeleted";
                newCol.CellTemplate = IntCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = false;
                newCol.Width = 70;
                Grd.Columns.Add(newCol);


              AccountsGlobals.ExtendCol(ref Grd, "SenderBranch");

             



                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool LoadGridDeatils()
        {
            try
            {
                //Set Grid.
                ///////////////////////////////////////////////////////////////////////////////////////////////////
                AccountsGlobals.SetGridStyle(ref GrdDetails);

                GrdDetails.EnableHeadersVisualStyles = false;
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
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "ID";
                newCol.Name = "ID";
                newCol.CellTemplate = IntCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = false;
                newCol.Visible = false;
                newCol.Width = 60;
                GrdDetails.Columns.Add(newCol);
                ///////////////////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Date";
                newCol.Name = "Date";

                newCol.CellTemplate = TextCell;

                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;
                newCol.Visible = false;
                newCol.Width = 250;
                GrdDetails.Columns.Add(newCol);
                ///////////////////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Branch ID";
                newCol.Name = "BranchID";
                newCol.CellTemplate = IntCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = false;
                newCol.Visible = false;
                newCol.Width = 60;
                GrdDetails.Columns.Add(newCol);
                /////////////////////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Item ID";
                newCol.Name = "ItemID";
                newCol.CellTemplate = IntCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;
              
                newCol.Width = 60;
                GrdDetails.Columns.Add(newCol);
                ///////////////////////////////////////////////
               
              
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Item Name";
                newCol.Name = "Item";

                newCol.CellTemplate = TextCell;

                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;

                newCol.Width = 250;
                GrdDetails.Columns.Add(newCol);



                //// To avoid all the annoying error messages, handle the DataError event of the DataGridView:
                //Grd.DataError += new DataGridViewDataErrorEventHandler(Grd_DataError); 

                //Col 3
                //////////////////////////////////////////////////////////////////////////////////////////////////               
               
                //////////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Quantity";
                newCol.Name = "Quantity";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.ReadOnly = true;
                newCol.Width = 150;
                GrdDetails.Columns.Add(newCol);


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
                GrdDetails.Columns.Add(newCol);


                AccountsGlobals.ExtendCol(ref GrdDetails, "Item");


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void FrmDeliveryChallan_Load(object sender, EventArgs e)
        {
            ClearControlls();
          
          
        }

        private void LoadData()
        {
            // Int32 counterid = new CounterController().GetCounterid(FrmLogin.UserID);
            Int32 Branchid =Globals.BranchID;
            //new CounterController().GetBranchid(FrmLogin.UserID);

            Item = (new ChallanController().GetRecivedData( Branchid));
            //Grd.DataSource = Item;

            if (Item != null)
            {
                PapulateData(Item);
            }

        }
        public void SetValues()
        {
            try
            {

           
                    item = new Challan();
                    item.ID = Convert.ToInt32(Grd.CurrentRow.Cells["ID"].Value);
                    item.ChallanLines = new ChallanController().GetChalan(item.ID);
                
                    SetPurchaseRows(item.ChallanLines);
           

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetValues", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetPurchaseRows(List<Challan> purchaseLines)
        {
            try
            {
                if (purchaseLines != null)
                {

                    for (int i = 0; i < purchaseLines.Count; i++)
                    {
                        int rowIndex = GrdDetails.Rows.Add();
                        GrdDetails.Rows[i].Cells["ID"].Value = purchaseLines[i].ID.ToString();
                        GrdDetails.Rows[i].Cells["Date"].Value = purchaseLines[i].FromDate.ToString();
                        GrdDetails.Rows[i].Cells["BranchID"].Value = purchaseLines[i].BranchID.ToString();
                        GrdDetails.Rows[i].Cells["ItemID"].Value = purchaseLines[i].ItemID.ToString();
                        GrdDetails.Rows[i].Cells["Item"].Value = purchaseLines[i].ItemName.ToString();
                        GrdDetails.Rows[i].Cells["Quantity"].Value = purchaseLines[i].Quantity.ToString();
               
                    }

                    CalculateQunatity();

                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetItemRow", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void PapulateData(List<Challan> list)
        {

            try
            {
                if (list != null)
                {

                    for (int i = 0; i < list.Count; i++)
                    {
                        int rowIndex = Grd.Rows.Add();


                        Grd.Rows[i].Cells["ID"].Value = list[i].ID.ToString();
                       Grd.Rows[i].Cells["SenderBranch"].Value = list[i].BranchName.ToString();
                        Grd.Rows[i].Cells["CreatedBy"].Value = list[i].Username.ToString();

                        Grd.Rows[i].Cells["Date"].Value = list[i].FromDate.ToString("d-MMM-yyyy");
                        Grd.Rows[i].Cells["CourierService"].Value = list[i].CourierAccount;
                        Grd.Rows[i].Cells["TrackingID"].Value = list[i].TrackingID;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetItemRow", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Grd_DoubleClick(object sender, EventArgs e)
        {
            LoadGridDeatils();
            SetValues();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControlls();
           

        }

        private void CalculateQunatity()
        {
            decimal totalqty = 0;
          
            for (int i = 0; i < GrdDetails.RowCount; i++)
            {
                totalqty += Convert.ToDecimal(GrdDetails.Rows[i].Cells["Quantity"].Value);

            }

            txtTotalQuantity.Text = totalqty.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateControl())
            {
                if (AddInvoice())
                {               
                    {
                        if (new ReceivedChallanController().Save(delchalan, isNew))
                        {
                            MessageBox.Show("Challan Received Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearControlls();
                            PrintReport(delchalan.ID);
                           
                        }
                    }
                    
                }
            }  
        }

        private void PrintReport(int iD)
        {
            PrintDialog pd = new PrintDialog();
            string oldPrinter = pd.PrinterSettings.DefaultPageSettings.PrinterSettings.PrinterName;
            Common.Data_Sets.DsChallan dsChallan = new Common.Data_Sets.DsChallan();
            if (new ChallanController().GetChallanData(ref dsChallan, Convert.ToInt32(iD), "",0 ))
            {

                Report_Forms.frmViewer Viewer = new Report_Forms.frmViewer();
                Viewer.reportViewer1.Reset();

                if (dsChallan.Tables["DsChallan"].Rows.Count > 0)
                {
                    ReportDataSource rds = new ReportDataSource("DataSet1", dsChallan.Tables["DsChallan"]);
                    Viewer.reportViewer1.LocalReport.DataSources.Add(rds);
                
                    Viewer.reportViewer1.LocalReport.ReportEmbeddedResource = "Restorant_Management_System.Report.RptChallan.rdlc";
                    ReportParameter[] rptParams = new ReportParameter[]
                    {
                                                    new ReportParameter("User",User._UserName),
                                                    new ReportParameter("Header","Received Challan"),
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearControlls();
        }

        private void ClearControlls()
        {
            txtUserName.Text = User._UserName;
            LoadGrid();
            LoadData();
            LoadGridDeatils();

            txtTotalQuantity.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
        }

        private bool AddInvoice()
        {
            try
            {
                delchalan = new Challan();
                for (int i = 0; i < GrdDetails.Rows.Count; i++)
                {
                    if (Convert.ToInt32(GrdDetails.Rows[i].Cells["ID"].Value) != 0)
                    {                  
                        delchalan.ID = Convert.ToInt32(GrdDetails.Rows[i].Cells["ID"].Value);
                        delchalan.FromDate = Convert.ToDateTime(GrdDetails.Rows[i].Cells["Date"].Value);                     
                    }
                }
                AddLines();
                delchalan.ChallanLines = Lines;
                return true;
            }
            catch(Exception ex)
            {
                return false;
                throw ex;
            }
        }

        private void AddLines()
        {
            try
            {
                if(GrdDetails.Rows.Count > 0)
                {
                    Lines = new List<Challan>();
                    for(int i=0;i< GrdDetails.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(GrdDetails.Rows[i].Cells["ItemID"].Value) != 0 && Convert.ToInt32(GrdDetails.Rows[i].Cells["BranchID"].Value) != 0)
                        {
                            Challan comon = new Challan();
                            comon.BranchID = Convert.ToInt32(GrdDetails.Rows[i].Cells["BranchID"].Value);
                            comon.ItemID= Convert.ToInt32(GrdDetails.Rows[i].Cells["ItemID"].Value);
                            comon.Quantity = Convert.ToDecimal(GrdDetails.Rows[i].Cells["Quantity"].Value);
                      

                            Lines.Add(comon);
                        }
                    }
                }
            }
             catch(Exception ex)
            {
                throw ex;

            }
        }

       

        private bool ValidateControl()
        {
            try
            {
                int rowIndex = Grd.CurrentRow.Index;
                int colIndex = Grd.CurrentCell.ColumnIndex;


                if (GrdDetails.Rows.Count < 2)
                {
                
                       
                        MessageBox.Show("Enter Some Data First.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

        private void GrdDetails_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

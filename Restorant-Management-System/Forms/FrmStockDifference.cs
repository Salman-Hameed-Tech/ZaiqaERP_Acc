using Accounts;
using Accounts.Forms;
using CategoryControlle;
using Common;
using ExcelDataReader;
using Microsoft.Reporting.WinForms;
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
    public partial class FrmStockDifference : Form
    {
        List<StockDifferenceSP> listitems = new List<StockDifferenceSP>();
        DataTable tables = new DataTable();
        public FrmStockDifference()
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

                //Col 1
                //////////////////////////////////////////////////////////////////////////////////////////////////                

                DataGridViewColumn newCol = new DataGridViewColumn(); // add a column to the grid                




                //Col 2
                //////////////////////////////////////////////////////////////////////////////////////////////////   

                newCol.CellTemplate = TextCell;
                newCol.HeaderText = "Barcode";
                newCol.Name = "Barcode";
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.ReadOnly = true;
                newCol.Width = 80;
                Grd.Columns.Add(newCol);





                ////////////////////////////////////

                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Item Name";
                newCol.Name = "Item";

                newCol.CellTemplate = TextCell;

                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;
                //  newCol.Visible = Globals.PackingColumnVisible;
                newCol.Width = 200;
                Grd.Columns.Add(newCol);

                /////////////////////////////
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Software Stock";
                newCol.Name = "CsQty";
                newCol.CellTemplate = TextCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.Width = 120;
                Grd.Columns.Add(newCol);
                //Col 7
                //////////////////////////////////////////////////////////////////////////////////////////////////

                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Physical Stock";
                newCol.Name = "Quantity";
                newCol.CellTemplate = TextCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.Width = 120;
                Grd.Columns.Add(newCol);
                //Col 8////////////////////

                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Difference";
                newCol.Name = "Difference";
                newCol.CellTemplate = TextCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.Width = 120;
                Grd.Columns.Add(newCol);
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

        private void PopulateData(DataTable tables)
        {
            try
            {

                LoadGrid();
                listitems.Clear();
                int count = 0;
           

                List<StockDifferenceSP> AllItems = new List<StockDifferenceSP>();
                AllItems = new ItemController().GetStockItems(Convert.ToInt32(cmbBranch.SelectedValue));
       
                for (int i = 0; i < AllItems.Count; i++)
                {
                    StockDifferenceSP obj = new StockDifferenceSP();
                    for(int k=0;k< tables.Rows.Count; k++)
                    {
                        if (AllItems[i].Barcode == tables.Rows[k]["BARCODE"].ToString())
                        {

                            AllItems[i].PhysicalQty = AllItems[i].PhysicalQty+ Convert.ToInt32(tables.Rows[k]["QUANTITY"]);
                         
                        }
                     
                       
                    }
                    
                }

         

                if (AllItems.Count > 0)
                {
                    for (int i = 0; i < AllItems.Count; i++)
                    {               
                        {
                            int diff = (AllItems[i].CsQty) - (AllItems[i].PhysicalQty);
                            if (diff != 0)
                            {
                                int RowIndex = Grd.Rows.Add();
                                Grd.Rows[RowIndex].Cells["Barcode"].Value = AllItems[i].Barcode;
                                Grd.Rows[RowIndex].Cells["Item"].Value = AllItems[i].ItemName;
                                Grd.Rows[RowIndex].Cells["Quantity"].Value = AllItems[i].PhysicalQty;
                                Grd.Rows[RowIndex].Cells["CsQty"].Value = AllItems[i].CsQty;

                                Grd.Rows[RowIndex].Cells["Difference"].Value = diff;
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "PopulateData", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmStockDifference_Load(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void ClearControls()
        {
            PopulateBranch();
            LoadGrid();
            txtFileNmae.Clear();
        }

        private void PopulateBranch()
        {
            try
            {

                List<Branch> counters = new BranchController().GetBranch(" where 1=1 ");
                cmbBranch.DataSource = counters;
                cmbBranch.ValueMember = "ID";
                cmbBranch.DisplayMember = "BranchName";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadCategories", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Common.Data_Sets.DSStockDifference dSStockDifference = new Common.Data_Sets.DSStockDifference();

            DataTable dt = new DataTable("ProdFromDGV");
            foreach (DataGridViewColumn col in Grd.Columns)
            {
                dt.Columns.Add(col.Name);
            }
            foreach (DataGridViewRow row in Grd.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dRow);
            }
            dSStockDifference.Tables.Add(dt);

            Report_Forms.frmViewer Viewer = new Report_Forms.frmViewer();
            if (dSStockDifference.Tables["ProdFromDGV"].Rows.Count > 0)
            {
                ReportDataSource rds = new ReportDataSource("DataSet1", dSStockDifference.Tables["ProdFromDGV"]);
                Viewer.reportViewer1.LocalReport.DataSources.Add(rds);           
                Viewer.reportViewer1.LocalReport.ReportPath = Globals.ReportPath + "/Report/RptStockDifference.rdlc";
                ReportParameter[] rptParams = new ReportParameter[]
                {
                    new ReportParameter("User",User._UserName),
                    new ReportParameter("Branch",cmbBranch.Text),
                 };
                Viewer.reportViewer1.LocalReport.SetParameters(rptParams);
                Viewer.reportViewer1.LocalReport.Refresh();
                Viewer.ShowDialog();
                ClearControls();

            }
            else
            {
                MessageBox.Show("No Data Found", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void Grd_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           
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
           
        }
    }
}

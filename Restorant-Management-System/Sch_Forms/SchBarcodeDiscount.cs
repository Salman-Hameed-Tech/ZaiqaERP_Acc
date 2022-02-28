using Accounts;
using Accounts.Forms;
using CategoryControlle;
using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restorant_Management_System.Sch_Forms
{
    public partial class SchBarcodeDiscount : Form
    {
        List<Common.SchDiscOffers> lstitem = new List<Common.SchDiscOffers>();
        List<Common.SchDiscOffers> subList = new List<Common.SchDiscOffers>();
        List<Common.SchDiscOffers> lstDetails = new List<Common.SchDiscOffers>();

        public int ParaOutID;

        public bool IsCategoryDisc;
        public SchBarcodeDiscount()
        {
            InitializeComponent();
        }

        private void SchBarcodeDiscount_Load(object sender, EventArgs e)
        {
            ParaOutID = 0;

            lstitem = (new SchDiscOfferController().GetBarcodeOffers());
            Grd.DataSource = lstitem.OrderByDescending(x => x.OfferID).ToList();
            FormatGrid();
            LoadTempGrid();
        }
        private void FormatGrid()
        {
            try
            {
                Grd.Columns["FileNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["FileNo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["FileNo"].Width = 60;

                Grd.Columns["FromDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["FromDate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["FromDate"].Width = 120;


                Grd.Columns["ToDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["ToDate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["ToDate"].Width = 120;


                Grd.Columns["Discount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Grd.Columns["Discount"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Discount"].Width = 50;

              
                Grd.Columns["IsActive"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["IsActive"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["IsActive"].Width = 60;


                Grd.Columns["Design"].Visible = false;
                Grd.Columns["Size"].Visible = false;
                Grd.Columns["BranchName"].Visible = false;
                Grd.Columns["OfferID"].Visible = false;
                Grd.Columns["Category"].Visible = false;
                Grd.Columns["CompanyName"].Visible = false;
                Grd.Columns["ProductName"].Visible = false;
                Grd.Columns["Barcode"].Visible = false;
               


                if (Grd.Rows.Count > 0)
                {
                    Grd.Rows[0].Selected = true;
                }

                AccountsGlobals.ExtendCol(ref Grd, "Discount");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //////


        }
        private void FormatGridDetail()
        {
            try
            {
                GrdDetail.Columns["OfferID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdDetail.Columns["OfferID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdDetail.Columns["OfferID"].Width = 80;

                GrdDetail.Columns["Barcode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdDetail.Columns["Barcode"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdDetail.Columns["Barcode"].Width = 60;

                GrdDetail.Columns["ProductName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                GrdDetail.Columns["ProductName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdDetail.Columns["ProductName"].Width = 200;

                GrdDetail.Columns["FromDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdDetail.Columns["FromDate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdDetail.Columns["FromDate"].Width = 120;


                GrdDetail.Columns["ToDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdDetail.Columns["ToDate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdDetail.Columns["ToDate"].Width = 120;


                GrdDetail.Columns["Discount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                GrdDetail.Columns["Discount"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdDetail.Columns["Discount"].Width = 50;





                GrdDetail.Columns["Design"].Visible = false;
                GrdDetail.Columns["Size"].Visible = false;
                GrdDetail.Columns["BranchName"].Visible = false;
         
                GrdDetail.Columns["Category"].Visible = false;
                GrdDetail.Columns["CompanyName"].Visible = false;
                GrdDetail.Columns["FileNo"].Visible = false;
                GrdDetail.Columns["IsActive"].Visible = false;


                //if (GrdDetail.Rows.Count > 0)
                //{
                //    GrdDetail.Rows[0].Selected = true;
                //}

                AccountsGlobals.ExtendCol(ref GrdDetail, "ProductName");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //////


        }
        private void LoadTempGrid()
        {
            try
            {
                this.GrdTemp.ColumnHeadersDefaultCellStyle.Font = new Font(GrdTemp.Font, FontStyle.Bold);
                GrdTemp.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                GrdTemp.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                GrdTemp.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                GrdTemp.GridColor = Color.Black;

                GrdTemp.MultiSelect = false;

                DataGridViewCell TextCell = new DataGridViewTextBoxCell();
                DataGridViewColumn newCol = new DataGridViewColumn();

                for (int i = 0; i < Grd.Columns.Count; i++)
                {
                    newCol = new DataGridViewColumn();
                    newCol.CellTemplate = TextCell;
                    newCol.HeaderText = Grd.Columns[i].HeaderText;
                    newCol.Name = Grd.Columns[i].Name;
                    newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    newCol.Visible = Grd.Columns[i].Visible;
                    newCol.Width = Grd.Columns[i].Width;
                    GrdTemp.Columns.Add(newCol);
                }
                GrdTemp.Rows.Add(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadTempGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                newCol.Width = 200;
                GrdBranch.Columns.Add(newCol);
                //////////////////////////////////////////
                checkColumn = new DataGridViewCheckBoxColumn();
                checkColumn.HeaderText = "Select";
                checkColumn.Name = "Select";
                // checkColumn.CellTemplate = IntCell;
                checkColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                checkColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                checkColumn.Visible = true;
                checkColumn.Width = 40;
                GrdBranch.Columns.Add(checkColumn);
                /////////////////////////////////////
                ///

                AccountsGlobals.ExtendCol(ref GrdBranch, "Branch");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void GrdTemp_EditValueChanged(object sender, EventArgs e)
        {
            if (GrdTemp.filterCondition.Length != 0)
            {
                Common.Globals.condition = GrdTemp.filterCondition;
                FormatCondition();
                subList = this.lstitem.FindAll(FilterBarFun);


                Grd.DataSource = null;
                Grd.DataSource = subList;
                FormatGrid();

            }
            else
            {
                Grd.DataSource = lstitem;
                FormatGrid();
            }
        }
        private bool FilterBarFun(Common.SchDiscOffers p)
        {
            try
            {
                String[] st = new String[1];
                st[0] = "AND";
                string s = Common.SchDiscOffers.Condition;
                string[] sr = s.Split(st, StringSplitOptions.RemoveEmptyEntries);
                string res = "";

                for (int i = 0; i < sr.Length; i++)
                {
                    string fieldName = sr[i].Split('=').GetValue(0).ToString().Trim();

                    string fieldValue = sr[i].Split('=').GetValue(1).ToString().Trim().ToUpper();


                    if (fieldValue.ToString().Trim().Length == 0)
                        break;

                    switch (fieldName)
                    {
                        case "[FileNo]":
                            res = res + " " + Convert.ToString((p.FileNo == Convert.ToInt32(fieldValue)));
                            break;
                        case "[FromDate]":
                            res = res + " " + Convert.ToString((p.FromDate.ToString().ToUpper().Contains(fieldValue.ToString().ToUpper())));
                            break;
                        case "[ToDate]":
                            res = res + " " + Convert.ToString((p.ToDate.ToString().ToUpper().Contains(fieldValue.ToString().ToUpper())));
                            break;
                        case "[Discount]":
                            res = res + " " + Convert.ToString((p.Discount.ToString().ToUpper().Contains(fieldValue.ToString().ToUpper())));
                            break;
                                      
                    }
                }
                if (res.Contains(" False") == true)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SchPurchases FilterPurchase", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return false;
            }
        }
        private void FormatCondition()
        {
            try
            {
                String oldcon = Common.SchDiscOffers.Condition;
                String newCon = "";

                while (oldcon.IndexOf(" Like ") > 0)
                {
                    newCon = oldcon.Substring(oldcon.IndexOf(" Like ") + " Like ".Length + 1, oldcon.IndexOf("*'") - (oldcon.IndexOf(" Like ") + " Like ".Length + 1));
                    oldcon = oldcon.Replace("Like '" + newCon + "*'", "= " + newCon);
                }

                Common.SchDiscOffers.Condition = oldcon;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "SchItem FormatCondition", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Grd_DoubleClick(object sender, EventArgs e)
        {
            SelectValue();
        }
        private void SelectValue()
        {

          if (Grd.Rows.Count == 0) return;
          
           ParaOutID = Convert.ToInt32(Grd.Rows[Grd.CurrentRow.Index].Cells["FileNo"].Value);        
           this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Grd_Click(object sender, EventArgs e)
        {
            SetBranches();
            SetDetails();
        }

       

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectValue(); 
        }
        private void SetDetails()
        {
          
            int RowIndex = Grd.CurrentRow.Index;
            int fileNo = Convert.ToInt32(Grd.Rows[RowIndex].Cells["FileNO"].Value);
            lstDetails = new DiscountOfferController().GetDiscDetail(fileNo);
            GrdDetail.DataSource = lstDetails;
            FormatGridDetail();
        }
        private void SetBranches()
        {
            int RowIndex = Grd.CurrentRow.Index;
            int fileNo = Convert.ToInt32(Grd.Rows[RowIndex].Cells["FileNO"].Value);
            bool isBarcodeDisc = true;
            List<Branch> branches = new List<Branch>();
            branches = new DiscountOfferController().GetOfferBranches(fileNo, isBarcodeDisc);

            LoadBranchGrid();
            for (int i = 0; i < branches.Count; i++)
            {

                GrdBranch.Rows.Add();
                GrdBranch.Rows[i].Cells["ID"].Value = branches[i].ID;
                GrdBranch.Rows[i].Cells["Branch"].Value = branches[i].BranchName;
                GrdBranch.Rows[i].Cells["Select"].Value = branches[i].Select;
            }
        }

        private void Grd_SelectionChanged(object sender, EventArgs e)
        {
            SetBranches();
            SetDetails();
        }
    }
}

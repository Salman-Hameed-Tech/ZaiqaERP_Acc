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
    public partial class SchDiscount : Form
    {
        List<Common.SchDiscOffers> lstitem = new List<Common.SchDiscOffers>();
        List<Common.SchDiscOffers> subList = new List<Common.SchDiscOffers>();

        public int ParaOutID;

        public bool IsCategoryDisc;
        public SchDiscount()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectValue();
        }

        private void frmDiscount_Load(object sender, EventArgs e)
        {
            ParaOutID = 0;
           
            lstitem = (new SchDiscOfferController().GetOffers(IsCategoryDisc));
            Grd.DataSource = lstitem.OrderByDescending(x => x.OfferID).ToList();
            FormatGrid();
            LoadTempGrid();
        }
        private void FormatGrid()
        {
            try
            {
                Grd.Columns["OfferID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["OfferID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["OfferID"].Width = 60;

                Grd.Columns["Category"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Grd.Columns["Category"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Grd.Columns["Category"].Width = 50;
            

                Grd.Columns["CompanyName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Grd.Columns["CompanyName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Grd.Columns["CompanyName"].Width = 90;
               

                Grd.Columns["ProductName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Grd.Columns["ProductName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Grd.Columns["ProductName"].Width = 50;

                Grd.Columns["Design"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Grd.Columns["Design"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Grd.Columns["Design"].Width = 90;
              
                Grd.Columns["Size"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Grd.Columns["Size"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Grd.Columns["Size"].Width = 90;
               

                Grd.Columns["IsActive"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Grd.Columns["IsActive"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Grd.Columns["IsActive"].Width = 50;


                Grd.Columns["Design"].Visible = false;
                Grd.Columns["Barcode"].Visible = false;
                Grd.Columns["ProductName"].Visible = false;
                Grd.Columns["Size"].Visible = false;
                Grd.Columns["BranchName"].Visible = false;
                Grd.Columns["FileNo"].Visible = false;
                if (Grd.Rows.Count > 0)
                {
                    Grd.Rows[0].Selected = true;
                }

                AccountsGlobals.ExtendCol(ref Grd, "Category");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //////
            

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
        private void SelectValue()
        {
            if (Grd.Rows.Count == 0) return;
            if (IsCategoryDisc)
            {
                ParaOutID = Convert.ToInt32(Grd.Rows[Grd.CurrentRow.Index].Cells["OfferID"].Value);
            }
            else
            {
                ParaOutID = Convert.ToInt32(Grd.Rows[Grd.CurrentRow.Index].Cells["FileNo"].Value);

            }
            this.Close();
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
                        case "[OfferID]":
                            res = res + " " + Convert.ToString((p.OfferID == Convert.ToInt32(fieldValue)));
                            break;
                        case "[Category]":
                            res = res + " " + Convert.ToString((p.Category.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
                            break;
                        case "[CompanyName]":
                            res = res + " " + Convert.ToString((p.CompanyName.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
                            break;
                        case "[ProductName]":
                            res = res + " " + Convert.ToString((p.ProductName.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
                            break;
                        case "[Design]":
                            res = res + " " + Convert.ToString((p.Design.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
                            break;
                        case "[Size]":
                            res = res + " " + Convert.ToString(p.Size.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper()));
                            break;
                        case "[IsActive]":
                            res = res + " " + Convert.ToString(p.IsActive.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper()));
                            break;
                        default:
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Grd_Click(object sender, EventArgs e)
        {
            SetBranches();
           
        }

        private void SetBranches()
        {
            int RowIndex = Grd.CurrentRow.Index;
            int offerid = Convert.ToInt32(Grd.Rows[RowIndex].Cells["OfferID"].Value);

            List<Branch> branches = new List<Branch>();
            branches = new DiscountOfferController().GetOfferBranches(offerid,false);

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
        }
    }
}

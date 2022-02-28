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
using Common;

namespace Restorant_Management_System.Sch_Forms
{
    public partial class SchBranch : Form
    {
        List<Branch> list = new List<Branch>();
        List<Branch> Sublist = new List<Branch>();
        public Branch branch = null;
        public List<Branch> selectedBranches;
        public bool IsBranchDisc;
        public int OfferID = 0;
        public SchBranch()
        {
            InitializeComponent();
        }

        private void SchBranch_Load(object sender, EventArgs e)
        {
            if (IsBranchDisc==true && OfferID !=0)
            {
                list = new CategoryControlle.DiscountOfferController().GetOfferBranches(OfferID,false);
            }
            else
            {
                list = new CategoryControlle.BranchController().GetBranch("");
            }
           
            Grd.DataSource = list;
            FormatGrid();
            LoadTempGrid();
        }
        private bool FilterBarFun(Branch c)
        {
            try
            {
                String[] st = new String[1];
                st[0] = "AND";
                string s = Common.Globals.condition;
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
                        case "[ID]":
                            res = res + " " + Convert.ToString((c.ID.ToString() == (fieldValue).ToString()));
                            break;
                        case "[BranchName]":
                            res = res + " " + Convert.ToString((c.BranchName.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
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
                MessageBox.Show(ex.Message, "SchBranch ", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return false;
            }
        }

        private void FormatGrid()
        {
            try
            {
                Grd.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["ID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["ID"].Width = 50;


                Grd.Columns["BranchName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Grd.Columns["BranchName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Grd.Columns["BranchName"].Width = 80;

                Grd.Columns["CityID"].Visible = false;
                if (IsBranchDisc)
                {
                    Grd.Columns["Select"].Visible = true;
                    Grd.Columns["Select"].Width = 80;
                    Grd.Columns["CityName"].Visible = false;
                    Grd.Columns["IsWarehouse"].Visible = false;
                }
                else
                {
                    Grd.Columns["Select"].Visible = false;
                }
                if (Grd.Rows.Count > 0)
                {
                    Grd.Rows[0].Selected = true;
                }

                AccountsGlobals.ExtendCol(ref Grd, "BranchName");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatCondition()
        {
            try
            {
                String oldcon = Common.Globals.condition;
                String newCon = "";

                while (oldcon.IndexOf(" Like ") > 0)
                {
                    newCon = oldcon.Substring(oldcon.IndexOf(" Like ") + " Like ".Length + 1, oldcon.IndexOf("*'") - (oldcon.IndexOf(" Like ") + " Like ".Length + 1));
                    oldcon = oldcon.Replace("Like '" + newCon + "*'", "= " + newCon);
                }

                Common.Globals.condition = oldcon;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SchBranch FormatCondition", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadTempGrid()
        {
            try
            {
                this.Grd_Temp.ColumnHeadersDefaultCellStyle.Font = new Font(Grd_Temp.Font, FontStyle.Bold);
                Grd_Temp.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                Grd_Temp.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                Grd_Temp.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                Grd_Temp.GridColor = Color.Black;

                Grd_Temp.MultiSelect = false;

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
                    Grd_Temp.Columns.Add(newCol);
                }
                Grd_Temp.Rows.Add(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadTempGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetParaOut()
        {
            try
            {
                if (list.Count > 0)
                {
                    int RowIndex = Grd.CurrentRow.Index;
                    branch = new CategoryControlle.BranchController().GetSingleCounter(Convert.ToInt32((Grd.Rows[RowIndex].Cells["ID"].Value.ToString())));

                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetParaOut", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Grd_Temp_EditValueChanged(object sender, EventArgs e)
        {
            if (Grd_Temp.filterCondition.Length != 0)
            {
                Common.Globals.condition = Grd_Temp.filterCondition;
                FormatCondition();
                Sublist = this.list.FindAll(FilterBarFun);


                Grd.DataSource = null;
                Grd.DataSource = Sublist;
                FormatGrid();

            }
            else
            {
                Grd.DataSource = list;
                FormatGrid();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Grd_DoubleClick(object sender, EventArgs e)
        {
            SetParaOut();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (IsBranchDisc)
            {
                SelectBranches();
            }
            else
            {
                SetParaOut();
            }
        }

        private void SelectBranches()
        {
            try
            {
                selectedBranches = new List<Branch>();
                for (int i = 0; i <= Grd.Rows.Count-1; i++)
                {
                 
                    if (Convert.ToBoolean(Grd.Rows[i].Cells["Select"].Value) == true)
                    {
                        Branch b = new Branch();
                        b.ID = Convert.ToInt32(Grd.Rows[i].Cells["ID"].Value);
                        b.BranchName = Convert.ToString(Grd.Rows[i].Cells["BranchName"].Value);
                        selectedBranches.Add(b);
                    }
                }
                this.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}

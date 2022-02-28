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

namespace Accounts.SchForms
{
    public partial class SchCategory : Form
    {
        List<Category> lstitem = new List<Category>();
        List<Category> subList = new List<Category>();

        public Category item = null;

        public SchCategory()
        {
            InitializeComponent();
        }

        private void SchItems_Load(object sender, EventArgs e)
        {
            this.BackColor = AccountsGlobals.FormColor;
            lstitem = (new CategoryController  ().GetCategories  (0));
            Grd.DataSource = lstitem;
            FormatGrid();
            LoadTempGrid();             
        }

        private void FormatGrid()
        {
            try
            {                
                Grd.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["ID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["ID"].Width = 50;

               
                Grd.Columns["Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Name"].Width = 120;

                Grd.Columns["DepartName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["DepartName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["DepartName"].Width = 110;

                Grd.Columns["IsService"].Visible = false;
                Grd.Columns["DepartID"].Visible = false;

                if (Grd.Rows.Count > 0)
                {
                    Grd.Rows[0].Selected = true;
                }

                AccountsGlobals .ExtendCol(ref Grd, "Name");
                Grd.Columns["Name"].HeaderText = "Name";            

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         
        private bool FilterBarFun(Category  p)
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
                        case "[Id]":                            
                            res =res +" "+ Convert.ToString ( (p.Id  .ToString()  == (fieldValue).ToString ()));
                            break;
                        case "[Name]":                            
                            res = res + " " + Convert.ToString((p.Name   .ToString().ToUpper().StartsWith(fieldValue.ToString ().ToUpper())));
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

        public void SetParaOut()
        {
            try
            {
                if (Grd.SelectedRows.Count > 0)
                {
                    // item = new CategoryControlle ().GetCategories (Convert.ToInt32((Grd.Rows[Grd.SelectedRows[0].Index].Cells["Id"].Value.ToString())))[0];
                    int RowIndex = Grd.CurrentRow.Index;
                    item = new CategoryController().GetSingleCategories(Convert.ToInt32((Grd.Rows[RowIndex].Cells["ID"].Value.ToString())));
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetParaOut",MessageBoxButtons.OK,MessageBoxIcon.Error );
            }
        }

        /// <summary>
        //No need to change this portion.
        /// </summary>
        
        private void LoadTempGrid()
        {
            try
            {

              //  grdTemp.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Navy;
                grdTemp.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
                grdTemp.ColumnHeadersDefaultCellStyle.Font = new Font(grdTemp.Font, FontStyle.Bold);
                grdTemp.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                grdTemp.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdTemp.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                grdTemp.GridColor = System.Drawing.Color.Black;

                grdTemp.MultiSelect = false;

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
                    grdTemp.Columns.Add(newCol);

                }
                grdTemp.Rows.Add(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadTempGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                MessageBox.Show(ex.Message, "SchItem FormatCondition", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }                                  
        private void dgv1_EditValueChanged(object sender, EventArgs e)
        {
            if (grdTemp.filterCondition.Length != 0)
            {
                Common.Globals.condition = grdTemp.filterCondition;
                FormatCondition();
                subList = lstitem.FindAll(FilterBarFun);

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
        private void SchItems_KeyDown(object sender, KeyEventArgs e)
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
                MessageBox.Show(ex.Message, "SchItem_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }               
        private void Grd_DoubleClick(object sender, EventArgs e)
        {
            SetParaOut();            
        }
        private void tsBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tsBtnSelect_Click(object sender, EventArgs e)
        {
            SetParaOut();
        }

        private void tsBtnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsBtnSelect_Click_1(object sender, EventArgs e)
        {
            SetParaOut();
        }

        private void Grd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetParaOut();
            }
        }


        //////////////////////////////////////////////////////////////////
         

      

      
    
     

      
      

      
    }
}

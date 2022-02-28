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
    public partial class SchUsers : Form
    {
        List<User > lstitem = new List<User>();
        List<User> subList = new List<User>();

        public User item = null;
        public Department department = null;

        public SchUsers()
        {
            InitializeComponent();
        }

        private void SchItems_Load(object sender, EventArgs e)
        {
            // To avoid all the annoying error messages, handle the DataError event of the DataGridView:
            Grd.DataError += new DataGridViewDataErrorEventHandler(Grd_DataError); 

            this.BackColor = AccountsGlobals.FormColor;
            lstitem = (new UserController   ().GetUsers (0));
            Grd.DataSource = lstitem;
            FormatGrid();
            LoadTempGrid();             
        }

        void Grd_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // (No need to write anything in here) 
        } 

        private void FormatGrid()
        {
            try
            {
              


                Grd.Columns["UserID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["UserID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["UserID"].Width = 50;

               
                Grd.Columns["UserName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["UserName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["UserName"].Width = 120;
             
                Grd.Columns["UserPassword"].Visible = false;

                Grd.Columns["DepartmentID"].Visible = false;

                Grd.Columns["IsAdmin"].Visible = false;
                Grd.Columns["IsActive"].Visible = false;
                Grd.Columns["Signatures"].Visible = false;


                if (Grd.Rows.Count > 0)
                {
                    Grd.Rows[0].Selected = true;
                }

                AccountsGlobals.ExtendCol(ref Grd, "UserName");
                Grd.Columns["UserName"].HeaderText = "User Name";            

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         
        private bool FilterBarFun(User   p)
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
                        case "[UserID]":                            
                            res =res +" "+ Convert.ToString ( (p.UserID .ToString()  == (fieldValue).ToString ()));
                            break;
                        case "[UserName]":                            
                            res = res + " " + Convert.ToString((p.UserName .ToString().ToUpper().StartsWith(fieldValue.ToString ().ToUpper())));
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
                    item = new UserController  ().GetUsers  (Convert.ToInt32((Grd.Rows[Grd.SelectedRows[0].Index].Cells["UserID"].Value.ToString())))[0];
                   
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

        #region Auto Formation

        private void LoadTempGrid()
        {
            try
            {

                grdTemp.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Navy;
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


        //////////////////////////////////////////////////////////////////

        #endregion

        private void grdTemp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

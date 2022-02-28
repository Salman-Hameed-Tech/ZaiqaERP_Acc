using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonController;
using Common;

namespace Accounts.SchForms
{
    public partial class SchClaim : Form
    {
        List<ClaimInvoice> lstitem = new List<ClaimInvoice>();
        List<ClaimInvoice> subList = new List<ClaimInvoice>();
        public string where = "";
        public ClaimInvoice item = null;

        public ClaimInvoiceType  type;

        public SchClaim()
        {
            InitializeComponent();
        }

        private void SchItems_Load(object sender, EventArgs e)
        {
            this.BackColor = AccountsGlobals.FormColor;
            lstitem = (new ClaimInvoiceController ().GetClaims (0,type));
            Grd.DataSource = lstitem;

            //////////////////////////////////////////////////////////////
            FormatGrid();
            LoadTempGrid();             
            //////////////////////////////////////////////////////////////
        }

        private void FormatGrid()
        {
            try
            {                
                Grd.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["ID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["ID"].Width = 50;

               
                Grd.Columns["Dated"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Dated"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Dated"].Width = 120;

             

                Grd.Columns["Party"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Party"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Party"].Width = 200;

              

              
              
                Grd.Columns["Remarks"].Visible = false;               
                Grd.Columns["CreatedBy"].Visible = false;
                



                

                if (Grd.Rows.Count > 0)
                {
                    Grd.Rows[0].Selected = true;
                }

                AccountsGlobals.ExtendCol(ref Grd, "Party");
                           

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool FilterBarFun(ClaimInvoice p)
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
                            res =res +" "+ Convert.ToString ( (p.ID .ToString()  == (fieldValue).ToString ()));
                            break;
                        case "[Dated]":                            
                            res = res + " " + Convert.ToString((p.Dated  .ToString().ToUpper().StartsWith(fieldValue.ToString ().ToUpper())));
                            break;
                        case "[Party]":                            
                            res = res + " " + Convert.ToString((p.Party    .ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
                            break;
                     
                        case "[TotalAmt]":                            
                            res = res + " " + Convert.ToString(p.TotalAmt  .ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper()));
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
                    item = new ClaimInvoiceController ().GetClaims (Convert.ToInt32((Grd.Rows[Grd.SelectedRows[0].Index].Cells["ID"].Value.ToString())), type )[0];
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetParaOut",MessageBoxButtons.OK,MessageBoxIcon.Error );
            }
        }

        #region

        /// <summary>
        //No need to change this portion.        
        private void LoadTempGrid()
        {
            try
            {

                grdTemp.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
                grdTemp.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                grdTemp.ColumnHeadersDefaultCellStyle.Font = new Font(grdTemp.Font, FontStyle.Bold);
                grdTemp.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                grdTemp.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdTemp.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                grdTemp.GridColor = Color.Black;

                grdTemp.MultiSelect = false;

                DataGridViewCell TextCell = new DataGridViewTextBoxCell();
                DataGridViewColumn newCol = new DataGridViewColumn();

                for (int i = 0; i < Grd.Columns .Count; i++)
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

        private void Grd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (Grd.SelectedRows[0].Index == 0)
                {
                    if (e.KeyCode == Keys.Up)
                    {
                        SendKeys.Send("\t");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "grd_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdTemp_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    SendKeys.Send("\t");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GrdTemp_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tsBtnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsBtnSelect_Click_1(object sender, EventArgs e)
        {
            SetParaOut();
        }
        /// </summary>
        //////////////////////////////////////////////////////////////////


        #endregion


    }
}

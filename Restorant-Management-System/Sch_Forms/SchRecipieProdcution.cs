using Accounts;
using Common;
using CommonController;
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
    public partial class SchRecipieProdcution : Form
    {
        List<ProductionRecipie> lstitem = new List<ProductionRecipie>();
        List<ProductionRecipie> subList = new List<ProductionRecipie>();
        public string where = "";
        public ProductionRecipie item = null;

        public SchRecipieProdcution()
        {
            InitializeComponent();
        }

        private void SchRecipieProdcution_Load(object sender, EventArgs e)
        {
          
            lstitem = (new RecipieController().GetInvoices(0,Globals.BranchID));
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

                Grd.Columns["Dated"].HeaderText = "Date";
                Grd.Columns["Dated"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Dated"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Dated"].Width = 100;

                Grd.Columns["MItemID"].HeaderText = "Marinated ItemID";
                Grd.Columns["MItemID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Grd.Columns["MItemID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["MItemID"].Width = 90;

                Grd.Columns["MItemName"].HeaderText = "Marinated Item";
                Grd.Columns["MItemName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Grd.Columns["MItemName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["MItemName"].Width = 300;

                Grd.Columns["MQuantity"].HeaderText = "Quantity";
                Grd.Columns["MQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Grd.Columns["MQuantity"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["MQuantity"].Width = 100;

                Grd.Columns["TotalAmt"].HeaderText = "Total";
                Grd.Columns["TotalAmt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Grd.Columns["TotalAmt"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["TotalAmt"].Width = 100;


          
                Grd.Columns["BranchID"].Visible = false;

                if (Grd.Rows.Count > 0)
                {
                    Grd.Rows[0].Selected = true;
                }

                AccountsGlobals.ExtendCol(ref Grd, "MItemName");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool FilterBarFun(ProductionRecipie p)
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
                            res = res + " " + Convert.ToString((p.ID.ToString() == (fieldValue).ToString()));
                            break;
                        case "[Dated]":
                            res = res + " " + Convert.ToString((p.Dated.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
                            break;
                        case "[MItemID]":
                            res = res + " " + Convert.ToString((p.MItemID.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
                            break;
                        case "[MItemName]":
                            res = res + " " + Convert.ToString((p.MItemName.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
                            break;
                        case "[MQuantity]":
                            res = res + " " + Convert.ToString((p.MQuantity.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
                            break;
                        case "[TotalAmt]":
                            res = res + " " + Convert.ToString(p.TotalAmt.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper()));
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
                    item = new RecipieController().GetInvoices(Convert.ToInt32((Grd.Rows[Grd.SelectedRows[0].Index].Cells["ID"].Value.ToString())), Globals.BranchID)[0];
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetParaOut", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void grdTemp_EditValueChanged(object sender, EventArgs e)
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

        private void Grd_SelectionChanged(object sender, EventArgs e)
        {
            if (Grd.CurrentRow != null)
            {
                int purID = Convert.ToInt32(Grd.Rows[Grd.CurrentRow.Index].Cells["ID"].Value);
                ProductionRecipie sale = new RecipieController().GetInvoices(purID, Globals.BranchID)[0];
                GrdDetail.DataSource = sale.productionRecipieLines;

                GrdDetail.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
                GrdDetail.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                GrdDetail.ColumnHeadersDefaultCellStyle.Font = new Font(grdTemp.Font, FontStyle.Bold);
                GrdDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                GrdDetail.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                GrdDetail.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                GrdDetail.GridColor = Color.Black;


                GrdDetail.Columns["ItemName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdDetail.Columns["ItemName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                GrdDetail.Columns["ItemName"].Width = 220;

                


                GrdDetail.Columns["Quantity"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdDetail.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                GrdDetail.Columns["Quantity"].Width = 100;

                GrdDetail.Columns["Rate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdDetail.Columns["Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                GrdDetail.Columns["Rate"].Width = 100;


                GrdDetail.Columns["Total"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdDetail.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                GrdDetail.Columns["Total"].Width = 100;


                GrdDetail.Columns["ItemID"].Visible = false;
                GrdDetail.Columns["SrNo"].Visible = false;
                GrdDetail.Columns["IsDeleted"].Visible = false;
                GrdDetail.Columns["CsQty"].Visible = false;
               

                GrdDetail.ExtendCol("ItemName");

            }
        }

        private void Grd_DoubleClick(object sender, EventArgs e)
        {
            SetParaOut();
        }
    }
}

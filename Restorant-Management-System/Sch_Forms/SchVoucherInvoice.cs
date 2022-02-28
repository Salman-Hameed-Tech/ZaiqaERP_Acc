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
using CategoryControlle;
using Common;


namespace Restorant_Management_System.Sch_Forms
{
    public partial class SchVoucherInvoice : Form
    {
        List<VoucherInvoice> lstitem = new List<VoucherInvoice>();
        List<VoucherInvoice> subList = new List<VoucherInvoice>();
        public string where = "";
        public List<VoucherInvoice> items = null;

        public TransactionFlow flow;
        public string accountNo;

        public SchVoucherInvoice()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                Grd.Columns["Party"].Width = 170;

                Grd.Columns["Purpose"].HeaderText = "Purpose";
                Grd.Columns["Purpose"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Purpose"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Purpose"].Width = 250;


                Grd.Columns["RemainingAmt"].HeaderText = "Rem.Amt";
                Grd.Columns["RemainingAmt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["RemainingAmt"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["RemainingAmt"].Width = 80;


                Grd.Columns["Select"].HeaderText = "Select";
                Grd.Columns["Select"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Select"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Select"].Width = 80;

                if (Grd.Rows.Count > 0)
                {
                    Grd.Rows[0].Selected = true;
                }

                AccountsGlobals.ExtendCol(ref Grd, "TotalAmt");
                Grd.Columns["TotalAmt"].HeaderText = "Total";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool FilterBarFun(VoucherInvoice p)
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
                        case "[Party]":
                            res = res + " " + Convert.ToString((p.Party.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
                            break;
                        case "[Purpose]":
                            res = res + " " + Convert.ToString((p.Purpose.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
                            break;
                        case "[TotalAmt]":
                            res = res + " " + Convert.ToString(p.TotalAmt.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper()));
                            break;
                        case "[RemainingAmt]":
                            res = res + " " + Convert.ToString(p.RemainingAmt.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper()));
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
                //int CurrentRow = Grd.SelectedRows[0].Index;
                grdTemp.Focus();

                items = new List<VoucherInvoice>();
                for (int i = 0; i < Grd.Rows.Count; i++)
                {
                    //if (Convert.ToBoolean(Grd.Rows[i].Cells["Select"].Value))
                    if (true)
                    {
                        VoucherInvoice item = new VoucherInvoice(Convert.ToInt32(Grd.Rows[i].Cells["ID"].Value), Convert.ToDecimal(Grd.Rows[i].Cells["RemainingAmt"].Value));
                        items.Add(item);
                    }

                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetParaOut", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
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
        private void SchVoucherInvoice_Load(object sender, EventArgs e)
        {
            this.Font = AccountsGlobals.Font;
            this.BackColor = AccountsGlobals.FormColor;
            lstitem = (new VoucherController().GetInvoices(accountNo, flow));
            Grd.DataSource = lstitem;

            //////////////////////////////////////////////////////////////
            FormatGrid();
            LoadTempGrid();
            //////////////////////////////////////////////////////////////
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

        private void btnTotal_Click(object sender, EventArgs e)
        {
            try
            {
                decimal total = 0;
                for (int i = 0; i < Grd.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(Grd.Rows[i].Cells["Select"].Value))
                    {
                        total += Convert.ToDecimal(Grd.Rows[i].Cells["RemainingAmt"].Value);
                    }
                }
                txtTotal.Text = total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnTotal_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SetParaOut();
        }

        private void Grd_DoubleClick(object sender, EventArgs e)
        {
            SetParaOut();
        }
    }
}

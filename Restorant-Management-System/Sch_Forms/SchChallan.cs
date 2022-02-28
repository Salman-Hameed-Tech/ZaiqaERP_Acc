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
using CategoryControlle;

namespace Restorant_Management_System.Sch_Forms
{
    public partial class SchChallan : Form
    {
        public Challan item = null;
        private List<Challan> purchases = new List<Challan>();
        private List<Challan> subList = new List<Challan>();
        public string where = "";
        private Challan selectedPurchase;

        public int ID;

        public Challan SelectedPurchase
        {
            get { return selectedPurchase; }
            set { selectedPurchase = value; }
        }
        public SchChallan()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
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
        public void SetValues()
        {
          
            if (Grd.Rows.Count > 0)
            {

                item = new Challan();
             
                item.ID = Convert.ToInt32(Grd.CurrentRow.Cells["ID"].Value);
             
                item.FromDate = Convert.ToDateTime(Grd.CurrentRow.Cells["FromDate"].Value);

                item.BranchName = Convert.ToString(Grd.CurrentRow.Cells["BranchName"].Value);
             


                item.ChallanLines = new ChallanController().GetChalan(item.ID);


                this.Close();
            }

            }
        private void FormatGrid()
        {
            try
            {
                Grd.Columns["ID"].HeaderText = "ID";
                Grd.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["ID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["ID"].Width = 60;

                Grd.Columns["FromDate"].HeaderText = "Date";
                Grd.Columns["FromDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["FromDate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["FromDate"].Width = 80;

                Grd.Columns["BranchName"].HeaderText = "Sender Branch";
                Grd.Columns["BranchName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["BranchName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["BranchName"].Width = 160;

                Grd.Columns["ReceiverBranch"].HeaderText = "Receiver Branch";
                Grd.Columns["ReceiverBranch"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["ReceiverBranch"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["ReceiverBranch"].Width = 160;

                Grd.Columns["Username"].HeaderText = "Created By ";
                Grd.Columns["Username"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Username"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Username"].Width = 150;

               

                Grd.Columns["BranchID"].Visible = false;
                // Grd.Columns["TrackingID"].Visible = false;IsReceived IsDeleted
                Grd.Columns["TrackingID"].Visible = false;
                Grd.Columns["CourierAccount"].Visible = false;
                Grd.Columns["Purate"].Visible = false;
                Grd.Columns["CounterID"].Visible = false;
                Grd.Columns["CounterName"].Visible = false;
                Grd.Columns["ToDate"].Visible = false;
                Grd.Columns["ItemID"].Visible = false;
                Grd.Columns["Barcode"].Visible = false;
                Grd.Columns["ItemName"].Visible = false;
                Grd.Columns["Quantity"].Visible = false;
                Grd.Columns["serialno"].Visible = false;
                Grd.Columns["stock"].Visible = false;
                Grd.Columns["isDeleted"].Visible = false;
                Grd.Columns["EntryBranchID"].Visible = false;
                Grd.Columns["IsReceived"].Visible = false;
                Grd.Columns["IsDeleted"].Visible = false;
                Grd.Columns["IsTarnsition"].Visible = false;

                if (Grd.Rows.Count > 0)
                {
                    Grd.Rows[0].Selected = true;
                }

                AccountsGlobals.ExtendCol(ref Grd, "Remarks");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

            private bool FilterPurchases(Challan p)
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
                                res = res + " " + Convert.ToString((p.ID.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
                                break;
                            case "[FromDate]":
                                res = res + " " + Convert.ToString((p.FromDate.ToString().ToUpper().StartsWith(fieldValue.ToString().ToUpper())));
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
                    MessageBox.Show(ex.Message, "SchChallan FilterChallan", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return false;
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
            private void SchChallan_Load(object sender, EventArgs e)
            {
                try
                {
                    //Get Purchase List.

                    purchases = (new ChallanController().GetData(0, where));
                    Grd.DataSource = purchases;
                    //Set Data Source for Grid.
                    purchases = purchases.OrderByDescending(x => x.ID).ToList();
                    Grd.DataSource = purchases;

                    FormatGrid();
                    LoadTempGrid();
                    if (purchases.Count <= 0)
                    {
                        Grd.Visible = false;
                    }


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "SchChallan Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void grdTemp_EditValueChanged(object sender, EventArgs e)
            {
                if (grdTemp.filterCondition.Length != 0)
                {
                    Common.Globals.condition = grdTemp.filterCondition;
                    FormatCondition();
                    subList = purchases.FindAll(FilterPurchases);

                    Grd.DataSource = null;
                    Grd.DataSource = subList;
                    FormatGrid();

                }
                else
                {
                    Grd.DataSource = purchases;
                    FormatGrid();
                }
            }

            private void Grd_DoubleClick(object sender, EventArgs e)
            {
                SetValues();
            }

            private void btnSelect_Click(object sender, EventArgs e)
            {
                SetValues();
            }

        private void Grd_SelectionChanged(object sender, EventArgs e)
        {
          
          
            
        }
    }
 }


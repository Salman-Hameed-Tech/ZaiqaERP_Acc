using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using CommonController;
using Accounts.Forms;

namespace Accounts.SchForms
{
    public partial class SchPartywiseOStock : Form
    {
        public SchPartywiseOStock()
        {
            InitializeComponent();
        }

        public OpeningStockLine os=null;

        public List<OpeningStockLine> lstSelectedOS;

        private List<OpeningStockLine> lstitem = new List<OpeningStockLine>();

        private void SchPartywiseOStock_Load(object sender, EventArgs e)
        {
            this.BackColor = AccountsGlobals.FormColor;

            lstitem = (new OpeningStockController().LoadGrid());
           
            Grd.DataSource = lstitem;
            Grd.Columns["ItemID"].Visible = false;
            Grd.Columns["ItemName"].Visible = false;
            Grd.Columns["Quantity"].Visible = false;
            Grd.Columns["SrNo"].Visible = false;
            AccountsGlobals.ExtendCol(ref Grd, "PartyName");

            //FormatGrid();
        }

        private bool FormatGrid()
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

                //Col 1
                //////////////////////////////////////////////////////////////////////////////////////////////////   
                DataGridViewColumn newCol = new DataGridViewColumn(); // add a column to the grid                 
                newCol.CellTemplate = IntCell;
                newCol.HeaderText = "ID";
                newCol.Name = "ID";

                newCol.CellTemplate = IntCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Width = 60;
                Grd.Columns.Add(newCol);

                //Col 2
                //////////////////////////////////////////////////////////////////////////////////////////////////                
             
                //Col3
                ///////////////////////////////////////////////////////////////////////////////////
                newCol = new DataGridViewColumn(); // add a column to the grid                 
                newCol.HeaderText = "Party ID";
                newCol.Name = "PartyID";

                newCol.CellTemplate = IntCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Width = 60;
                Grd.Columns.Add(newCol);

                //Col 4
                //////////////////////////////////////////////////////////////////////////////////////////////////                
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Party Name";
                newCol.Name = "PartyName";

                newCol.CellTemplate = TextCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;
                newCol.Width = 250;
                Grd.Columns.Add(newCol);

                //Col5
                ///////////////////////////////////////////////////////////////////////////////////
               

                Grd.Columns["ItemID"].Visible = false;
                Grd.Columns["ItemName"].Visible = false;
                Grd.Columns["Quantity"].Visible = false;

                if (Grd.Rows.Count > 0)
                {
                    Grd.Rows[0].Selected = true;
                }

              
                AccountsGlobals.ExtendCol(ref Grd, "PartyName");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SetParaOut();
        }

        public void SetParaOut()
        {
            try
            {
                if (Grd.Rows.Count > 0)
                {
                    lstSelectedOS = new List<OpeningStockLine>();
                    lstSelectedOS = new OpeningStockController().GetSingleOpeningStock( Convert.ToDateTime(Grd.Rows[Grd.CurrentRow.Index    ].Cells["Dated"].Value.ToString()));
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetParaOut", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Grd_DoubleClick(object sender, EventArgs e)
        {
            SetParaOut();
        }
    }
}
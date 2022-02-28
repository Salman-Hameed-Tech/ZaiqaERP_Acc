using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace Restorant_Management_System.Sch_Forms
{
    public partial class SchEngine : Form
    {
        public SchEngine()
        {
            InitializeComponent();
        }

        private void SchEngine_Load(object sender, EventArgs e)
        {
            FormatGrid();
            LoadTempGrid();
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
                    newCol.DefaultCellStyle.Alignment = Grd.Columns[i].DefaultCellStyle.Alignment;
                    newCol.HeaderCell.Style.Alignment = Grd.Columns[i].HeaderCell.Style.Alignment;
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
        private void FormatGrid()
        {
            try
            {


                Grd.Columns["EngineNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["EngineNo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["EngineNo"].Width = 150;

                Grd.Columns["ChasesNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Grd.Columns["ChasesNo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["ChasesNo"].Width = 110;

 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

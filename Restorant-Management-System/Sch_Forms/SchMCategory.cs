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

namespace RMS.Search_Forms
{
    public partial class SchMCategory : Form
    {
        private List<MCategory> categories = new List<MCategory>();
        private List<MCategory> subcategories = new List<MCategory>();

        private MCategory selectedMcctegory;
        public MCategory SelectedMCategory
        {
            get { return selectedMcctegory; }
            set { selectedMcctegory = value; }
        }

        public SchMCategory()
        {
            InitializeComponent();
        }

        private void SchMCategory_Load(object sender, EventArgs e)
        {
            try
            {
                categories = new MCategoryController().GetMCategories();
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SchLocation_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadGrid()
        {
            try
            {

                if (subcategories.Count > 0)
                {
                    Grd.DataSource = subcategories;
                }
                else
                    Grd.DataSource = categories;

                //Set First Column.
                Grd.Columns["MCategoryID"].HeaderText = "Category ID";

                Grd.Columns["MCategoryID"].Width = 80;
                //Set Second Column.
                Grd.Columns["MCategoryName"].HeaderText = "Category Name";

                Grd.Columns["MCategoryName"].Width = 200;

                //Set Second Column.
                Grd.Columns["Printer"].HeaderText = "Printer";

                Grd.Columns["Printer"].Width = 200;


                AccountsGlobals.ExtendCol(ref Grd, "MCategoryName");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SchAccounts LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private Boolean SelectValue()
        {
            try
            {
                if (Grd.SelectedCells.Count == 0)
                    return false;
                else
                {
                    if (subcategories.Count > 0)
                    {
                        this.SelectedMCategory = subcategories[Grd.CurrentRow.Index];
                    }
                    else
                        this.SelectedMCategory = categories[Grd.CurrentRow.Index];

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SchGodown SelectValue", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool FilterAccounts(MCategory a)
        {
            return a.MCategoryName.ToUpper().Contains(this.txtCategoryName.Text.ToUpper());
        }

        private void txtCategoryName_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (this.txtCategoryName.Text.Trim().Length == 0)
                {
                    subcategories.Clear();
                    LoadGrid();
                }
                else
                {
                    subcategories = categories.FindAll(FilterAccounts);
                    if (subcategories.Count > 0)
                    {
                        LoadGrid();
                    }
                    else
                    {
                        this.Grd.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " txtCategoryName_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Grd_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                SelectValue();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "tsBtnSelect_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Grd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SelectValue();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "tsBtnSelect_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsBtnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                SelectValue();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "tsBtnSelect_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

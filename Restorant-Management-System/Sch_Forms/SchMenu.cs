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
    public partial class SchMenu : Form
    {
        private List<Menus> menus = new List<Menus>();
        private List<Menus> subMenus = new List<Menus>();

        private Menus selectedMenu;
        public Menus SelectedMenu
        {
            get { return selectedMenu; }
            set { selectedMenu = value; }
        }
        public SchMenu()
        {
            InitializeComponent();
        }

        private void SchMenu_Load(object sender, EventArgs e)
        {
            try
            {
                menus = new MenusController().LoadGrid(0);
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

                if (subMenus.Count > 0)
                {
                    Grd.DataSource = subMenus;
                }
                else
                    Grd.DataSource = menus;

                //Set First Column.
                Grd.Columns["MenuID"].HeaderText = "Menu ID";
                Grd.Columns["MenuID"].Width = 60;
                //Set Second Column.
                Grd.Columns["MenuName"].HeaderText = "Menu Name";
                Grd.Columns["MenuName"].Width = 200;

                Grd.Columns["MCategoryName"].HeaderText = "Category Name";
                Grd.Columns["MCategoryName"].Width = 200;

                Grd.Columns["UrduName"].HeaderText = "Urdu Name";
                Grd.Columns["UrduName"].Width = 200;

                //Set Second Column.
                Grd.Columns["Rate"].HeaderText = "Rate";
                Grd.Columns["Rate"].Width = 80;

                Grd.Columns["UrduName"].Visible = false;

                AccountsGlobals.ExtendCol(ref Grd, "MenuName");


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
                    if (subMenus.Count > 0)
                    {
                        this.SelectedMenu = subMenus[Grd.CurrentRow.Index];
                    }
                    else
                        this.SelectedMenu = menus[Grd.CurrentRow.Index];

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SchGodown SelectValue", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool FilterAccounts(Menus a)
        {
            return a.MenuName.ToUpper().Contains(this.txtMenuName.Text.ToUpper());
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

        private void txtMenuName_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (this.txtMenuName.Text.Trim().Length == 0)
                {
                    subMenus.Clear();
                    LoadGrid();
                }
                else
                {
                    subMenus = menus.FindAll(FilterAccounts);
                    if (subMenus.Count > 0)
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
    }
}

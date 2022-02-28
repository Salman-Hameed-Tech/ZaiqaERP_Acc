using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounts.Forms;
using CategoryControlle;
using Common;

namespace Accounts.SchForms
{
    public partial class SchItems : Form
    {
        List<Common.SchItems > lstitem = new List<Common.SchItems>();
        List<Common.SchItems> subList = new List<Common.SchItems>();
        public List<Common.Item> subList1 = new List<Common.Item>();

        public Item item = null;
        public int storeID = 0;
        public string partyid = "";

        public int BranchId = 0;
        public LoadItemsFor loadFor = LoadItemsFor.All;
        public   string condition = "";
        public string isFinished = "";
        public bool isMarination;

        private Item selecteditem;
        public Item SelectedItem
        {
            get { return selecteditem; }
            set { selecteditem = value; }
        }


        public SchItems()
        {
            InitializeComponent();
        }

        private void SchItems_Load(object sender, EventArgs e)
        {
          
            if (isMarination == false)
            {
                lstitem = (new SchItemController().LoadGrid(isFinished,condition));
            }
            else
            {
                lstitem = new ItemController().GetMarinatedIems(condition);
            }
            Grd.DataSource = lstitem;
            FormatGrid();
            LoadTempGrid();

            //grdTemp.Rows[0].Cells["ProductName"].Selected = true;
                        
        }

        private void FormatGrid()
        {
            try
            {
               

                Grd.Columns["ItemID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["ItemID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                Grd.Columns["ItemID"].Width = 50;


             

                //Grd.Columns["Manufacturer"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                //Grd.Columns["Manufacturer"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //Grd.Columns["Manufacturer"].Width = 110;

                Grd.Columns["ProductName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Grd.Columns["ProductName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["ProductName"].Width = 110;

                Grd.Columns["Design"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Grd.Columns["Design"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Grd.Columns["Design"].Width = 110;




               
                if (loadFor == LoadItemsFor.DeliveryOrder)
                {
                    Grd.Columns["ProductName"].Visible = false;
                   // AccountsGlobals .ExtendCol(ref Grd, "ProductName");

                }
                if (loadFor == LoadItemsFor.All)
                {
                    Grd.Columns["ProductName"].Visible = true;
                   // AccountsGlobals .ExtendCol(ref Grd, "ProductName");
                }

                if (Grd.Rows.Count > 0)
                {
                    Grd.Rows[0].Selected = true;
                }
                if (isMarination)
                {

                    Grd.Columns["Design"].Visible = false;
                    
                    Grd.Columns["Companyname"].Visible = false;
                    Grd.Columns["Categoryname"].Visible = false;
                    Grd.Columns["Size"].Visible = false;
                    
                }
                Grd.Columns["VSelect1"].Visible = false;
                Grd.Columns["IsMarinated"].Visible = false;
                Grd.Columns["IsBakery"].Visible = false;
                Grd.Columns["Barcode"].Visible = false;

                AccountsGlobals.ExtendCol(ref Grd, "ProductName");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //private void LoadTempGrid()
        //{
        //    try
        //    {
        //        grdTemp.Rows.Add(1);

        

        //        grdTemp.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
        //        grdTemp.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        //        grdTemp.ColumnHeadersDefaultCellStyle.Font = new Font(grdTemp.Font, FontStyle.Bold);
        //        grdTemp.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
        //        grdTemp.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        //        grdTemp.CellBorderStyle = DataGridViewCellBorderStyle.Single;
        //        grdTemp.GridColor = Color.Black;

        //        grdTemp.MultiSelect = false;


        //        grdTemp.Columns["ItemID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //        grdTemp.Columns["ItemID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //        grdTemp.Columns["ItemID"].HeaderText = "Item ID";
        //        grdTemp.Columns["ItemID"].Width = 50;


               
        //        grdTemp.Columns["Manufacturer"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //        grdTemp.Columns["Manufacturer"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //        grdTemp.Columns["Manufacturer"].Width = 110;

        //        grdTemp.Columns["ProductName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //        grdTemp.Columns["ProductName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //        grdTemp.Columns["ProductName"].Width = 110;

        //        grdTemp.Columns["Type"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //        grdTemp.Columns["Type"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //        grdTemp.Columns["Type"].Width = 110;


        //        grdTemp.Columns["Origin"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //        grdTemp.Columns["Origin"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //        grdTemp.Columns["Origin"].Width = 110;

        //        grdTemp.Columns["Packing"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //        grdTemp.Columns["Packing"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //        grdTemp.Columns["Packing"].Width = 110;


        //        AccountsGlobals .ExtendCol(ref grdTemp, "CategoryName");
               
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "LoadTempGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
           
        //}


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
                    newCol.DefaultCellStyle.Alignment = Grd.Columns[i].DefaultCellStyle .Alignment ;
                    newCol.HeaderCell.Style.Alignment = Grd.Columns[i].HeaderCell .Style.Alignment ;
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
        private bool FilterBarFun(Common.SchItems  p)
        {
            try
            {
                String[] st = new String[1];
                st[0] = "AND";
                string s = Common.Item.condition;
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
                        case "[ItemID]":
                            res = res + " " + Convert.ToString((p.ItemID.ToString().ToUpper().Contains(fieldValue.ToString().ToUpper())));
                            break;
                        case "[Barcode]":
                            res = res + " " + Convert.ToString((p.Barcode.ToString().ToUpper().Contains(fieldValue.ToString().ToUpper())));
                            break;
                        case "[Categoryname]":
                            res = res + " " + Convert.ToString((p.Categoryname.ToString().ToUpper().Contains(fieldValue.ToString().ToUpper())));
                            break;
                        case "[Companyname]":
                            res = res + " " + Convert.ToString((p.Companyname.ToString().ToUpper().Contains(fieldValue.ToString().ToUpper())));
                            break;
                        case "[Productname]":
                            res = res + " " + Convert.ToString((p.Productname.ToString().ToUpper().Contains(fieldValue.ToString().ToUpper())));
                            break;
                        case "[Design]":
                            res = res + " " + Convert.ToString((p.Design.ToString().ToUpper().Contains(fieldValue.ToString().ToUpper())));
                            break;
                        case "[Size]":
                            res = res + " " + Convert.ToString(p.Size.ToString().ToUpper().Contains(fieldValue.ToString().ToUpper()));
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

        private void FormatCondition()
        {
            try
            {
                String oldcon = Common.Item.condition;
                String newCon = "";

                while (oldcon.IndexOf(" Like ") > 0)
                {
                    newCon = oldcon.Substring(oldcon.IndexOf(" Like ") + " Like ".Length + 1, oldcon.IndexOf("*'") - (oldcon.IndexOf(" Like ") + " Like ".Length + 1));
                    oldcon = oldcon.Replace("Like '" + newCon + "*'", "= " + newCon);
                }

                 Common.Item.condition = oldcon;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "SchItem FormatCondition", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

       
        private void dgv1_EditValueChanged(object sender, EventArgs e)
        {
            if (grdTemp.filterCondition  .Length != 0)
            {                
                Common.Item.condition = grdTemp.filterCondition ;
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

        public void SetParaOut()
        {
            try
            {
                if (Grd.SelectedRows.Count > 0)
                {
                    if (loadFor == LoadItemsFor.All)
                    {
                       subList1 = (new ItemController().EditModule(Convert.ToInt32((Grd.Rows[Grd.SelectedRows[0].Index].Cells["ItemID"].Value)), Globals.BranchID));                  
                    }           
                }

            
                
               this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetParaOut",MessageBoxButtons.OK,MessageBoxIcon.Error );
            }
        }
        public void Set()
        {
            try
            {
                if (Grd.SelectedRows.Count > 0)
                {
                    if (loadFor == LoadItemsFor.All)
                    {
                        //subList1 = (new ItemController().EditModule(Convert.ToInt32((Grd.Rows[Grd.SelectedRows[0].Index].Cells["ItemID"].Value))));
                         item = new ItemController().GetSingleItem(Convert.ToInt32((Grd.Rows[Grd.SelectedRows[0].Index].Cells["ItemID"].Value.ToString())), StockType.Pack,storeID);

                    }
                    //if (loadFor == LoadItemsFor.DeliveryOrder)
                    //{
                    //    item = new Item(Convert.ToInt32(Grd.Rows[Grd.SelectedRows[0].Index].Cells["ItemID"].Value), Convert.ToInt32(Grd.Rows[Grd.SelectedRows[0].Index].Cells["PackID"].Value));
                    //}
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

        private void tsBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsBtnSelect_Click(object sender, EventArgs e)
        {
            SetParaOut();
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
                MessageBox.Show(ex.Message, "grdTemp_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetRowNo(ref DGV .DGV grd)
        {
            try
            {                              
                for (int i = 0; i < grd.Rows.Count; i++)
                {
                    grd.Rows[i].HeaderCell.Value = (i+ 1).ToString();                   
                }
            }
            catch (Exception ex)
            {
                MessageBox .Show (ex.Message ,"SetRowNo",MessageBoxButtons .OK ,MessageBoxIcon.Error );
            }
        }

        private void Grd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SetParaOut();
                }
                if (Grd.SelectedRows [0].Index  == 0)
                {
                    //System.Threading.Thread.Sleep(2000);
                   
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

       
     
     
         

      

      
    
     

      
      

      
    }
}

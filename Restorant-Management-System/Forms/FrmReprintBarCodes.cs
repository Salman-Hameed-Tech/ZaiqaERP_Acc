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
using CategoryControlle;
using Accounts.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Drawing.Imaging;
using BarcodeStickerPrinter;


namespace Restorant_Management_System.Forms
{
    public partial class FrmReprintBarCodes : Form
    {

        decimal Qty = 0;
        List<BarcodeStickerPrinter.Item> items;
    
        public Purchase p = new Purchase();

        List<Common.Item> rePrintItems;
        List<PurchaseLine> rePrintPurItems;
        Report_Forms.FrmReportViewer frmViewer = new Report_Forms.FrmReportViewer();
        //DataSet ds = new DataSet();
        Common.Data_Sets.DSPurchaseRegister ds = new Common.Data_Sets.DSPurchaseRegister();
        private int count;

        public FrmReprintBarCodes()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool ValidateControls()
        {
            try
            {
                if (this.txtItemID.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Please Enter Item ID.", "Enter Item ID...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtItemID.Focus();
                    return false;
                }
                else if (this.txtQuantity.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Please Enter Quantity.", "Enter Quantity...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtQuantity.Focus();
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmRePrintBarCodes validateControls", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void PopulateGrid()
        {
            //LoadGrid();
            p.PurchaseLines = new List<PurchaseLine>();
            if (count == 0)
            {
                count = 1;
            }
            Common.Item it = new ItemController().GetSingleItem(Convert.ToInt32(this.txtItemID.Text), StockType.Pack, 0);
            PurchaseLine line = new PurchaseLine();
            line.Item = it;
            line.Quantity = Convert.ToDecimal(txtQuantity.Text.Trim());
            p.PurchaseLines.Add(line);

            foreach (PurchaseLine pl in p.PurchaseLines)
            {
                int rowIndex = Grd.Rows.Add();
                //Grd.Rows[rowIndex].Cells["Category"].Value = pl.Category.ToString();
                Grd.Rows[rowIndex].Cells["Item"].Value = pl.Item.ToString();
                Grd.Rows[rowIndex].Cells["ItemID"].Value = pl.Item.ItemID;
                Grd.Rows[rowIndex].Cells["Quantity"].Value = pl.Quantity;
                Grd.Rows[rowIndex].Cells["Printed"].Value = true;
                count++;
            }

          

            this.txtItemID.Focus();
         //   SetRowNo(ref Grd);
            //Grd.AllowAddNew = false;

        }
        private void SetRowNo(ref DGV.DGV grd)
        {
            try
            {
                int count = 0;

                for (int i = 0; i < grd.Rows.Count; i++)
                {
                    if (grd.Rows[i].Visible == true)
                    {
                        grd.Rows[i].HeaderCell.Value = (count + 1).ToString();
                        grd.Rows[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        count++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetRowNo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearControls()
        {
            try
            {

                this.txtItemID.Clear();
                this.txtItemName.Clear();

                this.txtQuantity.Clear();
                this.txtInStock.Clear();
                txtBarCodeCount.Clear();
                Qty = 0;
                this.txtItemID.Focus();

                LoadGrid();
                GetTitles();
              
                //////////////
                //Get Items from purchase which seleted for print
              

                /////////////


              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmRePrint ClearControls", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetTitles()
        {
            DataSet ds = new DataSet();
            ds = new ItemController().GetTitle();
            cmbBarcode.DataSource = ds.Tables[0];
            cmbBarcode.DisplayMember = "CompanyName";
            cmbBarcode.SelectedIndex = -1;
        }

        private void GetItemsForPrint()
        {
            try
            {
                List<Common.Item> itemlist = new List<Common.Item>();
                itemlist = new PurchaseController().GetPrintedItems();
                
                for(int i = 0; i < itemlist.Count; i++)
                {
                    int RowIndex = Grd.Rows.Add();
                    Grd.Rows[RowIndex].Cells["ItemID"].Value = itemlist[i].ItemID.ToString();
                    Grd.Rows[RowIndex].Cells["Item"].Value = itemlist[i].ItemNameb;
                    Grd.Rows[RowIndex].Cells["Quantity"].Value = itemlist[i].OpQty1.ToString();
                    Grd.Rows[RowIndex].Cells["Printed"].Value = true;
                }
                countqty();



            }
            catch(Exception ex)
            {

            }
        }

        private void CalCulateCount()
        {
            try
            {
                int count = 0;

                try
                {
                   
                    for (int i = 0; i < Grd.Rows.Count; i++)
                    {
                        if (Grd.Rows[i].Visible == true)
                        {
                            Grd.Rows[i].HeaderCell.Value = (count + 1).ToString();
                            Grd.Rows[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            this.txtBarCodeCount.Text = count.ToString();
                            count++;
                        }
                    }

                    this.txtBarCodeCount.Text = count.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "FrmRePrintBarCodes CalculateCount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.txtBarCodeCount.Text = count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmRePrintBarCodes CalculateCount", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateControls())
                {

                    PopulateGrid();
                    // CalCulateCount();
                    countqty();
                    this.txtItemID.Clear();
                    this.txtItemName.Clear();
                    this.txtQuantity.Clear();
                    this.txtInStock.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmRePrintBarCodes btnAdd_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool LoadGrid()
        {
            try
            {
                //Set Grid.
                ///////////////////////////////////////////////////////////////////////////////////////////////////
                //AccountsGlobals.SetGridStyle(ref Grd);

                Grd.Columns.Clear();

                Grd.EnableHeadersVisualStyles = false;
                //////////////////////////////////////////////////////////////////////////////////////////////////              
                //Specify which type of cell in this column (DataGridViewTextBoxCell,DataGridViewCheckBoxCell,
                //DataGridViewComboBoxCell,DataGridViewImageColumn,DataGridViewButtonColumn,DataGridViewLinkColumn



                DataGridViewCell TextCell = new DataGridViewTextBoxCell();
                DataGridViewCell DecimalCell = new TNumEditDataGridViewCell(2);
                DataGridViewCell RateCell = new TNumEditDataGridViewCell(4);
                DataGridViewCell IntCell = new TNumEditDataGridViewCell(0);
                DataGridViewCell ChkCell = new DataGridViewCheckBoxCell();

                //Col 1
                //////////////////////////////////////////////////////////////////////////////////////////////////                

                DataGridViewColumn newCol = new DataGridViewColumn(); // add a column to the grid                







             
                //Col 2
                //////////////////////////////////////////////////////////////////////////////////////////////////   

                newCol = new DataGridViewColumn();
                newCol.CellTemplate = IntCell;
                newCol.HeaderText = "Item ID";
                newCol.Name = "ItemID";
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.ReadOnly = true;
                newCol.Width = 40;
                Grd.Columns.Add(newCol);

               

                //Col 2
                //////////////////////////////////////////////////////////////////////////////////////////////////                
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Item";
                newCol.Name = "Item";
                newCol.CellTemplate = TextCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = true;
                newCol.Width = 80;
                Grd.Columns.Add(newCol);






                // To avoid all the annoying error messages, handle the DataError event of the DataGridView:
                Grd.DataError += new DataGridViewDataErrorEventHandler(Grd_DataError);

                //Col 3
                //////////////////////////////////////////////////////////////////////////////////////////////////               
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Qty";
                newCol.Name = "Quantity";
                newCol.CellTemplate = DecimalCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.Visible = true;
                newCol.Width = 70;
                Grd.Columns.Add(newCol);



                //Col 2
                //////////////////////////////////////////////////////////////////////////////////////////////////                
                newCol = new DataGridViewColumn();
                newCol.HeaderText = "Printed";
                newCol.Name = "Printed";
                newCol.CellTemplate = ChkCell;
                newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newCol.ReadOnly = false;
                newCol.Width = 70;
                Grd.Columns.Add(newCol);


                Grd.ExtendCol("Item");


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        void Grd_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // (No need to write anything in here) 
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void PopulateRePrintItems()
        {
            try
            {

                count = 1;
                foreach (Common.Item it in this.rePrintItems)
                {

                    int rowIndex = Grd.Rows.Add();

                    Grd.Rows[rowIndex].Cells["Item"].Value = it.ItemName.ToString();
                    Grd.Rows[rowIndex].Cells["ItemID"].Value = it.ItemID;
                    Grd.Rows[rowIndex].Cells["Quantity"].Value = it.CurrentStock;
                    Grd.Rows[rowIndex].Cells["Printed"].Value = true;

                    count++;
                }
                foreach (PurchaseLine pl in rePrintPurItems)
                {

                    int rowIndex = Grd.Rows.Add();
                    Grd.Rows[rowIndex].Cells["Item"].Value = pl.Item.ItemName;
                    Grd.Rows[rowIndex].Cells["ItemID"].Value = pl.Item.ItemID;
                    Grd.Rows[rowIndex].Cells["Quantity"].Value = pl.Quantity;
                    Grd.Rows[rowIndex].Cells["Printed"].Value = true;
                    count++;
                }


                //SetRowNo();
                CalCulateCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmPrintBarCodes PopulateRePrintItems", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FrmReprintBarCodes_Load(object sender, EventArgs e)
        {
             try
            {
              
                ClearControls();
                GetItemsForPrint();
                this.Font = Accounts.AccountsGlobals.Font;
                //FrmPrintBarCodes_Fill_Panel.BackColor = Accounts.AccountsGlobals.FormColor;
                //p = new Purchase();
                txtstartingcol.Text  = "1";
                txtstartingrow.Text = "1";

                //LoadGrid();

                //if (rePrintItems == null)
                //{
                //    rePrintItems = new List<Common.Item>();
                //}
                //this.rePrintItems = new ItemController().GetReprintItems();

                ////if (this.rePrintPurItems == null)
                ////{
                ////    rePrintPurItems = new List<Purchase>();
                ////}
                ////this.rePrintPurItems = new PurchaseController().GetReprintItems();

                //if (this.rePrintItems.Count > 0 /*|| this.rePrintPurItems.Count > 0 */ )
                //{
                //    PopulateRePrintItems();
                //}           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message ,"FrmPrintBarCodes_Load",MessageBoxButtons.OK ,MessageBoxIcon.Error );
            }    
        }

        private void txtItemID_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this.txtItemID.Text.Trim().Length != 0)
                {
                    Common.Item it = new ItemController().GetSingleItem (Convert.ToInt32(this.txtItemID.Text),StockType.Pack,0);

                    if (it != null)
                    {
                        this.txtItemName.Text = it.ItemName.ToString();
                        this.txtInStock.Text = it.CurrentStock.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Valid Item ID.", "Enter Valid ID...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtItemID.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmRePrintBarCodes txtItemID_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtItemID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    Accounts.SchForms.SchItems sch = new Accounts.SchForms.SchItems();

                    sch.ShowDialog();
                    List<Common.Item> lstitem = new List<Common.Item>();
                    lstitem = sch.subList1;

                    if (lstitem != null)
                    {

                        for (int i = 0; i < lstitem.Count; i++)
                        {
                            txtItemID.Text = lstitem[i].ItemID.ToString();
                            txtItemName.Text = lstitem[i].ItemName.ToString();
                            txtInStock.Text = lstitem[i].CurrentStock.ToString();
                            txtQuantity.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "txtItemID_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void CreateBarCode(string p)
        {
            // string barcode = p.Length;
            Bitmap bitmap = new Bitmap(p.Length * 25, 70);
            //IDAutomationHC39M
            using (Graphics grapics = Graphics.FromImage(bitmap))
            {
                // Graphics newGraphics = Graphics.FromImage(bitmap);
                Font oFont = new Font("IDAutomationHC39M", 13);
                PointF oPoint = new PointF(2f, 2f);
                SolidBrush black = new SolidBrush(Color.Black);
                SolidBrush white = new SolidBrush(Color.White);
                grapics.FillRectangle(white, 0, 0, bitmap.Width, bitmap.Height);
                grapics.DrawString("*Label123*", oFont, black, oPoint);
            }
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                // pictureBox1.Width = bitmap.Width+500;
                //  pictureBox1.Height = bitmap.Height;
                pictureBox1.Image = (Image)bitmap;

            }
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
        System.Drawing.Image img;
       
        private void PrintSticker(string p)
        {
            try
            {

                ds.Clear();
                items = new List<BarcodeStickerPrinter.Item>();
                //To select where to start printing from (Row and col)
                ////////////////////////////////////////////////////////////////////////////////////////////////////////
                int rows = (Convert.ToInt16(txtstartingrow.Text) - 1) * 4;
                int cols = Convert.ToInt16(txtstartingcol.Text) - 1;

                int totalEmptyItems = rows + cols;

                for (int i = 0; i < totalEmptyItems; i++)
                {
                    items.Add(new BarcodeStickerPrinter.Item());

                }
                Common.Item objitem = new Common.Item();
                //////////////////////////////////////////////////////////////////////////////////////////////////////////

                //Get items to be printed  and loop i for number of grid rows and j for number of quantity each item is to printed.
                //////////////////////////////////////////////////////////////////////////////////////////////////////////

               
                int rowIndex = Grd.CurrentRow.Index;
                int colIndex = Grd.CurrentCell.ColumnIndex;
                decimal qty = Convert.ToDecimal(txtBarCodeCount.Text);
                Grd.Rows[rowIndex].Cells["ItemID"].Selected = true;
                for (int i = 0; i < Grd.Rows.Count; i++)              
                {
                    if (Convert.ToBoolean(Grd.Rows[i].Cells["Printed"].Value) == true)
                    {
                        objitem = new Common.Item();
                        objitem = new ItemController().PrintSticker(Convert.ToInt32((Grd.Rows[i].Cells["ItemID"].Value.ToString())));
                        if (objitem.ItemID != 0)
                        {
                            for (int j = 0; j < Convert.ToInt32(Grd.Rows[i].Cells["Quantity"].Value); j++)
                            {
                                BarcodeStickerPrinter.Item item = new BarcodeStickerPrinter.Item(Convert.ToInt32(objitem.ItemID), Convert.ToString(objitem.PrintName), Convert.ToDouble(objitem.SalePrice), Convert.ToString(objitem.BarCode), Convert.ToInt32(objitem.OpQty1));
                                item.Code = objitem.CompanyName;
                                items.Add(item);
                            }
                        }
                    }
                }
              
                ////////////////////////////////////////////////////////////////////////////////////////////
                DataRow newItemRow;


                int itemQuantity = 0;

               // System.Drawing.Image img;

                //img = new BarcodeLibTest.TestApp().Call
                //  img = new BarcodeLibTest.TestApp().CallLabel((String.Concat(I.ItemBarcode, "~" + itemQuantity)));
                string label;
                foreach (BarcodeStickerPrinter.Item I in items)
                {

                     itemQuantity = itemQuantity + 1;
                    // newItemRow = ds.Tables["SPItemBarcode"].NewRow();
                    newItemRow = ds.Tables["PurchaseRegister"].NewRow();
                   
                
                    newItemRow["Itemname"] = I.Itemname; // "Item Name Full /Item Name Full ";//;
                    newItemRow["ItemPrice"] = I.ItemPrice;
                    System.Drawing.Image img;
                    newItemRow["barcode"] = I.ItemBarcode;
                    img = new BarcodeLibTest.TestApp().CallLabel(I.ItemBarcode);
                    newItemRow["ItemBarcode"] = ImageToByte(img);
                    newItemRow["ItemQuantity"] = itemQuantity;
                    newItemRow["Company"] = cmbBarcode.Text;
                    ds.Tables["PurchaseRegister"].Rows.Add(newItemRow);

                    // byte[] bb = ImageToByte(img);


                    /// newItemRow["ItemBarCode"] = ImageToByte(img); //ImageToByte(pictureBox1.Image); //I.ItemBarcode + "~" + itemQuantity; 


                    //newItemRow["BarcodeImage"] = bb;
                  //  ds.Tables["PurchaseRegister"].Rows.Add(newItemRow);
                  //  pictureBox1.Image = img;

                }

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////                
                //if records are fount print them.
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                Report_Forms.frmViewer Viewer = new Report_Forms.frmViewer();
                // if (ds.Tables[0].Rows.Count > 0)
                if (ds.Tables["PurchaseRegister"].Rows.Count > 0)
                {

                    ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
                    Viewer.reportViewer1.LocalReport.DataSources.Add(rds);
                    //Viewer.reportViewer1.LocalReport.ReportPath = "../../Report/RptPurchaseInvoice.rdlc";
                    Viewer.reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "Report/RptBarcodePrint.rdlc");
                    //    ReportParameter[] rptParams = new ReportParameter[]
                    //    {
                    //new ReportParameter("Date",Date),
                    //    };
                    //   Viewer.reportViewer1.LocalReport.SetParameters(rptParams);
                    // Viewer.reportViewer1.LocalReport.Refresh();
                    Viewer.ShowDialog();
                  if( new PurchaseController().ClearPrintedInv())
                    {
                        //to do
                    }
                         
                }
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //PrintProc();
                else
                    MessageBox.Show("No Data For Printing", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (cmbBarcode.Text.Trim().Length > 0)
            {
            
                PrintSticker("w");
                ClearControls();
            }
            else
            {
                MessageBox.Show("Enter Bar Code Title First.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbBarcode.Focus();
            }
        }

        private void SaveBarcodeTitle()
        {
           if(cmbBarcode.Text.Trim().Length > 0)
           {
                new ItemController().SaveBarcodeTitle(cmbBarcode.Text);
           }
        }

        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            
           
        }
        
        private void countqty()
         {

            int rowIndex = Grd.CurrentRow.Index;
            int colIndex = Grd.CurrentCell.ColumnIndex;
            decimal totalQty = 0;
            for(int i = 0; i < Grd.Rows.Count; i++)
            {
                if (Convert.ToInt32(Grd.Rows[i].Cells["ItemID"].Value) != 0 && Convert.ToBoolean(Grd.Rows[i].Cells["Printed"].Value)==true)
                {
                    totalQty += Convert.ToDecimal(Grd.Rows[i].Cells["Quantity"].Value);
                }
            }
            //if (txtQuantity.Text.Length>0)
            //{
            //    Qty += Convert.ToDecimal(txtQuantity.Text);
            //}
            txtBarCodeCount.Text = totalQty.ToString();
        }

        private void btnTitleBarcode_Click(object sender, EventArgs e)
        {
            FrmBarcodeTitle frm = new FrmBarcodeTitle();
            frm.ShowDialog();
            GetTitles();
        }

        

       

        private void Grd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Grd.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void Grd_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int colindex = Grd.CurrentCell.ColumnIndex;
            if (colindex == Grd.Columns["Printed"].Index)
            {
                countqty();
            }
        }
    }
}

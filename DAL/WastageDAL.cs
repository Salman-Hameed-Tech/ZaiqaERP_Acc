using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Common;

using System.Globalization;

namespace DAL
{
    public class WastageDAL
    {
        //Fields.
        List<Purchase> purchases;
        List<Purchase> subPurchases;
        List<Wastage> WAS = new List<Wastage>();
        private string source = ReadProjectConfigFile.ConfigString();

        SqlConnection con;
        SqlCommand cmd;

        SqlDataReader drPurchase;
        SqlDataReader drPurchaseLine;

        SqlTransaction VTran;
        SqlDataReader dr;

        public int GetMaximumID()
        {

            int VID = 0;

            con = new SqlConnection(source);
            con.Open();

            cmd = new SqlCommand("Select IsNull(Max(WasID),0) +1 From WastageInvoice", con);
            VID = Convert.ToInt32(cmd.ExecuteScalar());

            return VID;
        }

        public int CheckReturn(int p)
        {
            con = new SqlConnection(source);
            con.Open();
            int pid = 0;
            cmd = new SqlCommand("Select RetID From PurchaseReturnInvoice where PurchaseID=" + p, con);

            if (cmd.ExecuteScalar() != null)
            {
                pid = (int)cmd.ExecuteScalar();
                if (pid > 0)
                {
                    return pid;
                }
                else
                    return 0;
            }
            else
                return 0;
        }
        public bool DeleteWastage(int id)
        {
            try
            {
                try
                {
                    con = new SqlConnection(source);
                    con.Open();
                    string delete = "";
                    delete = "Delete From WastageInvoice where WASID=" + id;
                    cmd = new SqlCommand(delete, con);
                    cmd.ExecuteNonQuery();

                    delete = "Delete From WastageInvoiceBody where WASID=" + id;
                    cmd = new SqlCommand(delete, con);
                    cmd.ExecuteNonQuery();



                    return true;
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                { con.Close(); }
            }
            catch (Exception)
            {
                VTran.Rollback();
                throw;
            }
            finally { con.Close(); }
        }

        public List<WastageLine> GetWastagesline(int id)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand("select * from WastageInvoiceBody w inner join item i on i.itemid=w.itemid    where WasID=" + id, con);
                dr = cmd.ExecuteReader();
                List<WastageLine> lstmn = new List<WastageLine>();
                while (dr.Read())
                {
                    Common.WastageLine objorder = new WastageLine();
                    objorder.itemid = Convert.ToInt32(dr["ItemID"]);
                    objorder.Itemname = Convert.ToString(dr["ItemName"]);
                    objorder.PurchasePrice = Convert.ToDecimal(dr["PurPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["PurPrice"]));
                   
                    objorder.Quantity = dr["Quantity"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Quantity"]);

                    lstmn.Add(objorder);

                }
                return lstmn;
            }
            catch (Exception)
            {

                throw;
            }
            finally { con.Close(); dr.Close(); }
        }
        public List<Wastage> GetWastageData(int id, string where)
        {
            con = new SqlConnection(source);
            con.Open();
            WAS = new List<Wastage>();
            try
            {


                if (id > 0)
                {
                    where = " Where ID = " + id;
                }
                string select = "Select * from WastageInvoice c    " + where + " ORDER BY c.WasID";
                cmd = new SqlCommand(select, con);
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    Wastage o = new Wastage();

                    o.InvoiceNo = (int)read["WasID"];
                    o.WastageDate = Convert.ToDateTime(read["WastageDate"]);
                    o.AmountPaid = Convert.ToDecimal(read["AmtWaste"]);
                    o.Discount = Convert.ToDecimal(read["Discount"]);
                    o.Narration = Convert.ToString(read["Narration"]);


                    WAS.Add(o);
                }
                read.Close();

                con.Close();
                return WAS;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public bool SaveWastage(SaleReturn saleReturn, Wastage wastage, bool isNew)
        {
            try
            {
                int VID = 0;
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();

                #region

                if (isNew)
                {
                    cmd = new SqlCommand("Select IsNull(Max(WasID),0) +1 From WastageInvoice", con);
                    cmd.Transaction = VTran;
                    VID = Convert.ToInt32(cmd.ExecuteScalar());
                }
                else
                {
                    VID = wastage.InvoiceNo;
                    SqlCommand c1, c2, c3;

                    cmd = new SqlCommand("Select * from WastageInvoice Where WasID=" + VID, con);
                    cmd.Transaction = VTran;
                    int i = (int)cmd.ExecuteScalar();

                    if (i > 0)
                    {
                        SqlDataAdapter Da = new SqlDataAdapter("select itemid,srno from WastageInvoicebody where wasid=" + VID, con);
                        DataSet ds = new DataSet();
                        Da.SelectCommand.Transaction = VTran;
                        Da.Fill(ds);

                        //foreach (PurchaseLine pl in purchase.PurchaseLines)
                        ///for ( i = 0; i < ds.Tables [0].Rows.Count -1; i++)
                        
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            c1 = new SqlCommand("Delete from WastageInvoicebody where SrNo=" + Convert.ToInt32(item["srno"]), con);
                            c1.Transaction = VTran;
                            c1.ExecuteNonQuery();
                        }
                        c3 = new SqlCommand("Delete from WastageInvoice where WasID=" + VID, con);
                        c3.Transaction = VTran;
                        c3.ExecuteNonQuery(); ;
                    }
                }

                #endregion

                string insertPurchase = "Insert into WastageInvoice(WasID, WastageDate, AmtPaid, AmtWaste, Discount, Narration,BranchID) Values(" + wastage.InvoiceNo + ", '" + wastage.WastageDate + "', " + wastage.AmountPaid + ", " + wastage.TotalAmount + ", " + wastage.Discount + ", '" + wastage.Narration + "'," + wastage.BranchID + ")";
                cmd = new SqlCommand(insertPurchase, con);
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();

                foreach (WastageLine pl in wastage.WastageLines)
                {
                    string insertPurchaseItems = "Insert Into WastageInvoicebody(ItemID, Quantity, PurPrice, Descr, WasID,BranchID) Values(" + pl.Item.ItemID + "," + pl.Quantity + "," + pl.PurchasePrice + "," + pl.Disc + ", " + wastage.InvoiceNo + "," + wastage.BranchID + ")";
                    cmd = new SqlCommand(insertPurchaseItems, con);
                    cmd.Transaction = VTran;
                    cmd.ExecuteNonQuery();

                    #region
                    //if (pl.IsDeleted == false)
                    //{
                    //    string updateItemPrice = "Update Item Set SalePrice=" + pl.SalePrice + ",PurchasePrice=" + pl.PurchasePrice + " where ItemID=" + pl.Item.ItemID;
                    //    SqlCommand cmd2 = new SqlCommand(updateItemPrice, con);
                    //    cmd2.Transaction = VTran;
                    //    cmd2.ExecuteNonQuery();
                    //}
                    #endregion
                }
                cmd = new SqlCommand("exec SPWastageEntries " + VID + ",'" + wastage.WastageDate.Date + "'", con);
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();
                VTran.Commit();
                con.Close();
                return true;
            }
            catch (Exception)
            {
                VTran.Rollback();
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Purchase> GetPurchases()
        {
            try
            {
                if (purchases == null) purchases = new List<Purchase>();

                con = new SqlConnection(source);

                string select = "select PurchaseID,PurchaseDate,VendorID,AccountName,Discount,BillNo,TotalAmount,AmountPaid,AddToPrint from PurchaseInvoice PIN inner join ChartofAccounts C on C.AccountNo=PIN.vendorID";

                //Convert(VarChar(25),PurchaseDate,103)+' 00:00:00 AM' as 

                con.Open();
                cmd = new SqlCommand(select, con);

                drPurchase = cmd.ExecuteReader();
                //AddPurchases();
                if (purchases.Count > 0)
                {
                    AddPurchaseLines();
                }

                return purchases;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Purchase GetSinglePurchase(int purchaseID)
        {
            try
            {
                con = new SqlConnection(source);

                Purchase purchase = new Purchase();

                string select = "select PurchaseID,PurchaseDate,VendorID,AccountName,Discount,BillNo,TotalAmount,AmountPaid,AddToPrint from PurchaseInvoice PIN inner join ChartofAccounts C on C.AccountNo=PIN.vendorID where PurchaseID=" + purchaseID;

                con.Open();
                cmd = new SqlCommand(select, con);

                drPurchase = cmd.ExecuteReader();
               // AddPurchases();

                if (purchases.Count > 0)
                {
                    AddPurchaseLines();
                }
                return purchases[0];
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //public void AddPurchases()
        //{
        //    try
        //    {

        //        Vendor v;

        //        List<PurchaseLine> purchaseLines;
        //        purchases = new List<Purchase>();

        //        while (drPurchase.Read())
        //        {
        //            purchaseLines = new List<PurchaseLine>();
        //            v = new Vendor(new ChartOfAccounts((string)drPurchase["VendorID"], (string)drPurchase["AccountName"]), new Address(), "");

        //            //DateTime d = new DateTime();

        //            //d = DateTime.ParseExact(Convert.ToString(drPurchase["PurchaseDate"]), "dd/MM/yyyy", null);

        //            ////d = Convert.ToDateTime(drPurchase["PurchaseDate"]);
        //            //DateTimeFormatInfo dfi = new DateTimeFormatInfo();
        //            //CultureInfo ci = new CultureInfo("ur-PK"); // Change where is you culture do you want



        //            purchases.Add(new Purchase((int)drPurchase["PurchaseID"], (DateTime)drPurchase["PurchaseDate"], (decimal)drPurchase["Discount"], v, purchaseLines, (string)drPurchase["BillNo"], (decimal)drPurchase["TotalAmount"], (decimal)drPurchase["AmountPaid"], Convert.ToBoolean(drPurchase["AddToPrint"] == System.DBNull.Value ? 0 : drPurchase["AddToPrint"]),0,"","",false,0,0,"","",0,0));
        //        }
        //        drPurchase.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        drPurchase.Close();
        //    }
        //}
        public void AddPurchaseLines()
        {
            try
            {
                Item i;
                Category c;
                PurchaseLine purchaseLine;
                List<PurchaseLine> purchaseLines;

                SqlCommand cmd2;
                string selectPurchaseLine;

                purchaseLines = new List<PurchaseLine>();

                foreach (Purchase p in purchases)
                {
                    selectPurchaseLine = "select PIb.PurchaseID,PIb.ShortKey,I.ItemID,CompanyName,ProductName,Design,isnull(Color,'')as Color,Size,CS.Quantity as CSQty,IC.CategoryID,IC.CategoryName,Pib.Quantity,Pib.PurPrice,Pib.Srno,IsNull(Pib.Discount,0) as Discount,IsNull(Pib.SalePrice,0) as SalePrice from PurchaseInvoiceBody PIb inner join Item I on I.ItemID=PIb.ItemId inner join ItemCategory IC on IC.CategoryID=I.CategoryID inner join CurrentStock CS on CS.ItemID=PIB.ItemID Where PurchaseID=" + p.InvoiceNo;
                    cmd2 = new SqlCommand(selectPurchaseLine, con);

                    drPurchaseLine = cmd2.ExecuteReader();
                    while (drPurchaseLine.Read())
                    {
                        i = new Item(Convert.ToInt32(drPurchaseLine["ItemID"]), new ItemName((string)drPurchaseLine["CompanyName"], (string)drPurchaseLine["ProductName"], (string)drPurchaseLine["Design"], (string)drPurchaseLine["Size"]), (decimal)drPurchaseLine["CSQty"]);

                        c = new Category((int)drPurchaseLine["CategoryID"], (string)drPurchaseLine["CategoryName"]);

                        purchaseLine = new PurchaseLine(c, i,  Convert.ToDecimal(drPurchaseLine["Quantity"]), Convert.ToDecimal(drPurchaseLine["PurPrice"]), Convert.ToDecimal(Convert.ToDecimal(drPurchaseLine["Quantity"]) * Convert.ToDecimal(drPurchaseLine["PurPrice"])), Convert.ToInt32(drPurchaseLine["SrNo"]), Convert.ToDouble(drPurchaseLine["Discount"]), Convert.ToDecimal(drPurchaseLine["SalePrice"]), "");
                        p.PurchaseLines.Add(purchaseLine);
                    }
                    drPurchaseLine.Close();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            finally { drPurchaseLine.Close(); }
        }
        public bool DeletePurchase(Purchase purchase)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();

                cmd = new SqlCommand("Select * from PurchaseInvoice Where PurchaseID=" + purchase.InvoiceNo, con);
                cmd.Transaction = VTran;
                int i = (int)cmd.ExecuteScalar();

                if (i > 0)
                {
                    foreach (PurchaseLine pl in purchase.PurchaseLines)
                    {
                        cmd = new SqlCommand("Delete from PurchaseInvoiceBody where SrNo=" + pl.SerialNumber, con);
                        cmd.Transaction = VTran;
                        cmd.ExecuteNonQuery();
                    }
                    cmd = new SqlCommand("Delete from PurchaseInvoice where PurchaseID=" + purchase.InvoiceNo, con);
                    cmd.Transaction = VTran;
                    cmd.ExecuteNonQuery(); ;
                }

                VTran.Commit();
                con.Close();
                return true;
            }
            catch (Exception)
            {
                VTran.Rollback();
                throw;
            }
            finally { con.Close(); }
        }
        public List<PurchaseLine> VerifyItem(string id, string type)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                string vwhere = "";
                List<PurchaseLine> lst = new List<PurchaseLine>();

                if (type == "b")
                {
                    vwhere = " where item.itemid=(select itemid from itembarcodes where barcode='" + id + "') and item.isactive=1";
                }
                else if (type == "s")
                {
                    vwhere = " where shortkey='" + id + "'  and item.isactive=1";
                }
                else if (type == "i")
                {
                    vwhere = " where item.itemid=" + id + "  and item.isactive=1";
                }
                cmd = new SqlCommand("Select item.itemid,item.shortkey,IsNull(item.itemprint,'') as itemprint,item.companyName,item.productname,item.design,item.size,isnull(item.Color,'')as Color,IsNull(cs.quantity,0) as qty,IsNull(item.PurchasePrice,0) as purprice  ,item.saleprice,IsNull(item.discountlimit,0) as discountlimit  from item Left Outer Join CurrentStock Cs on Cs.Itemid=item.itemid  " + vwhere, con); //IsNull(cs.price,isnull(item.purchaseprice,0))
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Item i = new Item(Convert.ToInt32(dr["itemid"]), new ItemName((string)dr["companyname"], (string)dr["productname"], (string)dr["design"], (string)dr["size"]), Convert.ToDecimal(dr["qty"]), Convert.ToDecimal(dr["discountlimit"]));
                    //Item i = new Item(Convert.ToInt32  (drSales["itemid"]), new ItemName((string)drSales["companyname"], (string)drSales["productname"], (string)drSales["design"], (string)drSales["size"]), Convert.ToDecimal(drSales["qty"]), Convert.ToDecimal(drSales["discountlimit"]));
                    i.SalePrice = Convert.ToDecimal(dr["saleprice"]);
                    PurchaseLine obj = new PurchaseLine(new Category(), i,  (decimal)dr["SalePrice"], (decimal)dr["purprice"], 0, 0, 0, (decimal)dr["saleprice"], "");
                    lst.Add(obj);
                }
                return lst;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Purchase> GetPurchasesForReport(string wPurchaseBody, string wPurchase)
        {
            try
            {
                if (purchases == null) purchases = new List<Purchase>();

                con = new SqlConnection(source);

                string select = "select PIn.PurchaseID,PIn.PurchaseDate,PIn.VendorID,Discount,TotalAmount,AmountPaid,P.PartyName,isnull(PIn.Remarks,'')as Remarks from PurchaseInvoice PIn inner join Parties P on P.PartyID=PIn.VendorID";

                con.Open();
                cmd = new SqlCommand(select, con);
                drPurchase = cmd.ExecuteReader();

                Vendor c;
                List<PurchaseLine> purchaseLines;

                while (drPurchase.Read())
                {
                    purchaseLines = new List<PurchaseLine>();
                    c = new Vendor(new ChartOfAccounts((string)(drPurchase["VendorID"] == System.DBNull.Value ? "" : drPurchase["VendorID"]), Convert.ToString(drPurchase["PartyName"])), new Address(), "");

                   // purchases.Add(new Purchase((int)drPurchase["PurchaseID"], (DateTime)drPurchase["PurchaseDate"], Convert.ToDecimal(drPurchase["Discount"]), c, purchaseLines, "", Convert.ToDecimal(drPurchase["TotalAmount"]), Convert.ToDecimal(drPurchase["AmountPaid"]), Convert.ToBoolean(0),0,"",(string)drPurchase["Remarks"], false,0,0,"","",0,0));
                }
                drPurchase.Close();

                if (purchases.Count > 0)
                {
                    Item i;

                    SqlCommand cmd2;
                    string selectPurchaseLine;
                    subPurchases = new List<Purchase>();

                    foreach (Purchase p in purchases)
                    {
                        selectPurchaseLine = "select PIb.PurchaseID,I.ItemID,CompanyName,ProductName,Design,Size,isnull(Color,'')as Color,IC.CategoryID,IC.CategoryName,Pib.Quantity,Pib.PurPrice,Pib.Srno,IsNull(Pib.Discount) as Discount,IsNull(SalePrice,0) as SalePrice from PurchaseInvoiceBody PIb inner join Item I on I.ItemID=PIb.ItemId inner join ItemCategory IC on IC.CategoryID=I.CategoryID where PIB.PurchaseID=" + p.InvoiceNo + wPurchaseBody;

                        cmd2 = new SqlCommand(selectPurchaseLine, con);
                        drPurchaseLine = cmd2.ExecuteReader();

                        bool contains = false;
                        while (drPurchaseLine.Read())
                        {
                            i = new Item(Convert.ToInt32(drPurchaseLine["itemid"]), new ItemName((string)drPurchaseLine["companyname"], (string)drPurchaseLine["productname"], (string)drPurchaseLine["design"], (string)drPurchaseLine["size"]), "", "");

                            p.PurchaseLines.Add(new PurchaseLine(new Category(), i,  (decimal)drPurchaseLine["Quantity"], (decimal)drPurchaseLine["PurPrice"], Convert.ToDecimal((decimal)drPurchaseLine["Quantity"] * (decimal)drPurchaseLine["PurPrice"]), (int)drPurchaseLine["SrNo"], Convert.ToDouble(drPurchaseLine["Discount"]), Convert.ToDecimal(drPurchaseLine["SalePrice"]), ""));
                            contains = true;
                        }

                        if (contains == true)
                        {
                            subPurchases.Add(p);
                        }
                        drPurchaseLine.Close();
                    }
                }
                return subPurchases;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.Close(); }
        }
        public List<Purchase> GetReprintItems()
        {
            List<Purchase> lst = new List<Purchase>();

            try
            {
                string select, selectP;

                selectP = "Select * from PurchaseInvoice where AddToPrint=1";

                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand(selectP, con);

                drPurchase = cmd.ExecuteReader();

                while (drPurchase.Read())
                {
                    lst.Add(new Purchase(Convert.ToInt32(drPurchase["PurchaseID"]), ""));
                }
                drPurchase.Close();

                if (lst.Count > 0)
                {
                    foreach (Purchase p in lst)
                    {
                        select = "Select Item.ItemID,CompanyName,ProductName,Design,Size,isnull(Color,'')as Color,PB.Quantity from Item inner join (Select ItemID,Quantity from PurchaseInvoiceBody where PurchaseID=" + p.InvoiceNo + ")PB on PB.ItemID=Item.ItemID";

                        SqlCommand c = new SqlCommand(select, con);
                        dr = c.ExecuteReader();

                        while (dr.Read())
                        {
                            Item i = new Item(Convert.ToInt32(dr["itemid"]), new ItemName((string)dr["companyname"], (string)dr["productname"], (string)dr["design"], (string)dr["size"]));
                            PurchaseLine obj = new PurchaseLine(new Category(), i, (decimal)dr["Quantity"], 0, 0, 0, 0, 0, "");

                            p.PurchaseLines.Add(obj);
                        }
                        dr.Close();
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public bool UpdatePrintStatus(int p)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();


                VTran = con.BeginTransaction();
                cmd = new SqlCommand("Update PurchaseInvoice Set AddToPrint=0 where PurchaseID=" + p, con);
                cmd.Transaction = VTran;

                cmd.ExecuteNonQuery();
                VTran.Commit();

                con.Close();

                return true;
            }
            catch (Exception ex)
            {
                VTran.Rollback();
                throw ex;
            }
            finally { con.Close(); }
        }

        public bool LoadWasRegister(DataSet ds)
        {
            con = new SqlConnection(source);
            con.Open();
            cmd = new SqlCommand("select isnull(wi.WasID, 0) as WasID, isnull(wi.WastageDate, '') as WasDate, isnull(wi.AmtPaid, 0.00) as AmtPaid, isnull(wi.AmtWaste, 0.00) as AmtWastage, isnull(wi.Discount, 0.00) as Discount, isnull(wi.narration, '') as Narration, ISNULL(wib.SrNo, 0) as SrNo, ISNULL(wib.ItemID, 0) as ItemID, ISNULL(wib.PurPrice, 0.00) as PurPrice, ISNULL(wib.Quantity, 0.00) as Qty from WastageInvoice wi inner join WastageInvoiceBody wib on wi.WasID=wib.WasID", con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds, "DTWastReg");
            con.Close();

            return true;
        }
    }
}
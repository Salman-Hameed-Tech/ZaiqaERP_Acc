using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Common;

using System.Globalization;
using Common.Data_Sets;

namespace DAL
{
    public class PurchaseDAL
    {
        //Fields.
        List<Purchase> purchases;
        List<Purchase> subPurchases;
        List<PurchaseInvoice> PurchaseInv = new List<PurchaseInvoice>();

        private string source = ReadProjectConfigFile.ConfigString();

        SqlConnection con;
        SqlCommand cmd;
        
        SqlDataReader dr;
        SqlDataReader drPurchaseLine;

        SqlTransaction VTran;
      
        SqlDataAdapter da;
        public int GetMaximumID()
        {

            int VID = 0;
            
            con = new SqlConnection(source);
            con.Open();

            cmd = new SqlCommand("Select IsNull(Max(PurchaseID),0) +1 From PurchaseInvoice", con);
            VID = Convert.ToInt32(cmd.ExecuteScalar());

            return VID;
        }

        public int CheckReturn(int p)
        {
            con = new SqlConnection(source);
            con.Open();
            int pid = 0;
            cmd = new SqlCommand("Select ID From PurchaseReturn where PurchaseID=" + p, con);

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

        public List<PurchaseInvoice> GetPurchaseInvoice(int ItemId, int InvoiceNo)
        {
            if (PurchaseInv == null) PurchaseInv = new List<PurchaseInvoice>();
            try
            {
                string where = "";

                if (InvoiceNo > 0)
                {
                    where = " Where ID = " + InvoiceNo;
                }
                string select = "select pi.PurchaseId,isnull(coa.AccountName,'')as AccountName ,pi.PurchaseDate,pib.Itemid,i.ItemName,pib.PurPrice as Rate,pib.Quantity from purchaseinvoice pi  inner join purchaseinvoicebody pib on pib.PurchaseId= pi.PurchaseId  inner join item i on i.itemid= pib.itemid left join ChartofAccounts coa on coa.accountname=pi.VendorID  where pib.itemid=" + ItemId + " and pi.VendorID =" + InvoiceNo + "";
                // string select = "select * from purchaseinvoice pi  inner join purchaseinvoicebody pib on pib.pid= pi.id inner join item i on i.itemid= pib.itemid left join ChartofAccounts coa on coa.accountname=pi.partyid where pib.itemid=" + ItemId + "";

                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(select, con);
                dr = cmd.ExecuteReader();

                //Add Categories to Collection
                AddInvoices();
                con.Close();
                return PurchaseInv;
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
        private void AddInvoices()
        {
            try
            {

                while (dr.Read())
                {

                    PurchaseInvoice p = new PurchaseInvoice(Convert.ToInt32(dr["PurchaseID"]), dr["AccountName"].ToString(), Convert.ToDateTime(dr["PurchaseDate"]), Convert.ToInt32(dr["ItemID"]), dr["ItemName"].ToString(), Convert.ToDecimal(dr["Quantity"]));
                    p.Rate = Convert.ToDecimal(dr["Rate"]);


                    PurchaseInv.Add(p);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw;
            }

            finally { }
        }
        public bool GetVWInventory(ref DSVendorWInventory dSVendorWInventory, string partyid)
        {
            try
            {
               
                Object objid = partyid;
                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("SPVendorWiseInventory", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

            
                if (partyid.Trim().Length>0)
                {
                    cmd.Parameters.AddWithValue("@VendorID", objid);
                }
                SqlDataAdapter da1 = new SqlDataAdapter();
                da1.SelectCommand = cmd;

                da1.Fill(dSVendorWInventory, "SPVendroWInventory");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int VerifyItem(string id)
        {
            try
            {

                int itemid = 0;

                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("select isnull((pi.itemid),0) as itemid  from Challanbody pi   where pi.itemid= '" + id + "'", con);
                itemid = Convert.ToInt32(cmd.ExecuteScalar());
                return itemid;
            }
            catch
            {
                throw;
            }
        }
        public decimal VerifyQty(string id)
        {
            try
            {

                Decimal Qty = 0;

                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("select isnull((pi.Quantity),0) as Quantity  from Challanbody pi   where pi.itemid= '" + id + "'", con);
                Qty = Convert.ToDecimal(cmd.ExecuteScalar());
                return Qty;
            }
            catch
            {
                throw;
            }
        }

        public int SavePurchase(Purchase purchase,bool isNew)
        {
            try
            {
                int VID = 0;
                int TID = 0;
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();

                if (isNew)
                {
                    cmd = new SqlCommand("Select IsNull(Max(PurchaseID),0) +1 From PurchaseInvoice", con);
                    cmd.Transaction = VTran;
                    VID = Convert.ToInt32(cmd.ExecuteScalar());

                   
                    string insertPurchase = "Insert into PurchaseInvoice(PurchaseID,PurchaseDate,VendorID,Discount,TotalAmount,AmountPaid,BillNo,BranchID,UserNo,Remarks,IsAdjEnt,PaymentMode) Values(" + VID + ",'" + purchase.PurchaseDate.ToString("yyyy-MM-dd 00:00:00") + "','" + purchase.Vendor.Id.AccountNo + "'," + purchase.Discount + "," + purchase.TotalAmount + "," + purchase.AmountPaid + ",'" + purchase.BillNumber + "', " + Convert.ToInt32(purchase.BranchID) + ","+User.UserNo+",'"+purchase.Remarks+"',"+Convert.ToInt16(purchase.IsAdjust)+","+purchase.PaymentMode+")";
                    cmd.CommandText = insertPurchase;
                    cmd.ExecuteNonQuery();
                 
                   
                    foreach (PurchaseLine pl in purchase.PurchaseLines)
                    {
                        if (pl.IsDeleted == false)
                        {
                            cmd.CommandText = SetInsertLine(pl, VID);
                            cmd.ExecuteNonQuery();

                           
                        }
                    }


                }
                else
                {
                    VID = purchase.InvoiceNo;
                    cmd = new SqlCommand("", con);
                    cmd.Transaction = VTran;

                    if (con == null)
                    {
                        con = new SqlConnection(source);
                        con.Open();
                    }

                    foreach (PurchaseLine line in purchase.PurchaseLines)
                    {
                        if (!line.IsDeleted && line.SerialNumber != 0)
                        {                        
                            cmd.CommandText = "Update purchaseInvoiceBody Set ItemID = " + line.Item.ItemID + ",Barcode='"+line.Barcode+"' ,Quantity = " + line.Quantity + " ,PurPrice = " + line.PurchasePrice + ",Discount = " + line.Disc + ",SalePrice = " + line.SalePrice + " where SrNo = " + line.SerialNumber;
                            cmd.ExecuteNonQuery();                          
                        }
                        else if (!line.IsDeleted && line.SerialNumber == 0)
                        {
                            cmd.CommandText = SetInsertLine(line, purchase.InvoiceNo);
                            cmd.ExecuteNonQuery();                      
                        }
                        else
                        {                  
                            cmd.CommandText = "Delete from purchaseinvoicebody where SrNo = " + line.SerialNumber;
                            cmd.ExecuteNonQuery();                         
                        }


                    }
                    cmd.CommandText = "Update purchaseInvoice Set PaymentMode="+purchase.PaymentMode+",PurchaseDate='" + purchase.PurchaseDate.Date.ToString("yyyy-MM-dd 00:00:00") + "', VendorID = '" + purchase.Vendor.Id.AccountNo + "',  TotalAmount = " + purchase.TotalAmount + ", AmountPaid="+purchase.AmountPaid+ ", BillNo = '" + purchase.BillNumber + "' , BranchID = " + purchase.BranchID + ",UserNo="+User.UserNo+", Remarks='"+purchase.Remarks+ "',IsAdjEnt="+Convert.ToInt16(purchase.IsAdjust)+" Where PurchaseId = " + purchase.InvoiceNo;
                    cmd.ExecuteNonQuery();

                }

                cmd.CommandText = "DELETE FROM AccVouchersBody WHERE VoucherType = 'LPJ' AND refno = " + VID;
                cmd.ExecuteNonQuery();


                cmd = new SqlCommand("exec SppurchaseAccEntries " + VID , con);
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();
                VTran.Commit();
                con.Close();
                return VID;
            }
            catch (Exception ex)
            {
                VTran.Rollback ();
                throw;
            }
            finally 
            {
                con.Close();
            }
        }

     

        public bool ClearPrintedInv()
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
           
                string select = " update purchaseinvoice set Addtoprint=0 ";
                cmd = new SqlCommand(select, con);
                bool result=Convert.ToBoolean(cmd.ExecuteNonQuery());

                return result;

            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public List<Item> GetPrintedItems()
        {
            try
            {             
                con = new SqlConnection(source);
                con.Open();
                List<Item> itemlist = new List<Item>();
                string select = " select ib.Itemid,Item.ItemName,sum(ib.Quantity)as Quantity from PurchaseInvoicebody ib inner join PurchaseInvoice i on i.PurchaseId=ib.PurchaseId left join Item on ib.Itemid=Item.ItemID where i.AddtoPrint=1 group by ib.Itemid,item.ItemName ";
                cmd = new SqlCommand(select, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Item item = new Item();
                        item.ItemID = Convert.ToInt32(dr["Itemid"]);
                        item.ItemNameb= dr["ItemName"].ToString();
                        item.OpQty1= Convert.ToInt64(dr["Quantity"]);

                        itemlist.Add(item);
                    }
                }
               
               

                return itemlist;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private string SetInsertLine(PurchaseLine pl, int VID)
        {
            try
            {
                string insertPurchaseItems = "Insert Into PurchaseInvoiceBody(PurchaseID,ItemID,Quantity,PurPrice,Discount,SalePrice,Barcode) Values(" + VID + "," + pl.Item.ItemID + "," + pl.Quantity + "," + pl.PurchasePrice + "," + pl.Disc + "," + pl.SalePrice + ",'"+pl.Barcode+"')";

                return insertPurchaseItems;
            }
            catch
            {
                VTran.Rollback();
                throw;
            }
        }


        public bool GetReportData(ref Common.Data_Sets.DSPurchaseInvoice ds, int invID)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand("  select p.PurchaseId,c.PartyName,b.BranchName,i.ItemName,p.PurchaseDate,p.Discount,p.TotalAmount,p.IsAdjEnt,p.Remarks,u.UserName as CreatedBy ,pb.Itemid,(select max(barcode) from itemBarcodes where itemid=i.itemid)as Barcode,pb.Quantity,pb.PurPrice,pb.SalePrice,pb.DiscAmt,isnull(p.BillNo,'-')as BillNo  from PurchaseInvoice p inner join PurchaseInvoiceBody PB on P.PurchaseId=pb.PurchaseId left join Parties c on p.VendorID =c.PartyID left join item i on pb.itemid=i.itemid  left join Users u on p.UserNo=u.UserNo left join branch b on p.branchid=b.id where p.Purchaseid=" + invID + "  ", con);
                da = new SqlDataAdapter(cmd);           
                da.Fill(ds,"SPPurchaseInvoice");
                return true;
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

        public List<Purchase> GetPurchases()
        {
            try
            {
                if (purchases == null) purchases = new List<Purchase>();
                con = new SqlConnection(source);
                string select = "select isnull(PaymentMode,0) as PaymentMode,PurchaseID,PurchaseDate,VendorID,AccountName,Discount,BillNo,TotalAmount,AmountPaid,AddToPrint,PIN.BranchID,u.UserName,isnull(PIN.Remarks,'')as Remarks,isnull(PIN.IsAdjEnt,0)as IsAdjEnt from PurchaseInvoice PIN left join Users u on PIN.UserNo=u.UserNo inner join ChartofAccounts C on C.AccountNo=PIN.vendorID";
                con.Open();
                cmd = new SqlCommand(select, con);
                dr = cmd.ExecuteReader();
                AddPurchases();              
                return purchases;
            }
            catch (Exception ex)
            {
                throw ;
            }
        }
        public Purchase GetSinglePurchase(int purchaseID)
        {
            try
            {              
                con = new SqlConnection(source);
                Purchase purchase = new Purchase();
                string select = "select PurchaseID,isnull(PaymentMode,0) as PaymentMode,PurchaseDate,VendorID,AccountName,Discount,BillNo,TotalAmount,AmountPaid,isnull(PIN.UserNo,0)as UserNo,u.UserName,PIN.BranchID,isnull(PIN.Remarks,'')as Remarks,Isnull(IsAdjEnt,0)as  IsAdjEnt  from PurchaseInvoice PIN inner join ChartofAccounts C on C.AccountNo=PIN.vendorID left join Users u on PIN.UserNo=u.UserNo where PurchaseID=" + purchaseID;
                con.Open();
                cmd = new SqlCommand(select, con);
                dr = cmd.ExecuteReader();
                AddPurchases();
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

        public void AddPurchases()
        {
            try
            {               
                Vendor v;
                List<PurchaseLine> purchaseLines;
                purchases = new List<Purchase>();
                while (dr.Read())
                {
                    purchaseLines = new List<PurchaseLine>();
                    v = new Vendor(new ChartOfAccounts((string)dr["VendorID"], (string)dr["AccountName"]), new Address(), "");     
                    purchases.Add(new Purchase((int)dr["PurchaseID"], (DateTime)dr["PurchaseDate"], (decimal)dr["Discount"], v, purchaseLines, (string)dr["BillNo"], (decimal)dr["TotalAmount"], (decimal)dr["AmountPaid"],  Convert.ToInt32(dr["BranchID"]),Convert.ToString(dr["UserName"]),(string)dr["Remarks"], (bool)(dr["IsAdjEnt"]), (int)(dr["PaymentMode"])));                  
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {                
                dr.Close();
            }
        }

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
                    selectPurchaseLine = "select PIb.PurchaseID,0 as CSQty,I.ItemID,CompanyName,ProductName,isnull(Design,'') as Design,isnull(Size,'') as Size,IC.CategoryID,IC.CategoryName,Pib.Quantity,Pib.PurPrice,Pib.Srno,IsNull(Pib.Discount,0) as Discount,IsNull(Pib.SalePrice,0) as SalePrice,isnull(Barcode,'') as Barcode  from PurchaseInvoiceBody PIb inner join Item I on I.ItemID=PIb.ItemId inner join ItemCategory IC on IC.CategoryID=I.CategoryID Where PurchaseID=" + p.InvoiceNo+"order by i.itemid";
                    cmd2 = new SqlCommand(selectPurchaseLine, con);

                    drPurchaseLine = cmd2.ExecuteReader();
                    while (drPurchaseLine.Read())
                    {
                        i = new Item();
                        i.ItemID= Convert.ToInt32(drPurchaseLine["ItemID"]);
                        i.BarCode = drPurchaseLine["Barcode"].ToString();
                        ItemName name = new ItemName();
                        name.CompanyName = drPurchaseLine["CompanyName"].ToString();
                        name.ProductName = drPurchaseLine["ProductName"].ToString();
                        name.Design = drPurchaseLine["Design"].ToString();
                        name.Size = drPurchaseLine["Size"].ToString();
                        i.ItemName = name;

                        c = new Category((int)drPurchaseLine["CategoryID"], (string)drPurchaseLine["CategoryName"]);

                        purchaseLine = new PurchaseLine(c, i, Convert.ToDecimal(drPurchaseLine["Quantity"]), Convert.ToDecimal(drPurchaseLine["PurPrice"]), Convert.ToDecimal(Convert.ToDecimal(drPurchaseLine["Quantity"]) * Convert.ToDecimal(drPurchaseLine["PurPrice"])), Convert.ToInt32(drPurchaseLine["SrNo"]), Convert.ToDouble(drPurchaseLine["Discount"]), Convert.ToDecimal(drPurchaseLine["SalePrice"]),"");
                     
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

                cmd = new SqlCommand("Select * from PurchaseInvoice Where PurchaseID=" + purchase .InvoiceNo , con);
                cmd.Transaction = VTran;
                int i = (int)cmd.ExecuteScalar();

                if (i > 0)
                {
                    foreach (PurchaseLine pl in purchase.PurchaseLines)
                    {

                        cmd.CommandText = "Select Quantity from purchaseInvoiceBody where Itemid=" + pl.Item.ItemID + " and  SrNo = " + pl.SerialNumber + " and BranchID=" + 1 + " ";
                        decimal PrevQuantity = Convert.ToDecimal(cmd.ExecuteScalar());

                        cmd = new SqlCommand("Delete from PurchaseInvoiceBody where SrNo=" + pl.SerialNumber, con);
                        cmd.Transaction = VTran;
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "exec SPDeletePurchase " + pl.Item.ItemID + ", " + 1 + ", " + PrevQuantity + ", " + pl.PurchasePrice + " ";
                        cmd.ExecuteNonQuery();
                    }
                    cmd = new SqlCommand("Delete from PurchaseInvoice where PurchaseID=" + purchase.InvoiceNo , con);
                    cmd.Transaction = VTran;
                    cmd.ExecuteNonQuery(); ;

                    //cmd.CommandText = "DELETE FROM AccVouchersBody WHERE VoucherType = 'LPJ' AND VoucherNo = " + purchase.InvoiceNo;
                    //cmd.ExecuteNonQuery();
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

        public List<PurchaseLine> VerifyItem(string id, string type,int Branchid,string partyid)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                string vwhere = "";
                List<PurchaseLine> lst = new List<PurchaseLine>();

                if (type == "b")
                {
                    vwhere = " where  i.itemid=(select itemid from itembarcodes where barcode='" + id + "') and i.isactive=1";
                }
                else if (type == "s")
                {
                    vwhere = " where shortkey='" + id + "'  and i.isactive=1";
                }
                else if (type == "i")
                {

                    vwhere = " where i.itemid=" + id + "  and i.isactive=1   ";
                }
                cmd = new SqlCommand("Select i.itemid,ibc.Barcode,i.companyName,i.productname,i.design,i.size,IsNull(cs.quantity,0) as qty ,'' as Color, isnull((select max(pib.PurPrice) from PurchaseInvoiceBody   pib inner join PurchaseInvoice pi on pi.purchaseid=pib.PurchaseId where Itemid=i.itemid and  pi.PurchaseDate=(select max( pi.purchasedate) from PurchaseInvoiceBody pib inner join PurchaseInvoice pi on pi.purchaseid=pib.PurchaseId where itemid=i.itemid)),0) as PurPrice   from item i left outer join (select itemid,sum(quantity) as quantity,case when sum(quantity)<>0  then  sum(quantity*price)/sum(quantity) else 0  end  as price from tblfifo where branchid=" + Branchid + " group by itemid) Cs on Cs.Itemid=i.itemid left join ItemBarcodes ibc on i.itemid=ibc.itemid     " + vwhere, con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Item i = new Item();
                    ItemName itemname=new ItemName((string)dr["companyname"], (string)dr["productname"], (string)dr["design"], (string)dr["size"]);
                    i.ItemName = itemname;
                    i.ItemID = Convert.ToInt32(dr["itemid"]);
                    i.CurrentStock = Convert.ToDecimal(dr["qty"]);
                    i.BarCode = dr["Barcode"].ToString();
                    PurchaseLine obj = new PurchaseLine();
                    obj.PurchasePrice= Convert.ToDecimal(dr["PurPrice"]);
                    obj.Item = i;
                    lst.Add(obj);
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


        public List<Purchase> GetPurchasesForReport(string wPurchaseBody, string wPurchase)
        {
            try
            {
                if (purchases == null) purchases = new List<Purchase>();

                con = new SqlConnection(source);

                string select = "select PIn.PurchaseID,PIn.PurchaseDate,PIn.VendorID,Discount,TotalAmount,AmountPaid,P.PartyName,isnull(PIn.Remarks,'')as Remarks,isnull(PIn.CourierAccount,'')as CourierAccount,isnull(PIn.TrackingID,'')as TrackingID,isnull(PIn.CourierAmount,0)as CourierAmount from PurchaseInvoice PIn inner join Parties P on P.PartyID=PIn.VendorID";

                con.Open();
                cmd = new SqlCommand(select, con);
                dr = cmd.ExecuteReader();

                Vendor c;
                List<PurchaseLine> purchaseLines;

                while (dr.Read())
                {
                    purchaseLines = new List<PurchaseLine>();
                    c = new Vendor(new ChartOfAccounts((string)(dr["VendorID"] == System.DBNull.Value ? "" : dr["VendorID"]), Convert.ToString(dr["PartyName"])),new Address(), "");

                    purchases.Add(new Purchase((int)dr["PurchaseID"], (DateTime)dr["PurchaseDate"], Convert.ToDecimal(dr["Discount"]), c, purchaseLines, "", Convert.ToDecimal(dr["TotalAmount"]), Convert.ToDecimal(dr["AmountPaid"]),0,"",(string)dr["Remarks"], false,0));
                }
                dr.Close();

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

                            p.PurchaseLines.Add(new PurchaseLine(new Category(), i, (decimal)drPurchaseLine["Quantity"], (decimal)drPurchaseLine["PurPrice"], Convert.ToDecimal((decimal)drPurchaseLine["Quantity"] * (decimal)drPurchaseLine["PurPrice"]), (int)drPurchaseLine["SrNo"], Convert.ToDouble(drPurchaseLine["Discount"]), Convert.ToDecimal(drPurchaseLine["SalePrice"]),""));
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
                string select,selectP;

                selectP = "Select * from PurchaseInvoice where AddToPrint=1";               
                
                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand(selectP, con);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lst.Add(new Purchase(Convert.ToInt32(dr["PurchaseID"]),""));
                }
                dr.Close();

                if (lst.Count > 0)
                {
                    foreach (Purchase p in lst)
                    {
                        select = "Select Item.ItemID,CompanyName,ProductName,Design,Size,isnull(Color,'')as Color,PB.Quantity from Item inner join (Select ItemID,Quantity from PurchaseInvoiceBody where PurchaseID=" + p.InvoiceNo +")PB on PB.ItemID=Item.ItemID";

                        SqlCommand c = new SqlCommand(select, con);
                        dr = c.ExecuteReader();

                        while (dr.Read())
                        {
                            Item i = new Item(Convert.ToInt32(dr["itemid"]), new ItemName((string)dr["companyname"], (string)dr["productname"], (string)dr["design"], (string)dr["size"]));
                            PurchaseLine obj = new PurchaseLine(new Category(), i, (decimal)dr["Quantity"], 0, 0, 0,0,0,"");
                            
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
    }
}

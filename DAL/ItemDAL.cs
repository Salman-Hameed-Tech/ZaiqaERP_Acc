
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Common;
using Common.Data_Sets;

namespace DAL
{
   public  class ItemDAL
    {
        List<Item > items=new List<Item> ();

        SqlTransaction VTran;
        private List<string> companyNames;
        private List<string> productNames;
        private List<string> designs ;
        private List<string> sizes;
        List<string> names = new List<string>();

        private string source = ReadProjectConfigFile.ConfigString();
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlTransaction vtran;
        SqlDataAdapter da;

        public string ItemPrice(int Itemid,int BranchID)
        {
            con = new SqlConnection(source);
            con.Open();
            cmd = new SqlCommand( "select case when sum(quantity) > 0  then sum(quantity*price) / Sum(quantity) else 0  end  from tblfifo where itemid= " + Itemid + "  and  branchid=" + BranchID , con);
                return Convert.ToString( cmd.ExecuteScalar  ());
        }
        public Boolean DeleteItem(Int32 vid)
        {
            try
            {
                            
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();
                cmd = new SqlCommand("SELECT COUNT(*) FROM PurchaseInvoiceBody where itemid=" + vid, con);
                cmd.Transaction = VTran;
                int VID = Convert.ToInt32(cmd.ExecuteScalar());
                if (VID == 0)
                {
                    cmd = new SqlCommand("delete from itembarcodes where itemid=" + vid, con);
                    cmd.Transaction = VTran;
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("delete from item where itemid=" + vid, con);
                    cmd.Transaction = VTran;
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("delete from currentstock where itemid=" + vid, con);
                    cmd.Transaction = VTran;
                    cmd.ExecuteNonQuery();

                    VTran.Commit();
                    return true;
                }
                else
                {
                    VTran.Commit();
                    return false;
                }
 
            }
            catch (Exception ex)
                {
                VTran.Rollback();
                    return false;
                    throw;
                }
        }

        public List<SchItems> GetMarinatedItems(string condition)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();   
                cmd = new SqlCommand("select Itemid,ItemName from Item "+ condition + " ", con);

                dr = cmd.ExecuteReader();
                List<SchItems> lstitem = new List<SchItems>();
                while (dr.Read())
                {

                    SchItems obj = new SchItems();
                    obj.ItemID = Convert.ToInt32(dr["ItemID"]);
                    obj.Productname = Convert.ToString(dr["ItemName"]);

                    lstitem.Add(obj);
                }
                return lstitem;


            }
            catch (Exception)
            {
                throw;
            }
            finally
            { con.Close(); }
        }

        public List<Barcodes> GetbarcodeTitle()
        {
            try
            {         
                con = new SqlConnection(source);
                con.Open();             
                cmd = new SqlCommand(" Select * from BarcodeTitle  ", con);             
                List<Barcodes> title = new List<Barcodes>();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Barcodes b = new Barcodes();
                        b.ID = Convert.ToInt32(dr["ID"]);
                        b.Barcode = Convert.ToString(dr["CompanyName"]);
                        title.Add(b);
                    }
                }
                dr.Close(); 
                return title;
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
        public Barcodes GetSinglebarcodeTitle(int id)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(" Select * from BarcodeTitle where ID="+id+"  ", con);
                Barcodes title = new Barcodes();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        title.ID = Convert.ToInt32(dr["ID"]);
                        title.Barcode = Convert.ToString(dr["CompanyName"]);
                      
                    }
                }
                dr.Close();
                return title;
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

        public bool DetelteBracodeTitle(int id)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand(" Delete from BarcodeTitle where ID="+id+"", con);
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();



                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            finally { con.Close(); }
        }

        public string GetMaxTitleID()
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();       
               
                cmd = new SqlCommand(" select isnull((max(id)),0)+1 from BarcodeTitle ", con);
            
                string VID = cmd.ExecuteScalar().ToString();

             
            
                return VID;
            }
            catch (Exception ex)
            {                         
                throw ex;
            }
            finally { con.Close(); }
        }

        public bool SaveBarocdeTitle(Barcodes common, bool isNew)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();
                int VID = 0;
                if (isNew)
                {
                    cmd = new SqlCommand(" select isnull((max(id)),0)+1 from BarcodeTitle ", con);
                    cmd.Transaction = VTran;
                    VID = Convert.ToInt32(cmd.ExecuteScalar());

                    cmd = new SqlCommand("Insert into BarcodeTitle (ID,CompanyName) values(" + VID + ",'" + common.Barcode + "')", con);
                    cmd.Transaction = VTran;
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    VID = common.ID;
                    cmd = new SqlCommand("Update BarcodeTitle Set CompanyName='"+common.Barcode+"' where ID="+ VID + " ", con);
                    cmd.Transaction = VTran;
                    cmd.ExecuteNonQuery();
                }

                VTran.Commit();
                return true;
            }
            catch (Exception ex)
            {

                VTran.Commit();
                return false;
                throw ex;
            }
            finally { con.Close(); }
        }

        public List<Item> EditModule(int id,int BranchId)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand("select *, isnull((select max(pib.PurPrice) from PurchaseInvoiceBody   pib inner join PurchaseInvoice pi on pi.purchaseid=pib.PurchaseId where Itemid=item.itemid and  pi.PurchaseDate=(select max( pi.purchasedate) from PurchaseInvoiceBody pib inner join PurchaseInvoice pi on pi.purchaseid=pib.PurchaseId where itemid=item.itemid)),0) as PurPrice  ,isnull(cs.price,0) as Rate,ibc.barcode,(select accountname from chartofaccounts where accountno=item.PurchaseAccount) as PurchaseAccName,(select accountname from chartofaccounts where accountno=item.SaleAccount) as SaleAccName,isnull(cs.Quantity,0) as Csqty from item  left outer join (select itemid,sum(quantity) as quantity,case when sum(quantity)<>0  then  sum(quantity*price)/sum(quantity) else 0  end  as price from tblfifo where branchid=" + BranchId + " group by itemid) Cs on Cs.Itemid=item.itemid  inner join itemcategory on item.categoryid=itemcategory.categoryid left join itembarcodes ibc on item.itemid=ibc.itemid where   item.itemid=" + id, con);
                dr = cmd.ExecuteReader();
                List<Item> lstitem = new List<Item>();
                while (dr.Read())
                {
                    ItemName name = new ItemName();
                    name.CompanyName = dr["CompanyName"].ToString();
                    name.Size = Convert.ToString(dr["Size"]);
                    name.Design = Convert.ToString(dr["Design"]);
                    name.ProductName = dr["ProductName"].ToString();
                    
                    


                    Item item = new Item();
                    item.SalePrice= Convert.ToDecimal(dr["Rate"]);
                    item.PurchasePrice= Convert.ToDecimal(dr["PurPrice"]);
                    item.CurrentStock = Convert.ToDecimal(dr["CsQty"]);
                    item.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                    item.ItemID = Convert.ToInt32(dr["ItemID"]);
                    item.BarCode = dr["barcode"].ToString();
                    item.ItemName = name;
                    item.PurchaseAccount = new ChartOfAccounts(dr["PurchaseAccount"].ToString(), dr["PurchaseAccName"].ToString());
                    item.SaleAccount = new ChartOfAccounts(dr["SaleAccount"].ToString(), dr["SaleAccName"].ToString());
                    item.IsActive= Convert.ToBoolean(dr["IsActive"]);
                    item.IsMarinated= Convert.ToBoolean(dr["IsMarinated"] == System.DBNull.Value ? false :  dr["IsMarinated"]);
                    item.IsBakeryItem = Convert.ToBoolean(dr["IsBakery"] == System.DBNull.Value ? false : dr["IsBakery"]);

                //    item.SalePrice = Convert.ToDecimal(dr["SalePrice"] == System.DBNull.Value ? false : dr["SalePrice"]);




                    lstitem.Add(item);
                }
                return lstitem;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            { con.Close(); }
        }

        public Item GetRecipieItem(int itemid)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand("select ItemID,ItemName from Item where ismarinated<>1 and itemid=" + itemid, con);
                dr = cmd.ExecuteReader();
                Item item = new Item();
                ItemName name = new ItemName();
                while (dr.Read())
                {
                 
                    item.ItemID = Convert.ToInt32(dr["ItemID"]);
                    name.ProductName = dr["ItemName"].ToString() ;
                    item.ItemName = name;
                    
                }
                return item;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            { con.Close(); }
        
            
        }

        public List<StockDifferenceSP> GetStockItems(int branchid)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                List<StockDifferenceSP> lst = new List<StockDifferenceSP>();

                cmd = new SqlCommand("Select ib.Barcode,isnull(ItemName,'')as ItemName,cs.Quantity from Item inner join ItemBarcodes ib on Item.ItemID=ib.itemid left join currentstock cs on Item.ItemID=cs.ItemID where cs.BranchID=" + branchid + "  order by ib.Barcode ", con);
              
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    StockDifferenceSP diff = new StockDifferenceSP();
                    diff.Barcode= dr["Barcode"].ToString();
                    diff.ItemName = dr["ItemName"].ToString();
                    diff.CsQty = Convert.ToInt32(dr["Quantity"]);
                    lst.Add(diff);
                }
                dr.Close();
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { con.Close(); }
        }

    
        public Item GetSingleItem(int id, StockType stockType, string PartyID, string Category)
        {
            try
            {
                Item item = null;
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand("", con);

                List<Barcode> barcodes = new List<Barcode>();
                cmd.CommandText = "SELECT Barcode FROM ItemBarcodes WHERE ItemID = " + id;
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    barcodes.Add(new Barcode(dr["Barcode"].ToString()));
                }
                dr.Close();
                string where;

                if (Category == "")
                {
                    where = " where 1=1 and i.itemid=" + id + " and i.categoryid =1 ";
                }
                else
                {
                    where = " where 1=1 and i.itemid=" + id + " and I.CategoryID='" + Category + "'";
                }


                //if (storeID == 0)
                //{
                cmd.CommandText = "Select I.ItemID,CS.Price,isnull(i.Size,'')as Size,isnull(i.Color,'')as Color,isnull(i.FinalSize,'') as FinalSize,isnull(i.PerKG,0) as PerKG,isnull(i.LengthSize,'') as LengthSize,isnull(i.unit,'') as unit,isnull(i.Discription,'') as Discription,isnull(I.ItemCode,'') as ItemCode,IsNull(I.HSCode,'') as HsCode,IsNull(I.Origin,'') as Origin ,I.CategoryID,C.CategoryName,I.ItemName,ISNULL(I.ItemUrduName,'')as ItemUrduName,isnull(I.CompanyName,'') as CompanyName,isnull(I.ProductName,'') as ProductName,isnull(I.Design,'') as Design,isnull(I.Size,'') as Size,I.Unit,isnull(I.PurchasePrice,0) as PurchasePrice,isnull(I.Origin,'')as Origin,isnull(I.SalePrice,0) as SalePrice,ISNULL(I.WholeSalePrice,0) as WholeSalePrice,I.ReOrderLevel,I.DiscountLimit,IsNull(I.PurchaseAccount,'') as PurchaseAccount,isnull((select sum(" + (stockType == StockType.Pack ? "Quantity" : "QtyLoose") + ")  from currentStock where ItemID = " + id + "),0) as QtyCS,isnull((select Price  from currentStock where ItemID = " + id + "),0) as Price, isnull((Select IsNull(AccountName,'')  from ChartOfAccounts where AccountNo = I.PurchaseAccount ),'') as PurchaseAccName,isNull(I.SaleAccount,'') as SaleAccount,isnull((Select isNull(AccountName,'') from ChartOfAccounts where AccountNo = I.SaleAccount),'') as SaleAccName,IsNull(I.SaleTaxAccount,'') as SaleTaxAccount,isnull((select isNull(AccountName,'') from chartofaccounts where AccountNo = I.SaleTaxAccount),'') as SaleTaxAccName,I.PrintName,I.IsActive,isnull(I.ShortKey,'') as ShortKey,case when len('')=0 then I.OpeningQty else isnull((select max(rate) from saleinvoicebody where sid=(select max(id) from saleinvoice si inner join saleinvoicebody sib on si.id=sib.sid  where partyid='' and sib.itemid=i.itemid)),0) end as openingqty  ,isnull(I.Packing,'') as Packing,I.Multiplier,I.PurPrice,isnull(I.ItemPrint,'') as ItemPrint,I.AddToPrint,isnull(i.Factor,0) as Factor from Item I inner join ItemCategory C on C.CategoryID = I.CategoryID inner join currentstock cs on cs.ITEMID = I.ItemID " + where;
                // cmd.CommandText = "Select I.ItemID,i.Size,i.FinalSize,i.LengthSize,i.unit,i.Discription,I.ItemCode,IsNull(I.HSCode,'') as HsCode,IsNull(I.Origin,'') as Origin ,I.CategoryID,C.CategoryName,I.ItemName,ISNULL(I.ItemUrduName,'')as ItemUrduName,I.CompanyName,I.ProductName,I.Design,I.Size,I.Unit,isnull(I.PurchasePrice,0) as PurchasePrice,I.Origin,I.SalePrice,ISNULL(I.WholeSalePrice,0) as WholeSalePrice,I.ReOrderLevel,I.DiscountLimit,IsNull(I.PurchaseAccount,'') as PurchaseAccount,(select sum(" + (stockType == StockType.Pack ? "Quantity" : "QtyLoose") + ")  from currentStock where ItemID = " + id + ") as QtyCS, (Select IsNull(AccountName,'')  from ChartOfAccounts where AccountNo = I.PurchaseAccount ) as PurchaseAccName,isNull(I.SaleAccount,'') as SaleAccount,(Select isNull(AccountName,'') from ChartOfAccounts where AccountNo = I.SaleAccount) as SaleAccName,IsNull(I.SaleTaxAccount,'') as SaleTaxAccount,(select isNull(AccountName,'') from chartofaccounts where AccountNo = I.SaleTaxAccount) as SaleTaxAccName,I.PrintName,I.IsActive,I.ShortKey,case when len('" + PartyID.ToString().Trim() + "')=0 then I.OpeningQty else isnull((select max(rate) from saleinvoicebody where sid=(select max(id) from saleinvoice si inner join saleinvoicebody sib on si.id=sib.sid  where partyid='" + PartyID + "' and sib.itemid=i.itemid)),0) end as openingqty  ,I.Packing,I.Multiplier,I.PurPrice,I.ItemPrint,I.AddToPrint,isnull(i.Factor,0) as Factor from Item I inner join ItemCategory C on C.CategoryID = I.CategoryID "+where;
                //}
                //else
                //{
                //    cmd.CommandText = "Select I.ItemID,IsNull(I.HSCode,'') as HsCode,IsNull(I.Origin,'') as Origin ,I.CategoryID,C.CategoryName,I.ItemName,ISNULL(I.ItemUrduName,'')as ItemUrduName,I.CompanyName,I.ProductName,I.Design,I.Size,I.Unit,(CASE CS.Price WHEN 0 THEN PurPrice ELSE CS.Price END ) as PurchasePrice,I.Origin,I.SalePrice,ISNULL(I.WholeSalePrice,0) as WholeSalePrice,I.ReOrderLevel,I.DiscountLimit,IsNull(I.PurchaseAccount,'') as PurchaseAccount, (Select IsNull(AccountName,'')  from ChartOfAccounts where AccountNo = I.PurchaseAccount ) as PurchaseAccName,isNull(I.SaleAccount,'') as SaleAccount,(Select isNull(AccountName,'') from ChartOfAccounts where AccountNo = I.SaleAccount) as SaleAccName," + (stockType == StockType.Pack ? "CS.Quantity" : "CS.QtyLoose") + " as QtyCS,IsNull(I.SaleTaxAccount,'') as SaleTaxAccount,(select isNull(AccountName,'') from chartofaccounts where AccountNo = I.SaleTaxAccount) as SaleTaxAccName,I.IsActive,I.ShortKey,I.OpeningQty,I.PrintName,I.Packing,I.Multiplier,I.PurPrice,I.ItemPrint,I.AddToPrint from Item I inner join ItemCategory C on C.CategoryID = I.CategoryID inner join CurrentStock CS on CS.ItemID = I.ItemID   where I.itemid = " + id + " and cs.StoreID = " + storeID;
                //}


                dr = cmd.ExecuteReader();
                List<Item> lstitem = new List<Item>();

                while (dr.Read())
                {

                    item = new Item(Convert.ToInt32(dr["itemid"]), new Category(Convert.ToInt32(dr["categoryid"]), Convert.ToString(dr["CategoryName"])), new ItemName(Convert.ToString(dr["companyname"]), Convert.ToString(dr["productname"]), Convert.ToString(dr["design"]), Convert.ToString(dr["size"])), Convert.ToDecimal(dr["purchaseprice"]), Convert.ToDecimal(dr["saleprice"]), Convert.ToDecimal(dr["discountlimit"]), Convert.ToDecimal(dr["reorderlevel"]), new ChartOfAccounts(Convert.ToString(dr["saleaccount"]), ""), new ChartOfAccounts(Convert.ToString(dr["purchaseaccount"]), ""), Convert.ToBoolean(dr["isactive"]), Convert.ToString(dr["shortkey"]), Convert.ToDouble(dr["openingqty"]), Convert.ToDouble(dr["purprice"]), Convert.ToBoolean(dr["islocked"]), Convert.ToString(dr["itemprint"]), Convert.ToDouble(dr["quantity"]), Convert.ToBoolean(dr["AddToPrint"] == System.DBNull.Value ? 0 : dr["AddToPrint"]), dr["DepartName"].ToString());
                    item.Unit = Convert.ToString(dr["Unit"] == System.DBNull.Value ? "" : dr["Unit"]);
                    lstitem.Add(item);


                    lstitem.Add(item);
                }
                return item;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            { con.Close(); }
        }

        public bool GetItemsList(ref DSItems dSItems, string categoryid)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                string where = "where i.CategoryID <> 0";
                if (categoryid != null)
                {
                    where = "   where i.CategoryID = "+categoryid+"  ";
                }

                cmd = new SqlCommand(" select d.DepartName,p.PartyName,ic.CategoryName,ibc.Barcode,i.ItemID,i.CompanyName,i.ProductName,i.Design,i.Color,i.Seasons,i.Size,i.PurchasePrice,i.SalePrice,i.MarginAmt from Item i  left join Parties p on i.PartyID=p.PartyID left join ItemBarcodes ibc on i.ItemID=ibc.itemid left join ItemCategory ic on i.CategoryID=ic.CategoryID left join Department d on ic.DepartID=d.DepartID   "+where+" ", con);
                da = new SqlDataAdapter(cmd);

                da.Fill(dSItems, "SPItems");
                return true;
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

        public string GetItemName(string barcode)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                string itemname = "";
                cmd = new SqlCommand("Select isnull(ItemName,'')as ItemName from Item inner join ItemBarcodes ib on Item.ItemID=ib.itemid where ib.Barcode='" + barcode + "'",con);
               // cmd.CommandTimeout = 6000;//seconds
                itemname =cmd.ExecuteScalar().ToString();
                return itemname;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { con.Close(); }
        }

        public List<DiscountOffer> GetSeletedBarcodes(List<Category> categories)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                List<DiscountOffer> discounts = new List<DiscountOffer>();


                if (categories.Count > 0)
                {
                    for (int i = 0; i < categories.Count; i++)
                    {
                        cmd = new SqlCommand("  select i.ItemName,ib.Barcode from Item i inner join ItemBarcodes ib on i.itemid=ib.ItemID where i.CategoryID = " + categories[i].Id + " ", con);
                        dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                DiscountOffer offer = new DiscountOffer();

                                offer.Barcode = dr["Barcode"].ToString();
                                offer.ItemName = dr["ItemName"].ToString();
                                discounts.Add(offer);

                            }
                        }
                        dr.Close();
                    }
                }
               
                return discounts;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetBarcodes(string where)
        {
            con = new SqlConnection(source);
            con.Open();
            cmd = new SqlCommand("  select ib.ItemID,ib.Barcode from Item i inner join ItemBarcodes ib on i.itemid=ib.ItemID  "+ where + " ", con);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet GetProductName()
        {
            try
            {

                con = new SqlConnection(source);
                con.Open();
                SqlDataAdapter Da = new SqlDataAdapter(" Select ItemID,ItemName from Item I ", con);
                DataSet ds = new DataSet();
                Da.SelectCommand.Transaction = VTran;
                Da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Item GetSingleItem(int id, StockType stockType, int storeID)
        {
            try

            {

                con = new SqlConnection(source);
                con.Open();
                //cmd = new SqlCommand("select *,isnull(islocked,cast(0 as bit)) as islocked,cs.quantity  from item inner join itemcategory on item.categoryid=itemcategory.categoryid Left Outer Join (Select ItemID,isNull(IsLocked,cast (0 as bit)) as islocked,quantity,price,branchid from currentstock where itemid=" + id + ")Cs on Cs.ItemID=item.itemid   where cs.branchid="+Globals.BranchID+"  and item.itemid=" + id, con);
                cmd = new SqlCommand("select item.ItemID,Item.ItemName,isnull(companyname,'')as companyname,isnull(productname,'')as productname,isnull(design,'')as design,isnull(size,'')as size,isnull(Color,'')as Color,cs.Price,isnull(islocked,cast(0 as bit)) as islocked,isnull(cs.quantity,0)as quantity  from item inner join itemcategory on item.categoryid=itemcategory.categoryid left join currentstock Cs on Cs.ItemID=item.itemid   where cs.branchid=" + Globals.BranchID + "  and item.itemid=" + id + "", con);
                dr = cmd.ExecuteReader();
                Item item = new Item();
                List<Item> lstitem = new List<Item>();
                while (dr.Read())
                {
                    // item = new Item(Convert.ToInt32(dr["itemid"]), new Category(Convert.ToInt32(dr["categoryid"]), Convert.ToString(dr["CategoryName"])), new ItemName(Convert.ToString(dr["companyname"]), Convert.ToString(dr["productname"]), Convert.ToString(dr["design"]), Convert.ToString(dr["size"]),(string)dr["Color"]), Convert.ToDecimal(dr["purchaseprice"]), Convert.ToDecimal(dr["saleprice"]), Convert.ToDecimal(dr["discountlimit"]), Convert.ToDecimal(dr["reorderlevel"]), new ChartOfAccounts(Convert.ToString(dr["saleaccount"]), ""), new ChartOfAccounts(Convert.ToString(dr["purchaseaccount"]), ""), Convert.ToBoolean(dr["isactive"]), Convert.ToString(dr["shortkey"]), Convert.ToDouble(dr["openingqty"]), Convert.ToDouble(dr["purprice"]), Convert.ToBoolean(dr["islocked"]), Convert.ToString(dr["itemprint"]), Convert.ToDouble(dr["quantity"]), Convert.ToBoolean(dr["AddToPrint"] == System.DBNull.Value ? 0 : dr["AddToPrint"]));

                    item.ItemID = Convert.ToInt32(dr["ItemID"]);
                    item.ItemName = new ItemName(Convert.ToString(dr["companyname"]), Convert.ToString(dr["productname"]), Convert.ToString(dr["design"]), Convert.ToString(dr["size"]));
                    item.CurrentStock = Convert.ToDecimal(dr["quantity"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["quantity"]));
                    //item.Unit = Convert.ToString(dr["Unit"] == System.DBNull.Value ? "" : dr["Unit"]);
                    item.Purprice1 = Convert.ToDouble(dr["Price"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Price"]));
                    lstitem.Add(item);
                }
                return item;

                /* Item item = null;
                 con = new SqlConnection(source);
                 con.Open();
                 cmd = new SqlCommand("", con);

                 List<Barcode> barcodes = new List<Barcode>();
                 cmd.CommandText = "SELECT Barcode FROM ItemBarcodes WHERE ItemID = " + id;
                 dr = cmd.ExecuteReader();

                 while (dr.Read())
                 {
                     barcodes.Add(new Barcode(dr["Barcode"].ToString()));
                 }
                 dr.Close();




                     cmd.CommandText = "select *,isnull(islocked,cast(0 as bit)) as islocked,cs.quantity  from item inner join itemcategory on item.categoryid=itemcategory.categoryid Left Outer Join (Select ItemID,isNull(IsLocked,cast (0 as bit)) as islocked,quantity from currentstock where itemid=" + id + ")Cs on Cs.ItemID=item.itemid  where item.itemid= " + id;



                 dr = cmd.ExecuteReader();
                 List<Item> lstitem = new List<Item>();

                 while (dr.Read())
                 {
                     item = new Item(id, new Category(Convert.ToInt32(dr["CategoryID"]), dr["CategoryName"].ToString()), new ItemName(dr["CompanyName"].ToString(), dr["ProductName"].ToString(), dr["Design"].ToString(), dr["Origin"].ToString()), Convert.ToDecimal(dr["PurchasePrice"]), Convert.ToDecimal(dr["SalePrice"]), Convert.ToDecimal(dr["DiscountLimit"]), Convert.ToDecimal(dr["ReOrderLevel"]), new ChartOfAccounts(dr["SaleAccount"].ToString(), dr["SaleAccName"].ToString()), new ChartOfAccounts(dr["PurchaseAccount"].ToString(), dr["PurchaseAccName"].ToString()), Convert.ToBoolean(dr["IsActive"]), dr["ShortKey"].ToString(), 0, Convert.ToDouble(dr["PurPrice"]), Convert.ToBoolean(dr["AddToPrint"]), dr["Unit"].ToString());

                     item.CurrentStock = (dr["QtyCS"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["QtyCS"]));
                    // item.Barcodes = barcodes;
                     lstitem.Add(item);
                 }
                 return item;*/
            }
            catch (Exception)
            {

                throw;
            }
            finally
            { con.Close(); }
        }




        //public bool UpdateColor()
        //{
        //    try
        //    {
        //        con = new SqlConnection(source);
        //        con.Open();
        //        cmd = new SqlCommand("", con);

        //        List<Item> ss = new List<Item>();
        //        cmd.CommandText = "select * from item";
        //        dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            Item item = new Item();
        //            item.ItemID = Convert.ToInt32(dr["ItemID"]);
        //            item.Color = dr["Color"].ToString();
        //            item.ItemName.ProductName = dr["ItemName"].ToString();


        //            ss.Add(item);
        //        }
        //        dr.Close();

        //        for(int i=0; i < ss.Count; i++)
        //        {
        //            cmd.CommandText = "update item set ItemName="+ss[i].ItemName.ProductName+"-"+ss[i].Color+" where itemid="+ss[i].ItemID+"";
        //        }




        //        return true;
        //    }

        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
      
        public DataSet GetTitle()
        {
            try
            {
               
                con = new SqlConnection(source);
                con.Open();
                SqlDataAdapter Da = new SqlDataAdapter(" select distinct(CompanyName) from  BarcodeTitle ", con);
                DataSet ds = new DataSet();
                Da.SelectCommand.Transaction = VTran;
                Da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveBarcodeTitle(string title)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(" insert into BarcodeTitle (CompanyName) values('"+title+"')", con);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
               throw ex;
            }
        }

        public List<Barcode> LoadBarcodes(int id)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                //cmd = new SqlCommand("Select * from itembarcodes where itemid=cast(barcode as int) and itemid=" + id  + " Union  Select * from itembarcodes where itemid<>cast(barcode as int) and itemid=" + id, con);
                cmd = new SqlCommand("Select * from itembarcodes  where Srno =(Select min(srno) from itembarcodes where itemid=" + id +  ") and itemid=" + id + "  Union   Select * from itembarcodes where srno not in (select min (srno) from itembarcodes where itemid=" + id  + " ) and itemid= " + id  , con);
                dr = cmd.ExecuteReader();
                List<Barcode> lstbar = new List<Barcode>();
                while (dr.Read())
                {
                    Barcode bar = new Barcode(Convert.ToString(dr["barcode"]));
                    lstbar.Add (bar);

                }
                return lstbar ;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            { con.Close(); }
        }
        public DataSet GetReportData(int iD)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                vtran = con.BeginTransaction();
                cmd = new SqlCommand("select Itemname,saleprice as ItemPrice from item  inner join itembarcodes ib on ib.itemid=item.itemid  where srno=(select min(srno) from itembarcodes where itemid=" + iD + ")", con);
                cmd.Transaction = vtran;
                da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                vtran.Rollback();
                throw;
            }
            finally
            {
                vtran.Commit();
                con.Close();
            }
        }
        public Boolean verifyBarcode(string barcode)
        {
            try 
	{	        
		
	
            string select = "select count(*) as no from itembarcodes where barcode='" + barcode + "'";
            con = new SqlConnection(source);
            con.Open();
                cmd = new SqlCommand(select, con);
            int vid = 0;
            vid = (int) cmd.ExecuteScalar();
            if (vid == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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
        public List<Item> GetItems(string Cat)
        {
            if (items == null) items  = new List<Item>();
            try
            {
                string select;
                if(Cat.Trim ().Length !=0)
                {
                    select = "Select * from Item inner join itemcategory on item.categoryid=itemcategory.categoryid where IsActive=1 and itemcategory.CategoryName='" + Cat +"'";
                }
                else
                {
                    select = "Select * from Item inner join itemcategory on item.categoryid=itemcategory.categoryid where IsActive=1";
                }

                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(select, con);

                dr = cmd.ExecuteReader();

                //Add Categories to Collection
                AddItems();

                con.Close();
                return items ;
            }
            catch (Exception ex)
            {
                return items ;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Item> GetReprintItems()
        {
            if (items == null) items = new List<Item>();
            try
            {
                string select;
                               
                //select = "Select ItemID,CompanyName,ProductName,Design,Size,Sum(OpeningQty) as OpeningQty from (Select Item.ItemID,CompanyName,ProductName,Design,Size,OpeningQty from Item where IsActive=1 and Item.AddToPrint=1 Union All Select Item.ItemID,CompanyName,ProductName,Design,Size,PB.Quantity from Item inner join (Select ItemID,Quantity from PurchaseInvoice PIN inner join PurchaseInvoiceBody PIB on PIN.PurchaseID=PIB.PurchaseID where PIN.AddToPrint=1)PB on PB.ItemID=Item.ItemID)Main Group By ItemID,CompanyName,ProductName,Design,Size";

                select = "Select Item.ItemID,CompanyName,ProductName,Design,Size,isnull(Color,'')as Color,OpeningQty from Item where IsActive=1 and Item.AddToPrint=1";

                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(select, con);

                dr = cmd.ExecuteReader();

                //Add Categories to Collection
                //

                Item newItem;
                ItemName name;
                Category c;
                ChartOfAccounts p, s;
                while (dr.Read())
                {                                   
                    newItem = new Item(Convert.ToInt32(dr["itemid"]), new ItemName(Convert.ToString(dr["companyname"]), Convert.ToString(dr["productname"]), Convert.ToString(dr["design"]), Convert.ToString(dr["size"])), Convert.ToDecimal(dr["openingqty"]));
                    items.Add(newItem);
                }
                dr.Close();

                con.Close();
                return items;
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

        public string GetDepartment(int categoryID)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                vtran = con.BeginTransaction();
                cmd = new SqlCommand("select isnull(DepartName,'') as DepartName from Department d inner join ItemCategory i on i.DepartID=d.DepartID where CategoryID=" + categoryID + "", con);
                cmd.Transaction = vtran;
                return  Convert.ToString(cmd.ExecuteScalar());
               // return departname;
            }
            catch (Exception)
            {
                vtran.Rollback();
                throw;
            }
            finally
            {
                vtran.Commit();
                con.Close();
            }
        }
        public Int32 GetDapartmentid(string Department)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                vtran = con.BeginTransaction();
                cmd = new SqlCommand("select isnull(DepartID,0) as DepartID from Department d  where DepartName='" + Department + "'", con);
                cmd.Transaction = vtran;
                return Convert.ToInt32(cmd.ExecuteScalar());
                // return departname;
            }
            catch (Exception)
            {
                vtran.Rollback();
                throw;
            }
            finally
            {
                vtran.Commit();
                con.Close();
            }
        }
        public int MaxID()
        {
            try
            {


                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand("Select IsNull(Max(itemid),0) +1 from item", con);
                return (Convert.ToInt32(cmd.ExecuteScalar()));
            }
            catch (Exception)
            {

                throw;
            }
            finally
            { con.Close(); }
        }
        public Item  PrintSticker(int itemid)
        {
            try 
	{	        
		
	
            con = new SqlConnection(source);
            con.Open();
            //cmd = new SqlCommand("select * from item  inner join itembarcodes ib on ib.itemid=item.itemid where item.itemid=" + itemid + " and cast(barcode as bigint)=item.itemid",con);
            cmd = new SqlCommand("select * from item  inner join itembarcodes ib on ib.itemid=item.itemid  where srno=(select min(srno) from itembarcodes where itemid=" + itemid  + ")", con);
            dr = cmd.ExecuteReader();
            Item objitem=new Item();
            while (dr.Read())
            { 
                
                objitem.BarCode  = Convert.ToString ( dr["barcode"] );
                objitem.ItemID = Convert.ToInt32(dr["ItemID"]);

                objitem.SalePrice = Convert.ToDecimal  (dr["SalePrice"] );
                objitem.CompanyName = Convert.ToString (dr["CompanyName"]);
               objitem.PrintName = (dr["ItemName"].ToString());





                }
            dr.Close();
                return objitem  ;
                }
	catch (Exception)
	{
		
		throw;
	}
            finally 
            {con.Close ();}
        }
        public void AddItems()
        {
            try
            {
                Item  newItem;
                ItemName name;
                Category c;
                ChartOfAccounts p,s;
                while (dr.Read())
                {
                    c = new Category((int)dr["CategoryID"], (string)dr["CategoryName"]);
                    name = new ItemName((string)dr["CompanyName"], (string)dr["ProductName"], (string)dr["Design"], (string)dr["Size"]);
                    p =new ChartOfAccounts((string )dr["PurchaseAccount"],"");
                    s =new ChartOfAccounts((string )dr["SaleAccount"],"");

                    newItem = new Item(Convert.ToInt32(dr["ItemID"]), c, name, (decimal)dr["PurchasePrice"], (decimal)dr["SalePrice"], (decimal)dr["DiscountLimit"], (decimal)dr["ReOrderLevel"], s, p, (Boolean)dr["IsActive"], Convert.ToString(dr["shortkey"]), Convert.ToBoolean(dr["AddToPrint"] == System.DBNull.Value ? 0 : dr["AddToPrint"]));
                    items.Add(newItem);
                }
                dr.Close();
            }
            catch (Exception ex) { throw ex; }

            finally { dr.Close(); }

        }

        public List<string > GetCompanyNames(int cat,bool i)
        {
            if (companyNames == null) companyNames = new List<string >();
            try
            {                
                string select;

                if (i)
                {
                    select = "Select Distinct CompanyName from Item where CategoryID="+cat;
                }
                else
                    select = "Select Distinct CompanyName from Item ";

                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(select, con);

                dr = cmd.ExecuteReader();

                //Add Categories to Collection
                while (dr.Read())
                {                 
                    companyNames.Add((string)dr["CompanyName"]);
                }
                dr.Close();

                con.Close();
                return companyNames ;
            }
            catch (Exception ex)
            {
                return companyNames ;
            }
            finally
            {
                con.Close();
            }
        }

        public List<string> GetProductNames(string company,bool i)
                            {
            if (productNames  == null) productNames  = new List<string>();
            try
            {
                string select;

                if (i)
                {
                   // select  = "Select Distinct ProductName from Item where CompanyName='" + company + "'";
                    select = "Select Distinct ProductName from Item i inner join  itemcategory ic on ic.DepartID= i.departmentid where  i.CompanyName='" + company + "'";
                }          
                else
                    select = "Select Distinct ProductName from Item ";

                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(select, con);

                dr = cmd.ExecuteReader();

                //Add Categories to Collection
                while (dr.Read())
                {
                    productNames.Add((string)dr["ProductName"]);
                }
                dr.Close();

                con.Close();
                return productNames ;
            }
            catch (Exception ex)
            {
                return productNames ;
            }
            finally
            {
                con.Close();
            }
        }

        public List<string> GetDesigns(string product,string company,bool i)
        {
            if (designs  == null) designs  = new List<string>();
            try
            {
                string select;

                if (i)
                {
                    select = "Select Distinct Design from Item where ProductName='" + product + "' and CompanyName='" + company + "'";
                }
                else
                    select = "Select Distinct Design from Item ";

                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(select, con);

                dr = cmd.ExecuteReader();

                //Add Categories to Collection
                while (dr.Read())
                {
                    designs.Add((string)dr["Design"]);
                }
                dr.Close();

                con.Close();
                return designs ;
            }
            catch (Exception ex)
            {
                return designs ;
            }
            finally
            {
                con.Close();
            }
        }

        public List<string> GetSizes(string design,string product,string company,bool i)
        {
            if (sizes  == null) sizes  = new List<string>();
            try
            {
                string select ;

                if (i)
                {
                    select = "Select Distinct Size from Item where Design='"+design+"' and ProductName='"+ product +"' and CompanyName='"+ company +"'";
                }
                else
                    select = "Select Distinct Size from Item";

                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(select, con);

                dr = cmd.ExecuteReader();

                //Add Categories to Collection
                while (dr.Read())
                {
                    sizes.Add((string)dr["Size"]);
                }
                dr.Close();

                con.Close();
                return sizes ;
            }
            catch (Exception ex)
            {
                return sizes ;
            }
            finally
            {
                con.Close();
            }
        }

        public Boolean ChkShortkey(string shortkey)
        { 
            try 
	{	        
		
	
        con = new SqlConnection(source);
                con.Open();
            cmd =new SqlCommand ("Select count(*) from item where shortkey='" + shortkey +"'",con);
                if (Convert.ToInt16 (cmd.ExecuteScalar() ) >0)
                {
                    return true;
                }
                else
                {return false;}
                }
	catch (Exception)
	{
		
		throw;
	}
            finally
            { con.Close(); }
        }
        public List<string> GetNames(string select)
        {
            try
            {

                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(select, con);

                dr = cmd.ExecuteReader();

                //Add Categories to Collection
                AddNames();

                con.Close();
                return names;
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

        public Item GetChallanItem(string id,string type,int BranchID)
        {
            try
            {               
                con = new SqlConnection(source);
                con.Open();
                string where = "";
                if (type == "I")
                {
                    where = " where     item.itemid = " + Convert.ToInt32(id) + "  ";
                }
                else if(type=="B")
                {
                    where = " where   ib.barcode = " + id + "  ";
                }


                cmd = new SqlCommand("select item.ItemID,ib.barcode,Item.ItemName,isnull(companyname,'')as companyname,isnull(productname,'')as productname,isnull(design,'')as design,isnull(size,'')as size,(select sum(quantity) from tblfifo where itemid=" + id+" and branchid="+ BranchID +")as quantity  from item inner join itemcategory on item.categoryid=itemcategory.categoryid  left join itembarcodes ib on item.itemid=ib.itemid    " + where+"  ",con);
                dr = cmd.ExecuteReader();
                Item item = new Item();
                List<Item> lstitem = new List<Item>();
                while (dr.Read())
                {
                    // item = new Item(Convert.ToInt32(dr["itemid"]), new Category(Convert.ToInt32(dr["categoryid"]), Convert.ToString(dr["CategoryName"])), new ItemName(Convert.ToString(dr["companyname"]), Convert.ToString(dr["productname"]), Convert.ToString(dr["design"]), Convert.ToString(dr["size"]),(string)dr["Color"]), Convert.ToDecimal(dr["purchaseprice"]), Convert.ToDecimal(dr["saleprice"]), Convert.ToDecimal(dr["discountlimit"]), Convert.ToDecimal(dr["reorderlevel"]), new ChartOfAccounts(Convert.ToString(dr["saleaccount"]), ""), new ChartOfAccounts(Convert.ToString(dr["purchaseaccount"]), ""), Convert.ToBoolean(dr["isactive"]), Convert.ToString(dr["shortkey"]), Convert.ToDouble(dr["openingqty"]), Convert.ToDouble(dr["purprice"]), Convert.ToBoolean(dr["islocked"]), Convert.ToString(dr["itemprint"]), Convert.ToDouble(dr["quantity"]), Convert.ToBoolean(dr["AddToPrint"] == System.DBNull.Value ? 0 : dr["AddToPrint"]));
                  
                    item.ItemID = Convert.ToInt32(dr["ItemID"]);
                    item.BarCode = (dr["barcode"]).ToString() ;
                    item.ItemName = new ItemName(Convert.ToString(dr["companyname"]), Convert.ToString(dr["productname"]), Convert.ToString(dr["design"]), Convert.ToString(dr["size"]));
                    item.CurrentStock = Convert.ToDecimal(dr["quantity"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["quantity"]));
                    //item.Unit = Convert.ToString(dr["Unit"] == System.DBNull.Value ? "" : dr["Unit"]);
                    
                    lstitem.Add(item);
                }
                return item;

               /* Item item = null;
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand("", con);

                List<Barcode> barcodes = new List<Barcode>();
                cmd.CommandText = "SELECT Barcode FROM ItemBarcodes WHERE ItemID = " + id;
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    barcodes.Add(new Barcode(dr["Barcode"].ToString()));
                }
                dr.Close();



                
                    cmd.CommandText = "select *,isnull(islocked,cast(0 as bit)) as islocked,cs.quantity  from item inner join itemcategory on item.categoryid=itemcategory.categoryid Left Outer Join (Select ItemID,isNull(IsLocked,cast (0 as bit)) as islocked,quantity from currentstock where itemid=" + id + ")Cs on Cs.ItemID=item.itemid  where item.itemid= " + id;
               


                dr = cmd.ExecuteReader();
                List<Item> lstitem = new List<Item>();

                while (dr.Read())
                {
                    item = new Item(id, new Category(Convert.ToInt32(dr["CategoryID"]), dr["CategoryName"].ToString()), new ItemName(dr["CompanyName"].ToString(), dr["ProductName"].ToString(), dr["Design"].ToString(), dr["Origin"].ToString()), Convert.ToDecimal(dr["PurchasePrice"]), Convert.ToDecimal(dr["SalePrice"]), Convert.ToDecimal(dr["DiscountLimit"]), Convert.ToDecimal(dr["ReOrderLevel"]), new ChartOfAccounts(dr["SaleAccount"].ToString(), dr["SaleAccName"].ToString()), new ChartOfAccounts(dr["PurchaseAccount"].ToString(), dr["PurchaseAccName"].ToString()), Convert.ToBoolean(dr["IsActive"]), dr["ShortKey"].ToString(), 0, Convert.ToDouble(dr["PurPrice"]), Convert.ToBoolean(dr["AddToPrint"]), dr["Unit"].ToString());

                    item.CurrentStock = (dr["QtyCS"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["QtyCS"]));
                   // item.Barcodes = barcodes;
                    lstitem.Add(item);
                }
                return item;*/
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            { con.Close(); }
        }
        public void AddNames()
        {
            try
            {

                while (dr.Read())
                {
                    names.Add(dr["Name"].ToString());
                }
                dr.Close();
            }
            catch
            {
                throw;
            }

            finally { dr.Close(); }

        }

        public Boolean SaveItem(Item i,List <Barcode> barcodes)
        {
            
           try
            {
                //string insert = "if exists(select * from Item where ItemID=" + i.ItemID + ")Begin Update Item set CategoryID=" + i.Category + ",ItemID=" + i.ItemID + ",ItemName='" + i.ItemName.ToString() + "',CompanyName='" + i.ItemName.CompanyName + "',ProductName='" + i.ItemName.ProductName + "',Design='" + i.ItemName.Design + "',Size='" + i.ItemName.CompanyName + " where CategoryID=" + c.Id + " End Else Begin Insert into ItemCategory Values(" + c.Id + ",\'" + c.Name + "\' )End";
                int VID = 0;
                con = new SqlConnection(source);
                con.Open();

                             
                vtran = con.BeginTransaction();
                cmd = new SqlCommand();
                if (i.ItemID == 0)
                {
                    cmd = new SqlCommand("Select isnull(max(itemid),0) +1 from item", con);
                    cmd.Transaction = vtran;
                    VID = Convert.ToInt32 ( cmd.ExecuteScalar());
                }
                else
                {
                    VID = i.ItemID;
                    cmd = new SqlCommand("delete from itembarcodes where itemid=" + VID, con);
                    cmd.Transaction = vtran;
                    cmd.ExecuteNonQuery();
                }

                cmd = new SqlCommand("SPInsertItems", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = vtran;
                              
                cmd.Parameters.AddWithValue("@CategoryID",i.CategoryID  );
                cmd.Parameters.AddWithValue("@ItemID", VID);
                cmd.Parameters.AddWithValue("@ItemName", i.ItemName.ToString().Replace("'","''"));
                cmd.Parameters.AddWithValue("@CompanyName",  i.ItemName.CompanyName.Replace("'","''"));
                cmd.Parameters.AddWithValue("@ProductName",  i.ItemName.ProductName.Replace("'","''"));
                cmd.Parameters.AddWithValue("@Design",  i.ItemName.Design.Replace("'","''"));
                cmd.Parameters.AddWithValue("@Size",  i.ItemName.Size.Replace("'","''"));
                cmd.Parameters.AddWithValue("@PurchaseAccount",  i.PurchaseAccount.AccountNo );
                cmd.Parameters.AddWithValue("@SaleAccount",  i.SaleAccount.AccountNo  );
                cmd.Parameters.AddWithValue("@isactive", Convert.ToInt16(i.IsActive));            
                cmd.Parameters.AddWithValue("@UserNo", User.UserNo);
                cmd.Parameters.AddWithValue("@Dated", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@isMarinated", Convert.ToInt16(i.IsMarinated));
                cmd.Parameters.AddWithValue("@SalePrice", Convert.ToInt16(i.SalePrice));
                cmd.Parameters.AddWithValue("@isBakery", Convert.ToInt16(i.IsBakeryItem));

                cmd.ExecuteNonQuery();
                int VCount = 0;
                foreach (Barcode  item in barcodes )
                {
                    if (VCount != 0)
                    {
                        cmd = new SqlCommand("Insert into itembarcodes(itemid,barcode) values (" + VID + ",'" + item.Itembarcode + "')", con);
                        cmd.CommandType = CommandType.Text;
                        cmd.Transaction = vtran;
                        cmd.ExecuteNonQuery();
                    }
                    VCount += 1;
                }
                vtran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                vtran.Rollback();
                throw;

            }
            finally
            { con.Close(); }
        }

        public bool UpdatePrintStatus(int it)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();


                vtran = con.BeginTransaction();
                cmd = new SqlCommand("Alter Table Item Disable Trigger GenerateBarcodeUpdate", con);
                cmd.Transaction = vtran;
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("Update Item Set AddToPrint=0 where ItemID=" + it,con);
                cmd.Transaction = vtran;

                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("Alter Table Item enable Trigger GenerateBarcodeUpdate", con);
                cmd.Transaction = vtran;
                cmd.ExecuteNonQuery();
                vtran.Commit();

                con.Close();

                return true;
            }
            catch (Exception ex)
            {
                vtran.Rollback();
                throw ex;
            }
            finally { con.Close(); }
        }
        public Item GetItemDetail(int itemID)
        {
            try
            {
                SqlDataReader drItem;
                Item it=new Item ();

                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand("Select * from item I inner join CurrentStock CS on CS.ItemID=I.ItemID and CS.BranchID="+Globals.BranchID+"  where I.ItemID="+itemID+" and isActive=1" , con);

                drItem = cmd.ExecuteReader();
                while (drItem .Read ())
                {                   
                    it.ItemID = Convert.ToInt32 ( drItem["ItemID"]) ;
                    it.ItemName = new ItemName((string)drItem["CompanyName"], (string)drItem["ProductName"], (string)drItem["Design"], (string)drItem["Size"]);
                    it.CurrentStock = Convert.ToDecimal(drItem["Quantity"]);
                    it.PurchasePrice = Convert.ToDecimal(drItem["Price"]);
                    it.ReorderLimit = Convert.ToDouble(drItem["ReOrderLevel"]);
                    it.ShortKey = Convert.ToString(drItem["ShortKey"] == null ? "" : drItem["ShortKey"]);
                }

                return it;
            }
            catch (Exception ex)
            {  
                throw ex; 
            }
            finally
            { con.Close(); }
        }

        public List<Item> GetStockReportItems(string where)
        {
            try
            {
                if (items == null) items = new List<Item>();

                string select;                

                select = "Select IC.CategoryID,IC.CategoryName,I.ItemID,I.CompanyName,I.IsActive,I.ProductName,I.Design,I.Size,isnull(I.Color,'')as Color,I.ItemName,CS.Quantity,CS.Price from CurrentStock CS inner join Item I on CS.ItemID=I.ItemID inner join ItemCategory IC on IC.CategoryID=I.CategoryID inner join (Select Distinct ItemID from ItemBarcodes) IB on IB.ItemID=I.ItemID  where IsActive=1 " + where;
                

                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(select, con);

                dr = cmd.ExecuteReader();

                //Add Categories to Collection
                Item newItem;
                ItemName name;
                Category c;
                ChartOfAccounts p, s;

                while (dr.Read())
                {
                    c = new Category((int)dr["CategoryID"], (string)dr["CategoryName"]);
                    name = new ItemName((string)dr["CompanyName"], (string)dr["ProductName"], (string)dr["Design"], (string)dr["Size"]);
                    p = new ChartOfAccounts();
                    s = new ChartOfAccounts();

                    newItem = new Item(Convert.ToInt32(dr["ItemID"]), c, name, 0, 0, 0, 0, s, p, (Boolean)dr["IsActive"], "", 0, Convert.ToDouble(dr["Price"]), false, "", Convert.ToDouble(dr["Quantity"]), Convert.ToBoolean(dr["AddToPrint"] == System.DBNull.Value ? 0 : dr["AddToPrint"]));
                                       
                    items.Add(newItem);
                }
                dr.Close();

                con.Close();
                return items;
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

        public List<Item> GetReOrderReportItems(string where)
        {
            try
            {
                if (items == null) items = new List<Item>();

                string select;

                select = "select I.ItemID,I.Companyname,I.ProductName,I.Design,I.Size,isnull(I.Color,'')as Color,CS.Quantity,I.ReOrderLevel as Level from Item I inner join ItemCategory IC on IC.CategoryID=I.CategoryID inner join CurrentStock CS on CS.ItemID=I.ItemID where CS.Quantity <= I.ReOrderLevel and I.ReOrderLevel > 0 and I.IsActive=1" + where;


                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(select, con);

                dr = cmd.ExecuteReader();

                //Add Categories to Collection
                Item newItem;
                ItemName name;
                Category c;
                ChartOfAccounts p, s;

                while (dr.Read())
                {                    
                    name = new ItemName((string)dr["CompanyName"], (string)dr["ProductName"], (string)dr["Design"], (string)dr["Size"]);
                    
                    newItem = new Item(Convert.ToInt32(dr["ItemID"]),name, (decimal)Convert.ToDouble(dr["Quantity"]),Convert.ToDouble(dr["Level"]));

                    items.Add(newItem);
                }
                dr.Close();

                con.Close();
                return items;
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
              

        public decimal GetDiscountOffer(int ItemID)
        {
            try
            {
                decimal dis = 0;
                con = new SqlConnection(source);
                con.Open();
              
                cmd = new SqlCommand("select discount  from  discountoffers doo where    '" + System.DateTime.Now.ToString("yyyy/MM/dd 00:00:00") + "' >= doo.fromdate and  '" + System.DateTime.Now.ToString("yyyy/MM/dd 00:00:00") + "'  <=doo.todate  and  branchid=" + Globals.BranchID + "  and IsActive=1    and doo.ItemName =(select ItemName from Item where ItemID=" + ItemID + ") ", con);
                dis = Convert.ToDecimal(cmd.ExecuteScalar());
                //cmd = new SqlCommand("Select Discount from DiscountOffers Where Categoryid=(Select categoryid=(select distinct(categoryid) from discountoffers where categoryid=tb.categoryid) from (Select CategoryID from item where itemid=" + ItemID + ")tb) And isnull(Companyname,'@-')= isnull((Select (select Distinct(Companyname)  from discountoffers where Companyname=tb.Companyname) from (Select Companyname from item where itemid=" + ItemID + ")tb),'@-') And isnull(Productname,'@-') = isnull((Select (select Distinct(Productname)  from discountoffers where productname=tb.productname) from (Select productname  from item where itemid=" + ItemID + ")tb),'@-') And isnull(design,'@-')= isnull((Select (select Distinct(design) from discountoffers where design=tb.design) from (Select design  from item where itemid=" + ItemID + ")tb),'@-') And isnull(size,'@-') = IsNull((Select (select Distinct(size) from discountoffers where size=tb.size) from (Select size  from item where itemid=" + ItemID + ")tb),'@-')", con);
                if (dis == 0)
                {
                    cmd = new SqlCommand("select top 1 IsNull(discount,0) as discount  from(select max(id)  as id ,offerid,discount  from (select 1 as id,offerid,discount  from  discountoffers doo where    '" + System.DateTime.Now.ToString("yyyy/MM/dd 00:00:00") + "' >= doo.fromdate and  '" + System.DateTime.Now.ToString("yyyy/MM/dd 00:00:00") + "'  <=doo.todate  and  branchid=" + Globals.BranchID + "  and IsActive=1 and  doo.categoryid=(select categoryid from item where itemid=" + ItemID + ") and doo.companyname is null and doo.productname is null and doo.design is null and doo.size is null Union All select 2 as id,offerid,discount  from  discountoffers doo where doo.categoryid=(select categoryid from item where itemid=" + ItemID + ") and doo.companyname =( select companyname from item where itemid=" + ItemID + ")   and doo.productname is null and doo.design is null and doo.size is null Union All select 3 as id,offerid,discount  from  discountoffers doo where doo.categoryid=(select categoryid from item where itemid=" + ItemID + ") and doo.companyname = (select companyname from item where itemid=" + ItemID + ")   and doo.productname = (select productname from item where itemid=" + ItemID + ")  and doo.design is null and doo.size is null Union All select 4 as id,offerid,discount  from  discountoffers doo  where doo.categoryid=(select categoryid from item where itemid=" + ItemID + ") and doo.companyname = (select companyname from item where itemid=" + ItemID + ")   and doo.productname = (select productname from item where itemid=" + ItemID + ")  and doo.design=(select design from item where itemid=" + ItemID + ")  and doo.size is null Union All select 5 as id,offerid,discount  from  discountoffers doo where doo.categoryid=(select categoryid from item where itemid=" + ItemID + ") and doo.companyname = (select companyname from item where itemid=" + ItemID + ")   and doo.productname = (select productname from item where itemid=" + ItemID + ")  and doo.design=(select design from item where itemid=" + ItemID + ")  and doo.size=(select size from item where itemid=" + ItemID + "))tb group by offerid,discount)tb1", con);
                    dis = Convert.ToDecimal(cmd.ExecuteScalar());
                }

                
                return dis;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        public bool GetProfitLose(ref Common.Data_Sets.DSProfitLose ds, string where)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                string select;

                //select = "If(Select IsShop from Godown where GodownID=" + godownID + ")=1 Begin 	Select IC.CategoryID,IC.CategoryName,I.ItemID,I.ItemName,CS.Quantity as CurrentStock,CS.Price as Purprice1,(Select Godownname from Godown where GodownID=" + godownID + ") as GodownName," + godownID + " as GodownID from CurrentStock CS inner join Item I on CS.ItemID=I.ItemID inner join ItemCategory IC on IC.CategoryID=I.CategoryID inner join (Select Distinct ItemID from ItemBarcodes) IB on IB.ItemID=I.ItemID  where IsActive=1 " + where + " Order by I.ItemID End Else Begin select CategoryID,CategoryName,ItemID,ItemName,IsNull(Sum(CurrentStock),0) as CurrentStock,PurPrice1 as Purprice1,GodownName,GodownID from (select IC.CategoryID,IC.CategoryName,I.ItemID,I.ItemName,IsNull(-Sum(Quantity),0) as CurrentStock,ST.Price as Purprice1,GodownName,GodownID from StockShift ST inner join Godown G on G.GodownID=ST.Source inner join Item I on ST.ItemID=I.ItemID inner join ItemCategory IC on IC.CategoryID=I.CategoryID inner join (Select Distinct ItemID from ItemBarcodes) IB on IB.ItemID=I.ItemID  where G.IsShop=0 and ST.Source=" + godownID + where + " group By IC.CategoryID,IC.Categoryname,I.ItemID,I.ItemName,ST.Price,GodownName,GodownID	Union All select IC.CategoryID,IC.CategoryName,I.ItemID,I.ItemName,IsNull(Sum(Quantity),0) as CurrentStock,ST.Price as Purprice1,GodownName,GodownID from StockShift ST inner join Godown G on G.GodownID=ST.Destination inner join Item I on ST.ItemID=I.ItemID inner join ItemCategory IC on IC.CategoryID=I.CategoryID inner join (Select Distinct ItemID from ItemBarcodes) IB on IB.ItemID=I.ItemID  where G.IsShop=0 and ST.Destination=" + godownID + where + " group By IC.CategoryID,IC.Categoryname,I.ItemID,I.ItemName,ST.Price,GodownName,GodownID)Main 	group By CategoryID,Categoryname,ItemID,ItemName,PurPrice1,GodownName,GodownID End";
                select = "SELECT I.ItemName,I.Packing ,SUM(RecQty * (CASE IsLoose WHEN 1 THEN 1 ELSE I.Multiplier END) * Rate - RecQty * (CASE IsLoose WHEN 1 THEN 1 ELSE I.Multiplier END) * SIB.PurPrice) AS Profit    FROM SaleInvoiceBody SIB INNER JOIN Item I ON I.ItemID = SIB.ItemID " + where + " GROUP BY I.ItemName,I.Packing   Order By ItemName";

                cmd = new SqlCommand(select, con);

                da.SelectCommand = cmd;

                da.Fill(ds, "SPProfitLose");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

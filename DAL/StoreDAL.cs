using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Common;

namespace DAL
{
    public class StoreDAL
    {
        List<Store > stores = new List<Store >();
        SqlDataAdapter da = new SqlDataAdapter();

        private string source = ReadProjectConfigFile.ConfigString();
      
                    
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlTransaction VTran;



        public Int32 GetMaxID()
        {
            try
            {
                string Select = "Select isNull(Max(ID),0) + 1 as ID from Store";
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(Select, con);

                Int32 VID = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                return VID;
            }
            catch
            {
                con.Close();
                throw;
            }
        }

        public List<Store > GetItemStock(int id, StockType stockType)
        {
            try
            {

                Store  item = null;
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand("Select cs.StoreID as ID,Store.Name as StoreName,IsNull(I.HSCode,'') as HsCode,IsNull(I.Origin,'') as Origin,cs.StoreID," + (stockType == StockType.Pack ? "Quantity" : "QtyLoose") + " as QtyCs ,I.CategoryID,C.CategoryName,I.ItemName,I.CompanyName,I.ProductName,I.Design,I.Size,I.Unit,I.Origin from Item I inner join ItemCategory C on C.CategoryID = I.CategoryID inner join CurrentStock CS on cs.ItemID = I.ItemID inner join Store on CS.StoreID = Store.ID  where I.itemid = " + id, con);
                dr = cmd.ExecuteReader();
                List<Store > lstitem = new List<Store >();

                while (dr.Read())
                {
                    item = new Store(Convert.ToInt32(dr["ID"]), dr["StoreName"].ToString(), Convert.ToDecimal(dr["QtyCS"]));                   
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

        public List<Store > GetStores(int id,LoadStoresFor loadFor,int DOID)
        {
            if (stores == null) stores =new List<Store>();
            try
            {
                string where = "";

                if (id > 0)
                {
                    where = " Where ID = " + id;
                }
                string select = "";

                if (loadFor == LoadStoresFor.All)
                {
                    select = "Select * from Category" + where ; 
                }
                else if (loadFor == LoadStoresFor.OGP )
                {
                    select = "select S.ID , S.Name,IsOutSide from DOBody DOB INNER JOIN Store S ON S.ID = DOB.StoreID WHERE DOB.DOID = " + DOID;
                }

                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(select, con );
                
                dr = cmd.ExecuteReader();

                //Add Categories to Collection
                AddCategories();

                con.Close();
                return stores ;
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

        
        public void AddCategories()
        {
            try
            {
                Store   newCategory;
                while (dr.Read())
                {
                    //if (categories.Count == 0)
                    //{
                    //    newCategory = new Category(0, "---All Categories---",false ,false );
                    //    categories.Add(newCategory);
                    //}
                    newCategory=new Store ((int)dr["ID"],(string) dr["Name"],Convert .ToBoolean (dr["IsOutSide"]));
                    stores.Add(newCategory);
                }
                dr.Close();
            }
            catch (Exception ex) 
            {
                throw;
            }

            finally { dr.Close(); }
            
        }

        public Boolean  SaveStore(Store  c,bool isNew)
        {
            try
            {

                int VID=0;
                                 con = new SqlConnection(ReadProjectConfigFile.ConfigString () );
                con.Open();
                VTran = con.BeginTransaction();
                                if (isNew )
                {
                    cmd = new SqlCommand("Select IsNull(Max(id),0) +1 From Store", con);
                    cmd.Transaction = VTran;
                    VID =Convert.ToInt32 ( cmd.ExecuteScalar());
                                        }
                else
                {
                    VID=c.Id;
                }
                 string insert = "if exists(select * from Store where ID=" + VID + ")Begin Update Store set ID=" + VID + ",Name='" + c.Name + "',IsOutSide = " + Convert .ToInt32 ( c.IsOutSide )  + " where ID=" + VID + " End Else Begin Insert into Store(ID,Name,IsOutside) Values(" + VID + ",\'" + c.Name + "\'," + Convert .ToInt32 (c.IsOutSide  ) + ")End";
                cmd = new SqlCommand(insert, con);
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();
                VTran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                VTran.Rollback();
                throw;
            }
            finally
            { con.Close(); }
        }

        public Boolean DeleteStore(Store  c)
        {
            try
            {
                string delete = "Delete From Store where ID="+c.Id ;
                con = new SqlConnection(source);
                con.Open();

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

        public bool GetData(ref Common.Data_Sets.DSGodownStock ds,  string where)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                string select;
                //cmd = new SqlCommand(" exec spstkbalances '" + System.DateTime.Now.Date.ToString("yyyy-MM-dd 00:00:00") + "'", con);
                //cmd.ExecuteNonQuery();//
                //select = "If(Select IsShop from Godown where GodownID=" + godownID + ")=1 Begin 	Select IC.CategoryID,IC.CategoryName,I.ItemID,I.ItemName,CS.Quantity as CurrentStock,CS.Price as Purprice1,(Select Godownname from Godown where GodownID=" + godownID + ") as GodownName," + godownID + " as GodownID from CurrentStock CS inner join Item I on CS.ItemID=I.ItemID inner join ItemCategory IC on IC.CategoryID=I.CategoryID inner join (Select Distinct ItemID from ItemBarcodes) IB on IB.ItemID=I.ItemID  where IsActive=1 " + where + " Order by I.ItemID End Else Begin select CategoryID,CategoryName,ItemID,ItemName,IsNull(Sum(CurrentStock),0) as CurrentStock,PurPrice1 as Purprice1,GodownName,GodownID from (select IC.CategoryID,IC.CategoryName,I.ItemID,I.ItemName,IsNull(-Sum(Quantity),0) as CurrentStock,ST.Price as Purprice1,GodownName,GodownID from StockShift ST inner join Godown G on G.GodownID=ST.Source inner join Item I on ST.ItemID=I.ItemID inner join ItemCategory IC on IC.CategoryID=I.CategoryID inner join (Select Distinct ItemID from ItemBarcodes) IB on IB.ItemID=I.ItemID  where G.IsShop=0 and ST.Source=" + godownID + where + " group By IC.CategoryID,IC.Categoryname,I.ItemID,I.ItemName,ST.Price,GodownName,GodownID	Union All select IC.CategoryID,IC.CategoryName,I.ItemID,I.ItemName,IsNull(Sum(Quantity),0) as CurrentStock,ST.Price as Purprice1,GodownName,GodownID from StockShift ST inner join Godown G on G.GodownID=ST.Destination inner join Item I on ST.ItemID=I.ItemID inner join ItemCategory IC on IC.CategoryID=I.CategoryID inner join (Select Distinct ItemID from ItemBarcodes) IB on IB.ItemID=I.ItemID  where G.IsShop=0 and ST.Destination=" + godownID + where + " group By IC.CategoryID,IC.Categoryname,I.ItemID,I.ItemName,ST.Price,GodownName,GodownID)Main 	group By CategoryID,Categoryname,ItemID,ItemName,PurPrice1,GodownName,GodownID End";
                select = "Select IC.CategoryID,IC.CategoryName,I.ItemID,I.ItemName,I.Multiplier,CS.Quantity as CurrentStock,CS.QtyLoose,CS.Price as Purprice1, S.Name as StoreName,S.ID as StoreID from item I inner Join Currentstock Cs on I.ItemID=Cs.Itemid Inner Join ItemCategory IC on I.CategoryID=Ic.CategoryID inner Join Store S on Cs.StoreID = S.ID   "  + where + " Order By IC.CategoryID,I.ItemName";

                cmd = new SqlCommand(select, con);

                da.SelectCommand = cmd;

                da.Fill(ds, "GodownStock");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public bool GetData(ref Common.Data_Sets.DSStoreStockCT  ds, string where)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                string select;

                //select = "If(Select IsShop from Godown where GodownID=" + godownID + ")=1 Begin 	Select IC.CategoryID,IC.CategoryName,I.ItemID,I.ItemName,CS.Quantity as CurrentStock,CS.Price as Purprice1,(Select Godownname from Godown where GodownID=" + godownID + ") as GodownName," + godownID + " as GodownID from CurrentStock CS inner join Item I on CS.ItemID=I.ItemID inner join ItemCategory IC on IC.CategoryID=I.CategoryID inner join (Select Distinct ItemID from ItemBarcodes) IB on IB.ItemID=I.ItemID  where IsActive=1 " + where + " Order by I.ItemID End Else Begin select CategoryID,CategoryName,ItemID,ItemName,IsNull(Sum(CurrentStock),0) as CurrentStock,PurPrice1 as Purprice1,GodownName,GodownID from (select IC.CategoryID,IC.CategoryName,I.ItemID,I.ItemName,IsNull(-Sum(Quantity),0) as CurrentStock,ST.Price as Purprice1,GodownName,GodownID from StockShift ST inner join Godown G on G.GodownID=ST.Source inner join Item I on ST.ItemID=I.ItemID inner join ItemCategory IC on IC.CategoryID=I.CategoryID inner join (Select Distinct ItemID from ItemBarcodes) IB on IB.ItemID=I.ItemID  where G.IsShop=0 and ST.Source=" + godownID + where + " group By IC.CategoryID,IC.Categoryname,I.ItemID,I.ItemName,ST.Price,GodownName,GodownID	Union All select IC.CategoryID,IC.CategoryName,I.ItemID,I.ItemName,IsNull(Sum(Quantity),0) as CurrentStock,ST.Price as Purprice1,GodownName,GodownID from StockShift ST inner join Godown G on G.GodownID=ST.Destination inner join Item I on ST.ItemID=I.ItemID inner join ItemCategory IC on IC.CategoryID=I.CategoryID inner join (Select Distinct ItemID from ItemBarcodes) IB on IB.ItemID=I.ItemID  where G.IsShop=0 and ST.Destination=" + godownID + where + " group By IC.CategoryID,IC.Categoryname,I.ItemID,I.ItemName,ST.Price,GodownName,GodownID)Main 	group By CategoryID,Categoryname,ItemID,ItemName,PurPrice1,GodownName,GodownID End";
               // select = "Select I.ItemName,CAST(CAST(Quantity as int) as Varchar(10)) + ' | ' + CAST(CAST(QtyLoose as int) as Varchar(10)) as Quantity ,S.Name as StoreName,I.CategoryID,I.ProductName,I.CompanyName,I.Design,I.Origin from CurrentStock CS INNER JOIN Store S ON S.ID = CS.StoreID INNER JOIN Item I ON I.ItemID = CS.ItemID   " + where  + " UNION ALL Select I.ItemName,CAST(CAST(SUM(Quantity) as INT) as Varchar(15)) as Quantity ,'z QTY   (Pack)' as StoreName,I.CategoryID,I.ProductName,I.CompanyName,I.Design,I.Origin from CurrentStock CS INNER JOIN Store S ON S.ID = CS.StoreID INNER JOIN Item I ON I.ItemID = CS.ItemID   " + where + " GROUP BY ItemName,I.CategoryID,I.ProductName,I.CompanyName,I.Design,I.Origin UNION ALL Select I.ItemName,CAST(CAST(SUM(QtyLoose) as INT) as Varchar(15)) as Quantity ,'z QTY  (Loose)' as StoreName,I.CategoryID,I.ProductName,I.CompanyName,I.Design,I.Origin from CurrentStock CS INNER JOIN Store S ON S.ID = CS.StoreID INNER JOIN Item I ON I.ItemID = CS.ItemID INNER JOIN ItemCategory IC ON IC.CategoryID = I.CategoryID   "+ where +" GROUP BY ItemName,I.CategoryID,I.ProductName,I.CompanyName,I.Design,I.Origin";
                //select = "Select I.ItemName,CAST(CAST(Quantity as int) as Varchar(10)) + ' | ' + CAST(CAST(QtyLoose as int) as Varchar(10)) as Quantity ,S.Name as StoreName,I.CategoryID,I.ProductName,I.CompanyName,I.Design,I.Origin from CurrentStock CS INNER JOIN Store S ON S.ID = CS.StoreID INNER JOIN Item I ON I.ItemID = CS.ItemID   " + where + " UNION ALL Select I.ItemName,CAST(CAST(SUM(Quantity) as INT) as Varchar(15)) as Quantity ,'z QTY   (Pack)' as StoreName,I.CategoryID,I.ProductName,I.CompanyName,I.Design,I.Origin from CurrentStock CS INNER JOIN Store S ON S.ID = CS.StoreID INNER JOIN Item I ON I.ItemID = CS.ItemID   " + where + " GROUP BY ItemName,I.CategoryID,I.ProductName,I.CompanyName,I.Design,I.Origin ";
                select="Select I.ItemName,(SUM(Quantity)) as Quantity ,'Quantity' as StoreName,I.CategoryID,I.ProductName,I.CompanyName,I.Design,I.Origin from CurrentStock CS INNER JOIN Store S ON S.ID = CS.StoreID INNER JOIN Item I ON I.ItemID = CS.ItemID   " + where + " GROUP BY ItemName,I.CategoryID,I.ProductName,I.CompanyName,I.Design,I.Origin ";
                cmd = new SqlCommand(select, con);

                da.SelectCommand = cmd;

                da.Fill(ds, "SPStoreStockCT");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool GetData(ref Common.Data_Sets.DSItemLedger ds, int itemID, string fromDate, string toDate, int storeID,bool isLoose)
        {
            try
            {
                Object objFrom = fromDate;
                Object objTo = toDate;

                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("SPItemLedger", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ItemID", itemID);
                cmd.Parameters.AddWithValue("@StoreID", storeID );
                cmd.Parameters.AddWithValue("@IsLoose", Convert.ToInt32 (isLoose));
                cmd.Parameters.AddWithValue("@FromDate", string.Format("{0:yyyy-MM-dd 00:00:00}", objFrom));
                cmd.Parameters.AddWithValue("@ToDate", string.Format("{0:yyyy-MM-dd 00:00:00}", objTo));

                da.SelectCommand = cmd;
                da.Fill(ds, "SPItemLedger");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool GetDataRaw(ref Common.Data_Sets.DSItemLedger ds, int itemID, string fromDate, string toDate, int storeID, bool isLoose)
        {
            try
            {
                Object objFrom = fromDate;
                Object objTo = toDate;

                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("SPItemLedgerFinish", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ItemID", itemID);
                cmd.Parameters.AddWithValue("@StoreID", storeID);
                cmd.Parameters.AddWithValue("@IsLoose", Convert.ToInt32(isLoose));
                cmd.Parameters.AddWithValue("@FromDate", string.Format("{0:yyyy-MM-dd 00:00:00}", objFrom));
                cmd.Parameters.AddWithValue("@ToDate", string.Format("{0:yyyy-MM-dd 00:00:00}", objTo));

                da.SelectCommand = cmd;
                da.Fill(ds, "SPItemLedger");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetDataFinish(Common.Data_Sets.DSGodownStock ds, string where)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                string select;

                //select = "If(Select IsShop from Godown where GodownID=" + godownID + ")=1 Begin 	Select IC.CategoryID,IC.CategoryName,I.ItemID,I.ItemName,CS.Quantity as CurrentStock,CS.Price as Purprice1,(Select Godownname from Godown where GodownID=" + godownID + ") as GodownName," + godownID + " as GodownID from CurrentStock CS inner join Item I on CS.ItemID=I.ItemID inner join ItemCategory IC on IC.CategoryID=I.CategoryID inner join (Select Distinct ItemID from ItemBarcodes) IB on IB.ItemID=I.ItemID  where IsActive=1 " + where + " Order by I.ItemID End Else Begin select CategoryID,CategoryName,ItemID,ItemName,IsNull(Sum(CurrentStock),0) as CurrentStock,PurPrice1 as Purprice1,GodownName,GodownID from (select IC.CategoryID,IC.CategoryName,I.ItemID,I.ItemName,IsNull(-Sum(Quantity),0) as CurrentStock,ST.Price as Purprice1,GodownName,GodownID from StockShift ST inner join Godown G on G.GodownID=ST.Source inner join Item I on ST.ItemID=I.ItemID inner join ItemCategory IC on IC.CategoryID=I.CategoryID inner join (Select Distinct ItemID from ItemBarcodes) IB on IB.ItemID=I.ItemID  where G.IsShop=0 and ST.Source=" + godownID + where + " group By IC.CategoryID,IC.Categoryname,I.ItemID,I.ItemName,ST.Price,GodownName,GodownID	Union All select IC.CategoryID,IC.CategoryName,I.ItemID,I.ItemName,IsNull(Sum(Quantity),0) as CurrentStock,ST.Price as Purprice1,GodownName,GodownID from StockShift ST inner join Godown G on G.GodownID=ST.Destination inner join Item I on ST.ItemID=I.ItemID inner join ItemCategory IC on IC.CategoryID=I.CategoryID inner join (Select Distinct ItemID from ItemBarcodes) IB on IB.ItemID=I.ItemID  where G.IsShop=0 and ST.Destination=" + godownID + where + " group By IC.CategoryID,IC.Categoryname,I.ItemID,I.ItemName,ST.Price,GodownName,GodownID)Main 	group By CategoryID,Categoryname,ItemID,ItemName,PurPrice1,GodownName,GodownID End";
                // select = "Select I.ItemName,CAST(CAST(Quantity as int) as Varchar(10)) + ' | ' + CAST(CAST(QtyLoose as int) as Varchar(10)) as Quantity ,S.Name as StoreName,I.CategoryID,I.ProductName,I.CompanyName,I.Design,I.Origin from CurrentStock CS INNER JOIN Store S ON S.ID = CS.StoreID INNER JOIN Item I ON I.ItemID = CS.ItemID   " + where  + " UNION ALL Select I.ItemName,CAST(CAST(SUM(Quantity) as INT) as Varchar(15)) as Quantity ,'z QTY   (Pack)' as StoreName,I.CategoryID,I.ProductName,I.CompanyName,I.Design,I.Origin from CurrentStock CS INNER JOIN Store S ON S.ID = CS.StoreID INNER JOIN Item I ON I.ItemID = CS.ItemID   " + where + " GROUP BY ItemName,I.CategoryID,I.ProductName,I.CompanyName,I.Design,I.Origin UNION ALL Select I.ItemName,CAST(CAST(SUM(QtyLoose) as INT) as Varchar(15)) as Quantity ,'z QTY  (Loose)' as StoreName,I.CategoryID,I.ProductName,I.CompanyName,I.Design,I.Origin from CurrentStock CS INNER JOIN Store S ON S.ID = CS.StoreID INNER JOIN Item I ON I.ItemID = CS.ItemID INNER JOIN ItemCategory IC ON IC.CategoryID = I.CategoryID   "+ where +" GROUP BY ItemName,I.CategoryID,I.ProductName,I.CompanyName,I.Design,I.Origin";
                //select = "Select I.ItemName,CAST(CAST(Quantity as int) as Varchar(10)) + ' | ' + CAST(CAST(QtyLoose as int) as Varchar(10)) as Quantity ,S.Name as StoreName,I.CategoryID,I.ProductName,I.CompanyName,I.Design,I.Origin from CurrentStock CS INNER JOIN Store S ON S.ID = CS.StoreID INNER JOIN Item I ON I.ItemID = CS.ItemID   " + where + " UNION ALL Select I.ItemName,CAST(CAST(SUM(Quantity) as INT) as Varchar(15)) as Quantity ,'z QTY   (Pack)' as StoreName,I.CategoryID,I.ProductName,I.CompanyName,I.Design,I.Origin from CurrentStock CS INNER JOIN Store S ON S.ID = CS.StoreID INNER JOIN Item I ON I.ItemID = CS.ItemID   " + where + " GROUP BY ItemName,I.CategoryID,I.ProductName,I.CompanyName,I.Design,I.Origin ";
                select = "Select IC.CategoryID,IC.CategoryName,I.ItemID,I.ItemName,I.Multiplier,CS.Quantity as CurrentStock,CS.QtyLoose,CS.Price as Purprice1, S.Name as StoreName,S.ID as StoreID from item I inner Join ProductionCurrentStock Cs on I.ItemID=Cs.Itemid Inner Join ItemCategory IC on I.CategoryID=Ic.CategoryID inner Join Store S on Cs.StoreID = S.ID   " + where + " Order By IC.CategoryID,I.ItemName";
                cmd = new SqlCommand(select, con);

                da.SelectCommand = cmd;

                da.Fill(ds, "GodownStock");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using Common;

namespace DAL
{
    public class ItemReportDAL
    {
        private string source = ReadProjectConfigFile.ConfigString();
        SqlConnection con;
        SqlCommand cmd;

        SqlDataAdapter da = new SqlDataAdapter();

        public bool GetHotItems(ref Common.Data_Sets.DSCurrentStock ds, string fromDate,string toDate,int level,string where,string itemFilter)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                string select;

                select = "Select * From ( Select tb.categoryid,tb.categoryname ,tb.itemid,tb.itemname," + level + " as Purprice1,Currentstock= IsNull(( Select Sum(SIB.Quantity) as CurrentStock   from  SaleInvoiceBody SIB  where  SIB.IsCancelled=0 and  SIB.SaleDate between '" + fromDate + "' and '" + toDate + "' and itemid=Tb.itemid ),0) From (Select itemname,ic.categoryid,itemid,categoryname  from Item  Inner join itemcategory IC on item.categoryid=ic.categoryid where isactive=1 " + itemFilter + ")tb )tb" + where  +" Order By CurrentStock Desc"; 

                cmd = new SqlCommand(select, con);

                da.SelectCommand = cmd;

                da.Fill(ds, "CurrentStock");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetColdItems(ref Common.Data_Sets.DSCurrentStock ds, string fromDate, string toDate, int level)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                string select;

                select = "select * from (Select IC.CategoryID,IC.CategoryName,I.ItemID,I.ItemName,Sum(SIB.Quantity) as CurrentStock," + level + " as Purprice1 from Item I inner join ItemCategory IC on IC.CategoryID=I.CategoryID inner join SaleInvoiceBody SIB on SIB.ItemID=I.ItemID where IsActive=1 and SIB.IsCancelled=0 and SIB.SaleDate between '" + fromDate + "' and '" + toDate + "' Group By IC.CategoryID,IC.CategoryName,I.ItemID,I.ItemName)Main where CurrentStock <= " + level;      //+ " Order by I.ItemID"

                cmd = new SqlCommand(select, con);

                da.SelectCommand = cmd;

                da.Fill(ds, "CurrentStock");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using Common;

namespace DAL
{
    public class CurrentStockDAL
    {
        private string source = ReadProjectConfigFile.ConfigString();
        SqlConnection con;
        SqlCommand cmd;

        SqlDataAdapter da = new SqlDataAdapter();

        public bool GetData(ref Common.Data_Sets.DSCurrentStock ds, string where)
        {
            try
            {               
                con = new SqlConnection(source);
                con.Open();

                string select;

                select = "Select I.ShortKey,IC.CategoryID,IC.CategoryName,I.ItemID,I.ItemName,I.Unit,I.SalePrice,CS.Quantity as CurrentStock,CS.Price as Purprice1 from CurrentStock CS inner join Item I on CS.ItemID=I.ItemID inner join ItemCategory IC on IC.CategoryID=I.CategoryID inner join (Select Distinct ItemID from ItemBarcodes) IB on IB.ItemID=I.ItemID  where IsActive=1 " + where + " Order by I.ItemID";

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

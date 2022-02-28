using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using Common;


namespace DAL
{
    public class StockAdjRptDAL
    {
        private string source = ReadProjectConfigFile.ConfigString();
        SqlConnection con;
        SqlCommand cmd;

        SqlDataAdapter da = new SqlDataAdapter();

        public bool GetData(ref Common.Data_Sets.DSStockAdj ds, int itemID, string fromDate, string toDate)
        {
            try
            {
                Object objFrom = fromDate;
                Object objTo = toDate;
                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("SPStockAdj", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ItemID", itemID);
                cmd.Parameters.AddWithValue("@FromDate", objFrom);
                cmd.Parameters.AddWithValue("@ToDate", objTo);

                da.SelectCommand = cmd;

                da.Fill(ds, "StockAdj");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

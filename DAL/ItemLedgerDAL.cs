using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using Common;


namespace DAL
{
    public class ItemLedgerDAL
    {
        private string source = ReadProjectConfigFile.ConfigString();
        SqlConnection con;
        SqlCommand cmd;

        SqlDataAdapter da = new SqlDataAdapter();

        public bool GetData( ref Common.Data_Sets.DSItemLedger ds, int itemID, string fromDate,string toDate,int BranchID,string LedgerType)
        {
            try
            {
                Object objFrom = fromDate;
                Object objTo = toDate;
                Object objItemID = itemID;
                Object objBranchID = BranchID;
                con = new SqlConnection(source);
                con.Open();
               
                cmd = new SqlCommand("SPItemLedgerBranch", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ItemID", objItemID);
                cmd.Parameters.AddWithValue("@FromDate", objFrom);
                cmd.Parameters.AddWithValue("@ToDate", objTo);
                if(BranchID > 0)
                {
                    cmd.Parameters.AddWithValue("@BranchID", objBranchID);
                }
              
                da.SelectCommand = cmd;

                da.Fill(ds, "ItemLedger");

                return true;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }
}

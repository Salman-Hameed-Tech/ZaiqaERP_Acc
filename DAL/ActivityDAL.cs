using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;

using Common;


namespace DAL
{
    public class ActivityDAL
    {
        private string source = ReadProjectConfigFile.ConfigString();
        SqlConnection con;
        SqlCommand cmd;

        SqlDataAdapter da = new SqlDataAdapter();

        public bool GetData( ref Common.Data_Sets.DSActivity ds, DateTime fromDate, DateTime toDate,int branchid)
        {
            try
            {
                Object objFrom = fromDate;
                Object objTo = toDate;
                Object objid = branchid;
                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("SPActivity", con);
                
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                       
                cmd.Parameters.AddWithValue("@FromDate", objFrom);
                cmd.Parameters.AddWithValue("@ToDate", objTo);
                if (branchid > 0)
                {
                    cmd.Parameters.AddWithValue("@BranchID", objid);
                }

                da.SelectCommand = cmd;

                da.Fill(ds, "Activity");

                return true;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }
}

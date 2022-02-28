using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using Common;
using System.Configuration;

namespace DAL
{
    public class CashBookDAL
    {
        //private string source = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;
        private string source = ReadProjectConfigFile.ConfigString();
        SqlConnection con;
        SqlCommand cmd;

        SqlDataAdapter da = new SqlDataAdapter();

        public System.Data.DataSet GetRRegister(string FromDate, String Todate)
        {
            con = new SqlConnection(source);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("exec spreceiperegister '" + FromDate + "','" + Todate + "'", con);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            con.Close();
            return ds;

        }
        public System.Data.DataSet GetStkBalances(string FromDate, String Todate,string AccNo)
        {

            con = new SqlConnection(source);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("exec Spkitchensheet  '" + FromDate + "','" + Todate + "' " + (AccNo.ToString().Trim().Length==0?"":"," + AccNo)    , con);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            con.Close();
            return ds;

        }
        public bool GetData(ref Common.Data_Sets.DSCashBook ds, string fromDate, string toDate, string procedureName, string VoucherType,int  Branchid)
        {
            try
            {
                Object objFrom = fromDate;
                Object objTo = toDate;
                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand(procedureName, con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                
                cmd.Parameters.AddWithValue("@FromDate", objFrom);
                cmd.Parameters.AddWithValue("@ToDate", objTo);
                if (Branchid!=0)
                { 
                cmd.Parameters.AddWithValue("@BranchID", Branchid );
                }
                da.SelectCommand = cmd;

                da.Fill(ds, "SPCashBook");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

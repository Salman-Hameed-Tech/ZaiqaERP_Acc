using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DaySettingDAL
    {

        SqlConnection con;

        string source = ReadProjectConfigFile.ConfigString();
        SqlCommand cmd;
        SqlDataReader dr;
        
        SqlTransaction VTran;

        public bool TransferData(string ServerStr)
        {
            try
            {
                
                
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand("select count(*) from orders where orderdate in (select daydate from daydates where isclosed=0)", con);
                int Vcount = Convert.ToInt32(cmd.ExecuteScalar());
                if (Vcount > 1)
                {
                    cmd = new SqlCommand("select * from orders where orderdate in (select daydate from daydates where isclosed=0) and orderid not in (select max(orderid) from orders where orderdate in (select daydate from daydates where isclosed=0))", con);
                    dr = cmd.ExecuteReader();
                    SqlBulkCopy sbc = new SqlBulkCopy(ServerStr);
                    sbc.DestinationTableName = "orders";
                    sbc.WriteToServer(dr);
                    sbc.Close();
                    dr.Close();
                    cmd.CommandText = "select * from ordersbody where orderdate in (select daydate from daydates where isclosed=0) and orderid not in (select max(orderid) from orders where orderdate in (select daydate from daydates where isclosed=0))";
                    dr = cmd.ExecuteReader();
                    sbc = new SqlBulkCopy(ServerStr);
                    sbc.DestinationTableName = "ordersbody";
                    sbc.WriteToServer(dr);
                    sbc.Close();
                    dr.Close();
                    cmd = new SqlCommand(" delete  from ordersbody where orderdate in (select daydate from daydates where isclosed=0) and orderid not in (select max(orderid) from orders where orderdate in (select daydate from daydates where isclosed=0))  delete from orders where orderdate in (select daydate from daydates where isclosed=0) and orderid not in (select max(orderid) from orders where orderdate in (select daydate from daydates where isclosed=0))", con);
                    cmd.ExecuteNonQuery(); 
                    con.Close();



                }
                else if (Vcount==1) 
                {
                    cmd = new SqlCommand("select * from orders where orderdate in (select daydate from daydates where isclosed=0) ", con);
                    dr = cmd.ExecuteReader();
                    SqlBulkCopy sbc = new SqlBulkCopy(ServerStr);
                    sbc.DestinationTableName = "orders";
                    sbc.WriteToServer(dr);
                    sbc.Close();
                    dr.Close();
                    cmd.CommandText = "select * from ordersbody where orderdate in (select daydate from daydates where isclosed=0) ";
                    dr = cmd.ExecuteReader();
                    sbc = new SqlBulkCopy(ServerStr);
                    sbc.DestinationTableName = "ordersbody";
                    sbc.WriteToServer(dr);
                    sbc.Close();
                    dr.Close();
                    cmd = new SqlCommand("select * from ordersgst where orderdate in (select daydate from daydates where isclosed=0) ", con);
                    dr = cmd.ExecuteReader();
                    sbc = new SqlBulkCopy(ServerStr);
                    sbc.DestinationTableName = "ordersgst";
                    sbc.WriteToServer(dr);
                    sbc.Close();
                    dr.Close();
                    cmd.CommandText = "select * from ordersbodygst where orderdate in (select daydate from daydates where isclosed=0) ";
                    dr = cmd.ExecuteReader();
                    sbc = new SqlBulkCopy(ServerStr);
                    sbc.DestinationTableName = "ordersbodygst";
                    sbc.WriteToServer(dr);
                    sbc.Close();
                    dr.Close();
                    cmd = new SqlCommand(" delete from ordersbody where orderdate in (select daydate from daydates where isclosed=0)  delete from orders where orderdate in (select daydate from daydates where isclosed=0)", con);
                    cmd.ExecuteNonQuery(); 
                    con.Close(); 


                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
                return false;
                
            }
        }
        public bool StartDay(int branchid)
        {
            try
            {
                con = new SqlConnection(source);
                if (con.State == ConnectionState.Closed) con.Open();                
                string select = "Select count(tb.dat) from (select max(daydate) as dat  from daydates where branchid="+ branchid + ")tb";
                cmd = new SqlCommand(select, con);
                int result = Convert.ToInt16(cmd.ExecuteScalar());
                if (result != 0)//if the table is not empty
                {                    
                    if (CheckDayEnd(branchid))//if day is ended
                    {
                        if (con.State == ConnectionState.Closed) con.Open();
                        
                        select = "insert into daydates (dayid,daydate,isclosed,closingdate,closedby,branchid) values ((Select isnull(max(dayid),0) + 1  from daydates),'" + System.DateTime.Now + "',0,Null,'" + User.UserNo + "',"+branchid+")";
                        cmd = new SqlCommand(select, con);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    select = "insert into daydates (dayid,daydate,isclosed,closingdate,closedby,branchid) values ((Select isnull(max(dayid),0) + 1  from daydates),'" + System.DateTime.Now + "',0,Null,'" + User.UserNo + "',"+branchid+")";
                    cmd = new SqlCommand(select, con);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.Close(); }
        }


        public bool EndDay(int branchid)
        {
            try
            {
                con = new SqlConnection(source);
                if (con.State == ConnectionState.Closed) con.Open();                                
                string select = "Update DayDates set isclosed=1,closingdate='" + System.DateTime.Now.ToString("yyyy-MM-dd 00:00:00") + "',closedby='" + User.UserNo + "' where  dayid=(select max(dayid) from daydates )";
                cmd = new SqlCommand(select, con);
                cmd.ExecuteNonQuery();

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.Close(); }
        }



        public DateTime GetRunningDate(int branchid)//returns running date which is not ended
        {
            try
            {
                con = new SqlConnection(source);
                if (con.State == ConnectionState.Closed) con.Open();

                string select = "Select case  when tb.dt is null then (select CONVERT(smalldatetime, getdate(),108 ))  else (select tb.dt) end from ((select max(daydate) as dt  from daydates ))tb";
                cmd = new SqlCommand(select, con);
                return Convert.ToDateTime(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.Close(); }
        }
        public DateTime GetServerDateTime()
        {
            try
            {
                con = new SqlConnection(source);
                if (con.State == ConnectionState.Closed) con.Open();

                string select = "select CONVERT(smalldatetime, getdate(),108 )";
                cmd = new SqlCommand(select, con);
                return Convert.ToDateTime(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.Close(); }
        }


        public bool CheckDayEnd(int branchid) // returns true when day is ended
        {
            try
            {
                con = new SqlConnection(source);
                if (con.State == ConnectionState.Closed) con.Open();
                string select;
                int result;
                select = "Select count(tb.dat) from (select max(daydate) as dat  from daydates )tb";
                cmd = new SqlCommand(select, con);
                result = Convert.ToInt16(cmd.ExecuteScalar());
                if (result != 0)//if the table is not empty
                {
                    select = "select COUNT(isclosed) from (select isclosed from daydates where isclosed=0 )tb";
                    cmd = new SqlCommand(select, con);
                    int i = Convert.ToInt16(cmd.ExecuteScalar());
                    return Convert.ToBoolean(i > 0 ? false : true);
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.Close(); }
        }
    }
}

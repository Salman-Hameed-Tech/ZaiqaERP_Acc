using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using Common;

namespace DAL
{
    public class DayLogDAL
    {
        private string source = ReadProjectConfigFile.ConfigString();

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlTransaction VTran;

        public Boolean CheckDayStart()
        {
            try
            {
                int i = 0;

                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();

                cmd = new SqlCommand("Select Count(*) from DayStartLog where DayStart is not Null and DayEnd is Null", con);
                cmd.Transaction = VTran;
                i = (int)cmd.ExecuteScalar();

                VTran.Commit();
                con.Close();

                if (i > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                VTran.Rollback();
                throw ex;
            }
            finally { con.Close(); }
        }

        public DateTime GetDay(int branchid)//
        {
            try
            {
                DateTime d;
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();
                 cmd = new SqlCommand("Select DayDate from DayDates where IsClosed=0 ", con);
             
                cmd.Transaction = VTran;
                d = (DateTime)cmd.ExecuteScalar();

                VTran.Commit();
                con.Close();

                return d;
            }
            catch (Exception ex)
            {
                VTran.Rollback();
                throw ex;
            }
            finally { con.Close(); }
        }

        public Boolean StartDay()
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();

                cmd = new SqlCommand("Insert into DayStartLog Values('"+ System.DateTime.Now.Date +"',NULL)", con);
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

        public Boolean EndDay()
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();

                cmd = new SqlCommand("Update DayStartLog set DayEnd='" + System.DateTime.Now.Date + "' where DayStart is not null and DayEnd is null", con);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Common;

namespace DAL
{
   public class CounterDAL
    {
        List<Counter> counter = new List<Counter>();
        private string source = ReadProjectConfigFile.ConfigString();


        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlTransaction VTran;

        public Int32 GetMaxID()
        {
            try
            {
                string Select = "Select isNull(Max(ID),0) + 1 as ID from Counter";
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

        public Int32 GetCounterid(int userno)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                string select = "select isnull(CounterID,0) as CounterID  from Users where UserNo= " + userno + "";
                cmd = new SqlCommand(select, con);
                Int32 VID = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                return VID;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Int32 GetBranchid(int userno)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                string select = "select isnull(BranchID,0) as CounterID  from Users where UserNo= " + userno + "";
                cmd = new SqlCommand(select, con);
                Int32 VID = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                return VID;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Int32 GetAdmin(int userno)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                string select = "select IsAdministrator  from Users where UserNo= " + userno + "";
                cmd = new SqlCommand(select, con);
                Int32 VID = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                return VID;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Int32 GetAllusers(int userno)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                string select = "select isnull(AllUsers,0) as AllUsers from Users where UserNo= " + userno + "";
                cmd = new SqlCommand(select, con);
                Int32 VID = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                return VID;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool Getusers(int user)
        {
            try
            {
                List<User> coillist = new List<User>();

                SqlConnection conn = new SqlConnection(source);
                using (conn)
                {
                    SqlCommand cmd = new SqlCommand("Select * from users where userno=" + user + " ", conn);
                  

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    bool isExist;
                    if (reader.HasRows)
                    {
                        isExist = true;
                    }
                    else
                    {
                        isExist = false;
                    }

                    return isExist;
                   
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete(string ID)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();
                cmd = new SqlCommand("Delete from Counter where ID='" + ID + "'", con);
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                VTran.Rollback();
                return false;
                throw ex;
            }
            finally
            {
                VTran.Commit();
                con.Close();
            }
        }

        public Counter GetSingleCounter(int ID)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();
                Counter cou = null;
                cmd = new SqlCommand("Select * from Counter where ID=" + ID + "", con);
                cmd.Transaction = VTran;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cou = new Counter(Convert.ToInt32(dr["ID"]), Convert.ToString(dr["CounterName"]));
                    }
                }
                return cou;
            }
            catch (Exception)
            {
                dr.Close();
                VTran.Rollback();
                throw;
            }
            finally
            {
                dr.Close();
                VTran.Commit();
                con.Close();
            }
        }

        public List<Counter> GetCounter()
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();
                List<Counter> coun = new List<Counter>();
                cmd = new SqlCommand("select * from Counter order by ID", con);
                cmd.Transaction = VTran;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Counter c = new Counter(Convert.ToInt32(dr["ID"]), Convert.ToString(dr["CounterName"]));
                        coun.Add(c);
                    }
                }
                return coun;
            }
            catch (Exception)
            {
                dr.Close();
                VTran.Rollback();
                throw;
            }
            finally
            {
                dr.Close();
                VTran.Commit();
                con.Close();
            }
        }
        public bool Save(Counter C, bool isNew)

        {
            try
            {
                int CID = 0;
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();
                if (isNew)
                {
                    cmd = new SqlCommand("select isnull(Max(ID),0) + 1 from Counter", con);
                    cmd.Transaction = VTran;
                    CID = Convert.ToInt32(cmd.ExecuteScalar());
                   
                    //cmd = new SqlCommand("insert into Counter(ID,CounterName) Values(" + VID + ",'" + C.CounterName + "')", con);
                }
                else
                {
                    CID = C.ID;
                    //cmd = new SqlCommand("update Counter set CounterName='" + C.CounterName + "' where ID=" + C.ID + "", con);
                }
                string insert = "if exists(select * from Counter where ID=" + CID + ")Begin Update Counter set ID=" + CID + ",CounterName = '" + C.CounterName + "' WHERE ID=" + CID + " End Else Begin Insert into Counter(ID,CounterName) Values(" + CID + ",'" + C.CounterName + "')End";
                cmd = new SqlCommand(insert, con);
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();

                VTran.Commit();
                C.ID = CID;
                return true;
               
            }
            catch (Exception ex)
            {
                VTran.Rollback();
                throw ex;
            }
            finally
            { con.Close(); }
        }

    }
}

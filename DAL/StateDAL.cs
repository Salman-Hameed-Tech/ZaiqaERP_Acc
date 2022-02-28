using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Common;

namespace DAL
{
   public class StateDAL
    {
        private string source = ReadProjectConfigFile.ConfigString();
        List<States> S;
      
        SqlConnection con;
        SqlCommand cmd;

        SqlTransaction VTran;
        SqlDataReader dr;
        SqlDataAdapter da = new SqlDataAdapter();

        public int GetMaximumID()
        {
            try
            {
                int VID = 0;
                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("Select IsNull(Max(ID),0) +1 From State", con);
                VID = Convert.ToInt32(cmd.ExecuteScalar());

                return VID;
            }
            catch
            {
                throw;
            }
        }
        public States GetSingleStates(int ID)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();
                States cou = null;
                cmd = new SqlCommand("Select * from State where ID=" + ID + "", con);
                cmd.Transaction = VTran;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cou = new States(Convert.ToInt32(dr["ID"]), Convert.ToString(dr["StateName"]));
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
        public List<States> GetStates()
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();
                List<States> coun = new List<States>();
                cmd = new SqlCommand("select * from State", con);
                cmd.Transaction = VTran;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        States c = new States(Convert.ToInt32(dr["ID"]), Convert.ToString(dr["StateName"]));
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

        public bool Save(States s, bool Isnew)
        {
            try
            {

                int SID = 0;
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();
                if (Isnew)
                {
                    cmd = new SqlCommand("Select IsNull(Max(ID),0) +1 as Code From State", con);
                    cmd.Transaction = VTran;
                    SID = Convert.ToInt32(cmd.ExecuteScalar());
                }
                else
                {
                    SID = s.ID;
                }
                string insert = "if exists(select * from State where ID=" + SID + ")Begin Update State set ID=" + SID + ",StateName = '" + s.StateName + "' WHERE ID=" + SID + " End Else Begin Insert into State(ID,StateName) Values(" + SID + ",'" + s.StateName + "')End";
                cmd = new SqlCommand(insert, con);
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();

                VTran.Commit();
                s.ID = SID;
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


        public bool Delete(string ID)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();
                cmd = new SqlCommand("Delete from State where ID='" + ID + "'", con);
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


    }
}

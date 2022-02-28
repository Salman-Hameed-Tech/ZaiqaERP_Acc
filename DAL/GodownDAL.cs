using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using System.Data.SqlClient;

namespace DAL
{
    public class GodownDAL
    {
        List<Godown> godowns = new List<Godown>();


        private string source = ReadProjectConfigFile.ConfigString();


        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlTransaction VTran;

        public List<Godown> GetGodowns()
        {
            if (godowns == null) godowns = new List<Godown>();
            try
            {
                string select = "Select * from Branch";

                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(select, con);

                dr = cmd.ExecuteReader();


                //Add Categories to Collection
                AddGodowns();

                con.Close();
                return godowns;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public int GetMaximumID()
        {
            int VID = 0;
            con = new SqlConnection(source);
            con.Open();
            cmd = new SqlCommand("Select IsNull(Max(GodownId),0) +1 From Godown", con);
            VID=(int)cmd.ExecuteScalar();

            return VID;

        }
        public void AddGodowns()
        {
            try
            {
                Godown newGodown;

                while (dr.Read())
                {
                    newGodown = new Godown((int)dr["ID"], (string)dr["BranchName"]);
                    godowns.Add(newGodown);
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex) { throw ex; }

            finally { dr.Close(); }

        }

        public void  SaveGodown(Godown g)
        {
            try
            {
                int VID = 0;
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();
                if (g.GodownId == 0)
                {
                    cmd = new SqlCommand("Select IsNull(Max(GodownId),0) +1 From Godown", con);
                    cmd.Transaction = VTran;
                    VID = Convert.ToInt32(cmd.ExecuteScalar());
                }
                else
                {
                    VID = g.GodownId;
                }
                string insert = "if exists(select * from Godown where GodownID=" + VID + ")Begin Update Godown set GodownID=" + VID + ",GodownName='" + g.GodownName + "' where GodownID=" + VID + " End Else Begin Insert into Godown(GodownID,GodownName,IsShop) Values(" + VID + ",'" + g.GodownName + "'," + (VID == 1 ? 1:0) + ")End";
                cmd = new SqlCommand(insert, con);
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();
                VTran.Commit();                
            }
            catch (Exception ex)
            {
                VTran.Rollback();
                throw ex;
            }
            finally
            { con.Close(); }
        }

        public void  DeleteGodown(Godown g)
        {
            try
            {
                string delete = "Delete From Godown where GodownID=" + g.GodownId;
                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand(delete, con);

                cmd.ExecuteNonQuery();                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { con.Close(); }
        }
    

    }
}

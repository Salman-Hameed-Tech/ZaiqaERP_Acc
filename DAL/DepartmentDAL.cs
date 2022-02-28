using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DAL
{
    public class DepartmentDAL
    {
        private string source = ReadProjectConfigFile.ConfigString();
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlTransaction VTran;
        SqlDataReader dr;


        public string GetMaxID()
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();
                cmd = new SqlCommand("select isnull(Max(DepartID),0)+1 as DepartID from Department", con);
                cmd.Transaction = VTran;
                return Convert.ToString(cmd.ExecuteScalar());
            }
            catch(Exception ex)
            {
                VTran.Rollback();
                throw ex;
            }
            finally
            {
                VTran.Commit();
                con.Close();
            }
        }

    

        public DataSet LoadDepartment()
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();
                cmd = new SqlCommand("select * from Department", con);
                cmd.Transaction = VTran;
                DataSet ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                VTran.Rollback();
                throw;
            }
            finally
            {
                VTran.Commit();
                con.Close();
            }
        }

        public Department GetSingleDepart(int departID)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();
                Department dept=null;
                cmd = new SqlCommand("Select * from Department where DepartID=" + departID + "", con);
                cmd.Transaction = VTran;
                dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        dept = new Department(Convert.ToInt32(dr["DepartID"]), Convert.ToString(dr["DepartName"]), Convert.ToBoolean(dr["CanLogin"]));
                    }
                }
                return dept;
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

      

        public bool Delete(string deptID)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();
                cmd = new SqlCommand("Delete from Department where DepartID='" + deptID + "'", con);
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
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

        public bool Save(Department dept, bool isNew)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();
                if (isNew)
                {
                    cmd = new SqlCommand("select isnull(Max(DepartID),0) + 1 from Department", con);
                    cmd.Transaction = VTran;
                    int VID = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd = new SqlCommand("insert into Department(DepartID,DepartName,CanLogin) Values(" + VID + ",'" + dept.DepartName + "',0)", con);
                }
                else
                {
                    cmd = new SqlCommand("update Department set DepartName='"+dept.DepartName+"' where DepartID=" + dept.DepartID + "", con);
                }
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
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

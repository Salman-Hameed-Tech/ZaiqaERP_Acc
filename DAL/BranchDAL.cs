using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Common;


namespace DAL
{
   public class BranchDAL
    {
        List<Branch> branch = new List<Branch>();
        private string source = ReadProjectConfigFile.ConfigString();


        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlTransaction VTran;

        public Int32 GetMaxID()
        {
            try
            {
                string Select = "Select isNull(Max(ID),0) + 1 as ID from Branch";
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

        public string GetCurrentBranch(int branchID)
        {
            try
            {
                string Select = "Select BranchName from Branch where ID="+branchID+"";
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(Select, con);

                string brnachname = Convert.ToString(cmd.ExecuteScalar());
                con.Close();
                return brnachname;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public Branch GetSingleCounter(int ID)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();
                Branch cou = null;
                cmd = new SqlCommand("Select b.ID,b.BranchName,c.cityid,c.cityname,isnull(b.IsWarehouse,0)as IsWarehouse, isnull(b.Phone,'')as Phone,isnull(b.Email,'')as Email, isnull(b.Address,'')as Address, isnull(b.SaleNote,'')as SaleNote  from Branch b Inner join Cities c on c.cityid=b.cityid where ID=" + ID + "", con);
                cmd.Transaction = VTran;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cou = new Branch(Convert.ToInt32(dr["ID"]), Convert.ToString(dr["BranchName"]), Convert.ToInt32(dr["CityID"]), Convert.ToBoolean(dr["IsWarehouse"]), Convert.ToString(dr["Phone"]), Convert.ToString(dr["Email"]), Convert.ToString(dr["Address"]), Convert.ToString(dr["SaleNote"]));
                        cou.CityName = Convert.ToString(dr["CityName"]);

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
        public List<Branch> GetBranch(string where)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();
                List<Branch> coun = new List<Branch>();
                cmd = new SqlCommand("Select b.ID,b.BranchName,c.cityid,c.cityname,isnull(b.IsWarehouse,0)as IsWarehouse, isnull(b.Phone,'')as Phone, isnull(b.Email,'')as Email, isnull(b.Address,'')as Address, isnull(b.SaleNote,'')as SaleNote from Branch b Inner join Cities c on c.cityid=b.cityid   " + where + "", con);

                cmd.Transaction = VTran;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Branch c = new Branch(Convert.ToInt32(dr["ID"]), Convert.ToString(dr["BranchName"]), Convert.ToInt32(dr["CityID"]), Convert.ToBoolean(dr["IsWarehouse"]), Convert.ToString(dr["Phone"]), Convert.ToString(dr["Email"]), Convert.ToString(dr["Address"]), Convert.ToString(dr["SaleNote"]));
                        c.CityName = Convert.ToString(dr["CityName"]);
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

        public bool Delete(string ID)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();
                cmd = new SqlCommand("Delete from Branch where ID='" + ID + "'", con);
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
        public bool Save(Branch C, bool isNew)

        {
            try
            {
                int CID = 0;
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();
                if (isNew)
                {
                    cmd = new SqlCommand("select isnull(Max(ID),0) + 1 from Branch", con);
                    cmd.Transaction = VTran;
                    CID = Convert.ToInt32(cmd.ExecuteScalar());

                    
                }
                else
                {
                    CID = C.ID;
                   
                    
                }
                string insert = "if exists(select * from Branch where ID=" + CID + ")Begin Update Branch set ID=" + CID + ",BranchName = '" + C.BranchName + "',CityID = " + C.CityID + ", IsWarehouse="+Convert.ToInt16(C.IsWarehouse)+", Phone='"+C.Phone+"', Email='"+C.Email+"', Address='"+C.Address+"', SaleNote='"+C.SaleNote+"'     WHERE ID=" + CID + " End Else Begin Insert into Branch(ID, BranchName ,CityID, IsWarehouse, Phone, Email, Address, SaleNote) Values(" + CID + ",'" + C.BranchName + "'," + C.CityID + ","+Convert.ToInt16(C.IsWarehouse)+",'"+C.Phone+"','"+C.Email+"','"+C.Address+"','"+C.SaleNote+"')End";
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

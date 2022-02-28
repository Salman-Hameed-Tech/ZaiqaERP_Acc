using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DAL
{
    public class MCategoryDAL
    {
        private string source = ReadProjectConfigFile.ConfigString();
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlTransaction vtran;
        SqlDataAdapter da = new SqlDataAdapter();

       

        public string GetMaxID()
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                int VID = 0;

                cmd = new SqlCommand("select IsNull(Max(MCategoryID),0) +1 from MCategory ", con);
                VID = Convert.ToInt32(cmd.ExecuteScalar());

                return VID.ToString();
            }
            catch (Exception)
            {

                throw;
            }
            finally { con.Close(); }

        }

        public object GetCategory()
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("select * from (select 0 as MCategoryID,'All' as MCategoryName union all select MCategoryID,MCategoryName from MCategory) tb ", con);
                dr = cmd.ExecuteReader();

                List<MCategory> categories = new List<MCategory>();
                while (dr.Read())
                {
                    MCategory cat = new MCategory();
                    cat.MCategoryID = Convert.ToInt32(dr["MCategoryID"]);
                    cat.MCategoryName = dr["MCategoryName"].ToString();
                   
                    categories.Add(cat);
                }


                return categories;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<MCategory> GetMCategories()
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("select MCategoryID,MCategoryName,isnull(Printer,'') as Printer from  MCategory ", con);
                dr = cmd.ExecuteReader();

                List<MCategory> categories = new List<MCategory>();
                while (dr.Read())
                {
                    MCategory cat = new MCategory();
                    cat.MCategoryID = Convert.ToInt32(dr["MCategoryID"]);
                    cat.MCategoryName = dr["MCategoryName"].ToString();                 
                    cat.Printer = dr["Printer"].ToString();
                    categories.Add(cat);
                }


                return categories;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Save(MCategory category, bool isNew)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                int VID = 0;
                if (isNew)
                {
                    cmd = new SqlCommand("select IsNull(Max(MCategoryID),0) +1 from MCategory ", con);
                    VID = Convert.ToInt32(cmd.ExecuteScalar());

                    cmd = new SqlCommand("insert into MCategory (MCategoryID,MCategoryName,Printer) values(" + VID + ",'" + category.MCategoryName + "','" + category.Printer + "' )", con);
                    cmd.ExecuteNonQuery();

                    return true;
                }
                else
                {
                    VID = category.MCategoryID;
                    cmd = new SqlCommand("Update MCategory set MCategoryName='" + category.MCategoryName + "',Printer='" + category.Printer + "'   where MCategoryID=" + VID + " ", con);
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception)
            {

                throw;
                return false;
            }
            finally { con.Close(); }
        }
    }
}

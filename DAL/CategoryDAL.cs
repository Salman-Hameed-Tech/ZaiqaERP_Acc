using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Common;

namespace DAL
{
    public class CategoryDAL
    {
        List<Category> categories = new List<Category>();


        private string source = ReadProjectConfigFile.ConfigString();
      
                    
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlTransaction VTran;
        SqlDataAdapter da;

        public Int32 GetMaxID()
        {
            try
            {
                string Select = "Select isNull(Max(CategoryID),0) + 1 as ID from ItemCategory";
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
        public Category GetSingleCategories(int ID)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();
                Category cou = null;
                cmd = new SqlCommand("Select * from ItemCategory  where CategoryID=" + ID + "", con);
                cmd.Transaction = VTran;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cou = new Category(Convert.ToInt32(dr["CategoryID"]), Convert.ToString(dr["CategoryName"]));
                      

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

        public List<Category> GetCategorylist(int Departid)
        {
            if (categories == null) categories = new List<Category>();
            try
            {
                string select = "select CategoryID,CategoryName,'-' as DepartName from itemcategory where DepartID=" + Departid + "";

                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(select, con);

                dr = cmd.ExecuteReader();

                //Add Categories to Collection
                AddCategoryList();

                con.Close();
                return categories;
            }
            catch (Exception ex)
            {
                return categories;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet GetSelectedCategories(int Departid)
        {


            con = new SqlConnection(source);
            con.Open();
            cmd = new SqlCommand("select CategoryID,CategoryName from itemcategory where DepartID=" + Departid + "", con);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public List<Category > GetCategories()
        {
            if (categories == null) categories=new List<Category>();
            try
            {
                string select = "Select * from ItemCategory ";
                
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(select, con );
                
                dr = cmd.ExecuteReader();

                //Add Categories to Collection
                AddCategories();

                con.Close();
                return categories;
            }
            catch (Exception ex)
            {
                return categories;
            }
            finally
            {
                con.Close();
            }
        }

        
        public void AddCategories()
        {
            try
            {
                Category newCategory;
                while (dr.Read())
                {
                    if (categories.Count == 0)
                    {
                        newCategory = new Category(0, "---All Categories---");
                        categories.Add(newCategory);
                    }
                    newCategory=new Category((int)dr["CategoryID"],(string) dr["CategoryName"]);
                   
                    categories.Add(newCategory);
                }
                dr.Close();
            }
            catch (Exception ex) { }

            finally { dr.Close(); }
            
        }
        public void AddCategoryList()
        {
            try
            {
                Category newCategory;
                while (dr.Read())
                {
                   
                    newCategory = new Category((int)dr["CategoryID"], (string)dr["CategoryName"], (string)dr["DepartName"]);

                    categories.Add(newCategory);
                }
                dr.Close();
            }
            catch (Exception ex) { }

            finally { dr.Close(); }

        }
        public Boolean  SaveCategory(Category c,bool IsNew)
        {
            try
            {

                int VID=0;
               con = new SqlConnection(ReadProjectConfigFile.ConfigString () );
                con.Open();
                VTran = con.BeginTransaction();
                if (c.Id == 0)
                {
                    cmd = new SqlCommand("Select IsNull(Max(categoryid),0) +1 From Itemcategory", con);
                    cmd.Transaction = VTran;
                    VID =Convert.ToInt32 ( cmd.ExecuteScalar());
                 }
                else
                {
                    VID=c.Id;
                }
                string insert = "if exists(select * from ItemCategory where CategoryID=" + VID + ")Begin Update ItemCategory set CategoryID=" + VID + ",CategoryName='" + c.Name + "' where CategoryID=" + VID + " End Else Begin Insert into ItemCategory Values(" + VID + ",\'" + c.Name + "\' )End";
                cmd = new SqlCommand(insert, con);
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();
                VTran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                VTran.Rollback();
                return false;
            }
            finally
            { con.Close(); }
        }

        public Boolean DeleteCategory(Category c)
        {
            try
            {
                string delete = "Delete From ItemCategory where CategoryID="+c.Id ;
                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand(delete, con);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            { con.Close(); }
        }
    
    }
}

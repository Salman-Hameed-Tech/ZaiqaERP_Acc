using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class CategoryPartyDAL
    {
        List<CategoryPartyRelation> menus=new List<CategoryPartyRelation>();
        List<Category> categories = new List<Category>();        
        DataSet ds = new DataSet();


        private string source = ReadProjectConfigFile.ConfigString();
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlTransaction vtran;
        SqlDataAdapter da = new SqlDataAdapter();

        
        


        public Boolean SaveCPRelation(List<CategoryPartyRelation>listCPR)
        {

            try
            {                
                con = new SqlConnection(source);
                con.Open();
                string insert;
                vtran = con.BeginTransaction();


                insert = " Delete from CategoryPartyRelation ";
                cmd = new SqlCommand(insert, con);
                cmd.Transaction = vtran;
                cmd.ExecuteNonQuery();

                foreach (CategoryPartyRelation cpr in listCPR)
                {
                    //insert = "if exists(select SrNo from CategoryPartyRelation where SrNo=" + cpr.SrNo + ")Begin Update CategoryPartyRelation set PartyID= '" + cpr.PartyID + "',MCategoryID=" + cpr.MCategoryID + " where SrNo=" + cpr.SrNo + " End Else Begin Insert into CategoryPartyRelation(PartyID,MCategoryID) Values(" + cpr.PartyID + "," + cpr.MCategoryID + ")End";
                    insert = " Insert into CategoryPartyRelation(PartyID,MCategoryID) Values(" + cpr.PartyID + "," + cpr.MCategoryID + ")";
                    cmd = new SqlCommand(insert , con);
                    cmd.Transaction = vtran;
                    cmd.ExecuteNonQuery();
                }

                vtran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                vtran.Rollback();
                throw ex;
            }
            finally
            { con.Close(); }
        }

        public List<CategoryPartyRelation> GetCategoryPartyRelations()
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                List<CategoryPartyRelation> listCPRelations = new List<CategoryPartyRelation>();

                //cmd = new SqlCommand("select cpr.SrNo,cpr.PartyID,p.PartyName,cpr.MCategoryID,mc.MCategoryName from CategoryPartyRelation cpr inner join Parties p on p.PartyID=cpr.PartyID inner join MCategory mc on cpr.MCategoryID=mc.MCategoryID", con);
                cmd = new SqlCommand("select cpr.PartyID,isnull(p.PartyName, '') as PartyName, isnull(cpr.MCategoryID,0) as MCategoryID, isnull(mc.mcategoryname , '') as MenuName from CategoryPartyRelation cpr inner join Parties p on p.PartyID=cpr.PartyID inner join mcategory mc on cpr.MCategoryID=mc.mcategoryid ", con);
                dr = cmd.ExecuteReader();                
                while (dr.Read())
                {
                    //listCPRelations.Add(new CategoryPartyRelation(Convert.ToInt32(dr["PartyID"]), Convert.ToString(dr["PartyName"]), Convert.ToInt32(dr["MCategoryID"]),Convert.ToString(dr["MCategoryName"]),Convert.ToInt32(dr["SrNo"])));
                    listCPRelations.Add(new CategoryPartyRelation(Convert.ToInt32(dr["PartyID"]), Convert.ToString(dr["PartyName"]), Convert.ToInt32(dr["MCategoryID"]), Convert.ToString(dr["MenuName"])));
                }
                return listCPRelations ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { con.Close(); dr.Close(); }
        }

        public List<Category> GetCategories(int id)
        {
            categories = new List<Category>();
            try
            {
                string where = "";

                if (id > 0)
                {
                    where = " Where MCategoryID = " + id;
                }
                string select = "Select * from MCategory" + where + " ";

                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(select, con);

                da.SelectCommand = cmd;
                da.Fill(ds);

                //Add Categories to Collection
                AddCategories();

                con.Close();
                if (categories.Count == 0 || categories[0] == null)
                    return new List<Category>();
                else
                    return categories;
            }
            catch (Exception ex)
            {
                throw;
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
                Category newCategory = new Category();
                foreach (DataRow Row in ds.Tables[0].Rows)
                {
                    //if (categories.Count == 0)
                    //{
                    //    newCategory = new Category(0, "---All Categories---",false ,false );
                    //    categories.Add(newCategory);
                    //}

                    newCategory = new Category((int)Row["MCategoryID"], (string)Row["MCategoryName"]);
                    //newCategory=new Category((int)dr["CategoryID"],(string) dr["CategoryName"],Convert .ToBoolean (dr["IsRaw"]),Convert .ToBoolean (dr["IsFinished"]));
                    categories.Add(newCategory);
                }
                //dr.Close();
            }
            catch (Exception ex)
            {
                throw;
            }

            finally { }

        }

    }
}

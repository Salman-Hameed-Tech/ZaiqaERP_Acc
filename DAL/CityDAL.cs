using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class CityDAL
    {
        List<City> cities = new List<City>();


        private string source = ReadProjectConfigFile.ConfigString();


        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlTransaction VTran;

        public List<City> GetCities()
        {
            if (cities == null) cities = new List<City>();
            try
            {
                string select = "Select * from Cities  ";

                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(select, con);

                dr = cmd.ExecuteReader();


                //Add Categories to Collection
                AddCities();

                con.Close();
                return cities;
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

        public bool Delete(string ID)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();
                cmd = new SqlCommand("Delete from Cities where CityID='" + ID + "'", con);
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
        public City GetSingleCity(int ID)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
              
                City cou = null;
                cmd = new SqlCommand("Select * from Cities where cityID=" + ID + "", con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cou = new City(Convert.ToInt32(dr["CityID"]), Convert.ToString(dr["CityName"]));
                       
                    }
                }
                return cou;
               
            }
            catch (Exception)
            {
                dr.Close();
            
                throw;
            }
            finally
            {
                dr.Close();
              
                con.Close();
            }
        }

        public int GetMaximumID()
        {
            int VID = 0;
            con = new SqlConnection(source);
            con.Open();
            cmd = new SqlCommand("Select IsNull(Max(CityId),0) +1 From Cities", con);
            VID = (int)cmd.ExecuteScalar();

            return VID;

        }
        public void AddCities()
        {
            try
            {
                City newCity;

                while (dr.Read())
                {
                    newCity = new City(Convert.ToInt16 (dr["CityID"]), (string)dr["CityName"]);
                    cities.Add(newCity);
                }
                dr.Close();
                con.Close();
            }
            
            catch (Exception ex) { throw ex; }

            finally { dr.Close(); }

        }

        public void SaveCity(City  c, bool isNew)
        {
            try
            {
                int VID = 0;
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();
                if (isNew)
                {
                    cmd = new SqlCommand("Select IsNull(Max(CityId),0) +1 From Cities", con);
                    cmd.Transaction = VTran;
                    VID = Convert.ToInt32(cmd.ExecuteScalar());
                }
                else
                {
                    VID = c.CityID ;
                }
                string insert = "if exists(select * from Cities where CityID=" + VID + ")Begin Update Cities set CityID=" + VID + ",CityName='" + c.CityName + "',Distance='',StateID=" + c.StateID + " where CityID=" + VID + " End Else Begin Insert into Cities(CityID,CityName,Distance,StateID) Values(" + VID + ",'" + c.CityName + "',''," + c.StateID + " )End";
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

        public void DeleteCity(City c)
        {
            try
            {
                string delete = "Delete From Cities where CityID=" + c.CityID;
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

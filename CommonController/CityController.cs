using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DAL;

namespace CategoryControlle
{
    public class  CityController
    {
        private List<City> cities;
        private CityDAL cDal = new CityDAL();

        public int GetMaximimID()
        {
            return cDal.GetMaximumID();
        }
        public bool Delete(string ID)
        {
            return new DAL.CityDAL().Delete(ID);
        }


        public City GetSingleCity(int ID)
        {
            return new DAL.CityDAL().GetSingleCity(ID);
        }

        public List<City> GetCity()
        {
            if (cities == null) cities = new List<City>();

            //todo from database 
            cities = cDal.GetCities();
            return cities;
        }

        public void SaveCity(City c, bool isNew)
        {
            try
            {
                cDal.SaveCity(c,isNew);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteCity(City c)
        {
            try
            {
                cDal.DeleteCity(c);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }        
    }
}

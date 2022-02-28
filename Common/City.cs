using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class City
    {
        //Fields.
        private int cityID;
        private string cityName;
        public int StateID { get; set; }
        public String StateName { get; set; }

        public static string Condition;
        //Constructors.
        public City()
        { }

        public City(int cityID,string cityName,string statename)
        {
            this.cityID = cityID;
            this.cityName = cityName;
            this.StateName = statename;
        }
        public City(int cityID, string cityName)
        {
            this.cityID = cityID;
            this.cityName = cityName;
         
        }

        //Properties.
        public int CityID
        {
            get { return cityID; }
            set { cityID = value; }
        }     

        public string CityName
        {
            get { return cityName; }
            set { cityName = value; }
        }

        //Methods.

        public override string ToString()
        {
            return this.cityName.ToString();
        }
        //public override bool Equals(object obj)
        //{
        //    //return ((City)obj).cityID == this.cityID;
        //}
    }
}

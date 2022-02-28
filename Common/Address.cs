using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Common
{
    public class Address
    {
        // fields.
        private string city;
        private int sector;        
        private string state;
        private string adressLine;        

        public Address()
        { 
        
        }
        public Address(string addressLine,string city,string state)
        {
            this.city = city;
            this.state = state;
            this.adressLine = addressLine;            
        }
        public Address(string addressLine, string city, string state,int sector)
        {
            this.city = city;
            this.state = state;
            this.adressLine = addressLine;
            this.sector = sector;
        }
        //Properties.
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public int Sector
        {
            get { return sector; }
            set { sector = value; }
        }
        public string State
        {
            get { return state; }
            set { state = value; }
        }
        public string AdressLine
        {
            get { return adressLine; }
            set { adressLine = value; }
        }        

        //Methods
        public override string ToString()
        {
            return adressLine + ", " + city + ", " + state;
        }
        
    }
}

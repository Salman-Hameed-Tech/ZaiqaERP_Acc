using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{ 
    public class Vendor : Person
    {
        public string VisaNo { get; set; }
        public DateTime VisaDateTime { get; set; }
        public DateTime PassportDateTime { get; set; }

        public string PassportNo { get; set; }
        public string TradeLicenseNo { get; set; }
        public string VehiclesRegistrationNo { get; set; }
        public string TenacyContact { get; set; }
        public DateTime TradeLicenseExpiry { get; set; }
        public DateTime TenacyExpiry { get; set; }
        public DateTime vehiclesExpiry { get; set; }
        //Constructors.
        public List<Branch> BranchList = new List<Branch>();
        public Vendor()
        { 
        
        }

        public Vendor(ChartOfAccounts id, Address address, string phoneHome)
            : base(id, address, phoneHome)
        { 
            
        }

        public Vendor(ChartOfAccounts id, Address address, string phoneHome, string phoneOffice, string mobile, string fax)
            : base(id, address, phoneHome,phoneOffice,mobile,fax)
        {

        }
        public Vendor(ChartOfAccounts id, Address address, string phoneHome, string phoneOffice, string mobile, string fax, string email, string contactPerson, bool inPurcahse, bool inSale)
            : base(id, address, phoneHome, phoneOffice, mobile, fax, email, contactPerson, inPurcahse, inSale)
        {

        }
        private DateTime passportdt;
        private string vehiclesregistrationno;
        private string tradelicenseno;
        private string passportno;
        private string visano;
        private string tenacycontact;
        private DateTime vehiclesexp;
        private DateTime tradeexp;
        private DateTime tenacyexp;


        public Vendor(ChartOfAccounts id, Address address, string phoneHome, string phoneOffice, string mobile, string fax, string email, string contactPerson, bool inPurcahse,
            bool inSale, string passportno, string vehiclesregistrationno, string tradelicenseno, string visano, DateTime visadt, DateTime passportdt, string tenacycontact, DateTime vehiclesexp, DateTime tradeexp, DateTime tenacyexp)
            : base(id, address, phoneHome, phoneOffice, mobile, fax, email, contactPerson, inPurcahse, inSale)
        {
            this.visano = visano;
            this.VisaDateTime = visadt;
            this.PassportNo = passportno;
            this.PassportDateTime = passportdt;
            this.TradeLicenseNo = tradelicenseno;
            this.VehiclesRegistrationNo = vehiclesregistrationno;
            this.TenacyContact = tenacycontact;
            this.TenacyExpiry = tenacyexp;
            this.TradeLicenseExpiry = tradeexp;
            this.vehiclesExpiry = vehiclesexp;

        }

       


        //public Vendor(ChartOfAccounts id, Address address, string phoneHome, string phoneOffice, string mobile, string fax, string email, string contactPerson, bool inPurcahse, bool inSale)
        //    : base(id, address, phoneHome, phoneOffice, mobile, fax, email, contactPerson, inPurcahse, inSale)
        //{

        //}

        public override string ToString()
        {
            //return this.Name == System.DBNull.Value ? "":this .Name.ToString ();
            return this.Name;
        }
       
    }
}

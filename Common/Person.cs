using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public abstract class Person
    {
        //Fields.
        private ChartOfAccounts id;
        private string name;
        private string phoneHome;
        private string phoneOffice;
        private string mobile;        
        private string fax;
        private string email;
        private string contactPerson;      
        private Address address;

        bool inPurchase;
        bool inSale;
        bool isPos;

                
        public Person()
        {
            id = new ChartOfAccounts();                        
            address = new Address();
            name = "";
        }
        public Person(ChartOfAccounts id, Address address, string phoneHome)
            : this()
        {
            this.id = id;
            this.name = id.AccountName;
            this.address = address;
            this.phoneHome = phoneHome;
        }
        public Person(ChartOfAccounts id, Address address, string phoneHome, string phoneOffice,string mobile,string fax)
            : this()
        {
            this.id = id;
            this.name = id.AccountName;
            this.address = address;
            this.phoneHome = phoneHome;
            this.mobile = mobile;
            this.phoneOffice = phoneOffice;
            this.fax = fax;
        }
        public Person(ChartOfAccounts id, Address address, string phoneHome, string phoneOffice, string mobile, string fax, string email, string contactPerson, bool inPurchase, bool inSale)
            : this()
        {
            this.id = id;
            this.name = id.AccountName;
            this.address = address;
            this.phoneHome = phoneHome;
            this.mobile = mobile;
            this.phoneOffice = phoneOffice;
            this.fax = fax;
            this.email = email;
            this.contactPerson = contactPerson;
            this.inPurchase = inPurchase;
            this.inSale = inSale;
            //this.isPos = isPos;
        }
        //Properties.       
        public ChartOfAccounts  Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get{ return this.name ; }
            set{ this.name  = value;}
        }

        public string PhoneHome
        {
            get{ return this.phoneHome ; }
            set{ this.phoneHome  = value; }
        }
        public string PhoneOffice
        {
            get { return phoneOffice; }
            set { phoneOffice = value; }
        }
        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }
        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }
        public Address Address
        {   get{ return this.address ; }
            set{ this.address = value; }
        }
        public string ContactPerson
        {
            get { return contactPerson; }
            set { contactPerson = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public bool InSale
        {
            get { return inSale; }
            set { inSale = value; }
        }

        public bool InPurchase
        {
            get { return inPurchase; }
            set { inPurchase = value; }
        }
        public bool IsPos
        {
            get { return isPos; }
            set { isPos = value; }
        }
        //Methods.
        public override string ToString()
        {
            return Name.ToString() + Address.ToString() +PhoneHome.ToString ();
        }
        //public override bool Equals(object obj)
        //{
        //    return (((Person)obj).id == this .id );
        //}
              
                
    }
}

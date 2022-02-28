using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Customer:Person 
    {
        //Constructors.
        public Customer()
        { 
        
        }

        public Customer(ChartOfAccounts id, Name name, Address address, string contactNumber)
            : base(id, address, contactNumber)
        { 
            
        }

        public override string ToString()
        {
            return this.Name.ToString ();
        }
    }
}

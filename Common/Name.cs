using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Name
    {
        // fields.
        private string firstName;
        private string lastName;
        
        // properties.
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        // methods.
        public override string ToString()
        {
            return firstName + " " + lastName;
        }
    }
}

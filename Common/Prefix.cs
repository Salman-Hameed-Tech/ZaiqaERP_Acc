using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Prefix
    {
        //Fields.
        private int id;
        private string name;
       
      
      

        //Contstructors.
        public Prefix()
        {         
        }

        public Prefix(string name)
        {
            this.Name = name;
        }
        public Prefix(int id,string name,bool isOutSide)
        {

            
            this.Id = id;
            this.Name = name;
           
            
        }

        public Prefix(int id, string name)
        {


            this.Id = id;
            this.Name = name;
            
        }

        //Properties.
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
       
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
      
       //Methods.
        public override string ToString()
        {
            return this.Name;
        }                      
    }
}

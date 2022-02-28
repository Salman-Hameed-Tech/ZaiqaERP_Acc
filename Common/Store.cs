using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Store
    {
        //Fields.
        private int id;
        private string name;
        public bool IsOutSide { get; set; }
       
      

        //Contstructors.
        public Store()
        {         
        }

        public Store(string name)
        {
            this.Name = name;
        }

        public Store(int id)
        {
            this.Id  = id;
        }

        public Store(int id,string name,bool isOutSide)
        {            
            this.Id = id;
            this.Name = name;
            this.IsOutSide = isOutSide;

            
        }
        
        public Store(int id, string name)
        {


            this.Id = id;
            this.Name = name;
            
        }

        public Store(int id, string name,decimal currentStock)
        {
            this.Id = id;
            this.Name = name;
            this.CurrentStock = currentStock;
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

        public decimal CurrentStock { get; set; }
        public override bool Equals(object obj)
        {

            Store cat = obj as Store;
            if (cat == null) return false;
            return (this.Name  == cat.Name  );
        }
       //Methods.
        public override string ToString()
        {
            return this.Name;
        }                      
    }
}

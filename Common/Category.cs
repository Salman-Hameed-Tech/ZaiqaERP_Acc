using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Category
    {
        //Fields.
        private int id;
        private string name;
        
       

        public static string Condition;


        //Contstructors.
        public Category()
        {         
        }

        public Category(string name)
        {
            this.Name = name;
        }
        public Category(int id,string name,bool isService)
        {       
            this.Id = id;
            this.Name = name;
            this.IsService  = isService ;           
        }
        
        public Category(int id, string name)
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

        public bool IsService { get; set; }
        public override bool Equals(object obj)
        {

            Category cat = obj as Category;
            if (cat == null) return false;
            return (this.Name  == cat.Name  );
        }
       //Methods.
        public override string ToString()
        {
            return this.Name;
        }
        public int DepartID { get; set; }
        public string DepartName { get; set; }
        
        public Category(int id, string name, int departid)
        {
            this.Id = id;
            this.Name = name;
            this.DepartID = departid;
        }
        public Category(int id, string name, string departname)
        {
            this.Id = id;
            this.Name = name;
            this.DepartName = departname;
        }
    }
}

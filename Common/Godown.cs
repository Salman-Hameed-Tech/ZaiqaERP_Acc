using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class  Godown
    {
         //Fields.
        private int godownId;
        private string godownName;

        public static string Condition;

        //Contstructors.
        public Godown()
        {         
        }
        public Godown(int id, string name)
        {

            
            this.GodownId = id;
            this.GodownName = name;
        }

        //Properties.
        public int GodownId
        {
            get { return godownId; }
            set { godownId = value; }
        }
       
        public string GodownName
        {
            get { return godownName; }
            set { godownName = value; }
        }
        public override bool Equals(object obj)
        {

            Godown  g = obj as Godown;
            if (g == null) return false;
            return (this.GodownName  == g.godownName);
        }
       //Methods.
        public override string ToString()
        {
            return this.GodownName;
        }       


    }
}

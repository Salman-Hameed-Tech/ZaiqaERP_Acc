using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
   public class States
    {
        public Int32 ID { get; set; }
      
        public string StateName { get; set; }


        public States(int id, string bname)
        {
            this.ID = id;
            this.StateName = bname;
        }
        public States(int id)
        {
            this.ID = id;
       
        }
    }
}

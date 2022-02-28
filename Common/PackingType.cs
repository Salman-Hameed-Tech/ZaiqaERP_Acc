using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
   public  class   PackingType
    {
       public int ID { get; set; }
       public string PackingName { get; set; }

       public PackingType(int id, string packingName)
       {
           this.ID = id;
           this.PackingName = packingName;
       }
    }
}

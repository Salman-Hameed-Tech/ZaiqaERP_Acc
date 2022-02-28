using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class Menus
    {
        public Int32 MenuID { get; set; }
        public String MenuName { get; set; }
        public String UrduName { get; set; }
        public Int32 MCategoryID { get; set; }
        public String MCategoryName { get; set; }  
        public decimal Rate { get; set; }

        public List<MenuReceipe> menuReceipe { get; set; }

    }
}

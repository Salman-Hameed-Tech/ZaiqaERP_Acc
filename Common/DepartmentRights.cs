using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class DepartmentRights
    {
        public int ID { get; set; }
        public string DepartmentName { get; set; }
        public bool CanLogin { get; set; }
    }
}

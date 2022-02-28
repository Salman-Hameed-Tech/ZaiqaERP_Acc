using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Department
    {
        public int DepartID { get; set; }
        public string DepartName { get; set; }
        public bool CanLogin { get; set; }

        public Department()
        { }
        public Department (int deprtid,string departname,bool canlogin)
        {
            this.DepartID = deprtid;
            this.DepartName = departname;
            this.CanLogin = canlogin;
        }
    }
}

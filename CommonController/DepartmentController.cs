using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace CategoryControlle
{
    public class DepartmentController
    {
        public string GetMaxID()
        {
            return new DAL.DepartmentDAL().GetMaxID();
        }

        public bool Save(Department dept, bool isNew)
        {
            return new DAL.DepartmentDAL().Save(dept,isNew);
        }

        public bool Delete(string DeptID)
        {
            return new DAL.DepartmentDAL().Delete(DeptID);
        }

       

        public Department GetSingleDepart(int DepartID)
        {
            return new DAL.DepartmentDAL().GetSingleDepart(DepartID);
        }

        public List<DepartmentRights> GetDepatment(int v)
        {
            return new DAL.UserDAL().GetDepartment(v);
        }

        public DataSet LoadDepartment()
        {
            return new DAL.DepartmentDAL().LoadDepartment();
        }

       
    }
}

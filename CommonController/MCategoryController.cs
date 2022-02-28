using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace CommonController
{
    public class MCategoryController
    {
        public string GetMaxID()
        {
            return new DAL.MCategoryDAL().GetMaxID();
        }

        public bool Save(MCategory category, bool isNew)
        {
            return new DAL.MCategoryDAL().Save(category, isNew);
        }

        public List<MCategory> GetMCategories()
        {
            return new DAL.MCategoryDAL().GetMCategories();
        }

        public object GetCategory()
        {
            return new DAL.MCategoryDAL().GetCategory();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace CommonController
{
    public class ReceivedChallanController
    {
        public bool Save(Challan delchalan,bool isNew)
        {
            return new DAL.ReceivedChllanDAL().Save(delchalan, isNew);
        }

        public int CheckExist(int ID)
        {
            return new DAL.ReceivedChllanDAL().CheckExist( ID);
        }
    }
}

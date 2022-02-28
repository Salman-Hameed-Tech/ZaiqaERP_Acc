using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DAL;

namespace CategoryControlle
{
   public class StateController
    {
        public int GetMaximumID()
        {
            return new StateDAL().GetMaximumID();
        }
        public States GetSingleStates(int ID)
        {
            return new DAL.StateDAL().GetSingleStates(ID);
        }

        public bool Save(States s, bool Isnew)
        {
            return new DAL.StateDAL().Save(s, Isnew);
        }

        public List<States> GetStates()
        {
            return new DAL.StateDAL().GetStates();
        }



        public bool Delete(string ID)
        {
            return new DAL.StateDAL().Delete(ID);
        }
    }
}

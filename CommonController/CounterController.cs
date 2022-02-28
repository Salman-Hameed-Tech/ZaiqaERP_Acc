using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DAL;

namespace CategoryControlle
{
    public class CounterController
    {
        public Int32 GetMaxID()
        {
            return new CounterDAL().GetMaxID();
        }
        public bool Save(Counter C, bool isNew)
        {
            return new DAL.CounterDAL().Save(C, isNew);
        }
        public bool Delete(string ID)
        {
            return new DAL.CounterDAL().Delete(ID);
        }

        public List<Counter> GetCounter()
        {
            return new DAL.CounterDAL().GetCounter();
        }

        public Counter GetSingleCounter(int ID)
        {
            return new DAL.CounterDAL().GetSingleCounter(ID);
        }

        public Int32 GetCounterid(int userno)
        {
            return new CounterDAL().GetCounterid(userno);
        }
        public bool Getusers(int user)
        {
            return new DAL.CounterDAL().Getusers(user);
        }
        public Int32 GetAdmin(int userno)
        {
            return new CounterDAL().GetAdmin(userno);
        }
        public Int32 GetAllusers(int userno)
        {
            return new CounterDAL().GetAllusers(userno);
        }
        public Int32 GetBranchid(int userno)
        {
            return new CounterDAL().GetBranchid(userno);
        }
    }
}

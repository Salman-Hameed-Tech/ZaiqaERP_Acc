using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DAL;

namespace CommonController
{
    public class PrefixController
    {
        public Int32 GetMaxID()
        {
            return new PrefixDAL().GetMaxID(); 
        }

        public Boolean SavePrefix(Prefix c, bool isNew)
        {
            return new PrefixDAL().SavePrefix(c, isNew); 
        }

        public List<Prefix> GetPrefixs(int id)
        {
            return new PrefixDAL().GetPrefixs(id);
        }

        public Boolean DeletePrefix(Prefix c)
        {
            return new PrefixDAL().DeletePrefix(c);
        }

        //public bool GetData(ref Common.Data_Sets.DSPrefixRegister ds, string where)
        //{
        //    return new PrefixDAL().GetData(ref ds, where);
        //}
    }

   

}

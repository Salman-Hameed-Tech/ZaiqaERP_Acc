using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Common ;

namespace CategoryControlle
{
    public class FixedAccountController
    {
        public FixedAccounts getFixAcc()
        {
            FixedAccDAL FDAl = new FixedAccDAL();
            return FDAl.getEnteries();
        }
        public Boolean SaveFixAcc(FixedAccounts ObjFix)
        { 
            FixedAccDAL FDAl=new FixedAccDAL ();
            return (FDAl.SaveRecord (ObjFix ));
        }
    }
}

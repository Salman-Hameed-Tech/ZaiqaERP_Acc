using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Common;
using DAL;

namespace CategoryControlle
{
    public class DayLogController
    {
        public Boolean CheckDayStart()
        {
            try
            {
                return new DayLogDAL().CheckDayStart();
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public DateTime GetDay(int barnchid)
        {
            try
            {
                return new DayLogDAL().GetDay(barnchid);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public Boolean StartDay()
        {
            try
            {
                return new DayLogDAL().StartDay();
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public Boolean EndDay()
        {
            try
            {
                return new DayLogDAL().EndDay();
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }
}

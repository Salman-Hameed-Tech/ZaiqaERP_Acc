using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;


namespace CommonController
{
    public class DaySettingController
    {


        public bool TransferData(string ServerStr)
        {
            return new DaySettingDAL().TransferData(ServerStr); 
        }
        public bool StartDay(int branchid)
        {
            try
            {
                return new DaySettingDAL().StartDay(branchid);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool EndDay(int branchid)
        {
            try
            {
                return new DaySettingDAL().EndDay(branchid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DateTime GetRunningDate(int branchid)
        {
            try
            {
                return new DaySettingDAL().GetRunningDate(branchid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DateTime GetServerDateTime(int branchid)
        {
            try
            {
                return new DaySettingDAL().GetRunningDate(branchid);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
        public bool CheckDayEnd(int branchid)
        {
            try
            {
                return (new DaySettingDAL().CheckDayEnd(branchid));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

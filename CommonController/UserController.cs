using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Common;
using DAL;

namespace CategoryControlle
{
    public class UserController
    {
        User user;
        List<User> users;

        public int GetMaximumID()
        {
            try
            {
                return new UserDAL().GetMaximumID();
            }
            catch (Exception ex)
            {                
                throw ex;
            }            
        }
        public int GetBranchID(int USERNO)
        {
            try
            {
                return new UserDAL().GetBranchID(USERNO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<User> GetSupervisors()
        {
            try
            {
                return new UserDAL().GetSupervisors();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SaveUser(User u)
        {
            try
            {
                return new UserDAL().SaveUser(u);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public DataSet GetUserList(string where)
        {
            return new DAL.SummaryDAL().GetUserList(where);
        }

        public List<User> GetEmployees()
        {
            return new DAL.UserDAL().GetEmployees();
        }

        public DateTime GetServerDate()
        {
            return new UserDAL().GetServerDate();  
        }
        public User VerifyUser(User u)
        {
            try
            {
                return new UserDAL().VerifyUser(u);
            }
            catch (Exception ex)
            {                
                throw ex;
            }            
        }

        public User GetUserDetail(int userID)
        {
            try
            {
                return new UserDAL().GetUserDetail(userID);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public List<User> GetUsers(int userID)
        {
            try
            {
                return new UserDAL().GetUsers(userID );
            }
            catch (Exception ex)
            {                
                 throw ex;
            }            
        }

        public bool DeleteUser(User u)
        {
            try
            {
                return new UserDAL().DeleteUser(u);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public List<UserRight> GetUserRights(int UserID)
        {
            try
            {
                return new UserDAL().GetUserRights(UserID);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public bool SaveRight(int UserID, int RightID)
        {
            try
            {
                return new UserDAL().SaveRight(UserID, RightID);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public bool DeleteRight(int UserID, int RightID)
        {
            try
            {
                return new UserDAL().DeleteRight(UserID, RightID);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public List<UserRight> LoadRights()
        {
            return new DAL.UserDAL().LoadRights();
        }

        public bool SaveUserRight(int userid, List<UserRight> right)
        {
            return new DAL.UserDAL().SaveUserRight(userid,right);
        }

        public List<Department> GetDepart(string where)
        {
            return new DAL.UserDAL().GetDepart(where);
        }
    }
}

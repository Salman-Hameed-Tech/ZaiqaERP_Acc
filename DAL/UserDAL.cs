using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class UserDAL
    {
        User user;
        List<User> users;
        List<UserRight> rights;
        List<DepartmentRights> deprights;

        private string source = ReadProjectConfigFile.ConfigString();
        private string Msource = ReadProjectConfigFile.MConfigString(); 
        SqlConnection con;
        SqlConnection conLocal;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlTransaction VTran;
        SqlTransaction VTranLocal;

        public int GetMaximumID()
        {
            try
            {
                int VID = 0;
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand("Select IsNull(Max(UserNo),0) +1 From Users", con);
                VID = (int)cmd.ExecuteScalar();

                return VID;
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
                int VID = 0;
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand("Select isnull(BranchID,0) as BranchID From Users WHERE UserNo=" + USERNO + " ", con);
                VID = (int)cmd.ExecuteScalar();

                return VID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<User> GetSupervisors()
        {
            if (users == null) users = new List<User>();
            try
            {
                string select = "Select * from Users where isSupervisor=1";

                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(select, con);

                dr = cmd.ExecuteReader();


                //Add Users to Collection
                AddUsers();

                con.Close();
                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public void AddUsers()
        {
            try
            {
                User newUser;

                while (dr.Read())
                {
                    newUser = new User(Convert.ToInt32(dr["UserNo"]), Convert.ToString(dr["UserName"]), Convert.ToString(dr["Password"]), Convert.ToBoolean(dr["IsActive"]), Convert.ToBoolean(dr["IsAdministrator"]),0, Convert.ToBoolean(dr["IsCashCounter"]));
                    newUser.IsSupervisor = Convert.ToBoolean(dr["IsSupervisor"] == System.DBNull.Value ? 0 : dr["IsSupervisor"]);
                    newUser.Signatures = dr["Signature"].ToString().Length == 0 ? new byte[0] : (byte[])(dr["Signature"]);
                    users.Add(newUser);
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex) { throw ex; }

            finally { dr.Close(); }

        }
        public List<User> GetEmployees()
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();
                List<User> userlist = new List<User>();
                cmd = new SqlCommand("Select isnull(UserId,0) as UserId,isnull(USerName,'') as USerName From USers where isadministrator <>1", con);
                cmd.Transaction = VTran;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        User user = new User(Convert.ToInt32(dr["UserId"]), Convert.ToString(dr["USerName"]));
                        userlist.Add(user);
                    }
                }
                return userlist;
            }
            catch(Exception ex)
            {
                VTran.Rollback();
                throw ex;
            }
            finally
            {
                dr.Close();
                VTran.Commit();
                con.Close();
            }
        }

        public List<Department> GetDepart(string where)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();
                List<Department> userlist = new List<Department>();
                cmd = new SqlCommand("  select distinct(d.DepartID),d.DepartName,dr.CanLogin from DepartmentRights dr left join Department d on dr.DepartmentID=d.DepartID  " + where+" ", con);
                cmd.Transaction = VTran;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Department user = new Department(Convert.ToInt32(dr["DepartID"]), Convert.ToString(dr["DepartName"]), Convert.ToBoolean(dr["CanLogin"]));
                        userlist.Add(user);
                    }
                }
                return userlist;
            }
            catch (Exception ex)
            {
                VTran.Rollback();
                throw ex;
            }
            finally
            {
                dr.Close();
                VTran.Commit();
                con.Close();
            }
        }

        public bool SaveUser(User u)
        {
            try
            {
                int VID = 0;
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand("select 1",con);
                VTran = con.BeginTransaction();
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();

                if (u.UserID == 0)
                {
                    string GetMaxId = "Select IsNull(Max(UserNo),0) +1 From Users";
                   
                    cmd.CommandText = GetMaxId;
                  
                    VID = Convert.ToInt32(cmd.ExecuteScalar());
                }
                else
                {
                    VID = u.UserID;
                }

                string DeleteRights = "Delete from UserAndRights where UserID = " + VID;
                cmd.CommandText = DeleteRights;
                cmd.ExecuteNonQuery();



                string insert = "if exists(select * from Users where UserNo=" + VID + ")Begin Update Users set UserNo=" + VID + ",UserName='" + u.UserName + "',Password='" + u.UserPassword + "',IsAdministrator=" + Convert.ToInt16(u.IsAdmin) + ",IsActive=" + Convert.ToInt16(u.IsActive) + ",Signature = " + (u.Signatures.Length == 0 ? "NULL" : "@Signature") + ",AllUsers=" + Convert.ToInt16(u.Allusers) + ",BranchID=" + Convert.ToInt32(u.BranchID) + " where UserNo=" + VID + " End Else Begin Insert into Users(UserNo,UserName,Password,IsAdministrator,IsActive,Signature,AllUsers,BranchID,IsCashCounter) Values(" + VID + ",'" + u.UserName + "','" + u.UserPassword + "'," + Convert.ToInt16(u.IsAdmin) + "," + Convert.ToInt16(u.IsActive) + "," + (u.Signatures.Length == 0 ? "NULL" : "@Signature") + "," + Convert.ToInt16(u.Allusers) + "," + Convert.ToInt32(u.BranchID) + "," + Convert.ToInt16(u.IsCashCounter) + ")End";
                cmd.CommandText = insert;
                cmd.ExecuteNonQuery();

                foreach (UserRight right in u.Rights)
                {
                    string insertRights = "Insert into UserAndRights(UserID,FormID,CanAccess,CanEdit,CanDelete) Values(" + VID  + "," + right.ID  + "," + Convert .ToInt32 (right.CanAccess ) + "," + Convert .ToInt32 (right.CanEdit) + "," + Convert .ToInt32 (right.CanDelete ) + ")";
                    cmd.CommandText = insertRights;
                    cmd.ExecuteNonQuery();
                  
                }
                

           
                VTran.Commit();

                return true;
            }
            catch (Exception ex)
            {
                VTran.Rollback();
                throw ex;
            }
            finally
            { con.Close(); }
        }
        public bool SaveLocalUser(User u)
        {
            try
            {
                if (Msource.ToString().Trim().Length == 0) return true;
                int VID = 0;
                conLocal = new SqlConnection(Msource);
                conLocal.Open();
                VTranLocal = conLocal.BeginTransaction();
                cmd = new SqlCommand("select 0", conLocal);
                cmd.Transaction = VTranLocal;
                if (u.UserID == 0)
                {
                    string GetMaxId = "Select IsNull(Max(UserNo),0) +1 From Users";

                    cmd.CommandText = GetMaxId;
                    
                    
                    VID = Convert.ToInt32(cmd.ExecuteScalar());
                }
                else
                {
                    VID = u.UserID;
                }

                string DeleteRights = "Delete from UserAndRights where UserID = " + VID;
                cmd.CommandText = DeleteRights;
                cmd.ExecuteNonQuery();


                
                foreach (UserRight right in u.Rights)
                {
                    string insertRights = "Insert into UserAndRights(UserID,FormID,CanAccess,CanEdit,CanDelete) Values(" + VID + "," + right.ID + "," + Convert.ToInt32(right.CanAccess) + "," + Convert.ToInt32(right.CanEdit) + "," + Convert.ToInt32(right.CanDelete) + ")";
                    cmd.CommandText = insertRights;
                    cmd.ExecuteNonQuery();

                }





                string insert = "if exists(select * from Users where UserNo=" + VID + ")Begin Update Users set UserNo=" + VID + ",UserName='" + u.UserName + "',Password='" + u.UserPassword + "',IsAdministrator=" + Convert.ToInt16(u.IsAdmin) + ",IsActive=" + Convert.ToInt16(u.IsActive) + ",Signature = " + (u.Signatures.Length == 0 ? "NULL" : "@Signature") + ",AllUsers=" + Convert.ToInt16(u.Allusers) + ",BranchID=" + Convert.ToInt32(u.BranchID) + " where UserNo=" + VID + " End Else Begin Insert into Users(UserNo,UserName,Password,IsAdministrator,IsActive,Signature,AllUsers,BranchID,IsCashCounter) Values(" + VID + ",'" + u.UserName + "','" + u.UserPassword + "'," + Convert.ToInt16(u.IsAdmin) + "," + Convert.ToInt16(u.IsActive) + "," + (u.Signatures.Length == 0 ? "NULL" : "@Signature") + "," + Convert.ToInt16(u.Allusers) + "," + Convert.ToInt32(u.BranchID) + "," + Convert.ToInt16(u.IsCashCounter) + ")End";
                
                cmd= new SqlCommand   (insert , conLocal);
                cmd.Transaction = VTranLocal;
                cmd.ExecuteNonQuery();
                VTranLocal.Commit();

                return true;
            }
            catch (Exception ex)
            {
                VTranLocal.Rollback();
                throw ex;
            }
            finally
            { conLocal.Close(); }
        }
        public bool SaveUserRight(int userid, List<UserRight> right)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();
                cmd = new SqlCommand("delete from UserAndRightsRes where userid=" + userid + "", con);
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();
                for (int i = 0; i < right.Count; i++)
                {
                    cmd = new SqlCommand("insert into UserAndRightsRes(userid,rightid) values(" + userid + "," + right[i].RightID + ")", con);
                    cmd.Transaction = VTran;
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch(Exception ex)
            {
                VTranLocal.Rollback();
                throw ex;
            }
            finally
            {
                VTran.Commit();
                con.Close();
            }
        }

        public List<UserRight> LoadRights()
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();
                List<UserRight> userright = new List<UserRight>();
                cmd = new SqlCommand("select rightid,rightname ,cast(0 as bit) as checked  from RightsCataLogRes", con);
                cmd.Transaction = VTran;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        UserRight right = new UserRight(Convert.ToInt32(dr["rightid"]), Convert.ToString(dr["rightname"]), Convert.ToBoolean(dr["checked"]));
                        userright.Add(right);
                    }
                }
                return userright;
            }
            catch(Exception ex)
            {
                VTran.Rollback();
                throw ex;
            }
            finally
            {
                dr.Close();
                VTran.Commit();
                con.Close();
            }
        }

        public List<User> GetUsers(int userID)
        {
            if (users == null) users = new List<User>();
            try
            {
                string where = "";
                if (userID > 0)
                {
                    where = " Where UserNo = " + userID;
                }
                string select = "Select * from Users u  inner join Branch b on b.ID=u.branchid  " + where  ;

                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(select, con);

                dr = cmd.ExecuteReader();


                //Add Users to Collection
                AddUsers(userID );

                con.Close();
                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public void AddUsers(int userid)
        {
            try
            {
                User newUser;
               

                
                while ((!dr.IsClosed) && dr.Read())
                {
                    newUser = new User(Convert.ToInt32(dr["UserNo"]), Convert.ToString(dr["UserName"]), Convert.ToString(dr["Password"]), Convert.ToBoolean(dr["IsActive"]), Convert.ToBoolean(dr["IsAdministrator"]),0, Convert.ToBoolean(dr["IsCashCounter"] == DBNull.Value ? false : Convert.ToBoolean(dr["IsCashCounter"])));
                  //  newUser.DepartmentID = (Convert.ToInt32(dr["CounterID"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["CounterID"])));
                    newUser.BranchID = (Convert.ToInt32(dr["BranchID"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["BranchID"])));
                    newUser.BranchName = (Convert.ToString(dr["BranchName"] == DBNull.Value ? "" : Convert.ToString(dr["BranchName"])));
                   //newUser.CounterName = (Convert.ToString(dr["CounterName"] == DBNull.Value ? "" : Convert.ToString(dr["CounterName"])));
                    newUser.Signatures = dr["Signature"].ToString().Length == 0 ? new byte[0] : (byte[])(dr["Signature"]);
                    //newUser.Signatures = dr["Signature"].ToString().Length == 0 ? new byte[0] : (byte[])(dr["Signature"]);
                  // newUser.IsCashCounter= (Convert.ToBoolean(dr["IsCashCounter"] == DBNull.Value ? false : Convert.ToBoolean(dr["IsCashCounter"])));
                    if (userid > 0)
                    {
                        newUser.Rights = GetUserRights(Convert.ToInt32(dr["UserNo"])); 
                       // newUser.DepRights= GetDepartment(Convert.ToInt32(dr["UserNo"]));

                    }
                    users.Add(newUser);
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex) { throw ex; }

            finally { dr.Close(); }

        }
        public List<DepartmentRights> GetDepartment(int UserID)
        {
            
            try
            {
                SqlDataReader dataReader;
                List<DepartmentRights> userrights = new List<DepartmentRights>();
                con = new SqlConnection(source);
                con.Open();
                
                if (deprights == null) deprights = new List<DepartmentRights>();
                string select = "";

                if (UserID == 0)
                {
                    cmd = new SqlCommand(" Select DepartID as DepartmentID,DepartName as DepartName, CanLogin from Department ", con);
                }

                else
                {
                    cmd = new SqlCommand(  "  select dr.DepartmentID,D.DepartName,IsNull(dr.CanLogin,1) as CanLogin from departmentrights dr RIGHT OUTER JOIN Department D on D.DepartID = dr.DepartmentID where UserID = " + UserID+"",con);

                }


                dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        DepartmentRights d = new DepartmentRights();
                        d.ID = Convert.ToInt32(dataReader["DepartmentID"]);
                        d.DepartmentName = Convert.ToString(dataReader["DepartName"]);
                        d.CanLogin = Convert.ToBoolean(dataReader["CanLogin"]);
                          
                        deprights.Add(d);
                    }
                }
                dataReader.Close(); ;
                return deprights;
            }
            catch (Exception ex)
            {
              
              
                throw;
            }
            finally
            {
              
               
                con.Close();
            }

        }
        public DateTime GetServerDate()
        {
            con = new SqlConnection(source);
            con.Open();
            cmd = new SqlCommand("select getdate()", con);
            return Convert.ToDateTime(cmd.ExecuteScalar()); 
        }
        public User VerifyUser(User u)
        {
            try
            {                
                string select = "Select * from Users where IsActive=1 and UserName='"+ u.UserName +"' and Password='"+ u.UserPassword +"'" ;

                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(select, con);
                dr=cmd.ExecuteReader ();

                while (dr.Read ())
                {
                    user = new User(Convert.ToInt32(dr["UserNo"]), Convert.ToString(dr["UserName"]), Convert.ToString(dr["Password"]),Convert .ToBoolean (dr["IsActive"]),Convert .ToBoolean (dr["IsAdministrator"]), Convert.ToInt32(dr["BranchID"]), Convert.ToBoolean(dr["IsCashCounter"])); 
                }

                return user;
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
                string select = "Select * from Users where IsActive=1 and UserNo=" + userID ;

                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(select, con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    user = new User(Convert.ToInt32(dr["UserNo"]), Convert.ToString(dr["UserName"]), Convert.ToString(dr["Password"]));

                    user.IsAdmin = Convert.ToBoolean(dr["IsAdministrator"]);
                }

                return user;
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
                
                con = new SqlConnection(source);
                con.Open();

                VTran = con.BeginTransaction();
                string DeleteRights = "Delete from UserAndRights where UserID = " + u.UserID ;
                cmd = new SqlCommand(DeleteRights, con);
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();

                string DepartmentRights = "Delete from DepartmentRights where UserID = " + u.UserID;
                //cmd = new SqlCommand(DeleteRights, con);
                //cmd.Transaction = VTran;
                //cmd.ExecuteNonQuery();
                cmd.CommandText = DepartmentRights;
                cmd.ExecuteNonQuery();

                string delete = "Delete From Users where UserNo=" +u.UserID;
                cmd.CommandText = delete;
                cmd.ExecuteNonQuery();
                //cmd = new SqlCommand(delete, con);
                //cmd.Transaction = VTran;
                //cmd.ExecuteNonQuery();

                VTran.Commit();

                return true;
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
                SqlDataReader dataReader;
                List<UserRight> userrights = new List<UserRight>();
                con = new SqlConnection(source);
                con.Open();
             

                if (rights == null) rights = new List<UserRight>();
                string select = "";

                if (UserID == 0)
                {
                    select = "Select FormID,FormName,CanAccess,CanEdit,CanDelete from RightsCatalog ";
                }

                else
                {
                     select = "select UR.FormID,FormName,IsNull(UR.CanAccess,1) as CanAccess,IsNull(UR.CanEdit,1) as CanEdit,IsNull(UR.CanDelete,1) as CanDelete from UserAndRights UR RIGHT OUTER JOIN RightsCatalog RC on RC.FormID = UR.FormID  where UserID = " + UserID;

                }
                //cmd = new SqlCommand("Select  * from UserandRights  where userid=" + UserID+"", con);
                //cmd.Transaction = VTran;
                //dr = cmd.ExecuteReader();
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(select, con);

                dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                   
                    while (dataReader.Read())
                    {
                        rights.Add(new UserRight(Convert.ToInt32(dataReader["FormID"]), Convert.ToString(dataReader["FormName"]), Convert.ToBoolean(dataReader["CanAccess"]), Convert.ToBoolean(dataReader["CanEdit"]), Convert.ToBoolean(dataReader["CanDelete"])));
                    }
                    dataReader.Close();

                    con.Close();

                }
                dataReader.Close();
                return rights;
            }
            catch (Exception)
            {
               
                VTran.Rollback();
                throw;
            }
            finally
            {
              

                con.Close();
            }
        }

        public bool SaveRight(int UserID, int RightID)
        {
            try
            {
               
                VTran.Commit();

                return true;
            }
            catch (Exception ex)
            {
                VTran.Rollback();
                throw ex;
            }
            finally { con.Close(); }
        }

        public bool DeleteRight(int UserID, int RightID)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                VTran = con.BeginTransaction();
                string delete = "Delete from UserAndRights where UserID=" + UserID + " and RightID=" + RightID;
                cmd = new SqlCommand(delete, con);
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();
                VTran.Commit();

                return true;
            }
            catch (Exception ex)
            {
                VTran.Rollback();
                throw ex;
            }
            finally { con.Close(); }
        }
                
    }
}

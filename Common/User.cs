using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class User
    {
        //Fields.
        private int userID;
        private string userName;
        private string userPassword;        
        private bool isActive;
        private bool isAdmin;
        private List<UserRight> rights;
        private List<DepartmentRights> depRights;
        private bool isSupervisor;
        public byte[] Signatures { get; set; }
        public static bool _IsAdmin;
        public static string _UserName;

        public static string Condition;
       
        public static int UserNo;
        public static int BranchCode;
        public int DepartmentID { get; set; }
        public int BranchID { get; set; }
        public String BranchName { get; set; }
        public String CounterName { get; set; }
        public  bool Allusers { get; set; }
        public bool IsCashCounter { get; set; }


        public User()
        { }

        public User(int userID, string userName, string userPassword, bool isActive, bool isAdmin,int branchID,bool isCashcounter) :this()
        {
            this.userID = userID;
            this.userName = userName;
            //_UserName = userName;
            this.userPassword = userPassword;
            this.isActive = isActive;
            this.isAdmin = isAdmin;
            BranchID = branchID;
            IsCashCounter = isCashcounter;
        }
        public User(int userID, string userName, string userPassword, bool isActive, bool isAdmin,List<UserRight> rights): this()
        {
            this.userID = userID;
            this.userName = userName;
           // _UserName = userName;
            this.userPassword = userPassword;
            this.isActive = isActive;
            this.isAdmin = isAdmin;
            this.rights = rights;
        }
        public User(int userID,string userName,string userPassword):this()
        {
            this.userID = userID;
            this.userName = userName;
            //_UserName = userName;
            this.userPassword = userPassword;
        }
        public User(int userID, List<UserRight> rights): this()
        {
            this.userID = userID;
            this.rights = rights;
        }
        //Properties.
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }        
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string UserPassword
        {
            get { return userPassword; }
            set { userPassword = value; }
        }
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }              
        public bool IsAdmin
        {
            get { return isAdmin; }
            set { isAdmin = value; }
        }
        public List<UserRight> Rights
        {
            get { return rights; }
            set { rights = value; }
        }
        public List<DepartmentRights> DepRights
        {
            get { return depRights; }
            set { depRights = value; }
        }
        //Methods.
        public override string ToString()
        {
            return this.userName.ToString();
        }
        public User(int userID, string userName) : this()
        {
            this.userID = userID;
            this.userName = userName;
        }
        public bool IsSupervisor
        {
            get { return isSupervisor; }
            set { isSupervisor = value; }
        }
    }
}

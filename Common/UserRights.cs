using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class UserRight
    {
        public int ID { get; set; }
        public string FormName { get; set; }
        public bool CanAccess { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }

        public int RightID { get; set; }
        public string RightName { get; set; }
        public bool Assign { get; set; }

        public UserRight()
        {

        }

        public UserRight(int id, string formName, bool canAccess, bool canEdit, bool canDelete)
        {
            this.ID = id;
            this.FormName = formName;
            this.CanAccess = canAccess;
            this.CanEdit = canEdit;
            this.CanDelete = canDelete;
        }
        public UserRight(int rightid, string rightname, bool assign)
        {
            this.RightID = rightid;
            this.RightName = rightname;
            this.Assign = assign;
        }
    }
}

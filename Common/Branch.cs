using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
   public class Branch
    {
        public int ID { get; set; }
        public string BranchName { get; set; }

        public static string BranchNo { get; set; }
        public int CityID { get; set; }
        public string CityName { get; set; }
        public bool Select { get; set; }
        public bool IsWarehouse { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string SaleNote { get; set; }



        public Branch()
        { }
        public Branch(int id, string bname, int cityid,bool isWarehouse,string phone,string email,string address,string salenote)
        {
            this.ID = id;
            this.BranchName = bname;
            this.CityID = cityid;
            this.IsWarehouse = isWarehouse;
            this.Phone = phone;
            this.Email = email;
            this.Address = address;
            this.SaleNote = salenote;

        }
    }
}

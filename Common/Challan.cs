using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
   public class Challan
    {
        public Int32 ID { get; set; }
        public Int64 ItemID { get; set; }
        public Int32 BranchID { get; set; }
        public Int32 EntryBranchID { get; set; }
        public Int32 CounterID { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Barcode { get; set; }
        public string ItemName { get; set; }
        public string BranchName { get; set; }
        public string ReceiverBranch { get; set; }
        public string CounterName { get; set; }


        public Decimal Quantity { get; set; }
  
        public Decimal Purate { get; set; }
        public Decimal Cost { get; set; }
        public Int32 serialno { get; set; }
        public Decimal stock { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsReceived { get; set; }
        public bool IsTarnsition { get; set; }
        public string Username { get; set; }
      
        public string CourierAccount { get; set; }
        public string TrackingID { get; set; }
        public string Remarks { get; set; }
        public List<Challan> ChallanLines { get; set; }

       
    }

}

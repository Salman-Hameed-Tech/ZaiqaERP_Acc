using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
   public class ChequeClearance
    {
        public ChartOfAccounts Accouts { get; set; }
        public decimal  Amount { get; set; }
        public string  ChqNo { get; set; }
        public DateTime VoucherDate { get; set; }
        public string Narration { get; set; }
        public bool IsChecked { get; set; }
        public DateTime ChqDate { get; set; }
        public List<ChequeClearance> lines { get; set; }
        public static int Clear = 0;
        public static int Disown = 0;
        public static int Resubmitted = 0;
        public static int Bank = 0;
        public string  accountno { get; set; }  

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class PDCVoucherBody
    {
        public Int64 ChequeNo { get; set; }
        public string Narration { get; set; }
        public decimal Dr { get; set; }
        public decimal Cr { get; set; }   
        public DateTime ChequeDate{ get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
   public class Counter
    {
        public int ID { get; set; }
        public string CounterName { get; set; }

        public Counter()
        { }
        public Counter(int deprtid, string departname)
        {
            this.ID = deprtid;
            this.CounterName = departname;
        }
    }
}

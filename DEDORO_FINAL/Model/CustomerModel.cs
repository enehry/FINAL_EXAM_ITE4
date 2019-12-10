using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEDORO_FINAL
{
    public class CustomerModel
    {
        public int ID { get; set; }
        public string CustName { get; set; }
        public double totalPurch { get; set; }
        public double disc { get; set; }
        public double totalDue { get; set; }
        public double cpay { get; set; }
        public double change { get; set; }

    }
}

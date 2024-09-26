using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Model
{
    public class Ordering
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }
        public string Status { get; set; }
    }
}

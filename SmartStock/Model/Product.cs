using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Model
{
    public class Product
    {
        public int ProductID { get; set; }
        public int SupplierID { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }

        public string ProductImage { get; set; }

        //add on
        public string SupplierName { get; set; }
    }
}


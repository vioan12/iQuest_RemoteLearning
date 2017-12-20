using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Product
    {
        public string name { get; set; }
        public ProductCategory category { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public int size { get; set; }
    }
}

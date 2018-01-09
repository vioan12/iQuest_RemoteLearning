using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class ContainableItem
    {
        public Product product { set; get; }
        public Position position { set; get; }
        public ContainableItem()
        {
            product = new Product();
            position = new Position();
        }
    }
}
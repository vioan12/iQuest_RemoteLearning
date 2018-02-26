using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    abstract class Payment
    {
        protected double value { get; set; }
        public abstract double Pay(double price);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    abstract class PaymentMethod
    {
        public float amount{ get; protected set;}
        public abstract void Pay(int value);
        public abstract void Change(int value);
    }
}

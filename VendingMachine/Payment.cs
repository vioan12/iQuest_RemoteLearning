using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Payment
    {
        private int methodselected{ get; set;}
        private float amount { get; set; }
        public Payment()
        {
            methodselected = 0;
            amount = 0;
        }
        public void PaymentMethod(int method)
        {
            if((method == 1) || (method == 2) || (method == 3))
            {
                methodselected = method;
            }
        }
        public bool Pay(int )
    }
}

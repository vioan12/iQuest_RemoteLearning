using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    abstract class PaymentStock : Payment
    {
        protected string number, name;
        protected double amount;
        public bool valid { protected set; get; }
        public abstract void Validation(string value);
        public override double Pay(double price)
        {
            base.value = price;
            if (amount - base.value >= 0)
            {
                amount = amount - base.value;
                return base.value;
            }
            else
            {
                throw new CustomException("Insufficient funds!!!");
            }
        }
    }
}

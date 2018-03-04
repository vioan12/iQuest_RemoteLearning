using System;

namespace VendingMachine
{
    public abstract class PaymentStock : Payment
    {
        protected string number, name;
        protected double amount;
        public bool valid { protected set; get; }
        public abstract void IsValid(string value);
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
                throw new Exception("Insufficient funds!!!");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class PaymentTerminal
    {
        private double price;
        public double amount { private set; get; }
        public PaymentTerminal()
        {
            price = 0;
            amount = 0;
        }
        public void SelectProduct(double price)
        {
            this.price = price;
        }
        public void AddAmount(Payment payment)
        {
            amount = amount + payment.value;
        }
        public bool IsComplete()
        {
            if(amount < price)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public double GiveChange()
        {
            return amount - price;
        }
        public double Cancel()
        {
            return amount;
        }
    }
}

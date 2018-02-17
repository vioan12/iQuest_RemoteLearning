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
        private double amount;
        public PaymentTerminal()
        {
            Default();
        }
        private void Default()
        {
            price = 0;
            amount = 0;
        }
        private bool IsDefault()
        {
            if ((price == 0) || (amount == 0))
                return true;
            return false;
        }
        public void SelectProduct(int price)
        {
            this.price = price;
        }
        public void AddAmount(Payment payment)
        {
            if(IsDefault() == false)
            {
                amount = amount + payment.value;
            }
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
            if (IsComplete() == true)
            {
                return (amount - price);
            }
            else
            {
                return 0;
            }
        }
    }
}

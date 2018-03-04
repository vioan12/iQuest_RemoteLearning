using System;

namespace VendingMachine
{
    public class PaymentTerminal : Subject
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
            try
            {
                amount = amount + payment.Pay(price);
            }
            catch (Exception exception)
            {
                throw exception;
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
            return amount - price;
        }
        public double Cancel()
        {
            return amount;
        }
    }
}

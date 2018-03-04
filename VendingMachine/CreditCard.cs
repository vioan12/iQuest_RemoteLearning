using System;

namespace VendingMachine
{
    public class CreditCard : PaymentStock
    {
        private string validDate, cvv;
        public CreditCard(string number, string validDate, string name, double amount, string cvv)
        {
            base.number = number;
            this.validDate = validDate;
            base.name = name;
            base.amount = amount;
            this.cvv = cvv;
            valid = false;
        }
        public override void IsValid(string value)
        {
            if(cvv == value)
            {
                valid = true;
            }
            else
            {
                valid = false;
                throw new Exception("Wrong CVV!");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class CreditCard : PaymentStock
    {
        private string validdate, cvv;
        public CreditCard(string number, string validdate, string name, double amount, string cvv)
        {
            base.number = number;
            this.validdate = validdate;
            base.name = name;
            base.amount = amount;
            this.cvv = cvv;
            valid = false;
        }
        public override void Validation(string value)
        {
            if(cvv == value)
            {
                valid = true;
            }
            else
            {
                valid = false;
                throw new CustomException("Wrong CVV!");
            }
        }
    }
}

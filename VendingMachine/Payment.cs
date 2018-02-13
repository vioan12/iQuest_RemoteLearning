using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Payment
    {
        private PaymentMethod paymentmethod;
        private ContainableItem containableitem;
        private Dispenser dispenser;
        public Payment(ref Dispenser dispenser)
        {
            this.dispenser = dispenser;
        }
        public void SelectProduct(ContainableItem containableitem)
        {
            this.containableitem = containableitem;
        }
        public void PaymentMethod(int method)
        {
            if(method == 1)
            {
                paymentmethod = new Coins();
            }
            if(method == 2)
            {
                paymentmethod = new Banknote();
            }
            if(method == 3)
            {
                paymentmethod = new CreditCard();
            }
        }
        public void Pay(int value = 0)
        {
            if(paymentmethod != null)
            {
                paymentmethod.intro(value);
                if (paymentmethod.amount >= containableitem.product.price)
                {
                    Update();

                }
            }
        }
        private void Update()
        {
            dispenser.Update(containableitem.position.row, containableitem.position.column);
            paymentmethod.amount = (float)containableitem.product.price;
        }
    }
}

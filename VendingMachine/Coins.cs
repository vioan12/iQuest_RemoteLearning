using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Coins : PaymentMethod
    {
        private enum enumcoins : int { C1 = 5, C2 = 10, C3 = 50 };
        public override void Pay(int value)
        {
            if (Belongtoenum(value) == true)
            {
                amount = amount + value;
            }
        }
        private bool Belongtoenum(int value)
        {
            foreach (enumcoins coins in Enum.GetValues(typeof(enumcoins)))
            {
                if (value == (int)coins)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

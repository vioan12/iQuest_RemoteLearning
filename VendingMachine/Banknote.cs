using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Banknote : PaymentMethod
    {
        private enum enumbanknote : int { B1 = 1, B2 = 5, B3 = 10, B4 = 50, B5 = 100, B6 = 200, B7 = 500 };
        public override void Pay(int value)
        {
            if (Belongtoenum(value) == true)
            {
                amount = amount + value;
            }
        }
        private bool Belongtoenum(int value)
        {
            foreach (enumbanknote banknote in Enum.GetValues(typeof(enumbanknote)))
            {
                if (value == (int)banknote)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

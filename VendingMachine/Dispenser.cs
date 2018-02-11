using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Dispenser
    {
        public static void update(ref ContainableItemsCollection CIC, ContainableItem CI)
        {
            for(int i=0; i<CIC.Count(); i++)
            {
                if (CIC.GetItem(i).product.name == CI.product.name && CIC.GetItem(i).product.category.name == CI.product.category.name && CIC.GetItem(i).product.price == CI.product.price && CIC.GetItem(i).product.quantity == CI.product.quantity && CIC.GetItem(i).product.size == CI.product.size)
                {
                    if (CIC.GetItem(i).product.quantity > 1)
                    {
                        CIC.GetItem(i).product.quantity -= 1;
                    }
                    else
                    {
                        if (CIC.GetItem(i).product.quantity == 1)
                        {
                            CIC.Remove(CIC.GetItem(i));
                        }
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Dispenser
    {
        public ContainableItemsCollection CIC { set; get; }
        public void Update(int row, int column)
        {
            for(int i=0; i<CIC.Count(); i++)
            {
                if (CIC.GetItem(i).position.CompareWith(new Position(row, column)) == 0)
                {
                    if (CIC.GetItem(i).product.quantity > 1)
                    {
                        CIC.GetItem(i).product.quantity -= 1;
                    }
                    else
                    {
                        if (CIC.GetItem(i).product.quantity == 1)
                        {
                            CIC.Remove(row,column);
                        }
                    }
                }
            }
        }
    }
}

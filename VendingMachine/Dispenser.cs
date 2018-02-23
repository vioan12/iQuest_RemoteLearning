using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Dispenser
    {
        public ContainableItemsCollection collection { private set; get; }
        public Dispenser()
        {
            collection = new ContainableItemsCollection();
        }
        public void DecrementQuantity(int row, int column)
        {
            for(int i = 0; i < collection.Count(); i++)
            {
                if (collection.GetItem(i).position.CompareWith(new Position(row, column)) == 0)
                {
                    if (collection.GetItem(i).product.quantity > 1)
                    {
                        collection.GetItem(i).product.quantity -= 1;
                    }
                    else
                    {
                        collection.Remove(row, column);
                    }
                }
            }
        }
        public void Add(ContainableItem containableitem)
        {
            collection.Add(containableitem);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class ContainableItemsCollection
    {
        private List<ContainableItem> products_list;
        public ContainableItemsCollection()
        {
            products_list = new List<ContainableItem>();
        }
        public void Add(ContainableItem CI)
        {
            products_list.Add(CI);
        }
        public void Remove(ContainableItem CI)
        {
            for (int i = 0; i < products_list.Count; i++)
                if (products_list.ElementAt(i).product.name == CI.product.name && products_list.ElementAt(i).product.category.name == CI.product.category.name && products_list.ElementAt(i).product.price == CI.product.price && products_list.ElementAt(i).product.quantity == CI.product.quantity && products_list.ElementAt(i).product.size == CI.product.size)
                {
                    products_list.Remove(products_list.ElementAt(i));
                }
        }
        public int Count()
        {
            return products_list.Count;
        }
        public ContainableItem GetItem(int index)
        {
            if (products_list.ElementAt(index) != null)
            {
                return products_list.ElementAt(index);
            }
            else
            {
                return null;
            }
        }
    }
}

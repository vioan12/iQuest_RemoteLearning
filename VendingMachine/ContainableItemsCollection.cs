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
            bool sw = true;
            for (int i = 0; (i < products_list.Count) && (sw == true); i++)
                if (products_list.ElementAt(i).position.CompareWith(new Position(CI.position.row, CI.position.column)) == 0)
                {
                    sw = false;
                }
            if (sw == true)
            {
                products_list.Add(CI);
            }
        }
        public void Remove(int row, int column)
        {
            for (int i = 0; i < products_list.Count; i++)
                if (products_list.ElementAt(i).position.CompareWith(new Position(row,column)) == 0) 
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

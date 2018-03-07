using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachine
{
    public class ContainableItemsCollection :  IObserver
    {
        private List<ContainableItem> productsList;
        public ContainableItemsCollection()
        {
            productsList = new List<ContainableItem>();
        }
        public bool Add(ContainableItem item)
        {
            bool sw = true;
            for (int i = 0; (i < productsList.Count) && (sw == true); i++)
                if (productsList.ElementAt(i).position.CompareWith(new Position(item.position.row, item.position.column)) == 0)
                {
                    sw = false;
                }
            if (sw == true)
            {
                productsList.Add(item);
            }
            return sw;
        }
        public void Remove(int row, int column)
        {
            for (int i = 0; i < productsList.Count; i++)
                if (productsList.ElementAt(i).position.CompareWith(new Position(row,column)) == 0) 
                {
                    productsList.Remove(productsList.ElementAt(i));
                }
        }
        public int Count()
        {
            return productsList.Count;
        }
        public ContainableItem GetItem(int index)
        {
            if (productsList.ElementAt(index) != null)
            {
                return productsList.ElementAt(index);
            }
            else
            {
                throw new Exception("Item does not exist!");
            }
        }
        public ContainableItem GetItem(int row, int column)
        {
            for (int i = 0; i < productsList.Count; i++)
                if (productsList.ElementAt(i).position.CompareWith(new Position(row, column)) == 0)
                {
                    return productsList.ElementAt(i);
                }
            throw new Exception("Item does not exist!");
        }
        private void DecrementQuantity(int row, int column)
        {

            for (int i = 0; i < Count(); i++)
            {
                if (GetItem(i).position.CompareWith(new Position(row, column)) == 0)
                {
                    if (GetItem(i).product.quantity > 1)
                    {
                        GetItem(i).product.quantity -= 1;
                    }
                    else
                    {
                        Remove(row, column);
                    }
                }
            }
        }
        public void Update(ContainableItem item)
        {
            DecrementQuantity(item.position.row, item.position.column);
        }
    }
}

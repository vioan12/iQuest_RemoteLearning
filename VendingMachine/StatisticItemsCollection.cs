using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachine
{
    public class StatisticItemsCollection
    {
        private List<StatisticItem> productsList;
        public StatisticItemsCollection()
        {
            productsList = new List<StatisticItem>();
        }
        public void Add(Product product)
        {
            StatisticItem statisticItem = new StatisticItem();
            statisticItem.product = product;
            statisticItem.numberOfSoldProduct = 0;
            statisticItem.profitPercentage = Constants.profit;
            productsList.Add(statisticItem);
        }
        public int Count()
        {
            return productsList.Count();
        }
        public void IncrementNumberOfSoldProduct(Product product)
        {
            for (int i = 0; i < productsList.Count(); i++)
            {
                if (productsList.ElementAt(i).product.CompareWith(product) == 0)
                {
                    productsList.ElementAt(i).numberOfSoldProduct++;
                }
            }
        }
        public StatisticItem GetItem(int index)
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
    }
}

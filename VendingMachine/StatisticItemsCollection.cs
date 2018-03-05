using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachine
{
    public class StatisticItemsCollection : Observer
    {
        private List<StatisticItem> productsList;
        public StatisticItemsCollection()
        {
            productsList = new List<StatisticItem>();
        }
        public void Add(Product product)
        {
            //[AD] spre deosebire de containable items, nu faci nici o verificare si poti adauga acelasi produs de nenumarate ori
            if (!productsList.Any(item => item.product.name == product.name))
            {
                StatisticItem statisticItem = new StatisticItem();
                statisticItem.product = product;
                statisticItem.numberOfSoldProduct = 0;
                statisticItem.profitPercentage = Constants.profit;
                productsList.Add(statisticItem);
            }
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

        //[AD] ??? doua metode care nu au nici o implementare, makes no sense.
        //public void Update(int row, int column)
        //{
        //}

        //public void Update(Product product)
        //{
        //}

        public void Update(ContainableItem item)
        {
            IncrementNumberOfSoldProduct(item.product);
        }
    }
}

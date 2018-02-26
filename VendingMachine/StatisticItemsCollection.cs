using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class StatisticItemsCollection
    {
        private List<StatisticItem> list_products;
        public StatisticItemsCollection()
        {
            list_products = new List<StatisticItem>();
        }
        public void Add(Product product)
        {
            StatisticItem statisticitem = new StatisticItem();
            statisticitem.product = product;
            statisticitem.numberofsoldproduct = 0;
            statisticitem.profitpercentage = Constants.Profit;
            list_products.Add(statisticitem);
        }
        public int Count()
        {
            return list_products.Count();
        }
        public void IncrementNumberOfSoldProduct(Product product)
        {
            for (int i = 0; i < list_products.Count(); i++)
            {
                if (list_products.ElementAt(i).product.CompareWith(product) == 0)
                {
                    list_products.ElementAt(i).numberofsoldproduct++;
                }
            }
        }
        public StatisticItem GetItem(int index)
        {
            if (list_products.ElementAt(index) != null)
            {
                return list_products.ElementAt(index);
            }
            else
            {
                return null;
            }
        }
    }
}

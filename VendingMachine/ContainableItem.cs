using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class ContainableItem
    {
        Dictionary<string, Product> products_list;
            
        public ContainableItem()
        {
            products_list = new Dictionary<string, Product>();
        }
        public void Add(Product Product, int row, int column)
        {
            if (!products_list.ContainsKey(Convert.ToString(row) + " " + Convert.ToString(column)))
            {
                products_list.Add(Convert.ToString(row) + " " + Convert.ToString(column), Product);
            }
        }
        public void Remove(int row, int column)
        {
            if (products_list.ContainsKey(Convert.ToString(row) + " " + Convert.ToString(column)))
            {
                products_list.Remove(Convert.ToString(row) + " " + Convert.ToString(column));
            }
            
        }
        public int Count()
        {
            return products_list.Count;
        }
        public Product GetItem(int row, int column)
        {
            if (products_list.ContainsKey(Convert.ToString(row) + " " + Convert.ToString(column)))
            {
                return products_list[Convert.ToString(row) + " " + Convert.ToString(column)];
            }
            else
                return null;
        }
        public List<Product> GetAllItem()
        {
            List<Product> list = new List<Product>(products_list.Values);
            return list;
        }
    }
}
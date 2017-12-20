using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class ProductCollection
    {
        private List<Product> products_list;
        public ProductCollection()
        {
            products_list = new List<Product>();
        }
        public void Add(Product Product)
        {
            products_list.Add(Product);
        }
        public void Remove(Product Product)
        {
            for (int i = 0; i < products_list.Count; i++)
                if (products_list.ElementAt(i).name == Product.name && products_list.ElementAt(i).category.name == Product.category.name && products_list.ElementAt(i).price == Product.price && products_list.ElementAt(i).quantity == Product.quantity && products_list.ElementAt(i).size == Product.size)
                {
                    products_list.Remove(products_list.ElementAt(i));
                }
        }
        public int Count()
        {
            return products_list.Count;
        }
        public Product GetItem(int index)
        {
            return products_list.ElementAt(index);
        }
    }
}
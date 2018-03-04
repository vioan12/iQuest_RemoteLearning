
namespace VendingMachine
{
    public class Product
    {
        public string name { get; set; }
        public ProductCategory category { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public int size { get; set; }
        public int CompareWith(Product product)
        {
            if (name != product.name)
            {
                return 1;
            }
            if (category.name != product.category.name)
            {
                return 1;
            }
            if (price != product.price)
            {
                return 1;
            }
            return 0;
        }
    }
}
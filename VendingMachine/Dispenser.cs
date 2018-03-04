
namespace VendingMachine
{
    public class Dispenser : Observer
    {
        public ContainableItemsCollection collection { private set; get; }
        public Dispenser()
        {
            collection = new ContainableItemsCollection();
        }
        private void DecrementQuantity(int row, int column)
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
        public override void Update(int row, int column, Product product)
        {
            DecrementQuantity(row, column);
        }
    }
}

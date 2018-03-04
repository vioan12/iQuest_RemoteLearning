
namespace VendingMachine
{
    public abstract class Observer
    {
        public abstract void Update(int row, int column, Product product);
    }
}

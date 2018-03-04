
namespace VendingMachine
{
    public class Dispenser : Subject, Observer
    {
        public void Update(int row, int column)
        {
            Notify(row, column, null);
        }
        public void Update(Product product)
        {
            Notify(0, 0, product);
        }
    }
}

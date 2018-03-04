
namespace VendingMachine
{
    public interface Observer
    {
        void Update(int row, int column);
        void Update(Product product);
    }
}

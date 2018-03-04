
namespace VendingMachine
{
    public abstract class Payment
    {
        protected double value { get; set; }
        public abstract double Pay(double price);

    }
}

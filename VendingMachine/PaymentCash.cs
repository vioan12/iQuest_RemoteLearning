
namespace VendingMachine
{
    public abstract class PaymentCash : Payment
    {
        public PaymentCash(double value)
        {
            this.value = value;
        }
        public override double Pay(double price)
        {
            return base.value;
        }
    }
}

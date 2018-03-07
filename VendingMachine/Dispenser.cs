
using System;

namespace VendingMachine
{
    public class Dispenser : Subject, IObserver
    {
        public void Update(ContainableItem item)
        {
            Notify(item);
        }
    }
}

using System.Collections.Generic;

namespace VendingMachine
{
    public abstract class Subject : ISubject
    {
        private List<IObserver> observersList = new List<IObserver>();
        public void Attach(IObserver observer)
        {
            observersList.Add(observer);
        }
        public void Detach(IObserver observer)
        {
            observersList.Remove(observer);
        }
        public void Notify(ContainableItem item)
        {
            foreach (IObserver observer in observersList)
            {
                observer.Update(item);
            }
        }
    }
}

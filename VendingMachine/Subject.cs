using System.Collections.Generic;

namespace VendingMachine
{
    public class Subject
    {
        private List<Observer> observersList = new List<Observer>();
        public void Attach(Observer observer)
        {
            observersList.Add(observer);
        }
        public void Detach(Observer observer)
        {
            observersList.Remove(observer);
        }
        public void Notify(int row, int column, Product product)
        {
            foreach (Observer observer in observersList)
            {
                observer.Update(row, column, product);
            }
        }
    }
}

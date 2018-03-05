using System.Collections.Generic;

namespace VendingMachine
{
    public abstract class Subject : InterfaceSubject
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

        //[AD] Nu ar trebui sa ai 2 metode de update pe care le apelezi, beats the purpose
        public void Notify(ContainableItem item)
        {
            foreach (Observer observer in observersList)
            {
                observer.Update(item);
            }
        }

        //[AD] Nu ar trebui sa ai 2 metode de update pe care le apelezi, beats the purpose
        //public void Notify(int row, int column, Product product)
        //{
        //    foreach (Observer observer in observersList)
        //    {
        //        observer.Update(row, column);
        //        observer.Update(product);
        //    }
        //}
    }
}

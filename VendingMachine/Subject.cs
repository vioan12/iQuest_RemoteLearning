using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    abstract class Subject
    {
        private List<Observer> list_observers = new List<Observer>();
        public void Attach(Observer observer)
        {
            list_observers.Add(observer);
        }
        public void Detach(Observer observer)
        {
            list_observers.Remove(observer);
        }
        public void Notify(int row, int column)
        {
            foreach (Observer observer in list_observers)
            {
                observer.Update(row, column);
            }
        }
    }
}

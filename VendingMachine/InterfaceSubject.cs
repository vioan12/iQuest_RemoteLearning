using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public interface InterfaceSubject
    {
        void Attach(Observer observer);
        void Detach(Observer observer);
        void Notify(int row, int column, Product product);
    }
}

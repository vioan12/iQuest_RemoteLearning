
namespace VendingMachine
{
    //[AD] pentru numele de interfete se foloseste notatia IObserver
    public interface Observer
    {
        //[AD] Nu inteleg de ce ai nevoie de 2 metode. Ar trebui sa fie una singura, ii dai update si face ce trebuie sa faca. 
        // De fiecare data tu apelezi cu ambele metode ceea ce nu e ok.
        //void Update(int row, int column);
        //void Update(Product product);

        void Update(ContainableItem item);
    }
}

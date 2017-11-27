using System;
using System.Collections.Generic;
using System.Linq;

namespace Tema1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> ListaAnimale = new List<Animal>();
            ListaAnimale.Add(new Animal("Caine", "Hamhamahamaham"));
            ListaAnimale.Add(new Animal("Gaina", "Codcodaaaaac"));
            ListaAnimale.Add(new Animal("Broasca", "Oacoacoac"));
            ListaAnimale.Add(new Animal("Pisica", "miiauuuuuu"));
            ListaAnimale.Add(new Animal("Porc", "Grofgrof"));

            for (int i = 0; i < ListaAnimale.Count; i++)
            {
                Console.Out.WriteLine(ListaAnimale.ElementAt<Animal>(i).Get_nume + "->" + ListaAnimale.ElementAt<Animal>(i).Get_sunet);
            }
        }
    }
}


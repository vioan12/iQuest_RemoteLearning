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
            ListaAnimale.Add(new Broasca("Turti"));
            ListaAnimale.Add(new Caine("Albatronic"));
            ListaAnimale.Add(new Caine("HotDog"));
            ListaAnimale.Add(new Gaina("Iulia"));
            ListaAnimale.Add(new Pisica("China"));
            ListaAnimale.Add(new Porc("Franklin"));

            for (int i = 0; i < ListaAnimale.Count; i++)
            {
                Console.Out.WriteLine(ListaAnimale.ElementAt<Animal>(i).Get_tip+":"+ ListaAnimale.ElementAt<Animal>(i).Get_nume + "->" + ListaAnimale.ElementAt<Animal>(i).Get_sunet);
            }
        }
    }
}

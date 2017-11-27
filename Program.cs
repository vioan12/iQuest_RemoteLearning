using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Tema1
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal a = new Animal("asd", "dfs");
            List<Animal> ListaAnimale = new List<Animal>();
            int n;
            try
            {
                using (StreamReader sr = new StreamReader("Input.txt"))
                {
                    string line,line2;
                    line = sr.ReadLine();
                    n = Int32.Parse(line);
                    for(int i=0;i<n;i++)
                    {
                        line = sr.ReadLine();
                        line2 = sr.ReadLine();
                        ListaAnimale.Add(new Animal(line, line2));
                    }
                }
                for(int i=0;i<ListaAnimale.Count;i++)
                {
                    Console.Out.WriteLine(ListaAnimale.ElementAt<Animal>(i).Get_nume + "->" + ListaAnimale.ElementAt<Animal>(i).Get_sunet);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



        }
    }
}

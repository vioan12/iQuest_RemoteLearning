using System;

namespace Tema1
{
    abstract class Animal
    {
        private String nume, sunet;
        public String Get_nume
        {
            get { return nume; }
        }
        public String Get_sunet
        {
            get { return sunet; }
        }
        public abstract String Get_tip { get; }
        public Animal(String valueofnume, String valueofsunet)
        {
            nume = valueofnume;
            sunet = valueofsunet;
        }
    }
}

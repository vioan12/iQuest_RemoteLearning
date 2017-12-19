using System;

namespace Tema1
{
    abstract class Animal
    {
        private String nume;
        public String Get_nume
        {
            get { return nume; }
        }
        public abstract String Get_sunet { get; }
        public abstract String Get_tip { get; }
        public Animal(String valueofnume)
        {
            nume = valueofnume;
        }
    }
}

using System;

namespace Tema1
{
    class Animal
    {
        private String nume;
        private String sunet;

        public String Get_nume
        {
            get { return nume; }
        }
        public String Get_sunet
        {
            get { return sunet; }
        }
        public Animal(String valueofnume, String valueofsunet)
        {
            nume = valueofnume;
            sunet = valueofsunet;
        }
    }
}

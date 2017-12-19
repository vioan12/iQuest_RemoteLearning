using System;

namespace Tema1
{
    class Pisica : Animal
    {
        private String sunet;

        public override String Get_sunet
        {
            get { return sunet; }
        }
        public override String Get_tip
        {
            get { return this.GetType().Name; }
        }
        public Pisica(string valueofnume) : base(valueofnume)
        {
            sunet = "miau";
        }
    }
}

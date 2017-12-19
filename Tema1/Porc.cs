using System;

namespace Tema1
{
    class Porc : Animal
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
        public Porc(string valueofnume) : base(valueofnume)
        {
            sunet = "grof";
        }
    }
}

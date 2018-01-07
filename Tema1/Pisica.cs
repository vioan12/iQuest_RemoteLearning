using System;

namespace Tema1
{
    class Pisica : Animal
    {
        public override String Get_tip
        {
            get { return this.GetType().Name; }
        }
        public Pisica(string valueofnume) : base(valueofnume, "miau")
        {
        }
    }
}

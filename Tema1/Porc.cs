using System;

namespace Tema1
{
    class Porc : Animal
    {
        public override String Get_tip
        {
            get { return this.GetType().Name; }
        }
        public Porc(string valueofnume) : base(valueofnume, "grof")
        {
        }
    }
}

using System;

namespace Tema1
{
    class Gaina : Animal
    {
        public override String Get_tip
        {
            get { return this.GetType().Name; }
        }
        public Gaina(string valueofnume) : base(valueofnume, "cotcodac")
        {
        }
    }
}

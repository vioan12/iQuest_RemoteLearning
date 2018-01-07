using System;

namespace Tema1
{
    class Broasca : Animal
    {
        public override String Get_tip
        {
            get { return this.GetType().Name; }
        }
        public Broasca(string valueofnume) : base(valueofnume, "oac")
        {
        }
    }
}

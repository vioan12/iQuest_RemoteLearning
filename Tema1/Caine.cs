using System;

namespace Tema1
{
    class Caine : Animal
    {
        public override String Get_tip
        {
            get { return this.GetType().Name; }
        }
        public Caine(string valueofnume) : base(valueofnume, "ham")
        {
        }
    }
}

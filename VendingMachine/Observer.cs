﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    abstract class Observer
    {
        public abstract void Update(int row, int column);
    }
}

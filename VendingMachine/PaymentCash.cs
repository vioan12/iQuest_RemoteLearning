﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    abstract class PaymentCash : Payment
    {
        public PaymentCash(double value)
        {
            this.value = value;
        }
    }
}

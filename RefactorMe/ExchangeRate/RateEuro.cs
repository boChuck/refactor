﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe
{
    class RateEuro : Currency
    {
        public override double GetRate()
        {
            return 0.67;
        }
    }
}

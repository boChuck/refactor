﻿using RefactorMe.ExchangeRate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe
{
    public class RateUS : ICurrency
    {
        public double ConvertPrice(double price)
        {
            return price * 0.76;
        }
        public double GetRate()
        {
            return 0.76;
        }
    }
}
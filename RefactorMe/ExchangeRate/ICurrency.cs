﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.ExchangeRate
{
    public interface ICurrency
    {
       double ConvertPrice(double price);
       double GetRate();
    }
}

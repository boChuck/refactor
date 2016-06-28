using RefactorMe.ExchangeRate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe
{
    public class NormalRate : ICurrency
    {
        public double ConvertPrice(double price)
        {
            return price * 1;
        }

        public double GetRate()
        {
            return 1;
        }
    }
}

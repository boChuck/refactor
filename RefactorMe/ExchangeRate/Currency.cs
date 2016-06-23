using RefactorMe.ExchangeRate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe
{
    public class Currency : ICurrency
    {
       public virtual double GetRate()
        {
            return 1;
        }
    }
}

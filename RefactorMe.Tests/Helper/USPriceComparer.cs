using RefactorMe.DontRefactor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.Tests.Helper
{
    class USPriceComparer : PriceComparer
    {
        public override int Compare(Product x, Product y)
        {
            rate = new RateUS();
            return (x.Price * rate.GetRate()).CompareTo(y.Price);
        }
    }
}

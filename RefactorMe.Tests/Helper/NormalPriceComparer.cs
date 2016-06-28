using RefactorMe.DontRefactor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.Tests.Helper
{
    class NormalPriceComparer : PriceComparer
    {
        public override int Compare(Product x, Product y)
        {
           
            return x.Price.CompareTo(y.Price);
        }
    }
}

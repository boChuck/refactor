using RefactorMe.DontRefactor.Models;
using RefactorMe.ExchangeRate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.Tests.Helper
{
    class PriceComparer : IComparer<Product>, IComparer
    {
       public ICurrency rate;
        public int Compare(object x, object y)
        {
            var castX = x as Product;
            var castY = y as Product;

            if (castX == null || castY == null)
            {
                return 0;
            }

            return Compare(castX, castY);
        }

        public virtual int Compare(Product x, Product y)
        {
           
            return 0;
        }
    }
}

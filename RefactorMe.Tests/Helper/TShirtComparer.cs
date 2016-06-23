using RefactorMe.DontRefactor.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.Tests.Helper
{
    class TShirtComparer : IComparer<TShirt>, IComparer
    {
        public int Compare(object x, object y)
        {
            var castX = x as TShirt;
            var castY = y as TShirt;

            if (castX == null || castY == null)
            {
                return 0;
            }

            return Compare(castX, castY);
        }

        public int Compare(TShirt x, TShirt y)
        {
            var comparison = string.Compare(x.Name, y.Name, StringComparison.Ordinal);
            if (comparison != 0) return comparison;
            comparison = string.Compare(x.Colour, y.Colour, StringComparison.Ordinal);
            if (comparison != 0) return comparison;
            comparison = x.Price.CompareTo(y.Price);
            if (comparison != 0) return comparison;
            return string.Compare(x.ShirtText, y.ShirtText, StringComparison.Ordinal);
        }
    }
}

using RefactorMe.DontRefactor.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.Tests.Helper
{
    class LawnmoverComparer : IComparer<Lawnmower>, IComparer
    {
        public int Compare(object x, object y)
        {
            var castX = x as Lawnmower;
            var castY = y as Lawnmower;

            if (castX == null || castY == null)
            {
                return 0;
            }

            return Compare(castX, castY);
        }

        public int Compare(Lawnmower x, Lawnmower y)
        {
            var comparison = string.Compare(x.Name, y.Name, StringComparison.Ordinal);
            if (comparison != 0) return comparison;
            comparison = string.Compare(x.FuelEfficiency, y.FuelEfficiency, StringComparison.Ordinal);
            if (comparison != 0) return comparison;
            comparison = x.Price.CompareTo(y.Price);
            if (comparison != 0) return comparison;

            return x.IsVehicle.CompareTo(y.IsVehicle);
        }
    }
}

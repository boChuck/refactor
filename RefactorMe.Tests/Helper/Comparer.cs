using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.Tests.Helper
{
    class Comparer : IComparer<object>, IComparer
    {
        public int Compare(object x, object y)
        {
            return 0;
        }
    }
}

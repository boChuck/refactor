using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.Controller
{
   public interface IProductController
    {
       void Add();
       string GetProductType();
    }
}

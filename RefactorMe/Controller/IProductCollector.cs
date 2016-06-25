using RefactorMe.DontRefactor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.Controller
{
    public interface IProductCollector
    {
        List<Product> CollectProducts();
    }
}

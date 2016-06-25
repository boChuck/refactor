using RefactorMe.DontRefactor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.Controller
{
    class ProductCollector : IProductCollector
    {
        
        readonly IList<IProductController> _allControllers;
        public ProductCollector(IList<IProductController> allControllers)
        {
            _allControllers = allControllers;
        }

        public List<Product> CollectProducts()
        {
            var ps = new List<Product>();
            foreach (var controller in _allControllers)
            {
                ps.AddRange(controller.GetCurrencyConvertedItems().ToList());
            }  
            return ps;
        }
    }
}

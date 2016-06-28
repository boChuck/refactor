using RefactorMe.DontRefactor.Data;
using RefactorMe.DontRefactor.Data.Implementation;
using RefactorMe.DontRefactor.Models;
using RefactorMe.ExchangeRate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefactorMe.Controller;
using Ninject;
using Ninject.Modules;
using System.Reflection;

namespace RefactorMe
{
    public class ProductDataConsolidator
    {
        readonly IProductCollector _propCollector;
        
        public ProductDataConsolidator(IProductCollector collector)
        {
            _propCollector = collector;
        }

        public List<Product> Get() {
            return _propCollector.CollectProducts();
        }
    }
}

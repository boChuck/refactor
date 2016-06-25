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
        private readonly IProductCollector propCollector;

        public ProductDataConsolidator(IProductCollector collector)
        {
            propCollector = collector;
        }

        public List<Product> Get() {

            
            return propCollector.CollectProducts();
           
        }

        public List<Product> GetInUSDollars() {
         
           
            return propCollector.CollectProducts();
           
        }

        public List<Product> GetInEuros() {
            // set currency on Kernel
           

            // Get new ProductCollector with Ninject
            return propCollector.CollectProducts();
        }

  
    }
}

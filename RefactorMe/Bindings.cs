using Ninject.Modules;
using RefactorMe.Controller;
using RefactorMe.ExchangeRate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe
{
   public class Bindings : NinjectModule
    {
        public override void Load()
        {
#if DEBUG
            Bind<IProductCollector>().To<ProductCollector>();
            Bind<ICurrency>().To<RateUS>();
            Bind<ICurrency>().To<RateEuro>();
            Bind<ICurrency>().To<NormalRate>();
            Bind<IProductController>().To<LawnmoverController>();
            Bind<IProductController>().To<PhoneCaseController>();
            Bind<IProductController>().To<TShirtController>();
#else
           
#endif

        }
    }
}

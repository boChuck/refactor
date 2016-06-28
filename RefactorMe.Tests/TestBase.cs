using Ninject;
using Ninject.Parameters;
using NUnit.Framework;
using RefactorMe.Controller;
using RefactorMe.DontRefactor.Data.Implementation;
using RefactorMe.DontRefactor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.Tests
{
    [TestFixture]
    public class TestBase
    {
        public LawnmowerRepository l;
        public PhoneCaseRepository p;
        public TShirtRepository t;
        public StandardKernel kernel;

        [SetUp]
        public void TestSetup()
        {
            l = new LawnmowerRepository();
            p = new PhoneCaseRepository();
            t = new TShirtRepository();
            kernel = new StandardKernel(new Bindings());
            kernel.Load(Assembly.GetExecutingAssembly());

        }

        public IProductCollector GetCollector(object currency)
        {


            var lawnmoverController = kernel.Get<LawnmoverController>(new ConstructorArgument("currency", currency), new ConstructorArgument("lr", l));
            var phoneCaseController = kernel.Get<PhoneCaseController>(new ConstructorArgument("currency", currency), new ConstructorArgument("pcr", p));
            var tShirtController = kernel.Get<TShirtController>(new ConstructorArgument("currency", currency), new ConstructorArgument("tr", t));

            var controllers = new List<IProductController>();
            controllers.Add(lawnmoverController);
            controllers.Add(phoneCaseController);
            controllers.Add(tShirtController);

            return kernel.Get<IProductCollector>(new ConstructorArgument("allControllers", controllers));
        }

        public List<Product> GetNormalPriceProducts()
        {
            var currency = kernel.Get<NormalRate>();
            var collector = GetCollector(currency);
            var consolidator = new ProductDataConsolidator(collector);
            return consolidator.Get();
        }
    }
}

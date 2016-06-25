using RefactorMe;
using System;
using RefactorMe.DontRefactor.Models;
using Ninject;
using System.Reflection;
using RefactorMe.DontRefactor.Data.Implementation;
using RefactorMe.Controller;
using Ninject.Parameters;
using System.Collections.Generic;
using NUnit.Framework;

namespace RefactorMe.Tests
{
    [TestFixture]
    public class ProductDataConsolidatorTest
    {
        [SetUp]
        public void TestSetup()
        {
            var l = new LawnmowerRepository();
            var p = new PhoneCaseRepository();
            var t = new TShirtRepository();
        }

        [Test]
        public void CanGetProductList()
        {
            
            // Arrange
            var kernel = new StandardKernel(new Bindings());
            kernel.Load(Assembly.GetExecutingAssembly());
            var currency = kernel.Get<RateUS>();

            var lawnmoverController = kernel.Get<LawnmoverController>(new ConstructorArgument("currency", currency ), new ConstructorArgument("lr", l));
            var phoneCaseController = kernel.Get<PhoneCaseController>(new ConstructorArgument("currency", currency), new ConstructorArgument("pcr", p));
            var tShirtController = kernel.Get<TShirtController>(new ConstructorArgument("currency", currency), new ConstructorArgument("tr", t));

            var controllers = new List<IProductController>();
            controllers.Add(lawnmoverController);
            controllers.Add(phoneCaseController);
            controllers.Add(tShirtController);

             var collector = kernel.Get<IProductCollector>(new ConstructorArgument("allControllers", controllers));

            // Act
            var consolidator = new ProductDataConsolidator(collector);
            var lists = consolidator.Get();
            // Assert
            CollectionAssert.AllItemsAreNotNull(lists);
           
        }

        [TearDown]
        public void TestTearDown()
        {
            
        }
    }
}

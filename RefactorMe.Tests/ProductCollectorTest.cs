using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

using Ninject;
using Ninject.Parameters;
using RefactorMe.Controller;

namespace RefactorMe.Tests
{
    
    [TestFixture]
    public class ProductCollectorTest : TestBase
    {
        [Test]
        public void CanCollectLawnmoverProducts()
        {
            // Arrange
            var currency = kernel.Get<NormalRate>();
            var controller = kernel.Get<LawnmoverController>(new ConstructorArgument("currency", currency), new ConstructorArgument("lr", l));
            var controllers = new List<IProductController>();
            controllers.Add(controller);
            var collector = new ProductCollector(controllers);

            // Act
            var products = collector.CollectProducts();

            // Assert
            Assert.AreEqual(3, products.Count);
            products.ForEach(x => Assert.AreEqual(controller.GetProductType(), x.Type));
        }
        [Test]
        public void CanCollectPhoneCaseProducts()
        {
            // Arrange
            var currency = kernel.Get<NormalRate>();
            var controller = kernel.Get<PhoneCaseController>(new ConstructorArgument("currency", currency), new ConstructorArgument("pcr", p));
            var controllers = new List<IProductController>();
            controllers.Add(controller);
            var collector = new ProductCollector(controllers);

            // Act
            var products = collector.CollectProducts();

            // Assert
            Assert.AreEqual(2, products.Count);
            products.ForEach(x => Assert.AreEqual(controller.GetProductType(), x.Type));
        }
        [Test]
        public void CanCollectTShirtProducts()
        {
            // Arrange
            var currency = kernel.Get<NormalRate>();
            var controller = kernel.Get<TShirtController>(new ConstructorArgument("currency", currency), new ConstructorArgument("tr", t));
            var controllers = new List<IProductController>();
            controllers.Add(controller);
            var collector = new ProductCollector(controllers);

            // Act
            var products = collector.CollectProducts();

            // Assert
            Assert.AreEqual(3, products.Count);
            products.ForEach(x => Assert.AreEqual(controller.GetProductType(), x.Type));
        }
        [Test]
        public void ShowThrowNullException()
        {
            // Arrange
        
            var collector = new ProductCollector(null);
           
            // Act/Assert
            Assert.Throws<NullReferenceException>(() => collector.CollectProducts());
        }
    }
}

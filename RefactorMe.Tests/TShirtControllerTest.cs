using System;
using NUnit.Framework;
using RefactorMe.DontRefactor.Models;
using System.Collections.Generic;
using RefactorMe.DontRefactor.Data.Implementation;
using RefactorMe.Tests.Helper;
using System.Linq;
using Ninject;
using Ninject.Parameters;

namespace RefactorMe.Tests
{
    [TestFixture]
    public class TShirtControllerTest : TestBase
    {
        [Test]
        public void GetProductTypeTest()
        {
            // Arrange
            var currency = kernel.Get<NormalRate>();
            var controller = kernel.Get<TShirtController>(new ConstructorArgument("currency", currency), new ConstructorArgument("tr", t));
            // Act
            string type = controller.GetProductType();
            // Assert

            Assert.AreEqual("T-Shirt", type);
        }

        [Test]
        public void CanGetCurrencyConvertedItemsNormal()
        {
            // Arrange
            var currency = kernel.Get<NormalRate>();
            var controller = new TShirtController(currency, t);

            // Act
            var products = controller.GetCurrencyConvertedItems();

            // Assert

            CollectionAssert.AllItemsAreNotNull(products);
            CollectionAssert.AllItemsAreInstancesOfType(products, typeof(Product));
        }

        [Test]
        public void CanGetCurrencyConvertedItemsEURO()
        {
            // Arrange
            var currency = kernel.Get<RateEuro>();
            var controller = new TShirtController(currency, t);

            // Act
            var products = controller.GetCurrencyConvertedItems();

            // Assert

            CollectionAssert.AllItemsAreNotNull(products);
            CollectionAssert.AllItemsAreInstancesOfType(products, typeof(Product));
        }

        [Test]
        public void CanGetCurrencyConvertedItemsUS()
        {
            // Arrange
            var currency = kernel.Get<RateUS>();
            var controller = new TShirtController(currency, t);

            // Act
            var products = controller.GetCurrencyConvertedItems();

            // Assert

            CollectionAssert.AllItemsAreNotNull(products);
            CollectionAssert.AllItemsAreInstancesOfType(products, typeof(Product));
        }

        [Test]
        public void ShowThrowNullException()
        {
            // Arrange

            var controller = new TShirtController(null, null);

            // Act/Assert
            Assert.Throws<NullReferenceException>(() => controller.GetCurrencyConvertedItems().FirstOrDefault());
        }
    }
}

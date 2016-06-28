using System;
using NUnit.Framework;
using RefactorMe.DontRefactor.Models;
using RefactorMe.DontRefactor.Data.Implementation;
using RefactorMe.Tests.Helper;
using System.Linq;
using System.Collections.Generic;
using Ninject;
using Ninject.Parameters;
using RefactorMe.ExchangeRate;

namespace RefactorMe.Tests
{
    [TestFixture]
    public class LawnmoverControllerTest : TestBase
    {
        [Test]
        public void GetProductTypeTest()
        {
            // Arrange

            var currency = kernel.Get<NormalRate>();
            var controller = kernel.Get<LawnmoverController>(new ConstructorArgument("currency", currency), new ConstructorArgument("lr",l));

            // Act
            string type = controller.GetProductType();
            // Assert

            Assert.AreEqual("Lawnmower", type);
        }


        [Test]
        public void CanGetCurrencyConvertedItemsNormal()
        {
            // Arrange
            var currency = kernel.Get<NormalRate>();
            var controller = new LawnmoverController(currency, l);

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
            var controller = new LawnmoverController(currency, l);

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
            var controller = new LawnmoverController(currency, l);

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

            var controller = new LawnmoverController(null, null);
           
            // Act/Assert
            Assert.Throws<NullReferenceException>(() => controller.GetCurrencyConvertedItems().FirstOrDefault());
        }
    }
}

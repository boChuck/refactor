using System;
using NUnit.Framework;
using NUnit.VisualStudio.TestAdapter;
using RefactorMe.DontRefactor.Models;
using System.Collections.Generic;
using RefactorMe.DontRefactor.Data.Implementation;
using RefactorMe.Tests.Helper;
using System.Linq;

namespace RefactorMe.Tests
{
    [TestFixture]
    public class TShirtControllerTest
    {
        [Test]
        public void CanCreateTShirtConstruct()
        {
            // Arrange
            var ps = new List<Product>();
            var currency = new Currency();


            var tr = new TShirtRepository();

            // Act
            var controller = new TShirtController(ps, currency, tr);
            // Assert

            Assert.AreEqual(ps, controller.ps);
            Assert.AreEqual(currency, controller.iCurrency);
            CollectionAssert.AllItemsAreInstancesOfType(ps, typeof(TShirt));
            CollectionAssert.AreEqual(tr.GetAll().ToList(), controller.tshirts, new TShirtComparer());
        }

        [TestCase(null, typeof(NullReferenceException))]
        public void CannotCreateTShirtConstruct(TShirtRepository arg, Type expectedException)
        {
            // Arrange Act Assert
            Assert.Throws(expectedException, () => new TShirtController(null, null, arg));
        }

        [Test]
        public void GetProductTypeTest()
        {
            // Arrange
            var tr = new TShirtRepository();
            var controller = new TShirtController(null, null, tr);
            // Act
            string type = controller.GetProductType();
            // Assert

            Assert.AreEqual("T-Shirt", type);
        }
    }
}

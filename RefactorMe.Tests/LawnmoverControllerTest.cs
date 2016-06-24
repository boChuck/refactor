using System;
using RefactorMe;
using RefactorMe.DontRefactor.Models;
using System.Collections.Generic;
using RefactorMe.DontRefactor.Data.Implementation;
using System.Linq;
using RefactorMe.DontRefactor.Data;
using NUnit.Framework;
using System.Collections;
using RefactorMe.Tests.Helper;

namespace RefactorMe.Tests
{
    [TestFixture]
    public class LawnmoverControllerTest
    {
        [Test]
        public void CanCreateLawnmoverConstruct()
        {
            // Arrange
            var ps = new List<Product>();
            var currency = new Currency();


            var lr = new LawnmowerRepository();

            // Act
            var controller = new LawnmoverController(ps, currency, lr);
            // Assert

            Assert.AreEqual(ps, controller.ps);
            Assert.AreEqual(currency, controller.iCurrency);
            CollectionAssert.AllItemsAreInstancesOfType(ps, typeof(Lawnmower));
            CollectionAssert.AreEqual(lr.GetAll().ToList(), controller.lawnmovers, new LawnmoverComparer());
        }

        [TestCase(null, typeof(NullReferenceException))]
        public void CannotCreateTShirtConstruct(LawnmowerRepository arg, Type expectedException)
        {
            // Arrange Act Assert
            Assert.Throws(expectedException, () => new LawnmoverController(null, null, arg));
        }

        [Test]
        public void GetProductTypeTest()
        {
            // Arrange
            var lr = new LawnmowerRepository();
            var controller = new LawnmoverController(null, null,lr);
            // Act
            string type = controller.GetProductType();
            // Assert

            Assert.AreEqual("Lawnmower", type);
        }

        [TestCase(null, typeof(NullReferenceException))]
        public void AddWithNullRefExceptionTest(List<Product> ps, Type expectedException)
        {
            // Arrange
            var lr = new LawnmowerRepository();
            var controller = new LawnmoverController(ps, null, lr);

            // Act/Assert
            Assert.Throws(expectedException, () => controller.Add());
        }

        [Test]
        public void AddTest()
        {
            // Arrange
            var controller = new LawnmoverController {
                iCurrency = new Currency(),
                lawnmovers = new LawnmowerRepository().GetAll(),
                ps = new List<Product>()
            };


            // Act
            controller.Add();

            // Assert
            CollectionAssert.AllItemsAreInstancesOfType(controller.ps, typeof(Product));
            Assert.AreEqual(3, controller.ps.ToList().Count);
            controller.ps.ToList().ForEach(i => Assert.AreEqual("Lawnmower", i.Type ));
        }
    }
}

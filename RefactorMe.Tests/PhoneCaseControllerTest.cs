using System;
using NUnit.Framework;
using RefactorMe.DontRefactor.Models;
using RefactorMe.DontRefactor.Data.Implementation;
using RefactorMe.Tests.Helper;
using System.Linq;
using System.Collections.Generic;

namespace RefactorMe.Tests
{
    [TestFixture]
    public class PhoneCaseControllerTest
    {
        [Test]
        public void CanCreatePhoneCaseConstruct()
        {
            // Arrange
            var ps = new List<Product>();
            var currency = new Currency();


            var pr = new PhoneCaseRepository();

            // Act
            var controller = new PhoneCaseController(ps, currency, pr);
            // Assert

            Assert.AreEqual(ps, controller.ps);
            Assert.AreEqual(currency, controller.iCurrency);
            CollectionAssert.AllItemsAreInstancesOfType(ps, typeof(Lawnmower));
            CollectionAssert.AreEqual(pr.GetAll().ToList(), controller.PhoneCases, new PhoneCaseComparer());
        }

        [TestCase(null, typeof(NullReferenceException))]
        public void CannotCreateTShirtConstruct(PhoneCaseRepository arg, Type expectedException)
        {
            // Arrange Act Assert
            Assert.Throws(expectedException, () => new PhoneCaseController(null, null, arg));
        }

        [Test]
        public void GetProductTypeTest()
        {
            // Arrange
            var pr = new PhoneCaseRepository();
            var controller = new PhoneCaseController(null, null, pr);
            // Act
            string type = controller.GetProductType();
            // Assert
            Assert.AreEqual("Phone Case", type);
        }
        [Test]
        public void AddTest()
        {
            // Arrange
            var controller = new PhoneCaseController
            {
                iCurrency = new Currency(),
                PhoneCases = new PhoneCaseRepository().GetAll(),
                ps = new List<Product>()
            };


            // Act
            controller.Add();

            // Assert
            CollectionAssert.AllItemsAreInstancesOfType(controller.ps, typeof(Product));
            Assert.AreEqual(2, controller.ps.ToList().Count);
            controller.ps.ToList().ForEach(i => Assert.AreEqual("Phone Case", i.Type));
        }
    }
}

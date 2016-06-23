using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactorMe;
using RefactorMe.DontRefactor.Models;
using System.Collections.Generic;
using RefactorMe.DontRefactor.Data.Implementation;
using System.Linq;
using RefactorMe.DontRefactor.Data;

namespace RefactorMe.Tests
{
    [TestClass]
    public class LawnmoverControllerTest
    {
        [TestMethod]
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
            CollectionAssert.AreEqual(controller.lawnmovers.ToList(), lr.GetAll().ToList());
        }

        [TestMethod()]
        public void GetProductTypeTest()
        {
            // Arrange
            var controller = new LawnmoverController(null, null,null);
            // Act
            string type = controller.GetProductType();
            // Assert

            Assert.AreEqual("Lawnmower", type);
        }
    }
}

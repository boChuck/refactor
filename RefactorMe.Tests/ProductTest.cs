using System;
using NUnit.Framework;
using RefactorMe.DontRefactor.Data.Implementation;
using RefactorMe.DontRefactor.Models;
using System.Linq;
using System.Collections.Generic;

namespace RefactorMe.Tests.Helper
{
    [TestFixture]
    public class ProductTest
    {
        [TestCase(typeof(TShirtRepository), "T-Shirt")]
        public void AddTest( Type cls, string type )
        {
            // Arrange
            var controller = new TShirtController
            {
                iCurrency = new Currency(),
                tshirts = new TShirtRepository().GetAll(),
                ps = new List<Product>()
            };


            // Act
            controller.Add();

            // Assert
            CollectionAssert.AllItemsAreInstancesOfType(controller.ps, typeof(Product));
            Assert.AreEqual(2, controller.ps.ToList().Count);
            controller.ps.ToList().ForEach(i => Assert.AreEqual(type, i.Type));
        }
    }
}

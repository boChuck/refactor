using System;
using NUnit.Framework;
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
          

  

            // Act
          
            // Assert

        
        }

        [TestCase(null, typeof(NullReferenceException))]
        public void CannotCreateTShirtConstruct(TShirtRepository arg, Type expectedException)
        {
            // Arrange Act Assert
            Assert.Throws(expectedException, () => new TShirtController(null, arg));
        }

        [Test]
        public void GetProductTypeTest()
        {
            // Arrange
            var tr = new TShirtRepository();
            var controller = new TShirtController( null, tr);
            // Act
            string type = controller.GetProductType();
            // Assert

            Assert.AreEqual("T-Shirt", type);
        }

        [Test]
        public void AddTest()
        {
            // Arrange
           

            // Act
          

            // Assert
          
        }
    }
}

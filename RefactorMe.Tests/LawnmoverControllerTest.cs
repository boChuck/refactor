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
           

            // Act
            
            // Assert

        
        }

        [TestCase(null, typeof(NullReferenceException))]
        public void CannotCreateTShirtConstruct(LawnmowerRepository arg, Type expectedException)
        {
            // Arrange Act Assert
            Assert.Throws(expectedException, () => new LawnmoverController( null, arg));
        }

        [Test]
        public void GetProductTypeTest()
        {
            // Arrange
            var lr = new LawnmowerRepository();
            var controller = new LawnmoverController( null,lr);
            // Act
            string type = controller.GetProductType();
            // Assert

            Assert.AreEqual("Lawnmower", type);
        }

        [TestCase(null, typeof(NullReferenceException))]
        public void AddWithNullRefExceptionTest(List<Product> ps, Type expectedException)
        {
            // Arrange
           

            // Act/Assert
         //   Assert.Throws(expectedException, () => controller.Add());
        }

        [Test]
        public void AddTest()
        {
            // Arrange
           

            // Act
          

            // Assert
            
           // controller.ps.ToList().ForEach(i => Assert.AreEqual("Lawnmower", i.Type ));
        }
    }
}

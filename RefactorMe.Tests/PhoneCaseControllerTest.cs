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
         

            // Act
           
            // Assert

       
        }

        [TestCase(null, typeof(NullReferenceException))]
        public void CannotCreateTShirtConstruct(PhoneCaseRepository arg, Type expectedException)
        {
            // Arrange Act Assert
            Assert.Throws(expectedException, () => new PhoneCaseController( null, arg));
        }

        [Test]
        public void GetProductTypeTest()
        {
            // Arrange
            var pr = new PhoneCaseRepository();
            var controller = new PhoneCaseController(null, pr);
            // Act
            string type = controller.GetProductType();
            // Assert
            Assert.AreEqual("Phone Case", type);
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

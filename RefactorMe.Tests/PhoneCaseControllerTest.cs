using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RefactorMe.Tests
{
    [TestClass]
    public class PhoneCaseControllerTest
    {
        [TestMethod()]
        public void GetProductTypeTest()
        {
            // Arrange
            var controller = new PhoneCaseController(null, null,null);
            // Act
            string type = controller.GetProductType();
            // Assert
            Assert.AreEqual("Phone Case", type);
        }
    }
}

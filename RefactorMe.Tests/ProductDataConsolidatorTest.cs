using RefactorMe;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactorMe.DontRefactor.Models;

namespace RefactorMe.Tests
{
    [TestClass]
    public class ProductDataConsolidatorTest
    {
        [TestMethod]
        public void CanGetProductList()
        {
            // Arrange
            // Act
            var list = ProductDataConsolidator.Get();
            var listUS = ProductDataConsolidator.GetInUSDollars();
            var listEURO = ProductDataConsolidator.GetInEuros();
            // Assert
            CollectionAssert.AllItemsAreNotNull(list);
            CollectionAssert.AllItemsAreNotNull(listUS);
            CollectionAssert.AllItemsAreNotNull(listEURO);
            CollectionAssert.AreNotEqual(list, listUS);
            CollectionAssert.AreNotEqual(list, listEURO);
        }
    }
}

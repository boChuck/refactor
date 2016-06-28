using RefactorMe;
using System;
using RefactorMe.DontRefactor.Models;
using Ninject;
using System.Reflection;
using RefactorMe.DontRefactor.Data.Implementation;
using RefactorMe.Controller;
using Ninject.Parameters;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
using RefactorMe.ExchangeRate;
using RefactorMe.Tests.Helper;

namespace RefactorMe.Tests
{
    [TestFixture]
    public class ProductDataConsolidatorTest : TestBase
    {
       
        [Test]
        public void CanGetProductListUSDollar()
        {

            // Arrange
            var currency = kernel.Get<RateUS>();

            var collector = GetCollector(currency);


            // Act
            var consolidator = new ProductDataConsolidator(collector);
            var lists = consolidator.Get();
            // Assert
            CollectionAssert.AllItemsAreNotNull(lists);
            CollectionAssert.AllItemsAreInstancesOfType(lists, typeof(Product));
            CollectionAssert.AreEqual(GetNormalPriceProducts(), lists, new USPriceComparer());

        }

        [Test]
        public void CanGetProductListEURODollar()
        {

            // Arrange
            var currency = kernel.Get<RateEuro>();

            var collector = GetCollector(currency);

            // Act
            var consolidator = new ProductDataConsolidator(collector);
            var lists = consolidator.Get();
            // Assert
            CollectionAssert.AllItemsAreNotNull(lists);
            CollectionAssert.AllItemsAreInstancesOfType(lists, typeof(Product));
            CollectionAssert.AreEqual(GetNormalPriceProducts(), lists, new EUROPriceComparer());
        }

        [Test]
        public void CanGetProductListNormalPrice()
        {

            // Arrange
            var currency = kernel.Get<NormalRate>();
           
            var collector = GetCollector(currency);

            // Act
            var consolidator = new ProductDataConsolidator(collector);
            var lists = consolidator.Get();
            // Assert
            CollectionAssert.AllItemsAreNotNull(lists);
            CollectionAssert.AllItemsAreInstancesOfType(lists, typeof(Product));
            CollectionAssert.AreEqual(GetNormalPriceProducts(), lists, new NormalPriceComparer());
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCCMS.Controllers;
using MVCCMS.EntityFramework.Repositories;
using System.Web.Mvc;
using MVCCMS.Models.EntityModels;

namespace MVCCMS.tests
{
    [TestClass]
    public class ProductControllerTests
    {
        [TestMethod]
        public void ProductsControllerCreateAddsProductObject()
        {
            // Arrange
            var repo = new TestStoreRepository();
            var productController = new ProductsController(repo);
            var product = new Product { Name = "Test Product", Price = 100 };

            // Act
            var result = productController.Create(product) as ViewResult;

            // Assert
            Assert.AreEqual(product, result.Model);
        }
    }
}

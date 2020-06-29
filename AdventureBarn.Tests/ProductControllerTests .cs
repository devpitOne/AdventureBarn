using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using AdventureBarn.Contracts.Models;
using AdventureBarn.Contracts.Repositories;
using AdventureBarn.WorkSite.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AdventureBarn.Tests
{
    [TestClass]
    public class ProductControllerTests
    {
        private ProductController _productController;

        [TestInitialize]
        public void TestSetup()
        {            
        }

        [TestCleanup]
        public void TestTeardown()
        {
            _productController = null;
        }

        [TestMethod]
        public void ProductCreateTest()
        {
            //setup
            var product = new Product();

            var repo = new Mock<IGenericRepository<Product>>();
            repo.Setup(x => x.Create(product));
            _productController = new ProductController(repo.Object);

            //execute
            _productController.Create(product);

            //assert
            repo.Verify(x => x.Create(product), Times.Once);
        }

        [TestMethod]
        public void ProductRetrieveTest()
        {
            //setup
            var id = 1;
            var product = new Product { Id = id };

            var repo = new Mock<IGenericRepository<Product>>();
            repo.Setup(x => x.GetByID(id)).Returns(product);
            _productController = new ProductController(repo.Object);

            //execute
            _productController.Details(id);

            //assert
            repo.Verify(x => x.GetByID(id), Times.Once);
        }

        [TestMethod]
        public void ProductIndexTest()
        {
            //setup
            var id = 1;
            var product = new Product { Id = id };

            var repo = new Mock<IGenericRepository<Product>>();
            repo.Setup(x => x.GetAll()).Returns(new List<Product> { product });
            _productController = new ProductController(repo.Object);

            //execute
            _productController.Index();

            //assert
            repo.Verify(x => x.GetAll(), Times.Once);
        }

        [TestMethod]
        public void ProductUpdateTest()
        {
            //setup
            var id = 1;
            var product = new Product { Id = id };

            var repo = new Mock<IGenericRepository<Product>>();
            repo.Setup(x => x.Update(product));
            _productController = new ProductController(repo.Object);

            //execute
            _productController.Edit(product);

            //assert
            repo.Verify(x => x.Update(product), Times.Once);
        }

        [TestMethod]
        public void ProductDeleteTest()
        {
            //setup
            var id = 1;
            var product = new Product { Id = id };

            var repo = new Mock<IGenericRepository<Product>>();
            repo.Setup(x => x.Delete(id));
            _productController = new ProductController(repo.Object);

            //execute
            _productController.DeleteConfirmed(id);

            //assert
            repo.Verify(x => x.Delete(id), Times.Once);
        }
    }
}

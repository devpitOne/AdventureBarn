using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AdventureBarn.Contracts.Models;
using AdventureBarn.Contracts.Repositories;
using AdventureBarn.WorkSite.Controllers;
using CommonServiceLocator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AdventureBarn.Tests
{
    [TestClass]
    public class SupplierControllerTests
    {
        private SupplierController _supplierController;

        [TestInitialize]
        public void TestSetup()
        {
        }

        [TestCleanup]
        public void TestTeardown()
        {
            _supplierController = null;
        }

        [TestMethod]
        public void SupplierCreateTest()
        {
            //setup
            var supplier = new Supplier();

            var repo = new Mock<IGenericRepository<Supplier>>();
            repo.Setup(x => x.Create(supplier));
            _supplierController = new SupplierController(repo.Object);

            //execute
            _supplierController.Create(supplier);

            //assert
            repo.Verify(x => x.Create(supplier), Times.Once);
        }

        [TestMethod]
        public void SupplierRetrieveTest()
        {
            //setup
            var id = 1;
            var supplier = new Supplier { Id = id };

            var repo = new Mock<IGenericRepository<Supplier>>();
            repo.Setup(x => x.GetByID(id)).Returns(supplier);
            _supplierController = new SupplierController(repo.Object);

            //execute
            _supplierController.Details(id);

            //assert
            repo.Verify(x => x.GetByID(id), Times.Once);
        }

        [TestMethod]
        public void SupplierIndexTest()
        {
            //setup
            var id = 1;
            var supplier = new Supplier { Id = id };

            var repo = new Mock<IGenericRepository<Supplier>>();
            repo.Setup(x => x.GetAll()).Returns(new List<Supplier> { supplier });
            _supplierController = new SupplierController(repo.Object);

            //execute
            _supplierController.Index();

            //assert
            repo.Verify(x => x.GetAll(), Times.Once);
        }

        [TestMethod]
        public void SupplierUpdateTest()
        {
            //setup
            //Mock Resolver and Address Controller  
            var mockResolver = new Mock<IDependencyResolver>();
            var repoAddress = new Mock<IGenericRepository<Address>>();
            var mockAddressController = new Mock<AddressController>(repoAddress.Object);
            mockResolver.Setup(resolver => resolver.GetService(typeof(AddressController))).Returns(mockAddressController.Object);
            DependencyResolver.SetResolver(mockResolver.Object);

            //Mock Repo
            var repo = new Mock<IGenericRepository<Supplier>>();
            var id = 1;
            var supplier = new Supplier { Id = id };
            repo.Setup(x => x.Update(supplier));
            var request = new Mock<HttpRequestBase>();
            request.Setup(x => x.RequestContext).Returns(new System.Web.Routing.RequestContext());
            request.SetupGet(x => x.Headers).Returns(
                new System.Net.WebHeaderCollection {
                 {"X-Requested-With", "XMLHttpRequest"}
            });
            var context = new Mock<HttpContextBase>();
            context.SetupGet(x => x.Request).Returns(request.Object);
            //Create object to test
            _supplierController = new SupplierController(repo.Object);
            _supplierController.ControllerContext = new ControllerContext(context.Object, new RouteData(), _supplierController);

            //execute
            _supplierController.Edit(supplier);

            //assert
            repo.Verify(x => x.Update(supplier), Times.Once);
        }

        [TestMethod]
        public void SupplierDeleteTest()
        {
            //setup
            var id = 1;
            var supplier = new Supplier { Id = id };

            var repo = new Mock<IGenericRepository<Supplier>>();
            repo.Setup(x => x.Delete(id));
            _supplierController = new SupplierController(repo.Object);

            //execute
            _supplierController.DeleteConfirmed(id);

            //assert
            repo.Verify(x => x.Delete(id), Times.Once);
        }
    }
}

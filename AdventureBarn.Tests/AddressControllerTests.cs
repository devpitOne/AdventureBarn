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
    public class AddressControllerTests
    {
        private AddressController _addressController;

        [TestInitialize]
        public void TestSetup()
        {            
        }

        [TestCleanup]
        public void TestTeardown()
        {
            _addressController = null;
        }

        [TestMethod]
        public void AddressCreateTest()
        {
            //setup
            var address = new Address();

            var repo = new Mock<IGenericRepository<Address>>();
            repo.Setup(x => x.Create(address));
            _addressController = new AddressController(repo.Object);

            //execute
            _addressController.Create(address);

            //assert
            repo.Verify(x => x.Create(address), Times.Once);
        }

        [TestMethod]
        public void AddressRetrieveTest()
        {
            //setup
            var id = 1;
            var address = new Address { Id = id };

            var repo = new Mock<IGenericRepository<Address>>();
            repo.Setup(x => x.GetByID(id)).Returns(address);
            _addressController = new AddressController(repo.Object);

            //execute
            _addressController.Details(id);

            //assert
            repo.Verify(x => x.GetByID(id), Times.Once);
        }

        [TestMethod]
        public void AddressIndexTest()
        {
            //setup
            var id = 1;
            var address = new Address { Id = id };

            var repo = new Mock<IGenericRepository<Address>>();
            repo.Setup(x => x.GetAll()).Returns(new List<Address> { address });
            _addressController = new AddressController(repo.Object);

            //execute
            _addressController.Index();

            //assert
            repo.Verify(x => x.GetAll(), Times.Once);
        }

        [TestMethod]
        public void AddressUpdateTest()
        {
            //setup
            var id = 1;
            var address = new Address { Id = id };

            var repo = new Mock<IGenericRepository<Address>>();
            repo.Setup(x => x.Update(address));
            _addressController = new AddressController(repo.Object);

            //execute
            _addressController.Edit(address);

            //assert
            repo.Verify(x => x.Update(address), Times.Once);
        }

        [TestMethod]
        public void AddressDeleteTest()
        {
            //setup
            var id = 1;
            var address = new Address { Id = id };

            var repo = new Mock<IGenericRepository<Address>>();
            repo.Setup(x => x.Delete(id));
            _addressController = new AddressController(repo.Object);

            //execute
            _addressController.DeleteConfirmed(id);

            //assert
            repo.Verify(x => x.Delete(id), Times.Once);
        }
    }
}

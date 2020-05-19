using ITP_App.ApplicationLogic.Abstractions;
using ITP_App.ApplicationLogic.DataModel;
using ITP_App.ApplicationLogic.Exceptions;
using ITP_App.ApplicationLogic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITP_App.ApplicationLogic.Tests.Services
{
    [TestClass]
    public class AdminsServiceUnitTests
    {
        private AdminsService adminsService;
        private Mock<IAdminRepository> adminRepositoryMock;
        private Mock<ICarRepository> carRepositoryMock;
        private Mock<IOwnerRepository> ownerRepositoryMock;
        private Mock<IRuleRepository> ruleRepositoryMock;

        //Setup
        [TestInitialize]
        public void Setup()
        {
            adminRepositoryMock = new Mock<IAdminRepository>();
            carRepositoryMock = new Mock<ICarRepository>();
            ownerRepositoryMock = new Mock<IOwnerRepository>();
            ruleRepositoryMock = new Mock<IRuleRepository>();
        }

        [TestMethod]
        public void GetAdminById_ThrowsException_InvalidId()
        {
            adminsService = new AdminsService(adminRepositoryMock.Object, carRepositoryMock.Object,
                ownerRepositoryMock.Object, ruleRepositoryMock.Object);

            var invalidAdminId = "invalid";
            Assert.ThrowsException<Exception>(() =>
            {
                adminsService.GetAdminById(invalidAdminId);
            });
        }

        [TestMethod]
        public void GetAdminById_ThrowsEntityNotFound_AdminDoesntExist()
        {
            var nonExistingAdmin = Guid.NewGuid().ToString();
            var existingAdmin = Guid.NewGuid();

            var admin = new Admin {
                Id = existingAdmin,
                FirstName = "firstName",
                LastName = "lastName",
                Email = "admin@email.com"
            };

            adminRepositoryMock.Setup(adminRepositoryMock => adminRepositoryMock.GetAdminByUserId(existingAdmin)).Returns(admin);

            adminsService = new AdminsService(adminRepositoryMock.Object, carRepositoryMock.Object,
                ownerRepositoryMock.Object, ruleRepositoryMock.Object);

            Assert.ThrowsException<EntityNotFoundException>(()=>
            {
                adminsService.GetAdminById(nonExistingAdmin);
            });
        }

        [TestMethod]
        public void GetAdminById_Returns_AdminExists()
        {
            var existingAdminId = Guid.NewGuid();

            var admin = new Admin
            {
                Id = existingAdminId,
                UserId = Guid.NewGuid(),
                FirstName = "firstName",
                LastName = "lastName"
            };

            adminRepositoryMock.Setup(adminRepositoryMock => adminRepositoryMock.GetAdminByUserId(existingAdminId)).Returns(admin);

            adminsService = new AdminsService(adminRepositoryMock.Object, carRepositoryMock.Object,
                ownerRepositoryMock.Object, ruleRepositoryMock.Object);

            var searchedAdmin = adminsService.GetAdminById(existingAdminId.ToString());

            Assert.IsNotNull(searchedAdmin);
        }

        [TestMethod]
        public void GetRules()
        {
            adminsService = new AdminsService(adminRepositoryMock.Object, carRepositoryMock.Object,
                ownerRepositoryMock.Object, ruleRepositoryMock.Object);

            Assert.IsNotNull(adminsService.GetRules());
        }

        [TestMethod]
        public void GetRules_ThrowsNullReferenceException()
        {
            Assert.ThrowsException<NullReferenceException>(() =>
            {
                adminsService.GetRules();
            });
        }

        [TestMethod]
        public void GetCars()
        {
            adminsService = new AdminsService(adminRepositoryMock.Object, carRepositoryMock.Object,
                ownerRepositoryMock.Object, ruleRepositoryMock.Object);

            Assert.IsNotNull(adminsService.GetCars());
        }

        [TestMethod]
        public void GetCars_ThrowsNullReferenceException()
        {
            Assert.ThrowsException<NullReferenceException>(() =>
            {
                adminsService.GetCars();
            });
        }

        [TestMethod]
        public void GetCarByCivSeries()
        {
            adminsService = new AdminsService(adminRepositoryMock.Object, carRepositoryMock.Object,
                ownerRepositoryMock.Object, ruleRepositoryMock.Object);

            Assert.IsNotNull(adminsService.GetCarByCivSeries("civseriesI"));
        }

        [TestMethod]
        public void GetCarByCivSeries_ThrowsNullReferenceException()
        {
             Assert.ThrowsException<NullReferenceException>(() =>
            {
                adminsService.GetCarByCivSeries("civseriesI");
            });
        }

        [TestMethod]
        public void GetCarByBodySeries()
        {
            adminsService = new AdminsService(adminRepositoryMock.Object, carRepositoryMock.Object,
                ownerRepositoryMock.Object, ruleRepositoryMock.Object);

            Assert.IsNotNull(adminsService.GetCarByBodySeries("bodyseriesI"));
        }

        [TestMethod]
        public void GetCarByBodySeries_ThrowsNullReferenceException()
        {
            Assert.ThrowsException<NullReferenceException>(() =>
            {
                adminsService.GetCarByBodySeries("bodyseriesI");
            });
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ITP_App.ApplicationLogic.Abstractions;
using ITP_App.ApplicationLogic.DataModel;
using ITP_App.ApplicationLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using ITP_App.ApplicationLogic.Services;

namespace ITP_App.ApplicationLogic.Tests.Services
{
    [TestClass]
    public class ClientsServiceUnitTests
    {

        private ClientsService clientsService;
        private AdminsService adminsService;
        private Mock<IClientRepository> clientRepositoryMock;
        private Mock<IAdminRepository> adminRepositoryMock;
        private Mock<IReviewRepository> reviewRepositoryMock;
        private Mock<ICarRepository> carRepositoryMock;


        //Setup
        [TestInitialize]
        public void Setup()
        {
            clientRepositoryMock = new Mock<IClientRepository>();
            adminRepositoryMock = new Mock<IAdminRepository>();
            reviewRepositoryMock = new Mock<IReviewRepository>();
            carRepositoryMock = new Mock<ICarRepository>();
      
        }

        [TestMethod]
        public void GetClientById_ThrowsException_InvalidId()
        {
            clientsService = new ClientsService(clientRepositoryMock.Object, reviewRepositoryMock.Object);

            var invalidClientId = "invalid";
            Assert.ThrowsException<Exception>(() =>
            {
                clientsService.GetClientById(invalidClientId);
            });
        }

        [TestMethod]
        public void GetClientById_ThrowsEntityNotFound_ClientDoesntExist()
        {
            var nonExistingClient = Guid.NewGuid().ToString();
            var existingClient = Guid.NewGuid();

            var client = new Client
            {
                Id = existingClient,
                FirstName = "firstName",
                LastName = "lastName"
            };

            clientRepositoryMock.Setup(clientRepositoryMock => clientRepositoryMock.GetClientByUserId(existingClient)).Returns(client);

            clientsService = new ClientsService(clientRepositoryMock.Object, reviewRepositoryMock.Object);

            Assert.ThrowsException<EntityNotFoundException>(() =>
            {
                clientsService.GetClientById(nonExistingClient);
            });
        }

        [TestMethod]
        public void GetClientById_Returns_ClientExists()
        {
            var existingClientId = Guid.NewGuid();

            var client = new Client
            {
                Id = existingClientId,
                UserId = Guid.NewGuid(),
                FirstName = "firstName",
                LastName = "lastName"
            };

            clientRepositoryMock.Setup(clientRepositoryMock => clientRepositoryMock.GetClientByUserId(existingClientId)).Returns(client);

            clientsService = new ClientsService(clientRepositoryMock.Object, reviewRepositoryMock.Object);

            var searchedClient = clientsService.GetClientById(existingClientId.ToString());

            Assert.IsNotNull(searchedClient);
        }

        [TestMethod]
        public void GetReviews()
        {
            clientsService = new ClientsService(clientRepositoryMock.Object, reviewRepositoryMock.Object);
            Assert.IsNotNull(clientsService.GetReviews());
        }

        [TestMethod]
        public void GetReviews_ThrowsNullReferenceException()
        {
            Assert.ThrowsException<NullReferenceException>(() =>
            {
                clientsService.GetReviews();
            });
        }
    }
}

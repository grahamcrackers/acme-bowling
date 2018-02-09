using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using ACME.Domain;
using Moq;

namespace ACME.Tests.Isolated.Core
{
    [TestClass]
    public class AddGameServiceTests
    {
        private Mock<IGameRepository> _mockGameRepository;
        private Mock<IRemoteDataService> _mockRemoteDataService;
        private AddGameService _addGameService;

        [TestInitialize]
        public void Setup()
        {
            _mockGameRepository = new Mock<IGameRepository>();
            _mockRemoteDataService = new Mock<IRemoteDataService>();

            _addGameService = new AddGameService(
                            _mockGameRepository.Object,
                            _mockRemoteDataService.Object
                            );
        }

        [TestMethod]
        public void invalid_code_throws_an_error()
        {
            //_mockRemoteDataService.Setup(repo => repo.GetByCode("111")).Returns(new GameEntity { error })
            var result = Assert.ThrowsException<Exception>(() => _addGameService.AddWithCode("111"));
            Assert.AreEqual("invalid_ubs_code", result.Message);
        }

        [TestMethod]
        public void adding_code_that_has_already_been_added_throws_an_error()
        {
            _mockGameRepository.Setup(repo => repo.GetByCode("1111")).Returns(new GameEntity { });
            var result = Assert.ThrowsException<Exception>(() => _addGameService.AddWithCode("1111"));
            Assert.AreEqual("ubs_code_already_added", result.Message);
        }

        [TestMethod]
        public void adding_game_that_does_not_exist_in_external_service_throws_error()
        {
            //_mockRemoteDataService.Setup(service => service.Retrieve("1116"))
            //    .Throws(new Exception("not_found"));
            _mockRemoteDataService.Setup(service => service.Retrieve("1116"))
                .Returns((GameData) null);

            var result = Assert.ThrowsException<Exception>(() => _addGameService.AddWithCode("1116"));

            Assert.AreEqual("ubs_code_does_not_exist", result.Message);
        }

        [TestMethod]
        public void store_game_after_retrieving_from_remote_service()
        {
            _mockRemoteDataService.Setup(service => service.Retrieve("1111"))
                .Returns(new GameData
                {
                    Date = "2017/01/01",
                    Rolls = "11111111111111111111"
                });

            _addGameService.AddWithCode("1111");

            _mockGameRepository.Verify(
                repo => repo.Add(It.Is<GameEntity>(
                    entity =>
                        entity.Code == "1111" &&
                        entity.Rolls == "11111111111111111111"
                    )));
        }
    }
}

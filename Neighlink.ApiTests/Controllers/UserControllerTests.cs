using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Neighlink.Api.Contracts;
using Neighlink.Api.Controllers;
using Neighlink.Entity;
using Neighlink.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neighlink.Api.Controllers.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        UserController target;
        Mock<IUserService> userService;
        Mock<IBuildingService> buildingService;

        [TestInitialize]
        public void Initialize() 
        {
            userService = new Mock<IUserService>();
            buildingService = new Mock<IBuildingService>();

            target = new UserController(userService.Object, buildingService.Object);
        }

        [TestMethod()]
        public void UserControllerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AuthenticateTest_HappyPath_UserLogsIn()
        {
            //Arrange
            string expectedEmail = "nuevo@gmail.com";
            string expectedPassword = "1234";
            int expectedCondo = 1;

            User expectedUser = new User() { Email = expectedEmail };
            userService.Setup(x => x.Authenticate(expectedEmail, expectedPassword)).Returns(expectedUser);

            LoginRequest expectedRequest = new LoginRequest() { Email = expectedEmail, Password = expectedPassword, CondominiumId = expectedCondo };

            //Act
            var result = target.Authenticate(expectedRequest);
            var okResult = result as OkObjectResult;

            //Assert
            Assert.AreEqual(expectedUser, okResult.Value as User);
        }

        [TestMethod()]
        public void PostTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetUsersTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PutTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }
    }
}
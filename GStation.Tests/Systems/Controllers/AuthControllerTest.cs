using FluentAssertions;
using GStation.Api.Controllers;
using GStation.Services.Interfaces;
using GStation.Tests.Mocks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace GStation.Tests.Systems.Controllers
{
    public class AuthControllerTest
    {
        [Fact]
        public async Task Login_OnSuccess_ReturnsStatus200()
        {
            // Arrange

            var authServiceMock = new Mock<IAuthService>();
            authServiceMock
                .Setup(service => service.Login(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(AuthMocks.GetUserLoginTokenDto);

            var autoMapperMock = AutoMapperMocks.GetAutoMapper();

            var sut = new AuthController(authServiceMock.Object, autoMapperMock);

            // Act

            var result = await sut.Login(AuthMocks.GetUserLoginDto);

            var objectResult = (OkObjectResult)result;

            // Assert

            objectResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        }
    }
}

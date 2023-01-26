using Xunit;
using FluentAssertions;
using Moq;
using GStation.Api.Controllers;
using GStation.Services.Interfaces;
using GStation.Tests.Mocks;
using Microsoft.AspNetCore.Mvc;

namespace GStation.Tests.Systems.Controllers;

public class AuthControllerTest 
{
    [Fact]
    public async Task ShouldReturnStatus200_OnSuccess()
    {
        // Given
        var authServiceMock = new Mock<IAuthService>();
        authServiceMock
            .Setup(service => service.Login(It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync(AuthMocks.GetUserLoginTokenDto);

        var autoMapperMock = AutoMapperMocks.GetMock();

        var sut = new AuthController(authServiceMock.Object, autoMapperMock);

        // When
        var result = await sut.Login(AuthMocks.GetUserLoginDto);

        // Then
        result.Should().BeOfType(typeof(ActionResult));
    }
}
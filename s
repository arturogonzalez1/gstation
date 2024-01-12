[1mdiff --git a/GStation.Tests/Systems/Controllers/AuthControllerTest.cs b/GStation.Tests/Systems/Controllers/AuthControllerTest.cs[m
[1mindex 82627d0..4c1a06d 100644[m
[1m--- a/GStation.Tests/Systems/Controllers/AuthControllerTest.cs[m
[1m+++ b/GStation.Tests/Systems/Controllers/AuthControllerTest.cs[m
[36m@@ -1,5 +1,7 @@[m
 ﻿using FluentAssertions;[m
 using GStation.Api.Controllers;[m
[32m+[m[32musing GStation.Core.Props.Constants;[m
[32m+[m[32musing GStation.Core.Props;[m
 using GStation.Services.Interfaces;[m
 using GStation.Tests.Mocks;[m
 using Microsoft.AspNetCore.Http;[m
[36m@@ -34,5 +36,28 @@[m [mnamespace GStation.Tests.Systems.Controllers[m
 [m
             objectResult.StatusCode.Should().Be(StatusCodes.Status200OK);[m
         }[m
[32m+[m
[32m+[m[32m        [Fact][m
[32m+[m[32m        public async Task Login_OnInvalidCredentials_ShouldRetursAnError()[m
[32m+[m[32m        {[m
[32m+[m[32m            // Arrange[m
[32m+[m
[32m+[m[32m            var authServiceMock = new Mock<IAuthService>();[m
[32m+[m[32m            authServiceMock[m
[32m+[m[32m                .Setup(service => service.Login(It.IsAny<string>(), It.IsAny<string>()))[m
[32m+[m[32m                .ThrowsAsync(new CustomValidationException(ErrorConstants.INVALID_CREDENTIALS));[m
[32m+[m
[32m+[m[32m            var autoMapperMock = AutoMapperMocks.GetAutoMapper();[m
[32m+[m
[32m+[m[32m            var sut = new AuthController(authServiceMock.Object, autoMapperMock);[m
[32m+[m
[32m+[m[32m            // Act[m
[32m+[m
[32m+[m[32m            var ex = await Assert.ThrowsAsync<CustomValidationException>(async () => await sut.Login(AuthMocks.GetUserLoginDto));[m
[32m+[m
[32m+[m[32m            // Assert[m
[32m+[m
[32m+[m[32m            ex.Should().BeOfType<CustomValidationException>();[m
[32m+[m[32m        }[m
     }[m
 }[m

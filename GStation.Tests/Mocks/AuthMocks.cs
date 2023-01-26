using GStation.Core.Models.DTOs;
using GStation.Core.Props.Constants;

namespace GStation.Tests.Mocks;

public static class AuthMocks
{
    public static UserLoginTokenDto GetUserLoginTokenDto 
        => new UserLoginTokenDto
            {
                CompleteName = "John Doe",
                Email = "johndoe@example.com",
                Expiration = DateTime.UtcNow.AddDays(1),
                Role = Role.SUPERADMIN,
                Token = JwtMocks.GetToken,
                UserId = "3b0c779c-7635-4126-b01e-da7993866779",
            };

    public static UserLoginDto GetUserLoginDto =>
        new UserLoginDto
        {
            Email = "johndoe@example.com",
            Password = "mypassword",
        };
}
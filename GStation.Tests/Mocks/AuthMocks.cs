using GStation.Core.Models.DTOs;
using GStation.Core.Props.Constants;

namespace GStation.Tests.Mocks
{
    internal static class AuthMocks
    {
        public static UserLoginDto GetUserLoginDto =>
            new UserLoginDto
            {
                Email = "johndoe@example.com",
                Password = "mypassword"
            };

        public static UserLoginTokenDto GetUserLoginTokenDto =>
            new UserLoginTokenDto
            {
                CompleteName = "John Doe",
                Email = "johndoe@example.com",
                Expiration = DateTime.UtcNow.AddDays(1),
                Role = Role.SUPERADMIN,
                UserId = "5892c9e5-4a10-4c1f-9103-14319ba633f0",
                Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"
            };
    }
}

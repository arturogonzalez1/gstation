using System.IdentityModel.Tokens.Jwt;

namespace GStation.Api.Helpers
{
    public static class HtttpHelpers
    {
        public static string GetToken(this HttpContext context)
        {
            return context.Request.Headers["Authorization"]
                .ToString()
                .Replace("Bearer ", "")
                .Replace("bearer ", "");

        }

        public static string GetUserId(this string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            return jwtToken.Payload["userId"].ToString();
        }
    }
}

namespace GStation.Core.Models.DTOs
{
    public class UserLoginTokenDto
    {
        public UserLoginTokenDto(string token, DateTime expiration)
        {
            Token = token;
            Expiration = expiration;
        }

        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}

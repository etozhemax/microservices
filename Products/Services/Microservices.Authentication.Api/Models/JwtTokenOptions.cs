namespace Microservices.Authentication.Api.Models
{
    public class JwtTokenOptions
    {
        public required string Secret { get; set; }
        public required string Issuer { get; set; }
        public required string Audience { get; set; }
    }
}

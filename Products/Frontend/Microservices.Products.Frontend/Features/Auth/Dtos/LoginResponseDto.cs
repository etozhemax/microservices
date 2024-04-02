namespace Microservices.Products.Frontend.Features.Auth.Dtos
{
    public class LoginResponseDto
    {
        public UserDto? User { get; set; }
        public string? Token { get; set; }
    }
}
